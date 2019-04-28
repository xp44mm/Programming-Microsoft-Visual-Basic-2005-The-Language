Module Module1

    Sub Main()

        'FieldBenchmark()
        'TestByRefProperty()
        'TestGlobalsClass()
        'TestStaticConstructor()
        'TestOperatorOverloading()
        'TestConversions()
    End Sub

    Sub FieldBenchmark()
        Dim test As New Test
        test.RunBenchmark()
    End Sub

    Sub TestByRefProperty()
        Dim vc As New ValueClass
        vc.DoubleValue = 100
        ClearValue(vc.DoubleValue)
        ' Show that the method actually changed the property.
        Console.WriteLine(vc.DoubleValue)            ' => 0

        vc.DoubleValue += 10
        ' Show that the property was actually incremented.
        Console.WriteLine(vc.DoubleValue)            ' => 10
    End Sub

    Sub TestGlobalsClass()
        Globals.Value.UserName = "Francesco"
        ' Assign two items to the Documents array.
        Globals.Value.Documents = New String() {"c:\doc1.txt", "c:\doc2.txt"}
        ' Save current global variables on disk.
        Globals.Save("globals.xml")
    End Sub

    Sub TestStaticConstructor()
        Dim td1 As TextDocument = TextDocument.Create(11, "d:\foo.txt")
        Dim td2 As TextDocument = TextDocument.Create(22, "d:\bar.txt")

        Try
            ' Next statement throws an exception
            Dim td3 As TextDocument = TextDocument.Create(33, "d:\foobar.txt")
        Catch ex As Exception
            Console.WriteLine("ERROR: {0}", ex.Message)
        End Try

        ' Nest statement returns an instance of the first document
        Dim td4 As TextDocument = TextDocument.Create(11, "d:\foo.txt")
        Console.WriteLine(td1 Is td4)
    End Sub

    Sub TestOperatorOverloading()
        ' Prove that a fraction is always stored in normalized (simplified) format.
        Dim f As New Fraction(2, 10)
        Console.WriteLine(f)              ' => 1/5

        Dim f1 As New Fraction(2, 5)
        Dim f2 As New Fraction(1, 10)
        Console.WriteLine(f1 + f2)      ' => 1/2
        Console.WriteLine(f1 - f2)      ' => 3/10
        Console.WriteLine(f1 * f2)      ' => 1/25
        Console.WriteLine(f1 / f2)      ' => 4

        ' Another way to perform fraction addition
        Dim result As Fraction = Fraction.op_Addition(f1, f2)

    End Sub

    Sub TestConversions()
        ' Conversions from Long to Fraction don't require an explicit operator.
        Dim f As Fraction = 123

        ' Conversions from Fraction to Long do require an explicit operator
        ' (if Option Strict is On).
        Dim f2 As New Fraction(12, 5)
        ' Both n1 and n2 are assigned the value 2 (= 12 \ 5).
        ' Note that both CType and CLng operators are supported.
        Dim n1 As Long = CType(f2, Long)
        Dim n2 As Long = CLng(f2)

    End Sub

End Module
