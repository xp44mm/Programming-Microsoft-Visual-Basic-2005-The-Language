Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Public Class UserForm

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      If My.User.IsAuthenticated Then
         txtInfo.Text = "Name: " & My.User.Name             ' => MYPC\Francesco
      Else
         txtInfo.Text = "User isn't authenticated"
      End If

      With Thread.CurrentPrincipal.Identity
         txtInfo.AppendText(ControlChars.CrLf)
         txtInfo.AppendText(ControlChars.CrLf)
         txtInfo.AppendText("IsAuthenticated: " & .IsAuthenticated.ToString() & ControlChars.CrLf)
         txtInfo.AppendText("Name: " & .Name & ControlChars.CrLf)
         txtInfo.AppendText("AuthenticationType: " & .AuthenticationType & ControlChars.CrLf)
         ' => Can be NTLM, Basic, Forms, Passport, or a custom string.
      End With

      txtInfo.AppendText(ControlChars.CrLf)
      If My.User.IsInRole(BuiltInRole.Administrator) Then
         txtInfo.AppendText("User is an administrator." & ControlChars.CrLf)
      ElseIf My.User.IsInRole("Managers") Then
         txtInfo.AppendText("User is in the Managers group." & ControlChars.CrLf)
      ElseIf My.User.IsInRole("MYSERVER\Administrators") Then
         txtInfo.AppendText("User is an administrator of the MYSERVER computer." & ControlChars.CrLf)
      End If


   End Sub
End Class