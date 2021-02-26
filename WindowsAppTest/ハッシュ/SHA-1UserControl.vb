Public Class SHA_1UserControl
    Dim EasyEncrypt As New EasyEncryptClass

    Private Sub SHA_1UserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

        Encrypt()
    End Sub

    ' メモリ開放されたとき
    Private Sub SHA_1UserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

    End Sub

    Private Sub Encrypt()

        ' DstにSrcを改変したものをセットする
        EasyEncrypt.SetDstText(SHA_1Encode(EasyEncrypt.GetSrcText))

    End Sub

    Private Function SHA_1Encode(ByVal Text As String) As String

        ' バイト配列化
        Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)
        Dim sha_1 As New System.Security.Cryptography.SHA1CryptoServiceProvider()

        Dim hashValue As Byte() = sha_1.ComputeHash(data)

        ' byte 16進数に変換
        Dim result As New System.Text.StringBuilder()
        Dim b As Byte
        For Each b In hashValue
            result.Append(b.ToString("x2"))
        Next

        Return result.ToString

    End Function
End Class
