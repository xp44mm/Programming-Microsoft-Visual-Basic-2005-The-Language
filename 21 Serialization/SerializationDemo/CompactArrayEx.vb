Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public Class CompactArrayEx(Of T)
   Inherits CompactArray(Of T)
   Implements ISerializable              ' Interface reimplementation!

   Public ReadOnly DefaultValue As T     ' A new field in the derived class.

   Sub New(ByVal numEls As Integer, ByVal defaultValue As T)
      MyBase.New(numEls)
      Me.DefaultValue = defaultValue
   End Sub

   ' The GetObjectData method is re-implemented.
   Protected Overloads Sub GetObjectData(ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      ' Deserialize the base class, then deserialize any additional field.
      MyBase.GetObjectData(info, context)
      info.AddValue("DefaultValue", Me.DefaultValue)
   End Sub

   Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      ' Serialize the base class, then serialize any additional field.
      MyBase.New(info, context)
      Me.DefaultValue = CType(info.GetValue("DefaultValue", GetType(T)), T)
   End Sub
End Class
