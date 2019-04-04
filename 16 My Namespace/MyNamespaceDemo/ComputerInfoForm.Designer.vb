<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComputerInfoForm
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
      Me.lstResults = New System.Windows.Forms.ListBox
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(13, 17)
      Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(89, 27)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Show Info"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'lstResults
      '
      Me.lstResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstResults.FormattingEnabled = True
      Me.lstResults.ItemHeight = 18
      Me.lstResults.Location = New System.Drawing.Point(12, 51)
      Me.lstResults.Name = "lstResults"
      Me.lstResults.Size = New System.Drawing.Size(636, 310)
      Me.lstResults.TabIndex = 1
      '
      'ComputerInfoForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(670, 384)
      Me.Controls.Add(Me.lstResults)
      Me.Controls.Add(Me.Button1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "ComputerInfoForm"
      Me.Text = "ComputerInfoForm"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents lstResults As System.Windows.Forms.ListBox
End Class
