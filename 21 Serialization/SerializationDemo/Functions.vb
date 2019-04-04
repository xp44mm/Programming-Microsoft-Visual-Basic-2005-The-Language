Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Reflection

Module Functions
   Public Sub SerializeToFile(Of T)(ByVal path As String, ByVal obj As T)
      ' Open the stream for output.
      Using fs As New FileStream(path, FileMode.Create)
         ' Create a formatter for this file stream.
         Dim bf As New BinaryFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Serialize the object and close the stream.
         bf.Serialize(fs, obj)
      End Using
   End Sub

   Public Function DeserializeFromFile(Of T)(ByVal path As String) As T
      ' Open the stream for input.
      Using fs As New FileStream(path, FileMode.Open)
         ' Create a formatter for this file stream.
         Dim bf As New BinaryFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Deserialize the object from the stream.
         Return DirectCast(bf.Deserialize(fs), T)
      End Using
   End Function

   Public Sub SerializeToSoap(Of T)(ByVal path As String, ByVal obj As T)
      ' Open the stream for output.
      Using fs As New FileStream(path, FileMode.Create)
         ' Create a formatter for this file stream.
         Dim bf As New SoapFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Serialize the object and close the stream.
         bf.Serialize(fs, obj)
      End Using
   End Sub

   Public Function DeserializeFromSoap(Of T)(ByVal path As String) As T
      ' Open the stream for input.
      Using fs As New FileStream(path, FileMode.Open)
         ' Create a formatter for this file stream.
         Dim bf As New SoapFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.File))
         ' Deserialize the object from the stream.
         Return DirectCast(bf.Deserialize(fs), T)
      End Using
   End Function

   Function CloneObject(Of T)(ByVal obj As T) As T
      ' Create a memory stream and a formatter.
      Using ms As New MemoryStream(1000)
         Dim bf As New BinaryFormatter(Nothing, _
            New StreamingContext(StreamingContextStates.Clone))
         ' Serialize the object into the stream.
         bf.Serialize(ms, obj)
         ' Position stream pointer back to first byte.
         ms.Seek(0, SeekOrigin.Begin)
         ' Deserialize into another object.
         Return CType(bf.Deserialize(ms), T)
      End Using
   End Function

   ' Helper procedure meant to be called from inside ISerializable.GetObjectData.
   Sub GetObjectDataHelper(ByVal info As SerializationInfo, _
      ByVal context As StreamingContext, ByVal obj As Object)
      ' Get the list of serializable members.
      Dim members() As MemberInfo
      members = FormatterServices.GetSerializableMembers(obj.GetType)
      ' Uncomment next statement not to serialize delegate fields
      ' members = GetSerializableMembersEx(obj.GetType())

      ' Read the value of each member.
      Dim values() As Object = FormatterServices.GetObjectData(obj, members)
      ' Store values in the SerializationInfo object, using the member name as the key.
      For i As Integer = 0 To members.Length - 1
         info.AddValue(members(i).Name, values(i))
      Next
   End Sub

   ' Helper procedure meant to be called from ISerializable' special constructor.
   Public Sub ISerializableConstructorHelper(ByVal info As SerializationInfo, _
      ByVal context As StreamingContext, ByVal obj As Object)
      ' Get the list of serializable members for this object.
      Dim members() As MemberInfo
      members = FormatterServices.GetSerializableMembers(obj.GetType)
      ' Uncomment next statement not to serialize delegate fields
      ' members = GetSerializableMembersEx(obj.GetType())

      Dim values(members.Length - 1) As Object
      ' Read the value for this member (assuming it's a field).
      For i As Integer = 0 To members.Length - 1
         ' Retrieve the type for this member.
         Dim fi As FieldInfo = TryCast(members(i), FieldInfo)
         If fi IsNot Nothing Then
            values(i) = info.GetValue(fi.Name, fi.FieldType)
         End If
      Next
      ' Assign all serializable members in one operation
      FormatterServices.PopulateObjectMembers(obj, members, values)
   End Sub

   ' Get the list of serializable members of a type, except delegates.
   Function GetSerializableMembersEx(ByVal type As Type) As MemberInfo()
      Dim list As New List(Of MemberInfo)
      For Each mi As MemberInfo In FormatterServices.GetSerializableMembers(type)
         ' Add this element to the result only if it isn't a delegate.
         Dim fi As FieldInfo = TryCast(mi, FieldInfo)
         If fi IsNot Nothing And Not _
            GetType([Delegate]).IsAssignableFrom(fi.FieldType) Then
            list.Add(mi)
         End If
      Next
      Return list.ToArray()
   End Function

End Module
