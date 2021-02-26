Public Class CaesarCipherUserControl
    ' ロード時
    Private Sub CaesarCipherUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AssortmentComboBox.SelectedIndex = 0
        AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf SrcRichTextBox_TextChanged
    End Sub


    Private Sub SrcRichTextBox_TextChanged(sender As Object, e As EventArgs)
        Encode()
    End Sub


    Private Sub Encode()
        Dim Src As String = Form1.SrcRichTextBox.Text ' ソーステキスト
        Dim Shift As Integer

        If IsNumeric(Val(ShiftTextBox.Text)) Then
            Shift = Val(ShiftTextBox.Text) Mod 27 ' シフトするテキスト
        Else
            ' Todo エラーを記述
        End If

        Dim Dst As String ' 排出テキスト
        Dst = Encrypt(Src, Shift)

        Form1.DstRichTextBox.Text = Dst
    End Sub


    ''' <summary>
    ''' 文字列を1文字分割、配列に入れて返す
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <returns>文字配列</returns>
    Public Function ToLetters(ByVal Text As String)
        Dim Length As Integer = Text.Length

        Dim letters(Length) As String

        For I As Integer = 0 To Length - 1

            letters(I) = Text(I)

        Next

        Return letters
    End Function


    Private Function Encrypt(ByVal Text As String, ByVal Shift As Integer)
        Dim Length As Integer = Text.Length
        Dim letters() As String
        Dim afterText As String = ""
        Dim shiftedLetter As Char
        Dim shiftNumber As Integer = Shift Mod 27

        ' 文字配列化する
        letters = ToLetters(Text)


        For I As Integer = 0 To Length - 1

            ' 正規表現でアルファべットか判別
            ' アルファベットの時1文字ずらす
            If (System.Text.RegularExpressions.Regex.IsMatch(letters(I), "[a-z]")) Then

                Dim ascii As String = Asc(letters(I))
                Dim shiftedAscii As Integer = (ascii + Shift) Mod 123

                If (shiftedAscii < 97) Then
                    shiftedAscii += 97
                End If

                shiftedLetter = Convert.ToChar(shiftedAscii)

                ' 大文字のとき
            ElseIf (System.Text.RegularExpressions.Regex.IsMatch(letters(I), "[A-Z]")) Then

                Dim ascii As String = Asc(letters(I))
                Dim shiftedAscii As Integer = (ascii + Shift) Mod 91

                If (shiftedAscii < 65) Then
                    shiftedAscii += 65
                End If

                shiftedLetter = Convert.ToChar(shiftedAscii)

            Else

                shiftedLetter = letters(I)

            End If

            afterText &= Convert.ToString(shiftedLetter)
        Next

        Return afterText
    End Function


    ' Mode 変更時
    Private Sub AssortmentComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles AssortmentComboBox.SelectedIndexChanged

        Select Case AssortmentComboBox.SelectedIndex
            Case 1
                ' ROT13 選択時
                ShiftTextBox.Text = 13
                ShiftTextBox.Enabled = False
            Case Else
                ShiftTextBox.Enabled = True
        End Select

        ' 結果を反映
        Encode()

    End Sub



    Private Sub BruteforceButtonCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BruteforceButtonCheckBox.CheckedChanged
        If BruteforceButtonCheckBox.Checked Then
            ' 有効化の時

            ' ハンドラを削除
            RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf SrcRichTextBox_TextChanged

            ' Bruteforce を有効化
            AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Bruteforce

            ' 無効化
            AssortmentComboBox.Enabled = False
            ShiftTextBox.Enabled = False

            Bruteforce(sender, e)
        Else
            ' 無効の時
            ' ハンドラを有効化
            AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf SrcRichTextBox_TextChanged

            ' Bruteforce を無効化
            RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Bruteforce

            ' 有効化
            AssortmentComboBox.Enabled = True
            ShiftTextBox.Enabled = True

            ' 結果を反映
            Encode()
        End If
    End Sub


    Private Sub Bruteforce(sender As Object, e As EventArgs)
        Dim Src As String = Form1.SrcRichTextBox.Text ' ソーステキスト
        Dim Length As Integer = Form1.SrcRichTextBox.Lines.Length

        ' 結果のテキストボックスをクリア
        Form1.DstRichTextBox.Clear()

        If (Length <= 1) Then
            For I As Integer = 25 To 0 Step -1

                Form1.DstRichTextBox.Text &= "(" & I & ") = " & vbTab & Encrypt(Src, I) & Environment.NewLine

            Next
        Else
            For I As Integer = 25 To 0 Step -1

                Form1.DstRichTextBox.Text &= "(" & I & ") = {" & Environment.NewLine & Encrypt(Src, I) _
                    & Environment.NewLine & "}" & Environment.NewLine

            Next

        End If
    End Sub

    ' Shift を変更したとき
    Private Sub ShiftTextBox_TextChanged(sender As Object, e As EventArgs) Handles ShiftTextBox.TextChanged
        ' 結果を反映
        Encode()
    End Sub

    ' 抜けるとき
    Private Sub CaesarCipherUserControl_Leave(sender As Object, e As EventArgs) Handles Me.Disposed

        ' ハンドラを削除
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
        AddressOf SrcRichTextBox_TextChanged
        RemoveHandler Form1.SrcRichTextBox.TextChanged,
        AddressOf Bruteforce

    End Sub

End Class