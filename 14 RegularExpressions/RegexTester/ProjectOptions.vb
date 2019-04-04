Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.IO

Public Class ProjectOptions
   ' Public properties
   <XmlIgnore()> _
   Public RegexFile As String

   Public RegexName As String = ""
   Public RegexDescription As String = ""
   Public RegexText As String = ""
   Public ReplaceText As String = ""
   Public SourceText As String = ""
   Public Command As Command = Command.Find
   Public RegexOptions As RegexOptions
   Public Detail As DetailOption = DetailOption.Groups
   Public MaxMatches As Integer = 1000
   Public Sort As SortOption = SortOption.Position
   Public WordWrap As Boolean = True
   Public Format As FormatOption = FormatOption.Auto
   Public IncludeEmptyGroups As Boolean = True

   Public Language As LanguageOption = LanguageOption.VisualBasic
   Public VerbatimStrings As Boolean = False
   Public InstanceMethods As Boolean = True
   Public AssumeImports As Boolean = True
   Public GenerateLoop As Boolean = True
   Public IncludeComment As Boolean = True
   Public CopyCodeOnExit As Boolean = True

   <XmlIgnore()> _
   Private LoadValues As ProjectOptions

   Public ReadOnly Property HasChanged() As Boolean
      Get
         Return Me.RegexText <> LoadValues.RegexText OrElse _
            Me.ReplaceText <> LoadValues.ReplaceText OrElse _
            Me.SourceText <> LoadValues.SourceText OrElse _
            Me.Command <> LoadValues.Command OrElse _
            Me.RegexOptions <> LoadValues.RegexOptions OrElse _
            Me.Detail <> LoadValues.Detail OrElse _
            Me.MaxMatches <> LoadValues.MaxMatches OrElse _
            Me.Sort <> LoadValues.Sort OrElse _
            Me.Format <> LoadValues.Format OrElse _
            Me.WordWrap <> LoadValues.WordWrap
      End Get
   End Property

   Public Sub ClearChanges()
      Me.LoadValues = CType(Me.MemberwiseClone, ProjectOptions)
   End Sub

   ' Load an object from file
   Public Shared Function Load(ByVal fileName As String) As ProjectOptions
      Using st As New FileStream(fileName, FileMode.Open)
         Dim xmlSer As New XmlSerializer(GetType(ProjectOptions))
         Dim res As ProjectOptions = DirectCast(xmlSer.Deserialize(st), ProjectOptions)
         res.RegexFile = fileName
         res.ClearChanges()
         Return res
      End Using
   End Function

   ' Save current object to file 
   Public Sub Save(ByVal fileName As String)
      Using st As New FileStream(fileName, FileMode.Create)
         Dim xmlSer As New XmlSerializer(GetType(ProjectOptions))
         xmlSer.Serialize(st, Me)
         RegexFile = fileName
         ClearChanges()
      End Using
   End Sub
End Class
