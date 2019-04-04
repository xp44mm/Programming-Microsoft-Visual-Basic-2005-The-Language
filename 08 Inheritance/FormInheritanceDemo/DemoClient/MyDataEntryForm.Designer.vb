<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyDataEntryForm
    Inherits BaseForms.DataEntryFormBase

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
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.TextBox2 = New System.Windows.Forms.TextBox
      Me.TextBox3 = New System.Windows.Forms.TextBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.ComboBox1 = New System.Windows.Forms.ComboBox
      Me.ListBox1 = New System.Windows.Forms.ListBox
      Me.SuspendLayout()
      '
      'TextBox1
      '
      Me.TextBox1.Location = New System.Drawing.Point(24, 23)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(100, 23)
      Me.TextBox1.TabIndex = 0
      '
      'TextBox2
      '
      Me.TextBox2.Location = New System.Drawing.Point(24, 68)
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(100, 23)
      Me.TextBox2.TabIndex = 1
      '
      'TextBox3
      '
      Me.TextBox3.Location = New System.Drawing.Point(24, 115)
      Me.TextBox3.Name = "TextBox3"
      Me.TextBox3.Size = New System.Drawing.Size(100, 23)
      Me.TextBox3.TabIndex = 2
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(281, 21)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 3
      Me.Button1.Text = "Button1"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'ComboBox1
      '
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Location = New System.Drawing.Point(24, 162)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(100, 24)
      Me.ComboBox1.TabIndex = 4
      '
      'ListBox1
      '
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.ItemHeight = 16
      Me.ListBox1.Location = New System.Drawing.Point(158, 23)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(105, 164)
      Me.ListBox1.TabIndex = 5
      '
      'MyDataEntryForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.ClientSize = New System.Drawing.Size(374, 204)
      Me.Controls.Add(Me.ListBox1)
      Me.Controls.Add(Me.ComboBox1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.TextBox3)
      Me.Controls.Add(Me.TextBox2)
      Me.Controls.Add(Me.TextBox1)
      Me.FocusBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
      Me.FocusForeColor = System.Drawing.Color.Red
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "MyDataEntryForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
   Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

End Class
