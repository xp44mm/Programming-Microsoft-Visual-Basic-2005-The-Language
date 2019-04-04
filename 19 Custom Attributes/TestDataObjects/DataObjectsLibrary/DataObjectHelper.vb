Public Class DataObjectHelper

   Public Shared Function BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) As Boolean
      For Each companion As IDataObjectCompanion In obj.Companions
         companion.BeforeFill(obj, ds, command)
      Next
      Return Not command.Canceled
   End Function

   Public Shared Function BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) As Boolean
      For Each companion As IDataObjectCompanion In obj.Companions
         companion.BeforeUpdate(obj, ds, command)
      Next
      Return Not command.Canceled
   End Function

   Public Shared Function AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) As Boolean
      For Each companion As IDataObjectCompanion In obj.Companions
         companion.AfterFill(obj, ds, command)
      Next
      Return Not command.Canceled
   End Function

   Public Shared Function AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) As Boolean
      For Each companion As IDataObjectCompanion In obj.Companions
         companion.AfterUpdate(obj, ds, command)
      Next
      Return Not command.Canceled
   End Function
End Class
