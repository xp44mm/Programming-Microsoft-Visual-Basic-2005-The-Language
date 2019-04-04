Imports System.IO
Imports Microsoft.VisualStudio.DebuggerVisualizers

<Assembly: DebuggerVisualizer(GetType(FileVisualizer), GetType(VisualizerObjectSource), Target:=GetType(String), Description:="File visualizer")> 
<Assembly: DebuggerVisualizer(GetType(FileVisualizer), GetType(VisualizerObjectSource), Target:=GetType(FileInfo), Description:="FileInfo visualizer")> 

Public Class FileVisualizer
   Inherits DialogDebuggerVisualizer

   Protected Overrides Sub Show(ByVal windowService As IDialogVisualizerService, ByVal objectProvider As IVisualizerObjectProvider)
      Dim obj As Object = objectProvider.GetObject()

      ' Display the file in the form 
      Dim frm As New FileVisualizerForm
      If TypeOf obj Is String Then
         ' This is a string containing a filename
         frm.FileName = obj.ToString()
         frm.ReplaceEnabled = False
         frm.ShowDialog()

      ElseIf TypeOf obj Is FileInfo Then
         ' This is FileInfo object
         frm.FileName = DirectCast(obj, FileInfo).FullName
         frm.ReplaceEnabled = True

         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Replace the regex if user clicked on the Replace button 
            Dim newFileInfo As New FileInfo(frm.FileName)
            objectProvider.ReplaceObject(newFileInfo)
         End If
      End If
   End Sub

   ' Static method to test the visualizer 
   Public Shared Sub Test(ByVal obj As Object)
      Dim host As New VisualizerDevelopmentHost(obj, GetType(FileVisualizer))
      host.ShowVisualizer()
   End Sub

End Class
