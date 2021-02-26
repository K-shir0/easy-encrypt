Public MustInherit Class Encryption
    Public MustOverride Function Encode(ByVal Data As Byte()) As String
    Public MustOverride Function Decode(ByVal Text As String) As Byte()
End Class
