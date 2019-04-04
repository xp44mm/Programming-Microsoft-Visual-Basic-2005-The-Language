Module Functions
   Sub SaveObjects(ByVal table As DataTable, ByVal array() As IDataRowPersistable)
      ' Retrieve the primary key name. (Multiple column keys aren't supported.)
      Dim pkName As String = table.PrimaryKey(0).ColumnName
      ' Create a DataView sorted on the primary key.
      Dim dataView As New DataView(table)
      dataView.Sort = pkName

      For Each obj As IDataRowPersistable In array
         ' Search for the corresponding DataRow in the table.
         Dim row As DataRow
         Dim rowIndex As Integer = dataView.Find(obj.PrimaryKey)

         If rowIndex >= 0 Then
            ' If found, get a reference to the corresponding DataRow.
            row = table.Rows(rowIndex)
         Else
            ' If not found, this is a new object.
            row = table.NewRow()
         End If
         ' Ask the object to save itself.
         obj.Save(row)
         ' Add to the DataTable if it was a new row.
         If rowIndex < 0 Then table.Rows.Add(row)
      Next
   End Sub

   Sub LoadObjects(ByVal table As DataTable, ByVal array() As IDataRowPersistable)
      ' Load each object with data from a DataRow.
      For i As Integer = 0 To table.Rows.Count - 1
         Dim row As DataRow = table.Rows(i)
         array(i).Load(row)
      Next
   End Sub

End Module
