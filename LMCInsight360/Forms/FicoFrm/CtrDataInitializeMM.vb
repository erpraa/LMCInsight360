Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports LMCInsight360.ClassFunction
Imports LMCInsight360.SubClass
Public Class CtrDataInitializeMM

    Private dt As New DataTable()

    Private Sub CtrDataInitializeMM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()

        LoadComboBox(CbxPrfitCtr, "select distinct PRCTR from FI_BRANCH", "PRCTR")
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click

        Dim excelPath As String = TxtFilePath.Text

        If excelPath = "" Then
            MsgBox("Please select an Excel file.")
            Exit Sub
        End If

        '=== 1. Read Excel File ===
        dt = New DataTable()
        Dim excelConnStr As String =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath &
            ";Extended Properties='Excel 12.0;HDR=YES;'"

        Using excelConn As New OleDbConnection(excelConnStr)
            excelConn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM [Sheet1$]", excelConn)
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
        End Using

        '=== 2. DISPLAY DATA IN GRID ===
        GridControl1.DataSource = dt

        Using sqlConn As New SqlConnection(SqlConnect)
            sqlConn.Open()

            For Each row As DataRow In dt.Rows

                '==================================================
                ' CHECK IF RECORD ALREADY EXISTS
                '==================================================
                Dim checkQuery As String =
                    "SELECT COUNT(*) FROM FI_PURCHIST 
                     WHERE TRX_ORIGIN = @TRX_ORIGIN
                     AND PRCTR = @PRCTR
                     AND POPER = @POPER
                     AND RYEAR = @RYEAR"

                Dim exists As Integer = 0

                Using checkCmd As New SqlCommand(checkQuery, sqlConn)
                    checkCmd.Parameters.AddWithValue("@TRX_ORIGIN", row("TRX_ORIGIN").ToString())
                    checkCmd.Parameters.AddWithValue("@PRCTR", row("PRCTR").ToString())
                    checkCmd.Parameters.AddWithValue("@POPER", Convert.ToInt32(row("POPER")))
                    checkCmd.Parameters.AddWithValue("@RYEAR", Convert.ToInt32(row("RYEAR")))

                    exists = Convert.ToInt32(checkCmd.ExecuteScalar())
                End Using

                ' SKIP EXISTING DATA
                If exists > 0 Then
                    Continue For
                End If

                '==================================================
                ' INSERT NEW ROW
                '==================================================
                Dim insertQuery As String =
                    "INSERT INTO FI_PURCHIST (TRX_ORIGIN, PRCTR, HSL, POPER, RYEAR)
                     VALUES (@TRX_ORIGIN, @PRCTR, @HSL, @POPER, @RYEAR)"

                Using cmd As New SqlCommand(insertQuery, sqlConn)
                    cmd.Parameters.AddWithValue("@TRX_ORIGIN", row("TRX_ORIGIN").ToString())
                    cmd.Parameters.AddWithValue("@PRCTR", row("PRCTR").ToString())
                    cmd.Parameters.AddWithValue("@HSL", Convert.ToDecimal(row("HSL")))
                    cmd.Parameters.AddWithValue("@POPER", Convert.ToInt32(row("POPER")))
                    cmd.Parameters.AddWithValue("@RYEAR", Convert.ToInt32(row("RYEAR")))
                    cmd.ExecuteNonQuery()
                End Using

            Next

        End Using

        MsgBox("Upload completed! Existing records were skipped.")

    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Dim ofd As New OpenFileDialog() With {
            .Filter = "Excel Files|*.xlsx;*.xls"
        }

        If ofd.ShowDialog = DialogResult.OK Then
            TxtFilePath.Text = ofd.FileName
        End If
    End Sub
    Private Sub GridView1_RowClick(
        sender As Object,
        e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs
    ) Handles GridView1.RowClick

        If e.RowHandle < 0 Then Exit Sub

        CbxOrigin.Text = GridView1.GetRowCellValue(e.RowHandle, "SAP Source").ToString()
        CbxPrfitCtr.Text = GridView1.GetRowCellValue(e.RowHandle, "Profit Center").ToString()
        TxtAmt.Text = GridView1.GetRowCellValue(e.RowHandle, "Amount").ToString()
        CbxMonth.Text = GridView1.GetRowCellValue(e.RowHandle, "Month").ToString()
        TxtYear.Text = GridView1.GetRowCellValue(e.RowHandle, "Year").ToString()
    End Sub

    Private Sub LoadData()

        GridControl1.DataSource = PopulateDataSQL("SELECT
    CASE 
        WHEN TRX_ORIGIN = 'L4P' THEN 'CAS'
        WHEN TRX_ORIGIN = 'LRP' THEN 'Reserved'
    END AS [SAP Source],
    PRCTR AS [Profit Center],
    DATENAME(MONTH, DATEFROMPARTS(RYEAR, POPER, 1)) AS [Month],
    RYEAR AS [Year],
    FORMAT(HSL, 'N2') AS [Amount],
    CreatedDate,
    CreatedBy,
    UpdateDate,
    UpdateBy
    FROM FI_PURCHIST ORDER BY RYEAR,POPER,PRCTR,TRX_ORIGIN;")

        GridView1.BestFitColumns()
        GridView1.OptionsFind.AlwaysVisible = False
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsView.ShowAutoFilterRow = True

    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If String.IsNullOrWhiteSpace(CbxOrigin.Text) OrElse
      String.IsNullOrWhiteSpace(CbxPrfitCtr.Text) OrElse
      String.IsNullOrWhiteSpace(CbxMonth.Text) OrElse
      String.IsNullOrWhiteSpace(TxtYear.Text) OrElse
      String.IsNullOrWhiteSpace(TxtAmt.Text) Then

            MessageBox.Show("Please enter all required fields.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ChkDataExist As String = GetValue($"select count(*) from FI_PURCHIST 
                                                where TRX_ORIGIN='{If(Convert.ToString(CbxOrigin.EditValue) = "CAS", "L4P", "LRP")}' 
                                                and PRCTR='{CbxPrfitCtr.EditValue}' 
                                                and POPER={GetMonthNumber(CbxMonth.EditValue)}
                                                and RYEAR={TxtYear.EditValue}")
        Try

            Dim params As New Dictionary(Of String, Object) From {
                              {"@TRX_ORIGIN", If(Convert.ToString(CbxOrigin.EditValue) = "CAS", "L4P", "LRP")},
                              {"@PRCTR", CbxPrfitCtr.EditValue},
                              {"@POPER", GetMonthNumber(CbxMonth.EditValue)},
                              {"@RYEAR", TxtYear.EditValue},
                              {"@HSL", TxtAmt.EditValue},
                              {"@CreatedDate", GetServerDate()},
                              {"@CreatedBy", GstrUselogin},
                              {"@UpdateDate", GetServerDate()},
                              {"@UpdateBy", GstrUselogin}
                }

            If ChkDataExist = 0 Then
                Dim Insqry As String = "INSERT INTO FI_PURCHIST (TRX_ORIGIN,PRCTR,POPER,RYEAR,HSL,CreatedDate,CreatedBy) VALUES (@TRX_ORIGIN,@PRCTR,@POPER,@RYEAR,@HSL,@CreatedDate,@CreatedBy);"
                ExecuteInsert(Insqry, params)
                MessageBox.Show("Successfully saved!")
            Else

                Dim Amt As String = GetValue($"select FORMAT(HSL, 'N2') from FI_PURCHIST 
                                                where TRX_ORIGIN='{If(Convert.ToString(CbxOrigin.EditValue) = "CAS", "L4P", "LRP")}' 
                                                and PRCTR='{CbxPrfitCtr.EditValue}' 
                                                and POPER={GetMonthNumber(CbxMonth.EditValue)}
                                                and RYEAR={TxtYear.EditValue}")


                Dim result As DialogResult = MessageBox.Show("Data already exist. Do you want to override the Amount: " & Amt, SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.No Then
                    Exit Sub
                End If

                Dim Updqry As String = "UPDATE FI_PURCHIST SET HSL = @HSL, UpdateDate = @UpdateDate,UpdateBy = @UpdateBy
                                         WHERE TRX_ORIGIN = @TRX_ORIGIN 
                                         AND PRCTR= @PRCTR
                                         AND POPER = @POPER
                                         AND RYEAR = @RYEAR;"
                ExecuteUpdate(Updqry, params)

                MessageBox.Show("Successfully saved!")
            End If

            LoadData()

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation)

        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If String.IsNullOrWhiteSpace(CbxOrigin.Text) OrElse
String.IsNullOrWhiteSpace(CbxPrfitCtr.Text) OrElse
String.IsNullOrWhiteSpace(CbxMonth.Text) OrElse
String.IsNullOrWhiteSpace(TxtYear.Text) OrElse
String.IsNullOrWhiteSpace(TxtAmt.Text) Then

            MessageBox.Show("Please enter all required fields.", SystemTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this data?", SystemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Exit Sub
        End If

        Dim params As New Dictionary(Of String, Object) From {
                  {"@TRX_ORIGIN", If(Convert.ToString(CbxOrigin.EditValue) = "CAS", "L4P", "LRP")},
                  {"@PRCTR", CbxPrfitCtr.EditValue},
                  {"@POPER", GetMonthNumber(CbxMonth.EditValue)},
                  {"@RYEAR", TxtYear.EditValue},
                  {"@HSL", TxtAmt.EditValue}
    }

        Dim Delqry As String = "DELETE FROM FI_PURCHIST WHERE TRX_ORIGIN = @TRX_ORIGIN 
                                         AND PRCTR= @PRCTR
                                         AND POPER = @POPER
                                         AND RYEAR = @RYEAR;"
        ExecuteDelete(Delqry, params)
        MessageBox.Show("Successfully Deleted!")

        CbxOrigin.Text = ""
        CbxPrfitCtr.Text = ""
        CbxMonth.Text = ""
        TxtYear.Text = ""
        TxtAmt.Text = ""

        LoadData()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        CbxOrigin.Text = ""
        CbxPrfitCtr.Text = ""
        CbxMonth.Text = ""
        TxtYear.Text = ""
        TxtAmt.Text = ""
    End Sub
End Class
