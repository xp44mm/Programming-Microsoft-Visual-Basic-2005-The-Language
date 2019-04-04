Imports System.Reflection
Imports AttributeLibrary

Module BenchmarkModule

   ' ---------------------------------------------------------------
   ' WARNING: This program requires that you pass an argument when 
   ' you run it from the prompt window. You can test it inside VS2005 by
   ' uncommenting the first line after ensuring that the path 
   ' points to TestApplication.exe
   ' ---------------------------------------------------------------

   Sub Main(ByVal args() As String)

      ' args = New String() {"D:\Books\Programming VBNET 2005\Code\19 Custom Attributes\TestCustomAttributes\TestApplication\bin\TestApplication.exe"}

      ' Parse the assembly whose path is passed as an argument.
      Dim asm As [Assembly] = [Assembly].LoadFile(args(0))
      ' Search all methods marked with the Benchmark attribute, sorted by their Group.
      Dim attrList As New SortedDictionary(Of BenchmarkAttribute, MethodInfo)

      ' Iterate over all public and private static methods of all types.
      For Each type As Type In asm.GetTypes()
         For Each mi As MethodInfo In type.GetMethods(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Static)
            ' Extract the attribute associated with each member.
            Dim attr As BenchmarkAttribute = DirectCast(Attribute.GetCustomAttribute(mi, GetType(BenchmarkAttribute)), BenchmarkAttribute)
            ' This must be a Sub that takes no arguments.
            If attr IsNot Nothing AndAlso mi.GetParameters().Length = 0 Then
               ' Benchmark name defaults to method name.
               If attr.Name.Length = 0 Then attr.Name = mi.Name
               attrList.Add(attr, mi)
            End If
         Next
      Next

      Dim lastGroup As String = Nothing
      Dim timingList As New SortedDictionary(Of Long, BenchmarkAttribute)
      ' Display the report header.
      Console.WriteLine("{0,-20}{1,-30}{2,14}{3,12}", "Group", "Test", "Seconds", "Rate")
      Console.Write(New String("-"c, 78))

      ' Run all tests, sorted by their group.
      For Each kvp As KeyValuePair(Of BenchmarkAttribute, MethodInfo) In attrList
         Dim attr As BenchmarkAttribute = kvp.Key
         Dim mi As MethodInfo = kvp.Value

         ' Show a blank line if this is a new group.
         If attr.Group <> lastGroup Then
            DisplayGroupResult(timingList)
            Console.WriteLine()
            lastGroup = attr.Group
            timingList.Clear()
         End If

         ' Invoke the method.
         Dim sw As Stopwatch = Stopwatch.StartNew()
         mi.Invoke(Nothing, Nothing)
         sw.Stop()
         ' Remember total timing, keeping normalization factor into account.
         timingList.Add(CLng(sw.ElapsedTicks / attr.NormalizationFactor), attr)
      Next
      ' Display result of the last group.
      DisplayGroupResult(timingList)
   End Sub

   ' Helper routine that displays all the timings in a group
   Private Sub DisplayGroupResult(ByVal timingList As SortedDictionary(Of Long, BenchmarkAttribute))
      If timingList.Count = 0 Then Exit Sub
      Dim bestTime As Long = -1
      For Each kvp As KeyValuePair(Of Long, BenchmarkAttribute) In timingList
         ' The first timing in the sorted collection is also the best timing.
         If bestTime < 0 Then bestTime = kvp.Key
         Dim rate As Double = kvp.Key / bestTime
         Console.WriteLine("{0,-20}{1,-30}{2,14:N4}{3,12:N2}", kvp.Value.Group, kvp.Value.Name, kvp.Key / 100000000, rate)
      Next
   End Sub
End Module
