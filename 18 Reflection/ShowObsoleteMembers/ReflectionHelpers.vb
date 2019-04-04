Imports System.Reflection

Module ReflectionHelpers

   ' Returns the name of a type. (Supports generics and array types.)
   Function GetTypeName(ByVal type As Type) As String
      Dim typeName As String = Nothing
      Dim suffix As String = ""

      ' Account for array types.
      If type.IsArray Then
         suffix = "()"
         type = type.GetElementType()
      End If
      ' Account for byref types
      If type.IsByRef Then type = type.GetElementType()

      If type.IsGenericTypeDefinition Then
         ' It's the type definition of an "open" generic type.
         typeName = type.FullName
         typeName = typeName.Remove(typeName.IndexOf("`"c)) & "(Of "
         For Each targ As Type In type.GetGenericArguments()
            If targ.GenericParameterPosition > 0 Then typeName &= ","
            typeName &= targ.Name
         Next
         typeName &= ")"
      ElseIf type.IsGenericParameter Then
         ' It's a parameter in an Of clause.
         typeName = type.Name
      ElseIf type.IsGenericType Then
         ' This is a generic type that has been bound to specific types.
         typeName = type.GetGenericTypeDefinition.FullName
         typeName = typeName.Remove(typeName.IndexOf("`"c)) & "(Of "
         Dim sep As String = ""
         For Each argType As Type In type.GetGenericArguments
            typeName &= sep & GetTypeName(argType)
            sep = ", "
         Next
         typeName &= ")"
      Else
         ' This is a regular type.
         typeName = type.FullName
      End If
      Return typeName & suffix
   End Function

   ' Return the name of a member. (Recognizes constructors and generic methods.)
   Public Function GetMemberName(ByVal mi As MemberInfo) As String
      Dim memberName As String = mi.Name

      Select Case mi.MemberType
         Case MemberTypes.Constructor
            memberName = "New"
         Case MemberTypes.Method
            ' Account for generic methods.
            Dim method As MethodInfo = DirectCast(mi, MethodInfo)
            If method.IsGenericMethodDefinition() Then
               ' Include all type arguments.
               memberName &= "(Of "
               For Each ty As Type In method.GetGenericArguments()
                  If ty.GenericParameterPosition > 0 Then memberName &= ","
                  memberName &= ty.Name
               Next
               memberName &= ")"
            End If
      End Select
      Return memberName
   End Function

   ' Returns the syntax of a member
   Public Function GetMemberSyntax(ByVal member As MemberInfo) As String
      Dim memberSyntax As String = GetMemberName(member)

      Select Case member.MemberType
         Case MemberTypes.Property
            Dim pi As PropertyInfo = DirectCast(member, PropertyInfo)
            memberSyntax &= GetParametersSyntax(pi.GetGetMethod(True).GetParameters()) _
               & " As " & GetTypeName(pi.PropertyType)
         Case MemberTypes.Method
            Dim mi As MethodInfo = DirectCast(member, MethodInfo)
            memberSyntax = memberSyntax & GetParametersSyntax(mi.GetParameters())
            If mi.ReturnType.FullName <> "System.Void" Then
               memberSyntax &= " As " & GetTypeName(mi.ReturnType)
            End If
         Case MemberTypes.Constructor
            Dim ci As ConstructorInfo = DirectCast(member, ConstructorInfo)
            memberSyntax &= memberSyntax & GetParametersSyntax(ci.GetParameters)
         Case MemberTypes.Event
            Dim ei As EventInfo = DirectCast(member, EventInfo)
            Dim mi As MethodInfo = ei.EventHandlerType.GetMethod("Invoke")
            memberSyntax &= GetParametersSyntax(mi.GetParameters())
      End Select
      Return memberSyntax
   End Function

   ' Returns the syntax of an array of parameters.
   Private Function GetParametersSyntax(ByVal parInfos() As ParameterInfo) As String
      Dim paramSyntax As String = "("
      Dim sep As String = ""
      For Each pi As ParameterInfo In parInfos
         paramSyntax &= sep & GetTypeName(pi.ParameterType)
         sep = ", "
      Next
      Return paramSyntax & ")"
   End Function




End Module
