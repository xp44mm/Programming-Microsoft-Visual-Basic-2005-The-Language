Imports System.IO
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Threading

#Const APPCONFIG_USED = 0

Module Module1

   Sub Main()
      'TestTracepoint()
      'TestDebuggerNonUserCode()
      'TestDataTips()
      'TestXmlVisualizer()
      'TestCustomVisualizer()
      'DebugMethods()
      'TraceMethods()
      'BooleanSwitches()
      'TestTraceListeners()
      'CustomTraceFormat()
      'CustomTraceFilter()
      'TestTraceSource()
      'TestTraceSource2()
      'TestStopwatch()
      'TestDebuggerType()
      'TestStackTrace()
      'TestStackFrameFromException()
      'TestDebugInZone()
      'TestVsHost()
      'TestClearLocalVariablesMacro()
      'TestStepIntoOrOutMacro()
      TestAppConfigRenamingMacro()
   End Sub

   Sub TestTracepoint()
      Dim X As Integer = 1234
      Dim Name As String = "John"
      ' ENSURE THAT A TRACEPOINT IS SET HERE
      Dim res As Integer = X + 100
      TestTracepoint(X, Name)
   End Sub

   Sub TestTracepoint(ByVal n As Integer, ByVal s As String)
      ' ENSURE THAT A TRACEPOINT IS SET HERE
      Dim res As Integer = n + 100
   End Sub

   Sub TestDebuggerNonUserCode()
      Dim f As New Fraction(10, 7)
   End Sub

   Sub TestDataTips()
      Dim p As New Person("John", "Smith")
      Dim p2 As New Person("Ann", "Douglas")
      p.Spouse = p2
      p2.Spouse = p
      ' SET A BREAKPOINT HERE AND INSPECT THE P VARIABLE WITH DATA TIPS
      Console.WriteLine(p)

      Dim frac As New Fraction(4, 7)
      ' SET A BREAKPOINT HERE AND INSPECT THE frac VARIABLE TO SEE THE
      '  DebuggerDisplay AND DebuggerBrowsable ATTRIBUTES IN ACTION
      Console.WriteLine(frac)
   End Sub

   Sub TestXmlVisualizer()
      Try
         Dim configFile As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
         Dim configXml As String = File.ReadAllText(configFile)
         ' SET A BREAKPOINT HERE TO TEST THE XML VISUALIZER
         Console.WriteLine(configXml)
      Catch ex As Exception
      End Try
   End Sub

   Sub TestCustomVisualizer()
      Dim img As Image = Image.FromFile("Ventagli.bmp")
      Dim re As New Regex("\d+")
      Dim filename As String = "C:\Windows\Win.ini"
      Dim finfo As New FileInfo(filename)

      ' uncomment to display the Image Visualizer form
      ' Visualizers.ImageVisualizer.Test(img)
      ' Visualizers.RegexVisualizer.Test(re)
      ' Visualizers.FileVisualizer.Test(filename)

      ' SET A BREAKPOINT HERE TO TEST ALL CUSTOM VISUALIZERS 
      Console.WriteLine("Image size: {0} x {1}", img.Size.Width, img.Size.Height)
   End Sub

   Sub DebugMethods()
      Debug.Print("Name={0}, Weight={1:N2}", "Joe", 123.4)
      ' => Name=Joe, Weight=123.40  (followed by a newline)

      ' You can specify a message and a detailed message.
      Trace.Fail("An error has occurred", "File app.ini not found")

      Debug.WriteLine("Entering DebugMethods")
      Debug.Indent()
      Debug.WriteLine("Inside DebugMethods")
      Debug.Unindent()
      Debug.WriteLine("Exiting DebugMethods")
   End Sub

   Sub TraceMethods()
      Trace.WriteLine("Entering TraceMethods")
      Trace.Indent()
      Trace.WriteLine("Inside TraceMethods")
      Trace.Unindent()
      Trace.WriteLine("Exiting TraceMethods")
   End Sub

   Sub BooleanSwitches()
      Dim bsProfile As New BooleanSwitch("bsProfile", "")
      Dim tsDiagnostic As New TraceSwitch("tsDiagnostic", "")

      ' Display this information only if level is verbose enough.
      Trace.WriteLineIf(tsDiagnostic.Level >= 3, "Starting the application at " & Now.ToString())

      If bsProfile.Enabled Then
         ' Add code for benchmarking here.

      End If
   End Sub

   Sub TestTraceListeners()
      ' Disable this section if you use the corresponding
      ' entries from the configuration file (App2.config)


#If APPCONFIG_USED <> 1 Then
      ' Send trace output to the console window's standard output stream.
      Trace.Listeners.Add(New ConsoleTraceListener(False))

      ' Send trace output to a text file.
      Dim sw As New StreamWriter("trace.txt")
      Trace.Listeners.Add(New TextWriterTraceListener(sw))
#End If

      ' Do some tracing
      Trace.WriteLine("First trace message")
      Trace.WriteLine("Second trace message")

      ' Send trace output to the Application log on  the local machine,
      ' using a source named TracingDemo. 
      Dim ev As New EventLog("Application", ".", "TracingDemo")
      Trace.Listeners.Add(New EventLogTraceListener("TracingDemo"))

      ' Test it
      Trace.WriteLine("Test message for the EventLogTraceListener")

      ' Close the event log before exiting the program.
      ev.Close()

#If APPCONFIG_USED <> 1 Then
      ' Close the stream before exiting the program.
      sw.Close()
#End If
   End Sub

   Sub CustomTraceFormat()
      Dim listener As New ConsoleTraceListener()
      listener.TraceOutputOptions = TraceOptions.DateTime Or TraceOptions.ProcessId
      Trace.Listeners.Add(listener)

      Trace.TraceInformation("Application started")
      Trace.TraceInformation("...")
      Trace.TraceInformation("Application ended")
   End Sub

   Sub CustomTraceFilter()
      Dim twtl As New TextWriterTraceListener("trace2.txt")
      twtl.Filter = New TraceFilterByThreadID(Thread.CurrentThread.ManagedThreadId)
      Trace.Listeners.Add(twtl)

      Trace.TraceInformation("Application started")
      Trace.TraceInformation("...")
      Trace.TraceInformation("Application ended")
   End Sub

   Sub TestTraceSource()
      ' This code is based on App2.config
#If APPCONFIG_USED <> 2 Then
      Stop
#End If

      ' Create a TraceSource named ProfileTracer that initially traces warnings and errors.
      Dim tracer As New TraceSource("ProfileTracer")
      tracer.Switch.Level = SourceLevels.Warning Or SourceLevels.Error
      ' Prepare to send trace messages to file.
      Dim twtl As New TextWriterTraceListener(".\profiletraceinfo.txt")
      tracer.Listeners.Add(twtl)
      ' When tracing to a file you must set the Trace.AutoFlash property. (See note.)
      Trace.AutoFlush = True

      ' examples

      ' Trace an error message, with an ID event equal to 100.
      tracer.TraceEvent(TraceEventType.Error, 100, "Out of range")
      ' Trace the value of an object (not shown in this short demo).
      Dim pers As New Person("Joe", "Smith")
      tracer.TraceData(TraceEventType.Warning Or TraceEventType.Information, 100, pers)
      ' Send a simple trace message. Same as:
      '   TraceEvent(TraceEventType.Information, 0, "Benchmark end") 
      tracer.TraceInformation("Benchmark end")

      tracer.TraceEvent(TraceEventType.Information Or TraceEventType.Start, _
         100, "Application starts")

      Try
         File.ReadAllText("c:xxx")
      Catch ex As Exception
         tracer.TraceEvent(TraceEventType.Information, 10, "Exception {0} occurred at {1}", _
            ex.Message, ex.StackTrace)
      End Try
   End Sub

   Sub TestTraceSource2()
      ' This code requires that you use App3.config
      ' This code is based on App2.config
#If APPCONFIG_USED <> 3 Then
      Stop
#End If
      Dim tracer As New TraceSource("ProfileTracer")
      Dim actTracer As New TraceSource("ActivityTracer")
      Trace.AutoFlush = True

      actTracer.TraceEvent(TraceEventType.Start, 0)
      tracer.TraceEvent(TraceEventType.Error, 100, "It's an error")
      tracer.TraceEvent(TraceEventType.Warning, 100, "It's a warning")
      actTracer.TraceEvent(TraceEventType.Stop, 0)
   End Sub

   Sub TestStopwatch()
      ' Create the StopWatch and start counting elapsed time.
      Dim sw As Stopwatch = Stopwatch.StartNew()
      ' Place the code to be benchmarked here.

      Dim s As String = ""
      For i As Integer = 1 To 10000
         s &= CStr(i)
      Next

      ' Stop counting the elapsed time and display the number of elapsed seconds.
      sw.Stop()
      Console.WriteLine("Time elapsed: {0}", sw.Elapsed)
   End Sub

   Sub TestDebuggerType()
      If Debugger.IsAttached Then
         Console.WriteLine("This application can't run under a debugger.")
         Return
      End If

      For i As Integer = 0 To 10
         ' Break when the index variable is a multiple of 2, 3, or 5.
         If i Mod 2 = 0 OrElse i Mod 3 = 0 OrElse i Mod 5 = 0 Then Debugger.Break()
         ' do something here
      Next
   End Sub

   Sub TestStackTrace()
      Dim st As New StackTrace()
      ' Enumerate all the stack frame objects.
      ' (The frame at index 0 corresponds to the current routine.)
      For i As Integer = 0 To st.FrameCount - 1
         ' Get the ith stack frame and print the method name.
         Dim sf As StackFrame = st.GetFrame(i)
         Console.WriteLine(sf.GetMethod.Name)
      Next

   End Sub

   Sub TestStackFrameFromException()
      Try
         ' This causes an exception.
         TestStackFrameFromException_1(1)
      Catch e As Exception
         DisplayExceptionInfo(e)
      End Try
   End Sub

   Private Sub TestStackFrameFromException_1(ByVal x As Integer)
      TestStackFrameFromException_2("abc")
   End Sub

   Private Function TestStackFrameFromException_2(ByVal x As String) As String
      TestStackFrameFromException_3()
      Return Nothing
   End Function

   Private Sub TestStackFrameFromException_3()
      ' Cause an exception (null reference).
      Dim o As Object = Nothing
      Console.Write(o.ToString)
   End Sub


   Sub TestDebugInZone()
      ' RUN THIS CODE WITH CLICKONCE SETTINGS ENABLED, TO SEE THE EXCEPTION
      ' Read the names of files in the root directory of C: drive.
      Dim files() As String = Directory.GetFiles("c:\")
   End Sub

   Sub TestVsHost()
      ' This code assumes that application is named TestApp.
      Dim configFile As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
      Console.WriteLine(configFile)      ' => C:\TestApp\Bin\Debug\TestApp.vshost.exe.config

   End Sub

   Sub TestClearLocalVariablesMacro()
      TestClearLocalVariablesMacro("abc", 123)
   End Sub

   Sub TestClearLocalVariablesMacro(ByVal str As String, ByVal num As Integer)
      Dim i As Integer
      Dim k As String
      Dim b As Boolean

      i = 444
      k = "foobar"
      b = True

      ' RUN THE ClearLocalVariables MACRO HERE 
      Debugger.Break()
   End Sub

   Sub TestStepIntoOrOutMacro()
      Console.WriteLine("Inside TestStepIntoOrOutMacro")
      ' EXECUTE THE StepIntoOrOut MACRO HERE
      Debugger.Break()
      TestStepIntoOrOutMacro_1()
      Console.WriteLine("Exiting TestStepIntoOrOutMacro")
   End Sub

   Private Sub TestStepIntoOrOutMacro_1()
      Console.WriteLine("Inside TestStepIntoOrOutMacro_1")
      TestStepIntoOrOutMacro_2()

      Console.WriteLine("Exiting TestStepIntoOrOutMacro_1")
   End Sub

   Private Sub TestStepIntoOrOutMacro_2()
      Console.WriteLine("Inside TestStepIntoOrOutMacro_2")
      ' EXECUTE THE StepIntoOrOut MACRO HERE
      Console.WriteLine("Exiting TestStepIntoOrOutMacro_2")

   End Sub

   Sub TestAppConfigRenamingMacro()
      Console.WriteLine("SERVER NAME = {0}", My.Settings.ServerName)
      Console.ReadLine()
   End Sub

End Module
