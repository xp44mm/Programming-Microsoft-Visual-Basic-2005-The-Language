Public Class ObjectPool(Of T As New)
   Dim pool As New List(Of T)

   ' Create an object, taking it from the pool if possible.
   Function CreateObject() As T
      If pool.Count = 0 Then
         Return New T
      Else
         ' Return the first object in the pool.
         Dim item As T = pool(0)
         pool.RemoveAt(0)
         Return item
      End If
   End Function

   ' Return an object to the pool.
   Public Sub DestroyObject(ByVal item As T)
      pool.Add(item)
   End Sub
End Class
