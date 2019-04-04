Imports Microsoft.Win32

Public Class RegistryForm

   Private Sub btnCheckWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckWord.Click
      ' Check whether Microsoft Word is installed on this computer
      ' by searching the HKEY_CLASSES_ROOT\Word.Application key.
      Dim key As RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey("Word.Application")
      If key Is Nothing Then
         lblWord.Text = "Microsoft Word isn't installed"
      Else
         Dim keyName As String = "HKEY_CLASSES_ROOT\Word.Application\CurVer"
         ' Second argument is the value name; use Nothing for the default value.
         ' Third argument is the value to be returned if the value is missing.
         Dim value As String = My.Computer.Registry.GetValue(keyName, Nothing, "").ToString()
         lblWord.Text = "Microsoft Word is installed. Version = " & value

         ' Always close registry keys after using them.
         key.Close()
      End If
   End Sub

   Private Sub btnClsid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClsid.Click
      Dim guid As String = GetCLSID(txtClassname.Text)
      If guid IsNot Nothing Then
         lblClsid.Text = "GUID: " & guid
      Else
         lblClsid.Text = "< not found >"
      End If
   End Sub

   Private Sub btnComponents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComponents.Click
      DisplayCOMComponents()
   End Sub


   Private Sub btnAddKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddKey.Click
      ' Open the HKEY_LOCALMACHINE\SOFTWARE key.
      Dim regSoftware As RegistryKey = _
          My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
      ' Add a key for the company name (or open it if it exists already).
      Dim regCompany As RegistryKey = regSoftware.CreateSubKey("Code Architects")
      MsgBox("The HKEY_LOCALMACHINE\SOFTWARE\Code Architects key has been created")
      ' Add another key for the product name (or open it if it exists already).
      Dim regProduct As RegistryKey = regCompany.CreateSubKey("FormMaximizer")
      MsgBox("The HKEY_LOCALMACHINE\SOFTWARE\Code Architects\FormMaximizer key has been created")
      ' Create three Values under the Product key.
      regProduct.SetValue("Path", "C:\FormMaximizer\Bin")  ' A string value
      regProduct.SetValue("MajorVersion", 2)               ' A number
      regProduct.SetValue("MinorVersion", 1)               ' A number
      MsgBox("Three values under the HKEY_LOCALMACHINE\SOFTWARE\Code Architects\FormMaximizer key have been created")

      ' Delete the three values just added.
      regProduct.DeleteValue("Path")
      regProduct.DeleteValue("MajorVersion")
      regProduct.DeleteValue("MinorVersion")
      ' Delete the Product and Company keys after closing them.
      regProduct.Close()
      regCompany.DeleteSubKey("FormMaximizer")
      regCompany.Close()
      regSoftware.DeleteSubKey("Code Architects")
      MsgBox("All the values and keys have been removed")

   End Sub

   ' Return the CLSID of a COM component, or "" if not found.
   Function GetCLSID(ByVal ProgId As String) As String
      Dim guid As String = Nothing
      ' Open the key associated with the ProgID.
      Dim regProgID As RegistryKey = _
         My.Computer.Registry.ClassesRoot.OpenSubKey(ProgId)
      If Not (regProgID Is Nothing) Then
         ' If found, open the CLSID subkey.
         Dim regClsid As RegistryKey = regProgID.OpenSubKey("CLSID")
         If Not (regClsid Is Nothing) Then
            ' If found, get its default value. 2nd optional argu-ment is the 
            ' string to be returned if the specified value doesn't exist.
            ' (Returns an Object that we must convert to a string.)
            guid = CStr(regClsid.GetValue(""))
            regClsid.Close()
         End If
         regProgID.Close()
      End If
      Return guid
   End Function

   ' Display information on all the COM components installed on this computer.
   Sub DisplayCOMComponents()
      ' Iterate over the subkeys of the HKEY_CLASSES_ROOT\CLSID key.
      Dim regClsid As RegistryKey = _
         My.Computer.Registry.ClassesRoot.OpenSubKey("CLSID")
      For Each clsid As String In regClsid.GetSubKeyNames
         ' Open the subkey.
         Dim regClsidKey As RegistryKey = regClsid.OpenSubKey(clsid)
         ' Get the ProgID. (This is the default value for this key.)
         Dim ProgID As String = CStr(regClsidKey.GetValue(""))
         ' Get the InProcServer32 key, which holds the DLL path.
         Dim regPath As RegistryKey = regClsidKey.OpenSubKey("InprocServer32")
         If regPath Is Nothing Then
            ' If not found, it isn't an in-process DLL server; 
            ' let's see if it's an out-of-process EXE server.
            regPath = regClsidKey.OpenSubKey("LocalServer32")
         End If
         If Not (regPath Is Nothing) Then
            ' If either key has been found, retrieve its default value.
            Dim filePath As String = CStr(regPath.GetValue(""))
            ' Display all the relevant info gathered so far.
            lstComponents.Items.add(ProgID & " " & clsid & " -> " & filePath)
            regPath.Close()
         End If
         regClsidKey.Close()
      Next
   End Sub

End Class