Imports System.ComponentModel

Public Class User2
   ' The collection of event handlers
   Private events As New EventHandlerList()

   Public Custom Event BeforeLogin As CancelEventHandler
      AddHandler(ByVal value As CancelEventHandler)
         events.AddHandler("BeforeLogin", value)
      End AddHandler
      RemoveHandler(ByVal value As CancelEventHandler)
         events.RemoveHandler("BeforeLogin", value)
      End RemoveHandler
      RaiseEvent(ByVal sender As Object, ByVal e As CancelEventArgs)
         ' Raise the event if any client has subscribed to it.
         Dim deleg As CancelEventHandler = TryCast(events("BeforeLogin"), CancelEventHandler)
         If deleg IsNot Nothing Then deleg.Invoke(sender, e)
      End RaiseEvent
   End Event

   Public Custom Event AfterLogin As EventHandler
      AddHandler(ByVal value As EventHandler)
         events.AddHandler("AfterLogin", value)
      End AddHandler
      RemoveHandler(ByVal value As EventHandler)
         events.RemoveHandler("AfterLogin", value)
      End RemoveHandler
      RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
         ' Raise the event if any client has subscribed to it.
         Dim deleg As EventHandler = TryCast(events("AfterLogin"), EventHandler)
         If deleg IsNot Nothing Then deleg.Invoke(sender, e)
      End RaiseEvent
   End Event



   Public Sub Login()
      ' Ask clients whether logging in is OK, but only if there is at least one subscriber.
      Dim e As New CancelEventArgs()
      RaiseEvent BeforeLogin(Me, e)
      If e.Cancel Then Exit Sub

      ' Perform the login here…

      ' Let clients know that the user has logged in.
      RaiseEvent AfterLogin(Me, EventArgs.Empty)
   End Sub
End Class
