Imports System.Runtime.Serialization

Class MyDataTable
   Inherits DataTable
   Implements ISerializable

   Public AuthorName As String            ' The new field

   ' This method is invoked when an instance is serialized.
   Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      ' Let the base class serialize its own data.
      MyBase.GetObjectData(info, context)
      ' Next, serialize the new field.
      info.AddValue("AuthorName", Me.AuthorName)
   End Sub

   ' This special constructor is invoked when an instance is deserialized.
   Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      ' Ask the base class to deserialize its own data.
      MyBase.New(info, context)
      ' Next, deserialize the new field.
      Me.AuthorName = info.GetString("AuthorName")
   End Sub
End Class
