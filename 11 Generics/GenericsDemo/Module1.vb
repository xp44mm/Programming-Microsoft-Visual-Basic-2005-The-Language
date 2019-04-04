Module Module1

   Sub Main()
      'TestListType()
      'BenchmarkListType()
      'TestReadOnlyList()
      'TestRelation()
      'TestSwap()
      'OfKeywordUsage()
      'TestIsDefaultValue()
      'MethodOverloading()
      'UsingInheritedClasses()
      'TypeOfOperator()
      'TestMax()
      'TestMedianValue()
      'ProblemWithOverloadedMethods()
      'MultipleConstraints()
      'RuntimeConstraints()
      'NullableTypes()
      'TestNullableBooleanType()
      'TestStatsList()
      'TestEventHandlers()
      'TestObjectPool()
      TestObjectPoolEx()

   End Sub

   Sub TestListType()
      ' This collection will contain only integer numbers.
      Dim col As New List(Of Integer)
      col.Add(11) : col.Add(13) : col.Add(19)
      For Each n As Integer In col
         Console.WriteLine(n)
      Next
      ' Reading an element doesn't require any conversion operator.
      Dim element As Integer = col(0)
   End Sub

   Sub BenchmarkListType()
      Const TIMES As Integer = 1000000
      Dim al As New ArrayList
      Dim list As New List(Of Integer)

      Dim sw As New Stopwatch
      sw.Start()
      For i As Integer = 1 To TIMES
         al.Add(i)
      Next
      sw.Stop()
      Console.WriteLine("Adding to ArrayList: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      Dim res As Long = 0
      For i As Integer = 1 To TIMES - 1
         res += CInt(al(i))
      Next
      sw.Stop()
      Console.WriteLine("Reading ArrayList elements: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 0 To TIMES
         list.Add(i)
      Next
      sw.Stop()
      Console.WriteLine("Adding to List: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 0 To TIMES - 1
         res -= CInt(al(i))
      Next
      sw.Stop()
      Console.WriteLine("Reading List elements: {0} msecs.", sw.ElapsedMilliseconds)
   End Sub

   Sub TestReadOnlyList()
      ' This readonly list can contain up to 1000 integer values.
      Dim roList As New ReadOnlyList(Of Integer)(1000)
      roList.Add(123)
      Console.WriteLine(roList(0))                     ' => 123
      ' *** Next statement causes a compilation error: "Property Item is readonly."
      ' roList(0) = 234
   End Sub

   Sub TestReadOnlyList2()
      ' This readonly list can contain up to 1000 integer values.
      Dim roList As New ReadOnlyList2(Of Integer)(1000)
      roList.Add(123)
      Console.WriteLine(roList(0))                     ' => 123
      ' *** Next statement causes a compilation error: "Property Item is readonly."
      ' roList(0) = 234
   End Sub

   Sub TestRelation()
      Dim ca As New Company("Code Architects")
      Dim john As New Person("John", "Smith")
      Dim ann As New Person("Ann", "Doe")

      Dim relations As New List(Of Relation(Of Person, Company))
      Dim relJohnCa As New Relation(Of Person, Company)(john, ca)
      relations.Add(relJohnCa)
      relations.Add(New Relation(Of Person, Company)(ann, ca))

      For Each p As Person In GetEmployees(relations, ca)
         Console.WriteLine(p.FirstName & " " & p.LastName)
      Next
   End Sub

   ' helper method
   Private Function GetEmployees(ByVal relations As List(Of Relation(Of Person, Company)), _
      ByVal company As Company) As List(Of Person)
      Dim result As New List(Of Person)
      For Each rel As Relation(Of Person, Company) In relations
         If rel.Object2 Is company Then result.Add(rel.Object1)
      Next
      Return result
   End Function


   Sub TestSwap()
      Dim n1 As Integer = 123
      Dim n2 As Integer = 456
      Swap(Of Integer)(n1, n2)
      Console.WriteLine("n1={0}, n2={1}", n1, n2)    ' => n1=456, n2=123

      ' The following statement works correctly.
      Swap(n1, n2)
      Console.WriteLine("n1={0}, n2={1}", n1, n2)    ' => n1=123, n2=456

   End Sub

   Sub OfKeywordUsage()
      DoSomething(123, 456)             ' Same as DoSomething(Of Integer)
      DoSomething(123.56, 456.78)       ' Same as DoSomething(Of Double)

      Dim l As Long = 456
      Dim n As Integer = 123
      ' *** Next statement causes a compile-time error
      'DoSomething(l, n)

      ' Both these statements work correctly.
      DoSomething(l, CLng(n))
      DoSomething(Of Long)(l, n)

   End Sub

   ' a generic method that proves why sometimes you need to specify Of clause in invocation

   Private Sub DoSomething(Of T)(ByVal x As T, ByVal y As T)
      ' do nothing 
   End Sub

   Sub TestIsDefaultValue()
      Console.WriteLine(IsDefaultValue(Of String)(Nothing))       ' True
      Console.WriteLine(IsDefaultValue(Of Integer)(0))            ' True
      Console.WriteLine(IsDefaultValue(Of Integer)(1))            ' False

   End Sub


   Sub MethodOverloading()
      DoTask(123, 456.78)                ' Calls DoTask(Of Integer, Double)
      DoTask(123, "abc")                 ' Calls DoTask(Of Integer, String)
      ' *** Next statement raises a compilation error.
      ' DoTask(123, 123)
      ' Next statement compiles correctly 
      DoTask(Of Integer)(123, 123)

   End Sub

   Private Sub DoTask(Of T, P)(ByVal x As T, ByVal y As P)
      Console.WriteLine("First version")
   End Sub

   Private Sub DoTask(Of T)(ByVal x As T, ByVal y As String)
      Console.WriteLine("Second version")
   End Sub

   Private Sub DoTask(Of T)(ByVal x As T, ByVal y As T)
      Console.WriteLine("Third version")
   End Sub

   Sub UsingInheritedClasses()
      Dim ca As New Company("Code Architects")
      Dim john As New Person("John", "Smith")
      Dim ann As New Person("Ann", "Doe")

      Dim relations As New PersonCompanyRelationList
      Dim relJohnCa As New PersonCompanyRelation(john, ca)
      relations.Add(relJohnCa)
      relations.Add(New PersonCompanyRelation(ann, ca))

      For Each p As Person In GetEmployees(relations, ca)
         Console.WriteLine(p.FirstName & " " & p.LastName)
      Next
   End Sub

   Private Function GetEmployees(ByVal relations As PersonCompanyRelationList, _
         ByVal company As Company) As List(Of Person)
      Dim result As New List(Of Person)
      For Each rel As Relation(Of Person, Company) In relations
         If rel.Object2 Is company Then result.Add(rel.Object1)
      Next
      Return result
   End Function

   Sub TypeOfOperator()
      Dim obj As Object
      obj = New List(Of String)

      If TypeOf obj Is List(Of String) Then
         Console.WriteLine("obj is an instance of List(Of String)")
         Dim list As List(Of String) = DirectCast(obj, List(Of String))
      End If

      ' *** This code causes the following compile error: Type T is not defined.
      'If TypeOf obj Is List(Of T) Then
      '   obj is an open list type, such as List(Of Integer) or List(Of String).
      'End If

      ' *** This statement causes two compile errors: Type T is not defined.
      ' Dim list As List(Of T) = DirectCast(obj, List(Of T))

      If obj IsNot Nothing AndAlso obj.GetType().IsGenericType Then
         ' obj is an instance of a generic type.
         Console.WriteLine("obj is an instance of a generic type")
      End If

      If obj IsNot Nothing AndAlso obj.GetType().FullName.StartsWith( _
      "System.Collections.Generic.List`1") Then
         ' obj is a generic type of the form List(Of T).
         Console.WriteLine("obj is an instance of a generic type of the form List(Of T)")
      End If

      ' Test whether obj is a List(Of T) or derives from an List(Of T) type.
      If obj IsNot Nothing Then
         Dim type As Type = obj.GetType()
         Do
            If type.FullName.StartsWith("System.Collections.Generic.List`1") Then
               Console.WriteLine("TypeOf obj Is List(Of T) is true!")
               Exit Do
            End If
            type = type.BaseType
         Loop Until type Is Nothing
      End If
   End Sub

   ' A method that shows how to solve conversion problems with generics

   Sub CheckArguments(Of T)(ByVal value As T)
      If value IsNot Nothing AndAlso value.GetType() Is GetType(Integer) Then
         Dim n As Integer = CInt(CObj(value))
         ' …
      ElseIf value IsNot Nothing AndAlso _
            GetType(Exception).IsAssignableFrom(value.GetType()) Then
         Dim ex As Exception = DirectCast(CObj(value), Exception)
      End If
   End Sub

   Sub TestMax()
      Console.WriteLine(Max(12, 23, 6, -1))                       ' => 23
   End Sub

   Sub TestMedianValue()
      Dim list As New List(Of Integer)(New Integer() {2, 4, 9, 22, 3, 5, 9, 11, 0})
      Console.WriteLine("Median value = {0}", MedianValue(list))
   End Sub

   Sub ProblemWithOverloadedMethods()

      ' a relation between two objects of same type
      Dim r As New Relation3(Of String, String)("abc", "abc")
      ' *** uncomment next statement to see the problem
      ' r.Contains("abc")
   End Sub

   Sub MultipleConstraints()
      Dim arr As New SortableArray(Of Integer, ReverseIntegerComparer)(10)
      Dim rand As New Random()
      For i As Integer = 0 To 9
         arr(i) = rand.Next(1000)
      Next

      arr.Sort()
      For i As Integer = 0 To 9
         Console.WriteLine(arr(i))
      Next
   End Sub

   Sub RuntimeConstraints()
      Try
         ' This statement succeeds because String is clonable
         Dim obj1 As New ClassWithRuntimeConstraint(Of String)

         ' This statement fails because Int32 is neither clonable nor disposable
         Dim obj2 As New ClassWithRuntimeConstraint(Of Integer)
      Catch ex As Exception
         Console.WriteLine("ERROR: " + ex.Message)
      End Try

      Dim obj3 As New ClassWithRuntimeConstraint(Of Array)
   End Sub

   Sub NullableTypes()
      ' Declare an "unassigned" nullable value.
      Dim n As Nullable(Of Integer)
      ' Assign it a value.
      n = 123
      ' Reset it to the "unassigned" state.
      n = Nothing

      ' You can declare and assign a nullable value in these two ways.
      Dim d1 As Nullable(Of Double) = 123.45
      Dim d2 As New Nullable(Of Double)(123.45)

      If n.HasValue Then
         Console.WriteLine("Value is {0}.", n.Value)
      Else
         Console.WriteLine("No value has been assigned yet.")
      End If

      Dim value As Double = 123.45
      ' This conversion can never fail.
      Dim value2 As Nullable(Of Double) = value
      ' The conversion in the opposite direction can fail, thus it must be explicit.
      Dim value3 As Double = CDbl(value2)

      ' This code assumes that d1 and d2 are Nullable(Of Double) elements.
      If d1.HasValue AndAlso d2.HasValue Then
         Dim sum2 As Double = d1.Value + d2.Value
      End If

      ' Add to nullable numbers, using zero if the value is null.
      Dim sum As Double = d1.GetValueOrDefault() + d2.GetValueOrDefault()

      If d1.Equals(0) OrElse d1.Equals(d2) Then
         ' d1 is either zero or is equal to d2.
      ElseIf d1.Equals(Nothing) Then
         ' This is another way to test whether a nullable type has a value.
      End If

      Select Case Nullable.Compare(d1, d2)
         Case -1
            Console.WriteLine("d1 is null or is less than d2")
         Case 1
            Console.WriteLine("d2 is null or is less than d1")
         Case 0
            Console.WriteLine("d1 and d2 have same value or are both null.")
      End Select
   End Sub

   Sub TestNullableBooleanType()
      Dim fal As NullableBoolean = False
      Dim tru As NullableBoolean = True
      Dim unk As NullableBoolean            ' Null is the default state.

      Console.WriteLine(fal And unk)        ' => False
      Console.WriteLine(tru And unk)        ' => Null
      Console.WriteLine(fal Or unk)         ' => Null
      Console.WriteLine(tru Or unk)         ' => True
      Console.WriteLine(fal Xor unk)        ' => Null
      Console.WriteLine(tru Xor unk)        ' => Null
      Console.WriteLine(fal = unk)          ' => Null
      Console.WriteLine(tru <> unk)         ' => Null
   End Sub

   Sub TestStatsList()
      Dim sl As New StatsList(Of Double, NumericCalculator)
      For i As Integer = 0 To 10
         sl.Add(i)
      Next
      Console.WriteLine("Sum = {0}", sl.Sum)         ' => Sum = 55
      Console.WriteLine("Average = {0}", sl.Avg)     ' => Average = 5
   End Sub

   Sub TestEventHandlers()
      Dim em1 As New Employee2()
      AddHandler em1.NameChanging, AddressOf NameChanging
      AddHandler em1.NameChanged, AddressOf NameChanged

      em1.Name = "Francesco"

      RemoveHandler em1.NameChanging, AddressOf NameChanging
      RemoveHandler em1.NameChanged, AddressOf NameChanged
   End Sub

   ' event handlers

   Private Sub NameChanging(ByVal sender As Object, ByVal e As PropertyChangingEventArgs(Of String))
      Console.WriteLine("Changing Name property to {0}", e.ProposedValue)
   End Sub

   Private Sub NameChanged(ByVal sender As Object, ByVal e As EventArgs)
      Console.WriteLine("Name property changed to {0}", DirectCast(sender, Employee2).Name)
   End Sub

   Sub TestObjectPool()
      Dim pool As New ObjectPool(Of Employee)
      ' These two elements are created when the method is invoked.
      Dim e1 As Employee = pool.CreateObject()
      Dim e2 As Employee = pool.CreateObject()
      ' Return one object to the pool, then set its reference to Nothing.
      pool.DestroyObject(e1)
      e1 = Nothing
      ' Now the pool contains one element, thus the next statement takes it from there.
      Dim e3 As Employee = pool.CreateObject()
   End Sub

   Sub TestObjectPoolEx()
      Dim pool As New ObjectPoolEx(Of Employee)
      ' These two elements are created when the method is invoked.
      Dim e1 As Employee = pool.CreateObject("Joe", #1/1/1961#)
      Dim e2 As Employee = pool.CreateObject("Ann", #2/2/1962#)
      ' Return them to the pool and set their references to Nothing. 
      pool.DestroyObject(e1)
      e1 = Nothing
      pool.DestroyObject(e2)
      e2 = Nothing
      ' This object can't be taken from the pool, because its
      ' properties don't match any of the object in the pool.
      Dim e3 As Employee = pool.CreateObject("Joe", #3/3/1963#)
      ' This object matches exactly one object in the pool, thus no new instance is created
      Dim e4 As Employee = pool.CreateObject("Ann", #2/2/1962#)

   End Sub

End Module

