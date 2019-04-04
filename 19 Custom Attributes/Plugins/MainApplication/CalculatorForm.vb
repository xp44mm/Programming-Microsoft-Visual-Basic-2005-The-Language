Public Class CalculatorForm

   Private Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnits.TextChanged, txtUnitPrice.TextChanged, txtPercentTax.TextChanged
      CalculateTotal()
   End Sub

   Protected Overridable Sub CalculateTotal()
      Try
         Dim units As Integer = CInt(txtUnits.Text)
         Dim unitPrice As Decimal = CDec(txtUnitPrice.Text)
         Dim percentTax As Decimal = CDec(txtPercentTax.Text)
         Dim total As Decimal = units * unitPrice
         Dim tax As Decimal = total * percentTax / 100
         Dim grandTotal As Decimal = total + tax

         txtTotal.Text = total.ToString("N2")
         txtTax.Text = tax.ToString("N2")
         txtGrandTotal.Text = grandTotal.ToString("N2")
      Catch ex As Exception
         ' Clear result fields in case of exceptions.
         txtTotal.Text = ""
         txtTax.Text = ""
         txtGrandTotal.Text = ""
      End Try
   End Sub

   Public Overridable ReadOnly Property Total() As Decimal
      Get
         Return CDec(txtGrandTotal.Text)
      End Get
   End Property

End Class