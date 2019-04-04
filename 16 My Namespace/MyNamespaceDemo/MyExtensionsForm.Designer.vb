<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyExtensionsForm
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
      Me.Button1 = New System.Windows.Forms.Button
      Me.lstColors = New System.Windows.Forms.ListBox
      Me.Button2 = New System.Windows.Forms.Button
      Me.lblUserDomain = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(13, 76)
      Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(112, 32)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Color list"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'lstColors
      '
      Me.lstColors.FormattingEnabled = True
      Me.lstColors.ItemHeight = 18
      Me.lstColors.Location = New System.Drawing.Point(141, 76)
      Me.lstColors.Name = "lstColors"
      Me.lstColors.Size = New System.Drawing.Size(156, 130)
      Me.lstColors.TabIndex = 1
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(13, 22)
      Me.Button2.Margin = New System.Windows.Forms.Padding(4)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(112, 32)
      Me.Button2.TabIndex = 2
      Me.Button2.Text = "DomainName"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'lblUserDomain
      '
      Me.lblUserDomain.AutoSize = True
      Me.lblUserDomain.Location = New System.Drawing.Point(138, 29)
      Me.lblUserDomain.Name = "lblUserDomain"
      Me.lblUserDomain.Size = New System.Drawing.Size(51, 18)
      Me.lblUserDomain.TabIndex = 3
      Me.lblUserDomain.Text = "Label1"
      '
      'MyExtensionsForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(610, 354)
      Me.Controls.Add(Me.lblUserDomain)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.lstColors)
      Me.Controls.Add(Me.Button1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "MyExtensionsForm"
      Me.Text = "MyExtensionsForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents lstColors As System.Windows.Forms.ListBox
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents lblUserDomain As System.Windows.Forms.Label
End Class
