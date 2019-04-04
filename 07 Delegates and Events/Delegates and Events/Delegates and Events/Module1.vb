Imports System.IO

Module Module1

   Sub Main()
      'TestDelegate()
      'DelegateToStaticMethod()
      'DelegateToInstanceMethod()
      'TestTraverseDirectoryTree()
      'TestListSubfolders()
      'TestCallbackMethod()
      'MulticastDelegates()
      'TestNameChangedEvent()
      'TestCustomEvents()
      'TestEventHandlerList()
   End Sub

   Delegate Sub DisplayMessage(ByVal msg As String)

   Sub TestDelegate()
      Dim deleg As DisplayMessage
      deleg = New DisplayMessage(AddressOf WriteToDebugWindow)

      ' This statement displays the "FooBar" string in the Debug window.
      deleg.Invoke("FooBar")
   End Sub

   Delegate Function AskYesNoQuestion(ByVal msg As String) As Boolean

   Sub DelegateToStaticMethod()
      ' A delegate variable that points to a shared function.
      Dim question As New AskYesNoQuestion(AddressOf MessageDisplayer.AskYesNo)

      ' Call the shared method. (Note that Invoke is omitted.)
      If question("Do you want to save?") Then
         ' Save whatever needs to be saved here.

      End If
   End Sub

   Delegate Function AskQuestion(ByVal DefaultAnswer As Boolean) As Boolean

   Sub DelegateToInstanceMethod()
      ' Create an instance of the class, and initialize its properties.
      Dim msgdisp As New MessageDisplayer()
      msgdisp.MsgText = "Do you want to save?"
      msgdisp.MsgTitle = "File has been modified"
      ' Create the delegate to the instance method.
      ' (Note the object reference in the AddressOf clause.)
      Dim question As New AskQuestion(AddressOf msgdisp.YesOrNo)

      ' Call the instance method through the delegate.
      If question(False) Then
         ' Save whatever needs to be saved here. 
      End If
   End Sub

   Sub TestTraverseDirectoryTree()
      ' Print the name of all the directories under c:\WINDOWS.
      TraverseDirectoryTree("C:\WINDOWS", AddressOf DisplayDirName)
   End Sub

   ' A routine that complies with the TraverseDirectoryTreeCallback syntax
   Private Sub DisplayDirName(ByVal path As String)
      Console.WriteLine(path)
   End Sub

   Sub TestListSubfolders()
      For Each dirName As String In Directory.GetDirectories("c:\windows", "*.*", SearchOption.AllDirectories)
         ' Do whatever you wish with items in the returned ArrayList.
         Console.WriteLine(dirName)
      Next
   End Sub

   Sub TestCallbackMethod()
      ' Print the name of all the directories under c:\WINDOWS.
      TraverseDirectoryTree2("C:\WINDOWS", AddressOf DisplayDirName2)
   End Sub

   Function DisplayDirName2(ByVal path As String) As Boolean
      Console.WriteLine(path)
      If path.EndsWith("\printers") Then Return True
   End Function

   Sub MulticastDelegates()
      ' Notice that you can have a delegate point to methods defined in the .NET Framework.
      Dim cbk As New TraverseDirectoryTreeCallback(AddressOf Console.WriteLine)
      Dim cbk2 As New TraverseDirectoryTreeCallback(AddressOf Debug.WriteLine)

      ' Combine them into a multicast delegate; assign back to first variable.
      ' We need this statement if Option Strict is On.
      cbk = DirectCast([Delegate].Combine(cbk, cbk2), TraverseDirectoryTreeCallback)

      TraverseDirectoryTree("C:\WINDOWS", cbk)

      ' Get the list of individual delegates in a multicast delegate.
      Dim delegates() As [Delegate] = cbk.GetInvocationList()
      ' List the names of all the target methods.
      For Each d As [Delegate] In delegates
         Console.WriteLine(d.Method.Name)
      Next
   End Sub

   Dim WithEvents user As New User()

   Sub TestNameChangedEvent()
      ' This assignment causes the NameChanged event to be raised.
      user.Name = "Joe"
      ' This will make the assignment fail
      user.Name = "Joe12"
      Console.WriteLine(user.Name)
   End Sub


   Private Sub User_NameChanged(ByVal sender As Object, ByVal e As EventArgs) _
         Handles User.NameChanged
      Console.WriteLine("Name property has changed")
   End Sub

   Private Sub User_NameChanging(ByVal sender As Object, _
         ByVal e As NameChangingEventArgs) Handles user.NameChanging
      ' Accept only names that contain alphabetical characters; reject all others.
      If e.ProposedValue Like "*[!A-Za-z]*" Then e.Cancel = True
   End Sub

   Sub TestCustomEvents()
      Dim user As New User()
      AddHandler user.BeforeLogin, AddressOf user_BeforeLogin
      AddHandler user.AfterLogin, AddressOf user_AfterLogin
      user.Login()
   End Sub

   Private Sub user_BeforeLogin(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles user.BeforeLogin
      Console.WriteLine("Before login")
   End Sub

   Private Sub user_AfterLogin(ByVal sender As Object, ByVal e As System.EventArgs) Handles user.AfterLogin
      Console.WriteLine("After login")
   End Sub

   Sub TestEventHandlerList()
      Dim user As New User2()
      AddHandler user.BeforeLogin, AddressOf user_BeforeLogin
      AddHandler user.AfterLogin, AddressOf user_AfterLogin
      user.Login()
   End Sub


End Module
