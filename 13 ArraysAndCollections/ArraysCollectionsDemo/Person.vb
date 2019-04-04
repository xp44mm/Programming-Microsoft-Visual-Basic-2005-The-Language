Public Class Person
   ' These should be properties in a real-world application.
   Public FirstName As String
   Public LastName As String
   Public Spouse As Person
   Public ReadOnly Children As New PersonCollection

   Public Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   Public Function ReverseName() As String
      Return LastName & ", " & FirstName
   End Function
End Class
