Imports DataObjectLibrary
Imports DataSets

<DataObject("Access", "Customers")> _
Public Class DOCustomers
   Implements IDataObject(Of NWINDDataSet)

   ' The IDataObject(Of TDataSet) interface

   Public Function Fill(ByVal ds As NWINDDataSet, ByVal command As DataObjectCommand) As NWINDDataSet Implements DataObjectLibrary.IDataObject(Of NWINDDataSet).Fill
      If ds Is Nothing Then ds = New NWINDDataSet()
      If DataObjectHelper.BeforeFill(Me, ds, command) Then
         Dim customerId As String = ""
         If command.KeyValue IsNot Nothing Then customerId = command.KeyValue.ToString()

         Dim taCustomers As New NWINDDataSetTableAdapters.CustomersTableAdapter
         If customerId.Length = 0 Then
            taCustomers.Fill(ds.Customers)
         Else
            taCustomers.FillByCustomerID(ds.Customers, customerId)
         End If

         If command.ChildTables.Contains("Orders") Then
            Dim taOrders As New NWINDDataSetTableAdapters.OrdersTableAdapter
            If customerId.Length = 0 Then
               taOrders.Fill(ds.Orders)
            Else
               taOrders.FillByCustomerID(ds.Orders, customerId)
            End If
         End If
      End If
      DataObjectHelper.AfterFill(Me, ds, command)
      Return ds
   End Function

   Public Function Update(ByVal ds As NWINDDataSet, ByVal command As DataObjectCommand) As NWINDDataSet Implements DataObjectLibrary.IDataObject(Of NWINDDataSet).Update
      If DataObjectHelper.BeforeUpdate(Me, ds, command) Then
         Dim taCustomers As New NWINDDataSetTableAdapters.CustomersTableAdapter
         taCustomers.Update(ds.Customers.Select(Nothing, Nothing, DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

         If command.ChildTables.Contains("Orders") Then
            Dim taOrders As New NWINDDataSetTableAdapters.OrdersTableAdapter
            taOrders.Update(ds.Orders)
         End If
         taCustomers.Update(ds.Customers.Select(Nothing, Nothing, DataViewRowState.Deleted))
      End If
      DataObjectHelper.AfterUpdate(Me, ds, command)
      Return ds
   End Function

   ' The IDataObject interface

   Private m_Companions As New List(Of IDataObjectCompanion)

   Public ReadOnly Property Companions() As List(Of DataObjectLibrary.IDataObjectCompanion) Implements DataObjectLibrary.IDataObject.Companions
      Get
         Return m_Companions
      End Get
   End Property

End Class
