Public Class PersonComparer
   Implements IComparer(Of Person)

   Public Function Compare(ByVal x As Person, ByVal y As Person) As Integer _
         Implements IComparer(Of Person).Compare
      Return x.ReverseName.CompareTo(y.ReverseName)
   End Function
End Class
