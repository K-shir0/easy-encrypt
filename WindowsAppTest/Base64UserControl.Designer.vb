<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Base64UserControl
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DecryptRadioButton = New System.Windows.Forms.RadioButton()
        Me.EncryptRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DecryptRadioButton)
        Me.GroupBox3.Controls.Add(Me.EncryptRadioButton)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 62)
        Me.GroupBox3.TabIndex = 6
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Base64"
        '
        'Base64UserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Base64UserControl"
        Me.Size = New System.Drawing.Size(254, 469)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DecryptRadioButton As RadioButton
    Friend WithEvents EncryptRadioButton As RadioButton
End Class
