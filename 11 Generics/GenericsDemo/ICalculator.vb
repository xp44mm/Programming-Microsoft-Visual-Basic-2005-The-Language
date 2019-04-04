Public Interface ICalculator(Of T)
   Function Add(ByVal n1 As T, ByVal n2 As T) As T
   Function Subtract(ByVal n1 As T, ByVal n2 As T) As T
   Function Multiply(ByVal n1 As T, ByVal n2 As T) As T
   Function Divide(ByVal n1 As T, ByVal n2 As T) As T
   Function ConvertTo(ByVal n As Object) As T
End Interface
