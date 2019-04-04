Public Class Invoice
   ' This variable holds the number of instances created so far.
   Private Shared InstanceCount As Integer

   Public Sub New()
      ' Increment number of created instances.
      InstanceCount += 1
      ' Use the current count as the ID for this instance.
      m_Id = InstanceCount
   End Sub

   ' A unique ID for this instance
   Private ReadOnly m_Id As Long

   Public ReadOnly Property ID() As Long
      Get
         Return m_ID
      End Get
   End Property

   Public Shared ReadOnly Property NextInvoiceID() As Long
      Get
         Return InstanceCount + 1
      End Get
   End Property

End Class
