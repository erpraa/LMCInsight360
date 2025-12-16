Imports LMCInsight360.ClassFunction
Imports LMCInsight360.CryptoEngine
Module GlobalConnection

    'Public strServerName, strUser, strPassword, strDatabase, SqlConnect As String

    'Temporary only
    Public strServerName = "192.168.200.90"
    Public strUser = "fa"
    Public strPassword = "update1012225"
    Public strDatabase = "LMCMSTRPT"

    Public SqlConnect = $"Data Source='{strServerName}';User ID='{strUser}';password='{strPassword}';Initial Catalog='{strDatabase}';MultipleActiveResultSets=True"

    Public CasConnect As String = GetConnectionString("L4P")
    Public ResConnect As String = GetConnectionString("LRP")

    Public DispCasConnect As String = DispConnection("L4P")
    Public DispResConnect As String = DispConnection("LRP")

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
