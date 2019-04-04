Class Square
   Dim side As Double

   Sub New(ByVal side As Double)
      If side <= 0 Then
         Throw New ArgumentException("Negative value for side")
      End If
      Me.side = side
   End Sub

   Function GetPerimeter() As Double
      Return side * 4
   End Function
End Class
