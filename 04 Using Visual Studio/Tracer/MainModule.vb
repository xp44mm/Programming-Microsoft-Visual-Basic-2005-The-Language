Module MainModule

   Sub Main(ByVal args() As String)
      Console.Write(Now.ToString(" yy/MM/dd hh:mm:ss "))
      Console.Write(Environment.UserName & " (" & Environment.MachineName & "): ")
      Console.WriteLine(Join(args))
   End Sub

End Module
