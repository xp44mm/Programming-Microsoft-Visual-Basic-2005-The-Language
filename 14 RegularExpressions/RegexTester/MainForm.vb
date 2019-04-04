Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Xml

Public Class MainForm

   ' The current ProjectOptions instance
   Friend Options As New ProjectOptions
   ' The current regular expression
   Friend re As Regex
   ' The compileform 
   Friend CompileForm As CompileForm

   '------------------------------------------------
   ' Main commands
   '------------------------------------------------

   Sub ExecuteCommand()
      Dim sw As New Stopwatch()
      Dim matches As MatchCollection
      Dim matchCount As Integer
      Dim resultText As String = ""
      Dim splitLines() As String = Nothing

      Try
         ' Attempt to create the regex
         re = New Regex(rtbRegex.Text, Options.RegexOptions)
      Catch ex As Exception
         ' Exit if any syntax error
         staMatches.Text = "Parsing Error"
         MessageBox.Show(ex.Message, "Parsing error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return
      End Try

      ' Execute the regex
      Try
         ' Find all matches, regardless of the command 
         sw.Start()
         matches = re.Matches(rtbSource.Text)
         ' We need this to force full evaluation of regex.
         matchCount = matches.Count
         sw.Stop()

         ' Apply the Replace or Split command
         If Options.Command = Command.Replace Then
            sw.Start()
            resultText = re.Replace(rtbSource.Text, rtbReplace.Text)
            sw.Stop()
         ElseIf Options.Command = Command.Split Then
            splitLines = re.Split(rtbSource.Text)
            sw.Start()
            sw.Stop()
         End If
         ' Display results
         staExecutionTime.Text = String.Format("Execution: {0} msecs.   ", sw.ElapsedMilliseconds)
         staMatches.Text = String.Format("Found {0} matches   ", matchCount)
      Catch ex As Exception
         ' Exit if any syntax error
         staMatches.Text = "Execution error"
         MessageBox.Show(ex.Message, "Execution error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return
      End Try

      ' Get all results
      Dim matchList As New List(Of Match)
      For Each m As Match In matches
         matchList.Add(m)
      Next

      ' Display results
      staMatchInfoText = ""
      Me.Refresh()
      Dim count As Integer = 0

      ' Sort as required
      Select Case Options.Sort
         Case SortOption.Alphabetic
            matchList.Sort(New AlphaComparer())
         Case SortOption.ShortestFirst
            matchList.Sort(New ShortestComparer())
         Case SortOption.LargestFirst
            matchList.Sort(New LargestComparer())
      End Select

      ' Display results in treeview
      tvwResults.Nodes.Clear()
      For index As Integer = 0 To matchList.Count - 1
         Dim m As Match = matchList(index)
         Dim node As TreeNode = tvwResults.Nodes.Add(m.Value)
         node.Tag = New NodeInfo(m, index.ToString())
         ' Add a dummy node if necessary
         If Options.Detail <> DetailOption.NoDetails AndAlso m.Groups.Count > 0 Then node.Nodes.Add("*")
         ' exit if found enough matches
         count += 1
         If count = Options.MaxMatches Then Exit For
      Next
      If matches.Count > Options.MaxMatches Then
         Me.staItemInfo.Text = String.Format("(Only the first {0} are displayed)", Options.MaxMatches)
      End If

      ' Display results in result textbox
      count = 0
      If Options.Command = Command.Find Then

         Dim sb As New StringBuilder()
         For maIndex As Integer = 0 To matchList.Count - 1
            Dim m As Match = matchList(maIndex)
            sb.AppendFormat("MATCH[{0}]: '{1}'   [index={2}]", maIndex, m.Value, m.Index)
            sb.AppendLine()
            ' Skip remainder if groups must not be displayed
            If Options.Detail = DetailOption.NoDetails Then Continue For
            ' skip group (0)
            For grpIndex As Integer = 1 To m.Groups.Count - 1
               Dim g As Group = m.Groups(grpIndex)
               ' Skip empty groups if so required
               If g.Length = 0 AndAlso Not Options.IncludeEmptyGroups Then Continue For

               sb.AppendFormat("   GROUP[{0}]: '{1}'   [index={2}]", re.GroupNameFromNumber(grpIndex), g.Value, g.Index)
               sb.AppendLine()
               ' Skip remainder if captures must not be displayed
               If Options.Detail = DetailOption.Groups Then Continue For

               For caIndex As Integer = 0 To g.Captures.Count - 1
                  Dim c As Capture = g.Captures(caIndex)
                  sb.AppendFormat("      CAPTURE[{0}]: '{1}'   [index={2}]", caIndex, c.Value, c.Index)
                  sb.AppendLine()
               Next
            Next

            count += 1
            If count = Options.MaxMatches Then Exit For
         Next
         resultText = sb.ToString()
      ElseIf Options.Command = Command.Split Then
         Dim sb As New StringBuilder
         For Each line In splitLines
            sb.AppendFormat("[{0,3}]: {1}", count, line)
            sb.AppendLine()
            count += 1
            If count = Options.MaxMatches Then Exit For
         Next
         resultText = sb.ToString()
      End If

      rtbResults.Text = resultText
      rtbResults.Select(0, 0)
   End Sub

   '------------------------------------------------
   ' Helper procedures
   '------------------------------------------------

   Sub UpdateOptionFiels()
      ' update options fields
      Options.RegexText = rtbRegex.Text
      Options.ReplaceText = rtbReplace.Text
      Options.SourceText = rtbSource.Text
   End Sub

   ' Check whether current regex has been modified and offer to save it
   Function OkToProceed() As Boolean
      UpdateOptionFiels()
      ' exit if no change has been done
      If Not Options.HasChanged Then Return True

      Dim msg As String = String.Format("Current regex has been modified.{0}{0}Do you wish to save it?", ControlChars.CrLf)
      Select Case MessageBox.Show(msg, "Confirm action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
         Case Windows.Forms.DialogResult.Cancel
            Return False
         Case Windows.Forms.DialogResult.No
            Return True
         Case Windows.Forms.DialogResult.Yes
            If Not SaveRegex(Options.RegexFile) Then Return False
            Return True
      End Select
   End Function

   ' Open a regex to file
   Function OpenRegex(ByVal fileName As String) As Boolean
      ' Ask for the filename if necessary
      If String.IsNullOrEmpty(fileName) Then
         If dlgOpenRegex.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return False
         fileName = dlgOpenRegex.FileName
      End If

      Try
         Me.Options = ProjectOptions.Load(fileName)
         RefreshControlState()
         Return True
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End Try
   End Function

   ' Save current regex to file
   Function SaveRegex(ByVal fileName As String) As Boolean
      ' Check that this regex has a name and description
      If Options.RegexName.Length = 0 Then
         Dim name As String = InputBox("Please assign a name to the current regex", "Saving Regex file")
         If name = "" Then
            MessageBox.Show("Current regex hasn't been saved.", "Missing regex name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
         End If
         Options.RegexName = name
      End If

      ' Ask for the filename if necessary
      If String.IsNullOrEmpty(fileName) Then
         If dlgSaveRegex.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return False
         fileName = dlgSaveRegex.FileName
      End If

      Try
         Me.Options.Save(fileName)
         RefreshControlState()
         Return True
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Unable to save regex file", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End Try
   End Function

   ' Refresh the state of all controls

   Sub RefreshControlState()
      rtbRegex.Text = Options.RegexText
      rtbReplace.Text = Options.ReplaceText
      rtbSource.Text = Options.SourceText
      RefreshOptionsState()

      Dim title As String = My.Application.Info.Title
      If String.IsNullOrEmpty(Options.RegexName) Then
         Me.Text = title & " - (unnamed regex)"
      Else
         Me.Text = title & " - " & Options.RegexName
      End If
   End Sub

   ' Refresh the status of all menu commands
   Sub RefreshOptionsState()
      mnuEditWordWrap.Checked = Options.WordWrap

      mnuCommandsFind.Checked = (Options.Command = Command.Find)
      mnuCommandsReplace.Checked = (Options.Command = Command.Replace)
      mnuCommandsSplit.Checked = (Options.Command = Command.Split)

      mnuOptionsCompiled.Checked = (Options.RegexOptions And RegexOptions.Compiled) = RegexOptions.Compiled
      mnuOptionsCultureInvariant.Checked = (Options.RegexOptions And RegexOptions.CultureInvariant) = RegexOptions.CultureInvariant
      mnuOptionsEcmaScript.Checked = (Options.RegexOptions And RegexOptions.ECMAScript) = RegexOptions.ECMAScript
      mnuOptionsExplicitCapture.Checked = (Options.RegexOptions And RegexOptions.ExplicitCapture) = RegexOptions.ExplicitCapture
      mnuOptionsIgnoreCase.Checked = (Options.RegexOptions And RegexOptions.IgnoreCase) = RegexOptions.IgnoreCase
      mnuOptionsIgnoreWhitespace.Checked = (Options.RegexOptions And RegexOptions.IgnorePatternWhitespace) = RegexOptions.IgnorePatternWhitespace
      mnuOptionsMultiline.Checked = (Options.RegexOptions And RegexOptions.Multiline) = RegexOptions.Multiline
      mnuOptionsRightToLeft.Checked = (Options.RegexOptions And RegexOptions.RightToLeft) = RegexOptions.RightToLeft

      mnuResultsAuto.Checked = (Options.Format = FormatOption.Auto)
      mnuResultsTreeView.Checked = (Options.Format = FormatOption.TreeView)
      mnuResultsReport.Checked = (Options.Format = FormatOption.Report)
      mnuResultsNoDetails.Checked = (Options.Detail = DetailOption.NoDetails)
      mnuResultsGroups.Checked = (Options.Detail = DetailOption.Groups)
      mnuResultsCaptures.Checked = (Options.Detail = DetailOption.GroupAndCaptures)
      txtViewMaxMatches.Text = Options.MaxMatches.ToString()
      mnuResultsIncludeEmptyGroups.Checked = Options.IncludeEmptyGroups
      mnuResultsDontSort.Checked = (Options.Sort = SortOption.Position)
      mnuResultsSortAlphabetically.Checked = (Options.Sort = SortOption.Alphabetic)
      mnuResultsShortest.Checked = (Options.Sort = SortOption.ShortestFirst)
      mnuResultsLargest.Checked = (Options.Sort = SortOption.LargestFirst)

      tvwResults.Visible = (Options.Format = FormatOption.TreeView OrElse (Options.Format = FormatOption.Auto AndAlso Options.Command = Command.Find))
      rtbResults.Visible = Not tvwResults.Visible
      staItemInfo.Visible = tvwResults.Visible
      If tvwResults.Visible Then
         lblMatches.Text = "Matches"
      Else
         lblMatches.Text = "Report"
      End If

      If Options.Command = Command.Replace Then
         rtbRegex.Size = New Size(rtbRegex.Width, rtbReplace.Top - rtbRegex.Top - 10)
         rtbReplace.Visible = True
         lblReplace.Visible = True
      Else
         rtbRegex.Size = New Size(rtbRegex.Width, rtbReplace.Bottom - rtbRegex.Top)
         rtbReplace.Visible = False
         lblReplace.Visible = False
      End If

      rtbRegex.WordWrap = Options.WordWrap
      rtbReplace.WordWrap = Options.WordWrap
      rtbSource.WordWrap = Options.WordWrap
      rtbResults.WordWrap = Options.WordWrap
      If Options.WordWrap Then
         rtbRegex.ScrollBars = RichTextBoxScrollBars.Vertical
         rtbReplace.ScrollBars = RichTextBoxScrollBars.Vertical
         rtbSource.ScrollBars = RichTextBoxScrollBars.Vertical
         rtbResults.ScrollBars = RichTextBoxScrollBars.Vertical
      Else
         rtbRegex.ScrollBars = RichTextBoxScrollBars.Both
         rtbReplace.ScrollBars = RichTextBoxScrollBars.Both
         rtbSource.ScrollBars = RichTextBoxScrollBars.Both
         rtbResults.ScrollBars = RichTextBoxScrollBars.Both
      End If
   End Sub

   ' Build the regex context menu

   Sub BuildRegexMenu()
      ' Read the embedded XML document.
      Dim st As Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RegexTester.Regexes.xml")
      Dim sr As New StreamReader(st)
      Dim xmlText As String = sr.ReadToEnd()
      sr.Close()

      ' Parse it.
      Dim xmlDoc As New XmlDocument()
      xmlDoc.LoadXml(xmlText)

      BuildRegexMenu_Sub(xmlDoc, ctxPattern, 1)
      BuildRegexMenu_Sub(xmlDoc, ctxReplace, 2)

   End Sub

   Sub BuildRegexMenu_Sub(ByVal xmlDoc As XmlDocument, ByVal rootMenu As ContextMenuStrip, ByVal bitMask As Integer)
      ' Parse groups
      For Each groupNode As XmlElement In xmlDoc.SelectNodes("//group")
         Dim includeBits As Integer = CInt(groupNode.GetAttribute("includeBits"))
         If (includeBits And bitMask) = 0 Then Continue For

         ' Create the group menu
         Dim groupText As String = groupNode.GetAttribute("text").Replace("§", "&")
         ' Add a separator if text is "-"
         If groupText = "-" Then
            rootMenu.Items.Add(New ToolStripSeparator)
            Continue For
         End If

         Dim groupToolTip As String = groupNode.GetAttribute("toolTip").Replace("§", ControlChars.CrLf)
         Dim groupMenuItem As New ToolStripMenuItem(groupText)
         groupMenuItem.ToolTipText = groupToolTip
         rootMenu.Items.Add(groupMenuItem)

         ' Parse items
         For Each itemNode As XmlElement In groupNode.SelectNodes("item")
            Dim itemText As String = itemNode.GetAttribute("text").Replace("§", "&")
            ' Add a separator if text is "-"
            If itemText = "-" Then
               groupMenuItem.DropDownItems.Add(New ToolStripSeparator)
               Continue For
            End If

            Dim itemToolTip As String = itemNode.GetAttribute("toolTip").Replace("§", ControlChars.CrLf)
            Dim regex As String = itemNode.GetAttribute("regex")
            Dim itemMenuItem As New ToolStripMenuItem(itemText)
            itemMenuItem.ToolTipText = itemToolTip
            itemMenuItem.Tag = regex
            groupMenuItem.DropDownItems.Add(itemMenuItem)

            AddHandler itemMenuItem.Click, AddressOf RegexMenu_Click
         Next
      Next
   End Sub

   '------------------------------------------------
   ' Menu handlers
   '------------------------------------------------

   ' File menu

   Private Sub mnuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click
      If Not OkToProceed() Then Exit Sub
      Options = New ProjectOptions()
      Options.ClearChanges()
      RefreshControlState()
   End Sub

   Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
      If Not OkToProceed() Then Exit Sub
      OpenRegex(Nothing)
   End Sub

   Private Sub mnuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click
      UpdateOptionFiels()
      SaveRegex(Options.RegexFile)
   End Sub

   Private Sub mnuFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSaveAs.Click
      UpdateOptionFiels()
      SaveRegex(Nothing)
   End Sub

   Private Sub mnuFileLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileLoad.Click
      If dlgOpenDoc.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
      Try
         Options.SourceText = File.ReadAllText(dlgOpenDoc.FileName)
         rtbSource.Text = Options.SourceText
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Unable to load document", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub mnuFileProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileProperties.Click
      UpdateOptionFiels()
      Dim frm As New PropertiesForm()
      frm.Options = Me.Options
      If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
      RefreshControlState()
   End Sub

   Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
      If Not OkToProceed() Then Exit Sub
      Application.Exit()
   End Sub

   ' Edit menu

   Private Sub mnuEditWordWrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditWordWrap.Click
      Options.WordWrap = Not Options.WordWrap
      RefreshOptionsState()
   End Sub

   ' Commands menu

   Private Sub mnuCommandsRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsRun.Click
      ExecuteCommand()
   End Sub

   Private Sub mnuCommandsFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsFind.Click
      If Options.Command = Command.Find Then Exit Sub
      Options.Command = Command.Find
      rtbResults.Clear()
      RefreshOptionsState()
   End Sub

   Private Sub mnuCommandsReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsReplace.Click
      If Options.Command = Command.Replace Then Exit Sub
      Options.Command = Command.Replace
      rtbResults.Clear()
      RefreshOptionsState()
   End Sub

   Private Sub mnuCommandsSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsSplit.Click
      If Options.Command = Command.Split Then Exit Sub
      Options.Command = Command.Split
      rtbResults.Clear()
      RefreshOptionsState()
   End Sub

   Private Sub mnuCommandsShowGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsShowGroups.Click
      Dim sb As New StringBuilder
      Try
         Dim re As New Regex(rtbRegex.Text)
         Dim names() As String = re.GetGroupNames()
         For i As Integer = 0 To names.Length - 1
            If names(i) = i.ToString() Then
               sb.AppendFormat("group[{0}]", i)
            Else
               sb.AppendFormat("group[{0}] = {1}", i, names(i))
            End If
            sb.AppendLine()
         Next
         MessageBox.Show(sb.ToString(), "Capturing Groups", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         ' ignore exceptions
      End Try
   End Sub

   Private Sub mnuCommandsEscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsEscape.Click
      UpdateOptionFiels()
      Dim frm As New EscapeForm
      frm.Options = Me.Options
      frm.ShowDialog()
   End Sub

   Private Sub mnuCommandsGenerateCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsGenerateCode.Click
      UpdateOptionFiels()
      Dim frm As New GenerateCodeForm()
      frm.Options = Me.Options
      frm.ShowDialog()
   End Sub

   Private Sub mnuCommandsCompile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCommandsCompile.Click
      If Me.CompileForm Is Nothing Then
         Me.CompileForm = New CompileForm
         Me.CompileForm.MainForm = Me
      End If
      Me.CompileForm.Show()
   End Sub

   ' Options menu

   Private Sub mnuOptionsMultiline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsMultiline.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.Multiline
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsIgnoreCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsIgnoreCase.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.IgnoreCase
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsIgnoreWhitespace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsIgnoreWhitespace.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.IgnorePatternWhitespace
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsCompiled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsCompiled.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.Compiled
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsExplicitCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsExplicitCapture.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.ExplicitCapture
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsRightToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsRightToLeft.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.RightToLeft
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsCultureInvariant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsCultureInvariant.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.CultureInvariant
      RefreshOptionsState()
   End Sub

   Private Sub mnuOptionsEcmaScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsEcmaScript.Click
      Options.RegexOptions = Options.RegexOptions Xor RegexOptions.ECMAScript
      RefreshOptionsState()
   End Sub


   ' Results menu 

   Private Sub mnuResultsAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsAuto.Click
      Options.Format = FormatOption.Auto
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsTreeView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsTreeView.Click
      Options.Format = FormatOption.TreeView
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsReport.Click
      Options.Format = FormatOption.Report
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsNoDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsNoDetails.Click
      Options.Detail = DetailOption.NoDetails
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsGroups.Click
      Options.Detail = DetailOption.Groups
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsCaptures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsCaptures.Click
      Options.Detail = DetailOption.GroupAndCaptures
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsIncludeEmptyGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsIncludeEmptyGroups.Click
      Options.IncludeEmptyGroups = Not Options.IncludeEmptyGroups
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsDontSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsDontSort.Click
      Options.Sort = SortOption.Position
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsSortAlphabetically_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsSortAlphabetically.Click
      Options.Sort = SortOption.Alphabetic
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsShortest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsShortest.Click
      Options.Sort = SortOption.ShortestFirst
      RefreshOptionsState()
   End Sub

   Private Sub mnuResultsLargest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultsLargest.Click
      Options.Sort = SortOption.LargestFirst
      RefreshOptionsState()
   End Sub

   ' Help menu

   Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
      Dim frm As New AboutBoxForm
      frm.ShowDialog()
   End Sub

   ' Context menu

   Private Sub RegexMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rootMenu As ToolStrip = DirectCast(sender, ToolStripMenuItem).OwnerItem.Owner

      Dim ctrl As RichTextBox = Me.rtbRegex
      If rootMenu Is ctxReplace Then ctrl = rtbReplace

      ' Retrieve the regex
      Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
      Dim regex As String = CStr(menuItem.Tag)
      Dim selStart As Integer = rtbRegex.SelectionStart

      ' Insert the regex, but drop the placeholder chars.
      ctrl.SelectedText = regex.Replace("§", "")
      ' Select the portion embedded in § chars
      Dim i As Integer = regex.IndexOf("§")
      If i >= 0 Then
         Dim j As Integer = regex.IndexOf("§", i + 1)
         ctrl.Select(selStart + i, j - i - 1)
      End If
   End Sub


   '------------------------------------------------
   ' Control event handlers
   '------------------------------------------------

   Private Sub tvwResults_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwResults.AfterSelect
      Dim nodeInfo As NodeInfo = DirectCast(e.Node.Tag, NodeInfo)
      Dim kind As String = nodeInfo.Item.GetType().Name.ToUpper()

      Me.staItemInfo.Text = String.Format("{0}[{1}]: Index={2}, Length={3}", kind, nodeInfo.Name, nodeInfo.Item.Index, nodeInfo.Item.Length)

      ' Select the text in the source textbox
      rtbSource.Select(nodeInfo.Item.Index, nodeInfo.Item.Length)
      rtbSource.ScrollToCaret()
   End Sub


   Private Sub tvwResults_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwResults.BeforeExpand
      ' Exit right now if nothing to expand
      If e.Node.Nodes.Count <> 1 AndAlso e.Node.Nodes(0).Text <> "*" Then Exit Sub
      ' Remove the dummy child node.
      e.Node.Nodes.Clear()

      Dim nodeInfo As NodeInfo = DirectCast(e.Node.Tag, NodeInfo)

      If nodeInfo.Item.GetType() Is GetType(Match) Then
         Dim m As Match = DirectCast(nodeInfo.Item, Match)
         ' Expand all the groups in this match, skip group 0
         For index As Integer = 1 To m.Groups.Count - 1
            Dim g As Group = m.Groups(index)
            ' skip empty groups if so required
            If g.Length = 0 AndAlso Not Options.IncludeEmptyGroups Then Continue For

            Dim node As TreeNode = e.Node.Nodes.Add(g.Value)
            node.Tag = New NodeInfo(g, re.GroupNameFromNumber(index))
            ' If there are any captures, add a dummy child node.
            If Options.Detail = DetailOption.GroupAndCaptures AndAlso g.Captures.Count > 0 Then node.Nodes.Add("*")
         Next

      ElseIf nodeInfo.Item.GetType() Is GetType(Group) Then
         Dim g As Group = DirectCast(nodeInfo.Item, Group)
         For index As Integer = 0 To g.Captures.Count - 1
            Dim c As Capture = g.Captures(index)
            If c.GetType() Is GetType(Group) Then Continue For
            Dim node As TreeNode = e.Node.Nodes.Add(c.Value)
            node.Tag = New NodeInfo(c, index.ToString())
         Next
      End If

   End Sub

   Private Sub txtViewMaxMatches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtViewMaxMatches.TextChanged
      Dim n As Integer
      If Integer.TryParse(txtViewMaxMatches.Text, n) Then
         Options.MaxMatches = n
      End If
   End Sub


   Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' set all tooltips and help messages
      Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
      BuildRegexMenu()
      rtbResults.Bounds = tvwResults.Bounds

      ' Clear the status bar
      staMatches.Text = ""
      staExecutionTime.Text = ""
      staItemInfo.Text = ""

      Options.ClearChanges()

      'Dim text As String = File.ReadAllText("d:\book.txt")
      'rtbSource.Text = text
      'rtbRegex.Text = "(A\w+|B\w+)"
      'Options.Detail = DetailOption.GroupAndCaptures
      'RefreshOptionsState()
   End Sub

End Class

Class NodeInfo
   Public ReadOnly Item As Capture
   Public ReadOnly Name As String

   Sub New(ByVal item As Capture, ByVal name As String)
      Me.Item = item
      Me.Name = name
   End Sub
End Class