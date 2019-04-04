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
      Me.txtFirstName = New System.Windows.Forms.TextBox
      Me.txtLastName = New System.Windows.Forms.TextBox
      Me.txtCity = New System.Windows.Forms.TextBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnRun = New System.Windows.Forms.Button
      Me.btnTextboxWrappers = New System.Windows.Forms.Button
      Me.btnStaticEvents = New System.Windows.Forms.Button
      Me.btnControlArray = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'txtFirstName
      '
      Me.txtFirstName.Location = New System.Drawing.Point(40, 26)
      Me.txtFirstName.Name = "txtFirstName"
      Me.txtFirstName.Size = New System.Drawing.Size(100, 20)
      Me.txtFirstName.TabIndex = 0
      '
      'txtLastName
      '
      Me.txtLastName.Location = New System.Drawing.Point(40, 75)
      Me.txtLastName.Name = "txtLastName"
      Me.txtLastName.Size = New System.Drawing.Size(100, 20)
      Me.txtLastName.TabIndex = 1
      '
      'txtCity
      '
      Me.txtCity.Location = New System.Drawing.Point(40, 127)
      Me.txtCity.Name = "txtCity"
      Me.txtCity.Size = New System.Drawing.Size(100, 20)
      Me.txtCity.TabIndex = 2
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(189, 23)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnRun
      '
      Me.btnRun.Location = New System.Drawing.Point(189, 75)
      Me.btnRun.Name = "btnRun"
      Me.btnRun.Size = New System.Drawing.Size(75, 36)
      Me.btnRun.TabIndex = 4
      Me.btnRun.Text = "Run Notepad"
      Me.btnRun.UseVisualStyleBackColor = True
      '
      'btnTextboxWrappers
      '
      Me.btnTextboxWrappers.Location = New System.Drawing.Point(189, 127)
      Me.btnTextboxWrappers.Name = "btnTextboxWrappers"
      Me.btnTextboxWrappers.Size = New System.Drawing.Size(75, 36)
      Me.btnTextboxWrappers.TabIndex = 5
      Me.btnTextboxWrappers.Text = "TextBox wrappers"
      Me.btnTextboxWrappers.UseVisualStyleBackColor = True
      '
      'btnStaticEvents
      '
      Me.btnStaticEvents.Location = New System.Drawing.Point(189, 178)
      Me.btnStaticEvents.Name = "btnStaticEvents"
      Me.btnStaticEvents.Size = New System.Drawing.Size(75, 36)
      Me.btnStaticEvents.TabIndex = 6
      Me.btnStaticEvents.Text = "Static events"
      Me.btnStaticEvents.UseVisualStyleBackColor = True
      '
      'btnControlArray
      '
      Me.btnControlArray.Location = New System.Drawing.Point(189, 232)
      Me.btnControlArray.Name = "btnControlArray"
      Me.btnControlArray.Size = New System.Drawing.Size(75, 36)
      Me.btnControlArray.TabIndex = 7
      Me.btnControlArray.Text = "Control array"
      Me.btnControlArray.UseVisualStyleBackColor = True
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(302, 307)
      Me.Controls.Add(Me.btnControlArray)
      Me.Controls.Add(Me.btnStaticEvents)
      Me.Controls.Add(Me.btnTextboxWrappers)
      Me.Controls.Add(Me.btnRun)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.txtCity)
      Me.Controls.Add(Me.txtLastName)
      Me.Controls.Add(Me.txtFirstName)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
   Friend WithEvents txtLastName As System.Windows.Forms.TextBox
   Friend WithEvents txtCity As System.Windows.Forms.TextBox
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnRun As System.Windows.Forms.Button
   Friend WithEvents btnTextboxWrappers As System.Windows.Forms.Button
   Friend WithEvents btnStaticEvents As System.Windows.Forms.Button
   Friend WithEvents btnControlArray As System.Windows.Forms.Button

End Class
