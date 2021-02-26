Public Class Base64UserControl

    ' ロード時
    Private Sub Base64UserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ラジオボタン初期化
        EncryptRadioButton.Checked = True

        AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt



    End Sub

    ' Main
    Private Sub Encrypt()

        Dim Src As String = Form1.SrcRichTextBox.Text

        If EncryptRadioButton.Checked Then
            ' 暗号化にチェックが入ってるとき

            ' Base64 に変換
            Form1.DstRichTextBox.Text = Base64_Encode(Src)

        Else
            ' 復号化のとき

            ' テキストに戻す
            Form1.DstRichTextBox.Text = Base64_Decode(Src)
        End If

    End Sub

    Dim base64 As New Base64()

    ' エンコード
    Private Function Base64_Encode(ByVal Text As String) As String
        ' Base64 encode
        ' Text をByte に変換
        Dim Data As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)

        Return base64.Encode(Data)

    End Function

    ' デコード
    Private Function Base64_Decode(ByVal Text As String) As String
        Dim DstText As String = ""
        Dim Data As Byte() = base64.Decode(Text)

        Try
            DstText = System.Text.Encoding.UTF8.GetString(Data)
        Catch ex As Exception
            Return "Error"
        End Try

        Return DstText

    End Function

    Private Sub EncryptRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles EncryptRadioButton.CheckedChanged
        Encrypt()
    End Sub

    ' 消すとき
    Private Sub Base64UserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        ' ハンドラを削除
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

    End Sub
End Class
