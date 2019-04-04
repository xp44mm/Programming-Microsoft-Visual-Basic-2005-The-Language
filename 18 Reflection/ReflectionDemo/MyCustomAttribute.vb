
Public Class MyCustomAttribute
   Inherits Attribute

   Dim value As MsgBoxResult

   Public Size As Integer = 4
   Public Description As String = ""

   Sub New(ByVal value As MsgBoxResult)
      Me.value = value
   End Sub


End Class

