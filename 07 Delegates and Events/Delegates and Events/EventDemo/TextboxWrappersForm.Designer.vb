<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextboxWrappersForm
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
      Me.txtQty = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtPhone = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtID = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'txtQty
      '
      Me.txtQty.Location = New System.Drawing.Point(69, 28)
      Me.txtQty.Name = "txtQty"
      Me.txtQty.Size = New System.Drawing.Size(100, 20)
      Me.txtQty.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(13, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(23, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Qty"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(13, 68)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Phone"
      '
      'txtPhone
      '
      Me.txtPhone.Location = New System.Drawing.Point(69, 68)
      Me.txtPhone.Name = "txtPhone"
      Me.txtPhone.Size = New System.Drawing.Size(100, 20)
      Me.txtPhone.TabIndex = 2
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(13, 110)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(18, 13)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "ID"
      '
      'txtID
      '
      Me.txtID.Location = New System.Drawing.Point(69, 110)
      Me.txtID.Name = "txtID"
      Me.txtID.Size = New System.Drawing.Size(100, 20)
      Me.txtID.TabIndex = 4
      '
      'TextboxWrappersForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtID)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPhone)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtQty)
      Me.Name = "TextboxWrappersForm"
      Me.Text = "TextboxWrappersForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtQty As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtPhone As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtID As System.Windows.Forms.TextBox
End Class
