Module MainModule
   Sub Main()
      Application.EnableVisualStyles()
      Application.Run(PluginLibrary.FormExtenderManager.Create(Of MainApplication.MainForm)())
   End Sub
End Module
