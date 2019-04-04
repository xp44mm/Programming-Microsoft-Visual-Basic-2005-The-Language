Public Class Relation(Of T1, T2)
   Public ReadOnly Object1 As T1
   Public ReadOnly Object2 As T2

   Public Sub New(ByVal obj1 As T1, ByVal obj2 As T2)
      Me.Object1 = obj1
      Me.Object2 = obj2
   End Sub
End Class

' a new version that uses the As Class constraint

Public Class Relation2(Of T1 As Class, T2 As Class)
   Public ReadOnly Object1 As T1
   Public ReadOnly Object2 As T2

   Public Sub New(ByVal obj1 As T1, ByVal obj2 As T2)
      Me.Object1 = obj1
      Me.Object2 = obj2
   End Sub

   Public Function Contains(ByVal obj As Object) As Boolean
      Return Me.Object1 Is obj OrElse Me.Object2 Is obj

   End Function

End Class

' A new version that shows a minor issue with the VB compiler

Public Class Relation3(Of T1 As Class, T2 As Class)
   Public ReadOnly Object1 As T1
   Public ReadOnly Object2 As T2

   Public Sub New(ByVal obj1 As T1, ByVal obj2 As T2)
      Me.Object1 = obj1
      Me.Object2 = obj2
   End Sub

   Public Function Contains(ByVal obj As T1) As Boolean
      Return Me.Object1 Is obj
   End Function
   Public Function Contains(ByVal obj As T2) As Boolean
      Return Me.Object1 Is obj
   End Function

End Class


