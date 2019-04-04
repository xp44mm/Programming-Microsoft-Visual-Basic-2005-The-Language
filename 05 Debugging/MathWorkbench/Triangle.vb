Public Class Triangle
   Dim a, b, c As Double

   Public Sub New(ByVal sideA As Double, ByVal sideB As Double, ByVal sideC As Double)
      a = sideA : b = sideB : c = sideC
      ' Check that such a triangle can be actually built.
      If a < Math.Abs(b - c) OrElse b < Math.Abs(a - c) OrElse c < Math.Abs(a - c) Then
         Throw New ArgumentException("Invalid triangle")
      End If
   End Sub

   Public Function GetPerimeter() As Double
      Return a + b + c
   End Function

   Public Function GetArea() As Double
      ' Use the Heron formula to calculate the area.
      ' WARNING: the following statement contains a typo! 
      '          (Both asterisks should be replaced with a plus sign.)
      'Dim halfP As Double = (a * b * c) / 2
      Dim halfP As Double = (a + b + c) / 2
      Return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c))
   End Function
End Class
