Imports System.IO

Module Functions

   Sub ClearPerson(ByRef p As Person)
      ' We need this test to avoid NullReferenceException errors.
      If p IsNot Nothing Then
         Debug.WriteLine("Clearing Person " & p.FirstName & " " & p.LastName)
         p = Nothing
      End If
   End Sub

   Function Sum(ByVal ParamArray args() As Integer) As Integer
      Dim result As Integer = 0
      For index As Integer = 0 To UBound(args)
         result += args(index)
      Next
      Return result
   End Function

   Function MinValue(ByVal ParamArray args() As Integer) As Integer
      ' Sort the array, and then return its first element.
      ' (Concise code, even though not very efficient)
      Array.Sort(args)
      Return args(0)
   End Function

   Function InitializeArray(ByVal n As Integer) As Integer()
      Dim res(n - 1) As Integer
      For i As Integer = 0 To n - 1
         res(i) = i
      Next
      Return res
   End Function

   Function Factorial(ByVal n As Integer) As Double
      If n < 0 Then
         Throw New ArgumentException("Invalid argument")
      ElseIf n <= 1 Then
         Return 1
      Else
         Return n * Factorial(n - 1)      ' Tail recursion
      End If
   End Function

   Sub DisplayDirTree(ByVal path As String)
      Console.WriteLine(path)
      For Each dirName As String In Directory.GetDirectories(path)
         DisplayDirTree(dirName)
      Next
   End Sub

   Function NumberToText(ByVal n As Integer) As String
      Select Case n
         Case 0
            Return ""
         Case 1 To 19
            Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", _
               "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", _
                "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
            Return arr(n - 1) & " "
         Case 20 To 99
            Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", _
               "Seventy", "Eighty", "Ninety"}
            Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)
         Case 100 To 199
            Return "One Hundred " & NumberToText(n Mod 100)
         Case 200 To 999
            Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)
         Case 100 To 1999
            Return "One Thousand " & NumberToText(n Mod 1000)
         Case 2000 To 999999
            Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)
         Case 1000000 To 1999999
            Return "One Million " & NumberToText(n Mod 1000000)
         Case 1000000 To 999999999
            Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)
         Case 1000000000 To 1999999999
            Return "One Billion " & NumberToText(n Mod 1000000000)
         Case Else
            Return NumberToText(n \ 1000000000) & "Billions " _
               & NumberToText(n Mod 1000000000)
      End Select
   End Function

   Public Function LogException(ByVal ex As Exception) As Boolean
      Debug.WriteLine(ex.Message)
      Return False
   End Function

   ' Copy a text file, converting to lowercase in the process.
   Sub CopyFileToLowercase(ByVal inFile As String, ByVal outFile As String)
      Using sr As New StreamReader(inFile), sw As New StreamWriter(outFile)
         sw.Write(sr.ReadToEnd().ToLower())
      End Using
   End Sub


End Module
