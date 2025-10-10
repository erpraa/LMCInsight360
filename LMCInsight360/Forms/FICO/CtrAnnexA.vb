Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports System.Runtime.InteropServices

Public Class CtrAnnexA

    Dim BtnAnnexA As Integer

    Private Sub CtrFtr_AnnexA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnAnnexA = Gbl_FSAnnexA
        LastDateLoad()
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

            Select Case BtnAnnexA
                Case 1
                    Generate_IncomeStatement()
                Case 2
                    Generate_BalanceSheet()
                Case 3
                    Generate_DetailSchedule()
                Case 4
                    FeatureUnavailable("Generate Annex A")
            End Select

        End If

    End Sub

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

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 7

            With wsheet

                Dim reportDate = New Date(CInt(fiscalYear), fiscalMonth, Date.DaysInMonth(CInt(fiscalYear), fiscalMonth))

                'Report Title
                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = "FOODSTUFF INCOME STATEMENT"
                Else
                    .Cells(2, 1).Value = "CONSOLIDATED INCOME STATEMENT"
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

                If sapSource = "L4P" Then
                    .Cells(4, 1).Value = "CAS"
                ElseIf sapSource = "LRP" Then
                    .Cells(4, 1).Value = "RESERVED"
                End If

                .Cells(1, 1).Font.Size = 14
                .Cells(2, 1).Font.Size = 14
                .Cells(3, 1).Font.Size = 10
                .Cells(4, 1).Font.Size = 12

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

                    col += 1

                    If businessType = "FOODSTUFF" Then
                        If br.Key = "Marshmallows" Then
                            .Cells(5, col).Value = "Total Foodstuff"
                            SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)
                            col += 1
                        End If
                    End If

                Next

                ' Insert GrandTotal
                .Cells(5, col).Value = "Grand Total"
                SetSquareBorder(wsheet, 5, col, Excel.XlBorderWeight.xlThin)

                'Title Design
                For i As Integer = 1 To 4
                    With .Range(.Cells(i, 1), .Cells(i, col))
                        .Merge()
                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Font.Bold = True
                    End With
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

                                                .Cells(row, col) = AdjustValue(Val(GetValue(fYear, fMonth, sapSource, br.Key, fsItem, includePurchases, businessType)), reader("DCFLG").ToString())
                                                ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)

                                            End If

                                            ' Apply formulas
                                            If reader("FRMLA").ToString() <> "" Then
                                                .Cells(row, col).Formula = GetExcelFormula(reader("FRMLA").ToString(), col)
                                                ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)
                                            End If

                                            col += 1

                                            'Total 
                                            If fsItem <> "SKP" Then

                                                If businessType = "FOODSTUFF" Then
                                                    ' Insert TotalFoodstuff
                                                    If br.Key = "Marshmallows" Then
                                                        .Cells(row, col).Formula = $"=SUM(B{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)
                                                        col += 1
                                                    End If

                                                    ' Insert Total only at the last branch - Foodstuff
                                                    If i = totalBranches Then
                                                        .Cells(row, col).Formula = $"=SUM({GetExcelColName(col - 2)}{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)
                                                        col += 1
                                                    End If

                                                Else
                                                    ' Insert Total only at the last branch - Overall
                                                    If i = totalBranches Then
                                                        .Cells(row, col).Formula = $"=SUM(B{row}:{GetExcelColName(col - 1)}{row})"
                                                        ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)
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

    Private Sub ApplyCellFormat(cell As Excel.Range, wsheet As Excel.Worksheet, row As Integer, col As Integer, reader As IDataReader)
        cell.Font.Size = reader("VSIZE").ToString()
        cell.Font.Bold = reader("VBLD").ToString()
        cell.Font.Bold = reader("TBLD").ToString()
        SetBackFontColor(wsheet, row, col, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())
        Dim rowHeightValue = reader("ROWH")
        If IsNumeric(rowHeightValue) Then wsheet.Rows(row).RowHeight = CDbl(rowHeightValue)
        cell.NumberFormat = NumericFormat
        SetBottomBorder(wsheet, row, col, reader("ULINE").ToString().Trim())

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
            Dim fMonth As String = Nothing

            ' Column & Row tracking
            Dim col, row As Integer
            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 5

            With wsheet

                Dim reportDate = New Date(CInt(fiscalYear), fiscalMonth, Date.DaysInMonth(CInt(fiscalYear), fiscalMonth))

                'Report Title
                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                If businessType = "FOODSTUFF" Then
                    .Cells(2, 1).Value = "BALANCE SHEET - FOODSTUFF ONLY"
                    .Name = $"BS {MonthName(fiscalMonth, True)} {fiscalYear} Food"
                Else
                    .Cells(2, 1).Value = "BALANCE SHEET - OVERALL"
                    .Name = $"BS {MonthName(fiscalMonth, True)} {fiscalYear} Overall"
                End If

                .Cells(3, 1).Value = "As of " & reportDate.ToString("MMMM dd, yyyy")


                If sapSource = "L4P" Then
                    .Cells(4, 1).Value = "CAS"
                ElseIf sapSource = "LRP" Then
                    .Cells(4, 1).Value = "RESERVED"
                End If

                .Cells(1, 1).Font.Size = 14
                .Cells(2, 1).Font.Size = 13
                .Cells(3, 1).Font.Size = 12
                .Cells(4, 1).Font.Size = 12

                ' Load Month Names (header)
                Dim HeaderName As New List(Of KeyValuePair(Of String, Integer))()

                For m As Integer = 1 To CInt(fiscalMonth)
                    HeaderName.Add(New KeyValuePair(Of String, Integer)(MonthName(m, False), m)) ' True = abbreviated, False = full

                Next

                ' Print Month Name Headers
                col = baseCol
                For Each Mname In HeaderName
                    .Cells(7, col) = "'" & Mname.Key & " " & fiscalYear
                    col += 1
                Next

                With .Range(.Cells(5, 1), .Cells(5, col - 1))
                    .Merge()
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                End With

                With .Range(.Cells(40, 1), .Cells(40, col - 1))
                    .Merge()
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                End With


                'Format Month Header Row
                Dim headerStart As Excel.Range = .Cells(7, baseCol)
                Dim headerEnd As Excel.Range = .Cells(7, baseCol + HeaderName.Count - 1)
                Dim headerRange As Excel.Range = .Range(headerStart, headerEnd)



                With headerRange
                    .Font.Bold = True
                    .Font.Size = 11
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Interior.Color = RGB(155, 194, 230)
                    .Font.Color = System.Drawing.Color.Black
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                End With

                'Title Design
                For i As Integer = 1 To 3
                    With .Range(.Cells(i, 1), .Cells(i, col - 1))
                        .Merge()
                        .Interior.Color = RGB(31, 78, 120)
                        .Font.Color = System.Drawing.Color.White
                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Font.Bold = True
                    End With
                Next

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
                                    .Cells(row, 1).Font.Size = reader("TSIZE").ToString()
                                    .Cells(row, 1).Font.Bold = reader("VBLD").ToString()
                                    .Cells(row, 1).Font.Bold = reader("TBLD").ToString()
                                    SetBackFontColor(wsheet, row, col - 1, reader("FNTCLR").ToString(), reader("BCKCLR").ToString())

                                    Dim rowHeightValue = reader("ROWH")
                                    If IsNumeric(rowHeightValue) Then wsheet.Rows(row).RowHeight = CDbl(rowHeightValue)

                                    'SetBottomBorder(wsheet, row, 1, reader("ULINE").ToString().Trim())

                                    Dim totalmonth As Integer = HeaderName.Count
                                    Dim i As Integer = 0

                                    For Each Mname In HeaderName
                                        i += 1

                                        If reader("RPTDISPLY").ToString() <> "" Then

                                            fsItem = reader("ERGSL").ToString()
                                            If fsItem <> "" Then

                                                .Cells(row, col) = AdjustValue(Val(GetValueBS(fiscalYear, String.Join(",", Enumerable.Range(1, CInt(MonthNameToNum(Mname.Key)))), sapSource, fsItem, businessType)), reader("DCFLG").ToString())

                                                ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)



                                            End If

                                        End If

                                        ' Apply formulas
                                        If reader("FRMLA").ToString() <> "" Then
                                            .Cells(row, col).Formula = GetExcelFormula(reader("FRMLA").ToString(), col)
                                            ApplyCellFormat(.Cells(row, col), wsheet, row, col, reader)
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

                'Hide Previous Months (Show Only Latest)
                Try
                    Dim lastMonthCol As Integer = baseCol + HeaderName.Count - 1

                    ' Hide previous months if there’s more than one
                    If HeaderName.Count > 1 Then
                        Dim firstMonthCol As Integer = baseCol
                        Dim hideRange As Excel.Range = .Range(.Cells(7, firstMonthCol), .Cells(7, lastMonthCol - 1))
                        hideRange.EntireColumn.Hidden = True
                    End If

                Catch ex As Exception
                    MsgBox("Error hiding previous months: " & ex.Message)
                End Try

            End With

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating the Balance Sheet: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



#End Region


#Region "Details Schedule Report"
    Private Sub Generate_DetailSchedule()


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
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, True)
        ElseIf CbxBusinessType.EditValue = "OVERALL" Then
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "OVERALL", wbook, True)
        Else
            FS_DetailSchedule(TxtYear.EditValue, GetMonthNumber(CbxMonth.EditValue), sapSource, "FOODSTUFF", wbook, True)
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


    Private Sub FS_DetailSchedule(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        If fiscalMonth <= 0 Then Throw New ArgumentException("fiscalMonth must be > 0")

        Dim wsheet As Excel.Worksheet = Nothing
        Try
            If useFirstSheet Then
                wsheet = CType(wbook.Sheets(1), Excel.Worksheet)
            Else
                wsheet = CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet)
            End If

            Dim baseCol As Integer = 2
            Dim baseRow As Integer = 6
            Dim row As Integer = baseRow

            With wsheet
                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                .Cells(2, 1).Value = If(businessType = "FOODSTUFF",
                                    "ACCOUNT DETAILS SCHEDULE - FOODSTUFF ONLY",
                                    "ACCOUNT DETAILS SCHEDULE - OVERALL")
                .Cells(3, 1).Value = "As of " & New Date(fiscalYear, fiscalMonth, Date.DaysInMonth(fiscalYear, fiscalMonth)).ToString("MMMM dd, yyyy")
                .Cells(1, 1).Font.Size = 12
                .Cells(2, 1).Font.Size = 12
                .Cells(3, 1).Font.Size = 12

                Dim col As Integer = baseCol + fiscalMonth - 1
                .Range(.Cells(5, baseCol), .Cells(5, col + 1)).Merge() ' include TOTAL
                .Cells(5, baseCol).Value = "Year " & fiscalYear.ToString()
                .Cells(5, baseCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Cells(5, baseCol).Font.Bold = True

                'Title Design
                For i As Integer = 1 To 3
                    With .Range(.Cells(i, 1), .Cells(i, col + 1))
                        .Merge()
                        .Interior.Color = RGB(198, 224, 180)
                        .Font.Color = System.Drawing.Color.Black
                        .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Font.Bold = True
                    End With
                Next

                ' Month headers
                For m As Integer = 1 To fiscalMonth
                    .Cells(6, baseCol + m - 1).Value = MonthName(m, False)
                    .Cells(6, baseCol + m - 1).Font.Bold = True
                    .Cells(6, baseCol + m - 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Next

                ' Column total header
                .Cells(6, baseCol + fiscalMonth).Value = "TOTAL"
                .Cells(6, baseCol + fiscalMonth).Font.Bold = True
                .Cells(6, baseCol + fiscalMonth).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            End With

            Dim totals(fiscalMonth - 1) As Decimal
            Dim grandTotal As Decimal = 0D

            Dim formatList As New List(Of Tuple(Of String, String)) ' (RPTDISPLY, ERGSL)
            Dim allData As New Dictionary(Of String, Dictionary(Of String, Decimal()))()
            Dim allOrder As New Dictionary(Of String, List(Of String))()

            Using conn As New SqlConnection(SqlConnect)
                conn.Open()

                Dim fmtQuery As String = "SELECT RPTDISPLY, ERGSL FROM FI_RPTFORMAT WHERE RPTTYPE = 'DS' ORDER BY RPTSRT;"
                Using fmtCmd As New SqlCommand(fmtQuery, conn)
                    Using fmtReader = fmtCmd.ExecuteReader()
                        While fmtReader.Read()
                            Dim displayText As String = If(fmtReader.IsDBNull(0), String.Empty, fmtReader.GetString(0))
                            Dim fsItem As String = If(fmtReader.IsDBNull(1), String.Empty, fmtReader.GetString(1))
                            formatList.Add(New Tuple(Of String, String)(displayText, fsItem))
                        End While
                    End Using
                End Using

                Dim sqlAll As String =
                "SELECT FSItem, PostingPeriod, CONCAT(GLAccount,' ',GLLngDesc) AS GLDesc, SUM(Amount) AS AMT " &
                "FROM vwFI_GLREPORT " &
                "WHERE FiscalYear = @FiscalYear " &
                "  AND PostingPeriod BETWEEN 1 AND @MaxPeriod " &
                "  AND GLGrpDesc = 'Finance Cost' " &
                "GROUP BY FSItem, PostingPeriod, GLAccount, GLShrtDesc, GLLngDesc " &
                "ORDER BY FSItem, GLAccount, PostingPeriod;"

                Using cmdAll As New SqlCommand(sqlAll, conn)
                    cmdAll.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = fiscalYear
                    cmdAll.Parameters.Add("@MaxPeriod", SqlDbType.Int).Value = fiscalMonth

                    Using rdr = cmdAll.ExecuteReader()
                        While rdr.Read()
                            Dim fsItem As String = If(rdr.IsDBNull(rdr.GetOrdinal("FSItem")), String.Empty, rdr("FSItem").ToString())
                            Dim period As Integer = Convert.ToInt32(rdr("PostingPeriod"))
                            If period < 1 OrElse period > fiscalMonth Then Continue While
                            Dim glDesc As String = rdr("GLDesc").ToString()
                            Dim amt As Decimal = Convert.ToDecimal(rdr("AMT"))

                            If Not allData.ContainsKey(fsItem) Then
                                allData(fsItem) = New Dictionary(Of String, Decimal())()
                                allOrder(fsItem) = New List(Of String)()
                            End If

                            Dim inner = allData(fsItem)
                            If Not inner.ContainsKey(glDesc) Then
                                inner(glDesc) = New Decimal(fiscalMonth - 1) {}
                                allOrder(fsItem).Add(glDesc)
                            End If
                            inner(glDesc)(period - 1) = amt
                        End While
                    End Using
                End Using
            End Using

            For Each fmt In formatList
                Dim rptDisplay As String = fmt.Item1
                Dim fsItem As String = fmt.Item2

                If Not String.IsNullOrWhiteSpace(rptDisplay) Then
                    wsheet.Cells(row, 1).Value = rptDisplay
                    wsheet.Cells(row, 1).Font.Bold = True
                    row += 1
                End If

                If Not String.IsNullOrWhiteSpace(fsItem) AndAlso allData.ContainsKey(fsItem) Then
                    Dim inner = allData(fsItem)
                    Dim glOrder = allOrder(fsItem)

                    For Each gld In glOrder
                        Dim vals As Decimal() = inner(gld)
                        wsheet.Cells(row, 1).Value = gld
                        wsheet.Cells(row, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

                        Dim rowTotal As Decimal = 0D
                        For m As Integer = 1 To fiscalMonth
                            Dim v As Decimal = vals(m - 1)
                            rowTotal += v
                            wsheet.Cells(row, baseCol + m - 1).Value = v
                            wsheet.Cells(row, baseCol + m - 1).NumberFormat = "#,##0.00"
                            totals(m - 1) += v
                        Next

                        ' Add row total
                        wsheet.Cells(row, baseCol + fiscalMonth).Value = rowTotal
                        wsheet.Cells(row, baseCol + fiscalMonth).NumberFormat = "#,##0.00"
                        grandTotal += rowTotal

                        row += 1
                    Next
                End If
            Next

            wsheet.Cells(row, 1).Value = "TOTAL"
            wsheet.Cells(row, 1).Font.Bold = True
            For m As Integer = 1 To fiscalMonth
                wsheet.Cells(row, baseCol + m - 1).Value = totals(m - 1)
                wsheet.Cells(row, baseCol + m - 1).NumberFormat = "#,##0.00"
                wsheet.Cells(row, baseCol + m - 1).Font.Bold = True
            Next

            ' Column total grand total
            wsheet.Cells(row, baseCol + fiscalMonth).Value = grandTotal
            wsheet.Cells(row, baseCol + fiscalMonth).NumberFormat = "#,##0.00"
            wsheet.Cells(row, baseCol + fiscalMonth).Font.Bold = True


            With wsheet
                .UsedRange.Font.Name = "Calibri"
                .UsedRange.Columns.AutoFit()
                .Range("B7").Select()
                .Application.ActiveWindow.FreezePanes = True
            End With

        Catch ex As Exception
            MessageBox.Show("Error generating Details Schedule Report: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region

#Region "Last Load Data"

    Sub LastDateLoad()

        LblLoadDate.Text = Nothing
        LblStatus.Text = Nothing

        If CbxMonth.EditValue <> "" And TxtYear.EditValue <> "" Then

            Dim dataList As List(Of Dictionary(Of String, String)) = GetMultiValues($"Select case when PSTDATE is Null then LDDATE else PSTDATE end as LPDATE, PSTATS from FI_PSTNGPRD where POPER ={GetMonthNumber(CbxMonth.EditValue.ToString())} and RYEAR={TxtYear.EditValue}")

            For Each record In dataList

                If record("PSTATS") = True Then
                    LblStatus.Text = "Closed Period"
                    LblStatus.ForeColor = Color.Green
                Else
                    LblStatus.Text = "Open Period"
                    LblStatus.ForeColor = Color.Red
                End If

                LblLoadDate.Text = "Last Load Date: " & record("LPDATE")

            Next
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
