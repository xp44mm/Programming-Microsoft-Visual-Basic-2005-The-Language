Public Class AppScheduler
   Private WithEvents Timer As New System.Windows.Forms.Timer
   Private exePath As String
   Private arguments As String

   Public Sub New(ByVal exePath As String, ByVal arguments As String, _
         ByVal milliseconds As Integer)
      ' Remember application's path and arguments for later.
      Me.exePath = exePath
      Me.arguments = arguments
      ' Activate the timer.
      Me.Timer.Interval = milliseconds
      Me.Timer.Enabled = True
   End Sub

   Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer.Tick
      ' Prevent the timer from firing again.
      Me.Timer.Enabled = False
      ' Run the application.
      Process.Start(exePath, arguments)
   End Sub
End Class
