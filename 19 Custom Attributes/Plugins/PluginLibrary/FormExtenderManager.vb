Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class FormExtenderManager

   ' All the FormExtenders known to this manager
   Private Shared extenders As Dictionary(Of String, FormExtenderInfo)

   ' Private constructor to prevent instantiation

   Private Sub New()
   End Sub

   ' Initialize the list of form extenders when the type is referenced.

   Public Shared Sub InitializePlugIns()
      Dim dirName As String = Path.GetDirectoryName(Application.ExecutablePath) ' & "\PlugIns"
      InitializePlugIns(dirName)
   End Sub

   ' Create the list of form extenders.

   Public Shared Sub InitializePlugIns(ByVal dirName As String)
      extenders = New Dictionary(Of String, FormExtenderInfo)
      ' Visit all the DLLs in this directory.
      For Each dllName As String In Directory.GetFiles(dirName, "*.dll")
         Try
            ' Attempt to load this assembly.
            Dim asm As [Assembly] = [Assembly].LoadFile(dllName)
            ParseAssembly(asm)
         Catch ex As Exception
            ' Ignore DLLs that aren't assemblies.
         End Try
      Next
   End Sub

   ' Parse an assembly.

   Private Shared Sub ParseAssembly(ByVal asm As Assembly)
      Dim attrType As Type = GetType(FormExtenderAttribute)
      ' Check all the types in the assembly.
      For Each type As Type In asm.GetTypes()
         ' Retrieve the FormExtenderAttribute.
         Dim attr As FormExtenderAttribute = DirectCast(Attribute.GetCustomAttribute(type, attrType, False), FormExtenderAttribute)
         If attr IsNot Nothing Then
            ' Add to the dictionary
            Dim info As New FormExtenderInfo
            info.FormName = attr.FormName
            info.Replace = attr.Replace
            info.IncludeInherited = attr.IncludeInherited
            info.Type = type
            extenders.Add(info.FormName, info)
         End If
      Next
   End Sub

   ' Create a form.

   Public Shared Function Create(Of T As Form)() As T
      Return DirectCast(CreateForm(Of T)(), T)
   End Function

   ' Show a form

   Public Shared Sub Show(Of T As Form)()
      CreateForm(Of T).Show()
   End Sub

   Private Shared Function CreateForm(Of T As Form)() As Form
      ' Initialize plug-ins if necessary.
      If extenders Is Nothing Then InitializePlugIns()
      Dim formType As Type = GetType(T)
      Dim formName As String = formType.FullName
      Dim mustNotify As Boolean = True

      ' Check whether this form appears in the dictionary.
      If extenders.ContainsKey(formName) Then
         Dim info As FormExtenderInfo = extenders(formName)
         ' If form must be replaced, instantiate the corresponding type instead.
         If info.Replace Then
            formType = info.Type
            mustNotify = False
         End If
      End If

      ' Create the form.
      Dim frm As Form = DirectCast(Activator.CreateInstance(formType, True), Form)
      ' Notify to all extenders, if necessary, then return form to the caller.
      If mustNotify Then NotifyFormCreation(frm)
      Return frm
   End Function

   ' Notify that a given form has been created.

   Public Shared Sub NotifyFormCreation(ByVal frm As Form)
      ' Initialize plug-ins if necessary
      If extenders Is Nothing Then InitializePlugIns()

      Dim formName As String = frm.GetType().FullName
      Dim extenderType As Type = Nothing

      ' Check whether this form appears in the dictionary.
      If extenders.ContainsKey(formName) Then
         ' Don't notify forms that would replace the original one.
         If Not extenders(formName).Replace Then extenderType = extenders(formName).Type
      Else
         ' Check whether there is an extender that applies to one of the base classes.
         Dim type As Type = frm.GetType()
         Do
            type = type.BaseType
            If extenders.ContainsKey(type.FullName) Then
               Dim info As FormExtenderInfo = extenders(type.FullName)
               ' We can use this extender only if the IncludeInherited property is true.
               If info.IncludeInherited AndAlso Not info.Replace Then
                  extenderType = info.Type
                  Exit Do
               End If
            End If
            ' Continue until we get to the System.Windows.Forms.Form base class.
         Loop Until type Is GetType(Form)
      End If

      If extenderType IsNot Nothing Then
         ' Invoke the extender's constructor, passing the form instance as an argument.
         ' (This statement fails if such a constructor is missing.)
         Try
            Dim args() As Object = {frm}
            Activator.CreateInstance(extenderType, args)
         Catch ex As Exception
            Debug.WriteLine("Constructor not found for type " & extenderType.FullName)
         End Try
      End If
   End Sub

   ' Helper method that returns a reference to a control given its name.

   Public Shared Function FindControl(ByVal frm As Form, ByVal ctrlName As String) As Control
      Return FindControl(frm.Controls, ctrlName)
   End Function

   Public Shared Function FindControl(ByVal controls As Control.ControlCollection, ByVal ctrlName As String) As Control
      For Each ctrl As Control In controls
         If ctrl.Name = ctrlName Then Return ctrl
         ' Search child controls
         Dim child As Control = FindControl(ctrl.Controls, ctrlName)
         If Not child Is Nothing Then Return child
      Next
      Return Nothing
   End Function

   ' Nested class used to hold information on form extenders

   Private Class FormExtenderInfo
      Public FormName As String
      Public Replace As Boolean
      Public IncludeInherited As Boolean
      Public Type As Type
   End Class

End Class


