Imports System.ComponentModel

<Assembly: CLSCompliant(True)> 

<Serializable()> _
<Description("The Person type")> _
Public Class Person

   Private m_FirstName As String

   Public Property FirstName() As String
      Get
         Return m_FirstName
      End Get
      Set(ByVal value As String)
         If value = "" Then
            Throw New ArgumentException("FirstName can't be an empty string")
         End If
         m_FirstName = value
      End Set
   End Property

   Private m_LastName As String

   Public Property LastName() As String
      Get
         Return m_LastName
      End Get
      Set(ByVal value As String)
         If value = "" Then
            Throw New ArgumentException("LastName can't be an empty string")
         End If
         m_LastName = value
      End Set
   End Property

   ' An example of method overloading
   Public Function CompleteName() As String
      Return FirstName & " " & LastName
   End Function

   Public Function CompleteName(ByVal title As String) As String
      Return title & " " & FirstName & " " & LastName
   End Function

   ' An example of a constructor

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub


   Sub New()
      ' the default constructor
   End Sub

   Public Overrides Function ToString() As String
      Return FirstName & " " & LastName
   End Function


End Class
