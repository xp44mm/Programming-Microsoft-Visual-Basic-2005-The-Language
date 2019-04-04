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
      Me.btnFindWindow = New System.Windows.Forms.Button
      Me.txtWindowTitle = New System.Windows.Forms.TextBox
      Me.btnGetClassName = New System.Windows.Forms.Button
      Me.btnTestUnions = New System.Windows.Forms.Button
      Me.btnTestCopyFile = New System.Windows.Forms.Button
      Me.txtFrom = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtTo = New System.Windows.Forms.TextBox
      Me.btnEnumWindows = New System.Windows.Forms.Button
      Me.Label3 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'btnFindWindow
      '
      Me.btnFindWindow.Location = New System.Drawing.Point(12, 32)
      Me.btnFindWindow.Name = "btnFindWindow"
      Me.btnFindWindow.Size = New System.Drawing.Size(137, 23)
      Me.btnFindWindow.TabIndex = 0
      Me.btnFindWindow.Text = "Find Window"
      Me.btnFindWindow.UseVisualStyleBackColor = True
      '
      'txtWindowTitle
      '
      Me.txtWindowTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtWindowTitle.Location = New System.Drawing.Point(208, 32)
      Me.txtWindowTitle.Name = "txtWindowTitle"
      Me.txtWindowTitle.Size = New System.Drawing.Size(252, 20)
      Me.txtWindowTitle.TabIndex = 1
      Me.txtWindowTitle.Text = "Notepad - Untitled"
      '
      'btnGetClassName
      '
      Me.btnGetClassName.Location = New System.Drawing.Point(12, 70)
      Me.btnGetClassName.Name = "btnGetClassName"
      Me.btnGetClassName.Size = New System.Drawing.Size(137, 23)
      Me.btnGetClassName.TabIndex = 2
      Me.btnGetClassName.Text = "GetClassName"
      Me.btnGetClassName.UseVisualStyleBackColor = True
      '
      'btnTestUnions
      '
      Me.btnTestUnions.Location = New System.Drawing.Point(12, 115)
      Me.btnTestUnions.Name = "btnTestUnions"
      Me.btnTestUnions.Size = New System.Drawing.Size(137, 23)
      Me.btnTestUnions.TabIndex = 3
      Me.btnTestUnions.Text = "Test unions"
      Me.btnTestUnions.UseVisualStyleBackColor = True
      '
      'btnTestCopyFile
      '
      Me.btnTestCopyFile.Location = New System.Drawing.Point(12, 162)
      Me.btnTestCopyFile.Name = "btnTestCopyFile"
      Me.btnTestCopyFile.Size = New System.Drawing.Size(137, 23)
      Me.btnTestCopyFile.TabIndex = 4
      Me.btnTestCopyFile.Text = "Test CopyFile"
      Me.btnTestCopyFile.UseVisualStyleBackColor = True
      '
      'txtFrom
      '
      Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtFrom.Location = New System.Drawing.Point(208, 162)
      Me.txtFrom.Name = "txtFrom"
      Me.txtFrom.Size = New System.Drawing.Size(252, 20)
      Me.txtFrom.TabIndex = 5
      Me.txtFrom.Text = "c:\Windows\*.*"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(155, 165)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(30, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "From"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(155, 191)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(20, 13)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "To"
      '
      'txtTo
      '
      Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTo.Location = New System.Drawing.Point(208, 188)
      Me.txtTo.Name = "txtTo"
      Me.txtTo.Size = New System.Drawing.Size(252, 20)
      Me.txtTo.TabIndex = 7
      Me.txtTo.Text = "c:\Backup"
      '
      'btnEnumWindows
      '
      Me.btnEnumWindows.Location = New System.Drawing.Point(12, 230)
      Me.btnEnumWindows.Name = "btnEnumWindows"
      Me.btnEnumWindows.Size = New System.Drawing.Size(137, 23)
      Me.btnEnumWindows.TabIndex = 9
      Me.btnEnumWindows.Text = "EnumWindows"
      Me.btnEnumWindows.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(155, 35)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(27, 13)
      Me.Label3.TabIndex = 11
      Me.Label3.Text = "Title"
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(484, 370)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.btnEnumWindows)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtTo)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtFrom)
      Me.Controls.Add(Me.btnTestCopyFile)
      Me.Controls.Add(Me.btnTestUnions)
      Me.Controls.Add(Me.btnGetClassName)
      Me.Controls.Add(Me.txtWindowTitle)
      Me.Controls.Add(Me.btnFindWindow)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnFindWindow As System.Windows.Forms.Button
   Friend WithEvents txtWindowTitle As System.Windows.Forms.TextBox
   Friend WithEvents btnGetClassName As System.Windows.Forms.Button
   Friend WithEvents btnTestUnions As System.Windows.Forms.Button
   Friend WithEvents btnTestCopyFile As System.Windows.Forms.Button
   Friend WithEvents txtFrom As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtTo As System.Windows.Forms.TextBox
   Friend WithEvents btnEnumWindows As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
