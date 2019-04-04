Imports System.Net

Public Class NetworkForm

   Private Sub btnPing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPing.Click
      Dim found As Boolean = False
      If My.Computer.Network.IsAvailable Then
         Try
            ' Attempt to ping the specified site, with a 3-second timeout.
            Dim url As String = txtUrl.Text
            found = My.Computer.Network.Ping(url, 3000)
         Catch ex As Exception
            ' Optionally display an error message here.
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End If
      If found Then
         ' The site is reachable.
         lblPingResult.Text = "The site is available"
      Else
         lblPingResult.Text = "The site is not available"
      End If

   End Sub

   Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
      Try
         ' The remote address must include a protocol name.
         Dim url As String = txtUrl.Text
         If Not url.ToLower().StartsWith("http://") Then url = "http://" & url
         Dim fileName As String = txtDestfile.Text
         ' True means that a progress dialog should be displayed; 
         ' False means that the local file shouldn't be overwritten;
         ' Timeout is 3 seconds.
         My.Computer.Network.DownloadFile(url, fileName, Nothing, Nothing, True, 3000, False)
      Catch ex As WebException When ex.Message = "The operation has timed out"
         ' A timeout has occurred: the site isn't reachable.
         MessageBox.Show(ex.Message, "TIMEOUT", MessageBoxButtons.OK, MessageBoxIcon.Error)

      Catch ex As WebException When ex.Message = _
            "The operation was canceled."
         ' The end user canceled the operation while it was progressing.
         MessageBox.Show(ex.Message, "User canceled the request", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
         MessageBox.Show(ex.Message, ex.GetType.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub
End Class