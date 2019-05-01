Imports System.Globalization
Imports System.IO
Imports System.Text

Module Module1

   Sub Main()
      'TestBoxing()
      'TestBoxing2()
      'ComparingAndSearchingStrings()
      'ModifyingAndExtractingStrings()
      'StringAndCharArrays()
      'StringOptimizations()
      'TestCultureInfo()
      'TestEncodingType()
      'FormattingNumericValues()
      'FormattingDateValues()
      'CharType()
      'StringBuilderType()
      'BenchmarkStringbuilder()
      'NumericConversions()
      'FormattingNumbers()
      'ParsingStringsIntoNumbers()
      'ConvertType()
      'RandomNumberGenerator()
      'DateTimeType()
      'FormattingDates()
      'WorkingWithTimeZones()
      'TimeZoneType()
      'GuidType()
      'WorkingWithEnums()
   End Sub

   ' This procedure benchmarks calls to empty routines, one requiring boxing and the other one
   ' not requiring it

   Sub TestBoxing()
      Dim i As Integer
      Dim start As Date
      Dim res As Integer

      ' benchmark the version that does NOT use boxing
      start = Now
      For i = 1 To 100000000
         res = GetInteger(i)
      Next
      Console.WriteLine("Without boxing: " & Now.Subtract(start).ToString)

      ' benchmark the version that uses boxing and unboxing
      start = Now
      For i = 1 To 100000000
         res = CInt(GetObject(i))
      Next
      Console.WriteLine("With boxing: " & Now.Subtract(start).ToString)
   End Sub

   ' support procedures for TestBoxing

   Private Function GetInteger(ByVal n As Integer) As Integer
      Return n
   End Function

   Private Function GetObject(ByVal o As Object) As Object
      Return o
   End Function

   ' test code optimized for boxing

   Sub TestBoxing2()
      Dim i, j As Integer
      Dim start As Date

      ' The version that does NOT cache the value type in a reference variable.
      start = Now
      For i = 1 To 1000
         For j = 1 To 100000
            GetObject2(i, j)
         Next
      Next
      Console.WriteLine("Non-optimized: " & Now.Subtract(start).ToString)
      GC.Collect() : GC.WaitForPendingFinalizers()

      ' The version that caches the value type in a reference variable.
      start = Now
      For i = 1 To 1000
         ' Cache the value type in an Object variable.
         Dim o As Object = i
         For j = 1 To 100000
            GetObject2(o, j)
         Next
      Next
      Console.WriteLine("Should be optimized, but it's slower: " & Now.Subtract(start).ToString)
   End Sub

   Private Function GetObject2(ByVal o As Object, ByVal o2 As Object) As Object
      Return o
   End Function

   Sub ComparingAndSearchingStrings()
      Dim s1 As String = "ABC"
      Dim s2 As String = "abcde"

      ' Compare two strings in case-sensitive mode, using Unicode values.
      Dim match As Boolean = String.Equals(s1, s2)
      ' Compare two strings in case-insensitive mode, using the current locale.
      match = String.Equals(s1, s2, StringComparison.CurrentCultureIgnoreCase)
      ' Compare two strings in case-sensitive mode, using the invariant locale.
      match = String.Equals(s1, s2, StringComparison.InvariantCulture)
      ' Compare the numeric Unicode values of all the characters in the two strings.
      match = String.Equals(s1, s2, StringComparison.Ordinal)

      ' Compare two strings in case-sensitive mode, using the current culture.
      Dim res As Integer = String.Compare(s1, s2)
      Select Case res
         Case -1 : Console.WriteLine("s1 < s2")
         Case 0 : Console.WriteLine("s1 = s2")
         Case 1 : Console.WriteLine("s1 > s2")
      End Select

      ' Compare the first 10 characters of two strings in case-insensitive mode.
      ' (Second and fourth arguments are the index of first char to compare.)
      res = String.Compare(s1, 0, s2, 0, 10, True)

      ' Compare two strings using the local culture in case-insensitive mode.
      res = String.Compare(s1, s2, StringComparison.CurrentCultureIgnoreCase)
      ' Compare two substrings using the invariant culture in case-sensitive mode.
      res = String.Compare(s1, 0, s2, 0, 10, StringComparison.InvariantCulture)
      ' Compare two strings by the numeric code of their characters.
      res = String.Compare(s1, s2, StringComparison.Ordinal)

      ' Compare two strings using the local culture in case-insensitive mode.
      res = StringComparer.CurrentCultureIgnoreCase.Compare(s1, s2)
      ' Compare two strings using the invariant culture in case-sensitive mode.
      res = StringComparer.InvariantCulture.Compare(s1, s2)

      ' These two statements are equivalent, but only the latter works in Visual Basic 2005.
      If s1 Is Nothing OrElse s1.Length = 0 Then Console.WriteLine("Empty string")
      If String.IsNullOrEmpty(s1) Then Console.WriteLine("Empty string")

      ' The Contains method works only in case-sensitive mode.
      Dim s As String = "ABCDEFGHI ABCDEF"
      Dim found As Boolean = s.Contains("BCD")           ' => True
      found = s.Contains("bcd")                          ' => False

      Dim pos As Integer = s.IndexOf("CDE")            ' => 2
      pos = s.LastIndexOf("CDE")                       ' => 12
      ' Both IndexOf and LastIndexOf are case sensitive.
      pos = s.IndexOf("cde")

      pos = s.LastIndexOf("cde", StringComparison.CurrentCultureIgnoreCase)

      match = s.StartsWith("ABC")                      ' => True
      match = s.EndsWith("def")                        ' => False 

      ' Both these statements assign True to the variable.
      match = s.StartsWith("abc", StringComparison.CurrentCultureIgnoreCase)
      match = s.EndsWith("CDE", True, CultureInfo.InvariantCulture)

      Dim chars() As Char = {"D"c, "F"c, "I"c}
      pos = s.IndexOfAny(chars)                     ' => 3
      pos = s.LastIndexOfAny(chars)                 ' => 15
      pos = s.IndexOfAny(chars, 6)                  ' => 8
      pos = s.IndexOfAny(chars, 6, 2)               ' => -1

   End Sub

   Sub ModifyingAndExtractingStrings()
      Dim s As String = "ABCDEFGHI ABCDEF"
      ' Extract the substring after the 11th character. Same as Mid(s, 11)
      Dim result As String = s.Substring(10)        ' => ABCDEF
      ' Extract 4 characters after the 11th character. Same as Mid(s, 11, 4)
      result = s.Substring(10, 4)                   ' => ABCD
      ' Extract the last 4 characters. Same as Right(s, 4)
      result = s.Substring(s.Length - 4)            ' => CDEF

      result = s.Insert(4, "-123-")                 ' => ABCD-123-EFGHI ABCDEF
      result = s.Remove(4, 3)                       ' => ABCDHI ABCDEF

      ' Extract the first 4 characters. Same as Left(s, 4)
      result = s.Remove(4)                          ' => ABCD

      Dim t As String = "  001234.560  "
      result = t.Trim()                            ' => "001234.560"
      result = t.TrimStart(" "c, "0"c)             ' => "1234.560  "
      result = t.TrimEnd(" "c, "0"c)               ' => "  001234.56"
      result = t.Trim(" "c, "0"c)                  ' => "1234.56"

      ' Right-align a number in a field that is 8-char wide.
      Dim number As Integer = 1234
      result = number.ToString().PadLeft(8)        ' => "    1234"

      ' Convert the s string to lowercase, using the current culture's rules.
      result = s.ToLower()
      ' Convert the s string to uppercase, using the invariant culture's rules.
      result = s.ToUpperInvariant()
   End Sub

   Sub StringAndCharArrays()
      Dim s1 As String = "file"
      Dim s2 As String = "life"
      ' Transform both strings to an array of characters.
      Dim chars1() As Char = s1.ToCharArray()
      Dim chars2() As Char = s2.ToCharArray()
      ' Sort both arrays.
      Array.Sort(chars1)
      Array.Sort(chars2)
      ' Build two new strings from the sorted arrays, and compare them.
      Dim sorted1 As New String(chars1)
      Dim sorted2 As New String(chars2)
      ' Compare them. (You can use case-insensitive comparison, if necessary.) 
      Dim match As Boolean = (String.Compare(sorted1, sorted2) = 0)     ' => True

      Dim x As String = "Hey, Visual Basic Rocks!"
      Dim arr() As String = x.Split(" "c, ","c, "."c)
      ' The result contains the words "Hey", "", "Visual", "Basic", "Rocks!"
      Dim numOfWords As Integer = arr.Length            ' => 5
      ' Same as before, but no more than 100 elements, and drop empty items.
      Dim separators() As Char = {" "c, ","c, "."c}
      Dim arr2() As String = x.Split(separators, 100, StringSplitOptions.RemoveEmptyEntries)
      ' The result contains the words "Hey", "Visual", "Basic", "Rocks!"
      numOfWords = arr2.Length                          ' => 4 

      ' Count the number of nonempty lines in a text file.
      Dim crlfs() As String = {ControlChars.CrLf}
      Dim lines() As String = File.ReadAllText("book.txt").Split(crlfs, StringSplitOptions.None)
      Dim numOfLines As Integer = lines.Length

      ' Reassemble the string by adding CR-LF pairs, but skip the first array element.
      Dim newText As String = String.Join(ControlChars.CrLf, lines, 1, lines.Length - 1)

   End Sub

   Sub StringOptimizations()
      Dim s1 As String = "1234" & "5678"
      Dim s2 As String = "12345678"
      Console.WriteLine(s1 Is s2)                     ' => True

      ' Attempt to modify the S1 string using the Mid statement.
      Mid(s1, 2, 1) = "x"
      ' Prove that a new string was created behind the scenes.
      Console.WriteLine(s1 Is s2)                     ' => False

      ' Prove that no optimization is performed at run time.
      s1 = "1234"
      s1 &= "5678"
      s2 = "12345678"
      ' These two variables point to different String objects.
      Console.WriteLine(s1 Is s2)                     ' => False

      s1 = "ABCD"
      s1 &= "EFGH"
      ' Move S1 to the intern pool.
      s1 = String.Intern(s1)
      ' Assign S2 a string constant (that we know is in the pool).
      s2 = "ABCDEFGH"
      ' These two variables point to the same String object.
      Console.WriteLine(s1 Is s2)                     ' => True
   End Sub

   Sub TestCultureInfo()
      ' Get information about the current locale.
      Dim ci As CultureInfo = CultureInfo.CurrentCulture
      ' Assuming that the current language is Italian, we get:
      Console.WriteLine(ci.Name)                            ' => it
      Console.WriteLine(ci.EnglishName)                     ' => Italian
      Console.WriteLine(ci.NativeName)                      ' => italiano
      Console.WriteLine(ci.LCID)                            ' => 16
      Console.WriteLine(ci.TwoLetterISOLanguageName)        ' => it
      Console.WriteLine(ci.ThreeLetterISOLanguageName)      ' => ita
      Console.WriteLine(ci.ThreeLetterWindowsLanguageName)  ' => ITA

      Dim ti As TextInfo = ci.TextInfo
      Console.WriteLine(ti.ANSICodePage)                    ' => 1252
      Console.WriteLine(ti.EBCDICCodePage)                  ' => 20280
      Console.WriteLine(ti.OEMCodePage)                     ' => 850
      Console.WriteLine(ti.ListSeparator)                   ' => ;
      Console.WriteLine()

      ' How do you spell "Sunday" in German?
      ' First create a CultureInfo object for German/Germany.
      ' (Note that you must pass a string in the form "locale-COUNTRY" if
      ' a given language is spoken in multiple countries.)
      Dim ciDe As New CultureInfo("de-DE")
      ' Next get the corresponding DateTimeFormatInfo object.
      Dim dtfi As DateTimeFormatInfo = ciDe.DateTimeFormat
      ' Here's the answer.
      Console.WriteLine(dtfi.GetDayName(DayOfWeek.Sunday))   ' => Sonntag
      Console.WriteLine()

      ' Get info on all the installed cultures.
      Dim ciArr() As CultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures)
      ' Print abbreviation and English name of each culture.
      For Each c As CultureInfo In ciArr
         Console.WriteLine("{0} ({1})", c.Name, c.EnglishName)
      Next
      Console.WriteLine()

      Dim ci1 As CultureInfo = CultureInfo.GetCultureInfo("it-IT")
      Dim ci2 As CultureInfo = CultureInfo.GetCultureInfo("it-IT")
      ' Prove that the second call returned a cached object.
      Console.WriteLine(ci1 Is ci2)                         ' => True
      Console.WriteLine()

      ' Create a CultureInfo object for Canadian French. (Use a cached object if possible.)
      Dim ciFr As CultureInfo = CultureInfo.GetCultureInfo("fr-CA")
      ' Convert a string to title case using Canadian French rules.
      Dim s As String = ciFr.TextInfo.ToTitleCase("abcde efghi")

      ' Compare two strings in case-insensitive mode according to rules of Italian language.
      Dim s1 As String = "cioè"
      Dim s2 As String = "CIOÈ"
      ' You can create a CultureInfo object on the fly.
      If String.Compare(s1, s2, True, New CultureInfo("it")) = 0 Then
         Console.WriteLine("s1 = s2")
      End If

      If String.Compare(s1, 1, s2, 1, 4, True, New CultureInfo("it")) = 1 Then
         Console.WriteLine("s1's first four chars are greater than s2's")
      End If
   End Sub

   Sub TestEncodingType()
      Dim text As String = "A Unicode string with accented vowels: àèéìòù"
      Dim uni As Encoding = Encoding.Unicode
      Dim uniBytes() As Byte = uni.GetBytes(text)
      Dim ascii As Encoding = Encoding.ASCII
      Dim asciiBytes() As Byte = Encoding.Convert(uni, ascii, uniBytes)

      ' Convert the ASCII bytes back to a string.
      Dim asciiText As String = ascii.GetChars(asciiBytes)
      Console.WriteLine(asciiText)  ' => A Unicode string with accented vowels: ?????
      Console.WriteLine()

      For Each ei As EncodingInfo In Encoding.GetEncodings
         Console.WriteLine("Name={0}, DisplayName={1}, CodePage={2}", _
            ei.Name, ei.DisplayName, ei.CodePage)
      Next
   End Sub

   Sub FormattingNumericValues()
      ' Print the value of a string variable.
      Dim xyz As String = "foobar"
      Dim msg As String
      msg = String.Format("The value of {0} variable is {1}.", "XYZ", xyz)
      ' => The value of XYZ variable is foobar.
      Console.WriteLine(msg)

      ' Format a Currency according to current locale.
      msg = String.Format("Total is {0:C}, balance is {1:C}", 123.45, -67)
      ' => Total is $123.45, balance is ($67.00)
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:N}", 123456.78)   ' => Total is 123,456.78
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:N4}", 123456.785555)   ' => Total is 123,456.7856
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:D8}", 123456)          ' => Total is 00123456
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:F3}", 123.45678)       ' => Total is 123.457
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:E}", 123456.789)   ' => Total is 1.234568E+005
      Console.WriteLine(msg)
      msg = String.Format("Total is {0:E3}", 123456.789)  ' => Total is 1.235E+005
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:G}", 123456)   ' => Total is 123456
      Console.WriteLine(msg)
      msg = String.Format("Total is {0:G4}", 123456)  ' => Total is 1.235E+05
      Console.WriteLine(msg)

      msg = String.Format("Percentage is {0:P}", 0.123)   ' => Total is 12.30 %
      Console.WriteLine(msg)

      ' The number of digits you pass after the "R" character is ignored.
      msg = String.Format("Value of PI is {0:R}", Math.PI)
      ' => Value of PI is 3.1415926535897931
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:X8}", 65535)   ' => Total is 0000FFFF
      Console.WriteLine(msg)

      msg = String.Format("Total is {0:##,###.00}", 1234.567)   ' => Total is 1,234.57
      Console.WriteLine(msg)
      msg = String.Format("Percentage is {0:##.000%}", 0.3456)   ' => Percentage is 34.560%
      Console.WriteLine(msg)

      ' An example of prescaler
      msg = String.Format("Length in {0:###,.00 }", 12344)     ' => Total is 12.34
      Console.WriteLine(msg)

      ' Two examples of exponential format
      msg = String.Format("Total is {0:#.#####E+00}", 1234567) ' => Total is 1.23457E+06
      Console.WriteLine(msg)
      msg = String.Format("Total is {0:#.#####E0}", 1234567)   ' => Total is 1.23457E6
      Console.WriteLine(msg)

      ' Two examples with separate sections
      msg = String.Format("Total is {0:##;<##>}", -123)        ' => Total is <123>
      Console.WriteLine(msg)
      msg = String.Format("Total is {0:#;(#);zero}", 1234567)  ' => Total is 1234567
      Console.WriteLine(msg)

      Dim n1 As Integer = 10
      Dim n2 As Integer = 11
      If n1 > n2 Then
         msg = "n1 is greater than n2"
      ElseIf n1 < n2 Then
         msg = "n1 is less than n2"
      Else
         msg = "n1 is equal to n2"
      End If
      Console.WriteLine(msg)

      msg = String.Format("n1 is {0:greater than;less than;equal to} n2", n1 - n2)
      Console.WriteLine(msg)

      ' Build a table of numbers, their square, and their square root.
      ' This prints the header of the table.
      Console.WriteLine("{0,-5} | {1,7} | {2,10:N2}", "N", "N^2", "Sqrt(N)")
      For n As Integer = 1 To 100
         ' N is left-aligned in a field 5-char wide, 
         ' N^2 is right-aligned in a field 7-char wide, and Sqrt(N) is displayed with 
         ' 2 decimal digits and is right-aligned in a field 10-char wide.
         Console.WriteLine("{0,-5} | {1,7} | {2,10:N2}", n, n ^ 2, Math.Sqrt(n))
      Next

      Console.WriteLine(" {{{0}}}", 123)          ' => {123}
   End Sub

   Sub FormattingDateValues()
      Dim aDate As Date = #5/17/2005 3:54:00 PM#
      Dim msg As String
      msg = String.Format("Event Date Time is {0:f}", aDate)
      ' => Event Date Time is Tuesday, May 17, 2005 3:54 PM
      Console.WriteLine(msg)

      msg = String.Format("Current year is {0:yyyy}", Now) ' => Current year is 2005
      Console.WriteLine(msg)

      ' Format a date in the format mm/dd/yyyy, regardless of current locale.
      msg = String.Format("{0:MM\/dd\/yyyy}", aDate)   ' => 05/17/2005
      Console.WriteLine(msg)
   End Sub

   Sub CharType()
      ' Check an individual Char value.
      Dim ok As Boolean = Char.IsDigit("1"c)          ' => True
      ' Check the Nth character in a string.
      ok = Char.IsDigit("A123", 0)                    ' => False

      Dim newChar As Char = Char.ToUpper("a"c)                  ' => A
      newChar = Char.ToLower("H"c, New CultureInfo("it-IT"))    ' => h
      Dim loChar As Char = Char.ToLowerInvariant("G"c)          ' => g

      If Char.TryParse("a", newChar) Then
         ' newChar contains the a character.
      End If

      ' Get the Unicode value of a character (same as Asc, AscW).
      Dim uni As Short = Convert.ToInt16("A"c)
      ' Convert back to a character.
      Dim ch As Char = Convert.ToChar(uni)
   End Sub

   Sub StringBuilderType()
      ' Create a StringBuilder object with initial capacity of 1,000 characters.
      Dim sb As New StringBuilder(1000)

      ' Create a comma-delimited list of the first 100 integers.
      For n As Integer = 1 To 100
         ' Note that two Append methods are faster than a single Append, 
         ' whose argument is the concatenation of N and ",".
         sb.Append(n)
         sb.Append(",")
      Next
      ' Insert a string at the beginning of the buffer.
      sb.Insert(0, "List of numbers: ")
      Console.WriteLine(sb)   ' => List of numbers: 1,2,3,4,5,6,…
      Console.WriteLine("Length is {0}.", sb.Length)   ' => Length is 309.
   End Sub

   Sub BenchmarkStringbuilder()
      Dim s As String = ""
      Const TIMES As Integer = 10000
      Dim sw As New Stopwatch()
      sw.Start()
      For i As Integer = 1 To TIMES
         s &= CStr(i) & ","
      Next
      sw.Stop()
      Console.WriteLine("Regular string: {0} milliseconds", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      Dim sb As New StringBuilder(TIMES * 4)
      For i As Integer = 1 To TIMES
         ' Notice how you can merge two Append methods.
         sb.Append(i).Append(",")
      Next
      sw.Stop()
      Console.WriteLine("StringBuilder: {0} milliseconds.", sw.ElapsedMilliseconds)
   End Sub

   Sub NumericConversions()
      ' Convert an integer to hexadecimal.
      Console.WriteLine(1234.ToString("X"))       ' => 4D2
      ' Display PI with 6 digits (in all).
      Dim d As Double = Math.PI
      Console.WriteLine(d.ToString("G6"))         ' => 3.14159

      Dim sngValue As Single = 1.23
      ' Compare the Single variable sngValue with 1.
      ' Note that you must force the argument to Single.
      Select Case sngValue.CompareTo(CSng(1))
         Case 1 : Console.WriteLine("sngValue is > 1")
         Case 0 : Console.WriteLine("sngValue is = 1")
         Case -1 : Console.WriteLine("sngValue is < 1")
      End Select

      ' Display the greatest value you can store in a Double variable.
      Console.WriteLine(Double.MaxValue)      ' => 1.79769313486232E+308

      Console.WriteLine(Single.Epsilon)       ' => 1.401298E-45
      Console.WriteLine(Double.Epsilon)       ' => 4.94065645841247E-324

      ' Any number divided by infinity gives 0.
      Console.WriteLine(1 / Double.PositiveInfinity)     ' => 0
   End Sub

   Sub FormattingNumbers()
      Dim intValue As Integer = 12345
      Console.WriteLine(intValue.ToString("##,##0.00"))  ' => 12,345.00

      Dim ci As New CultureInfo("it-IT")
      Console.WriteLine(intValue.ToString("##,##0.00", ci))    ' => 12.345,00

      ' Format a number with current locale formatting options, but use a comma
      ' for the decimal separator and a space for the thousands separator.
      ' (You need DirectCast because the Clone method returns an Object.)
      Dim nfi As NumberFormatInfo = _
         DirectCast(NumberFormatInfo.CurrentInfo.Clone, NumberFormatInfo)
      ' The nfi object is writable, so you can change its properties.
      nfi.NumberDecimalSeparator = ","
      nfi.NumberGroupSeparator = " "
      ' You can now format a value with the custom NumberFormatInfo object.
      Dim sngValue As Single = 12345.5
      Console.WriteLine(sngValue.ToString("##,##0.00", nfi)) ' => 12 345,50
   End Sub

   Sub ParsingStringsIntoNumbers()
      ' Next line assigns 1234 to the variable.
      Dim shoValue As Short = Short.Parse("1234")

      Dim dblValue As Double = Double.Parse(" 1,234.56E6  ", NumberStyles.Any)
      ' dblValue is assigned the value 1234560000.

      Dim style As NumberStyles = NumberStyles.AllowDecimalPoint _
   Or NumberStyles.AllowLeadingSign
      ' This works and assigns -123.45 to sngValue.
      Dim sngValue As Single = Single.Parse("-123.45", style)
      ' This throws a FormatException because of the thousands separator.
      sngValue = Single.Parse("12,345.67", style)

      ' Parse a string according to Italian rules.
      sngValue = Single.Parse("12.345,67", New CultureInfo("it-IT"))

      Dim intValue As Integer
      If Integer.TryParse("12345", intValue) Then
         ' intValue contains the result of the parse operation.
      Else
         ' The string doesn't contain an integer value in a valid format.
      End If

      style = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowLeadingSign
      Dim aValue As Single
      If Single.TryParse("-12.345,67", style, New CultureInfo("it-IT"), aValue) Then
         ' aValue contains a valid number
      End If
   End Sub

   Sub ConvertType()
      ' Convert the string "123.45" to a Double (same as CDbl function).
      Dim dblValue As Double = Convert.ToDouble("123.45")

      ' Convert a Double value to an integer (same as CInt function).
      Dim intValue As Integer = Convert.ToInt32(dblValue)

      ' Convert from a string holding a binary representation of a number.
      Dim result As Integer = Convert.ToInt32("11011", 2)         ' => 27 
      ' Convert from an octal number.
      result = Convert.ToInt32("777", 8)                          ' => 511
      ' Convert from an hexadecimal number.
      result = Convert.ToInt32("AC", 16)                          ' => 172

      ' Determine the binary representation of a number.
      Dim text As String = Convert.ToString(27, 2)                ' => 11011
      ' Determine the hexadecimal representation of a number. (Note: result is lowercase.)
      text = Convert.ToString(172, 16)                            ' => ac

      ' An array of 16 bytes (two identical sequences of 8 bytes)
      Dim b1() As Byte = {12, 45, 213, 88, 11, 220, 34, 0, _
          12, 45, 213, 88, 11, 220, 34, 0}
      ' Convert it to a Base64 string.
      Dim s64 As String = Convert.ToBase64String(b1)
      Console.WriteLine(s64)
      ' Convert it back to an array of bytes, and display it.
      Dim b2() As Byte = Convert.FromBase64String(s64)
      For Each b As Byte In b2
         Console.Write("{0} ", b)
      Next
      Console.WriteLine()

      ' new in .NET 2.0
      s64 = Convert.ToBase64String(b1, Base64FormattingOptions.InsertLineBreaks)

      ' Convert a value to Double.
      Dim aValue As String = "123.45"
      Console.WriteLine(Convert.ChangeType(aValue, GetType(Double)))
   End Sub

   Sub RandomNumberGenerator()
      ' The argument must be a 32-bit integer.
      Dim rand As New Random(12345)

      ' You need these conversions because the Ticks property
      ' returns a 64-bit value that must be truncated to a 32-bit integer.
      rand = New Random(CInt(Date.Now.Ticks And Integer.MaxValue))

      For i As Integer = 1 To 10
         Console.WriteLine(rand.Next)
      Next
      Console.WriteLine()

      ' Get a value in the range 0 to 1000.
      Dim intValue As Integer = rand.Next(1000)
      ' Get a value in the range 100 to 1,000.
      intValue = rand.Next(100, 1000)

      Dim dblValue As Double = rand.NextDouble()

      ' Get an array of 100 random byte values.
      Dim buffer(100) As Byte
      rand.NextBytes(buffer)
   End Sub

   Sub DateTimeType()
      ' Create a Date value by providing year, month, and day values.
      Dim dt As Date = New Date(2005, 1, 6)           ' January 6, 2005

      ' Provide also hour, minute, and second values.
      dt = New Date(2005, 1, 6, 18, 30, 20)           ' January 6, 2005 6:30:20 PM

      ' Add millisecond value (half a second in this example).
      dt = New Date(2005, 1, 6, 18, 30, 20, 500)

      ' Create a time value from ticks (10 million ticks = 1 second).
      Dim ticks As Long = 20000000                    ' 2 seconds
      ' This is considered the time elapsed from Jan. 1 of year 1.
      dt = New Date(ticks)                            ' 1/1/0001 12:00:02 AM

      dt = New DateTime(2005, 1, 6)
      dt = New Date(2005, 1, 6)
      dt = New DateTime(2005, 1, 6)

      ' The Now property returns the system date and time.
      dt = Date.Now                   ' For example, October 17, 2005 3:54:20 PM
      ' The Today property returns the system date only.
      dt = Date.Today                 ' For example, October 17, 2005 12:00:00 AM

      dt = Date.UtcNow

      ' Is today the first day of the current month?
      If Date.Today.Day = 1 Then Console.WriteLine("First day of month")
      ' How many days have passed since January 1?
      Console.WriteLine(Date.Today.DayOfYear)
      ' Get current time—note that ticks are included.
      Console.WriteLine(Date.Now.TimeOfDay)     ' => 10:39:28.3063680

      ' Tomorrow's date
      dt = Date.Today.AddDays(1)
      ' Yesterday's date
      dt = Date.Today.AddDays(-1)
      ' What time will it be 2 hours and 30 minutes from now?
      dt = Date.Now.AddHours(2.5)

      ' A CPU-intensive way to pause for 5 seconds.
      Dim endTime As Date = Date.Now.AddSeconds(5)
      Do : Loop Until Date.Now > endTime

      ' One Long value is interpreted as a Ticks value.
      Dim ts As TimeSpan = New TimeSpan(13500000)       ' 1.35 seconds
      ' Three integer values are interpreted as hours, minutes, seconds.
      ts = New TimeSpan(0, 32, 20)                      ' 32 minutes, 20 seconds
      ' Four integer values are interpreted as days, hours, minutes, seconds.
      ts = New TimeSpan(1, 12, 0, 0)                    ' 1 day and a half
      ' (Note that arguments aren't checked for out-of-range errors; therefore,
      '  the next statement delivers the same result as the previous one.)
      ts = New TimeSpan(0, 36, 0, 0)                    ' 1 day and a half
      ' A fifth argument is interpreted as a millisecond value.
      ts = New TimeSpan(0, 0, 1, 30, 500)               ' 90 seconds and a half

      ' What will be the time 2 days, 10 hours, and 30 minutes from now?
      dt = Date.Now.Add(New TimeSpan(2, 10, 30, 0))

      ' What was the time 1 day, 12 hours, and 20 minutes ago?
      dt = Date.Now.Subtract(New TimeSpan(1, 12, 20, 0))

      ' How many days, hours, minutes, and seconds have elapsed 
      ' since the beginning of the third millennium?
      Dim startDate As New Date(2001, 1, 1)
      Dim diff As TimeSpan = Date.Now.Subtract(startDate)

      ' Is current date later than October 30, 2005?
      Select Case Date.Today.CompareTo(New Date(2005, 10, 30))
         Case 1   ' Later than Oct. 30, 2005
         Case -1  ' Earlier than Oct. 30, 2005
         Case 0   ' Today is Oct. 30, 2005.
      End Select

      If Date.Now.IsDaylightSavingTime() Then Console.Write("Daylight Saving Time is active")

      ' Test for a leap year.
      Console.WriteLine(Date.IsLeapYear(2000))          ' => True
      ' Retrieve the number of days in a given month.
      Console.WriteLine(Date.DaysInMonth(2000, 2))      ' => 29
   End Sub

   Sub FormattingDates()
      ' This is January 6, 2005 6:30:20.500 PM—U.S. Eastern Time.
      Dim dt As Date = New Date(2005, 1, 6, 18, 30, 20, 500)

      ' Display a date using the LongDatePattern standard format.
      Dim dateText As String = dt.ToString("D")     ' => Thursday, January 06, 2005
      ' Display a date using a custom format.
      dateText = dt.ToString("d-MMM-yyyy")          ' => 6-Jan-2005

      Console.WriteLine(dt.ToShortDateString())     ' => 1/6/2005
      Console.WriteLine(dt.ToLongDateString())      ' => Thursday, January 06, 2005
      Console.WriteLine(dt.ToShortTimeString())     ' => 6:30 PM
      Console.WriteLine(dt.ToLongTimeString())      ' => 6:30:20 PM
      Console.WriteLine(dt.ToFileTime())            ' => 127495062205000000
      Console.WriteLine(dt.ToOADate())              ' => 38358.7710706019
      ' The next two results vary depending on the time zone you're in.
      Console.WriteLine(dt.ToUniversalTime())       ' => 1/7/2005 12:30:20 PM
      Console.WriteLine(dt.ToLocalTime())           ' => 1/6/2005 12:30:20 PM
   End Sub

   Sub ParsingDates()
      Dim dt As Date = Date.Parse("2005/1/6 12:30:20")

      ' Get a writable copy of the current locale's DateTimeFormatInfo object.
      Dim dtfi As DateTimeFormatInfo
      dtfi = CType(DateTimeFormatInfo.CurrentInfo.Clone, DateTimeFormatInfo)
      ' Change date and time separators.
      dtfi.DateSeparator = "-"
      dtfi.TimeSeparator = "."
      ' Now we're ready to parse a date formatted in a nonstandard way.
      dt = Date.Parse("2005-1-6 12.30.20", dtfi)

      ' Prepare to parse (dd/mm/yy) dates, in short or long format.
      dtfi.ShortDatePattern = "d/M/yyyy"
      dtfi.LongDatePattern = "dddd, dd MMMM, yyyy"

      ' Both these statements assign the date "January 6, 2005."
      dt = Date.Parse("6-1-2005 12.30.44", dtfi)
      dt = Date.Parse("Thursday, 6 January, 2005", dtfi)

      ' Display the abbreviated names of months.
      For Each s As String In DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames
         Console.WriteLine(s)
      Next

      ' This statements assigns the date "January 6, 2005."
      dt = Date.ParseExact("6-1-2005", "d-M-yyyy", Nothing)

      Dim aDate As Date
      If Date.TryParse("January 6, 2005", aDate) Then
         ' aDate contains the parsed date.
      End If

      Dim ci As New CultureInfo("en-US")
      If Date.TryParse(" 6/1/2005 14:26 ", ci, DateTimeStyles.AllowWhiteSpaces Or _
         DateTimeStyles.AssumeUniversal, aDate) Then
         ' aDate contains the parsed date.
      End If
   End Sub

   Sub WorkingWithTimeZones()
      ' February 14, 2005 at 12:00 AM, UTC value
      Dim aDate As New Date(2005, 2, 14, 12, 0, 0, DateTimeKind.Utc)
      ' Test the Kind property.
      Console.WriteLine(aDate.Kind.ToString)          ' Utc

      ' Next statement changes the Kind property (but doesn't change the date/time value!).
      Dim newDate As Date = Date.SpecifyKind(aDate, DateTimeKind.Utc)

      ' Convert to a Long value.
      Dim lngValue As Long = aDate.ToBinary()
      ' Convert back from a Long to a Date value.
      newDate = Date.FromBinary(lngValue)

      ' Serialize a date in UTC format.
      Dim text As String = aDate.ToString("o", CultureInfo.InvariantCulture)

      ' Deserialize it into a new DateTime value.
      newDate = Date.ParseExact(text, "o", CultureInfo.InvariantCulture, _
         DateTimeStyles.RoundtripKind)
   End Sub

   Sub TimeZoneType()
      ' Get the TimeZone object for the current time zone.
      Dim tz As TimeZone = TimeZone.CurrentTimeZone
      ' Display name of time zone, without and with Daylight Saving Time.
      ' (I got these results by running this code in Italy.)
      Console.WriteLine(tz.StandardName)  ' => W. Europe Standard Time
      Console.WriteLine(tz.DaylightName)  ' => W. Europe Daylight Time

      ' Display the time offset of W. Europe time zone in March 2005, 
      ' when no Daylight Saving Time is active.
      Console.WriteLine(tz.GetUtcOffset(New Date(2005, 3, 1)))  ' => 01:00:00
      ' Display the time offset of W. Europe time zone in July, 
      ' when Daylight Saving Time is active.
      Console.WriteLine(tz.GetUtcOffset(New Date(2005, 7, 1)))  ' => 02:00:00

      ' No Daylight Saving Time in March
      Console.WriteLine(tz.IsDaylightSavingTime(New Date(2005, 3, 1)))
      ' => False


      ' Retrieve the DaylightTime object for year 2005.
      Dim dlc As DaylightTime = tz.GetDaylightChanges(2005)
      ' Note that you might get different start and end dates if you
      ' run this code in a country other than the United States.
      Console.WriteLine("Starts at {0}, Ends at {1}, Delta is {2} minutes", _
         dlc.Start, dlc.End, dlc.Delta.TotalMinutes)
      ' => Starts at 3/27/2005 2:00:00 A.M., ends at 10/30/2005 3:00:00 A.M., Delta is 60 minutes.
   End Sub

   Sub GuidType()
      ' Create a new GUID.
      Dim guid1 As Guid = Guid.NewGuid()
      ' By definition, you'll surely get a different output here.
      Console.WriteLine(guid1.ToString)       '=> 3f5f1d42-2d92-474d-a2a4-1e707c7e2a37

      ' Initialize from a string.
      Dim guid2 As New Guid("45FA3B49-3D66-AB33-BB21-1E3B447A6621")

      ' Convert to an array of bytes.
      Dim bytes() As Byte = guid1.ToByteArray
      For Each b As Byte In bytes
         Console.Write("{0} ", b)
         ' => 239 1 161 57 143 200 172 70 185 64 222 29 59 15 190 205
      Next

      ' Compare two GUIDs.
      If Not guid1.Equals(guid2) Then
         Console.WriteLine("GUIDs are different.")
      End If
   End Sub

   Sub WorkingWithEnums()
      Dim de As DataEntry = DataEntry.DateTime
      ' Display the numeric value.
      Console.WriteLine(de)                 ' => 3
      ' Display the symbolic value.
      Console.WriteLine(de.ToString)        ' => DateTime

      ' General and fixed formats display the Enum name.
      Console.WriteLine(de.ToString("F"))   ' => DateTime
      ' Decimal format displays Enum value.
      Console.WriteLine(de.ToString("D"))   ' => 3
      ' Hexadecimal format displays eight hex digits.
      Console.WriteLine(de.ToString("X"))   ' => 00000003

      ' You can use the GetType method (inherited from System.Object)
      ' to get the Type object required by the Parse method.
      de = CType([Enum].Parse(GetType(DataEntry), "CharString"), DataEntry)

      Try
         ' *** This statement throws an exception. 
         Console.WriteLine([Enum].Parse(de.GetType, "charstring"))
      Catch ex As Exception
         Console.WriteLine("ERROR: {0}", ex.Message)
      End Try

      ' This works well because case-insensitive comparison is used.
      Console.WriteLine([Enum].Parse(de.GetType, "charstring", True))

      Console.WriteLine([Enum].GetUnderlyingType(de.GetType))   ' => System.Int32

      If [Enum].IsDefined(GetType(DataEntry), 3) Then
         ' 3 is a valid value for the DataEntry class.
         de = CType(3, DataEntry)
      End If

      ' This code produces an invalid result, yet it doesn't throw an exception.
      de = CType(123, DataEntry)

      If [Enum].GetName(GetType(DataEntry), 3) IsNot Nothing Then
         de = CType(3, DataEntry)
      End If

      ' List all the values in DataEntry.
      Dim names() As String = [Enum].GetNames(GetType(DataEntry))
      Dim values As Array = [Enum].GetValues(GetType(DataEntry))
      For i As Integer = 0 To names.Length - 1
         Console.WriteLine("{0} = {1}", names(i), CInt(values.GetValue(i)))
      Next

      Dim vde As ValidDataEntry = ValidDataEntry.IntegerNumber Or ValidDataEntry.DateTime
      Console.WriteLine(vde.ToString)       ' => IntegerNumber, DateTime

      Dim vde2 As ValidDataEntry
      Console.WriteLine(vde2.ToString)    ' => None

      vde = CType(123, ValidDataEntry)
      Console.WriteLine(vde.ToString)     ' => 123

      vde = CType([Enum].Parse( _
         vde.GetType, "IntegerNumber, FloatingNumber"), ValidDataEntry)
      Console.WriteLine(CInt(vde))        ' => 3

   End Sub

End Module
