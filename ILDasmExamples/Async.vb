Public Module Async
    Public Sub Main()
        DoStuffAsync().Wait()
    End Sub

    Public Async Function DoStuffAsync() As Task
        Await Task.Delay(1000)
    End Function
End Module
