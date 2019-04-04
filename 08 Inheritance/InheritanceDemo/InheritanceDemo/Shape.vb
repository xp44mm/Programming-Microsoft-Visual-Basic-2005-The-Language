' An example of abstract class containing an abstract method

Public MustInherit Class Shape
   ' Position on the X-Y plane
   Public X, Y As Single

   ' Move the object on the X-Y plane.
   Public Sub Offset(ByVal deltaX As Single, ByVal deltaY As Single)
      X = X + deltaX
      Y = Y + deltaY
      ' Redraw the shape at the new position.
      Display()
   End Sub

   Public MustOverride Sub Display()
End Class

' A class that provides a concrete implementation of an abstract class

Public Class Square
   Inherits Shape

   Public Side As Single

   Public Overrides Sub Display()
      ' Add here the statements that draw the square.
      ' …
   End Sub
End Class

