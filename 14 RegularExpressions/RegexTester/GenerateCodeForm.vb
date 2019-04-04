Imports System.Text.RegularExpressions

Public Class GenerateCodeForm

   Public Options As ProjectOptions
   Dim initializing As Boolean = True

   Private Sub GenerateCodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' set all tooltips and help messages
      Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)

      If Options.Language = LanguageOption.VisualBasic Then
         radVisualBasic.Checked = True
      Else
         radVisualCSharp.Checked = True
      End If
      chkVerbatimStrings.Checked = Options.VerbatimStrings
      chkInstanceMethods.Checked = Options.InstanceMethods
      chkAssumeImports.Checked = Options.AssumeImports
      chkGenerateLoops.Checked = Options.GenerateLoop
      chkDescriptionAsComment.Checked = Options.IncludeComment
      chkCopyToClipboard.Checked = Options.CopyCodeOnExit
      ' Some options might be unavailable
      chkGenerateLoops.Enabled = (Options.Command <> Command.Replace)
      chkDescriptionAsComment.Enabled = Options.RegexDescription.Length > 0

      initializing = False
      RefreshCode()
   End Sub

   Private Sub radVisualCSharp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radVisualCSharp.CheckedChanged, radVisualBasic.CheckedChanged, chkVerbatimStrings.CheckedChanged, chkInstanceMethods.CheckedChanged, chkAssumeImports.CheckedChanged, chkGenerateLoops.CheckedChanged, chkDescriptionAsComment.CheckedChanged
      RefreshCode()
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      ' Save options
      If radVisualBasic.Checked Then
         Options.Language = LanguageOption.VisualBasic
      Else
         Options.Language = LanguageOption.VisualCsharp
      End If
      Options.VerbatimStrings = chkVerbatimStrings.Checked
      Options.InstanceMethods = chkInstanceMethods.Checked
      Options.AssumeImports = chkAssumeImports.Checked
      Options.GenerateLoop = chkGenerateLoops.Checked
      Options.IncludeComment = chkDescriptionAsComment.Checked
      Options.CopyCodeOnExit = chkCopyToClipboard.Checked

      ' Copy code to clipboard if required.
      If Options.CopyCodeOnExit Then Clipboard.SetText(txtCode.Text)

      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub

   Sub RefreshCode()
      chkVerbatimStrings.Enabled = radVisualCSharp.Checked
      If initializing Then Exit Sub

      Dim pattern As String = Options.RegexText
      Dim varName As String = "re"
      Dim sourceText As String = """text"""
      Dim ns As String = ""
      If Not chkAssumeImports.Checked Then ns = "System.Text.RegularExpressions."
      Dim commentChar As String = "//"

      ' process the regex options
      Dim reOptions As String = ""
      If CBool(Options.RegexOptions And RegexOptions.IgnoreCase) Then reOptions &= " | {0}RegexOptions.IgnoreCase"
      If CBool(Options.RegexOptions And RegexOptions.IgnorePatternWhitespace) Then reOptions &= " | {0}RegexOptions.IgnorePatternWhitespace"
      If CBool(Options.RegexOptions And RegexOptions.Multiline) Then reOptions &= " | {0}RegexOptions.Multiline"
      If CBool(Options.RegexOptions And RegexOptions.Compiled) Then reOptions &= " | {0}RegexOptions.Compiled"
      If CBool(Options.RegexOptions And RegexOptions.ExplicitCapture) Then reOptions &= " | {0}RegexOptions.ExplicitCapture"
      If CBool(Options.RegexOptions And RegexOptions.RightToLeft) Then reOptions &= " | {0}RegexOptions.RightToLeft"
      If CBool(Options.RegexOptions And RegexOptions.CultureInvariant) Then reOptions &= " | {0}RegexOptions.CultureInvariant"
      If CBool(Options.RegexOptions And RegexOptions.ECMAScript) Then reOptions &= " | {0}RegexOptions.ECMAScript"
      If reOptions.Length = 0 Then
         reOptions = "{0}RegexOptions.None"
      Else
         ' Drop the initial " | "
         reOptions = reOptions.Substring(3)
      End If
      ' Replace the namespace
      reOptions = String.Format(reOptions, ns)

      Dim code As String = Nothing

      If radVisualBasic.Checked Then
         pattern = """" & pattern.Replace("""", """""") & """"
         reOptions = reOptions.Replace("|", "Or")
         commentChar = "'"

         If chkInstanceMethods.Checked Then
            code = "Dim {1} As New {2}Regex({3}, {4}){0}"
         End If
         Select Case Options.Command
            Case Command.Find
               If chkInstanceMethods.Checked Then
                  code &= "Dim mc As {2}MatchCollection = re.Matches({5}){0}"
               Else
                  code = "Dim mc As {2}MatchCollection = {2}Regex.Matches({5}, {3}, {4}){0}"
               End If
               If chkGenerateLoops.Checked Then
                  code &= "For Each ma As {2}Match in mc{0}{0}Next{0}"
               End If
            Case Command.Replace
               If chkInstanceMethods.Checked Then
                  code &= "Dim result As String = {1}.Replace({5}){0}"
               Else
                  code = "Dim result As String = {2}Regex.Replace({5}, {3}, {4}){0}"
               End If
            Case Command.Split
               If chkInstanceMethods.Checked Then
                  code &= "Dim lines() As String = re.Split({5}){0}"
               Else
                  code = "Dim lines() as String = {2}Regex.Split({5}, {3}, {4}){0}"
               End If
               If chkGenerateLoops.Checked Then
                  code &= "For Each line As String In lines{0}{0}Next{0}"
               End If
         End Select
      Else
         If chkVerbatimStrings.Checked Then
            pattern = "@""" & pattern.Replace("""", """""") & """"
         Else
            pattern = """" & pattern.Replace("\", "\\").Replace("""", "\""") & """"
         End If
         If chkInstanceMethods.Checked Then
            code = "{2}Regex {1} = new {2}Regex({3}, {4});{0}"
         End If
         Select Case Options.Command
            Case Command.Find
               If chkInstanceMethods.Checked Then
                  code &= "{2}MatchCollection mc = re.Matches({5});{0}"
               Else
                  code = "{2}MatchCollection mc = {2}Regex.Matches({5}, {3}, {4});{0}"
               End If
               If chkGenerateLoops.Checked Then
                  code &= "foreach ({2}Match ma in mc){0}{{{0}}}{0}"
               End If
            Case Command.Replace
               If chkInstanceMethods.Checked Then
                  code &= "string result = {1}.Replace({5});{0}"
               Else
                  code = "string result = {2}Regex.Replace({5}, {3}, {4});{0}"
               End If
            Case Command.Split
               If chkInstanceMethods.Checked Then
                  code &= "string[] lines= re.Split({5});{0}"
               Else
                  code = "string[] lines = {2}Regex.Split({5}, {3}, {4});{0}"
               End If
               If chkGenerateLoops.Checked Then
                  code &= "foreach (string line in lines){0}{{{0}}}{0}"
               End If
         End Select
      End If

      ' prefix comment if requested and available
      If chkDescriptionAsComment.Checked AndAlso Options.RegexDescription.Length > 0 Then
         Dim comment As String = ""
         For Each line As String In Options.RegexDescription.Split(New String() {ControlChars.CrLf}, StringSplitOptions.RemoveEmptyEntries)
            comment &= commentChar & " " & line & ControlChars.CrLf
         Next
         code = comment & code
      End If

      ' Replace portions and display in control
      code = String.Format(code, ControlChars.CrLf, varName, ns, pattern, reOptions, sourceText)
      txtCode.Text = code
   End Sub


End Class