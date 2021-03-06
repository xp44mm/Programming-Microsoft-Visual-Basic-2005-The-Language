Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics

Public Module DemoMacros
   Sub CheckLocalVariables()
      ' Retrieve the value of a local variable and a property.
      ' (These statements fail if no members named X or Name are accessible
      ' from the method in the main program where the tracepoint is defined.)
      Dim X As Integer = DTE.Debugger.GetExpression("X").Value
      Dim Name As String = DTE.Debugger.GetExpression("Name").Value
      ' Use the retrieved values here.
      Dim msg As String = String.Format("X={0}, NAME={1}", X, Name)
      MsgBox(msg, MsgBoxStyle.Information, "Variables")

   End Sub

   ' Insert this code in a macro referenced by a tracepoint.
   Sub DumpMethodValues()
      Dim frame As EnvDTE.StackFrame = DTE.Debugger.CurrentStackFrame
      ' Display name of current method.
      Debug.WriteLine("Method: " & frame.FunctionName & " [returns" & frame.ReturnType & "]")
      ' Display values of arguments and local variables.
      For Each expr As EnvDTE.Expression In frame.Locals
         Debug.WriteLine("  " & expr.Name & " = " & expr.Value)
      Next
   End Sub

   Sub ClearLocalVariables()
      Dim frame As EnvDTE.StackFrame = DTE.Debugger.CurrentStackFrame
      For Each expr As EnvDTE.Expression In frame.Locals
         ' Check whether this local is an argument.
         Dim isArgument As Boolean = False
         For Each arg As Expression In frame.Arguments
            If arg.Name = expr.Name Then isArgument = True : Exit For
         Next
         ' If it is a local variable, reset it to its default value.
         If Not isArgument Then
            Select Case expr.Type
               Case "Integer", "Short", "Long", "Single", "Double", "Decimal"
                  expr.Value = 0
               Case "Char"
                  expr.Value = Chr(0)
               Case "Boolean"
                  expr.Value = False
               Case Else
                  ' Treat any other type as an object, but be prepared for exceptions.
                  Try
                     ' Assigning the Value property doesn't work in this case.
                     DTE.Debugger.ExecuteStatement(expr.Name & " = Nothing")
                  Catch ex As System.Exception
                     ' Ignore exceptions.
                  End Try
            End Select
         End If
      Next
   End Sub

   Sub StepIntoOrOut()
      Try
         Dim funcName As String = DTE.Debugger.CurrentStackFrame.FunctionName
         Do
            ' Single-step tracing
            DTE.Debugger.StepInto()
            ' Loop until execution leaves current function.
         Loop While DTE.Debugger.CurrentStackFrame.FunctionName = funcName
      Catch ex As Exception
      End Try
   End Sub

End Module

