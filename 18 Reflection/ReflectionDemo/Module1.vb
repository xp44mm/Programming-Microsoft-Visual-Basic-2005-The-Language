Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Module MainModule

   Sub Main()
      'LoadAssembly()
      'AppDomainLoadAssemblyEvent()
      'AppDomainAssemblyResolveEvent()
      'AssemblyPropertiesAndMethods()
      'AssemblyNameType()
      'ModuleType()
      'GetttingATypeObject()
      TypeResolveEvent()
      'RetrievingTypeProperties()
      'EnumeratingMembers()
      'ExploringTypeMembers()
      'ExploringFields()
      'ExploringProperties()
      'ExploringEvents()
      'ExploringParameters()
      'ExploringTheMethodBody()
      'ExploringGenericTypes()
      'ExploringGenericMethods()
      'ExploringMembersThatUseGenericTypes()
      'BindingAGenericType()
      'ExploringAttributes()
      'ExploringAttributes2()
      'TestCustomAttributeData()
      'CreatingAnObjectDinamically()
      'AccessingMembers()
      'InvokeMemberMethod()
      'DynamicRegistrationOfEventHandlers()
      'CreatingAUniversalComparer()
      'SchedulingASequenceOfActions()
      'PerformanceConsiderations()
      'SecurityIssues()
   End Sub

   '---------------------------------------------------------
   ' Loading an assembly
   '---------------------------------------------------------

   Sub LoadAssembly()
      Dim asm As Assembly

      ' Get a reference to the assembly this code is running in.
      asm = Assembly.GetExecutingAssembly()

      ' Get a reference to the assembly a type belongs to.
      asm = Assembly.GetAssembly(GetType(System.Data.DataSet))

      ' Another way to reach the same result.
      asm = GetType(System.Data.DataSet).Assembly

      ' Get a reference to an assembly given its display name.
      ' (The argument can be the assembly's full name, which includes
      '  version, culture, and public key.)
      asm = Assembly.Load("mscorlib")

      Try
         ' Get a reference to an assembly given its filename or its full name.
         asm = Assembly.LoadFrom("c:\myapp\mylib.dll")
         ' Another way to get a reference to an assembly given its path. (See text for notes.)
         asm = Assembly.LoadFile("c:\myapp\mylib.dll")
      Catch
         ' These statements are doom to failure.
      End Try

      Console.WriteLine("Assemblies referenced by current assembly:")
      For Each refAsm As Assembly In AppDomain.CurrentDomain.GetAssemblies()
         Console.WriteLine(refAsm.FullName)
      Next
      Console.WriteLine()

      ' Load the System.Data.dll for reflection purposes.
      asm = Assembly.ReflectionOnlyLoad( _
         "System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")

      Try
         ' Load a file for reflection purposes, given its path.
         asm = Assembly.ReflectionOnlyLoadFrom("c:\myapp\mylib.dll")
      Catch
         ' These statements are doom to failure.
      End Try

      Console.WriteLine("Assemblies loaded for reflection purposes only:")
      For Each refAsm As Assembly In AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies()
         Console.WriteLine(refAsm.FullName)
      Next
      Console.WriteLine()
   End Sub

   Sub AppDomainLoadAssemblyEvent()
      ' Subscribe to AppDomain event.
      Dim appDom As AppDomain = AppDomain.CurrentDomain
      AddHandler appDom.AssemblyLoad, AddressOf AppDomain_AssemblyLoad

      ' This statement causes the JIT-compilation of DoSomethingWithXml method
      ' which in turns loads the System.Xml.dll assembly
      DoSomethingWithXml()
      Console.WriteLine()

      ' Unsubscribe from event.
      RemoveHandler appDom.AssemblyLoad, AddressOf AppDomain_AssemblyLoad
   End Sub

   Private Sub DoSomethingWithXml()
      ' This statement causes the loading of the System.Xml.dll assembly.
      Dim doc As New System.Xml.XmlDocument()
   End Sub


   Private Sub AppDomain_AssemblyLoad(ByVal sender As Object, ByVal e As AssemblyLoadEventArgs)
      Console.WriteLine("Assembly {0} is being loaded", e.LoadedAssembly.Location)
   End Sub

   Sub AppDomainAssemblyResolveEvent()
      ' Subscribe to AppDomain event.
      Dim appDom As AppDomain = AppDomain.CurrentDomain
      AddHandler appDom.AssemblyResolve, AddressOf AppDomain_AssemblyResolve
      AddHandler appDom.ReflectionOnlyAssemblyResolve, AddressOf AppDomain_ReflectionOnlyAssemblyResolve

      ' Attempt to load an assembly that isn't in the private path.
      'Dim asm As Assembly = Assembly.Load("EvaluatorLibrary")
      'Console.WriteLine("Found {0} assembly at {1}", asm.FullName, asm.Location)

      Dim asm As Assembly = Assembly.ReflectionOnlyLoad("EvaluatorLibrary")
      Console.WriteLine("Found {0} assembly at {1}", asm.FullName, asm.Location)

      ' Unsubscribe from events.
      RemoveHandler appDom.AssemblyResolve, AddressOf AppDomain_AssemblyResolve
      RemoveHandler appDom.ReflectionOnlyAssemblyResolve, AddressOf AppDomain_ReflectionOnlyAssemblyResolve
   End Sub

   Private Function AppDomain_AssemblyResolve(ByVal sender As Object, ByVal e As ResolveEventArgs) As Assembly
      ' Search the assembly two levels up in the directory tree.
      Dim searchDir As String = Path.GetFullPath(".\..\..")
      For Each dllFile As String In Directory.GetFiles(searchDir, "*.dll")
         Try
            Dim asm As Assembly = Assembly.LoadFile(dllFile)
            ' If the DLL is an assembly and its name matches, we've found it.
            If asm.GetName().Name = e.Name Then Return asm
         Catch ex As Exception
            ' Ignore DLLs that aren't valid assemblies.
         End Try
      Next
      ' If we get here, return Nothing to signal that the search failed.
      Return Nothing
   End Function

   Private Function AppDomain_ReflectionOnlyAssemblyResolve(ByVal sender As Object, ByVal e As ResolveEventArgs) As Assembly
      ' Search the assembly two levels up in the directory tree.
      Dim searchDir As String = Path.GetFullPath(".\..\..")
      For Each dllFile As String In Directory.GetFiles(searchDir, "*.dll")
         Try
            Dim asm As Assembly = Assembly.LoadFile(dllFile)
            ' If the DLL is an assembly and its name matches, we've found it.
            If asm.GetName().Name = e.Name Then Return asm
         Catch ex As Exception
            ' Ignore DLLs that aren't valid assemblies.
         End Try
      Next
      ' If we get here, return Nothing to signal that the search failed.
      Return Nothing
   End Function
   '---------------------------------------------------------
   ' Assembly's properties and methods
   '---------------------------------------------------------

   Sub AssemblyPropertiesAndMethods()
      Dim asm As Assembly

      ' This is the ADO.NET assembly.
      asm = GetType(System.Data.DataSet).Assembly
      Console.WriteLine(asm.FullName)
      ' => System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
      Debug.Assert(asm.FullName = "System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")

      Console.WriteLine(asm.Location)
      ' => C:\WINDOWS\assembly\GAC_32\System.Data\2.0.0.0_ b77a5c561934e089\System.Data.dll
      Debug.Assert(asm.Location = "C:\WINDOWS\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll")

      Console.WriteLine(asm.CodeBase)
      ' => file:///C:/WINDOWS/assembly/GAC_32/System.Data/2.0.0.0_b77a5c561934e089/System.Data.dll
      Debug.Assert(asm.CodeBase = "file:///C:/WINDOWS/assembly/GAC_32/System.Data/2.0.0.0__b77a5c561934e089/System.Data.dll")

      ' Enumerate all the types defined in an assembly.
      For Each ty As Type In asm.GetTypes
         Console.WriteLine(ty.FullName)
      Next

      ' Get a reference to a type by its textual name.
      Dim ty2 As Type = asm.GetType("System.Data.DataTable")

      ' This statement doesn't raise any exception because type name
      ' is compared in a case-insensitive way.
      Dim ty3 As Type = asm.GetType("system.data.datatable", True, True)

   End Sub


   '---------------------------------------------------------
   ' The AssemblyName Type
   '---------------------------------------------------------

   Sub AssemblyNameType()
      ' Get a reference to an assembly and its AssemblyName.
      Dim asm As Assembly = Assembly.Load("mscorlib")
      Dim an As AssemblyName = asm.GetName()

      ' Get information on all the assemblies referenced by the current assembly.
      Dim anArr() As AssemblyName
      anArr = Assembly.GetExecutingAssembly.GetReferencedAssemblies()

      Console.WriteLine(an.FullName)
      ' => mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
      Debug.Assert(an.FullName = "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")

      ' The ProcessorArchitecture property is new in .NET 2.0.
      ' It can be MSIL, X86, IA64, Amd64, or None. 
      Console.WriteLine(an.ProcessorArchitecture.ToString())   ' => X86
      Debug.Assert(an.ProcessorArchitecture.ToString() = "X86")

      ' These properties come from the version object.
      Console.WriteLine(an.Version.Major)                      ' => 2
      Console.WriteLine(an.Version.Minor)                      ' => 0
      Console.WriteLine(an.Version.Build)                      ' => 0
      Console.WriteLine(an.Version.Revision)                   ' => 0
      ' You can also get the version as a single number.
      Console.WriteLine(an.Version)                            ' => 2.0.0.0
      Debug.Assert(an.Version.ToString() = "2.0.0.0")

      ' Display the public key token of the assembly 
      For Each b As Byte In an.GetPublicKeyToken()
         Console.Write("{0} ", b)
      Next
      Console.WriteLine()

      ' Create an AssemblyName object from a full name
      Dim an2 As New AssemblyName("mscorlib, Version=2.0.0.0, Culture=neutral, " _
         & "PublicKeyToken=b77a5c561934e089, ProcessorArchitecture=x86")
   End Sub

   '---------------------------------------------------------
   ' The Module Type
   '---------------------------------------------------------

   Sub ModuleType()
      ' Enumerate all the modules in the mscorlib assembly.
      Dim asm As Assembly = Assembly.Load("mscorlib")
      ' (Note that Module is a reserved word in Visual Basic.)
      For Each mo As [Module] In asm.GetModules()
         Console.WriteLine("{0} – {1}", mo.Name, mo.ScopeName)
      Next
      Debug.Assert(asm.GetModules().Length = 1 AndAlso asm.GetModules()(0).Name = "mscorlib.dll" AndAlso asm.GetModules()(0).ScopeName = "CommonLanguageRuntimeLibrary")

      ' Get a reference to the manifest module
      Dim manModule As [Module] = asm.ManifestModule
   End Sub

   '---------------------------------------------------------
   ' Getting a Type Object
   '---------------------------------------------------------

   Sub GetttingATypeObject()
      Dim asm As Assembly = GetType(Object).Assembly

      ' List the types in the mscorlib assembly
      For Each t As Type In asm.GetTypes()
         Console.WriteLine(t.FullName)
      Next

      ' Using the GetType VB operator
      Dim ty As Type = GetType(String)
      Console.WriteLine(ty.FullName)            ' => System.String

      ' Using the GetType method
      Dim d As Double = 123.45
      ty = d.GetType()
      Console.WriteLine(ty.FullName)            ' => System.Double

      ' Note that you can't pass Type.GetType a Visual Basic synonym, 
      ' such as Short, Integer, Long, or Date.
      ty = Type.GetType("System.Int64")
      Console.WriteLine(ty.FullName)            ' => System.Int64

      ' Using the TYpe.GetType method
      Dim typeName As String = "System.Data.DataSet, System.Data, " _
          & "Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
      ty = Type.GetType(typeName)


      typeName = "System.String, System.Data, " _
         & "Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
      ty = Type.ReflectionOnlyGetType(typeName, False, False)
   End Sub


   Sub TypeResolveEvent()
      ' Subscribe to the event.
      Dim appDom As AppDomain = AppDomain.CurrentDomain
      AddHandler appDom.TypeResolve, AddressOf AppDomain_TypeResolve

      ' Get a reference to the Form type. 
      ' (It should fail, but it doesn't because we are handling the TypeResolve event.)
      Dim ty As Type = Type.GetType("System.Windows.Forms.Form")
      ' Create a form and show it.
      Dim obj As Object = ty.InvokeMember("", BindingFlags.CreateInstance, Nothing, Nothing, Nothing, Nothing)
      ty.InvokeMember("Show", BindingFlags.InvokeMethod, Nothing, obj, Nothing)

      ' Unsubscribe from the event.
      RemoveHandler appDom.TypeResolve, AddressOf AppDomain_TypeResolve
   End Sub

   Private Function AppDomain_TypeResolve(ByVal sender As Object, ByVal e As ResolveEventArgs) As Assembly
      If e.Name = "System.Windows.Forms.Form" Then
         Dim asmFile As String = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory, "System.Windows.Forms.dll")
         Return Assembly.LoadFile(asmFile)
      End If
      ' Return Nothing if unable to provide an alternative.
      Return Nothing
   End Function

   '---------------------------------------------------------
   ' Retrieving Type Properties
   '---------------------------------------------------------

   Sub RetrievingTypeProperties()

      Console.WriteLine("All the types exported by mscorlib:")
      Dim asm As Assembly = Assembly.Load("mscorlib")
      For Each t As Type In asm.GetExportedTypes()
         If t.IsClass Then
            Console.WriteLine(t.Name & " (Class)")
         ElseIf t.IsEnum Then
            ' An enum is also a value type, so we must test IsEnum before IsValueType.
            Console.WriteLine(t.Name & " (Enum)")
         ElseIf t.IsValueType Then
            Console.WriteLine(t.Name & " (Structure)")
         ElseIf t.IsInterface Then
            Console.WriteLine(t.Name & " (Interface)")
         Else
            ' This statement is never reached because a type
            ' can't be anything other than one of the above.
         End If
      Next
      Console.WriteLine()

      Console.WriteLine("Info on all the types exported by mscorlib:")
      For Each t As Type In asm.GetExportedTypes()
         Dim text As String = t.FullName & " "
         If t.IsAbstract Then text &= "MustInherit "
         If t.IsSealed Then text &= "NotInheritable "
         ' We need this test because System.Object has no base class.
         If t.BaseType IsNot Nothing Then
            text &= "(base: " & t.BaseType.FullName & ") "
         End If
         Console.WriteLine(text)
      Next
      Console.WriteLine()

      ' Testint type relatonship
      Dim obj As Object = New Person()
      If TypeOf obj Is Person Then
         ' obj can be assigned to a Person variable (the VB way).
      End If

      If GetType(Person).IsAssignableFrom(obj.GetType()) Then
         ' obj can be assigned to a Person variable (the reflection way).
      End If

      If GetType(Person).IsInstanceOfType(obj) Then
         ' obj is a Person object.
      End If

      If GetType(Person) Is obj.GetType() Then
         ' obj is a Person object (but fails if obj is Nothing).
      End If

      If obj.GetType().IsSubclassOf(GetType(Person)) Then
         ' obj is an object that inherits from Person.
      End If
   End Sub

   '---------------------------------------------------------
   ' Enumerating Members
   '---------------------------------------------------------

   Sub EnumeratingMembers()
      ' ALl the members of the String type
      Console.WriteLine("List all the members of the String type:")
      Dim minfos() As MemberInfo = GetType(String).GetMembers()
      For Each mi As MemberInfo In minfos
         Console.WriteLine("{0} ({1})", mi.Name, mi.MemberType)
      Next
      Console.WriteLine()

      ' Get all public, instance, noninherited members of String type.
      Console.WriteLine("List all public, instance, noninherited members of String type:")
      Dim minfo() As MemberInfo = GetType(String).GetMembers( _
          BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
      For Each mi As MemberInfo In minfos
         Console.WriteLine("{0} ({1})", mi.Name, mi.MemberType)
      Next
      Console.WriteLine()

      ' All the public methods of the String type
      Console.WriteLine("List all the public methods of the String type:")
      For Each mi As MethodInfo In GetType(String).GetMethods()
         Console.WriteLine(mi.Name)
      Next
      Console.WriteLine()

      ' All the interfaces of the String type
      Console.WriteLine("List all the interfaces of the String type:")
      For Each itf As Type In GetType(String).GetInterfaces()
         Console.WriteLine(itf.FullName)
      Next
      Console.WriteLine()

      ' Get information about the String.Chars property.
      Dim pi2 As PropertyInfo = GetType(String).GetProperty("Chars")
      Debug.Assert(pi2 IsNot Nothing)

      ' Get the MethodInfo object for the IndexOf string method with the
      ' following signature: IndexOf(char, startIndex, endIndex).
      ' Prepare the signature as an array of Type objects.
      Dim argTypes() As Type = {GetType(Char), GetType(Integer), GetType(Integer)}
      ' Ask for the method with given name and signature.
      Dim mi2 As MethodInfo = GetType(String).GetMethod("IndexOf", argTypes)
      Debug.Assert(mi2 IsNot Nothing)

      ' This code shows how you can build a reference to the following method
      '      Sub TestMethod(ByRef x As Integer, ByVal arr(,) As String)
      Dim argType1 As Type = GetType(Integer).MakeByRefType()
      Dim argType2 As Type = GetType(String).MakeArrayType(2)
      Dim arrTypes() As Type = {argType1, argType2}
      Dim mi3 As MethodInfo = GetType(TestClass).GetMethod("TestMethod", arrTypes)
      Debug.Assert(mi3 IsNot Nothing)

      ' Get a reference to the current method
      Dim currMethod As MethodBase = MethodBase.GetCurrentMethod()
      Debug.Assert(currMethod.Name = "EnumeratingMembers")

      ' Show that array types have a pair of square brackets.
      Dim arrTy As Type = GetType(Integer())
      Dim arrTy2 As Type = GetType(Integer(,))
      Console.WriteLine(arrTy.FullName)           ' => System.Int32[]
      Console.WriteLine(arrTy2.FullName)          ' => System.Int32[,]

   End Sub

   '---------------------------------------------------------
   ' Exploring Type Members
   '---------------------------------------------------------

   Sub ExploringTypeMembers()
      ' List of members of the String type, suppressing repeated overloaded methods.
      Console.WriteLine("List of methods in String type:")
      ' We use this ArrayList to keep track of items already displayed.
      Dim al As New ArrayList()
      For Each mi As MemberInfo In GetType(String).GetMembers()
         If mi.MemberType = MemberTypes.Constructor Then
            ' Ignore constructor methods.
         ElseIf Not mi.DeclaringType Is mi.ReflectedType Then
            ' Ignore inherited members.
         ElseIf Not al.Contains(mi.Name) Then
            ' If this element hasn't been listed yet, do it now.
            Console.WriteLine("{0}  ({1})", mi.Name, mi.MemberType)
            ' Add this element to the list of processed items.
            al.Add(mi.Name)
         End If
      Next
      Console.WriteLine()

   End Sub

   Sub ExploringFields()
      ' List all the nonconstant fields with Public or Friend scope in the Person type.
      Console.WriteLine("List all the nonconstant fields with Public or Friend scope in the TestClass type:")
      For Each fi As FieldInfo In GetType(TestClass).GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
         If (fi.IsPublic OrElse fi.IsAssembly) AndAlso Not fi.IsLiteral Then
            Console.WriteLine("{0} As {1}", fi.Name, fi.FieldType.Name)
         End If
      Next
      Console.WriteLine()

      ' List all the constants in the Person type.
      Console.WriteLine("List all the constants in the TestClass type:")
      For Each fi As FieldInfo In GetType(TestClass).GetFields()
         If fi.IsLiteral Then
            Console.WriteLine("{0} = {1}", fi.Name, fi.GetRawConstantValue())
         End If
      Next
      Console.WriteLine()

      ' List all methods of the Array class.
      Console.WriteLine("List all methods of the Array class:")
      For Each mi As MethodInfo In GetType(Array).GetMethods()
         ' Ignore special methods, such as property getters and setters.
         If mi.IsSpecialName Then Continue For
         If mi.IsFinal Then
            Console.Write("NotOverridable ")
         ElseIf mi.IsVirtual Then
            Console.Write("Overridable ")
         ElseIf mi.IsAbstract Then
            Console.Write("MustOverride ")
         End If
         Dim retTypeName As String = mi.ReturnType.FullName
         If retTypeName = "System.Void" Then
            Console.WriteLine("Sub {0}", mi.Name)
         Else
            Console.WriteLine("Function {0} As {1}", mi.Name, retTypeName)
         End If
      Next
      Console.WriteLine()
   End Sub

   Sub ExploringProperties()
      ' Display instance and static Public properties.
      For Each pi As PropertyInfo In GetType(TestClass).GetProperties( _
         BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
         ' Get either the Get or the Set accessor methods.
         Dim modifier As String = ""
         Dim mi As MethodInfo
         If pi.CanRead Then
            mi = pi.GetGetMethod()
            If Not pi.CanWrite Then modifier = "ReadOnly "
         Else
            mi = pi.GetSetMethod()
            modifier = "WriteOnly "
         End If
         ' Uncomment next line to prove that you can reach the same result
         ' with the GetAccessors method
         ' mi = pi.GetAccessors(True)(0)
         ' Add the Shared qualifier if necessary.
         If mi.IsStatic Then modifier = "Shared " & modifier
         ' Display the Visual Basic syntax.
         Console.WriteLine("Public {0}Property {1} As {2}", modifier, pi.Name, pi.PropertyType.FullName)
      Next
   End Sub

   Sub ExploringEvents()
      ' Get information on the SampleEvent event of the TestClass object.
      Dim ei As EventInfo = GetType(TestClass).GetEvent("SampleEvent")
      ' Get a reference to the hidden add_SampleEvent method.
      Dim mi2 As MethodInfo = ei.GetAddMethod()
      ' Test the method scope and check whether it's static.
      Console.WriteLine("SampleEvent is static = {0}", mi2.IsStatic)
   End Sub

   Sub ExploringParameters()
      ' Exploring the parameters of a method
      Console.WriteLine("The syntax of a method with optional and ByRef arguments:")
      Dim mi As MethodInfo = GetType(TestClass).GetMethod("MethodWithOptionalArgs")
      Console.Write(mi.Name & "(")
      For Each pi As ParameterInfo In mi.GetParameters()
         ' Display a comma if it isn't the first parameter.
         If pi.Position > 0 Then Console.Write(", ")
         If pi.IsOptional Then Console.Write("Optional ")
         ' Notice how you can discern between ByVal and ByRef parameters.
         Dim direction As String = "ByVal"
         If pi.ParameterType.IsByRef Then direction = "ByRef"
         ' Process the parameter type.
         Dim tyName As String = pi.ParameterType.FullName
         ' Convert [] into () and drop the & character (included if parameter is ByRef).
         tyName = tyName.Replace("[", "(").Replace("]", ")").Replace("&", "")
         Console.Write("{0} {1} As {2}", direction, pi.Name, tyName)
         ' Append the default value for optional parameters.
         If pi.IsOptional Then Console.Write(" = " & GetObjectValue(pi.DefaultValue))
      Next
      Console.WriteLine(")")
      Console.WriteLine()

      ' Exploring the parameters of an event.
      Console.WriteLine("The syntax of an event:")
      Dim ei As EventInfo = GetType(TestClass).GetEvent("SampleEvent")
      Console.Write(ei.Name & "(")

      Dim delegType As Type = ei.EventHandlerType
      Dim mi2 As MethodInfo = delegType.GetMethod("Invoke")
      For Each pi As ParameterInfo In mi2.GetParameters()
         ' Display a comma if it isn't the first parameter.
         If pi.Position > 0 Then Console.Write(", ")
         ' Notice how you can discern between ByVal and ByRef parameters.
         Dim direction As String = "ByVal"
         If pi.ParameterType.IsByRef Then direction = "ByRef"
         ' Process the parameter type.
         Dim tyName As String = pi.ParameterType.FullName
         Console.Write("{0} {1} As {2}", direction, pi.Name, tyName)
      Next
      Console.WriteLine(")")
      Console.WriteLine()
   End Sub

   Sub ExploringTheMethodBody()
      ' Get a reference to the  method in a type.
      Dim mi As MethodInfo = GetType(TestClass).GetMethod("TestMethod")
      Dim mb As MethodBody = mi.GetMethodBody()
      ' Display the number of used stack elements.
      Console.WriteLine("Stack Size = {0}", mb.MaxStackSize)

      ' Display index and type of local variables.
      Console.WriteLine("Local variables:")
      For Each lvi As LocalVariableInfo In mb.LocalVariables
         Console.WriteLine("  var[{0}] As {1}", lvi.LocalIndex, lvi.LocalType.FullName)
      Next

      ' Display information about exception handlers.
      Console.WriteLine("Exception handlers:")
      For Each ehc As ExceptionHandlingClause In mb.ExceptionHandlingClauses
         Console.Write("  Type={0}, ", ehc.Flags.ToString())
         If ehc.Flags = ExceptionHandlingClauseOptions.Clause Then
            Console.Write("ex As {0}, ", ehc.CatchType.Name)
         End If
         Console.Write("Try offset/length={0}/{1}, ", ehc.TryOffset, ehc.TryLength)
         Console.WriteLine("Handler offset/length={0}/{1}", ehc.HandlerOffset, ehc.HandlerLength)
      Next

   End Sub

   '---------------------------------------------------------
   ' Reflecting on Generics
   '---------------------------------------------------------

   Sub ExploringGenericTypes()
      ' List all the generic types in an assembly:
      Console.WriteLine("List all the generic types in mscorlib:")
      Dim asm As Assembly = GetType(Object).Assembly
      For Each ty As Type In asm.GetTypes()
         If ty.IsGenericTypeDefinition() Then
            Console.WriteLine(ty.FullName)
         End If
      Next
      Console.WriteLine()

      ' Retrieve the Type object corresponding to a generic type, given its name.
      Dim genType As Type = asm.GetType("System.Collections.Generic.Dictionary`2")
      Debug.Assert(genType IsNot Nothing)

      ' Display the name of a generic type (including name of type parameters).
      Dim typeName As String = genType.FullName
      ' Strip the reverse quote character.
      typeName = typeName.Remove(typeName.IndexOf("`"c)) & "(Of "
      ' Append the name of each type parameter.
      For Each tyArg As Type In genType.GetGenericArguments()
         ' The GenericParameterPosition property reflects the position where
         ' this argument appears in the signature.
         If tyArg.GenericParameterPosition > 0 Then typeName &= ","
         typeName &= tyArg.Name
      Next
      typeName &= ")"
      Console.WriteLine(typeName)  ' => System.Collections.Generic.Dictionary(Of TKey,TValue)
      Console.WriteLine()
      Debug.Assert(typeName = "System.Collections.Generic.Dictionary(Of TKey,TValue)")

      ' List all the generic methods in the ArrayType
      Console.WriteLine("Generic methods of the Array type:")
      For Each mi As MethodInfo In GetType(Array).GetMethods()
         If mi.IsGenericMethodDefinition Then
            Dim methodName As String = mi.Name & "(Of "
            For Each tyArg2 As Type In mi.GetGenericArguments()
               If tyArg2.GenericParameterPosition > 0 Then methodName &= ","
               methodName &= tyArg2.Name
            Next
            methodName &= ")"
            Console.WriteLine(methodName)     ' => IndexOf(Of T), ...
         End If
      Next
      Console.WriteLine()


   End Sub

   Sub ExploringGenericMethods()
      ' List all the arguments of a generic method
      Console.WriteLine("List the arguments of a generic method:")
      Dim tableType As Type = Assembly.GetExecutingAssembly().GetType("MyApp.GenericTable`2")
      Dim mi As MethodInfo = tableType.GetMethod("TestMethod")
      Dim signature As String = mi.Name & "("
      For Each par As ParameterInfo In mi.GetParameters()
         If par.Position > 0 Then signature &= ", "
         signature &= par.Name & " As " & GetTypeName(par.ParameterType)
      Next
      signature &= ")"
      Dim retType As Type = mi.ReturnType
      If retType.FullName <> "System.Void" Then
         signature &= " As " & GetTypeName(retType)
      End If
      Console.WriteLine(signature)    ' => TestMethod(key As K, values As V(), count As System.Int32) As T
      Debug.Assert(signature = "TestMethod(key As K, values As V(), count As System.Int32) As T")

   End Sub

   Sub ExploringMembersThatUseGenericTypes()

      ' Display the correct name of a type that takes generic arguments.
      Dim tableType As Type = Assembly.GetExecutingAssembly().GetType("MyApp.GenericTable`2")
      Dim mi As MethodInfo = tableType.GetMethod("Convert")
      Dim retType As Type = mi.ReturnType

      Dim typeName As String = retType.GetGenericTypeDefinition.FullName
      typeName = typeName.Remove(typeName.IndexOf("`"c)) & "(Of "
      Dim sep As String = ""
      For Each argType As Type In retType.GetGenericArguments
         typeName &= sep & GetTypeName(argType)
         sep = ", "
      Next
      typeName &= ")"
      Console.WriteLine(typeName)
      Console.WriteLine()
      ' => System.Collections.Generic.Dictionary(Of System.String, System.Double)
      Debug.Assert(typeName = "System.Collections.Generic.Dictionary(Of System.String, System.Double)")

      ' Test the complete version of GetTypeName
      Dim fi As FieldInfo = tableType.GetField("MyList")
      Dim fieldSyntax As String = fi.Name & " As " & GetTypeName(fi.FieldType)
      Console.WriteLine(fieldSyntax)
      Debug.Assert(fieldSyntax = "MyList As System.Collections.Generic.List(Of System.Collections.Generic.Dictionary(Of System.String, System.Double))")

      fi = tableType.GetField("MyDictionary")
      fieldSyntax = fi.Name & " As " & GetTypeName(fi.FieldType)
      Console.WriteLine(fieldSyntax)
      Debug.Assert(fieldSyntax = "MyDictionary As System.Collections.Generic.Dictionary(Of System.String, System.Collections.Generic.Dictionary(Of System.String, System.Collections.Generic.List(Of System.Int32)))")
      Console.WriteLine()
   End Sub

   Sub BindingAGenericType()
      ' Retrieve the type that corresponds to MyGenericTable(Of String, Double).
      ' First, get a reference to the "open" generic type.
      Dim tableType As Type = Assembly.GetExecutingAssembly().GetType("MyApp.GenericTable`2")
      ' Bind the "open" generic type to a set of arguments, and retrieve
      ' a reference to the MyGenericTable(Of String, Double).
      Dim type As Type = tableType.MakeGenericType(GetType(String), GetType(Double))
      Console.WriteLine(type.FullName)
      Console.WriteLine()
      ' => MyApp.GenericTable`2[[System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Double, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
      Debug.Assert(type.FullName = "MyApp.GenericTable`2[[System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Double, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")


      ' Retrieve a reference to a MethodInfo that takes generic arguments.

      ' First, get a reference to the List "open" generic type.
      Dim typeName As String = "System.Collections.Generic.List`1"
      Dim openType As Type = GetType(Object).Assembly.GetType(typeName)
      ' Bind the open List type to the Integer type.
      Dim boundType As Type = openType.MakeGenericType(GetType(Integer))
      ' Prepare the signature of the method you're interested in.
      Dim argTypes() As Type = {boundType, GetType(Integer)}
      ' Get the reference to that specific method.
      Dim method As MethodInfo = GetType(TestClass).GetMethod("TestSub", argTypes)
      Console.WriteLine(method.Name)
      Console.WriteLine()
      Debug.Assert(method IsNot Nothing)

      ' List constraints 
      Console.WriteLine("Constaints of the T argument in GenericList type:")
      Dim genType As Type = Assembly.GetExecutingAssembly().GetType("MyApp.GenericList`1")
      For Each argType As Type In genType.GetGenericArguments()
         ' Get the constraints for this argument.
         For Each constraint As Type In argType.GetGenericParameterConstraints()
            Console.WriteLine(constraint.FullName)
         Next
         Debug.Assert(argType.GetGenericParameterConstraints().Length = 2)
      Next
      Console.WriteLine()
   End Sub

   '---------------------------------------------------------
   ' Reflecting on Attributes
   '---------------------------------------------------------

   Sub ExploringAttributes()
      ' The second argument specifies whether you also want to test 
      ' attributes inherited from the base class.
      If GetType(Person).IsDefined(GetType(SerializableAttribute), False) Then
         Console.WriteLine("The Person class is serializable")
      End If
      Console.WriteLine()

      ' Display all the Conditional attributes associated with the Person.SendEmail method.
      Dim mi As MethodInfo = GetType(Person).GetMethod("SendEmail")
      ' GetCustomAttributes returns an array of Object, so you need to cast.
      Dim miAttrs() As ConditionalAttribute = DirectCast( _
         mi.GetCustomAttributes(GetType(ConditionalAttribute), False), ConditionalAttribute())
      ' Check whether the result contains at least one element.
      If miAttrs.Length > 0 Then
         Console.WriteLine("SendEmail is marked with the following Conditional attribute(s):")
         ' Read the properties of individual attributes.
         For Each attr As ConditionalAttribute In miAttrs
            Console.WriteLine("   <Conditional(""{0}"")>", attr.ConditionString)
         Next
      End If
      Console.WriteLine()

      ' Display all the attributes associated with the Person.FirstName field.
      Dim fi As FieldInfo = GetType(Person).GetField("FirstName")
      Dim fiAttrs As Array = fi.GetCustomAttributes(False)
      ' Check whether the result contains at least one element.
      If fiAttrs.Length > 0 Then
         Console.WriteLine("FirstName is marked with the following attribute(s):")
         ' Display the name of all attributes (but not their properties).
         For Each attr As Attribute In fiAttrs
            Console.WriteLine("   " & attr.GetType().FullName)
         Next
      End If
      Console.WriteLine()
   End Sub

   Sub ExploringAttributes2()
      ' Check whether the Person class is marked as obsolete.
      If Attribute.IsDefined(GetType(Person), GetType(SerializableAttribute)) Then
         Console.WriteLine("The Person class is serializable")
      End If
      Console.WriteLine()

      ' Retrieve the Conditional attributes associated with the Person.SendEmail method,
      ' including those inherited from the base class.
      Dim mi As MethodInfo = GetType(Person).GetMethod("SendEmail")
      Dim miAttrs() As ConditionalAttribute = DirectCast( _
         Attribute.GetCustomAttributes(mi, GetType(ConditionalAttribute), True), ConditionalAttribute())
      ' Check whether the result contains at least one element.
      If miAttrs.Length > 0 Then
         Console.WriteLine("SendEmail is marked with the following Conditional attribute(s):")
         ' Read the properties of individual attributes.
         For Each attr As ConditionalAttribute In miAttrs
            Console.WriteLine("   <Conditional(""{0}"")>", attr.ConditionString)
         Next
      End If

      ' Display all the attributes associated with the Person.FirstName field.
      Dim fi As FieldInfo = GetType(Person).GetField("FirstName")
      Dim fiAttrs As Array = Attribute.GetCustomAttributes(fi, False)
      ' Check whether the result contains at least one element.
      If fiAttrs.Length > 0 Then
         Console.WriteLine("FirstName is marked with the following attribute(s):")
         ' Display the name of all attributes (but not their properties).
         For Each attr As Attribute In fiAttrs
            Console.WriteLine("   " & attr.GetType().FullName)
         Next
      End If

      ' Read the Obsolete attribute associated with the Person class, if any.
      Dim tyAttr As ObsoleteAttribute = DirectCast(Attribute.GetCustomAttribute( _
         GetType(Person), GetType(ObsoleteAttribute)), ObsoleteAttribute)
      If tyAttr IsNot Nothing Then
         Console.WriteLine("The Person class is marked as obsolete.")
         Console.WriteLine("  IsError={0}, Message={1}", tyAttr.IsError, tyAttr.Message)
      End If

   End Sub

   Sub TestCustomAttributeData()
      ' Retrieve the syntax used for custom attributes in the TestClass type.
      Dim attrList As IList(Of CustomAttributeData) = CustomAttributeData.GetCustomAttributes(GetType(TestClass))

      ' Iterate over all the attributes.
      For Each attrData As CustomAttributeData In attrList
         ' Retrieve the attribute's type, by means of the ConstructorInfo object.
         Dim attrType As Type = attrData.Constructor.DeclaringType
         ' Start building the Visual Basic code.
         Dim attrString As String = "<" & attrType.FullName & "("
         Dim sep As String = ""

         ' Include all mandatory arguments for this constructor.
         For Each typedArg As CustomAttributeTypedArgument In attrData.ConstructorArguments
            attrString &= sep & FormatTypedArgument(typedArg)
            ' A comma is used as the separator for all elements after the first one.
            sep = ", "
         Next

         ' Include all optional arguments for this constructor.
         For Each namedArg As CustomAttributeNamedArgument In attrData.NamedArguments
            ' The TypedValue property returns a CustomAttributeTypedArgument object.
            Dim typedArg As CustomAttributeTypedArgument = namedArg.TypedValue
            ' Use the MemberInfo property to retrieve the field or property name.
            attrString &= sep & namedArg.MemberInfo.Name & ":=" & FormatTypedArgument(typedArg)
            ' A comma is used as the separator for all elements after the first one.
            sep = ", "
         Next
         ' Complete the attribute syntax and display it.
         attrString &= ")>"
         Console.WriteLine(attrString)
      Next

   End Sub

   '---------------------------------------------------------
   ' Reflection at Run-Time
   '---------------------------------------------------------

   Sub CreatingAnObjectDinamically()
      ' Next statement assumes that the Person class is defined in
      ' an assembly named "MyApp".
      Dim type As Type = Assembly.GetExecutingAssembly().GetType("MyApp.Person")
      Dim o As Object = Activator.CreateInstance(type)
      ' Prove that we created a Person.
      Console.WriteLine("A {0} object has been created", o.GetType().Name)

      ' Use the constructor that takes two arguments.
      Dim args2() As Object = {"Joe", "Doe"}
      ' Call the constructor that matches the parameter signature.
      Dim o2 As Object = Activator.CreateInstance(type, args2)
      Console.WriteLine("Another {0} object has been created", o.GetType().Name)


      ' Prepare the array of parameters. 
      Dim args3() As Object = {"Joe", "Doe"}
      ' Constructor methods have no name and take Nothing in last-but-one argument.
      Dim o3 As Object = type.InvokeMember("", BindingFlags.CreateInstance, _
          Nothing, Nothing, args3)
      Console.WriteLine("A third {0} object has been created", o.GetType().Name)

      ' Prepare the argument signature as an array of types (2 strings).
      Dim types() As Type = {GetType(String), GetType(String)}
      ' Get a reference to the correct constructor.
      Dim ci As ConstructorInfo = type.GetConstructor(types)
      ' Prepare the parameters.
      Dim args4() As Object = {"Joe", "Doe"}
      ' Invoke the constructor and assign the result to a variable. 
      Dim o4 As Object = ci.Invoke(args4)
      Console.WriteLine("A fourth {0} object has been created", o.GetType().Name)

      ' Create an array of Double. (You can pass an integer argument to the MakeArrayType
      ' method to specify the rank of the array, for multidimensional arrays.
      Dim arrType As Type = GetType(Double).MakeArrayType()
      ' The new array has 10 elements.
      Dim arr As Array = DirectCast(Activator.CreateInstance(arrType, 10), Array)
      Console.WriteLine("{0} {1} elements", arr.Length, arr.GetValue(0).GetType.Name)

      ' Assign the first element and read it back.
      arr.SetValue(123.45, 0)
      Console.WriteLine(arr.GetValue(0))            ' => 123.45
      Debug.Assert(arr.GetValue(0).Equals(123.45))

   End Sub

   Sub AccessingMembers()
      ' Create a Person object and reflect on it.
      Dim type As Type = Assembly.GetExecutingAssembly().GetType("MyApp.Person")
      Dim args() As Object = {"Joe", "Doe"}
      ' Call the constructor that matches the parameter signature.
      Dim o As Object = Activator.CreateInstance(type, args)

      ' Get a reference to its FirstName field.
      Dim fi As FieldInfo = type.GetField("FirstName")
      ' Display its current value then change it.
      Console.WriteLine(fi.GetValue(o))       ' => Joe
      fi.SetValue(o, "Robert")

      ' Prove that it changed, by casting to a strong type variable.
      Dim pers As Person = DirectCast(o, Person)
      Console.WriteLine(pers.FirstName)       ' => Robert
      Debug.Assert(pers.FirstName = "Robert")


      ' Get a reference to the PropertyInfo object.
      Dim pi As PropertyInfo = type.GetProperty("Age")
      ' Note that the type of value must match exactly.
      ' (Integer constants must be converted to Short, in this case.)
      pi.SetValue(o, 35S, Nothing)
      ' Read it back.
      Console.WriteLine(pi.GetValue(o, Nothing))   ' => 35
      Debug.Assert(pers.Age = 35)

      ' Get a reference to the PropertyInfo object.
      Dim pi2 As PropertyInfo = type.GetProperty("Notes")
      ' Prepare the array of parameters.
      Dim args2() As Object = {1}
      ' Set the property.
      pi2.SetValue(o, "Tell John about the briefing", args2)
      ' Read it back.
      Console.WriteLine(pi2.GetValue(o, args2))

      ' Get the MethodInfo for this method.
      Dim mi As MethodInfo = type.GetMethod("SendEmail")
      ' Prepare an array for expected arguments.
      Dim arguments() As Object = {"This is a message", 3}
      ' Invoke the method.
      mi.Invoke(o, arguments)

      ' Don't pass the second argument.
      arguments = New Object() {"This is a message", type.Missing}
      mi.Invoke(o, arguments)

      ' Retrieve the DefaultValue from the ParameterInfo object.
      arguments = New Object() {"This is a message", mi.GetParameters(1).DefaultValue}
      mi.Invoke(o, arguments)

      Try
         ' Negative priority causes an exception.
         arguments = New Object() {"This is a message", -1}
         mi.Invoke(o, arguments)
      Catch ex As TargetInvocationException
         Console.WriteLine(ex.InnerException.Message)
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub

   Sub InvokeMemberMethod()
      Dim type As Type = Assembly.GetExecutingAssembly().GetType("MyApp.Person")
      Dim arguments() As Object = {"Joe", "Doe"}
      Dim obj As Object = type.InvokeMember("", BindingFlags.CreateInstance, Nothing, Nothing, arguments)

      ' Set the FirstName field.
      Dim args() As Object = {"Francesco"}        ' One argument
      type.InvokeMember("FirstName", BindingFlags.SetField, Nothing, obj, args)
      ' Read the FirstName field. (Pass Nothing for the argument array.)
      Dim value As Object = type.InvokeMember("FirstName", BindingFlags.GetField, _
         Nothing, obj, Nothing)

      ' Set the Age property.
      Dim args2() As Object = {35S}               ' One argument
      type.InvokeMember("Age", BindingFlags.SetProperty, Nothing, obj, args2)

      ' Call the SendEMail method, create the argument array on the fly.
      type.InvokeMember("SendEmail", BindingFlags.InvokeMethod, Nothing, obj, _
         New Object() {"This is a message", 2})

      ' Read the m_Age private field. 
      Dim age As Object = type.InvokeMember("m_Age", _
         BindingFlags.GetField Or BindingFlags.NonPublic Or BindingFlags.Instance, _
         Nothing, obj, Nothing)

      ' Prove that InvokeMember works with ByRef arguments.
      Dim args3() As Object = {10}
      type.InvokeMember("IncrementValue", BindingFlags.InvokeMethod, Nothing, obj, args3)
      Console.WriteLine("New value for argument = {0}", args3(0))
      Debug.Assert(args3(0).Equals(11))
   End Sub

   Sub DynamicRegistrationOfEventHandlers()
      Dim type As Type = Assembly.GetExecutingAssembly().GetType("MyApp.Person")
      Dim arguments() As Object = {"Joe", "Doe"}
      Dim obj As Object = type.InvokeMember("", BindingFlags.CreateInstance, Nothing, Nothing, arguments)

      ' Get a reference to the GotEmail event.
      Dim ei As EventInfo = type.GetEvent("GotEmail")
      ' Get a reference to the delegate that defines the event.
      Dim handlerType As Type = ei.EventHandlerType
      ' Create a delegate of this type that points to a method in this module
      Dim handler As [Delegate] = [Delegate].CreateDelegate( _
          handlerType, GetType(MainModule), "GotEmail_Handler")
      ' Register this handler dynamically.
      ei.AddEventHandler(obj, handler)
      ' Call the method that fires the event. (Use late-binding.)
      Dim args() As Object = {"Hello Joe", 2}
      type.InvokeMember("SendEmail", BindingFlags.InvokeMethod, Nothing, obj, args)
   End Sub

   Private Sub GotEmail_Handler(ByVal sender As Object, ByVal e As EventArgs)
      Console.WriteLine("GotEmail event fired")
   End Sub

   Sub CreatingAUniversalComparer()
      Dim persons() As Person = {New Person("Joe", "Doe"), _
         New Person("Ann", "Doe"), _
         New Person("Joe", "Smith"), _
         New Person("Robert", "Douglas")}

      ' Sort the array on the LastName and FirstName fields.
      Dim comp As New UniversalComparer(Of Person)("LastName, FirstName ")
      Array.Sort(Of Person)(persons, comp)
      Console.WriteLine("Persons sorted in ascending order:")
      For Each p As Person In persons
         Console.WriteLine("{0} {1}", p.FirstName, p.LastName)
      Next
      Console.WriteLine()

      ' Sort in descending order
      comp = New UniversalComparer(Of Person)("LastName DESC, FirstName DESC")
      Array.Sort(Of Person)(persons, comp)
      Console.WriteLine("Persons sorted in descending order:")
      For Each p As Person In persons
         Console.WriteLine("{0} {1}", p.FirstName, p.LastName)
      Next
      Console.WriteLine()
   End Sub

   Sub SchedulingASequenceOfActions()
      ' Schedule the creation of c:\backup directory.
      Dim actionSequence As New ActionSequence(AddressOf Console.WriteLine)
      Dim act As New Action("Create c:\backup directory", GetType(Directory), _
         "CreateDirectory", "c:\backup")
      Dim undoAct As New Action("Delete c:\backup directory", GetType(Directory), _
         "Delete", "c:\backup", True)
      actionSequence.Add(act, undoAct)

      ' Create a readme.txt file in the c:\ root directory.
      Dim contents As String = "Instructions for myapp.exe..."
      act = New Action("Create the c:\myapp_readme.txt", GetType(File), _
         "WriteAllText", "c:\myapp_readme.txt", contents)
      ' Notice that this action has no undo action.
      actionSequence.Add(act, Nothing)

      ' Move the readme file to the backup directory.
      act = New Action("Move the c:\myapp_readme.txt to c:\backup\readme.txt", GetType(File), _
         "Move", "c:\myapp_readme.txt", "c:\backup\readme.txt")
      undoAct = New Action("Move c:\backup\readme.txt to c:\myapp_readme.txt", GetType(File), _
         "Move", "c:\backup\readme.txt", "c:\myapp_readme.txt")
      actionSequence.Add(act, undoAct)

      ' Copy the c:\missing.txt file to the c:\backup directory.
      ' THIS ACTION WILL CAUSE THE ENTIRE SEQUENCE TO BE ROLLED BACK.
      act = New Action("Copy c:\missing.txt to c:\backup", GetType(File), _
         "Copy", "c:\missing.text", "c:\backup\missing.txt")
      ' (No need to define an undo action for this demo...)
      actionSequence.Add(act, Nothing)

      ' Execute the action sequence. (False means that an exception undoes all actions.)
      actionSequence.Execute(False)
   End Sub

   Sub PerformanceConsiderations()
      ' This code doesn't work – The GetMethod method returns Nothing.
      ' You must either use Integer instead of Short in the argTypes signature
      ' or drop the BindingFlags.ExactBinding bit in the GetMethod call.
      Dim argTypes() As Type = {GetType(Char), GetType(Short)}
      Dim mi As MethodInfo = GetType(String).GetMethod("IndexOf", BindingFlags.ExactBinding Or _
         BindingFlags.Public Or BindingFlags.Instance, Nothing, argTypes, Nothing)
      Debug.WriteLine(mi Is Nothing)

      ' Store information about a method in the Person type.
      Dim hType As RuntimeTypeHandle = GetType(Person).TypeHandle
      Dim hMethod As RuntimeMethodHandle = GetType(Person).GetMethod("SendEmail").MethodHandle
      ' ...
      ' (Later in the application...)
      ' Rebuild the Type and MethodBase objects.
      Dim ty As Type = Type.GetTypeFromHandle(hType)
      Dim mb As MethodBase = MethodBase.GetMethodFromHandle(hMethod, hType)
      ' Use them as needed.
      Console.WriteLine("Type={0}, Method={1}", ty.FullName, mb.Name)

   End Sub

   Sub SecurityIssues()
      ' Copy a Person object via reflection.
      Dim joe As New Person("Joe", "Doe")
      Dim ann As New Person("Ann", "Smith")
      joe.Spouse = ann
      ann.Spouse = joe
      ' We need no CType or DirectCast, thanks to generics.
      Dim joe2 As Person = CloneObject(joe)
      ' Prove that it worked.
      Console.WriteLine("{0} {1}, spouse is {2} {3}", joe2.FirstName, joe2.LastName, _
         joe2.Spouse.FirstName, joe2.Spouse.LastName)
      ' => Joe Doe, spouse is Ann Smith
      Debug.Assert(joe2.FirstName = "Joe" AndAlso joe2.LastName = "Doe" AndAlso joe2.Spouse Is joe.Spouse)
   End Sub


End Module
