Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
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
                    FeatureUnavailable("IS COMPARATIVE")
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
            TxtCompYear.Enabled = False
            PnlReportType.Enabled = False
        ElseIf CbxStatementType.EditValue = "YEAR TO YEAR" Then
            CbxCompMonth.EditValue = CbxMonth.EditValue
            CbxCompMonth.Enabled = True
            TxtCompYear.Enabled = True
            PnlReportType.Enabled = True
        Else
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


#Region "SEGAAE"

    ' Excel Formatting
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
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .WrapText = True
        End With
    End Sub

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
            Dim reportDate As Date = New Date(fiscalYear, fiscalMonth, Date.DaysInMonth(fiscalYear, fiscalMonth))
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
                        Dim rng As Excel.Range = .Range(.Cells(i, 1), .Cells(i, 6))
                        ApplyTitleStyle(rng)
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
                                    If(fmtReader.IsDBNull(0), "", fmtReader.GetString(0)),  ' FSITEM
                                    If(fmtReader.IsDBNull(1), "", fmtReader.GetString(1))   ' RPTDISPLY
                                ))
                            End While
                        End Using
                    End Using

                    For Each fmt In formatList
                        Dim fsItem As String = fmt.Item1
                        Dim rptDisplay As String = fmt.Item2

                        ' FSITEM for this sheet
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

                        ' Compute difference & trend
                        For Each gl In glOrder
                            Dim prevVal As Decimal = allData(gl)(fiscalMonth - 1)
                            Dim currVal As Decimal = allData(gl)(fiscalMonth)
                            Dim diffVal As Decimal = currVal - prevVal
                            Dim trend As String = ""
                            Dim remarks As String = ""

                            ' Skip zero
                            If prevVal = 0 AndAlso currVal = 0 Then
                                Continue For
                            End If

                            If diffVal > 0 Then
                                trend = "Increase"
                            ElseIf diffVal < 0 Then
                                trend = "Decrease"
                            Else diffVal = 0
                                trend = "Same"

                            End If

                            wsheet.Cells(dataRow, 1).Value = gl
                            wsheet.Cells(dataRow, 2).Value = prevVal
                            wsheet.Cells(dataRow, 3).Value = currVal
                            wsheet.Cells(dataRow, 4).Value = diffVal
                            wsheet.Cells(dataRow, 5).Value = trend
                            wsheet.Cells(dataRow, 6).Value = remarks

                            'Red font
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

                'Apply number format to numeric columns
                wsheet.Range($"B6:D{dataRow - 1}").NumberFormat = NUM_FMT

                ' Add Total Row
                Dim rowTotal As Integer = dataRow
                wsheet.Cells(rowTotal, 1).Value = "TOTAL"
                wsheet.Cells(rowTotal, 1).Font.Bold = True

                ' Sum each numeric column based on the data above
                wsheet.Cells(rowTotal, 2).Formula = $"=SUM(B6:B{dataRow - 1})"
                wsheet.Cells(rowTotal, 3).Formula = $"=SUM(C6:C{dataRow - 1})"
                wsheet.Cells(rowTotal, 4).Formula = $"=SUM(D6:D{dataRow - 1})"

                ' Apply total formatting
                With wsheet.Range(wsheet.Cells(rowTotal, 1), wsheet.Cells(rowTotal, 6))
                    .Font.Bold = True
                    .Interior.Color = TOTAL_COLOR
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                End With

                ' Add bottom border for consistency
                With wsheet.Range(wsheet.Cells(rowTotal, 1), wsheet.Cells(rowTotal, 6)).Borders
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                End With

                wsheet.Columns("A:F").AutoFit()
            Next

        Catch ex As Exception
            MessageBox.Show("Error generating FS SEGAAE: " & ex.Message)
        End Try
    End Sub



#End Region



End Class
