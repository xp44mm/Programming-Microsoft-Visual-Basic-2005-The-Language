Public Module EventHelper
   ' Delegates declaration
   Public Delegate Sub OnPropertyChangingEventHandler(Of T) _
      (ByVal e As PropertyChangingEventArgs(Of T))
   Public Delegate Sub OnPropertyChangedEventHandler(ByVal e As EventArgs)

   Public Sub AssignProperty(Of T)(ByRef oldValue As T, ByVal proposedValue As T, _
         ByVal onChanging As OnPropertyChangingEventHandler(Of T), _
         ByVal onChanged As OnPropertyChangedEventHandler)
      ' Nothing to do if the new value is the same as the old value.
      If Object.Equals(oldValue, proposedValue) Then Exit Sub
      ' Invoke the OnChangingXXXX method, exit if subscribers canceled the assignment.
      Dim e As New PropertyChangingEventArgs(Of T)(proposedValue)
      onChanging.DynamicInvoke(e)
      If e.Cancel Then Exit Sub
      ' Proceed with assignment, then invoke the OnChangedXXXX method.
      oldValue = proposedValue
      onChanged.DynamicInvoke(EventArgs.Empty)
   End Sub
End Module
