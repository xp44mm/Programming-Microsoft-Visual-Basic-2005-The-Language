<AttributeUsage(AttributeTargets.Class)> _
Public Class FormExtenderAttribute
   Inherits Attribute

   ' Constructors

   Public Sub New(ByVal formName As String)
      Me.New(formName, False)
   End Sub

   Public Sub New(ByVal formName As String, ByVal Replace As Boolean)
      m_FormName = formName
      m_Replace = Replace
   End Sub

   ' The FormName property (readonly)

   Private m_FormName As String

   Public ReadOnly Property FormName() As String
      Get
         Return m_FormName
      End Get
   End Property

   ' The Replace property (readonly)

   Private m_Replace As Boolean

   Public ReadOnly Property Replace() As Boolean
      Get
         Return m_Replace
      End Get
   End Property

   ' The IncludeInherited property

   Private m_IncludeInherited As Boolean

   Property IncludeInherited() As Boolean
      Get
         Return m_IncludeInherited
      End Get
      Set(ByVal Value As Boolean)
         m_IncludeInherited = Value
      End Set
   End Property

End Class
