Public Class ReverseStringComparer
   Implements IComparer

   Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
      ' Just change the sign of the String.Compare result.
      Return -String.Compare(x.ToString, y.ToString)
   End Function
End Class

