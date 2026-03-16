Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubQuery
Imports LMCInsight360.CryptoEngine
Imports DevExpress.XtraEditors.Controls

Public Class CtrCreateAccount
    Private WithEvents SelectTools As FrmLookup

    Private Sub CtrCreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPass.Properties.UseSystemPasswordChar = True
        TxtRepass.Properties.UseSystemPasswordChar = True
    End Sub

    Private Sub ChkShowpass_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowpass.CheckedChanged
        If ChkShowpass.Checked Then
            TxtPass.Properties.UseSystemPasswordChar = False
            TxtRepass.Properties.UseSystemPasswordChar = False
        Else
            TxtPass.Properties.UseSystemPasswordChar = True
            TxtRepass.Properties.UseSystemPasswordChar = True
        End If
    End Sub

    Sub ClearText()
        TxtName.Text = String.Empty
        TxtUser.Text = String.Empty
        BtnEdtDpt.Text = String.Empty
        TxtPass.Text = String.Empty
        TxtRepass.Text = String.Empty
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If String.IsNullOrWhiteSpace(TxtUser.Text) OrElse
         String.IsNullOrWhiteSpace(BtnEdtDpt.Text) OrElse
        String.IsNullOrWhiteSpace(TxtPass.Text) OrElse
        String.IsNullOrWhiteSpace(TxtRepass.Text) OrElse
        String.IsNullOrWhiteSpace(TxtName.Text) Then

            MessageBox.Show("Please enter all required fields.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ChkUserExist As String = GetValue($"select COUNT(*) UserExist from MSTR_USERS where UserName='{TxtUser.Text.Trim()}'")

        If ChkUserExist <> 0 Then
            MsgBox("That username is already taken!", vbExclamation)
            ClearText()
            Return
        End If

        Try

            If TxtPass.Text <> TxtRepass.Text Then
                MsgBox("Password Not Match!", vbExclamation)
                Return
            Else

                Dim nxtTrxCount As String = GetValue(GetUserNumRnge)

                Dim params As New Dictionary(Of String, Object) From {
                              {"@UserID", nxtTrxCount},
                              {"@DeptID", BtnEdtDpt.EditValue},
                              {"@FullName", TxtName.Text},
                              {"@UserName", TxtUser.Text},
                              {"@Password", DataEncrypt(TxtPass.Text, AppSecurity)},
                              {"@CreatedDate", GetServerDate()},
                              {"@CreatedBy", GstrUselogin}
                }

                Dim qry As String = "INSERT INTO MSTR_USERS (UserID, DeptID, FullName, UserName, Password, CreatedDate, CreatedBy) VALUES (@UserID, @DeptID, @FullName, @UserName, @Password, @CreatedDate, @CreatedBy);
                                     SELECT @UserID;"

                Dim newUserID As String = ExecuteInsert(qry, params)

                Dim paramAUC As New Dictionary(Of String, Object) From {{"@ColumnName", nxtTrxCount}}
                ExecuteProcedure("AddUserColumn", paramAUC)

                MessageBox.Show("User saved! New ID:" & newUserID)

                ClearText()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation)

        End Try
    End Sub

    Private Sub TxtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtName.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub


    Private Sub BtnEdtDpt_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles BtnEdtDpt.ButtonPressed
        Dim strTripSelect As String = "select * from MSTR_DEPARTMENT"

        If IsFormOpen(SelectTools) Then
            SelectTools.Close()
        End If

        SelectTools = New FrmLookup(strTripSelect, "CreateAccount")
        SelectTools.ShowDialog()
    End Sub

    Private Sub Select_Selected(Get_idNumber As String) Handles SelectTools.Selected
        BtnEdtDpt.EditValue = Get_idNumber
    End Sub


End Class
