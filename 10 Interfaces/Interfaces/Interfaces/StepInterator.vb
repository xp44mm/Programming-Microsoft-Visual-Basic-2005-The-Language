Public Class StepIterator
   Implements IEnumerable

   Private ienum As IEnumerator
   Private stepValue As Integer
   Private skipValue As Integer

   ' The constructor does nothing but remember values for later.
   Public Sub New(ByVal iEnumerable As IEnumerable, ByVal stepValue As Integer, _
         Optional ByVal skipValue As Integer = 0)
      Me.ienum = iEnumerable.GetEnumerator()
      Me.stepValue = stepValue
      Me.skipValue = skipValue
   End Sub

   ' Pass an instance of the inner enumerator.
   Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      Return New StepEnumerator(ienum, stepValue, skipValue)
   End Function

   ' The private enumerator object
   Private Class StepEnumerator
      Implements IEnumerator

      Private ienum As IEnumerator
      Private stepValue As Integer
      Private skipValue As Integer
      Private firstIteration As Boolean = True

      ' The constructor remembers values for later.
      Public Sub New(ByVal ienum As IEnumerator, ByVal stepValue As Integer, _
            ByVal skipValue As Integer)
         Me.ienum = ienum
         Me.stepValue = stepValue
         Me.skipValue = skipValue
      End Sub

      ' MoveNext method calls the method of the original object to skip desired
      ' number of elements at the first iteration and at subsequent iterations.
      Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
         If firstIteration Then
            firstIteration = False
            ' Note that you must call MoveNext at least once at the first iteration.
            For i As Integer = 1 To skipValue + 1
               If Not ienum.MoveNext Then Return False
            Next
         Else
            ' Skip the desired number of iterations.
            For i As Integer = 1 To stepValue
               If Not ienum.MoveNext Then Return False
            Next
         End If
         ' Tell the application that there is a current value.
         Return True
      End Function

      ' Current and Reset members delegate to the original IEnumerator object.
      Public ReadOnly Property Current() As Object Implements IEnumerator.Current
         Get
            Return ienum.Current
         End Get
      End Property

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
         ienum.Reset()
      End Sub
   End Class
End Class
