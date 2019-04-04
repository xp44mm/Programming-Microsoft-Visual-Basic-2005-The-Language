Imports System.IO
Imports System.Text.RegularExpressions

Module Module1

   ' Compile this application and create FileGrep.Exe executable.
   Sub Main(ByVal args() As String)
      ' Show syntax if too few arguments.
      If args.Length <> 2 Then
         Console.WriteLine("Syntax: FILEGREP ""regex"" filespec")
         Exit Sub
      End If

      Dim pattern As String = args(0)
      Dim filespec As String = args(1)
      ' Create the regular expression (throws if pattern is invalid).
      Dim filePattern As New Regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.Multiline)

      ' Apply the regular expression to each file in specified or current directory.
      Dim dirname As String = Path.GetDirectoryName(filespec)
      If dirname.Length = 0 Then dirname = Directory.GetCurrentDirectory
      Dim search As String = Path.GetFileName(filespec)
      For Each fname As String In Directory.GetFiles(dirname, search)
         ' Read file contents and apply the regular expression to it.
         Dim text As String = File.ReadAllText(fname)
         Dim mc As MatchCollection = filePattern.Matches(text)
         ' Display file name if one or more matches.
         If mc.Count > 0 Then
            Console.WriteLine("{0} [{1} matches]", fname, mc.Count)
         End If
      Next
   End Sub


End Module
