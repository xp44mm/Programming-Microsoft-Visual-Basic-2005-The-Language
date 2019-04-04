Public Interface IAddin
   ReadOnly Property Id() As Long
   Property State() As Boolean
   Function OnConnection(ByVal environment As String) As Boolean
   Sub OnDisconnection()
End Interface

Public Interface IAddin2
   Inherits IAddin
   Property Description() As String
End Interface

Interface IHostEnvironment
   ReadOnly Property HashCode() As Long
End Interface

Public Interface IDataRowPersistable
   ReadOnly Property PrimaryKey() As Object
   Sub Save(ByVal row As DataRow)
   Sub Load(ByVal row As DataRow)
End Interface
