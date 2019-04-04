Public Class DataObjectCommand

   ' The name of this command
   Public ReadOnly Name As String

   ' The list of child tables to be included in the fill/update command
   Public ReadOnly ChildTables As New List(Of String)

   ' The value of key column. (This version supports only one key column.)
   Public ReadOnly KeyValue As Object

   ' True if this command has been canceled (by a data companion)
   Public Canceled As Boolean

   Sub New(ByVal name As String)
      Me.New(name, Nothing)
   End Sub

   Sub New(ByVal name As String, ByVal keyValue As Object, ByVal ParamArray childTables() As String)
      Me.Name = name
      Me.KeyValue = keyValue
      If childTables IsNot Nothing Then Me.ChildTables.AddRange(childTables)
   End Sub
End Class


