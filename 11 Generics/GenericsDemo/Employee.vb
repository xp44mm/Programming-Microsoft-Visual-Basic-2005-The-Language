Public Class Employee
   Implements IPoolable

   ' The IPoolable interface

   Public Sub Initialize(ByVal ParamArray propertyValues() As Object) _
      Implements IPoolable.Initialize
      Me.Name = CStr(propertyValues(0))
      Me.BirthDate = CDate(propertyValues(1))
   End Sub

   Public Function IsEqual(ByVal ParamArray propertyValues() As Object) As Boolean _
         Implements IPoolable.IsEqual
      Return Me.Name = CStr(propertyValues(0)) AndAlso _
         Me.BirthDate = CDate(propertyValues(1))
   End Function

   ' all the other members

   Event NameChanging As EventHandler(Of PropertyChangingEventArgs(Of String))
   Event BirthDateChanging As EventHandler(Of PropertyChangingEventArgs(Of Date))
   Event NameChanged As EventHandler
   Event BirthDateChanged As EventHandler

   Private m_Name As String

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         If m_Name <> value Then
            Dim e As New PropertyChangingEventArgs(Of String)(value)
            OnNameChanging(e)
            If e.Cancel Then Exit Property
            m_Name = value
            OnNameChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   Private m_BirthDate As Date

   Public Property BirthDate() As Date
      Get
         Return m_BirthDate
      End Get
      Set(ByVal value As Date)
         If m_BirthDate <> value Then
            Dim e As New PropertyChangingEventArgs(Of Date)(value)
            OnBirthDateChanging(e)
            If e.Cancel Then Exit Property
            m_BirthDate = value
            OnBirthDateChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   ' Protected Onxxxx methods
   Protected Overridable Sub OnNameChanging(ByVal e As _
         PropertyChangingEventArgs(Of String))
      RaiseEvent NameChanging(Me, e)
   End Sub

   Protected Overridable Sub OnNameChanged(ByVal e As EventArgs)
      RaiseEvent NameChanged(Me, e)
   End Sub

   Protected Overridable Sub OnBirthDateChanging(ByVal e As _
         PropertyChangingEventArgs(Of Date))
      RaiseEvent BirthDateChanging(Me, e)
   End Sub

   Protected Overridable Sub OnBirthDateChanged(ByVal e As EventArgs)
      RaiseEvent BirthDateChanged(Me, e)
   End Sub

End Class

' this version uses the EventHelper module

Public Class Employee2
   Event NameChanging As EventHandler(Of PropertyChangingEventArgs(Of String))
   Event BirthDateChanging As EventHandler(Of PropertyChangingEventArgs(Of Date))
   Event NameChanged As EventHandler
   Event BirthDateChanged As EventHandler

   Private m_Name As String

   Public Property Name() As String
      Get
         Return m_Name
      End Get
      Set(ByVal value As String)
         AssignProperty(Of String)(m_Name, value, AddressOf OnNameChanging, _
            AddressOf OnNameChanged)
      End Set
   End Property

   Private m_BirthDate As Date

   Public Property BirthDate() As Date
      Get
         Return m_BirthDate
      End Get
      Set(ByVal value As Date)
         AssignProperty(Of Date)(m_BirthDate, value, AddressOf OnBirthDateChanging, _
            AddressOf OnBirthDateChanged)
      End Set
   End Property


   ' Protected Onxxxx methods
   Protected Overridable Sub OnNameChanging(ByVal e As _
         PropertyChangingEventArgs(Of String))
      RaiseEvent NameChanging(Me, e)
   End Sub

   Protected Overridable Sub OnNameChanged(ByVal e As EventArgs)
      RaiseEvent NameChanged(Me, e)
   End Sub

   Protected Overridable Sub OnBirthDateChanging(ByVal e As _
         PropertyChangingEventArgs(Of Date))
      RaiseEvent BirthDateChanging(Me, e)
   End Sub

   Protected Overridable Sub OnBirthDateChanged(ByVal e As EventArgs)
      RaiseEvent BirthDateChanged(Me, e)
   End Sub

End Class