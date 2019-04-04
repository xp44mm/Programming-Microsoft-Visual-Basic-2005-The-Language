Public Class ClipboardWrapper
   Implements IDisposable

   Private Declare Function OpenClipboard Lib "user32" _
       Alias "OpenClipboard" (ByVal hwnd As Integer) As Integer
   Private Declare Function CloseClipboard Lib "user32" _
       Alias "CloseClipboard" () As Integer

   ' Remember whether the clipboard is currently open.
   Dim isOpen As Boolean

   ' Open the clipboard and associate it with a window.
   Public Sub Open(ByVal hWnd As Integer)
      ' OpenClipboard returns 0 if any error.
      If OpenClipboard(hWnd) = 0 Then Throw New Exception("Unable to open clipboard")
      isOpen = True
   End Sub

   ' Close the clipboard - ignore the command if not open
   Public Sub Close()
      If isOpen Then CloseClipboard()
      isOpen = False
   End Sub

   Private Sub Dispose() Implements IDisposable.Dispose
      Close()
   End Sub

   Protected Overrides Sub Finalize()
      Close()
   End Sub
End Class
