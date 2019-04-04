Public Class CustomException
   Inherits Exception

   Sub New(ByVal message As String)
      MyBase.New(message)
      Me.HResult = &H80001234
   End Sub
End Class
