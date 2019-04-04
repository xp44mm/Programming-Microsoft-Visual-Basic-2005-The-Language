<PluginLibrary.FormExtender("MainApplication.CalculatorForm", True)> _
Public Class CalculatorForm_Replacement

   Private Sub txtPercentDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercentDiscount.TextChanged
      CalculateTotal()
   End Sub

   Protected Overrides Sub CalculateTotal()
      If Not Me.Visible Then Exit Sub
      Try
         Dim units As Integer = CInt(txtUnits.Text)
         Dim unitPrice As Decimal = CDec(txtUnitPrice.Text)
         Dim percentTax As Decimal = CDec(txtPercentTax.Text)
         Dim percentDiscount As Decimal = CDec(txtPercentDiscount.Text)

         Dim total As Decimal = units * unitPrice
         Dim discount As Decimal = total * percentDiscount / 100
         Dim discountedTotal As Decimal = total - discount
         Dim tax As Decimal = discountedTotal * percentTax / 100
         Dim grandTotal As Decimal = discountedTotal + tax

         txtTotal.Text = total.ToString("N2")
         txtDiscount.Text = discount.ToString("N2")
         txtDiscountedTotal.Text = discountedTotal.ToString("N2")
         txtTax.Text = tax.ToString("N2")
         txtGrandTotal.Text = grandTotal.ToString("N2")
      Catch ex As Exception
         ' Clear result fields in case of exceptions.
         txtTotal.Text = ""
         txtDiscount.Text = ""
         txtDiscountedTotal.Text = ""
         txtTax.Text = ""
         txtGrandTotal.Text = ""
      End Try
   End Sub
End Class
