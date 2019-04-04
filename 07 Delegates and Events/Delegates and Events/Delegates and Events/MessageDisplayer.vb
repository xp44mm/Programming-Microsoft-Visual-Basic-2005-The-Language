Public Class MessageDisplayer
   ' Show a message box; return True if user clicks Yes.
   Public Shared Function AskYesNo(ByVal msgText As String) As Boolean
      ' Display the message.
      Dim answer As MsgBoxResult = _
         MsgBox(msgText, MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
      ' Return True if the user answers yes.
      Return (answer = MsgBoxResult.Yes)
   End Function

   Public MsgText As String
   Public MsgTitle As String

   ' Display a message box, and return True if the user selects Yes.
   Function YesOrNo(ByVal DefaultAnswer As Boolean) As Boolean
      ' This is a yes/no question.
      Dim style As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Question
      ' Select the default button for this message box.
      If DefaultAnswer Then
         style = style Or MsgBoxStyle.DefaultButton1      ' Yes button
      Else
         style = style Or MsgBoxStyle.DefaultButton2      ' No button
      End If
      ' Display the message box, and return True if the user replies Yes.
      Return (MsgBox(MsgText, style, MsgTitle) = MsgBoxResult.Yes)
   End Function

End Class
