Public Class SubQuery

#Region "Annex A Report"
    Public Shared Function RptQueryIS(FiscalYear As String, PostingPeriod As String, TrxOrigin As String, busUnit As String, FSItem As String, PurcH As Boolean, businessType As String) As String

        Dim Gscript As String

        Dim pTrxOrigin As String = Nothing
        Dim pbusUnit As String = Nothing
        Dim pFSItem As String = Nothing


        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If busUnit <> Nothing Then

            If businessType = "FOODSTUFF" Then
                pbusUnit = $"and busUnit1='{busUnit}'"
            Else
                pbusUnit = $"and busUnit2='{busUnit}'"
            End If

        End If

        If FSItem <> Nothing Then
            pFSItem = $"and FSItem='{FSItem}'"
        End If

        If PurcH = False Then
            Gscript = $"select SUM(Amount) from vwFI_GLREPORT where FiscalYear IN ({FiscalYear}) and PostingPeriod IN ({PostingPeriod}) {pTrxOrigin} {pbusUnit} {pFSItem}"
        Else
            Gscript = $"select SUM(Amount) from vwFI_PURCHREPORT where FiscalYear IN ({FiscalYear}) and PostingPeriod IN ({PostingPeriod}) {pTrxOrigin} {pbusUnit} "
        End If

        Return Gscript
    End Function

    Public Shared Function RptQueryBS(FiscalYear As String, PostingPeriod As String, TrxOrigin As String, FSItem As String, businessType As String) As String

        Dim GscriptBS As String
        Dim pTrxOrigin As String = Nothing
        Dim pFSItem As String = Nothing
        Dim pbusUnit As String

        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If FSItem <> Nothing Then
            pFSItem = $"and FSItem='{FSItem}'"
        End If

        If businessType = "FOODSTUFF" Then
            pbusUnit = $"and BusType='Foodstuff Only'"
        Else
            pbusUnit = Nothing
        End If


        GscriptBS = $"select SUM(Amount) from vwFI_GLREPORT where FiscalYear IN ({FiscalYear}) and PostingPeriod IN ({PostingPeriod}) {pTrxOrigin} {pFSItem} {pbusUnit}"

        Return GscriptBS
    End Function

#End Region

#Region "Annex B Report"
    Public Shared Function RptQueryBIS(FiscalYear As String, PostingPeriod As String, TrxOrigin As String, FSItem As String, businessType As String) As String
        Dim Gresult As String
        Dim pTrxOrigin As String = Nothing
        Dim pbusinessType As String = Nothing


        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If businessType = "FOODSTUFF" Then
            pbusinessType = $"and BusType='Foodstuff Only'"
        End If


        Gresult = $"Select SUM(Amount) from vwFI_GLREPORT where FiscalYear={FiscalYear} and PostingPeriod IN ({PostingPeriod}) and FSItem='{FSItem}' {pTrxOrigin} {pbusinessType}"

        Return Gresult
    End Function


    Public Shared Function RptQueryGaae(FiscalYear As String, PostingPeriod As String, FSItem As String, GLaccnt As Integer, TrxOrigin As String, businessType As String) As String
        Dim Gresult As String
        Dim pTrxOrigin As String = Nothing
        Dim pbusinessType As String = Nothing


        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If businessType = "FOODSTUFF" Then
            pbusinessType = $"and BusType='Foodstuff Only'"
        End If


        Gresult = $"Select SUM(Amount) from vwFI_GLREPORT where FiscalYear={FiscalYear} and PostingPeriod IN ({PostingPeriod}) and FSItem='{FSItem}' and GLAccount={GLaccnt} {pTrxOrigin} {pbusinessType}"

        Return Gresult
    End Function




#End Region




#Region "CtrDataInitializeFI Module"
    Public NotInheritable Class Datainialized
        Public Shared ReadOnly Property DelTrxDetails As String
            Get
                Return "DELETE FROM FI_TRXDETAILS WHERE POPER=@PostingPeriod AND RYEAR=@FiscalYear"
            End Get
        End Property

        Public Shared ReadOnly Property DelTrxData As String
            Get
                Return "DELETE FROM FI_TRXDATA WHERE POPER=@PostingPeriod AND RYEAR=@FiscalYear"
            End Get
        End Property
        Public Shared ReadOnly Property UpdateLoadDate As String
            Get
                Return "UPDATE FI_PSTNGPRD SET LDDATE=@loaddate, PSTBY=@postby WHERE POPER=@PostingPeriod AND RYEAR=@FiscalYear"
            End Get
        End Property

        Public Shared ReadOnly Property UpdatePostDate As String
            Get
                Return "UPDATE FI_PSTNGPRD SET PSTDATE=@postdate, PSTBY=@postby, PSTATS=@poststat WHERE POPER=@PostingPeriod AND RYEAR=@FiscalYear"
            End Get
        End Property

        Public Shared ReadOnly Property UpdatePostStatus As String
            Get
                Return "UPDATE FI_PSTNGPRD SET PSTDATE=@postdate, PSTBY=@postby, PSTATS=@poststat WHERE POPER=@PostingPeriod AND RYEAR=@FiscalYear"
            End Get
        End Property

        Public Shared ReadOnly Property InsertNewPeriod As String
            Get
                Return "INSERT INTO FI_PSTNGPRD (POPER, RYEAR) VALUES (@PostingPeriod, @FiscalYear)"
            End Get
        End Property

        Public Shared ReadOnly Property ViewPostingPeriod As String
            Get
                Return "Select DATENAME(MONTH, DATEFROMPARTS(2000, POPER, 1)) AS PostingPeriod,
                         RYEAR AS FiscalYear,
                         LDDATE AS LoadDate,
                         PSTDATE AS CloseDate,
                         PSTATS AS Status,
                         PSTBY AS Account
                         FROM FI_PSTNGPRD
                         WHERE RYEAR IN (YEAR(GETDATE()) - 1, YEAR(GETDATE())) order by RYEAR,POPER;"
            End Get
        End Property

         Public Shared ReadOnly Property SelectSKAT As String
            Get
                Return "Trim(LEADING '0' FROM SAKNR) AS SAKNR,KTOPL,SPRAS,TXT20,TXT50,MCOD1 From SAPHANADB.SKAT Where MANDT = '800' And KTOPL = '1000' AND SPRAS='E'"
            End Get
        End Property

          Public Shared ReadOnly Property SelectSKB1 As String
            Get
                Return "Trim(LEADING '0' FROM SAKNR) AS SAKNR,BUKRS,TO_VARCHAR(TO_DATE(ERDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS ERDAT,ERNAM,FDLEV,FIPLS,FSTAG,HBKID,HKTID,MITKZ,MWSKZ,WAERS,XGKON,XINTB,XKRES,XOPVW,XSPEB,ZINRT,ZUAWA,XMWNO,XSALH From SAPHANADB.SKB1 Where MANDT = '800' And BUKRS = '2000'ORDER BY SAKNR;"
            End Get
        End Property

       Public Shared ReadOnly Property SelecT004G As String
            Get
                Return "FSTAG,SPRAS,BUKRS,FSTTX From SAPHANADB.T004G  Where MANDT = '800' And BUKRS = '1000' AND SPRAS='E'"
            End Get
        End Property

    End Class

#End Region

End Class
