Public Class ResourcesForm

   Private Sub ResourcesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.RichTextBox1.Rtf = My.Resources.resources_text
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      My.Computer.Audio.Play(My.Resources.Windows_XP_Logon_Sound, AudioPlayMode.Background)
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Me.RichTextBox1.Clear()
      For Each de As DictionaryEntry In My.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, False, True)
         Dim text As String = String.Format("{0} = {1}", de.Key, de.Value)
         Me.RichTextBox1.AppendText(text)
         Me.RichTextBox1.AppendText(ControlChars.CrLf)

      Next
   End Sub
End Class