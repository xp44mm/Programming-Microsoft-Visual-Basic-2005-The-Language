Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization

<Serializable()> _
Public Class Person2
   Implements IDeserializationCallback
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
   Private Sub OnDeserialization(ByVal sender As Object) _
      Implements IDeserializationCallback.OnDeserialization
      ' Re-open the file stream when the object is deserialized.
      OpenLogFile()
      ' Only if the Country field hasn't been deserialized.
      If Country Is Nothing Then
         ' Use reflection to read the OptionalField attribute.
         Dim fi As FieldInfo = Me.GetType().GetField("Country")
         Dim attr As OptionalFieldAttribute = TryCast(Attribute.GetCustomAttribute(fi, _
            GetType(OptionalFieldAttribute)), OptionalFieldAttribute)
         If attr Is Nothing Then
            ' This should never happen.
         ElseIf attr.VersionAdded = 1 Then
            Country = "USA"
         Else
            Country = ""
         End If
      End If

   End Sub

   ' This method is called when the object been completely deserialized.
   <OnDeserialized()> _
   Private Sub AfterDeserialization(ByVal context As StreamingContext)
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
