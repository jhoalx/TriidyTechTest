Public Class GreatherThan
    Public num1 As Int32
    Public num2 As Int32
    Public num3 As Int32
    Public num4 As Int32
    Public num5 As Int32

    Public Function getHighestNumber()
        Dim nums = New Integer() {num1, num2, num3, num4, num5}
        Return nums.Max
    End Function
End Class
