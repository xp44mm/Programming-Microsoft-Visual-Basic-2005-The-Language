open System.Reflection
open System.Text.RegularExpressions

// ---------------------------------------------------
'  WARNING: this version of the EventInterceptor class doesn// t support
// removal of object sources. Once an event source has been added, a
// number of EventInterceptorHandler instances are created and will
// be destroyed only when the form will be unloaded.
// 
// Search the www.dotnet2themax.com site for a more complete and
// powerful version that solves this issue.
// ---------------------------------------------------

type EventInterceptor() =

    // the public event
    Public Event ObjectEvent As ObjectEventHandler

    // This is invoked from inside the EventInterceptorHandler auxiliary class.
    Protected Sub OnObjectEvent(e : ObjectEventArgs)
        RaiseEvent ObjectEvent(Me, e)
    

    member this.AddEventSource(eventSource : Object, includeChildren : Boolean, filterPattern : String) =
        for ei: EventInfo in eventSource.GetType().GetEvents() do
            ' Skip this event if its name doesn// t match the pattern.
            if not <| String.IsNullOrEmpty(filterPattern) && not <| Regex.IsMatch(ei.Name, "^" + filterPattern + "$") then Continue For

            // Get the signature of the underlying delegate.
            let mi: MethodInfo = ei.EventHandlerType.GetMethod("Invoke")
            let pars: ParameterInfo[] = mi.GetParameters()
            // Check that event signature is in the form (sender, e).
            if mi.ReturnType.FullName = "System.Void" && pars.Length = 2 && pars(0).ParameterType = typeof<Object> && typeof<EventArgs>.IsAssignableFrom(pars(1).ParameterType) then
                // Create a EventInterceptorHandler that handles this event.
                let interceptor = new EventInterceptorHandler(eventSource, ei, Me)
            
        
        // Recurse on child controls if so required.
        if eventSource.GetType() = typeof<Control> && includeChildren then
            for ctrl: Control in eventSource :?> Control.Controls do
                AddEventSource(ctrl, includeChildren, filterPattern)
            
        
    

    // EventInterceptorHandler auxiliary class (private)

    type EventInterceptorHandler() =

        // The event being intercepted
        Public ReadOnly EventInfo As EventInfo

        // The parent EventInterceptor
        Public ReadOnly Parent As EventInterceptor

        member this.new(eventSource : Object, eventInfo : EventInfo, parent : EventInterceptor) =
            Me.EventInfo = eventInfo
            Me.Parent = parent
            // Create a delegate that points to the EventHandler method.
            let method: MethodInfo = Me.GetType().GetMethod("EventHandler")
            let handler: Delegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, Me, method)
            // Register the event.
            eventInfo.AddEventHandler(eventSource, handler)
        

        member this.EventHandler(sender : Object, e : EventArgs) =
            // Notify the parent EventInterceptor object.
            let objEv = new ObjectEventArgs(sender, EventInfo.Name, e)
            Parent.OnObjectEvent(objEv)
        

    



Public Delegate Sub ObjectEventHandler(sender : Object, e : ObjectEventArgs)

type ObjectEventArgs() =
    Inherits EventArgs

    Public ReadOnly EventSource As Object
    Public ReadOnly EventName As String
    Public ReadOnly Arguments As EventArgs

    member this.new(eventSource : Object, eventName : String, arguments : EventArgs) =
        Me.EventSource = eventSource
        Me.EventName = eventName
        Me.Arguments = arguments
    


