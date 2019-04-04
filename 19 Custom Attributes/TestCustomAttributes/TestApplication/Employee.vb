Imports AttributeLibrary
Imports System.Xml.Serialization

Public Class Employee
   <CsvField(1, Quoted:=True)> _
   Public FirstName As String
   <CsvField(2, Quoted:=True)> _
   Public LastName As String
   <CsvField(3, Format:="dd/M/yyyy")> _
   Public BirthDate As Date

   Dim m_Salary As Decimal

   <CsvField(4, Format:="######.00")> _
   Public Property Salary() As Decimal
      Get
         Return m_Salary
      End Get
      Set(ByVal Value As Decimal)
         m_Salary = Value
      End Set
   End Property

   ' Constructors
   Sub New()
   End Sub

   Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthDate As Date, ByVal salary As Decimal)
      Me.FirstName = firstName
      Me.LastName = lastName
      Me.BirthDate = birthDate
      Me.Salary = salary
   End Sub

   Public Overrides Function ToString() As String
      Return String.Format("{0} {1} born on {2} (Salary={3})", _
         FirstName, LastName, BirthDate.ToShortDateString, Salary)
   End Function
End Class