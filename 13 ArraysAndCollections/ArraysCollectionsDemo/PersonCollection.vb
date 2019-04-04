Public Class PersonCollection
   Inherits CollectionBase

   Public Sub Add(ByVal item As Person)
      Me.List.Add(item)
   End Sub

   Public Sub Remove(ByVal item As Person)
      Me.List.Remove(item)
   End Sub

   Default Public Property Item(ByVal index As Integer) As Person
      Get
         Return DirectCast(Me.List(index), Person)
      End Get
      Set(ByVal Value As Person)
         Me.List(index) = Value
      End Set
   End Property

   Public Sub Sort()
      Me.InnerList.Sort()
   End Sub

   Protected Overrides Sub OnValidate(ByVal value As Object)
      If Not TypeOf value Is Person Then Throw New ArgumentException("Invalid item")
   End Sub


End Class
