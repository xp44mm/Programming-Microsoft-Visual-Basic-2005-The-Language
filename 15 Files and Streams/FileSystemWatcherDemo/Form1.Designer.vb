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

   Friend WithEvents fsw As System.IO.FileSystemWatcher
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtPath As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents chkIncludeSubdirs As System.Windows.Forms.CheckBox
   Friend WithEvents txtLog As System.Windows.Forms.TextBox
   Friend WithEvents chkEnableEvents As System.Windows.Forms.CheckBox
   Friend WithEvents txtFilter As System.Windows.Forms.TextBox
   Friend WithEvents btnWaitForChanged As System.Windows.Forms.Button

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.chkEnableEvents = New System.Windows.Forms.CheckBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtPath = New System.Windows.Forms.TextBox
      Me.txtFilter = New System.Windows.Forms.TextBox
      Me.txtLog = New System.Windows.Forms.TextBox
      Me.btnWaitForChanged = New System.Windows.Forms.Button
      Me.fsw = New System.IO.FileSystemWatcher
      Me.chkIncludeSubdirs = New System.Windows.Forms.CheckBox
      CType(Me.fsw, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'chkEnableEvents
      '
      Me.chkEnableEvents.Location = New System.Drawing.Point(16, 128)
      Me.chkEnableEvents.Name = "chkEnableEvents"
      Me.chkEnableEvents.Size = New System.Drawing.Size(216, 26)
      Me.chkEnableEvents.TabIndex = 6
      Me.chkEnableEvents.Text = "Enable Events"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(248, 16)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Path"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(16, 72)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(248, 16)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Filter"
      '
      'txtPath
      '
      Me.txtPath.Location = New System.Drawing.Point(16, 40)
      Me.txtPath.Name = "txtPath"
      Me.txtPath.Size = New System.Drawing.Size(416, 24)
      Me.txtPath.TabIndex = 1
      Me.txtPath.Text = "c:\"
      '
      'txtFilter
      '
      Me.txtFilter.Location = New System.Drawing.Point(16, 96)
      Me.txtFilter.Name = "txtFilter"
      Me.txtFilter.Size = New System.Drawing.Size(176, 24)
      Me.txtFilter.TabIndex = 1
      Me.txtFilter.Text = "*.*"
      '
      'txtLog
      '
      Me.txtLog.Location = New System.Drawing.Point(16, 160)
      Me.txtLog.Multiline = True
      Me.txtLog.Name = "txtLog"
      Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtLog.Size = New System.Drawing.Size(424, 104)
      Me.txtLog.TabIndex = 5
      '
      'btnWaitForChanged
      '
      Me.btnWaitForChanged.Location = New System.Drawing.Point(224, 128)
      Me.btnWaitForChanged.Name = "btnWaitForChanged"
      Me.btnWaitForChanged.Size = New System.Drawing.Size(176, 24)
      Me.btnWaitForChanged.TabIndex = 7
      Me.btnWaitForChanged.Text = "WaitForChanged"
      '
      'fsw
      '
      Me.fsw.EnableRaisingEvents = True
      Me.fsw.Path = "c:\"
      Me.fsw.SynchronizingObject = Me
      '
      'chkIncludeSubdirs
      '
      Me.chkIncludeSubdirs.Location = New System.Drawing.Point(224, 96)
      Me.chkIncludeSubdirs.Name = "chkIncludeSubdirs"
      Me.chkIncludeSubdirs.Size = New System.Drawing.Size(176, 24)
      Me.chkIncludeSubdirs.TabIndex = 4
      Me.chkIncludeSubdirs.Text = "Include Subdirectories"
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(7, 17)
      Me.ClientSize = New System.Drawing.Size(448, 277)
      Me.Controls.Add(Me.btnWaitForChanged)
      Me.Controls.Add(Me.chkEnableEvents)
      Me.Controls.Add(Me.txtLog)
      Me.Controls.Add(Me.chkIncludeSubdirs)
      Me.Controls.Add(Me.txtFilter)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPath)
      Me.Controls.Add(Me.Label1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "Form1"
      Me.Text = "FileSystemWatcherForm"
      CType(Me.fsw, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub
End Class
