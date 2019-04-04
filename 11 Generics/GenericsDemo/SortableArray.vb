Public Class SortableArray(Of T, C As {New, IComparer(Of T)})
   Dim values() As T

   Public Sub New(ByVal highestIndex As Integer)
      ReDim values(highestIndex)
   End Sub

   Public Sub Sort()
      ' Sort the array using the specified comparer object.
      Array.Sort(values, New C)
   End Sub

   Default Public Property Item(ByVal index As Integer) As T
      Get
         Return values(index)
      End Get
      Set(ByVal value As T)
         values(index) = value
      End Set
   End Property
End Class

' a sample comparer

Public Class ReverseIntegerComparer
   Implements IComparer(Of Integer)

   Public Function Compare(ByVal x As Integer, ByVal y As Integer) As Integer _
          Implements IComparer(Of Integer).Compare
      ' Return -1 if x>y, +1 if x<y, 0 if x=y.
      Return Math.Sign(y - x)
   End Function
End Class

