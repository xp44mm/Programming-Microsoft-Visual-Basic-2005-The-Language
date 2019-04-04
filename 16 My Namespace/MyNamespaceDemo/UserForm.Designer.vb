<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserForm
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
      Me.txtInfo = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(18, 17)
      Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(112, 32)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Show Info"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'txtInfo
      '
      Me.txtInfo.Location = New System.Drawing.Point(18, 57)
      Me.txtInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtInfo.Multiline = True
      Me.txtInfo.Name = "txtInfo"
      Me.txtInfo.Size = New System.Drawing.Size(544, 300)
      Me.txtInfo.TabIndex = 1
      '
      'UserForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(585, 381)
      Me.Controls.Add(Me.txtInfo)
      Me.Controls.Add(Me.Button1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "UserForm"
      Me.Text = "UserForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents txtInfo As System.Windows.Forms.TextBox
End Class
