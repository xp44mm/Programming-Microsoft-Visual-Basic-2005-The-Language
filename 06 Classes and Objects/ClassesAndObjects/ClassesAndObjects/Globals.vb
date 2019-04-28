Imports System.IO
Imports System.Xml.Serialization

' (Classes must be public to use XML serialization.)
Public Class Globals

    ' This singleton instance is created when the application is created.
    Private Shared m_Value As New Globals

    ' This static read-only property returns the singleton instance.
    Public Shared ReadOnly Property Value() As Globals
        Get
            Return m_Value
        End Get
    End Property

    ' Load the singleton instance from file.
    Public Shared Sub Load(ByVal fileName As String)
        ' Deserialize the content of this file into the singleton object.
        Using fs As New FileStream(fileName, FileMode.Open)
            Dim xser As New XmlSerializer(GetType(Globals))
            m_Value = DirectCast(xser.Deserialize(fs), Globals)
        End Using
    End Sub

    ' Save the singleton instance to file.
    Public Shared Sub Save(ByVal fileName As String)
        ' Serialize the singleton object to the file.
        Using fs As New FileStream(fileName, FileMode.Create)
            Dim xser As New XmlSerializer(GetType(Globals))
            xser.Serialize(fs, m_Value)
        End Using
    End Sub

    Shared Sub New()
        ' Load the default set of variables when the application starts.
        If File.Exists("defaultdata.xml") Then
            Load("defaultdata.xml")
        End If
        ' Prepare to receive an event when the application exits.
        AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf ProcessExit
    End Sub

    Private Shared Sub ProcessExit(ByVal sender As Object, ByVal e As EventArgs)
        ' Save current state of variables when the application exits.
        Save("defaultdata.xml")
    End Sub

    ' Instance fields (the global variables)
    Public UserName As String

    Public Documents() As String
    Public UseSimplifiedMenus As Boolean = True
    Public UseSpellChecker As Boolean = True
End Class
