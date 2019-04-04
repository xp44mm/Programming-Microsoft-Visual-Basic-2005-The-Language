Public Class StatsList(Of T, C As {New, ICalculator(Of T)})
   Inherits List(Of T)

   ' The object used as a calculator
   Dim calc As New C

   ' Return the sum of all elements.
   Public Function Sum() As T
      Dim result As T
      For Each elem As T In Me
         result = calc.Add(result, elem)
      Next
      Return result
   End Function

   ' Return the average of all elements.
   Public Function Avg() As T
      Return calc.Divide(Me.Sum, calc.ConvertTo(Me.Count))
   End Function
End Class
