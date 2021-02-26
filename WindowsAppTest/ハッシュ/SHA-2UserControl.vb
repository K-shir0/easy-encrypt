Public Class SHA_2UserControl
    Dim EasyEncrypt As New EasyEncryptClass

    Private Sub SHA_2UserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ComboBox ﾃﾞﾌｫﾙﾄ指定
        AssortmentComboBox.SelectedIndex = 0


        AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

        Encrypt()
    End Sub

    ' メモリ開放されたとき
    Private Sub SHA_2UserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

    End Sub

    Private Sub Encrypt()

        ' DstにSrcを改変したものをセットする
        EasyEncrypt.SetDstText(SHA_2Encode(EasyEncrypt.GetSrcText))

    End Sub

    Public Function SHA_2Encode(ByVal Text As String) As String

        ' バイト配列化
        Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)
        Dim sha_2 As Object

        Select Case AssortmentComboBox.SelectedIndex
            Case 0
                ' 512
                sha_2 = New System.Security.Cryptography.SHA512CryptoServiceProvider()
            Case 1
                ' 384
                sha_2 = New System.Security.Cryptography.SHA384CryptoServiceProvider()
            Case 2
                ' 256
                sha_2 = New System.Security.Cryptography.SHA256CryptoServiceProvider()

                ' test code
                Dim sha__2 As New SHA_2

                Console.WriteLine("sha__2 実行")

                ' Dim Datas As Integer() = (sha__2.Encode(System.Text.Encoding.UTF8.GetBytes("test")))
                Dim Datas As Long() = (sha__2.Encode())

                For Each Datae As Long In Datas
                    Console.WriteLine("Datae" & Datae)
                Next

                ' test code end

                Console.WriteLine(Hex(Datas(0)) & Hex(Datas(1)) & Hex(Datas(2)) & Hex(Datas(3)) & Hex(Datas(4)) & Hex(Datas(5)) & Hex(Datas(6)) & Hex(Datas(7)))
            Case Else
                ' Default
                sha_2 = New System.Security.Cryptography.SHA512CryptoServiceProvider()
        End Select

        Dim hashValue As Byte() = sha_2.ComputeHash(data)

        ' byte 16進数に変換
        Dim result As New System.Text.StringBuilder()
        Dim b As Byte
        For Each b In hashValue
            result.Append(b.ToString("x2"))
        Next

        Return result.ToString

    End Function

    Private Sub AssortmentComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AssortmentComboBox.SelectedIndexChanged
        Encrypt()
    End Sub
End Class
