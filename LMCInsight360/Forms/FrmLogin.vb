Imports DevExpress.XtraEditors
Imports LMCInsight360.ClassFunction
Imports LMCInsight360.CryptoEngine

Public Class FrmLogin

    Private m_blnConn As Boolean = False

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUsername.Properties.NullText = "Username"
        TxtPassword.Properties.NullText = "Password"
        LblVersion.Text = "Version: " & GetPublishVersion()

        Me.AcceptButton = BtnLogin

        PnlSelectConn.Hide()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        Dim dataMain As List(Of Dictionary(Of String, String)) = GetMultiValues("select * from SysMaintenance")

        For Each record In dataMain

            If record("IsActive") = True Then
                MessageBox.Show(record("MsgInfo"), SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'If Trim(record("Version")) <> Trim(GetPublishVersion()) Then
            '    MessageBox.Show($"Your version ({GetPublishVersion()}) is outdated. The current version is ({record("Version")}). Please update before continuing.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If

        Next

        Try
            Dim found As Boolean = False

            Dim dataUser As List(Of Dictionary(Of String, String)) = GetMultiValues("select * from MSTR_USERS")

            For Each record In dataUser

                If TxtPassword.Text = DataDecrypt(record("Password").ToString, AppSecurity) Then
                    found = True
                    GstrUseID = record("UserID").ToString
                    GstrUselogin = record("FullName").ToString
                    GstrUsername = record("UserName").ToString
                    GstrPassword = DataDecrypt(record("Password").ToString, AppSecurity)

                    GstrIsActive = record("IsActive").ToString
                    GstrIsLoggedIn = record("IsLoggedIn").ToString
                    GstrIsResetPass = record("IsResetPass").ToString
                End If

            Next

            If found Then

                If GstrIsActive = False Then
                    MessageBox.Show("Contact the Administrator to activate your account.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                ' Check if user is already logged in
                If GstrIsLoggedIn = True Then
                    Dim response As Integer
                    response = MsgBox("This user is already logged in on another device." & vbCrLf & vbCrLf & " Do you want to continue?" & vbCrLf & vbCrLf & "(Continuing will log them out, and any unsaved data will be lost.)", vbYesNo + vbQuestion, SystemTitle)
                    If response = vbYes Then
                        ExecuteUpdate($"Update MSTR_USERS set isLoggedIn='False' where UserID='{GstrUseID}'")
                    Else
                        Exit Sub
                    End If
                End If

                If GstrIsResetPass = True Then

                    Dim argpass As New XtraInputBoxArgs(), editpass As New TextEdit()
                    Dim argconfirm As New XtraInputBoxArgs(), editconfirm As New TextEdit()

                    ' Set password character for both inputs
                    With editpass
                        .Properties.PasswordChar = "*" ' Corrected syntax
                    End With

                    With editconfirm
                        .Properties.PasswordChar = "*" ' Corrected syntax
                    End With

                    ' First input for new password
                    With argpass
                        .Caption = "Reset Password"
                        .Prompt = "Please input your New password to proceed: "
                        .DefaultResponse = ""
                        .Editor = editpass
                        .DefaultButtonIndex = 0
                    End With

                    ' Second input for password confirmation
                    With argconfirm
                        .Caption = "Confirm Password"
                        .Prompt = "Retype your password:"
                        .DefaultResponse = ""
                        .Editor = editconfirm
                        .DefaultButtonIndex = 0
                    End With

                    ' Show the input boxes and trim the user input
                    Dim PassResult As String = XtraInputBox.Show(argpass)?.Trim()
                    Dim ConfirmResult As String = XtraInputBox.Show(argconfirm)?.Trim()

                    ' Check if either input is empty
                    If String.IsNullOrEmpty(PassResult) OrElse String.IsNullOrEmpty(ConfirmResult) Then
                        MessageBox.Show("Password fields cannot be empty. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    ' Validate passwords
                    If PassResult = ConfirmResult AndAlso Not String.IsNullOrEmpty(PassResult) Then

                        ExecuteUpdate($"update MSTR_USERS set Password='{DataEncrypt(PassResult, AppSecurity)}',IsResetPass=0 where UserID='{GstrUseID}'")

                        MessageBox.Show("Password successfully set!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                MessageBox.Show("Access Granted. Welcome " & StrConv(GstrUselogin, VbStrConv.ProperCase), SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                UpdateLoginStatus(GstrUseID, True)

                FrmMain.Show()

                Me.Hide()
            Else
                MessageBox.Show("Access Denied. Invalid Username or Password!", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub


    Private Sub RPnlLeft_MouseDown(sender As Object, e As MouseEventArgs) Handles RPnlLeft.MouseDown
        RoundedCornersForm_MouseDown(e)
    End Sub

    Private Sub RPnlLeft_MouseMove(sender As Object, e As MouseEventArgs) Handles RPnlLeft.MouseMove
        RoundedCornersForm_MouseMove(Me, e)
    End Sub

    Private Sub RPnlLeft_MouseUp(sender As Object, e As MouseEventArgs) Handles RPnlLeft.MouseUp
        RoundedCornersForm_MouseUp()
    End Sub

    'Allow the user to drag the form since there's no title bar
    Private isDragging As Boolean = False
    Private startPoint As Point

    Sub RoundedCornersForm_MouseDown(e As MouseEventArgs)
        isDragging = True
        startPoint = e.Location
    End Sub

    Sub RoundedCornersForm_MouseMove(SelectForm As Form, e As MouseEventArgs)
        If isDragging Then
            SelectForm.Location = New Point(SelectForm.Location.X + e.X - startPoint.X, SelectForm.Location.Y + e.Y - startPoint.Y)
        End If
    End Sub

    Sub RoundedCornersForm_MouseUp()
        isDragging = False
    End Sub

    Private Sub LblClose_Click(sender As Object, e As EventArgs) Handles LblClose.Click
        Dim result As DialogResult
        result = MessageBox.Show("Do you want to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub TxtPassword_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPassword.EditValueChanged
        If TxtPassword.Properties.NullText = "Password" Then
            TxtPassword.Properties.UseSystemPasswordChar = True
        Else
            TxtPassword.Properties.UseSystemPasswordChar = False
        End If
    End Sub
    Private Sub ChkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowPass.CheckedChanged
        If TxtPassword.EditValue <> "" Then
            If ChkShowPass.Checked Then
                TxtPassword.Properties.UseSystemPasswordChar = False
            Else
                TxtPassword.Properties.UseSystemPasswordChar = True
            End If
        End If
    End Sub

    Private Sub LblLinkDatabase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblLinkDatabase.LinkClicked
        m_blnConn = Not m_blnConn
        PnlSelectConn.Visible = m_blnConn
    End Sub

    Private Sub RPnlLeft_Paint(sender As Object, e As PaintEventArgs) Handles RPnlLeft.Paint

    End Sub
End Class