Public Class Person
   ' Fields visible from outside the class
   Public FirstName As String
   Public LastName As String

   Public Overridable Function CompleteName() As String
      Return FirstName & " " & LastName
   End Function

End Class
