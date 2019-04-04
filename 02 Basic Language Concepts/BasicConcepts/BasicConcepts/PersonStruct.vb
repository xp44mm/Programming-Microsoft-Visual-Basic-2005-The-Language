Public Structure PersonStruct
   Dim FirstName As String
   Dim LastName As String
   Public Address As String
   Private SSN As String

   Function CompleteName() As String
      Return FirstName & " " & LastName
   End Function

   ' A constructor for this structure
   Sub New(ByVal firstName As String, ByVal lastName As String)
      ' Note how you can use the Me keyword to reduce ambiguity.
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

End Structure
