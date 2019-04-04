<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistryForm
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
      Me.btnCheckWord = New System.Windows.Forms.Button
      Me.lblWord = New System.Windows.Forms.Label
      Me.btnClsid = New System.Windows.Forms.Button
      Me.txtClassname = New System.Windows.Forms.TextBox
      Me.lblClsid = New System.Windows.Forms.Label
      Me.btnComponents = New System.Windows.Forms.Button
      Me.lstComponents = New System.Windows.Forms.ListBox
      Me.btnAddKey = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'btnCheckWord
      '
      Me.btnCheckWord.Location = New System.Drawing.Point(24, 24)
      Me.btnCheckWord.Name = "btnCheckWord"
      Me.btnCheckWord.Size = New System.Drawing.Size(170, 28)
      Me.btnCheckWord.TabIndex = 0
      Me.btnCheckWord.Text = "Check Word"
      Me.btnCheckWord.UseVisualStyleBackColor = True
      '
      'lblWord
      '
      Me.lblWord.AutoSize = True
      Me.lblWord.Location = New System.Drawing.Point(200, 29)
      Me.lblWord.Name = "lblWord"
      Me.lblWord.Size = New System.Drawing.Size(51, 18)
      Me.lblWord.TabIndex = 1
      Me.lblWord.Text = "Label1"
      '
      'btnClsid
      '
      Me.btnClsid.Location = New System.Drawing.Point(24, 72)
      Me.btnClsid.Name = "btnClsid"
      Me.btnClsid.Size = New System.Drawing.Size(170, 28)
      Me.btnClsid.TabIndex = 2
      Me.btnClsid.Text = "Get CLSID"
      Me.btnClsid.UseVisualStyleBackColor = True
      '
      'txtClassname
      '
      Me.txtClassname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtClassname.Location = New System.Drawing.Point(203, 74)
      Me.txtClassname.Name = "txtClassname"
      Me.txtClassname.Size = New System.Drawing.Size(311, 24)
      Me.txtClassname.TabIndex = 3
      Me.txtClassname.Text = "ADODB.Recordset"
      '
      'lblClsid
      '
      Me.lblClsid.AutoSize = True
      Me.lblClsid.Location = New System.Drawing.Point(200, 101)
      Me.lblClsid.Name = "lblClsid"
      Me.lblClsid.Size = New System.Drawing.Size(51, 18)
      Me.lblClsid.TabIndex = 4
      Me.lblClsid.Text = "Label1"
      '
      'btnComponents
      '
      Me.btnComponents.Location = New System.Drawing.Point(24, 137)
      Me.btnComponents.Name = "btnComponents"
      Me.btnComponents.Size = New System.Drawing.Size(173, 29)
      Me.btnComponents.TabIndex = 5
      Me.btnComponents.Text = "List COM components"
      Me.btnComponents.UseVisualStyleBackColor = True
      '
      'lstComponents
      '
      Me.lstComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstComponents.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstComponents.FormattingEnabled = True
      Me.lstComponents.ItemHeight = 16
      Me.lstComponents.Location = New System.Drawing.Point(24, 172)
      Me.lstComponents.Name = "lstComponents"
      Me.lstComponents.Size = New System.Drawing.Size(490, 180)
      Me.lstComponents.TabIndex = 6
      '
      'btnAddKey
      '
      Me.btnAddKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAddKey.Location = New System.Drawing.Point(24, 380)
      Me.btnAddKey.Name = "btnAddKey"
      Me.btnAddKey.Size = New System.Drawing.Size(173, 29)
      Me.btnAddKey.TabIndex = 7
      Me.btnAddKey.Text = "Add registry key"
      Me.btnAddKey.UseVisualStyleBackColor = True
      '
      'RegistryForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(524, 418)
      Me.Controls.Add(Me.btnAddKey)
      Me.Controls.Add(Me.lstComponents)
      Me.Controls.Add(Me.btnComponents)
      Me.Controls.Add(Me.lblClsid)
      Me.Controls.Add(Me.txtClassname)
      Me.Controls.Add(Me.btnClsid)
      Me.Controls.Add(Me.lblWord)
      Me.Controls.Add(Me.btnCheckWord)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "RegistryForm"
      Me.Text = "RegistryForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnCheckWord As System.Windows.Forms.Button
   Friend WithEvents lblWord As System.Windows.Forms.Label
   Friend WithEvents btnClsid As System.Windows.Forms.Button
   Friend WithEvents txtClassname As System.Windows.Forms.TextBox
   Friend WithEvents lblClsid As System.Windows.Forms.Label
   Friend WithEvents btnComponents As System.Windows.Forms.Button
   Friend WithEvents lstComponents As System.Windows.Forms.ListBox
   Friend WithEvents btnAddKey As System.Windows.Forms.Button
End Class
