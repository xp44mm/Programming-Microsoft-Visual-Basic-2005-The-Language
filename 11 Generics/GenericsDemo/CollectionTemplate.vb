Imports ItemType = System.Int32

Public Class CollectionTemplate
   Inherits CollectionBase

   Public Sub Add(ByVal item As ItemType)
      Me.List.Add(item)
   End Sub

   Public Sub Remove(ByVal item As ItemType)
      Me.List.Remove(item)
   End Sub

   Default Public Property Item(ByVal index As Integer) As ItemType
      Get
         Return CType(Me.List(index), ItemType)
      End Get
      Set(ByVal Value As ItemType)
         Me.List(index) = Value
      End Set
   End Property
End Class


