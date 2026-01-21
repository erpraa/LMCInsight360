Imports DevExpress.XtraEditors.Controls
Imports LMCInsight360.ClassFunction
Imports LMCInsight360.CryptoEngine
Public Class CtrResetPassword

    Private WithEvents SelectTools As FrmLookup

    Private Sub CtrResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlFooter.Hide()
    End Sub


    Private Sub BtnEdtUserID_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles BtnEdtUserID.ButtonPressed
        Dim strTripSelect As String = "SELECT UserID,FullName,UserName,CreatedDate,CreatedBy,IsActive,IsLoggedIn,IsResetPass FROM MSTR_USERS"

        If IsFormOpen(SelectTools) Then
            SelectTools.Close()
        End If

        SelectTools = New FrmLookup(strTripSelect, "ResetPassword")
        SelectTools.ShowDialog()
    End Sub

    Private Sub Select_Selected(Get_idNumber As String) Handles SelectTools.Selected

        BtnEdtUserID.EditValue = Get_idNumber

    End Sub

    Sub GetUserData()
        Dim dataList As List(Of Dictionary(Of String, String)) = GetMultiValues($"SELECT UserID,FullName,UserName,CreatedDate,CreatedBy,IsActive,IsLoggedIn,IsResetPass FROM MSTR_USERS WHERE UserID ='{BtnEdtUserID.EditValue}'")

        For Each row In dataList
            TxtUserName.Text = row("UserName")
            TxtName.Text = row("FullName")


            If row("IsActive") = True Then
                lblActive.Text = "Active"
                lblActive.ForeColor = Color.Green
            Else
                lblActive.Text = "Inactive"
                lblActive.ForeColor = Color.Red
            End If

            If row("IsLoggedIn") = True Then
                lblActiveSession.Text = "Online"
                lblActiveSession.ForeColor = Color.Green
            Else
                lblActiveSession.Text = "Offline"
                lblActiveSession.ForeColor = Color.Red
            End If
        Next

    End Sub

    Private Sub BtnEdtUserID_EditValueChanged(sender As Object, e As EventArgs) Handles BtnEdtUserID.EditValueChanged
        GetUserData()

        If Convert.IsDBNull(BtnEdtUserID.EditValue) OrElse String.IsNullOrWhiteSpace(Convert.ToString(BtnEdtUserID.EditValue)) Then
            PnlFooter.Hide()
        Else
            PnlFooter.Show()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtNewPassword.Text <> TxtRePassword.Text Then
            MsgBox("Password Not Match!", vbExclamation)
            Return
        Else

            Dim params As New Dictionary(Of String, Object) From {
                              {"@UserID", BtnEdtUserID.EditValue},
                              {"@Password", DataEncrypt(TxtNewPassword.Text, AppSecurity)},
                              {"@IsResetPass", 1}
                }

            Dim qry As String = "Update MSTR_USERS set Password=@Password,IsResetPass=@IsResetPass where UserID=@UserID;
                                     SELECT @UserID;"
            ExecuteUpdate(qry, params)

            MsgBox("Password reset completed", vbInformation)

        End If
    End Sub
End Class

