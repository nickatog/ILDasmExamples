Public Module Async
    Public Sub Main()
        DoStuffAsync().Wait()
    End Sub

    ' Async methods undergo some heavy compilation magic in order to look like a Task object to callers
    ' Similar to lambda functions, an anonymous class will be generated to represent the body of the method
    ' However, the class works like a state machine, and defines a MoveNext() method that is used to progress through the original method body
    Public Async Function DoStuffAsync() As Task
        Await Task.Delay(1000)
    End Function
End Module
