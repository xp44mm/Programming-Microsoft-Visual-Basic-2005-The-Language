Public Class FloatingPointKeyComparer
   Implements IEqualityComparer

   Dim digits As Integer

   Sub New(ByVal digits As Integer)
      Me.digits = digits
   End Sub

   Public Shadows Function Equals(ByVal x As Object, ByVal y As Object) As Boolean _
         Implements IEqualityComparer.Equals
      Dim d1 As Double = Math.Round(CDbl(x), digits)
      Dim d2 As Double = Math.Round(CDbl(y), digits)
      Return d1 = d2
   End Function

   Public Shadows Function GetHashCode(ByVal obj As Object) As Integer _
         Implements IEqualityComparer.GetHashCode
      Dim d As Double = Math.Round(CDbl(obj), digits)
      Return d.GetHashCode()
   End Function
End Class
