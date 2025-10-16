Imports Sap.Data.Hana
Imports System.Data.SqlClient

Imports LMCInsight360.ClassFunction
Imports DevExpress.XtraSplashScreen
Public Class CtrDataInitializeFI

    Private Sub CtrDataInitializeFI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl2.DataSource = PopulateDataSQL("select TRX_ORIGIN,SAKNR,TXT20,TXT50,CreatedDate from  FI_SKAT where SAKNR IN (select * from FI_NEWGL) ")
        GridView2.BestFitColumns()
        GridView2.OptionsFind.AlwaysVisible = True
        GridView2.OptionsBehavior.Editable = True
        GridView2.OptionsView.ShowAutoFilterRow = True
    End Sub

    Private Sub BtnOpenPeriod_Click(sender As Object, e As EventArgs) Handles BtnOpenPeriod.Click

    End Sub

    Private Sub BtnLoadData_Click(sender As Object, e As EventArgs) Handles BtnLoadData.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitFrm), True, True, False)

        LoadHeader()

        SplashScreenManager.CloseDefaultWaitForm()
    End Sub

    Private Sub LoadHeader()
        LoadDataHeader("FI_SKAT", "Select 'LRP' as TRX_ORIGIN,Trim(LEADING '0' FROM SAKNR) AS SAKNR,KTOPL,SPRAS,TXT20,TXT50,MCOD1 From SAPHANADB.SKAT Where MANDT = '800' And KTOPL = '1000' AND SPRAS='E'", "SAKNR", ResConnect)
        LoadDataHeader("FI_SKAT", "Select 'L4P' as TRX_ORIGIN,Trim(LEADING '0' FROM SAKNR) AS SAKNR,KTOPL,SPRAS,TXT20,TXT50,MCOD1 From SAPHANADB.SKAT Where MANDT = '800' And KTOPL = '1000' AND SPRAS='E'", "SAKNR", CasConnect)

        LoadDataHeader("FI_SKB1", "Select 'LRP' as TRX_ORIGIN,Trim(LEADING '0' FROM SAKNR) AS SAKNR,BUKRS,TO_VARCHAR(TO_DATE(ERDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS ERDAT,ERNAM,FDLEV,FIPLS,FSTAG,HBKID,HKTID,MITKZ,MWSKZ,WAERS,XGKON,XINTB,XKRES,XOPVW,XSPEB,ZINRT,ZUAWA,XMWNO,XSALH From SAPHANADB.SKB1 Where MANDT = '800' And BUKRS = '2000'ORDER BY SAKNR;", "SAKNR", ResConnect)
        LoadDataHeader("FI_SKB1", "Select 'L4P' as TRX_ORIGIN,Trim(LEADING '0' FROM SAKNR) AS SAKNR,BUKRS,TO_VARCHAR(TO_DATE(ERDAT, 'YYYYMMDD'), 'YYYY-MM-DD') AS ERDAT,ERNAM,FDLEV,FIPLS,FSTAG,HBKID,HKTID,MITKZ,MWSKZ,WAERS,XGKON,XINTB,XKRES,XOPVW,XSPEB,ZINRT,ZUAWA,XMWNO,XSALH From SAPHANADB.SKB1 Where MANDT = '800' And BUKRS = '2000'ORDER BY SAKNR;", "SAKNR", CasConnect)

        LoadDataHeader("FI_T004G", "Select 'LRP' as TRX_ORIGIN,FSTAG,SPRAS,BUKRS,FSTTX From SAPHANADB.T004G  Where MANDT = '800' And BUKRS = '1000' AND SPRAS='E'", "FSTAG", ResConnect)
        LoadDataHeader("FI_T004G", "Select 'L4P' as TRX_ORIGIN,FSTAG,SPRAS,BUKRS,FSTTX From SAPHANADB.T004G  Where MANDT = '800' And BUKRS = '1000' AND SPRAS='E'", "FSTAG", CasConnect)
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
                            For Each gl As String In newRecords
                                If (GetQuery($"select count(*) from FI_GLGRP where SAKNR='{gl}'")) = 0 Then
                                    Using insertCmd As New SqlCommand($"INSERT INTO FI_NEWGL (SAKNR) VALUES (@GL)", sqlConn)
                                        insertCmd.Parameters.AddWithValue("@GL", gl)
                                        insertCmd.ExecuteNonQuery()
                                    End Using
                                End If
                            Next
                        End If

                    End If

                End Using
            End Using
        End Using
    End Sub



End Class
