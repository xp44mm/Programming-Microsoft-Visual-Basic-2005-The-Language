Public Class Person
   Implements IComparable

   Public Shared ReadOnly NameComparer As New ComparerByName()
   Public Shared ReadOnly ReverseNameComparer As New ComparerByReverseName()

   ' Public fields (should be properties in a real-world class)
   Public FirstName As String
   Public LastName As String

   ' A simple constructor
   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   ' A property that returns the name in the format "Evans, John"
   ReadOnly Property ReverseName() As String
      Get
         Return LastName & ", " & FirstName
      End Get
   End Property

   ' A property that returns a name in the format "John Evans"
   ReadOnly Property CompleteName() As String
      Get
         Return FirstName & " " & LastName
      End Get
   End Property


   ' This private procedure adds sorting capabilities to the class.
   Private Function CompareTo(ByVal obj As Object) As Integer _
             Implements IComparable.CompareTo
      ' Any non-Nothing object is greater than Nothing.
      If obj Is Nothing Then Return 1
      ' Cast to a specific Person object; error if the argument is of a different type.
      Dim other As Person = DirectCast(obj, Person)
      ' Compare LastName first.
      Dim result As Integer = String.Compare(Me.LastName, other.LastName, True)
      If result = 0 Then
         ' Compare FirstName only if the two persons have same last name.
         result = String.Compare(Me.FirstName, other.FirstName, True)
      End If
      Return result
   End Function

   ' nested IComparer classes

   ' First auxiliary class, to sort on CompleteName  
   Class ComparerByName
      Implements IComparer

      Function Compare(ByVal o1 As Object, ByVal o2 As Object) _
          As Integer Implements IComparer.Compare
         ' Two null objects are equal.
         If (o1 Is Nothing) And (o2 Is Nothing) Then Return 0
         ' Any non-null object is greater than a null object.
         If (o1 Is Nothing) Then Return 1
         If (o2 Is Nothing) Then Return -1
         ' Cast both objects to Person, and do the comparison.
         ' (Throws an exception if arguments aren't Person objects.)
         Dim p1 As Person = DirectCast(o1, Person)
         Dim p2 As Person = DirectCast(o2, Person)
         Return String.Compare(p1.CompleteName, p2.CompleteName, True)
      End Function
   End Class

   ' Second auxiliary class, to sort on ReverseName
   Class ComparerByReverseName
      Implements IComparer

      Function Compare(ByVal o1 As Object, ByVal o2 As Object) _
          As Integer Implements IComparer.Compare
         ' Two null objects are equal.
         If (o1 Is Nothing) And (o2 Is Nothing) Then Return 0
         ' Any non-null object is greater than a null object.
         If (o1 Is Nothing) Then Return 1
         If (o2 Is Nothing) Then Return -1
         ' Save code by casting to Person objects on the fly.
         Return String.Compare(DirectCast(o1, Person).ReverseName, _
             DirectCast(o2, Person).ReverseName, True)
      End Function
   End Class


End Class
