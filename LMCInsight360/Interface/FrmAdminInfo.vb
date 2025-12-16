Imports LMCInsight360.ClassFunction
Public Class FrmAdminInfo
    Private Sub FrmAdminInfo_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub

    Private Sub FrmAdminInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblUser.Text = GstrUsername
        LblDatabase.Text = strDatabase
        LblReportServer.Text = strServerName
        LblCasServer.Text = DispCasConnect
        LblResServer.Text = DispResConnect
        LblVersion.Text = "Version: " & GetPublishVersion()
    End Sub

End Class