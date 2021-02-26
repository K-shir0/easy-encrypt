' 参考文献
' Secure Hash Standard (SHS)
' https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.180-4.pdf
' WikiPedia
' https://ja.wikipedia.org/wiki/SHA-2

Public Class SHA_2
    ' Initial Hash Value ハッシュ初期値
    Dim IHV As Long() = {
            &H6A09E667UI, &HBB67AE85UI, &H3C6EF372UI, &HA54FF53AUI, &H510E527FUI, &H9B05688CUI, &H1F83D9ABUI, &H5BE0CD19UI
        }

    ' Constants ハッシュ計算時に使用する初期値
    Dim K As UInteger() = {
            &H428A2F98UI, &H71374491UI, &HB5C0FBCFUI, &HE9B5DBA5UI, &H3956C25BUI, &H59F111F1UI, &H923F82A4UI, &HAB1C5ED5UI,
            &HD807AA98UI, &H12835B01UI, &H243185BEUI, &H550C7DC3UI, &H72BE5D74UI, &H80DEB1FEUI, &H9BDC06A7UI, &HC19BF174UI,
            &HE49B69C1UI, &HEFBE4786UI, &HFC19DC6UI, &H240CA1CCUI, &H2DE92C6FUI, &H4A7484AAUI, &H5CB0A9DCUI, &H76F988DAUI,
            &H983E5152UI, &HA831C66DUI, &HB00327C8UI, &HBF597FC7UI, &HC6E00BF3UI, &HD5A79147UI, &H6CA6351UI, &H14292967UI,
            &H27B70A85UI, &H2E1B2138UI, &H4D2C6DFCUI, &H53380D13UI, &H650A7354UI, &H766A0ABBUI, &H81C2C92EUI, &H92722C85UI,
            &HA2BFE8A1UI, &HA81A664BUI, &HC24B8B70UI, &HC76C51A3UI, &HD192E819UI, &HD6990624UI, &HF40E3585UI, &H106AA070UI,
            &H19A4C116UI, &H1E376C08UI, &H2748774CUI, &H34B0BCB5UI, &H391C0CB3UI, &H4ED8AA4AUI, &H5B9CCA4FUI, &H682E6FF3UI,
            &H748F82EEUI, &H78A5636FUI, &H84C87814UI, &H8CC70208UI, &H90BEFFFAUI, &HA4506CEBUI, &HBEF9A3F7UI, &HC67178F2UI
        }


    ' 64Byteにサイズ調整する関数
    Private Function Padding(ByVal Text As String)
        Dim Length As Integer = Text.Length
        Dim Tmps(64 - 1) As String

        ' Tmps を0で初期化 先頭を&H80にする
        For Each Tmp As String In Tmps
            Tmp = "0"
        Next
        Tmps(0) = &H80


        ' test code
        For Each temp As Integer In Tmps
            ' Console.WriteLine(temp)
        Next


        Dim BlockSize As String() = {Text} ' 違うかも
        BlockSize = BlockSize.Concat(Tmps).ToArray

        ' test code
        For Each temp As String In BlockSize
            Console.WriteLine(temp)
        Next


        If Length Mod 64 < 56 Then
            Dim temp() As String = {(56 - (Length Mod 64))}
            BlockSize.Concat(temp)
        Else
            Dim temp() As String = {(64 + 56 - Length Mod 64)}
            BlockSize.Concat(temp)
        End If

        ' 長さの８倍を確保する
        Dim Bit As Integer = Length * 8
        Dim Size() As String = {
            &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0
        }
        Size(4) = (Bit And &HFF000000) >> 24
        Size(5) = (Bit And &H__FF0000) >> 16
        Size(6) = (Bit And &H____FF00) >> 8
        Size(7) = (Bit And &H______FF)
        BlockSize = BlockSize.Concat(Size).ToArray

        Console.WriteLine(BlockSize.Length)

        Return BlockSize

    End Function


    ' ローテーション関数の実装
    ' 右にNビット循環する
    Private Function ROTR(ByVal X As UInteger, ByVal N As UInteger) As UInteger
        Return (X >> N) Or (X << (32 - N))
    End Function

    Private Function SHR(ByVal X As UInteger, ByVal N As UInteger) As UInteger
        Return X >> N
    End Function

    ' ローテーション関数実装 End


    ' SHA-256用 公式で定義されている6つの関数の実装
    Private Function Ch(ByVal X As UInteger, ByVal Y As UInteger, ByVal Z As UInteger) As UInteger
        Return (X And Y) Xor (Not X And Z)
    End Function

    Private Function Maj(ByVal X As UInteger, ByVal Y As UInteger, ByVal Z As UInteger) As UInteger
        Return (X And Y) Xor (X And Z) Xor (Y And Z)
    End Function

    Private Function Sigma0(ByVal X As UInteger) As UInteger
        Return ROTR(X, 2) Xor ROTR(X, 13) Xor ROTR(X, 22)
    End Function

    Private Function Sigma1(ByVal X As UInteger) As UInteger
        Return ROTR(X, 6) Xor ROTR(X, 11) Xor ROTR(X, 25)
    End Function

    Private Function Sigma_0(ByVal X As UInteger) As UInteger
        Return ROTR(X, 7) Xor ROTR(X, 18) Xor SHR(X, 3)
    End Function

    Private Function Sigma_1(ByVal X As UInteger) As Integer
        Return ROTR(X, 17) Xor ROTR(X, 19) Xor SHR(X, 10)
    End Function

    ' 実装 End



    Public Function Encode() As Long()
        Console.WriteLine("SHA_2 呼び出されました")

        Dim Datas As String() = {0}

        ' test code

        Padding("00")
        Dim Data() As Long = {128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

        ' メッセージブロックのサイズ
        Dim N As Integer = Data.Length / 64
        Dim W(63), Hash(IHV.Length) As Long

        For I As Integer = 0 To IHV.Length - 1
            Hash(I) = IHV(I)
        Next

        ' メッセージスケジュールの準備
        For I As Integer = 1 To N
            Dim Mask As UInteger = UInteger.MaxValue

            For J As Integer = 0 To J > 64 - 1
                If J < 16 Then
                    ' 4Byte区切りにする
                    Dim P As Integer = (I - 1) * 64 + J * 4
                    W(J) = (Data(P) << 24) + (Data(P + 1) << 16) + (Data(P + 2) << 8) + Data(P + 3)
                Else
                    W(J) = (Sigma_1(W(J - 2)) + W(J - 7) + Sigma_0(W(J - 15)) + W(J - 16)) And Mask
                End If
            Next

            Dim a As UInteger = Hash(0)
            Dim b As UInteger = Hash(1)
            Dim c As UInteger = Hash(2)
            Dim d As UInteger = Hash(3)
            Dim e As UInteger = Hash(4)
            Dim f As UInteger = Hash(5)
            Dim g As UInteger = Hash(6)
            Dim h As UInteger = Hash(7)



            ' 参考文献により決められている計算方式でハッシュ値を計算
            For J As Integer = 0 To 63
                Dim T1 As Long = (CULng(h) + Sigma1(e) + Ch(e, f, g) + K(J) + W(J)) And Mask
                Console.WriteLine("2 a: " & a & " b: " & b & " c: " & c & " d: " & d & " e: " & e & " f: " & f & " g: " & g & " h: " & h)
                Dim T2 As Long = (CULng(Sigma0(a)) + Maj(a, b, c)) And Mask
                Console.WriteLine("T1: " & T1 & " T2: " & T2)

                h = g
                g = f
                f = e
                e = (CULng(d) + T1) And Mask
                d = c
                c = b
                b = a
                a = (CULng(T1) + T2) And Mask
            Next

            Hash(0) = CULng(a + Hash(0)) And Mask
            Hash(1) = CULng(b + Hash(1)) And Mask
            Hash(2) = CULng(c + Hash(2)) And Mask
            Hash(3) = CULng(d + Hash(3)) And Mask
            Hash(4) = CULng(e + Hash(4)) And Mask
            Hash(5) = CULng(f + Hash(5)) And Mask
            Hash(6) = CULng(g + Hash(6)) And Mask
            Hash(7) = CULng(h + Hash(7)) And Mask

            Console.WriteLine("2 a: " & a & " b: " & b & " c: " & c & " d: " & d & " e: " & e & " f: " & f & " g: " & g & " h: " & h)
            Debug.WriteLine("GetByteString: " & GetByteString(a))

        Next

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



End Class

