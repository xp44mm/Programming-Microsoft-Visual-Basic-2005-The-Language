Imports System.IO

Public Class CurrentDirectory
   Implements IDisposable

   Dim oldPath As String

   Public Sub New(ByVal newPath As String)
      ' Remember the current directory, and then change it.
      oldPath = Directory.GetCurrentDirectory()
      Directory.SetCurrentDirectory(newPath)
   End Sub

   Public Sub Restore() Implements IDisposable.Dispose
      ' Restore the original current directory.
      Directory.SetCurrentDirectory(oldPath)
   End Sub
End Class
