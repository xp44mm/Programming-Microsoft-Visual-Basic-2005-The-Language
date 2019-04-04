Public Class Employee2
   Implements ICloneable

   Public FirstName As String
   Public LastName As String
   Public Boss As Employee2

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   ' ...(other fields and constructor as in Employee)...

   Public Function Clone() As Object Implements ICloneable.Clone
      ' Start with a shallow copy of this object.
      ' (This copies all nonobject properties in one operation.)
      Dim em As Employee2 = DirectCast(Me.MemberwiseClone(), Employee2)
      ' Manually copy the Boss property, reusing its Clone method.
      If em.Boss IsNot Nothing Then em.Boss = DirectCast(Me.Boss.Clone(), Employee2)
      Return em
   End Function
End Class
