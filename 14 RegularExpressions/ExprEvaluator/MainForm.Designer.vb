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
      Me.btnEval = New System.Windows.Forms.Button
      Me.txtResult = New System.Windows.Forms.TextBox
      Me.txtExpression = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'btnEval
      '
      Me.btnEval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEval.Location = New System.Drawing.Point(622, 42)
      Me.btnEval.Margin = New System.Windows.Forms.Padding(4)
      Me.btnEval.Name = "btnEval"
      Me.btnEval.Size = New System.Drawing.Size(74, 33)
      Me.btnEval.TabIndex = 7
      Me.btnEval.Text = "&Eval"
      '
      'txtResult
      '
      Me.txtResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtResult.BackColor = System.Drawing.Color.WhiteSmoke
      Me.txtResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtResult.ForeColor = System.Drawing.Color.SteelBlue
      Me.txtResult.Location = New System.Drawing.Point(13, 164)
      Me.txtResult.Margin = New System.Windows.Forms.Padding(4)
      Me.txtResult.Name = "txtResult"
      Me.txtResult.Size = New System.Drawing.Size(596, 26)
      Me.txtResult.TabIndex = 6
      '
      'txtExpression
      '
      Me.txtExpression.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtExpression.Location = New System.Drawing.Point(13, 42)
      Me.txtExpression.Margin = New System.Windows.Forms.Padding(4)
      Me.txtExpression.Multiline = True
      Me.txtExpression.Name = "txtExpression"
      Me.txtExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtExpression.Size = New System.Drawing.Size(596, 87)
      Me.txtExpression.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(13, 9)
      Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(326, 33)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Enter an expression"
      '
      'MainForm
      '
      Me.AcceptButton = Me.btnEval
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(718, 212)
      Me.Controls.Add(Me.btnEval)
      Me.Controls.Add(Me.txtResult)
      Me.Controls.Add(Me.txtExpression)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "MainForm"
      Me.Text = "Expression Evaluator"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnEval As System.Windows.Forms.Button
   Friend WithEvents txtResult As System.Windows.Forms.TextBox
   Friend WithEvents txtExpression As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
