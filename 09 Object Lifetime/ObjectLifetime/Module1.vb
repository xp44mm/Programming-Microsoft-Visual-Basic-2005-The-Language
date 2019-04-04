Module Module1

   Sub Main()
      'FinalizeMethod()
      'GarbageCollection()
      'Generations()
      'JitOptimization()
      'JitOptimization2()
      'WeakReferences()
      'ServerGarbageCollection()
      'ObjectResurrection()
   End Sub

   Sub FinalizeMethod()
      Debug.WriteLine("About to create a Person2 object.")
      Dim aPerson As New Person("John", "Doe")
      Debug.WriteLine("About to set the Person2 object to Nothing.")
      aPerson = Nothing
      Debug.WriteLine("About to terminate the application.")
   End Sub

   Sub GarbageCollection()
      Debug.WriteLine("About to create a Person2 object.")
      Dim aPerson As New Person("John", "Doe")
      'aPerson = Nothing
      Debug.WriteLine("About to fire a garbage collection.")
      GC.Collect()
      GC.WaitForPendingFinalizers()
      Debug.WriteLine("About to terminate the application.")
   End Sub

   Sub Generations()
      Dim s As String = "dummy string"
      ' This is a generation-0 object.
      Console.WriteLine(GC.GetGeneration(s))          ' => 0
      ' Make it survive a first garbage collection.
      GC.Collect() : GC.WaitForPendingFinalizers()
      Console.WriteLine(GC.GetGeneration(s))          ' => 1
      ' Make it survive a second garbage collection.
      GC.Collect() : GC.WaitForPendingFinalizers()
      Console.WriteLine(GC.GetGeneration(s))          ' => 2
      ' Subsequent garbage collections don’t increment the generation counter.
      GC.Collect() : GC.WaitForPendingFinalizers()
      Console.WriteLine(GC.GetGeneration(s))          ' => 2
   End Sub

   Sub JitOptimization()
      Console.WriteLine("About to create a Person2 object.")
      Dim aPerson As New Person("John", "Doe")
      ' aPerson = Nothing

      ' After this point aPerson is a candidate for garbage collection.
      Console.WriteLine("About to fire a garbage collection.")
      GC.Collect()
      GC.WaitForPendingFinalizers()

      Console.WriteLine("About to terminate the application")
   End Sub

   Sub JitOptimization2()
      Console.WriteLine("About to create a Person2 object.")
      Dim aPerson As New Person("John", "Doe")

      ' Use the aPerson object inside the loop.
      For i As Integer = 1 To 100
         Console.WriteLine("Iteration #{0}", i)
         If i <= 50 Then
            ' Use the object only in the first 50 iterations.
            Console.WriteLine(aPerson.FirstName)
            ' Explicitly set the variable to Nothing after its last use.
            If i = 50 Then aPerson = Nothing
         Else
            ' Do something else here, but don't use the aPerson variable.
            '…
            ' simulate a GC because of memory shortage
            If i = 99 Then GC.Collect() : GC.WaitForPendingFinalizers()
         End If
      Next
   End Sub

   Sub WeakReferences()
      ' Read and cache the contents of the "book.txt" file.
      Dim cf As New CachedFile("book.txt")
      Console.WriteLine(cf.GetText())
      '…
      ' Uncomment next line to force a garbage collection.
      ' GC.Collect(): GC.WaitForPendingFinalizers()
      '…
      ' Read the contents again some time later.
      ' (No disk access is performed, unless a GC has occurred in the meantime.)
      Console.WriteLine(cf.GetText())
   End Sub

   ' Before running this method, you may want to change the GC setting in the 
   ' configuration file.

   Sub ServerGarbageCollection()
      If System.Runtime.GCSettings.IsServerGC Then
         Console.WriteLine("Server GC is used")
      Else
         Console.WriteLine("Workstation GC is used")
      End If
   End Sub

   ' Demonstrate object resurrection and custom object pooling

   Sub ObjectResurrection()
      ' Create a few RandomArray instances.
      Dim ra1 As RandomArray = RandomArray.Create(10000)
      Dim ra2 As RandomArray = RandomArray.Create(20000)
      Dim ra3 As RandomArray = RandomArray.Create(30000)
      ' Clear some of them.
      ra2 = Nothing
      ra3 = Nothing
      ' Simulate a GC, which moves the objects to the pool.
      GC.Collect() : GC.WaitForPendingFinalizers()

      ' Create a few more objects, which will be taken from the pool
      Dim ra4 As RandomArray = RandomArray.Create(20000)
      Dim ra5 As RandomArray = RandomArray.Create(30000)
   End Sub
End Module



