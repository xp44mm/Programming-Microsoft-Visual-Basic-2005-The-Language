Class MyAddin
   ' You can have two distinct Implements statements if you prefer.
   Implements IAddin, IHostEnvironment

   ' This procedure implements two read-only properties from distinct interfaces.
   Public ReadOnly Property Id() As Long Implements IAddin.Id, IHostEnvironment.HashCode
      Get

      End Get
   End Property

   Protected Overridable Function OnConnection(ByVal environment As String) As Boolean _
      Implements IAddin.OnConnection

   End Function

   Public Sub OnDisconnection() Implements IAddin.OnDisconnection

   End Sub

   Public Property State() As Boolean Implements IAddin.State
      Get

      End Get
      Set(ByVal value As Boolean)

      End Set
   End Property
End Class

Class AnotherAddin
   Inherits MyAddin

   Protected Overrides Function OnConnection(ByVal environment As String) As Boolean

   End Function
End Class
