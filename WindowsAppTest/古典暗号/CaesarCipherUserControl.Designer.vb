<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaesarCipherUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AssortmentComboBox = New System.Windows.Forms.ComboBox()
        Me.ShiftTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BruteforceButtonCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'AssortmentComboBox
        '
        Me.AssortmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AssortmentComboBox.FormattingEnabled = True
        Me.AssortmentComboBox.Items.AddRange(New Object() {"ﾃﾞﾌｫﾙﾄ", "ROT13"})
        Me.AssortmentComboBox.Location = New System.Drawing.Point(16, 23)
        Me.AssortmentComboBox.Name = "AssortmentComboBox"
        Me.AssortmentComboBox.Size = New System.Drawing.Size(181, 20)
        Me.AssortmentComboBox.TabIndex = 0
        '
        'ShiftTextBox
        '
        Me.ShiftTextBox.Location = New System.Drawing.Point(57, 25)
        Me.ShiftTextBox.Name = "ShiftTextBox"
        Me.ShiftTextBox.Size = New System.Drawing.Size(105, 19)
        Me.ShiftTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "シーザー暗号"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AssortmentComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 60)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "暗号種別"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ShiftTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 61)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "キー"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "文字"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "シフト："
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BruteforceButtonCheckBox)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 169)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 61)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "オプション"
        '
        'BruteforceButtonCheckBox
        '
        Me.BruteforceButtonCheckBox.AutoSize = True
        Me.BruteforceButtonCheckBox.Location = New System.Drawing.Point(16, 29)
        Me.BruteforceButtonCheckBox.Name = "BruteforceButtonCheckBox"
        Me.BruteforceButtonCheckBox.Size = New System.Drawing.Size(65, 16)
        Me.BruteforceButtonCheckBox.TabIndex = 0
        Me.BruteforceButtonCheckBox.Text = "総当たり"
        Me.BruteforceButtonCheckBox.UseVisualStyleBackColor = True
        '
        'CaesarCipherUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CaesarCipherUserControl"
        Me.Size = New System.Drawing.Size(254, 469)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AssortmentComboBox As ComboBox
    Friend WithEvents ShiftTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BruteforceButtonCheckBox As CheckBox
End Class
