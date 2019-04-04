Imports System.ComponentModel

Public Class User
   ' Define the event.
   Public Event NameChanged(ByVal sender As Object, ByVal e As EventArgs)

   Public Event NameChanging As NameChangingEventHandler

   Private m_Name As String

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         If m_Name <> value Then
            ' Ask clients whether it's OK to assign the new value.
            Dim e As New NameChangingEventArgs(value)
            RaiseEvent NameChanging(Me, e)
            If e.Cancel Then Exit Property
            ' Proceed with assignment.
            m_Name = value
            ' Raise the NameChanged event (only if the property has actually changed).
            RaiseEvent NameChanged(Me, EventArgs.Empty)
         End If
      End Set
   End Property

   Public Event AfterLogin As EventHandler

   ' The private delegate variable
   Private m_BeforeLogin As CancelEventHandler

   ' The custom event
   Public Custom Event BeforeLogin As CancelEventHandler
      ' Add an event handler to the list of subscribers.
      AddHandler(ByVal value As CancelEventHandler)
         m_BeforeLogin = DirectCast([Delegate].Combine(m_BeforeLogin, value), CancelEventHandler)
      End AddHandler

      ' Remove an event handler from the list of subscribers.
      RemoveHandler(ByVal value As CancelEventHandler)
         m_BeforeLogin = DirectCast([Delegate].Remove(m_BeforeLogin, value), CancelEventHandler)
      End RemoveHandler

      ' Raise the events, but only if there are any subscribers.
      RaiseEvent(ByVal sender As Object, ByVal e As CancelEventArgs)
         If m_BeforeLogin IsNot Nothing Then
            For Each handler As CancelEventHandler In m_BeforeLogin.GetInvocationList()
               handler.Invoke(sender, e)
               If e.Cancel Then Exit For
            Next
         End If
      End RaiseEvent
   End Event

   Public Sub Login()
      ' Ask clients whether logging in is OK, but only if there is at least one subscriber.
      If m_BeforeLogin IsNot Nothing Then
         Dim e As New CancelEventArgs()
         RaiseEvent BeforeLogin(Me, e)
         If e.Cancel Then Exit Sub
      End If

      ' Perform the login here…

      ' Let clients know that the user has logged in.
      RaiseEvent AfterLogin(Me, EventArgs.Empty)
   End Sub

End Class

Public Class NameChangingEventArgs
   Inherits CancelEventArgs

   Public Sub New(ByVal proposedValue As String)
      m_ProposedValue = proposedValue
   End Sub

   Private m_ProposedValue As String

   Public ReadOnly Property ProposedValue() As String
      Get
         Return m_ProposedValue
      End Get
   End Property
End Class

' The delegate that defines the event
Public Delegate Sub NameChangingEventHandler(ByVal sender As Object, _
   ByVal e As NameChangingEventArgs)
