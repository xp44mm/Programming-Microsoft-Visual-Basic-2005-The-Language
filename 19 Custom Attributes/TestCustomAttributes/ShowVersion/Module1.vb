Imports System.Reflection
Imports AttributeLibrary

Module Module1

   Sub Main(ByVal args() As String)
      ' args = New String() {"D:\Books\Programming VBNET 2005\Code\18 Custom Attributes\TestApplication\bin\TestApplication.exe"}

      ' Read the assembly whose path is passed as an argument; throws an exception if not found.
      Dim asm As [Assembly] = [Assembly].LoadFile(args(0))
      ' Display the header.
      Console.WriteLine("{0,-40}{1,-12}{2,-10}{3,-6}", "Member", "Author", "Version", "Tested")
      Console.WriteLine(New String("-"c, 68))

      ' Iterate over all public and private types.
      For Each type As Type In asm.GetTypes()
         ' Extract the attribute associated with the type.
         Dim attr As VersionAttribute
         attr = DirectCast(Attribute.GetCustomAttribute(type, GetType(VersionAttribute)), VersionAttribute)
         If attr IsNot Nothing Then
            Console.WriteLine("{0,-40}{1,-12}{2,-10}{3,-6}", type.FullName, attr.Author, attr.Version, attr.Tested)
         End If

         ' Iterate over all public and private members.
         For Each mi As MemberInfo In type.GetMembers(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Static)
            ' Extract the attribute associated with each member
            attr = DirectCast(Attribute.GetCustomAttribute(mi, GetType(VersionAttribute)), VersionAttribute)
            If attr IsNot Nothing Then
               Console.WriteLine("    {0,-36}{1,-12}{2,-10}{3,-6}", mi.Name, attr.Author, attr.Version, attr.Tested)
            End If
         Next
      Next

   End Sub

End Module
