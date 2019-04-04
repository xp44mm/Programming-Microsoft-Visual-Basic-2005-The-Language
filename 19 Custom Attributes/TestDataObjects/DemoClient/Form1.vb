Imports DataObjectLibrary
Imports DataSets

Public Class Form1

   Dim factory As New DataObjectFactory("Access", Application.StartupPath)

   Private Sub btnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFill.Click
      Try
         Dim doCustomers As IDataObject(Of NWINDDataSet) = DirectCast(factory.Create("Customers"), IDataObject(Of NWINDDataSet))
         ' Uncomment next line to see the GenericFilter type in action.
         ' doCustomers.Companions.Add(New GenericFilter("Customers", "City", "Berlin"))

         Dim command As New DataObjectCommand("GetCustomers", Nothing, "Orders")
         doCustomers.Fill(Me.NwindDataSet1, command)
      Catch ex As Exception
         MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
      Try
         Dim doCustomers As IDataObject(Of NWINDDataSet) = DirectCast(factory.Create("Customers"), IDataObject(Of NWINDDataSet))
         Dim command As New DataObjectCommand("UpdateCustomers", Nothing, "Orders")
         doCustomers.Update(Me.NwindDataSet1, command)
      Catch ex As Exception
         MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class
