Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Module MainModule
   ' Modify this value to output html or xml text.
   Public OUTPUT_FORMAT As String = "HTML"    ' can be "TEXT", "HTML" or "XML"

   Sub Main(ByVal args() As String)
      If OUTPUT_FORMAT = "XML" Then Console.WriteLine("<OBSOLETEMEMBERS>")
      If args.Length = 0 Then
         ShowObsoleteMembers()
      Else
         ShowObsoleteMembers(args(0))
      End If
      If OUTPUT_FORMAT = "XML" Then Console.WriteLine("</OBSOLETEMEMBERS>")
   End Sub

   ' Process all the assemblies in the .NET Framework directory.
   Sub ShowObsoleteMembers()
      Dim path As String = RuntimeEnvironment.GetRuntimeDirectory()
      For Each asmFile As String In Directory.GetFiles(path, "*.dll")
         'If asmFile.Contains("Microsoft.ReportViewer") Then Continue For
         ShowObsoleteMembers(asmFile)
      Next
   End Sub

   ' Process an assembly at the specified file path.
   Sub ShowObsoleteMembers(ByVal asmFile As String)
      Try
         Dim asm As Assembly = Assembly.LoadFrom(asmFile)
         If OUTPUT_FORMAT = "TEXT" Then
            ShowObsoleteMembers(asm)
         ElseIf OUTPUT_FORMAT = "HTML" Then
            ShowObsoleteMembersHTML(asm)
         ElseIf OUTPUT_FORMAT = "XML" Then
            ShowObsoleteMembersXML(asm)
         End If
      Catch ex As Exception
         ' The file isn't a valid assembly.
      End Try
   End Sub

   ' Process all the types and members in an assembly.
   Sub ShowObsoleteMembers(ByVal asm As Assembly)
      Dim attrType As Type = GetType(ObsoleteAttribute)

      ' This header is displayed only if this assembly contains obsolete members.
      Dim asmHeader As String = String.Format("ASSEMBLY {0}{1}", _
         asm.GetName().Name, ControlChars.CrLf)

      For Each type As Type In asm.GetTypes()
         ' This header will be displayed only if the type is obsolete or 
         ' contains obsolete members.
         Dim typeHeader As String = String.Format("   TYPE {0}{1}", _
            GetTypeName(type), ControlChars.CrLf)

         ' Search the Obsolete attribute at the type level.
         Dim attr As ObsoleteAttribute = DirectCast( _
            Attribute.GetCustomAttribute(type, attrType), ObsoleteAttribute)
         If attr IsNot Nothing Then
            ' This type is obsolete.
            Console.Write(asmHeader & typeHeader)
            ' Display the message attached to the attribute.
            Dim message As String = "WARNING"
            If attr.IsError Then message = "ERROR"
            Console.WriteLine("      {0}: {1}", message, attr.Message)

            ' Don't display the assembly header again.
            asmHeader = ""
         Else
            ' The type isn't obsolete, let's search for obsolete members.
            For Each mi As MemberInfo In type.GetMembers()
               attr = DirectCast(Attribute.GetCustomAttribute(mi, _
                  attrType), ObsoleteAttribute)
               If attr IsNot Nothing Then
                  ' This member is obsolete.
                  Dim memberHeader As String = String.Format("      {0} {1}", _
                     mi.MemberType.ToString().ToUpper(), GetMemberSyntax(mi))
                  Console.WriteLine(asmHeader & typeHeader & memberHeader)
                  ' Check whether using the member causes a warning or an 
                  ' error, and display the message.
                  Dim message As String = "WARNING"
                  If attr.IsError Then message = "ERROR"
                  Console.WriteLine("            {0}: {1}", message, attr.Message)
                  ' Don't display the assembly and the type header again.
                  asmHeader = ""
                  typeHeader = ""
               End If
            Next
         End If
      Next
   End Sub

   Sub ShowObsoleteMembersHTML(ByVal asm As Assembly)
      Dim attrType As Type = GetType(ObsoleteAttribute)

      ' This header is displayed only if this assembly contains obsolete members.
      Dim asmHeader As String = String.Format("<H1>ASSEMBLY {0}</H1>{1}", _
         asm.GetName().Name, ControlChars.CrLf)

      For Each type As Type In asm.GetTypes()
         ' This header will be displayed only if the type is obsolete or 
         ' contains obsolete members.
         Dim typeHeader As String = String.Format("<H2>TYPE {0}</H2>{1}", _
            GetTypeName(type), ControlChars.CrLf)

         ' Search the Obsolete attribute at the type level.
         Dim attr As ObsoleteAttribute = DirectCast( _
            Attribute.GetCustomAttribute(type, attrType), ObsoleteAttribute)
         If attr IsNot Nothing Then
            ' This type is obsolete.
            Console.Write(asmHeader & typeHeader)
            ' Display the message attached to the attribute.
            Dim message As String = "WARNING"
            If attr.IsError Then message = "ERROR"
            Console.WriteLine("      {0}: {1}", message, attr.Message)
            ' Don't display the assembly header again.
            asmHeader = ""
         Else
            ' The type isn't obsolete, let's search for obsolete members.
            For Each mi As MemberInfo In type.GetMembers()
               attr = DirectCast(Attribute.GetCustomAttribute(mi, _
                  attrType), ObsoleteAttribute)
               If attr IsNot Nothing Then
                  ' This member is obsolete.
                  Dim memberHeader As String = String.Format("<H3>{0} {1}</H3>", _
                     mi.MemberType.ToString().ToUpper(), GetMemberSyntax(mi))
                  Console.WriteLine(asmHeader & typeHeader & memberHeader)
                  ' Check whether using the member causes a warning or an 
                  ' error, and display the message.
                  Dim message As String = "WARNING"
                  If attr.IsError Then message = "ERROR"
                  Console.WriteLine("<P>{0}: {1}</P>", message, _
                     ConvertToHtml(attr.Message))
                  ' Don't display the assembly and the type header again.
                  asmHeader = ""
                  typeHeader = ""
               End If
            Next
         End If
      Next
   End Sub

   Sub ShowObsoleteMembersXML(ByVal asm As Assembly)
      Dim attrType As Type = GetType(ObsoleteAttribute)

      ' This header is displayed only if this assembly contains obsolete members.
      Dim asmHeader As String = String.Format("<ASSEMBLY name='{0}'>{1}", _
         asm.GetName().Name, ControlChars.CrLf)

      For Each type As Type In asm.GetTypes()
         ' This header will be displayed only if the type is obsolete or 
         ' contains obsolete members.
         Dim typeHeader As String = String.Format("<TYPE name='{0}'>{1}", _
            GetTypeName(type), ControlChars.CrLf)

         ' Search the Obsolete attribute at the type level.
         Dim attr As ObsoleteAttribute = DirectCast( _
            Attribute.GetCustomAttribute(type, attrType), ObsoleteAttribute)
         If attr IsNot Nothing Then
            ' This type is obsolete.
            Console.Write(asmHeader & typeHeader)
            ' Display the message attached to the attribute.
            Dim message As String = "WARNING"
            If attr.IsError Then message = "ERROR"
            Console.WriteLine("<MESSAGE kind='{0}'>", message)
            Console.WriteLine(ConvertToHtml(attr.Message))
            Console.WriteLine("</MESSAGE>")
            ' Don't display the assembly and type header again.
            asmHeader = ""
            typeHeader = ""
         Else
            ' The type isn't obsolete, let's search for obsolete members.
            For Each mi As MemberInfo In type.GetMembers()
               attr = DirectCast(Attribute.GetCustomAttribute(mi, _
                  attrType), ObsoleteAttribute)
               If attr IsNot Nothing Then
                  ' This member is obsolete.
                  Dim memberHeader As String = String.Format("<MEMBER kind='{0}' name='{1}'>", _
                     mi.MemberType.ToString().ToUpper(), GetMemberSyntax(mi))
                  Console.WriteLine(asmHeader & typeHeader & memberHeader)
                  ' Check whether using the member causes a warning or an 
                  ' error, and display the message.
                  Dim message As String = "WARNING"
                  If attr.IsError Then message = "ERROR"
                  Console.WriteLine("<MESSAGE kind='{0}'>", message)
                  Console.WriteLine(ConvertToHtml(attr.Message))
                  Console.WriteLine("</MESSAGE>")
                  Console.WriteLine("</MEMBER>")
                  ' Don't display the assembly and the type header again.
                  asmHeader = ""
                  typeHeader = ""
               End If
            Next
         End If
         ' Append the </TYPE> tag, if necessary.
         If typeHeader.Length = 0 Then Console.WriteLine("</TYPE>")
      Next
      ' Append the </ASSEMBLY> tag, if necessary.
      If asmHeader.Length = 0 Then Console.WriteLine("</ASSEMBLY>")
   End Sub

   Private Function ConvertToHtml(ByVal text As String) As String
      text = text.Replace("&", "&amp;")
      text = text.Replace("<", "&lt;").Replace(">", "&gt;")
      Return text
   End Function


End Module
