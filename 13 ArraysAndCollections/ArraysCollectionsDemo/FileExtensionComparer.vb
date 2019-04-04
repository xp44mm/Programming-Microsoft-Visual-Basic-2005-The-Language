Imports System.IO

Public Class FileExtensionComparer
   Implements IComparer(Of String)

   Public Function Compare(ByVal x As String, ByVal y As String) As Integer _
         Implements IComparer(Of String).Compare
      ' Compare the extensions of file names in case-insensitive mode.
      Dim res As Integer = String.Compare(Path.GetExtension(x), Path.GetExtension(y), True)
      If res = 0 Then
         ' If extensions are equal, compare the entire file names.
         res = String.Compare(Path.GetFileName(x), Path.GetFileName(y), True)
      End If
      Return res
   End Function
End Class
