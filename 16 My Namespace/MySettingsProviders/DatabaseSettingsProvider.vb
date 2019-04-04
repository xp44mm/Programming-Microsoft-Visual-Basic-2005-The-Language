Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.OleDb
Imports System.Reflection

Public Class DatabaseSettingsProvider
   Inherits SettingsProvider

   Private m_ApplicationName As String = Assembly.GetExecutingAssembly().GetName().Name

   ' The name of the calling application
   Public Overrides Property ApplicationName() As String
      Get
         Return m_ApplicationName
      End Get
      Set(ByVal value As String)
         m_ApplicationName = value
      End Set
   End Property

   ' Return the name of this settings provider.
   Public Overrides ReadOnly Property Name() As String
      Get
         Return "DatabaseSettingsProvider"
      End Get
   End Property

   ' The connection to the database that holds application settings. (Edit as required.)
   Private connStr As String = _
      "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""D:\Books\Programming VBNET 2005\Code\MyNamespace\MySettingsProviders\AppSettings.mdb"";Persist Security Info=True"

   Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
      MyBase.Initialize(Me.Name, config)
   End Sub

   ' Get the values for all settings from the database.

   Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, _
         ByVal collection As SettingsPropertyCollection) As SettingsPropertyValueCollection
      ' Load a hashtable with all the application- and user-level settings.
      Dim ht As New Hashtable
      Using cn As New OleDbConnection(connStr)
         cn.Open()
         ' Find all application and current user's settings.
         Dim sql As String = String.Format( _
            "SELECT * FROM {0} WHERE UserName='{1}' OR UserName IS NULL", _
            Me.ApplicationName, My.User.Name)
         Dim cmd As New OleDbCommand(sql, cn)
         Using dr As OleDbDataReader = cmd.ExecuteReader()
            ' Assign to hashtable for quick retrieval.
            Do While dr.Read
               ht.Add(dr("SettingName").ToString, dr("SettingValue"))
            Loop
         End Using
      End Using

      ' Return property values in the format expected by the caller.
      Dim values As New SettingsPropertyValueCollection
      For Each prop As SettingsProperty In collection
         Dim propValue As New SettingsPropertyValue(prop)
         propValue.IsDirty = False
         propValue.SerializedValue = ht(prop.Name)
         values.Add(propValue)
      Next
      Return values
   End Function

   ' Update the database when settings have changed.

   Public Overrides Sub SetPropertyValues(ByVal context As SettingsContext, _
         ByVal collection As SettingsPropertyValueCollection)
      Using cn As New OleDbConnection(connStr)
         cn.Open()

         For Each propValue As SettingsPropertyValue In collection
            If propValue.IsDirty Then
               ' Update the database with the new value. For simplicity we
               ' use dynamic SQL and double all quote characters in values.
               ' A more robust implementation should use parameterized commands.
               Dim value As String = propValue.SerializedValue.ToString().Replace("'", "")
               Dim sql As String = String.Format("UPDATE {0} SET SettingValue='{1}'" _
                  & " WHERE UserName='{2}' AND SettingName='{3}'", _
                  Me.ApplicationName, value, My.User.Name, propValue.Name)
               Using cmd As New OleDbCommand(sql, cn)
                  Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                  ' Insert a new row if the update command failed.
                  If rowsAffected = 0 Then
                     cmd.CommandText = String.Format( _
                        "INSERT {0} VALUES ('{1}', '{2}', '{3}')", _
                        Me.ApplicationName, My.User.Name, propValue.Name, value)
                     cmd.ExecuteNonQuery()
                  End If
               End Using
            End If
         Next
      End Using
   End Sub
End Class
