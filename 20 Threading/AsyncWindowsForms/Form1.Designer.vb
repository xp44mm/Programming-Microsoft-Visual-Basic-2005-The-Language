<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
      Me.lblMessage = New System.Windows.Forms.Label
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnStart = New System.Windows.Forms.Button
      Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
      Me.lstFiles = New System.Windows.Forms.ListBox
      Me.SuspendLayout()
      '
      'lblMessage
      '
      Me.lblMessage.AutoSize = True
      Me.lblMessage.Location = New System.Drawing.Point(124, 33)
      Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(51, 18)
      Me.lblMessage.TabIndex = 0
      Me.lblMessage.Text = "Label1"
      '
      'btnSearch
      '
      Me.btnSearch.Location = New System.Drawing.Point(12, 28)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(94, 28)
      Me.btnSearch.TabIndex = 1
      Me.btnSearch.Text = "Search files"
      Me.btnSearch.UseVisualStyleBackColor = True
      '
      'btnStart
      '
      Me.btnStart.Location = New System.Drawing.Point(12, 85)
      Me.btnStart.Name = "btnStart"
      Me.btnStart.Size = New System.Drawing.Size(94, 28)
      Me.btnStart.TabIndex = 2
      Me.btnStart.Text = "Start"
      Me.btnStart.UseVisualStyleBackColor = True
      '
      'BackgroundWorker1
      '
      Me.BackgroundWorker1.WorkerReportsProgress = True
      Me.BackgroundWorker1.WorkerSupportsCancellation = True
      '
      'lstFiles
      '
      Me.lstFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstFiles.FormattingEnabled = True
      Me.lstFiles.ItemHeight = 18
      Me.lstFiles.Location = New System.Drawing.Point(127, 85)
      Me.lstFiles.Name = "lstFiles"
      Me.lstFiles.Size = New System.Drawing.Size(547, 364)
      Me.lstFiles.TabIndex = 3
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(686, 461)
      Me.Controls.Add(Me.lstFiles)
      Me.Controls.Add(Me.btnStart)
      Me.Controls.Add(Me.btnSearch)
      Me.Controls.Add(Me.lblMessage)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents btnSearch As System.Windows.Forms.Button
   Friend WithEvents btnStart As System.Windows.Forms.Button
   Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
   Friend WithEvents lstFiles As System.Windows.Forms.ListBox

End Class
