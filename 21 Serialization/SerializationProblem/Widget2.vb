<Serializable()> _
Public Class Widget2
   <NonSerialized()> _
   Dim m_NameChangedHandler As EventHandler

   Public Custom Event NameChanged As EventHandler
      AddHandler(ByVal value As EventHandler)
         m_NameChangedHandler = DirectCast([Delegate].Combine(m_NameChangedHandler, value), EventHandler)
      End AddHandler

      RemoveHandler(ByVal value As EventHandler)
         m_NameChangedHandler = DirectCast([Delegate].Remove(m_NameChangedHandler, value), EventHandler)
      End RemoveHandler

      RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
         If m_NameChangedHandler IsNot Nothing Then
            m_NameChangedHandler(sender, e)
         End If
      End RaiseEvent
   End Event

End Class
