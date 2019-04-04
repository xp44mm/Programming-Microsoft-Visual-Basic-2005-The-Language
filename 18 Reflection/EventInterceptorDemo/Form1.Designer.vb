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
      Me.btnClear = New System.Windows.Forms.Button
      Me.label2 = New System.Windows.Forms.Label
      Me.label1 = New System.Windows.Forms.Label
      Me.txtOutput = New System.Windows.Forms.TextBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'btnClear
      '
      Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnClear.Location = New System.Drawing.Point(573, 72)
      Me.btnClear.Name = "btnClear"
      Me.btnClear.Size = New System.Drawing.Size(75, 28)
      Me.btnClear.TabIndex = 11
      Me.btnClear.Text = "Clear log"
      Me.btnClear.UseVisualStyleBackColor = True
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.label2.Location = New System.Drawing.Point(32, 78)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(51, 17)
      Me.label2.TabIndex = 10
      Me.label2.Text = "Events"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.label1.Location = New System.Drawing.Point(32, 18)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(290, 34)
      Me.label1.TabIndex = 9
      Me.label1.Text = "Use the textbox and button controls and see " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "how events are generated and trappe" & _
          "d." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      '
      'txtOutput
      '
      Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtOutput.Location = New System.Drawing.Point(32, 101)
      Me.txtOutput.Multiline = True
      Me.txtOutput.Name = "txtOutput"
      Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtOutput.Size = New System.Drawing.Size(616, 368)
      Me.txtOutput.TabIndex = 8
      Me.txtOutput.WordWrap = False
      '
      'Button1
      '
      Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button1.Location = New System.Drawing.Point(468, 18)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(93, 28)
      Me.Button1.TabIndex = 7
      Me.Button1.Text = "Button"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'TextBox1
      '
      Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TextBox1.Location = New System.Drawing.Point(344, 20)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(118, 23)
      Me.TextBox1.TabIndex = 6
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(673, 490)
      Me.Controls.Add(Me.btnClear)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me.txtOutput)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.TextBox1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents btnClear As System.Windows.Forms.Button
   Private WithEvents label2 As System.Windows.Forms.Label
   Private WithEvents label1 As System.Windows.Forms.Label
   Private WithEvents txtOutput As System.Windows.Forms.TextBox
   Private WithEvents Button1 As System.Windows.Forms.Button
   Private WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
