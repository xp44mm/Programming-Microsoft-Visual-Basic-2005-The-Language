Public Class Matrix(Of T)
   Private values()() As T

   Sub New(ByVal rowMax As Integer, ByVal colMax As Integer)
      ReDim values(rowMax)
      For i As Integer = 0 To rowMax
         Dim row(colMax) As T
         values(i) = row
      Next
   End Sub

   Default Public Property Item(ByVal row As Integer, ByVal col As Integer) As T
      Get
         Return values(row)(col)
      End Get
      Set(ByVal value As T)
         values(row)(col) = value
      End Set
   End Property
End Class
