<AttributeUsage(AttributeTargets.Method)> _
Public Class BenchmarkAttribute
   Inherits Attribute
   Implements IComparable(Of BenchmarkAttribute)

   Public Sub New(ByVal group As String)
      If group Is Nothing Then group = ""
      m_Group = group
   End Sub

   Private m_Group As String = ""
   Public ReadOnly Property Group() As String
      Get
         Return m_Group
      End Get
   End Property

   Private m_Name As String = ""
   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal Value As String)
         If Value Is Nothing Then Value = ""
         m_Name = Value
      End Set
   End Property

   Private m_NormalizationFactor As Double = 1
   Public Property NormalizationFactor() As Double
   	Get
   		Return m_NormalizationFactor
   	End Get
      Set(ByVal Value As Double)
         If Value <= 0 Then Value = 1
         m_NormalizationFactor = Value
      End Set
   End Property

   Public Function CompareTo(ByVal other As BenchmarkAttribute) As Integer Implements System.IComparable(Of BenchmarkAttribute).CompareTo
      Dim res As Integer = Me.Group.CompareTo(other.Group)
      If res = 0 Then res = Me.Name.CompareTo(other.Name)
      Return res
   End Function
End Class
