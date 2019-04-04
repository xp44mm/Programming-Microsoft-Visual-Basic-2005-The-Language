Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual), _
 ComSourceInterfaces(GetType(Person_Events))> _
Public Class Person
   Public Event GotEmail(ByVal msg As String)
   Public Event TodayIsMyBirthday(ByVal age As Integer)

   Private m_FirstName As String

   Public Property FirstName() As String
      Get
         Return m_FirstName
      End Get
      Set(ByVal value As String)
         m_FirstName = value
      End Set
   End Property

   Private m_LastName As String

   Public Property LastName() As String
      Get
         Return m_LastName
      End Get
      Set(ByVal value As String)
         m_LastName = value
      End Set
   End Property

   Public Function ReverseName() As String
      Return Me.LastName & ", " & Me.FirstName
   End Function
End Class

<InterfaceType(ComInterfaceType.InterfaceIsIDispatch)> _
Public Interface Person_Events
   Sub GotEmail(ByVal msg As String)
   Sub TodayIsMyBirthday(ByVal age As Integer)
End Interface
