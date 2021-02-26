' 参考文献
' Wikipedia (日本語よりこっちのほうがわかりやすかった)
' https://en.wikipedia.org/wiki/MD5


Public Class MD5

    ' ラウンドごとのローテーション量
    Dim P As Integer() = {
            7, 12, 17, 22,
            7, 12, 17, 22,
            7, 12, 17, 22,
            7, 12, 17, 22,
            5, 9, 14, 20,
            5, 9, 14, 20,
            5, 9, 14, 20,
            5, 9, 14, 20,
            4, 11, 16, 23,
            4, 11, 16, 23,
            4, 11, 16, 23,
            4, 11, 16, 23,
            6, 10, 15, 21,
            6, 10, 15, 21,
            6, 10, 15, 21,
            6, 10, 15, 21
    }

    ' キーテーブル
    Dim K As UInteger() = {
            &HD76AA478UI, &HE8C7B756UI, &H242070DBUI, &HC1BDCEEEUI,
            &HF57C0FAFUI, &H4787C62AUI, &HA8304613UI, &HFD469501UI,
            &H698098D8UI, &H8B44F7AFUI, &HFFFF5BB1UI, &H895CD7BEUI,
            &H6B901122UI, &HFD987193UI, &HA679438EUI, &H49B40821UI,
            &HF61E2562UI, &HC040B340UI, &H265E5A51UI, &HE9B6C7AAUI,
            &HD62F105DUI, &H_2441453UI, &HD8A1E681UI, &HE7D3FBC8UI,
            &H21E1CDE6UI, &HC33707D6UI, &HF4D50D87UI, &H455A14EDUI,
            &HA9E3E905UI, &HFCEFA3F8UI, &H676F02D9UI, &H8D2A4C8AUI,
            &HFFFA3942UI, &H8771F681UI, &H6D9D6122UI, &HFDE5380CUI,
            &HA4BEEA44UI, &H4BDECFA9UI, &HF6BB4B60UI, &HBEBFBC70UI,
            &H289B7EC6UI, &HEAA127FAUI, &HD4EF3085UI, &H_4881D05UI,
            &HD9D4D039UI, &HE6DB99E5UI, &H1FA27CF8UI, &HC4AC5665UI,
            &HF4292244UI, &H432AFF97UI, &HAB9423A7UI, &HFC93A039UI,
            &H655B59C3UI, &H8F0CCC92UI, &HFFEFF47DUI, &H85845DD1UI,
            &H6FA87E4FUI, &HFE2CE6E0UI, &HA3014314UI, &H4E0811A1UI,
            &HF7537E82UI, &HBD3AF235UI, &H2AD7D2BBUI, &HEB86D391UI
        }


    ' 左にローテーションする
    Function LeftRotate(ByVal X As UInteger, ByVal Y As UInteger) As UInteger
        Return (X << Y) Or (X >> (32 - Y))
    End Function


    ' 計算部
    Public Function Compute(ByVal Data As Byte()) As String
        Console.WriteLine("MD5 計算開始")

        Dim DataLength As Integer = Data.Length

        ' 初期値
        ' UInteger じゃないと先頭8以上がマイナスとして処理されるのでLongはダメな模様
        Dim INIT_a As UInteger = &H67452301UI
        Dim INIT_b As UInteger = &HEFCDAB89UI
        Dim INIT_c As UInteger = &H98BADCFEUI
        Dim INIT_d As UInteger = &H10325476UI

        ' パディングで追加する長さを調べる
        Dim AddLength As Integer = (56 - ((DataLength + 1) Mod 64)) Mod 64
        Dim AddedArray(DataLength + AddLength + 8) As Byte ' 型
        Array.Copy(Data, AddedArray, DataLength)
        ' １ビット付与
        AddedArray(DataLength) = &H80

        Dim Length As Byte() = BitConverter.GetBytes(DataLength * 8)
        Array.Copy(Length, 0, AddedArray, AddedArray.Length + -8, 4)

        ' マスクしてオーバーフローしないようにする
        Dim Mask As UInteger = UInteger.MaxValue

        For I As Integer = 0 To (AddedArray.Length / 64) - 1

            Dim M(16 - 1) As UInteger
            For J As Integer = 0 To M.Length - 1
                M(J) = BitConverter.ToUInt32(AddedArray, (I * 64) + J * 4)
            Next

            ' 初期化
            Dim a As UInteger = INIT_a
            Dim b As UInteger = INIT_b
            Dim c As UInteger = INIT_c
            Dim d As UInteger = INIT_d
            Dim f As UInteger = 0
            Dim g As UInteger = 0

            ' メインループ
            For J As UInteger = 0 To 64 - 1

                ' 決められている計算式で計算する
                Select Case J
                    Case 0 To 15
                        f = (b And c) Or ((Not b) And d)
                        g = J
                    Case 16 To 31
                        f = (d And b) Or ((Not d) And c)
                        g = ((5 * J) + 1) Mod 16
                    Case 32 To 47
                        f = b Xor c Xor d
                        g = ((3 * J) + 5) Mod 16
                    Case 48 To 64
                        f = c Xor (b Or (Not d))
                        g = (7 * J) Mod 16
                End Select

                Dim dTemp As UInteger = d
                d = c
                c = b
                b = CULng(b) + LeftRotate((CULng(a) + CULng(f) + CULng(K(J)) + CULng(M(g))) And Mask, P(J)) And Mask
                a = dTemp

            Next

            ' 
            INIT_a = (CULng(INIT_a) + CULng(a)) And Mask
            INIT_b = (CULng(INIT_b) + CULng(b)) And Mask
            INIT_c = (CULng(INIT_c) + CULng(c)) And Mask
            INIT_d = (CULng(INIT_d) + CULng(d)) And Mask

        Next

        Dim Hash As String = (GetByteString(INIT_a) & GetByteString(INIT_b) & GetByteString(INIT_c) & GetByteString(INIT_d))

        Console.WriteLine("MD5 計算終了" & " Hash: " & Hash)

        Return Hash
    End Function


    ''' <summary>
    ''' リトルエンディアンで16進数に戻す
    ''' </summary>
    ''' <param name="X">UInteger</param>
    ''' <returns>String</returns>
    Function GetByteString(ByVal X As UInteger) As String
        Dim result As New System.Text.StringBuilder()

        Dim bs As Byte() = BitConverter.GetBytes(X)

        For Each b In bs
            result.Append(b.ToString("x2"))
        Next

        Return result.ToString
    End Function


    ' 実行部
    Public Function Encode(ByVal Text As String) As String

        ' 文字列をByte()に変換
        Dim Data As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)

        Dim md5 As New MD5
        Return md5.Compute(Data)

    End Function

End Class
