Imports System.Console
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text


Public Class DESUserControl
    Dim EasyEncrypt As New EasyEncryptClass

    ' ロード時
    Private Sub DESUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ラジオボタン
        EncryptRadioButton.Select()

        AddHandler Form1.SrcRichTextBox.TextChanged,
                AddressOf Encrypt

    End Sub

    Private Sub Encrypt()
        Dim Src As String = Form1.SrcRichTextBox.Text

        If EncryptRadioButton.Checked Then
            ' 暗号化にチェックが入ってるとき
            ' DES に変換

            Form1.DstRichTextBox.Text = DES_Encode(Src, "!QAZ2WSX#EDC4RFV", "5TGB&YHN7UJM(IK<")

        Else
            Form1.DstRichTextBox.Text = DES_Decode(Src)
        End If
    End Sub

    ' Encode
    Private Function DES_Encode(ByVal Text As String, ByVal IV As String, ByVal Key As String) As String

        ' バイトに変換
        Dim Data As Byte() = EasyEncrypt.ToByte(Text)

        Dim DES As New AesCryptoServiceProvider()

        DES.BlockSize = 128
        DES.KeySize = 128
        DES.IV = Encoding.UTF8.GetBytes(IV)
        DES.Key = Encoding.UTF8.GetBytes(Key)
        DES.Mode = CipherMode.CBC
        DES.Padding = PaddingMode.PKCS7

        ' 暗号化
        Using enc As ICryptoTransform = DES.CreateEncryptor()
            Dim dest As Byte() = enc.TransformFinalBlock(Data, 0, Data.Length)

            ' バイト型配列からBase64形式の文字列に変換
            Return Convert.ToBase64String(dest)
        End Using

    End Function

    Private Function DES_Decode(ByVal Text As String) As String

    End Function

    Private Sub EncryptRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles EncryptRadioButton.CheckedChanged
        Encrypt()
    End Sub

    Private Sub DESUserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        ' ハンドラを削除
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
             AddressOf Encrypt

    End Sub
End Class