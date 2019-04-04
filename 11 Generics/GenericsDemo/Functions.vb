Module Functions

   Function IsDefaultValue(Of T)(ByVal value As T) As Boolean
      Dim defValue As T = Nothing
      Return Object.Equals(value, defValue)
   End Function

   ' Exchange two arguments passed by address.
   Sub Swap(Of T)(ByRef x As T, ByRef y As T)
      Dim tmp As T = x
      x = y
      y = tmp
   End Sub

   Function Max(Of T As IComparable)(ByVal ParamArray values() As T) As T
      Dim result As T = values(0)
      For i As Integer = 1 To UBound(values)
         If result.CompareTo(values(i)) < 0 Then result = values(i)
      Next
      Return result
   End Function

   Function MedianValue(Of T As IComparable(Of T))(ByVal list As List(Of T), _
      Optional ByVal position As Integer = -1) As T
      ' Provide a default value for second argument.
      If position < 0 Then position = list.Count \ 2

      ' If the list has just one element, we've found its median.
      Dim guess As T = list(0)
      If list.Count = 1 Then Return guess
      ' These list will contain values lower and higher than the current guess.
      Dim lowerList As New List(Of T)
      Dim higherList As New List(Of T)

      For i As Integer = 1 To list.Count - 1
         Dim value As T = list(i)
         If guess.CompareTo(value) <= 0 Then
            ' The value is higher than or equal to the current guess.
            higherList.Add(value)
         Else
            ' The value is lower than the current guess.
            lowerList.Add(value)
         End If
      Next

      If lowerList.Count > position Then
         ' The median value must be in the lower-than list.
         Return MedianValue(lowerList, position)
      ElseIf lowerList.Count < position Then
         ' The median value must be in the higher-than list.
         Return MedianValue(higherList, position - lowerList.Count - 1)
      Else
         ' The guess is correct.
         Return guess
      End If
   End Function

   Public Function CreateObject(Of T As New)() As T
      Return New T
   End Function

   Public Function CreateArray(Of T As New)(ByVal numEls As Integer) As T()
      Dim values(numEls - 1) As T
      For i As Integer = 0 To numEls - 1
         values(i) = New T
      Next
      Return values
   End Function



End Module
