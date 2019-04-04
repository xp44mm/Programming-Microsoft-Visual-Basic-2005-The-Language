Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Reflection

Imports BOLibrary

Module Module1

   Sub Main()
      'BinarySerialization()
      'SoapSerialization()
      'GenericSerialization()
      'ObjectGraphs()
      'ShallowCopy()
      'DeepCopy()
      'DeserializingWithSimpleFormat()
      'VersionToleranteDeserialization()
      'SerializationBinder()
      'IDeserializationCallbackInterface()
      'ISerializationInterface()
      'OnDeserializedAttribute()
      'SingletonObjects()
      'IObjectReferenceInterface()
      'SurrogateTypes()
      TestSerializationHelpers()
   End Sub

   Sub BinarySerialization()
      ' Create an array of integers.
      Dim arr() As Integer = {1, 2, 4, 8, 16, 32, 64, 128, 256}
      ' Open a stream for output.
      Using fs As New FileStream("c:\powers.dat", FileMode.Create)
         ' Create a binary formatter for this stream.
         Dim bf As New BinaryFormatter()
         ' Serialize the array to the file stream, and flush the stream.
         bf.Serialize(fs, arr)
      End Using

      Dim arr2() As Integer
      ' Open a file stream for input.
      Using fs2 As New FileStream("c:\powers.dat", FileMode.Open)
         ' Create a binary formatter for this stream.
         Dim bf As New BinaryFormatter()
         ' Deserialize the contents of the file stream into an Integer array.
         ' (Deserialize returns an object that must be coerced.)
         arr2 = DirectCast(bf.Deserialize(fs2), Integer())
      End Using

      For Each n As Integer In arr2
         Console.Write("{0},", n)
      Next
      Console.WriteLine()
   End Sub

   Sub SoapSerialization()
      ' Create a Hashtable object, and fill it with some data.
      Dim ht As New Hashtable()
      ht.Add("One", 1)
      ht.Add("Two", 2)
      ht.Add("Three", 3)
      ' Create a soap serializer.
      Dim sf As New SoapFormatter()
      ' Save the Hashtable to disk in SOAP format.
      Using fs As New FileStream("c:\hashtable.xml", FileMode.Create)
         sf.Serialize(fs, ht)
      End Using

      ' Reload the file contents, using the same SoapFormatter object.
      Dim ht2 As Hashtable
      Using fs As New FileStream("c:\hashtable.xml", FileMode.Open)
         ht2 = DirectCast(sf.Deserialize(fs), Hashtable)
      End Using
      ' Prove that the object has been deserialized correctly.
      For Each de As DictionaryEntry In ht2
         Console.WriteLine("Key={0}  Value={1}", de.Key, de.Value)
      Next
   End Sub

   Sub GenericSerialization()
      Dim list As New List(Of Person)
      list.Add(New Person("Joe", "Doe", #1/12/1960#))
      list.Add(New Person("John", "Smith", #3/6/1962#))
      list.Add(New Person("Ann", "Doe", #10/4/1965#))
      SerializeToFile("c:\persons.dat", list)

      ' Reload the file contents into another list object.
      Dim list2 As List(Of Person) = DeserializeFromFile(Of List(Of Person))("c:\persons.dat")
      For Each p As Person In list2
         Console.WriteLine("{0} {1} ({2})", p.FirstName, p.LastName, p.Age)
      Next
   End Sub

   Sub ObjectGraphs()
      ' Create three Person objects.
      Dim p1 As New Person("Joe", "Doe", #1/12/1960#)
      Dim p2 As New Person("John", "Smith", #3/6/1962#)
      Dim p3 As New Person("Ann", "Doe", #10/4/1965#)
      ' Define the relationship between two of them.
      p2.Spouse = p3
      p3.Spouse = p2

      ' Load them into a List(Of Person) object in one operation.
      Dim list As New List(Of Person)(New Person() {p1, p2, p3})
      ' Serialize to disk.
      SerializeToFile("c:\persons.dat", list)

      ' Reload into another List(Of Person) object and display.
      ' Reload the file contents into another list object.
      Dim list2 As New List(Of Person)(New Person() {p1, p2, p3})
      For Each p As Person In list2
         Console.WriteLine("{0} {1} ({2})", p.FirstName, p.LastName, p.Age)
         If Not (p.Spouse Is Nothing) Then
            ' Show the spouse's name if there is one.
            Console.WriteLine("   Spouse of " & p.Spouse.FirstName)
         End If
      Next
   End Sub

   Sub ShallowCopy()
      ' Define husband and wife.
      Dim p1 As New Person("Joe", "Doe", #1/12/1960#)
      Dim p2 As New Person("Ann", "Doe", #10/4/1965#)
      p1.Spouse = p2
      p2.Spouse = p1
      ' Clone the husband.
      Dim q1 As Person = DirectCast(p1.Clone, Person)
      ' The Spouse person hasn't been cloned because it's a shallow copy.
      Console.WriteLine(q1.Spouse Is p1.Spouse)           ' => True
   End Sub

   Sub DeepCopy()
      ' Define husband and wife.
      Dim p1 As New Person("Joe", "Doe", #1/12/1960#)
      Dim p2 As New Person("Ann", "Doe", #10/4/1965#)
      p1.Spouse = p2
      p2.Spouse = p1
      ' Clone the husband. (Notice that the type T can be inferred from the argument.)
      Dim q1 As Person = CloneObject(p1)
      Dim q2 As Person = q1.Spouse
      ' Prove that properties were copied correctly.
      Console.WriteLine("{0} {1}", q1.FirstName, q1.LastName)  ' => Joe Doe
      Console.WriteLine("{0} {1}", q2.FirstName, q2.LastName)  ' => Joe Doe
      ' Prove that both objects were cloned because it's a deep copy.
      Console.WriteLine(p1 Is q1)                              ' => False
      Console.WriteLine(p2 Is q2)                              ' => False
   End Sub

   Sub DeserializingWithSimpleFormat()
      ' Deserialize an assembly stored with SimpleFormat under 1.1
      Using fs As New FileStream("customer_v10_simple.dat", FileMode.Open)
         Dim bf As New BinaryFormatter
         Dim cust As Customer = DirectCast(bf.Deserialize(fs), Customer)
         Console.WriteLine("{0} ({1})", cust.Name, cust.City)
      End Using
   End Sub

   Sub VersionToleranteDeserialization()
      ' Serialize an instance of Customer from BOLibrary version 1.0
      Dim asm As Assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() & "\BOLibrary_v10.dll")
      Dim ty As Type = asm.GetType("BOLibrary.Customer")
      Dim obj As Object = Activator.CreateInstance(ty, New Object() {"Ann Smith", "Los Angeles"})
      Using fs As New FileStream("customer_v10.dat", FileMode.Create)
         Dim bf As New BinaryFormatter
         bf.Serialize(fs, obj)
      End Using

      ' Deserialize version 1.0 assembly into version 2.0
      Using fs As New FileStream("customer_v10.dat", FileMode.Open)
         Dim bf As New BinaryFormatter
         Dim cust As Customer = DirectCast(bf.Deserialize(fs), Customer)
         Console.WriteLine("{0} ({1}) - ASSEMBLY={2}", cust.Name, cust.City, cust.GetType().Assembly.GetName().FullName)
      End Using
   End Sub

   Sub SerializationBinder()
      Dim cust As New Customer("John Smith", "New York")
      ' Serialize a Customer object from BOLibrary assembly
      Dim ms As New MemoryStream
      Dim bf As New BinaryFormatter
      bf.Serialize(ms, cust)

      ' Rewind the stream and deserialize into a SerializationDemo.CustomerEx object
      ms.Seek(0, SeekOrigin.Begin)
      Dim bf2 As New BinaryFormatter
      bf2.Binder = New MySerializationBinder
      Dim custEx As CustomerEx = DirectCast(bf2.Deserialize(ms), CustomerEx)

      Console.WriteLine("{0} ({1})", custEx.Name, custEx.City, custEx.Country)
   End Sub

   Sub IDeserializationCallbackInterface()
      Dim pers As New Person3("John", "Smith")
      SerializeToFile("person.dat", pers)
      ' Close the log file.
      pers.Dispose()

      ' Deserialize the object.
      Dim pers2 As Person2 = DeserializeFromFile(Of Person2)("person.dat")
      ' Show that Country field was initialized correctly.
      Console.WriteLine("{0} {1}, {2}", pers2.FirstName, pers2.LastName, pers2.Country)
   End Sub

   Sub ISerializationInterface()
      ' Test the compressed serialization feature.
      Dim ca As New CompactArray(Of Integer)(10000)
      ca(1) = 1 : ca(23) = 23 : ca(66) = 66
      SerializeToFile("compactarray.dat", ca)

      Dim fi As New FileInfo("compactarray.dat")
      Console.WriteLine("Size of compressed stream = {0}", fi.Length)

      Dim ca2 As CompactArray(Of Integer) = DeserializeFromFile(Of CompactArray(Of Integer))("compactarray.dat")
      For i As Integer = 0 To 9999
         If ca(i) <> ca2(i) Then Console.WriteLine("Found a difference: CA({0})={1}, CA2({0})={2}", i, ca(i), ca2(i))
      Next
   End Sub

   Sub OnDeserializedAttribute()
      Dim pers As New Person3("John", "Smith")
      SerializeToFile("person.dat", pers)
      ' Close the log file.
      pers.Dispose()

      ' Deserialize the object.
      Dim pers3 As Person3 = DeserializeFromFile(Of Person3)("person.dat")
      ' Show that Country field was initialized correctly.
      Console.WriteLine("{0} {1}, {2}", pers3.FirstName, pers3.LastName, pers3.Country)
   End Sub

   Sub SingletonObjects()
      ' Get a singleton instance and serialize it.
      Dim s1 As Singleton = Singleton.Instance
      SerializeToFile("singleton.dat", s1)
      ' Deserialize it into a different variable and check that they point to the object.
      Dim s2 As Singleton = DeserializeFromFile(Of Singleton)("singleton.dat")
      Console.WriteLine(s1 Is s2)                    ' True
   End Sub

   Sub IObjectReferenceInterface()
      Dim ivp As IdValuePair = IdValuePair.Create(1, "abc")
      SerializeToFile("idvaluepair.dat", ivp)

      Dim ivp2 As IdValuePair = DeserializeFromFile(Of IdValuePair)("idvaluepair.dat")
      Console.WriteLine(ivp Is ivp2)
   End Sub

   Sub SurrogateTypes()
      ' Create a PurchaseOrder instance and its dependent objects.
      Dim po As New PurchaseOrder
      po.Supplier = New Supplier("JD", "Joe Doe")
      po.Attachment = New Document()
      po.Attachment.Number = 11
      po.Attachment.Location = "c:\docs\description.doc"

      ' Create an empty instance of the standard SurrogateSelector object.
      Dim surSel As New SurrogateSelector()
      surSel.AddSurrogate(GetType(Document), _
         New StreamingContext(StreamingContextStates.All), _
         New DocumentSerializationSurrogate)
      ' Tell the SurrogateSelector how to deal with Document and Supplier objects.
      surSel.AddSurrogate(GetType(Supplier), _
         New StreamingContext(StreamingContextStates.All), _
         New SupplierSerializationSurrogate)
      ' Create the BinaryFormatter and set its SurrogateSelector property.
      Dim bf As New BinaryFormatter
      bf.SurrogateSelector = surSel

      ' Serialize to a memory stream and deserialize into a different object.
      Dim ms As New MemoryStream
      bf.Serialize(ms, po)
      ms.Seek(0, SeekOrigin.Begin)
      Dim po2 As PurchaseOrder = DirectCast(bf.Deserialize(ms), PurchaseOrder)

      ' Prove that the object deserialized correctly.
      Console.WriteLine(po2.Supplier.Name)           ' => Joe Doe
      Console.WriteLine(po2.Attachment.Number)       ' => 11
   End Sub

   Sub TestSerializationHelpers()
      Dim em As New Employee("Joe", "Doe", #1/12/1960#)
      em.Spouse = New Employee("Ann", "Douglas", #4/6/1962#)
      em.Spouse.Spouse = em
      em.Boss = New Employee("Robert", "Smith", #11/7/1965#)

      SerializeToFile("employee.dat", em)
      Dim em2 As Employee = DeserializeFromFile(Of Employee)("employee.dat")

      Console.WriteLine(em2.FirstName)              ' => Joe
      Console.WriteLine(em2.Spouse.FirstName)       ' => Ann
      Console.WriteLine(em2.Boss.FirstName)         ' => Robert
      Console.WriteLine(em2.Boss.BirthDate)         ' => #11/7/1965#
      ' Check that circular references are handled correctly.
      Console.WriteLine(em2.Spouse.Spouse Is em2)    ' => True 

      ' Another case
      em.Boss = DirectCast(em.Spouse, Employee)
      SerializeToFile("employee.dat", em)
      Dim em3 As Employee = DeserializeFromFile(Of Employee)("employee.dat")
      Console.WriteLine(em3.Boss Is em3.Spouse)         ' => True



   End Sub

End Module
