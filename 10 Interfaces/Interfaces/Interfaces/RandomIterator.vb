Public Class RandomIterator
   Implements IEnumerable

   Private al As New ArrayList()

   Public Sub New(ByVal ienum As IEnumerable)
      ' Read all the elements into the inner ArrayList.
      For Each o As Object In ienum
         al.Add(o)
      Next
      ' Shuffle the ArrayList.
      Dim rand As New Random(CInt(DateTime.Now.Ticks And &H7FFFFFF))
      For i As Integer = al.Count - 1 To 1 Step -1
         ' Swap Ith element with an element whose index is in the range [0, i].
         Dim j As Integer = rand.Next(0, i)
         Dim tmp As Object = al(i)
         al(i) = al(j)
         al(j) = tmp
      Next
   End Sub

   ' Return the GetEnumerator of the inner ArrayList.
   Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      Return al.GetEnumerator()
   End Function
End Class
