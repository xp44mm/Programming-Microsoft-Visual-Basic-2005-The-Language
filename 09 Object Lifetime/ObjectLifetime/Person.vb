Public Class Person

   ' Fields visible from outside the class
   Public FirstName As String
   Public LastName As String

   Public Overridable Function CompleteName() As String
      Return FirstName & " " & LastName
   End Function

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub
   ' ...(other properties and methods as in Person class) ...
   ' … 

   Protected Overrides Sub Finalize()
      If Environment.HasShutdownStarted Then
         Debug.WriteLine("Person2 object is being destroyed.(Application is shutting down.)")
      Else
         Console.WriteLine("Person2 object is being destroyed")
      End If
   End Sub

End Class
