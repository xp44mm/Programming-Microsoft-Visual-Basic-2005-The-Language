Public Class UnableToLoadIniFileException
   Inherits System.ApplicationException

   Private Const Default_Message As String = "Unable to load initialization file"

   ' Constructors with fewer parameters delegate to the constructor with more parameters.
   Public Sub New()
      Me.New(Default_Message, Nothing)
   End Sub

   Public Sub New(ByVal message As String)
      Me.New(message, Nothing)
   End Sub

   Public Sub New(ByVal innerException As Exception)
      Me.New(Default_Message, innerException)
   End Sub

   ' The most complete constructor calls the base type's constructor.
   Public Sub New(ByVal message As String, ByVal innerException As Exception)
      MyBase.New(message, innerException)
   End Sub
End Class
