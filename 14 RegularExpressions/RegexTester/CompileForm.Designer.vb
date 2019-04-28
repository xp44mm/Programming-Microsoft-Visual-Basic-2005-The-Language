<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompileForm
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
      Me.components = New System.ComponentModel.Container
      Me.btnRemove = New System.Windows.Forms.Button
      Me.btnCompile = New System.Windows.Forms.Button
      Me.txtNamespace = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.btnCancel = New System.Windows.Forms.Button
      Me.dlgOpenRegex = New System.Windows.Forms.OpenFileDialog
      Me.dgrRegexes = New System.Windows.Forms.DataGridView
      Me.grdcolName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.grdcolPattern = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.dgrcolOptions = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RegexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.btnFile = New System.Windows.Forms.Button
      Me.btnNew = New System.Windows.Forms.Button
      Me.btnClear = New System.Windows.Forms.Button
      Me.btnCurrent = New System.Windows.Forms.Button
      Me.Label2 = New System.Windows.Forms.Label
      Me.dlgSaveAssembly = New System.Windows.Forms.SaveFileDialog
      Me.txtAssemblyName = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.dlgAssemblyPath = New System.Windows.Forms.FolderBrowserDialog
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.btnBrowse = New System.Windows.Forms.Button
      Me.txtPath = New System.Windows.Forms.TextBox
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
      CType(Me.dgrRegexes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RegexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnRemove
      '
      Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRemove.Location = New System.Drawing.Point(776, 154)
      Me.btnRemove.Name = "btnRemove"
      Me.btnRemove.Size = New System.Drawing.Size(58, 23)
      Me.btnRemove.TabIndex = 6
      Me.btnRemove.Text = "&Remove"
      Me.ToolTip1.SetToolTip(Me.btnRemove, "Remove the selected regular expression from the list. §(Click on the row header t" & _
              "o the left to select an item.)")
      Me.btnRemove.UseVisualStyleBackColor = True
      '
      'btnCompile
      '
      Me.btnCompile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCompile.Location = New System.Drawing.Point(776, 239)
      Me.btnCompile.Name = "btnCompile"
      Me.btnCompile.Size = New System.Drawing.Size(58, 23)
      Me.btnCompile.TabIndex = 9
      Me.btnCompile.Text = "&Compile"
      Me.ToolTip1.SetToolTip(Me.btnCompile, "Compile the list of regular expressions and generate an assembly.")
      Me.btnCompile.UseVisualStyleBackColor = True
      '
      'txtNamespace
      '
      Me.txtNamespace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNamespace.Location = New System.Drawing.Point(459, 20)
      Me.txtNamespace.Name = "txtNamespace"
      Me.txtNamespace.Size = New System.Drawing.Size(298, 20)
      Me.txtNamespace.TabIndex = 3
      Me.ToolTip1.SetToolTip(Me.txtNamespace, "The namespace used for all the compiled regular expressions.")
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(363, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(90, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "R&oot Namespace"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(776, 268)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(58, 23)
      Me.btnCancel.TabIndex = 10
      Me.btnCancel.Text = "Cancel"
      Me.ToolTip1.SetToolTip(Me.btnCancel, "Close the dialog box without compiling.")
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'dlgOpenRegex
      '
      Me.dlgOpenRegex.DefaultExt = "regex"
      Me.dlgOpenRegex.Filter = "Regex files (*.regex)|*.regex|All files|*.*"
      Me.dlgOpenRegex.Multiselect = True
      Me.dlgOpenRegex.Title = "Open a regex file"
      '
      'dgrRegexes
      '
      Me.dgrRegexes.AllowUserToAddRows = False
      Me.dgrRegexes.AllowUserToResizeRows = False
      Me.dgrRegexes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgrRegexes.AutoGenerateColumns = False
      Me.dgrRegexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgrRegexes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.grdcolName, Me.grdcolPattern, Me.dgrcolOptions})
      Me.dgrRegexes.DataSource = Me.RegexBindingSource
      Me.dgrRegexes.Location = New System.Drawing.Point(7, 29)
      Me.dgrRegexes.MultiSelect = False
      Me.dgrRegexes.Name = "dgrRegexes"
      Me.dgrRegexes.RowHeadersWidth = 24
      Me.dgrRegexes.Size = New System.Drawing.Size(764, 177)
      Me.dgrRegexes.TabIndex = 1
      Me.ToolTip1.SetToolTip(Me.dgrRegexes, "The list of regular expressions to be compiled.")
      '
      'grdcolName
      '
      Me.grdcolName.DataPropertyName = "Name"
      Me.grdcolName.HeaderText = "Name"
      Me.grdcolName.MaxInputLength = 30
      Me.grdcolName.Name = "grdcolName"
      Me.grdcolName.Width = 150
      '
      'grdcolPattern
      '
      Me.grdcolPattern.DataPropertyName = "Pattern"
      Me.grdcolPattern.HeaderText = "Pattern"
      Me.grdcolPattern.MaxInputLength = 1024
      Me.grdcolPattern.Name = "grdcolPattern"
      Me.grdcolPattern.Width = 480
      '
      'dgrcolOptions
      '
      Me.dgrcolOptions.DataPropertyName = "OptionsText"
      Me.dgrcolOptions.HeaderText = "Options"
      Me.dgrcolOptions.Name = "dgrcolOptions"
      '
      'RegexBindingSource
      '
      Me.RegexBindingSource.AllowNew = False
      '
      'btnFile
      '
      Me.btnFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFile.Location = New System.Drawing.Point(776, 87)
      Me.btnFile.Name = "btnFile"
      Me.btnFile.Size = New System.Drawing.Size(58, 23)
      Me.btnFile.TabIndex = 5
      Me.btnFile.Text = "&File"
      Me.ToolTip1.SetToolTip(Me.btnFile, "Add a regular expression saved in a file to the list.")
      Me.btnFile.UseVisualStyleBackColor = True
      '
      'btnNew
      '
      Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNew.Location = New System.Drawing.Point(776, 29)
      Me.btnNew.Name = "btnNew"
      Me.btnNew.Size = New System.Drawing.Size(58, 23)
      Me.btnNew.TabIndex = 3
      Me.btnNew.Text = "&New"
      Me.ToolTip1.SetToolTip(Me.btnNew, "Add a new (blank) regular expression to the list.")
      Me.btnNew.UseVisualStyleBackColor = True
      '
      'btnClear
      '
      Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClear.Location = New System.Drawing.Point(776, 183)
      Me.btnClear.Name = "btnClear"
      Me.btnClear.Size = New System.Drawing.Size(58, 23)
      Me.btnClear.TabIndex = 7
      Me.btnClear.Text = "C&lear"
      Me.ToolTip1.SetToolTip(Me.btnClear, "Remove all items from the list.")
      Me.btnClear.UseVisualStyleBackColor = True
      '
      'btnCurrent
      '
      Me.btnCurrent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCurrent.Location = New System.Drawing.Point(776, 58)
      Me.btnCurrent.Name = "btnCurrent"
      Me.btnCurrent.Size = New System.Drawing.Size(58, 23)
      Me.btnCurrent.TabIndex = 4
      Me.btnCurrent.Text = "C&urrent"
      Me.ToolTip1.SetToolTip(Me.btnCurrent, "Add the current regular expression (the one being §tested in the main window) to " & _
              "the list.")
      Me.btnCurrent.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(9, 209)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(734, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "OPTIONS: I=Ignore case,  M=Multiline, X=Ignore,PatternWhitespace,  C=compiled,  N" & _
          "=ExplicitCapture,  R=RightToLeft, U=CultureInvariant, A=EcmaScript"
      '
      'dlgSaveAssembly
      '
      Me.dlgSaveAssembly.DefaultExt = "dll"
      Me.dlgSaveAssembly.Filter = "All assemblies (*.dll)|*.dll"
      Me.dlgSaveAssembly.Title = "Select the destination assembly"
      '
      'txtAssemblyName
      '
      Me.txtAssemblyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtAssemblyName.Location = New System.Drawing.Point(58, 22)
      Me.txtAssemblyName.Name = "txtAssemblyName"
      Me.txtAssemblyName.Size = New System.Drawing.Size(261, 20)
      Me.txtAssemblyName.TabIndex = 1
      Me.ToolTip1.SetToolTip(Me.txtAssemblyName, "The name of the compiled assembly. §(It is also used to name the generated DLL fi" & _
              "le.)")
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 22)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(35, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "&Name"
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.btnBrowse)
      Me.GroupBox1.Controls.Add(Me.txtPath)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.txtAssemblyName)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.txtNamespace)
      Me.GroupBox1.Location = New System.Drawing.Point(7, 234)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(764, 88)
      Me.GroupBox1.TabIndex = 8
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Generated assembly"
      '
      'btnBrowse
      '
      Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBrowse.Location = New System.Drawing.Point(325, 53)
      Me.btnBrowse.Name = "btnBrowse"
      Me.btnBrowse.Size = New System.Drawing.Size(34, 23)
      Me.btnBrowse.TabIndex = 6
      Me.btnBrowse.Text = "..."
      Me.ToolTip1.SetToolTip(Me.btnBrowse, "Select the output path.")
      Me.btnBrowse.UseVisualStyleBackColor = True
      '
      'txtPath
      '
      Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPath.Location = New System.Drawing.Point(58, 53)
      Me.txtPath.Name = "txtPath"
      Me.txtPath.ReadOnly = True
      Me.txtPath.Size = New System.Drawing.Size(261, 20)
      Me.txtPath.TabIndex = 5
      Me.ToolTip1.SetToolTip(Me.txtPath, "The directory where the compiled assembly is created.")
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(6, 56)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(29, 13)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "&Path"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(4, 9)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(411, 13)
      Me.Label5.TabIndex = 0
      Me.Label5.Text = "Enter the regular expressions expressions to be compiled, or add them from .regex" & _
          " files"
      '
      'CompileForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(846, 339)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.btnCurrent)
      Me.Controls.Add(Me.btnClear)
      Me.Controls.Add(Me.btnNew)
      Me.Controls.Add(Me.btnFile)
      Me.Controls.Add(Me.dgrRegexes)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnCompile)
      Me.Controls.Add(Me.btnRemove)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(854, 373)
      Me.Name = "CompileForm"
      Me.Text = "Compile to Assembly"
      CType(Me.dgrRegexes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RegexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnRemove As System.Windows.Forms.Button
   Friend WithEvents btnCompile As System.Windows.Forms.Button
   Friend WithEvents txtNamespace As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents dlgOpenRegex As System.Windows.Forms.OpenFileDialog
   Friend WithEvents dgrRegexes As System.Windows.Forms.DataGridView
   Friend WithEvents btnFile As System.Windows.Forms.Button
   Friend WithEvents RegexBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents btnNew As System.Windows.Forms.Button
   Friend WithEvents btnClear As System.Windows.Forms.Button
   Friend WithEvents btnCurrent As System.Windows.Forms.Button
   Friend WithEvents grdcolName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grdcolPattern As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents dgrcolOptions As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents dlgSaveAssembly As System.Windows.Forms.SaveFileDialog
   Friend WithEvents txtAssemblyName As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dlgAssemblyPath As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnBrowse As System.Windows.Forms.Button
   Friend WithEvents txtPath As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
