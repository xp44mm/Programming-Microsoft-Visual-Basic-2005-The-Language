VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Person"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Event NameChanged(sender As Object, e As Object)

' member variable for FirstName property
Private m_FirstName As String
' member variable for LastName property
Private m_LastName As String

' The FirstName property

Property Get FirstName() As String
    FirstName = m_FirstName
End Property

Property Let FirstName(ByVal newValue As String)
    If m_FirstName = newValue Then Exit Property
    m_FirstName = newValue
    RaiseEvent NameChanged(Me, Nothing)
End Property

' The LastName property

Property Get LastName() As String
    LastName = m_LastName
End Property

Property Let LastName(ByVal newValue As String)
    If m_LastName = newValue Then Exit Property
    m_LastName = newValue
    RaiseEvent NameChanged(Me, Nothing)
End Property

Public Function CompleteName() As String
    CompleteName = Me.FirstName & " " & Me.LastName
End Function







