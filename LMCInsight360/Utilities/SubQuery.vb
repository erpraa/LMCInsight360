Public Class SubQuery


    Public Shared Function RptQuery(FiscalYear As String, PostingPeriod As String, TrxOrigin As String, busUnit As String, FSItem As String, PurcH As Boolean, businessType As String) As String

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
        'test123 - 456 -789
        Dim GscriptBS As String
        Dim pTrxOrigin As String = Nothing
        Dim pFSItem As String = Nothing
        Dim pbusinessType As String = Nothing

        If TrxOrigin <> Nothing Then
            pTrxOrigin = $"and TrxOrigin='{TrxOrigin}'"
        End If

        If FSItem <> Nothing Then
            pFSItem = $"and FSItem='{FSItem}'"
        End If

        GscriptBS = $"select SUM(Amount) from vwFI_GLREPORT where FiscalYear IN ({FiscalYear}) and PostingPeriod IN ({PostingPeriod}) {pTrxOrigin} {pFSItem} {pbusinessType}"

        Return GscriptBS
    End Function

End Class
