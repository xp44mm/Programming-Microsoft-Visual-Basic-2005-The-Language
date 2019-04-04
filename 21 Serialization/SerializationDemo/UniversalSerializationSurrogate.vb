Imports System.Reflection
Imports System.Runtime.Serialization

Public Class UniversalSerializationSurrogate
   Implements ISerializationSurrogate

   Public Sub GetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) Implements ISerializationSurrogate.GetObjectData
      Dim flags As BindingFlags = BindingFlags.Instance Or _
         BindingFlags.Public Or BindingFlags.Public
      For Each fi As FieldInfo In obj.GetType().GetFields(flags)
         info.AddValue(fi.Name, fi.GetValue(obj))
      Next
   End Sub

   Public Function SetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext, ByVal selector As ISurrogateSelector) _
      As Object Implements ISerializationSurrogate.SetObjectData
      Dim flags As BindingFlags = BindingFlags.Instance Or _
         BindingFlags.Public Or BindingFlags.Public
      For Each fi As FieldInfo In obj.GetType().GetFields(flags)
         fi.SetValue(obj, info.GetValue(fi.Name, fi.FieldType))
      Next
      Return obj
   End Function
End Class
