Public Class ControlArrayForm
   Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      ' Registers two events for each control on the Form.
      For Each ctrl As Control In GetChildControls(Me)
         AddHandler ctrl.MouseEnter, AddressOf Control_MouseEnter
         AddHandler ctrl.MouseLeave, AddressOf Control_MouseLeave
      Next
   End Sub

   Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
      Handles Me.FormClosing
      ' Unregisters the events for all the controls on the Form.
      For Each ctrl As Control In GetChildControls(Me)
         RemoveHandler ctrl.MouseEnter, AddressOf Control_MouseEnter
         RemoveHandler ctrl.MouseLeave, AddressOf Control_MouseLeave
      Next
   End Sub


   Private Sub Control_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
      Dim ctrl As Control = DirectCast(sender, Control)
      If Not ctrl.Tag Is Nothing Then ToolStripStatusLabel1.Text = ctrl.Tag.ToString()
   End Sub

   Private Sub Control_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
      ToolStripStatusLabel1.Text = ""
   End Sub

   ' Return the list of all the controls contained in another control.
   Function GetChildControls(ByVal parent As Control) As ArrayList
      Dim result As New ArrayList()
      For Each ctrl As Control In parent.Controls
         ' Add this control to the result.
         result.Add(ctrl)
         ' Recursively call this method to add all child controls as well.
         result.AddRange(GetChildControls(ctrl))
      Next
      Return result
   End Function

End Class