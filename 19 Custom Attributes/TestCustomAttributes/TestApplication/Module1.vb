Imports System.IO
Imports System.Xml.Serialization
Imports AttributeLibrary

Module Module1

   Sub Main()
      'TestCsvSerializer()

   End Sub

   ' Test the CsvSerializer object.

   Sub TestCsvSerializer()
      Const DATAFILE As String = "employees.txt"
      Dim arr() As Employee = {New Employee("John", "Smith", #1/12/1965#, 30000), _
         New Employee("Ann", "Doe", #4/8/1967#, 35000), _
         New Employee("Robert", "Smith", #7/11/1962#, 45000)}


      Dim ser As New CsvSerializer(Of Employee)
      Console.WriteLine("Serializing...")
      ser.Serialize(DATAFILE, arr)
      Console.WriteLine(File.ReadAllText(DATAFILE))

      Console.WriteLine()
      Console.WriteLine("Deserializing...")
      Dim arr2() As Employee = ser.Deserialize(DATAFILE)
      For Each em As Employee In arr2
         Console.WriteLine(em)
      Next
   End Sub

End Module


