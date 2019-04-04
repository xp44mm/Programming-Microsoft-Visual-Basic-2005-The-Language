Imports Microsoft.VisualBasic.FileIO

Public Class FileSystemForm

   Private Sub btnFindInFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindInFiles.Click
      ' Retrieve the path of the My Documents special folder.
      Dim myDocumentsPath As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
      ' Look for the string "Visual Basic" in all document files in this 
      ' directory tree, in case-insensitive mode.
      Dim files As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = _
         My.Computer.FileSystem.FindInFiles(myDocumentsPath, txtFindText.Text, True, _
         FileIO.SearchOption.SearchAllSubDirectories)
      ' Show all file names in a listbox.
      lstFiles.Items.Clear()
      For Each file As String In files
         lstFiles.Items.Add(file)
      Next
   End Sub


   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Dim source As String = Me.txtFromDirectory.Text
      Dim dest As String = Me.txtToDirectory.Text

      Try
         My.Computer.FileSystem.CopyDirectory(source, dest, UIOption.AllDialogs, UICancelOption.ThrowException)
      Catch ex As OperationCanceledException
         ' The user canceled the operation.
         MsgBox(ex.Message)
      Catch ex As Exception
         ' The user canceled the operation.
         MsgBox(ex.Message)
      End Try

   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      ' Delete a folder, displaying the standard Windows dialog box,
      ' sending files to the Recycle bin, and doing nothing if user canceled the action.
      My.Computer.FileSystem.DeleteDirectory(txtDeleteDir.Text, UIOption.AllDialogs, _
         RecycleOption.SendToRecycleBin, UICancelOption.DoNothing)

   End Sub
End Class