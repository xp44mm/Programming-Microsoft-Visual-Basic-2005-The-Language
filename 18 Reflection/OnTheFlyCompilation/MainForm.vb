Imports System.IO
Imports System.Reflection
Imports EvaluatorLibrary
Imports System.CodeDom.Compiler

#Const USEAPPDOMAIN = False

Public Class MainForm

    Private Sub btnEval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEval.Click
        Try
            ' Create an Evaluator object from the dynamic assembly.
            Dim evaluator As Object = GetEvaluatorObject(txtExpression.Text)
            ' Exit if there was a compilation error.
            If evaluator Is Nothing Then Exit Sub

            Dim result As Double = EvalExpression(evaluator, 0)
            txtResult.Text = result.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRoots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoots.Click
        Try
            ' Create an Evaluator object from the dynamic assembly.
            Dim evaluator As Object = GetEvaluatorObject(txtExpression.Text)
            ' Exit if there was a compilation error.
            If evaluator Is Nothing Then Exit Sub

            Dim xmin As Double = CDbl(txtXMin.Text)
            Dim xmax As Double = CDbl(txtXMax.Text)
            Dim xstep As Double = CDbl(txtStep.Text)

            txtResult.Clear()
            Dim x As Double = xmin
            Do While x <= xmax
                Dim root As Object = FindRoot(evaluator, x, x + xstep)
                If Not root Is Nothing Then
                    x = Math.Round(CDbl(root), 6)
                    txtResult.AppendText("X = " & x.ToString & ControlChars.CrLf)
                End If
                x += xstep
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Create an assembly on the fly with an Evaluator.Eval method
    ' that returns the value of an F(x) expression

    Function GetEvaluatorObject(ByVal expression As String) As Object

#If USEAPPDOMAIN Then
        ' get the filename of the DLL
        Dim currAsmPath As String = Path.GetDirectoryName([Assembly].GetExecutingAssembly.Location)
        Dim dllfile As String = Path.Combine(currasmpath, "EvaluatorLibrary.Dll")
        ' CReate a new AppDomain
        Dim appdomSetup As New AppDomainSetup
        appdomSetup.ApplicationName = "TempExe"
        appdomSetup.ApplicationBase = currAsmPath
        Dim appdom As AppDomain = AppDomain.CreateDomain("tempappdom", Nothing, appdomSetup)
        Dim factory As Factory = DirectCast(appdom.CreateInstanceFromAndUnwrap(dllfile, "EvaluatorLibrary.Factory"), Factory)
        Dim evaluator As IEvaluator = factory.GetEvaluator(expression)
        Return evaluator

#Else
        ' Prepare the source code for the assembly.
        Dim source As String = String.Format(
            "Imports Microsoft.VisualBasic{0}" _
            & "Imports System.Math{0}" _
            & "{0}" _
            & "Public Class Evaluator{0}" _
            & "   Public Function Eval(ByVal x As Double) As Double{0}" _
            & "   ' System.Diagnostics.Debugger.Break{0}" _
            & "      Return {1}{0}" _
            & "   End Function{0}" _
            & "End Class{0}",
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

        ' Add a reference to necessary strong-named assemblies.
        params.ReferencedAssemblies.Add("Microsoft.VisualBasic.Dll")
        params.ReferencedAssemblies.Add("System.Dll")

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

        ' Return an instance of the Evaluator class in the other assembly.
        Return asm.CreateInstance("Evaluator")
#End If
    End Function

    ' Evaluate the expression for a given value

    Function EvalExpression(ByVal evaluator As Object, ByVal x As Double) As Double
#If USEAPPDOMAIN = False Then
        Dim args() As Object = {x}
        Dim result As Object = evaluator.GetType.InvokeMember("Eval", BindingFlags.InvokeMethod, Nothing, evaluator, args)
        Return CDbl(result)
#Else
        ' in this case we can use the IEvaluator interface
        Return DirectCast(evaluator, IEvaluator).Eval(x)
#End If
    End Function

    ' return the root in a given interval, or nothing

    Function FindRoot(ByVal evaluator As Object, ByVal x0 As Double, ByVal x1 As Double) As Object
        ' Find the value of the function at the two extremes of the interval
        Const EPSILON As Double = 0.0000000001
        Try
            ' Eval the function at the two extremes, exit if result is "near" zero.
            Dim y0 As Double = EvalExpression(evaluator, x0)
            If Math.Abs(y0) < EPSILON Then Return x0
            Dim y1 As Double = EvalExpression(evaluator, x1)
            If Math.Abs(y1) < EPSILON Then Return x1
            ' No root in this interval if both values have same sign.
            If Math.Sign(y0) = Math.Sign(y1) Then Return Nothing

            ' Eval the function at the mid-point, exit if we've found a root.
            Dim xm As Double = (x0 + x1) / 2
            Dim ym As Double = EvalExpression(evaluator, xm)
            If Math.Abs(ym) < EPSILON Then Return xm

            ' Find the root in the proper half.
            If Math.Sign(ym) = Math.Sign(y0) Then
                x0 = xm
            Else
                x1 = xm
            End If
            Return FindRoot(evaluator, x0, x1)
        Catch ex As Exception
            ' ignore exceptions
            Return Nothing
        End Try
    End Function

End Class
