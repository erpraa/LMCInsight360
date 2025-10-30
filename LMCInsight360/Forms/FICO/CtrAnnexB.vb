Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
Imports LMCInsight360.SubQuery

Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports System.Runtime.InteropServices

Public Class CtrAnnexB

    Dim BtnAnnexB As Integer

    Private Sub CtrlAnnexB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlReportType.Enabled = False

        BtnAnnexB = Gbl_ReportTag

        Select Case BtnAnnexB
            Case 1
                CbxStatementType.Enabled = True
            Case 2
                CbxStatementType.Enabled = False
        End Select

        TxtYear.Text = Date.Now.Year.ToString()

    End Sub

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

        Dim result As DialogResult
        result = MessageBox.Show("This report may take several minutes to generate. Do you want to continue?", "Run Report", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then

            Select Case BtnAnnexB
                Case 1
                    Generate_ISComp()
                Case 2
                    SEGAAE()
            End Select

        End If

    End Sub

    Private Sub CbxStatementType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxStatementType.SelectedIndexChanged
        FilterLogic()
    End Sub

    Sub FilterLogic()
        If CbxStatementType.EditValue = "MONTH TO MONTH" Then
            TxtCompYear.Text = TxtYear.Text

            CbxCompMonth.Enabled = True
            TxtCompYear.Enabled = False
            PnlReportType.Enabled = False

        ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then
            CbxCompMonth.EditValue = CbxMonth.EditValue

            CbxCompMonth.Enabled = False
            TxtCompYear.Enabled = True
            PnlReportType.Enabled = True

        Else

            CbxCompMonth.Text = ""
            TxtCompYear.Text = ""

            CbxCompMonth.Enabled = False
            TxtCompYear.Enabled = False
            PnlReportType.Enabled = False
        End If
    End Sub

    Private Sub CbxMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMonth.SelectedIndexChanged
        FilterLogic()
    End Sub

    Private Sub TxtYear_EditValueChanged(sender As Object, e As EventArgs) Handles TxtYear.EditValueChanged
        FilterLogic()
    End Sub

    Private Sub CbxCompMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCompMonth.SelectedIndexChanged
        FilterLogic()
    End Sub

    Private Sub TxtCompYear_EditValueChanged(sender As Object, e As EventArgs) Handles TxtCompYear.EditValueChanged
        FilterLogic()
    End Sub

#Region "IScomparative"

    Private Sub Generate_ISComp()

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

        Dim fmonth,fyear,cmpfmonth, cmpfyear As String
        fmonth = GetMonthNumber(CbxMonth.EditValue)
        fyear = TxtYear.Text
        cmpfmonth = GetMonthNumber(CbxCompMonth.EditValue)
        cmpfyear = TxtCompYear.Text

        If CbxBusinessType.EditValue = "" Then

            If CbxStatementType.EditValue = "MONTH TO MONTH" Then

                If String.IsNullOrWhiteSpace(CbxCompMonth.Text) Then
                    MessageBox.Show("Please input Comparison Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "MTM", Nothing, wbook, True)
                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "MTM", Nothing, wbook, False)

            ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then

                If String.IsNullOrWhiteSpace(TxtCompYear.Text) Then
                    MessageBox.Show("Please input Comparison Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If RbtnMonthly.Checked Then
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "YTY", "Monthly", wbook, True)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "YTY", "Monthly", wbook, False)
                ElseIf RbtnAccum.Checked Then
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "YTY", "Accum", wbook, True)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "YTY", "Accum", wbook, False)
                Else
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "YTY", "Monthly", wbook, True)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "YTY", "Accum", wbook, False)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "YTY", "Monthly", wbook, False)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "YTY", "Accum", wbook, False)
                End If
            Else
                FS_IncomeStatementComp(fmonth, fyear, If(fmonth = 1, 12, fmonth - 1), If(fmonth = 1, fyear - 1, fyear), sapSource, "FOODSTUFF", "MTM", Nothing, wbook, True)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, "FOODSTUFF", "YTY", "Monthly", wbook, False)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, "FOODSTUFF", "YTY", "Accum", wbook, False)

                FS_IncomeStatementComp(fmonth, fyear, If(fmonth = 1, 12, fmonth - 1), If(fmonth = 1, fyear - 1, fyear), sapSource, "OVERALL", "MTM", Nothing, wbook, False)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, "OVERALL", "YTY", "Monthly", wbook, False)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, "OVERALL", "YTY", "Accum", wbook, False)
            End If
        Else
            Dim BusinessType As String = CbxBusinessType.EditValue

            If CbxStatementType.EditValue = "MONTH TO MONTH" Then

                If String.IsNullOrWhiteSpace(CbxCompMonth.Text) Then
                    MessageBox.Show("Please input Comparison Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SplashScreenManager.CloseDefaultWaitForm()
                    Exit Sub
                End If

                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "MTM", Nothing, wbook, True)
            ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then

                If String.IsNullOrWhiteSpace(TxtCompYear.Text) Then
                    MessageBox.Show("Please input Comparison Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SplashScreenManager.CloseDefaultWaitForm()
                    Exit Sub
                End If

                If RbtnMonthly.Checked Then
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "YTY", "Monthly", wbook, True)
                ElseIf RbtnAccum.Checked Then
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "YTY", "Accum", wbook, True)
                Else
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "YTY", "Monthly", wbook, True)
                    FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "YTY", "Accum", wbook, False)
                End If
            Else
                FS_IncomeStatementComp(fmonth, fyear, If(fmonth = 1, 12, fmonth - 1), If(fmonth = 1, fyear - 1, fyear), sapSource, BusinessType, "MTM", Nothing, wbook, True)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, BusinessType, "YTY", "Monthly", wbook, False)
                FS_IncomeStatementComp(fmonth, fyear, fmonth, fyear - 1, sapSource, BusinessType, "YTY", "Accum", wbook, False)
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

    End Sub

    Private Sub FS_IncomeStatementComp(fiscalMonth As Integer,fiscalYear As Integer,CmpFMonth As Integer,CmpFYear As Integer, sapSource As String, businessType As String, StatementType As String, ReportType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim wsheet As Excel.Worksheet = Nothing

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            Dim saptitle As String = Nothing

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 5

            With wsheet

                'Report Title
                saptitle = If(sapSource = "L4P", " (CAS)", If(sapSource = "LRP", " (Reserved)", ""))

                .Cells(1, 1).Value = "Liwayway Marketing Corporation"

                Dim typeLabel As String = If(businessType = "FOODSTUFF", "Foodstuff", "Overall")
                Dim namePrefix As String = If(businessType = "FOODSTUFF", "Food", "Overall")

                If StatementType = "MTM" Then
                    .Cells(2, 1).Value = $"Comparative IS - One Month Only (Month-to-Month) - {typeLabel} {saptitle}"
                    .Name = $"MTM-Comp IS {namePrefix}"
                ElseIf ReportType = "Monthly" Then
                    .Cells(2, 1).Value = $"Comparative IS - One Month Only (Year-to-Year) - {typeLabel} {saptitle}"
                    .Name = $"YTY-Comp IS {namePrefix}"
                Else
                    .Cells(2, 1).Value = $"Comparative IS - Accumulated by Month (Year-to-Year) - {typeLabel} {saptitle}"
                    .Name = $"YTY-Comp IS {namePrefix} Accum"
                End If

                .Cells(3, 1).Value = "As Stated under Cash Approach"

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, 8)), Nothing, "180,198,231")
                Next

                col = baseCol
                row = baseRow

                Dim header As New List(Of String) From {MonthName(CmpFMonth) & " " & CmpFYear, "%", MonthName(fiscalMonth) & " " & fiscalYear, "%", "Difference", "Percentage", "Remark"}

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()
                    Dim rptQuery As String = "SELECT * FROM FI_RPTFORMAT WHERE RPTTYPE = 'BIS' ORDER BY RPTSRT"
                    Using cmd As New SqlCommand(rptQuery, conn)
                        Using reader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()

                                    .Cells(row, 1) = reader("RPTDISPLY").ToString()
                                    ApplyCellFormat(.Cells(row, 1), reader)
                                    SetBottomBorder(wsheet, row, 1, reader("ULINE").ToString().Trim())
                                    SetBackFontColor(wsheet, row, 1, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())
                                    SetSquareBorder(wsheet, 5, 1, Excel.XlBorderWeight.xlThin)

                                    Dim fMonth, fYear As String
                                    Dim fsItem = reader("ERGSL").ToString()
                                    Dim remark = reader("REMARK").ToString()

                                    Dim i As Integer = 0

                                    ' Loop through each header item
                                    For Each hdr In header
                                        i += 1

                                        .Cells(5, col) = "'" & If(ReportType = "Accum" AndAlso (i = 1 OrElse i = 3), "As of ", "") & hdr

                                        .Cells(5, col).Font.Bold = True
                                        .Cells(5, col).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                        SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                                        SetBackFontColor(wsheet, 5, col, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())

                                        Dim parts() As String = hdr.Split(" "c)
                                        If parts.Length = 2 Then
                                            If ReportType = "Accum" Then
                                                fMonth = String.Join(",", Enumerable.Range(1, CInt(GetMonthNumber(parts(0)))))
                                            Else
                                                fMonth = GetMonthNumber(parts(0))
                                            End If
                                            fYear = parts(1)

                                            If fsItem <> "" Then
                                                .Cells(row, col) = AdjustValue(Val(GetAmount(RptQueryBIS(fYear, fMonth, sapSource, fsItem, businessType))), reader("DCFLG").ToString())
                                                GroupFormat(wsheet, row, col, NumericFormat, reader)
                                            End If
                                            ' Apply formulas based on SQL
                                            If reader("FRMLA") <> "" Then
                                                .Cells(row, col).Formula = GetExcelFormula(reader("FRMLA").ToString(), col)
                                                GroupFormat(wsheet, row, col, NumericFormat, reader)
                                            End If
                                        End If

                                        'Apply formulas 
                                        If reader("RPTDISPLY") <> "" Then
                                            If i = 2 And row <> 7 Then
                                                .Cells(row, col) = $"=B{row}/B7"
                                                GroupFormat(wsheet, row, col, PercentageFormat, reader)
                                            ElseIf i = 4 And row <> 7 Then
                                                .Cells(row, col) = $"=D{row}/D7"
                                                GroupFormat(wsheet, row, col, PercentageFormat, reader)
                                            ElseIf i = 5 Then
                                                .Cells(row, col) = $"=D{row}-B{row}"
                                                GroupFormat(wsheet, row, col, NumericFormat, reader)
                                            ElseIf i = 6 Then
                                                .Cells(row, col) = $"=F{row}/B{row}"
                                                GroupFormat(wsheet, row, col, PercentageFormat, reader)
                                            ElseIf i = 7 And remark <> "" Then
                                                .Cells(row, col) = remark
                                            End If

                                            SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
                                        End If

                                        .Cells(row, col).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Cells(row, col).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlThin

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
                .Range("B6").Select()
                .Application.ActiveWindow.FreezePanes = True
                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

            End With

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating the Income Statement: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

    Private Sub ApplyCellFormat(cell As Excel.Range, reader As IDataReader)
        cell.Font.Size = CDbl(reader("TSIZE"))
        cell.Font.Size = CDbl(reader("VSIZE"))
        cell.Font.Bold = reader("TBLD").ToString()
        cell.Font.Bold = reader("VBLD").ToString()

        Dim rowHeightValue As String = reader("ROWH").ToString()
        If IsNumeric(rowHeightValue) Then
            cell.RowHeight = CDbl(rowHeightValue)
        End If
    End Sub


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

    Private Sub GroupFormat(wsheet As Excel.Worksheet, row As Integer, col As Integer, format As String, reader As IDataReader)
        With wsheet
            .Cells(row, col).NumberFormat = format
            ApplyCellFormat(.Cells(row, col), reader)
            SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())
            SetBackFontColor(wsheet, row, col, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())
        End With
    End Sub

#End Region


#Region "SEGAAE"

    ' Excel Formatting
    Private Const NUM_FMT As String = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"
    Private ReadOnly HEADER_COLOR As Integer = RGB(198, 224, 180)
    Private ReadOnly TOTAL_COLOR As Integer = RGB(91, 155, 213)

    'Private Sub ApplyTitleStyle(rng As Excel.Range)
    '    With rng
    '        .Merge()
    '        .Interior.Color = HEADER_COLOR
    '        .Font.Color = System.Drawing.Color.Black
    '        .Font.Bold = True
    '        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    '        .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '        .WrapText = True
    '    End With
    'End Sub

    Private Sub SEGAAE()
        Generate_SEGAAE()
    End Sub

    Private Sub Generate_SEGAAE()
        SplashScreenManager.ShowForm(GetType(WaitFrm))

        Dim sapSource As String
        Select Case CbxSapSource.EditValue
            Case "CAS" : sapSource = "L4P"
            Case "Reserved" : sapSource = "LRP"
            Case Else : sapSource = Nothing
        End Select

        Dim excelApp As New Excel.Application()
        Dim wbook As Excel.Workbook = excelApp.Workbooks.Add()

        For i As Integer = wbook.Sheets.Count To 2 Step -1
            wbook.Sheets(i).Delete()
        Next

        Dim yearVal As Integer = TxtYear.EditValue
        Dim monthVal As Integer = GetMonthNumber(CbxMonth.EditValue)

        Select Case CbxBusinessType.EditValue
            Case "FOODSTUFF"
                FS_SEGAAE(yearVal, monthVal, sapSource, "FOODSTUFF", wbook, True)
            Case "OVERALL"
                FS_SEGAAE(yearVal, monthVal, sapSource, "OVERALL", wbook, True)
            Case Else
                FS_SEGAAE(yearVal, monthVal, sapSource, "", wbook, True)
        End Select

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)
        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()

        SplashScreenManager.CloseForm()
    End Sub

    Private Sub FS_SEGAAE(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        Dim Row As Integer = 6

        Try
            Dim wsheet As Excel.Worksheet = Nothing
            Dim saptitle As String = Nothing
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 5
            '     Dim reportDate As Date = New Date(fiscalYear, fiscalMonth, Date.DaysInMonth(fiscalYear, fiscalMonth))
            Dim MonthName As New Date(fiscalYear, fiscalMonth, 1)
            Dim prevMonth As Date = MonthName.AddMonths(-1)

            If sapSource = "L4P" Then
                saptitle = " (CAS)"
            ElseIf sapSource = "LRP" Then
                saptitle = " (Reserved)"
            End If

            Dim sheetsInfo() As (Name As String, BusType As String, FSItem As Integer, Title As String) = {
                ("SELLING EXP Food", "FOODSTUFF", 52, "Selling Expenses - Foodstuff Only"),
                ("SELLING EXP Overall", "OVERALL", 52, "Selling Expenses - Overall"),
                ("GAAE Food", "FOODSTUFF", 54, "Administrative Expenses - Foodstuff Only"),
                ("GAAE Overall", "OVERALL", 54, "Administrative Expenses - Overall")
            }

            For Each info In sheetsInfo
                If businessType <> "" AndAlso businessType <> businessType Then Continue For

                If useFirstSheet AndAlso info.Name = "SELLING EXP Food" Then
                    wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
                Else
                    wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
                End If

                With wsheet
                    .Name = info.Name
                    .Cells.Clear()
                    .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                    .Cells(2, 1).Value = $"Comparative Summary of {info.Title}{saptitle}"
                    .Cells(3, 1).Value = "Fot the Months of " & prevMonth.ToString("MMM yyyy") & " & " & MonthName.ToString("MMM yyyy")

                    For i As Integer = 1 To 3
                        ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, 6)), Nothing, "198, 224, 180")
                    Next

                    Dim HeaderName As Integer = 5
                    .Cells(HeaderName, 1).Value = "Account Description"
                    .Cells(HeaderName, 2).Value = "'" & prevMonth.ToString("MMM yyyy")
                    .Cells(HeaderName, 3).Value = "'" & MonthName.ToString("MMM yyyy")
                    .Cells(HeaderName, 4).Value = "Difference"
                    .Cells(HeaderName, 5).Value = "Trend"
                    .Cells(HeaderName, 6).Value = "Remarks"

                    With .Range(.Cells(HeaderName, 1), .Cells(HeaderName, 6))
                        .Font.Bold = True
                        .Interior.Color = RGB(220, 230, 241)
                        .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End With
                End With

                Dim dataRow As Integer = 6
                Dim formatList As New List(Of Tuple(Of String, String))

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()

                    Using fmtCmd As New SqlCommand("SELECT ERGSL, RPTDISPLY FROM FI_RPTFORMAT WHERE RPTTYPE = 'BDS' ORDER BY RPTSRT;", conn)
                        Using fmtReader = fmtCmd.ExecuteReader()
                            While fmtReader.Read()
                                formatList.Add(New Tuple(Of String, String)(
                                    If(fmtReader.IsDBNull(0), "", fmtReader.GetString(0)),
                                    If(fmtReader.IsDBNull(1), "", fmtReader.GetString(1))
                                ))
                            End While
                        End Using
                    End Using

                    For Each fmt In formatList
                        Dim fsItem As String = fmt.Item1
                        Dim rptDisplay As String = fmt.Item2

                        If fsItem <> info.FSItem.ToString() Then Continue For

                        Dim pbusUnit As String
                        If businessType = "FOODSTUFF" Then
                            pbusUnit = $"and BusType='Foodstuff Only'"
                        Else
                            pbusUnit = Nothing
                        End If

                        Dim trxorigin As String = ""
                        If sapSource <> "" Then
                            trxorigin = $"AND TrxOrigin='{sapSource}'"
                        End If

                        Dim allData As New Dictionary(Of String, Decimal())()
                        Dim glOrder As New List(Of String)

                        Using cmdAll As New SqlCommand($"
                        SELECT CONCAT(GLAccount,' ',GLLngDesc) AS GLDesc, PostingPeriod, SUM(Amount) AS AMT
                        FROM vwFI_GLREPORT
                        WHERE FiscalYear=@FY AND PostingPeriod BETWEEN 1 AND @Max AND FSItem=@FSItem
                        {pbusUnit} {trxorigin}
                        GROUP BY GLAccount, GLLngDesc, PostingPeriod
                        ORDER BY GLAccount, PostingPeriod;", conn)

                            cmdAll.Parameters.AddWithValue("@FY", fiscalYear)
                            cmdAll.Parameters.AddWithValue("@Max", fiscalMonth)
                            cmdAll.Parameters.AddWithValue("@FSItem", fsItem)

                            Using rdr = cmdAll.ExecuteReader()
                                While rdr.Read()
                                    Dim gl As String = rdr.GetString(0)
                                    Dim period As Integer = Convert.ToInt32(If(IsDBNull(rdr(1)), 0, rdr(1)))
                                    Dim amt As Decimal = Convert.ToDecimal(If(IsDBNull(rdr(2)), 0, rdr(2)))

                                    If Not allData.ContainsKey(gl) Then
                                        allData(gl) = New Decimal(12) {}
                                        glOrder.Add(gl)
                                    End If
                                    allData(gl)(period) = amt
                                End While
                            End Using
                        End Using

                        For Each gl In glOrder
                            Dim prevVal As Decimal = allData(gl)(fiscalMonth - 1)
                            Dim currVal As Decimal = allData(gl)(fiscalMonth)
                            Dim diffVal As Decimal = currVal - prevVal
                            Dim trend As String = ""
                            Dim remarks As String = ""

                            If prevVal = 0 AndAlso currVal = 0 Then Continue For

                            If diffVal > 0 Then
                                trend = "Increase"
                            ElseIf diffVal < 0 Then
                                trend = "Decrease"
                            Else
                                diffVal = 0
                                trend = "Same"
                            End If

                            wsheet.Cells(dataRow, 1).Value = gl
                            wsheet.Cells(dataRow, 2).Value = prevVal
                            wsheet.Cells(dataRow, 3).Value = currVal
                            wsheet.Cells(dataRow, 4).Value = diffVal
                            wsheet.Cells(dataRow, 5).Value = trend
                            wsheet.Cells(dataRow, 6).Value = remarks

                            If diffVal < 0 AndAlso trend = "Decrease" Then
                                With wsheet.Range(wsheet.Cells(dataRow, 4), wsheet.Cells(dataRow, 5))
                                    .Font.Color = RGB(255, 0, 0)
                                End With
                            End If

                            dataRow += 1
                        Next
                    Next
                End Using

                Dim usedRange As Excel.Range = wsheet.Range($"A5", $"F{dataRow - 1}")
                With usedRange.Borders
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                End With

                wsheet.Range($"B6:D{dataRow - 1}").NumberFormat = NUM_FMT

                Dim rowTotal As Integer = dataRow
                wsheet.Cells(rowTotal, 1).Value = "TOTAL"
                wsheet.Cells(rowTotal, 1).Font.Bold = True
                wsheet.Cells(rowTotal, 2).Formula = $"=SUM(B6:B{dataRow - 1})"
                wsheet.Cells(rowTotal, 3).Formula = $"=SUM(C6:C{dataRow - 1})"
                wsheet.Cells(rowTotal, 4).Formula = $"=SUM(D6:D{dataRow - 1})"

                With wsheet.Range(wsheet.Cells(rowTotal, 1), wsheet.Cells(rowTotal, 6))
                    .Font.Bold = True
                    .Interior.Color = TOTAL_COLOR
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                End With

                With wsheet.Range(wsheet.Cells(rowTotal, 1), wsheet.Cells(rowTotal, 6)).Borders
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                End With

                'Notes
                If wsheet.Name = "SELLING EXP Food" Then
                    Dim noteRow As Integer = rowTotal + 3
                    wsheet.Cells(noteRow, 1).Value = "Notes:"
                    wsheet.Cells(noteRow + 1, 1).Value = "622440 SE Delivery Expens"
                    wsheet.Cells(noteRow + 2, 1).Value = "Recorded Delivery Costs - Cavite/Tarlac"
                    wsheet.Cells(noteRow + 3, 1).Value = "Recorded Delivery Costs - Other Satellites"
                    wsheet.Cells(noteRow + 4, 1).Value = "Total"

                    Using conn As New SqlConnection(SqlConnect)
                        conn.Open()
                        Using cmd As New SqlCommand("
                            SELECT CASE WHEN BusUnit1 IN ('Cavite/Pasay','Tarlac') THEN 'Cavite/Tarlac' ELSE 'Other Satellites' END AS GRP,
                                   SUM(CASE WHEN PostingPeriod = @PrevMonth THEN Amount ELSE 0 END) AS PrevAmt,
                                   SUM(CASE WHEN PostingPeriod = @CurrMonth THEN Amount ELSE 0 END) AS CurrAmt
                            FROM vwFI_GLREPORT
                            WHERE FiscalYear = @FY AND GLAccount = '622440' AND FSItem = '52' 
                            GROUP BY CASE WHEN BusUnit1 IN ('Cavite/Pasay','Tarlac') THEN 'Cavite/Tarlac' ELSE 'Other Satellites' END ", conn)

                            cmd.Parameters.AddWithValue("@FY", fiscalYear)
                            cmd.Parameters.AddWithValue("@PrevMonth", fiscalMonth - 1)
                            cmd.Parameters.AddWithValue("@CurrMonth", fiscalMonth)


                            Dim cavPrev As Decimal = 0, cavCurr As Decimal = 0
                            Dim othPrev As Decimal = 0, othCurr As Decimal = 0

                            Using rdr = cmd.ExecuteReader()
                                While rdr.Read()
                                    If rdr("GRP").ToString() = "Cavite/Tarlac" Then
                                        cavPrev = rdr("PrevAmt")
                                        cavCurr = rdr("CurrAmt")
                                    Else
                                        othPrev = rdr("PrevAmt")
                                        othCurr = rdr("CurrAmt")
                                    End If
                                End While
                            End Using

                            wsheet.Cells(noteRow + 2, 2).Value = cavPrev
                            wsheet.Cells(noteRow + 2, 3).Value = cavCurr
                            wsheet.Cells(noteRow + 2, 4).Value = cavCurr - cavPrev

                            wsheet.Cells(noteRow + 3, 2).Value = othPrev
                            wsheet.Cells(noteRow + 3, 3).Value = othCurr
                            wsheet.Cells(noteRow + 3, 4).Value = othCurr - othPrev

                            wsheet.Cells(noteRow + 4, 2).Value = cavPrev + othPrev
                            wsheet.Cells(noteRow + 4, 3).Value = cavCurr + othCurr
                            wsheet.Cells(noteRow + 4, 4).Value = (cavCurr + othCurr) - (cavPrev + othPrev)
                        End Using
                    End Using

                    ' Note format
                    wsheet.Range(
                        wsheet.Cells(noteRow + 2, 2),
                        wsheet.Cells(noteRow + 4, 4)
                    ).NumberFormat = NUM_FMT

                    With wsheet.Range(wsheet.Cells(noteRow + 4, 1), wsheet.Cells(noteRow + 4, 4))
                        .Font.Bold = True
                        .Interior.Color = TOTAL_COLOR
                    End With

                End If

                wsheet.Columns("A:F").AutoFit()
                wsheet.Activate()
                wsheet.Range("A6").Select()
                wsheet.Application.ActiveWindow.FreezePanes = True

            Next
        Catch ex As Exception
            MessageBox.Show("Error generating FS SEGAAE: " & ex.Message)
        End Try
    End Sub

#End Region




End Class
