Public Class ClipboardWrapper2
   Implements IDisposable

   Private Declare Function OpenClipboard Lib "user32" _
       Alias "OpenClipboard" (ByVal hwnd As Integer) As Integer
   Private Declare Function CloseClipboard Lib "user32" _
       Alias "CloseClipboard" () As Integer

   ' Remember whether the clipboard is currently open.
   Dim isOpen As Boolean
   ' Remember whether the object has been already disposed.
   ' (Protected makes it available to derived classes.)
   Protected disposed As Boolean

   Public Sub New()
      ' Don't invoke Finalize unless the Open method is actually invoked.
      GC.SuppressFinalize(Me)
   End Sub

   ' Open the clipboard and associate it with a window.
   Public Sub Open(ByVal hWnd As Integer)
      ' OpenClipboard returns 0 if any error.
      If OpenClipboard(hWnd) = 0 Then Throw New Exception("Unable to open clipboard")
      isOpen = True
      ' Register the Finalize method, in case clients forget to call Close or Dispose.
      GC.ReRegisterForFinalize(Me)
   End Sub

   Public Sub Close()
      Dispose()               ' Delegate to private Dispose method.
   End Sub

   Private Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
      ' Remember that the object has been disposed.
      disposed = True
      ' Tell .NET not to call the Finalize method.
      GC.SuppressFinalize(Me)
   End Sub

   Protected Overrides Sub Finalize()
      Dispose(False)
   End Sub

   Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      ' Exit if the object has been already disposed.
      If disposed Then Exit Sub

      If disposing Then
         ' The object is being disposed, not finalized. It is safe to access other
         ' other objects (other than the base object) only from inside this block.
         '…
      End If

      ' Perform cleanup chores that have to be executed in either case.
      CloseClipboard()
      isOpen = False
   End Sub
End Class
