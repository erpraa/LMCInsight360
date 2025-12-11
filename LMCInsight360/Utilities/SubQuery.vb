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



    Public Shared Function RptQueryUnFxF(FiscalYear As String, PostingPeriod As String, FSItem As String, TCurrency As String, TrxOrigin As String, businessType As String) As String
        Dim Gresult As String
        Dim pTrxOrigin As String = Nothing
        Dim pbusinessType As String = Nothing


        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If businessType = "FOODSTUFF" Then
            pbusinessType = $"and BusType='Foodstuff Only'"
        End If

        Gresult = $"SELECT TOP 1 RunningTotal FROM (
                    SELECT 
                    TCCurrency,
                    PostingPeriod,
                    SUM(TCAmount) AS MonthlyTotal,
                    SUM(SUM(TCAmount)) OVER (PARTITION BY TCCurrency ORDER BY PostingPeriod ROWS UNBOUNDED PRECEDING) AS RunningTotal
                  FROM vwFI_GLREPORT
                  WHERE FiscalYear = {FiscalYear} AND PostingPeriod <= {PostingPeriod}
                    AND FSItem='{FSItem}'
                    AND TCCurrency='{TCurrency}'
                    {pTrxOrigin} {pbusinessType}
                    GROUP BY TCCurrency, PostingPeriod
                    ) x
                    ORDER BY PostingPeriod DESC;"

        Return Gresult
    End Function

    Public Shared Function RptQueryUnFxP(FiscalYear As String, PostingPeriod As String, FSItem As String, TrxOrigin As String, businessType As String) As String
        Dim Gresult As String
        Dim pTrxOrigin As String = Nothing
        Dim pbusinessType As String = Nothing


        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"AND f.TRX_ORIGIN='{TrxOrigin}'"
        End If

        If businessType = "FOODSTUFF" Then
            pbusinessType = "AND b.BSTYPE='Foodstuff Only'"
        End If

        Gresult = $"SELECT SUM(f.HSL) AS TotalHSL
                    FROM dbo.FI_VACDOCA f
                    INNER JOIN vwFI_GETGLGRP g ON LEFT(LTRIM(RTRIM(f.SGTXT)), 6) = CAST(g.SAKNR AS VARCHAR(20))
                    LEFT JOIN FI_BRANCH b ON f.PRCTR = b.PRCTR 
                    WHERE 
                    f.AUGDT IS NULL
                    AND f.GJAHR = {FiscalYear} AND f.POPER = {PostingPeriod}
	                AND g.CTM1 = '{FSItem}'
                    {pTrxOrigin} {pbusinessType}"

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

        Public Shared ReadOnly Property SelecLFA1 As String
            Get
                Return "Trim(LEADING '0' FROM LIFNR) AS LIFNR,LAND1,NAME1,NAME2,STRAS,ORT01,PSTLZ,STCEG,KTOKK FROM SAPHANADB.LFA1 where KTOKK='BANK' and MANDT='800'"
            End Get
        End Property

        Public Shared ReadOnly Property SelectBSEG As String
            Get
                Return "BUKRS
      ,H_BLART
      ,KOART
      ,SHKZG
      ,TRIM(LEADING '0' FROM LIFNR) AS LIFNR
      ,TRIM(LEADING '0' FROM BELNR) AS BELNR
      ,AUGBL
      ,GJAHR
      ,TRIM(LEADING '0' FROM BUZEI) AS BUZEI
      ,TO_VARCHAR(TO_DATE(H_BLDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS H_BLDAT
      ,TO_VARCHAR(TO_DATE(H_BUDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS H_BUDAT
      , CASE 
          WHEN AUGDT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(AUGDT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS AUGDT
       , CASE 
          WHEN AUGCP = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(AUGCP, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS AUGCP
        , CASE 
          WHEN FDTAG = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(FDTAG, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS FDTAG        
              , CASE 
          WHEN VALUT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(VALUT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS VALUT         
    , CASE 
          WHEN SK1DT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(SK1DT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS SK1DT
       , CASE 
          WHEN SK2DT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(SK2DT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS SK2DT
      ,PSWSL
      ,WRBTR
      ,RFCCUR
      ,DMBTR
      ,MWSTS
      ,WMWST
      ,BSCHL
      ,ZUONR
      ,SGTXT
      ,KOKRS
      ,TRIM(LEADING '0' FROM HKONT) AS HKONT
      ,PRCTR
      ,TO_VARCHAR(CURRENT_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS.FF3') AS UpdateDate
FROM SAPHANADB.BSEG where H_BLART='KA'"
            End Get
        End Property

        Public Shared ReadOnly Property SelectACDOCA As String
            Get
                Return "BELNR
      ,RLDNR
      ,BLART    
  	,CASE 
          WHEN BLDAT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(BLDAT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS BLDAT    
      
      ,CASE 
          WHEN BUDAT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(BUDAT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS BUDAT 
	 ,CASE 
          WHEN AUGDT = '00000000' THEN NULL
          ELSE TO_VARCHAR(TO_DATE(AUGDT, 'YYYYMMDD'), 'YYYY-MM-DD') 
        END AS AUGDT 
      ,GJAHR
      ,POPER
      ,RBUKRS
      ,TRIM(LEADING '0' FROM RACCT) AS RACCT
      ,PRCTR
      ,RCNTR
      ,LIFNR
      ,TRIM(LEADING '0' FROM GKONT) AS GKONT
      ,BSCHL
      ,BTTYPE
      ,DOCLN
      ,RWCUR
      ,WSL
      ,RHCUR
      ,HSL
      ,SGTXT
      ,ZUONR
      ,GKOAR
      ,DRCRK
      ,SDM_VERSION
      ,TO_VARCHAR(CURRENT_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS.FF3') AS UpdateDate
  FROM SAPHANADB.ACDOCA where (RACCT IN ('0000721001','0000721004','0000721005') OR GKONT IN ('0000721002','0000721006'))"
            End Get
        End Property

    End Class


    Public Shared Function SelectTCURR(FiscalYear As String, PostingPeriod As String)
        Dim Gresult As String

        Gresult = $"select * from ( 
            SELECT KURST,FCURR,TCURR,TO_VARCHAR(TO_DATE(TO_VARCHAR(99999999 - GDATU), 'YYYYMMDD'),'YYYY-MM-DD') AS GDATU,UKURS,
            TO_VARCHAR(CURRENT_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS.FF3') AS UpdateDate
            FROM SAPHANADB.TCURR WHERE MANDT = '800' AND KURST = 'M' ) Temp
            WHERE year(GDATU)={FiscalYear} and  month(GDATU)={PostingPeriod}"

        Return Gresult

    End Function

    Public Shared Function SelectBKPF(TrxOrg As String, FiscalYear As String, PostingPeriod As String)
        Dim Gresult As String

        Gresult = $"SELECT '{TrxOrg}' as TRX_ORIGIN,
                    BUKRS,
                    BELNR,
                    GJAHR,
                    BLART,
                    TO_VARCHAR(TO_DATE(BLDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS BLDAT,
                    TO_VARCHAR(TO_DATE(CPUDT, 'YYYYMMDD'), 'YYYY-MM-DD') AS CPUDT,
                    TO_VARCHAR(TO_DATE(BUDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS BUDAT,
                    MONAT,
                    KURSF,
                    TO_VARCHAR(CURRENT_TIMESTAMP, 'YYYY-MM-DD HH24:MI:SS.FF3') AS UpdateDate
                    FROM SAPHANADB.BKPF where MANDT='800' and KURSF > 1 and  GJAHR={FiscalYear} and MONAT={PostingPeriod}"

        Return Gresult

    End Function

#End Region
End Class
