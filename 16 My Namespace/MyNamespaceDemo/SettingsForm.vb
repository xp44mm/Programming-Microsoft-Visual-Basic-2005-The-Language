Imports System.Configuration

Public Class SettingsForm

   Private Sub SettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Enforce user preferences when the form loads.
      Me.BackColor = My.Settings.BackColor
      Me.Font = My.Settings.WindowFont
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         My.Settings.BackColor = Me.ColorDialog1.Color
         Me.BackColor = Me.ColorDialog1.Color
      End If
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         My.Settings.WindowFont = Me.FontDialog1.Font
         Me.Font = Me.FontDialog1.Font
      End If
   End Sub

   Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      My.Settings.Reload()
   End Sub

   Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
      My.Settings.Reset()
   End Sub

   Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
      For Each sp As SettingsProperty In My.Settings.Properties
         Dim desc As String = String.Format("{0} (As {1}) = {2} (Default={3})", _
            sp.Name, sp.PropertyType.FullName, My.Settings(sp.Name), sp.DefaultValue)
         If sp.IsReadOnly Then desc &= " (readonly)"
         txtSettings.AppendText(desc)
         txtSettings.AppendText(ControlChars.CrLf)
      Next

   End Sub
End Class