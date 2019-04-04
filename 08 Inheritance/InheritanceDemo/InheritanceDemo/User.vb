Public Class User
   ' Define the event.
   Public Event NameChanged As EventHandler

   Private m_Name As String

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         If m_Name <> value Then
            m_Name = value
            ' Raise the event (only if the property has actually changed).
            OnNameChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   Protected Overridable Sub OnNameChanged(ByVal e As EventArgs)
      RaiseEvent NameChanged(Me, e)
   End Sub
End Class

Public Class PowerUser
   Inherits User

   Protected Overrides Sub OnNameChanged(ByVal e As EventArgs)
      ' Raise the event only if the new name is a nonempty string.
      If Me.Name <> "" Then MyBase.OnNameChanged(e)
   End Sub
End Class

