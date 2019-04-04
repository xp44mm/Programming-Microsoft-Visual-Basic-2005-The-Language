Structure Employee
   Public FirstName As String
   Public LastName As String
   Public HireDate As Date

   Sub New(ByVal firstName As String, ByVal lastName As String, ByVal hireDate As Date)
      Me.FirstName = firstName
      Me.LastName = lastName
      Me.HireDate = hireDate
   End Sub

   ' A function to display an element's properties easily
   Function Description() As String
      Return String.Format("{0} {1} (hired on {2})", FirstName, LastName, _
         HireDate.ToShortDateString())
   End Function
End Structure
