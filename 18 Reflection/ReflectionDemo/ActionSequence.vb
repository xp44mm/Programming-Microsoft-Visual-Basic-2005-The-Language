Imports System.Reflection

Public Class Action
    Public ReadOnly Message As String       ' Description of the action
    Public ReadOnly [Object] As Object      ' Instance on which the method is called
    Public ReadOnly Method As MethodInfo    ' The method to be invoked
    Public ReadOnly Arguments() As Object   ' Arguments for the method

    ' 2nd argument can be an object (for instance methods) or a Type (for static methods).
    Public Sub New(ByVal message As String, ByVal obj As Object,
          ByVal methodName As String, ByVal ParamArray arguments() As Object)
        Me.Message = message
        Me.Arguments = arguments
        ' Determine the type this method belongs to.
        Dim type As Type = TryCast(obj, Type)
        If type Is Nothing Then
            Me.Object = obj
            type = obj.GetType()
        End If
        ' Prepare the list of argument types, to call GetMethod without any ambiguity.
        Dim argTypes(arguments.Length - 1) As Type
        For index As Integer = 0 To arguments.Length - 1
            If arguments(index) IsNot Nothing Then
                argTypes(index) = arguments(index).GetType()
            End If
        Next
        ' Retrieve the actual MethodInfo object, throw an exception if not found.
        Me.Method = type.GetMethod(methodName, argTypes)
        If Me.Method Is Nothing Then
            Throw New ArgumentException("Missing method")
        End If
    End Sub

    ' Execute this method.
    Public Sub Execute()
        Me.Method.Invoke(Me.Object, Me.Arguments)
    End Sub

End Class

Public Class ActionSequence

    ' The parallel lists of actions and undo actions.
    Private Actions As New List(Of Action)

    Private UndoActions As New List(Of Action)

    ' This delegate must point to a method that takes a string.
    Private DisplayMethod As Action(Of String)

    ' The constructor takes a delegate to a method that can output a message
    Public Sub New(ByVal displayMethod As Action(Of String))
        Me.DisplayMethod = displayMethod
    End Sub

    ' Add an action and an undo action to the list.
    Public Sub Add(ByVal action As Action, ByVal undoAction As Action)
        Actions.Add(action)
        UndoActions.Add(undoAction)
    End Sub

    ' Insert an action and an undo action at a specific index in the list.
    Public Sub Insert(ByVal index As Integer, ByVal action As Action, ByVal undoAction As Action)
        Actions.Insert(index, action)
        UndoActions.Insert(index, undoAction)
    End Sub

    ' Execute all pending actions, return true if no exception occurred.
    Public Function Execute(ByVal ignoreExceptions As Boolean) As Boolean
        ' This is the list of undo actions to execute in case of error.
        Dim undoSequence As New ActionSequence(Me.DisplayMethod)

        For index As Integer = 0 To Actions.Count - 1
            Dim act As Action = Actions(index)
            ' Skip over null actions.
            If act Is Nothing Then Continue For

            Try
                ' Display the message and execute the action.
                DisplayMessage(act.Message)
                act.Execute()
                ' If successful, remember the undo action. The undo action is placed
                ' in front of all others, so that it will be the first to be executed in case of error.
                undoSequence.Insert(0, UndoActions(index), Nothing)
            Catch ex As TargetInvocationException
                ' Ignore exceptions if so required.
                If ignoreExceptions Then Continue For
                ' Display the error message.
                DisplayMessage("ERROR: " & ex.InnerException.Message)
                ' Perform the undo sequence. (Ignore exceptions while undoing.)
                DisplayMessage("UNDOING OPERATIONS...")
                undoSequence.Execute(True)
                ' Signal that an exception occurred.
                Return False
            End Try
        Next
        ' Signal that no exceptions occurred.
        Return True
    End Function

    ' Report a message via the delegate passed to the constructor.
    Private Sub DisplayMessage(ByVal text As String)
        If Me.DisplayMethod IsNot Nothing Then
            Me.DisplayMethod(text)
        End If
    End Sub

End Class
