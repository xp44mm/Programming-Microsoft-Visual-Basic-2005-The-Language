Public Class TextBoxWrapper
   ' The control being wrapped
   Private WithEvents TextBox As TextBox
   ' The list of valid characters 
   Private ValidChars As String

   Public Sub New(ByVal textBox As TextBox, ByVal validChars As String)
      Me.TextBox = textBox
      Me.ValidChars = validChars
   End Sub

   Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
         Handles TextBox.KeyPress
      ' Discard any key press not in the list of valid characters.
      If ValidChars.IndexOf(e.KeyChar) < 0 Then e.Handled = True
   End Sub
End Class
