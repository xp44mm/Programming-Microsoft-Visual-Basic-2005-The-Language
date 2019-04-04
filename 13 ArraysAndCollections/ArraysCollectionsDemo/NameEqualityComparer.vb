Public Class NameEqualityComparer
   Implements IEqualityComparer(Of String)

   Public Shadows Function Equals(ByVal x As String, ByVal y As String) As Boolean _
         Implements IEqualityComparer(Of String).Equals
      Return String.Equals(NormalizedName(x), NormalizedName(y))
   End Function

   Public Shadows Function GetHashCode(ByVal obj As String) As Integer _
         Implements IEqualityComparer(Of String).GetHashCode
      Return NormalizedName(obj).GetHashCode()
   End Function

   ' Helper method that returns a person name in upper case and in the 
   ' (LastName,FirstName) format, without any spaces.
   Private Function NormalizedName(ByVal name As String) As String
      ' If there is a comma, assume that name is already in (last,first) format.
      If name.IndexOf(","c) < 0 Then
         ' Find first and last name.
         Dim separators() As Char = {" "c}
         Dim parts() As String = name.Split(separators, 2, _
            StringSplitOptions.RemoveEmptyEntries)
         ' Invert the two portions.
         name = parts(1) & "," & parts(0)
      End If
      ' Delete spaces, if any.
      If name.IndexOf(" "c) >= 0 Then name = name.Replace(" ", "")
      ' Convert to uppercase and return.
      Return name.ToUpper()
   End Function
End Class
