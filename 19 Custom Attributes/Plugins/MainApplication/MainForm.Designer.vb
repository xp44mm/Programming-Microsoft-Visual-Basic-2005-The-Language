<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
      Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuView = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuViewSampleForm = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuViewCalculate = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuPlugins = New System.Windows.Forms.ToolStripMenuItem
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuView, Me.mnuPlugins})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(489, 24)
      Me.MenuStrip1.TabIndex = 0
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'mnuFile
      '
      Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileExit})
      Me.mnuFile.Name = "mnuFile"
      Me.mnuFile.Size = New System.Drawing.Size(35, 20)
      Me.mnuFile.Text = "&File"
      '
      'mnuFileExit
      '
      Me.mnuFileExit.Name = "mnuFileExit"
      Me.mnuFileExit.Size = New System.Drawing.Size(103, 22)
      Me.mnuFileExit.Text = "Exit"
      '
      'mnuView
      '
      Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewSampleForm, Me.mnuViewCalculate})
      Me.mnuView.Name = "mnuView"
      Me.mnuView.Size = New System.Drawing.Size(41, 20)
      Me.mnuView.Text = "View"
      '
      'mnuViewSampleForm
      '
      Me.mnuViewSampleForm.Name = "mnuViewSampleForm"
      Me.mnuViewSampleForm.Size = New System.Drawing.Size(144, 22)
      Me.mnuViewSampleForm.Text = "Sample form"
      '
      'mnuViewCalculate
      '
      Me.mnuViewCalculate.Name = "mnuViewCalculate"
      Me.mnuViewCalculate.Size = New System.Drawing.Size(144, 22)
      Me.mnuViewCalculate.Text = "Calculate"
      '
      'mnuPlugins
      '
      Me.mnuPlugins.Name = "mnuPlugins"
      Me.mnuPlugins.Size = New System.Drawing.Size(52, 20)
      Me.mnuPlugins.Text = "Plugins"
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(489, 228)
      Me.Controls.Add(Me.MenuStrip1)
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "MainForm"
      Me.Text = "Main form"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuViewCalculate As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents mnuPlugins As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
   Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuViewSampleForm As System.Windows.Forms.ToolStripMenuItem

End Class
