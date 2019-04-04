Public Class MainForm

   Private Sub btnEval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEval.Click
      ' evaluate the selected or entire portion of txtSource
      Dim expr As String = txtExpression().SelectedText
      If expr = "" Then expr = txtExpression().Text
      If expr = "" Then Exit Sub

      Try
         txtResult.Text = Evaluate(expr).ToString
      Catch ex As Exception
         txtResult.Text = ex.Message
      End Try
   End Sub
End Class