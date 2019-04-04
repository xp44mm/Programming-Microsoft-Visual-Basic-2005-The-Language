Module Module1

   Sub Main()
      'TestInheritance()
      'VirtualVsNonvirtualPerformance()
      'TestOverridableMethods()
      'ProblemWithOverridableMethods()
      'MethodShadowing()
   End Sub

   Sub TestInheritance()
      Dim e As New Employee
      e.FirstName = "John"
      e.LastName = "Doe"
      ' This assignment always works.
      Dim p As Person = e
      ' This proves that p points to the Employee object.
      Console.WriteLine(p.CompleteName)   '=> John Doe

      Dim e2 As Employee = DirectCast(p, Employee)
   End Sub

   ' this procedure benchmarks NotOverridable and Overridable methods
   ' run this code with Start without Debugging (Ctrl+F5) to see the
   ' best results.

   Sub VirtualVsNonvirtualPerformance()
      Const Times As Integer = 200000000

      Dim i As Integer
      Dim sum As Integer
      Dim w As New Widget()

      ' benchmark calls to non-overridable method.
      Dim sw As Stopwatch = Stopwatch.StartNew()
      For i = 1 To Times
         sum += w.GetInteger()
      Next
      Console.WriteLine("Non-overridable method: {0} milliseconds.", sw.ElapsedMilliseconds)

      ' benchmark calls to overridable method.
      sw = Stopwatch.StartNew()
      For i = 1 To Times
         sum -= w.GetInteger2()
      Next
      Console.WriteLine("Overridable method: {0} milliseconds.", sw.ElapsedMilliseconds)

      ' benchmark calls to a method in the class interface.
      sw = Stopwatch.StartNew()
      For i = 1 To Times
         w.Dispose()
      Next
      Console.WriteLine("Method in main class interface: {0} milliseconds.", sw.ElapsedMilliseconds)

      ' benchmark calls to a method in an interface.
      Dim d As IDisposable = CType(w, IDisposable)
      sw = Stopwatch.StartNew()
      For i = 1 To Times
         d.Dispose()
      Next
      Console.WriteLine("Method in an interface: {0} milliseconds.", sw.ElapsedMilliseconds)
   End Sub

   Sub TestOverridableMethods()
      Dim e As New Employee3("John", "Doe")
      e.Gender = Gender.Male
      ' The TitledName method defined in Person3 uses the overridden
      ' version of Title property defined in Employee3.
      Console.WriteLine(e.TitledName)         ' => Mr. John Doe
   End Sub

   ' This method shows a problem with overridable methods. To fix the problem
   ' goto class Person3 and uncomment the statement in Property CanVote, so 
   ' that the MyClass keyword is used.

   Sub ProblemWithOverridableMethods()
      ' Create a person and an employee.
      Dim p As New Person3("John", "Doe")
      Dim e As New Employee3("Robert", "Smith")
      ' They are born on the same day.
      p.BirthDate = #12/31/1987#
      e.BirthDate = #12/31/1987#
      ' (Assuming that you run this code in the year 2005...)
      ' The person can't vote yet (correct).
      Console.WriteLine(p.CanVote)                       ' => False
      ' The employee is allowed to vote (incorrect).
      Console.WriteLine(e.CanVote)                       ' => True
   End Sub

   Sub MethodShadowing()
      Dim b As New BBB()
      b.DoSomething()          ' => BBB.DoSomething
      b.DoSomething("abc")     ' => AAA.DoSomething(abc)
      b.DoSomething2()         ' => BBB.DoSomething2
      ' *** This statement doesn't compile.
      ' b.DoSomething2("abc")

      Dim e As New Employee3("Joe", "Doe")

      Try
         ' CORRECT: This statement correctly raises an ArgumentException 
         ' because of the code in the Employee class.
         e.Address = ""
      Catch ex As Exception
         Console.WriteLine("ERROR: {0}", ex.Message)
      End Try

      ' Access the same object through a base class variable.
      Dim p As Person3 = e
      ' WRONG: This raises no run-time error because the Address property procedure
      ' in the base class is actually executed.
      p.Address = ""
   End Sub

End Module



