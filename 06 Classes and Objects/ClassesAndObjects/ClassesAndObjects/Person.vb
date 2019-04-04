Public Class Person
   ' Fields visible from outside the class
   Public FirstName As String
   Public LastName As String

   ' Fields that can be used only from inside the class
   Dim m_LoginDate As Date
   Private EmailUserName As String
   Private EmailEnabled As Boolean = True     ' Field initializer

   Private CreateTime As Date

   Public Citizenship As String = "American"

   Public Sub New()
      ' Display a diagnostic message.
      Console.WriteLine("A new instance of Person is being created.")
      ' Remember when this instance was created.
      CreateTime = Now
      ' Perform other initialization chores.

   End Sub



   Function CompleteName(Optional ByVal title As String = "") As String
      CompleteName = ""
      ' Use the title if provided.
      If title <> "" Then CompleteName = title & " "
      ' Append first and last name.
      CompleteName &= FirstName & " " & LastName
   End Function

   ' You can define variables anywhere in a class or module.
   Dim m_BirthDate As Date

   Public Property BirthDate() As Date
      Get
         Return m_BirthDate
      End Get
      Set(ByVal value As Date)
         m_BirthDate = value
      End Set
   End Property

   ' An object property
   Private m_Spouse As Person

   Public Property Spouse() As Person
      Get
         Return m_Spouse
      End Get
      Set(ByVal Value As Person)
         m_Spouse = Value
      End Set
   End Property

   ' The Age property is read-only.
   Public ReadOnly Property Age() As Integer
      Get
         Return Year(Now) - Year(m_BirthDate)    ' Simplistic age calculation
      End Get
   End Property

   ' LoginDate is a write-only property.
   Public WriteOnly Property LoginDate() As Date
      Set(ByVal Value As Date)
         m_LoginDate = Value
      End Set
   End Property

   ' The ArrayList type exposes methods such as Add, Remove, etc.
   Private m_Notes As ArrayList

   Public ReadOnly Property Notes() As ArrayList
      Get
         ' Create the ArrayList at the first request.
         If m_Notes Is Nothing Then m_Notes = New ArrayList
         Return m_Notes
      End Get
   End Property

   Public ReadOnly Property HasNotes() As Boolean
      Get
         Return m_Notes IsNot Nothing AndAlso m_Notes.Count > 0
      End Get
   End Property

   Private m_ID As Integer

   Public Property ID() As Integer
      Get
         Return m_ID
      End Get
      Friend Set(ByVal value As Integer)
         If value <= 0 Then Throw New ArgumentException("Negative values are invalid")
         m_ID = value
      End Set
   End Property

   Private m_UserName As String

   Friend Property UserName() As String
      Get
         Return m_UserName
      End Get
      Private Set(ByVal value As String)
         If value = "" Then Throw New ArgumentException("Empty strings are invalid")
         m_UserName = value
      End Set
   End Property

   Dim m_Addresses(3) As String       ' Up to four distinct lines for address

   ' The Addresses property takes an Integer argument.
   Default Public Property Addresses(ByVal index As Integer) As String
      Get
         If index < 0 Or index > UBound(m_Addresses) Then
            Throw New IndexOutOfRangeException("Invalid address index.")
         End If
         Return m_Addresses(index)
      End Get
      Set(ByVal value As String)
         If index < 0 Or index > UBound(m_Addresses) Then
            Throw New IndexOutOfRangeException("Invalid address index.")
         End If
         m_Addresses(index) = value
      End Set
   End Property


End Class
