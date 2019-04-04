<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListWindowsForm
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
      Me.tvwWindows = New System.Windows.Forms.TreeView
      Me.SuspendLayout()
      '
      'tvwWindows
      '
      Me.tvwWindows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tvwWindows.Location = New System.Drawing.Point(12, 12)
      Me.tvwWindows.Name = "tvwWindows"
      Me.tvwWindows.Size = New System.Drawing.Size(268, 242)
      Me.tvwWindows.TabIndex = 13
      '
      'ListWindows
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.tvwWindows)
      Me.Name = "ListWindows"
      Me.Text = "ListWindows"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents tvwWindows As System.Windows.Forms.TreeView
End Class
