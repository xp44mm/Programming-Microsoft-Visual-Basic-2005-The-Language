Public Class ListWindowsForm

   Private Sub ListWindows_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim topWindows As New WindowCollection
      tvwWindows.Nodes.Clear()
      AddWindows(tvwWindows.Nodes, topWindows)
   End Sub


   ' helper recursive routine
   Private Sub AddWindows(ByVal nodes As TreeNodeCollection, ByVal windows As WindowCollection)
      Dim w As Window
      For Each w In windows
         ' add this window
         Dim n As TreeNode = nodes.Add(w.Description)
         ' recurse on its child windows
         AddWindows(n.Nodes, w.ChildWindows)
      Next

   End Sub
End Class