#If _MyType = "WindowsFormsWithCustomSubMain" Then

Imports System.Net.NetworkInformation

Module MainModule
   Sub Main()
      AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf NetAvailabilityChanged
      AddHandler NetworkChange.NetworkAddressChanged, AddressOf NetAddressChanged
      Application.Run(New MainForm())
   End Sub

   Private Sub NetAvailabilityChanged(ByVal sender As Object, ByVal e As NetworkAvailabilityEventArgs)
      ' The computer has been connected to or disconnected from the network.
      Debug.WriteLine("The computer has been connected to or disconnected from the network.")
   End Sub

   Private Sub NetAddressChanged(ByVal sender As Object, ByVal e As EventArgs)
      ' The network address of the computer has changed.
      Debug.WriteLine("The network address of the computer has changed.")
   End Sub

End Module

#End If
