Public Class IntegerCollection
   Inherits CollectionBase

   Public Sub Add(ByVal item As Integer)
      Me.List.Add(item)
   End Sub

   Public Sub Remove(ByVal item As Integer)
      Me.List.Remove(item)
   End Sub

   Public Property Item(ByVal index As Integer) As Integer
      Get
         Return CType(Me.List(index), Integer)
      End Get
      Set(ByVal Value As Integer)
         Me.List(index) = Value
      End Set
   End Property
End Class

