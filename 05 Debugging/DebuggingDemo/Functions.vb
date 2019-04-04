Imports System.IO
Imports System.Reflection

Module Functions
   Sub DisplayExceptionInfo(ByVal e As Exception)
      ' Display the error message.
      Console.WriteLine(e.Message)
      Dim res As String = ""
      Dim st As New StackTrace(e, True)
      For i As Integer = 0 To st.FrameCount - 1
         ' Get the ith stack frame and the corresponding method.
         Dim sf As StackFrame = st.GetFrame(i)
         Dim mi As MemberInfo = sf.GetMethod
         ' Append the type and method name.
         res &= mi.DeclaringType.FullName & "." & mi.Name & " ("
         ' Append information about the position in the source file
         ' (but only if Debug information is available).
         If sf.GetFileName <> "" Then
            res &= String.Format("{0}, Line {1}, Col {2},", _
               sf.GetFileName, sf.GetFileLineNumber, sf.GetFileColumnNumber)
         End If
         ' Append information about offset in MSIL code, if available.
         If sf.GetILOffset <> StackFrame.OFFSET_UNKNOWN Then
            res &= String.Format("IL offset {0},", sf.GetILOffset)
         End If
         ' Append information about offset in native code and display.
         res &= " native offset " & sf.GetNativeOffset & ")"
         Console.WriteLine(res)
      Next
   End Sub

   Public Function CheckCaller(ByVal methodName As String, _
      Optional ByVal typeName As String = Nothing, _
      Optional ByVal immediateOnly As Boolean = False) As Boolean
      ' Create a stack trace, skipping both current method and the method that invoked it.
      Dim st As New StackTrace(2)
      For i As Integer = 0 To st.FrameCount - 1
         ' Retrieve the MethodInfo object describing the calling method.
         Dim sf As StackFrame = st.GetFrame(i)
         Dim mi As MethodInfo = sf.GetMethod()
         ' Exit if method name matches. If typeName was provided, check it as well.
         If mi.Name = methodName AndAlso (typeName Is Nothing OrElse mi.ReflectedType.FullName = typeName) Then Return True
         ' Exit and return false if only the immediate caller had to be checked.
         If immediateOnly Then Exit For
      Next
      Return False
   End Function


End Module
