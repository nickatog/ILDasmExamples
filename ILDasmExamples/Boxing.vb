Public Module Boxing
    Public Sub Main()
        ' A pre-2.0 list collection
        ' Objects contained within are of type Object
        Dim oldList As New ArrayList()
        ' If we add an integer to the list, it'll get converted (boxed) to a reference type first because it's a primitive
        oldList.Add(1)
        ' Accessing an item from the list and assigning it to an integer variable will incur additional conversion overhead
        Dim oldVariable As Integer = oldList(0)

        ' A generic list (introduced in 2.0) of integers
        Dim newList As New List(Of Integer)()
        ' This list can only contain integers instead of objects of all types, but we get better type safety for method parameters with it
        newList.Add(1)
        ' Indexing the list and storing the value in a variable is now a simple assignment operation
        Dim newVariable As Integer = newList(0)

        ' Boxing can also happen when some methods are called on instances of value types, but there are some safety checks built-in
        ' Here's an object (reference type) to compare with
        Dim testReference As New Object()
        ' And an instance of a structure (a value type)
        Dim testValue As New TestValueType()

        testReference.GetType()
        ' GetType() is inherited from Object (a reference type) and isn't virtual, so the value gets boxed here 100% of the time
        testValue.GetType()

        testReference.ToString()
        ' ToString() is inherited from Object and is virtual, so the value type might have an override for it, but it may not
        ' The CLR's implementation of 'callvirt' can be constrained to a given type to check for this override, and box if necessary
        testValue.ToString()

        Dim timer1 As Stopwatch = Stopwatch.StartNew()
        For count As Integer = 1 To 1000000
            testValue.GetHashCode()
        Next
        timer1.Stop()

        Dim testValueFast As New TestValueTypeFast()
        Dim timer2 As Stopwatch = Stopwatch.StartNew()
        For count As Integer = 1 To 1000000
            testValueFast.GetHashCode()
        Next
        timer2.Stop()

        Console.WriteLine(
            "TestValueType ({1}) vs. TestValueTypeFast ({3})",
            testValue,
            timer1.Elapsed.TotalSeconds,
            testValueFast,
            timer2.Elapsed.TotalSeconds)
    End Sub

    Public Structure TestValueType
    End Structure

    Public Structure TestValueTypeFast
        Public Overrides Function GetHashCode() As Integer
            Return 1
        End Function
    End Structure
End Module
