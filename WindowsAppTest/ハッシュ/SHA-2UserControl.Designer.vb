<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHA_2UserControl
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AssortmentComboBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SHA-2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AssortmentComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 60)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "暗号種別"
        '
        'AssortmentComboBox
        '
        Me.AssortmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AssortmentComboBox.FormattingEnabled = True
        Me.AssortmentComboBox.Items.AddRange(New Object() {"512", "384", "256"})
        Me.AssortmentComboBox.Location = New System.Drawing.Point(16, 23)
        Me.AssortmentComboBox.Name = "AssortmentComboBox"
        Me.AssortmentComboBox.Size = New System.Drawing.Size(181, 20)
        Me.AssortmentComboBox.TabIndex = 0
        '
        'SHA_2UserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SHA_2UserControl"
        Me.Size = New System.Drawing.Size(254, 469)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents AssortmentComboBox As ComboBox
End Class
