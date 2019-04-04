Imports System.Text
Imports System.Runtime.InteropServices

Public Class Form1

   ' (The Ansi qualifier is optional.)
   Private Declare Ansi Function FindWindow Lib "user32" Alias "FindWindowA" _
      (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
   Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" _
      (ByVal hWnd As Integer, ByVal x As Integer, ByVal y As Integer, _
      ByVal nWidth As Integer, ByVal nHeight As Integer, _
      ByVal bRepaint As Integer) As Integer
   Declare Function EnumWindows Lib "user32" (ByVal lpEnumFunc As EnumWindowsCBK, _
      ByVal lParam As Integer) As Integer

   ' This is the syntax for a EnumWindows callback procedure.
   Delegate Function EnumWindowsCBK(ByVal hWnd As Integer, _
      ByVal lParam As Integer) As Integer

   ' This method uses Declare statements
   Sub TestFindWindow(ByVal windowTitle As String)
      ' This works only on English and US versions of Windows.
      Dim hWnd As Integer = FindWindow(Nothing, windowTitle)
      If hWnd <> 0 Then
         MoveWindow(hWnd, 0, 0, 600, 300, 1)
      Else
         MessageBox.Show("Window not found", "Error")
      End If
   End Sub

   ' This method calls methods flagged with the DllImport attribute
   Sub TestFindWindow2(ByVal windowTitle As String)
      Dim hWnd As Integer = WindowsFunctions.FindWindow(Nothing, windowTitle)
      If hWnd <> 0 Then
         WindowsFunctions.MoveWindow(hWnd, 0, 0, 600, 300, 1)
      Else
         MessageBox.Show("Window not found", "Error")
      End If
   End Sub

   Private Sub btnFindWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindWindow.Click
      TestFindWindow2(txtWindowTitle.Text)
   End Sub

   Private Sub btnGetClassName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetClassName.Click
      Dim buffer As New StringBuilder(512)
      ' The last argument is the max number of characters in the buffer.
      WindowsFunctions.GetClassName(Me.Handle, buffer, buffer.Capacity)
      Dim classname As String = buffer.ToString()
      MessageBox.Show(classname, "GetClassName")
   End Sub

   Private Sub btnTestUnions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestUnions.Click
      ' Split a color into its components.
      Dim rgb As RGBColor
      rgb.Value = &H112233             ' This is equal to 1122867.
      Dim res As String = String.Format("Red={0}, Green={1}, Blue={2}", rgb.Red, rgb.Green, rgb.Blue)
      ' => Red=51, Green=34, Blue=17
      MessageBox.Show(res)

      rgb.Red = 51
      rgb.Green = 34
      rgb.Blue = 17
      res = String.Format("RGB color = {0:X}", rgb.Value)    ' => 1122867
      MessageBox.Show(res)

      Dim it As IntegerTypes
      it.Short0 = 517                    ' Hex 0205
      res = String.Format("Byte0 = {0}, Byte1 = {1}", it.Byte0, it.Byte1)
      MessageBox.Show(res)
   End Sub

   
   Private Sub btnTestCopyFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestCopyFile.Click
      Select Case FileOperation.CopyFile(txtFrom.Text, txtTo.Text)
         Case 0 : MessageBox.Show("All files were copied correctly.")
         Case 1 : MessageBox.Show("User canceled the operation.")
         Case 2 : MessageBox.Show("An error occurred.")
      End Select

   End Sub

   Private Sub btnEnumWindows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnumWindows.Click
      Dim frm As New ListWindowsForm
      frm.Show()
   End Sub


End Class
