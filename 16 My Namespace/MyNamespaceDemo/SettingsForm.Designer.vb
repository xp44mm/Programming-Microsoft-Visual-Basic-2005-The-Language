<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
      Me.FontDialog1 = New System.Windows.Forms.FontDialog
      Me.Button2 = New System.Windows.Forms.Button
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.Button3 = New System.Windows.Forms.Button
      Me.Button4 = New System.Windows.Forms.Button
      Me.Button5 = New System.Windows.Forms.Button
      Me.txtSettings = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(30, 67)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(123, 28)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Change color"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(159, 67)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(123, 28)
      Me.Button2.TabIndex = 2
      Me.Button2.Text = "Change font"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'TextBox1
      '
      Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MyNamespaceDemo.My.MySettings.Default, "WelcomeMessage", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.TextBox1.Location = New System.Drawing.Point(30, 25)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(497, 24)
      Me.TextBox1.TabIndex = 3
      Me.TextBox1.Text = Global.MyNamespaceDemo.My.MySettings.Default.WelcomeMessage
      '
      'Button3
      '
      Me.Button3.Location = New System.Drawing.Point(30, 125)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(123, 28)
      Me.Button3.TabIndex = 4
      Me.Button3.Text = "Reload"
      Me.Button3.UseVisualStyleBackColor = True
      '
      'Button4
      '
      Me.Button4.Location = New System.Drawing.Point(159, 125)
      Me.Button4.Name = "Button4"
      Me.Button4.Size = New System.Drawing.Size(123, 28)
      Me.Button4.TabIndex = 5
      Me.Button4.Text = "Reset"
      Me.Button4.UseVisualStyleBackColor = True
      '
      'Button5
      '
      Me.Button5.Location = New System.Drawing.Point(30, 179)
      Me.Button5.Name = "Button5"
      Me.Button5.Size = New System.Drawing.Size(123, 28)
      Me.Button5.TabIndex = 6
      Me.Button5.Text = "List"
      Me.Button5.UseVisualStyleBackColor = True
      '
      'txtSettings
      '
      Me.txtSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSettings.Location = New System.Drawing.Point(170, 179)
      Me.txtSettings.Multiline = True
      Me.txtSettings.Name = "txtSettings"
      Me.txtSettings.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtSettings.Size = New System.Drawing.Size(357, 152)
      Me.txtSettings.TabIndex = 7
      Me.txtSettings.WordWrap = False
      '
      'SettingsForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(548, 343)
      Me.Controls.Add(Me.txtSettings)
      Me.Controls.Add(Me.Button5)
      Me.Controls.Add(Me.Button4)
      Me.Controls.Add(Me.Button3)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.Button1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "SettingsForm"
      Me.Text = "SettingsForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents Button3 As System.Windows.Forms.Button
   Friend WithEvents Button4 As System.Windows.Forms.Button
   Friend WithEvents Button5 As System.Windows.Forms.Button
   Friend WithEvents txtSettings As System.Windows.Forms.TextBox
End Class
