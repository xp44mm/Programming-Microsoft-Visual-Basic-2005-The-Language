<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EscapeForm
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
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtText = New System.Windows.Forms.TextBox
      Me.radEscape = New System.Windows.Forms.RadioButton
      Me.radUnescape = New System.Windows.Forms.RadioButton
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtResult = New System.Windows.Forms.TextBox
      Me.chkCopyToClipboard = New System.Windows.Forms.CheckBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.lblError = New System.Windows.Forms.Label
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(37, 23)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "&Text"
      '
      'txtText
      '
      Me.txtText.Location = New System.Drawing.Point(55, 9)
      Me.txtText.Multiline = True
      Me.txtText.Name = "txtText"
      Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtText.Size = New System.Drawing.Size(552, 97)
      Me.txtText.TabIndex = 1
      Me.txtText.Text = "Enter a string that you want to escape or unescape."
      '
      'radEscape
      '
      Me.radEscape.AutoSize = True
      Me.radEscape.Checked = True
      Me.radEscape.Location = New System.Drawing.Point(55, 112)
      Me.radEscape.Name = "radEscape"
      Me.radEscape.Size = New System.Drawing.Size(61, 17)
      Me.radEscape.TabIndex = 2
      Me.radEscape.TabStop = True
      Me.radEscape.Text = "&Escape"
      Me.ToolTip1.SetToolTip(Me.radEscape, "Test the Escape command.")
      Me.radEscape.UseVisualStyleBackColor = True
      '
      'radUnescape
      '
      Me.radUnescape.AutoSize = True
      Me.radUnescape.Location = New System.Drawing.Point(122, 112)
      Me.radUnescape.Name = "radUnescape"
      Me.radUnescape.Size = New System.Drawing.Size(74, 17)
      Me.radUnescape.TabIndex = 3
      Me.radUnescape.Text = "&Unescape"
      Me.ToolTip1.SetToolTip(Me.radUnescape, "Test the Unescape command.")
      Me.radUnescape.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(12, 137)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(37, 23)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "&Result"
      '
      'txtResult
      '
      Me.txtResult.Location = New System.Drawing.Point(55, 137)
      Me.txtResult.Multiline = True
      Me.txtResult.Name = "txtResult"
      Me.txtResult.ReadOnly = True
      Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtResult.Size = New System.Drawing.Size(552, 94)
      Me.txtResult.TabIndex = 6
      Me.txtResult.Text = "The result of the Escape or Unescape method."
      '
      'chkCopyToClipboard
      '
      Me.chkCopyToClipboard.AutoSize = True
      Me.chkCopyToClipboard.Checked = True
      Me.chkCopyToClipboard.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkCopyToClipboard.Location = New System.Drawing.Point(471, 114)
      Me.chkCopyToClipboard.Name = "chkCopyToClipboard"
      Me.chkCopyToClipboard.Size = New System.Drawing.Size(137, 17)
      Me.chkCopyToClipboard.TabIndex = 4
      Me.chkCopyToClipboard.Text = "C&opy result to Clipboard"
      Me.ToolTip1.SetToolTip(Me.chkCopyToClipboard, "If selected, the result is copied to the Clipboard hen the user clicks on the O" & _
              "K button.")
      Me.chkCopyToClipboard.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(451, 237)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 8
      Me.btnOK.Text = "OK"
      Me.ToolTip1.SetToolTip(Me.btnOK, "Close the dialog box and optionally copy the result to the Clipboard.")
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(532, 237)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 9
      Me.btnCancel.Text = "Cancel"
      Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without copying the result to the Clipboard.")
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblError
      '
      Me.lblError.AutoSize = True
      Me.lblError.ForeColor = System.Drawing.Color.Red
      Me.lblError.Location = New System.Drawing.Point(52, 237)
      Me.lblError.Name = "lblError"
      Me.lblError.Size = New System.Drawing.Size(39, 13)
      Me.lblError.TabIndex = 7
      Me.lblError.Text = "lblError"
      '
      'EscapeForm
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(619, 270)
      Me.Controls.Add(Me.lblError)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.chkCopyToClipboard)
      Me.Controls.Add(Me.txtResult)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.radUnescape)
      Me.Controls.Add(Me.radEscape)
      Me.Controls.Add(Me.txtText)
      Me.Controls.Add(Me.Label1)
      Me.Name = "EscapeForm"
      Me.Text = "Escape Command"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtText As System.Windows.Forms.TextBox
   Friend WithEvents radEscape As System.Windows.Forms.RadioButton
   Friend WithEvents radUnescape As System.Windows.Forms.RadioButton
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtResult As System.Windows.Forms.TextBox
   Friend WithEvents chkCopyToClipboard As System.Windows.Forms.CheckBox
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblError As System.Windows.Forms.Label
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
