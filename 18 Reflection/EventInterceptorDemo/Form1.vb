Imports System.Text
Imports System.Reflection

Public Class Form1

    Dim WithEvents Interceptor As New EventInterceptor

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Interceptor.AddEventSource(Me, True, "")
    End Sub

    Private Sub Interceptor_ObjectEvent(ByVal sender As Object, ByVal e As ObjectEventArgs) Handles Interceptor.ObjectEvent
        If e.EventSource Is txtOutput AndAlso e.EventName = "TextChanged" Then Return
        Dim sb As New StringBuilder
        Dim ctrl As Control = DirectCast(e.EventSource, Control)
        sb.AppendFormat("{0}.{1}{2}", ctrl.Name, e.EventName, ControlChars.CrLf)

        ' Show event arguments, if not a plain EventArgs object.
        If e.Arguments.GetType() IsNot GetType(EventArgs) Then
            For Each pi As PropertyInfo In e.Arguments.GetType().GetProperties()
                Dim value As Object = pi.GetValue(e.Arguments, Nothing)
                sb.AppendFormat("   {0} = {1}{2}", pi.Name, value, ControlChars.CrLf)
            Next
        End If

        ' Display in control; catch errors because txtOutput might have been disposed of.
        Try
            txtOutput.AppendText(sb.ToString())
        Catch
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtOutput.Clear()
    End Sub

End Class
