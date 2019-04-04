<Serializable()> _
Public Class Person
   Implements ICloneable

   Public ReadOnly FirstName As String
   Public ReadOnly LastName As String
   Private ReadOnly BirthDate As Date
   <NonSerialized()> Private m_Age As Integer

   Public Spouse As Person

   ' Note that BirthDate can be set only by means of the constructor method.
   Sub New(ByVal firstName As String, ByVal lastName As String, ByVal birthDate As Date)
      Me.FirstName = firstName
      Me.LastName = lastName
      Me.BirthDate = birthDate
   End Sub

   ' The Age property caches its value in the m_Age private variable.
   Public ReadOnly Property Age() As Integer
      Get
         ' Evaluate Age if not cached already.             
         If m_Age = 0 Then
            m_Age = Now.Year - BirthDate.Year
            If BirthDate.DayOfYear > Now.DayOfYear Then m_Age -= 1
         End If
         Return m_Age
      End Get
   End Property

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Return Me.MemberwiseClone()
   End Function
End Class



