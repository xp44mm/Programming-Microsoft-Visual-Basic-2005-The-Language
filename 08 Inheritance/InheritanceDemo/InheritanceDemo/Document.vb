' An example of abstract class

Public MustInherit Class Document
   ' Contents in RTF format
   Private m_RTFText As String

   Overridable Property RTFText() As String
      Get
         Return m_RTFText
      End Get
      Set(ByVal Value As String)
         m_RTFText = Value
      End Set
   End Property

   ' Save RTF contents to file.
   Overridable Sub SaveToFile(ByVal fileName As String)
      '…
   End Sub

   ' Load RTF contents from file.
   Overridable Sub LoadFromFile(ByVal fileName As String)
      '…
   End Sub

   ' Print the RTF contents.
   Overridable Sub Print()
      '…
   End Sub
End Class

' A class that provides a concrete implementation of an abstract class

Class PurchaseOrder
   Inherits Document

   ' Redefines how a PO is printed.
   Public Overrides Sub Print()
      '…
   End Sub
End Class

