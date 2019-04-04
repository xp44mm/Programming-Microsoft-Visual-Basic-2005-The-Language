<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetworkForm
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
      Me.txtUrl = New System.Windows.Forms.TextBox
      Me.btnPing = New System.Windows.Forms.Button
      Me.lblPingResult = New System.Windows.Forms.Label
      Me.btnDownload = New System.Windows.Forms.Button
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtDestfile = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(22, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 18)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "URL"
      '
      'txtUrl
      '
      Me.txtUrl.Location = New System.Drawing.Point(82, 22)
      Me.txtUrl.Name = "txtUrl"
      Me.txtUrl.Size = New System.Drawing.Size(567, 24)
      Me.txtUrl.TabIndex = 1
      Me.txtUrl.Text = "www.dotnet2themax.com"
      '
      'btnPing
      '
      Me.btnPing.Location = New System.Drawing.Point(82, 73)
      Me.btnPing.Name = "btnPing"
      Me.btnPing.Size = New System.Drawing.Size(86, 29)
      Me.btnPing.TabIndex = 2
      Me.btnPing.Text = "Ping"
      Me.btnPing.UseVisualStyleBackColor = True
      '
      'lblPingResult
      '
      Me.lblPingResult.AutoSize = True
      Me.lblPingResult.Location = New System.Drawing.Point(174, 78)
      Me.lblPingResult.Name = "lblPingResult"
      Me.lblPingResult.Size = New System.Drawing.Size(51, 18)
      Me.lblPingResult.TabIndex = 3
      Me.lblPingResult.Text = "Label2"
      '
      'btnDownload
      '
      Me.btnDownload.Location = New System.Drawing.Point(82, 136)
      Me.btnDownload.Name = "btnDownload"
      Me.btnDownload.Size = New System.Drawing.Size(86, 29)
      Me.btnDownload.TabIndex = 4
      Me.btnDownload.Text = "Download"
      Me.btnDownload.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(174, 141)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(104, 18)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Destination file"
      '
      'txtDestfile
      '
      Me.txtDestfile.Location = New System.Drawing.Point(284, 141)
      Me.txtDestfile.Name = "txtDestfile"
      Me.txtDestfile.Size = New System.Drawing.Size(365, 24)
      Me.txtDestfile.TabIndex = 6
      '
      'NetworkForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(700, 231)
      Me.Controls.Add(Me.txtDestfile)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.btnDownload)
      Me.Controls.Add(Me.lblPingResult)
      Me.Controls.Add(Me.btnPing)
      Me.Controls.Add(Me.txtUrl)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "NetworkForm"
      Me.Text = "NetworkForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtUrl As System.Windows.Forms.TextBox
   Friend WithEvents btnPing As System.Windows.Forms.Button
   Friend WithEvents lblPingResult As System.Windows.Forms.Label
   Friend WithEvents btnDownload As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtDestfile As System.Windows.Forms.TextBox
End Class
