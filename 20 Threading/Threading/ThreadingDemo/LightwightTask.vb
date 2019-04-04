Class LightweightTask
   Public SomeData As String

   ' The method that contains the interesting code
   ' (Not really interesting in this example)
   Sub Execute(ByVal state As Object)
      Console.WriteLine("Message from thread #{0}", state)
   End Sub
End Class
