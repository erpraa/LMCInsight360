Imports LMCInsight360.ClassFunction
Imports LMCInsight360.CryptoEngine
Module GlobalConnection

    'Public SqlConnect As String = "Server=Localhost;Database=LMCMSTRPT;User Id=sa;Password=wasad123;"
    Public SqlConnect As String = "Server=Localhost;Database=LMCMSTRPT;Integrated Security=True;TrustServerCertificate=True"

    Public CasConnect As String = GetConnectionString("L4P")
    Public ResConnect As String = GetConnectionString("LRP")

    Private Function GetConnectionString(ByVal sapCode As String) As String
        Dim data = GetMultiValues($"SELECT * FROM SAP_CONNECTION WHERE SAP = '{sapCode}'")
        If data.Count > 0 Then
            Dim row = data(0)
            Return $"Server={row("SERVER")};UserId={DataDecrypt(row("USERID"), AppSecurity)};Password={DataDecrypt(row("PASSWORD"), AppSecurity)}"
        End If
        Return ""
    End Function

End Module
