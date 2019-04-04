Public Class Form1


   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Console.WriteLine(Application.LocalUserAppDataPath)

      lblShowStatusBar.Text = "ShowStatusBar = " & My.Settings.ShowStatusBar
      txtUserName.Text = My.Settings.UserNickname
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      My.Settings.UserNickname = txtUserName.Text
   End Sub
End Class
