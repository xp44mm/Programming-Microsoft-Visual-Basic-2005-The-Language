Public Class Person

   Public FirstName As String
   Public LastName As String
   Public Spouse As Person

   Public Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   Overrides Function ToString() As String
      Return Me.FirstName & " " & Me.LastName
   End Function

End Class
