Public Class MyExtensionsForm

   Private Sub MyExtensionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' register a handler for the My.Application.DisplaySettingsChanged event 
      AddHandler My.Application.DisplaySettingsChanged, AddressOf DisplaySettingsChanged
   End Sub

   ' A handler for the My.Application.DisplaySettingsChanged event

   Private Sub DisplaySettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
      MessageBox.Show("Display settings have changed", "My.Application event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      lstColors.Items.Clear()
      lstColors.Items.AddRange(My.Resources.Colors)
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      lblUserDomain.Text = My.Computer.DomainName
   End Sub

End Class