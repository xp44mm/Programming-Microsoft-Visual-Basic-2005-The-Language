Imports System.Text.RegularExpressions

Module EvaluateModule
   Function Evaluate(ByVal expr As String) As Double
      ' A floating point number, with optional leading and trailing spaces
      Const num As String = "\s*[+-]?\d+\.?\d*\b\s*"
      ' A number inside a pair of parenthesis
      Const nump As String = "\s*\((?<nump>" & num & ")\)\s*"
      ' Math operations
      Const add As String = "(?<![*/^]\s*)(?<add1>" & num & ")\+(?<add2>" _
         & num & ")(?!\s*[*/^])"
      Const subt As String = "(?<![*/^]\s*)(?<sub1>" & num & ")\-(?<sub2>" _
         & num & ")(?!\s*[*/^])"
      Const mul As String = "(?<!\^\s*)(?<mul1>" & num & ")\*(?<mul2>" & num _
         & ")(?!\s*\^)"
      Const div As String = "(?<!\^\s*)(?<div1>" & num & ")\/(?<div2>" & num _
         & ")(?!\s*\^)"
      Const modu As String = "(?<!\^\s*)(?<mod1>" & num & ")\s+mod\s+(?<mod2>" _
         & num & ")(?!\s*\^)"
      Const pow As String = "(?<pow1>" & num & ")\^(?<pow2>" & num & ")"
      ' 1-operand and 2-operand functions
      Const fone As String = "(?<fone>(exp|log|log10|abs|sqr|sqrt|sin|cos|tan|asin|acos|atan))" _
         & "\s*\((?<fone1>" & num & ")\)"
      Const ftwo As String = "(?<ftwo>(min|max)\s*)\((?<ftwo1>" & num _
         & "),(?<ftwo2>" & num & ")\)"

      ' Put everything in a single regex.
      Const pattern As String = "(" & fone & "|" & ftwo & "|" & modu & "|" & pow & "|" _
         & div & "|" & mul & "|" & subt & "|" & add & "|" & nump & ")"
      Dim reEval As New Regex(pattern, RegexOptions.IgnoreCase)

      ' Ensure that +/- used for additions and subtractions don't precede immediately a number.
      expr = Regex.Replace(expr, "(?<=[0-9)]\s*)[+-](?=[0-9(])", "$0 ")

      Dim reNumber As New Regex("^" & num & "$")

      ' Loop until the expression is reduced to a number.
      Do Until reNumber.IsMatch(expr)
         ' Replace only the first subexpression that can be processed.
         Dim newExpr As String = reEval.Replace(expr, AddressOf PerformOperation, 1)
         ' If the expression hasn't been simplified, there must be a problem.
         If expr = newExpr Then Throw New ArgumentException("Invalid expression")
         ' Re-enter the loop with the new expression.
         expr = newExpr
      Loop
      ' Convert to a floating point number and return.
      Return Double.Parse(expr)
   End Function

   Private Function PerformOperation(ByVal m As Match) As String
      Dim result As Double
      If m.Groups("nump").Length > 0 Then
         Return m.Groups("nump").Value.Trim()
      ElseIf m.Groups("neg").Length > 0 Then
         Return "+"
      ElseIf m.Groups("add1").Length > 0 Then
         result = Double.Parse(m.Groups("add1").Value) + Double.Parse(m.Groups("add2").Value)
      ElseIf m.Groups("sub1").Length > 0 Then
         result = Double.Parse(m.Groups("sub1").Value) - Double.Parse(m.Groups("sub2").Value)
      ElseIf m.Groups("mul1").Length > 0 Then
         result = Double.Parse(m.Groups("mul1").Value) * Double.Parse(m.Groups("mul2").Value)
      ElseIf m.Groups("mod1").Length > 0 Then
         result = Math.IEEERemainder(Double.Parse(m.Groups("mod1").Value), Double.Parse(m.Groups("mod2").Value))
      ElseIf m.Groups("div1").Length > 0 Then
         result = Double.Parse(m.Groups("div1").Value) / Double.Parse(m.Groups("div2").Value)
      ElseIf m.Groups("pow1").Length > 0 Then
         result = Double.Parse(m.Groups("pow1").Value) ^ Double.Parse(m.Groups("pow2").Value)
      ElseIf m.Groups("fone").Length > 0 Then
         Dim operand As Double = Double.Parse(m.Groups("fone1").Value)
         Select Case m.Groups("fone").Value.ToLower()
            Case "exp" : result = Math.Exp(operand)
            Case "log" : result = Math.Log(operand)
            Case "log10" : result = Math.Log10(operand)
            Case "abs" : result = Math.Abs(operand)
            Case "sqrt" : result = Math.Sqrt(operand)
            Case "sin" : result = Math.Sin(operand)
            Case "cos" : result = Math.Cos(operand)
            Case "tan" : result = Math.Tan(operand)
            Case "asin" : result = Math.Asin(operand)
            Case "acos" : result = Math.Acos(operand)
            Case "atan" : result = Math.Atan(operand)
         End Select
      ElseIf m.Groups("ftwo").Length > 0 Then
         Dim operand1 As Double = Double.Parse(m.Groups("ftwo1").Value)
         Dim operand2 As Double = Double.Parse(m.Groups("ftwo2").Value)
         Select Case m.Groups("ftwo").Value.ToLower()
            Case "min" : result = Math.Min(operand1, operand2)
            Case "max" : result = Math.Max(operand1, operand2)
         End Select
      End If
      Return result.ToString()
   End Function

End Module
