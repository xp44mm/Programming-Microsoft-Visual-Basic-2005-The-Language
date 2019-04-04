Public Class ClipboardWrapperEx
   Inherits ClipboardWrapper2

   ' Insert here regular methods, some of which may allocate additional
   ' unmanaged resources.
   '…
   ' The only method we need to override to implement the Dispose-Finalize
   ' pattern for this class.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      ' Exit now if the object has been already disposed.
      ' (The disposed variable is declared as Protected in the base class.) 
      If disposed Then Exit Sub

      Try
         If disposing Then
            ' The object is being disposed, not finalized. It is safe to access other
            ' other objects (other than the base object) only from inside this block.
            '…
         End If

         ' Perform clean up chores that have to be executed in either case.
         '…
      Finally
         ' Call the base class's Dispose method in all cases.
         MyBase.Dispose(disposing)
      End Try
   End Sub
End Class
