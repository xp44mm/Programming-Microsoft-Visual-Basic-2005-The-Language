Imports AttributeLibrary

<Version("John", 1.01)> _
Public Class TestVersionClass
   <Version("Robert", 1.01, Tested:=True)> _
   Sub MyProc()
      '…
   End Sub

   <Version("Ann", 1.02)> _
   Function MyFunction() As Long
      '…
   End Function
End Class
