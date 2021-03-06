Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics

Public Module ProgrammingVB2005Macros


    Sub WrapInIfThenElse()
        ' Open an undo context.
        DTE.UndoContext.Open("WrapInIfThenElse")
        ' Retrieve the selected text, append a newline if necessary.
        Dim selText As String = DTE.ActiveDocument.Selection.Text
        If Not selText.EndsWith(ControlChars.NewLine) Then selText &= ControlChars.NewLine
        ' Embed the selected text in an If...Then...Else block.
        Dim newText As String = String.Format("If condition Then{0}{1}Else{0}{0}End If{0}", _
           ControlChars.NewLine, selText)
        ' Replace the selection with the new text and format the document.
        DTE.ActiveDocument.Selection.Text = newText
        DTE.ExecuteCommand("Edit.FormatDocument")
        ' Close the undo context.
        DTE.UndoContext.Close()
    End Sub

    Sub CreateProperty()
        Dim propName As String = InputBox("Enter the name of the property")
        If propName = "" Then Exit Sub
        Dim propType As String = InputBox("Enter the property type", , "String")
        If propType = "" Then Exit Sub
        Dim res As MsgBoxResult = MsgBox("Do you want to check incoming values?", _
           MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
        Dim doCheck As String = (res = MsgBoxResult.Yes).ToString()
        CreateProperty(propName, propType, doCheck)
    End Sub

    ' Macro with arguments
    Sub CreateProperty(ByVal propName As String, Optional ByVal propType As String = "String", _
      Optional ByVal doCheck As String = "True")
        DTE.UndoContext.Open("CreateProperty " & propName)
        Dim varName As String = "m_" & propName
        Dim pattern As String = "Private {3} As {2}{0}{0}" _
           & "Public Property {1} As {2}{0}" _
           & "Get{0}Return {3}{0}End Get{0}Set(Byval value As {2}){0}"
        If CBool(doCheck) Then
            pattern &= "If value is Nothing Then{0}" _
               & "Throw New ArgumentException(){0}End If{0}"
        End If
        pattern &= "{3} = value{0}End Set{0}End Property{0}"
        Dim newText As String = String.Format(pattern, ControlChars.NewLine, _
           propName, propType, varName)
        DTE.ActiveDocument.Selection.Insert(newText)
        DTE.ExecuteCommand("Edit.FormatDocument")
        DTE.UndoContext.Close()
    End Sub

    Public WithEvents TextDocumentKeyPressEvents As TextDocumentKeyPressEvents = EnvironmentEvents.TextDocumentKeyPressEvents

    Private Sub TextDocumentKeyPressEvents_AfterKeyPress(ByVal Keypress As String, _
       ByVal Selection As EnvDTE.TextSelection, ByVal InStatementCompletion As Boolean) _
       Handles TextDocumentKeyPressEvents.AfterKeyPress
        ' If the key is among those we're looking for, replace the current selection
        ' with the close parenthesis, then move the caret one position to the
        ' left, so that it is left between the open and close parenthesises. 
        If Keypress = "(" Then
            Selection.Text = ")"
            Selection.CharLeft()
        ElseIf Keypress = "{" Then
            Selection.Text = "}"
            Selection.CharLeft()
        ElseIf Keypress = "[" Then
            Selection.Text = "]"
            Selection.CharLeft()
        End If
    End Sub

End Module
