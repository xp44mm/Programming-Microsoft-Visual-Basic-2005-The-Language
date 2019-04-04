<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileVisualizerForm
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
      Me.lvwProperties = New System.Windows.Forms.ListView
      Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
      Me.btnBrowse = New System.Windows.Forms.Button
      Me.rtbContents = New System.Windows.Forms.RichTextBox
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
      Me.btnReplace = New System.Windows.Forms.Button
      Me.btnClose = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(54, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Properties"
      '
      'lvwProperties
      '
      Me.lvwProperties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwProperties.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
      Me.lvwProperties.Location = New System.Drawing.Point(15, 25)
      Me.lvwProperties.Name = "lvwProperties"
      Me.lvwProperties.Size = New System.Drawing.Size(407, 129)
      Me.lvwProperties.TabIndex = 1
      Me.lvwProperties.UseCompatibleStateImageBehavior = False
      Me.lvwProperties.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Name = "ColumnHeader1"
      Me.ColumnHeader1.Text = "Name"
      Me.ColumnHeader1.Width = 140
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Name = "ColumnHeader2"
      Me.ColumnHeader2.Text = "Value"
      Me.ColumnHeader2.Width = 240
      '
      'btnBrowse
      '
      Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBrowse.Location = New System.Drawing.Point(428, 25)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(64, 23)
      Me.btnBrowse.TabIndex = 2
      Me.btnBrowse.Text = "Browse"
      Me.btnBrowse.UseVisualStyleBackColor = True
      '
      'rtbContents
      '
      Me.rtbContents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbContents.Location = New System.Drawing.Point(15, 160)
      Me.rtbContents.Name = "rtbContents"
      Me.rtbContents.Size = New System.Drawing.Size(407, 109)
      Me.rtbContents.TabIndex = 3
      Me.rtbContents.Text = ""
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      '
      'btnReplace
      '
      Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReplace.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnReplace.Enabled = False
      Me.btnReplace.Location = New System.Drawing.Point(428, 95)
      Me.btnReplace.Name = "btnReplace"
      Me.btnReplace.Size = New System.Drawing.Size(64, 23)
      Me.btnReplace.TabIndex = 4
      Me.btnReplace.Text = "Replace"
      Me.btnReplace.UseVisualStyleBackColor = True
      '
      'btnClose
      '
      Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnClose.Location = New System.Drawing.Point(428, 121)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(64, 23)
      Me.btnClose.TabIndex = 5
      Me.btnClose.Text = "Close"
      Me.btnClose.UseVisualStyleBackColor = True
      '
      'FileVisualizerForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(503, 281)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.btnReplace)
      Me.Controls.Add(Me.rtbContents)
      Me.Controls.Add(Me.btnBrowse)
      Me.Controls.Add(Me.lvwProperties)
      Me.Controls.Add(Me.Label1)
      Me.Name = "FileVisualizerForm"
      Me.Text = "FileVisualizerForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lvwProperties As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents btnBrowse As System.Windows.Forms.Button
   Friend WithEvents rtbContents As System.Windows.Forms.RichTextBox
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnReplace As System.Windows.Forms.Button
   Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
