
Imports DevExpress.XtraBars.Docking2010.Views
Imports System.Data.SqlClient
Imports LMCInsight360.SubQuery
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


#Region "General Function"

    Public Shared Function GetMultiValues(ByVal strSql As String) As List(Of Dictionary(Of String, String))
        Dim result As New List(Of Dictionary(Of String, String))

        Try
            Using cn As New SqlConnection(SqlConnect)
                cn.Open()
                Using cmd As New SqlCommand(strSql, cn)
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

                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return result
    End Function


    Public Shared Function GetValue(FiscalYear As String, PostingPeriod As String, Optional TrxOrigin As String = Nothing, Optional busUnit As String = Nothing, Optional FSItem As String = Nothing, Optional PurcH As Boolean = False, Optional businessType As String = Nothing)

        Dim rtnAmt As String = Nothing

        Using strConn As New SqlConnection(SqlConnect)
            strConn.Open()

            Using command As New SqlCommand(RptQuery(FiscalYear, PostingPeriod, TrxOrigin, busUnit, FSItem, PurcH, businessType), strConn)
                Using reader = command.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read()
                            If reader.IsDBNull(0) Or reader(0).ToString = "" Then
                                rtnAmt = "0.00"
                            Else
                                rtnAmt = reader(0).ToString
                            End If
                        End While
                    End If
                End Using
            End Using
        End Using

        Return rtnAmt
    End Function

    Public Shared Function GetValueBS(FiscalYear As String, PostingPeriod As String, Optional TrxOrigin As String = Nothing, Optional FSItem As String = Nothing, Optional businessType As String = Nothing)

        Dim rtnAmt As String = Nothing

        Using strConn As New SqlConnection(SqlConnect)
            strConn.Open()

            Using command As New SqlCommand(RptQueryBS(FiscalYear, PostingPeriod, TrxOrigin, FSItem, businessType), strConn)
                Using reader = command.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read()
                            If reader.IsDBNull(0) Or reader(0).ToString = "" Then
                                rtnAmt = "0.00"
                            Else
                                rtnAmt = reader(0).ToString
                            End If
                        End While
                    End If
                End Using
            End Using
        End Using

        Return rtnAmt
    End Function


#Region "Report Function"

    Public Shared Function GetMonthNumber(monthName As String) As Integer
        Try
            Return DateTime.ParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture).Month
        Catch ex As Exception
            Return 0
        End Try
    End Function

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


    Public Shared Function MonthNameToNum(monthName As String) As Integer
        Try
            ' Parse month name using DateTime
            Dim monthDate As DateTime = DateTime.ParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture)
            Return monthDate.Month
        Catch ex As Exception
            ' If invalid month name, return 0
            Return 0
        End Try
    End Function
#End Region



#End Region







End Class
