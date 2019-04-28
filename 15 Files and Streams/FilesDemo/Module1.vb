Imports Microsoft.VisualBasic.FileIO
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Security
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Text

Module Module1

    ' ------------------------------------------------------------------------------
    ' WARNING: code in this module uses literal file names for clarity. When run,
    ' most of these methods will throw a runtime exception. Please edit the code to
    ' match folder and file names on your system.
    ' ------------------------------------------------------------------------------

    Sub Main()
        'TestPathType()
        'TestDisplayDirTree()
        'TestGetFiles()
        'ReadWriteAll()
        'ReadAllLines()
        'ReadWriteAllBytes()
        'DirInfoFileInfo()
        'DriveInfoType()
        'TestACLs()
        'DirectoryFileSecurity()
        'CopyACLs()
        'CreateAccessRules()
        'DisplayAuditRules()
        'ReadTextFile()
        'ReadTextFile2()
        'StreamWriterType()
        'CopyAndConvertTextFile()
        'ReadWriteBinaryFiles()
        'ReadDelimitedFiles()
        'ReadFixedLengthFiles()
        'ReadTextFilesWithHeaders()
        'TestMemoryStream()
        'ReadWriteStrings()
        'StringWriterType()
        'SimpleCompression()
        'ChunkBasedCompression()
    End Sub

    Sub TestPathType()
        Console.WriteLine(Path.AltDirectorySeparatorChar)  ' => /
        Console.WriteLine(Path.DirectorySeparatorChar)     ' => \
        Console.WriteLine(Path.PathSeparator)              ' => ;
        Console.WriteLine(Path.VolumeSeparatorChar)        ' => :

        ' Note: the actual output from following methods includes unprintable characters.
        Console.WriteLine(Path.GetInvalidPathChars())      ' => <>|
        Console.WriteLine(Path.GetInvalidFileNameChars())  ' => <>|:*?\/

        Console.WriteLine(Path.GetTempPath)
        ' => C:\Documents and Settings\Francesco\Local Settings\Temp
        Console.WriteLine(Path.GetTempFileName)
        ' => C:\Documents and Settings\Francesco\Local Settings\Temp\tmp1FC7.tmp

        Dim file As String = "C:\MyApp\Bin\MyApp.exe"
        Console.WriteLine(Path.GetDirectoryName(file))            ' => C:\MyApp\Bin
        Console.WriteLine(Path.GetFileName(file))                 ' => MyApp.exe
        Console.WriteLine(Path.GetExtension(file))                ' => .exe
        Console.WriteLine(Path.GetFileNameWithoutExtension(file)) ' => MyApp
        Console.WriteLine(Path.GetPathRoot(file))                 ' => C:\
        Console.WriteLine(Path.HasExtension(file))                ' => True
        Console.WriteLine(Path.IsPathRooted(file))                ' => True

        ' Retrieve the Windows main directory (parent of Windows system directory)
        Console.WriteLine(Path.GetDirectoryName(Environment.SystemDirectory))

        ' Next line assumes that current directory is C:\MyApp.
        Console.WriteLine(Path.GetFullPath("MyApp.Exe"))         ' => C:\MyApp\MyApp.Exe

        Console.WriteLine(Path.ChangeExtension("MyApp.Exe", "dat"))  ' => MyApp.dat

        Console.WriteLine(Path.Combine("C:\MyApp", "MyApp.Dat"))    ' => C:\MyApp\MyApp.Dat
    End Sub

    Sub TestDisplayDirTree()
        DisplayDirTree(Environment.SystemDirectory, True)
    End Sub

    Sub TestGetFiles()

        Try
            ' Display all the *.txt files in C:\DOCS.
            For Each fname As String In Directory.GetFiles("c:\docs", "*.txt")
                Console.WriteLine(fname)
            Next

            ' Display only read-only .txt files in the c:\docs folder.
            For Each fname As String In Directory.GetFiles("c:\docs", "*.txt")
                If CBool(File.GetAttributes(fname) And FileAttributes.ReadOnly) Then
                    Console.WriteLine(fname)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("Error while accessing c:\docs")
        End Try

        For Each file As String In Directory.GetFiles("c:\windows", "*.dll", System.IO.SearchOption.AllDirectories)
            Console.WriteLine(file)
        Next

        ' Display system and hidden files in C:\.
        For Each fname As String In Directory.GetFiles("C:\")
            Dim attr As FileAttributes = File.GetAttributes(fname)
            ' Display the file if marked as hidden or system (or both).
            If CBool(attr And FileAttributes.Hidden) Or CBool(attr And FileAttributes.System) Then
                Console.WriteLine(fname)
            End If
        Next
    End Sub

    Sub ReadWriteAll()
        ' Read a text file, convert its contents to uppercase, and save it to another file.
        Dim text As String = File.ReadAllText("data.txt")
        File.WriteAllText("upper.txt", text.ToUpper())
    End Sub

    Sub ReadAllLines()
        ' Read the source file into an array of strings.
        Dim lines() As String = File.ReadAllLines("c:\source.txt")
        Dim count As Integer = 0
        ' Delete empty lines, by moving non-empty lines towards lower indices.
        For i As Integer = 0 To lines.Length - 1
            If lines(i).Trim.Length > 0 Then
                lines(count) = lines(i)
                count += 1
            End If
        Next
        ' Trim lines in excess and write to destination file.
        ReDim Preserve lines(count - 1)
        File.WriteAllLines("c:\dest.txt", lines)
    End Sub

    Sub ReadWriteAllBytes()
        ' Very simple encryption of a binary file
        Dim bytes() As Byte = File.ReadAllBytes("c:\source.dat")
        ' Flip every other bit in each byte.
        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = bytes(i) Xor CByte(&H55)
        Next
        ' Write it to a different file
        File.WriteAllBytes("c:\dest.dat", bytes)
    End Sub

    Sub DirInfoFileInfo()
        ' Create a DirectoryInfo object that points to C:\.
        Dim diRoot As New DirectoryInfo("c:\")
        ' Create a FileInfo object that points to c:\autoexec.bat.
        Dim fiAutoexec As New FileInfo("c:\autoexec.bat")

        ' List the directories in c:\.
        For Each di As DirectoryInfo In diRoot.GetDirectories()
            Console.WriteLine(di.Name)
        Next

        ' List all the *.txt files in c:\.
        For Each fi As FileInfo In diRoot.GetFiles("*.txt")
            Console.WriteLine(fi.Name)
        Next

        ' Show files and directories in one operation
        For Each fsi As FileSystemInfo In diRoot.GetFileSystemInfos()
            ' Use the [dir] or [file] prefix.
            Dim prefix As String = Nothing
            If CBool(fsi.Attributes And FileAttributes.Directory) Then
                prefix = "dir"
            Else
                prefix = "file"
            End If
            ' Print type, name and creation date.
            Console.WriteLine("[{0}] {1} – {2}", prefix, fsi.Name, fsi.CreationTime)
        Next

        ' List all empty files in c:\.
        For Each fi As FileInfo In diRoot.GetFiles()
            If fi.Length = 0 Then Console.WriteLine(fi.Name)
        Next

        ' Encrypt all the writable files in the c:\private directory.
        Dim diPrivate As New DirectoryInfo("c:\private")
        For Each fi As FileInfo In diPrivate.GetFiles()
            If Not fi.IsReadOnly Then fi.Encrypt()
        Next
    End Sub

    Sub DriveInfoType()
        ' Display the volume label of drive C.
        Dim driveC As New DriveInfo("c:")
        Console.WriteLine("Label of C: drive: {0}", driveC.VolumeLabel)

        ' Display name and total size of all available drives.
        For Each di As DriveInfo In DriveInfo.GetDrives()
            If di.IsReady Then
                Console.WriteLine("Drive {0}: {1:N} bytes", di.Name, di.TotalSize)
            End If
        Next
        Console.WriteLine()

        ' Display information of all drives
        Console.WriteLine("{0,-6}{1,-10}{2,-8}{3,-16}{4,18}{5,18}",
           "Name", "Label", "Type", "Format", "TotalSize", "TotalFreeSpace")
        Console.WriteLine(New String("-"c, 78))
        For Each di As DriveInfo In DriveInfo.GetDrives()
            If di.IsReady Then
                Console.WriteLine("{0,-6}{1,-10}{2,-8}{3,-16}{4,18:N0}{5,18:N0}",
                   di.Name, di.VolumeLabel, di.DriveType.ToString, di.DriveFormat,
                   di.TotalSize, di.TotalFreeSpace)
            Else
                Console.WriteLine("{0,-6}(not ready)", di.Name)
            End If
        Next
    End Sub

    '-------------------------------------------------------
    ' Access Control Lists
    '-------------------------------------------------------

    Sub TestACLs()
        Dim nta As New NTAccount("BUILTIN\Administrators")
        Dim sia As SecurityIdentifier = DirectCast(nta.Translate(GetType(SecurityIdentifier)), SecurityIdentifier)
        Console.WriteLine("Name={0}, SID={1}", nta.Value, sia.Value)
        ' => Name=BUILTIN\Administrators, SID=S-1-5-32-544

        Dim isSameAccount As Boolean = (nta = sia)              ' => False
        Console.WriteLine(isSameAccount)
        isSameAccount = (nta.Translate(GetType(SecurityIdentifier)) = sia)  ' => True
        Console.WriteLine(isSameAccount)

        ' Create the SecurityIdentifier corresponding to the Administrators group.
        ' (2nd argument must be non-Nothing for some kinds of well-known SIDs.)
        Dim sia2 As New SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, Nothing)
        Console.WriteLine(sia2.Value)                   ' => S-1-5-32-544"
        Dim nta2 As NTAccount = DirectCast(sia2.Translate(GetType(NTAccount)), NTAccount)
        Console.WriteLine(nta2.Value)                   ' => BUILTIN\Administrators

        ' Here's another way to get a reference to the same account.
        sia2 = New SecurityIdentifier("S-1-5-32-544")

        ' the account of current user
        Dim siUser As SecurityIdentifier = WindowsIdentity.GetCurrent().User
        Console.WriteLine(siUser.Value)

        ' Create the WindowsPrincipal corresponding to current user.
        Dim wp As New WindowsPrincipal(WindowsIdentity.GetCurrent())
        ' Create the SecurityIdentifier for the BUILTIN\Administrator group.
        Dim siAdmin As New SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, Nothing)
        ' Check whether the current user is an administrator.
        Console.WriteLine("Is a power user = {0}", wp.IsInRole(siAdmin))
    End Sub

    Sub DirectoryFileSecurity()
        Dim dirName As String = "c:\windows"
        Dim fileName As String = "c:\test.txt"

        ' Retrieve only access information related to the folder.
        Dim dirSec As New DirectorySecurity(dirName, AccessControlSections.Access)
        ' Retrieve all security information related to the file.
        Dim fileSec As New FileSecurity(fileName, AccessControlSections.All)

        ' (This code is equivalent to previous snippet.)
        dirSec = Directory.GetAccessControl(dirName, AccessControlSections.Access)
        fileSec = File.GetAccessControl(fileName, AccessControlSections.All)

        ' Get access-related security information for the c:\test.txt file.
        Console.WriteLine(fileSec.GetSecurityDescriptorSddlForm(AccessControlSections.Access))
        ' => D:AI(D;;DCLCRPCR;;;SY)(A;ID;FA;;;BA)......

        ' Get the owner of the c:\test.doc as an NTAccount object.
        Dim nta3 As NTAccount = DirectCast(fileSec.GetOwner(GetType(NTAccount)), NTAccount)
        ' Get the primary group of the owner of c:\test.doc as a SecurityIdentifier object.
        Dim sia3 As SecurityIdentifier = DirectCast(fileSec.GetGroup(
           GetType(SecurityIdentifier)), SecurityIdentifier)
        Console.WriteLine()

        ' Display the header of the result table.
        Console.WriteLine("{0,-25}{1,-30}{2,-8}{3,-6}", "User", "Rights", "Access", "Inherited")
        Console.WriteLine(New String("-"c, 72))
        ' 1st argument tells whether to include access rules explicitly set for the object
        ' 2nd argument tells whether to include inherited rules.
        For Each fsar As FileSystemAccessRule In fileSec.GetAccessRules(True, True,
               GetType(NTAccount))
            Console.WriteLine("{0,-25}{1,-30}{2,-8}{3,-6}", fsar.IdentityReference.Value,
               fsar.FileSystemRights, fsar.AccessControlType, fsar.IsInherited)
        Next
    End Sub

    Sub CopyACLs()
        Dim sourceFile As String = "c:\test.txt"
        Dim destFile As String = "c:\tryme2.txt"

        ' Retrieve all security information related to the file.
        Dim fileSec As New FileSecurity(sourceFile, AccessControlSections.All)

        ' Create a copy of the all permissions associated with c:\test.doc.
        ' (You can also copy just the access permissions, for example.)
        Dim sddl As String = fileSec.GetSecurityDescriptorSddlForm(AccessControlSections.All)
        Dim fileSec2 As New FileSecurity
        fileSec2.SetSecurityDescriptorSddlForm(sddl)
        ' Enforce these permissions on the target file.
        File.SetAccessControl(destFile, fileSec2)
    End Sub

    Sub CreateAccessRules()
        Dim fileName As String = "c:\test.txt"

        ' Create an access rule that grants full control to administrators.
        Dim ntAcc1 As New NTAccount("BUILTIN\Administrators")
        Dim fsar1 As New FileSystemAccessRule(ntAcc1, FileSystemRights.FullControl, AccessControlType.Allow)
        ' Create another access rule that denies write permissions to ASPNET user.
        Dim ntAcc2 As New NTAccount("DELLNB\ASPNET")
        Dim fsar2 As New FileSystemAccessRule(ntAcc2, FileSystemRights.Write, AccessControlType.Deny)
        ' Create a FileSecurity object that contains these two access rules.
        Dim fsec As New FileSecurity
        fsec.AddAccessRule(fsar1)
        fsec.AddAccessRule(fsar2)
        ' Assign these permissions to the c:\tryme2.txt file.
        File.SetAccessControl(fileName, fsec)
    End Sub

    Sub DisplayAuditRules()
        Dim fileName As String = "c:\test.txt"
        Dim fsec As New FileSecurity(fileName, AccessControlSections.All)

        Console.WriteLine("{0,-25}{1,-30}{2,-8}{3,-6}", "User", "Rights", "Outcome", "Inherited")
        Console.WriteLine(New String("-"c, 72))
        For Each fsar As FileSystemAuditRule In fsec.GetAuditRules(True, True, GetType(NTAccount))
            Console.WriteLine("{0,-25}{1,-30}{2,-8}{3,-6}", fsar.IdentityReference.Value,
               fsar.FileSystemRights, fsar.AuditFlags, fsar.IsInherited)
        Next
    End Sub

    '-------------------------------------------------------
    ' Stream readers and writers
    '-------------------------------------------------------

    Sub StreamReaderType()
        ' With the File.OpenText static method
        Dim fileName As String = "c:\test.txt"
        Dim sr As StreamReader = File.OpenText(fileName)

        ' With the OpenText instance method of a FileInfo object
        Dim fi2 As New FileInfo(fileName)
        Dim sr2 As StreamReader = fi2.OpenText

        ' By passing a FileStream from the Open method of the File class to
        ' the StreamReader's constructor method
        ' (This technique lets you specify mode, access, and share mode.)
        Dim st3 As Stream = File.Open(fileName,
           FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
        Dim sr3 As New StreamReader(st3)

        ' By opening a FileStream on the file and then passing it
        ' to the StreamReader's constructor method
        Dim fs4 As New FileStream(fileName, FileMode.Open)
        Dim sr4 As New StreamReader(fs4)

        ' By getting a FileStream from the OpenRead method of the File class
        ' and passing it to the StreamReader's constructor
        Dim sr5 As New StreamReader(File.OpenRead(fileName))

        ' By passing the filename to the StreamReader's constructor
        Dim sr6 As New StreamReader(fileName)

        ' By passing the filename and encoding
        Dim sr7 As New StreamReader("c:\autoexec.bat", System.Text.Encoding.Unicode)
        Dim sr8 As New StreamReader(fileName, System.Text.Encoding.ASCII)

        ' As before, but we let the system decide the best encoding.
        Dim sr9 As New StreamReader(fileName, True)

        ' Create a file for sequential reading and writing, with a 2K buffer;
        ' The file will be deleted when closed.
        Dim fs10 As New FileStream("c:\tryme.tmp", FileMode.CreateNew, FileAccess.ReadWrite,
           FileShare.Read, 2048, FileOptions.SequentialScan Or FileOptions.DeleteOnClose)
    End Sub

    Sub ReadTextFile()
        Dim fileName As String = "c:\test.txt"

        ' Display all the text lines in the c:\test.txt file.
        Dim sr As New StreamReader(fileName)
        Do Until sr.Peek = -1
            Console.WriteLine(sr.ReadLine())
        Loop
        sr.Close()
    End Sub

    Sub ReadTextFile2()
        Dim fileName As String = "c:\test.txt"

        Using sr As New StreamReader(fileName)
            Do Until sr.EndOfStream
                Console.WriteLine(sr.ReadLine())
            Loop
        End Using
    End Sub

    Sub ReadMethod()
        Dim fileName As String = "c:\test.txt"

        ' Read the entire contents of C:\test.doc in one shot.
        Dim sr As New StreamReader(fileName)
        Dim fileContents As String = sr.ReadToEnd()

        ' If the file is longer than 100 chars, process it again, one character at a
        ' time (admittedly a silly thing to do, but it's just a demo).
        If fileContents.Length >= 100 Then
            ' Reset the stream's pointer to the beginning.
            sr.BaseStream.Seek(0, SeekOrigin.Begin)
            ' Read individual characters until EOF is reached.
            Do Until sr.EndOfStream
                ' Read method returns an integer, so convert it to Char.
                Console.Write(sr.Read().ToString())
            Loop
        End If
        sr.Close()
    End Sub

    Sub StreamWriterType()
        ' By means of the CreateText static method of the File type
        Dim fileName As String = "c:\text.dat"
        Dim sw1 As StreamWriter = File.CreateText(fileName)

        ' By passing a FileStream from the Open method of the File class to
        ' the StreamWriter's constructor method
        Dim st2 As Stream = File.Open(fileName,
           FileMode.Create, FileAccess.ReadWrite, FileShare.None)
        Dim sw2 As New StreamWriter(st2)

        ' By opening a FileStream on the file and then passing it
        ' to the StreamWriter's constructor
        Dim fs3 As New FileStream(fileName, FileMode.Open)
        Dim sw3 As New StreamWriter(fs3)

        ' By getting a FileStream from the OpenWrite method of the File type
        ' and passing it to the StreamWriter's constructor
        Dim sw4 As New StreamWriter(File.OpenWrite(fileName))

        ' By passing the filename to the StreamWriter's constructor
        Dim sw5 As New StreamWriter(fileName)

        ' Open the c:\test.dat file in append mode, be prepared to output
        ' ASCII characters, and use a 2K buffer.
        Dim sw6 As New StreamWriter("c:\test.new", True, Encoding.ASCII, 2024)
        ' Terminate each line with a null character followed by a newline character.
        sw6.NewLine = ControlChars.NullChar & ControlChars.NewLine
    End Sub

    Sub CopyAndConvertTextFile()
        ' Technique 1
        Using sr As New StreamReader("c:\test.txt")
            Using sw As New StreamWriter("c:\test.new")
                Do Until sr.EndOfStream
                    sw.WriteLine(sr.ReadLine.ToUpper())
                Loop
            End Using     ' This actually writes data to the file and closes it.
        End Using

        ' Technique 2 (for small files)
        Using sr As New StreamReader("c:\test.txt"), sw As New StreamWriter("c:\test.new")
            sw.WriteLine(sr.ReadToEnd().ToUpper())
        End Using
    End Sub

    Sub ReadWriteBinaryFiles()
        Dim fileName As String = "c:\values.dat"

        ' Associate a stream with a new file opened with write access.
        Dim st As Stream = File.Open(fileName, FileMode.Create, FileAccess.Write)
        ' Create a BinaryWriter associated with the output stream.
        Dim bw As New BinaryWriter(st)

        ' Save 10 Double values to the file.
        Dim rand As New Random()
        For i As Integer = 1 To 10
            bw.Write(rand.NextDouble())
        Next
        ' Flush the output data to the file.
        bw.Close()

        ' Read back values written in previous code.

        ' Associate a stream with an existing file, opened with read access.
        Dim st2 As Stream = File.Open(fileName, FileMode.Open, FileAccess.Read)
        ' Create a BinaryReader associated with the input stream.
        Using br2 As New BinaryReader(st2)
            ' Loop until data is available.
            Do Until br2.PeekChar() = -1
                ' Read the next element. (We know it's a Double.)
                Console.WriteLine(br2.ReadDouble())
            Loop
            ' Next statement closes both the BinaryReader and the underlying stream.
        End Using

    End Sub

    '-------------------------------------------------------
    ' Stream readers and writers
    '-------------------------------------------------------

    Sub ReadDelimitedFiles()
        Dim fileName As String = "data.txt"

        Dim parser As New TextFieldParser(fileName, Encoding.Default)
        ' Field separator can be either a comma or a semicolon.
        parser.Delimiters = New String() {",", ";"}
        parser.TrimWhiteSpace = True

        Do Until parser.EndOfData
            Dim fields() As String = parser.ReadFields()
            ' Process each field in current record here.
            Console.WriteLine("First={0}, Last={1}, City={2}", fields(0), fields(1), fields(2))
        Loop
        parser.Close()
    End Sub

    Sub ReadFixedLengthFiles()
        Using parser As New TextFieldParser("data2.txt", Encoding.Default)
            parser.TextFieldType = FieldType.FixedWidth
            parser.FieldWidths = New Integer() {8, 10, 6}
            Do Until parser.EndOfData
                Dim fields() As String = parser.ReadFields()
                Console.WriteLine("First={0}, Last={1}, City={2}", fields(0), fields(1), fields(2))
            Loop
        End Using
    End Sub

    Sub ReadTextFilesWithHeaders()
        Using parser As New TextFieldParser("data3.txt", Encoding.Default)
            parser.TextFieldType = FieldType.FixedWidth
            Dim headerWidths() As Integer = {3, 4, 11, 12}
            Dim detailWidths() As Integer = {3, 6, 18, 6}
            parser.FieldWidths = headerWidths

            Do Until parser.EndOfData
                Dim code As String = parser.PeekChars(2)
                If code = "IH" Then
                    parser.FieldWidths = headerWidths
                    Dim fields() As String = parser.ReadFields()
                    Console.WriteLine("Invoice #{0}, Date={1}, Customer={2}", fields(1), fields(2), fields(3))
                ElseIf code = "ID" Then
                    parser.FieldWidths = detailWidths
                    Dim fields() As String = parser.ReadFields()
                    Console.WriteLine("  #{0} {1} at ${2} each", fields(1), fields(2), fields(3))
                Else
                    Throw New MalformedLineException("Invalid record code")
                End If
            Loop
        End Using
    End Sub

    Sub TestMemoryStream()
        ' Create a memory stream with initial capacity of 1 KB.
        Dim st As New MemoryStream(1024)
        Dim bw As New BinaryWriter(st)
        Dim rand As New Random()
        ' Write 10 random Double values to the stream.
        For i As Integer = 1 To 10
            bw.Write(rand.NextDouble())
        Next

        ' Rewind the stream to the beginning and read back the data.
        st.Seek(0, SeekOrigin.Begin)
        Dim br As New BinaryReader(st)
        Do Until br.PeekChar = -1
            Console.WriteLine(br.ReadDouble())
        Loop
        bw.Close()
        br.Close()
        st.Close()
    End Sub

    Sub ReadWriteStrings()
        Dim st As New MemoryStream(1000)
        Dim bw As New BinaryWriter(st)
        ' The BinaryWriter.Write method outputs a length-prefixed string.
        bw.Write("a length-prefixed string")
        ' We'll use this 1-KB buffer for both reading and writing.
        Dim buffer(1023) As Char

        Dim s As String = "13 Characters"           ' A fixed-length string
        s.CopyTo(0, buffer, 0, s.Length)            ' Copy into the buffer.
        bw.Write(buffer, 0, s.Length)               ' Output first 13 chars in buffer.
        bw.Write(buffer, 0, s.Length)               ' Do it a second time.

        ' Rewind the stream, and prepare to read from it.
        st.Seek(0, SeekOrigin.Begin)
        Dim br As New BinaryReader(st)
        ' Reading the length-prefixed string is simple.
        Console.WriteLine(br.ReadString())          ' => a length-prefixed string

        ' Read the fixed-length string (13 characters) into the buffer.
        br.Read(buffer, 0, 13)
        s = New String(buffer, 0, 13)               ' Convert to a string.
        Console.WriteLine(s)                        ' => 13 Characters

        ' Another way to read a fixed-length string (13 characters)
        ' (ReadChars returns a Char array that we can pass to the string constructor.)
        s = New String(br.ReadChars(13))
        Console.WriteLine(s)                        ' => 13 Characters
    End Sub

    Sub StringWriterType()
        ' Create a string with the space-separated abbreviated names of weekdays.
        Dim sb As New StringBuilder()
        ' The StringWriter associated with the StringBuilder
        Dim strWriter As New StringWriter(sb)

        ' Output day names to the string.
        For Each d As String In DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames
            strWriter.Write(d)
            strWriter.Write(" ")        ' Append a space.
        Next
        Console.WriteLine(sb)           ' => Sun Mon Tue Wed Thu Fri Sat
    End Sub

    Sub SimpleCompression()
        Dim uncompressedFile As String = "test.txt"
        Dim compressedFile As String = "test.zip"
        ' Read the source (uncompressed) file in the buffer.
        Dim buffer() As Byte = File.ReadAllBytes(uncompressedFile)
        ' Open the destination (compressed) file with a FileStream object.
        Dim outStream As New FileStream(compressedFile, FileMode.Create)
        ' Wrap a DeflateStream object around the output stream.
        Dim zipStream As New DeflateStream(outStream, CompressionMode.Compress)
        ' Write the contents of the buffer.
        zipStream.Write(buffer, 0, buffer.Length)
        ' Flush compressed data and close all output streams.
        zipStream.Flush()
        zipStream.Close()
        outStream.Close()
    End Sub

    Sub ChunkBasedCompression()
        CompressFile("data.txt", "data.zip")
        UncompressFile("data.zip", "data.new")

    End Sub

End Module
