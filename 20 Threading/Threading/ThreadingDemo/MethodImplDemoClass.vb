Imports System.Runtime.CompilerServices

Class MethodImplDemoClass
   ' This method can be executed by one thread at a time.
   <MethodImpl(MethodImplOptions.Synchronized)> _
   Sub WriteAsterisk()
      Console.Write("*")
      Console.Write(" ")
   End Sub

   '<MethodImpl(MethodImplOptions.Synchronized)> _
   Sub WritePlus()
      SyncLock Me
         Console.Write("+")
         Console.Write(" ")
      End SyncLock
   End Sub

   <MethodImpl(MethodImplOptions.Synchronized)> _
   Public Shared Sub WriteColon()
      Console.Write("+")
      Console.Write(" ")
   End Sub

   '<MethodImpl(MethodImplOptions.Synchronized)> _
   Public Shared Sub WriteDot()
      SyncLock GetType(MethodImplDemoClass)
         Console.Write(".")
         Console.Write(" ")
      End SyncLock
   End Sub

   Shared lock As New Object

End Class
