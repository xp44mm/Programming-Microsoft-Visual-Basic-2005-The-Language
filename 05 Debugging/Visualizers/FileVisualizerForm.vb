Imports System.IO
Imports System.Windows.Forms

Public Class FileVisualizerForm

   Private m_FileName As String

   Public Property FileName() As String
      Get
         Return m_FileName
      End Get
      Set(ByVal value As String)
         m_FileName = value
         ShowFileProperties()
      End Set
   End Property

   Dim m_ReplaceEnabled As Boolean

   Public Property ReplaceEnabled() As Boolean
      Get
         Return m_ReplaceEnabled
      End Get
      Set(ByVal value As Boolean)
         m_ReplaceEnabled = value
      End Set
   End Property

   Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowse.Click
      If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         Me.FileName = OpenFileDialog1.FileName
         ShowFileProperties()
         If Me.ReplaceEnabled Then btnReplace.Enabled = True
      End If
   End Sub

   Sub ShowFileProperties()
      lvwProperties.Items.Clear()

      ' Load the FileInfo object
      Dim info As FileInfo
      Try
         info = New FileInfo(Me.FileName)
      Catch ex As Exception
         MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Exit Sub
      End Try

      AddProperty("Name", info.Name)
      AddProperty("Path", info.DirectoryName)
      AddProperty("Length", info.Length)
      AddProperty("CreationTime", info.CreationTime)
      AddProperty("LastWriteTime", info.LastWriteTime)
      AddProperty("LastAccessTime", info.LastAccessTime)
      AddProperty("Attributes", info.Attributes.ToString())

      ' try to load in rtbox control
      rtbContents.Clear()
      Try
         rtbContents.LoadFile(info.FullName)
      Catch ex As Exception
         Try
            Dim text As String = File.ReadAllText(info.FullName)
            rtbContents.Text = text
         Catch ex1 As Exception
            rtbContents.Text = ex.Message
         End Try
      End Try

   End Sub

   Private Sub AddProperty(ByVal name As String, ByVal value As Object)
      Dim item As ListViewItem = lvwProperties.Items.Add(name)
      item.SubItems.Add(value.ToString())
   End Sub


End Class