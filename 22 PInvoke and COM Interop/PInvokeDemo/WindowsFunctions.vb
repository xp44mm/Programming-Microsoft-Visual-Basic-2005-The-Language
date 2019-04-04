Imports System.Text
Imports System.Runtime.InteropServices

Public Class WindowsFunctions
   <DllImport("user32")> _
   Public Shared Function FindWindow(ByVal lpClassName As String, _
      ByVal lpWindowName As String) As Integer
      ' No code here
   End Function

   <DllImport("user32")> _
   Shared Function MoveWindow(ByVal hWnd As Integer, ByVal x As Integer, _
      ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, _
      ByVal bRepaint As Integer) As Integer
      ' No code here
   End Function

   <DllImport("user32")> _
   Public Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal buffer As StringBuilder, _
      ByVal charcount As Integer) As Integer
   End Function





End Class
