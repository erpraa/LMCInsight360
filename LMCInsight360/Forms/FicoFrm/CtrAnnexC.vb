Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
Imports LMCInsight360.SubQuery

Imports Excel = Microsoft.Office.Interop.Excel
Imports DevExpress.XtraSplashScreen
Imports System.Runtime.InteropServices
Public Class CtrAnnexC

    Dim BtnAnnexC As Integer

    Private Sub CtrAnnexC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnAnnexC = Gbl_ReportTag

        Select Case BtnAnnexC
            Case 1
                ChkBusUnit.Hide()
            Case 2
                ChkBusUnit.Show()
        End Select

        TxtStrYear.Text = GetDefaultYear()
        TxtEndYear.Text = GetDefaultYear()
    End Sub

#Region "Annex C Report"

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click

        If CbxStrMonth.EditValue = CbxEndMonth.EditValue AndAlso TxtStrYear.Text = TxtEndYear.Text Then
            MessageBox.Show("Year and month must not be the same.", "Invalid Year or Month", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If String.IsNullOrWhiteSpace(CbxEndMonth.Text) Then
            MessageBox.Show("Please input Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtEndYear.Text) Then
            MessageBox.Show("Please input Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim yearValue As Integer
        If Not Integer.TryParse(TxtEndYear.Text, yearValue) Then
            MessageBox.Show("Year must be a valid number.", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If yearValue < 2000 OrElse yearValue > 2100 Then
            MessageBox.Show("Please enter a valid year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If GetValue($"Select count(*) from FI_TRXDATA where RYEAR={TxtEndYear.Text} and POPER={GetMonthNumber(CbxEndMonth.EditValue)}") = 0 Then
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show("This report may take several minutes to generate. Do you want to continue?", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then

            Select Case BtnAnnexC
                Case 1
                    Generate_COSRatio()
                Case 2
                    Generate_MfgCost()
            End Select

        End If
    End Sub

#End Region

#Region "Cost Ratio"
    Private Sub Generate_COSRatio()

        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String = GetSapSource(CbxSapSource.EditValue)

        ' Create Excel only once
        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        ' Delete extra sheets, keep only Sheet1
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next


        Dim SfiscalYear, EfiscalYear, SfiscalMonth, EfiscalMonth As Integer

        SfiscalYear = TxtStrYear.EditValue
        SfiscalMonth = GetMonthNumber(CbxStrMonth.EditValue)
        EfiscalYear = TxtEndYear.EditValue
        EfiscalMonth = GetMonthNumber(CbxEndMonth.EditValue)

        If CbxBusinessType.EditValue = "FOODSTUFF" Then
            FS_Generate_COSRatio(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, True)
        ElseIf CbxBusinessType.EditValue = "OVERALL" Then
            FS_Generate_COSRatio(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "OVERALL", wbook, True)
        Else
            FS_Generate_COSRatio(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, True)
            FS_Generate_COSRatio(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "OVERALL", wbook, False)
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

    Private Sub FS_Generate_COSRatio(SfiscalYear As Integer, SfiscalMonth As Integer, EfiscalYear As Integer, EfiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)

        Dim wsheet As Excel.Worksheet = Nothing

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            ' Column & Row tracking
            Dim col, row, lastCol As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 6

            With wsheet

                Dim reportDate = New Date(CInt(EfiscalYear), EfiscalMonth, Date.DaysInMonth(CInt(EfiscalYear), EfiscalMonth))

                'Report Title
                Dim saptitle As String = Nothing
                If sapSource = "L4P" Then
                    saptitle = "(CAS)"
                ElseIf sapSource = "LRP" Then
                    saptitle = "(Reserved)"
                End If

                .Cells(1, 1).Value = "Liwayway Marketing Corporation"
                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = $"Comparative Cost of Sales Ratio - Foodstuff {saptitle}"
                    .Name = "COS Ratio - Food"
                Else
                    .Cells(2, 1).Value = $"Comparative Cost of Sales Ratio - Overall {saptitle}"
                    .Name = "COS Ratio - Overall"
                End If
                .Cells(3, 1).Value = "For the Period Ending " & reportDate.ToString("MMMM dd, yyyy")


                .Cells(1, 1).Font.Size = 11
                .Cells(2, 1).Font.Size = 11
                .Cells(3, 1).Font.Size = 11

                Dim branchQuery As String
                If businessType = "FOODSTUFF" Then
                    branchQuery = "select distinct HDESC1,RPTSRT1,BSTYPE from FI_BRANCH where PRCTR<>'1000-HO' AND BSTYPE='Foodstuff Only' order by BSTYPE,RPTSRT1"
                Else
                    branchQuery = "select distinct HDESC1,RPTSRT1,BSTYPE from FI_BRANCH order by BSTYPE,RPTSRT1"
                End If

                Dim branches As List(Of Dictionary(Of String, String)) = GetMultiValues(branchQuery)

                'Branch Headers
                col = baseCol
                row = baseRow

                For Each br In branches
                    .Cells(5, col) = br("HDESC1")
                    SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                    SetBackFontColor(wsheet, 5, col, "", "169,169,169")

                    col += 1
                Next

                lastCol = col

                ' Insert GrandTotal
                .Cells(5, col).Value = "Total"
                SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                SetBackFontColor(wsheet, 5, col, "", "169,169,169")

                col = baseCol

                Dim months As List(Of Dictionary(Of String, String)) = GetMultiValues($"WITH MonthRange AS (
                                                                                        SELECT DATEFROMPARTS({SfiscalYear}, {SfiscalMonth}, 1) AS MonthDate
                                                                                        UNION ALL
                                                                                        SELECT DATEADD(MONTH, 1, MonthDate)
                                                                                        FROM MonthRange
                                                                                        WHERE MonthDate < DATEFROMPARTS({EfiscalYear}, {EfiscalMonth}, 1))                                  
                                                                                        SELECT DATENAME(MONTH, MonthDate) + ' ' + CAST(YEAR(MonthDate) AS VARCHAR(4)) AS MonthNameYear
                                                                                        FROM MonthRange ORDER BY MonthDate OPTION (MAXRECURSION 100);")

                For Each br In branches

                    ' Monthly sections
                    For Each m In months
                        Dim monthYear As String = m("MonthNameYear").ToString()
                        Dim parts() As String = monthYear.Split(" "c)

                        row += 1

                        .Cells(row, 1) = "Sales"
                        .Cells(row, col) = Val(GetAmount(RptQueryCOSR(parts(1), GetMonthNumber(parts(0)), sapSource, "60", br("HDESC1")))) * -1 'to make Positive
                        .Cells(row, lastCol).Value = $"=SUM({GetExcelColName(baseCol)}{row}:{GetExcelColName(lastCol - 1)}{row})"
                        .Cells(row, col).NumberFormat = NumericFormat

                        row += 1

                        .Cells(row, 1) = "Cost of Sales"
                        .Cells(row, col) = Val(GetAmount(RptQueryCOSR(parts(1), GetMonthNumber(parts(0)), sapSource, "61", br("HDESC1"))))
                        .Cells(row, lastCol).Value = $"=SUM({GetExcelColName(baseCol)}{row}:{GetExcelColName(lastCol - 1)}{row})"
                        .Cells(row, col).NumberFormat = NumericFormat

                        SetBorderStyle(wsheet, row, 1, "S", "B")
                        SetBorderStyle(wsheet, row, col, "S", "B")
                        SetBorderStyle(wsheet, row, lastCol, "S", "B")

                        row += 2

                        SetBackFontColor(wsheet, row, 1, "", "211,211,211")

                        .Cells(row, 1) = $"{m("MonthNameYear")} - CGS / Sales Ratio"
                        .Cells(row, col).Value = $"=IFERROR({GetExcelColName(col)}{row - 2}/{GetExcelColName(col)}{row - 3},0)"
                        .Cells(row, col).NumberFormat = PercentageFormat
                        SetBackFontColor(wsheet, row, col, "", "211,211,211")

                        'Total
                        .Cells(row, lastCol).Value = $"=IFERROR({GetExcelColName(lastCol)}{row - 2}/{GetExcelColName(lastCol)}{row - 3},0)"
                        .Cells(row, lastCol).NumberFormat = PercentageFormat
                        SetBackFontColor(wsheet, row, lastCol, "", "211,211,211")

                        SetBorderStyle(wsheet, row, 1, "S", "B")
                        SetBorderStyle(wsheet, row, col, "S", "B")
                        SetBorderStyle(wsheet, row, lastCol, "S", "B")

                        row += 1
                    Next

                    For Each c As Integer In {col, lastCol}
                        With .Range(.Cells(baseRow, c), .Cells(row - 1, c)) _
                             .Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                    Next

                    row += 1

                    .Cells(row, 1) = "Increase (Decrease) in Sales"
                    .Cells(row, col).Value = $"={GetExcelColName(col)}{row - 5}-{GetExcelColName(col)}{row - 10}"
                    .Cells(row, lastCol).Value = $"={GetExcelColName(lastCol)}{row - 5}-{GetExcelColName(lastCol)}{row - 10}"

                    SetBorderStyle(wsheet, row, 1, "D", "B")
                    SetBorderStyle(wsheet, row, col, "D", "B")
                    SetBorderStyle(wsheet, row, lastCol, "D", "B")

                    row += 2

                    .Cells(row, 1) = "Difference In COGS/Sales Ratio On Prior Mo."
                    .Cells(row, col).Value = $"={GetExcelColName(col)}{row - 4}-{GetExcelColName(col)}{row - 9}"
                    .Cells(row, col).NumberFormat = PercentageFormat

                    .Cells(row, lastCol).Value = $"={GetExcelColName(lastCol)}{row - 4}-{GetExcelColName(lastCol)}{row - 9}"
                    .Cells(row, lastCol).NumberFormat = PercentageFormat

                    row += 1

                    .Cells(row, 1) = "Increase (Decrease) in Manufacturing Cost"
                    .Cells(row, col).Value = $"={GetExcelColName(col)}{row - 3}*{GetExcelColName(col)}{row - 1}"
                    .Cells(row, col).NumberFormat = NumericFormat

                    .Cells(row, lastCol).Value = $"={GetExcelColName(lastCol)}{row - 3}*{GetExcelColName(lastCol)}{row - 1}"
                    .Cells(row, lastCol).NumberFormat = NumericFormat

                    row += 1

                    .Cells(row + 1, 1) = "Increase(Decrease):"
                    .Cells(row + 1, 1).font.bold = True
                    .Cells(row + 2, 1) = "Materials Consumption"
                    .Cells(row + 3, 1) = "Labor"
                    .Cells(row + 4, 1) = "Manufacturing Overhead"
                    .Cells(row + 5, 1) = "Total"
                    .Cells(row + 6, 1) = "Difference"

                    .Cells(row + 5, col).Value = $"=SUM({GetExcelColName(col)}{row + 2}:{GetExcelColName(col)}{row + 4})"
                    .Cells(row + 5, lastCol).Value = $"=SUM({GetExcelColName(lastCol)}{row + 2}:{GetExcelColName(lastCol)}{row + 4})"

                    .Cells(row + 6, col).Value = $"={GetExcelColName(col)}{row - 1}-{GetExcelColName(col)}{row + 5}"
                    .Cells(row + 6, lastCol).Value = $"={GetExcelColName(lastCol)}{row - 1}-{GetExcelColName(lastCol)}{row + 5}"


                    SetBorderStyle(wsheet, row + 5, 1, "D", "B")
                    SetBorderStyle(wsheet, row + 5, col, "D", "B")
                    SetBorderStyle(wsheet, row + 5, lastCol, "D", "B")

                    col += 1
                    row = baseRow

                Next

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

#Region "MFG Cost"
    Sub Generate_MfgCost()
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim sapSource As String = GetSapSource(CbxSapSource.EditValue)

        ' Create Excel only once
        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        ' Delete extra sheets, keep only Sheet1
        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next

        Dim SfiscalYear, EfiscalYear, SfiscalMonth, EfiscalMonth As Integer

        SfiscalYear = If(GetMonthNumber(CbxStrMonth.EditValue) = 1, TxtStrYear.EditValue - 1, TxtStrYear.EditValue)
        SfiscalMonth = If(GetMonthNumber(CbxStrMonth.EditValue) = 1, 12, GetMonthNumber(CbxStrMonth.EditValue) - 1)
        EfiscalYear = TxtEndYear.EditValue
        EfiscalMonth = GetMonthNumber(CbxEndMonth.EditValue)

        If CbxBusinessType.EditValue = "FOODSTUFF" Then
            FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, True)

            If ChkBusUnit.Checked = True Then
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Cavite")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "CDO")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Cebu")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Tarlac")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Iloilo")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Pangasinan")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Laguna")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Ready to Drink")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Marshmallows")
            End If

        ElseIf CbxBusinessType.EditValue = "OVERALL" Then
            FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "OVERALL", wbook, True)
        Else
            FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, True)
            FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "OVERALL", wbook, False)

            If ChkBusUnit.Checked = True Then
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Cavite")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "CDO")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Cebu")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Tarlac")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Iloilo")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Pangasinan")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Laguna")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Ready to Drink")
                FS_Generate_MfgCost(SfiscalYear, SfiscalMonth, EfiscalYear, EfiscalMonth, sapSource, "FOODSTUFF", wbook, False, "Marshmallows")
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


    Private Sub FS_Generate_MfgCost(SfiscalYear As Integer, SfiscalMonth As Integer, EfiscalYear As Integer, EfiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean, Optional busUnit As String = Nothing)
        Dim wsheet As Excel.Worksheet = Nothing


        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 6
            Dim colT As Integer = 2
            With wsheet

                Dim reportDate = New Date(CInt(EfiscalYear), EfiscalMonth, Date.DaysInMonth(CInt(EfiscalYear), EfiscalMonth))

                'Report Title
                Dim saptitle As String = Nothing
                If sapSource = "L4P" Then
                    saptitle = "(CAS)"
                ElseIf sapSource = "LRP" Then
                    saptitle = "(Reserved)"
                End If

                .Cells(1, 1).Value = "Liwayway Marketing Corporation"

                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = $"Cost of Sales Analysis - {busUnit} Foodstuff {saptitle}"

                    If busUnit = Nothing Then
                        .Name = "Mfg Cost - Food"
                    Else
                        .Name = $"Mfg Cost - {busUnit}"
                    End If
                Else
                    .Cells(2, 1).Value = $"Cost of Sales Analysis - Overall {saptitle}"
                    .Name = "Mfg Cost - Overall"
                End If
                .Cells(3, 1).Value = "For the Period Ending " & reportDate.ToString("MMMM dd, yyyy")

                .Cells(1, 1).Font.Size = 11
                .Cells(2, 1).Font.Size = 11
                .Cells(3, 1).Font.Size = 11

                Dim HeaderMonths As List(Of Dictionary(Of String, String)) = GetMultiValues($"WITH MonthRange AS (
                                                                                        SELECT DATEFROMPARTS({SfiscalYear}, {SfiscalMonth}, 1) AS MonthDate
                                                                                        UNION ALL
                                                                                        SELECT DATEADD(MONTH, 1, MonthDate)
                                                                                        FROM MonthRange
                                                                                        WHERE MonthDate < DATEFROMPARTS({EfiscalYear}, {EfiscalMonth}, 1))                                  
                                                                                        SELECT DATENAME(MONTH, MonthDate) + ' ' + CAST(YEAR(MonthDate) AS VARCHAR(4)) AS MonthNameYear
                                                                                        FROM MonthRange ORDER BY MonthDate OPTION (MAXRECURSION 100);")


                Dim RowDescription As List(Of Dictionary(Of String, String)) = GetMultiValues("select * from FI_RPTFORMAT where RPTTYPE='CMFG' order by RPTSRT")

                col = baseCol
                row = baseRow

                'Monthly sections Header
                For Each HdrMnth In HeaderMonths
                    .Cells(row - 2, col).Value = "'" & HdrMnth("MonthNameYear").ToString()
                    SetSquareBorder(wsheet, row - 2, col, Excel.XlBorderWeight.xlThin)
                    SetBackFontColor(wsheet, row - 2, col, "", "169,169,169")
                    col += 1
                Next

                .Cells(row - 2, col).Value = $"Difference ({MonthName(If(EfiscalMonth = 1, 12, EfiscalMonth - 1), True)} & {MonthName(EfiscalMonth, True)})"
                SetSquareBorder(wsheet, row - 2, col, Excel.XlBorderWeight.xlThin)
                SetBackFontColor(wsheet, row - 2, col, "", "169,169,169")

                col += 1

                .Cells(row - 2, col).Value = "% Difference"
                SetSquareBorder(wsheet, row - 2, col, Excel.XlBorderWeight.xlThin)
                SetBackFontColor(wsheet, row - 2, col, "", "169,169,169")

                col = baseCol

                For Each rowDesc In RowDescription
                    Dim pFS_ITEM As String = rowDesc("ERGSL").ToString()

                    .Cells(row, 1).Value = rowDesc("RPTDISPLY").ToString()

                    For Each HdrMnth In HeaderMonths

                        If pFS_ITEM <> "" Then
                            Dim fiscalMonth As String = Nothing

                            Dim monthYear As String = HdrMnth("MonthNameYear").ToString()
                            Dim parts() As String = monthYear.Split(" "c)

                            If parts(0) = "January" AndAlso CInt(parts(1)) = EfiscalYear Then
                                colT = col
                            End If

                            If pFS_ITEM = "C13" Then
                                fiscalMonth = String.Join(",", Enumerable.Range(1, CInt(GetMonthNumber(parts(0)))))
                            Else
                                fiscalMonth = GetMonthNumber(parts(0))
                            End If

                            .Cells(row, col).Value = AdjustValue(Val(GetAmount(RptQueryMFG(parts(1), fiscalMonth, sapSource, pFS_ITEM, businessType, busUnit))), rowDesc("DCFLG").ToString())
                                .Cells(row, col).NumberFormat = NumericFormat
                                ApplyCellFormat(.Cells(row, col), rowDesc)
                            End If

                            ' Apply formulas
                            If rowDesc("FRMLA").ToString() <> "" Then
                            .Cells(row, col).Formula = GetExcelFormula(rowDesc("FRMLA").ToString(), col)
                        End If

                        Select Case row
                            Case 25
                                .Cells(row, col).Formula = $"={ .Cells(6, col).Address}*{ .Cells(18, col - 1).Address}"
                            Case 26
                                .Cells(row, col).Formula = $"={ .Cells(6, col).Address}*{ .Cells(19, col - 1).Address}"
                            Case 27
                                .Cells(row, col).Formula = $"={ .Cells(6, col).Address}*{ .Cells(20, col - 1).Address}"
                        End Select

                        Select Case row
                            Case 18, 19, 20, 21
                                .Cells(row, col).NumberFormat = PercentageFormat
                            Case Else
                                .Cells(row, col).NumberFormat = NumericFormat
                        End Select

                        SetBorderStyle(wsheet, row, col, rowDesc("ULINE").ToString(), rowDesc("PLINE").ToString())
                        ApplyCellFormat(.Cells(row, col), rowDesc)

                        col += 1

                    Next

                    .Cells(21, col).Formula = $"=AVERAGE({ .Cells(21, colT).Address}:{ .Cells(21, col - 1).Address})"
                    SetBorderStyle(wsheet, row, col, rowDesc("ULINE").ToString(), rowDesc("PLINE").ToString())
                    ApplyCellFormat(.Cells(row, col), rowDesc)

                    .Cells(24, col).Value = "Inc(Dec)in Value"

                    Select Case row
                        Case 6, 8, 10, 12, 14
                            .Cells(row, col).Formula = $"={ .Cells(row, col - 1).Address}-{ .Cells(row, col - 2).Address}"
                            col += 1
                            .Cells(row, col).Formula = $"={ .Cells(row, col - 1).Address}/{ .Cells(row, col - 3).Address}"
                            .Cells(row, col).NumberFormat = PercentageFormat
                        Case 16
                            .Cells(row, col).Formula = $"={ .Cells(row, col - 1).Address}-{ .Cells(row, col - 2).Address}"
                        Case 25
                            .Cells(row, col).Formula = $"={ .Cells(8, col - 1).Address}-{ .Cells(row, col - 1).Address}"
                        Case 26
                            .Cells(row, col).Formula = $"={ .Cells(10, col - 1).Address}-{ .Cells(row, col - 1).Address}"
                        Case 27
                            .Cells(row, col).Formula = $"={ .Cells(12, col - 1).Address}-{ .Cells(row, col - 1).Address}"
                        Case 28
                            .Cells(row, col).Formula = $"={ .Cells(row - 3, col).Address}+{ .Cells(row - 2, col).Address}+{ .Cells(row - 1, col).Address}"
                    End Select

                    SetBorderStyle(wsheet, row, col, rowDesc("ULINE").ToString(), rowDesc("PLINE").ToString())
                    ApplyCellFormat(.Cells(row, col), rowDesc)

                    row += 1
                    col = baseCol
                Next

                'Final Format
                .Range("B5").Select()
                .Application.ActiveWindow.FreezePanes = True
                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

                .Columns("B:B").Hidden = True
            End With


        Catch ex As Exception
            MessageBox.Show("An error occurred while generating Manufacturing Cost Report: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


#End Region

    Private Sub ApplyCellFormat(cell As Excel.Range, reader As Dictionary(Of String, String))
        cell.Font.Size = CDbl(reader("TSIZE"))
        cell.Font.Size = CDbl(reader("VSIZE"))
        cell.Font.Bold = reader("TBLD").ToString()
        cell.Font.Bold = reader("VBLD").ToString()

        Dim rowHeightValue As String = reader("ROWH").ToString()
        If IsNumeric(rowHeightValue) Then
            cell.RowHeight = CDbl(rowHeightValue)
        End If
    End Sub

End Class
