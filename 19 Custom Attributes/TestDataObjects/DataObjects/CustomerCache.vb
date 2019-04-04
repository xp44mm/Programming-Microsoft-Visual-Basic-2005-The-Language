Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports DataObjectLibrary

<DataObjectCompanion("DataObjects.DOCustomers")> _
Public Class CustomerCache
   Implements IDataObjectCompanion

   Dim cacheFile As String = My.Settings.CacheFile

   Public Sub AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterFill
      If command.ChildTables.Contains("Orders") And Not command.Canceled Then
         SaveToCache(ds)
      End If
   End Sub

   Public Sub AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterUpdate
      If command.ChildTables.Contains("Orders") And Not command.Canceled Then
         SaveToCache(ds)
      End If
   End Sub

   Public Sub BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeFill
      If File.Exists(cacheFile) AndAlso File.GetCreationTime(cacheFile).Date = Date.Today Then
         LoadFromCache(ds)
         command.Canceled = True
      End If
   End Sub

   Public Sub BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeUpdate
      ' Nothing to do.
   End Sub

   ' Save and load from the cache.

   Private Sub SaveToCache(ByVal ds As DataSet)
      Console.WriteLine("Dataset is being saved to {0}", cacheFile)
      ds.RemotingFormat = SerializationFormat.Binary
      Using fs As New FileStream(cacheFile, FileMode.Create)
         Dim bf As New BinaryFormatter
         bf.Serialize(fs, ds)
      End Using
   End Sub

   Private Sub LoadFromCache(ByVal ds As DataSet)
      Console.WriteLine("Dataset is being loaded from {0}", cacheFile)
      ds.RemotingFormat = SerializationFormat.Binary
      Using fs As New FileStream(cacheFile, FileMode.Open)
         Dim bf As New BinaryFormatter
         Dim ds2 As DataSet = DirectCast(bf.Deserialize(fs), DataSet)
         ds.Merge(ds2)
      End Using
   End Sub
End Class
