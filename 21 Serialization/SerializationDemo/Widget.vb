<Serializable()> _
Public Class Widget
   Public Event NameChanged As EventHandler

   Private m_Name As String

   Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         If m_Name <> value Then
            m_Name = value
            RaiseEvent NameChanged(Me, EventArgs.Empty)
         End If
      End Set
   End Property
End Class

