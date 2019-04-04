Imports System.IO

Module Functions

   ' Display a string in the Debug window.
   Sub WriteToDebugWindow(ByVal msgText As String)
      Debug.WriteLine(msgText)
   End Sub

   ' Display a string in a pop-up message box.
   Sub PopupMsg(ByVal msgText As String)
      MsgBox(msgText)
   End Sub

   ' The delegate that defines the syntax of the function whose address
   ' can be passed to TraverseDirectoryTree
   Delegate Sub TraverseDirectoryTreeCallback(ByVal dirName As String)

   ' A reusable routine that visits all the folders in a directory tree
   ' and calls back the caller by passing the name of each folder
   Sub TraverseDirectoryTree(ByVal path As String, _
         ByVal cbk As TraverseDirectoryTreeCallback)
      For Each dirName As String In Directory.GetDirectories(path)
         ' Do the actual job by invoking the callback procedure.
         cbk.Invoke(dirName)
         ' Call this routine recursively to process subfolders.
         TraverseDirectoryTree(dirName, cbk)
      Next
   End Sub

   ' A delegate that defines the syntax of the function whose address
   ' can be passed to TraverseDirectoryTree2
   Delegate Function TraverseDirectoryTreeCallback2(ByVal dirName As String) As Boolean

   Function TraverseDirectoryTree2(ByVal path As String, _
         ByVal cbk As TraverseDirectoryTreeCallback2) As Boolean
      For Each dirName As String In Directory.GetDirectories(path)
         ' Invoke the callback function; exit if it canceled enumeration.
         Dim canceled As Boolean = cbk.Invoke(dirName)
         If canceled Then Return True
         ' Call this routine recursively; exit if enumeration was canceled.
         canceled = TraverseDirectoryTree2(dirName, cbk)
         If canceled Then Return True
      Next
   End Function


End Module
