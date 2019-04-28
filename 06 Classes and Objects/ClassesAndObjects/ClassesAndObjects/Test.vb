Class Test
    Public publicField As Integer

    Sub RunBenchmark()
        Dim sw As New Stopwatch()
        sw.Start()
        For i As Integer = 1 To 1000000000
            publicField += 1
        Next
        sw.Stop()
        Console.WriteLine("Public field: {0} msecs", sw.ElapsedMilliseconds)

        Dim localVar As Integer
        sw = New Stopwatch()
        sw.Start()
        For i As Integer = 1 To 1000000000
            localVar += 1
        Next
        sw.Stop()
        Console.WriteLine("Local variable: {0} msecs", sw.ElapsedMilliseconds)

        Console.WriteLine("Total = {0}", publicField + localVar)
    End Sub

End Class
