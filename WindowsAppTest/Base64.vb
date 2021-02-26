Public Class Base64
    Inherits Format

    ' 変換テーブルを列挙
    Private ReadOnly ConvertTable As Char() = {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/"
    }

    Public Overrides Function Encode(Data() As Byte) As String

        ' DataをBitに変換したものを入れる
        Dim Bits() As Char = ""
        Dim DstText As String = ""

        Dim Length As Integer = Data.Length

        ' 2進数の文字列に変換する
        For I As Integer = 0 To Length - 1
            Bits &= Convert.ToString(Data(I), 2).PadLeft(8, "0").ToCharArray
        Next


        Dim BitSix As String = ""

        For I As Integer = 0 To Bits.Length - 1

            BitSix &= Bits(I)

            ' Bitの長さが6になったときBase64に変換する
            If BitSix.Length = 6 Then

                Dim ConvertIndex = Convert.ToInt32(BitSix, 2)

                DstText &= ConvertTable(ConvertIndex)

                BitSix = ""

            End If

            ' 最後にBitが6を満たないときに0でパディングする
            If I = Bits.Length - 1 And BitSix.Length <> 0 Then
                Dim Padding As Integer = 6 - BitSix.Length
                For J As Integer = 0 To Padding - 1
                    BitSix &= 0
                Next


                Dim ConvertIndex = Convert.ToInt32(BitSix, 2)
                DstText &= ConvertTable(ConvertIndex)

            End If

        Next

        ' 足りない分には＝を付け足す
        While (DstText.Length Mod 4 <> 0)
            DstText &= "="
        End While

        Return DstText

    End Function

    Public Overrides Function Decode(Text As String) As Byte()

        Dim DstText As String
        Dim SixDigsts As String = 0
        Dim Oct As Integer = 0
        Dim BitIndex As Integer = 0

        Dim bytes As New List(Of Byte)

        ' イコールを削除する
        DstText = Text.TrimEnd("=")

        For Each DstChars As Char In DstText

            Dim Value As Integer = Array.IndexOf(ConvertTable, DstChars)

            SixDigsts = Convert.ToString(Value, 2).PadLeft(6, "0")

            For Each V As String In SixDigsts

                BitIndex += 1

                If V.Equals("1") Then
                    Oct += 128 >> (BitIndex - 1)
                End If

                If BitIndex = 8 Then
                    bytes.Add(Oct)
                    Oct = 0
                    BitIndex = 0
                End If
            Next

        Next


        Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes.ToArray()) & "TOstring")

        Return bytes.ToArray()
    End Function
End Class
