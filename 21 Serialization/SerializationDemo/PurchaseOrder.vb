<Serializable()> _
Public Class PurchaseOrder
   Public Supplier As Supplier
   Public Attachment As Document
End Class

Public Class Document
   Public Number As Integer
   Public Location As String
End Class

Public Class Supplier
   Public ReadOnly ID As String
   Public ReadOnly Name As String

   Sub New(ByVal id As String, ByVal name As String)
      Me.ID = id
      Me.Name = name
   End Sub
End Class
