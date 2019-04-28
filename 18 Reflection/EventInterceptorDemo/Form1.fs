open System.Text
open System.Reflection

type Form1() =

    Dim WithEvents Interceptor As new EventInterceptor

    member this.Form1_Load(sender : System.Object, e : System.EventArgs) Handles MyBase.Load =
        Interceptor.AddEventSource(Me, true, "")
    

    member this.Interceptor_ObjectEvent(sender : Object, e : ObjectEventArgs) Handles Interceptor.ObjectEvent =
        if e.EventSource = txtOutput && e.EventName = "TextChanged" then Return
        let sb = new StringBuilder
        let ctrl: Control = e.EventSource :?> Control
        sb.AppendFormat("{0}.{1}{2}", ctrl.Name, e.EventName, ControlChars.CrLf)

        // Show event arguments, if not a plain EventArgs object.
        if e.Arguments.GetType() <> typeof<EventArgs> then
            for pi: PropertyInfo in e.Arguments.GetType().GetProperties() do
                let value: Object = pi.GetValue(e.Arguments, null)
                sb.AppendFormat("   {0} = {1}{2}", pi.Name, value, ControlChars.CrLf)
            
        

        // Display in control; catch errors because txtOutput might have been disposed of.
        try
            txtOutput.AppendText(sb.ToString())
        Catch
        
    

    member this.btnClear_Click(sender : System.Object, e : System.EventArgs) Handles btnClear.Click =
        txtOutput.Clear()
    


