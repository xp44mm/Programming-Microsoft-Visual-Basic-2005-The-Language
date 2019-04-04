Imports System.Text.RegularExpressions
Imports Microsoft.VisualStudio.DebuggerVisualizers

<Assembly: DebuggerVisualizer(GetType(RegexVisualizer), GetType(VisualizerObjectSource), Target:=GetType(Regex), Description:="Regex visualizer")> 

Public Class RegexVisualizer
   Inherits DialogDebuggerVisualizer

   Protected Overrides Sub Show(ByVal windowService As Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService, ByVal objectProvider As Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider)
      Dim re As Regex = TryCast(objectProvider.GetObject(), Regex)
      If re Is Nothing Then Exit Sub

      ' Display the regex in the form 
      Dim frm As New RegexVisualizerForm
      frm.RegexPattern = re.ToString()

      If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         ' Replace the regex if user clicked on the Replace button 
         Dim newRegex As New Regex(frm.RegexPattern)
         objectProvider.ReplaceObject(newRegex)
      End If
   End Sub

   ' Static method to test the visualizer 
   Public Shared Sub Test(ByVal obj As Object)
      Dim host As New VisualizerDevelopmentHost(obj, GetType(RegexVisualizer))
      host.ShowVisualizer()
   End Sub
End Class
