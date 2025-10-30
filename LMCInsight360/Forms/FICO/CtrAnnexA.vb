Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
Imports LMCInsight360.SubQuery

Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports System.Runtime.InteropServices

Public Class CtrAnnexA

    Dim BtnAnnexA As Integer

    Private Sub CtrFtr_AnnexA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnAnnexA = Gbl_ReportTag
        LastDateLoad()
        TxtYear.Text = Date.Now.Year.ToString()

        PnlReportType.Show()

        Select Case BtnAnnexA
            Case 1
                PnlReportType.Show()
            Case 2
                PnlReportType.Hide()
            Case 3
                PnlReportType.Hide()
            Case 4
                PnlReportType.Hide()
        End Select
    End Sub

#Region "Generate Annex A Report"

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click

        If String.IsNullOrWhiteSpace(CbxMonth.Text) Then
            MessageBox.Show("Please input Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtYear.Text) Then
            MessageBox.Show("Please input Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim yearValue As Integer
        If Not Integer.TryParse(TxtYear.Text, yearValue) Then
            MessageBox.Show("Year must be a valid number.", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If yearValue < 2000 OrElse yearValue > 2100 Then
            MessageBox.Show("Please enter a valid year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If GetValue($"Select count(*) from FI_TRXDATA where RYEAR={TxtYear.Text} and POPER={GetMonthNumber(CbxMonth.EditValue)}") = 0 Then
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show("This report may take several minutes to generate. Do you want to continue?", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then

            Select Case BtnAnnexA
                    Case 1
                        Generate_IncomeStatement()
                    Case 2
                        Generate_BalanceSheet()
                        PnlReportType.Show()
                    Case 3
                        Generate_DetailSchedule()
                    Case 4
                        Generate_AnnexA()
                End Select

            End If

    End Sub
    Private Sub Generate_AnnexA()

        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String

        If CbxSapSource.EditValue = "CAS" Then
            sapSource = "L4P"
        ElseIf CbxSapSource.EditValue = "Reserved" Then
            sapSource = "LRP"
        Else
            sapSource = Nothing
        End If

        ' Create Excel only once
        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        ' Delete extra sheets, keep only Sheet1
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next


        If CbxBusinessType.EditValue = "FOODSTUFF" Then
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, False)
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, False)
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, False)
        ElseIf CbxBusinessType.EditValue = "OVERALL" Then
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, True)
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, False)
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, False)
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, False)
        Else

            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, False)

            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, False)
            FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, False)

            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, False)
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, False)

            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, False)
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, False)

        End If

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        ' Cleanup COM
        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)

        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

#End Region

#Region "Income Statement Report"

    Private Sub Generate_IncomeStatement()

        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String

        If CbxSapSource.EditValue = "CAS" Then
            sapSource = "L4P"
        ElseIf CbxSapSource.EditValue = "Reserved" Then
            sapSource = "LRP"
        Else
            sapSource = Nothing
        End If

        ' Create Excel only once
        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        ' Delete extra sheets, keep only Sheet1
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next

        If RbtnMonthly.Checked Then

            If CbxBusinessType.EditValue = "FOODSTUFF" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
            ElseIf CbxBusinessType.EditValue = "OVERALL" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, True)
            Else
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, False)
            End If

        ElseIf RbtnAccum.Checked Then

            If CbxBusinessType.EditValue = "FOODSTUFF" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, True)
            ElseIf CbxBusinessType.EditValue = "OVERALL" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, True)
            Else
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, True)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, False)
            End If

        ElseIf RbtnBoth.Checked Then

            If CbxBusinessType.EditValue = "FOODSTUFF" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, False)
            ElseIf CbxBusinessType.EditValue = "OVERALL" Then
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, True)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, False)
            Else

                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Monthly", wbook, True)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", "Accum", wbook, False)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Monthly", wbook, False)
                FS_IncomeStatement(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", "Accum", wbook, False)

            End If

        End If

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        ' Cleanup COM
        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)

        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

    Private Sub FS_IncomeStatement(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String, businessType As String, ReportType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)

        Dim wsheet As Excel.Worksheet = Nothing

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            ' Report Parameters
            Dim fsItem As String = Nothing
            Dim fMonth As String = Nothing
            Dim fYear As String = fiscalYear
            Dim includePurchases As Boolean = False
            Dim saptitle As String = Nothing

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 7

            With wsheet

                Dim reportDate = New Date(CInt(fiscalYear), fiscalMonth, Date.DaysInMonth(CInt(fiscalYear), fiscalMonth))

                'Report Title
                If sapSource = "L4P" Then
                    saptitle = " (CAS)"
                ElseIf sapSource = "LRP" Then
                    saptitle = " (Reserved)"
                End If

                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = $"FOODSTUFF INCOME STATEMENT{saptitle}"
                Else
                    .Cells(2, 1).Value = $"CONSOLIDATED INCOME STATEMENT{saptitle}"
                End If

                If ReportType = "Monthly" Then

                    If businessType = "FOODSTUFF" Then
                        .Name = $"IS {MonthName(fiscalMonth, True)} {fiscalYear} Monthly Food"
                        .Cells(3, 1).Value = "For the Month Ended " & reportDate.ToString("MMMM dd, yyyy")
                    Else
                        .Name = $"IS {MonthName(fiscalMonth, True)} {fiscalYear} Monthly Overall"
                        .Cells(3, 1).Value = "For the Month Ended " & reportDate.ToString("MMMM dd, yyyy")
                    End If

                ElseIf ReportType = "Accum" Then

                    If businessType = "FOODSTUFF" Then
                        .Name = $"IS {MonthName(fiscalMonth, True)} {fiscalYear} Food Accum"
                        .Cells(3, 1).Value = "For " & NumberToWords(fiscalMonth) & " Months Ended " & reportDate.ToString("MMMM dd, yyyy")
                    Else
                        .Name = $"IS {MonthName(fiscalMonth, True)} {fiscalYear} Overall Accum"
                        .Cells(3, 1).Value = "For " & NumberToWords(fiscalMonth) & " Months Ended " & reportDate.ToString("MMMM dd, yyyy")
                    End If

                End If

                .Cells(1, 1).Font.Size = 14
                .Cells(2, 1).Font.Size = 14
                .Cells(3, 1).Font.Size = 10

                ' Load Branches (header)
                Dim branches As New List(Of KeyValuePair(Of String, Integer))()

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()

                    Dim branchQuery, hdesc, rptsrt As String

                    If businessType = "FOODSTUFF" Then
                        branchQuery = "SELECT DISTINCT HDESC1, RPTSRT1 FROM FI_BRANCH WHERE BSTYPE = 'Foodstuff Only' ORDER BY RPTSRT1"
                        hdesc = "HDESC1"
                        rptsrt = "RPTSRT1"
                    Else
                        branchQuery = "SELECT DISTINCT HDESC2, RPTSRT2 FROM FI_BRANCH ORDER BY RPTSRT2"
                        hdesc = "HDESC2"
                        rptsrt = "RPTSRT2"
                    End If

                    Using cmd As New SqlCommand(branchQuery, conn)
                        Using reader = cmd.ExecuteReader()
                            While reader.Read()
                                branches.Add(New KeyValuePair(Of String, Integer)(reader(hdesc).ToString(), CInt(reader(rptsrt))))
                            End While
                        End Using
                    End Using
                End Using

                ' Print Branch Headers
                col = baseCol
                For Each br In branches
                    .Cells(5, col) = br.Key
                    SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                    SetBackFontColor(wsheet, 5, col, "", "169,169,169")

                    col += 1

                    If businessType = "FOODSTUFF" Then
                        If br.Key = "Marshmallows" Then
                            .Cells(5, col).Value = "Total Foodstuff"
                            SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                            SetBackFontColor(wsheet, 5, col, "", "169,169,169")
                            col += 1
                        End If
                    End If

                Next

                ' Insert GrandTotal
                .Cells(5, col).Value = "Grand Total"
                SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                SetBackFontColor(wsheet, 5, col, "", "169,169,169")

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, col)), Nothing, Nothing)
                Next

                col = baseCol
                row = baseRow

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()
                    Dim rptQuery As String = "SELECT * FROM FI_RPTFORMAT WHERE RPTTYPE = 'IS' ORDER BY RPTSRT"
                    Using cmd As New SqlCommand(rptQuery, conn)
                        Using reader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()

                                    .Cells(row, 1) = reader("RPTDISPLY").ToString()
                                    .Cells(row, 1).Font.Size = reader("TSIZE").ToString()
                                    SetBottomBorder(wsheet, row, 1, reader("ULINE").ToString().Trim())

                                    Dim totalBranches As Integer = branches.Count
                                    Dim i As Integer = 0

                                    For Each br In branches
                                        i += 1
                                        If reader("RPTDISPLY").ToString() <> "" Then

                                            fsItem = reader("ERGSL").ToString()

                                            If fsItem <> "" AndAlso fsItem <> "SKP" Then

                                                ' Determine fiscal month logic
                                                Select Case fsItem
                                                    Case "10" ' Inventory

                                                        If reader("DCFLG").ToString() = "N" Then 'Ending
                                                            fMonth = String.Join(",", Enumerable.Range(1, CInt(fiscalMonth)))
                                                            fYear = fiscalYear

                                                        Else 'Beginning

                                                            If ReportType = "Monthly" Then

                                                                If fiscalMonth = 1 Then  'December Previous Year
                                                                    fMonth = 12
                                                                    fYear = fiscalYear - 1
                                                                Else
                                                                    fMonth = String.Join(",", Enumerable.Range(1, CInt(fiscalMonth - 1)))
                                                                    fYear = fiscalYear
                                                                End If

                                                            ElseIf ReportType = "Accum" Then

                                                                fMonth = "1,2,3,4,5,6,7,8,9,10,11,12"
                                                                fYear = fiscalYear - 1

                                                            End If
                                                        End If

                                                        includePurchases = False

                                                    Case "P" ' Purchases
                                                        If ReportType = "Monthly" Then
                                                            fMonth = fiscalMonth
                                                        ElseIf ReportType = "Accum" Then
                                                            fMonth = String.Join(",", Enumerable.Range(1, CInt(fiscalMonth)))
                                                        End If

                                                        fYear = fiscalYear
                                                        includePurchases = True

                                                    Case Else
                                                        If ReportType = "Monthly" Then
                                                            fMonth = fiscalMonth
                                                        ElseIf ReportType = "Accum" Then
                                                            fMonth = String.Join(",", Enumerable.Range(1, CInt(fiscalMonth)))
                                                        End If

                                                        fYear = fiscalYear
                                                        includePurchases = False

                                                End Select

                                                .Cells(row, col) = AdjustValue(Val(GetAmount(RptQueryIS(fYear, fMonth, sapSource, br.Key, fsItem, includePurchases, businessType))), reader("DCFLG").ToString())

                                                ApplyCellFormat(.Cells(row, col), reader)
                                                SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                            End If

                                            ' Apply formulas
                                            If reader("FRMLA").ToString() <> "" Then
                                                .Cells(row, col).Formula = GetExcelFormula(reader("FRMLA").ToString(), col)
                                                ApplyCellFormat(.Cells(row, col), reader)
                                                SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                            End If

                                            col += 1

                                            'Total 
                                            If fsItem <> "SKP" Then

                                                If businessType = "FOODSTUFF" Then
                                                    ' Insert TotalFoodstuff
                                                    If br.Key = "Marshmallows" Then
                                                        .Cells(row, col).Formula = $"=SUM(B{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), reader)
                                                        SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                                        col += 1
                                                    End If

                                                    ' Insert Total only at the last branch - Foodstuff
                                                    If i = totalBranches Then
                                                        .Cells(row, col).Formula = $"=SUM({GetExcelColName(col - 2)}{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), reader)
                                                        SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                                        col += 1
                                                    End If

                                                Else
                                                    ' Insert Total only at the last branch - Overall
                                                    If i = totalBranches Then
                                                        .Cells(row, col).Formula = $"=SUM(B{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), reader)
                                                        SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                                        col += 1
                                                    End If

                                                End If

                                            End If

                                        End If

                                    Next

                                    row += 1
                                    col = baseCol
                                End While
                            End If
                        End Using
                    End Using
                End Using

                'Final Format
                .Range("B6").Select()
                .Application.ActiveWindow.FreezePanes = True
                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

            End With

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating the Income Statement: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

#Region "Balance Sheet Report"
    Private Sub Generate_BalanceSheet()

        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String

        If CbxSapSource.EditValue = "CAS" Then
            sapSource = "L4P"
        ElseIf CbxSapSource.EditValue = "Reserved" Then
            sapSource = "LRP"
        Else
            sapSource = Nothing
        End If

        ' Create Excel only once
        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        ' Delete extra sheets, keep only Sheet1
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next

        If CbxBusinessType.EditValue = "FOODSTUFF" Then
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, True)
        ElseIf CbxBusinessType.EditValue = "OVERALL" Then
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, True)
        Else
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, True)
            FS_BalanceSheet(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, False)
        End If

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        ' Cleanup COM
        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)

        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()

        SplashScreenManager.CloseDefaultWaitForm()

    End Sub


    Private Sub FS_BalanceSheet(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)

        Dim wsheet As Excel.Worksheet = Nothing

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            ' Report Parameters
            Dim fsItem As String = Nothing
            Dim saptitle As String = Nothing

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 5

            With wsheet

                Dim reportDate = New Date(CInt(fiscalYear), fiscalMonth, Date.DaysInMonth(CInt(fiscalYear), fiscalMonth))

                'Report Title
                If sapSource = "L4P" Then
                    saptitle = " (CAS)"
                ElseIf sapSource = "LRP" Then
                    saptitle = " (Reserved)"
                End If

                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = $"BALANCE SHEET - FOODSTUFF ONLY{saptitle}"
                    .Name = $"BS {MonthName(fiscalMonth, True)} {fiscalYear} Food"
                Else
                    .Cells(2, 1).Value = $"BALANCE SHEET - OVERALL{saptitle}"
                    .Name = $"BS {MonthName(fiscalMonth, True)} {fiscalYear} Overall"
                End If

                .Cells(3, 1).Value = "As of " & reportDate.ToString("MMMM dd, yyyy")

                .Cells(1, 1).Font.Size = 14
                .Cells(2, 1).Font.Size = 13
                .Cells(3, 1).Font.Size = 12

                ' Load Month Names (header)
                Dim HeaderName As New List(Of KeyValuePair(Of String, Integer))()

                Dim prevMonth As Integer = 12
                Dim prevYear As Integer = fiscalYear - 1

                HeaderName.Add(New KeyValuePair(Of String, Integer)(MonthName(prevMonth, False) & " " & prevYear, prevMonth))

                For m As Integer = 1 To CInt(fiscalMonth)
                    HeaderName.Add(New KeyValuePair(Of String, Integer)(MonthName(m, False) & " " & fiscalYear, m))
                Next

                ' Print Month Name Headers
                col = baseCol
                For Each Mname In HeaderName
                    .Cells(7, col) = "'" & Mname.Key
                    .Cells(42, col) = "'" & Mname.Key
                    .Cells(7, col).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Cells(42, col).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    col += 1
                Next

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, col - 1)), "255,255,255", "31, 78, 120")
                Next

                With .Range(.Cells(5, 1), .Cells(5, col - 1))
                    .Merge()
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                End With

                With .Range(.Cells(40, 1), .Cells(40, col - 1))
                    .Merge()
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                End With

                col = baseCol
                row = baseRow

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()
                    Dim rptQuery As String = "SELECT * FROM FI_RPTFORMAT WHERE RPTTYPE = 'BS' ORDER BY RPTSRT"
                    Using cmd As New SqlCommand(rptQuery, conn)
                        Using reader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()

                                    .Cells(row, 1) = reader("RPTDISPLY").ToString()
                                    ApplyCellFormat(.Cells(row, 1), reader)

                                    If row <> 7 AndAlso row <> 42 Then
                                        SetBackFontColor(wsheet, row, 1, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())
                                    End If

                                    If row = 37 OrElse row = 73 Then
                                        SetBottomBorder(wsheet, row, 1, reader("ULINE").ToString().Trim())
                                    End If

                                    Dim totalmonth As Integer = HeaderName.Count
                                    Dim i As Integer = 0

                                    For Each Mname In HeaderName
                                        i += 1
                                        Dim fullName As String = Mname.Key
                                        Dim parts() As String = fullName.Split(" "c)
                                        Dim yearValue As Integer = CInt(parts(1))
                                        Dim monthValue As Integer = Mname.Value

                                        If reader("RPTDISPLY").ToString() <> "" Then

                                            fsItem = reader("ERGSL").ToString()

                                            If fsItem <> "" Then

                                                If businessType <> "FOODSTUFF" Then
                                                    If fsItem = "29" OrElse fsItem = "34" Then
                                                        GoTo Skip
                                                    End If
                                                End If
                                                .Cells(row, col) = AdjustValue(Val(GetAmount(RptQueryBS(yearValue, String.Join(",", Enumerable.Range(1, CInt(monthValue))), sapSource, fsItem, businessType))), reader("DCFLG").ToString())
Skip:

                                            End If

                                            ApplyCellFormat(.Cells(row, col), reader)
                                            SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                            SetBackFontColor(wsheet, row, col, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())

                                        End If

                                        ' Apply formulas
                                        If reader("FRMLA").ToString() <> "" Then
                                            .Cells(row, col).Formula = GetExcelFormula(reader("FRMLA").ToString(), col)
                                            ApplyCellFormat(.Cells(row, col), reader)
                                        End If
                                        col += 1
                                    Next
                                    row += 1
                                    col = baseCol
                                End While
                            End If
                        End Using
                    End Using
                End Using

                'Final Format
                .Range("B4").Select()
                .Application.ActiveWindow.FreezePanes = True
                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

                ' Hide previous months if there’s more than one
                Dim lastMonthCol As Integer = baseCol + HeaderName.Count - 1
                If HeaderName.Count > 1 Then
                    Dim firstMonthCol As Integer = baseCol + 1
                    Dim hideRange As Excel.Range = .Range(.Cells(7, firstMonthCol), .Cells(7, lastMonthCol - 1))
                        hideRange.EntireColumn.Hidden = True
                    End If

            End With

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating the Balance Sheet: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "Details Schedule Report"

    'Excel Formatting
    Private Const NUM_FMT As String = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"
    Private ReadOnly HEADER_COLOR As Integer = RGB(198, 224, 180)
    Private ReadOnly TOTAL_COLOR As Integer = RGB(91, 155, 213)

    Private Sub ApplyTitleStyle(rng As Excel.Range)
        With rng
            .Merge()
            .Interior.Color = HEADER_COLOR
            .Font.Color = System.Drawing.Color.Black
            .Font.Bold = True
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With
    End Sub

    Private Sub ApplySectionTotalStyle(rng As Excel.Range)
        With rng
            .Font.Bold = True
            .Interior.Color = TOTAL_COLOR
            .NumberFormat = NUM_FMT
        End With
    End Sub

    Private Sub ApplyNumberFormat(rng As Excel.Range)
        rng.NumberFormat = NUM_FMT
    End Sub

    Private Sub ApplyBorders(rng As Excel.Range, Optional isThick As Boolean = False)
        With rng.Borders
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = If(isThick, Excel.XlBorderWeight.xlMedium, Excel.XlBorderWeight.xlThin)
            .ColorIndex = 0
        End With
    End Sub

    'Main Entry
    Private Sub Generate_DetailSchedule()
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String = Nothing
        Select Case CbxSapSource.EditValue
            Case "CAS" : sapSource = "L4P"
            Case "Reserved" : sapSource = "LRP"
        End Select

        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        'Remove extra sheets
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next

        'Generate reports
        Dim yearVal = TxtYear.EditValue
        Dim monthVal = GetMonthNumber(CbxMonth.EditValue)

        Select Case CbxBusinessType.EditValue
            Case "FOODSTUFF"
                FS_DetailSchedule(yearVal, monthVal, sapSource, "FOODSTUFF", wbook, True)
            Case "OVERALL"
                FS_DetailSchedule(yearVal, monthVal, sapSource, "OVERALL", wbook, True)
            Case Else
                FS_DetailSchedule(yearVal, monthVal, sapSource, "FOODSTUFF", wbook, True)
                FS_DetailSchedule(yearVal, monthVal, sapSource, "OVERALL", wbook, False)
        End Select

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        'Cleanup
        Marshal.ReleaseComObject(wbook)
        Marshal.ReleaseComObject(excelApp)
        GC.Collect()
        GC.WaitForPendingFinalizers()

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

    Private Sub FS_DetailSchedule(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String,
                              businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)

        'initialize worksheet properly
        Dim wsheet As Excel.Worksheet =
    If(useFirstSheet,
       CType(wbook.Sheets(1), Excel.Worksheet),
       CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet))

        Dim baseCol As Integer = 2
        Dim baseRow As Integer = 6
        Dim row As Integer = baseRow
        Dim reportDate As New Date(fiscalYear, fiscalMonth, Date.DaysInMonth(fiscalYear, fiscalMonth))

        'Header 
        Dim saptitle As String = Nothing
        If sapSource = "L4P" Then
            saptitle = " (CAS)"
        ElseIf sapSource = "LRP" Then
            saptitle = " (Reserved)"
        End If

        With wsheet
            .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
            If businessType = "FOODSTUFF" Then
                .Cells(2, 1).Value = $"DETAILS SCHEDULE - FOODSTUFF ONLY{saptitle}"
                .Name = $"DS {MonthName(fiscalMonth, True)} {fiscalYear} Food"
            Else
                .Cells(2, 1).Value = $"DETAILS SCHEDULE - OVERALL{saptitle}"
                .Name = $"DS {MonthName(fiscalMonth, True)} {fiscalYear} Overall"
            End If

            .Cells(3, 1).Value = "As of " & reportDate.ToString("MMMM dd, yyyy")

            .Cells(1, 1).Font.Size = 14
            .Cells(2, 1).Font.Size = 13
            .Cells(3, 1).Font.Size = 12

            'Merge and style title rows
            For i As Integer = 1 To 3
                ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, baseCol + fiscalMonth)))
            Next

            'Year header
            Dim col As Integer = baseCol + fiscalMonth - 1
            .Range(.Cells(5, baseCol), .Cells(5, col + 1)).Merge()
            .Cells(5, baseCol).Value = "Year " & fiscalYear
            .Cells(5, baseCol).Font.Bold = True
            .Cells(5, baseCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            'Month headers
            For m As Integer = 1 To fiscalMonth
                .Cells(6, baseCol + m - 1).Value = MonthName(m, False)
                .Cells(6, baseCol + m - 1).Font.Bold = True
                .Cells(6, baseCol + m - 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Next
            .Cells(6, baseCol + fiscalMonth).Value = "TOTAL"
            .Cells(6, baseCol + fiscalMonth).Font.Bold = True
            .Cells(6, baseCol + fiscalMonth).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With

        'SQL Section 
        Dim totals(fiscalMonth - 1) As Decimal
        Dim grandTotal As Decimal = 0D
        Dim formatList As New List(Of Tuple(Of String, String))

        Using conn As New SqlConnection(SqlConnect)
            conn.Open()

            'Load report formats
            Using fmtCmd As New SqlCommand("SELECT RPTDISPLY, ERGSL FROM FI_RPTFORMAT WHERE RPTTYPE = 'DS' ORDER BY RPTSRT;", conn)
                Using fmtReader = fmtCmd.ExecuteReader()
                    While fmtReader.Read()
                        formatList.Add(New Tuple(Of String, String)(
                    If(fmtReader.IsDBNull(0), "", fmtReader.GetString(0)),
                    If(fmtReader.IsDBNull(1), "", fmtReader.GetString(1))
                ))
                    End While
                End Using
            End Using

            'Loop each FS Item 
            For Each fmt In formatList
                Dim rptDisplay = fmt.Item1
                Dim fsItem = fmt.Item2

                If rptDisplay <> "" Then
                    wsheet.Cells(row, 1).Value = rptDisplay
                    wsheet.Cells(row, 1).Font.Bold = True
                    row += 1
                End If
                If fsItem = "" Then Continue For

                '=========================================
                ' NEW LOGIC: Filter Setup
                '=========================================
                Dim bustypeList As String = ""
                Dim trxorigin As String = ""

                If businessType = "FOODSTUFF" Then
                    bustypeList = "AND BusType='Foodstuff Only'"
                End If

                If sapSource <> Nothing Then
                    trxorigin = $"AND TrxOrigin='{sapSource}'"
                End If
                '=========================================

                'Query data
                Dim allData As New Dictionary(Of String, Decimal())()
                Dim glOrder As New List(Of String)

                Using cmdAll As New SqlCommand($"
                SELECT CONCAT(GLAccount,' ',GLLngDesc) AS GLDesc, PostingPeriod, SUM(Amount) AS AMT
                FROM vwFI_GLREPORT
                WHERE FiscalYear=@FY AND PostingPeriod BETWEEN 1 AND @Max AND FSItem=@FSItem
                {bustypeList} {trxorigin}
                GROUP BY GLAccount, GLLngDesc, PostingPeriod
                ORDER BY GLAccount, PostingPeriod;", conn)

                    cmdAll.Parameters.AddWithValue("@FY", fiscalYear)
                    cmdAll.Parameters.AddWithValue("@Max", fiscalMonth)
                    cmdAll.Parameters.AddWithValue("@FSItem", fsItem)

                    Using rdr = cmdAll.ExecuteReader()
                        While rdr.Read()
                            Dim glDesc = rdr("GLDesc").ToString()
                            Dim period = CInt(rdr("PostingPeriod"))
                            Dim amt = CDec(rdr("AMT"))
                            If Not allData.ContainsKey(glDesc) Then
                                allData(glDesc) = New Decimal(fiscalMonth - 1) {}
                                glOrder.Add(glDesc)
                            End If
                            allData(glDesc)(period - 1) = amt
                        End While
                    End Using
                End Using

                'Flags
                Dim isFSItem38 As Boolean = (fsItem = "38")
                Dim isFSItem41 As Boolean = (fsItem = "41")

                'Output Rows 
                Dim sectionTotals(fiscalMonth - 1) As Decimal
                Dim sectionGrand As Decimal = 0D

                'FSItem 41 ( Only show total row )
                If isFSItem41 Then
                    For Each vals In allData.Values
                        Dim accumulated As Decimal = 0D
                        For m As Integer = 1 To fiscalMonth
                            accumulated += vals(m - 1)
                            sectionTotals(m - 1) += accumulated
                        Next
                    Next

                    wsheet.Cells(row, 1).Value = "Total " & rptDisplay
                    Dim secRng = wsheet.Range(wsheet.Cells(row, 1), wsheet.Cells(row, baseCol + fiscalMonth))
                    ApplySectionTotalStyle(secRng)

                    For m As Integer = 1 To fiscalMonth
                        wsheet.Cells(row, baseCol + m - 1).Value = sectionTotals(m - 1)
                        totals(m - 1) += sectionTotals(m - 1)
                    Next

                    ApplyBorders(secRng, True)
                    row += 2
                    Continue For
                End If

                'Normal FSItems
                For Each gld In glOrder
                    Dim vals = allData(gld)
                    wsheet.Cells(row, 1).Value = gld

                    Dim rowTotal As Decimal = 0D
                    Dim accumulated As Decimal = 0D

                    For m As Integer = 1 To fiscalMonth
                        Dim v As Decimal = vals(m - 1)
                        If isFSItem38 Then
                            accumulated += v
                            v = accumulated
                        End If
                        rowTotal += v
                        wsheet.Cells(row, baseCol + m - 1).Value = v
                        ApplyNumberFormat(wsheet.Cells(row, baseCol + m - 1))
                        sectionTotals(m - 1) += v
                    Next

                    If Not isFSItem38 Then
                        wsheet.Cells(row, baseCol + fiscalMonth).Value = rowTotal
                        ApplyNumberFormat(wsheet.Cells(row, baseCol + fiscalMonth))
                    End If

                    ApplyBorders(wsheet.Range(wsheet.Cells(row, 1), wsheet.Cells(row, baseCol + fiscalMonth)))
                    sectionGrand += rowTotal
                    row += 1
                Next

                'Totals
                If glOrder.Count > 0 Then
                    wsheet.Cells(row, 1).Value = "Total " & rptDisplay
                    Dim secRng = wsheet.Range(wsheet.Cells(row, 1), wsheet.Cells(row, baseCol + fiscalMonth))
                    ApplySectionTotalStyle(secRng)

                    For m As Integer = 1 To fiscalMonth
                        wsheet.Cells(row, baseCol + m - 1).Value = sectionTotals(m - 1)
                        totals(m - 1) += sectionTotals(m - 1)
                    Next

                    If Not isFSItem38 Then
                        wsheet.Cells(row, baseCol + fiscalMonth).Value = sectionGrand
                    End If

                    ApplyBorders(secRng, True)
                    grandTotal += sectionGrand
                    row += 2
                End If
            Next
        End Using

        With wsheet
            .UsedRange.Font.Name = "Calibri"
            .UsedRange.Columns.AutoFit()
            .Range("B6").Select()
            .Application.ActiveWindow.FreezePanes = True
        End With
    End Sub

#End Region

#Region "Annex A Function"

    Private Sub ApplyTitleStyle(rng As Excel.Range, Optional fntcolor As String = Nothing, Optional bckcolor As String = Nothing)
        With rng
            .Merge()
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Font.Bold = True

            If Not String.IsNullOrEmpty(fntcolor) Then
                Dim fParts() As String = fntcolor.Split(","c)
                .Font.Color = RGB(CInt(fParts(0)), CInt(fParts(1)), CInt(fParts(2)))
            End If

            If Not String.IsNullOrEmpty(bckcolor) Then
                Dim bParts() As String = bckcolor.Split(","c)
                .Interior.Color = RGB(CInt(bParts(0)), CInt(bParts(1)), CInt(bParts(2)))
            End If

        End With
    End Sub

    Private Sub ApplyCellFormat(cell As Excel.Range, reader As IDataReader)
        cell.Font.Size = CDbl(reader("TSIZE"))
        cell.Font.Size = CDbl(reader("VSIZE"))
        cell.Font.Bold = reader("TBLD").ToString()
        cell.Font.Bold = reader("VBLD").ToString()
        cell.NumberFormat = NumericFormat

        Dim rowHeightValue As String = reader("ROWH").ToString()
        If IsNumeric(rowHeightValue) Then
            cell.RowHeight = CDbl(rowHeightValue)
        End If
    End Sub

#End Region

#Region "Last Load Data"

    Sub LastDateLoad()

        LblLoadDate.Text = Nothing
        LblStatus.Text = Nothing
        LblLoadDate.ForeColor = Color.FromArgb(64, 64, 64)

        If CbxMonth.EditValue <> "" And TxtYear.EditValue <> "" Then

            Dim dataList As List(Of Dictionary(Of String, String)) = GetMultiValues($"Select LDDATE, PSTATS from FI_PSTNGPRD where POPER ={GetMonthNumber(CbxMonth.EditValue.ToString())} and RYEAR={TxtYear.EditValue}")

            For Each record In dataList

                If record("PSTATS") = True Then
                    LblStatus.Text = "  Closed Period"
                    LblStatus.ForeColor = Color.Green
                Else
                    LblStatus.Text = "  Open Period"
                    LblStatus.ForeColor = Color.Red
                End If

                LblLoadDate.Text = "Last Load Date: " & record("LDDATE")

            Next

            If GetValue($"Select count(*) from FI_TRXDATA where RYEAR={TxtYear.Text} and POPER={GetMonthNumber(CbxMonth.EditValue)}") = 0 Then
                LblLoadDate.Text = "No data found. Please reload the data first in Data Management."
                LblLoadDate.ForeColor = Color.Red
                LblStatus.Text = Nothing
            End If


        End If
    End Sub

    Private Sub CbxMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMonth.SelectedIndexChanged
        LastDateLoad()
    End Sub

    Private Sub TxtYear_EditValueChanged(sender As Object, e As EventArgs) Handles TxtYear.EditValueChanged
        LastDateLoad()
    End Sub




#End Region

End Class
