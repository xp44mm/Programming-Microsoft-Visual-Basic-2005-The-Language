' A class that has a Value field
Class ValueClass
    Private Value As Double

    ' A property that uses the Value field
    Public Property DoubleValue() As Double
        Get
            Return Me.Value * 2
        End Get
        Set(ByVal newValue As Double)
            Me.Value = newValue / 2
        End Set
    End Property

End Class
