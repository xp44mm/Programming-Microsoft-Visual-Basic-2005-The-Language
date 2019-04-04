Imports System.Text

' a collection of top-level or child windows

Public Class WindowCollection
   Inherits List(Of Window)

   Private Delegate Function EnumWindowsProc(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean
   Private Declare Function EnumWindows Lib "user32" (ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Integer
   Private Declare Function EnumChildWindows Lib "user32" Alias "EnumChildWindows" (ByVal hWndParent As IntPtr, ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As IntPtr) As Integer

   ' the handle of the parent window, or zero if top-level windows 
   Dim m_hWnd As IntPtr

   ' constructors

   Sub New()
      ' create a collection of top-level windows
      Me.New(IntPtr.Zero)
   End Sub

   Sub New(ByVal handle As IntPtr)
      ' create a collection of top-level or child-windows
      m_hWnd = handle
      If handle.Equals(IntPtr.Zero) Then
         ' top-level windows 
         EnumWindows(New EnumWindowsProc(AddressOf EnumWindows_CBK), IntPtr.Zero)
      Else
         ' child windows
         EnumChildWindows(m_hWnd, AddressOf EnumWindows_CBK, m_hWnd)
      End If
   End Sub

   ' the callback function

   Private Function EnumWindows_CBK(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean
      ' add a new window to the inner list
      Me.Add(New Window(hWnd))
      ' return True to continue enumeration
      Return True
   End Function
End Class

' a Windows's window

Public Class Window
   Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
   Private Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As String) As Integer
   Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer

   ' the handle of this window
   Dim m_hWnd As IntPtr
   ' the collection of child windows
   Dim m_ChildWindows As WindowCollection

   ' constructor
   Sub New(ByVal handle As IntPtr)
      m_hWnd = handle
   End Sub

   ' the Handle property (readonly)
   ReadOnly Property Handle() As IntPtr
      Get
         Return m_hWnd
      End Get
   End Property

   ' the Text property

   Property Text() As String
      Get
         Dim sb As New StringBuilder(1024)
         GetWindowText(m_hWnd, sb, sb.Capacity)
         Return sb.ToString
      End Get
      Set(ByVal Value As String)
         SetWindowText(m_hWnd, Value)
      End Set
   End Property

   ' the ClassName property (readonly)

   ReadOnly Property ClassName() As String
      Get
         Dim sb As New StringBuilder(1024)
         GetClassName(m_hWnd, sb, sb.Capacity)
         Return sb.ToString
      End Get
   End Property

   ' the Description property (readonly)

   ReadOnly Property Description() As String
      Get
         ' return handle, classname, and Text
         Return String.Format("[{0:X8}] {1} ""{2}""", m_hWnd, ClassName, Text)
      End Get
   End Property

   ' the ChildWindows collection
   ' (the collection is created the first time this property is queried)

   ReadOnly Property ChildWindows() As WindowCollection
      Get
         If m_ChildWindows Is Nothing Then
            m_ChildWindows = New WindowCollection(m_hWnd)
         End If
         Return m_ChildWindows
      End Get
   End Property

End Class
