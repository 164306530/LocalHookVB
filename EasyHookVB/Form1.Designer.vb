<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.wb = New System.Windows.Forms.WebBrowser()
        Me.chkcheat = New System.Windows.Forms.CheckBox()
        Me.butgotourl = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(12, 1)
        Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb.Name = "wb"
        Me.wb.ScriptErrorsSuppressed = True
        Me.wb.Size = New System.Drawing.Size(1104, 477)
        Me.wb.TabIndex = 0
        '
        'chkcheat
        '
        Me.chkcheat.AutoSize = True
        Me.chkcheat.Location = New System.Drawing.Point(22, 500)
        Me.chkcheat.Name = "chkcheat"
        Me.chkcheat.Size = New System.Drawing.Size(81, 17)
        Me.chkcheat.TabIndex = 1
        Me.chkcheat.Text = "HOOK图片"
        Me.chkcheat.UseVisualStyleBackColor = True
        '
        'butgotourl
        '
        Me.butgotourl.Location = New System.Drawing.Point(501, 500)
        Me.butgotourl.Name = "butgotourl"
        Me.butgotourl.Size = New System.Drawing.Size(77, 26)
        Me.butgotourl.TabIndex = 2
        Me.butgotourl.Text = "浏览"
        Me.butgotourl.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 540)
        Me.Controls.Add(Me.butgotourl)
        Me.Controls.Add(Me.chkcheat)
        Me.Controls.Add(Me.wb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents wb As WebBrowser
    Friend WithEvents chkcheat As CheckBox
    Friend WithEvents butgotourl As Button
End Class
