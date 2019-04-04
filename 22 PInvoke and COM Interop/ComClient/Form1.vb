Imports System.Runtime.InteropServices

Public Class Form1

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      Dim pers As New TestComComponent.Person
      pers.FirstName = "John"
      pers.LastName = "Evans"
      Dim res As String = pers.CompleteName()
      MessageBox.Show(res)

      Dim isCom As Boolean = Marshal.IsComObject(pers)
      Debug.WriteLine(isCom)
   End Sub
End Class
