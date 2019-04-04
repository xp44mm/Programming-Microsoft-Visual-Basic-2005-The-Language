Public Interface IDataObject
   ReadOnly Property Companions() As List(Of IDataObjectCompanion)
End Interface

Public Interface IDataObject(Of TDataSet As DataSet)
   Inherits IDataObject
   Function Fill(ByVal ds As TDataSet, ByVal command As DataObjectCommand) As TDataSet
   Function Update(ByVal ds As TDataSet, ByVal command As DataObjectCommand) As TDataSet
End Interface

Public Interface IDataObjectCompanion
   Sub BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand)
   Sub BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand)
   Sub AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand)
   Sub AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand)
End Interface

