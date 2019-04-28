Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module MainModule

    Sub Main(ByVal args() As String)
        Dim fileName As String = args(0)
        Dim code As String = File.ReadAllText(fileName)
        Dim stats As New CodeStats("FILE", fileName, code)
        Console.Write(stats.Description(0))
    End Sub

End Module

Public Class CodeStats
    Public Type As String
    Public Name As String
    Public TotalLines As Integer
    Public BlankLines As Integer
    Public CommentLines As Integer
    Public ExecutableLines As Integer

    ' Child elements
    Public Members As New List(Of CodeStats)()

    Dim reTotalLines As New Regex("^.*$", RegexOptions.Multiline)
    Dim reBlankLines As New Regex("^\s*$", RegexOptions.Multiline)

    Dim reCommentLines As New Regex("^\s*('|Rem ).*$",
       RegexOptions.Multiline Or RegexOptions.IgnoreCase)

    Dim reTypes As New Regex("(Public|Friend|Private|Protected|Protected Friend)?\s*" &
       "(Shadows|NotInheritable|MustInherit)?\s*" &
       "(?<type>(Class|Module|Interface|Enum|Structure))" &
       "\s+(?<name>\w+)[\w\W]+?End \k<type>",
       RegexOptions.IgnoreCase Or RegexOptions.Multiline)

    Dim reMembers As New Regex("(Public|Friend|Private|Protected|Protected Friend)?\s*" &
       "(Default|Shared)?\s*(ReadOnly|WriteOnly)?\s*(Overloads)?\s*" &
       "(Shadows|Overridable|Overrides|MustOverride|NotOverridable)?\s*" &
       "(?<type>(Function|Sub|Property))\s+(?<name>\w+)[\w\W]+?End \k<type>",
       RegexOptions.IgnoreCase Or RegexOptions.Multiline)

    ' The constructor
    Sub New(ByVal type As String, ByVal name As String, ByVal code As String)
        Me.Type = type
        Me.Name = name
        Me.TotalLines = reTotalLines.Matches(code).Count
        Me.BlankLines = reBlankLines.Matches(code).Count
        Me.CommentLines = reCommentLines.Matches(code).Count
        Me.ExecutableLines = TotalLines - BlankLines - CommentLines

        If type = "FILE" Then
            For Each m As Match In reTypes.Matches(code)
                Members.Add(New CodeStats("TYPE", m.Groups("name").Value, m.Value))
            Next
        ElseIf type = "TYPE" Then
            For Each m As Match In reMembers.Matches(code)
                Members.Add(New CodeStats("MEMBER", m.Groups("name").Value, m.Value))
            Next
        End If
    End Sub

    Function Description(ByVal indentLevel As Integer) As String
        Dim indent As New String(" "c, indentLevel * 2)
        Dim sb As New StringBuilder()
        sb.AppendFormat("{0}{1} {2}{3}", indent, Type, Name, Environment.NewLine)
        indent &= "  "
        sb.AppendFormat("{0}Total lines:      {1,6}{2}", indent, TotalLines, Environment.NewLine)
        sb.AppendFormat("{0}Blank lines:      {1,6}{2,9:P1}{3}", indent,
           BlankLines, BlankLines / TotalLines, Environment.NewLine)
        sb.AppendFormat("{0}Comment lines:    {1,6}{2,9:P1}{3}", indent,
           CommentLines, CommentLines / TotalLines, Environment.NewLine)
        sb.AppendFormat("{0}Executable lines: {1,6}{2,9:P1}{3}", indent,
           ExecutableLines, ExecutableLines / TotalLines, Environment.NewLine)
        sb.Append(Environment.NewLine)
        ' Ask child objects to display their description.
        For Each stats As CodeStats In Me.Members
            sb.Append(stats.Description(indentLevel + 1))
        Next
        Return sb.ToString()
    End Function

End Class
