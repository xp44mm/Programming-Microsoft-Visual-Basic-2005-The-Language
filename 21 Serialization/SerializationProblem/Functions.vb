Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection

Module Functions
   Public Sub SerializeToFile(ByVal path As String, ByVal obj As Object)
      ' Open the stream for output.
      Using fs As New FileStream(path, FileMode.Create)
         ' Create a formatter for this file stream.
         Dim bf As New BinaryFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Serialize the object and close the stream.
         bf.Serialize(fs, obj)
      End Using
   End Sub

   Public Function DeserializeFromFile(ByVal path As String) As Object
      ' Open the stream for input.
      Using fs As New FileStream(path, FileMode.Open)
         ' Create a formatter for this file stream.
         Dim bf As New BinaryFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Deserialize the object from the stream.
         Return bf.Deserialize(fs)
      End Using
   End Function

End Module
