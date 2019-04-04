Imports System.Runtime.Serialization

<Serializable()> _
Public Class Singleton
   Implements IObjectReference

   ' The one and only instance is created when the type is initialized.
   Public Shared ReadOnly Instance As New Singleton()

   ' One or more instance fields.
   Public Id As Integer

   ' Prevent clients from instantiating this class.
   Private Sub New()
   End Sub

   Private Function GetRealObject(ByVal context As StreamingContext) As Object _
         Implements IObjectReference.GetRealObject
      Return Instance
   End Function

End Class
