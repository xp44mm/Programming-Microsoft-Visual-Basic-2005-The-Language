Imports System.Runtime.Serialization

Public Class DocumentSerializationSurrogate
   Implements ISerializationSurrogate

   Public Sub GetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) Implements ISerializationSurrogate.GetObjectData
      ' Save the properties of the object being serialized.
      Dim instance As Document = DirectCast(obj, Document)
      info.AddValue("Number", instance.Number)
      info.AddValue("Location", instance.Location)
   End Sub

   Public Function SetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext, ByVal selector As ISurrogateSelector) _
      As Object Implements ISerializationSurrogate.SetObjectData
      ' Populate the (uninitialized) object passed as an argument.
      Dim instance As Document = DirectCast(obj, Document)
      instance.Number = info.GetInt32("Number")
      instance.Location = info.GetString("Location")
      ' You can return Nothing if you've populated the object passed as an argument.
      Return Nothing
   End Function
End Class

Public Class SupplierSerializationSurrogate
   Implements ISerializationSurrogate

   Public Sub GetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) Implements ISerializationSurrogate.GetObjectData
      ' Save the properties of the object being serialized.
      Dim instance As Supplier = DirectCast(obj, Supplier)
      info.AddValue("Id", instance.ID)
      info.AddValue("Name", instance.Name)
   End Sub

   Public Function SetObjectData(ByVal obj As Object, ByVal info As SerializationInfo, _
      ByVal context As StreamingContext, ByVal selector As ISurrogateSelector) _
      As Object Implements ISerializationSurrogate.SetObjectData
      ' Ignore the object passed as an argument and create a new instance.
      Dim id As String = info.GetString("Id")
      Dim name As String = info.GetString("Name")
      Return New Supplier(id, name)
   End Function
End Class
