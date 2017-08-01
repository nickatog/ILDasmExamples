Public Module Enumeration
    Public Sub PrintNumbers(
        ByVal numbers As IEnumerable(Of Integer))

        ' For Each loops can be used with any IEnumerable data source
        ' This loop will get compiled to the following actions:
        ' - A call to numbers.GetEnumerator() (and the hidden variable to store the result)
        ' - A call to the IEnumerator.Current property to retrive the current value and store it in the number variable
        ' - A call to the IEnumerator.MoveNext() method to advance the position of the enumerator
        ' - A conditional branch to exit the loop when IEnumerator.MoveNext() returns false
        For Each number As Integer In numbers
            Console.WriteLine(number)
        Next
    End Sub
End Module
