Module Functions
   Function PadCenter(ByVal s As String, ByVal width As Integer, _
         Optional ByVal padChar As Char = " "c, _
         Optional ByVal truncate As Boolean = False) As String
      Dim diff As Integer = width - s.Length
      If diff = 0 OrElse (diff < 0 AndAlso Not truncate) Then
         ' Return the string as is.
         Return s
      ElseIf diff < 0 Then
         ' Truncate the string.
         Return s.Substring(0, width)
      Else
         ' Half of the extra chars go to the left, the remaining ones go to the right.
         Return s.PadLeft(width - diff \ 2, padChar).PadRight(width, padChar)
      End If
   End Function

   Function StringReverse(ByVal s As String, Optional ByVal startIndex As Integer = 0, _
      Optional ByVal count As Integer = -1) As String
      Dim chars() As Char = s.ToCharArray()
      If count < 0 Then count = s.Length - startIndex
      Array.Reverse(chars, startIndex, count)
      Return New String(chars)
   End Function

   Function StringDuplicate(ByVal s As String, ByVal count As Integer) As String
      ' Prepare a character array of given length.
      Dim chars(s.Length * count - 1) As Char
      ' Copy the string into the array multiple times.
      For i As Integer = 0 To count - 1
         s.CopyTo(0, chars, i * s.Length, s.Length)
      Next
      Return New String(chars)
   End Function

   Function CountSubstrings(ByVal source As String, ByVal search As String) As Integer
      Dim count As Integer = -1
      Dim index As Integer = -1
      Do
         count += 1
         index = source.IndexOf(search, index + 1)
      Loop Until index < 0
      Return count
   End Function

   ' Return the whole number of years between two dates.
   Function YearDiff(ByVal startDate As Date, ByVal endDate As Date) As Integer
      Dim result As Integer = endDate.Year - startDate.Year
      If endDate.Month < startDate.Month OrElse (endDate.Month = startDate.Month _
         AndAlso endDate.Day < startDate.Day) Then result -= 1
      Return result
   End Function

   ' Return the whole number of months between two dates.
   Function MonthDiff(ByVal startDate As Date, ByVal endDate As Date) As Integer
      Dim result As Integer = endDate.Year * 12 + endDate.Month - _
         (startDate.Year * 12 + startDate.Month)
      If endDate.Month = startDate.Month AndAlso endDate.Day < startDate.Day Then result -= 1
      Return result
   End Function


End Module
