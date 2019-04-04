Public Class Employee
   Inherits Person

   Public BirthDate As Date                ' A new field

   Function ReverseName() As String        ' A new method
      Return LastName & ", " & FirstName
   End Function

   Sub New(ByVal firstName As String, ByVal lastName As String)
      ' Delegate to the constructor in the Person class.
      MyBase.New(firstName, lastName)
   End Sub

End Class
