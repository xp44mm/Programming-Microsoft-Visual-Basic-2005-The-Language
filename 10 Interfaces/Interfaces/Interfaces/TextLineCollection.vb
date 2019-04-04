Imports System.IO

Public Class TextLineCollection
   Inherits ReadOnlyCollectionBase

   Sub New(ByVal path As String)
      ' Load the inner list with text lines in the specified file.
      Using sr As New StreamReader(path)
         Do Until sr.Peek < 0
            Me.InnerList.Add(sr.ReadLine)
         Loop
      End Using
   End Sub

   Default ReadOnly Property Item(ByVal index As Integer) As String
      Get
         Return Me.InnerList(index).ToString
      End Get
   End Property
End Class
