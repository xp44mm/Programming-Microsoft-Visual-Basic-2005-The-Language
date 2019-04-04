<AttributeUsage(AttributeTargets.Field Or AttributeTargets.Property)> _
Public Class CsvFieldAttribute
   Inherits Attribute
   Implements IComparable

   ' These would be properties in a real-world implementation.
   Public ReadOnly Index As Integer
   Public Quoted As Boolean = False
   Public Format As String = ""

   Public Sub New(ByVal index As Integer)
      Me.Index = index
   End Sub

   ' Attributes are sorted on their Index property.
   Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
      Return Me.Index.CompareTo(DirectCast(obj, CsvFieldAttribute).Index)
   End Function
End Class
