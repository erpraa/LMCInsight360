Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class CtrDataInitializeMM

    Private dt As New DataTable()

    Private Sub CtrDataInitializeMM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

End Class
