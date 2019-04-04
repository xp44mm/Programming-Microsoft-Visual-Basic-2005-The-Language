Imports System.Collections.Generic

Module Helpers
   Sub SetTooltipsAndHelpMessages(ByVal frm As Form, ByVal tooltip As ToolTip, ByVal helpProv As HelpProvider)
      For Each ctrl As Control In GetChildControls(frm)
         ' Retrieve the tooltip
         Dim text As String = tooltip.GetToolTip(ctrl)
         ' Convert § to newlines
         text = text.Replace("§", ControlChars.CrLf)
         ' Assign both the tooltip and the help message
         tooltip.SetToolTip(ctrl, text)
         helpProv.SetHelpString(ctrl, text)
      Next
   End Sub

   ' retrieve all controls on a form
   Function GetChildControls(ByVal ctrl As Control) As Control()
      Dim list As New List(Of Control)
      For Each c As Control In ctrl.Controls
         list.Add(c)
         list.AddRange(GetChildControls(c))
      Next
      Return list.ToArray()
   End Function
End Module
