<Serializable()> _
Public Class CustomerEx
   Public Name As String
   Public City As String

   Sub New(ByVal name As String, ByVal city As String)
      Me.Name = name
      Me.City = city
   End Sub

   Public Country As String = "USA"

End Class
