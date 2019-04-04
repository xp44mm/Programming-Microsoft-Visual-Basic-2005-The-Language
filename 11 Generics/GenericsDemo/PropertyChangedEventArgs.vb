Public Class PropertyChangingEventArgs(Of T)
   ' Inheriting from CancelEventArgs adds support for the Cancel property.
   Inherits System.ComponentModel.CancelEventArgs

   Sub New(ByVal proposedValue As T)
      m_ProposedValue = proposedValue
   End Sub

   Private m_ProposedValue As T

   Public ReadOnly Property ProposedValue() As T
      Get
         Return m_ProposedValue
      End Get
   End Property
End Class


