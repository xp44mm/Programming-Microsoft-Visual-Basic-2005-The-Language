Public Class PersonDictionary
   Inherits DictionaryBase

   Public Sub Add(ByVal key As String, ByVal item As Person)
      Me.Dictionary.Add(key, item)
   End Sub

   Public Sub Remove(ByVal key As String)
      Me.Dictionary.Remove(key)
   End Sub

   Default Public Property Item(ByVal key As String) As Person
      Get
         Return DirectCast(Me.Dictionary(key), Person)
      End Get
      Set(ByVal Value As Person)
         Me.Dictionary(key) = Value
      End Set
   End Property

   Protected Overrides Sub OnValidate(ByVal key As Object, ByVal value As Object)
      If Not TypeOf key Is String Then Throw New ArgumentException("Invalid key")
      If Not TypeOf value Is Person Then Throw New ArgumentException("Invalid item")
   End Sub
End Class
