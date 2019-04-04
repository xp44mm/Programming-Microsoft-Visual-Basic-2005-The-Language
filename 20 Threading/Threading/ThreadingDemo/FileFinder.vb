Imports System.Threading
Imports System.IO

Class FileFinder
   Public StartPath As String       ' The starting search path
   Public SearchPattern As String   ' The search pattern 

   Sub StartSearch()
      Search(Me.StartPath)
      ' Decrease the number of running threads before exiting.
      Interlocked.Decrement(searchingThreads)
      ' Let the consumer know it should check thread counter.
      are.Set()
   End Sub

   ' This recursive procedure does the actual job.
   Sub Search(ByVal path As String)
      Try
         ' Get all the files that match the search pattern.
         Dim files() As String = Directory.GetFiles(path, SearchPattern)
         ' If there is at least one file, let the main thread know about it.
         If files IsNot Nothing AndAlso files.Length > 0 Then
            ' Ensure found files are added as an atomic operation.
            SyncLock lockObj
               ' Add all found files.
               fileList.AddRange(files)
               ' Let the consumer thread know about the new filenames.
               are.Set()
            End SyncLock
         End If

         ' Repeat the search on all subdirectories.
         For Each dirname As String In Directory.GetDirectories(path)
            Search(dirname)
         Next
      Catch
         ' Do nothing if any error
      End Try
   End Sub
End Class
