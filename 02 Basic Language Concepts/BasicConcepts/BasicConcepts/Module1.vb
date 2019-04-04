Imports System.Text.RegularExpressions

Module Module1

   Sub Main(ByVal args() As String)
      ' ShowFactorial()
      'TestClass()
      'TestInheritedClass()
      'CompareReferenceAndValueTypes()
      'BlockVariables()
      'DivisionBenchmark()
      'LikeOperatorBenchmark()
      'BitwiseOperators()
      'ShiftOperators()
      'GetTypeOperator()
      'TestArrays()
   End Sub

   Sub ShowFactorial()
      Dim res As Double = Factorial(10)
      Console.WriteLine(res)
   End Sub

   Sub TestClass()
      Dim pers As New Person()
      pers.FirstName = "John"
      pers.LastName = "Doe"
      Console.WriteLine(pers.CompleteName)   ' => John Doe
   End Sub

   Sub TestInheritedClass()
      Dim empl As New Employee("John", "Doe")
      Console.WriteLine(empl.CompleteName)     ' => John Doe
      Console.WriteLine(empl.ReverseName)      ' => Doe, John
   End Sub

   Sub TestSharedMembers()
      ' First technique: using the class name as a prefix 
      Console.WriteLine(Person.InstanceCount)    ' => 0 
      ' Second technique: using an existing instance variable
      Dim pers As New Person("John", "Doe")
      Console.WriteLine(Person.InstanceCount)      ' => 1
   End Sub

   Sub CompareReferenceAndValueTypes()
      ' Creation is similar, but structures don’t require New.
      Dim aPersonObject As New Person
      Dim aPersonStruct As New PersonStruct         ' New is optional.

      ' Assignment to members is identical.
      aPersonObject.FirstName = "John"
      aPersonObject.LastName = "Doe"
      aPersonStruct.FirstName = "John"
      aPersonStruct.LastName = "Doe"

      ' Method and property invocation is also identical.
      Console.WriteLine(aPersonObject.CompleteName())         ' => John Doe
      Console.WriteLine(aPersonStruct.CompleteName())         ' => John Doe

      ' Assignment to a variable of the same type has different effects.
      Dim aPersonObject2 As Person
      aPersonObject2 = aPersonObject
      ' Classes are reference types; hence, the new variable receives
      ' a pointer to the original object.
      aPersonObject2.FirstName = "Ann"
      ' The original object has been affected.
      Console.WriteLine(aPersonObject.FirstName)    ' => Ann 

      Dim aPersonStruct2 As PersonStruct
      aPersonStruct2 = aPersonStruct
      ' Structures are value types; hence, the new variable receives
      ' a copy of the original structure.
      aPersonStruct2.FirstName = "Ann"
      ' The original structure hasn’t been affected.
      Console.WriteLine(aPersonStruct.FirstName)    ' => John
   End Sub

   Sub BlockVariables()
      For i As Integer = 1 To 2
         Dim y As Long
         For j As Integer = 1 To 2
            y = y + 1
            Console.WriteLine(y)
         Next
      Next
   End Sub

   Sub DivisionBenchmark()
      Dim arr(10000000) As Double
      For i As Integer = 0 To UBound(arr)
         arr(i) = i
      Next

      ' Divide all the elements of an array by 125.
      ' (This code assumes that arr is an initialized Double array.)
      Dim sw As New Stopwatch
      sw.Start()
      Dim factor As Double = 1 / 125
      For i As Integer = 0 To arr.Length - 1
         arr(i) = arr(i) * factor
      Next
      sw.Stop()
      Console.WriteLine("Multiplication: {0} milliseconds", sw.ElapsedMilliseconds)


      sw = New Stopwatch()
      sw.Start()
      factor = 125
      For i As Integer = 0 To arr.Length - 1
         arr(i) = arr(i) / factor
      Next
      sw.Stop()
      Console.WriteLine("Division: {0} milliseconds", sw.ElapsedMilliseconds)
   End Sub

   Sub TestLikeOperator()
      Dim value As String = "AB123"
      Dim ok As Boolean

      ' The Like operator is affected by the current Option Compare setting.

      ' Check that a string consists of "AB" followed by three digits.
      If value Like "AB###" Then ok = True ' e.g., "AB123"
      ' Check that a string starts with "ABC" and ends with "XYZ" chars.
      If value Like "ABC*XYZ" Then ok = True ' e.g., "ABCDEFGHIVWXYZ"
      ' Check that a string starts with "1", ends with "X", and includes 5 chars.
      If value Like "1???X" Then ok = True ' e.g., "1234X" or "1uvwx"

      ' One of the letters A,B,C followed by three digits
      If value Like "[A-C]###" Then ok = True ' e.g., "A123" or "c456"
      ' Three letters, the first one must be a vowel 
      If value Like "[AEIOU][A-Z][A-Z]" Then ok = True ' e.g., "IVB" or "OOP"
      ' At least three characters, the first one can't be a digit
      ' Note: a leading exclamation point (!) excludes a range.
      If value Like "[!0-9]??*" Then ok = True ' e.g., "K12BC" or "ABHIL"

      ' Only alphabetical characters
      If Not (value Like "*[!A-Za-z]*") Then ok = True
      ' Only digits
      If Not (value Like "*[!0-9]*") Then ok = True
      ' Any character, but no consecutive punctuation symbols
      If Not (value Like "*[:;.,][:;.,]*") Then ok = True
   End Sub

   Sub LikeOperatorBenchmark()
      Dim s As String = "ABCDE1234"
      Dim count As Integer = 0

      Dim sw As New Stopwatch
      sw.Start()
      For i As Integer = 1 To 1000000
         If s Like "A????####" Then count = count + 1
      Next
      sw.Stop()
      Console.WriteLine("Like operator: {0} milliseconds", sw.ElapsedMilliseconds)

      sw = New Stopwatch
      sw.Start()
      Dim re As New Regex("^A....\d\d\d\d$")
      For i As Integer = 1 To 1000000
         If re.IsMatch(s) Then count = count + 1
      Next
      sw.Stop()
      Console.WriteLine("Regular expressions: {0} milliseconds", sw.ElapsedMilliseconds)

      sw = New Stopwatch
      sw.Start()
      re = New Regex("^A....\d\d\d\d$", RegexOptions.Compiled)
      For i As Integer = 1 To 1000000
         If re.IsMatch(s) Then count = count + 1
      Next
      sw.Stop()
      Console.WriteLine("Compiled Regular expressions: {0} milliseconds", sw.ElapsedMilliseconds)

      sw = New Stopwatch
      sw.Start()
      For i As Integer = 1 To 1000000
         If s.Length = 9 AndAlso s.Chars(0) = "A"c _
            AndAlso Char.IsDigit(s.Chars(5)) _
            AndAlso Char.IsDigit(s.Chars(6)) _
            AndAlso Char.IsDigit(s.Chars(7)) _
            AndAlso Char.IsDigit(s.Chars(8)) Then count = count + 1
      Next
      sw.Stop()
      Console.WriteLine("Char methods: {0} milliseconds", sw.ElapsedMilliseconds)
   End Sub

   Sub BitwiseOperators()
      ' Test the rightmost (least significant) bit.
      Dim number As Integer = 12345
      If (number And 1) = 1 Then Console.WriteLine("Number is odd.")

      ' Clear the last eight bits (two equivalent ways).
      number = number And &HFFFFFF00
      number = number And Not 255

      ' Set the last four bits.
      number = number Or 15

      ' Flip the most significant bit.
      number = number Xor &H10000000

      ' Round down to the nearest even number.
      If (number Mod 2) = 1 Then number = number - 1
      ' Alternative way (just clears the least significant bit)
      number = number And Not 1

      ' Round up to the nearest odd number.
      If (number Mod 2) = 0 Then number = number + 1
      ' Alternative way (just sets the least significant bit)
      number = number Or 1

      Dim a, b, c As Integer, ok As Boolean

      ' Test whether all the numbers in a group are zero.
      If a = 0 And b = 0 And c = 0 Then ok = True
      ' Alternative way (relies on the fact that the result of Or is zero
      ' only if both its operands are zero)
      If (a Or b Or c) = 0 Then ok = True

      ' Test whether all numbers in a group are positive.
      If a >= 0 And b >= 0 And c >= 0 Then ok = True
      ' Alternative way (relies on the fact the sign bit of the result of Or
      ' is zero only if the sign bit of all its operands is also zero)
      If (a Or b Or c) >= 0 Then ok = True

      ' Test whether all numbers in a group are negative.
      If a < 0 And b < 0 And c < 0 Then ok = True
      ' Alternative way (relies on the fact the sign bit of the result of And
      ' is set only if the sign bit of all its operands is also set)
      If (a And b And c) < 0 Then ok = True

      ' Test whether two numbers have the same sign.
      If (a >= 0 And b >= 0) Or (a < 0 And b < 0) Then ok = True
      ' Alternative way (relies on the fact that the sign bit of the result from 
      ' a Xor operator is zero if operands have same sign)
      If (a Xor b) < 0 Then ok = True
   End Sub

   Sub ShiftOperators()
      Console.WriteLine(34 << 2)    ' => 136
      Console.WriteLine(34 >> 2)    ' => 8
      Dim i As Short = -8     ' –8 decimal = 11111111 11111000 binary
      Console.WriteLine(i >> 2)   ' –2 decimal = 11111111 11111110 binary
      ' Notice the "S" suffix to force a Short hex constant.
      Console.WriteLine(i >> 2 And &H4FFFS)   ' 20478 decimal = 00111111 11111110 binary

      Console.WriteLine(2 << 33)         ' => You expect 0, but it is 4. 
   End Sub

   Sub GetTypeOperator()
      Dim aString As String = "123"
      Dim ty As Type = aString.GetType()
      ' Display the full .NET name of the string type.
      Console.WriteLine(ty.FullName)                ' => System.String
      ' Enumerate all the public instance methods of the String type.
      For Each mi As System.Reflection.MethodInfo In ty.GetMethods()
         Console.WriteLine(mi.Name)
      Next
   End Sub

   Sub TestArrays()
      ' Declare and create an array of five integers.
      Dim arr() As Integer = {0, 1, 2, 3, 4}

      ' Declare and create a two-dimensional array of strings
      ' with two rows and four columns.
      Dim arr2(,) As String = {{"00", "01", "02", "03"}, _
                                {"10", "11", "12", "13"}}

      ' This code assumes that Option Strict is Off.
      Dim arr3() As Integer = {0, 111, 222, 333}
      ' Create a copy (clone) of the array.
      Dim arr4() As Integer = DirectCast(arr3.Clone(), Integer())
      ' Modify an element in the new array.
      arr4(1) = 9999
      ' Check that the original array hasn’t been affected.
      Console.WriteLine(arr3(1))           ' => 111

   End Sub
End Module
