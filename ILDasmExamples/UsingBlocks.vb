Public Module UsingBlocks
    Public Sub Main()
        ' Using blocks can be used with any IDisposable object, and handle some tedious actions automatically and safely:
        ' - Implicitly wraps the body in a try..finally
        ' - Inside the finally block, calls IDisposable.Dispose() on the object if it's not null
        Using output As New IO.FileStream("C:\test.txt", IO.FileMode.Create)
            ' Do something with the stream
            Console.WriteLine(output.CanWrite)
        End Using
    End Sub
End Module
