Enum Gender
   NotSpecified
   Male
   Female
End Enum

Class Person3
   ' (In a real-world class, these would be properties.)
   Public FirstName As String
   Public LastName As String
   Public Gender As Gender = Gender.NotSpecified
   ' ...(other members omitted for brevity) ...

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   Dim m_Title As String
   Overridable Property Title() As String
      Get
         Return m_Title
      End Get
      Set(ByVal Value As String)
         m_Title = Value
      End Set
   End Property

   ' Prefix the name with a title if one has been specified.
   Function TitledName() As String
      If Title <> "" Then
         Return Title & " " & FirstName & " " & LastName
      Else
         Return FirstName & " " & LastName
      End If
   End Function

   Public BirthDate As Date

   ' Age is defined as the number of whole years passed from BirthDate.
   Overridable ReadOnly Property Age() As Integer
      Get
         Age = Now.Year - BirthDate.Year
         If Now.DayOfYear < BirthDate.DayOfYear Then Age -= 1
      End Get
   End Property

   ReadOnly Property CanVote() As Boolean
      Get
         ' Uncomment next statement to fix the problem
         ' Return MyClass.Age >= 18
         Return (Age >= 18)
      End Get
   End Property

   Dim m_Address As String

   Property Address() As String
      Get
         Return m_Address
      End Get
      Set(ByVal Value As String)
         m_Address = Value
      End Set
   End Property

   Public Father As Person
   Public Mother As Person

   Public Shared Function AreBrothers(ByVal p1 As Person3, ByVal p2 As Person3) As Boolean
      Return (p1.Father Is p2.Father) Or (p1.Mother Is p2.Mother)
   End Function

End Class
