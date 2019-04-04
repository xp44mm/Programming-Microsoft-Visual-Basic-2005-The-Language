Imports System.Runtime.Serialization
Imports System.Security.Permissions

Public Class PersonalData
   Public LastName As String
   Public FirstName As String
   Public Spouse As PersonalData
   Private m_BirthDate As Date             ' A private field

   Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthDate As Date)
      Me.FirstName = firstName
      Me.LastName = lastName
      Me.m_BirthDate = birthDate
   End Sub

   Public ReadOnly Property BirthDate() As Date
      Get
         Return m_BirthDate
      End Get
   End Property
End Class


<Serializable()> _
Public Class Employee
   Inherits PersonalData
   Implements ISerializable

   Public Boss As Employee
   Private m_BirthDate As Date             ' A private field

   Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthDate As Date)
      MyBase.New(firstName, lastName, birthDate)
      ' Save the birth date also in the private field at this hierarchy level.
      Me.m_BirthDate = birthDate
   End Sub

   <SecurityPermission(SecurityAction.Demand, SerializationFormatter:=True)> _
   Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) _
      Implements ISerializable.GetObjectData
      SerializeObjectFields(info, "", Me, Nothing)
   End Sub

   Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      ' Unfortunately, we *must* have a call to the base class's constructor.
      MyBase.New("anyfirstname", "anylastname", New Date())
      DeserializeObjectFields(info, "", Me, Nothing)
   End Sub
End Class
