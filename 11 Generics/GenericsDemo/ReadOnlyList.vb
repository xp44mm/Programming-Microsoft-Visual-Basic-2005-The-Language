Public Class ReadOnlyList(Of T)
   Dim values() As T

   ' The constructor takes the maximum number of elements.
   Public Sub New(ByVal elementCount As Integer)
      ReDim values(elementCount - 1)
   End Sub

   ' The Count readonly property
   Private m_Count As Integer

   Public ReadOnly Property Count() As Integer
      Get
         Return m_Count
      End Get
   End Property

   ' Add a new element to the collection; error if too many elements.
   Public Sub Add(ByVal value As T)
      values(m_Count) = value
      m_Count += 1
   End Sub

   ' Return the N-th element; error if index is out of range.
   Default Public ReadOnly Property Item(ByVal index As Integer) As T
      Get
         If index < 0 OrElse index >= m_Count Then Throw New ArgumentException("Index out of range")
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
