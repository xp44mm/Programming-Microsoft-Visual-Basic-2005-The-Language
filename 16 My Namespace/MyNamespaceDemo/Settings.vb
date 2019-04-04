
Namespace My
    
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
   Partial Friend NotInheritable Class MySettings

      Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
         If e.PropertyName = "BackColor" Then
            ' Change the BackColor property of all open forms.
            For Each frm As Form In My.Application.OpenForms
               frm.BackColor = My.Settings.BackColor
            Next
         End If

      End Sub

      Private Sub MySettings_SettingChanging(ByVal sender As Object, ByVal e As System.Configuration.SettingChangingEventArgs) Handles Me.SettingChanging
         Select Case e.SettingName
            Case "MainWindowLocation"
               Dim pt As Point = CType(e.NewValue, Point)
               If pt.X < 0 OrElse pt.Y < 0 Then
                  ' Cancel the assignment if either coordinate is negative.
                  e.Cancel = True
                  ' Ensure that the saved value isn't negative.
                  My.Settings.MainWindowLocation = _
                     New Point(Math.Max(pt.X, 0), Math.Max(pt.Y, 0))
               End If
               ' Test here other settings.
               '…
         End Select

      End Sub

      Private Sub MySettings_SettingsSaving(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.SettingsSaving
         If MessageBox.Show("Do you want to save new settings?", "Exiting the Application", _
      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
         End If

      End Sub
   End Class
End Namespace
