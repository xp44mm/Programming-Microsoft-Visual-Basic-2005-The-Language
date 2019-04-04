Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public Class CompactArray(Of T)
   Implements ISerializable

   ' Actual elements are stored in this private array.
   Private arr() As T

   ' The constructor takes the number of elements in the array.
   Sub New(ByVal numEls As Integer)
      ReDim arr(numEls - 1)
   End Sub

   ' The default Item property makes this class looks like a standard array.
   Default Public Overridable Property Item(ByVal index As Integer) As T
      Get
         Return arr(index)
      End Get
      Set(ByVal value As T)
         arr(index) = value
      End Set
   End Property

   ' Compress data when the object is serialized.
   Protected Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      ' Serialize the private array to a compressed stream in memory.
      Using memStream As New MemoryStream()
         Using zipStream As New DeflateStream(memStream, CompressionMode.Compress)
            Dim bf As New BinaryFormatter()
            bf.Serialize(zipStream, arr)
            zipStream.Flush()
            ' Save the contents of the compressed stream.
            Dim bytes() As Byte = memStream.GetBuffer()
            info.AddValue("bytes", bytes)
         End Using
      End Using
   End Sub

   ' Decompress data when the object is deserialized
   Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      ' Retrieve the bytes and initialize a memory buffer.
      Dim bytes() As Byte = DirectCast(info.GetValue("bytes", GetType(Byte())), Byte())
      Using inStream As New MemoryStream(bytes)
         ' Wrap a DeflateStream object around the compressed buffer.
         Using zipStream As New DeflateStream(inStream, CompressionMode.Decompress)
            Dim bf As New BinaryFormatter
            arr = DirectCast(bf.Deserialize(zipStream), T())
         End Using
      End Using
   End Sub
End Class

<Serializable()> _
Public Class CompactArray2(Of T)
   Inherits CompactArray(Of T)

   Sub New(ByVal numEls As Integer)
      MyBase.New(numEls)
   End Sub
End Class