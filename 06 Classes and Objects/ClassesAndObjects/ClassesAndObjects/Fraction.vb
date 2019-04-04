Public Structure Fraction
   ' Read-only fields 
   Private num As Long
   Private den As Long

   ' Read-only properties
   Public ReadOnly Property Numerator() As Long
      Get
         Return num
      End Get
   End Property

   Public ReadOnly Property Denominator() As Long
      Get
         Return den
      End Get
   End Property

   Sub New(ByVal numerator As Long, ByVal denominator As Long)
      ' Normalize the numerator and denominator.
      If numerator = 0 Then
         denominator = 1
      ElseIf denominator < 0 Then
         numerator = -numerator
         denominator = -denominator
      End If
      Dim div As Long = GCD(numerator, denominator)
      num = numerator \ div
      den = denominator \ div
   End Sub

   ' The greatest common divisor of two numbers (helper method)
   Private Function GCD(ByVal n1 As Long, ByVal n2 As Long) As Long
      n1 = Math.Abs(n1)
      n2 = Math.Abs(n2)
      Do
         ' Ensure that n1 > n2
         If n1 < n2 Then
            Dim tmp As Long = n1
            n1 = n2
            n2 = tmp
         End If
         n1 = n1 Mod n2
      Loop While n1 <> 0
      Return n2
   End Function

   ' Override ToString to provide a textual representation of the fraction.
   Public Overrides Function ToString() As String
      If num = 0 OrElse den = 1 Then
         Return num.ToString()
      Else
         Return String.Format("{0}/{1}", num, den)
      End If
   End Function

   ' (Add to the Fraction type.)
   Public Shared Operator +(ByVal f1 As Fraction, ByVal f2 As Fraction) As Fraction
      ' a/b + c/d = (a*d + b*c) / (b*d)
      Return New Fraction(f1.num * f2.den + f2.num * f1.den, f1.den * f2.den)
   End Operator

   Public Shared Operator -(ByVal f1 As Fraction, ByVal f2 As Fraction) As Fraction
      ' a/b - c/d = (a*d - b*c) / (b*d)
      Return New Fraction(f1.num * f2.den - f2.num * f1.den, f1.den * f2.den)
   End Operator

   Public Shared Operator *(ByVal f1 As Fraction, ByVal f2 As Fraction) As Fraction
      ' a/b * c/d = (a*c) / (b*d)
      Return New Fraction(f1.num * f2.num, f1.den * f2.den)
   End Operator

   Public Shared Operator /(ByVal f1 As Fraction, ByVal f2 As Fraction) As Fraction
      ' Dividing is like multiplying by the reciprocal of second operand.
      Return New Fraction(f1.num * f2.den, f1.den * f2.num)
   End Operator

   ' Adding a fraction and an integer
   Public Shared Operator +(ByVal f As Fraction, ByVal n As Integer) As Fraction
      Return New Fraction(f.num + n * f.den, f.den)
   End Operator

   Public Shared Operator +(ByVal n As Integer, ByVal f As Fraction) As Fraction
      ' Delegate to the other overload.
      Return f + n
   End Operator

   ' Unary minus
   Public Shared Operator -(ByVal f As Fraction) As Fraction
      Return New Fraction(-f.num, f.den)
   End Operator

   ' Comparison operators must be redefined in pairs
   Public Shared Operator =(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      ' This code relies on the denominator always being 1 if numerator is zero.
      Return f1.num = f2.num AndAlso f1.den = f2.den
   End Operator

   Public Shared Operator <(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      Return f1.num * f2.den < f1.den * f2.num
   End Operator

   Public Shared Operator >(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      Return f1.num * f2.den > f1.den * f2.num
   End Operator

   Public Shared Operator <>(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      Return Not (f1 = f2)
   End Operator

   Public Shared Operator <=(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      Return Not (f1 > f2)
   End Operator

   Public Shared Operator >=(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
      Return Not (f1 < f2)
   End Operator

   ' if you redefine the = operator you should redefine the Equals method as well
   Public Overloads Function Equals(ByVal f As Fraction) As Boolean
      Return (f = Me)
   End Function

   Public Overloads Shared Function Equals(ByVal f1 As Fraction, _
         ByVal f2 As Fraction) As Boolean
      Return (f1 = f2)
   End Function

   ' Implicit conversion to a boolean
   Public Shared Operator IsTrue(ByVal f As Fraction) As Boolean
      Return f.num <> 0
   End Operator

   Public Shared Operator IsFalse(ByVal f As Fraction) As Boolean
      Return f.num = 0
   End Operator

   ' COnversions to and from integers
   Public Shared Narrowing Operator CType(ByVal f As Fraction) As Long
      Return f.num \ f.den
   End Operator

   Public Shared Widening Operator CType(ByVal n As Long) As Fraction
      Return New Fraction(n, 1)
   End Operator

   ' Conversion from string
   Public Shared Narrowing Operator CType(ByVal value As String) As Fraction
      Dim f As Fraction
      If TryParse(value, f) Then
         Return f
      Else
         Throw New ArgumentException("Invalid format")
      End If
   End Operator

   Public Shared Function Parse(ByVal value As String) As Fraction
      Return CType(value, Fraction)
   End Function

   Public Shared Function TryParse(ByVal value As String, ByRef f As Fraction) As Boolean
      Dim parts() As String = value.Split("/"c)
      If parts.Length = 1 Then
         f = New Fraction(CLng(parts(0)), 1)
         Return True
      ElseIf parts.Length = 2 Then
         f = New Fraction(CLng(parts(0)), CLng(parts(1)))
         Return True
      Else
         Return False
      End If
   End Function


   Public Shared Operator Like(ByVal f As Fraction, ByVal f2 As Fraction) As Long
      Return f.num \ f.den
   End Operator

   Public Shared Function ToInt64(ByVal f As Fraction) As Long
      Return CType(f, Long)
   End Function

   Public Shared Function FromInt64(ByVal value As Long) As Fraction
      Return CType(value, Fraction)
   End Function



End Structure
