Public Class TraceFilterByThreadID
   Inherits TraceFilter

   Dim threadId As Integer

   Sub New(ByVal threadId As Integer)
      ' Remember the thread ID passed to the constructor.
      Me.threadId = threadId
   End Sub

   Public Overrides Function ShouldTrace(ByVal cache As TraceEventCache, _
      ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer, _
      ByVal formatOrMessage As String, ByVal args() As Object, ByVal data1 As Object, _
      ByVal data() As Object) As Boolean
      ' Return true only if thread ID is the one passed to the constructor.
      Return (cache.ThreadId = Me.threadId)
   End Function
End Class
