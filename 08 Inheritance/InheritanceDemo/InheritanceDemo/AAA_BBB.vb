Class AAA
   Sub DoSomething()
      Console.WriteLine("AAA.DoSomething")
   End Sub
   Sub DoSomething(ByVal msg As String)
      Console.WriteLine("AAA.DoSomething({0})", msg)
   End Sub

   Sub DoSomething2()
      Console.WriteLine("AAA.DoSomething2")
   End Sub
   Sub DoSomething2(ByVal msg As String)
      Console.WriteLine("AAA.DoSomething2({0})", msg)
   End Sub
End Class

Class BBB
   Inherits AAA

   Overloads Sub DoSomething()
      Console.WriteLine("BBB.DoSomething")
   End Sub
   Shadows Sub DoSomething2()
      Console.WriteLine("BBB.DoSomething2")
   End Sub
End Class
