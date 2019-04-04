'<DebuggerNonUserCode()> _
<DebuggerDisplay("Value = {Numerator} / {Denominator}")> _
Public Class Fraction
   <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
   Private m_Numerator As Integer
   <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
   Private m_Denominator As Integer

   Sub New(ByVal num As Integer, ByVal den As Integer)
      ' PUT A BREAKPOINT HERE TO DEMONSTRATE IT IS IGNORED 
      ' BUCAUSE THIS CLASS IS MARKED WITH THE DebuggerNonUserCode attribute.
      m_Numerator = num
      m_Denominator = den
   End Sub

   Public Property Numerator() As Integer
      Get
         Return m_Numerator
      End Get
      Set(ByVal value As Integer)
         m_Denominator = value
      End Set
   End Property

   Public Property Denominator() As Integer
      Get
         Return m_Denominator
      End Get
      Set(ByVal value As Integer)
         m_Denominator = value
      End Set
   End Property

   Public Overrides Function ToString() As String
      Return CStr(Numerator) & " / " & CStr(Denominator)
   End Function
End Class

