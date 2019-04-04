Imports System.Reflection

Module ReflectionHelpers

   ' Return the textual representation of an object's value in VB syntax.
   Function GetObjectValue(ByVal obj As Object) As String
      If obj Is Nothing Then
         Return "Nothing"
      ElseIf obj.GetType() Is GetType(String) Then
         Return """" & obj.ToString() & """"
      ElseIf obj.GetType() Is GetType(Date) Then
         Return "#" & obj.ToString() & "#"
      ElseIf obj.GetType().IsEnum Then
         ' It's an enum type
         Return obj.GetType().Name & "." & [Enum].GetName(obj.GetType(), obj)
      Else
         ' It's something else, including a number.
         Return obj.ToString()
      End If
   End Function

   ' Return the name of a type, discerning between generic and nongeneric types,
   ' type passed as arguments, array types, etc.
   Function GetTypeName_Old(ByVal type As Type) As String
      If type.IsGenericParameter Then
         Return type.Name
      Else
         Return type.FullName.Replace("[", "(").Replace("]", ")").Replace("&", "")
      End If
   End Function

   Function GetTypeName(ByVal type As Type) As String
      Dim typeName As String = Nothing
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
      ' Account for array types and byref types.
      typeName = typeName.Replace("[", "(").Replace("]", ")").Replace("&", "")
      Return typeName
   End Function

   ' Return a textual representation of a string, date, or numeric argument in an attribute.
   Function FormatTypedArgument(ByVal typedArg As CustomAttributeTypedArgument) As String
      If typedArg.ArgumentType Is GetType(String) Then
         ' It's a quoted string.
         Return """" & typedArg.Value.ToString() & """"
      ElseIf typedArg.ArgumentType Is GetType(Date) Then
         ' It's a Date constant.
         Return "#" & typedArg.Value.ToString() & "#"
      ElseIf typedArg.ArgumentType.IsEnum Then
         ' It's an enum value.
         Return typedArg.ArgumentType.Name & "." & _
            [Enum].GetName(typedArg.ArgumentType, typedArg.Value)
      Else
         ' It's something else (presumably a number).
         Return typedArg.Value.ToString()
      End If
   End Function

   ' Clone an object via reflection.
   Function CloneObject(Of T)(ByVal obj As T) As T
      If obj Is Nothing Then
         ' Cloning a null object is easy.
         Return Nothing
      ElseIf TypeOf CObj(obj) Is ICloneable Then
         ' Take advantage of the IClonable interface, if possible.
         Dim iclone As ICloneable = DirectCast(obj, ICloneable)
         Return CType(iclone.Clone(), T)
      Else
         ' Use reflection if everything else failed.
         ' (Throws if application doesn't have ReflectionPermission.)
         Dim mi As MethodInfo = obj.GetType().GetMethod("MemberwiseClone", _
            BindingFlags.ExactBinding Or BindingFlags.NonPublic Or BindingFlags.Instance)
         Return CType(mi.Invoke(obj, Nothing), T)
      End If
   End Function

End Module
