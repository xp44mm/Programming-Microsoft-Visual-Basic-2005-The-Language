<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Struct, Inherited:=True)> _
Public Class DataObjectAttribute
   Inherits Attribute
   Implements IComparable(Of DataObjectAttribute)

   Public Sub New(ByVal configuration As String, ByVal table As String)
      m_Configuration = configuration
      m_Table = table
   End Sub

   ' The configuration in which the data object is valid

   Private m_Configuration As String

   Public ReadOnly Property Configuration() As String
      Get
         Return m_Configuration
      End Get
   End Property

   ' The database table this data object applies to

   Private m_Table As String

   Public ReadOnly Property Table() As String
      Get
         Return m_Table
      End Get
   End Property

   ' Support for the IComparable(Of DataObjectAttribute) interface

   Public Function CompareTo(ByVal other As DataObjectAttribute) As Integer Implements System.IComparable(Of DataObjectAttribute).CompareTo
      Dim res As Integer = Me.Configuration.CompareTo(other.Configuration)
      If res = 0 Then res = Me.Table.CompareTo(other.Table)
      Return res
   End Function
End Class
