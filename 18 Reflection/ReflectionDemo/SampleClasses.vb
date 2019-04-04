Imports System.ComponentModel
Imports System.Runtime.InteropServices

<Serializable()> _
Public Class Person
   Event GotEmail(ByVal sender As Object, ByVal e As GotEmailEventArgs)

   <NonSerialized()> _
   <Description("Firstname field")> _
   Public FirstName As String
   Public LastName As String

   Public Spouse As Person

   ' Constructor without arguments
   Sub New()
   End Sub

   ' Constructor with arguments
   Sub New(ByVal firstName As String, ByVal lastName As String)
      Me.FirstName = firstName
      Me.LastName = lastName
   End Sub

   ' A public property
   Dim m_Age As Short

   Public Property Age() As Short
      Get
         Return m_Age
      End Get
      Set(ByVal value As Short)
         m_Age = value
      End Set
   End Property

   ' A property with arguments.
   Dim m_Notes(9) As String

   Public Property Notes(ByVal index As Integer) As String
      Get
         Return m_Notes(index)
      End Get
      Set(ByVal value As String)
         m_Notes(index) = value
      End Set
   End Property

   <Conditional("TRACE"), Conditional("DEBUG")> _
   Sub SendEmail(ByVal text As String, Optional ByVal priority As Integer = 1)
      Console.WriteLine("Sending email. Text={0}, Priority={1}", text, priority)
      If priority < 0 Then
         Throw New ArgumentException("Priority can't be negative")
      End If
      Dim e As New GotEmailEventArgs(text, priority)
      RaiseEvent GotEmail(Me, e)
   End Sub

   Sub IncrementValue(ByRef n As Integer)
      n = n + 1
   End Sub
End Class

' Support for the GotEmail event

Public Class GotEmailEventArgs
   Inherits EventArgs

   Public ReadOnly Text As String
   Public ReadOnly Priority As Integer

   Sub New(ByVal text As String, ByVal priority As Integer)
      Me.Text = text
      Me.Priority = priority
   End Sub
End Class

' A class used for all nongeneric examples.

<Serializable()> _
<MyCustomAttribute(MsgBoxResult.Ok, Size:=8, Description:="A test class")> _
<System.Web.Services.WebService(Description:="My web services", Name:="Sample web method")> _
Public Class TestClass
   Public Field1 As String
   Friend Field2 As Integer

   Public Const Constant1 As Long = 1234
   Public Const Constant2 As String = "ABCDE"

   Public Shared Event SampleEvent As CancelEventHandler


   Sub TestMethod(ByRef x As Integer, ByVal arr(,) As String)
      Try
         Console.WriteLine("First Try block")
      Catch ex As NullReferenceException
         Console.WriteLine("NullReference exception")
      Catch ex As Exception
         Console.WriteLine("Other exception")
      Finally
         Console.WriteLine("Finally block")
      End Try

      Try
         Console.WriteLine("Second Try block")
      Catch ex As NullReferenceException
         Console.WriteLine("NullReference exception")
      Catch ex As OverflowException
         Console.WriteLine("Overflow exception")
      Catch ex As Exception
         Console.WriteLine("Other exception")
      End Try
   End Sub

   ' A method with optional arguments.
   Sub MethodWithOptionalArgs(ByRef x As Integer, ByVal arr() As String, Optional ByVal y As Integer = -1, Optional ByVal s As String = "ABCDE")

   End Sub

   ' A public property.
   Public Property ID() As Integer
      Get
         Return 0
      End Get
      Set(ByVal value As Integer)

      End Set
   End Property

   ' A static readonly property
   Public Shared ReadOnly Property StaticName() As String
      Get
         Return Nothing
      End Get
   End Property


   Sub TestSub(ByVal list As List(Of Integer), ByVal x As Integer)
      Console.WriteLine("TestSub overload #1")
   End Sub
   Sub TestSub(ByVal list As List(Of String), ByVal x As String)
      Console.WriteLine("TestSub overload #2")
   End Sub
End Class



' Two classes used for generic examples.

Public Class GenericList(Of T As {New, Class, IComparable, ICloneable})

End Class

Public Class GenericTable(Of K, V)
   Public MyList As List(Of Dictionary(Of String, Double))
   Public MyDictionary As Dictionary(Of String, Dictionary(Of String, List(Of Integer)))

   Function TestMethod(Of T)(ByVal key As K, ByVal values() As V, ByVal count As Integer) As T

   End Function

   Function Convert(ByVal x As List(Of Integer)) As Dictionary(Of String, Double)
      Return Nothing
   End Function

End Class


