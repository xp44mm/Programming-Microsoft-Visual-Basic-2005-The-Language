<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResourcesForm
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
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.Button2 = New System.Windows.Forms.Button
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = Global.MyNamespaceDemo.My.Resources.Resources.CompanyLogo
      Me.PictureBox1.Location = New System.Drawing.Point(31, 25)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(445, 82)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 0
      Me.PictureBox1.TabStop = False
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(31, 131)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(105, 32)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Play sound"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Location = New System.Drawing.Point(31, 182)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(445, 188)
      Me.RichTextBox1.TabIndex = 2
      Me.RichTextBox1.Text = ""
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(166, 131)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(124, 32)
      Me.Button2.TabIndex = 3
      Me.Button2.Text = "List resources"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'ResourcesForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(507, 398)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.RichTextBox1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.PictureBox1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "ResourcesForm"
      Me.Text = "ResourcesForm"
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
