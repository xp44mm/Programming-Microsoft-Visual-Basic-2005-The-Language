Imports System.Windows.Forms

Public Class MouseCursor
   Implements IDisposable

   Dim control As Control
   Dim oldCursor As Cursor

   Public Sub New(ByVal ctrl As Control, ByVal newCursor As Cursor)
      ' Remember control and old cursor, and then enforce new cursor.
      control = ctrl
      oldCursor = ctrl.Cursor
      control.Cursor = newCursor
   End Sub

   Public Sub Restore() Implements IDisposable.Dispose
      ' Restore the original cursor.
      control.Cursor = oldCursor
   End Sub
End Class
