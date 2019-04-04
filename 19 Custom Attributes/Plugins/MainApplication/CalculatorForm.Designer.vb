<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalculatorForm
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
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtUnits = New System.Windows.Forms.TextBox
      Me.txtUnitPrice = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtPercentTax = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.txtTotal = New System.Windows.Forms.TextBox
      Me.txtTax = New System.Windows.Forms.TextBox
      Me.Label5 = New System.Windows.Forms.Label
      Me.txtGrandTotal = New System.Windows.Forms.TextBox
      Me.Label6 = New System.Windows.Forms.Label
      Me.btnDone = New System.Windows.Forms.Button
      Me.Label7 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label1.Location = New System.Drawing.Point(24, 29)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(121, 26)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Units"
      '
      'txtUnits
      '
      Me.txtUnits.Location = New System.Drawing.Point(151, 29)
      Me.txtUnits.Name = "txtUnits"
      Me.txtUnits.Size = New System.Drawing.Size(110, 26)
      Me.txtUnits.TabIndex = 1
      Me.txtUnits.Text = "1"
      Me.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtUnitPrice
      '
      Me.txtUnitPrice.Location = New System.Drawing.Point(151, 74)
      Me.txtUnitPrice.Name = "txtUnitPrice"
      Me.txtUnitPrice.Size = New System.Drawing.Size(110, 26)
      Me.txtUnitPrice.TabIndex = 3
      Me.txtUnitPrice.Text = "100"
      Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label2.Location = New System.Drawing.Point(24, 74)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(121, 26)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Unit price"
      '
      'txtPercentTax
      '
      Me.txtPercentTax.Location = New System.Drawing.Point(151, 118)
      Me.txtPercentTax.Name = "txtPercentTax"
      Me.txtPercentTax.Size = New System.Drawing.Size(110, 26)
      Me.txtPercentTax.TabIndex = 5
      Me.txtPercentTax.Text = "6"
      Me.txtPercentTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label3.Location = New System.Drawing.Point(24, 118)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(121, 26)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "% Tax"
      '
      'Label4
      '
      Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label4.Location = New System.Drawing.Point(270, 76)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(121, 26)
      Me.Label4.TabIndex = 6
      Me.Label4.Text = "Total"
      '
      'txtTotal
      '
      Me.txtTotal.Location = New System.Drawing.Point(397, 76)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(110, 26)
      Me.txtTotal.TabIndex = 7
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTax
      '
      Me.txtTax.Location = New System.Drawing.Point(397, 116)
      Me.txtTax.Name = "txtTax"
      Me.txtTax.ReadOnly = True
      Me.txtTax.Size = New System.Drawing.Size(110, 26)
      Me.txtTax.TabIndex = 9
      Me.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label5.Location = New System.Drawing.Point(270, 116)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(121, 26)
      Me.Label5.TabIndex = 8
      Me.Label5.Text = "Tax"
      '
      'txtGrandTotal
      '
      Me.txtGrandTotal.Location = New System.Drawing.Point(397, 180)
      Me.txtGrandTotal.Name = "txtGrandTotal"
      Me.txtGrandTotal.ReadOnly = True
      Me.txtGrandTotal.Size = New System.Drawing.Size(110, 26)
      Me.txtGrandTotal.TabIndex = 11
      Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label6.Location = New System.Drawing.Point(270, 180)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(121, 26)
      Me.Label6.TabIndex = 10
      Me.Label6.Text = "Grand total"
      '
      'btnDone
      '
      Me.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnDone.Location = New System.Drawing.Point(528, 180)
      Me.btnDone.Name = "btnDone"
      Me.btnDone.Size = New System.Drawing.Size(75, 26)
      Me.btnDone.TabIndex = 12
      Me.btnDone.Text = "Done"
      Me.btnDone.UseVisualStyleBackColor = True
      '
      'Label7
      '
      Me.Label7.BackColor = System.Drawing.Color.Black
      Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.Label7.Location = New System.Drawing.Point(271, 157)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(236, 4)
      Me.Label7.TabIndex = 13
      '
      'CalculatorForm
      '
      Me.AcceptButton = Me.btnDone
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(621, 225)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.btnDone)
      Me.Controls.Add(Me.txtGrandTotal)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtTax)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtPercentTax)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtUnitPrice)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtUnits)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.Name = "CalculatorForm"
      Me.Text = "Calculator"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected WithEvents Label1 As System.Windows.Forms.Label
   Protected WithEvents txtUnits As System.Windows.Forms.TextBox
   Protected WithEvents txtUnitPrice As System.Windows.Forms.TextBox
   Protected WithEvents Label2 As System.Windows.Forms.Label
   Protected WithEvents txtPercentTax As System.Windows.Forms.TextBox
   Protected WithEvents Label3 As System.Windows.Forms.Label
   Protected WithEvents Label4 As System.Windows.Forms.Label
   Protected WithEvents txtTotal As System.Windows.Forms.TextBox
   Protected WithEvents txtTax As System.Windows.Forms.TextBox
   Protected WithEvents Label5 As System.Windows.Forms.Label
   Protected WithEvents txtGrandTotal As System.Windows.Forms.TextBox
   Protected WithEvents Label6 As System.Windows.Forms.Label
   Protected WithEvents btnDone As System.Windows.Forms.Button
   Protected WithEvents Label7 As System.Windows.Forms.Label
End Class
