Public Class WinResource
   Implements IDisposable

   ' A private field that creates a wrapper for the unmanaged resource
   Private wrapper As UnmanagedResourceWrapper = Nothing

   ' True if the object has been disposed of
   Private disposed As Boolean = False

   Public Sub New(ByVal someData As String)
      ' Allocate the unmanaged resource here.
      wrapper = New UnmanagedResourceWrapper(someData)
   End Sub

   ' A public method that clients call to work with the unmanaged resource
   Public Sub DoSomething()
      ' Throw an exception if the object has been already disposed of.
      If disposed Then
         Throw New ObjectDisposedException("")
      End If

      ' This code can pass the wrapper.Handle value to API calls.
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      ' Avoid issues when multiple threads call Dispose at the same time.
      SyncLock Me
         ' Do nothing if already disposed of.
         If disposed Then Return
         ' Dispose of all the disposable objects used by this instance
         ' including the one that wraps the unmanaged resource
         ' ...
         wrapper.Dispose()
         ' Remember this object has been disposed of.
         disposed = True
      End SyncLock
   End Sub

   ' The nested private class that allocates and releases the unmanaged resource.
   Private NotInheritable Class UnmanagedResourceWrapper
      Implements IDisposable
      ' An invalid handle value, that the wrapper class can use to check
      ' whether the handle is valid
      Public Shared ReadOnly InvalidHandle As New IntPtr(-1)

      ' A public field, but accessible only from inside the WinResource class 
      Public Handle As IntPtr = InvalidHandle

      ' The constructor takes some data and allocates the unmanaged resource (e.g. a file).
      Public Sub New(ByVal someData As String)
         ' This is just a demo...
         Me.Handle = New IntPtr(12345)
      End Sub

      Public Sub Dispose() Implements IDisposable.Dispose
         ' Exit now if this object didn't completed its constructor correctly.
         If Me.Handle = InvalidHandle Then Return

         ' Release the unmanaged resource.
         ' eg. CloseHandle(Handle)

         ' Finally, invalidate the handle.
         Me.Handle = InvalidHandle
         ' Tell the CLR not to call the Finalize method.
         GC.SuppressFinalize(Me)
      End Sub

      Protected Overrides Sub Finalize()
         Dispose()
      End Sub
   End Class
End Class
