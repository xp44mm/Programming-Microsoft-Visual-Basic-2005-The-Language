Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Threading
Imports System.Reflection
Imports System.Runtime.Remoting.Messaging

Module Module1

   Sub Main()
      Thread.CurrentThread.Name = "Main thread"
      'RunThread()
      'RunParameterizedThread()
      'RunThreadWithObjectArgument()
      'TestInterrupt()
      'TestThreadException()
      'SynchronizationProblem()
      'SyncLockStatement()
      'SynchronizedObjects()
      'TestMethodImplAttribute()
      'MonitorWithTimeout()
      'WaitAnyExample()
      'MutexWithName()
      'OpenExistingMethod()
      'MutexSecurity()
      'SemaphoreExample()
      'TestReaderWriterLock()
      'TestAutoResetEvent()
      'ThreadPoolDemo()
      'TestThreadingTimer()
      'AsyncDelegates()
      'AsyncCallbacks()
      'OneWayCalls()
      'AsyncFileOperations()
      'TestTextFileReader()
   End Sub


   '----------------------------------------------------
   ' Threading Fundamentals
   '----------------------------------------------------

   ' Create a secondary thread

   Sub RunThread()
      ' Create a new thread and define its starting point.
      Dim t As New Thread(AddressOf RunThread_Task)
      ' Run the new thread.
      t.Start()

      ' Print some messages to the Console window.
      For i As Integer = 1 To 10
         Console.WriteLine("Msg #{0} from main thread", i)
         ' Wait for 0.2 second.
         Thread.Sleep(200)
      Next
   End Sub

   Private Sub RunThread_Task()
      Thread.CurrentThread.Name = "Worker thread"
      For i As Integer = 1 To 10
         Console.WriteLine("Msg #{0} from secondary thread", i)
         ' Wait for 0.2 second.
         Thread.Sleep(200)
      Next
   End Sub

   ' Pass an argument to a secondary thread

   Sub RunParameterizedThread()
      Dim t As New Thread(AddressOf RunParameterizedThread_Task)
      ' Specify that we want 20 iterations.
      t.Start(20)

      ' Print some messages to the Console window.
      For i As Integer = 1 To 10
         Console.WriteLine("Msg #{0} from main thread", i)
         ' Wait for 0.2 second.
         Thread.Sleep(200)
      Next
   End Sub

   Private Sub RunParameterizedThread_Task(ByVal obj As Object)
      For i As Integer = 1 To CInt(obj)
         Console.WriteLine("Msg #{0} from secondary thread", i)
         ' Wait for 0.2 second.
         Thread.Sleep(200)
      Next
   End Sub

   ' Pass an object to a thread

   Private Class ThreadData
      ' Input values
      Public Iterations As Integer
      Public Message As String
      ' Output values
      Public CurrentIteration As Integer
      Public Done As Boolean
   End Class

   Sub RunThreadWithObjectArgument()
      ' Create an instance of the ThreadData class and initialize its fields.
      Dim data As New ThreadData
      data.Iterations = 20
      data.Message = "Msg #{0} from secondary thread"

      ' Run the secondary thread.
      Dim t As New Thread(AddressOf RunThreadWithObjectArgument_Task)
      t.Start(data)

      ' Wait until the other thread has reached the 10-th iteration.
      Do Until data.CurrentIteration >= 10
         Thread.Sleep(100)
      Loop

      ' Print some messages to the Console window.
      For i As Integer = 1 To 10
         Console.WriteLine("Msg #{0} from main thread", i)
         ' Wait for 0.2 second.
         Thread.Sleep(200)
      Next

   End Sub

   Sub RunThreadWithObjectArgument_Task(ByVal obj As Object)
      Dim data As ThreadData = DirectCast(obj, ThreadData)
      For i As Integer = 1 To data.Iterations
         Console.WriteLine(data.Message, i)
         data.CurrentIteration = i
         Thread.Sleep(200)
      Next
      ' Set the Done flag.
      data.Done = True
   End Sub

   ' The Interrupt method

   Sub TestInterrupt()
      ' This thread will complete correctly
      Dim t As New Thread(AddressOf TestInterrupt_Task)
      t.Start()
      Thread.Sleep(6000)
      t.Join()
      ' this thread will be interrupted
      Dim t2 As New Thread(AddressOf TestInterrupt_Task)
      t2.Start()
      Thread.Sleep(2000)
      t2.Interrupt()
      t.Join()
   End Sub

   Private Sub TestInterrupt_Task(ByVal arg As Object)
      Try
         ' Go to sleep for 5 seconds or until another thread
         ' calls the Interrupt method on this thread.
         Thread.Sleep(5000)
         ' We get here if the timeout elapsed and no exception is thrown.
         Console.WriteLine("The thread has completed correctly")
      Catch e As ThreadInterruptedException
         ' We get here if the thread has been interrupted.
         Console.WriteLine("The thread has been interrupted")
      End Try
   End Sub

   ' Test the effect of an exception on the running application.

   Sub TestThreadException()
      ' Prepare to trap AppDomain events.
      AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
      ' Cause an exception on a secondary thread.
      Dim t As New Thread(AddressOf TestThreadException_Task)
      t.Start()
      t.Join()
      ' This line will be never reached.
      Console.WriteLine("Application terminated normally")
   End Sub

   Private Sub TestThreadException_Task()
      Throw New DivideByZeroException()
   End Sub

   Private Sub AppDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
      ' Show information about the current exception.
      Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
      Console.WriteLine(ex.Message)
   End Sub

   ' Show the synchronization problem

   Sub SynchronizationProblem()
      ' Create ten secondary threads.
      For i As Integer = 0 To 9
         Dim t As New Thread(AddressOf SynchronizationProblem_Task)
         t.Start(i)
      Next
   End Sub

   Sub SynchronizationProblem_Task(ByVal obj As Object)
      Dim number As Integer = CInt(obj)
      ' Print a lot of information to the console window.
      For i As Integer = 1 To 1000
         ' Split the output line in two pieces.
         Console.Write(" ")
         Console.Write(number)
      Next
   End Sub

   ' How to solve the problem

   Sub SyncLockStatement()
      ' Create ten secondary threads.
      For i As Integer = 0 To 9
         Dim t As New Thread(AddressOf SyncLockStatement_Task)
         t.Start(i)
      Next
   End Sub

   ' The lock object. (Any non-Nothing reference value will do.)
   Dim consoleLock As New Object()

   Sub SyncLockStatement_Task(ByVal obj As Object)
      Dim number As Integer = CInt(obj)
      ' Print a lot of information to the console window.
      For i As Integer = 1 To 1000
         SyncLock consoleLock
            ' Split the output line in two pieces.
            Console.Write(" ")
            Console.Write(number)
         End SyncLock
      Next
   End Sub

   ' synchronized ArrayList

   Sub SynchronizedObjects()
      ' Create an ArrayList object, and add some values to it.
      Dim al As New ArrayList()
      al.Add(1) : al.Add(2) : al.Add(3)
      ' Create a synchronized, thread-safe version of this ArrayList.
      Dim syncAl As ArrayList = ArrayList.Synchronized(al)
      ' Prove that the new object is thread-safe.
      Console.WriteLine(al.IsSynchronized)        ' => False
      Console.WriteLine(syncAl.IsSynchronized)    ' => True
      ' You can share the syncAl object among different threads.
      ' ...
   End Sub

   ' test the MethodImpl(synchronized) attribute

   Sub TestMethodImplAttribute()
      Dim dc As New MethodImplDemoClass
      Dim t As New Thread(AddressOf TestMethodImplAttribute_Task)
      t.Start(dc)

      For i As Integer = 1 To 10000
         dc.WriteAsterisk()
         ' Uncomment next statement to check MethodImpl attribute on static method
         ' MethodImplDemoClass.WriteDot()
      Next

   End Sub

   Private Sub TestMethodImplAttribute_Task(ByVal arg As Object)
      Dim dc As MethodImplDemoClass = DirectCast(arg, MethodImplDemoClass)
      For i As Integer = 1 To 10000
         dc.WritePlus()
         ' Uncomment next statement to check MethodImpl attribute on static method
         ' MethodImplDemoClass.WriteColon()
      Next
   End Sub

   ' The Monitor type

   ' A non-Nothing module-level object variable
   Dim objLock As New Object()

   Sub TestMonitorType()
      Try
         ' Attempt to enter the protected section; 
         ' wait if the lock is currently owned by another thread.
         Monitor.Enter(objLock)
         ' Do something here.
         ' ...
      Finally
         ' Release the lock.
         Monitor.Exit(objLock)
      End Try
   End Sub

   ' MOnitor.Enter with timeot

   Sub MonitorWithTimeout()
      ' Create ten secondary threads.
      For i As Integer = 0 To 9
         Dim t As New Thread(AddressOf MonitorWithTimeout_Task)
         t.Name = i.ToString()
         t.Start(i)
      Next
   End Sub

   Sub MonitorWithTimeout_Task(ByVal obj As Object)
      Dim number As Integer = CInt(obj)
      ' Print a lot of information to the console window.
      For i As Integer = 1 To 1000
         Try
            Do Until Monitor.TryEnter(consoleLock, 10)
               Debug.WriteLine("Thread " + Thread.CurrentThread.Name + " failed to acquire the lock")
            Loop
            ' Split the output line in pieces.
            Console.Write(" ")
            Console.Write(number)
         Finally
            ' Release the lock.
            Monitor.Exit(consoleLock)
         End Try

      Next
   End Sub

   ' Mutexes

   ' This Mutex object must be accessible to all threads.
   Dim m As New Mutex()

   Sub WaitOneExample()
      ' Attempt to enter the synchronized section, but give up after 0.1 second.
      If m.WaitOne(100, False) Then
         ' Enter the synchronized section.
         ' ...
         ' Exit the synchronized section, and release the Mutex.
         m.ReleaseMutex()
      End If
   End Sub

   ' An array of three Mutex objects
   Dim mutexes() As Mutex = {New Mutex(), New Mutex(), New Mutex()}

   Sub WaitAnyExample()
      For i As Integer = 1 To 10
         Dim t As New Thread(AddressOf WaitAnyExample_Task)
         t.Start(i)
      Next
   End Sub

   Private Sub WaitAnyExample_Task(ByVal obj As Object)
      Dim n As Integer = CInt(obj)
      ' Wait until a resource becomes available.
      ' (Returns the index of the available resource.)
      Dim mutexNdx As Integer = Mutex.WaitAny(mutexes)
      Console.WriteLine("Thread {0} has acquired mutex #{1}", n, mutexNdx)
      ' Enter the synchronized section. 
      ' (This code should use only the resource corresponding to mutexNdx.)
      Thread.Sleep(100 * n)
      Console.WriteLine("Thread {0} is releasing mutex #{1}", n, mutexNdx)
      ' Exit the synchronized section, and release the resource.
      mutexes(mutexNdx).ReleaseMutex()
   End Sub

   ' named mutex

   Sub MutexWithName()
      Dim ownership As Boolean
      Dim m As New Mutex(True, "mutexname", ownership)
      If ownership Then
         Console.WriteLine("This app got the ownership of Mutex named DemoMutex")
         Console.WriteLine("Press ENTER to run another instance of this app")
         Console.ReadLine()
         Process.Start(Assembly.GetExecutingAssembly().GetName().CodeBase)
         Console.WriteLine("Press ENTER to release ownership of the mutex")
         Console.ReadLine()
         m.ReleaseMutex()
      Else
         Console.WriteLine("This app is waiting to get ownership of Mutex named DemoMutex")
         m.WaitOne()
         '...
         Console.WriteLine("Exiting")
         m.ReleaseMutex()
      End If
   End Sub

   Sub OpenExistingMethod()
      Dim ownership As Boolean
      Dim m As New Mutex(True, "mutexname", ownership)
      If ownership Then
         Console.WriteLine("This app got the ownership of Mutex named DemoMutex")
         Console.WriteLine("Press ENTER to run another instance of this app")
         Console.ReadLine()
         Process.Start(Assembly.GetExecutingAssembly().GetName().CodeBase)
         Console.WriteLine("Press ENTER to release ownership of the mutex")
         Console.ReadLine()
         m.ReleaseMutex()
         Return
      End If

      Try
         ' Request a Mutex with the right to wait for it and to release it.
         Dim rights As MutexRights = MutexRights.Synchronize Or MutexRights.Modify
         Dim m2 As Mutex = Mutex.OpenExisting("mutexname", rights)
         ' Use the mutex here.
         Console.WriteLine("Found the mutex. Waiting for ownership.")
         m2.WaitOne()
         Console.WriteLine("Got the ownership. Exiting...")
         ' …
      Catch ex As WaitHandleCannotBeOpenedException
         ' The specified object doesn't exist.
      Catch ex As UnauthorizedAccessException
         ' The specified object exists, but current user doesn't have the
         ' necessary access rights.
      Catch ex As IOException
         ' A Win32 error has occurred.
      End Try
   End Sub

   ' determine who owns a mutex

   Sub MutexSecurity()
      Dim ownership As Boolean
      Dim m As New Mutex(True, "mutexname", ownership)
      If ownership Then
         Console.WriteLine("This app got the ownership of Mutex named DemoMutex")
         Console.WriteLine("Press ENTER to run another instance of this app")
         Console.ReadLine()
         Process.Start(Assembly.GetExecutingAssembly().GetName().CodeBase)
         Console.WriteLine("Press ENTER to release ownership of the mutex")
         Console.ReadLine()
         m.ReleaseMutex()
         Return
      End If

      ' Determine who is the owner of the Mutex
      Dim mutexSec As MutexSecurity = m.GetAccessControl()
      Dim account As NTAccount = DirectCast(mutexSec.GetOwner(GetType(NTAccount)), _
         NTAccount)
      Console.WriteLine("Mutex is owned by {0}", account)           ' => MYSERVER\Administrator
      Console.WriteLine("Type ENTER to exit")
      Console.ReadLine()
   End Sub

   Dim sem As Semaphore

   Sub SemaphoreExample()
      sem = New Semaphore(2, 2)
      For i As Integer = 1 To 10
         Dim t As New Thread(AddressOf SemaphoreExample_Task)
         t.Start(i)
      Next
   End Sub

   Private Sub SemaphoreExample_Task(ByVal obj As Object)
      Dim n As Integer = CInt(obj)
      ' Next statement decrements the semaphore
      Console.WriteLine("Thread {0} is invoking WaitOne", n)
      If sem.WaitOne() Then
         Console.WriteLine("Thread {0} is running in the critical section", n)
         '…
         Thread.Sleep(1000)
         ' Next statement increments the semaphore
         Console.WriteLine("Thread {0} is invoking Release", n)
         sem.Release()
      End If
   End Sub

   ' readerwriterlock

   Dim rwl As New ReaderWriterLock()
   Dim rnd As New Random()

   Sub TestReaderWriterLock()
      For i As Integer = 0 To 9
         Dim t As New Thread(AddressOf ReaderWriterLock_Task)
         t.Start(i)
      Next
      '…
   End Sub

   Sub ReaderWriterLock_Task(ByVal obj As Object)
      Dim n As Integer = CInt(obj)
      ' Perform 10 read or write operations. (Reads are more frequent.)
      For i As Integer = 1 To 10
         If rnd.NextDouble < 0.8 Then
            ' Attempt a read operation.
            rwl.AcquireReaderLock(Timeout.Infinite)
            Console.WriteLine("Thread #{0} is reading", n)
            Thread.Sleep(300)
            Console.WriteLine("Thread #{0} completed the read operation", n)
            rwl.ReleaseReaderLock()
         Else
            ' Attempt a write operation.
            rwl.AcquireWriterLock(Timeout.Infinite)
            Console.WriteLine("Thread #{0} is writing", n)
            Thread.Sleep(300)
            Console.WriteLine("Thread #{0} completed the write operation", n)
            rwl.ReleaseWriterLock()
         End If
      Next
   End Sub

   ' events

   ' The shared AutoResetEvent object
   Public are As New AutoResetEvent(False)
   ' The list where matching filenames should be added
   Public fileList As New List(Of String)()
   ' The number of running threads
   Public searchingThreads As Integer
   ' An object used for locking purposes
   Public lockObj As New Object()

   Sub TestAutoResetEvent()
      ' Search *.zip files in all the subdirectories of C:
      For Each dirname As String In Directory.GetDirectories("C:\")
         Interlocked.Increment(searchingThreads)
         ' Create a new wrapper class, pointing to a subdirectory.
         Dim sf As New FileFinder()
         sf.StartPath = dirname
         sf.SearchPattern = "*.zip"
         ' Create and run a new thread for that subdirectory only.
         Dim t As New Thread(AddressOf sf.StartSearch)
         t.Start()
      Next

      ' Remember how many results we have so far.
      Dim resCount As Integer = 0
      Do While searchingThreads > 0
         ' Wait until there are new results.
         are.WaitOne()

         SyncLock lockObj
            ' Display all new results.
            For i As Integer = resCount To fileList.Count - 1
               Console.WriteLine(fileList(i))
            Next
            ' Remember that you've displayed these filenames.
            resCount = fileList.Count
         End SyncLock
      Loop
      Console.WriteLine("")
      Console.WriteLine("Found {0} files", resCount)
   End Sub

   ' thread pool

   Sub ThreadPoolDemo()
      For i As Integer = 1 To 20
         ' Create a new object for the next lightweight task.
         Dim task As New LightweightTask()
         ' Pass additional information to it. (Not used in this demo.)
         task.SomeData = "other data"
         ' Run the task with a thread from the pool. (Pass the counter as an argument.)
         ThreadPool.QueueUserWorkItem(AddressOf task.Execute, i)
      Next
   End Sub

   ' timer

   Sub TestThreadingTimer()
      ' Get the first callback after one second.
      Dim dueTime As New TimeSpan(0, 0, 1)
      ' Get additional callbacks every half second.
      Dim period As New TimeSpan(0, 0, 0, 0, 500)
      ' Create the timer.
      Using t As New Timer(AddressOf TimerProc, Nothing, dueTime, period)
         ' Wait for five seconds in this demo, then destroy the timer.
         Thread.Sleep(5000)
      End Using
   End Sub

   ' The callback procedure
   Sub TimerProc(ByVal state As Object)
      ' Display current system time in console window.
      Console.WriteLine("Callback proc called at {0}", Date.Now)
   End Sub

   ' async delegates

   Delegate Function FindFilesDelegate(ByVal path As String, _
    ByVal fileSpec As String, ByRef parsedDirs As Integer) As List(Of String)

   Sub AsyncDelegates()
      ' Create a delegate that points to the target procedure.
      Dim findFilesDeleg As New FindFilesDelegate(AddressOf FindFiles)
      ' Start the asynchronous call; get an IAsyncResult object.
      Dim parsedDirs As Integer
      Dim ar As IAsyncResult = findFilesDeleg.BeginInvoke( _
         "c:\windows", "*.dll", parsedDirs, Nothing, Nothing)

      ' Wait until the method completes its execution.
      Do Until ar.IsCompleted
         Console.WriteLine("The main thread is waiting for FindFiles results.")
         Thread.Sleep(500)
      Loop

      ' Now you can get the results.
      Dim files As List(Of String) = findFilesDeleg.EndInvoke(parsedDirs, ar)
      For Each file As String In files
         Console.WriteLine(file)
      Next
      Console.WriteLine("  {0} directories have been parsed.", parsedDirs)
   End Sub

   ' This procedure scans a directory tree for a file.
   ' It takes a path and a file specification and returns a list of
   ' filenames; it returns the number of directories that have been 
   ' parsed in the third argument.

   Function FindFiles(ByVal path As String, ByVal fileSpec As String, _
         ByRef parsedDirs As Integer) As List(Of String)
      ' Prepare the result.
      FindFiles = New List(Of String)
      ' Get all files in this directory that match the file spec.
      FindFiles.AddRange(Directory.GetFiles(path, fileSpec))
      ' Remember that a directory has been parsed.
      parsedDirs += 1

      ' Scan subdirectories.
      For Each subdir As String In Directory.GetDirectories(path)
         ' Add all the matching files in subdirectories.
         FindFiles.AddRange(FindFiles(subdir, fileSpec, parsedDirs))
      Next
   End Function

   ' callbacks

   Sub AsyncCallbacks()
      ' Create a delegate that points to the target procedure.
      Dim findFilesDeleg As New FindFilesDelegate(AddressOf FindFiles)
      ' The msg to be shown at the end of the routine
      Dim msg As String = "DLL files in C:\WINDOWS"
      ' Start the async call, pass a delegate to the MethodCompleted
      ' procedure and get an IAsyncResult object.
      Dim parsedDirs As Integer
      Dim ar As IAsyncResult = findFilesDeleg.BeginInvoke("c:\windows", "*.dll", parsedDirs, AddressOf AsyncCallbacks_CBK, msg)
      ' Let the other thread run
      Thread.Sleep(15000)
   End Sub

   Private Sub AsyncCallbacks_CBK(ByVal ar As IAsyncResult)
      ' Extract the delegate.
      Dim deleg As FindFilesDelegate = DirectCast(DirectCast(ar, AsyncResult).AsyncDelegate, FindFilesDelegate)
      ' extractr the value
      Dim msg As String = DirectCast(ar.AsyncState, String)
      ' Call the EndInvoke method, and display result.
      Console.WriteLine(msg)

      Dim parsedDirs As Integer
      For Each file As String In deleg.EndInvoke(parsedDirs, ar)
         Console.WriteLine(file)
      Next
      Console.WriteLine("  {0} directories have been parsed.", parsedDirs)
   End Sub

   ' one way calls
   Delegate Sub DelegateOne()
   Delegate Sub DelegateTwo(ByRef n As Integer)

   Sub OneWayCalls()
      Dim deleg As DelegateOne = Nothing
      Dim ar As IAsyncResult = Nothing

      Try
         deleg = New DelegateOne(AddressOf MethodThatThrows)
         ar = deleg.BeginInvoke(Nothing, Nothing)
         deleg.EndInvoke(ar)
         Console.WriteLine("Method didn't throw an exception")
      Catch ex As Exception
         Console.WriteLine("Method threw an exception")
      End Try

      Try
         deleg = New DelegateOne(AddressOf MethodThatThrows_OneWay)
         ar = deleg.BeginInvoke(Nothing, Nothing)
         deleg.EndInvoke(ar)
         Console.WriteLine("Method didn't throw an exception")
      Catch ex As Exception
         Console.WriteLine("Method threw an exception")
      End Try

      Dim deleg2 As DelegateTwo
      Try
         deleg2 = New DelegateTwo(AddressOf MethodThatThrows_OneWay)
         ar = deleg2.BeginInvoke(0, Nothing, Nothing)

         Dim n As Integer
         deleg2.EndInvoke(n, ar)
         ' Prove that N is still zero.
         Console.WriteLine("Method didn't throw an exception. N = {0}", n)
      Catch ex As Exception
         Console.WriteLine("Method threw an exception")
      End Try


   End Sub

   Private Sub MethodThatThrows()
      Thread.Sleep(1000)
      Throw New ArgumentException()
   End Sub

   <System.Runtime.Remoting.Messaging.OneWay()> _
   Private Sub MethodThatThrows_OneWay()
      Thread.Sleep(1000)
      Throw New ArgumentException()
   End Sub

   <System.Runtime.Remoting.Messaging.OneWay()> _
   Private Sub MethodThatThrows_OneWay(ByRef n As Integer)
      n = 1234
      Thread.Sleep(1000)
   End Sub

   ' async file operations

   ' The file being read from or written to
   Const FileName As String = "C:\TESTDATA.TMP"
   ' The FileStream object used for both reading and writing
   Dim fs As FileStream
   ' The buffer for file I/O
   Dim buffer(1048575) As Byte

   Sub AsyncFileOperations()
      ' Fill the buffer with random data.
      For i As Integer = 0 To UBound(buffer)
         buffer(i) = CByte(i Mod 256)
      Next

      ' Create the target file in asynchronous mode (open in asynchronous mode).
      fs = New FileStream(FileName, FileMode.Create, _
         FileAccess.Write, FileShare.None, 65536, True)
      ' Start the async write operation.
      Console.WriteLine("Starting the async write operation")
      Dim ar As IAsyncResult = fs.BeginWrite(buffer, 0, _
         buffer.Length, AddressOf AsyncFileCallback, "write")

      ' Wait a few seconds until the operation completes.
      Thread.Sleep(4000)
      ' Now read the file back.
      fs = New FileStream(FileName, FileMode.Open, _
         FileAccess.Read, FileShare.None, 65536, True)
      ' Size the receiving buffer.
      ReDim buffer(CInt(fs.Length) - 1)
      ' Start the async read operation.
      Console.WriteLine("Starting the async read operation")
      ar = fs.BeginRead(buffer, 0, buffer.Length, _
         AddressOf AsyncFileCallback, "read")
   End Sub

   ' This is the callback procedure for both async read and write.
   Sub AsyncFileCallback(ByVal ar As IAsyncResult)
      ' Get the state object (the "write" or "read" string).
      Dim opName As String = ar.AsyncState.ToString()

      ' The behavior is quite different in the two cases.
      Select Case opName
         Case "write"
            Console.WriteLine("Async write operation completed")
            ' Complete the write, and close the stream.
            fs.EndWrite(ar)
            fs.Close()
         Case "read"
            Console.WriteLine("Async read operation completed")
            ' Complete the read, and close the stream.
            Dim bytes As Integer = fs.EndRead(ar)
            Console.WriteLine("Read {0} bytes", bytes)
            fs.Close()
      End Select
   End Sub

   ' test the TextFileReader class

   Sub TestTextFileReader()
      Dim tfr As New TextFileReader()
      tfr.BeginRead("d:\book.txt")

      Thread.Sleep(2000)
      Dim text As String = tfr.EndRead()

      Console.WriteLine(text)

   End Sub


End Module
