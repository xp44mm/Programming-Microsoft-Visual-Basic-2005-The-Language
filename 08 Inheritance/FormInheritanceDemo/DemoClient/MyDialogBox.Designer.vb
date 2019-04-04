<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyDialogBox
    Inherits BaseForms.DialogBoxBase

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
      Me.chkSkipRegistration = New System.Windows.Forms.CheckBox
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(339, 34)
      '
      'btnCancel
      '
      Me.btnCancel.Location = New System.Drawing.Point(339, 66)
      '
      'lblMessage
      '
      Me.lblMessage.Size = New System.Drawing.Size(273, 18)
      Me.lblMessage.Text = "Enter your CodeBox registration number"
      '
      'txtValue
      '
      Me.txtValue.Size = New System.Drawing.Size(320, 24)
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = Global.DemoClient.My.Resources.Resources.CodeBox_small_logo
      Me.PictureBox1.Location = New System.Drawing.Point(12, 66)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(172, 50)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 4
      Me.PictureBox1.TabStop = False
      '
      'chkSkipRegistration
      '
      Me.chkSkipRegistration.AutoSize = True
      Me.chkSkipRegistration.Location = New System.Drawing.Point(190, 64)
      Me.chkSkipRegistration.Name = "chkSkipRegistration"
      Me.chkSkipRegistration.Size = New System.Drawing.Size(133, 22)
      Me.chkSkipRegistration.TabIndex = 5
      Me.chkSkipRegistration.Text = "&Skip registration"
      Me.chkSkipRegistration.UseVisualStyleBackColor = True
      '
      'MyDialogBox
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.ClientSize = New System.Drawing.Size(426, 136)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.chkSkipRegistration)
      Me.Name = "MyDialogBox"
      Me.Text = "CodeBox Registration"
      Me.Controls.SetChildIndex(Me.chkSkipRegistration, 0)
      Me.Controls.SetChildIndex(Me.PictureBox1, 0)
      Me.Controls.SetChildIndex(Me.txtValue, 0)
      Me.Controls.SetChildIndex(Me.btnOK, 0)
      Me.Controls.SetChildIndex(Me.btnCancel, 0)
      Me.Controls.SetChildIndex(Me.lblMessage, 0)
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents chkSkipRegistration As System.Windows.Forms.CheckBox

End Class
