Imports PluginLibrary

Public Class MainForm
   ' Uncomment this code if you create this form by a plain New keyword.
   'Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
   '   MyBase.OnLoad(e)
   '   FormExtenderManager.NotifyFormCreation(Me)
   'End Sub

   Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
      Me.Close()
   End Sub

   Private Sub mnuViewSampleForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSampleForm.Click
      FormExtenderManager.Show(Of SampleForm)()
   End Sub

   Private Sub mnuViewCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewCalculate.Click
      Dim frmCalc As CalculatorForm = FormExtenderManager.Create(Of CalculatorForm)()
      If frmCalc.ShowDialog() = Windows.Forms.DialogResult.OK Then
         ' Read the Total public property of the CalculatorForm type.
         MessageBox.Show(frmCalc.Total.ToString(), "Total", MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
      End If
   End Sub
End Class
