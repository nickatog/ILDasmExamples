Public Module Existence
    Public Sub Main()
        ' IsNothing() looks like a function, and actually compiles to one, so it's best practice to avoid it and use the keywords instead
        Dim item As String = Nothing

        Dim result As Boolean = False

        result = IsNothing(item)

        result = item Is Nothing
    End Sub
End Module
