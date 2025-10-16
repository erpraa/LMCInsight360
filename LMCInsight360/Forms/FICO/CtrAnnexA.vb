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
                For i As Integer = 1 To 4
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

                                                .Cells(row, col) = AdjustValue(Val(GetValue(fYear, fMonth, sapSource, br.Key, fsItem, includePurchases, businessType)), reader("DCFLG").ToString())
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
                                                .Cells(row, col) = AdjustValue(Val(GetValueBS(yearValue, String.Join(",", Enumerable.Range(1, CInt(monthValue))), sapSource, fsItem, businessType)), reader("DCFLG").ToString())
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

    Private Sub FS_DetailSchedule(fiscalYear As Integer, fiscalMonth As Integer, sapSource As String, businessType As String, wbook As Excel.Workbook, useFirstSheet As Boolean)
        Dim wsheet As Excel.Worksheet =
            If(useFirstSheet, CType(wbook.Sheets(1), Excel.Worksheet),
            CType(wbook.Sheets.Add(After:=wbook.Sheets(wbook.Sheets.Count)), Excel.Worksheet))

        Dim bustypeList As String = Nothing
        Dim trxorigin As String = Nothing
        Dim TotalColor As String = "91, 155, 213"
        Dim row, col As Integer
        Dim baserow As Integer = 6

        Try
            ' === HEADER ===
            Dim repDate As New Date(fiscalYear, fiscalMonth, Date.DaysInMonth(fiscalYear, fiscalMonth))
            With wsheet
                .Name = $"DS {MonthName(fiscalMonth, True)} {fiscalYear} {If(businessType = "FOODSTUFF", "Food", "Overall")}"
                .Cells(1, 1).Value = "LIWAYWAY MARKETING CORPORATION"
                .Cells(2, 1).Value = If(businessType = "FOODSTUFF", "DETAILS SCHEDULE - FOODSTUFF ONLY", "DETAILS SCHEDULE - OVERALL")
                .Cells(3, 1).Value = "As of " & repDate.ToString("MMMM dd, yyyy")
                .Cells(4, 1).Value = If(sapSource = "L4P", "CAS", If(sapSource = "LRP", "RESERVED", ""))

                'Title Design
                For i As Integer = 1 To 3
                    ApplyTitleStyle(.Range(.Cells(i, 1), .Cells(i, fiscalMonth + 2)), Nothing, "198, 224, 180")
                Next

                row = baserow
                col = fiscalMonth

                ' === FS ITEM LOOP ===
                Dim fsItems As DataTable = GetData("SELECT RPTDISPLY, ERGSL FROM FI_RPTFORMAT WHERE RPTTYPE = 'DS' ORDER BY RPTSRT")

                For Each itemRow As DataRow In fsItems.Rows
                    Dim rptDisplay As String = itemRow("RPTDISPLY").ToString()
                    Dim fsItem As String = itemRow("ERGSL").ToString()

                    .Cells(row, 1).Value = rptDisplay
                    DSApplyCellFormat(wsheet, row, 1, True)

                    For m = 1 To col
                        .Cells(row, m + 1).Value = MonthName(m, False)
                        .Cells(row, m + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        DSApplyCellFormat(wsheet, row, m + 1, True)
                    Next
                    .Cells(row, col + 2).Value = "Total"
                    .Cells(row, col + 2).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    DSApplyCellFormat(wsheet, row, col + 2, True)

                    row += 1

                    If businessType = "FOODSTUFF" Then
                        bustypeList = "AND BusType='Foodstuff Only'"
                    End If

                    If sapSource <> Nothing Then
                        trxorigin = $"AND TrxOrigin='{sapSource}'"
                    End If

                    Dim query As String = $"SELECT CONCAT(GLAccount, ' ', GLLngDesc) AS GLDesc, PostingPeriod, SUM(Amount) AS AMT FROM vwFI_GLREPORT
                                            WHERE FiscalYear = @FY 
                                            AND PostingPeriod BETWEEN 1 AND @FM
                                            AND FSItem = @FSItem 
                                            {bustypeList} {trxorigin}
                                            GROUP BY GLAccount, GLLngDesc, PostingPeriod
                                            ORDER BY GLAccount, PostingPeriod"

                    Dim params As SqlParameter() = {
                    New SqlParameter("@FY", fiscalYear),
                    New SqlParameter("@FM", fiscalMonth),
                    New SqlParameter("@FSItem", fsItem)
                }
                    Dim glData As DataTable = GetData(query, params)

                    ' --- Write to Excel ---
                    Dim grouped = glData.AsEnumerable().GroupBy(Function(r) r("GLDesc").ToString())

                    Dim monthlyTotals As New Dictionary(Of Integer, Double)

                    For Each g In grouped

                        ' --- Process GL Data ---
                        If fsItem <> "41" Then
                            ' --- Normal GL Breakdown ---

                            ' Write GL description
                            .Cells(row, 1).Value = g.Key
                                DSApplyCellFormat(wsheet, row, 1, False)

                            Dim total As Double = 0

                            ' Loop through posting periods (months)
                            For Each record In g
                                  Dim m As Integer = CInt(record("PostingPeriod"))
                                Dim amt As Double = If(IsDBNull(record("AMT")), 0, Convert.ToDouble(record("AMT")))

                                ' Write value per month
                                .Cells(row, m + 1).Value = amt
                                    .Cells(row, m + 1).NumberFormat = DSNumericFormat
                                    DSApplyCellFormat(wsheet, row, m + 1, False)

                                    ' Update monthly totals
                                    If Not monthlyTotals.ContainsKey(m) Then monthlyTotals(m) = 0
                                    monthlyTotals(m) += amt

                                    ' Accumulate row total
                                    total += amt
                                Next

                                ' Write total at end of row
                                .Cells(row, col + 2).Value = total
                                .Cells(row, col + 2).NumberFormat = DSNumericFormat
                                DSApplyCellFormat(wsheet, row, col + 2, False)

                                ' Move to next row
                                row += 1

                        Else
                            ' --- FSItem = 41: Totals Only (No GL Breakdown) ---
                            For Each record In g

                                Dim m As Integer = CInt(record("PostingPeriod"))
                                Dim amt As Double = If(IsDBNull(record("AMT")), 0, Convert.ToDouble(record("AMT")))

                                ' Update monthly totals only
                                If Not monthlyTotals.ContainsKey(m) Then monthlyTotals(m) = 0
                                monthlyTotals(m) += amt
                            Next
                        End If

                    Next
                    ' --- TOTAL ROW ---
                    .Cells(row, 1).Value = "Total / " & rptDisplay
                    DSApplyCellFormat(wsheet, row, 1, True, TotalColor)
                    DSApplyCellFormat(wsheet, row, col + 2, True, TotalColor)

                    Dim grandTotal As Double = 0

                    ' Write total per month and compute overall total
                    For m As Integer = 1 To fiscalMonth
                        Dim val As Double = If(monthlyTotals.ContainsKey(m), monthlyTotals(m), 0)
                        grandTotal += val
                        .Cells(row, m + 1).Value = val
                        .Cells(row, m + 1).NumberFormat = DSNumericFormat

                        DSApplyCellFormat(wsheet, row, m + 1, True, TotalColor)

                    Next

                    ' Write grand total in last column
                    .Cells(row, col + 2).Value = grandTotal
                    .Cells(row, col + 2).NumberFormat = DSNumericFormat
                    DSApplyCellFormat(wsheet, row, col + 2, True)

                    row += 2
                Next

                ' === FINAL FORMATTING ===
                .Columns.AutoFit()
                .Range("A1").Select()

            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    ' === SQL HELPER ===
    Private Function GetData(sql As String, Optional params As SqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(SqlConnect)
            Using cmd As New SqlCommand(sql, conn)
                If params IsNot Nothing Then cmd.Parameters.AddRange(params)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Shared Sub DSApplyCellFormat(ws As Excel.Worksheet, row As Integer, col As Integer, bold As Boolean, Optional bckcolor As String = Nothing)
        Dim cell As Excel.Range = ws.Cells(row, col)

        ' === Border ===
        With cell.Borders
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        ' === Font and Fill ===
        With cell
            .Font.Bold = bold

            If Not String.IsNullOrEmpty(bckcolor) Then
                Dim bParts() As String = bckcolor.Split(","c)
                .Interior.Color = RGB(CInt(bParts(0)), CInt(bParts(1)), CInt(bParts(2)))
            End If

        End With
    End Sub


#End Region


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
