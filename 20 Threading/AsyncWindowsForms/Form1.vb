Imports System.IO
Imports System.Threading
Imports System.ComponentModel

Public Class Form1

   ' A delegate that can point to the ShowMessage procedure.
   Delegate Sub ShowMessageDelegate(ByVal msg As String)
   ' An instance of the delegate.
   Dim threadSafeDelegate As ShowMessageDelegate

   Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      Dim t As New Thread(AddressOf SearchFiles)
      t.Start("c:\windows")
   End Sub

   ' This method must run in the main UI thread.
   Sub ShowMessage(ByVal msg As String)
      ' Use the Invoke method only if necessary.
      If Me.InvokeRequired Then
         Me.Invoke(threadSafeDelegate, msg)
         Return
      End If

      Me.lblMessage.Text = msg
      Me.Refresh()
   End Sub

   ' (This method runs in a non-UI thread.)
   Sub SearchFiles(ByVal arg As Object)
      ' Retrieve the argument.
      Dim path As String = arg.ToString()
      ' Prepare the delegate
      threadSafeDelegate = New ShowMessageDelegate(AddressOf ShowMessage)
      ' Invoke the worker procedure. (The result isn't used in this demo.) 
      Dim files As List(Of String) = GetFiles(path)
      ' Show that execution has terminated.
      Dim msg As String = String.Format("Found {0} files", files.Count)
      Me.Invoke(threadSafeDelegate, msg)
   End Sub

   ' A recursive function that retrieves all the files in a directory tree.
   ' (This method runs in a non-UI thread.)
   Function GetFiles(ByVal path As String) As List(Of String)
      ' Display a message.
      Dim msg As String = String.Format("Parsing directory {0}", path)
      Me.Invoke(threadSafeDelegate, msg)

      ' Read the files in this folder and all subfolders.
      Dim files As New List(Of String)
      For Each fi As String In Directory.GetFiles(path)
         files.Add(fi)
      Next
      For Each di As String In Directory.GetDirectories(path)
         files.AddRange(GetFiles(di))
      Next
      Return files
   End Function

   ' backgroundworker demo

   ' The same button works as a Start and a Stop button.
   Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) _
         Handles btnStart.Click
      If btnStart.Text = "Start" Then
         lstFiles.Items.Clear()
         Me.BackgroundWorker1.RunWorkerAsync("c:\windows")
         Me.btnStart.Text = "Stop"
      Else
         Me.BackgroundWorker1.CancelAsync()
      End If
   End Sub

   ' The code that starts the asynchronous file search
   Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) _
      Handles BackgroundWorker1.DoWork
      ' Retrieve the argument.
      Dim path As String = e.Argument.ToString()
      ' Invoke the worker procedure.
      files = New List(Of String)
      SearchFiles(path)
      ' Return a result to the RunWorkerCompleted event.
      Dim msg As String = String.Format("Found {0} files", files.Count)
      e.Result = msg
   End Sub

   Dim files As List(Of String)

   ' A recursive function that retrieves all the files in a directory tree.
   Sub SearchFiles(ByVal path As String)
      ' Display a message
      Dim msg As String = String.Format("Parsing directory {0}", path)
      ' Notice that we don't really use the percentage;
      ' instead, we pass the message in the UserState property.
      Me.BackgroundWorker1.ReportProgress(0, msg)

      ' Read the files in this folder and all subfolders.
      ' Exit immediately if the task has been canceled.
      For Each fi As String In Directory.GetFiles(path)
         If Me.BackgroundWorker1.CancellationPending Then Return
         files.Add(fi)
      Next
      For Each di As String In Directory.GetDirectories(path)
         If Me.BackgroundWorker1.CancellationPending Then Return
         SearchFiles(di)
      Next
   End Sub

   ' We need this variable to avoid nested calls to ProgressChanged.
   Dim callInProgress As Boolean

   Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
      Handles BackgroundWorker1.ProgressChanged
      ' Reject nested calls.
      If callInProgress Then Return
      callInProgress = True
      ' Display the message, received in the UserState property.
      Me.lblMessage.Text = e.UserState.ToString()
      ' Display all files added since last call
      For i As Integer = lstFiles.Items.Count To files.Count - 1
         lstFiles.Items.Add(files(i))
      Next
      Me.Refresh()
      ' Let Windows process message in the queue. 
      ' If you omit this call, clicks on buttons are ignored.
      Application.DoEvents()
      callInProgress = False
   End Sub

   Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
      Handles BackgroundWorker1.RunWorkerCompleted
      ' Display the last message and reset button's caption.
      Me.lblMessage.Text = e.Result.ToString()
      btnStart.Text = "Start"
   End Sub


End Class
