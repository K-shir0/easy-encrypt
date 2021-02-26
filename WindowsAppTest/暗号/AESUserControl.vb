Imports System.Console
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class AESUserControl
    Dim EasyEncrypt As New EasyEncryptClass

    ' ロード時
    Private Sub DESUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' デモ用の初期表示
        IVTextBox.Text = "!QAZ2WSX#EDC4RFV"
        KeyTextBox.Text = "5TGB&YHN7UJM(IK<"

        ' ラジオボタン選択状態にする
        EncryptRadioButton.Select()
        IVInputRadioButton.Select()
        KeyInputRadioButton.Select()

        IVGenerateRadioButton_CheckedChanged(sender, e)
        PasswordInputRadioButton_CheckedChanged(sender, e)

        ' Passwordを削除をする
        Dim PassChar As Char = "*"

        PasswordTextBox.PasswordChar = PassChar
        RePasswordTextBox.PasswordChar = PassChar

        AddHandler Form1.SrcRichTextBox.TextChanged,
                AddressOf Encrypt

    End Sub


    ' 暗号化を実行
    Private Sub Encrypt()
        Dim Src As String = Form1.SrcRichTextBox.Text

        Dim IV, Key As String

        IV = IVTextBox.Text
        Key = KeyTextBox.Text
        Dim IVData, KeyData As Byte()

        ' IVを生成するか
        ' チェックのときIVを生成する。
        If IVGenerateRadioButton.Checked = True Then



        Else

            If Not IV.Length = 16 Then
                ' ポップアップエラー
                Exit Sub
            End If

            IVData = Encoding.UTF8.GetBytes(IV)

        End If

        ' Console.WriteLine("IV Length :" & Val(IVData.Length))

        If PasswordGroupBox.Enabled = True Then

            If PasswordTextBox.Text = RePasswordTextBox.Text Then
                KeyData = LengthFix(PasswordTextBox.Text)
            Else
                ' ポップアップエラー
                Exit Sub
            End If

        Else

            KeyData = Encoding.UTF8.GetBytes(Key)

        End If

        Console.WriteLine(Key.Length)

        If IsNothing(KeyData) Then
            Exit Sub
        End If


        If EncryptRadioButton.Checked Then
            ' 暗号化にチェックが入ってるとき
            ' DES に変換

            Form1.DstRichTextBox.Text = DES_Encode(Src, IVData, KeyData)
        Else
            ' 復号化にチェックが入っているとき

            ' IV自動生成にチェックが入ってるか
            If IVGenerateRadioButton.Checked = True Then

                ' 生成の時
                Form1.DstRichTextBox.Text = DES_Decode(Src, KeyData)

            Else

                ' 手入力の時
                Form1.DstRichTextBox.Text = DES_Decode(Src, IVData, KeyData)

            End If
        End If
    End Sub

    ' Encode
    Private Function DES_Encode(ByVal Text As String, ByVal IV As Byte(), ByVal Key As Byte()) As String

        Console.WriteLine("暗号化実行")

        ' 暗号化を実行
        Dim AES As New AesCryptoServiceProvider()

        AES.BlockSize = 128
        AES.KeySize = 128
        AES.Key = Key
        AES.Mode = CipherMode.CBC
        AES.Padding = PaddingMode.PKCS7

        ' IV の処理
        If Not IsNothing(IV) Then

            If IV.Length = 16 Then

                ' 自分で入力したとき
                AES.IV = IV

            Else

                ' 自動生成の時
                Console.WriteLine("IVが不正です Length :" & IV.Length)
                Exit Function

            End If
        End If

        Console.WriteLine(AES.Key.Length)

        ' 暗号化
        Dim ByteText As Byte()
        ByteText = Encoding.UTF8.GetBytes(Text)

        Using enc As ICryptoTransform = AES.CreateEncryptor()
            Dim dest As Byte() = enc.TransformFinalBlock(ByteText, 0, ByteText.Length)

            If Not IsNothing(IV) Then

            Else
                WriteLine(dest.Length)

                ' 自分で入力したとき

                dest = AES.IV.Concat(dest).ToArray

                WriteLine("接続：" & dest.Length)

                ShowByte(AES.IV)

            End If

            ' バイト型配列からBase64形式の文字列に変換
            Return Convert.ToBase64String(dest)
        End Using

    End Function

    ' Decode
    Private Function DES_Decode(ByVal Text As String, ByVal IV As Byte(), ByVal Key As Byte()) As String

        ' 鍵をバイト化
        Dim KeyData As Byte() = Key

        Dim IVData As Byte() = IV

        ' 暗号化を実行
        Dim AES As New AesCryptoServiceProvider()

        AES.BlockSize = 128
        AES.KeySize = 128
        If Not IsNothing(IV) Then
            AES.IV = IVData
        End If
        AES.Key = KeyData
        AES.Mode = CipherMode.CBC
        AES.Padding = PaddingMode.PKCS7

        Dim src As Byte()

        Try
            ' Base64形式の文字列からバイト型配列に変換
            src = System.Convert.FromBase64String(Text)

            ' 複号化する
            Using dec As ICryptoTransform = AES.CreateDecryptor()

                Dim dest As Byte() = dec.TransformFinalBlock(src, 0, src.Length)
                Return Encoding.UTF8.GetString(dest)

            End Using
        Catch ex As Exception
            Return "Error"
        End Try

    End Function

    Private Function DES_Decode(ByVal Text As String, ByVal Key As Byte()) As String

        Dim src As Byte()
        Dim IVData(15) As Byte

        ' Base64 に戻すことできなければError
        Try

            ' Base64形式の文字列からバイト型配列に変換
            src = System.Convert.FromBase64String(Text)

            ' 鍵の取り出し
            For I As Integer = 0 To IVData.Length - 1
                IVData(I) = src(I)
            Next

            ' 16bit 切り離し
            Console.WriteLine("鍵は取り出されました" & src.Length)

            src = src.Skip(16).Take(src.Length - 16).ToArray()

            Console.WriteLine("鍵は取り出されました" & src.Length)

            ShowByte(IVData)
            ShowByte(src)

        Catch ex As Exception
            Return "Base64 が不正"
        End Try

        ' 鍵をバイト化
        Dim KeyData As Byte() = Key

        ' 暗号化を実行
        Dim AES As New AesCryptoServiceProvider()

        AES.BlockSize = 128
        AES.KeySize = 128
        AES.IV = IVData
        AES.Key = KeyData
        AES.Mode = CipherMode.CBC
        AES.Padding = PaddingMode.PKCS7


        ' 復号化できなければError
        ' 複号化する
        Using dec As ICryptoTransform = AES.CreateDecryptor()
            'Try
            Dim dest As Byte() = dec.TransformFinalBlock(src, 0, src.Length)
            Return Encoding.UTF8.GetString(dest)

        End Using

    End Function


    Private Function LengthFix(ByVal Text As String) As Byte()

        ' 鍵とIVをバイト化
        ' 鍵長を16に加工
        Dim Rfc2898DeriveBytes As New Rfc2898DeriveBytes(Text, 16)
        Dim Solt(16) As Byte
        Solt = Rfc2898DeriveBytes.Salt

        Dim KeyData(16) As Byte
        KeyData = Solt

        Return KeyData

    End Function

    ' EncrytptRadioButton を押したとき
    ' Private Sub EncryptRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles EncryptRadioButton.CheckedChanged
    '    Encrypt()
    ' End Sub

    Private Sub DESUserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        ' ハンドラを削除
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
             AddressOf Encrypt

    End Sub

    Private Sub PasswordInputRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles PasswordInputRadioButton.CheckedChanged

        If PasswordInputRadioButton.Checked = True Then

            PasswordGroupBox.Enabled = True
            KeyGroupBox.Enabled = False

        Else

            PasswordGroupBox.Enabled = False
            KeyGroupBox.Enabled = True

        End If

    End Sub

    Private Sub IVGenerateRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles IVGenerateRadioButton.CheckedChanged

        If IVGenerateRadioButton.Checked = True Then

            IVTextBox.Enabled = False

        Else

            IVTextBox.Enabled = True

        End If


    End Sub


    Public Sub ShowByte(ByVal ByteData As Byte())

        WriteLine("表示" & ByteData.ToString)

        For Each data As Byte In ByteData
            WriteLine(data.ToString)
        Next


    End Sub

End Class
