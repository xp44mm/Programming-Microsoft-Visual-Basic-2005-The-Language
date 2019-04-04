Imports AttributeLibrary

Public Module TestBenchmarkModule

   <Benchmark("Concatenation", NormalizationFactor:=100)> _
   Sub TestStringBuilder()
      Dim sb As New System.Text.StringBuilder()
      For i As Integer = 1 To 1000000
         sb.Append(i)
      Next
   End Sub

   <Benchmark("Concatenation")> _
   Sub TestString()
      Dim s As String = ""
      For i As Integer = 1 To 10000
         s &= i.ToString()
      Next
   End Sub

   <Benchmark("Division", Name:="Integer division")> _
   Function TestIntegerDivision() As Integer
      Dim res As Integer
      For i As Integer = 1 To 10000000
         res = 1000000 \ i
      Next
      Return res
   End Function

   <Benchmark("Division", Name:="Long division")> _
   Function TestLongDivision() As Long
      Dim res As Long
      For i As Integer = 1 To 10000000
         res += 1000000 \ i
      Next
      Return res
   End Function

   <Benchmark("Division", Name:="Double division")> _
   Function TestDoubleDivision() As Double
      Dim res As Double
      For i As Integer = 1 To 10000000
         res += 1000000 / i
      Next
      Return res
   End Function


End Module
