' The Widget class demonstrates the IDisposable interface.
' and performance of Overridable and NotOverridable methods.

' This class is visible from outside the assembly but can't
' be used as a base class for classes outside the assembly.

Public Class Widget
   Implements IDisposable

   Function GetInteger() As Integer
      Return 1
   End Function

   Overridable Function GetInteger2() As Integer
      Return 1
   End Function

   Sub Dispose() Implements IDisposable.Dispose
      ' Close files and release other resources here.
      ' ...
   End Sub

   ' This constructor can be called only from inside the current assembly.
   Friend Sub New()
      '…
   End Sub

   ' A pseudoconstructor method for clients located outside the current assembly.
   Public Shared Function CreateWidget() As Widget
      Return New Widget()
   End Function

End Class
