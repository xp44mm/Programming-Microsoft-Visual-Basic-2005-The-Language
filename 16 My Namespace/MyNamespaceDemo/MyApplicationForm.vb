Public Class MyApplicationForm

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      ' (txtInfo is a TextBox that will contain diagnostics information.)
      With My.Application.Info
         txtInfo.AppendText("AssemblyName: " & .AssemblyName & ControlChars.CrLf)
         txtInfo.AppendText("Directory: " & .DirectoryPath & ControlChars.CrLf)
         txtInfo.AppendText(ControlChars.CrLf)

         txtInfo.AppendText("CompanyName: " & .CompanyName & ControlChars.CrLf)
         txtInfo.AppendText("Copyright:" & .Copyright & ControlChars.CrLf)
         txtInfo.AppendText("Description: " & .Description & ControlChars.CrLf)
         txtInfo.AppendText("ProductName:" & .ProductName & ControlChars.CrLf)
         txtInfo.AppendText("Title:" & .Title & ControlChars.CrLf)
         txtInfo.AppendText("Trademark: " & .Trademark & ControlChars.CrLf)
         txtInfo.AppendText("Version: " & .Version.ToString() & ControlChars.CrLf)
         txtInfo.AppendText(ControlChars.CrLf)

         txtInfo.AppendText("Working set : " & .WorkingSet.ToString() & ControlChars.CrLf)
      End With

   End Sub
End Class