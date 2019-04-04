Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization

Module SerializationHelpers
   ' Return True if a type and all its base types are serializable.
   Function TypeIsSerializable(ByVal type As Type) As Boolean
      Do Until type Is Nothing
         ' Exit now if the type isn't serializable.
         If Not type.IsSerializable Then Return False
         ' If this type implements ISerializable, we can assume it's fully serializable.
         If GetType(ISerializable).IsAssignableFrom(type) Then Return True
         ' Continue to analyze its base class.
         type = type.BaseType
      Loop
      Return True
   End Function

   Sub SerializeObjectFields(ByVal info As SerializationInfo, ByVal key As String, _
      ByVal obj As Object, ByVal type As Type)
      If type Is Nothing Then type = obj.GetType()

      If type.BaseType IsNot GetType(Object) Then
         ' First, serialize the base class's fields.
         SerializeObjectFields(info, Path.Combine("*Base", key), obj, type.BaseType)
      End If

      ' Next, loop over all fields that are declared in this type.
      Dim complexFields As New ArrayList
      For Each fi As FieldInfo In type.GetFields(BindingFlags.Instance Or _
            BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.DeclaredOnly)
         ' Remember the value of all serializable fields.
         If Not fi.IsNotSerialized Then
            ' Build the complete field name.
            Dim fieldKey As String = Path.Combine(key, fi.Name)
            ' Read actual field value.
            Dim value As Object = fi.GetValue(obj)

            If value Is Nothing OrElse TypeIsSerializable(value.GetType()) Then
               ' Save directory if field's type is serializable.
               info.AddValue(fieldKey, value)
            Else
               ' Remember this is a complex field.
               complexFields.Add(fi.Name)
               ' Remember its type.
               info.AddValue(Path.Combine(fieldKey, "*Type"), value.GetType())
               ' Store the object value by calling this method recursively.
               SerializeObjectFields(info, fieldKey, value, Nothing)
            End If
         End If
      Next
      ' Remember the list of simple fields.
      info.AddValue(Path.Combine(key, "*Complex"), complexFields)
   End Sub

   Sub DeserializeObjectFields(ByVal info As SerializationInfo, ByVal key As String, _
      ByVal obj As Object, ByVal type As Type)
      If type Is Nothing Then type = obj.GetType()

      ' First, deserialize the base class's fields.
      If type.BaseType IsNot GetType(Object) Then
         DeserializeObjectFields(info, Path.Combine("*Base", key), obj, type.BaseType)
      End If

      ' Retrieve the list of complex (non-serializable) fields.
      Dim complexFields As ArrayList = DirectCast(info.GetValue( _
         Path.Combine(key, "*Complex"), GetType(ArrayList)), ArrayList)

      ' Loop over all fields that are declared in this type.
      For Each fi As FieldInfo In type.GetFields(BindingFlags.Instance Or _
         BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.DeclaredOnly)
         ' Read the value of all serializable fields.
         If Not fi.IsNotSerialized Then
            Dim fieldKey As String = Path.Combine(key, fi.Name)
            Dim value As Object = Nothing

            If Not complexFields.Contains(fi.Name) Then
               ' Read directly if it's a serializable type.
               value = info.GetValue(fieldKey, GetType(Object))
            Else
               ' Retrieve the type of this field.
               Dim fieldType As Type = DirectCast(info.GetValue( _
                  Path.Combine(fieldKey, "*Type"), GetType(Type)), Type)
               ' Create an uninitialized object of that type.
               value = FormatterServices.GetUninitializedObject(fieldType)
               ' Fill this instance by calling this method recursively.
               DeserializeObjectFields(info, fieldKey, value, Nothing)
            End If
            fi.SetValue(obj, value)
         End If
      Next
   End Sub

End Module
