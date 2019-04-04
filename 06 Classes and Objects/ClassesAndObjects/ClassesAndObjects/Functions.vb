Module Functions
   Function Sum(ByVal n1 As Long, ByVal n2 As Long) As Long
      Return n1 + n2
   End Function
   Function Sum(ByVal n1 As Single, ByVal n2 As Single) As Single
      Return n1 + n2
   End Function

   Sub ClearValue(ByRef arg As String)
      arg = ""
   End Sub
   Sub ClearValue(ByRef arg As Long)
      arg = 0
   End Sub
   Sub ClearValue(ByRef arg As Double)
      arg = 0
   End Sub

End Module
