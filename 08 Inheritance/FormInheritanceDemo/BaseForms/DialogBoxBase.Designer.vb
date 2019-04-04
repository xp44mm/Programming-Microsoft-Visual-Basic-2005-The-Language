<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxBase
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
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.lblMessage = New System.Windows.Forms.Label
      Me.txtValue = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.Location = New System.Drawing.Point(393, 34)
      Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(74, 24)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.Location = New System.Drawing.Point(393, 66)
      Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(74, 24)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblMessage
      '
      Me.lblMessage.AutoSize = True
      Me.lblMessage.Location = New System.Drawing.Point(12, 13)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(93, 18)
      Me.lblMessage.TabIndex = 2
      Me.lblMessage.Text = "Enter a value"
      '
      'txtValue
      '
      Me.txtValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtValue.Location = New System.Drawing.Point(12, 34)
      Me.txtValue.Name = "txtValue"
      Me.txtValue.Size = New System.Drawing.Size(374, 24)
      Me.txtValue.TabIndex = 3
      '
      'DialogBoxBase
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(480, 104)
      Me.Controls.Add(Me.txtValue)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DialogBoxBase"
      Me.Text = "DialogBoxBase"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected WithEvents btnOK As System.Windows.Forms.Button
   Protected WithEvents btnCancel As System.Windows.Forms.Button
   Protected WithEvents lblMessage As System.Windows.Forms.Label
   Protected WithEvents txtValue As System.Windows.Forms.TextBox
End Class
