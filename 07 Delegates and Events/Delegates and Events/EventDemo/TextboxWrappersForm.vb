Public Class TextboxWrappersForm

   Dim qtyWrapper, phoneWrapper, idWrapper As TextBoxWrapper

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) _
         Handles MyBase.Load
      ' txtQty is a numeric field that can hold only positive numbers.
      qtyWrapper = New TextBoxWrapper(txtQty, "0123456789")
      ' txtPhone can contain digits and a few symbols.
      phoneWrapper = New TextBoxWrapper(txtPhone, "-0123456789()")
      ' txtID can contain only hexadecimal characters.
      idWrapper = New TextBoxWrapper(txtID, "0123456789ABCDEFabcdef")
   End Sub

End Class