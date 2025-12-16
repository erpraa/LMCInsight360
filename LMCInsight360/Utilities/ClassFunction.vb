
Imports DevExpress.XtraBars.Docking2010.Views
Imports System.Data.SqlClient
Public Class ClassFunction
#Region "FrmMain"
    Public Shared Function CheckifTabExists(tabtext As String) As Boolean
        Dim visibleDocs As New List(Of String)()
        For Each doc As BaseDocument In FrmMain.TabbedView1.Documents
            visibleDocs.Add(doc.Caption.ToString)
        Next doc

        If visibleDocs.Contains(tabtext) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Get Function"
    Public Shared Function GetServerDate() As DateTime
        Dim serverDate As DateTime

        Using conn As New SqlConnection(SqlConnect)
            conn.Open()
            Using cmd As New SqlCommand("SELECT GETDATE()", conn)
                serverDate = Convert.ToDateTime(cmd.ExecuteScalar())
            End Using
        End Using

        Return serverDate
    End Function

    Public Shared Sub UpdateLoginStatus(userID As String, isLoggedIn As Boolean)
        Dim query As String = "UPDATE MSTR_USERS SET IsLoggedIn = @IsLoggedIn WHERE UserID = @UserID"

        Using conn As New SqlConnection(SqlConnect)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", userID)
                cmd.Parameters.AddWithValue("@IsLoggedIn", isLoggedIn)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function GetMultiValues(ByVal query As String) As List(Of Dictionary(Of String, String))
        Dim result As New List(Of Dictionary(Of String, String))

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim row As New Dictionary(Of String, String)
                            For i As Integer = 0 To dr.FieldCount - 1
                                row(dr.GetName(i)) = dr(i).ToString()
                            Next
                            result.Add(row)
                        End While
                    End Using
                End Using

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return result
    End Function

    Public Shared Function GetValue(ByVal query As String) As String
        Dim result As String = Nothing

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()

                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            result = If(Not reader.IsDBNull(0), reader.GetValue(0).ToString(), String.Empty)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"An error occurred: {ex.Message}")
        End Try

        Return result
    End Function

    Public Shared Function GetAmount(ByVal query As String) As String
        Dim result As String = "0.00"

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()

                Using cmd As New SqlCommand(query, conn)
                    Dim obj = cmd.ExecuteScalar()

                    If obj IsNot Nothing AndAlso Not Convert.IsDBNull(obj) Then
                        Dim value = obj.ToString().Trim()
                        If value <> "" Then result = value
                    End If
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"An error occurred: {ex.Message}")
        End Try

        Return result
    End Function

    Public Shared Function PopulateDataSQL(query As String) As DataView
        Dim dvcv As New DataView
        Dim adapterCv As New SqlDataAdapter
        Dim dsConn As New DataSet

        Using conn As New SqlConnection(SqlConnect)
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.CommandTimeout = 0
                Try
                    With adapterCv
                        .SelectCommand = cmd
                        .Fill(dsConn)
                        .Dispose()
                    End With

                    dvcv = dsConn.Tables(0).DefaultView

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

        End Using

        Return dvcv
    End Function



    Public Shared Function GetCurrencyFormat(currency As String) As String
        Select Case currency.ToUpper()

            Case "PHP"
                Return "_-[$PHP ]* #,##0.00_-;_-[$PHP ]* (#,##0.00)_-;_-[$PHP ]* 0.00_-;_-@_-"

            Case "EUR"
                Return "_-[$EUR ]* #,##0.00_-;_-[$EUR ]* (#,##0.00)_-;_-[$EUR ]* 0.00_-;_-@_-"

            Case "USD"
                Return "_-[$USD ]* #,##0.00_-;_-[$USD ]* (#,##0.00)_-;_-[$USD ]* 0.00_-;_-@_-"

            Case "JPY"
                Return "_-[$JPY ]* #,##0.00_-;_-[$JPY ]* (#,##0.00)_-;_-[$JPY ]* 0.00_-;_-@_-"

            Case "SGD"
                Return "_-[$SGD ]* #,##0.00_-;_-[$SGD ]* (#,##0.00)_-;_-[$SGD ]* 0.00_-;_-@_-"

            Case "CNY"
                Return "_-[$CNY ]* #,##0.00_-;_-[$CNY ]* (#,##0.00)_-;_-[$CNY ]* 0.00_-;_-@_-"

            Case "KRW"
                Return "_-[$KRW ]* #,##0_-;_-[$KRW ]* (#,##0)_-;_-[$KRW ]* 0_-;_-@_-"

            Case "HKD"
                Return "_-[$HKD ]* #,##0.00_-;_-[$HKD ]* (#,##0.00)_-;_-[$HKD ]* 0.00_-;_-@_-"

            Case Else
                Return "#,##0.00;(#,##0.00)"
        End Select

    End Function


#End Region

#Region "Submit Function"

    ' INSERT FUNCTION (Return new ID)
    Public Shared Function ExecuteInsert(ByVal query As String, Optional ByVal parameters As Dictionary(Of String, Object) = Nothing) As String

        Dim newID As String = ""

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0

                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        newID = result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error (Insert): " & ex.Message)
        End Try

        Return newID
    End Function


    ' UPDATE FUNCTION (Return affected rows)
    Public Shared Function ExecuteUpdate(ByVal query As String, Optional ByVal parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Dim rowsAffected As Integer = 0

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0

                    ' Add parameters safely
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If

                    rowsAffected = cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Error (Update): " & ex.Message)
        End Try

        Return rowsAffected
    End Function

    ' DELETE FUNCTION (Return affected rows)
    Public Shared Function ExecuteDelete(ByVal query As String, Optional ByVal parameters As Dictionary(Of String, Object) = Nothing) As Integer

        Dim rowsAffected As Integer = 0

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()

                Using cmd As New SqlCommand(query, conn)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0

                    ' Add parameters only if provided
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If

                    rowsAffected = cmd.ExecuteNonQuery()
                End Using

            End Using

        Catch ex As Exception
            Console.WriteLine("Error (Delete): " & ex.Message)
        End Try

        Return rowsAffected
    End Function


    Public Shared Function ExecuteProcedure(ByVal procedureName As String, Optional ByVal parameters As Dictionary(Of String, Object) = Nothing, Optional ByVal expectResult As Boolean = False) As Object
        Dim result As Object = Nothing

        Try
            Using conn As New SqlConnection(SqlConnect)
                conn.Open()

                Using cmd As New SqlCommand(procedureName, conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    ' Add parameters dynamically (if any)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            cmd.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If

                    '  Choose mode depending on whether results are expected
                    If expectResult Then
                        Using da As New SqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            da.Fill(dt)
                            result = dt  ' Return DataTable for SELECT results
                        End Using
                    Else
                        result = cmd.ExecuteNonQuery()  ' Return affected rows for insert/update/delete
                    End If
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Error executing procedure [{procedureName}]: " & ex.Message)
        End Try

        Return result
    End Function

#End Region

#Region "Report Function"

    Public Shared Function AdjustValue(baseValue As Double, dcflgObj As Object) As Double
        Dim dcflg As String = ""

        ' Handle DBNull or Nothing safely
        If dcflgObj IsNot Nothing AndAlso Not IsDBNull(dcflgObj) Then
            dcflg = dcflgObj.ToString().Trim()
        End If

        Select Case dcflg
            Case "P"
                Return Math.Abs(baseValue)  ' Always positive
            Case "N"
                Return -Math.Abs(baseValue) ' Always negative
            Case "M"
                Return (baseValue * -1) 'Switch Signs
            Case ""  ' blank
                Return baseValue            ' Leave as-is
            Case Else
                Return baseValue            ' Default
        End Select
    End Function

    Public Shared Function GetExcelFormula(rawFormulaObj As Object, col As Integer) As String

        Dim rawFormula As String = rawFormulaObj.ToString().Trim()
        ' Replace numbers with Excel column + row (e.g., "17" -> "B17")
        Dim excelFormula As String = "=" & System.Text.RegularExpressions.Regex.Replace(rawFormula, "(\d+)", GetExcelColName(col) & "$1")

        Return excelFormula

    End Function

    Public Shared Function GetExcelColName(ByVal colNumber As Integer) As String
        Dim dividend As Integer = colNumber
        Dim colName As String = ""
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            colName = Chr(65 + modulo) & colName
            dividend = (dividend - modulo) \ 26
        End While

        Return colName
    End Function

    Public Shared Function NumberToWords(ByVal number As Integer) As String
        Select Case number
            Case 1 : Return "One"
            Case 2 : Return "Two"
            Case 3 : Return "Three"
            Case 4 : Return "Four"
            Case 5 : Return "Five"
            Case 6 : Return "Six"
            Case 7 : Return "Seven"
            Case 8 : Return "Eight"
            Case 9 : Return "Nine"
            Case 10 : Return "Ten"
            Case 11 : Return "Eleven"
            Case 12 : Return "Twelve"
            Case Else : Return number.ToString()
        End Select
    End Function

    Public Shared Function GetMonthNumber(monthName As String) As Integer
        Try
            Return DateTime.ParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture).Month
        Catch ex As Exception
            Return 0
        End Try
    End Function

#End Region




End Class
