Imports System.Runtime.Serialization

<Serializable()> _
Public Class Customer
   Public Name As String
   Public City As String

   Sub New(ByVal name As String, ByVal city As String)
      Me.Name = name
      Me.City = city
   End Sub

   '<OptionalField()> _
   Public Country As String
End Class