<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
      Me.Button2 = New System.Windows.Forms.Button
      Me.Button3 = New System.Windows.Forms.Button
      Me.Button4 = New System.Windows.Forms.Button
      Me.Button5 = New System.Windows.Forms.Button
      Me.Button6 = New System.Windows.Forms.Button
      Me.Button7 = New System.Windows.Forms.Button
      Me.Button8 = New System.Windows.Forms.Button
      Me.Button9 = New System.Windows.Forms.Button
      Me.Button10 = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(18, 17)
      Me.Button1.Margin = New System.Windows.Forms.Padding(4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(158, 27)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Application"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(18, 66)
      Me.Button2.Margin = New System.Windows.Forms.Padding(4)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(158, 27)
      Me.Button2.TabIndex = 1
      Me.Button2.Text = "Sound and Clipboard"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'Button3
      '
      Me.Button3.Location = New System.Drawing.Point(18, 115)
      Me.Button3.Margin = New System.Windows.Forms.Padding(4)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(158, 27)
      Me.Button3.TabIndex = 2
      Me.Button3.Text = "File system"
      Me.Button3.UseVisualStyleBackColor = True
      '
      'Button4
      '
      Me.Button4.Location = New System.Drawing.Point(18, 164)
      Me.Button4.Margin = New System.Windows.Forms.Padding(4)
      Me.Button4.Name = "Button4"
      Me.Button4.Size = New System.Drawing.Size(158, 27)
      Me.Button4.TabIndex = 3
      Me.Button4.Text = "Computer info"
      Me.Button4.UseVisualStyleBackColor = True
      '
      'Button5
      '
      Me.Button5.Location = New System.Drawing.Point(18, 213)
      Me.Button5.Margin = New System.Windows.Forms.Padding(4)
      Me.Button5.Name = "Button5"
      Me.Button5.Size = New System.Drawing.Size(158, 27)
      Me.Button5.TabIndex = 4
      Me.Button5.Text = "Network"
      Me.Button5.UseVisualStyleBackColor = True
      '
      'Button6
      '
      Me.Button6.Location = New System.Drawing.Point(219, 17)
      Me.Button6.Margin = New System.Windows.Forms.Padding(4)
      Me.Button6.Name = "Button6"
      Me.Button6.Size = New System.Drawing.Size(158, 27)
      Me.Button6.TabIndex = 5
      Me.Button6.Text = "Registry"
      Me.Button6.UseVisualStyleBackColor = True
      '
      'Button7
      '
      Me.Button7.Location = New System.Drawing.Point(219, 66)
      Me.Button7.Margin = New System.Windows.Forms.Padding(4)
      Me.Button7.Name = "Button7"
      Me.Button7.Size = New System.Drawing.Size(158, 27)
      Me.Button7.TabIndex = 6
      Me.Button7.Text = "User"
      Me.Button7.UseVisualStyleBackColor = True
      '
      'Button8
      '
      Me.Button8.Location = New System.Drawing.Point(219, 115)
      Me.Button8.Margin = New System.Windows.Forms.Padding(4)
      Me.Button8.Name = "Button8"
      Me.Button8.Size = New System.Drawing.Size(158, 27)
      Me.Button8.TabIndex = 7
      Me.Button8.Text = "Resources"
      Me.Button8.UseVisualStyleBackColor = True
      '
      'Button9
      '
      Me.Button9.Location = New System.Drawing.Point(219, 164)
      Me.Button9.Margin = New System.Windows.Forms.Padding(4)
      Me.Button9.Name = "Button9"
      Me.Button9.Size = New System.Drawing.Size(158, 27)
      Me.Button9.TabIndex = 8
      Me.Button9.Text = "Settings"
      Me.Button9.UseVisualStyleBackColor = True
      '
      'Button10
      '
      Me.Button10.Location = New System.Drawing.Point(219, 213)
      Me.Button10.Margin = New System.Windows.Forms.Padding(4)
      Me.Button10.Name = "Button10"
      Me.Button10.Size = New System.Drawing.Size(158, 27)
      Me.Button10.TabIndex = 9
      Me.Button10.Text = "My extensions"
      Me.Button10.UseVisualStyleBackColor = True
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(400, 258)
      Me.Controls.Add(Me.Button10)
      Me.Controls.Add(Me.Button9)
      Me.Controls.Add(Me.Button8)
      Me.Controls.Add(Me.Button7)
      Me.Controls.Add(Me.Button6)
      Me.Controls.Add(Me.Button5)
      Me.Controls.Add(Me.Button4)
      Me.Controls.Add(Me.Button3)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.Button1)
      Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.MyNamespaceDemo.My.MySettings.Default, "MainWindowLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Location = Global.MyNamespaceDemo.My.MySettings.Default.MainWindowLocation
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "MainForm"
      Me.Text = "MyNamespace Demo"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents Button3 As System.Windows.Forms.Button
   Friend WithEvents Button4 As System.Windows.Forms.Button
   Friend WithEvents Button5 As System.Windows.Forms.Button
   Friend WithEvents Button6 As System.Windows.Forms.Button
   Friend WithEvents Button7 As System.Windows.Forms.Button
   Friend WithEvents Button8 As System.Windows.Forms.Button
   Friend WithEvents Button9 As System.Windows.Forms.Button
   Friend WithEvents Button10 As System.Windows.Forms.Button

End Class
