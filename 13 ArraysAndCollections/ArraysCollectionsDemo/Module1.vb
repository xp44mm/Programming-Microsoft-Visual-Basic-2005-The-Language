Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text.RegularExpressions

Module Module1

   Sub Main()
      'TheArrayType()
      'SortingElements()
      'ClearingElements()
      'ConstrainedCopy()
      'CopyingElements()
      'TwodimensionalRedimPreserve()
      'BlockCopy()
      'SearchingValues()
      'BinarySearch()
      'JaggedArrays()
      'TestMatrix()
      'GenericIndexOf()
      'ArrayResize()
      'ArrayFindWithLoop()
      'ArrayFind()
      'ArrayFindAllWithLoop()
      'ArrayFindAll()
      'ArrayTrueForAll()
      'ArrayConvertAll()
      'ArrayForEach()
      'ArrayListType()
      'HashtableType()
      'SortedListType()
      'FindWords()
      'StackType()
      'QueueType()
      'BitArrayType()
      'BitVector32Type()
      'CollectionBaseType()
      'DictionaryBaseType()
      'NameObjectCollectionBaseType()
      'ListType()
      'DictionaryType()
      'LinkedListType()
      'SortedDictionaryType()
      'TestEvalRPN()
      'TestIndexableDictionary()
      'TestMinMaxCollection()
   End Sub

   '------------------------------------------------------
   ' The Array Type
   '------------------------------------------------------

   Sub TheArrayType()
      ' An array initialized with the powers of 2
      Dim intArr() As Integer = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512}
      ' Noninitialized two-dimensional array 
      Dim lngArr(10, 20) As Long
      ' An empty array
      Dim dblArr() As Double

      Dim res As Long = lngArr.Rank
      Console.WriteLine(res)                          ' => 2
      ' lngArr has 11*21 elements.
      res = lngArr.Length
      Console.WriteLine(res)                          ' => 231

      ' ...(Continuing previous example)...
      res = lngArr.GetLength(0)                   ' => 11, same as UBound(1)
      Console.WriteLine(res)                          ' => 231
      res = lngArr.GetLowerBound(1)               ' => 0, same as LBound(2)
      Console.WriteLine(res)                          ' => 231
      res = lngArr.GetUpperBound(1)               ' => 20, same as UBound(2)
      Console.WriteLine(res)                          ' => 231

      Dim strArr(,) As String = {{"00", "01", "02"}, {"10", "11", "12"}}
      For Each s As String In strArr
         Console.Write(s & ",")     ' => 00,01,02,10,11,12
      Next

      ' This is the required syntax if Option Strict is On.
      Dim anotherArray(,) As String = DirectCast(strArr.Clone, String(,))

      ' Create and initialize an array (10 elements).
      Dim sourceArr() As Integer = {1, 2, 3, 5, 7, 11, 13, 17, 19, 23}
      ' Create the destination array (must be same size or larger).
      Dim destArr(19) As Integer
      ' Copy the source array into the second half of the destination array.
      sourceArr.CopyTo(destArr, 10)
   End Sub

   Sub SortingElements()
      ' Fill an array with random values 
      Dim targetArray(101) As Integer
      Dim rnd As New Random
      For i As Integer = 0 To targetArray.Length - 1
         targetArray(i) = rnd.Next(0, 1000)
      Next

      ' Sort only elements [10,100] of the targetArray.
      ' Second argument is starting index; last argument is length of the subarray.
      Array.Sort(targetArray, 10, 91)

      ' Create a test array.
      Dim employees() As Employee = {New Employee("Joe", "Doe", #3/1/2001#), _
          New Employee("Robert", "Smith", #8/12/2000#), _
          New Employee("Ann", "Douglas", #11/1/1999#)}
      ' Create a parallel array of hiring dates.
      Dim hireDates(employees.Length - 1) As Date
      For i As Integer = 0 To employees.Length - 1
         hireDates(i) = employees(i).HireDate
      Next
      ' Sort the array of Employees using HireDates to provide the keys.
      Array.Sort(hireDates, employees)
      ' Prove that the array is sorted on the HireDate field.
      For Each em As Employee In employees
         Console.WriteLine(em.Description)
      Next
      Console.WriteLine()

      ' Add a fourth employee.
      ReDim Preserve employees(3)
      employees(3) = New Employee("Chris", "Doe", #5/9/2000#)
      ' Extend the key array as well – no need to reinitialize it.
      ReDim Preserve hireDates(3)
      hireDates(3) = employees(3).HireDate
      ' Re-sort the new, larger array.
      Array.Sort(hireDates, employees)
      ' Prove that the array is sorted on the HireDate field.
      For Each em As Employee In employees
         Console.WriteLine(em.Description)
      Next
      Console.WriteLine()
   End Sub

   Sub ClearingElements()
      Dim intArr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
      Dim intArr2(20) As Integer
      ' Copy the entire source array into the first half of the target array.
      Array.Copy(intArr, intArr2, 10)
      For i As Integer = 0 To 20
         Console.Write("{0} ", intArr2(i))
         ' => 1 2 3 4 5 6 7 8 9 10 0 0 0 0 0 0 0 0 0 0 0
      Next
      Console.WriteLine()
      Console.WriteLine()

      ' Copy elements at indexes 5-9 to the end of intArr2.
      Array.Copy(intArr, 5, intArr2, 15, 5)
      ' This is the first element that has been copied.
      Console.WriteLine(intArr2(15))                      ' => 6

      Try

         Dim intArr3() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
         ' This Copy operation succeeds even if array types are different.
         Dim lngArr3(20) As Long
         Array.Copy(intArr3, lngArr3, 10)
         ' This Copy operation fails with ArrayTypeMismatchException.
         '   (But you can carry it out with an explicit For loop.)
         Dim shoArr3(20) As Short
         Array.Copy(intArr3, shoArr3, 10)
      Catch ex As Exception
         Console.WriteLine("ERROR: " & ex.GetType().Name)
      End Try
   End Sub

   Sub ConstrainedCopy()
      ' prove tha ContrainedCopy can't be used when a narrowing cast is necessary.
      Dim source() As Object = {"A", "A", "A", "A"}
      Dim dest() As String = {" ", "", "", ""}
      Try
         Array.ConstrainedCopy(source, 0, dest, 0, source.Length)
      Catch ex As Exception
         Console.WriteLine("ERROR: " & ex.Message)
      End Try
   End Sub

   Sub CopyingElements()
      Dim lngArr4() As Long = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
      ' Delete element at index 4.
      Array.Copy(lngArr4, 5, lngArr4, 4, 5)
      ' Complete the delete operation by clearing the last element.
      Array.Clear(lngArr4, lngArr4.Length - 1, 1)
      ' Now the array contains: {1, 2, 3, 4, 6, 7, 8, 9, 10, 0}

   End Sub

   Function RedimPreserve(Of T)(ByVal arr(,) As T, ByVal rows As Integer, _
      ByVal cols As Integer) As T(,)
      Dim newArr(rows, cols) As T
      For r As Integer = 0 To Math.Min(arr.GetUpperBound(0), rows)
         For c As Integer = 0 To Math.Min(arr.GetUpperBound(1), cols)
            newArr(r, c) = arr(r, c)
         Next
      Next
      Return newArr
   End Function

   Sub TwodimensionalRedimPreserve()
      Dim arr(,) As Integer = {{1, 2}, {3, 4}, {5, 6}}
      Dim rows As Integer = 4
      Dim columns As Integer = 3

      ' We want to "redim preserve" this array so that it size becomes (rows, columns).
      ' Create a temporary array with as many rows as required, but same number of columns.
      Dim tmpArr(rows, arr.GetUpperBound(1)) As Integer
      ' Next statement copies all elements from old array into the temporary one.
      Array.Copy(arr, tmpArr, Math.Min(arr.Length, tmpArr.Length))
      ' Add or remove columns as desired.
      ReDim Preserve tmpArr(rows, columns)
      ' Replace the old array with the temporary one.
      arr = tmpArr
   End Sub

   Sub BlockCopy()
      Dim chars() As Char = {"A"c, "B"c, "C"c, "D"c}
      Dim codes(3) As UShort
      ' Syntax is: BlockCopy(sourceArray, sourceIndex, destArray, destIndex, byteCount)
      Buffer.BlockCopy(chars, 0, codes, 0, 8)
      For Each code As UShort In codes
         Console.Write("{0} ", code)               ' => 65 66 67 68
      Next
      Console.WriteLine()

      ' Inspecting the bytes of a Long array
      Dim values() As Double = {123, 456, 789}     ' 3 Doubles = 24 bytes
      Dim bytes(23) As Byte
      Buffer.BlockCopy(values, 0, bytes, 0, 24)
      For Each code As UShort In bytes
         Console.Write("{0} ", code)               ' => 0 0 0 0 0 192 94 64 0 0 0 0 0 128 124 64 0 0 0 0 0 168 136 64
      Next
      Console.WriteLine()
   End Sub

   Sub SearchingValues()
      Dim strArr() As String = {"Robert", "Joe", "Ann", "Chris", "Joe"}
      Dim index As Integer = Array.IndexOf(strArr, "Ann")      ' => 2
      Console.WriteLine(index)
      ' Note that string searches are case sensitive.
      index = Array.IndexOf(strArr, "ANN")                     ' => -1
      Console.WriteLine(index)
      Console.WriteLine()

      ' Search for all the occurrences of the "Joe" string.
      index = Array.IndexOf(strArr, "Joe")
      Do Until index < 0
         Console.WriteLine("Found at index {0}", index)
         ' Search next occurrence.
         index = Array.IndexOf(strArr, "Joe", index + 1)
      Loop
      Console.WriteLine()

      ' A revised version of the search loop, which searches
      ' from higher indexes toward the beginning of the array.
      index = Array.LastIndexOf(strArr, "Joe", strArr.Length - 1)
      Do Until index < 0
         Console.WriteLine("Found at index {0}", index)
         index = Array.LastIndexOf(strArr, "Joe", index - 1)
      Loop
      Console.WriteLine()
   End Sub

   Sub BinarySearch()
      ' Binary search on a sorted array
      Dim strArr2() As String = {"Ann", "Chris", "Joe", "Robert", "Sam"}
      Dim index As Integer = Array.BinarySearch(strArr2, "Chris")             ' => 1
      Console.WriteLine(index)

      index = Array.BinarySearch(strArr2, "David")
      If index >= 0 Then
         Console.WriteLine("Found at index {0}", index)
      Else
         ' Negate the result to get the index for the insertion point.
         index = Not index
         Console.WriteLine("Not Found. Insert at index {0}", index)
         ' => Not found. Insert at index 2
      End If

      index = Array.BinarySearch(strArr2, 0, 3, "Chris")        ' => 1
      Console.WriteLine(index)
      Console.WriteLine()
   End Sub

   Sub JaggedArrays()
      ' Initialize an array of arrays.
      Dim arr()() As String = {New String() {"a00"}, _
         New String() {"a10", "a11"}, _
         New String() {"a20", "a21", "a22"}, _
         New String() {"a30", "a31", "a32", "a33"}}

      ' Show how you can reference an element.
      Dim elem As String = arr(3)(1)                  ' => a31
      Console.WriteLine(elem)
      ' Assign an entire row.
      arr(0) = New String() {"a00", "a01", "a02"}
      ' Read an element just added.
      elem = arr(0)(2)                                ' => a02
      Console.WriteLine(elem)

      ' Expand one of the rows.
      ReDim Preserve arr(1)(3)
      ' Assign the new elements. (Currently they are Nothing.)
      arr(1)(2) = "a12"
      arr(1)(3) = "a13"
      ' Read back one of them.
      elem = arr(1)(2)                                ' => a12
      Console.WriteLine(elem)
      Console.WriteLine()
   End Sub

   Sub TestMatrix()
      Dim mat As New Matrix(Of Double)(100, 200)
      mat(10, 1) = 123.45
      Console.WriteLine(mat(10, 1))                ' => 123.45

      ' benchmarks
      Dim sw As Stopwatch
      Dim arr(100, 200) As Double

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         For r As Integer = 0 To arr.GetUpperBound(0)
            For c As Integer = 0 To arr.GetUpperBound(1)
               arr(r, c) = 1.2345
            Next
         Next
      Next
      sw.Stop()
      Console.WriteLine("2-dim arrays: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         For r As Integer = 0 To arr.GetUpperBound(0)
            For c As Integer = 0 To arr.GetUpperBound(1)
               mat(r, c) = 1.2345
            Next
         Next
      Next
      sw.Stop()
      Console.WriteLine("Matrix: {0} msecs.", sw.ElapsedMilliseconds)
   End Sub

   Sub GenericIndexOf()
      Dim res As Integer

      ' Create an array with a nonzero value in the last element.
      Dim arr(100000) As Short
      arr(100000) = -1

      Dim sw As Stopwatch
      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         ' Search for the nonzero element.
         res = Array.IndexOf(arr, -1)
      Next
      sw.Stop()
      Console.WriteLine("Nongeneric IndexOf method with Int16 array: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         ' Search for the nonzero element.
         res = Array.IndexOf(Of Short)(arr, -1)
      Next
      sw.Stop()
      Console.WriteLine("Generic IndexOf method with Int16 array: {0} msecs.", sw.ElapsedMilliseconds)

      ' Repeat the benchmark with a reference type
      Dim arr2(100000) As String
      arr2(100000) = "A"

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         ' Search for the nonzero element.
         res = Array.IndexOf(arr2, "A")
      Next
      sw.Stop()
      Console.WriteLine("Nongeneric IndexOf method with String array: {0} msecs.", sw.ElapsedMilliseconds)

      sw = New Stopwatch()
      sw.Start()
      For i As Integer = 1 To 1000
         ' Search for the nonzero element.
         res = Array.IndexOf(Of String)(arr2, "A")
      Next
      sw.Stop()
      Console.WriteLine("Generic IndexOf method with String array: {0} msecs.", sw.ElapsedMilliseconds)
   End Sub

   Sub ArrayResize()
      Dim arr() As Integer = {0, 1, 2, 3, 4}

      ' Extend the array to contain 10 elements, but preserve existing ones.
      ' Same as ReDim Preserve arr(10) 
      Array.Resize(Of Integer)(arr, 10)
      Console.WriteLine(arr.Length)             ' => 10

      ' test the custom Resize(Of T) method
      Dim arr2(10, 20) As Integer

      Resize(Of Integer)(arr2, 30, 60)
      Console.WriteLine(arr2.Length)             ' => 1800
   End Sub

   ' The procedure of the form Predicate(Of T)
   Private Function IsMultipleOfTen(ByVal n As Integer) As Boolean
      Return n > 0 AndAlso (n Mod 10) = 0
   End Function

   Sub ArrayFindWithLoop()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}
      Dim result As Integer = 0
      For i As Integer = 0 To arr.Length - 1
         If IsMultipleOfTen(arr(i)) Then
            result = arr(i)
            Exit For
         End If
      Next
      If result = 0 Then
         Console.WriteLine("Not found")
      Else
         Console.WriteLine("Result = {0}", result)     ' => Result = 60
      End If
   End Sub

   Sub ArrayFind()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}

      ' Test Array.Find.
      Dim res As Integer = Array.Find(Of Integer)(arr, AddressOf IsMultipleOfTen)
      Console.WriteLine(res)                           ' => 60

      ' Test Array.FindLast.
      res = Array.FindLast(Of Integer)(arr, AddressOf IsMultipleOfTen)
      Console.WriteLine(res)                           ' => 10

      ' Test Array.Exists
      If Array.Exists(Of Integer)(arr, AddressOf IsMultipleOfTen) Then
         Console.WriteLine("The array contains at least one positive multiple of ten.")
      Else
         Console.WriteLine("The array doesn't contain any positive multiple of ten.")
      End If

      ' Test Array.FindIndex
      Dim index As Integer = Array.FindIndex(Of Integer)(arr, AddressOf IsMultipleOfTen)
      If index < 0 Then
         Console.WriteLine("Element not found")
      Else
         Console.WriteLine("Element {0} found at index {1}", arr(index), index)
         ' => Element 60 found at index 2
      End If

      index = Array.FindLastIndex(Of Integer)(arr, AddressOf IsMultipleOfTen)  ' => 8
      If index < 0 Then
         Console.WriteLine("Element not found")
      Else
         Console.WriteLine("Element {0} found at index {1}", arr(index), index)
         ' => Element 10 found at index 8
      End If
   End Sub

   Sub ArrayFindAllWithLoop()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}

      Dim index As Integer = -1
      Dim al As New ArrayList()    ' Can replace with List(Of Integer) for better performance.
      Do
         ' Find the next match, exit the loop if not found.
         index = Array.FindIndex(Of Integer)(arr, index + 1, AddressOf IsMultipleOfTen)
         If index < 0 Then Exit Do
         ' Remember the match in an ArrayList.
         al.Add(arr(index))
      Loop
      ' Convert the ArrayList to a strong-typed array.
      Dim matches() As Integer = CType(al.ToArray(GetType(Integer)), Integer())
      Console.WriteLine("Found {0} matches", matches.Length)   ' => Found 3 matches
   End Sub

   Sub ArrayFindAll()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}
      ' This statement is equivalent to the previous code snippet.
      Dim matches() As Integer = Array.FindAll(Of Integer)(arr, AddressOf IsMultipleOfTen)
      Console.WriteLine("Found {0} matches", matches.Length)   ' => Found 3 matches
   End Sub

   Sub ArrayTrueForAll()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}
      If Array.TrueForAll(Of Integer)(arr, AddressOf IsMultipleOfTen) Then
         Console.WriteLine("All elements in the array are positive multiples of ten.")
      Else
         Console.WriteLine("There is at least one element that isn't a positive multiple of ten.")
      End If

      ' IMplement the missing FalseForAll method by means of the ReversePredicate type
      Dim arr2() As Integer = {1, 3, 4, 66, 79, -4}
      Dim revPred As New ReversePredicate(Of Integer)(AddressOf IsMultipleOfTen)
      If Array.TrueForAll(Of Integer)(arr2, AddressOf revPred.Reverse) Then
         Console.WriteLine("No elements in the array are positive multiples of ten.")
      Else
         Console.WriteLine("There is at least one element that is a positive multiple of ten.")
      End If
   End Sub

   ' a method compatible with the Convert(T, U) delegate
   Private Function ConvertToHex(ByVal n As Integer) As String
      Return Convert.ToString(n, 16)
   End Function

   Sub ArrayConvertAll()
      Dim arr() As Integer = {1, 3, 60, 4, 30, 66, -10, 79, 10, -4}

      ' Convert to hex values
      Dim hexValues() As String = Array.ConvertAll(Of Integer, String) _
         (arr, AddressOf ConvertToHex)
      For Each s As String In hexValues
         Console.Write("{0} ", s)
      Next
      Console.WriteLine()

      ' (Notice that you can also drop the Conversion prefix.)
      hexValues = Array.ConvertAll(Of Integer, String)(arr, AddressOf Conversion.Hex)
      For Each s As String In hexValues
         Console.Write("{0} ", s)
      Next
      Console.WriteLine()

      ' Convert to string values
      Dim arrStr() As String = Array.ConvertAll(Of Integer, String) _
         (arr, AddressOf Convert.ToString)
      For Each s As String In arrStr
         Console.Write("{0} ", s)
      Next
      Console.WriteLine()

      ' Convert an array of strings to uppercase
      arrStr = New String() {"abc", "def", "ghi"}
      arrStr = Array.ConvertAll(Of String, String)(arrStr, AddressOf UCase)
      For Each s As String In arrStr
         Console.Write("{0} ", s)
      Next
      Console.WriteLine()
   End Sub

   Sub ArrayForEach()
      Dim arrStr() As String = {"abc", "def", "ghi"}
      Array.ForEach(Of String)(arrStr, AddressOf Console.WriteLine)
   End Sub

   '------------------------------------------------------
   ' The System.Collections Namespace
   '------------------------------------------------------

   Sub ArrayListType()
      ' Create an ArrayList with default initial capacity of 4 elements.
      Dim al As New ArrayList()
      ' Create an ArrayList with initial capacity of 1000 elements.
      Dim al2 As New ArrayList(1000)
      ' Create an array on-the-fly and pass it to the ArrayList constructor.
      Dim al3 As New ArrayList(New String() {"one", "two", "three"})

      ' Make the ArrayList take just the memory that it strictly needs.
      al.Capacity = al.Count
      ' Another way to achieve the same result
      al.TrimToSize()

      ' Create an ArrayList with 100 elements equal to an empty string.
      Dim al4 As ArrayList = ArrayList.Repeat("", 100)

      ' Be sure that you start with an empty ArrayList.
      al.Clear()
      ' Append the elements "Joe" and "Ann" at the end of the ArrayList.
      al.Add("Joe")
      al.Add("Ann")
      ' Insert "Robert" item at the beginning of the list. (Index is 0-based.)
      al.Insert(0, "Robert")
      ' Remove "Joe" from the list.
      al.Remove("Joe")
      ' Remove the first element of the list ("Robert" in this case).
      al.RemoveAt(0)


      ' Two ways to remove all the elements with given value from an arraylist

      ' Using the Contains method is concise but not very efficient.
      Do While al.Contains("element to remove")
         al.Remove("element to remove")
      Loop

      ' A more efficient technique: loop until the Count property becomes constant.
      Dim saveCount As Integer
      Do
         saveCount = al.Count
         al.Remove("element to remove")
      Loop While al.Count < saveCount

      ' Extract elements to an Object array (never throws an exception).
      Dim objArr() As Object = al.ToArray()
      ' Extract elements to a String array (might throw an InvalidCastException).
      Dim strArr() As String = DirectCast(al.ToArray(GetType(String)), String())

      ' Same as above but uses the CopyTo method.
      al = New ArrayList(New String() {"a", "b", "c", "d", "e", "f", "g", "h"})
      ' (Note that the target array must be large enough.)
      Dim strArr2(al.Count) As String
      al.CopyTo(strArr2)
      ' Copy only items [1,2], starting at element 4 in the target array.
      Dim strArr3() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
      ' Syntax is: CopyTo(sourceIndex, target, destIndex, count).
      al.CopyTo(0, strArr3, 4, 2)
   End Sub

   Sub HashtableType()
      ' Default load factor and initial capacity
      Dim ht As New Hashtable()
      ' Default load factor and specified initial capacity
      Dim ht2 As New Hashtable(1000)
      ' Specified initial capability and custom load factor
      Dim ht3 As New Hashtable(1000, 0.8)

      ' Decrease the load factor of the current Hashtable.
      ht = New Hashtable(ht, 0.5)

      ' Syntax for Add method is Add(key, value).
      ht.Add("Joe", 12000)
      ht.Add("Ann", 13000)
      ' Referencing a new key creates an element.
      ht.Item("Robert") = 15000
      ' Item is the default member, so you can omit its name.
      ht("Chris") = 11000
      Console.Write(ht("Joe"))     ' => 12000
      ' The Item property lets you overwrite an existing element.
      ' (You need CInt or CType if Option Strict is On.)
      ht("Ann") = CInt(ht("Ann")) + 1000
      ' By default keys are compared in case-insensitive mode,
      ' so the following statement creates a *new* element.
      ht("ann") = 15000
      ' Reading a nonexistent element doesn't create it.
      Console.WriteLine(ht("Lee"))       ' Doesn't display anything.

      ' Remove an element given its key.
      ht.Remove("Chris")
      ' How many elements are now in the Hashtable?
      Console.WriteLine(ht.Count)        ' => 4

      ' Adding an element that already exists throws an exception.
      Try
         ht.Add("Joe", 11500)             ' Throws ArgumentException.
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try

      ht.Clear()
      Dim values As ICollection = ht.Values
      ht.Add("Chris", 11000)
      ' Prove that the collection continue to be linked to the Hashtable.
      Console.WriteLine(values.Count)         ' => 1

      Dim ht4 As Hashtable = CollectionsUtil.CreateCaseInsensitiveHashtable()

      ' Test the ability to pass a keycomparer
      ht = New Hashtable(New FloatingPointKeyComparer(2))
      ht.Add(1.123, "first")
      ht.Add(1.456, "second")
      ' Prove that keys that round to the same Double number resolve to same item.
      Console.WriteLine(ht(1.119))              ' => first
   End Sub

   Sub SortedListType()
      ' A SortedList with default capacity (16 entries)
      Dim sl As New SortedList()
      ' A SortedList with specified initial capacity
      Dim sl2 As New SortedList(1000)

      ' A SortedList can be initialized with all the elements in an IDictionary.
      Dim ht As New Hashtable()
      ht.Add("Robert", 100)
      ht.Add("Ann", 200)
      ht.Add("Joe", 300)
      Dim sl3 As New SortedList(ht)

      For Each de As DictionaryEntry In sl3
         Console.WriteLine("sl3('{0}') = {1}", de.Key, de.Value)
      Next
      Console.WriteLine()

      ' A SortedList that sorts elements through a custom IComparer
      Dim sl4 As New SortedList(New ReverseStringComparer())

      ' A SortedList that loads all its elements from a Hashtable and 
      ' sorts them with a custom IComparer object.
      Dim sl5 As New SortedList(ht, New ReverseStringComparer)
      For Each de As DictionaryEntry In sl5
         Console.WriteLine("sl3('{0}') = {1}", de.Key, de.Value)
      Next
      Console.WriteLine()

      Dim sl6 As SortedList = CollectionsUtil.CreateCaseInsensitiveSortedList()

      sl = New SortedList()
      ' Get a live reference to key and value collections.
      Dim alKeys As IList = sl.GetKeyList()
      Dim alValues As IList = sl.GetValueList()
      ' Add some values, out-of-order.
      sl.Add(3, "three")
      sl.Add(2, "two")
      sl.Add(1, "one")
      ' Display values in sorted order.
      For i As Integer = 0 To sl.Count - 1
         Console.WriteLine("{0} = ""{1}""", alKeys(i), alValues(i))
      Next
      ' Any attempt to modify the IList object throws an exception.
      Try
         alValues.Insert(0, "four")           ' Throws NotSupportedException error.
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub

   Sub FindWords()
      ' Read the contents of a text file. (Change file path as needed.)
      Dim filetext As String = File.ReadAllText("c:\document.txt")
      ' Use regular expressions to parse individual words, put them in an ArrayList.
      Dim alWords As New ArrayList()
      For Each m As Match In Regex.Matches(filetext, "\w+")
         alWords.Add(m.Value)
      Next
      Console.WriteLine("Found {0} words.", alWords.Count)

      ' Create a case-insensitive Hashtable.
      Dim htWords As Hashtable = CollectionsUtil.CreateCaseInsensitiveHashtable()
      ' Process each word in the ArrayList.
      For Each word As String In alWords
         ' Search this word in the Hashtable.
         Dim elem As Object = htWords(word)
         If elem Is Nothing Then
            ' Not found: this is the first occurrence.
            htWords(word) = 1
         Else
            ' Found: increment occurrence count.
            htWords(word) = CInt(elem) + 1
         End If
      Next
      ' Sort all elements alphabetically.
      Dim slWords As New SortedList(htWords)
      ' Display words and their occurrence count.
      For Each de As DictionaryEntry In slWords
         Console.WriteLine("{0} ({1} occurrences)", de.Key, de.Value)
      Next
   End Sub

   Sub StackType()
      Dim st As New Stack()
      ' Push three values onto the stack.
      st.Push(10)
      st.Push(20)
      st.Push(30)
      ' Pop the value on top of the stack, and display its value.
      Console.WriteLine(st.Pop())                   ' => 30
      ' Read the value on top of the stack without popping it.
      Console.WriteLine(st.Peek())                  ' => 20
      ' Now pop it.
      Console.WriteLine(st.Pop())                   ' => 20
      ' Determine how many elements are now in the stack.
      Console.WriteLine(st.Count)                   ' => 1
      ' Pop the only value still on the stack.
      Console.WriteLine(st.Pop())                   ' => 10
      ' Check that the stack is now empty.
      Console.WriteLine(st.Count)                   ' => 0

      ' Is the value 10 somewhere in the stack?
      If st.Contains(10) Then Console.Write("Found")
      ' Extract all the items to an array.
      Dim values() As Object = st.ToArray()
      ' Clear the stack.
      st.Clear()

      For Each o As Object In st
         Console.WriteLine(o)
      Next
   End Sub

   Sub QueueType()
      ' A queue with initial capacity of 200 elements; a growth factor equal to 1.5
      ' (When new room is needed, the capacity will become 300, then 450, 675, etc.)
      Dim qu1 As New Queue(200, 1.5)
      ' A queue with 100 elements and a default growth factor of 2
      Dim qu2 As New Queue(100)
      ' A queue with 32 initial elements and a default growth factor of 2
      Dim qu3 As New Queue()

      Dim qu As New Queue(100)
      ' Insert three values in the queue.
      qu.Enqueue(10)
      qu.Enqueue(20)
      qu.Enqueue(30)
      ' Extract the first value, and display it.
      Console.WriteLine(qu.Dequeue())                ' => 10
      ' Read the next value, but don't extract it.
      Console.WriteLine(qu.Peek())                   ' => 20
      ' Extract it.
      Console.WriteLine(qu.Dequeue())                ' => 20
      ' Check how many items are still in the queue.
      Console.WriteLine(qu.Count)                    ' => 1
      ' Extract the last element, and check that the queue is now empty.
      Console.WriteLine(qu.Dequeue())                ' => 30
      Console.WriteLine(qu.Count)                    ' => 0
   End Sub

   Sub BitArrayType()
      ' Provide the number of elements (all initialized to False).
      Dim ba As New BitArray(1024)
      ' Provide the number of elements, and initialize them to a value.
      Dim ba2 As New BitArray(1024, True)

      ' Initialize the BitArray from an array of Boolean, Byte, or Integer.
      Dim boolArr(1023) As Boolean
      ' Initialize the boolArr array here.
      For i As Integer = 0 To boolArr.Length - 1
         boolArr(i) = (i Mod 3) = 0
      Next
      Dim ba3 As New BitArray(boolArr)

      ' Initialize the BitArray from another BitArray object.
      Dim ba4 As New BitArray(ba)

      ' Set element at index 9, and read it back.
      ba.Set(9, True)
      Console.WriteLine(ba.Get(9))            ' => True

      ' Bitwise copy to an array of Integers
      Dim intArr(31) As Integer              ' 32 elements * 32 bits each = 1024 bits
      ' Second argument is the index in which the copy begins in target array.
      ba.CopyTo(intArr, 0)
      ' Check that bit 9 of first element in intArr is set.
      Console.WriteLine(intArr(0))           ' => 512

      Dim bitCount As Integer = 0
      For Each b As Boolean In ba
         If b Then bitCount += 1
      Next
      Console.WriteLine("Found {0} True values.", bitCount)
   End Sub

   Sub BitVector32Type()
      Dim bv As New BitVector32()
      ' Set one element and read it back.
      bv(1) = True
      Console.WriteLine(bv(1))                ' => True

      ' Initialize all elements to True.
      bv = New BitVector32(-1)

      bv = New BitVector32()
      ' Create three sections, of 4, 5, and 6 bits each.
      Dim se1 As BitVector32.Section = BitVector32.CreateSection(15)
      Dim se2 As BitVector32.Section = BitVector32.CreateSection(31, se1)
      Dim se3 As BitVector32.Section = BitVector32.CreateSection(63, se2)

      ' Assign a given value to each section.
      bv(se1) = 10
      bv(se2) = 20
      bv(se3) = 40
      ' Read values back.
      Console.WriteLine(bv(se1))        ' => 10
      Console.WriteLine(bv(se2))        ' => 20
      Console.WriteLine(bv(se3))        ' => 40

      ' Read the entire field as a 32-bit value.
      Console.WriteLine(bv.Data)                      ' => 20810
      Console.WriteLine(bv.Data.ToString("X"))        ' => 514A
   End Sub

   '------------------------------------------------------
   ' Abstract Types for Strong-typed Collections
   '------------------------------------------------------

   Sub CollectionBaseType()
      Dim john As New Person("John", "Doe")
      john.Children.Add(New Person("Robert", "Doe"))    ' This works.
      ' The next statement doesn't even compile if Option Strict is On.
      'john.Children.Add(New Object())                   ' Compilation error! 

      Console.WriteLine(john.Children(0).FirstName)      ' Robert

      ' These statements would raise neither a compiler warning nor a runtime error
      ' if it weren't for the OnValidate protected method in PersonCollection
      Try
         DirectCast(john.Children, IList).Item(0) = New Object()
         DirectCast(john.Children, IList).Add(New Object())
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub

   Sub DictionaryBaseType()
      Dim dict As New PersonDictionary()
      dict.Add("John", New Person("John", "Doe"))
      dict.Add("Ann", New Person("Ann", "Smith"))
      Console.WriteLine(dict("John").LastName)
   End Sub

   Sub NameObjectCollectionBaseType()
      Dim col As New PersonCollection2()
      col.Add("John", New Person("John", "Doe"))
      col.Add("Ann", New Person("Ann", "Doe"))
      col.Add("Robert", New Person("Robert", "Smith"))

      ' Visit elements by index
      For i As Integer = 0 To col.Count - 1
         Console.WriteLine(col(i).ReverseName)
      Next
      Console.WriteLine()

      ' Visit element by key
      Console.WriteLine(col("John").ReverseName)
      Console.WriteLine(col("Ann").ReverseName)
      Console.WriteLine(col("Robert").ReverseName)
   End Sub

   '------------------------------------------------------
   ' Generic Collections
   '------------------------------------------------------

   Sub ListType()
      ' Copy elements between two strong-typed collections.
      Dim persons As New List(Of Person)
      persons.Add(New Person("John", "Doe"))
      persons.Add(New Person("Ann", "Doe"))
      persons.Add(New Person("Robert", "Smith"))

      ' Create a new collection and initialize it with 3 elements from first collection.
      Dim persons2 As New List(Of Person)(persons.GetRange(0, 3))
      ' Add elements 1-2 from first collection.
      persons2.AddRange(persons.GetRange(1, 2))

      Dim arr() As Person = {New Person("Robert", "Doe"), _
         New Person("Ann", "Smith")}
      ' Insert these elements at the beginning of the collection.
      persons.InsertRange(0, arr)

      ' Sort using a delegate
      persons = New List(Of Person)
      persons.Add(New Person("John", "Doe"))
      persons.Add(New Person("Ann", "Doe"))
      persons.Add(New Person("Robert", "Smith"))
      persons.Sort(AddressOf ComparePersonsDesc)
      For Each p As Person In persons
         Console.WriteLine(p.ReverseName)
      Next

      Dim list As New List(Of String)
      ' Fill the list and process its elements...
      list.Add("")
      list.Add(Nothing)
      list.Add("")
      If list.TrueForAll(AddressOf String.IsNullOrEmpty) Then
         Console.WriteLine("All elements are null or empty strings.")
      End If

      Dim testValue As String = "ABC"
      If list.TrueForAll(AddressOf testValue.Equals) Then
         Console.WriteLine("All elements are equal to 'ABC'")
      Else
         Console.WriteLine("At least one element is different from 'ABC'")
      End If

      ' Create two strong-typed collections of Double values.
      Dim list1 As New List(Of Double)(New Double() {1, 2, 3, 4, 5, 6, 7, 8, 9})
      Dim list2 As New List(Of Double)(New Double() {0, 9, 12, 3, 6})
      ' Check whether the second collection is a subset of the first one.
      Dim isSubset As Boolean = list2.TrueForAll(AddressOf list1.Contains)   ' => False

      ' One statement to find all the elements in list2 that are contained in list1.
      Dim list3 As List(Of Double) = list2.FindAll(AddressOf list1.Contains)
      ' Remove from list1 and list2 the elements that they have in common.
      list1.RemoveAll(AddressOf list3.Contains)
      list2.RemoveAll(AddressOf list3.Contains)

      ' Display the elements in the three lists.
      list1.ForEach(AddressOf Console.WriteLine)          ' => 1 2 4 5 7 8
      Console.WriteLine()
      list2.ForEach(AddressOf Console.WriteLine)          ' => 0 12
      Console.WriteLine()
      list3.ForEach(AddressOf Console.WriteLine)          ' => 9 3 6
      Console.WriteLine()

      ' Get a read-only wrapper of the original list.
      Dim roList As ReadOnlyCollection(Of Double) = list1.AsReadOnly()
      Console.WriteLine(roList.Count = list1.Count)           ' => True
      ' Prove that roList reflects all the operations on the original list.
      list1.Add(123)
      Console.WriteLine(roList.Count = list1.Count)           ' => True
   End Sub

   ' This function can be used to sort in descending direction
   Private Function ComparePersonsDesc(ByVal p1 As Person, ByVal p2 As Person) As Integer
      ' Notice that the order of arguments is reversed.
      Return p2.ReverseName.CompareTo(p1.ReverseName)
   End Function

   Sub DictionaryType()
      Dim dictPersons As New Dictionary(Of String, Person)
      dictPersons.Add("John Doe", New Person("John", "Doe"))
      dictPersons.Add("Robert Smith", New Person("Robert", "Smith"))

      ' use the NameEqualityComparer type to manage a dictionary of Persons whose 
      ' elements can be retrieved by providing a name in several different formats:
      dictPersons = New Dictionary(Of String, Person)(New NameEqualityComparer())
      dictPersons.Add("John Doe", New Person("Joe", "Doe"))
      dictPersons.Add("Robert Smith", New Person("Robert", "Smith"))
      dictPersons.Add("Ann Doe", New Person("Ann", "Doe"))
      ' Prove that the last element can be retrieved by providing a key in 
      ' either the (last,first) format or the (first last) format, that spaces
      ' are ignored, and that character casing isn't significant.
      Dim name As String
      name = dictPersons("robert smith").ReverseName
      Console.WriteLine(name) ' => Smith, Robert 
      name = dictPersons("SMITH, robert").ReverseName
      Console.WriteLine(name) ' => Smith, Robert 

      If dictPersons.Remove("john doe") Then
         Console.WriteLine("Element John Doe has been removed")
      Else
         Console.WriteLine("Element John Doe hasn't been found")
      End If
      Console.WriteLine()

      For Each kvp As KeyValuePair(Of String, Person) In dictPersons
         ' You can reference a member of the Person class in strong-typed mode.
         Console.WriteLine("Key={0} FirstName={1}", kvp.Key, kvp.Value.FirstName)
      Next

      Dim p As Person = Nothing
      If dictPersons.TryGetValue("ann doe", p) Then
         ' The variable p contains a reference to the found element.
         Console.WriteLine("Found {0}", p.ReverseName)
      Else
         Console.WriteLine("Not found")
      End If
   End Sub

   Sub LinkedListType()
      Dim lnkList As New LinkedList(Of Person)
      ' An empty linked list has no first or last node.
      Console.WriteLine(lnkList.First Is Nothing)        ' => True
      Console.WriteLine(lnkList.Last Is Nothing)         ' => True

      ' Add the first node of the list.
      Dim p1 As New Person("John", "Doe")
      lnkList.AddFirst(p1)
      ' When the list contains only one node, the first and last nodes coincide.
      Console.WriteLine(lnkList.First Is lnkList.Last)         ' => True

      ' Add a new node after the list head.
      lnkList.AddAfter(lnkList.First, New Person("Ann", "Doe"))
      ' The new node has become the list's tail node.
      Console.WriteLine(lnkList.Last.Value.ReverseName)     ' => Doe, Ann
      ' Add a new node immediately before the list tail.
      lnkList.AddBefore(lnkList.Last, New Person("Robert", "Smith"))
      ' Add a new node after the current list tail (it becomes the new tail).
      lnkList.AddLast(New Person("James", "Douglas"))
      ' Now the list contains four elements.
      Console.WriteLine(lnkList.Count)                      ' => 4

      For Each p As Person In lnkList
         Console.Write("{0} ", p.FirstName)      ' => Joe Robert Ann James
      Next
      Console.WriteLine()

      ' Visit all nodes in reverse order.
      Dim node As LinkedListNode(Of Person) = lnkList.Last
      Do Until node Is Nothing
         Console.WriteLine(node.Value.ReverseName)
         node = node.Previous
      Loop

      ' Change last name from Doe to Douglas.
      node = lnkList.First
      Do Until node Is Nothing
         If node.Value.LastName = "Doe" Then node.Value.LastName = "Douglas"
         node = node.Next
      Loop
      For Each p As Person In lnkList
         Console.Write("{0} ", p.LastName)      ' => Douglas Smith Douglas Douglas
      Next
      Console.WriteLine()


      Dim aList As New LinkedList(Of Person)
      aList.AddFirst(New LinkedListNode(Of Person)(Nothing))
      ' You can now add all nodes with a plain AddLast method.
      aList.AddLast(New Person("Joe", "Doe"))
      aList.AddLast(New Person("Ann", "Doe"))
      aList.AddLast(New Person("Robert", "Smith"))

      ' We are sure that the first node exist, thus next statement can never throw.
      Dim aNode As LinkedListNode(Of Person) = aList.First.Next
      Do Until aNode Is Nothing
         Console.WriteLine(aNode.Value.ReverseName)
         aNode = aNode.Next
      Loop

      aNode = aList.First.Next
      Do Until aNode Is Nothing
         ' Remove this node if the last name is Doe.
         If aNode.Value.LastName = "Doe" Then
            ' Backtrack to previous node and remove the node that was current.
            ' (We can be sure that the previous node exists.)
            aNode = aNode.Previous
            aList.Remove(aNode.Next)
         End If
         aNode = aNode.Next
      Loop

      Console.WriteLine("The list contains {0} persons", aList.Count - 1)
   End Sub

   Sub SortedDictionaryType()
      Dim fileDict As New SortedDictionary(Of String, String)(New FileExtensionComparer())
      ' Load some elements.
      fileDict.Add("c:\foo.txt", "contents of foo.txt...")
      fileDict.Add("c:\data.txt", "contents of data.txt...")
      fileDict.Add("c:\data.doc", "contents of data.doc...")
      ' Check that files have been sorted on their extension.
      For Each kvp As KeyValuePair(Of String, String) In fileDict
         Console.Write("{0}, ", kvp.Key)    ' => c:\data.doc, c:\data.txt, c:\foo.txt,
      Next
      Console.WriteLine()

      Dim text As String = Nothing
      If fileDict.TryGetValue("foo.txt", text) Then
         ' The text variable contains the value of the "foo.txt" element.
         Console.WriteLine(text)
      End If

      ' Display the value for the first item.
      Dim values(fileDict.Count - 1) As String
      fileDict.Values.CopyTo(values, 0)
      Console.WriteLine(values(0))

   End Sub

   Sub TestEvalRPN()
      Dim res As Double = EvalRPN("12 34 + 56 78 - *")  ' => -1012   
      Console.WriteLine(res)
      res = EvalRPN("123 456 + 2 /")                    ' => 289.5 
      Console.WriteLine(res)

      Try
         res = EvalRPN("123 456 + 2 ")                     ' => Throws exception.
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try

      Try
         res = EvalRPN("123 456 + 2 / *")                  ' => Throws exception.
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try

   End Sub

   Sub TestIndexableDictionary()
      Dim idPersons As New IndexableDictionary(Of String, Person)
      idPersons.Add("Smith, Robert", New Person("Robert", "Smith"))
      idPersons.Add("Doe, Ann", New Person("Ann", "Doe"))
      Console.WriteLine(idPersons(0).ReverseName)         ' => Doe, Ann
   End Sub

   Sub TestMinMaxCollection()
      Dim col As New MinMaxCollection(Of Double)
      ' MinValue and MaxValue are always updated during these insertions.
      col.Add(123) : col.Add(456) : col.Add(789) : col.Add(-33)
      ' This removal doesn't touch MinValue and MaxValue.
      col.Remove(456)
      Console.WriteLine("Min={0}, Max={1}", col.MinValue, col.MaxValue)  ' => Min=-33, Max=789
      ' This statement does affect MinValue and therefore sets upToDate=False.
      col.Remove(-33)
      ' The next call to MinValue causes the properties to be recalculated.
      Console.WriteLine("Min={0}, Max={1}", col.MinValue, col.MaxValue) ' => Min=123, Max=789

   End Sub

   

End Module
