<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageVisualizerForm
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
      Me.picImage = New System.Windows.Forms.PictureBox
      Me.btnClose = New System.Windows.Forms.Button
      Me.btnCopy = New System.Windows.Forms.Button
      Me.btnPaste = New System.Windows.Forms.Button
      Me.btnLoad = New System.Windows.Forms.Button
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
      Me.btnReplace = New System.Windows.Forms.Button
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'picImage
      '
      Me.picImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.picImage.Location = New System.Drawing.Point(12, 12)
      Me.picImage.Name = "picImage"
      Me.picImage.Size = New System.Drawing.Size(268, 210)
      Me.picImage.TabIndex = 0
      Me.picImage.TabStop = False
      '
      'btnClose
      '
      Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnClose.Location = New System.Drawing.Point(285, 199)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(66, 23)
      Me.btnClose.TabIndex = 1
      Me.btnClose.Text = "Close"
      Me.btnClose.UseVisualStyleBackColor = True
      '
      'btnCopy
      '
      Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCopy.Location = New System.Drawing.Point(287, 13)
      Me.btnCopy.Name = "btnCopy"
      Me.btnCopy.Size = New System.Drawing.Size(64, 23)
      Me.btnCopy.TabIndex = 2
      Me.btnCopy.Text = "Copy"
      Me.btnCopy.UseVisualStyleBackColor = True
      '
      'btnPaste
      '
      Me.btnPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnPaste.Location = New System.Drawing.Point(287, 42)
      Me.btnPaste.Name = "btnPaste"
      Me.btnPaste.Size = New System.Drawing.Size(64, 23)
      Me.btnPaste.TabIndex = 3
      Me.btnPaste.Text = "Paste"
      Me.btnPaste.UseVisualStyleBackColor = True
      '
      'btnLoad
      '
      Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnLoad.Location = New System.Drawing.Point(286, 71)
      Me.btnLoad.Name = "btnLoad"
      Me.btnLoad.Size = New System.Drawing.Size(64, 23)
      Me.btnLoad.TabIndex = 4
      Me.btnLoad.Text = "Load"
      Me.btnLoad.UseVisualStyleBackColor = True
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      Me.OpenFileDialog1.Filter = "All files|*.*|Image files|*.bmp;*.jpg;*.gif"
      Me.OpenFileDialog1.Title = "Select the image"
      '
      'btnReplace
      '
      Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReplace.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnReplace.Location = New System.Drawing.Point(285, 170)
      Me.btnReplace.Name = "btnReplace"
      Me.btnReplace.Size = New System.Drawing.Size(66, 23)
      Me.btnReplace.TabIndex = 5
      Me.btnReplace.Text = "Replace"
      Me.btnReplace.UseVisualStyleBackColor = True
      '
      'ImageVisualizerForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnClose
      Me.ClientSize = New System.Drawing.Size(355, 230)
      Me.Controls.Add(Me.btnReplace)
      Me.Controls.Add(Me.btnLoad)
      Me.Controls.Add(Me.btnPaste)
      Me.Controls.Add(Me.btnCopy)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.picImage)
      Me.Name = "ImageVisualizerForm"
      Me.Text = "ImageVisualizerForm"
      CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents picImage As System.Windows.Forms.PictureBox
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents btnCopy As System.Windows.Forms.Button
   Friend WithEvents btnPaste As System.Windows.Forms.Button
   Friend WithEvents btnLoad As System.Windows.Forms.Button
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnReplace As System.Windows.Forms.Button
End Class
