Public Class Product

   Public Sub New(ByVal name As String)
      ' Call the other constructor, pass default value for second argument.
      Me.New(name, 0)
   End Sub

   Public Sub New(ByVal name As String, ByVal id As Integer)
      Me.Name = name
      Me.Id = id
   End Sub

   Private m_Name As String

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         m_Name = value
      End Set
   End Property

   Private m_ID As Integer

   Public Property ID() As Integer
      Get
         Return m_ID
      End Get
      Set(ByVal value As Integer)
         m_ID = value
      End Set
   End Property
End Class
