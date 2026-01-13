Imports LMCInsight360.ClassFunction
Imports LMCInsight360.CryptoEngine
Imports System.Data.SqlClient
Module GlobalConnection

    Public strServerName, strUser, strPassword, strDatabase, SqlConnect As String
    Public CasConnect, ResConnect, DispCasConnect, DispResConnect As String

    Public Sub GConnection(profileName As String)
        Fetchsettings(profileName)
        SqlConnect = $"Data Source='{strServerName}';User ID='{strUser}';password='{strPassword}';Initial Catalog='{strDatabase}';MultipleActiveResultSets=True"

        Using conn As New SqlConnection(SqlConnect)
            Try
                conn.Open()
            Catch ex As Exception
                MsgBox("Connection Failed: " & ex.Message)
                FrmLogin.Show()
            End Try
        End Using

        CasConnect = GetConnectionString("L4P")
        ResConnect = GetConnectionString("LRP")

        DispCasConnect = DispConnection("L4P")
        DispResConnect = DispConnection("LRP")

    End Sub

    Public Sub Fetchsettings(profileName As String)
        Dim s As String = Application.ProductName
        strServerName = GetSetting(s, "dbsection_" & profileName, "Data Source", "")
        strUser = GetSetting(s, "dbsection_" & profileName, "User ID", "")
        strPassword = GetSetting(s, "dbsection_" & profileName, "password", "")
        strDatabase = GetSetting(s, "dbsection_" & profileName, "Initial Catalog", "")
    End Sub

    Private Function GetConnectionString(ByVal sapCode As String) As String
        Dim data = GetMultiValues($"SELECT * FROM SAP_CONNECTION WHERE SAP = '{sapCode}'")
        If data.Count > 0 Then
            Dim row = data(0)
            Return $"Server={row("SERVER")};UserId={DataDecrypt(row("USERID"), AppSecurity)};Password={DataDecrypt(row("PASSWORD"), AppSecurity)}"
        End If
        Return ""
    End Function

    Private Function DispConnection(ByVal sapCode As String) As String
        Dim data = GetMultiValues($"SELECT * FROM SAP_CONNECTION WHERE SAP = '{sapCode}'")
        If data.Count > 0 Then
            Dim row = data(0)
            Return row("SERVER")
        End If
        Return ""
    End Function

End Module
