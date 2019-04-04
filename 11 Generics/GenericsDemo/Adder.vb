Interface IAdder(Of T)
   Function Add(ByVal n1 As T, ByVal n2 As T) As T
End Interface

Class Adder
   Implements IAdder(Of Integer), IAdder(Of Double)

   Public Function Add(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
         Implements IAdder(Of Integer).Add
      Return n1 + n2
   End Function

   Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
         Implements IAdder(Of Double).Add
      Return n1 + n2
   End Function
End Class
