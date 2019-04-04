Public Class Employee
   Inherits Person

   ' Two new public fields
   Public BaseSalary As Single
   Public HoursWorked As Integer
   ' A new private field
   Private m_HourlySalary As Single

   ' A new property
   Property HourlySalary() As Single
      Get
         Return m_HourlySalary
      End Get
      Set(ByVal Value As Single)
         m_HourlySalary = Value
      End Set
   End Property

   ' A new method
   Function GetSalary() As Single
      Return BaseSalary + m_HourlySalary * HoursWorked
   End Function

   ' An overridden method
   Public Overrides Function CompleteName() As String
      Return LastName & ", " & FirstName
   End Function

   ' Note: no Overrides keyword, but Overloads is required to avoid a warning.
   Public Overloads Function CompleteName(ByVal title As String) As String
      Return title & " " & LastName & ", " & FirstName
   End Function



End Class

