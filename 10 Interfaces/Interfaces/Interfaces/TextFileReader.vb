Imports System.IO

Public Class TextFileReader
   Implements IEnumerable

   Dim path As String

   Sub New(ByVal path As String)
      Me.path = path              ' Remember for later.
   End Sub

   Private Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      ' Return an instance of the inner enumerator.
      Return New FileReaderEnumerator(path)
   End Function

   ' The private enumerator (nested inside TextFileReader)
   Private Class FileReaderEnumerator
      Implements IEnumerator, IDisposable

      Dim sr As StreamReader             ' The Stream reader
      Dim currLine As String             ' The text line just read

      Sub New(ByVal path As String)
         sr = New StreamReader(path)
      End Sub

      ' The IEnumerator interface (three methods)

      Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
         If sr.Peek >= 0 Then
            ' If not at end of file, read the next line.
            currLine = sr.ReadLine()
            Return True
         Else
            ' Else, return False to stop enumeration.
            Return False
         End If
      End Function

      Public ReadOnly Property Current() As Object Implements IEnumerator.Current
         Get
            ' Return the line read by MoveNext.
            Return currLine
         End Get
      End Property

      Public Sub Reset() Implements IEnumerator.Reset
         ' This method is never called and can be empty.
      End Sub

      Public Sub Dispose() Implements IDisposable.Dispose
         ' Close the stream when this object is disposed.
         sr.Close()
      End Sub
   End Class

End Class
