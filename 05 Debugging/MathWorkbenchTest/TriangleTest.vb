Imports System.io
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MathWorkbench


<TestClass()> Public Class TriangleTest

   Shared TestContext As TestContext

   <ClassInitialize()> _
   Public Shared Sub MyClassInitialize(ByVal context As TestContext)
      ' This method runs before any of the tests defined in the current class.
      ' Save the TestContext object for later.
      testContext = context
      System.Diagnostics.Debug.WriteLine("MyClassInitialized")
   End Sub

   <ClassCleanup()> _
   Public Shared Sub MyClassCleanup()
      ' This method runs after all the tests defined in the current class.
      System.Diagnostics.Debug.WriteLine("MyClassCleanup")
   End Sub

   Dim sw As StreamWriter
   Dim failedTests As Integer

   <TestInitialize()> _
   Public Sub Initialize()
      ' Create a log file for each test whose name ends with "DB" suffix.
      If TestContext.TestName.EndsWith("DB") Then
         Dim fileName As String = "c:\" & TestContext.TestName & ".log"
         sw = New StreamWriter(fileName)
         failedTests = 0
      End If
   End Sub

   <TestCleanup()> _
   Public Sub Cleanup()
      ' Append the number of failed tests and close the StreamWriter.
      If sw IsNot Nothing Then
         sw.WriteLine("Tests failed: " & failedTests.ToString())
         sw.Close()
         ' If we'd omit next line, non-DB tests would mistakenly attempt to log their results.
         sw = Nothing
      End If
   End Sub


   '''<summary>
   '''A test for GetArea()
   '''</summary>
   <TestMethod(), TestProperty("DateCreated", "03/12/2005")> _
   Public Sub GetAreaTest()
      Dim sideA As Double = 30
      Dim sideB As Double = 40
      Dim sideC As Double = 50
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
      Dim expected As Double = 600
      Dim actual As Double
      actual = target.GetArea
      Assert.AreEqual(expected, actual, "MathWorkbench.Triangle.GetArea did not return the expected value.")
   End Sub

   '''<summary>
   '''A test for GetPerimeter()
   '''</summary>
   <TestMethod()> _
   Public Sub GetPerimeterTest()
      Dim sideA As Double = 30
      Dim sideB As Double = 40
      Dim sideC As Double = 50
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
      Dim expected As Double = 120
      Dim actual As Double
      actual = target.GetPerimeter
      Assert.AreEqual(expected, actual, "MathWorkbench.Triangle.GetPerimeter did not return the expected value.")
   End Sub

   <TestMethod(), Priority(5), _
   Description("Check that the perimeter is evaluated correctly")> _
   Public Sub GetPerimeterTest2()
      Dim sideA As Double = 20
      Dim sideB As Double = 20
      Dim sideC As Double = 30
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
      Dim expected As Double = 70
      Dim actual As Double
      actual = target.GetPerimeter
      Assert.AreEqual(expected, actual, "MathWorkbench.Triangle.GetPerimeter did not return the expected value.")
   End Sub


   '''<summary>
   '''A test for New(ByVal Double, ByVal Double, ByVal Double)
   '''</summary>
   <TestMethod(), ExpectedException(GetType(ArgumentException), "Invalid triangle")> _
   Public Sub ConstructorTest()
      ' An invalid triangle
      Dim sideA As Double = 100
      Dim sideB As Double = 30
      Dim sideC As Double = 50
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
   End Sub

   <TestMethod()> _
   <DataSource("System.Data.SqlClient", _
       "Data Source=.;Initial Catalog=MathWorkbenchTest;Integrated Security=True", _
       "TriangleData", DataAccessMethod.Sequential)> _
   Public Sub GetPerimeterTestDB()
      Dim sideA As Double = CDbl(TestContext.DataRow("SideA"))
      Dim sideB As Double = CDbl(TestContext.DataRow("SideB"))
      Dim sideC As Double = CDbl(TestContext.DataRow("SideC"))
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
      Dim expected As Double = CDbl(TestContext.DataRow("Perimeter"))
      Dim actual As Double = target.GetPerimeter

      ' Compare expected and actual value at the end of GetPerimeterTestDB procedure.
      If Math.Abs(expected - actual) > 1.0E-20 Then
         ' Output the comma-delimited list of arguments, expected and result results.
         Dim text As String = String.Format("{0},{1},{2},{3},{4}", sideA, sideB, sideC, expected, actual)
         sw.WriteLine(text)
         failedTests += 1
         Assert.Fail("MathLibrary.Triangle.GetPerimeter did not return the expected value.")
      End If
   End Sub

   <TestMethod()> _
   <DataSource("System.Data.SqlClient", _
       "Data Source=.;Initial Catalog=MathWorkbenchTest;Integrated Security=True", _
       "TriangleData", DataAccessMethod.Sequential)> _
   Public Sub GetAreaTestDB()
      Dim sideA As Double = CDbl(TestContext.DataRow("SideA"))
      Dim sideB As Double = CDbl(TestContext.DataRow("SideB"))
      Dim sideC As Double = CDbl(TestContext.DataRow("SideC"))
      Dim target As Triangle = New Triangle(sideA, sideB, sideC)
      Dim expected As Double = CDbl(TestContext.DataRow("Area"))
      Dim actual As Double = target.GetArea

      ' Compare expected and actual value at the end of GetPerimeterTestDB procedure.
      If Math.Abs(expected - actual) > 1.0E-20 Then
         ' Output the comma-delimited list of arguments, expected and result results.
         Dim text As String = String.Format("{0},{1},{2},{3},{4}", sideA, sideB, sideC, expected, actual)
         sw.WriteLine(text)
         failedTests += 1
         Assert.AreEqual(expected, actual, _
            "MathLibrary.Triangle.GetArea did not return the expected value.")
      End If
   End Sub

End Class
