Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Module Module1

   Sub Main()
      Do
         ' Ask the end user for a name file.
         Console.Write("Enter a file name [an empty string to quit] >> ")
         Dim fileName As String = Console.ReadLine()

         ' This code assumes a server on local machine is listening to port 2048.
         Dim tcpCli As New Sockets.TcpClient("localhost", 2048)
         ' Retrieve the stream that can send and receive data.
         Dim ns As NetworkStream = tcpCli.GetStream()
         ' Send a CR-LF-termined string to the server.

         ' USE A BUFFERED STREAM !!!
         Dim bufStream As New BufferedStream(ns, 8192)
         Dim sw As New StreamWriter(bufStream)

         'Dim sw As New StreamWriter(ns)
         sw.WriteLine(fileName)
         sw.Flush()                          ' This is VERY important!

         If fileName <> "" Then
            ' Receive data from the server application and display it.
            Dim resultData As String = ReadData(ns)
            Console.WriteLine(resultData)
         End If
         ' Release resources and close the NetworkStream.
         sw.Close()
         ns.Close()
         If fileName = "" Then Exit Do
      Loop
   End Sub

   ' Read a length-prefixed string.
   Function ReadData(ByVal ns As NetworkStream) As String
      Dim sr As New StreamReader(ns)
      Dim dataLength As Integer = CInt(sr.ReadLine())
      Dim buffer(dataLength - 1) As Char
      sr.Read(buffer, 0, dataLength)
      sr.Close()
      Return New String(buffer)
   End Function


End Module
