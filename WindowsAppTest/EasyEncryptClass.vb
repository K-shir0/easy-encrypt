Public Class EasyEncryptClass
    Private Src As RichTextBox = Form1.SrcRichTextBox
    Private Dst As RichTextBox = Form1.DstRichTextBox

    ' ゲッターとセッター
    Public Function GetSrcText() As String
        Return Src.Text
    End Function

    Public Sub SetDstText(ByVal Text As String)
        Dst.Text = Text
    End Sub


    ' バイトに変換
    Public Function ToByte(ByVal Text As String) As Byte()

        Dim Data As Byte() = System.Text.Encoding.UTF8.GetBytes(Text)

        Return Data

    End Function

End Class
