Imports System.IO

Module Module1

   ' Change the access date/time of all files whose names are passed on the command line.
   Sub Main(ByVal args() As String)
      For Each fname As String In args
         File.SetCreationTime(fname, Date.Now)
      Next
   End Sub


End Module
