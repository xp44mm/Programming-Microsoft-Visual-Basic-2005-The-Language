Imports System.Collections.Specialized

Public Class PersonCollection2
   Inherits NameObjectCollectionBase

   Sub Add(ByVal key As String, ByVal p As Person)
      Me.BaseAdd(key, p)
   End Sub

   Sub Clear()
      Me.BaseClear()
   End Sub

   ' The Remove method that takes a string key
   Sub Remove(ByVal key As String)
      Me.Remove(key)
   End Sub

   ' The Remove method that takes a numeric index
   Sub Remove(ByVal index As Integer)
      Me.Remove(index)
   End Sub

   ' The Item property that takes a string key
   Default Property Item(ByVal key As String) As Person
      Get
         Return DirectCast(Me.BaseGet(key), Person)
      End Get
      Set(ByVal Value As Person)
         Me.BaseSet(key, Value)
      End Set
   End Property

   ' The Item property that takes a numeric index
   Default Property Item(ByVal index As Integer) As Person
      Get
         Return DirectCast(Me.BaseGet(index), Person)
      End Get
      Set(ByVal Value As Person)
         Me.BaseSet(index, Value)
      End Set
   End Property
End Class
