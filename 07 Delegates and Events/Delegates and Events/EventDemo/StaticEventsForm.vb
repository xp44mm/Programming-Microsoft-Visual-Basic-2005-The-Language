Public Class StaticEventsForm

   Private Sub StaticEventsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      AddHandler Application.Idle, AddressOf Application_Idle
   End Sub

   Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
      lblCharCount.Text = txtField.TextLength.ToString()
   End Sub
End Class

