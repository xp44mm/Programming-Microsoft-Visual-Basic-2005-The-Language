Imports System.IO
Imports System.Reflection

Public Class DataObjectFactory

   ' This dictionary holds all data objects founds so far.
   Public ReadOnly DataObjects As New Dictionary(Of String, Type)
   ' This holds all validator objects for a given data object.
   Public ReadOnly DataCompanions As New Dictionary(Of String, List(Of Type))

   ' Constructors 
   Sub New(ByVal configuration As String, ByVal assembly As Assembly)
      Me.Configuration = configuration
      AddDataObjects(assembly)
   End Sub

   Sub New(ByVal configuration As String, ByVal dataObjectsDirectory As String)
      Me.Configuration = configuration
      AddDataObjects(dataObjectsDirectory)
   End Sub

   ' the Configuration property (readonly)
   ' Configurations are compared in case-insensitive way.

   Private m_Configuration As String

   Public Property Configuration() As String
      Get
         Return m_Configuration
      End Get
      Private Set(ByVal value As String)
         If String.IsNullOrEmpty(value) Then
            Throw New ArgumentException("Configuration can't be null or empty")
         End If
         m_Configuration = value
      End Set
   End Property

   ' Add all the data objects in all the assemblies in the specified directory.
   Public Sub AddDataObjects(ByVal dataObjectsDirectory As String)
      ' Read all the DLLs in the provided path.
      For Each asmFile As String In Directory.GetFiles(dataObjectsDirectory, "*.dll")
         AddDataObjects(asmFile, False)
      Next
   End Sub

   ' Add all the data objects in a given assembly.
   Public Sub AddDataObjects(ByVal asmFile As String, ByVal throwIfError As Boolean)
      Try
         ' Add all the data objects in this assembly.
         Dim asm As Assembly = Assembly.LoadFile(asmFile)
         AddDataObjects(asm)
      Catch ex As Exception When Not throwIfError
         ' Ignore DLLs that aren't .NET assemblies if so required.
      End Try
   End Sub

   ' Add all the DataObjects of this assembly to the list.
   Public Sub AddDataObjects(ByVal assembly As Assembly)
      For Each type As Type In assembly.GetTypes()
         ' Look for types marked with the DataObject attribute.
         Dim doAttr As DataObjectAttribute = DirectCast(Attribute.GetCustomAttribute(type, GetType(DataObjectAttribute), False), DataObjectAttribute)
         ' Ensure that type implements IDataObject and that it's suitable for this configuration
         ' (or current configuration is null).
         If doAttr IsNot Nothing AndAlso GetType(IDataObject).IsAssignableFrom(type) _
               AndAlso (String.Compare(Me.Configuration, doAttr.Configuration, True) = 0 OrElse Me.Configuration.Length = 0) Then
            ' Add to the dictionary only if not there already.
            If Not DataObjects.ContainsKey(doAttr.Table.ToLower()) Then DataObjects.Add(doAttr.Table.ToLower(), type)
         End If

         ' Look for types marked with the DataObjectValidator attribute.
         ' (This attribute allows multiple instances.)
         Dim coAttrs() As DataObjectCompanionAttribute = DirectCast(Attribute.GetCustomAttributes(type, GetType(DataObjectCompanionAttribute), False), DataObjectCompanionAttribute())
         If coAttrs IsNot Nothing AndAlso coAttrs.Length > 0 Then
            ' Iterate over each instance of the attribute.
            For Each coAttr As DataObjectCompanionAttribute In coAttrs
               ' Create an item in the DataValidators dictionary, if necessary.
               If Not Me.DataCompanions.ContainsKey(coAttr.TypeName) Then
                  Me.DataCompanions.Add(coAttr.TypeName, New List(Of Type))
               End If
               ' Add this validator to the list.
               Me.DataCompanions(coAttr.TypeName).Add(type)
            Next
         End If
      Next
   End Sub

   ' Create a dataobject for a given database/table.
   Public Function Create(ByVal table As String) As IDataObject
      If Not Me.DataObjects.ContainsKey(table.ToLower()) Then
         Throw New ArgumentException("Table not found: " & table)
      End If
      ' Create an instance of the corresponding data object.
      Dim type As Type = Me.DataObjects(table.ToLower())
      Dim dataObj As IDataObject = DirectCast(Activator.CreateInstance(type, True), IDataObject)

      ' Add all specific data companiones that are associated with this specific data object.
      If Me.DataCompanions.ContainsKey(type.FullName) Then
         ' Create an instance of each validator associated with this data object
         ' and add the validator to the Validators collection.
         For Each coType As Type In Me.DataCompanions(type.FullName)
            Dim compObj As IDataObjectCompanion = DirectCast(Activator.CreateInstance(coType, True), IDataObjectCompanion)
            dataObj.Companions.Add(compObj)
         Next
      End If

      ' Add all the generic data companions (generic companions are associated with all data object).
      If Me.DataCompanions.ContainsKey("") Then
         ' Create an instance of each validator associated with this data object
         ' and add the validator to the Validators collection.
         For Each coType As Type In Me.DataCompanions("")
            Dim compObj As IDataObjectCompanion = DirectCast(Activator.CreateInstance(coType, True), IDataObjectCompanion)
            dataObj.Companions.Add(compObj)
         Next
      End If

      Return dataObj
   End Function

End Class
