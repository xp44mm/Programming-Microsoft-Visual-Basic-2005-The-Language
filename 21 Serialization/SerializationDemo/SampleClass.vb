Imports System.Runtime.Serialization

<Serializable()> _
Public Class SampleClass
   Implements ISerializable

   Public Sub GetObjectData(ByVal info As SerializationInfo, _
         ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      GetObjectDataHelper(info, context, Me)
   End Sub

   Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      ISerializableConstructorHelper(info, context, Me)
   End Sub

   ' ...(The remainder of the class)... 

End Class
