Imports System.Threading
Imports System.Globalization

Public Class MainForm

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Dim frm As New MyApplicationForm
      frm.Show()
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Dim frm As New MyComputerForm
      frm.Show()
   End Sub

   Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      Dim frm As New FileSystemForm
      frm.Show()
   End Sub


   Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
      Dim frm As New ComputerInfoForm
      frm.Show()
   End Sub

   Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
      Dim frm As New NetworkForm
      frm.Show()
   End Sub

   Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
      Dim frm As New RegistryForm
      frm.Show()
   End Sub

   Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
      Dim frm As New UserForm
      frm.Show()
   End Sub

   Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
      Dim frm As New ResourcesForm
      frm.Show()
   End Sub

   Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
      Dim frm As New SettingsForm
      frm.Show()
   End Sub

   Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
      Dim frm As New MyExtensionsForm
      frm.show()
   End Sub
End Class
