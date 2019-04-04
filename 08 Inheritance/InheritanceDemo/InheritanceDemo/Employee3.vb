Class Employee3
   Inherits Person3

   Sub New(ByVal firstName As String, ByVal lastName As String)
      ' The first statement *must* be a call to the constructor in the base class.
      MyBase.New(firstName, lastName)
      ' You can continue with the initialization step here.
      '… 
   End Sub

   ' Override Title to provide a title if no one has been assigned.
   Overrides Property Title() As String
      Get
         If MyBase.Title <> "" Then
            Return MyBase.Title
         ElseIf Gender = Gender.Male Then
            Return "Mr."
         ElseIf Gender = Gender.Female Then
            Return "Mrs."
         Else
            Return ""
         End If
      End Get
      Set(ByVal Value As String)
         MyBase.Title = Value
      End Set
   End Property

   ' Age is defined as difference between the current year and birth year.
   Overrides ReadOnly Property Age() As Integer
      Get
         Age = Now.Year - BirthDate.Year
      End Get
   End Property

   Shadows Property Address() As String
      Get
         Return MyBase.Address
      End Get
      Set(ByVal Value As String)
         If Value = "" Then Throw New ArgumentException()
         MyBase.Address = Value
      End Set
   End Property

   Public Shared Shadows Function AreBrothers(ByVal e1 As Employee3, _
      ByVal e2 As Employee3) As Boolean
      Return Person3.AreBrothers(e1, e2) And (e1.LastName = e2.LastName)
   End Function


End Class
