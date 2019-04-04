Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class DataEntryFormBase

   Private m_FocusForeColor As Color
   Private m_FocusBackColor As Color

   <Description("The foreground color of focused controls.")> _
   <Category("Appearance")> _
   Public Property FocusForeColor() As Color
      Get
         Return m_FocusForeColor
      End Get
      Set(ByVal Value As Color)
         m_FocusForeColor = Value
      End Set
   End Property


   <Description("The background color of focused controls.")> _
   <Category("Appearance")> _
   Public Property FocusBackColor() As Color
      Get
         Return m_FocusBackColor
      End Get
      Set(ByVal Value As Color)
         m_FocusBackColor = Value
      End Set
   End Property

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      ' Register events for input controls.
      For Each ctrl As Control In GetChildControls(Me)
         If ctrl.BackColor.Equals(SystemColors.Window) Then
            AddHandler ctrl.Enter, AddressOf Control_Enter
            AddHandler ctrl.Leave, AddressOf Control_Leave
         End If
      Next
   End Sub

   ' Temporary storage for control's colors
   Private saveForeColor As Color = SystemColors.WindowText
   Private saveBackColor As Color = SystemColors.Window

   ' Change colors when the control gets the focus.
   Private Sub Control_Enter(ByVal sender As Object, ByVal e As EventArgs)
      Dim ctrl As Control = DirectCast(sender, Control)
      ctrl.ForeColor = FocusForeColor
      ctrl.BackColor = FocusBackColor
   End Sub

   ' Restore original colors when the control loses the focus.
   Private Sub Control_Leave(ByVal sender As Object, ByVal e As EventArgs)
      Dim ctrl As Control = DirectCast(sender, Control)
      ctrl.ForeColor = saveForeColor
      ctrl.BackColor = saveBackColor
   End Sub

   ' Return the list of all the controls contained in another control.
   Private Function GetChildControls(ByVal parent As Control) As ArrayList
      Dim result As New ArrayList()
      For Each ctrl As Control In parent.Controls
         ' Add this control to the result.
         result.Add(ctrl)
         ' Recursively call this method to add all child controls as well.
         result.AddRange(GetChildControls(ctrl))
      Next
      Return result
   End Function

   ' Public events
   Public Event AppActivated As EventHandler
   Public Event AppDeactivate As EventHandler

   Protected Overrides Sub WndProc(ByRef m As Message)
      Const WM_ACTIVATEAPP As Integer = &H1C
      ' Let the base form process this message.
      MyBase.WndProc(m)
      ' Process only the WM_ACTIVATEAPP message.
      If m.Msg = WM_ACTIVATEAPP Then
         If m.WParam.ToInt32 <> 0 Then
            OnAppActivated(EventArgs.Empty)
         Else
            OnAppDeactivate(EventArgs.Empty)
         End If
      End If
   End Sub

   ' Onxxxx protected methods that actually raise the event
   Protected Sub OnAppActivated(ByVal e As EventArgs)
      RaiseEvent AppActivated(Me, e)
   End Sub

   Protected Sub OnAppDeactivate(ByVal e As EventArgs)
      RaiseEvent AppDeactivate(Me, e)
   End Sub

End Class