<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StaticEventsForm
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
      Me.txtField = New System.Windows.Forms.TextBox
      Me.lblCharCount = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'txtField
      '
      Me.txtField.Location = New System.Drawing.Point(13, 28)
      Me.txtField.Multiline = True
      Me.txtField.Name = "txtField"
      Me.txtField.Size = New System.Drawing.Size(259, 178)
      Me.txtField.TabIndex = 0
      '
      'lblCharCount
      '
      Me.lblCharCount.AutoSize = True
      Me.lblCharCount.Location = New System.Drawing.Point(13, 213)
      Me.lblCharCount.Name = "lblCharCount"
      Me.lblCharCount.Size = New System.Drawing.Size(39, 13)
      Me.lblCharCount.TabIndex = 1
      Me.lblCharCount.Text = "Label1"
      '
      'StaticEventsForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.lblCharCount)
      Me.Controls.Add(Me.txtField)
      Me.Name = "StaticEventsForm"
      Me.Text = "StaticEventsForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtField As System.Windows.Forms.TextBox
   Friend WithEvents lblCharCount As System.Windows.Forms.Label
End Class
