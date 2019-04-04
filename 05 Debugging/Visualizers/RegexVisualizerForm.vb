Imports System.Text.RegularExpressions

Public Class RegexVisualizerForm

   Private m_RegexPattern As String

   Public Property RegexPattern() As String
      Get
         Return m_RegexPattern
      End Get
      Set(ByVal value As String)
         m_RegexPattern = value
         txtPattern.Text = value
      End Set
   End Property

   Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
      Dim re As New Regex(txtPattern.Text)
      txtResults.Clear()

      For Each m As Match In re.Matches(txtSource.Text)
         txtResults.AppendText(String.Format("Index {0,-4}: {1}{2}", m.Index, m.Value, ControlChars.CrLf))
      Next
   End Sub

   Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
      m_RegexPattern = txtPattern.Text
      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub
End Class