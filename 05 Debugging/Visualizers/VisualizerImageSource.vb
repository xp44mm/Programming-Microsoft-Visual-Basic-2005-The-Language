Imports System.Drawing
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.VisualStudio.DebuggerVisualizers

Public Class VisualizerImageSource
   Inherits VisualizerObjectSource

   Public Overrides Sub GetData(ByVal target As Object, ByVal outgoingData As Stream)
      If TypeOf target Is Image Then
         Dim bf As New BinaryFormatter
         bf.Serialize(outgoingData, target)
      End If
   End Sub

End Class
