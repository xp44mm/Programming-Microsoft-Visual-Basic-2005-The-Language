Imports System.Text.RegularExpressions

Public Class PokerGame

   ' Take an array of five strings, each one corresponding to a card in a poker hand. 
   ' Returns one of the following strings:
   '     StraightFlush, FourOfAKind, FullHouse, Flush, Straight, 
   '     ThreeOfAKind, TwoPairs, OnePair, HighCard
   ' Cards are encoded as two-char strings, in the format value/suit.
   ' Valid value chars are 1,2,3,4,5,6,7,8,9,T,J,Q,K  (T means Ten).
   ' Valid suit chars are H,D,C,S  (for Hearts,Diamonds,Clubs, and Spades)
   ' Input arguments are assumed to be validated already.

   Public Shared Function EvalPokerScore(ByVal ParamArray cards() As String) As String
      ' Sort the array and create the sequence of values and of suits.
      Array.Sort(cards)
      Dim values As String = cards(0)(0) + cards(1)(0) + cards(2)(0) + cards(3)(0) + cards(4)(0)
      Dim suits As String = cards(0)(1) + cards(1)(1) + cards(2)(1) + cards(3)(1) + cards(4)(1)

      ' Check each sequence in order.
      If Regex.IsMatch(values, "12345|23456|34567|45678|56789|6789T|789JT|89JQT" _
         & "|9JKQT|1JKQT") AndAlso Regex.IsMatch(suits, "(.)\1\1\1\1") Then
         Return "StraightFlush"
      ElseIf Regex.IsMatch(values, "(.)\1\1\1") Then
         Return "FourOfAKind"
      ElseIf Regex.IsMatch(values, "(.)\1\1(.)\2|(.)\3(.)\4\4") Then
         Return "FullHouse"
      ElseIf Regex.IsMatch(suits, "(.)\1\1\1\1") Then
         Return "Flush"
      ElseIf Regex.IsMatch(values, "12345|23456|34567|45678|56789|6789T|789JT|89JQT" _
         & "|9JKQT|1JKQT") Then
         Return "Straight"
      ElseIf Regex.IsMatch(values, "(.)\1\1") Then
         Return "ThreeOfAKind"
      ElseIf Regex.IsMatch(values, "(.)\1(.)\2") Then
         Return "TwoPairs"
      ElseIf Regex.IsMatch(values, "(.)\1") Then
         Return "OnePair"
      Else
         Return "HighCard"
      End If
   End Function

   Public Shared Function EvalPokerScore2(ByVal ParamArray cards() As String) As String
      ' Sort the array and create the sequence of values and of suits.
      Array.Sort(cards)
      Dim values As String = cards(0)(0) + cards(1)(0) + cards(2)(0) + cards(3)(0) + cards(4)(0)
      Dim suits As String = cards(0)(1) + cards(1)(1) + cards(2)(1) + cards(3)(1) + cards(4)(1)
      Dim scores(,) As String = { _
         {"12345|23456|34567|45678|56789|6789T|789JT|89JQT|9JKQT|1JKQT", "(.)\1\1\1\1", "StraightFlush"}, _
         {"(.)\1\1\1", ".", "FourOfAKind"}, _
         {"(.)\1\1(.)\2|(.)\3(.)\4\4", ".", "FullHouse"}, _
         {".", "(.)\1\1\1\1", "Flush"}, _
         {"12345|23456|34567|45678|56789|6789T|789JT|89JQT|9JKQT|1JKQT", ".", "Straight"}, _
         {"(.)\1\1", ".", "ThreeOfAKind"}, _
         {"(.)\1.?(.)\2", ".", "TwoPairs"}, _
         {"(.)\1", ".", "OnePair"}}
      For i As Integer = 0 To scores.GetUpperBound(0)
         If Regex.IsMatch(values, scores(i, 0)) AndAlso Regex.IsMatch(suits, scores(i, 1)) Then
            Return scores(i, 2)
         End If
      Next
      Return "HighCard"
   End Function

End Class
