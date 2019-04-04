Imports System.Drawing

Public Class ImageVisualizerForm

   Public Property VisibleImage() As Image
      Get
         Return picImage.Image
      End Get
      Set(ByVal value As Image)
         picImage.Image = value
      End Set
   End Property

   Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
      My.Computer.Clipboard.SetImage(picImage.Image)
      btnReplace.Enabled = True
   End Sub

   Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
      picImage.Image = My.Computer.Clipboard.GetImage()
      btnReplace.Enabled = True
   End Sub

   Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
      If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         picImage.Image = Image.FromFile(OpenFileDialog1.FileName)
         btnReplace.Enabled = True
      End If
   End Sub
End Class