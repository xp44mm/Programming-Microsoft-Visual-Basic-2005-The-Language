<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegexVisualizerForm
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
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtPattern = New System.Windows.Forms.TextBox
      Me.txtSource = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.btnRun = New System.Windows.Forms.Button
      Me.btnClose = New System.Windows.Forms.Button
      Me.txtResults = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.btnReplace = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 18)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(41, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Pattern"
      '
      'txtPattern
      '
      Me.txtPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPattern.Location = New System.Drawing.Point(59, 12)
      Me.txtPattern.Name = "txtPattern"
      Me.txtPattern.Size = New System.Drawing.Size(401, 20)
      Me.txtPattern.TabIndex = 1
      '
      'txtSource
      '
      Me.txtSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSource.Location = New System.Drawing.Point(59, 38)
      Me.txtSource.Multiline = True
      Me.txtSource.Name = "txtSource"
      Me.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtSource.Size = New System.Drawing.Size(401, 48)
      Me.txtSource.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 44)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(28, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Text"
      '
      'btnRun
      '
      Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRun.Location = New System.Drawing.Point(466, 12)
      Me.btnRun.Name = "btnRun"
      Me.btnRun.Size = New System.Drawing.Size(65, 23)
      Me.btnRun.TabIndex = 4
      Me.btnRun.Text = "Run"
      Me.btnRun.UseVisualStyleBackColor = True
      '
      'btnClose
      '
      Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnClose.Location = New System.Drawing.Point(466, 203)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(65, 23)
      Me.btnClose.TabIndex = 5
      Me.btnClose.Text = "Cancel"
      Me.btnClose.UseVisualStyleBackColor = True
      '
      'txtResults
      '
      Me.txtResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtResults.Location = New System.Drawing.Point(59, 92)
      Me.txtResults.Multiline = True
      Me.txtResults.Name = "txtResults"
      Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtResults.Size = New System.Drawing.Size(401, 134)
      Me.txtResults.TabIndex = 7
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 98)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(28, 13)
      Me.Label3.TabIndex = 6
      Me.Label3.Text = "Text"
      '
      'btnReplace
      '
      Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReplace.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnReplace.Location = New System.Drawing.Point(466, 174)
      Me.btnReplace.Name = "btnReplace"
      Me.btnReplace.Size = New System.Drawing.Size(65, 23)
      Me.btnReplace.TabIndex = 8
      Me.btnReplace.Text = "Replace"
      Me.btnReplace.UseVisualStyleBackColor = True
      '
      'RegexVisualizerForm
      '
      Me.AcceptButton = Me.btnRun
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnClose
      Me.ClientSize = New System.Drawing.Size(543, 238)
      Me.Controls.Add(Me.btnReplace)
      Me.Controls.Add(Me.txtResults)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.btnRun)
      Me.Controls.Add(Me.txtSource)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPattern)
      Me.Controls.Add(Me.Label1)
      Me.Name = "RegexVisualizerForm"
      Me.Text = "RegexVisualizerForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtPattern As System.Windows.Forms.TextBox
   Friend WithEvents txtSource As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnRun As System.Windows.Forms.Button
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents txtResults As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents btnReplace As System.Windows.Forms.Button
End Class
