Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports System.IO

Public Class CompileForm

   Public MainForm As MainForm

   ' This list lives until the application shuts down
   Shared regexList As New BindingList(Of RegexInfo)

   Private Sub CompileForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' set all tooltips and help messages
      Helpers.SetTooltipsAndHelpMessages(Me, Me.ToolTip1, Me.HelpProvider1)
      ' Display the list of regexes
      RegexBindingSource.DataSource = regexList
   End Sub


   Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
      regexList.Add(New RegexInfo())
   End Sub

   Private Sub btnCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrent.Click
      Me.MainForm.UpdateOptionFiels()
      Dim ri As RegexInfo = RegexInfo.FromProjectOption(Me.MainForm.Options)
      regexList.Add(ri)
   End Sub

   Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
      ' Add from a regex file
      If dlgOpenRegex.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
      Try
         Dim prjOption As ProjectOptions = ProjectOptions.Load(dlgOpenRegex.FileName)
         Dim ri As RegexInfo = RegexInfo.FromProjectOption(prjOption)
         regexList.Add(ri)
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Unable to open regex file", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return
      End Try
   End Sub

   Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
      If dgrRegexes.SelectedRows.Count = 0 Then
         MessageBox.Show("Please select an entire row", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return
      End If

      For Each dgvr As DataGridViewRow In dgrRegexes.SelectedRows
         regexList.RemoveAt(dgvr.Index)
      Next
   End Sub

   Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
      If MessageBox.Show("Do you want to remove all items?", "Remove all rows", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
         regexList.Clear()
      End If
   End Sub

   Private Sub btnCompile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompile.Click
      Dim reList As New List(Of RegexInfo)

      ' sanity check
      If txtAssemblyName.TextLength = 0 OrElse txtNamespace.TextLength = 0 Then
         MessageBox.Show("Please type the name of the assembly and its root namespace", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return
      ElseIf txtPath.TextLength = 0 Then
         MessageBox.Show("Please select the output path.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return
      Else
         For Each ri As RegexInfo In regexList
            ' skip over empty entries
            If ri.Name = "" AndAlso ri.Pattern = "" Then Continue For
            ' check that both values are provided
            If ri.Name = "" Or ri.Pattern = "" Then
               MessageBox.Show("Please enter name and pattern for all regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return
            End If
            reList.Add(ri)
         Next
         ' check that at least one regex is included
         If reList.Count = 0 Then
            MessageBox.Show("Please enter one or more regex expressions", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
         End If
      End If

      Dim compInfoList As New List(Of RegexCompilationInfo)
      For Each ri As RegexInfo In reList
         Dim rci As New RegexCompilationInfo(ri.Pattern, ri.Options, ri.Name, txtNamespace.Text, True)
         compInfoList.Add(rci)
      Next
      ' create the array
      Dim rciArray() As RegexCompilationInfo = compInfoList.ToArray()

      ' Compile these types to an assembly named "CustomRegularExpressions"
      Dim an As New AssemblyName(txtAssemblyName.Text)
      an.CodeBase = Path.Combine(txtPath.Text, Path.ChangeExtension(txtAssemblyName.Text, ".dll"))

      Try
         Regex.CompileToAssembly(rciArray, an)
         MessageBox.Show("The assembly has been created", "Compilation Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
      If dlgAssemblyPath.ShowDialog() = Windows.Forms.DialogResult.OK Then
         txtPath.Text = dlgAssemblyPath.SelectedPath
      End If
   End Sub
End Class

Class RegexInfo
   Private m_Name As String = ""
   Private m_Pattern As String = ""
   Private m_Options As RegexOptions

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         m_Name = value
      End Set
   End Property

   Public Property Pattern() As String
      Get
         Return m_Pattern
      End Get
      Set(ByVal value As String)
         m_Pattern = value
      End Set
   End Property

   Public Property Options() As RegexOptions
      Get
         Return m_Options
      End Get
      Set(ByVal value As RegexOptions)
         m_Options = value
      End Set
   End Property

   Public Property OptionsText() As String
      Get
         Dim res As String = ""
         If CBool(m_Options And RegexOptions.IgnoreCase) Then res &= "I"
         If CBool(m_Options And RegexOptions.IgnorePatternWhitespace) Then res &= "X"
         If CBool(m_Options And RegexOptions.Multiline) Then res &= "M"
         If CBool(m_Options And RegexOptions.Compiled) Then res &= "C"
         If CBool(m_Options And RegexOptions.ExplicitCapture) Then res &= "N"
         If CBool(m_Options And RegexOptions.RightToLeft) Then res &= "R"
         If CBool(m_Options And RegexOptions.CultureInvariant) Then res &= "U"
         If CBool(m_Options And RegexOptions.ECMAScript) Then res &= "A"
         Return res
      End Get
      Set(ByVal value As String)
         value = value.ToUpper()
         m_Options = RegexOptions.None
         If value.Contains("I") Then m_Options = m_Options Or RegexOptions.IgnoreCase
         If value.Contains("X") Then m_Options = m_Options Or RegexOptions.IgnorePatternWhitespace
         If value.Contains("M") Then m_Options = m_Options Or RegexOptions.Multiline
         If value.Contains("C") Then m_Options = m_Options Or RegexOptions.Compiled
         If value.Contains("N") Then m_Options = m_Options Or RegexOptions.ExplicitCapture
         If value.Contains("R") Then m_Options = m_Options Or RegexOptions.RightToLeft
         If value.Contains("U") Then m_Options = m_Options Or RegexOptions.CultureInvariant
         If value.Contains("A") Then m_Options = m_Options Or RegexOptions.ECMAScript
      End Set
   End Property

   Public Shared Function FromProjectOption(ByVal prjOptions As ProjectOptions) As RegexInfo
      Dim ri As New RegexInfo
      ri.Name = prjOptions.RegexName
      ri.Pattern = prjOptions.RegexText
      ri.Options = prjOptions.RegexOptions
      Return ri
   End Function
End Class

