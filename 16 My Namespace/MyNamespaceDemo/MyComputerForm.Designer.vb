<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyComputerForm
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
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.btnStopPlaying = New System.Windows.Forms.Button
      Me.btnPlayAsync = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.btnBrowse = New System.Windows.Forms.Button
      Me.txtWavFile = New System.Windows.Forms.TextBox
      Me.btnPlay = New System.Windows.Forms.Button
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.btnMultipleCopy = New System.Windows.Forms.Button
      Me.btnListFormats = New System.Windows.Forms.Button
      Me.btnPasteWidget = New System.Windows.Forms.Button
      Me.btnCopyWidget = New System.Windows.Forms.Button
      Me.btnExport = New System.Windows.Forms.Button
      Me.rtbClipboard = New System.Windows.Forms.RichTextBox
      Me.btnGetText = New System.Windows.Forms.Button
      Me.GroupBox3 = New System.Windows.Forms.GroupBox
      Me.lstFiles = New System.Windows.Forms.ListBox
      Me.txtFindText = New System.Windows.Forms.TextBox
      Me.btnFindInFiles = New System.Windows.Forms.Button
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.SuspendLayout()
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.DefaultExt = "Wav"
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      Me.OpenFileDialog1.Filter = "All files|*.*|WAV files|*.wav"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnStopPlaying)
      Me.GroupBox1.Controls.Add(Me.btnPlayAsync)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.btnBrowse)
      Me.GroupBox1.Controls.Add(Me.txtWavFile)
      Me.GroupBox1.Controls.Add(Me.btnPlay)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(617, 105)
      Me.GroupBox1.TabIndex = 7
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "My.Computer.Audio"
      '
      'btnStopPlaying
      '
      Me.btnStopPlaying.Location = New System.Drawing.Point(480, 63)
      Me.btnStopPlaying.Margin = New System.Windows.Forms.Padding(4)
      Me.btnStopPlaying.Name = "btnStopPlaying"
      Me.btnStopPlaying.Size = New System.Drawing.Size(79, 28)
      Me.btnStopPlaying.TabIndex = 11
      Me.btnStopPlaying.Text = "Stop"
      Me.btnStopPlaying.UseVisualStyleBackColor = True
      '
      'btnPlayAsync
      '
      Me.btnPlayAsync.Location = New System.Drawing.Point(218, 63)
      Me.btnPlayAsync.Margin = New System.Windows.Forms.Padding(4)
      Me.btnPlayAsync.Name = "btnPlayAsync"
      Me.btnPlayAsync.Size = New System.Drawing.Size(96, 28)
      Me.btnPlayAsync.TabIndex = 10
      Me.btnPlayAsync.Text = "Play Async"
      Me.btnPlayAsync.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 31)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(120, 18)
      Me.Label1.TabIndex = 9
      Me.Label1.Text = "Select a WAV file"
      '
      'btnBrowse
      '
      Me.btnBrowse.Location = New System.Drawing.Point(567, 31)
      Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(38, 28)
      Me.btnBrowse.TabIndex = 8
      Me.btnBrowse.Text = "..."
      Me.btnBrowse.UseVisualStyleBackColor = True
      '
      'txtWavFile
      '
      Me.txtWavFile.Location = New System.Drawing.Point(133, 31)
      Me.txtWavFile.Margin = New System.Windows.Forms.Padding(4)
      Me.txtWavFile.Name = "txtWavFile"
      Me.txtWavFile.Size = New System.Drawing.Size(426, 24)
      Me.txtWavFile.TabIndex = 7
      '
      'btnPlay
      '
      Me.btnPlay.Location = New System.Drawing.Point(131, 63)
      Me.btnPlay.Margin = New System.Windows.Forms.Padding(4)
      Me.btnPlay.Name = "btnPlay"
      Me.btnPlay.Size = New System.Drawing.Size(79, 28)
      Me.btnPlay.TabIndex = 6
      Me.btnPlay.Text = "Play"
      Me.btnPlay.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.btnMultipleCopy)
      Me.GroupBox2.Controls.Add(Me.btnListFormats)
      Me.GroupBox2.Controls.Add(Me.btnPasteWidget)
      Me.GroupBox2.Controls.Add(Me.btnCopyWidget)
      Me.GroupBox2.Controls.Add(Me.btnExport)
      Me.GroupBox2.Controls.Add(Me.rtbClipboard)
      Me.GroupBox2.Controls.Add(Me.btnGetText)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 123)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(617, 155)
      Me.GroupBox2.TabIndex = 8
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "My.Computer.Clipboard"
      '
      'btnMultipleCopy
      '
      Me.btnMultipleCopy.Location = New System.Drawing.Point(9, 100)
      Me.btnMultipleCopy.Margin = New System.Windows.Forms.Padding(4)
      Me.btnMultipleCopy.Name = "btnMultipleCopy"
      Me.btnMultipleCopy.Size = New System.Drawing.Size(105, 28)
      Me.btnMultipleCopy.TabIndex = 13
      Me.btnMultipleCopy.Text = "Multiple copy"
      Me.btnMultipleCopy.UseVisualStyleBackColor = True
      '
      'btnListFormats
      '
      Me.btnListFormats.Location = New System.Drawing.Point(9, 64)
      Me.btnListFormats.Margin = New System.Windows.Forms.Padding(4)
      Me.btnListFormats.Name = "btnListFormats"
      Me.btnListFormats.Size = New System.Drawing.Size(105, 28)
      Me.btnListFormats.TabIndex = 12
      Me.btnListFormats.Text = "List formats"
      Me.btnListFormats.UseVisualStyleBackColor = True
      '
      'btnPasteWidget
      '
      Me.btnPasteWidget.Location = New System.Drawing.Point(473, 118)
      Me.btnPasteWidget.Margin = New System.Windows.Forms.Padding(4)
      Me.btnPasteWidget.Name = "btnPasteWidget"
      Me.btnPasteWidget.Size = New System.Drawing.Size(132, 28)
      Me.btnPasteWidget.TabIndex = 11
      Me.btnPasteWidget.Text = "Paste a widget"
      Me.btnPasteWidget.UseVisualStyleBackColor = True
      '
      'btnCopyWidget
      '
      Me.btnCopyWidget.Location = New System.Drawing.Point(473, 91)
      Me.btnCopyWidget.Margin = New System.Windows.Forms.Padding(4)
      Me.btnCopyWidget.Name = "btnCopyWidget"
      Me.btnCopyWidget.Size = New System.Drawing.Size(132, 28)
      Me.btnCopyWidget.TabIndex = 10
      Me.btnCopyWidget.Text = "Copy a widget"
      Me.btnCopyWidget.UseVisualStyleBackColor = True
      '
      'btnExport
      '
      Me.btnExport.Location = New System.Drawing.Point(473, 28)
      Me.btnExport.Margin = New System.Windows.Forms.Padding(4)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(132, 28)
      Me.btnExport.TabIndex = 9
      Me.btnExport.Text = "Export to Excel"
      Me.btnExport.UseVisualStyleBackColor = True
      '
      'rtbClipboard
      '
      Me.rtbClipboard.Location = New System.Drawing.Point(121, 30)
      Me.rtbClipboard.Name = "rtbClipboard"
      Me.rtbClipboard.Size = New System.Drawing.Size(335, 116)
      Me.rtbClipboard.TabIndex = 8
      Me.rtbClipboard.Text = ""
      '
      'btnGetText
      '
      Me.btnGetText.Location = New System.Drawing.Point(9, 28)
      Me.btnGetText.Margin = New System.Windows.Forms.Padding(4)
      Me.btnGetText.Name = "btnGetText"
      Me.btnGetText.Size = New System.Drawing.Size(105, 28)
      Me.btnGetText.TabIndex = 7
      Me.btnGetText.Text = "GetText"
      Me.btnGetText.UseVisualStyleBackColor = True
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.lstFiles)
      Me.GroupBox3.Controls.Add(Me.txtFindText)
      Me.GroupBox3.Controls.Add(Me.btnFindInFiles)
      Me.GroupBox3.Location = New System.Drawing.Point(12, 284)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(617, 140)
      Me.GroupBox3.TabIndex = 9
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "My.Computer.FileSystem"
      '
      'lstFiles
      '
      Me.lstFiles.FormattingEnabled = True
      Me.lstFiles.ItemHeight = 18
      Me.lstFiles.Location = New System.Drawing.Point(121, 57)
      Me.lstFiles.Name = "lstFiles"
      Me.lstFiles.Size = New System.Drawing.Size(335, 58)
      Me.lstFiles.TabIndex = 9
      '
      'txtFindText
      '
      Me.txtFindText.Location = New System.Drawing.Point(121, 26)
      Me.txtFindText.Margin = New System.Windows.Forms.Padding(4)
      Me.txtFindText.Name = "txtFindText"
      Me.txtFindText.Size = New System.Drawing.Size(335, 24)
      Me.txtFindText.TabIndex = 8
      '
      'btnFindInFiles
      '
      Me.btnFindInFiles.Location = New System.Drawing.Point(9, 23)
      Me.btnFindInFiles.Name = "btnFindInFiles"
      Me.btnFindInFiles.Size = New System.Drawing.Size(105, 27)
      Me.btnFindInFiles.TabIndex = 0
      Me.btnFindInFiles.Text = "FindInFiles"
      Me.btnFindInFiles.UseVisualStyleBackColor = True
      '
      'MyComputerForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(658, 488)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "MyComputerForm"
      Me.Text = "MyComputerForm"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnStopPlaying As System.Windows.Forms.Button
   Friend WithEvents btnPlayAsync As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnBrowse As System.Windows.Forms.Button
   Friend WithEvents txtWavFile As System.Windows.Forms.TextBox
   Friend WithEvents btnPlay As System.Windows.Forms.Button
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents rtbClipboard As System.Windows.Forms.RichTextBox
   Friend WithEvents btnGetText As System.Windows.Forms.Button
   Friend WithEvents btnExport As System.Windows.Forms.Button
   Friend WithEvents btnPasteWidget As System.Windows.Forms.Button
   Friend WithEvents btnCopyWidget As System.Windows.Forms.Button
   Friend WithEvents btnListFormats As System.Windows.Forms.Button
   Friend WithEvents btnMultipleCopy As System.Windows.Forms.Button
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents txtFindText As System.Windows.Forms.TextBox
   Friend WithEvents btnFindInFiles As System.Windows.Forms.Button
   Friend WithEvents lstFiles As System.Windows.Forms.ListBox
End Class
