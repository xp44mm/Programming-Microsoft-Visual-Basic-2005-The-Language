Public Class Student
   Implements IDataRowPersistable

   ' These should be properties in a real-world class.
   Public FirstName As String
   Public LastName As String
   Public BirthDate As Date
   ' The primary key for this object is private.
   Private ID As Guid = Guid.Empty

   ' Two constructors
   Public Sub New(ByVal firstName As String, ByVal lastName As String, _
         ByVal birthDate As Date)
      Me.FirstName = firstName
      Me.LastName = lastName
      Me.BirthDate = birthDate
   End Sub

   Public Sub New()
   End Sub

   ' Return the primary key of this object.
   Public ReadOnly Property PrimaryKey() As Object _
         Implements IDataRowPersistable.PrimaryKey
      Get
         ' Generate the ID only when needed.
         If Me.ID.Equals(Guid.Empty) Then Me.ID = Guid.NewGuid()
         Return Me.ID
      End Get
   End Property

   Public Sub Load(ByVal row As DataRow) Implements IDataRowPersistable.Load
      Me.ID = CType(row("ID"), Guid)
      Me.FirstName = CStr(row("FirstName"))
      Me.LastName = CStr(row("LastName"))
      Me.BirthDate = CDate(row("BirthDate"))
   End Sub

   Public Sub Save(ByVal row As DataRow) Implements IDataRowPersistable.Save
      ' Save the ID only if the primary key field is null.
      If DBNull.Value.Equals(row("ID")) Then row("ID") = Me.ID
      row("FirstName") = Me.FirstName
      row("LastName") = Me.LastName
      row("BirthDate") = Me.BirthDate
   End Sub
End Class
