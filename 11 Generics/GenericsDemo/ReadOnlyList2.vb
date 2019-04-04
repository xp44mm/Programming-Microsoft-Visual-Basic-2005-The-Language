Public Class ReadOnlyList2(Of T)
   Dim values As List(Of T)

   ' The constructor can takes the maximum number of elements. (Default value is 16.)
   Public Sub New(Optional ByVal elementCount As Integer = 16)
      values = New List(Of T)(elementCount)
   End Sub

   ' The Count readonly property
   Public ReadOnly Property Count() As Integer
      Get
         Return values.Count
      End Get
   End Property

   ' Add a new element to the collection.
   Public Sub Add(ByVal value As T)
      values.Add(value)
   End Sub

   ' Return the N-th element; error if index is out of range.
   Default Public ReadOnly Property Item(ByVal index As Integer) As T
      Get
         Return values(index)
      End Get
   End Property

   Public Sub Reset()
      ' Reset all existing elements to the type's default value.
      For i As Integer = 0 To Me.Count - 1
         values(i) = Nothing
      Next
   End Sub


End Class
