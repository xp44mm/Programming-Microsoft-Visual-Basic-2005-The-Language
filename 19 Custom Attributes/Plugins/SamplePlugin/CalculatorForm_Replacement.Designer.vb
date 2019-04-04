<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalculatorForm_Replacement
    Inherits MainApplication.CalculatorForm

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
      Me.Label8 = New System.Windows.Forms.Label
      Me.txtPercentDiscount = New System.Windows.Forms.TextBox
      Me.Label9 = New System.Windows.Forms.Label
      Me.txtDiscount = New System.Windows.Forms.TextBox
      Me.Label10 = New System.Windows.Forms.Label
      Me.txtDiscountedTotal = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'txtPercentTax
      '
      Me.txtPercentTax.Location = New System.Drawing.Point(151, 217)
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(24, 217)
      '
      'txtTax
      '
      Me.txtTax.Location = New System.Drawing.Point(397, 214)
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(270, 214)
      '
      'txtGrandTotal
      '
      Me.txtGrandTotal.Location = New System.Drawing.Point(397, 279)
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(270, 279)
      '
      'btnDone
      '
      Me.btnDone.Location = New System.Drawing.Point(528, 279)
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(271, 256)
      '
      'Label8
      '
      Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label8.Location = New System.Drawing.Point(24, 122)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(121, 24)
      Me.Label8.TabIndex = 14
      Me.Label8.Text = "% Discount"
      '
      'txtPercentDiscount
      '
      Me.txtPercentDiscount.Location = New System.Drawing.Point(151, 120)
      Me.txtPercentDiscount.Name = "txtPercentDiscount"
      Me.txtPercentDiscount.Size = New System.Drawing.Size(110, 26)
      Me.txtPercentDiscount.TabIndex = 15
      Me.txtPercentDiscount.Text = "0"
      Me.txtPercentDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label9
      '
      Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label9.Location = New System.Drawing.Point(270, 122)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(121, 24)
      Me.Label9.TabIndex = 16
      Me.Label9.Text = "Discount"
      '
      'txtDiscount
      '
      Me.txtDiscount.Location = New System.Drawing.Point(397, 120)
      Me.txtDiscount.Name = "txtDiscount"
      Me.txtDiscount.ReadOnly = True
      Me.txtDiscount.Size = New System.Drawing.Size(110, 26)
      Me.txtDiscount.TabIndex = 17
      Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label10
      '
      Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
      Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label10.Location = New System.Drawing.Point(271, 158)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(236, 4)
      Me.Label10.TabIndex = 18
      '
      'txtDiscountedTotal
      '
      Me.txtDiscountedTotal.Location = New System.Drawing.Point(397, 174)
      Me.txtDiscountedTotal.Name = "txtDiscountedTotal"
      Me.txtDiscountedTotal.ReadOnly = True
      Me.txtDiscountedTotal.Size = New System.Drawing.Size(110, 26)
      Me.txtDiscountedTotal.TabIndex = 20
      Me.txtDiscountedTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CalculatorForm_Replacement
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.ClientSize = New System.Drawing.Size(625, 325)
      Me.Controls.Add(Me.txtDiscountedTotal)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.txtDiscount)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.txtPercentDiscount)
      Me.Name = "CalculatorForm_Replacement"
      Me.Controls.SetChildIndex(Me.txtPercentDiscount, 0)
      Me.Controls.SetChildIndex(Me.Label8, 0)
      Me.Controls.SetChildIndex(Me.Label7, 0)
      Me.Controls.SetChildIndex(Me.txtGrandTotal, 0)
      Me.Controls.SetChildIndex(Me.Label6, 0)
      Me.Controls.SetChildIndex(Me.txtTax, 0)
      Me.Controls.SetChildIndex(Me.Label5, 0)
      Me.Controls.SetChildIndex(Me.txtPercentTax, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.btnDone, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtUnits, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.txtUnitPrice, 0)
      Me.Controls.SetChildIndex(Me.Label4, 0)
      Me.Controls.SetChildIndex(Me.txtTotal, 0)
      Me.Controls.SetChildIndex(Me.txtDiscount, 0)
      Me.Controls.SetChildIndex(Me.Label9, 0)
      Me.Controls.SetChildIndex(Me.Label10, 0)
      Me.Controls.SetChildIndex(Me.txtDiscountedTotal, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents txtPercentDiscount As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents txtDiscountedTotal As System.Windows.Forms.TextBox

End Class
