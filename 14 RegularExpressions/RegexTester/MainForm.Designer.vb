<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ctxPattern = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.Label1 = New System.Windows.Forms.Label
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
      Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuFileProperties = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuFileLoad = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuEditWordWrap = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommands = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsRun = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuCommandsFind = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsReplace = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsSplit = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuCommandsShowGroups = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsEscape = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsGenerateCode = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuCommandsCompile = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsIgnoreCase = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsIgnoreWhitespace = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsMultiline = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsCompiled = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsExplicitCapture = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsRightToLeft = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsCultureInvariant = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOptionsEcmaScript = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResults = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsTreeView = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsReport = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsAuto = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuResultsNoDetails = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsGroups = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsCaptures = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripMenuItem
      Me.txtViewMaxMatches = New System.Windows.Forms.ToolStripTextBox
      Me.mnuResultsIncludeEmptyGroups = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuResultsDontSort = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsSortAlphabetically = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsShortest = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuResultsLargest = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem
      Me.dlgOpenDoc = New System.Windows.Forms.OpenFileDialog
      Me.rtbSource = New System.Windows.Forms.RichTextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.lblReplace = New System.Windows.Forms.Label
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.staMatches = New System.Windows.Forms.ToolStripStatusLabel
      Me.staExecutionTime = New System.Windows.Forms.ToolStripStatusLabel
      Me.staItemInfo = New System.Windows.Forms.ToolStripStatusLabel
      Me.ctxReplace = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.tvwResults = New System.Windows.Forms.TreeView
      Me.rtbResults = New System.Windows.Forms.RichTextBox
      Me.rtbRegex = New System.Windows.Forms.RichTextBox
      Me.rtbReplace = New System.Windows.Forms.RichTextBox
      Me.lblMatches = New System.Windows.Forms.Label
      Me.dlgOpenRegex = New System.Windows.Forms.OpenFileDialog
      Me.dlgSaveRegex = New System.Windows.Forms.SaveFileDialog
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
      Me.MenuStrip1.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ctxPattern
      '
      Me.ctxPattern.Name = "ctxPattern"
      Me.ctxPattern.Size = New System.Drawing.Size(61, 4)
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(12, 33)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(63, 38)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Regex"
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuCommands, Me.mnuOptions, Me.mnuResults, Me.mnuHelp})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.MenuStrip1.Size = New System.Drawing.Size(753, 24)
      Me.MenuStrip1.TabIndex = 0
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'mnuFile
      '
      Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveAs, Me.ToolStripSeparator4, Me.mnuFileProperties, Me.ToolStripSeparator5, Me.mnuFileLoad, Me.ToolStripSeparator6, Me.mnuFileExit})
      Me.mnuFile.Name = "mnuFile"
      Me.mnuFile.Size = New System.Drawing.Size(35, 20)
      Me.mnuFile.Text = "&File"
      '
      'mnuFileNew
      '
      Me.mnuFileNew.Name = "mnuFileNew"
      Me.mnuFileNew.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileNew.Text = "&New"
      '
      'mnuFileOpen
      '
      Me.mnuFileOpen.Name = "mnuFileOpen"
      Me.mnuFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me.mnuFileOpen.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileOpen.Text = "&Open ..."
      '
      'mnuFileSave
      '
      Me.mnuFileSave.Name = "mnuFileSave"
      Me.mnuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
      Me.mnuFileSave.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileSave.Text = "&Save"
      '
      'mnuFileSaveAs
      '
      Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
      Me.mnuFileSaveAs.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileSaveAs.Text = "Save &as ..."
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
      '
      'mnuFileProperties
      '
      Me.mnuFileProperties.Name = "mnuFileProperties"
      Me.mnuFileProperties.ShortcutKeys = System.Windows.Forms.Keys.F4
      Me.mnuFileProperties.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileProperties.Text = "&Properties"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(177, 6)
      '
      'mnuFileLoad
      '
      Me.mnuFileLoad.Name = "mnuFileLoad"
      Me.mnuFileLoad.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
      Me.mnuFileLoad.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileLoad.Text = "&Load source"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(177, 6)
      '
      'mnuFileExit
      '
      Me.mnuFileExit.Name = "mnuFileExit"
      Me.mnuFileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
      Me.mnuFileExit.Size = New System.Drawing.Size(180, 22)
      Me.mnuFileExit.Text = "E&xit"
      '
      'mnuEdit
      '
      Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditWordWrap})
      Me.mnuEdit.Name = "mnuEdit"
      Me.mnuEdit.Size = New System.Drawing.Size(37, 20)
      Me.mnuEdit.Text = "&Edit"
      '
      'mnuEditWordWrap
      '
      Me.mnuEditWordWrap.Name = "mnuEditWordWrap"
      Me.mnuEditWordWrap.Size = New System.Drawing.Size(138, 22)
      Me.mnuEditWordWrap.Text = "&Word wrap"
      '
      'mnuCommands
      '
      Me.mnuCommands.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCommandsRun, Me.ToolStripSeparator3, Me.mnuCommandsFind, Me.mnuCommandsReplace, Me.mnuCommandsSplit, Me.ToolStripSeparator1, Me.mnuCommandsShowGroups, Me.mnuCommandsEscape, Me.mnuCommandsGenerateCode, Me.mnuCommandsCompile})
      Me.mnuCommands.Name = "mnuCommands"
      Me.mnuCommands.Size = New System.Drawing.Size(71, 20)
      Me.mnuCommands.Text = "&Commands"
      '
      'mnuCommandsRun
      '
      Me.mnuCommandsRun.Name = "mnuCommandsRun"
      Me.mnuCommandsRun.ShortcutKeys = System.Windows.Forms.Keys.F5
      Me.mnuCommandsRun.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsRun.Text = "&Run"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
      '
      'mnuCommandsFind
      '
      Me.mnuCommandsFind.Name = "mnuCommandsFind"
      Me.mnuCommandsFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
      Me.mnuCommandsFind.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsFind.Text = "&Find"
      '
      'mnuCommandsReplace
      '
      Me.mnuCommandsReplace.Name = "mnuCommandsReplace"
      Me.mnuCommandsReplace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
      Me.mnuCommandsReplace.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsReplace.Text = "&Replace"
      '
      'mnuCommandsSplit
      '
      Me.mnuCommandsSplit.Name = "mnuCommandsSplit"
      Me.mnuCommandsSplit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
      Me.mnuCommandsSplit.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsSplit.Text = "&Split"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(180, 6)
      '
      'mnuCommandsShowGroups
      '
      Me.mnuCommandsShowGroups.Name = "mnuCommandsShowGroups"
      Me.mnuCommandsShowGroups.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsShowGroups.Text = "&Show groups"
      '
      'mnuCommandsEscape
      '
      Me.mnuCommandsEscape.Name = "mnuCommandsEscape"
      Me.mnuCommandsEscape.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsEscape.Text = "&Escape"
      '
      'mnuCommandsGenerateCode
      '
      Me.mnuCommandsGenerateCode.Name = "mnuCommandsGenerateCode"
      Me.mnuCommandsGenerateCode.ShortcutKeys = System.Windows.Forms.Keys.F2
      Me.mnuCommandsGenerateCode.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsGenerateCode.Text = "&Generate code"
      '
      'mnuCommandsCompile
      '
      Me.mnuCommandsCompile.Name = "mnuCommandsCompile"
      Me.mnuCommandsCompile.Size = New System.Drawing.Size(183, 22)
      Me.mnuCommandsCompile.Text = "&Compile to Assembly"
      '
      'mnuOptions
      '
      Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptionsIgnoreCase, Me.mnuOptionsIgnoreWhitespace, Me.mnuOptionsMultiline, Me.mnuOptionsCompiled, Me.mnuOptionsExplicitCapture, Me.mnuOptionsRightToLeft, Me.mnuOptionsCultureInvariant, Me.mnuOptionsEcmaScript})
      Me.mnuOptions.Name = "mnuOptions"
      Me.mnuOptions.Size = New System.Drawing.Size(56, 20)
      Me.mnuOptions.Text = "&Options"
      '
      'mnuOptionsIgnoreCase
      '
      Me.mnuOptionsIgnoreCase.Name = "mnuOptionsIgnoreCase"
      Me.mnuOptionsIgnoreCase.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsIgnoreCase.Text = "&Ignore case"
      '
      'mnuOptionsIgnoreWhitespace
      '
      Me.mnuOptionsIgnoreWhitespace.Name = "mnuOptionsIgnoreWhitespace"
      Me.mnuOptionsIgnoreWhitespace.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsIgnoreWhitespace.Text = "Ignore &Whitespace"
      '
      'mnuOptionsMultiline
      '
      Me.mnuOptionsMultiline.Name = "mnuOptionsMultiline"
      Me.mnuOptionsMultiline.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsMultiline.Text = "&Multiline"
      '
      'mnuOptionsCompiled
      '
      Me.mnuOptionsCompiled.Name = "mnuOptionsCompiled"
      Me.mnuOptionsCompiled.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsCompiled.Text = "&Compiled"
      '
      'mnuOptionsExplicitCapture
      '
      Me.mnuOptionsExplicitCapture.Name = "mnuOptionsExplicitCapture"
      Me.mnuOptionsExplicitCapture.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsExplicitCapture.Text = "&Explicit capture"
      '
      'mnuOptionsRightToLeft
      '
      Me.mnuOptionsRightToLeft.Name = "mnuOptionsRightToLeft"
      Me.mnuOptionsRightToLeft.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsRightToLeft.Text = "&Right to left"
      '
      'mnuOptionsCultureInvariant
      '
      Me.mnuOptionsCultureInvariant.Name = "mnuOptionsCultureInvariant"
      Me.mnuOptionsCultureInvariant.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsCultureInvariant.Text = "C&ulture invariant"
      '
      'mnuOptionsEcmaScript
      '
      Me.mnuOptionsEcmaScript.Name = "mnuOptionsEcmaScript"
      Me.mnuOptionsEcmaScript.Size = New System.Drawing.Size(176, 22)
      Me.mnuOptionsEcmaScript.Text = "EC&MAScript"
      '
      'mnuResults
      '
      Me.mnuResults.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuResultsTreeView, Me.mnuResultsReport, Me.mnuResultsAuto, Me.ToolStripSeparator7, Me.mnuResultsNoDetails, Me.mnuResultsGroups, Me.mnuResultsCaptures, Me.ToolStripSeparator2, Me.ToolStripTextBox1, Me.mnuResultsIncludeEmptyGroups, Me.ToolStripMenuItem1, Me.mnuResultsDontSort, Me.mnuResultsSortAlphabetically, Me.mnuResultsShortest, Me.mnuResultsLargest})
      Me.mnuResults.Name = "mnuResults"
      Me.mnuResults.Size = New System.Drawing.Size(54, 20)
      Me.mnuResults.Text = "&Results"
      '
      'mnuResultsTreeView
      '
      Me.mnuResultsTreeView.Name = "mnuResultsTreeView"
      Me.mnuResultsTreeView.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsTreeView.Text = "&Tree view"
      '
      'mnuResultsReport
      '
      Me.mnuResultsReport.Name = "mnuResultsReport"
      Me.mnuResultsReport.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsReport.Text = "&Report"
      '
      'mnuResultsAuto
      '
      Me.mnuResultsAuto.Name = "mnuResultsAuto"
      Me.mnuResultsAuto.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsAuto.Text = "&Auto"
      '
      'ToolStripSeparator7
      '
      Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
      Me.ToolStripSeparator7.Size = New System.Drawing.Size(192, 6)
      '
      'mnuResultsNoDetails
      '
      Me.mnuResultsNoDetails.Name = "mnuResultsNoDetails"
      Me.mnuResultsNoDetails.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsNoDetails.Text = "N&o details"
      '
      'mnuResultsGroups
      '
      Me.mnuResultsGroups.Name = "mnuResultsGroups"
      Me.mnuResultsGroups.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsGroups.Text = "&Groups"
      '
      'mnuResultsCaptures
      '
      Me.mnuResultsCaptures.Name = "mnuResultsCaptures"
      Me.mnuResultsCaptures.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsCaptures.Text = "Groups and &Captures"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(192, 6)
      '
      'ToolStripTextBox1
      '
      Me.ToolStripTextBox1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtViewMaxMatches})
      Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
      Me.ToolStripTextBox1.Size = New System.Drawing.Size(195, 22)
      Me.ToolStripTextBox1.Text = "&Max number  of results"
      '
      'txtViewMaxMatches
      '
      Me.txtViewMaxMatches.Name = "txtViewMaxMatches"
      Me.txtViewMaxMatches.Size = New System.Drawing.Size(100, 21)
      Me.txtViewMaxMatches.Text = "1000"
      '
      'mnuResultsIncludeEmptyGroups
      '
      Me.mnuResultsIncludeEmptyGroups.Name = "mnuResultsIncludeEmptyGroups"
      Me.mnuResultsIncludeEmptyGroups.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsIncludeEmptyGroups.Text = "&Include empty groups"
      '
      'ToolStripMenuItem1
      '
      Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
      Me.ToolStripMenuItem1.Size = New System.Drawing.Size(192, 6)
      '
      'mnuResultsDontSort
      '
      Me.mnuResultsDontSort.Name = "mnuResultsDontSort"
      Me.mnuResultsDontSort.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsDontSort.Text = "Sort on &Position"
      '
      'mnuResultsSortAlphabetically
      '
      Me.mnuResultsSortAlphabetically.Name = "mnuResultsSortAlphabetically"
      Me.mnuResultsSortAlphabetically.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsSortAlphabetically.Text = "Sort on &Name"
      '
      'mnuResultsShortest
      '
      Me.mnuResultsShortest.Name = "mnuResultsShortest"
      Me.mnuResultsShortest.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsShortest.Text = "&Shortest matches first"
      '
      'mnuResultsLargest
      '
      Me.mnuResultsLargest.Name = "mnuResultsLargest"
      Me.mnuResultsLargest.Size = New System.Drawing.Size(195, 22)
      Me.mnuResultsLargest.Text = "&Largest matches first"
      '
      'mnuHelp
      '
      Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
      Me.mnuHelp.Name = "mnuHelp"
      Me.mnuHelp.Size = New System.Drawing.Size(40, 20)
      Me.mnuHelp.Text = "&Help"
      '
      'mnuHelpAbout
      '
      Me.mnuHelpAbout.Name = "mnuHelpAbout"
      Me.mnuHelpAbout.Size = New System.Drawing.Size(114, 22)
      Me.mnuHelpAbout.Text = "&About"
      '
      'dlgOpenDoc
      '
      Me.dlgOpenDoc.Filter = "Text files (*.txt;*.doc)|*.txt;*.doc|All files|*.*"
      Me.dlgOpenDoc.Title = "Open a text document"
      '
      'rtbSource
      '
      Me.rtbSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbSource.DetectUrls = False
      Me.rtbSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.rtbSource.HideSelection = False
      Me.rtbSource.Location = New System.Drawing.Point(67, 188)
      Me.rtbSource.Name = "rtbSource"
      Me.rtbSource.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
      Me.rtbSource.Size = New System.Drawing.Size(674, 101)
      Me.rtbSource.TabIndex = 6
      Me.rtbSource.Text = ""
      Me.ToolTip1.SetToolTip(Me.rtbSource, "The text on which the regular expression is applied. se the File-Load menu to l" & _
              "oad a text file.")
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(12, 191)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(75, 38)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Source"
      '
      'lblReplace
      '
      Me.lblReplace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblReplace.Location = New System.Drawing.Point(12, 123)
      Me.lblReplace.Name = "lblReplace"
      Me.lblReplace.Size = New System.Drawing.Size(60, 40)
      Me.lblReplace.TabIndex = 3
      Me.lblReplace.Text = "Replace"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.staMatches, Me.staExecutionTime, Me.staItemInfo})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
      Me.StatusStrip1.MinimumSize = New System.Drawing.Size(753, 22)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(753, 22)
      Me.StatusStrip1.TabIndex = 10
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'staMatches
      '
      Me.staMatches.ForeColor = System.Drawing.SystemColors.ActiveCaption
      Me.staMatches.Name = "staMatches"
      Me.staMatches.Size = New System.Drawing.Size(80, 17)
      Me.staMatches.Text = "Found matches"
      '
      'staExecutionTime
      '
      Me.staExecutionTime.Name = "staExecutionTime"
      Me.staExecutionTime.Size = New System.Drawing.Size(77, 17)
      Me.staExecutionTime.Text = "Execution time"
      '
      'staItemInfo
      '
      Me.staItemInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption
      Me.staItemInfo.Name = "staItemInfo"
      Me.staItemInfo.Size = New System.Drawing.Size(50, 17)
      Me.staItemInfo.Text = "Item info"
      '
      'ctxReplace
      '
      Me.ctxReplace.Name = "ctxPattern"
      Me.ctxReplace.Size = New System.Drawing.Size(61, 4)
      '
      'tvwResults
      '
      Me.tvwResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tvwResults.Location = New System.Drawing.Point(67, 305)
      Me.tvwResults.Name = "tvwResults"
      Me.tvwResults.ShowRootLines = False
      Me.tvwResults.Size = New System.Drawing.Size(674, 164)
      Me.tvwResults.TabIndex = 8
      Me.ToolTip1.SetToolTip(Me.tvwResults, "All the matches found. ouble-click on an item to see groups and captures.")
      '
      'rtbResults
      '
      Me.rtbResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbResults.DetectUrls = False
      Me.rtbResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.rtbResults.HideSelection = False
      Me.rtbResults.Location = New System.Drawing.Point(12, 360)
      Me.rtbResults.Name = "rtbResults"
      Me.rtbResults.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
      Me.rtbResults.Size = New System.Drawing.Size(28, 45)
      Me.rtbResults.TabIndex = 9
      Me.rtbResults.Text = ""
      Me.ToolTip1.SetToolTip(Me.rtbResults, "The replaced text, or the split elements, or the matches in report format.")
      '
      'rtbRegex
      '
      Me.rtbRegex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbRegex.ContextMenuStrip = Me.ctxPattern
      Me.rtbRegex.DetectUrls = False
      Me.rtbRegex.Location = New System.Drawing.Point(67, 33)
      Me.rtbRegex.Name = "rtbRegex"
      Me.rtbRegex.Size = New System.Drawing.Size(674, 84)
      Me.rtbRegex.TabIndex = 2
      Me.rtbRegex.Text = ""
      Me.ToolTip1.SetToolTip(Me.rtbRegex, "The regular expression pattern. ight-click to display list of common patterns.")
      '
      'rtbReplace
      '
      Me.rtbReplace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbReplace.ContextMenuStrip = Me.ctxReplace
      Me.rtbReplace.DetectUrls = False
      Me.rtbReplace.Location = New System.Drawing.Point(67, 123)
      Me.rtbReplace.Name = "rtbReplace"
      Me.rtbReplace.Size = New System.Drawing.Size(674, 48)
      Me.rtbReplace.TabIndex = 4
      Me.rtbReplace.Text = ""
      Me.ToolTip1.SetToolTip(Me.rtbReplace, "The replace pattern. ight-click to display list of common patterns.")
      '
      'lblMatches
      '
      Me.lblMatches.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMatches.Location = New System.Drawing.Point(12, 305)
      Me.lblMatches.Name = "lblMatches"
      Me.lblMatches.Size = New System.Drawing.Size(75, 38)
      Me.lblMatches.TabIndex = 7
      Me.lblMatches.Text = "Matches"
      '
      'dlgOpenRegex
      '
      Me.dlgOpenRegex.DefaultExt = "regex"
      Me.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
      Me.dlgOpenRegex.Title = "Open a regex file"
      '
      'dlgSaveRegex
      '
      Me.dlgSaveRegex.DefaultExt = "regex"
      Me.dlgSaveRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
      Me.dlgSaveRegex.Title = "Save a regex file"
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(753, 500)
      Me.Controls.Add(Me.rtbRegex)
      Me.Controls.Add(Me.tvwResults)
      Me.Controls.Add(Me.rtbReplace)
      Me.Controls.Add(Me.MenuStrip1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.rtbResults)
      Me.Controls.Add(Me.lblReplace)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblMatches)
      Me.Controls.Add(Me.rtbSource)
      Me.Controls.Add(Me.Label2)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "MainForm"
      Me.Text = "Code Architects Regex Tester"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsIgnoreCase As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsMultiline As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsIgnoreWhitespace As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsCompiled As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsExplicitCapture As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsRightToLeft As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsCultureInvariant As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuOptionsEcmaScript As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents dlgOpenDoc As System.Windows.Forms.OpenFileDialog
   Friend WithEvents rtbSource As System.Windows.Forms.RichTextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResults As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommands As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommandsFind As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommandsReplace As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommandsSplit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuCommandsEscape As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents lblReplace As System.Windows.Forms.Label
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents staExecutionTime As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents staMatches As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tvwResults As System.Windows.Forms.TreeView
   Friend WithEvents mnuResultsGroups As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsCaptures As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsNoDetails As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuResultsDontSort As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsSortAlphabetically As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsShortest As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsLargest As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents txtViewMaxMatches As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents rtbResults As System.Windows.Forms.RichTextBox
   Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ctxPattern As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ctxReplace As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents rtbRegex As System.Windows.Forms.RichTextBox
   Friend WithEvents rtbReplace As System.Windows.Forms.RichTextBox
   Friend WithEvents mnuCommandsRun As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuFileSave As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuFileSaveAs As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuFileProperties As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuFileLoad As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents staItemInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents mnuResultsTreeView As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsReport As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblMatches As System.Windows.Forms.Label
   Friend WithEvents mnuResultsAuto As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuEditWordWrap As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents dlgOpenRegex As System.Windows.Forms.OpenFileDialog
   Friend WithEvents dlgSaveRegex As System.Windows.Forms.SaveFileDialog
   Friend WithEvents mnuCommandsGenerateCode As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommandsShowGroups As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuResultsIncludeEmptyGroups As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuCommandsCompile As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
   Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
End Class
