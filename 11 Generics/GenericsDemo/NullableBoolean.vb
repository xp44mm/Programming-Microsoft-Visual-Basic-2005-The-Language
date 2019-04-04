Public Structure NullableBoolean
   Private m_HasValue As Boolean
   Private m_Value As Boolean

   Sub New(ByVal value As Boolean)
      m_HasValue = True
      m_Value = value
   End Sub

   Public ReadOnly Property HasValue() As Boolean
      Get
         Return m_HasValue
      End Get
   End Property

   Public ReadOnly Property Value() As Boolean
      Get
         If Not m_HasValue Then Throw New InvalidOperationException()
         Return m_Value
      End Get
   End Property

   Public Overrides Function ToString() As String
      If Me.HasValue Then
         Return Me.Value.ToString()
      Else
         Return "Null"
      End If
   End Function

   Public Shared Operator =(ByVal v1 As NullableBoolean, _
         ByVal v2 As NullableBoolean) As NullableBoolean
      If v1.HasValue AndAlso v2.HasValue Then
         Return New NullableBoolean(v1.Value = v2.Value)
      Else
         Return New NullableBoolean
      End If
   End Operator

   Public Shared Operator <>(ByVal v1 As NullableBoolean, _
         ByVal v2 As NullableBoolean) As NullableBoolean
      Return Not (v1 = v2)
   End Operator


   Public Shared Operator And(ByVal v1 As NullableBoolean, _
         ByVal v2 As NullableBoolean) As NullableBoolean
      If (v1.HasValue AndAlso v1.Value = False) OrElse _
            (v2.HasValue AndAlso v2.Value = False) Then
         Return New NullableBoolean(False)
      ElseIf v1.HasValue AndAlso v2.HasValue Then
         Return New NullableBoolean(True)
      Else
         Return New NullableBoolean()
      End If
   End Operator

   Public Shared Operator Or(ByVal v1 As NullableBoolean, _
         ByVal v2 As NullableBoolean) As NullableBoolean
      If (v1.HasValue AndAlso v1.Value) OrElse _
            (v2.HasValue AndAlso v2.Value) Then
         Return New NullableBoolean(True)
      ElseIf v1.HasValue AndAlso v2.HasValue Then
         Return New NullableBoolean(False)
      Else
         Return New NullableBoolean()
      End If
   End Operator

   Public Shared Operator Not(ByVal v As NullableBoolean) As NullableBoolean
      If v.HasValue Then
         Return New NullableBoolean(Not v.Value)
      Else
         Return New NullableBoolean
      End If
   End Operator

   Public Shared Operator Xor(ByVal v1 As NullableBoolean, _
         ByVal v2 As NullableBoolean) As NullableBoolean
      If v1.HasValue AndAlso v2.HasValue Then
         Return v1.Value Xor v2.Value
      Else
         Return New NullableBoolean
      End If
   End Operator

   Public Shared Operator IsTrue(ByVal v As NullableBoolean) As Boolean
      Return v.HasValue AndAlso v.Value
   End Operator

   Public Shared Operator IsFalse(ByVal v As NullableBoolean) As Boolean
      Return v.HasValue AndAlso v.Value = False
   End Operator

   Public Shared Widening Operator CType(ByVal v As Boolean) As NullableBoolean
      Return New NullableBoolean(v)
   End Operator

   Public Shared Narrowing Operator CType(ByVal v As NullableBoolean) As Boolean
      If v.HasValue Then
         Return v.Value
      Else
         Throw New InvalidOperationException("Nullable objects must have a value")
      End If
   End Operator
End Structure
