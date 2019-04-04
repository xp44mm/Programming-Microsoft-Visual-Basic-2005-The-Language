Imports System.Text.RegularExpressions

Public Class EscapeForm

   Public Options As ProjectOptions


   Private Sub EscapeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' set all tooltips and help messages
      Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)

      txtText.Text = Options.RegexText
      lblError.Text = ""
   End Sub

   Private Sub radUnescape_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEscape.CheckedChanged, radUnescape.CheckedChanged
      ' Clear textbox when a new command is attempted
      txtText.Text = ""
   End Sub

   Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
      Try
         If radEscape.Checked Then
            txtResult.Text = Regex.Escape(txtText.Text)
         Else
            txtResult.Text = Regex.Unescape(txtText.Text)
         End If
         lblError.Text = ""
      Catch ex As Exception
         lblError.Text = ex.Message
      End Try
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      If chkCopyToClipboard.Checked AndAlso txtResult.TextLength > 0 Then
         Clipboard.SetText(txtResult.Text)
      End If
      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub
End Class