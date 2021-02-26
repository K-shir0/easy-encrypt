<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AESUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DecryptRadioButton = New System.Windows.Forms.RadioButton()
        Me.EncryptRadioButton = New System.Windows.Forms.RadioButton()
        Me.IVGroupBox = New System.Windows.Forms.GroupBox()
        Me.IVGenerateRadioButton = New System.Windows.Forms.RadioButton()
        Me.IVInputRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IVTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordGroupBox = New System.Windows.Forms.GroupBox()
        Me.PopLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RePasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KeyTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordInputRadioButton = New System.Windows.Forms.RadioButton()
        Me.KeyInputRadioButton = New System.Windows.Forms.RadioButton()
        Me.KeyGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.IVGroupBox.SuspendLayout()
        Me.PasswordGroupBox.SuspendLayout()
        Me.KeyGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "AES"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DecryptRadioButton)
        Me.GroupBox3.Controls.Add(Me.EncryptRadioButton)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(221, 62)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "オプション"
        '
        'DecryptRadioButton
        '
        Me.DecryptRadioButton.AutoSize = True
        Me.DecryptRadioButton.Location = New System.Drawing.Point(71, 27)
        Me.DecryptRadioButton.Name = "DecryptRadioButton"
        Me.DecryptRadioButton.Size = New System.Drawing.Size(59, 16)
        Me.DecryptRadioButton.TabIndex = 1
        Me.DecryptRadioButton.TabStop = True
        Me.DecryptRadioButton.Text = "復号化"
        Me.DecryptRadioButton.UseVisualStyleBackColor = True
        '
        'EncryptRadioButton
        '
        Me.EncryptRadioButton.AutoSize = True
        Me.EncryptRadioButton.Location = New System.Drawing.Point(6, 27)
        Me.EncryptRadioButton.Name = "EncryptRadioButton"
        Me.EncryptRadioButton.Size = New System.Drawing.Size(59, 16)
        Me.EncryptRadioButton.TabIndex = 0
        Me.EncryptRadioButton.TabStop = True
        Me.EncryptRadioButton.Text = "暗号化"
        Me.EncryptRadioButton.UseVisualStyleBackColor = True
        '
        'IVGroupBox
        '
        Me.IVGroupBox.Controls.Add(Me.IVGenerateRadioButton)
        Me.IVGroupBox.Controls.Add(Me.IVInputRadioButton)
        Me.IVGroupBox.Controls.Add(Me.Label4)
        Me.IVGroupBox.Controls.Add(Me.IVTextBox)
        Me.IVGroupBox.Location = New System.Drawing.Point(16, 97)
        Me.IVGroupBox.Name = "IVGroupBox"
        Me.IVGroupBox.Size = New System.Drawing.Size(215, 78)
        Me.IVGroupBox.TabIndex = 12
        Me.IVGroupBox.TabStop = False
        Me.IVGroupBox.Text = "IV"
        '
        'IVGenerateRadioButton
        '
        Me.IVGenerateRadioButton.AutoSize = True
        Me.IVGenerateRadioButton.Location = New System.Drawing.Point(16, 18)
        Me.IVGenerateRadioButton.Name = "IVGenerateRadioButton"
        Me.IVGenerateRadioButton.Size = New System.Drawing.Size(71, 16)
        Me.IVGenerateRadioButton.TabIndex = 5
        Me.IVGenerateRadioButton.TabStop = True
        Me.IVGenerateRadioButton.Text = "自動生成"
        Me.IVGenerateRadioButton.UseVisualStyleBackColor = True
        Me.IVGenerateRadioButton.Visible = False
        '
        'IVInputRadioButton
        '
        Me.IVInputRadioButton.AutoSize = True
        Me.IVInputRadioButton.Location = New System.Drawing.Point(93, 18)
        Me.IVInputRadioButton.Name = "IVInputRadioButton"
        Me.IVInputRadioButton.Size = New System.Drawing.Size(59, 16)
        Me.IVInputRadioButton.TabIndex = 4
        Me.IVInputRadioButton.TabStop = True
        Me.IVInputRadioButton.Text = "手入力"
        Me.IVInputRadioButton.UseVisualStyleBackColor = True
        Me.IVInputRadioButton.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "VI："
        '
        'IVTextBox
        '
        Me.IVTextBox.Location = New System.Drawing.Point(42, 44)
        Me.IVTextBox.Name = "IVTextBox"
        Me.IVTextBox.Size = New System.Drawing.Size(159, 19)
        Me.IVTextBox.TabIndex = 2
        '
        'PasswordGroupBox
        '
        Me.PasswordGroupBox.Controls.Add(Me.PopLabel)
        Me.PasswordGroupBox.Controls.Add(Me.Label5)
        Me.PasswordGroupBox.Controls.Add(Me.RePasswordTextBox)
        Me.PasswordGroupBox.Controls.Add(Me.Label3)
        Me.PasswordGroupBox.Controls.Add(Me.PasswordTextBox)
        Me.PasswordGroupBox.Location = New System.Drawing.Point(30, 352)
        Me.PasswordGroupBox.Name = "PasswordGroupBox"
        Me.PasswordGroupBox.Size = New System.Drawing.Size(215, 114)
        Me.PasswordGroupBox.TabIndex = 13
        Me.PasswordGroupBox.TabStop = False
        Me.PasswordGroupBox.Text = "パスワード"
        Me.PasswordGroupBox.Visible = False
        '
        'PopLabel
        '
        Me.PopLabel.AutoSize = True
        Me.PopLabel.Location = New System.Drawing.Point(14, 87)
        Me.PopLabel.Name = "PopLabel"
        Me.PopLabel.Size = New System.Drawing.Size(0, 12)
        Me.PopLabel.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "再入力："
        '
        'RePasswordTextBox
        '
        Me.RePasswordTextBox.Location = New System.Drawing.Point(78, 53)
        Me.RePasswordTextBox.Name = "RePasswordTextBox"
        Me.RePasswordTextBox.Size = New System.Drawing.Size(123, 19)
        Me.RePasswordTextBox.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "パスワード："
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(78, 24)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(123, 19)
        Me.PasswordTextBox.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "鍵："
        '
        'KeyTextBox
        '
        Me.KeyTextBox.Location = New System.Drawing.Point(42, 18)
        Me.KeyTextBox.Name = "KeyTextBox"
        Me.KeyTextBox.Size = New System.Drawing.Size(159, 19)
        Me.KeyTextBox.TabIndex = 1
        '
        'PasswordInputRadioButton
        '
        Me.PasswordInputRadioButton.AutoSize = True
        Me.PasswordInputRadioButton.Location = New System.Drawing.Point(24, 27)
        Me.PasswordInputRadioButton.Name = "PasswordInputRadioButton"
        Me.PasswordInputRadioButton.Size = New System.Drawing.Size(103, 16)
        Me.PasswordInputRadioButton.TabIndex = 7
        Me.PasswordInputRadioButton.TabStop = True
        Me.PasswordInputRadioButton.Text = "パスワードを使用"
        Me.PasswordInputRadioButton.UseVisualStyleBackColor = True
        Me.PasswordInputRadioButton.Visible = False
        '
        'KeyInputRadioButton
        '
        Me.KeyInputRadioButton.AutoSize = True
        Me.KeyInputRadioButton.Location = New System.Drawing.Point(133, 27)
        Me.KeyInputRadioButton.Name = "KeyInputRadioButton"
        Me.KeyInputRadioButton.Size = New System.Drawing.Size(68, 16)
        Me.KeyInputRadioButton.TabIndex = 6
        Me.KeyInputRadioButton.TabStop = True
        Me.KeyInputRadioButton.Text = "鍵を使用"
        Me.KeyInputRadioButton.UseVisualStyleBackColor = True
        Me.KeyInputRadioButton.Visible = False
        '
        'KeyGroupBox
        '
        Me.KeyGroupBox.Controls.Add(Me.KeyTextBox)
        Me.KeyGroupBox.Controls.Add(Me.Label2)
        Me.KeyGroupBox.Location = New System.Drawing.Point(16, 37)
        Me.KeyGroupBox.Name = "KeyGroupBox"
        Me.KeyGroupBox.Size = New System.Drawing.Size(215, 54)
        Me.KeyGroupBox.TabIndex = 14
        Me.KeyGroupBox.TabStop = False
        Me.KeyGroupBox.Text = "鍵"
        '
        'AESUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.KeyGroupBox)
        Me.Controls.Add(Me.PasswordGroupBox)
        Me.Controls.Add(Me.IVGroupBox)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PasswordInputRadioButton)
        Me.Controls.Add(Me.KeyInputRadioButton)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AESUserControl"
        Me.Size = New System.Drawing.Size(254, 469)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.IVGroupBox.ResumeLayout(False)
        Me.IVGroupBox.PerformLayout()
        Me.PasswordGroupBox.ResumeLayout(False)
        Me.PasswordGroupBox.PerformLayout()
        Me.KeyGroupBox.ResumeLayout(False)
        Me.KeyGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DecryptRadioButton As RadioButton
    Friend WithEvents EncryptRadioButton As RadioButton
    Friend WithEvents IVGroupBox As GroupBox
    Friend WithEvents PasswordGroupBox As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents KeyTextBox As TextBox
    Friend WithEvents IVTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents IVGenerateRadioButton As RadioButton
    Friend WithEvents IVInputRadioButton As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents PasswordInputRadioButton As RadioButton
    Friend WithEvents KeyInputRadioButton As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents RePasswordTextBox As TextBox
    Friend WithEvents KeyGroupBox As GroupBox
    Friend WithEvents PopLabel As Label
End Class
