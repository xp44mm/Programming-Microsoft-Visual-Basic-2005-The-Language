Imports System.Drawing
Imports Microsoft.VisualStudio.DebuggerVisualizers

<Assembly: DebuggerVisualizer(GetType(ImageVisualizer), GetType(VisualizerImageSource), Target:=GetType(Bitmap), Description:="Bitmap visualizer")> 
<Assembly: DebuggerVisualizer(GetType(ImageVisualizer), GetType(VisualizerImageSource), Target:=GetType(IMage), Description:="Image visualizer")> 

Public Class ImageVisualizer
   Inherits DialogDebuggerVisualizer

   Protected Overrides Sub Show(ByVal windowService As IDialogVisualizerService, ByVal objectProvider As IVisualizerObjectProvider)
      ' Retrieve the object to be visualized, exit if wrong type
      Dim img As Image = TryCast(objectProvider.GetObject(), Image)
      If img Is Nothing Then Return

      Dim frm As New ImageVisualizerForm
      frm.VisibleImage = img
      If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         objectProvider.ReplaceObject(frm.VisibleImage)
      End If
   End Sub

   Public Shared Sub Test(ByVal obj As Object)
      Dim host As New VisualizerDevelopmentHost(obj, GetType(ImageVisualizer))
      host.ShowVisualizer()
   End Sub

End Class
