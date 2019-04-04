Public Class Employee3
   Implements ICloneable

   Public FirstName As String
   Public LastName As String
   Public Boss As Employee3

   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   ' The only method of the ICloneable interface (private)
   Private Function CloneMe() As Object Implements ICloneable.Clone
      ' Reuses the code in the strongly typed Clone method.
      Return Clone
   End Function

   ' The strongly typed Clone method (public)
   Public Function Clone() As Employee3
      ' Start creating a shallow copy of this object.
      ' (This copies all nonobject properties in one operation.)
      Clone = DirectCast(Me.MemberwiseClone(), Employee3)
      ' Manually copy the Boss property, reusing its Clone method.
      If Clone.Boss IsNot Nothing Then Clone.Boss = Me.Boss.Clone()
   End Function
End Class
