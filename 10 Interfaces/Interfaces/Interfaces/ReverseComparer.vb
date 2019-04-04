Public Class ReverseComparer
   Implements IComparer

   Private icomp As IComparer

   Public Sub New(Optional ByVal icomp As IComparer = Nothing)
      Me.icomp = icomp
   End Sub

   Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
      If icomp IsNot Nothing Then
         ' Use the passed IComparer object if possible; notice arguments in reverse order.
         Return icomp.Compare(y, x)
      ElseIf x IsNot Nothing AndAlso TypeOf x Is IComparable Then
         ' Use x's IComparable interface, negate result to get the reverse effect.
         Return -DirectCast(x, IComparable).CompareTo(y)
      ElseIf y IsNot Nothing AndAlso TypeOf y Is IComparable Then
         ' Use y's IComparable interface. (No need to negate the result)
         Return DirectCast(y, IComparable).CompareTo(x)
      Else
         Throw New ArgumentException("Neither argument is IComparable")
      End If
   End Function
End Class
