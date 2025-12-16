Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports Sap.Data.Hana
Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubQuery.Datainialized
Public Class CtrDataInitializeFI

    Private Sub CtrDataInitializeFI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        TxtMonth.Text = ""
        TxtYear.Text = ""
    End Sub

    Private Sub BtnLoadData_Click(sender As Object, e As EventArgs) Handles BtnLoadData.Click

        If String.IsNullOrWhiteSpace(TxtMonth.Text) Then
            MessageBox.Show("Please Select Period", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show("This may take several minutes to load data....", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then

            Dim sql As String = $"select * from FI_PSTNGPRD where RYEAR={TxtYear.Text} and POPER={GetMonthNumber(TxtMonth.Text)}"
            Dim data As List(Of Dictionary(Of String, String)) = GetMultiValues(sql)

            For Each row As Dictionary(Of String, String) In data

                Dim postingperiod As String = row("POPER")
                Dim fiscalyear As String = row("RYEAR")
                Dim poststat As String = row("PSTATS")

                If poststat = True Then
                    MessageBox.Show($"{MonthName(postingperiod)} {fiscalyear} is already closed.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

                LoadSapDataHeader()

                Dim params As New Dictionary(Of String, Object) From {{"@PostingPeriod", postingperiod}, {"@FiscalYear", fiscalyear}}

                ExecuteDelete(DelTrxDetails, params)
                ExecuteDelete(DelTrxData, params)

                Dim reseed As New Dictionary(Of String, Object) From {{"@TableName", "FI_TRXDETAILS"}}
                ExecuteProcedure("RESEED_TRXROW", reseed, False)

                LoadDataDetails("L4P", CasConnect, fiscalyear, postingperiod)
                LoadDataDetails("LRP", ResConnect, fiscalyear, postingperiod)
                ExecuteProcedure("INS_FI_TRXDATA", params, False)
                ExecuteProcedure("UPD_FI_TRXDATA", params, False)

                Dim upparams As New Dictionary(Of String, Object) From {
                    {"@loaddate", GetServerDate()},
                    {"@postby", GstrUselogin},
                    {"@PostingPeriod", postingperiod},
                    {"@FiscalYear", fiscalyear}
                }
                ExecuteUpdate(UpdateLoadDate, upparams)

                ExecuteDelete("Delete from FI_VBSEG")
                LoadDataSAPSQL("FI_VBSEG", CasConnect, $"Select 'L4P' as TRX_ORIGIN,{SelectBSEG}")
                LoadDataSAPSQL("FI_VBSEG", ResConnect, $"Select 'LRP' as TRX_ORIGIN,{SelectBSEG}")

                ExecuteDelete("Delete from FI_VACDOCA")
                LoadDataSAPSQL("FI_VACDOCA", CasConnect, $"Select 'L4P' as TRX_ORIGIN,{SelectACDOCA}")
                LoadDataSAPSQL("FI_VACDOCA", ResConnect, $"Select 'LRP' as TRX_ORIGIN,{SelectACDOCA}")

                LoadDataSAPSQL("FI_VTCURR", CasConnect, SubQuery.SelectTCURR(fiscalyear, postingperiod))

                LoadDataSAPSQL("FI_VBKPF", CasConnect, SubQuery.SelectBKPF("L4P", fiscalyear, postingperiod))
                LoadDataSAPSQL("FI_VBKPF", ResConnect, SubQuery.SelectBKPF("LRP", fiscalyear, postingperiod))

                SplashScreenManager.CloseDefaultWaitForm()
            Next

            LoadData()

        End If

    End Sub

    Private Sub BtnClosedPeriod_Click(sender As Object, e As EventArgs) Handles BtnClosedPeriod.Click

        If String.IsNullOrWhiteSpace(TxtMonth.Text) Then
            MessageBox.Show("Please Select Period", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show($"Are you sure you want to close the {TxtMonth.Text} {TxtYear.Text} period? {vbCrLf} Please ensure that all data is up to date before proceeding.", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            Dim sql As String = $"select * from FI_PSTNGPRD where RYEAR={TxtYear.Text} and POPER={GetMonthNumber(TxtMonth.Text)}"
            Dim data As List(Of Dictionary(Of String, String)) = GetMultiValues(sql)

            For Each row As Dictionary(Of String, String) In data

                Dim postingperiod As String = row("POPER")
                Dim fiscalyear As String = row("RYEAR")
                Dim loaddate As String = row("LDDATE")
                Dim poststat As String = row("PSTATS")

                If poststat = True Then
                    MessageBox.Show($"{MonthName(postingperiod)} {fiscalyear} is already closed.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If loaddate Is Nothing OrElse loaddate.ToString.Trim() = "" Then
                    MessageBox.Show($"Please load data first", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

                Dim upparams As New Dictionary(Of String, Object) From {
                    {"@postdate", GetServerDate()},
                    {"@postby", "Administrator"},
                    {"@poststat", True},
                    {"@PostingPeriod", postingperiod},
                    {"@FiscalYear", fiscalyear}
                }
                ExecuteUpdate(UpdatePostDate, upparams)

                If GetValue($"select count(*) from FI_PSTNGPRD where POPER ={If(postingperiod = 12, 1, postingperiod + 1)} and RYEAR= {If(postingperiod = 12, fiscalyear + 1, fiscalyear)}") = 0 Then
                    Dim insparams As New Dictionary(Of String, Object) From {
                             {"@PostingPeriod", If(postingperiod = 12, 1, postingperiod + 1)},
                             {"@FiscalYear", If(postingperiod = 12, fiscalyear + 1, fiscalyear)}
                         }
                    ExecuteInsert(InsertNewPeriod, insparams)
                End If

                SplashScreenManager.CloseDefaultWaitForm()
            Next

            LoadData()
        End If
    End Sub

    Private Sub BtnOpenPeriod_Click(sender As Object, e As EventArgs) Handles BtnOpenPeriod.Click

        If String.IsNullOrWhiteSpace(TxtMonth.Text) Then
            MessageBox.Show("Please Select Period", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim result As DialogResult
        result = MessageBox.Show($"Do you want to open the {TxtMonth.Text} {TxtYear.Text} period?", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            Dim sql As String = $"select * from FI_PSTNGPRD where RYEAR={TxtYear.Text} and POPER={GetMonthNumber(TxtMonth.Text)}"
            Dim data As List(Of Dictionary(Of String, String)) = GetMultiValues(sql)

            For Each row As Dictionary(Of String, String) In data

                Dim postingperiod As String = row("POPER")
                Dim fiscalyear As String = row("RYEAR")
                Dim postingdate As String = row("PSTDATE")

                If postingdate Is Nothing OrElse postingdate.ToString.Trim() = "" Then
                    Exit Sub
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

                Dim upparams As New Dictionary(Of String, Object) From {
                    {"@postdate", DBNull.Value},
                    {"@postby", "Administrator"},
                    {"@poststat", False},
                    {"@PostingPeriod", postingperiod},
                    {"@FiscalYear", fiscalyear}
                }
                ExecuteUpdate(UpdatePostStatus, upparams)

                SplashScreenManager.CloseDefaultWaitForm()
            Next

            LoadData()

        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim monthValue As Object = GridView1.GetFocusedRowCellValue("PostingPeriod")
        Dim yearValue As Object = GridView1.GetFocusedRowCellValue("FiscalYear")

        TxtMonth.Text = If(monthValue IsNot Nothing, monthValue.ToString(), "")
        TxtYear.Text = If(yearValue IsNot Nothing, yearValue.ToString(), "")
    End Sub

    Private Sub LoadData()

        ' Save the current selected values before refreshing
        Dim lastYear As String = TxtYear.Text
        Dim lastMonth As String = TxtMonth.Text

        GridControl1.DataSource = PopulateDataSQL(ViewPostingPeriod)

        If GridView1.RowCount > 0 Then
            For i As Integer = 0 To GridView1.RowCount - 1
                Dim yearValue As Object = GridView1.GetRowCellValue(i, "FiscalYear")
                Dim monthValue As Object = GridView1.GetRowCellValue(i, "PostingPeriod")

                If yearValue IsNot Nothing AndAlso monthValue IsNot Nothing Then
                    If yearValue.ToString() = lastYear AndAlso monthValue.ToString() = lastMonth Then
                        GridView1.FocusedRowHandle = i
                        GridView1.MakeRowVisible(i)
                        Exit For
                    End If
                End If
            Next
        End If

        GridView1.BestFitColumns()
        GridView1.OptionsFind.AlwaysVisible = False
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsView.ShowAutoFilterRow = False


        BtnNewGL.Text = GetValue("SELECT COUNT(*) FROM FI_NEWGL") & " New GL"
    End Sub

    Private Sub LoadSapDataHeader()
        LoadDataHeader("FI_SKAT", $"Select 'LRP' as TRX_ORIGIN,{SelectSKAT}", "SAKNR", ResConnect)
        LoadDataHeader("FI_SKAT", $"Select 'L4P' as TRX_ORIGIN,{SelectSKAT}", "SAKNR", CasConnect)

        LoadDataHeader("FI_SKB1", $"Select 'LRP' as TRX_ORIGIN,{SelectSKB1}", "SAKNR", ResConnect)
        LoadDataHeader("FI_SKB1", $"Select 'L4P' as TRX_ORIGIN,{SelectSKB1}", "SAKNR", CasConnect)

        LoadDataHeader("FI_T004G", $"Select 'LRP' as TRX_ORIGIN,{SelecT004G}", "FSTAG", ResConnect)
        LoadDataHeader("FI_T004G", $"Select 'L4P' as TRX_ORIGIN,{SelecT004G}", "FSTAG", CasConnect)

        LoadDataHeader("FI_VLFA1", $"Select 'LRP' as TRX_ORIGIN,{SelecLFA1}", "LIFNR", ResConnect)
        LoadDataHeader("FI_VLFA1", $"Select 'L4P' as TRX_ORIGIN,{SelecLFA1}", "LIFNR", CasConnect)
    End Sub

    Public Sub LoadDataHeader(sqlTable As String, hanaQuery As String, keyColumn As String, str_hanaConnect As String)

        Using hanaConn As New HanaConnection(str_hanaConnect)
            hanaConn.Open()

            ' Step 1: Load data from HANA into DataTable
            Dim hanaCmd As New HanaCommand(hanaQuery, hanaConn)
            Dim hanaDt As New DataTable()
            Using reader As HanaDataReader = hanaCmd.ExecuteReader()
                hanaDt.Load(reader)
            End Using

            Using sqlConn As New SqlConnection(SqlConnect)
                sqlConn.Open()

                ' Step 2: Create temp table
                Dim tempTableName As String = $"#{sqlTable}_TEMP"

                ' Drop temp table if exists
                Using dropCmd As New SqlCommand($"IF OBJECT_ID('tempdb..{tempTableName}') IS NOT NULL DROP TABLE {tempTableName};", sqlConn)
                    dropCmd.ExecuteNonQuery()
                End Using

                ' Clone structure of target table
                Using cloneCmd As New SqlCommand($"SELECT TOP 0 * INTO {tempTableName} FROM [{sqlTable}];", sqlConn)
                    cloneCmd.ExecuteNonQuery()
                End Using

                ' Step 3: Bulk copy data from HANA to temp table
                Using bulkCopy As New SqlBulkCopy(sqlConn)
                    bulkCopy.DestinationTableName = tempTableName
                    bulkCopy.BulkCopyTimeout = 0
                    bulkCopy.BatchSize = 5000
                    bulkCopy.WriteToServer(hanaDt)
                End Using

                ' Step 3.5: Find new records not in SQL table
                Dim newRecords As New List(Of String)
                Using checkCmd As New SqlCommand($"SELECT s.[{keyColumn}] FROM {tempTableName} s LEFT JOIN [{sqlTable}] t ON s.[{keyColumn}] = t.[{keyColumn}] WHERE t.[{keyColumn}] IS NULL;", sqlConn)
                    Using reader As SqlDataReader = checkCmd.ExecuteReader()
                        While reader.Read()
                            newRecords.Add(reader(0).ToString())
                        End While
                    End Using
                End Using

                ' Step 4: Build MERGE SQL
                Dim mergeSql As New Text.StringBuilder()
                mergeSql.AppendLine($"MERGE [{sqlTable}] AS target")
                mergeSql.AppendLine($"USING {tempTableName} AS source")
                mergeSql.AppendLine($"ON target.[{keyColumn}] = source.[{keyColumn}]")

                ' --- INSERT new records ---
                mergeSql.AppendLine("WHEN NOT MATCHED BY TARGET THEN")
                mergeSql.AppendLine("    INSERT (")

                Dim sqlColumns As New List(Of String)
                Dim sqlValues As New List(Of String)

                For Each col As DataColumn In hanaDt.Columns
                    sqlColumns.Add($"[{col.ColumnName}]")
                    sqlValues.Add($"source.[{col.ColumnName}]")
                Next

                ' Add only CreatedDate
                sqlColumns.Add("[CreatedDate]")
                sqlValues.Add("GETDATE()")

                mergeSql.AppendLine(String.Join(",", sqlColumns))
                mergeSql.AppendLine("    ) VALUES (")
                mergeSql.AppendLine(String.Join(",", sqlValues))
                mergeSql.AppendLine("    )")

                ' --- UPDATE existing records ---
                mergeSql.AppendLine("WHEN MATCHED THEN")
                mergeSql.AppendLine("    UPDATE SET")

                Dim updateCols = hanaDt.Columns.Cast(Of DataColumn) _
                .Where(Function(c) c.ColumnName <> keyColumn) _
                .Select(Function(c) $"        target.[{c.ColumnName}] = source.[{c.ColumnName}]") _
                .ToList()

                updateCols.Add("        target.[UpdateDate] = GETDATE()")
                mergeSql.AppendLine(String.Join("," & vbCrLf, updateCols))
                mergeSql.AppendLine(";")

                ' Step 5: Execute MERGE
                Using mergeCmd As New SqlCommand(mergeSql.ToString(), sqlConn)
                    mergeCmd.CommandTimeout = 0
                    Dim affectedRows As Integer = mergeCmd.ExecuteNonQuery()


                    If sqlTable = "FI_SKAT" Then 'This wil Apply on SKAT Tbale only

                        ' --- Insert new GLs to FI_NEWGL table ---
                        If newRecords.Count > 0 Then
                            Dim insertedCount As Integer = 0

                            For Each gl As String In newRecords
                                ' Check if GL exists in FI_GLGRP
                                If (GetValue($"SELECT COUNT(*) FROM FI_GLGRP WHERE SAKNR = '{gl}'")) = 0 Then
                                    Using insertCmd As New SqlCommand("INSERT INTO FI_NEWGL (SAKNR) VALUES (@GL)", sqlConn)
                                        insertCmd.Parameters.AddWithValue("@GL", gl)
                                        Dim rows = insertCmd.ExecuteNonQuery()

                                        If rows > 0 Then
                                            insertedCount += 1
                                        End If
                                    End Using
                                End If
                            Next
                            If insertedCount > 0 Then
                                LblMessage.Text = $"{insertedCount} new GL record(s) inserted successfully."
                            Else
                                LblMessage.Text = "No new GL records were inserted."
                            End If
                        End If


                    End If

                End Using
            End Using
        End Using
    End Sub

    Sub LoadDataDetails(trxOrgn As String, str_hanaConnect As String, fiscalyear As Integer, postingperiod As Integer)

        Using hanaConn As New HanaConnection(str_hanaConnect)
            hanaConn.Open()

            Dim hanaQuery As String = $"SELECT '' as TRX_ROW,'{trxOrgn}' as TRX_ORIGIN,
                                        DOCNR,BELNR,DOCLN,RLDNR,TO_VARCHAR(TO_DATE(BUDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS BUDAT,RYEAR,        
                                        TRIM(LEADING '0' FROM POPER) AS POPER,RBUKRS,KOKRS,       
                                        TRIM(LEADING '0' FROM RACCT) AS RACCT,PRCTR,HSL,TSL,RTCUR,WSL,RWCUR,KSL,OSL,MSL,   
                                        DRCRK,BSCHL,GJAHR,ACTIV,AWTYP,RVERS,SEGMENT,BUZEI,LINETYPE,XSPLITMOD,RRCTY,RMVCT,RUNIT, 
 	                                    CASE 
	                                    WHEN COST_ELEM ='' THEN '0'
	                                    ELSE
	                                    TRIM(LEADING '0' FROM COST_ELEM) 	
	                                    END AS COST_ELEM, 
                                        RCNTR,SCNTR,PPRCTR,PSEGMENT,BSTAT        
                                        FROM SAPHANADB.FGLV_FAGLFLEXA
                                        WHERE RYEAR={fiscalyear} AND POPER={postingperiod} AND RCLNT = '800'AND RBUKRS='2000' and RLDNR='0L'"

            Dim hanaCmd As New HanaCommand(hanaQuery, hanaConn)

            Using reader As HanaDataReader = hanaCmd.ExecuteReader()
                Using sqlConn As New SqlConnection(SqlConnect)
                    sqlConn.Open()

                    ' Bulk copy to SQL Server table
                    Using bulkCopy As New SqlBulkCopy(sqlConn)
                        bulkCopy.DestinationTableName = "dbo.FI_TRXDETAILS"
                        bulkCopy.BulkCopyTimeout = 0

                        bulkCopy.WriteToServer(reader)
                    End Using
                End Using
            End Using
        End Using

    End Sub

    Sub LoadDataSAPSQL(sql_tableName As String, str_hanaConnect As String, str_hanQuery As String)

        Using hanaConn As New HanaConnection(str_hanaConnect)
            hanaConn.Open()

            Dim hanaCmd As New HanaCommand(str_hanQuery, hanaConn)

            Using reader As HanaDataReader = hanaCmd.ExecuteReader()
                Using sqlConn As New SqlConnection(SqlConnect)
                    sqlConn.Open()

                    ' Bulk copy to SQL Server table
                    Using bulkCopy As New SqlBulkCopy(sqlConn)
                        bulkCopy.DestinationTableName = $"dbo.{sql_tableName}"
                        bulkCopy.BulkCopyTimeout = 0

                        bulkCopy.WriteToServer(reader)
                    End Using
                End Using
            End Using
        End Using

    End Sub







    Private Sub BtnNewGL_Click(sender As Object, e As EventArgs) Handles BtnNewGL.Click
        FrmViewGL.ShowDialog()
    End Sub
End Class
