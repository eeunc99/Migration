<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Migration
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnManual = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fileDate1 = New System.Windows.Forms.DateTimePicker()
        Me.fileDate2 = New System.Windows.Forms.DateTimePicker()
        Me.insertBox = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fileDate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnManual
        '
        Me.btnManual.Location = New System.Drawing.Point(520, 12)
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(65, 27)
        Me.btnManual.TabIndex = 0
        Me.btnManual.Text = "실행"
        Me.btnManual.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "파일 생성 날짜 : "
        '
        'fileDate1
        '
        Me.fileDate1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fileDate1.Location = New System.Drawing.Point(111, 16)
        Me.fileDate1.Name = "fileDate1"
        Me.fileDate1.Size = New System.Drawing.Size(156, 21)
        Me.fileDate1.TabIndex = 2
        Me.fileDate1.Value = New Date(2024, 3, 14, 0, 0, 0, 0)
        '
        'insertBox
        '
        Me.insertBox.FormattingEnabled = True
        Me.insertBox.ItemHeight = 12
        Me.insertBox.Location = New System.Drawing.Point(12, 50)
        Me.insertBox.Name = "insertBox"
        Me.insertBox.Size = New System.Drawing.Size(573, 340)
        Me.insertBox.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(449, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 27)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "실행"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fileDate2
        '
        Me.fileDate2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fileDate2.Location = New System.Drawing.Point(287, 16)
        Me.fileDate2.Name = "fileDate2"
        Me.fileDate2.Size = New System.Drawing.Size(156, 21)
        Me.fileDate2.TabIndex = 5
        Me.fileDate2.Value = New Date(2024, 3, 14, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "~"
        '
        'Migration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 418)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fileDate2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.insertBox)
        Me.Controls.Add(Me.fileDate1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnManual)
        Me.Name = "Migration"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnManual As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents fileDate1 As DateTimePicker
    Friend WithEvents insertBox As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents fileDate2 As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
