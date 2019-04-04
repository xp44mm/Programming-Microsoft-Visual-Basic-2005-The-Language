Imports System.Collections.ObjectModel
Imports Microsoft.Win32 

Namespace My
   Partial Friend Class MyApplication
      ' The font used for menus.
      Public ReadOnly Property MenuFont() As Font
         Get
            Return SystemInformation.MenuFont
         End Get
      End Property

      ' Support for the DisplaySettingsChanged event

      Public Event DisplaySettingsChanged As EventHandler

      Protected Overrides Function OnInitialize( _
         ByVal commandLineArgs As ReadOnlyCollection(Of String)) As Boolean
         AddHandler SystemEvents.DisplaySettingsChanged, AddressOf Events_SettingsChanged
         Return MyBase.OnInitialize(commandLineArgs)
      End Function

      Private Sub Events_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         OnDisplaySettingsChanged(e)
      End Sub

      Protected Overridable Sub OnDisplaySettingsChanged(ByVal e As EventArgs)
         RaiseEvent DisplaySettingsChanged(Me, e)
      End Sub

   End Class

   Partial Friend Class MyComputer
      ' The name of the user's domain, or the computer name if no domain is present.
      Public ReadOnly Property DomainName() As String
         Get
            Return SystemInformation.UserDomainName
         End Get
      End Property
   End Class
End Namespace

Namespace My.Resources
   <System.Diagnostics.DebuggerNonUserCodeAttribute(), _
    Microsoft.VisualBasic.HideModuleName()> _
   Friend Module MyResources

      Private m_Colors() As String

      '''<summary>
      '''  Looks up a string array containing color names.
      '''</summary>
      Friend ReadOnly Property Colors() As String()
         Get
            If m_Colors Is Nothing Then
               Dim separators() As String = {ControlChars.CrLf}
               m_Colors = My.Computer.FileSystem.ReadAllText("colors.dat"). _
                  Split(separators, StringSplitOptions.RemoveEmptyEntries)
            End If
            Return m_Colors
         End Get
      End Property


   End Module
End Namespace

Namespace My
   Partial Friend Class MySettings
      <Global.System.Configuration.UserScopedSettingAttribute(), _
       Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
       Global.System.Configuration.DefaultSettingValueAttribute(Nothing)> _
      Public Property UserNicknames() As String()
         Get
            Return CType(Me("UserNicknames"), String())
         End Get
         Set(ByVal value As String())
            Me("UserNicknames") = value
         End Set
      End Property
   End Class

End Namespace



