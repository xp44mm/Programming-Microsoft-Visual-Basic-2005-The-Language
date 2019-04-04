<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
      Me.txtStep = New System.Windows.Forms.TextBox
      Me.Label4 = New System.Windows.Forms.Label
      Me.txtXMax = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtXMin = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.btnRoots = New System.Windows.Forms.Button
      Me.btnEval = New System.Windows.Forms.Button
      Me.txtResult = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtExpression = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'txtStep
      '
      Me.txtStep.Location = New System.Drawing.Point(707, 142)
      Me.txtStep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtStep.Name = "txtStep"
      Me.txtStep.Size = New System.Drawing.Size(70, 25)
      Me.txtStep.TabIndex = 22
      Me.txtStep.Text = ".01"
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(623, 142)
      Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(72, 33)
      Me.Label4.TabIndex = 21
      Me.Label4.Text = "step"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtXMax
      '
      Me.txtXMax.Location = New System.Drawing.Point(539, 142)
      Me.txtXMax.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtXMax.Name = "txtXMax"
      Me.txtXMax.Size = New System.Drawing.Size(70, 25)
      Me.txtXMax.TabIndex = 20
      Me.txtXMax.Text = "100"
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(455, 142)
      Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(72, 33)
      Me.Label3.TabIndex = 19
      Me.Label3.Text = "xmax"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtXMin
      '
      Me.txtXMin.Location = New System.Drawing.Point(371, 142)
      Me.txtXMin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtXMin.Name = "txtXMin"
      Me.txtXMin.Size = New System.Drawing.Size(70, 25)
      Me.txtXMin.TabIndex = 18
      Me.txtXMin.Text = "-100"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(287, 142)
      Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 33)
      Me.Label2.TabIndex = 17
      Me.Label2.Text = "xmin"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnRoots
      '
      Me.btnRoots.Location = New System.Drawing.Point(160, 142)
      Me.btnRoots.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.btnRoots.Name = "btnRoots"
      Me.btnRoots.Size = New System.Drawing.Size(96, 33)
      Me.btnRoots.TabIndex = 16
      Me.btnRoots.Text = "&Roots"
      '
      'btnEval
      '
      Me.btnEval.Location = New System.Drawing.Point(13, 142)
      Me.btnEval.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.btnEval.Name = "btnEval"
      Me.btnEval.Size = New System.Drawing.Size(96, 33)
      Me.btnEval.TabIndex = 15
      Me.btnEval.Text = "&Eval"
      '
      'txtResult
      '
      Me.txtResult.Location = New System.Drawing.Point(13, 186)
      Me.txtResult.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtResult.Multiline = True
      Me.txtResult.Name = "txtResult"
      Me.txtResult.ReadOnly = True
      Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtResult.Size = New System.Drawing.Size(764, 87)
      Me.txtResult.TabIndex = 14
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(13, 9)
      Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(288, 32)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "F(x) expression"
      '
      'txtExpression
      '
      Me.txtExpression.Location = New System.Drawing.Point(13, 42)
      Me.txtExpression.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtExpression.Multiline = True
      Me.txtExpression.Name = "txtExpression"
      Me.txtExpression.Size = New System.Drawing.Size(764, 87)
      Me.txtExpression.TabIndex = 12
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(796, 297)
      Me.Controls.Add(Me.txtStep)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtXMax)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtXMin)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.btnRoots)
      Me.Controls.Add(Me.btnEval)
      Me.Controls.Add(Me.txtResult)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtExpression)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "MainForm"
      Me.Text = "Expression Evaluator"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtStep As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtXMax As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtXMin As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnRoots As System.Windows.Forms.Button
   Friend WithEvents btnEval As System.Windows.Forms.Button
   Friend WithEvents txtResult As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtExpression As System.Windows.Forms.TextBox
End Class
