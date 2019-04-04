VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   2685
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4080
   LinkTopic       =   "Form1"
   ScaleHeight     =   2685
   ScaleWidth      =   4080
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Test .NET component "
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   360
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim WithEvents emp As SampleNetComponent.Employee
Attribute emp.VB_VarHelpID = -1

Private Sub Command1_Click()
    Set emp = New SampleNetComponent.Employee
    emp.FirstName = "John"
    emp.LastName = "Evans"
    Dim res As String
    res = emp.ReverseName()
    MsgBox (res)
End Sub

Private Sub emp_NameChanged(ByVal sender As Variant, ByVal e As mscorlib.EventArgs)
    Debug.Print ("Name changed: " & emp.ReverseName)
End Sub
