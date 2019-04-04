Imports System.IO
Imports System.IO.Compression

Module Functions

   Sub DisplayDirTree(ByVal dir As String, ByVal showFiles As Boolean, _
         Optional ByVal level As Integer = 0)
      ' Display the name of this directory with correct indentation.
      Console.WriteLine(New String("-"c, level * 2) & dir)

      Try
         ' Display all files in this directory with correct indentation.
         If showFiles Then
            For Each fname As String In Directory.GetFiles(dir)
               Console.WriteLine(New String(" "c, level * 2 + 2) & fname)
            Next
         End If
         ' A recursive call for all the subdirectories in this directory
         For Each subdir As String In Directory.GetDirectories(dir)
            DisplayDirTree(subdir, showFiles, level + 1)
         Next
      Catch
         ' Do nothing if any error (presumably "Drive not ready").
      End Try
   End Sub

   Sub CompressFile(ByVal uncompressedFile As String, ByVal compressedFile As String)
      ' Open the source (uncompressed) file, using a 4K input buffer.
      Using inStream As New FileStream(uncompressedFile, FileMode.Open, _
            FileAccess.Read, FileShare.None, 4096)
         ' Open the destination (compressed) file with a FileStream object.
         Using outStream As New FileStream(compressedFile, FileMode.Create)
            ' Wrap a DeflateStream object around the output stream.
            Using zipStream As New DeflateStream(outStream, CompressionMode.Compress)
               ' Prepare a 4K read buffer .
               Dim buffer(4095) As Byte
               Do
                  ' Read up to 4K bytes from the input file, exit if no more bytes.
                  Dim readBytes As Integer = inStream.Read(buffer, 0, buffer.Length)
                  If readBytes = 0 Then Exit Do
                  ' Write the contents of the buffer to the compressed stream.
                  zipStream.Write(buffer, 0, readBytes)
               Loop
               ' Flush and close all streams.
               zipStream.Flush()
            End Using             ' Close the DeflateStream object.
         End Using                ' Close the output FileStream object.
      End Using                   ' Close the input FileStream object.
   End Sub

   Sub UncompressFile(ByVal compressedFile As String, ByVal uncompressedFile As String)
      ' Open the output (uncompressed) file, use a 4K output buffer.
      Using outStream As New FileStream(uncompressedFile, FileMode.Create, _
            FileAccess.Write, FileShare.None, 4096)
         ' Open the source (compressed) file.
         Using inStream As New FileStream(compressedFile, FileMode.Open)
            ' Wrap the DeflateStream object around the input stream.
            Using zipStream As New DeflateStream(inStream, CompressionMode.Decompress)
               ' Prepare a 4K buffer.
               Dim buffer(4095) As Byte
               Do
                  ' Read enough compressed bytes to fill the 4K buffer.
                  Dim bytesRead As Integer = zipStream.Read(buffer, 0, 4096)
                  ' Exit if no more bytes were read.
                  If bytesRead = 0 Then Exit Do
                  ' Else, write these bytes to the uncompressed file, and loop.
                  outStream.Write(buffer, 0, bytesRead)
               Loop
               ' Ensure that cached bytes are written correctly and close all streams.
               outStream.Flush()
            End Using             ' Close the DeflateStream object.
         End Using                ' Close the input FileStream object.
      End Using                   ' Close the output FileStream object.
   End Sub

End Module
