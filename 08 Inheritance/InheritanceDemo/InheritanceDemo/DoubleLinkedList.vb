Public Class DoubleLinkedList
   ' These members must be private, because they refer to private type.
   Private FirstItem As ListItem
   Private LastItem As ListItem

   ' This class isn't visible from outside the DoubleLinkedList class.
   Private Class ListItem
      Private list As DoubleLinkedList
      ' The constructor takes a reference to the outer DoubleLinkedList object.
      Public Sub New(ByVal list As DoubleLinkedList)
         Me.list = list
      End Sub

      ' This method references a private member in the outer class.
      Public Function IsFirstItem() As Boolean
         Return (Me Is list.FirstItem)
      End Function
      '…
   End Class

End Class
