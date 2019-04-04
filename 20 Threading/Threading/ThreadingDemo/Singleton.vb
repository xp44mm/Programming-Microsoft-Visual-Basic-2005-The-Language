Imports System.Threading

Public Class Singleton
   Private Shared m_Instance As Singleton
   Private Shared sharedLock As New Object()

   Public Shared ReadOnly Property Instance() As Singleton
      Get
         If m_Instance Is Nothing Then
            SyncLock sharedLock
               If m_Instance Is Nothing Then
                  Dim tempInstance As New Singleton()
                  ' Ensure that writes related to instantiation are flushed.
                  Thread.MemoryBarrier()
                  m_Instance = tempInstance
               End If
            End SyncLock
         End If
         Return m_Instance
      End Get
   End Property

End Class
