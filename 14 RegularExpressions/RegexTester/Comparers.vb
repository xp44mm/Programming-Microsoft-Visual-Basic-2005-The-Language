Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class AlphaComparer
   Implements IComparer(Of Match)

   Public Function Compare(ByVal x As System.Text.RegularExpressions.Match, ByVal y As System.Text.RegularExpressions.Match) As Integer Implements System.Collections.Generic.IComparer(Of System.Text.RegularExpressions.Match).Compare
      Return String.Compare(x.Value, y.Value, True)
   End Function
End Class

Public Class ShortestComparer
   Implements IComparer(Of Match)

   Public Function Compare(ByVal x As System.Text.RegularExpressions.Match, ByVal y As System.Text.RegularExpressions.Match) As Integer Implements System.Collections.Generic.IComparer(Of System.Text.RegularExpressions.Match).Compare
      Return x.Length.CompareTo(y.Length)
   End Function
End Class

Public Class LargestComparer
   Implements IComparer(Of Match)

   Public Function Compare(ByVal x As System.Text.RegularExpressions.Match, ByVal y As System.Text.RegularExpressions.Match) As Integer Implements System.Collections.Generic.IComparer(Of System.Text.RegularExpressions.Match).Compare
      Return y.Length.CompareTo(x.Length)
   End Function
End Class

