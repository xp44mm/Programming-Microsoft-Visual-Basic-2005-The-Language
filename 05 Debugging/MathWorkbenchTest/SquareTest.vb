Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MathWorkbenchTest


<TestClass()> Public Class SquareTest

   '''<summary>
   '''A test for GetPerimeter()
   '''</summary>
   <DeploymentItem("MathWorkbench.exe"), _
    TestMethod()> _
   Public Sub GetPerimeterTest()
      Dim side As Double = 10
      Dim target As Object = MathWorkbench_SquareAccessor.CreatePrivate(side)
      Dim accessor As MathWorkbench_SquareAccessor = New MathWorkbench_SquareAccessor(target)
      Dim expected As Double = 40
      Dim actual As Double
      actual = accessor.GetPerimeter
      Assert.AreEqual(expected, actual, "MathWorkbench.Square.GetPerimeter did not return the expected value.")
   End Sub

   '''<summary>
   '''A test for New(ByVal Double)
   '''</summary>
   <DeploymentItem("MathWorkbench.exe"), _
    TestMethod()> _
   Public Sub ConstructorTest()
      Dim side As Double = 10
      Dim target As Object = MathWorkbench_SquareAccessor.CreatePrivate(side)
   End Sub
End Class
