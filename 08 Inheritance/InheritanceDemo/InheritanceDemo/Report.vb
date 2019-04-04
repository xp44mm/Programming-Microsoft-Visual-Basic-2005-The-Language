Public Class Report
   Public Sub Print()
      OnPrintHeader()
      OnPrintBody()
      OnPrintFooter()
   End Sub

   Protected Overridable Sub OnPrintHeader()
      '…
   End Sub
   Protected Overridable Sub OnPrintBody()
      ' …
   End Sub
   Protected Overridable Sub OnPrintFooter()
      '…
   End Sub
End Class


Public Class Report2
   Inherits Report

   Protected Overrides Sub OnPrintHeader()
      ' Print no header.
   End Sub

   Protected Overrides Sub OnPrintFooter()
      ' Print all totals here.
      '…
      ' Print the standard footer.
      MyBase.OnPrintFooter()
   End Sub
End Class
