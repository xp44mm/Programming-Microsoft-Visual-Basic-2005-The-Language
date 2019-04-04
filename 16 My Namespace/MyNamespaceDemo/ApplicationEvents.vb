#If _MyType = "WindowsForms" Then

Namespace My

   ' The following events are availble for MyApplication:
   ' 
   ' Startup: Raised when the application starts, before the startup form is created.
   ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
   ' UnhandledException: Raised if the application encounters an unhandled exception.
   ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
   ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
   Partial Friend Class MyApplication
      Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Me.Shutdown
         ' Save all data when the application shuts down.
         '…
      End Sub

      Private Sub MyApplication_Startup(ByVal sender As Object, _
            ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) _
            Handles Me.Startup
         ' Refuse to activate this program from 6 pm to 8 am.
         If Now.TimeOfDay > New TimeSpan(18, 0, 0) OrElse Now.TimeOfDay < New TimeSpan(8, 0, 0) Then
            ' Uncomment next line to actually activate this feature.
            ' e.Cancel = True
         End If
      End Sub

      Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal _
            e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) _
            Handles Me.StartupNextInstance
         If e.CommandLine.Count >= 1 Then
            Dim documentFile As String = e.CommandLine(0)
            ' Load the requested document inside the current instance.
            '…
         End If
      End Sub

      Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal _
            e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) _
            Handles Me.UnhandledException
         ' Log the exception, then ask the user if she wants to exit.
         My.Application.Log.WriteException(e.Exception)
         Dim msg As String = e.Exception.Message & ControlChars.CrLf & _
            "Do you want to exit the application?"
         If MessageBox.Show(msg, "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) _
               = DialogResult.Yes Then
            e.ExitApplication = True
         Else
            e.ExitApplication = False
         End If
      End Sub

      Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, _
            ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) _
            Handles Me.NetworkAvailabilityChanged
         Debug.WriteLine("MyApplication_NetworkAvailabilityChanged event")
         If e.IsNetworkAvailable Then
            ' Connect the application to network resources.
            '…
         Else
            ' Disconnect the application from network resources.
            '…
         End If
      End Sub

   End Class

End Namespace

#End If