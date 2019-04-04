Imports System.Runtime.InteropServices

Class FileOperation

   Shared Function CopyFile(ByVal source As String, ByVal dest As String, Optional ByVal progressText As String = Nothing) As Integer
      Const FO_COPY As Integer = &H2
      Const RENAMEONCOLLISION As Integer = &H8
      Const ALLOWUNDO As Integer = &H40
      Const SIMPLEPROGESS As Integer = &H100

      ' Fill an SHFILEOPSTRUCT structure.
      Dim sh As SHFILEOPSTRUCT
      sh.wFunc = CType(FO_COPY, FileOp)
      sh.hwnd = IntPtr.Zero    ' No owner window
      sh.pTo = dest
      ' Ensure source file ends with an extra null char. (See SDK docs.)
      sh.pFrom = source & ControlChars.NullChar
      sh.fFlags = CType(ALLOWUNDO Or RENAMEONCOLLISION, FileOpFlags)

      If Not (progressText Is Nothing) Then
         ' allocate an ANSI string somewhere in memory and store its pointer here
         sh.lpszProgressTitle = Marshal.StringToHGlobalAnsi(progressText)
         sh.fFlags = sh.fFlags Or FileOpFlags.SimpleProgress
      End If

      Dim res As Integer = SHFileOperation(sh)

      If Not (progressText Is Nothing) Then
         ' release any memory taken for the ProgressTitle string
         Marshal.FreeHGlobal(sh.lpszProgressTitle)
         sh.lpszProgressTitle = IntPtr.Zero
      End If

      ' The API functions returns non-zero if there is a problem.
      If res = 0 Then
         Return 0              ' 0 means everything was OK.
      ElseIf sh.fAnyOperationsAborted Then
         Return 1              ' 1 means user aborted the operation.
      Else
         Return 2              ' 2 means an error has occurred.
      End If
   End Function

   Private Declare Ansi Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationA" (ByRef lpFileOp As SHFILEOPSTRUCT) As Integer

   <StructLayout(LayoutKind.Explicit)> _
   Private Structure SHFILEOPSTRUCT
      <FieldOffset(0)> Public hwnd As IntPtr
      <FieldOffset(4)> Public wFunc As FileOp
      <FieldOffset(8)> Public pFrom As String
      <FieldOffset(12)> Public pTo As String
      <FieldOffset(16)> Public fFlags As FileOpFlags
      <FieldOffset(18), MarshalAs(UnmanagedType.Bool)> Public fAnyOperationsAborted As Boolean
      <FieldOffset(22)> Public hNameMappings As Integer
      <FieldOffset(26)> Public lpszProgressTitle As IntPtr ' was String, only used if FOF_SIMPLEPROGRESS
   End Structure

   Private Enum FileOp As Integer
      FO_COPY = &H2
      FO_DELETE = &H3
      FO_MOVE = &H1
      FO_RENAME = &H4
   End Enum

   ' the handle of the parent window
   Private ReadOnly m_hWnd As IntPtr
   ' True if user canceled the operation
   Private m_Canceled As Boolean
   ' flags to be used for the operation
   Private m_Flags As FileOpFlags = FileOpFlags.AllowUndo

   ' constructors

   Sub New()
      Me.New(IntPtr.Zero)    ' dialog box has no parent window
   End Sub

   Sub New(ByVal ownerForm As Form)
      Me.New(ownerForm.Handle)
   End Sub

   Sub New(ByVal ownerhandle As IntPtr)
      m_hWnd = ownerhandle
   End Sub

   ' private helper routine for setting a bit
   Private Sub SetFlag(ByRef flags As FileOpFlags, ByVal flagMask As FileOpFlags, ByVal value As Boolean)
      If value Then
         flags = flags Or flagMask
      Else
         flags = flags And Not flagMask
      End If
   End Sub

   ' the Flags property

   Property Flags() As FileOpFlags
      Get
         Return m_Flags
      End Get
      Set(ByVal Value As FileOpFlags)
         m_Flags = Value
      End Set
   End Property

   ' the AllowUndo property (default is True)

   Property AllowUndo() As Boolean
      Get
         Return CBool(m_Flags And FileOpFlags.AllowUndo)
      End Get
      Set(ByVal Value As Boolean)
         SetFlag(m_Flags, FileOpFlags.AllowUndo, Value)
      End Set
   End Property

   ' the NoConfirmation property 

   Property NoConfirmation() As Boolean
      Get
         Return CBool(m_Flags And FileOpFlags.NoConfirmation)
      End Get
      Set(ByVal Value As Boolean)
         SetFlag(m_Flags, FileOpFlags.NoConfirmation, Value)
      End Set
   End Property

   ' the NoConfirmMkDir property 

   Property NoConfirmMkDir() As Boolean
      Get
         Return CBool(m_Flags And FileOpFlags.NoConfirmMkDir)
      End Get
      Set(ByVal Value As Boolean)
         SetFlag(m_Flags, FileOpFlags.NoConfirmMkDir, Value)
      End Set
   End Property

   ' the RenameOnCollision property 

   Property RenameOnCollision() As Boolean
      Get
         Return CBool(m_Flags And FileOpFlags.RenameOnCollision)
      End Get
      Set(ByVal Value As Boolean)
         SetFlag(m_Flags, FileOpFlags.RenameOnCollision, Value)
      End Set
   End Property

   ' the Silent property 

   Property Silent() As Boolean
      Get
         Return CBool(m_Flags And FileOpFlags.Silent)
      End Get
      Set(ByVal Value As Boolean)
         SetFlag(m_Flags, FileOpFlags.Silent, Value)
      End Set
   End Property


   ' the ProgressTitle property
   ' if set, it automatically sets the SimpleProgress flag
   Dim m_ProgressTitle As String

   Property ProgressTitle() As String
      Get
         Return m_ProgressTitle
      End Get
      Set(ByVal Value As String)
         m_ProgressTitle = Value
      End Set
   End Property

   ' return True if user canceled the operation

   ReadOnly Property Canceled() As Boolean
      Get
         Return m_Canceled
      End Get
   End Property

   ' public methods

   ' copy one file (supports wildcards)

   Function Copy(ByVal sourceFile As String, ByVal destFile As String, ByVal flags As FileOpFlags) As Boolean
      Dim sh As SHFILEOPSTRUCT
      sh.wFunc = FileOp.FO_COPY
      sh.pFrom = sourceFile
      sh.pTo = destFile
      sh.fFlags = flags
      Return Execute(sh)
   End Function

   ' copy multiple files to the same target directory

   Function Copy(ByVal sourceFiles() As String, ByVal destDir As String, ByVal flags As FileOpFlags) As Boolean
      ' create a string containing the list of files
      Dim files As String = String.Join(ControlChars.NullChar, sourceFiles)
      ' delegate to the simpler version of this method
      Return Copy(files, destDir, flags)
   End Function

   ' copy multiple files, specifying a different target name for each one

   Function Copy(ByVal sourceFiles() As String, ByVal destFiles() As String, ByVal flags As FileOpFlags) As Boolean
      ' create a list containing the list of destination files
      Dim files As String = String.Join(ControlChars.NullChar, destFiles)
      ' delegate to the simpler version of this method, but ensure a flag is set
      Return Copy(sourceFiles, files, flags Or FileOpFlags.MultiDestFiles)
   End Function

   ' three more versions that don't take a Flags argument
   Function Copy(ByVal sourceFile As String, ByVal destFile As String) As Boolean
      Return Copy(sourceFile, destFile, Me.Flags)
   End Function

   Function Copy(ByVal sourceFiles() As String, ByVal destDir As String) As Boolean
      Return Copy(sourceFiles, destDir, Me.Flags)
   End Function

   Function Copy(ByVal sourceFiles() As String, ByVal destFiles() As String) As Boolean
      Return Copy(sourceFiles, destFiles, Me.Flags)
   End Function

   ' move one file (supports wildcards)

   Function Move(ByVal sourceFile As String, ByVal destFile As String, ByVal flags As FileOpFlags) As Boolean
      Dim sh As SHFILEOPSTRUCT
      sh.wFunc = FileOp.FO_MOVE
      sh.pFrom = sourceFile
      sh.pTo = destFile
      sh.fFlags = flags
      Return Execute(sh)
   End Function

   ' Move multiple files to the same target directory

   Function Move(ByVal sourceFiles() As String, ByVal destDir As String, ByVal flags As FileOpFlags) As Boolean
      ' create a string containing the list of files
      Dim files As String = String.Join(ControlChars.NullChar, sourceFiles)
      ' delegate to the simpler version of this method
      Return Move(files, destDir, flags)
   End Function

   ' move multiple files, specifying a different target name for each one

   Function Move(ByVal sourceFiles() As String, ByVal destFiles() As String, ByVal flags As FileOpFlags) As Boolean
      ' create a list containing the list of destination files
      Dim files As String = String.Join(ControlChars.NullChar, destFiles)
      ' delegate to the simpler version of this method, but ensure a flag is set
      Return Move(sourceFiles, files, flags Or FileOpFlags.MultiDestFiles)
   End Function

   ' three more versions that don't take a Flags argument

   Function Move(ByVal sourceFile As String, ByVal destFile As String) As Boolean
      Return Move(sourceFile, destFile, Me.Flags)
   End Function

   Function Move(ByVal sourceFiles() As String, ByVal destDir As String) As Boolean
      Return Move(sourceFiles, destDir, Me.Flags)
   End Function

   Function Move(ByVal sourceFiles() As String, ByVal destFiles() As String) As Boolean
      Return Move(sourceFiles, destFiles, Me.Flags)
   End Function

   ' rename one file (supports wildcards)

   Function Rename(ByVal oldFile As String, ByVal newFile As String, ByVal flags As FileOpFlags) As Boolean
      Dim sh As SHFILEOPSTRUCT
      sh.wFunc = FileOp.FO_RENAME
      sh.pFrom = oldFile
      sh.pTo = newFile
      sh.fFlags = flags
      Return Execute(sh)
   End Function

   ' a version that doesn't take a Flags argument
   Function Rename(ByVal oldFile As String, ByVal newFile As String) As Boolean
      Return Rename(oldFile, newFile, Me.Flags)
   End Function

   ' delete one file (support wildcards)

   Function Delete(ByVal sourceFile As String, ByVal flags As FileOpFlags) As Boolean
      Dim sh As New SHFILEOPSTRUCT
      sh.wFunc = FileOp.FO_DELETE
      sh.pFrom = sourceFile
      Return Execute(sh)
   End Function

   ' delete multiple files

   Function Delete(ByVal sourceFiles() As String, ByVal flags As FileOpFlags) As Boolean
      ' create a string containing the list of files
      Dim files As String = String.Join(ControlChars.NullChar, sourceFiles)
      ' delegate to the simpler version of this method
      Return Delete(files, flags)
   End Function

   ' two more versions that don't take a Flags argument

   Function Delete(ByVal sourceFile As String) As Boolean
      Return Delete(sourceFile, Me.Flags)
   End Function

   Function Delete(ByVal sourceFiles() As String) As Boolean
      Return Delete(sourceFiles, Me.Flags)
   End Function

   Shared Function CopyFile(ByVal source As String, ByVal dest As String, ByRef canceled As Boolean) As Boolean
      Const FO_COPY As Integer = &H2
      ' Fill the SHFILEOPSTRUCT structure
      Dim sh As SHFILEOPSTRUCT
      sh.wFunc = CType(FO_COPY, FileOp)
      sh.hwnd = IntPtr.Zero
      sh.pTo = dest
      ' Ensure source file ends with an extra null char. (See SDK docs.)
      sh.pFrom = source & ControlChars.NullChar
      sh.fFlags = FileOpFlags.AllowUndo Or FileOpFlags.RenameOnCollision
      ' call the API function
      If SHFileOperation(sh) <> 0 Then
         ' There was an error - set Cancel if user canceled the operation.
         canceled = sh.fAnyOperationsAborted
         Return False
      Else
         ' Everything was ok
         canceled = False
         Return True
      End If
   End Function

   ' a private function that does most of the job

   Private Function Execute(ByVal sh As SHFILEOPSTRUCT) As Boolean
      ' set the hWnd
      sh.hwnd = m_hWnd
      ' ensure source file ends with an extra null char
      sh.pFrom &= ControlChars.NullChar

      If ProgressTitle <> "" Then
         ' allocate an ANSI string somewhere in memory and store its pointer here
         sh.lpszProgressTitle = Marshal.StringToHGlobalAnsi(ProgressTitle)
         sh.fFlags = m_Flags Or FileOpFlags.SimpleProgress
      Else
         ' else, ensure this flag isn't set
         sh.fFlags = m_Flags And Not FileOpFlags.SimpleProgress
      End If

      ' call the API function
      Dim res As Integer = SHFileOperation(sh)

      ' release any memory taken for the ProgressTitle string
      If sh.lpszProgressTitle.ToInt32() <> 0 Then
         Marshal.FreeHGlobal(sh.lpszProgressTitle)
         sh.lpszProgressTitle = IntPtr.Zero
      End If

      ' process the result
      If res <> 0 Then
         m_Canceled = sh.fAnyOperationsAborted
         Return False
      Else
         Return True
      End If
   End Function

End Class


<Flags()> _
Public Enum FileOpFlags As Short
   AllowUndo = &H40
   ConfirmMouse = &H2
   FilesOnly = &H80
   MultiDestFiles = &H1
   NoConfirmation = &H10
   NoConfirmMkDir = &H200
   RenameOnCollision = &H8
   Silent = &H4
   SimpleProgress = &H100
   WantMappingHandle = &H20
End Enum