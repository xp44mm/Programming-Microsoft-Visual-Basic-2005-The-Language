Imports System.Data.SqlClient

#If USE_STATIC_METHODS Then

Namespace My
   Public Class Data
      Public Shared Function GetDataTable(ByVal connString As String, ByVal query As String) As DataTable
         Dim dt As New DataTable
         ' Open a connection.
         Using cn As New SqlConnection(connString)
            cn.Open()
            ' Open a data reader.
            Dim cmd As New SqlCommand(query, cn)
            Using dr As SqlDataReader = cmd.ExecuteReader()
               ' Fill the data table.
               dt.Load(dr)
            End Using
         End Using
         Return dt
      End Function
   End Class
End Namespace

#Else

Namespace My
   <System.Diagnostics.DebuggerNonUserCodeAttribute(), _
    Microsoft.VisualBasic.HideModuleName()> _
   Public Module MyCustomTypes
      Dim m_data As MyData

      Public ReadOnly Property Data() As MyData
         Get
            ' Instantiate the object only when strictly needed.
            If m_data Is Nothing Then m_data = New MyData
            Return m_data
         End Get
      End Property
   End Module
End Namespace

Public Class MyData
   Public Function GetDataTable(ByVal connString As String, ByVal query As String) As DataTable
      Dim dt As New DataTable
      ' Open a connection.
      Using cn As New SqlConnection(connString)
         cn.Open()
         ' Open a data reader.
         Dim cmd As New SqlCommand(query, cn)
         Using dr As SqlDataReader = cmd.ExecuteReader()
            ' Fill the data table.
            dt.Load(dr)
         End Using
      End Using
      Return dt
   End Function
End Class

#End If
