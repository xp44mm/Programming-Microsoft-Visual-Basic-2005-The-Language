Imports DataObjectLibrary
Imports DataSets

<DataObjectCompanion("DataObjects.DOCustomers")> _
Public Class CustomerFilter
   Implements IDataObjectCompanion

   Public Country As String = "Germany"

   Public Sub AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterFill
      Dim ds2 As NWINDDataSet = DirectCast(ds, NWINDDataSet)
      ' Remove all companyes not in the right country.
      For i As Integer = ds2.Customers.Rows.Count - 1 To 0 Step -1
         If ds2.Customers(i).Country <> Country Then
            ' Remove this row from the result.
            ds2.Customers.Rows.RemoveAt(i)
         End If
      Next
   End Sub

   Public Sub AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterUpdate
   End Sub

   Public Sub BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeFill
   End Sub

   Public Sub BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeUpdate
      Dim ds2 As NWINDDataSet = DirectCast(ds, NWINDDataSet)
      For Each custRow As NWINDDataSet.CustomersRow In ds2.Customers.GetChanges().Rows
         If custRow.Country <> Country Then
            Throw New Exception("Records must have Country = " & Country)
         End If
      Next
   End Sub
End Class
