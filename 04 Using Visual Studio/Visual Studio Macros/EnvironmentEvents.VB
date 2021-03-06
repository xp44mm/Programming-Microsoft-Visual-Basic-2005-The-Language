Option Strict Off
Option Explicit Off
Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics

Imports System.IO
Imports System.Collections

Public Module EnvironmentEvents

#Region "Automatically generated code, do not modify"
'Automatically generated code, do not modify
'Event Sources Begin
	<System.ContextStaticAttribute()> Public WithEvents DTEEvents As EnvDTE.DTEEvents
	<System.ContextStaticAttribute()> Public WithEvents DocumentEvents As EnvDTE.DocumentEvents
	<System.ContextStaticAttribute()> Public WithEvents WindowEvents As EnvDTE.WindowEvents
	<System.ContextStaticAttribute()> Public WithEvents TaskListEvents As EnvDTE.TaskListEvents
	<System.ContextStaticAttribute()> Public WithEvents FindEvents As EnvDTE.FindEvents
	<System.ContextStaticAttribute()> Public WithEvents OutputWindowEvents As EnvDTE.OutputWindowEvents
	<System.ContextStaticAttribute()> Public WithEvents SelectionEvents As EnvDTE.SelectionEvents
	<System.ContextStaticAttribute()> Public WithEvents BuildEvents As EnvDTE.BuildEvents
	<System.ContextStaticAttribute()> Public WithEvents SolutionEvents As EnvDTE.SolutionEvents
	<System.ContextStaticAttribute()> Public WithEvents SolutionItemsEvents As EnvDTE.ProjectItemsEvents
	<System.ContextStaticAttribute()> Public WithEvents MiscFilesEvents As EnvDTE.ProjectItemsEvents
	<System.ContextStaticAttribute()> Public WithEvents DebuggerEvents As EnvDTE.DebuggerEvents
	<System.ContextStaticAttribute()> Public WithEvents ProjectsEvents As EnvDTE.ProjectsEvents
	<System.ContextStaticAttribute()> Public WithEvents TextDocumentKeyPressEvents As EnvDTE80.TextDocumentKeyPressEvents
	<System.ContextStaticAttribute()> Public WithEvents CodeModelEvents As EnvDTE80.CodeModelEvents
	<System.ContextStaticAttribute()> Public WithEvents DebuggerProcessEvents As EnvDTE80.DebuggerProcessEvents
	<System.ContextStaticAttribute()> Public WithEvents DebuggerExpressionEvaluationEvents As EnvDTE80.DebuggerExpressionEvaluationEvents
'Event Sources End
'End of automatically generated code
#End Region


   Private Sub BuildEvents_OnBuildProjConfigDone( _
         ByVal Project As String, ByVal ProjectConfig As String, _
         ByVal Platform As String, ByVal SolutionConfig As String, _
         ByVal Success As Boolean) Handles BuildEvents.OnBuildProjConfigDone

      Dim prj As Project = DTE.Solution.Projects.Item(Project)
      Dim prjDir As String = Path.GetDirectoryName(prj.FileName)
      ' This macro only works only with the active configuration.
      Dim cnf As Configuration = prj.ConfigurationManager.ActiveConfiguration

      ' Get a reference to the right .config file.
      Dim sourceFile As String = Path.Combine(prjDir, cnf.ConfigurationName & ".config")
      ' If not found, look for a file named Default.config.
      If Not File.Exists(sourceFile) Then sourceFile = Path.Combine(prjDir, "Default.config")
      If File.Exists(sourceFile) Then
         ' Evaluate the directory for output files.
         Dim outDir As String = cnf.Properties.Item("OutputPath").Value
         ' If relative file name, convert to absolute path.
         If Not Path.IsPathRooted(outDir) Then outDir = Path.Combine(prjDir, outDir)
         ' Derive the name of the output configuration file.
         Dim configFile As String = outDir & _
            prj.Properties.Item("OutputFileName").Value & ".config"
         ' Copy the file, renaming it in the process.
         Try
            File.Copy(sourceFile, configFile, True)
         Catch ex As System.Exception
            Debug.WriteLine(String.Format("Unable to copy config file {0} to {1}", _
               sourceFile, configFile))
         End Try
      End If
   End Sub


End Module

