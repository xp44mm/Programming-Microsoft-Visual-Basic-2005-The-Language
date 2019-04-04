Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Module Module1

   Dim snippetsPath As String
   Dim catNames As New Dictionary(Of String, String)

   Sub Main(ByVal args() As String)
      ' If no argument has been provided, use default path for snippets.
      If args.Length = 0 Then
         args = New String() {"C:\Program Files\Microsoft Visual Studio 8\Vb\Snippets\1033\SnippetIndex.xml"}
         ' Uncomment next line to list C# snippets
         ' args = New String() {"C:\Program Files\Microsoft Visual Studio 8\VC#\Snippets\1033\SnippetsIndex.xml"}
      End If
      Dim snippetsFile As String = args(0)
      snippetsPath = Path.GetDirectoryName(snippetsFile)

      ' Load the snippet index file.
      Dim xmlIndex As New XmlDocument()
      xmlIndex.Load(snippetsFile)
      ' We need two passes, because dirs and subdirs use a different XML element.
      ParseSnippetIndex(xmlIndex, "//SnippetDir")
      ParseSnippetIndex(xmlIndex, "//SnippetSubDir")

      ' Iterate over all the directories in the main snippet directory.
      For Each dir As String In Directory.GetDirectories(snippetsPath)
         ParseSnippetFolder(dir, "")
      Next
   End Sub

   Sub ParseSnippetIndex(ByVal xmlIndex As XmlDocument, ByVal searchKey As String)
      ' Create the correspondence between relative paths and localized categories
      For Each xmlEl As XmlElement In xmlIndex.SelectNodes(searchKey)
         Dim elPath As XmlElement = DirectCast(xmlEl.SelectSingleNode("DirPath"), XmlElement)
         Dim elName As XmlElement = DirectCast(xmlEl.SelectSingleNode("LocalizedName"), XmlElement)
         catNames.Add(elPath.InnerText, elName.InnerText)
      Next
   End Sub

   Sub ParseSnippetFolder(ByVal dir As String, ByVal parentCategory As String)
      ' Retrieve the relative name of this subdirectory.
      Dim relPath As String = dir.Substring(snippetsPath.Length)
      ' The default name for this category
      Dim categoryName As String = parentCategory & Path.GetFileNameWithoutExtension(dir)

      ' Search this relative path in the snippet index.
      Dim searchPath As String = "%InstallRoot%\Vb\Snippets\%LCID%" + relPath + "\"
      If catNames.ContainsKey(searchPath) Then
         ' If found, use the localized category as appears in the index file
         categoryName = parentCategory & catNames(searchPath)
      End If
      Console.WriteLine(categoryName.ToUpper())

      ' Parse individual snippets in this directory.
      For Each file As String In Directory.GetFiles(dir, "*.snippet")
         ParseSnippetFile(file)
      Next
      ' Parse all sub-categories
      For Each subdir As String In Directory.GetDirectories(dir)
         ParseSnippetFolder(subdir, categoryName & " / ")
      Next
   End Sub

   Dim reTitle As New Regex("<Title>(.+?)</Title>")
   Dim reShortcut As New Regex("<Shortcut>(.+?)</Shortcut>")

   Sub ParseSnippetFile(ByVal snippetFile As String)
      Dim text As String = File.ReadAllText(snippetFile)
      ' We use regexes to extract information for individual snippet files.
      Dim maTitle As Match = reTitle.Match(text)
      Dim maShortcut As Match = reShortcut.Match(text)

      Dim title As String = maTitle.Groups(1).Value
      Dim shortcut As String = maShortcut.Groups(1).Value

      Console.WriteLine("  {0} [{1}]", title, shortcut)
   End Sub

End Module
