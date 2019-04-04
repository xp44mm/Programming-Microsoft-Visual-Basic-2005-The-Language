Public Interface IPoolable
   Sub Initialize(ByVal ParamArray propertyValues() As Object)
   Function IsEqual(ByVal ParamArray propertyValues() As Object) As Boolean
End Interface

Public Class ObjectPoolEx(Of T As {New, IPoolable})
   Dim pool As New List(Of T)

   ' Create an object, taking it from the pool if possible.
   Function CreateObject(ByVal ParamArray propertyValues() As Object) As T
      For i As Integer = 0 To pool.Count - 1
         Dim item As T = pool(i)
         If item.IsEqual(propertyValues) Then
            ' We've found an object with the required properties.
            pool.RemoveAt(i)
            Return item
         End If
      Next
      ' Create and return a brand new object.
      Dim obj As New T
      obj.Initialize(propertyValues)
      Return obj
   End Function

   ' Return an object to the pool.
   Public Sub DestroyObject(ByVal item As T)
      pool.Add(item)
   End Sub
End Class
