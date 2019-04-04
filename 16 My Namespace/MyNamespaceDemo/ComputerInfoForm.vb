Public Class ComputerInfoForm

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      ' Display information in a listbox named lstResults.
      lstResults.Items.Clear()
      With My.Computer.Info
         lstResults.Items.Add("AvailablePhysicalMemory = " & .AvailablePhysicalMemory.ToString())
         lstResults.Items.Add("AvailableVirtualMemory = " & .AvailableVirtualMemory.ToString())
         lstResults.Items.Add("InstalledUICulture = " & .InstalledUICulture.Name)
         lstResults.Items.Add("OSFullName = " & .OSFullName)
         lstResults.Items.Add("OSPlatform = " & .OSPlatform)
         lstResults.Items.Add("OSVersion = " & .OSVersion)
         lstResults.Items.Add("TotalPhysicalMemory = " & .TotalPhysicalMemory.ToString())
         lstResults.Items.Add("TotalVirtualMemory = " & .TotalVirtualMemory.ToString())
         lstResults.Items.Add("")
      End With
      With My.Computer.Screen
         lstResults.Items.Add("BitsPerPixel = " & .BitsPerPixel.ToString())
         lstResults.Items.Add("Width = " & .Bounds.Width.ToString())
         lstResults.Items.Add("Height = " & .Bounds.Height.ToString())
         lstResults.Items.Add("DeviceName = " & .DeviceName.ToString())
         lstResults.Items.Add("Primary = " & .Primary.ToString())
         lstResults.Items.Add("WorkingArea.Left = " & .WorkingArea.Left.ToString())
         lstResults.Items.Add("WorkingArea.Top = " & .WorkingArea.Top.ToString())
         lstResults.Items.Add("WorkingArea.Width = " & .WorkingArea.Width.ToString())
         lstResults.Items.Add("WorkingArea.Height = " & .WorkingArea.Height.ToString())
         lstResults.Items.Add("")
      End With

   End Sub
End Class