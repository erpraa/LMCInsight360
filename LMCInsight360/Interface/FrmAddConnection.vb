Imports System.Data.SqlClient
Public Class FrmAddConnection

    Private Sub FrmAddConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfilesToComboBox()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Txtdbserver.Text = ""
        Txtdbuser.Text = ""
        Txtdbpassword.Text = ""
        Cbxdbname.Text = ""
        CbxConnection.Text = ""
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Txtdbserver.Text = "" Or Txtdbuser.Text = "" Or Txtdbpassword.Text = "" Or Cbxdbname.Text = "" Or CbxConnection.Text = "" Then
            MessageBox.Show("Database connection invalid!", "LMC System", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Savesettings(CbxConnection.Text)
        LoadProfilesToComboBox()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If CbxConnection.SelectedItem IsNot Nothing Then
            Dim profileName = CbxConnection.SelectedItem.ToString()
            If MsgBox("Are you sure you want to delete profile '" & profileName & "'?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DeleteProfile(profileName)
                LoadProfilesToComboBox()

                Txtdbserver.Text = ""
                Txtdbuser.Text = ""
                Txtdbpassword.Text = ""
                Cbxdbname.Text = ""
                CbxConnection.Text = ""
            End If
        End If
    End Sub

    Private Sub Cbxdbname_DropDown(sender As Object, e As EventArgs) Handles Cbxdbname.DropDown
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Cbxdbname.Items.Clear()
        Dim connects As New SqlConnection
        SqlConnect = "Data Source='" & Txtdbserver.Text & "';User ID='" & Txtdbuser.Text & "';password='" & Txtdbpassword.Text & "'"
        connects.ConnectionString = SqlConnect

        Try
            connects.Open()
            cmd.CommandText = "SELECT * FROM sys.databases WHERE name NOT IN ('master','tempdb','model','msdb')"
            cmd.Connection = connects
            dr = cmd.ExecuteReader
            While dr.Read
                Cbxdbname.Items.Add(dr.GetString(0))
            End While
            connects.Close()
        Catch myerror As SqlException
            MessageBox.Show("Error was encountered when connecting" & myerror.Message)
        End Try
    End Sub

    Private Sub CbxConnection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxConnection.SelectedIndexChanged
        If CbxConnection.SelectedItem IsNot Nothing Then
            Dim profileName As String = CbxConnection.SelectedItem.ToString()
            Fetchsettings(profileName)

            ' Load values into the form fields
            Txtdbserver.Text = strServerName
            Txtdbuser.Text = strUser
            Txtdbpassword.Text = strPassword
            Cbxdbname.Text = strDatabase
        End If
    End Sub

    Private Sub Savesettings(profileName As String)
        Dim s As String = Application.ProductName

        ' Save connection settings for this profile
        SaveSetting(s, "dbsection_" & profileName, "Data Source", Txtdbserver.Text)
        SaveSetting(s, "dbsection_" & profileName, "User ID", Txtdbuser.Text)
        SaveSetting(s, "dbsection_" & profileName, "password", Txtdbpassword.Text)
        SaveSetting(s, "dbsection_" & profileName, "Initial Catalog", Cbxdbname.Text)

        ' Get existing profile list
        Dim existing = GetSetting(s, "profiles", "list", "")
        Dim profiles = If(existing <> "", existing.Split(","c).ToList(), New List(Of String))

        ' Add new profile if not in list
        If Not profiles.Contains(profileName) Then
            profiles.Add(profileName)
            SaveSetting(s, "profiles", "list", String.Join(",", profiles))
        End If

        MsgBox("Settings for profile '" & profileName & "' successfully saved.", MsgBoxStyle.Information)

        'If MsgBox("Restart program now?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        '    Application.Restart()
        'End If
    End Sub

    Private Sub DeleteProfile(profileName As String)
        Dim s As String = Application.ProductName

        ' Delete the profile's DB settings
        DeleteSetting(s, "dbsection_" & profileName)

        ' Update profile list
        Dim existing = GetSetting(s, "profiles", "list", "")
        Dim profiles = existing.Split(","c).Where(Function(p) Not String.IsNullOrWhiteSpace(p)).ToList()

        If profiles.Contains(profileName) Then
            profiles.Remove(profileName)
            SaveSetting(s, "profiles", "list", String.Join(",", profiles))
        End If

        ' Clear last used if it was the one deleted
        If GetSetting(s, "profiles", "lastUsed", "") = profileName Then
            SaveSetting(s, "profiles", "lastUsed", "")
        End If

        MsgBox("Profile '" & profileName & "' deleted.", MsgBoxStyle.Information)
    End Sub

    Private Sub LoadProfilesToComboBox()

        ' Get the comma-separated profile names from registry
        Dim profilesStr As String = GetSetting(Application.ProductName, "profiles", "list", "")

        ' Convert the string into a list of profile names
        Dim profileList As List(Of String) = profilesStr.Split(","c).Where(Function(p) Not String.IsNullOrWhiteSpace(p)).ToList()

        ' Clear and load profiles into ComboBox1
        CbxConnection.Items.Clear()
        CbxConnection.Items.AddRange(profileList.ToArray())

        FrmLogin.CbxSelectServer.Items.Clear()
        FrmLogin.CbxSelectServer.Items.AddRange(profileList.ToArray())


    End Sub

End Class