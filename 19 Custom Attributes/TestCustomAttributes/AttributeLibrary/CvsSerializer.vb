Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions

Public Class CsvSerializer(Of T As New)
   Private type As Type
   Private separator As String
   Private attrList As New SortedDictionary(Of CsvFieldAttribute, MemberInfo)
   Private rePattern As String

   ' Constructors
   Sub New()
      Me.New(",")
   End Sub

   Sub New(ByVal separator As String)
      Me.type = GetType(T)
      Me.separator = separator
      BuildAttrList()
   End Sub

   ' Build the sorted list of (attribute, MemberInfo) pair.
   Private Sub BuildAttrList()
      ' Create the list of public members that are flagged with the
      ' CsvFieldAttribute, sorted on the attribute's Index property.
      For Each mi As MemberInfo In type.GetMembers()
         ' get the attribute associated with this member
         Dim attr As CsvFieldAttribute = DirectCast(Attribute.GetCustomAttribute(mi, GetType(CsvFieldAttribute)), CsvFieldAttribute)
         If attr IsNot Nothing Then
            ' Add to the list of attributes found so far, sorted on Index property.
            attrList.Add(attr, mi)
         End If
      Next

      ' Create the regex pattern and format string output pattern.
      Dim sb As New StringBuilder()
      Dim sep As String = ""

      For Each de As KeyValuePair(Of CsvFieldAttribute, MemberInfo) In attrList
         ' Add a separator to the pattern, but only from the 2nd iteration onward.
         If sb.Length > 0 Then sb.Append(separator)
         sb.Append(" *")

         ' Get attribute and Memberinfo for this item.
         Dim attr As CsvFieldAttribute = de.Key
         Dim mi As MemberInfo = de.Value

         ' Append to the regex for this element.
         If Not attr.Quoted Then
            sb.AppendFormat("(?<{0}>[^{1}]+)", mi.Name, separator)
         Else
            sb.AppendFormat("""(?<{0}>[^""]+)""", mi.Name)
         End If
         sb.Append(" *")
      Next
      ' Set the pattern.
      rePattern = sb.ToString()
   End Sub

   ' Deserialize a text file.
   Public Function Deserialize(ByVal fileName As String, Optional ByVal ignoreFieldHeader As Boolean = False) As T()
      Using reader As New StreamReader(fileName)
         Return Deserialize(reader, ignoreFieldHeader)
      End Using
   End Function

   ' Deserialize from a stream.
   Public Function Deserialize(ByVal reader As StreamReader, Optional ByVal ignoreFieldHeader As Boolean = False) As T()
      ' The result array
      Dim list As New List(Of T)
      ' Create a compiled Regex for best performance.
      Dim re As New Regex("^" & rePattern & "$", RegexOptions.Compiled)

      ' Skip the field header, if necessary.
      If ignoreFieldHeader Then reader.ReadLine()

      Do Until reader.Peek() = -1
         Dim text As String = reader.ReadLine()

         Dim m As Match = re.Match(text)
         If m.Success Then
            ' Create an instance of the target type.
            Dim obj As New T()
            ' Set individual properties
            For Each de As KeyValuePair(Of CsvFieldAttribute, MemberInfo) In attrList
               ' Get attribute and memberinfo.
               Dim attr As CsvFieldAttribute = de.Key
               Dim mi As MemberInfo = de.Value
               ' Retrieve the string value.
               Dim strValue As String = m.Groups(mi.Name).Value

               If TypeOf mi Is FieldInfo Then
                  Dim fi As FieldInfo = DirectCast(mi, FieldInfo)
                  Dim fldValue As Object = Convert.ChangeType(strValue, fi.FieldType)
                  fi.SetValue(obj, fldValue)
               ElseIf TypeOf mi Is PropertyInfo Then
                  Dim pi As PropertyInfo = DirectCast(mi, PropertyInfo)
                  Dim propValue As Object = Convert.ChangeType(strValue, pi.PropertyType)
                  pi.SetValue(obj, propValue, Nothing)
               End If
            Next
            ' Add this object to result.
            list.Add(obj)
         End If
      Loop

      ' Return the array of instances.
      Return list.ToArray()
   End Function

   ' Serialize to text file.
   Public Sub Serialize(ByVal fileName As String, ByVal col As ICollection(Of T))
      Using writer As New StreamWriter(fileName)
         Serialize(writer, col)
      End Using
   End Sub

   ' Serialize to a stream.
   Public Sub Serialize(ByVal writer As StreamWriter, ByVal col As ICollection(Of T))
      For Each obj As T In col
         ' This is the result string.
         Dim sb As New StringBuilder()

         For Each kvp As KeyValuePair(Of CsvFieldAttribute, MemberInfo) In attrList
            ' Append the separator (but not at the first element in the line)
            If sb.Length > 0 Then sb.Append(separator)

            ' Get attribute and memberinfo.
            Dim attr As CsvFieldAttribute = kvp.Key
            Dim mi As MemberInfo = kvp.Value

            ' Get the value of the field or property, as an Object.
            Dim fldValue As Object = Nothing
            If TypeOf mi Is FieldInfo Then
               fldValue = DirectCast(mi, FieldInfo).GetValue(obj)
            ElseIf TypeOf mi Is PropertyInfo Then
               fldValue = DirectCast(mi, PropertyInfo).GetValue(obj, Nothing)
            End If

            ' Get the format to be used with this field/property value.
            Dim format As String = "{0}"
            If attr.Format <> "" Then format = "{0:" & attr.Format & "}"
            If attr.Quoted Then format = """" & format & """"
            ' Call the ToString, with a format argument if specified.
            sb.AppendFormat(format, fldValue)
         Next
         ' Output to the stream.
         writer.WriteLine(sb.ToString)
      Next
   End Sub

End Class
