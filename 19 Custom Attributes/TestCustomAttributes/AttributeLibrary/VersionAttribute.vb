' The AttributeTargets.All value means that this attribute
' can be used with any program entity.
<AttributeUsage(AttributeTargets.All)> _
Public Class VersionAttribute
   ' All attribute classes inherit from System.Attribute.
   Inherits System.Attribute

   ' The Attribute constructor takes two required values.
   Sub New(ByVal author As String, ByVal version As Single)
      m_Author = author
      m_Version = version
   End Sub

   ' Private fields
   Private m_Author As String
   Private m_Version As Single
   Private m_Tested As Boolean

   Public ReadOnly Property Author() As String
      Get
         Return m_Author
      End Get
   End Property

   Public ReadOnly Property Version() As Single
      Get
         Return m_Version
      End Get
   End Property

   Public Property Tested() As Boolean
      Get
         Return m_Tested
      End Get
      Set(ByVal Value As Boolean)
         m_Tested = Value
      End Set
   End Property
End Class
