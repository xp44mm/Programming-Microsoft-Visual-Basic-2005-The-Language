Imports System.Reflection
Imports System.Text.RegularExpressions

' ---------------------------------------------------
'  WARNING: this version of the EventInterceptor class doesn't support
'  removal of object sources. Once an event source has been added, a
'  number of EventInterceptorHandler instances are created and will
'  be destroyed only when the form will be unloaded.
'
'  Search the www.dotnet2themax.com site for a more complete and
'  powerful version that solves this issue.
' ---------------------------------------------------

Public Class EventInterceptor
   ' the public event
   Public Event ObjectEvent As ObjectEventHandler

   ' This is invoked from inside the EventInterceptorHandler auxiliary class.
   Protected Sub OnObjectEvent(ByVal e As ObjectEventArgs)
      RaiseEvent ObjectEvent(Me, e)
   End Sub

   Public Sub AddEventSource(ByVal eventSource As Object, ByVal includeChildren As Boolean, ByVal filterPattern As String)
      For Each ei As EventInfo In eventSource.GetType().GetEvents()
         ' Skip this event if its name doesn't match the pattern.
         If Not String.IsNullOrEmpty(filterPattern) AndAlso Not Regex.IsMatch(ei.Name, "^" & filterPattern & "$") Then Continue For

         ' Get the signature of the underlying delegate.
         Dim mi As MethodInfo = ei.EventHandlerType.GetMethod("Invoke")
         Dim pars() As ParameterInfo = mi.GetParameters()
         ' Check that event signature is in the form (sender, e).
         If mi.ReturnType.FullName = "System.Void" AndAlso pars.Length = 2 AndAlso pars(0).ParameterType Is GetType(Object) AndAlso GetType(EventArgs).IsAssignableFrom(pars(1).ParameterType) Then
            ' Create a EventInterceptorHandler that handles this event.
            Dim interceptor As New EventInterceptorHandler(eventSource, ei, Me)
         End If
      Next
      ' Recurse on child controls if so required.
      If TypeOf eventSource Is Control AndAlso includeChildren Then
         For Each ctrl As Control In DirectCast(eventSource, Control).Controls
            AddEventSource(ctrl, includeChildren, filterPattern)
         Next
      End If
   End Sub


   ' EventInterceptorHandler auxiliary class (private)

   Private Class EventInterceptorHandler
      ' The event being intercepted
      Public ReadOnly EventInfo As EventInfo
      ' The parent EventInterceptor
      Public ReadOnly Parent As EventInterceptor

      Public Sub New(ByVal eventSource As Object, ByVal eventInfo As EventInfo, ByVal parent As EventInterceptor)
         Me.EventInfo = eventInfo
         Me.Parent = parent
         ' Create a delegate that points to the EventHandler method.
         Dim method As MethodInfo = Me.GetType().GetMethod("EventHandler")
         Dim handler As [Delegate] = [Delegate].CreateDelegate(eventInfo.EventHandlerType, Me, method)
         ' Register the event.
         eventInfo.AddEventHandler(eventSource, handler)
      End Sub

      Public Sub EventHandler(ByVal sender As Object, ByVal e As EventArgs)
         ' Notify the parent EventInterceptor object.
         Dim objEv As New ObjectEventArgs(sender, EventInfo.Name, e)
         Parent.OnObjectEvent(objEv)
      End Sub
   End Class

End Class

Public Delegate Sub ObjectEventHandler(ByVal sender As Object, ByVal e As ObjectEventArgs)

Public Class ObjectEventArgs
   Inherits EventArgs

   Public ReadOnly EventSource As Object
   Public ReadOnly EventName As String
   Public ReadOnly Arguments As EventArgs

   Sub New(ByVal eventSource As Object, ByVal eventName As String, ByVal arguments As EventArgs)
      Me.EventSource = eventSource
      Me.EventName = eventName
      Me.Arguments = arguments
   End Sub
End Class
