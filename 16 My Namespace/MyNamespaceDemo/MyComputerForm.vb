Imports System.Media
Imports System.ComponentModel
Imports System.Threading

Public Class MyComputerForm

   Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
      If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         txtWavFile.Text = Me.OpenFileDialog1.FileName
      End If
   End Sub

   Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If txtWavFile.Text.Length = 0 Then Exit Sub
      My.Computer.Audio.Play(txtWavFile.Text, AudioPlayMode.BackgroundLoop)
   End Sub

   Private Sub btnPlayAsync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If txtWavFile.Text.Length = 0 Then Exit Sub
      Dim player As New SoundPlayer
      AddHandler player.LoadCompleted, AddressOf Player_LoadCompleted
      player.SoundLocation = txtWavFile.Text
      player.LoadAsync()
   End Sub

   Private Sub Player_LoadCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
      Dim player As SoundPlayer = DirectCast(sender, SoundPlayer)
      player.PlayLooping()
   End Sub

   Private Sub btnStopPlaying_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      My.Computer.Audio.Stop()
   End Sub

   Private Sub btnGetText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetText.Click
      If My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then
         rtbClipboard.Rtf = My.Computer.Clipboard.GetText(TextDataFormat.Rtf)
      ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Text) Then
         rtbClipboard.Text = My.Computer.Clipboard.GetText(TextDataFormat.Text)
      End If

   End Sub

   Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      ' Export data to a 2x4 cell range in Excel.
      Dim values As String = String.Format("1,2,3,4{0}5,6,7,8{0}", Environment.NewLine, ControlChars.Tab)
      ' Account for regional settings 
      If Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "," Then
         values = values.Replace(",", Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator)
      End If

#If False Then
      ' This doesn't appear to work
      My.Computer.Clipboard.SetText(values, TextDataFormat.CommaSeparatedValue)

#Else
      Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(values)
      Dim ms As New System.IO.MemoryStream(bytes)
      Dim data As New DataObject()
      data.SetData(DataFormats.CommaSeparatedValue, ms)
      Clipboard.SetDataObject(data, True)
#End If

      MsgBox("Switch to Excel and paste data where you see fit.")

   End Sub

   Private Sub btnCopyWidget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyWidget.Click
      Dim widget As New Widget
      widget.Name = "Foobar"
      My.Computer.Clipboard.SetData("Widget", widget)
   End Sub

   Private Sub btnPasteWidget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteWidget.Click
      Dim widget As Widget = DirectCast(My.Computer.Clipboard.GetData("Widget"), Widget)
      If widget Is Nothing Then
         MsgBox("No Widget object in the clipboard")
      Else
         MsgBox("Found a widget object named " & widget.Name)
      End If
   End Sub

   Private Sub btnListFormats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListFormats.Click
      ' Retrieve all the formats currently in the clipboard; the True argument means
      ' that we are interested also in the format obtainable by converting the data.
      Dim formats() As String = My.Computer.Clipboard.GetDataObject().GetFormats(True)
      Me.rtbClipboard.Text = Join(formats, ControlChars.CrLf)
   End Sub

   Private Sub btnMultipleCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultipleCopy.Click
      Dim data As New DataObject
      data.SetData("Text", "1234")           ' Also copies in UnicodeText format.
      data.SetData("System.String", "1234")
      data.SetData("System.Int32", 1234)
      My.Computer.Clipboard.SetDataObject(data)

      Dim value As Integer = DirectCast(My.Computer.Clipboard.GetData("System.Int32"), Integer)
      MsgBox(value)

   End Sub


End Class

<Serializable()> _
Public Class Widget
   Public Name As String
End Class
