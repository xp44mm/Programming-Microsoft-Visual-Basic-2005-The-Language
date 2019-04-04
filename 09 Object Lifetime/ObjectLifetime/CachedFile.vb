Imports System.IO

Public Class CachedFile
   ' The name of the file cached
   Public ReadOnly Filename As String
   ' A weak reference to the string that contains the text
   Dim wrText As WeakReference

   ' The constructor takes the name of the file to read.
   Public Sub New(ByVal filename As String)
      Me.Filename = filename
   End Sub

   ' Read the contents of the file.
   Private Function ReadFile() As String
      Dim text As String = File.ReadAllText(Filename)
      ' Create a weak reference to this string.
      wrText = New WeakReference(text)
      Return text
   End Function

   ' Return the textual content of the file.
   Public Function GetText() As String
      Dim text As Object = Nothing
      ' Retrieve the target of the weak reference.
      If wrText IsNot Nothing Then text = wrText.Target
      If text IsNot Nothing Then
         ' If non-null, the data is still in the cache.
         Return text.ToString()
      Else
         ' Otherwise, read it and put it in the cache again.
         Return ReadFile()
      End If
   End Function
End Class
