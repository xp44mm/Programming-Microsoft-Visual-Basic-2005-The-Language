Class IndexableDictionary(Of TKey, TValue)
   Inherits SortedDictionary(Of TKey, TValue)

   ' Retrieve a key by its index.
   Function GetKey(ByVal index As Integer) As TKey
      ' Retrieve the N-th key. 
      Dim keys(Me.Count - 1) As TKey
      Me.Keys.CopyTo(keys, 0)
      Return keys(index)
   End Function

   Default Public Overloads Property Item(ByVal index As Integer) As TValue
      Get
         Return Me(GetKey(index))
      End Get
      Set(ByVal value As TValue)
         Me(GetKey(index)) = value
      End Set
   End Property
End Class
