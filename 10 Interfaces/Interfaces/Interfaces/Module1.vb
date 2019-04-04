Module Module1

   Sub Main()
      'AccessingTheInterface()
      'InterfacesAndPolymorphism()
      'IComparableInterface()
      'IComparerInterface()
      'TestReverseComparer()
      'IClonableInterface()
      'ShallowAndDeepCopies()
      'DeepCopy()
      'UsingStatement()
      'TestReadonlyCollectionBase()
      'TestGenericCollection()
      'IEnumerableInterface()
      'TestReverseIterator()
      'TestRandomIterator()
      'TestStepIterator()
   End Sub

   Sub AccessingTheInterface()
      ' An instance of the class
      Dim addin As New MyAddin()
      ' Cast to an interface variable.
      Dim iadd As IAddin = addin
      ' Now you can access all the methods and properties in the interface.
      iadd.State = True

      ' Cast to the interface type and invoke a method in one operation.
      ' (These two statements are equivalent.)
      CType(addin, IAddin).OnConnection("MyHost")
      DirectCast(addin, IAddin).OnConnection("MyHost")
   End Sub

   Sub InterfacesAndPolymorphism()
      ' Define a DataTable with four fields.
      Dim table As New DataTable()
      ' Create the ID column and make it the primary key for this table.
      Dim idCol As DataColumn = table.Columns.Add("ID", GetType(Guid))
      table.PrimaryKey = New DataColumn() {idCol}
      table.Columns.Add("FirstName", GetType(String))
      table.Columns.Add("LastName", GetType(String))
      table.Columns.Add("BirthDate", GetType(Date))

      ' Save an array of Student objects into the DataTable.
      Dim students() As Student = {New Student("John", "Doe", #1/2/1965#), _
         New Student("Ann", "Doe", #8/17/1972#), _
         New Student("Robert", "Smith", #11/1/1973#)}
      SaveObjects(table, students)

      ' Initialize an array of Studentobjects and load it from the DataTable.
      Dim studArray(table.Rows.Count - 1) As Student
      For i As Integer = 0 To studArray.Length - 1
         studArray(i) = New Student()
      Next
      LoadObjects(table, studArray)
   End Sub

   Sub IComparableInterface()
      Dim persons() As Person = {New Person("John", "Smith"), _
         New Person("Robert", "Doe"), New Person("John", "Doe")}
      Array.Sort(persons)
      ' Display all the elements in sorted order.
      For Each p As Person In persons
         Console.WriteLine(p.ReverseName)
      Next
   End Sub

   Sub IComparerInterface()
      Dim persons() As Person = {New Person("John", "Frum"), _
         New Person("Robert", "Zare"), New Person("John", "Evans")}
      ' Sort the array on name.
      Array.Sort(persons, Person.NameComparer)
      ' Display all the elements in sorted order.
      For Each p As Person In persons
         Console.WriteLine(p.CompleteName)
      Next
      Console.WriteLine()

      ' Sort the array on reversed name.
      Array.Sort(persons, Person.ReverseNameComparer)
      ' Display all the elements in sorted order.
      For Each p As Person In persons
         Console.WriteLine(p.ReverseName)
      Next
   End Sub

   Sub TestReverseComparer()
      Dim arr() As String = {"a", "c", "f", "b", "z", "q"}

      ' Reverse sort of a string array in case-sensitive mode
      Array.Sort(arr, New ReverseComparer())
      ' Reverse sort of a string array in case-insensitive mode
      Array.Sort(arr, New ReverseComparer(StringComparer.CurrentCultureIgnoreCase))

      For Each s As String In arr
         Console.WriteLine(s)
      Next
   End Sub

   Sub IClonableInterface()
      ' Define an employee and his boss.
      Dim john As New Employee("John", "Evans")
      Dim robert As New Employee("Robert", "Zare")
      john.Boss = robert

      ' Clone it. The Clone method returns a generic object, so you need a cast.
      Dim john2 As Employee = DirectCast(john.Clone(), Employee)
      ' Prove that all properties were copied.
      Console.WriteLine("{0} {1}, whose boss is {2} {3}", _
         john2.FirstName, john2.LastName, john2.Boss.FirstName, john2.Boss.LastName)
      ' => John Evans, whose boss is Robert Zare
   End Sub

   Sub ShallowAndDeepCopies()
      ' Define an employee and his boss.
      Dim john As New Employee("John", "Evans")
      Dim robert As New Employee("Robert", "Zare")
      john.Boss = robert

      ' Clone it, and prove that the Employee object was cloned into a 
      ' distinct instance, but his boss wasn't.
      Dim john2 As Employee = DirectCast(john.Clone(), Employee)
      Console.WriteLine(john Is john2)                   ' => False
      Console.WriteLine(john.Boss Is john2.Boss)         ' => True
   End Sub

   Sub DeepCopy()
      ' Define an employee and his boss.
      Dim john As New Employee2("John", "Evans")
      Dim robert As New Employee2("Robert", "Zare")
      john.Boss = robert

      ' Clone it, and prove that the Employee object was cloned into a 
      ' distinct instance, but his boss wasn't.
      Dim john2 As Employee2 = DirectCast(john.Clone(), Employee2)
      Console.WriteLine(john Is john2)                   ' => False
      Console.WriteLine(john.Boss Is john2.Boss)         ' => False
   End Sub

   Sub UsingStatement()
      ' --------------------------------------------------------------------------------
      ' WARNING: Chenge directory names if c:\temp or c:\windows folders don't exist.
      ' --------------------------------------------------------------------------------

      Using New CurrentDirectory("c:\temp")
         ' Current directory is now c:\temp.
         Console.WriteLine(Environment.CurrentDirectory)

         Using New CurrentDirectory("c:\windows")
            ' Current directory is now c:\windows.
            Console.WriteLine(Environment.CurrentDirectory)

            ' The next statement restores c:\temp as the current directory.
         End Using

         Console.WriteLine(Environment.CurrentDirectory)

         ' The next statement restores the original current directory.
      End Using
      Console.WriteLine(Environment.CurrentDirectory)
   End Sub

   Sub TestReadonlyCollectionBase()
      Dim lines As New TextLineCollection("c:\windows\win.ini")
      ' Display the last line.
      Console.WriteLine(lines(lines.Count - 1))
      ' Display all lines in a For Each loop.
      For Each s As String In lines
         Console.WriteLine(s)
      Next
   End Sub

   Sub TestGenericCollection()
      Dim col As New PersonCollection
      col.Add(New Person("John", "Evans"))    ' This statement works fine.
      col.Add(New Person("Robert", "Smith"))    ' This statement works fine.

      ' *** This statement doesn't compile.
      ' col.Add("a string")

      For Each p As Person In col
         Console.WriteLine(p.CompleteName)
      Next

   End Sub

   Sub IEnumerableInterface()
      For Each s As String In New TextFileReader("c:\windows\win.ini")
         Console.WriteLine(s)
      Next

   End Sub

   Sub TestReverseIterator()
      Dim arr() As String = {"one", "two", "three", "four", "five", "six"}
      For Each s As String In New ReverseIterator(arr)
         Console.WriteLine(s)          ' => six five four three two one
      Next
   End Sub

   Sub TestRandomIterator()
      Dim arr() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
      For Each n As Integer In New RandomIterator(arr)
         Console.WriteLine(n)
      Next
   End Sub

   Sub TestStepIterator()
      Dim arr() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
      For Each n As Integer In New StepIterator(arr, 2, 0)
         Console.Write("{0} ", n)              ' => 0 2 4 6 8
      Next
      Console.WriteLine()

      For Each n As Integer In New StepIterator(arr, 2, 1)
         Console.Write("{0} ", n)              ' => 1 3 5 7 9
      Next
      Console.WriteLine()


   End Sub
End Module
