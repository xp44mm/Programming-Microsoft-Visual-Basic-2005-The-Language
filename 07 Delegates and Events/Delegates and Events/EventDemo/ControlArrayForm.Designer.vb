<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlArrayForm
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
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.TextBox2 = New System.Windows.Forms.TextBox
      Me.ComboBox1 = New System.Windows.Forms.ComboBox
      Me.ListBox1 = New System.Windows.Forms.ListBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 244)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(292, 22)
      Me.StatusStrip1.TabIndex = 0
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
      Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
      '
      'TextBox1
      '
      Me.TextBox1.Location = New System.Drawing.Point(27, 35)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(171, 20)
      Me.TextBox1.TabIndex = 1
      Me.TextBox1.Tag = "Enter ueser name"
      '
      'TextBox2
      '
      Me.TextBox2.Location = New System.Drawing.Point(27, 72)
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(171, 20)
      Me.TextBox2.TabIndex = 2
      Me.TextBox2.Tag = "Enter user password"
      '
      'ComboBox1
      '
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Location = New System.Drawing.Point(27, 110)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(171, 21)
      Me.ComboBox1.TabIndex = 4
      Me.ComboBox1.Tag = "Select user city"
      '
      'ListBox1
      '
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.Location = New System.Drawing.Point(27, 159)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(171, 69)
      Me.ListBox1.TabIndex = 5
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(224, 35)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(56, 23)
      Me.Button1.TabIndex = 6
      Me.Button1.Tag = "Click here to confirm"
      Me.Button1.Text = "OK"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(24, 19)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(55, 13)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Username"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(24, 58)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Password"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(24, 95)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(24, 13)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "City"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(26, 143)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = "Groups"
      '
      'ControlArrayForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.ListBox1)
      Me.Controls.Add(Me.ComboBox1)
      Me.Controls.Add(Me.TextBox2)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Name = "ControlArrayForm"
      Me.Text = "ControlArrayForm"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
