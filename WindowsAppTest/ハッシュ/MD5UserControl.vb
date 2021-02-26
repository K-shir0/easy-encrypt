Public Class MD5UserControl

    Private Sub MD5UserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

        Encrypt()
    End Sub

    ' メモリ開放されたとき
    Private Sub MD5UserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        RemoveHandler Form1.SrcRichTextBox.TextChanged,
            AddressOf Encrypt

    End Sub

    Private Sub Encrypt()

        Dim md5 As New MD5

        Form1.DstRichTextBox.Text = md5.Encode(Form1.SrcRichTextBox.Text)

    End Sub
End Class
