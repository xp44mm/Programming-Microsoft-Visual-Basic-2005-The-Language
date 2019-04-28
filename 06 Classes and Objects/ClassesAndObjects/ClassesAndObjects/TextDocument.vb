Imports System.IO

Public Class TextDocument

    ' A collection of all the TextDocument objects generated so far
    Private Shared docs As New Hashtable()

    ' The public static factory method
    Public Shared Function Create(ByVal id As Long, ByVal path As String) As TextDocument
        ' The next statement returns Nothing if no element with this ID is in the Hashtable.
        Dim doc As TextDocument = DirectCast(docs(id), TextDocument)
        If doc IsNot Nothing Then
            ' If both ID and path match, return the previous instance.
            If doc.Path = path Then Return doc
            ' Otherwise, we have a document with the same ID and a different path.
            Throw New ArgumentException("ID already used.")
        End If
        ' Return an instance with given ID.
        Return New TextDocument(id, path)
    End Function

    ' The private constructor
    Private Sub New(ByVal id As Long, ByVal path As String)
        Me.ID = id
        Me.Path = path
        'Me.Text = File.ReadAllText(path)
        ' Store the current instance in the static Hashtable.
        docs.Add(id, Me)
    End Sub

    ' These should be read-only properties in a real application.
    Public ReadOnly ID As Long

    Public ReadOnly Path As String
    Public ReadOnly Text As String
End Class
