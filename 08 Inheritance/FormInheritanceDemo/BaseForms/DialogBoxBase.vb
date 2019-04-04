Public Class DialogBoxBase
   ' Wrap the value typed by the user in a public property.
   Property InputValue() As String
      Get
         Return txtValue.Text
      End Get
      Set(ByVal Value As String)
         txtValue.Text = Value
      End Set
   End Property

   ' Event handlers
   Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
      OnOkClick(e)
   End Sub

   Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      OnCancelClick(e)
   End Sub

   ' Since this form has been designed for being inherited from
   ' we put the actual code in two Protected procedures.
   Protected Overridable Sub OnOkClick(ByVal e As System.EventArgs)
      ' close this form
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

   Protected Overridable Sub OnCancelClick(ByVal e As System.EventArgs)
      ' close this form 
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
   End Sub

End Class