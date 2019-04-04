<AttributeUsage(AttributeTargets.Class, AllowMultiple:=True)> _
Public Class DataObjectCompanionAttribute
   Inherits Attribute

   Public Sub New(ByVal type As Type)
      m_TypeName = type.FullName
   End Sub

   Public Sub New(ByVal typeName As String)
      If typeName Is Nothing Then typeName = ""
      m_TypeName = typeName
   End Sub

   ' The type of the data object. Use "" for all data objects.

   Private m_TypeName As String

   Public ReadOnly Property TypeName() As String
      Get
         Return m_TypeName
      End Get
   End Property

End Class
