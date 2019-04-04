Imports System.windows.forms

<PluginLibrary.FormExtender("MainApplication.MainForm")> _
Public Class MainForm_Extender

   Sub New(ByVal frm As MainApplication.MainForm)
      ' Add an entry to the Plugins menu.
      Dim item As New ToolStripMenuItem("Show Date", Nothing, AddressOf MenuClick)
      frm.mnuPlugins.DropDownItems.Add(item)
   End Sub

   Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs)
      MessageBox.Show(Date.Now.ToString(), "Current Date/Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
   End Sub

End Class