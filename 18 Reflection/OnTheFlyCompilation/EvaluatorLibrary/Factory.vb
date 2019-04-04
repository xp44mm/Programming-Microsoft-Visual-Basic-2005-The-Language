Imports System.CodeDom.Compiler
Imports System.Reflection
Imports System.IO
Imports System.windows.Forms

Public Class Factory
   Inherits MarshalByRefObject

   Public Function GetEvaluator(ByVal expression As String) As IEvaluator
      Dim source As String = String.Format( _
          "Imports Microsoft.VisualBasic{0}" _
          & "Imports System.Math{0}" _
          & "Imports EvaluatorLibrary{0}" _
          & "{0}" _
          & "Public Class Evaluator{0}" _
          & "   Inherits System.MarshalByrefObject{0}" _
          & "   Implements IEvaluator{0}" _
          & "   Public Function Eval(ByVal x As Double) As Double Implements IEvaluator.Eval{0}" _
          & "   ' System.Diagnostics.Debugger.Break{0}" _
          & "      Return {1}{0}" _
          & "   End Function{0}" _
          & "End Class{0}", _
          ControlChars.CrLf, expression)


      Dim params As New CompilerParameters
      ' Generate a DLL, not and EXE executable.
      ' (Not really necessary, as False is the default.)
      params.GenerateExecutable = False
      ' Generate the assembly in memory, don't save to a file
      params.GenerateInMemory = True

#If DEBUG Then
      ' Include debug information and keep temporary source files.
      params.IncludeDebugInformation = True
      params.TempFiles.KeepFiles = True
      params.GenerateInMemory = False
      'params.OutputAssembly = "c:\out.dll"

#Else
        ' Treat warnings as errors, don't keep temporary source files.
        params.TreatWarningsAsErrors = True 
        params.TempFiles.KeepFiles = False 
        ' Optimize the code for faster execution.
        params.CompilerOptions = "/Optimize+"
#End If
      ' The path of the current assembly
      Dim currAsmFile As String = [Assembly].GetExecutingAssembly.Location
      Dim currAsmPath As String = Path.GetDirectoryName(currAsmFile)

      ' create the dynamic assembly with a fixed name
      'params.OutputAssembly = Path.Combine(currAsmPath, "temp.dll")
      'Directory.SetCurrentDirectory(currAsmPath)

      ' Add a reference to necessary strong-named assemblies.
      params.ReferencedAssemblies.Add("Microsoft.VisualBasic.Dll")
      params.ReferencedAssemblies.Add("System.Dll")
      ' Add a reference to the current DLL (non strong-named)
      params.ReferencedAssemblies.Add(currAsmFile)

      ' Create the VB compiler.
      Dim provider As New VBCodeProvider
      Dim compRes As CompilerResults = provider.CompileAssemblyFromSource(params, source)

      ' Check whether we have errors.
      If compRes.Errors.Count > 0 Then
         ' Gather all error messages, display them, and exit.
         Dim msg As String = ""
         For Each compErr As CompilerError In compRes.Errors
            msg &= compErr.ToString & ControlChars.CrLf
         Next
         MessageBox.Show(msg, "Compilation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return Nothing
      End If

      ' Get a reference to the compiled assembly.
      Dim asm As [Assembly] = compRes.CompiledAssembly

      Dim evaluator As IEvaluator = DirectCast(asm.CreateInstance("Evaluator"), IEvaluator)
      Return evaluator

   End Function



End Class
