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
        BtnAnnexB = Gbl_ReportTag
        TxtYear.Text = Date.Now.Year.ToString()
    End Sub

#Region "Filter Logic"
    Sub FilterLogic(sender As Object, e As EventArgs) Handles CbxStatementType.SelectedIndexChanged, CbxMonth.SelectedIndexChanged, TxtYear.EditValueChanged, CbxCompMonth.SelectedIndexChanged, TxtCompYear.EditValueChanged
        Select Case BtnAnnexB
            Case 1
                LblTypeReport.Text = "Statement Type: *"
                CbxStatementType.Show()
                CbxRptSheet.Hide()
                CbxRptSheet1.Hide()

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
            Case 2
                LblTypeReport.Text = "(SE/GAAE) Report: *"
                CbxStatementType.Hide()
                CbxRptSheet.Show()
                CbxRptSheet1.Hide()
                PnlReportType.Hide()

            Case 3
                LblTypeReport.Text = "RealizedFx/UnrealizeFx: *"
                CbxStatementType.Hide()
                CbxRptSheet.Hide()
                CbxRptSheet1.Show()
                PnlReportType.Hide()

                LblCompPrd.Hide()
                CbxCompMonth.Hide()
                TxtCompYear.Hide()
        End Select
    End Sub
#End Region

#Region "Annex B Report"

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
                    Generate_SEGAAE()
                Case 3
                    Generate_RUFx_GainLoss()
            End Select

        End If

    End Sub

#End Region

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
                    MessageBox.Show("Please input Comparative Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "FOODSTUFF", "MTM", Nothing, wbook, True)
                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, "OVERALL", "MTM", Nothing, wbook, False)

            ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then

                If String.IsNullOrWhiteSpace(TxtCompYear.Text) Then
                    MessageBox.Show("Please input Comparative Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    MessageBox.Show("Please input Comparative Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                FS_IncomeStatementComp(fmonth, fyear, cmpfmonth, cmpfyear, sapSource, BusinessType, "MTM", Nothing, wbook, True)
            ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then

                If String.IsNullOrWhiteSpace(TxtCompYear.Text) Then
                    MessageBox.Show("Please input Comparative Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                                    SetBorderStyle(wsheet, row, 1, reader("ULINE"), reader("PLINE"))
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

                                            SetBorderStyle(wsheet, row, col, reader("ULINE"), reader("PLINE"))
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
            SetBorderStyle(wsheet, row, col, reader("ULINE"), reader("PLINE"))
            SetBackFontColor(wsheet, row, col, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())
        End With
    End Sub

#End Region

#Region "SEGAAE"

    Private Sub Generate_SEGAAE()

        If String.IsNullOrWhiteSpace(CbxCompMonth.EditValue) Then
            MessageBox.Show("Please input Month", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtCompYear.Text) Then
            MessageBox.Show("Please input Year", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


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

        Dim fiscalYear As Integer = TxtYear.EditValue
        Dim fiscalMonth As Integer = GetMonthNumber(CbxMonth.EditValue)
        Dim CmpFYear As Integer = TxtCompYear.EditValue
        Dim CmpFMonth As Integer = GetMonthNumber(CbxCompMonth.EditValue)


        If CbxBusinessType.EditValue = "" Then
            If CbxRptSheet.EditValue = "Selling Expenses" Then
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", "FOODSTUFF", wbook, True)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", "OVERALL", wbook, False)
            ElseIf CbxRptSheet.EditValue = "Administrative Expenses" Then
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", "FOODSTUFF", wbook, True)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", "OVERALL", wbook, False)
            Else
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", "FOODSTUFF", wbook, True)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", "OVERALL", wbook, False)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", "FOODSTUFF", wbook, False)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", "OVERALL", wbook, False)
            End If
        Else
            Dim BusinessType As String = CbxBusinessType.EditValue

            If CbxRptSheet.EditValue = "Selling Expenses" Then
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", BusinessType, wbook, True)
            ElseIf CbxRptSheet.EditValue = "Administrative Expenses" Then
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", BusinessType, wbook, True)
            Else
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Selling Exp", BusinessType, wbook, True)
                FS_SEGAAE(fiscalMonth, fiscalYear, CmpFMonth, CmpFYear, sapSource, "Admin Exp", BusinessType, wbook, False)
            End If

        End If

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)
        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub FS_SEGAAE(fiscalMonth As Integer, fiscalYear As Integer, CmpFMonth As Integer, CmpFYear As Integer, sapSource As String, tabType As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim wsheet As Excel.Worksheet = Nothing

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            Dim saptitle As String = Nothing
            Dim fsitem As String = Nothing

            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 6

            With wsheet

                'Report Title
                saptitle = If(sapSource = "L4P", " (CAS)", If(sapSource = "LRP", " (Reserved)", ""))
                Dim typeLabel As String = If(businessType = "FOODSTUFF", "Foodstuff", "Overall")
                Dim namePrefix As String = If(businessType = "FOODSTUFF", "Food", "Overall")

                .Cells(1, 1).Value = "Liwayway Marketing Corporation"
                If tabType = "Selling Exp" Then
                    .Cells(2, 1).Value = $"Comparative Summary Of Selling Expenses - {typeLabel} {saptitle}"
                    .Name = $"Selling Exp - {namePrefix}"
                    fsitem = "52"
                Else
                    .Cells(2, 1).Value = $"Comparative Summary Of Administrative Expenses - {typeLabel} {saptitle}"
                    .Name = $"GAAE - {namePrefix}"
                    fsitem = "54"
                End If
                .Cells(3, 1).Value = $"For the Months Of {MonthName(CmpFMonth)} {CmpFYear} & {MonthName(fiscalMonth)} {fiscalYear}"

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, 6)), Nothing, "180,198,231")
                Next

                Dim HeaderName As Integer = 5
                .Cells(HeaderName, 1).Value = "Account Description"
                .Cells(HeaderName, 2).Value = $"'{MonthName(CmpFMonth)} {CmpFYear}"
                .Cells(HeaderName, 3).Value = $"'{MonthName(fiscalMonth)} {fiscalYear}"
                .Cells(HeaderName, 4).Value = "Difference"
                .Cells(HeaderName, 5).Value = "Trend"
                .Cells(HeaderName, 6).Value = "Remarks"

                With .Range(.Cells(HeaderName, 1), .Cells(HeaderName, 6))
                    .Font.Bold = True
                    .Interior.Color = RGB(198, 224, 180)
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                End With

                col = baseCol
                row = baseRow

                Dim formatList As New List(Of Tuple(Of String, String))

                Using conn As New SqlConnection(SqlConnect)
                    conn.Open()

                    Dim busType As String = If(businessType = "FOODSTUFF", "and BusType='Foodstuff Only'", Nothing)

                    Dim trxOrigin As String = Nothing
                    If sapSource <> Nothing Then
                        trxOrigin = $"and TrxOrigin='{sapSource}'"
                    End If

                    Using cmd As New SqlCommand($"select distinct GLAccount, Concat(GLAccount,' ',GLLngDesc) AccntDesc  from vwFI_GLREPORT where FSItem='{fsitem}'
                                                  and FiscalYear IN ({CmpFYear},{fiscalYear}) and PostingPeriod IN ({CmpFMonth},{fiscalMonth}) {busType} {trxOrigin} ", conn)
                        Using Reader = cmd.ExecuteReader()
                            If Reader.HasRows Then
                                While Reader.Read()

                                    Dim glaccnt = Reader("GLAccount").ToString()

                                    .Cells(row, 1) = Reader("AccntDesc").ToString()

                                    For i As Integer = 1 To 4

                                        If i = 1 Then
                                            .Cells(row, col) = GetAmount(RptQueryGaae(CmpFYear, CmpFMonth, fsitem, glaccnt, sapSource, businessType))
                                        ElseIf i = 2 Then
                                            .Cells(row, col) = GetAmount(RptQueryGaae(fiscalYear, fiscalMonth, fsitem, glaccnt, sapSource, businessType))
                                        ElseIf i = 3 Then
                                            .Cells(row, col).Formula = $"=C{row}-B{row}"
                                        ElseIf i = 4 Then
                                            If .Cells(row, col - 1).value > 0 Then
                                                .Cells(row, col) = "Increase"
                                                .Cells(row, col).Font.Color = RGB(0, 176, 80)
                                            ElseIf .Cells(row, col - 1).value < 0 Then
                                                .Cells(row, col) = "Decrease"
                                                .Cells(row, col).Font.Color = RGB(255, 0, 0)
                                            Else
                                                .Cells(row, col) = "Same"
                                            End If
                                            .Cells(row, col).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                        End If

                                        col += 1
                                    Next

                                    col = baseCol
                                    row += 1

                                End While

                                .Cells(row, 1).Value = "TOTAL"
                                .Cells(row, 2).Formula = $"=SUM(B6:B{row - 1})"
                                .Cells(row, 3).Formula = $"=SUM(C6:C{row - 1})"
                                .Cells(row, 4).Formula = $"=SUM(D6:D{row - 1})"
                                .Range($"A{row}:F{row}").Font.Bold = True
                                .Range($"A{row}:F{row}").Interior.Color = RGB(141, 180, 226)

                                .Range($"B6:D{row}").NumberFormat = DSNumericFormat
                                .Range($"A5:F{row}").Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                                row += 2
                            End If
                        End Using
                    End Using

                    If tabType = "Selling Exp" Then

                        Dim startrow As Integer = 0

                        .Cells(row, 1).Value = "Notes:"
                        .Cells(row, 1).Font.Bold = True

                        row += 1
                        .Cells(row, 2).Value = $"'{MonthName(CmpFMonth)} {CmpFYear}"
                        .Cells(row, 3).Value = $"'{MonthName(fiscalMonth)} {fiscalYear}"
                        .Cells(row, 4).Value = "Difference"
                        .Range(.Cells(row, 1), .Cells(row, 4)).Font.Bold = True
                        .Range(.Cells(row, 2), .Cells(row, 4)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                        Using cmd As New SqlCommand($"SELECT Concat(GLAccount,' ',GLLngDesc) as GLdesc,CASE WHEN ProfitCntr IN ('1100-FOOD','1400-FOOD') THEN 'Cavite/Tarlac' ELSE 'Other Satellites' END AS busGrp,
                                                  SUM(CASE WHEN PostingPeriod={CmpFMonth} and FiscalYear={CmpFYear} THEN Amount ELSE 0 END) AS PrevAmt,
                                                  SUM(CASE WHEN PostingPeriod={fiscalMonth} and FiscalYear={fiscalYear} THEN Amount ELSE 0 END) AS CurrAmt
                                                  FROM vwFI_GLREPORT
                                                  WHERE GLAccount = '622440' AND FSItem = '52' {busType} {trxOrigin}
                                                  GROUP BY Concat(GLAccount,' ',GLLngDesc),CASE WHEN ProfitCntr IN ('1100-FOOD','1400-FOOD') THEN 'Cavite/Tarlac' ELSE 'Other Satellites' END", conn)
                            Using Reader = cmd.ExecuteReader()
                                If Reader.HasRows Then
                                    Dim glDescWritten As Boolean = False
                                    While Reader.Read()

                                        If Not glDescWritten Then
                                            .Cells(row, 1) = Reader("GLdesc").ToString()
                                            glDescWritten = True
                                            row += 1
                                            startrow = row
                                        End If

                                        .Cells(row, 1) = Reader("busGrp").ToString()
                                        .Cells(row, 2) = Reader("PrevAmt").ToString()
                                        .Cells(row, 3) = Reader("CurrAmt").ToString()
                                        .Cells(row, 4).Formula = $"=C{row}-B{row}"

                                        row += 1
                                    End While
                                End If

                                .Cells(row, 1).Value = "TOTAL"
                                .Cells(row, 2).Formula = $"=SUM(B{startrow}:B{row - 1})"
                                .Cells(row, 3).Formula = $"=SUM(C{startrow}:C{row - 1})"
                                .Cells(row, 4).Formula = $"=SUM(D{startrow}:D{row - 1})"
                                .Range($"A{row}:D{row}").Font.Bold = True

                                .Range($"B{startrow}:D{row}").NumberFormat = DSNumericFormat

                                With .Range($"B{row}:D{row}")
                                    .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                                End With

                            End Using
                        End Using

                    End If

                End Using

                .Columns("A:F").AutoFit()
                .Activate()
                .Range("A6").Select()
                .Application.ActiveWindow.FreezePanes = True

            End With

        Catch ex As Exception
            MessageBox.Show("Error generating FS SEGAAE: " & ex.Message)
        End Try

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

#End Region

#Region "RealizedFx / UnrealizedFx (Gain or Loss)"
    Private Sub Generate_RUFx_GainLoss()

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

        Dim fiscalMonth As Integer = GetMonthNumber(CbxMonth.EditValue)
        Dim fiscalYear As Integer = TxtYear.EditValue

        If CbxBusinessType.EditValue = "" Then

            If CbxRptSheet1.EditValue = "RealizedFx Gain Loss" Then
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, "FOODSTUFF", wbook, True)
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, "OVERALL", wbook, False)
            ElseIf CbxRptSheet1.EditValue = "UnrealizedFx Gain Loss" Then
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, "FOODSTUFF", wbook, True)
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, "OVERALL", wbook, False)
            Else
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, "FOODSTUFF", wbook, True)
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, "FOODSTUFF", wbook, False)
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, "OVERALL", wbook, False)
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, "OVERALL", wbook, False)
            End If
        Else
            Dim BusinessType As String = CbxBusinessType.EditValue

            If CbxRptSheet1.EditValue = "RealizedFx Gain Loss" Then
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, BusinessType, wbook, True)
            ElseIf CbxRptSheet1.EditValue = "UnrealizedFx Gain Loss" Then
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, BusinessType, wbook, True)
            Else
                FS_RealizedFx(fiscalMonth, fiscalYear, sapSource, BusinessType, wbook, True)
                FS_UnrealizedFx(fiscalMonth, fiscalYear, sapSource, BusinessType, wbook, False)
            End If

        End If

        wbook.Sheets(1).Activate()
        excelApp.Visible = True

        If wbook IsNot Nothing Then Marshal.ReleaseComObject(wbook)
        If excelApp IsNot Nothing Then Marshal.ReleaseComObject(excelApp)
        wbook = Nothing
        excelApp = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub FS_RealizedFx(fiscalMonth As Integer, fiscalYear As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim wsheet As Excel.Worksheet = Nothing
        Dim headerColor = RGB(198, 224, 180)

        Dim Fcnt, F1cnt, F2cnt, F3cnt As Integer

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            Dim saptitle As String = Nothing
            Dim col, row As Integer
            Dim baseCol As Integer = 1
            Dim baseRow As Integer = 6

            With wsheet

                'Report Title
                saptitle = If(sapSource = "L4P", " (CAS)", If(sapSource = "LRP", " (Reserved)", ""))
                Dim typeLabel As String = If(businessType = "FOODSTUFF", "Foodstuff", "Overall")
                Dim namePrefix As String = If(businessType = "FOODSTUFF", "Food", "Overall")

                .Name = $"RealizedFx Gain Loss - {namePrefix}"
                .Cells(1, 1).Value = "Liwayway Marketing Corporation"
                .Cells(2, 1) = $"Summary of Realized Gain/Loss on Foreign Currency - {typeLabel} {saptitle}"
                .Cells(3, 1) = $"For the Period Ended {MonthName(fiscalMonth)} {Date.DaysInMonth(fiscalYear, fiscalMonth)}, {fiscalYear}"

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, 9)), Nothing, "180,198,231")
                Next

                .Cells(5, 1).Value = "REALIZED GAIN\(LOSS) - FINANCIAL"
                .Cells(5, 3).Value = "Loan Payment"
                .Cells(5, 6).Value = " Exchange Rate"
                .Range("F5:H5").Merge()

                With .Range("A5:I6")
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Font.Bold = True
                    .Interior.Color = headerColor
                End With

                Dim trxOrigin As String = Nothing
                If sapSource <> Nothing Then
                    trxOrigin = $"and TrxOrigin='{sapSource}'"
                End If

                Dim query As String = $"Select 
                                        VendorName as 'Name of Bank',
                                        Assignment as 'PN Number',	
                                        AmountCC as '{MonthName(fiscalMonth)} 1-{Date.DaysInMonth(fiscalYear, fiscalMonth)}, {fiscalYear}',									  
									    FORMAT(PostingDate, 'dd-MMM-yy') as 'Booking Date',
                                        FORMAT(ClearingDate, 'dd-MMM-yy')  as 'Payment Date',
                                        BRate as 'Original Rate',
                                        PRate as 'Payment Rate',
                                        (BRate - PRate) as 'Net Change',
                                        (BRate - PRate) * AmountCC AS 'Net Amount'

                                        from LMCMSTRPT.dbo.vwFI_GAINLOSSR
                                        where DocumentType = 'KA' and PostingKey = '31' and DocumentCurrency = 'USD'
                                        and FiscalYear = {fiscalYear}
                                        and Month(ClearingDate) ={fiscalMonth}
                                        {trxOrigin}

										order by VendorName"

                Dim dt As New DataTable()

                Using conn As New SqlConnection(SqlConnect)
                    Dim cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using

                col = baseCol
                row = baseRow

                'Column Headers
                For i As Integer = 0 To dt.Columns.Count - 1
                    .Cells(row, col) = dt.Columns(i).ColumnName
                    col += 1
                Next

                'Write Data Rows
                For r As Integer = 0 To dt.Rows.Count - 1
                    col = baseCol
                    row += 1

                    For c As Integer = 0 To dt.Columns.Count - 1
                        .Cells(row, col) = dt.Rows(r)(c).ToString()
                        col += 1
                    Next
                Next

                'Add Formula
                row += 1 '
                .Cells(row, 1).Value = "REALIZED GAIN/(LOSS) on Forex - Bank Loan"
                .Cells(row, 3).Formula = $"=SUM(C{baseRow + 1}:C{row - 1})"
                .Cells(row, 6).Formula = $"=SUMPRODUCT(C{baseRow + 1}:C{row - 1},F{baseRow + 1}:F{row - 1}) / C{row}"
                .Cells(row, 7).Formula = $"=SUMPRODUCT(C{baseRow + 1}:C{row - 1},G{baseRow + 1}:G{row - 1}) / C{row}"
                .Cells(row, 8).Formula = $"=F{row}-G{row}"
                .Cells(row, 9).Formula = $"=SUM(I{baseRow + 1}:I{row - 1})"

                'Format 
                .Range($"C{baseRow + 1}:C{row}").NumberFormat = DollarFormat
                .Range($"F{baseRow + 1}:H{row}").NumberFormat = ExchangeRateFormat
                .Range($"I{baseRow + 1}:I{row}").NumberFormat = NumericFormat

                With .Range($"A{row}:I{row}")
                    .Font.Bold = True
                    .Interior.Color = headerColor
                End With

                With .Range($"A{baseRow - 1}:I{row}")
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    .Borders.Weight = Excel.XlBorderWeight.xlThin
                End With

                F1cnt = row
                col = baseCol
                row += 2

                'GAIN/LOSS - OPERATIONS
                Dim dataF As List(Of Dictionary(Of String, String)) = GetMultiValues("select * from FI_RPTFORMAT where RPTTYPE='BRFX' order by RPTSRT")

                Dim bsType As String = If(businessType = "FOODSTUFF", "'Foodstuff Only'", "NULL")

                If sapSource <> Nothing Then
                    trxOrigin = "'" & sapSource & "'"
                Else
                    trxOrigin = "NULL"
                End If

                For Each record As Dictionary(Of String, String) In dataF
                    Dim FsItem = record("ERGSL").ToString
                    Dim Fmrla = record("FRMLA").ToString

                    .Cells(row, baseCol) = record("RPTDISPLY").ToString
                    SetBorderStyle(wsheet, row, baseCol, record("ULINE"), record("PLINE"))
                    SetBorderStyle(wsheet, row, baseCol, "S", "R")

                    For i As Integer = 0 To dt.Columns.Count - 1
                        SetBorderStyle(wsheet, row, col, record("ULINE"), record("PLINE"))
                        SetBorderStyle(wsheet, row, col, "S", "R")
                        col += 1
                    Next

                    col -= 1

                    If FsItem <> "SKP" AndAlso FsItem <> "" Then
                        .Cells(row, col) = AdjustValue(Val(GetAmount($"select SUM(Amount) from FnFI_GAINLOSSR ({fiscalYear},{fiscalMonth},'{FsItem}',{bsType},{trxOrigin})")), record("DCFLG").ToString())
                        .Cells(row, col).NumberFormat = GetCurrencyFormat("Normal")

                        Fcnt += 1
                    End If

                    If Fmrla = "F1" Then
                        .Cells(row, col) = $"=SUM(I{row - Fcnt}:I{row - 1})"
                        .Cells(row, col).Font.Bold = True
                        F2cnt = row
                        Fcnt = 0
                    ElseIf Fmrla = "F2" Then
                        .Cells(row, col) = $"=I{row - 1}"
                        .Cells(row, col).Font.Bold = True
                        F3cnt = row
                    ElseIf Fmrla = "F3" Then
                        .Cells(row, col) = $"=I{F1cnt}+I{F2cnt}+I{F3cnt}"
                        .Cells(row, col).Font.Bold = True
                    End If

                    col = baseCol
                    row += 1
                Next

                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

            End With

        Catch ex As Exception
            MessageBox.Show("Error generating: " & ex.Message)
        End Try

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

    Private Sub FS_UnrealizedFx(fiscalMonth As Integer, fiscalYear As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        Dim wsheet As Excel.Worksheet = Nothing

        Dim Grp1Color = RGB(198, 224, 180)
        Dim Grp2Color = RGB(155, 194, 230)

        Dim Fcnt, F1cnt, F2cnt, F3cnt As Integer

        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            Dim saptitle As String = Nothing
            Dim col, row As Integer
            Dim baseCol As Integer = 1
            Dim baseRow As Integer = 6

            With wsheet

                'Report Title
                saptitle = If(sapSource = "L4P", " (CAS)", If(sapSource = "LRP", " (Reserved)", ""))
                Dim typeLabel As String = If(businessType = "FOODSTUFF", "Foodstuff", "Overall")
                Dim namePrefix As String = If(businessType = "FOODSTUFF", "Food", "Overall")

                .Name = $"UnrealizeFx Gain Loss - {namePrefix}"
                .Cells(1, 1).Value = "Liwayway Marketing Corporation"
                .Cells(2, 1) = $"Summary of Unrealized Gain/Loss on Foreign Currency - {typeLabel} {saptitle}"
                .Cells(3, 1) = $"For the Period Ended {MonthName(fiscalMonth)} {Date.DaysInMonth(fiscalYear, fiscalMonth)}, {fiscalYear}"

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, 8)), Nothing, "180,198,231")
                Next

                .Cells(5, 1).Value = "UNREALIZED GAIN\(LOSS) - FINANCIAL"
                .Cells(5, 3).Value = "Loan Balance"
                .Cells(5, 6).Value = " Exchange Rate"
                .Range("E5:G5").Merge()

                With .Range("A5:H6")
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Font.Bold = True
                    .Interior.Color = Grp1Color
                End With

                Dim trxOrigin As String = "NULL"
                If sapSource <> Nothing Then
                    trxOrigin = "'" & sapSource & "'"
                End If

                Dim query As String = $"select 
                                       VendorName as 'Name of Bank',
                                       Assignment as 'PN Number',
                                       AmountCC as '{MonthName(fiscalMonth)} 1-{Date.DaysInMonth(fiscalYear, fiscalMonth)}, {fiscalYear}',
                                       FORMAT(PostingDate, 'dd-MMM-yy') as 'Booking Date',
                                       BRate as 'Doc Rate',
                                       RRate as '{MonthName(fiscalMonth)} 1-{Date.DaysInMonth(fiscalYear, fiscalMonth)}, {fiscalYear} ',
                                       UNetChange as 'Net Change',
                                       UAmountNet as 'Net Amount'from FnFI_GAINLOSSU ({fiscalMonth},{fiscalYear},{trxOrigin})
                                       Order by VendorName"

                Dim dt As New DataTable()

                Using conn As New SqlConnection(SqlConnect)
                    Dim cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using

                col = baseCol
                row = baseRow

                'Column Headers
                For i As Integer = 0 To dt.Columns.Count - 1
                    .Cells(row, col) = dt.Columns(i).ColumnName
                    col += 1
                Next

                'Write Data Rows
                For r As Integer = 0 To dt.Rows.Count - 1
                    col = baseCol
                    row += 1

                    For c As Integer = 0 To dt.Columns.Count - 1
                        .Cells(row, col) = dt.Rows(r)(c).ToString()
                        col += 1
                    Next
                Next

                'Add Formula
                row += 1 '
                .Cells(row, 1).Value = "TOTAL"
                .Cells(row, 3).Formula = $"=SUM(C{baseRow + 1}:C{row - 1})"
                .Cells(row, 5).Formula = $"=SUMPRODUCT(C{baseRow + 1}:C{row - 1},E{baseRow + 1}:E{row - 1}) / C{row}"
                .Cells(row, 6).Formula = $"=SUMPRODUCT(C{baseRow + 1}:C{row - 1},F{baseRow + 1}:F{row - 1}) / C{row}"
                .Cells(row, 7).Formula = $"=E{row}-F{row}"
                .Cells(row, 8).Formula = $"=SUM(H{baseRow + 1}:H{row - 1})"

                'Format 
                .Range($"C{baseRow + 1}:C{row}").NumberFormat = DollarFormat
                .Range($"E{baseRow + 1}:G{row}").NumberFormat = ExchangeRateFormat

                With .Range($"A{row}:H{row}")
                    .Font.Bold = True
                    .Interior.Color = Grp1Color
                    .RowHeight = 25
                End With

                row += 1 '

                '210001 - Valuation
                Dim dataV As List(Of Dictionary(Of String, String)) = GetMultiValues($"SELECT SGTXT,SUM(HSL) AS AMT FROM FI_VACDOCA AS f 
                               WHERE LEFT(LTRIM(RTRIM(f.SGTXT)), 6) in ('210001') 
                               and BUDAT='{fiscalYear}-{fiscalMonth}-01'
                               GROUP BY SGTXT")

                For Each record As Dictionary(Of String, String) In dataV
                    .Cells(row, 1) = record("SGTXT").ToString
                    .Cells(row, 8) = record("AMT")
                Next

                row += 1

                .Cells(row, 1) = "UNREALIZED GAIN/(LOSS) on Forex - Bank Loans"
                .Cells(row, 8) = $"=(H{row - 2} + H{row - 1}) * -1"
                .Range($"H{baseRow + 1}:H{row}").NumberFormat = NumericFormat

                With .Range($"A{row}:H{row}")
                    .Font.Bold = True
                    .Interior.Color = Grp2Color
                    .RowHeight = 25
                End With

                With .Range($"A{baseRow - 1}:H{row}")
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    .Borders.Weight = Excel.XlBorderWeight.xlThin
                End With

                F1cnt = row
                col = baseCol
                row += 2

                'Foreign Currency Breakdown
                Dim tCurrency As String = Nothing

                Dim dataF As List(Of Dictionary(Of String, String)) = GetMultiValues("select * from FI_RPTFORMAT where RPTTYPE='BUFX' order by RPTSRT")

                Dim currencies As String() = {"USD", "EUR", "JPY", "SGD", "CNY", "HKD", "Normal"}

                For Each record As Dictionary(Of String, String) In dataF
                    Dim Fmrla As String = record("FRMLA").ToString
                    Dim FsItem As String = record("ERGSL").ToString

                    .Cells(row, baseCol) = record("RPTDISPLY").ToString
                    SetBorderStyle(wsheet, row, baseCol, record("ULINE"), record("PLINE"))
                    SetBorderStyle(wsheet, row, baseCol, "S", "R")

                    For i As Integer = 0 To currencies.Length - 1
                        tCurrency = currencies(i)
                        col += 1

                        If FsItem <> "" Then
                            If tCurrency = "Normal" Then
                                .Cells(row, col) = Val(GetAmount(RptQueryUnFxP(fiscalYear, fiscalMonth, FsItem, sapSource, businessType)))
                            Else
                                .Cells(row, col) = Val(GetAmount(RptQueryUnFxF(fiscalYear, fiscalMonth, FsItem, tCurrency, sapSource, businessType)))
                            End If
                            .Cells(row, col).NumberFormat = GetCurrencyFormat(tCurrency)
                        End If

                        SetBorderStyle(wsheet, row, col, record("ULINE"), record("PLINE"))
                        SetBorderStyle(wsheet, row, col, "S", "R")
                    Next

                    If FsItem <> "" Then
                        Fcnt += 1
                    End If

                    If Fmrla = "F1" Then
                        .Cells(row, 8) = $"=SUM(H{row - Fcnt}:H{row - 1})"
                        .Cells(row, 8).Font.Bold = True
                        F2cnt = row
                        Fcnt = 0
                    ElseIf Fmrla = "F2" Then
                        .Cells(row, 8) = $"=SUM(H{row - Fcnt}:H{row - 1})"
                        .Cells(row, 8).Font.Bold = True
                        F3cnt = row
                    ElseIf Fmrla = "F3" Then
                        .Cells(row, 8) = $"=H{F1cnt}+H{F2cnt}+H{F3cnt}"
                        .Cells(row, 8).Font.Bold = True
                    End If

                    col = baseCol
                    row += 1
                Next

                With .Range(.Cells(row - 1, 1), .Cells(row - 1, currencies.Length + 1))
                    .Font.Bold = True
                    .Interior.Color = Grp2Color
                    .RowHeight = 25
                End With

                .UsedRange.Font.Name = "Tahoma"
                .UsedRange.Columns.AutoFit()

            End With

        Catch ex As Exception
            MessageBox.Show("Error generating: " & ex.Message)
        End Try

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

#End Region

End Class