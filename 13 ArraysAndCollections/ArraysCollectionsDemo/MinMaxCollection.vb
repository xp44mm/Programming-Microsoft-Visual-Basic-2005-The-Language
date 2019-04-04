Imports System.Collections.ObjectModel

Public Class MinMaxCollection(Of T As IComparable)
   Inherits Collection(Of T)

   Private min As T, max As T
   Private upToDate As Boolean

   Public ReadOnly Property MinValue() As T
      Get
         If Not upToDate Then UpdateValues()
         Return min
      End Get
   End Property

   Public ReadOnly Property MaxValue() As T
      Get
         If Not upToDate Then UpdateValues()
         Return max
      End Get
   End Property

   Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As T)
      MyBase.InsertItem(index, item)
      If Me.Count = 1 Then
         UpdateValues()
      ElseIf upToDate Then
         ' If values are up-to-date, adjusting the min/max value is simple.
         If min.CompareTo(item) > 0 Then min = item
         If max.CompareTo(item) < 0 Then max = item
      End If
   End Sub

   Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As T)
      MyBase.SetItem(index, item)
      If min.CompareTo(item) = 0 OrElse max.CompareTo(item) = 0 Then upToDate = False
   End Sub

   Protected Overrides Sub RemoveItem(ByVal index As Integer)
      Dim item As T = Me(index)     ' Remember value before removing it.
      MyBase.RemoveItem(index)
      If min.CompareTo(item) = 0 OrElse max.CompareTo(item) = 0 Then upToDate = False
   End Sub

   Protected Overrides Sub ClearItems()
      MyBase.ClearItems()
      upToDate = False
   End Sub

   Private Sub UpdateValues()
      If Me.Count = 0 Then
         ' Assign default value of T if collection is empty.
         min = Nothing : max = Nothing
      Else
         ' Else evaluate the min/max value.
         min = Me(0) : max = Me(0)
         For Each item As T In Me
            If min.CompareTo(item) > 0 Then min = item
            If max.CompareTo(item) < 0 Then max = item
         Next
      End If
      ' Signal that min/max values are now up-to-date.
      upToDate = True
   End Sub
End Class
