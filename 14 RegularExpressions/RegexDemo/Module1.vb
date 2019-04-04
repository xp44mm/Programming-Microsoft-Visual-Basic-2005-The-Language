Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions

Module Module1

   Sub Main()
      'TheFundamentals()
      'RegularExpressionOptions()
      'RegularExpressionOptions2()
      'SearchingForSubstrings()
      'MatchesLazyEvaluation()
      'TheMatchMethod()
      'TheSplitMethod()
      'TheReplaceMethod()
      'TestReplaceWithCallback()
      'StaticMethods()
      'CompileToAssemblyMethod()
      'TheMatchCollection()
      'TheGroupType()
      'ParseHtmlFile()
      'TheCaptureCollection()
      'SearchingForWords()
      'NoiseWords()
      'QuotedStrings()
      'UniqueWords()
      'DuplicatedWords()
      'ProximitySearches()
      'CheckUSZipCode()
      'CheckPasswordPolicy()
      'ValidateIntegerRanges()
      'ValidatingTimes()
      'ValidatingDates()
      'ParsingFixedWidthDataFiles()
      'ParsingDelimitedDataFiles()
      'ParsingDelimitedQuotedDataFiles()
      'ParsingDelimitedQuotedDataFiles2()
      FindNestedHtmlTags()
      'PlayPoker()
   End Sub

   '-----------------------------------------
   ' Regular expressions fundamentales
   '-----------------------------------------

   Sub TheFundamentals()
      Dim re As New Regex("[aeiou]\d")
      ' This source string contains 3 groups that match the Regex.
      Dim text As String = "a1 = a1 & e2"
      ' Get the collection of matches.
      Dim mc As MatchCollection = re.Matches(text)
      ' How many occurrences did we find?
      Console.WriteLine("{0} matches", mc.Count)         ' => 3 matches
      Debug.Assert(mc.Count = 3)

      For Each m As Match In mc
         ' Display text and position of this match.
         Console.WriteLine("  '{0}' at position {1}", m.Value, m.Index)
      Next

      ' Replacing a substring
      ' Search for the "a" character followed by a digit.
      Dim re2 As New Regex("a\d")
      ' Drop the digit that follows the "a" character.
      Dim res As String = re2.Replace(text, "a")        ' => a = a & e2
      Console.WriteLine("Result of replacement: {0}", res)
      Debug.Assert(res = "a = a & e2")

      ' This code snippet is equivalent to the previous one, but it doesn't
      ' instantiate a Regex object.
      res = Regex.Replace(text, "a\d", "a")
      Debug.Assert(res = "a = a & e2")
   End Sub

   Sub RegularExpressionOptions()
      Dim source As String = "ABC Abc abc"
      Dim mc As MatchCollection = Regex.Matches(source, "abc")
      Console.WriteLine(mc.Count)                    ' => 1
      Debug.Assert(mc.Count = 1)

      mc = Regex.Matches(source, "abc", RegexOptions.IgnoreCase)
      Console.WriteLine(mc.Count)
      Console.WriteLine()
      Debug.Assert(mc.Count = 3)

      ' Create a compiled regular expression that searches 
      ' words that start with uppercase or lowercase A.
      Dim reComp As New Regex("\Aw+", RegexOptions.IgnoreCase Or RegexOptions.Compiled)

      ' Match a string optionally enclosed in single or double quotation marks.
      Dim pattern As String = _
         "\s*         # ignore leading spaces" + ControlChars.CrLf & _
         "(           # two cases: quoted or unquoted string" + ControlChars.CrLf & _
         "(?<quote>   # case 1: define a group named 'quote' '" + ControlChars.CrLf & _
         "['""])     # the group is single or a double quote" + ControlChars.CrLf & _
         ".*?         # a sequence of characters (lazy matching)" + ControlChars.CrLf & _
         "\k<quote>   # followed by the same quote char" + ControlChars.CrLf & _
         "|           # end of case 1" + ControlChars.CrLf & _
         "[^'""]+     # case 2: a string without quotes" + ControlChars.CrLf & _
         ")           # end of case 2" + ControlChars.CrLf & _
         "\s*         # ignore trailing spaces"
      Dim re As New Regex(pattern, RegexOptions.IgnorePatternWhitespace)
      source = "one 'two three' four ""five six"" seven"
      For Each m As Match In re.Matches(source)
         Console.WriteLine("[{0}]", m.Value)
      Next
      Debug.Assert(re.Matches(source).Count = 5)

   End Sub

   Sub RegularExpressionOptions2()
      ' Change directory so that project directory becomes current.
      Directory.SetCurrentDirectory(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory)))

      ' The pattern matches from the keyword to the end of the line.
      Dim pattern As String = "(?im)^\s+(dim|public|private) \w+ As .+(?=\r\n)"
      Dim source As String = File.ReadAllText("Module1.vb")
      Dim mc As MatchCollection = Regex.Matches(source, pattern)
      For Each m As Match In mc
         Console.WriteLine(m.Value)
      Next
   End Sub

   '-----------------------------------------
   ' egular Expression Types
   '-----------------------------------------

   Sub SearchingForSubstrings()
      ' Finds consecutive groups of space-delimited numbers.
      Dim re As New Regex("\G\s*\d+")
      ' Note that search stops at the first non-numeric group.
      Console.WriteLine(re.Matches("12 34 56 ab 78").Count)     ' => 3

      ' Check whether the input string is a date in the format mm-dd-yy or 
      ' mm-dd-yyyy. (The source string can use slashes as date separators and 
      ' can contain leading or trailing white spaces.)
      Dim re2 As New Regex("^\s*\d{1,2}(/|-)\d{1,2}\1(\d{4}|\d{2})\s*$")
      If re2.IsMatch(" 12/10/2001  ") Then
         Console.WriteLine("The date is formatted correctly.")
         ' (We don't check whether month and day values are in valid range.)
      End If
      Debug.Assert(re2.IsMatch(" 12/10/2001  "))
   End Sub

   Sub MatchesLazyEvaluation()
      ' Prepare to search for the "A" character.
      Dim re As New Regex("A")
      ' Create a very long string with a match at its beginning and its end.
      Dim text As String = "A" & New String(" "c, 1000000) & "A"

      Dim sw As New Stopwatch()
      sw.Start()
      For Each m As Match In re.Matches(text)
         ' Show how long it took to find this match.
         Console.WriteLine("Elapsed {0} milliseconds", sw.ElapsedMilliseconds)
      Next
      sw.Stop()
   End Sub

   Sub TheMatchMethod()
      ' Search all the dates in a source string.
      Dim source As String = " 12-2-1999  10/23/2001 4/5/2001 "
      Dim re As New Regex("\s*\d{1,2}(/|-)\d{1,2}\1(\d{4}|\d{2})")
      ' Find the first match.
      Dim m As Match = re.Match(source)
      ' Enter the following loop only if the search was successful.
      Do While m.Success
         ' Display the match, but discard leading and trailing spaces.
         Console.WriteLine(m.ToString.Trim())
         ' Find the next match; exit if not successful.
         m = m.NextMatch()
      Loop
   End Sub

   Sub TheSplitMethod()
      Dim source As String = "123, 456,,789"
      Dim re As New Regex("\s*,\s*")
      For Each s As String In re.Split(source)
         ' Note that the third element is a null string.
         Console.Write(s & "-")              ' => 123-456--789-
      Next
      Console.WriteLine()
   End Sub

   Sub TheReplaceMethod()
      Dim source As String = "12-2-1999  10/23/2001  4/5/2001 "
      Dim pattern As String = _
          "\b(?<mm>\d{1,2})(?<sep>(/|-))(?<dd>\d{1,2})\k<sep>(?<yy>(\d{4}|\d{2}))\b"
      Dim re As New Regex(pattern)
      Console.WriteLine(re.Replace(source, "${dd}${sep}${mm}${sep}${yy}"))
      ' => 2-12-1999  23/10/2001  5/4/2001
      Debug.Assert(re.Replace(source, "${dd}${sep}${mm}${sep}${yy}") = "2-12-1999  23/10/2001  5/4/2001 ")

      ' Expand all "ms" abbreviations to "Microsoft" (regardless of their case).
      Dim text As String = "Welcome to ms Ms ms MS"
      Dim re2 As New Regex("\bMS\b", RegexOptions.IgnoreCase)
      ' Replace up to two occurrences, starting at the 12-th character.
      Console.WriteLine(re2.Replace(text, "Microsoft", 2, 12))
      ' => Welcome to ms Microsoft Microsoft MS
      Debug.WriteLine(re2.Replace(text, "Microsoft", 2, 12) = "Welcome to ms Microsoft Microsoft MS")
   End Sub

   Sub TestReplaceWithCallback()
      ' This pattern defines two integers separated by a plus sign.
      Dim re As New Regex("\d+\s*\+\s*\d+")
      Dim source As String = "a = 100 + 234: b = 200+345"
      ' Replace all sum operations with their results.
      Console.WriteLine(re.Replace(source, AddressOf DoSum))
      ' => a = 334: b = 545
      Debug.Assert(re.Replace(source, AddressOf DoSum) = "a = 334: b = 545")

      ' Convert country names in the text string to uppercase.
      Dim text As String = "I visited italy, france, and then GERMANY"
      Dim re2 As New Regex("\b(Usa|France|Germany|Italy|Great Britain)\b", _
         RegexOptions.IgnoreCase)
      text = re2.Replace(text, AddressOf ConvertToProperCase)
      Console.WriteLine(text)     ' => I visited Italy, France, and then Germany
      Debug.Assert(text = "I visited Italy, France, and then Germany")
   End Sub

   ' The callback method
   Private Function DoSum(ByVal m As Match) As String
      ' Parse the two operands.
      Dim args() As String = m.Value.Split("+"c)
      Dim n1 As Long = CLng(args(0))
      Dim n2 As Long = CLng(args(1))
      ' Return their sum, as a string.
      Return (n1 + n2).ToString()
   End Function

   Private Function ConvertToUpperCase(ByVal m As Match) As String
      Return m.Value.ToUpper()
   End Function

   Private Function ConvertToLowerCase(ByVal m As Match) As String
      Return m.Value.ToLower()
   End Function

   Private Function ConvertToProperCase(ByVal m As Match) As String
      ' We must convert to lowercase first, to ensure that ToTitleCase works as intended.
      Return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Value.ToLower())
   End Function

   Sub StaticMethods()
      ' \W means "any nonalphanumeric character."
      Dim words() As String = Regex.Split("Split these words", "\W+")
      Console.WriteLine("{0} words", words.Length)
      Console.WriteLine()
      Debug.Assert(words.Length = 3)

      ' The Escape method
      Console.WriteLine(Regex.Escape("(x)"))     ' => \(x\)
      Console.WriteLine()
      Debug.Assert(Regex.Escape("(x)") = "\(x\)")

      ' The Unescape method
      Dim s As String
      s = Regex.Unescape("First line\r\nSecond line ends with null char\x00")
      Console.WriteLine(s)
   End Sub

   Sub CompileToAssemblyMethod()
      ' INSTRUCTIONS:
      ' (1) Run this method to create the CustomRegularExpressions.dll assembly
      ' (2) Stop VS2005, then add a reference to the new assembly
      ' (3) Uncomment next block of lines and run this method again.

      'Dim reWords As New CustomRegex.RegexWords
      'For Each m As Match In reWords.Matches("A string containing five words")
      '   Console.WriteLine(m.Value)
      'Next
      'Return

      ' The namespace for both compiled regex types in this sample
      Dim nsName As String = "CustomRegex"
      ' The first regular expression compiles to a type named RegexWords.
      ' (The last argument means that the type is public.)
      Dim rci1 As New RegexCompilationInfo("\w+", RegexOptions.Compiled, _
         "RegexWords", nsName, True)
      ' The second regular expression compiles to a type named RegexIntegers.
      Dim rci2 As New RegexCompilationInfo("\d+", RegexOptions.Compiled, _
         "RegexIntegers", nsName, True)
      ' Create the array that defines all compiled regular expressions.
      Dim regexInfo() As RegexCompilationInfo = {rci1, rci2}

      ' Compile these types to an assembly named "CustomRegularExpressions"
      Dim an As New System.Reflection.AssemblyName
      an.Name = "CustomRegularExpressions"
      Regex.CompileToAssembly(regexInfo, an)
   End Sub

   Sub TheMatchCollection()
      Dim re As New Regex("\d*")
      For Each m As Match In re.Matches("1a23bc456de789")
         ' The output from this loop shows that some matches are empty.
         Console.Write(m.Value & ",")  ' => 1,,23,,456,,,789,,
      Next
      Console.WriteLine()
      Console.WriteLine()

      Dim source As String = "a = 123: b=456"
      Dim re2 As New Regex("(\s*)(?<name>\w+)\s*=\s*(?<value>\d+)")
      For Each m As Match In re2.Matches(source)
         Console.WriteLine("Variable: {0}, Value: {1}", _
            m.Groups("name").Value, m.Groups("value").Value)
      Next
      Console.WriteLine()

      ' This code produces exactly the same result as the preceding snippet.
      For Each m As Match In re2.Matches(source)
         Console.WriteLine(m.Result("Variable: ${name}, Value: ${value}"))
      Next
   End Sub

   Sub TheGroupType()
      Dim text As String = "a = 123: b=456"
      Dim re As New Regex("(\s*)(?<name>\w+)\s*=\s*(?<value>\d+)")
      For Each m As Match In re.Matches(text)
         Dim g As Group = m.Groups("name")
         ' Get information on variable name and value.
         Console.Write("Variable '{0}' found at index {1}", g.Value, g.Index)
         Console.WriteLine(", value is {0}", m.Groups("value").Value)
      Next
   End Sub

   Sub ParseHtmlFile()
      Dim re As New Regex("<A\s+HREF\s*=\s*("".+?""|.+?)>(.+?)</A>", RegexOptions.IgnoreCase)
      ' Load the contents of an HTML file.
      Dim text As String = File.ReadAllText("test.htm")

      ' Display all occurrences.
      Dim m As Match = re.Match(text)
      Do While m.Success
         Console.WriteLine("{0} => {1}", m.Groups(2).Value, m.Groups(1).Value)
         m = m.NextMatch()
      Loop
   End Sub

   Sub TheCaptureCollection()
      Dim text As String = "abc def"
      Dim re As New Regex("(\w)+")
      ' Get the name or numbers of all the groups.
      Dim groups() As String = re.GetGroupNames()

      ' Iterate over all matches.
      For Each m As Match In re.Matches(text)
         ' Display information on this match.
         Console.WriteLine("Match '{0}' at index {1}", m.Value, m.Index)
         ' Iterate over the groups in each match.
         For Each s As String In groups
            ' Get a reference to the corresponding group.
            Dim g As Group = m.Groups(s)
            ' Get the capture collection for this group.                
            Dim cc As CaptureCollection = g.Captures
            ' Display the number of captures.
            Console.WriteLine("  Found {0} capture(s) for group {1}", cc.Count, s)
            ' Display information on each capture.
            For Each c As Capture In cc
               Console.WriteLine("    '{0}' at index {1}", c.Value, c.Index)
            Next
         Next
      Next

   End Sub

   '-----------------------------------------
   ' Regular expressions at work
   '-----------------------------------------

   Sub SearchingForWords()
      Dim text As String = "A word with àccéntèd vowels, and the 123 number."
      Dim pattern As String

      ' This pattern includes words with accented characters and numbers.
      pattern = "\w+"
      For Each m As Match In Regex.Matches(Text, pattern)
         Console.WriteLine(m.Value)
      Next
      Console.WriteLine()

      ' This pattern doesn't consider words with accented chars.
      pattern = "[A-Za-z]+"
      For Each m As Match In Regex.Matches(text, pattern)
         Console.WriteLine(m.Value)
      Next
      Console.WriteLine()

      ' This pattern works correctly and uses Unicode character classes.
      pattern = "(\p{Lu}|\p{Ll})+"
      For Each m As Match In Regex.Matches(text, pattern)
         Console.WriteLine(m.Value)
      Next
      Console.WriteLine()

      ' This pattern works correctly and uses character subtraction.
      pattern = "[\w-[0-9_]]+"
      For Each m As Match In Regex.Matches(text, pattern)
         Console.WriteLine(m.Value)
      Next
      Console.WriteLine()

      ' Eliminating noise words.
      pattern = "\b(?!(the|a|an|and|or|on|with|of|but)\b)\w+"
      'text = "A fox and another animal on the lawn"
      For Each m As Match In Regex.Matches(text, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine("{0} ", m.Value)     ' => fox another animal lawn
      Next
   End Sub

   Sub NoiseWords()
      Dim pattern As String = "\b(?!(the|a|an|and|or|on|of|with)\b)\w+"
      Dim text As String = "A fox and another animal on the lawn"
      For Each m As Match In Regex.Matches(text, pattern, RegexOptions.IgnoreCase)
         Console.Write("{0} ", m.Value)     ' => fox another animal lawn
      Next
   End Sub

   Sub QuotedStrings()
      Dim text As String = "one 'two three' four ""five six"" seven"
      Dim pattern As String = "((?<q>[""']).*?\k<q>|\w+)"
      Dim re As New Regex(pattern)
      For Each m As Match In re.Matches(text)
         Console.WriteLine("{0}", m.Value)
      Next
   End Sub

   Sub UniqueWords()
      Dim text As String = "one two three two zone four three"

      ' This version uses a HashTable to keep track of unique words.
      Dim re As New Regex("\w+")
      Dim words As New Hashtable()
      For Each m As Match In re.Matches(text)
         If Not words.Contains(m.Value) Then
            Console.Write("{0} ", m.Value)
            words.Add(m.Value, Nothing)
         End If
      Next
      Console.WriteLine()

      ' This technique uses regex exclusively.
      Dim pattern As String = "(?<word>\b\w+\b)(?!.+\b\k<word>\b)"
      For Each m As Match In Regex.Matches(text, pattern)
         Console.Write("{0} ", m.Value)
      Next
      Console.WriteLine()

      ' Benchmark the two techniques.
      ' Replace argument of next method as necessary.
      text = File.ReadAllText("d:\book.txt")
      Dim sw As New Stopwatch()
      Dim wordList As New ArrayList()

      words.Clear()
      sw.Start()
      For Each m As Match In re.Matches(text)
         If Not words.Contains(m.Value) Then
            words.Add(m.Value, Nothing)
            wordList.Add(m.Value)
         End If
      Next
      sw.Stop()
      Console.WriteLine("Hashtable-based technique: {0} milliseconds", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      wordList.Clear()
      sw.Start()
      For Each m As Match In Regex.Matches(text, pattern)
         wordList.Add(m.Value)
      Next
      sw.Stop()
      Console.WriteLine("Regex-oly technique: {0} milliseconds", sw.ElapsedMilliseconds)
   End Sub

   Sub DuplicatedWords()
      Dim text As String = "one two three two zone four three"
      Dim pattern As String = "(?<word>\b\w+\b)(?=.+\b\k<word>\b)"

      ' This technique uses regex exclusively.
      For Each m As Match In Regex.Matches(text, pattern)
         Console.Write("{0} ", m.Value)
      Next
      Console.WriteLine()
   End Sub

   Sub ProximitySearches()
      Dim text As String = "one two three two zone four three"
      Dim pattern As String = "\bone(\W+\w+){0,4}\W+\bfour\b"

      ' This technique uses regex exclusively.
      For Each m As Match In Regex.Matches(text, pattern)
         Console.Write("{0} ", m.Value)
      Next
      Console.WriteLine()


      Dim mc As MatchCollection = ProximityMatches(text, "one", "four", 4)
      If mc.Count > 0 Then
         Console.WriteLine("Found: {0}", mc(0).Value)
      End If
      Console.WriteLine()
   End Sub

   ' Helper function to build proximity searches patterns.
   Private Function ProximityMatches(ByVal text As String, ByVal word1 As String, _
         ByVal word2 As String, ByVal maxDistance As Integer) As MatchCollection
      Dim pattern As String = "\b" & word1 & "(\W+\w+){0," & maxDistance.ToString() & "}\" _
         & "W+\b" & word2 & "\b"
      Dim re As New Regex(pattern, RegexOptions.IgnoreCase)
      Return re.Matches(text)
   End Function

   '-----------------------------------------
   ' Validating strings, numbers, and dates
   '-----------------------------------------

   Sub CheckUSZipCode()
      Dim pattern As String = "^(?!00000)\d{5}$"

      Dim text As String = "12345"
      If Regex.IsMatch(text, pattern) Then
         ' It's a string containing 5 digits.
         Console.WriteLine("{0} is a valid US zip code", text)
      Else
         Console.WriteLine("{0} isn't a valid US zip code", text)
      End If

      text = "00000"
      If Regex.IsMatch(text, pattern) Then
         ' It's a string containing 5 digits.
         Console.WriteLine("{0} is a valid US zip code", text)
      Else
         Console.WriteLine("{0} isn't a valid US zip code", text)
      End If
   End Sub

   Sub CheckPasswordPolicy()
      Dim pattern As String = "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])\w{8,}$"

      Dim text As String = "foobar12AK"
      If Regex.IsMatch(text, pattern) Then
         ' It's a string containing 5 digits.
         Console.WriteLine("{0} is a robust password", text)
      Else
         Console.WriteLine("{0} isn't a robust password", text)
      End If

      text = "foobar12"
      If Regex.IsMatch(text, pattern) Then
         ' It's a string containing 5 digits.
         Console.WriteLine("{0} is a robust password", text)
      Else
         Console.WriteLine("{0} isn't a robust password", text)
      End If
   End Sub

   Sub ValidateIntegerRanges()
      ' Validate an integer in the range 1 to 9999, reject leading zeroes.
      Dim pattern As String = "^(?!0)\d{1,4}$"
      For Each text As String In New String() {"123", "0123", "0", "10000"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a number in the range 1-9999, with no leading zeroes", text)
         Else
            Console.WriteLine("{0} isn't a number in the range 1-9999, with no leading zeroes", text)
         End If
      Next
      Console.WriteLine()

      ' Validate an integer in the range 0 to 9999, but reject leading zeroes.
      pattern = "^(0|(?!0)\d{1,4})$"
      For Each text As String In New String() {"123", "0123", "0", "10000"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a number in the range 0-9999, with no leading zeroes", text)
         Else
            Console.WriteLine("{0} isn't a number in the range 0-9999, with no leading zeroes", text)
         End If
      Next
      Console.WriteLine()

      ' Validate an integer in the range 0 to 255, with no leading zeroes
      pattern = "^(25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)$"
      For Each text As String In New String() {"0", "8", "23", "123", "255", "256", "300", "012"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a number in the range 0-255", text)
         Else
            Console.WriteLine("{0} isn't a number in the range 0-255", text)
         End If
      Next
      Console.WriteLine()

      ' Validate a 4-part IP address
      pattern = "^((25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)\.){3}" _
         & "(25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)$"
      For Each text As String In New String() {"0.0.0.1", "12.23.45.255", "1.2.3", "2.4.6.256"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a valid IP address", text)
         Else
            Console.WriteLine("{0} isn't a valid IP address", text)
         End If
      Next
      Console.WriteLine()

      ' Validate an integer number in the range 0 to 65535; leading zeroes are OK.
      pattern = "^([1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-4]|\d{1,4})$"
      For Each text As String In New String() {"0", "4", "23", "345", "1234", "23456", "54567", "65536", "73456", "-123"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is an integer in the range 0-65535", text)
         Else
            Console.WriteLine("{0} isn't an integer in the range 0-65535", text)
         End If
      Next
      Console.WriteLine()

      ' Validate an integer in the range -32768 to 32767; leading zeroes are OK.
      pattern = "^(-?[12]\d{4}|-?3[0-1]\d{3}|-?32[0-6]\d{2}|-?327[0-5]\d|" _
         & "-?3276[0-7]|-32768|-?\d{1,4})$"
      For Each text As String In New String() {"-4", "-123", "0", "4", "23", "345", "1234", "23456", "32767", "32768", "54567", "-32768", "-32800"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is an integer in the range -32768 to 32767", text)
         Else
            Console.WriteLine("{0} isn't an integer in the range -32768 to 32767", text)
         End If
      Next
      Console.WriteLine()
   End Sub

   Sub ValidatingTimes()
      ' Validate a time value in the format hh:mm; the hour number can have a leading zero.
      Dim pattern As String = "^(2[0-3]|[01]\d|\d):[0-5]\d$"
      For Each text As String In New String() {"0:00", "1:23", "3:333", "12:4", "12:12", "23:00", "23:59", "23:61", "24:00"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a valid time value", text)
         Else
            Console.WriteLine("{0} isn't a valid time value", text)
         End If
      Next
      Console.WriteLine()
   End Sub

   Sub ValidatingDates()
      ' This portion deals with months with 31 days.
      Dim p1 As String = "(0?[13578]|10|12)/(3[01]|[012]\d|\d)/\d{2}"
      ' This portion deals with months with 30 days.
      Dim p2 As String = "(0?[469]|11)/(30|[012]\d|\d)/\d{2}"
      ' This portion deals with February 29 in leap years.
      Dim p3 As String = "(0?2)/29/([02468][048]|[13579][26])"
      ' This portion deals with other days in February.
      Dim p4 As String = "(0?2)/(2[0-8]|[01]\d|\d)/\d{2}"
      ' Put all the patterns together.
      Dim pattern As String = String.Format("^({0}|{1}|{2}|{3})$", p1, p2, p3, p4)
      ' Check the date.

      For Each text As String In New String() {"1/1/99", "11/30/99", "11/31/99", "1/32/90", "2/28/03", "2/29/03", "2/29/04"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a valid date in mm/dd/yy format", text)
         Else
            Console.WriteLine("{0} isn't a valid date in mm/dd/yy format", text)
         End If
      Next
      Console.WriteLine()

      ' This portion deals with months with 31 days.
      Const s1 As String = "(0?[13578]|10|12)/(3[01]|[12]\d|0?[1-9])/(\d\d)?\d\d"
      ' This portion deals with months with 30 days.
      Const s2 As String = "(0?[469]|11)/(30|[12]\d|0?[1-9])/(\d\d)?\d\d "
      ' This portion deals with days 1-28 in February in all years.
      Const s3 As String = "(0?2)/(2[0-8]|[01]\d|0?[1-9])/(\d\d)?\d\d"
      ' This portion deals with February 29 in years divisible by 400.
      Const s4 As String = "(0?2)/29/(1600|2000|2400|2800|00)"
      ' This portion deals with February 29 in non-century leap years.
      Const s5 As String = "(0?2)/29/(\d\d)?(0[48]|[2468][048]|[13579][26])"
      ' Put all the patterns together.
      pattern = String.Format("^({0}|{1}|{2}|{3}|{4})$", s1, s2, s3, s4, s5)

      For Each text As String In New String() {"1/1/2001", "11/30/99", "11/31/1999", "1/32/2001", "2/28/2003", "2/29/2003", "2/29/2004", "2/29/2000", "2/29/2100"}
         If Regex.IsMatch(text, pattern) Then
            ' It's a string containing 5 digits.
            Console.WriteLine("{0} is a valid date in mm/dd/yyyy format", text)
         Else
            Console.WriteLine("{0} isn't a valid date in mm/dd/yyyy format", text)
         End If
      Next
      Console.WriteLine()
   End Sub

   '-----------------------------------------
   ' Parsing Data Files
   '-----------------------------------------

   Sub ParsingFixedWidthDataFiles()
      Dim text As String = _
         "John  Smith   New York" & ControlChars.CrLf & _
         "Ann   Doe     Los Angeles" & ControlChars.CrLf

      'Dim lines() As String = File.ReadAllLines("c:\data.txt")
      Dim seps() As String = {ControlChars.CrLf}
      Dim lines() As String = text.Split(seps, StringSplitOptions.RemoveEmptyEntries)

      Dim pattern As String = "^(?<first>.{6})(?<last>.{8})(?<city>.+)$"
      Dim re As New Regex(pattern)
      For Each line As String In lines
         Dim m As Match = re.Match(line)
         Console.WriteLine("First={0}, Last={1}, City={2}", _
            m.Groups("first").Value.TrimEnd(), m.Groups("last").Value.TrimEnd(), _
            m.Groups("city").Value.TrimEnd())
      Next
      Console.WriteLine()
   End Sub

   Sub ParsingDelimitedDataFiles()
      Dim text As String = _
         "John , Smith, New York" & ControlChars.CrLf & _
         "Ann, Doe, Los Angeles" & ControlChars.CrLf

      'Dim lines() As String = File.ReadAllLines("c:\data.txt")
      Dim seps() As String = {ControlChars.CrLf}
      Dim lines() As String = text.Split(seps, StringSplitOptions.RemoveEmptyEntries)

      Dim pattern As String = "^\s*(?<first>.*?)\s*,\s*(?<last>.*?)\s*,\s*(?<city>.*?)\s*$"
      Dim re As New Regex(pattern)
      For Each line As String In lines
         Dim m As Match = re.Match(line)
         Console.WriteLine("First={0}, Last={1}, City={2}", _
            m.Groups("first").Value.TrimEnd(), m.Groups("last").Value.TrimEnd(), _
            m.Groups("city").Value.TrimEnd())
      Next
      Console.WriteLine()
   End Sub

   Sub ParsingDelimitedQuotedDataFiles()
      Dim text As String = _
         "'John, P.' , ""Smith"" , ""New York""" & ControlChars.CrLf & _
         "'Robert ""Slim""', """" , ""Los Angeles, CA""" & ControlChars.CrLf

      'Dim lines() As String = File.ReadAllLines("c:\data.txt")
      Dim seps() As String = {ControlChars.CrLf}
      Dim lines() As String = text.Split(seps, StringSplitOptions.RemoveEmptyEntries)

      Dim pattern As String = "^\s*(?<q1>[""'])(?<first>.*?)\k<q1>\s*," & _
         "\s*(?<q2>[""'])(?<last>.*?)\k<q2>\s*,\s*(?<q3>[""'])(?<city>.*?)\k<q3>\s*$"

      Dim re As New Regex(pattern)
      For Each line As String In lines
         Dim m As Match = re.Match(line)
         Console.WriteLine("First={0}, Last={1}, City={2}", _
            m.Groups("first").Value.TrimEnd(), m.Groups("last").Value.TrimEnd(), _
            m.Groups("city").Value.TrimEnd())
      Next
      Console.WriteLine()
   End Sub

   Sub ParsingDelimitedQuotedDataFiles2()
      Dim text As String = _
         """John, P."" , Doe , ""Los Angeles, CA""" & ControlChars.CrLf & _
         "Robert, Smith, New York" & ControlChars.CrLf

      'Dim lines() As String = File.ReadAllLines("c:\data.txt")
      Dim seps() As String = {ControlChars.CrLf}
      Dim lines() As String = text.Split(seps, StringSplitOptions.RemoveEmptyEntries)

      Dim pattern As String = "^\s*(?<q1>[""']?)(?<first>.*?)(?(q1)\k<q1>)\s*" & _
         ",\s*(?<q2>[""']?)(?<last>.*?)(?(q2)\k<q2>)\s*" & _
         ",\s*(?<q3>[""']?)(?<city>.*?)(?(q3)\k<q3>)\s*$"

      Dim re As New Regex(pattern)
      For Each line As String In lines
         Dim m As Match = re.Match(line)
         Console.WriteLine("First={0}, Last={1}, City={2}", _
            m.Groups("first").Value.TrimEnd(), m.Groups("last").Value.TrimEnd(), _
            m.Groups("city").Value.TrimEnd())
      Next
      Console.WriteLine()
   End Sub

   Sub FindNestedHtmlTags()
      ' Find all nested HTML tags in a file. (eg. <table>...</table>)
      Dim text As String = File.ReadAllText("test.htm")
      Dim re As New Regex("<(?<tag>(table|tr|td|div|span))[\s>]", RegexOptions.IgnoreCase)
      For Each m As Match In re.Matches(text)
         ' We've found an open tag. Lets look for open & close versions of this tag.
         Dim tag As String = m.Groups("tag").Value
         Dim openTags As Integer = 1
         Dim pattern2 As String = String.Format("((?<open><{0})[\s>]|(?<close>)</{0}>)", tag)
         Dim found As String = Nothing
         Dim re2 As New Regex(pattern2, RegexOptions.IgnoreCase)

         For Each m2 As Match In re2.Matches(text, m.Index + 1)
            If m2.Groups("open").Success Then
               openTags += 1
            ElseIf m2.Groups("close").Success Then
               openTags -= 1
               If openTags = 0 Then
                  found = text.Substring(m.Index, m2.Index + m.Length + 1 - m.Index)
                  Exit For
               End If
            End If
         Next
         ' Display this match.
         If found IsNot Nothing Then
            Console.WriteLine(found)
            Console.WriteLine("------------------------------------------")
         Else
            Console.WriteLine("Unmatched tag {0} at index {1}", tag, m.Index)
         End If
      Next
   End Sub

   Sub PlayPoker()
      PlayPokerHand("StraightFlush", "1H", "2H", "3H", "4H", "5H")
      PlayPokerHand("StraightFlush", "3H", "4H", "5H", "6H", "7H")
      PlayPokerHand("StraightFlush", "6C", "7C", "8C", "9C", "TC")
      PlayPokerHand("StraightFlush", "7S", "8S", "9S", "TS", "JS")
      PlayPokerHand("StraightFlush", "8S", "9S", "TS", "JS", "QS")
      PlayPokerHand("StraightFlush", "TD", "JD", "QD", "KD", "1D")

      PlayPokerHand("Flush", "8S", "JS", "QS", "KS", "1S")
      PlayPokerHand("Flush", "7H", "8H", "9H", "TH", "KH")
      PlayPokerHand("Flush", "8C", "9C", "TC", "QC", "KC")

      PlayPokerHand("FourOfAKind", "8C", "9D", "8D", "8H", "8S")
      PlayPokerHand("FourOfAKind", "TS", "TC", "QD", "TD", "TH")
      PlayPokerHand("FourOfAKind", "1C", "1S", "8S", "1H", "1D")

      PlayPokerHand("FullHouse", "1C", "1D", "8C", "1D", "8S")
      PlayPokerHand("FullHouse", "9C", "9S", "8D", "8S", "9H")
      PlayPokerHand("FullHouse", "QC", "TD", "QD", "TS", "QS")

      PlayPokerHand("Straight", "3S", "7S", "5S", "4S", "6D")
      PlayPokerHand("Straight", "6D", "7S", "8H", "9H", "TD")
      PlayPokerHand("Straight", "7S", "8D", "9D", "TH", "JC")
      PlayPokerHand("Straight", "TC", "JS", "QS", "KS", "1S")

      PlayPokerHand("ThreeOfAKind", "9C", "9S", "8H", "TD", "9D")
      PlayPokerHand("ThreeOfAKind", "TC", "TS", "7S", "TH", "1D")
      PlayPokerHand("ThreeOfAKind", "TC", "TS", "8S", "TH", "KH")

      PlayPokerHand("TwoPairs", "1C", "1F", "8F", "DP", "8Q")
      PlayPokerHand("TwoPairs", "9C", "KF", "8F", "8P", "9Q")
      PlayPokerHand("TwoPairs", "1C", "DF", "QF", "DP", "QQ")

      PlayPokerHand("OnePair", "1C", "1H", "KH", "TS", "8S")
      PlayPokerHand("OnePair", "9C", "KH", "QH", "8S", "9D")
      PlayPokerHand("OnePair", "1S", "TS", "QC", "8C", "QC")

      PlayPokerHand("HighCard", "1C", "QC", "KC", "TD", "8D")
      PlayPokerHand("HighCard", "TC", "KC", "QD", "8D", "9H")
      PlayPokerHand("HighCard", "1C", "TC", "KD", "8D", "QH")
      PlayPokerHand("HighCard", "8D", "QD", "TD", "9D", "KH")
   End Sub

   Private Sub PlayPokerHand(ByVal expectedScore As String, ByVal ParamArray cards() As String)
      Dim score As String = PokerGame.EvalPokerScore2(cards)
      Console.WriteLine("{0} {1} {2} {3} {4} => {5}", cards(0), cards(1), cards(2), cards(3), cards(4), score)
      If score <> expectedScore Then Console.WriteLine("    WRONG! (expected {0})", expectedScore)
   End Sub


End Module
