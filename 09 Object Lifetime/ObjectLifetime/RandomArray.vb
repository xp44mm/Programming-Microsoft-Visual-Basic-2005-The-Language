Public Class RandomArray
   Implements IDisposable

   ' This array stores the elements.
   Public ReadOnly Values() As Double

   ' The constructor creates the random array.
   Private Sub New(ByVal length As Integer)
      ReDim Values(length - 1)
      Dim rand As New Random()

      ' This is a time-consuming operation.
      For i As Integer = 0 To length - 1
         Values(i) = rand.NextDouble()
      Next
   End Sub

   ' Dispose and Finalize methods

   Public Sub Dispose() Implements IDisposable.Dispose
      ' Return this object to the pool.
      Debug.WriteLine("Returning a RandomArray object with " & Values.Length.ToString & " elements to the pool")
      Pool.Add(Me)
      GC.SuppressFinalize(Me)
   End Sub

   Protected Overrides Sub Finalize()
      Dispose()
   End Sub

   ' Static members

   ' The pool of objects
   Private Shared Pool As New ArrayList()

   ' The factory method
   Public Shared Function Create(ByVal length As Integer) As RandomArray
      ' Check whether there is an element in the pool with the
      ' requested number of elements.
      For i As Integer = 0 To Pool.Count - 1
         Dim ra As RandomArray = DirectCast(Pool(i), RandomArray)
         If ra.Values.Length = length Then
            ' Remove the element from the pool.
            Pool.RemoveAt(i)
            ' Re-register for finalization, in case no Dispose method is invoked.
            GC.ReRegisterForFinalize(ra)
            Debug.WriteLine("Taking a RandomArray object with " & length.ToString & " elements from the pool")
            Return ra
         End If
      Next
      ' If no suitable element in the pool, create a new element.
      Debug.WriteLine("Creating a new RandomArray object with " & length.ToString & " elements")
      Return New RandomArray(length)
   End Function
End Class

