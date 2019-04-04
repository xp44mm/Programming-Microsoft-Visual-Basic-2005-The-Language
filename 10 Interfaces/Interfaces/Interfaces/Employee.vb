Public Class Employee
   Implements ICloneable

   Public FirstName As String
   Public LastName As String
   Public Boss As Employee

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

#If False Then
   ' The only method of the ICloneable interface
   Public Function Clone() As Object Implements ICloneable.Clone
      ' Create a new Employee with same property values.
      Dim em As New Employee(FirstName, LastName)
      ' Properties not accepted in the constructors must be copied manually.
      em.Boss = Me.Boss
      Return em
   End Function
#Else
   Public Function Clone() As Object Implements ICloneable.Clone
      Return Me.MemberwiseClone()
   End Function
#End If

End Class

