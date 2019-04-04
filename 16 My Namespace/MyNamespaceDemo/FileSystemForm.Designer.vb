<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSystemForm
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
      Me.lstFiles = New System.Windows.Forms.ListBox
      Me.txtFindText = New System.Windows.Forms.TextBox
      Me.btnFindInFiles = New System.Windows.Forms.Button
      Me.Button1 = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtFromDirectory = New System.Windows.Forms.TextBox
      Me.txtToDirectory = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Button2 = New System.Windows.Forms.Button
      Me.txtDeleteDir = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'lstFiles
      '
      Me.lstFiles.FormattingEnabled = True
      Me.lstFiles.ItemHeight = 18
      Me.lstFiles.Location = New System.Drawing.Point(137, 73)
      Me.lstFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.lstFiles.Name = "lstFiles"
      Me.lstFiles.Size = New System.Drawing.Size(500, 94)
      Me.lstFiles.TabIndex = 12
      '
      'txtFindText
      '
      Me.txtFindText.Location = New System.Drawing.Point(137, 30)
      Me.txtFindText.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
      Me.txtFindText.Name = "txtFindText"
      Me.txtFindText.Size = New System.Drawing.Size(500, 24)
      Me.txtFindText.TabIndex = 11
      '
      'btnFindInFiles
      '
      Me.btnFindInFiles.Location = New System.Drawing.Point(13, 28)
      Me.btnFindInFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.btnFindInFiles.Name = "btnFindInFiles"
      Me.btnFindInFiles.Size = New System.Drawing.Size(114, 28)
      Me.btnFindInFiles.TabIndex = 10
      Me.btnFindInFiles.Text = "FindInFiles"
      Me.btnFindInFiles.UseVisualStyleBackColor = True
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(13, 189)
      Me.Button1.Margin = New System.Windows.Forms.Padding(4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(114, 28)
      Me.Button1.TabIndex = 13
      Me.Button1.Text = "CopyDirectory"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(134, 194)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 18)
      Me.Label1.TabIndex = 14
      Me.Label1.Text = "From"
      '
      'txtFromDirectory
      '
      Me.txtFromDirectory.Location = New System.Drawing.Point(199, 189)
      Me.txtFromDirectory.Margin = New System.Windows.Forms.Padding(6)
      Me.txtFromDirectory.Name = "txtFromDirectory"
      Me.txtFromDirectory.Size = New System.Drawing.Size(438, 24)
      Me.txtFromDirectory.TabIndex = 15
      '
      'txtToDirectory
      '
      Me.txtToDirectory.Location = New System.Drawing.Point(199, 225)
      Me.txtToDirectory.Margin = New System.Windows.Forms.Padding(6)
      Me.txtToDirectory.Name = "txtToDirectory"
      Me.txtToDirectory.Size = New System.Drawing.Size(438, 24)
      Me.txtToDirectory.TabIndex = 17
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(134, 230)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(26, 18)
      Me.Label2.TabIndex = 16
      Me.Label2.Text = "To"
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(13, 311)
      Me.Button2.Margin = New System.Windows.Forms.Padding(4)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(114, 28)
      Me.Button2.TabIndex = 18
      Me.Button2.Text = "DeleteDirectory"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'txtDeleteDir
      '
      Me.txtDeleteDir.Location = New System.Drawing.Point(137, 311)
      Me.txtDeleteDir.Margin = New System.Windows.Forms.Padding(6)
      Me.txtDeleteDir.Name = "txtDeleteDir"
      Me.txtDeleteDir.Size = New System.Drawing.Size(500, 24)
      Me.txtDeleteDir.TabIndex = 19
      '
      'FileSystemForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(681, 387)
      Me.Controls.Add(Me.txtDeleteDir)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.txtToDirectory)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtFromDirectory)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.lstFiles)
      Me.Controls.Add(Me.txtFindText)
      Me.Controls.Add(Me.btnFindInFiles)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "FileSystemForm"
      Me.Text = "FileSystemForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lstFiles As System.Windows.Forms.ListBox
   Friend WithEvents txtFindText As System.Windows.Forms.TextBox
   Friend WithEvents btnFindInFiles As System.Windows.Forms.Button
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtFromDirectory As System.Windows.Forms.TextBox
   Friend WithEvents txtToDirectory As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents txtDeleteDir As System.Windows.Forms.TextBox
End Class
