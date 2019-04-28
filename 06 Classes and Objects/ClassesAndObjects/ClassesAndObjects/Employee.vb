Public Class Employee

    '(A more robust version of Employee?
    Public Sub New(ByVal firstName As String, ByVal lastName As String)
        ' Delegate validation to Property procedures.
        Me.FirstName = firstName
        Me.LastName = lastName
    End Sub

    Private m_FirstName As String

    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal Value As String)
            If Value = "" Then Throw New ArgumentException("Invalid FirstName value")
            m_FirstName = Value
        End Set
    End Property

    Private m_LastName As String

    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(ByVal Value As String)
            If Value = "" Then Throw New ArgumentException("Invalid LastName value")
            m_LastName = Value
        End Set
    End Property

End Class
