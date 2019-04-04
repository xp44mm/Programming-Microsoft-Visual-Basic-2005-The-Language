Imports System.IO
Imports System.Threading

Public Class TextFileReader
   ' This private delegate matches the signature of the Read method.
   Private Delegate Function InvokeRead(ByVal fileName As String) As String

   ' True if the asynchronous operation has been canceled
   Private canceled As Boolean
   ' A delegate that points to the Read method
   Private deleg As InvokeRead
   ' The object used to control asynchronous operations
   Private ar As IAsyncResult

   ' The Read method (synchronous)
   Public Function Read(ByVal fileName As String) As String
      canceled = False
      Dim sb As New System.Text.StringBuilder()
      Using sr As New StreamReader(fileName)
         Do While sr.Peek() <> -1
            sb.Append(sr.ReadLine()).Append(ControlChars.CrLf)
            If canceled Then Return Nothing
         Loop
         Return sb.ToString()
      End Using
   End Function

   ' The following methods add support for asynchronous operations.
   Public Sub BeginRead(ByVal fileName As String)
      deleg = New InvokeRead(AddressOf Read)
      ar = deleg.BeginInvoke(fileName, Nothing, Nothing)
   End Sub

   Public Function EndRead() As String
      If canceled OrElse deleg Is Nothing Then
         Return Nothing
      Else
         Return deleg.EndInvoke(ar)
      End If
   End Function

   Public Sub CancelRead()
      ' Cause the Read method to exit prematurely, then return the thread to the pool
      If Not canceled AndAlso deleg IsNot Nothing Then
         canceled = True
         deleg.EndInvoke(ar)
      End If
   End Sub
End Class
