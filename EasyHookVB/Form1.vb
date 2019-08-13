Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wb.Navigate("https://ibb.co/8MXBCxc")
    End Sub

    Private Sub butGotoUrl_Click(sender As Object, e As EventArgs) Handles butgotourl.Click
        wb.Refresh()
    End Sub

    Private Sub chkCheat_CheckedChanged(sender As Object, e As EventArgs) Handles chkcheat.CheckedChanged
        If chkcheat.Checked Then
            HookHttpOpenRequest.Install()
            HookInternetReadFile.Install()
        Else
            HookHttpOpenRequest.UnInstall()
            HookInternetReadFile.UnInstall()
        End If
    End Sub

End Class