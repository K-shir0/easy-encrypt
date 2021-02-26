Public Class Form1

    Dim eNodeNamed As String = ""
    Dim control As Object

    ' TreeView をクリックしたとき
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Console.WriteLine(e.Node.Name & eNodeNamed)

        ' 他のノードが選択されたときOptionPanelをリセット
        If eNodeNamed <> e.Node.Name And e.Node.Level > 0 Then
            If (Not IsNothing(control)) Then
                control.dispose()

                ' 初期化処理
                DstRichTextBox.ResetText()
                eNodeNamed = ""
            End If
        End If


        Select Case e.Node.Name
            Case "CaesarCipherUserControl"
                control = New CaesarCipherUserControl
            Case "Base64"
                Console.WriteLine("base64")
                control = New Base64UserControl
            Case "MD5"
                control = New MD5UserControl
            Case "SHA-1"
                control = New SHA_1UserControl
            Case "SHA-2"
                control = New SHA_2UserControl
            Case "AES"
                control = New AESUserControl
            Case "DES"
                control = New DESUserControl
        End Select

        ' OprionPanelに追加
        If e.Node.Level > 0 Then
            OptionPanel.Controls.Add(control)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        SrcRichTextBox.Text = DstRichTextBox.Text

    End Sub

    ' コピーボタンをクリック
    Private Sub ClipBoardButton_Click(sender As Object, e As EventArgs) Handles ClipBoardButton.Click

        Dim Str As String = DstRichTextBox.Text

        If Str = String.Empty Then
            Exit Sub
        End If

        Clipboard.Clear()

        Clipboard.SetText(Str)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SrcRichTextBox.Clear()
    End Sub

    Private Sub らくらくエンクリプトのバージョン情報ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles らくらくエンクリプトのバージョン情報aToolStripMenuItem.Click
        Dim f As New VersionForm
        f.Show()
    End Sub
End Class