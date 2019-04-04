Public Class NumericCalculator
   Implements ICalculator(Of Integer)
   Implements ICalculator(Of Double)

   ' The ICalculator(Of Integer) interface
   Public Function AddInt32(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
         Implements ICalculator(Of Integer).Add
      Return n1 + n2
   End Function
   Public Function SubtractInt32(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
         Implements ICalculator(Of Integer).Subtract
      Return n1 - n2
   End Function
   Public Function MultiplyInt32(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
         Implements ICalculator(Of Integer).Multiply
      Return n1 * n2
   End Function
   Public Function DivideInt32(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
         Implements ICalculator(Of Integer).Divide
      Return n1 \ n2
   End Function
   Public Function ConvertToInt32(ByVal n As Object) As Integer _
         Implements ICalculator(Of Integer).ConvertTo
      Return CInt(n)
   End Function

   ' The ICalculator(Of Double) interface
   Public Function AddDouble(ByVal n1 As Double, ByVal n2 As Double) As Double _
         Implements ICalculator(Of Double).Add
      Return n1 + n2
   End Function
   Public Function SubtractDouble(ByVal n1 As Double, ByVal n2 As Double) As Double _
         Implements ICalculator(Of Double).Subtract
      Return n1 - n2
   End Function
   Public Function MultiplyDouble(ByVal n1 As Double, ByVal n2 As Double) As Double _
         Implements ICalculator(Of Double).Multiply
      Return n1 * n2
   End Function
   Public Function DivideDouble(ByVal n1 As Double, ByVal n2 As Double) As Double _
         Implements ICalculator(Of Double).Divide
      Return n1 / n2
   End Function
   Public Function ConvertToDouble(ByVal n As Object) As Double _
         Implements ICalculator(Of Double).ConvertTo
      Return CDbl(n)
   End Function
End Class
