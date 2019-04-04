Public Class Form1

   Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) _
      Handles btnOK.Click
      Me.Close()
   End Sub

   Private Sub txtFirstName_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
      Handles txtFirstName.KeyPress
      ' Ignore spaces typed by the user. (This is obtained by telling 
      ' the .NET Framework that we handled this key.)
      If e.KeyChar = " "c Then e.Handled = True
   End Sub

   Private Sub Control_Enter(ByVal sender As Object, ByVal e As EventArgs) _
      Handles txtFirstName.Enter, txtLastName.Enter, txtCity.Enter
      Dim ctrl As Control = DirectCast(sender, Control)
      ' Change the background color when this control gets the focus.
      ctrl.BackColor = Color.Yellow
   End Sub

   Private Sub Control_Leave(ByVal sender As Object, ByVal e As EventArgs) _
         Handles txtFirstName.Leave, txtLastName.Leave, txtCity.Leave
      Dim ctrl As Control = DirectCast(sender, Control)
      ' Restore the default background color when the control loses the focus.
      ctrl.BackColor = SystemColors.Window
   End Sub

   Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
      Dim sched As New AppScheduler("Notepad.exe", "c:\data.txt", 5000)
   End Sub

   Private Sub btnTextboxWrappers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTextboxWrappers.Click
      Dim frm As New TextboxWrappersForm
      frm.Show()
   End Sub

   Private Sub btnStaticEvents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStaticEvents.Click
      Dim frm As New StaticEventsForm
      frm.Show()
   End Sub

   Private Sub btnControlArray_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnControlArray.Click
      Dim frm As New ControlArrayForm
      frm.Show()
   End Sub
End Class
