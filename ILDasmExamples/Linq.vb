Public Module Linq
    Public Sub SortOddNumbers(
        ByVal numbers As IEnumerable(Of Integer))

        ' LINQ query syntax looks simple on the surface, but really maps to a set of extension methods during compilation
        ' This query results in 3 extension method calls (each of which takes the results of the previous calls as input to the next):
        ' - IEnumerable.Where()
        ' - IEnumerable.Select()
        ' - IEnumerable.OrderBy()
        ' Each method also takes a delegate as a parameter, which are created from anonymous functions defined at compile-time
        Dim sortedNumbers =
            From number As Integer In numbers
            Where number Mod 2 = 1
            Select number
            Order By number
    End Sub
End Module
