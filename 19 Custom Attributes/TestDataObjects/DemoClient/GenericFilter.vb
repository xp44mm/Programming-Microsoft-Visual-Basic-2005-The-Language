Imports DataObjectLibrary

Public Class GenericFilter
   Implements IDataObjectCompanion

   Public ReadOnly TableName As String
   Public ReadOnly FieldName As String
   Public ReadOnly FieldValue As Object

   Public Sub New(ByVal tableName As String, ByVal fieldName As String, ByVal fieldValue As Object)
      Me.TableName = tableName
      Me.FieldName = fieldName
      Me.FieldValue = fieldValue
   End Sub

   Public Sub AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterFill
      Dim dt As DataTable = ds.Tables(TableName)
      ' Remove all 
      For i As Integer = dt.Rows.Count - 1 To 0 Step -1
         If Not dt.Rows(i)(FieldName).Equals(FieldValue) Then
            ' Remove this row from the result.
            dt.Rows.RemoveAt(i)
         End If
      Next
   End Sub

   Public Sub AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterUpdate
   End Sub

   Public Sub BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeFill
   End Sub

   Public Sub BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeUpdate
      Dim dt As DataTable = ds.Tables(TableName)
      For Each row As DataRow In dt.GetChanges().Rows
         If Not row(FieldName).Equals(FieldValue) Then
            Throw New Exception("Record doesn't match the filter criteria")
         End If
      Next
   End Sub
End Class
