<ComClass(Employee.ClassId, Employee.InterfaceId, Employee.EventsId)> _
Public Class Employee
   Public Event NameChanged As EventHandler

#Region "COM GUIDs"
   ' These  GUIDs provide the COM identity for this class 
   ' and its COM interfaces. If you change them, existing 
   ' clients will no longer be able to access the class.
   Public Const ClassId As String = "f1cdeea2-601b-479d-b1f4-ec9cc4905f04"
   Public Const InterfaceId As String = "452d1073-df75-443a-b3fb-a397628eb883"
   Public Const EventsId As String = "5d5ded49-1162-4f6c-93c8-74a010202072"
#End Region

   ' A creatable COM class must have a Public Sub New() 
   ' with no parameters, otherwise, the class will not be 
   ' registered in the COM registry and cannot be created 
   ' via CreateObject.
   Public Sub New()
      MyBase.New()
   End Sub

   Private m_FirstName As String

   Public Property FirstName() As String
      Get
         Return m_FirstName
      End Get
      Set(ByVal value As String)
         If m_FirstName = value Then Return
         m_FirstName = value
         RaiseEvent NameChanged(Me, EventArgs.Empty)
      End Set
   End Property

   Private m_LastName As String

   Public Property LastName() As String
      Get
         Return m_LastName
      End Get
      Set(ByVal value As String)
         If m_LastName = value Then Return
         m_LastName = value
         RaiseEvent NameChanged(Me, EventArgs.Empty)
      End Set
   End Property

   Public Function ReverseName() As String
      Return Me.LastName & ", " & Me.FirstName
   End Function

End Class


