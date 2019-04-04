Public Class Triangle
   Dim a, b, c As Double

   Public Sub New(ByVal sideA As Double, ByVal sideB As Double, ByVal sideC As Double)
      a = sideA : b = sideB : c = sideC
      ' Check that such a triangle can actually be built.
      If a < Math.Abs(b - c) OrElse b < Math.Abs(a - c) OrElse c < Math.Abs(a - c) Then
         Throw New ArgumentException("Invalid triangle")
      End If
   End Sub

   Public Function GetPerimeter() As Double
      Return a + b + c
   End Function

   Public Function GetArea() As Double
      ' Use Heron’s formula to calculate the area.
      Dim halfP As Double = (a + b + c) / 2
      Return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c))
   End Function

   Public Shared Function GetPerimeter(ByVal a As Double, ByVal b As Double, _
      ByVal c As Double) As Double
      Return a + b + c
   End Function

   Public Shared Function GetArea(ByVal a As Double, ByVal b As Double, _
         ByVal c As Double) As Double
      Dim halfP As Double = (a + b + c) / 2
      Return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c))
   End Function

End Class
