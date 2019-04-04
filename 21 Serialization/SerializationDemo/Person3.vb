Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization

<Serializable()> _
Public Class Person3
   Implements IDisposable

   Public FirstName As String
   Public LastName As String
   <OptionalField(VersionAdded:=2)> Public Country As String = "USA"
   <NonSerialized()> Dim logStream As FileStream

   Sub New(ByVal firstName As String, ByVal lastName As String)
      ' Initialize the FirstName, LastName, and BirthDate fields.
      Me.FirstName = firstName
      Me.LastName = lastName
      ' Open the file for logging.
      OpenLogFile()
   End Sub

   ' This method is called when the object been completely deserialized.
   <OnDeserializedAttribute()> _
   Private Sub AfterDeserialization(ByVal context As StreamingContext)
      Debug.WriteLine("Inside AfterDeserialization method")
      OpenLogFile()
   End Sub


   ' Open a log file just for this instance.
   Private Sub OpenLogFile()
      Dim fileName As String = Me.FirstName & " " & Me.LastName & ".txt"
      logStream = New FileStream(fileName, FileMode.OpenOrCreate)
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      If logStream IsNot Nothing Then logStream.Close()
   End Sub
End Class
