Imports System.IO

Public Class Form1

#Const USE_SINGLE_EVENT_HANDLER = True

#If USE_SINGLE_EVENT_HANDLER Then
   ' You can use one event handler for all three events
   Private Sub fsw_All(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles fsw.Changed, fsw.Created, fsw.Deleted
      LogMessage(String.Format("File changed: {0} ({1})", e.FullPath, e.ChangeType))
   End Sub

#Else
    ' three separate event handlers

    Private Sub fsw_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles fsw.Changed
        LogMessage("File changed: " & e.FullPath)
    End Sub

    Private Sub fsw_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles fsw.Created
        LogMessage("File created: " & e.FullPath)
    End Sub

    Private Sub fsw_Deleted(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles fsw.Deleted
        LogMessage("File deleted: " & e.FullPath)
    End Sub
#End If

   ' two more event handlers

   Private Sub fsw_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles fsw.Renamed
      LogMessage("File renamed: " & e.OldFullPath & " => " & e.FullPath)
   End Sub

   Private Sub fsw_Error(ByVal sender As Object, ByVal e As System.IO.ErrorEventArgs) Handles fsw.Error
      LogMessage("FileSystemWatcher error")
   End Sub

   ' Add a string to the log
   Sub LogMessage(ByVal msg As String)
      txtLog.AppendText(msg & ControlChars.CrLf)
   End Sub

   ' enable/disable events

   Private Sub chkEnableEvents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableEvents.CheckedChanged
      Dim f As New System.IO.FileSystemWatcher

      If chkEnableEvents.Checked Then
         fsw.Path = txtPath.Text
         fsw.Filter = txtFilter.Text
         fsw.IncludeSubdirectories = chkIncludeSubdirs.Checked
         fsw.SynchronizingObject = Me
         fsw.NotifyFilter = NotifyFilters.Attributes Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName
         fsw.EnableRaisingEvents = True
      Else
         fsw.EnableRaisingEvents = False
      End If
   End Sub

   ' demonstrate the WaitForChanged method

   Private Sub btnWaitForChanged_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitForChanged.Click
      ' Create a *new* FileSystemWatcher component.
      Dim tmpFsw As New FileSystemWatcher(txtPath.Text, txtFilter.Text)
      ' Wait max 10 seconds for an event.
      Dim res As WaitForChangedResult = tmpFsw.WaitForChanged(WatcherChangeTypes.All, 10000)

      If res.TimedOut Then
         LogMessage("10 seconds have elapsed without any event")
      Else
         Dim changeType As String = [Enum].GetName(GetType(IO.WatcherChangeTypes), res.ChangeType)
         LogMessage("Event: " & res.Name & " (" & changeType & ")")
      End If
   End Sub
End Class
