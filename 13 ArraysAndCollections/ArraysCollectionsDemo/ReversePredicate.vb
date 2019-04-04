Public Class ReversePredicate(Of T)

   Dim predicate As Predicate(Of T)

   Public Sub New(ByVal predicate As Predicate(Of T))
      Me.predicate = predicate
   End Sub

   Public Function Reverse(ByVal obj As T) As Boolean
      Return Not predicate(obj)
   End Function

End Class
