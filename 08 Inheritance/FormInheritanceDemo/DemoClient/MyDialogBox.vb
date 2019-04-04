Public Class MyDialogBox
   Protected Overrides Sub OnOkClick(ByVal e As EventArgs)
      If Not chkSkipRegistration.Checked AndAlso (txtValue.Text.Length <> 16 OrElse txtValue.Text Like "*[!0-9a-fA-f]*") Then
         ' Display an error message.
         MessageBox.Show("Invalid serial number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         ' Perform the default action (ie closing the form).
         MyBase.OnOkClick(e)
      End If
   End Sub
End Class
