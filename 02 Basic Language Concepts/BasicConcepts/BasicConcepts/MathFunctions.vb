Module MathFunctions
   ' A public constant
   Public Const DoublePI As Double = 6.28318530717958
   ' Two private arrays
   Private names() As String
   Dim values() As Double

   Private factResults(169) As Double

   Sub New()
      factResults(0) = 1
      For i As Integer = 1 To 169
         factResults(i) = factResults(i - 1) * i
      Next
   End Sub

   Public Function Factorial(ByVal n As Integer) As Double
      ' Throw an exception if outside the range [0,169].
      Return factResults(n)
   End Function

   Public Function Pow(ByVal number As Long, ByVal exponent As Integer) As Long
      Dim result As Long = 1
      Do While exponent > 0
         If (exponent Mod 2) = 1 Then result = result * number
         number = number * number
         exponent = exponent >> 1
      Loop
      Return result
   End Function

   Public Function Pow(ByVal number As Double, ByVal exponent As Integer) As Double
      Dim result As Double = 1
      Do While exponent > 0
         If (exponent Mod 2) = 1 Then result = result * number
         number = number * number
         exponent = exponent >> 1
      Loop
      Return result
   End Function

   ' (All these routines assume that N is in the range 0-31.)
   ' Set the Nth bit of a value.
   Function BitSet(ByVal value As Integer, ByVal n As Integer) As Integer
      Return value Or (1 << n)
   End Function

   ' Clear the Nth bit of a value.
   Function BitClear(ByVal value As Integer, ByVal n As Integer) As Integer
      Return value And Not (1 << n)
   End Function

   ' Toggle the Nth bit of a value.
   Function BitToggle(ByVal value As Integer, ByVal n As Integer) As Integer
      Return value Xor (1 << n)
   End Function

   ' Test the Nth bit of a value.
   Function BitTest(ByVal value As Integer, ByVal n As Integer) As Boolean
      Return CBool(value And (1 << n))
   End Function

   ' Rotate an integer value N bits to the left. (N in the 0-31 range)
   Function RotateLeft(ByVal value As Integer, ByVal n As Integer) As Integer
      Return (value << n) Or ((value >> 32 - n) And Not (-1 << n))
   End Function

   ' Rotate an integer value N bits to the right. (N in the 0-31 range)
   Function RotateRight(ByVal value As Integer, ByVal n As Integer) As Integer
      Return ((value >> n) And Not (-1 << 32 - n)) Or (value << 32 - n)
   End Function

   Function BitCount(ByVal n As Integer) As Integer
      Do Until n = 0
         BitCount += 1
         n = n And (n - 1)       ' Clear the most significant bit.
      Loop
   End Function


End Module
