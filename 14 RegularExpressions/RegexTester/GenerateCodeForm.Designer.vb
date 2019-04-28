<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateCodeForm
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
      Me.radVisualBasic = New System.Windows.Forms.RadioButton
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.chkVerbatimStrings = New System.Windows.Forms.CheckBox
      Me.radVisualCSharp = New System.Windows.Forms.RadioButton
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.chkDescriptionAsComment = New System.Windows.Forms.CheckBox
      Me.chkGenerateLoops = New System.Windows.Forms.CheckBox
      Me.chkAssumeImports = New System.Windows.Forms.CheckBox
      Me.chkInstanceMethods = New System.Windows.Forms.CheckBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.chkCopyToClipboard = New System.Windows.Forms.CheckBox
      Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'radVisualBasic
      '
      Me.radVisualBasic.AutoSize = True
      Me.radVisualBasic.Location = New System.Drawing.Point(18, 21)
      Me.radVisualBasic.Name = "radVisualBasic"
      Me.radVisualBasic.Size = New System.Drawing.Size(82, 17)
      Me.radVisualBasic.TabIndex = 0
      Me.radVisualBasic.TabStop = True
      Me.radVisualBasic.Text = "Visual &Basic"
      Me.ToolTip1.SetToolTip(Me.radVisualBasic, "Generate Visual Basic code")
      Me.radVisualBasic.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkVerbatimStrings)
      Me.GroupBox1.Controls.Add(Me.radVisualCSharp)
      Me.GroupBox1.Controls.Add(Me.radVisualBasic)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(230, 122)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Language"
      '
      'chkVerbatimStrings
      '
      Me.chkVerbatimStrings.AutoSize = True
      Me.chkVerbatimStrings.Location = New System.Drawing.Point(40, 75)
      Me.chkVerbatimStrings.Name = "chkVerbatimStrings"
      Me.chkVerbatimStrings.Size = New System.Drawing.Size(120, 17)
      Me.chkVerbatimStrings.TabIndex = 2
      Me.chkVerbatimStrings.Text = "&Verbatim (@) strings"
      Me.ToolTip1.SetToolTip(Me.chkVerbatimStrings, "If selected, generated code uses @ C# strings.")
      Me.chkVerbatimStrings.UseVisualStyleBackColor = True
      '
      'radVisualCSharp
      '
      Me.radVisualCSharp.AutoSize = True
      Me.radVisualCSharp.Location = New System.Drawing.Point(18, 48)
      Me.radVisualCSharp.Name = "radVisualCSharp"
      Me.radVisualCSharp.Size = New System.Drawing.Size(70, 17)
      Me.radVisualCSharp.TabIndex = 1
      Me.radVisualCSharp.TabStop = True
      Me.radVisualCSharp.Text = "Visual &C#"
      Me.ToolTip1.SetToolTip(Me.radVisualCSharp, "Generate C# code")
      Me.radVisualCSharp.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.chkDescriptionAsComment)
      Me.GroupBox2.Controls.Add(Me.chkGenerateLoops)
      Me.GroupBox2.Controls.Add(Me.chkAssumeImports)
      Me.GroupBox2.Controls.Add(Me.chkInstanceMethods)
      Me.GroupBox2.Location = New System.Drawing.Point(259, 13)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(230, 121)
      Me.GroupBox2.TabIndex = 1
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Options"
      '
      'chkDescriptionAsComment
      '
      Me.chkDescriptionAsComment.AutoSize = True
      Me.chkDescriptionAsComment.Location = New System.Drawing.Point(16, 98)
      Me.chkDescriptionAsComment.Name = "chkDescriptionAsComment"
      Me.chkDescriptionAsComment.Size = New System.Drawing.Size(139, 17)
      Me.chkDescriptionAsComment.TabIndex = 3
      Me.chkDescriptionAsComment.Text = "&Description as comment"
      Me.ToolTip1.SetToolTip(Me.chkDescriptionAsComment, "The generated code contains a comment equal to the regex description. §(This opti" & _
              "on is disabled if the current regular expression has no description.)")
      Me.chkDescriptionAsComment.UseVisualStyleBackColor = True
      '
      'chkGenerateLoops
      '
      Me.chkGenerateLoops.AutoSize = True
      Me.chkGenerateLoops.Location = New System.Drawing.Point(16, 74)
      Me.chkGenerateLoops.Name = "chkGenerateLoops"
      Me.chkGenerateLoops.Size = New System.Drawing.Size(93, 17)
      Me.chkGenerateLoops.TabIndex = 2
      Me.chkGenerateLoops.Text = "&Generate loop"
      Me.ToolTip1.SetToolTip(Me.chkGenerateLoops, "The generate code contains a loop that visits all matches or split lines. §(This " & _
              "option is disabled if the current command is Replace.)")
      Me.chkGenerateLoops.UseVisualStyleBackColor = True
      '
      'chkAssumeImports
      '
      Me.chkAssumeImports.AutoSize = True
      Me.chkAssumeImports.Location = New System.Drawing.Point(16, 48)
      Me.chkAssumeImports.Name = "chkAssumeImports"
      Me.chkAssumeImports.Size = New System.Drawing.Size(130, 17)
      Me.chkAssumeImports.TabIndex = 1
      Me.chkAssumeImports.Text = "&Assume Imports/using"
      Me.ToolTip1.SetToolTip(Me.chkAssumeImports, "Assume that the System.Text.RegularExpressions namespace §has been imported in cu" & _
              "rrent source file.")
      Me.chkAssumeImports.UseVisualStyleBackColor = True
      '
      'chkInstanceMethods
      '
      Me.chkInstanceMethods.AutoSize = True
      Me.chkInstanceMethods.Location = New System.Drawing.Point(16, 20)
      Me.chkInstanceMethods.Name = "chkInstanceMethods"
      Me.chkInstanceMethods.Size = New System.Drawing.Size(105, 17)
      Me.chkInstanceMethods.TabIndex = 0
      Me.chkInstanceMethods.Text = "&Instance method"
      Me.ToolTip1.SetToolTip(Me.chkInstanceMethods, "If selected the generated code uses the Find, Replace, or Split instance method. " & _
              "§Otherwise generate code that uses the static version of these methods.")
      Me.chkInstanceMethods.UseVisualStyleBackColor = True
      '
      'txtCode
      '
      Me.txtCode.Location = New System.Drawing.Point(12, 148)
      Me.txtCode.Multiline = True
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(478, 101)
      Me.txtCode.TabIndex = 2
      Me.ToolTip1.SetToolTip(Me.txtCode, "The generated source code.")
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(426, 255)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(64, 23)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without copying the generated code to the Clipboard.")
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(354, 255)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(64, 23)
      Me.btnOK.TabIndex = 4
      Me.btnOK.Text = "OK"
      Me.ToolTip1.SetToolTip(Me.btnOK, "Close the dialog box and optionally copy the generated code to the Clipboard.")
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'chkCopyToClipboard
      '
      Me.chkCopyToClipboard.AutoSize = True
      Me.chkCopyToClipboard.Location = New System.Drawing.Point(12, 259)
      Me.chkCopyToClipboard.Name = "chkCopyToClipboard"
      Me.chkCopyToClipboard.Size = New System.Drawing.Size(169, 17)
      Me.chkCopyToClipboard.TabIndex = 3
      Me.chkCopyToClipboard.Text = "C&opy code to clipboard on exit"
      Me.ToolTip1.SetToolTip(Me.chkCopyToClipboard, "If enabled, generated code is copied to the Clipboard §when the user clicks on th" & _
              "e OK button.")
      Me.chkCopyToClipboard.UseVisualStyleBackColor = True
      '
      'GenerateCodeForm
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(499, 284)
      Me.Controls.Add(Me.chkCopyToClipboard)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "GenerateCodeForm"
      Me.Text = "Generate Code"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents radVisualBasic As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkVerbatimStrings As System.Windows.Forms.CheckBox
   Friend WithEvents radVisualCSharp As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents chkGenerateLoops As System.Windows.Forms.CheckBox
   Friend WithEvents chkAssumeImports As System.Windows.Forms.CheckBox
   Friend WithEvents chkInstanceMethods As System.Windows.Forms.CheckBox
   Friend WithEvents txtCode As System.Windows.Forms.TextBox
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents chkCopyToClipboard As System.Windows.Forms.CheckBox
   Friend WithEvents chkDescriptionAsComment As System.Windows.Forms.CheckBox
   Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
