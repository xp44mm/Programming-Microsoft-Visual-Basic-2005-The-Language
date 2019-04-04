Public Class Employee2
   Inherits Person2

   Sub New(ByVal firstName As String, ByVal lastName As String)
      ' The first statement *must* be a call to the constructor in the base class.
      MyBase.New(firstName, lastName)
      ' You can continue with the initialization step here.
      '… 
   End Sub
End Class
