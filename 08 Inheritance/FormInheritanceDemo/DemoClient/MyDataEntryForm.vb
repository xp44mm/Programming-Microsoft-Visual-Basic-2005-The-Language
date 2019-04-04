Public Class MyDataEntryForm

   Private Sub MyDataEntryForm_AppActivated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AppActivated
      For Each frm As Form In My.Application.OpenForms
         frm.BackColor = SystemColors.Control
      Next
   End Sub

   Private Sub MyDataEntryForm_AppDeactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AppDeactivate
      For Each frm As Form In My.Application.OpenForms
         frm.BackColor = Color.DarkGray
      Next
   End Sub
End Class
