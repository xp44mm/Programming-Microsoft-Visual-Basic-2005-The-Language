Module Helpers
   Sub ArrayDeleteElement(ByVal arr As Array, ByVal index As Integer)
      ' This method works only with 1-dimensional arrays.
      If arr.Rank <> 1 Then Throw New ArgumentException("Invalid rank")
      ' Shift elements from arr(index+1) to arr(index).
      Array.Copy(arr, index + 1, arr, index, UBound(arr) - index)
      ' Clear the last element.
      Array.Clear(arr, arr.Length - 1, 1)
   End Sub

   Sub ArrayInsertElement(ByVal arr As Array, ByVal index As Integer, _
      Optional ByVal newValue As Object = Nothing)
      ' This method works only with 1-dimensional arrays.
      If arr.Rank <> 1 Then Throw New ArgumentException("Invalid rank")
      ' Shift elements from arr(index) to arr(index+1) to make room.
      Array.Copy(arr, index, arr, index + 1, arr.Length - index - 1)
      ' Assign the element using the SetValue method.
      arr.SetValue(newValue, index)
   End Sub

   Sub ArrayDeleteElement(Of T)(ByVal arr() As T, ByVal index As Integer)
      Array.Copy(arr, index + 1, arr, index, UBound(arr) - Index)
      arr(index) = Nothing
   End Sub

   Sub ArrayInsertElement(Of T)(ByVal arr() As T, ByVal index As Integer, _
         ByVal newValue As T)
      Array.Copy(arr, index, arr, index + 1, arr.Length - index - 1)
      arr(index) = newValue
   End Sub

   Sub Resize(Of T)(ByRef arr(,) As T, ByVal rows As Integer, ByVal columns As Integer)
      If rows <= 0 OrElse columns <= 0 Then Throw New ArgumentException("Invalid new size")
      ' Create a temporary array with as many rows as required, but same number of columns.
      Dim tmpArr(rows - 1, arr.GetLength(1) - 1) As T
      ' Next statement copies the old array into the temporary one.
      Array.Copy(arr, tmpArr, Math.Min(arr.Length, tmpArr.Length))
      ' Add or remove columns as desired.
      ReDim Preserve tmpArr(rows - 1, columns - 1)
      ' Replace old array with the temporary one.
      arr = tmpArr
   End Sub

   Function ArrayListJoin(ByVal al1 As ArrayList, ByVal al2 As ArrayList) As ArrayList
      ' Note how we avoid time-consuming reallocations.
      Dim res As New ArrayList(al1.Count + al2.count)
      ' Append the items in the two ArrayList arguments.
      res.AddRange(al1)
      res.AddRange(al2)
      Return res
   End Function

   Public Function EvalRPN(ByVal expression As String) As Double
      Dim stack As New Stack(Of Double)
      ' Split the string expression in tokens.
      Dim operands() As String = expression.ToLower().Split(New Char() {" "c}, _
         StringSplitOptions.RemoveEmptyEntries)
      For Each op As String In operands
         Select Case op
            Case "+"
               stack.Push(stack.Pop() + stack.Pop())
            Case "-"
               stack.Push(-stack.Pop() + stack.Pop())
            Case "*"
               stack.Push(stack.Pop() * stack.Pop())
            Case "/"
               Dim tmp As Double = stack.Pop()
               stack.Push(stack.Pop() / tmp)
            Case "sqrt"
               stack.Push(Math.Sqrt(stack.Pop()))
            Case Else
               ' Assume this token is a number, throw if the parse operation fails.
               stack.Push(Double.Parse(op))
         End Select
      Next
      ' Throw if stack is unbalanced.
      If stack.Count <> 1 Then Throw New ArgumentException("Unbalanced expression")
      Return stack.Pop()
   End Function

End Module
