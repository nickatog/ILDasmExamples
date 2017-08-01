Public Module Strings
    Public Sub Main()
        ' Concatenated literal strings will be optimized into a single pooled string instead
        Dim text As String =
            "This " &
            "is " &
            "a " &
            "sentence " &
            "on " &
            "many " &
            "lines."

        Console.WriteLine(
            "String: ""{0}""{1}Interned: ""{2}""",
            text,
            vbCrLf,
            String.IsInterned(text))

        ' Using a StringBuilder to re-create one of the individual lines of text from above, we can see that they aren't all interned
        Dim word As New Text.StringBuilder()
        For Each character As String In {"l", "i", "n", "e", "s", "."}
            word.Append(character)
        Next

        Console.WriteLine()
        Console.WriteLine(
            "String: ""{0}""{1}Interned: ""{2}""",
            word.ToString(),
            vbCrLf,
            String.IsInterned(word.ToString()))
    End Sub
End Module
