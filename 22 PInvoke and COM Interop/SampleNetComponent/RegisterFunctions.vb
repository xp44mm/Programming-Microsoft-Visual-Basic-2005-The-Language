Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class RegisterFunctions
   Const COMPANYKEY As String = "Software\CodeArchitects\MyApp"

   <ComRegisterFunction()> _
   Private Shared Sub Register(ByVal ty As Type)
      Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(COMPANYKEY)
      key.SetValue("InstallDate", Now.ToLongDateString)
      key.Close()
   End Sub

   Private Shared Sub UnRegister(ByVal ty As Type)
      Registry.CurrentUser.DeleteSubKey(COMPANYKEY)
   End Sub

End Class
