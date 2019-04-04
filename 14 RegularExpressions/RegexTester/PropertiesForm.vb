Imports System.Text.RegularExpressions

Public Class PropertiesForm

   Public Options As ProjectOptions

   Private Sub PropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' set all tooltips and help messages
      Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)

      txtName.Text = Options.RegexName
      txtDescription.Text = Options.RegexDescription
      chkIgnoreCase.Checked = CBool(Options.RegexOptions And RegexOptions.IgnoreCase)
      chkIgnoreWhitespace.Checked = CBool(Options.RegexOptions And RegexOptions.IgnorePatternWhitespace)
      chkMultiline.Checked = CBool(Options.RegexOptions And RegexOptions.Multiline)
      chkCompiled.Checked = CBool(Options.RegexOptions And RegexOptions.Compiled)
      chkExplicitCapture.Checked = CBool(Options.RegexOptions And RegexOptions.ExplicitCapture)
      chkRightToLeft.Checked = CBool(Options.RegexOptions And RegexOptions.RightToLeft)
      chkCultureInvariant.Checked = CBool(Options.RegexOptions And RegexOptions.CultureInvariant)
      chkEcmaScript.Checked = CBool(Options.RegexOptions And RegexOptions.ECMAScript)

      numMatches.Value = Options.MaxMatches
      chkWordWrap.Checked = Options.WordWrap
      cboFormat.SelectedIndex = CInt(Options.Format)
      cboDetails.SelectedIndex = CInt(Options.Detail)
      cboSort.SelectedIndex = CInt(Options.Sort)
      chkIncludeEmptyGroups.Checked = Options.IncludeEmptyGroups
   End Sub


   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Options.RegexName = txtName.Text
      Options.RegexDescription = txtDescription.Text
      SetRegexOption(RegexOptions.IgnoreCase, chkIgnoreCase.Checked)
      SetRegexOption(RegexOptions.IgnorePatternWhitespace, chkIgnoreWhitespace.Checked)
      SetRegexOption(RegexOptions.Multiline, chkMultiline.Checked)
      SetRegexOption(RegexOptions.Compiled, chkCompiled.Checked)
      SetRegexOption(RegexOptions.ExplicitCapture, chkExplicitCapture.Checked)
      SetRegexOption(RegexOptions.RightToLeft, chkRightToLeft.Checked)
      SetRegexOption(RegexOptions.CultureInvariant, chkCultureInvariant.Checked)
      SetRegexOption(RegexOptions.ECMAScript, chkEcmaScript.Checked)

      Options.MaxMatches = CInt(numMatches.Value)
      Options.WordWrap = chkWordWrap.Checked
      Options.Format = CType(cboFormat.SelectedIndex, FormatOption)
      Options.Detail = CType(cboDetails.SelectedIndex, DetailOption)
      Options.Sort = CType(cboSort.SelectedIndex, SortOption)
      Options.IncludeEmptyGroups = chkIncludeEmptyGroups.Checked

      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub

   Private Sub SetRegexOption(ByVal bitMask As RegexOptions, ByVal value As Boolean)
      If value Then
         Options.RegexOptions = Options.RegexOptions Or bitMask
      Else
         Options.RegexOptions = Options.RegexOptions And Not bitMask
      End If
   End Sub


End Class