Imports System.Runtime.Serialization

<Serializable()> _
Public Class IdValuePair
   Implements IObjectReference

   ' This is where all instances created so far are stored.
   Private Shared dict As New Dictionary(Of Integer, IdValuePair)

   ' Instance fields
   Public ReadOnly Id As Integer
   Public ReadOnly Value As String

   ' Private constructor prevents instantiation.
   Private Sub New(ByVal id As Integer, ByVal value As String)
      Me.Id = id
      Me.Value = value
   End Sub

   ' The factory method
   Public Shared Function Create(ByVal id As Integer, ByVal value As String) As IdValuePair
      ' Add a new instance to the private table if necessary.
      If Not dict.ContainsKey(id) Then
         dict.Add(id, New IdValuePair(id, value))
      End If
      ' Always return an instance from the cache.
      Return dict(id)
   End Function

   Private Function GetRealObject(ByVal context As StreamingContext) As Object _
         Implements IObjectReference.GetRealObject
      ' The instance has been deserialized, so you can access its properties.
      Debug.WriteLine("GetRealObject method for ID=" & Me.Id.ToString())
      Return Create(Me.Id, Me.Value)
   End Function

End Class
