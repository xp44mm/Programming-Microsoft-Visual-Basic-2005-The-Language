Imports System.Runtime.InteropServices
Imports System.Security

Public Class Form1

    Dim password As New SecureString()

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
          Handles txtPassword.KeyPress
        Select Case Asc(e.KeyChar)
            Case 8
                ' Backspace: remove the char from the secure string.
                If txtPassword.SelectionStart > 0 Then
                    password.RemoveAt(txtPassword.SelectionStart - 1)
                End If
            Case Is >= 32
                ' Delete current selection
                If txtPassword.SelectionLength > 0 Then
                    For i As Integer = txtPassword.SelectionStart + txtPassword.SelectionLength - 1 To txtPassword.SelectionStart Step -1
                        password.RemoveAt(i)
                    Next
                End If
                ' Regular character: insert it in the secure string.
                If txtPassword.SelectionStart = txtPassword.TextLength Then
                    password.AppendChar(e.KeyChar)
                Else
                    password.InsertAt(txtPassword.SelectionStart, e.KeyChar)
                End If
                ' Display (and store) an asterisk in the text box.
                e.KeyChar = "*"c
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Convert the password into an unmanaged BSTR.
        Dim ptr As IntPtr = Marshal.SecureStringToBSTR(password)
        ' For demo purposes, convert the BSTR into a regular string and use it.
        Dim pw As String = Marshal.PtrToStringBSTR(ptr)

        MessageBox.Show(pw, "Password")

        ' Clear the unmanaged BSTR used for the password.
        Marshal.ZeroFreeBSTR(ptr)

    End Sub

End Class
