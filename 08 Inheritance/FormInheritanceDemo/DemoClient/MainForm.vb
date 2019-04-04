Public Class MainForm

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Dim frm As New MyDialogBox
      If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         MessageBox.Show(frm.InputValue, "Dialog result", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Dim frm As New MyDataEntryForm
      frm.Show()
   End Sub
End Class
