Imports System.Text
Imports DataObjectLibrary

<DataObjectCompanion("")> _
Public Class Tracer
   Implements IDataObjectCompanion

   Public Sub BeforeFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeFill
      Console.WriteLine("[{0}] BeforeFill - Command:{1}", CObj(obj).GetType().Name, command.Name)
   End Sub

   Public Sub BeforeUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.BeforeUpdate
      Console.WriteLine("[{0}] BeforeUpdate - Command:{1}", CObj(obj).GetType().Name, command.Name)
   End Sub

   Public Sub AfterFill(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterFill
      Console.WriteLine("[{0}] AfterFill - Command:{1}", CObj(obj).GetType().Name, command.Name)
   End Sub

   Public Sub AfterUpdate(ByVal obj As IDataObject, ByVal ds As DataSet, ByVal command As DataObjectCommand) Implements IDataObjectCompanion.AfterUpdate
      Console.WriteLine("[{0}] AfterUpdate - Command:{1}", CObj(obj).GetType().Name, command.Name)
   End Sub
End Class
