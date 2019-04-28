<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.chkEcmaScript = New System.Windows.Forms.CheckBox
      Me.chkCultureInvariant = New System.Windows.Forms.CheckBox
      Me.chkRightToLeft = New System.Windows.Forms.CheckBox
      Me.chkExplicitCapture = New System.Windows.Forms.CheckBox
      Me.chkCompiled = New System.Windows.Forms.CheckBox
      Me.chkMultiline = New System.Windows.Forms.CheckBox
      Me.chkIgnoreWhitespace = New System.Windows.Forms.CheckBox
      Me.chkIgnoreCase = New System.Windows.Forms.CheckBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtDescription = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.chkIncludeEmptyGroups = New System.Windows.Forms.CheckBox
      Me.numMatches = New System.Windows.Forms.NumericUpDown
      Me.Label7 = New System.Windows.Forms.Label
      Me.cboDetails = New System.Windows.Forms.ComboBox
      Me.Label6 = New System.Windows.Forms.Label
      Me.cboSort = New System.Windows.Forms.ComboBox
      Me.Label5 = New System.Windows.Forms.Label
      Me.cboFormat = New System.Windows.Forms.ComboBox
      Me.Label4 = New System.Windows.Forms.Label
      Me.chkWordWrap = New System.Windows.Forms.CheckBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.GroupBox3 = New System.Windows.Forms.GroupBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      CType(Me.numMatches, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox3.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkEcmaScript)
      Me.GroupBox1.Controls.Add(Me.chkCultureInvariant)
      Me.GroupBox1.Controls.Add(Me.chkRightToLeft)
      Me.GroupBox1.Controls.Add(Me.chkExplicitCapture)
      Me.GroupBox1.Controls.Add(Me.chkCompiled)
      Me.GroupBox1.Controls.Add(Me.chkMultiline)
      Me.GroupBox1.Controls.Add(Me.chkIgnoreWhitespace)
      Me.GroupBox1.Controls.Add(Me.chkIgnoreCase)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.txtDescription)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.txtName)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(616, 182)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Regex"
      '
      'chkEcmaScript
      '
      Me.chkEcmaScript.AutoSize = True
      Me.chkEcmaScript.Location = New System.Drawing.Point(460, 150)
      Me.chkEcmaScript.Name = "chkEcmaScript"
      Me.chkEcmaScript.Size = New System.Drawing.Size(83, 17)
      Me.chkEcmaScript.TabIndex = 12
      Me.chkEcmaScript.Text = "ECM&AScript"
      Me.ToolTip1.SetToolTip(Me.chkEcmaScript, "Enables ECMAScript-compliant behavior. his flag can be used only in conjunction" & _
              " with the IgnoreCase, Multiline, and Compiled flags. ")
      Me.chkEcmaScript.UseVisualStyleBackColor = True
      '
      'chkCultureInvariant
      '
      Me.chkCultureInvariant.AutoSize = True
      Me.chkCultureInvariant.Location = New System.Drawing.Point(460, 127)
      Me.chkCultureInvariant.Name = "chkCultureInvariant"
      Me.chkCultureInvariant.Size = New System.Drawing.Size(102, 17)
      Me.chkCultureInvariant.TabIndex = 11
      Me.chkCultureInvariant.Text = "C&ulture invariant"
      Me.ToolTip1.SetToolTip(Me.chkCultureInvariant, "Uses the culture implied by CultureInfo.InvariantCulture, instead of he locale " & _
              "assigned to the current thread.")
      Me.chkCultureInvariant.UseVisualStyleBackColor = True
      '
      'chkRightToLeft
      '
      Me.chkRightToLeft.AutoSize = True
      Me.chkRightToLeft.Location = New System.Drawing.Point(310, 151)
      Me.chkRightToLeft.Name = "chkRightToLeft"
      Me.chkRightToLeft.Size = New System.Drawing.Size(80, 17)
      Me.chkRightToLeft.TabIndex = 10
      Me.chkRightToLeft.Text = "&Right to left"
      Me.ToolTip1.SetToolTip(Me.chkRightToLeft, "Specifies that the search is from right to left nstead of from left to right. I" & _
              "f a starting index is specified, t should point to the end of the string. ")
      Me.chkRightToLeft.UseVisualStyleBackColor = True
      '
      'chkExplicitCapture
      '
      Me.chkExplicitCapture.AutoSize = True
      Me.chkExplicitCapture.Location = New System.Drawing.Point(310, 128)
      Me.chkExplicitCapture.Name = "chkExplicitCapture"
      Me.chkExplicitCapture.Size = New System.Drawing.Size(98, 17)
      Me.chkExplicitCapture.TabIndex = 9
      Me.chkExplicitCapture.Text = "&Explicit capture"
      Me.ToolTip1.SetToolTip(Me.chkExplicitCapture, "Captures only explicitly named or numbered groups f the form (?<name>) so that " & _
              "naked parentheses act as noncapturing roups without your having to use the (?:" & _
              ") construct.")
      Me.chkExplicitCapture.UseVisualStyleBackColor = True
      '
      'chkCompiled
      '
      Me.chkCompiled.AutoSize = True
      Me.chkCompiled.Location = New System.Drawing.Point(206, 151)
      Me.chkCompiled.Name = "chkCompiled"
      Me.chkCompiled.Size = New System.Drawing.Size(69, 17)
      Me.chkCompiled.TabIndex = 8
      Me.chkCompiled.Text = "&Compiled"
      Me.ToolTip1.SetToolTip(Me.chkCompiled, "Compiles the regular expression and generates MSIL code; his option generates f" & _
              "aster code at the expense of longer start-up time.")
      Me.chkCompiled.UseVisualStyleBackColor = True
      '
      'chkMultiline
      '
      Me.chkMultiline.AutoSize = True
      Me.chkMultiline.Location = New System.Drawing.Point(206, 127)
      Me.chkMultiline.Name = "chkMultiline"
      Me.chkMultiline.Size = New System.Drawing.Size(64, 17)
      Me.chkMultiline.TabIndex = 7
      Me.chkMultiline.Text = "&Multiline"
      Me.ToolTip1.SetToolTip(Me.chkMultiline, "Multiline mode; changes the behavior of  and $ so that they match the beginning" & _
              " and end of individual lines, respectively, nstead of the whole string.")
      Me.chkMultiline.UseVisualStyleBackColor = True
      '
      'chkIgnoreWhitespace
      '
      Me.chkIgnoreWhitespace.AutoSize = True
      Me.chkIgnoreWhitespace.Location = New System.Drawing.Point(75, 151)
      Me.chkIgnoreWhitespace.Name = "chkIgnoreWhitespace"
      Me.chkIgnoreWhitespace.Size = New System.Drawing.Size(116, 17)
      Me.chkIgnoreWhitespace.TabIndex = 6
      Me.chkIgnoreWhitespace.Text = "Ignore &Whitespace"
      Me.ToolTip1.SetToolTip(Me.chkIgnoreWhitespace, "Ignores unescaped white space from the pattern and nables comments marked with " & _
              "#. Significant spaces n the pattern must be specified as [ ] or \x20.")
      Me.chkIgnoreWhitespace.UseVisualStyleBackColor = True
      '
      'chkIgnoreCase
      '
      Me.chkIgnoreCase.AutoSize = True
      Me.chkIgnoreCase.Location = New System.Drawing.Point(75, 128)
      Me.chkIgnoreCase.Name = "chkIgnoreCase"
      Me.chkIgnoreCase.Size = New System.Drawing.Size(83, 17)
      Me.chkIgnoreCase.TabIndex = 5
      Me.chkIgnoreCase.Text = "&Ignore Case"
      Me.ToolTip1.SetToolTip(Me.chkIgnoreCase, "Ignore case in searches")
      Me.chkIgnoreCase.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(9, 128)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Options"
      '
      'txtDescription
      '
      Me.txtDescription.AcceptsReturn = True
      Me.txtDescription.Location = New System.Drawing.Point(75, 58)
      Me.txtDescription.Multiline = True
      Me.txtDescription.Name = "txtDescription"
      Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtDescription.Size = New System.Drawing.Size(529, 52)
      Me.txtDescription.TabIndex = 3
      Me.ToolTip1.SetToolTip(Me.txtDescription, "The free-format description of the regular expression.an be used to generate co" & _
              "mments in code.")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(9, 58)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "&Description"
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(74, 25)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(530, 20)
      Me.txtName.TabIndex = 1
      Me.ToolTip1.SetToolTip(Me.txtName, "The name of the regular expression. t is used when the expression is compiled.")
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "&Name"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.chkIncludeEmptyGroups)
      Me.GroupBox2.Controls.Add(Me.numMatches)
      Me.GroupBox2.Controls.Add(Me.Label7)
      Me.GroupBox2.Controls.Add(Me.cboDetails)
      Me.GroupBox2.Controls.Add(Me.Label6)
      Me.GroupBox2.Controls.Add(Me.cboSort)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.cboFormat)
      Me.GroupBox2.Controls.Add(Me.Label4)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 212)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(295, 177)
      Me.GroupBox2.TabIndex = 1
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Results"
      '
      'chkIncludeEmptyGroups
      '
      Me.chkIncludeEmptyGroups.AutoSize = True
      Me.chkIncludeEmptyGroups.Location = New System.Drawing.Point(75, 150)
      Me.chkIncludeEmptyGroups.Name = "chkIncludeEmptyGroups"
      Me.chkIncludeEmptyGroups.Size = New System.Drawing.Size(127, 17)
      Me.chkIncludeEmptyGroups.TabIndex = 8
      Me.chkIncludeEmptyGroups.Text = "Include empty g&roups"
      Me.ToolTip1.SetToolTip(Me.chkIncludeEmptyGroups, "If selected, groups are included in results ven if they match an empty string.")
      Me.chkIncludeEmptyGroups.UseVisualStyleBackColor = True
      '
      'numMatches
      '
      Me.numMatches.Increment = New Decimal(New Integer() {100, 0, 0, 0})
      Me.numMatches.Location = New System.Drawing.Point(75, 26)
      Me.numMatches.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me.numMatches.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
      Me.numMatches.Name = "numMatches"
      Me.numMatches.Size = New System.Drawing.Size(83, 20)
      Me.numMatches.TabIndex = 1
      Me.numMatches.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.numMatches, "Maximum number of matches that are displayed.")
      Me.numMatches.Value = New Decimal(New Integer() {100, 0, 0, 0})
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(9, 26)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(73, 30)
      Me.Label7.TabIndex = 0
      Me.Label7.Text = "Ma&x number of matches"
      '
      'cboDetails
      '
      Me.cboDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboDetails.FormattingEnabled = True
      Me.cboDetails.Items.AddRange(New Object() {"No details", "Groups", "Groups and Captures"})
      Me.cboDetails.Location = New System.Drawing.Point(75, 123)
      Me.cboDetails.Name = "cboDetails"
      Me.cboDetails.Size = New System.Drawing.Size(186, 21)
      Me.cboDetails.TabIndex = 7
      Me.ToolTip1.SetToolTip(Me.cboDetails, "Whether groups and captures are displayed in results")
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(9, 123)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(39, 13)
      Me.Label6.TabIndex = 6
      Me.Label6.Text = "De&tails"
      '
      'cboSort
      '
      Me.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboSort.FormattingEnabled = True
      Me.cboSort.Items.AddRange(New Object() {"Sort on Position", "Sort on Name", "Shortest first", "Longest first"})
      Me.cboSort.Location = New System.Drawing.Point(74, 93)
      Me.cboSort.Name = "cboSort"
      Me.cboSort.Size = New System.Drawing.Size(186, 21)
      Me.cboSort.TabIndex = 5
      Me.ToolTip1.SetToolTip(Me.cboSort, "How results are sorted")
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(10, 93)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(26, 13)
      Me.Label5.TabIndex = 4
      Me.Label5.Text = "&Sort"
      '
      'cboFormat
      '
      Me.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormat.FormattingEnabled = True
      Me.cboFormat.Items.AddRange(New Object() {"Auto", "Treeview", "Report"})
      Me.cboFormat.Location = New System.Drawing.Point(74, 58)
      Me.cboFormat.Name = "cboFormat"
      Me.cboFormat.Size = New System.Drawing.Size(186, 21)
      Me.cboFormat.TabIndex = 3
      Me.ToolTip1.SetToolTip(Me.cboFormat, "Sets the format used to display results. esults are displayed either in a treev" & _
              "iew or a textbox. y default, the Find command uses the treeview, all other com" & _
              "mands use the textbox.")
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(9, 61)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(39, 13)
      Me.Label4.TabIndex = 2
      Me.Label4.Text = "&Format"
      '
      'chkWordWrap
      '
      Me.chkWordWrap.AutoSize = True
      Me.chkWordWrap.Location = New System.Drawing.Point(35, 29)
      Me.chkWordWrap.Name = "chkWordWrap"
      Me.chkWordWrap.Size = New System.Drawing.Size(78, 17)
      Me.chkWordWrap.TabIndex = 0
      Me.chkWordWrap.Text = "&Word wrap"
      Me.ToolTip1.SetToolTip(Me.chkWordWrap, "Word-wrap mode for all textboxes in the main form.")
      Me.chkWordWrap.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(472, 405)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "OK"
      Me.ToolTip1.SetToolTip(Me.btnOK, "Save all properties and close the dialog box.")
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(553, 405)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 4
      Me.btnCancel.Text = "Cancel"
      Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without saving.")
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.chkWordWrap)
      Me.GroupBox3.Location = New System.Drawing.Point(322, 212)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(306, 177)
      Me.GroupBox3.TabIndex = 2
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Miscellaneous"
      '
      'PropertiesForm
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(639, 439)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PropertiesForm"
      Me.Text = "Properties"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      CType(Me.numMatches, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkEcmaScript As System.Windows.Forms.CheckBox
   Friend WithEvents chkCultureInvariant As System.Windows.Forms.CheckBox
   Friend WithEvents chkRightToLeft As System.Windows.Forms.CheckBox
   Friend WithEvents chkExplicitCapture As System.Windows.Forms.CheckBox
   Friend WithEvents chkCompiled As System.Windows.Forms.CheckBox
   Friend WithEvents chkMultiline As System.Windows.Forms.CheckBox
   Friend WithEvents chkIgnoreWhitespace As System.Windows.Forms.CheckBox
   Friend WithEvents chkIgnoreCase As System.Windows.Forms.CheckBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtDescription As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents cboSort As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cboFormat As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cboDetails As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents numMatches As System.Windows.Forms.NumericUpDown
   Friend WithEvents chkWordWrap As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents chkIncludeEmptyGroups As System.Windows.Forms.CheckBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
