Imports System.Reflection
Imports System.Runtime.Serialization

Public Class MySerializationBinder
   Inherits SerializationBinder

   Public Overrides Function BindToType(ByVal assemblyName As String, _
      ByVal typeName As String) As Type
      If typeName = "BOLibrary.Customer" Then
         ' Return the CustomerEx type taken from current assembly
         Return GetType(CustomerEx)
      Else
         ' Otherwise, tell the runtime to apply the default binding policy.
         Return Nothing
      End If
   End Function
End Class
