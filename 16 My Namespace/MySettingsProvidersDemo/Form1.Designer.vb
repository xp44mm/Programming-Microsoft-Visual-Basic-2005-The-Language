<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
      Me.lblShowStatusBar = New System.Windows.Forms.Label
      Me.lblUserName = New System.Windows.Forms.Label
      Me.Button1 = New System.Windows.Forms.Button
      Me.txtUserName = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'lblShowStatusBar
      '
      Me.lblShowStatusBar.AutoSize = True
      Me.lblShowStatusBar.Location = New System.Drawing.Point(44, 47)
      Me.lblShowStatusBar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblShowStatusBar.Name = "lblShowStatusBar"
      Me.lblShowStatusBar.Size = New System.Drawing.Size(51, 18)
      Me.lblShowStatusBar.TabIndex = 0
      Me.lblShowStatusBar.Text = "Label1"
      '
      'lblUserName
      '
      Me.lblUserName.AutoSize = True
      Me.lblUserName.Location = New System.Drawing.Point(44, 92)
      Me.lblUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblUserName.Name = "lblUserName"
      Me.lblUserName.Size = New System.Drawing.Size(51, 18)
      Me.lblUserName.TabIndex = 1
      Me.lblUserName.Text = "Label2"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(47, 151)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(146, 26)
      Me.Button1.TabIndex = 2
      Me.Button1.Text = "Change UserName"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'txtUserName
      '
      Me.txtUserName.Location = New System.Drawing.Point(200, 151)
      Me.txtUserName.Name = "txtUserName"
      Me.txtUserName.Size = New System.Drawing.Size(269, 24)
      Me.txtUserName.TabIndex = 3
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(640, 374)
      Me.Controls.Add(Me.txtUserName)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.lblUserName)
      Me.Controls.Add(Me.lblShowStatusBar)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblShowStatusBar As System.Windows.Forms.Label
   Friend WithEvents lblUserName As System.Windows.Forms.Label
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents txtUserName As System.Windows.Forms.TextBox

End Class
