Public Class ClassWithRuntimeConstraint(Of T)
   ' Check the condition in the static constructor
   Shared Sub New()
      If Not GetType(IDisposable).IsAssignableFrom(GetType(T)) AndAlso _
         Not GetType(ICloneable).IsAssignableFrom(GetType(T)) Then
         Throw New ArgumentException("Invalid type argument")
      End If
   End Sub

End Class
