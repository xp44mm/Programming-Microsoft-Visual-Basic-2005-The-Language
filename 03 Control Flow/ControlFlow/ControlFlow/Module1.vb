Imports System.IO

Module Module1

   Sub Main()
      'TestClearPerson()
      'TestArrayByVal()
      'TestArrayByRef()
      'TestParamArray()
      'TestArrayFunction()
      'TestRecursion()
      'TestWhenKeyword()
      'TestNestedTryWhen()
      'TestNestedTryWhen2()
      'TestGetExceptionMethod()
      'TestCustomException()

   End Sub

   Sub TestClearPerson()
      Dim p As New Person("John", "Smith")
      ClearPerson(p)
      Console.WriteLine("P Is Nothing = {0}", p Is Nothing)
   End Sub

   Sub TestArrayByVal()
      Dim arr() As Integer = {0, 1, 2, 3, 4}
      ' Pass the array by value to a procedure.
      ArrayProc(arr)
      ' Prove that the array element has been modified.
      Console.WriteLine(arr(3))             ' => 300
   End Sub

   ' A procedure that modifies its array argument's elements
   Private Sub ArrayProc(ByVal arr() As Integer)
      For i As Integer = 0 To UBound(arr)
         arr(i) = arr(i) * 100
      Next
   End Sub

   Sub TestArrayByRef()
      Dim byvalArray(10) As Integer
      Dim byrefArray(10) As Integer
      ArrayProc2(byvalArray, byrefArray)
      ' Check which array has been affected by the ReDim statement.
      Console.WriteLine(UBound(byvalArray))   ' => 10 (not modified)
      Console.WriteLine(UBound(byrefArray))   ' => 100 (modified)
   End Sub

   Private Sub ArrayProc2(ByVal arr() As Integer, ByRef arr2() As Integer)
      ' Change the size of both arrays.
      ReDim arr(100)
      ReDim arr2(100)
   End Sub

   Sub TestParamArray()
      Dim result As Integer = Sum(2, 4, 6, 8, 11)
      Console.WriteLine("Sum = {0}", result)
      Dim min As Integer = MinValue(23, 32, 1, 4, -2)
      Console.WriteLine("MinValue = {0}", min)
   End Sub

   Sub TestArrayFunction()
      Dim arr() As Integer = InitializeArray(10)
      For Each n As Integer In arr
         Console.WriteLine(n)
      Next
   End Sub

   Sub TestRecursion()
      Dim fact As Double = Factorial(100)
      Console.WriteLine("Factorial(100) = {0}", fact)
      Console.WriteLine("NumberToText(1234567) = {0}", NumberToText(1234567))

      DisplayDirTree("c:\windows\system32")
   End Sub

   Sub TestWhenKeyword()
      Dim x, y, z, res As Integer        ' All variables are 0.
      Try
         ' You can see different behaviors by commenting out or changing
         ' the order of the following statements.
         res = y \ x

         res = x \ y

         res = x \ z
      Catch ex As DivideByZeroException When (x = 0)
         Console.WriteLine("Division error: x is 0.")
      Catch ex As DivideByZeroException When (y = 0)
         Console.WriteLine("Division error: y is 0.")
      Catch ex As DivideByZeroException
         Console.WriteLine("Division error: no information on variables")
      Catch ex As Exception
         Console.WriteLine("An error has occurred.")
      End Try

      Try
         ' Comment out next statement to see the behavior 
         ' when another file is missing.
         Dim fs1 As New FileStream("c:\myapp.ini", FileMode.Open)
         Dim fs2 As New FileStream("c:\user.dat", FileMode.Open)
      Catch ex As FileNotFoundException When InStr(ex.Message, "'c:\myapp.ini'") > 0
         ' The ini file is missing.
         Console.WriteLine("Can't initialize: MyApp.ini file not found")
      Catch ex As FileNotFoundException
         ' Another file is missing: extract the filename from the Message property.
         Dim filename As String = Split(ex.Message, "'")(1)
         Console.WriteLine("The following file is missing: " & filename)
      End Try
   End Sub

   Sub TestWhenKeyword2()
      Try
         ' Do something.

      Catch ex As Exception When LogException(ex)
         ' (No code here.)
      Catch ex As FileNotFoundException

      Catch ex As DivideByZeroException

      Catch ex As Exception

      End Try
   End Sub

   Dim fs As FileStream

   Sub TestNestedTryWhen()
      Try
         Try
            fs = New FileStream("c:\data.txt", FileMode.Open)
            ' Process the file here.
         Finally
            Console.WriteLine("Inside inner Finally block")
            ' Close the file stream.
            fs.Close()
         End Try
      Catch ex As Exception When CheckException(ex)
         Console.WriteLine("Inside outer Catch block")
      End Try
   End Sub

   Sub TestNestedTryWhen2()
      Try
         Try

            Try
               Console.WriteLine("Impersonating a different user")
               ' Process the file here.
            Finally
               Console.WriteLine("Revert to original user")

            End Try

         Finally
            Console.WriteLine("Inside inner Finally block")
            ' Close the file stream.
            fs.Close()
         End Try
      Catch ex As Exception When CheckException(ex)
         Console.WriteLine("Inside outer Catch block")
      End Try
   End Sub

   Private Function CheckException(ByVal ex As Exception) As Boolean
      Console.WriteLine("Inside CheckException function")
      Return True
   End Function

   Sub TestGetExceptionMethod()
      Try
         OldStyleErrorHandlerProc()
      Catch ex As DivideByZeroException
         Console.WriteLine("A DivideByZeroException has been caught.")
      End Try
   End Sub

   ' This procedure traps an error using an old-style On Error Goto
   ' and returns it to the caller as an exception.
   Sub OldStyleErrorHandlerProc()
      On Error GoTo ErrorHandler
      Dim x, y As Integer         ' Cause a division-by-zero error.
      y = 1 \ x
      Exit Sub
ErrorHandler:
      ' Add cleanup code here as necessary.

      ' Then report the error to the caller as an exception object.
      Throw Err.GetException()
   End Sub

   ' The caller code
   Sub TestCustomException()
      Try
         LoadIniFile()
      Catch ex As UnableToLoadIniFileException
         Console.WriteLine(ex.Message)   ' => Unable to load…
      Catch ex As Exception
         ' Deal with other errors here.
      End Try
   End Sub

   ' The routine that opens the ini file
   Sub LoadIniFile()
      Try
         ' Try to open the ini file. 
         File.ReadAllBytes("nonexistentfile")
      Catch ex As Exception
         ' Whatever caused the error, throw a more specific exception.
         ' (We use the default message but initialize the inner exception.)
         Throw New UnableToLoadIniFileException(ex)
      End Try
   End Sub

End Module
