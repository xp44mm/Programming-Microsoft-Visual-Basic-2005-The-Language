Public Class ReverseIterator
   Implements IEnumerable

   Private al As New ArrayList()

   Public Sub New(ByVal ienum As IEnumerable)
      ' Read all the elements into the inner ArrayList.
      For Each o As Object In ienum
         al.Add(o)
      Next
      ' Reverse the element order.
      al.Reverse()
   End Sub

   ' Return the GetEnumerator of the inner ArrayList.
   Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      Return al.GetEnumerator()
   End Function
End Class
