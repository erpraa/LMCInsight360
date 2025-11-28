Imports DevExpress.XtraBars.Docking2010.Views.Tabbed
Imports DevExpress.XtraBars.Docking2010.Views
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports LMCInsight360.ClassFunction

Imports Excel = Microsoft.Office.Interop.Excel
Public Class SubClass

#Region "FrmMain"
    Public Shared Sub TabviewButton(TabControl As UserControl, TabName As String)
        ' Create a new Document for the DocumentManager
        Dim doc As BaseDocument = FrmMain.DocumentManager1.View.AddDocument(TabControl)

        ' Set the document caption (tab name)
        doc.Caption = TabName

        ' Disable close button only for specific tab
        If TabName = "Home" Then
            Dim tdoc = TryCast(doc, DevExpress.XtraBars.Docking2010.Views.Tabbed.Document)
            If tdoc IsNot Nothing Then
                tdoc.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False
            End If
        End If

        ' Activate the newly added document
        FrmMain.DocumentManager1.View.ActivateDocument(TabControl)
    End Sub

    Public Shared Sub TabMenu(frm As FrmMain, CtrTabName As UserControl, TabName As String)

        If CheckifTabExists(TabName) Then
            TabviewButton(CtrTabName, TabName)
        Else
            For Each doc As Document In frm.TabbedView1.Documents
                If doc.Caption.ToString = TabName Then
                    frm.TabbedView1.Controller.Activate(doc)
                    Exit For
                End If
            Next doc
        End If

    End Sub

    Public Shared Sub CloseALLTab()
        ' Close ALL active documents
        For Each doc As BaseDocument In FrmMain.DocumentManager1.View.Documents.ToArray()
            FrmMain.DocumentManager1.View.Controller.Close(doc)
            doc.Dispose()
        Next

    End Sub

#End Region

#Region "General Sub"
    Public Shared Sub LoadComboBox(combo As ComboBoxEdit, sqlQuery As String, columnName As String)
        Dim dt As New DataTable()

        Try
            Using conn As New SqlConnection(SqlConnect)
                Using cmd As New SqlCommand(sqlQuery, conn)
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using

            ' 🔹 Clear old items and add new ones
            combo.Properties.Items.Clear()
            For Each row As DataRow In dt.Rows
                combo.Properties.Items.Add(row(columnName).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading ComboBox: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Reports Design"

    Public Shared Sub SetSquareBorder(ws As Excel.Worksheet, row As Integer, col As Integer, weight As Excel.XlBorderWeight)
        Dim cell As Excel.Range = ws.Cells(row, col)

        With cell.Borders
            .Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Item(Excel.XlBordersIndex.xlEdgeTop).Weight = weight

            .Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Item(Excel.XlBordersIndex.xlEdgeBottom).Weight = weight

            .Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Item(Excel.XlBordersIndex.xlEdgeLeft).Weight = weight

            .Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            .Item(Excel.XlBordersIndex.xlEdgeRight).Weight = weight

        End With

        ' Formatting (must be applied on the cell, not on Borders)
        cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        cell.Font.Bold = True
    End Sub

    Public Enum LinePosition
        Top
        Bottom
        Left
        Right
    End Enum

    Public Shared Sub SetBorderStyle(ByVal ws As Excel.Worksheet,
                                 row As Integer,
                                 col As Integer,
                                 lineType As String,
                                 position As Object,
                                 Optional ByVal lineWeight As Excel.XlBorderWeight = Excel.XlBorderWeight.xlThin,
                                 Optional ByVal lineColor As Integer = 0)

        Dim rng As Excel.Range = ws.Cells(row, col)

        '-------------------------------------------
        ' 1. Convert position (string or enum) → enum
        '-------------------------------------------
        Dim posEnum As LinePosition

        If TypeOf position Is String Then
            Dim posStr As String = position.ToString().Trim().ToUpper()

            If posStr = "" Then
                Exit Sub
            End If

            Select Case posStr
                Case "T" : posEnum = LinePosition.Top
                Case "B" : posEnum = LinePosition.Bottom
                Case "L" : posEnum = LinePosition.Left
                Case "R" : posEnum = LinePosition.Right
                Case Else
                    Throw New Exception("Invalid position: " & position)
            End Select
        Else
            posEnum = CType(position, LinePosition)
        End If

        '-------------------------------------------
        ' 2. Determine line style (S = Single, D = Double, else remove)
        '-------------------------------------------
        Dim style As Excel.XlLineStyle


        Select Case lineType.Trim().ToUpper()
            Case "S"
                style = Excel.XlLineStyle.xlContinuous
            Case "D"
                style = Excel.XlLineStyle.xlDouble
                lineWeight = Excel.XlBorderWeight.xlThick
            Case Else
                ' Remove border
                Dim idxNone As Excel.XlBordersIndex

                Select Case posEnum
                    Case LinePosition.Top : idxNone = Excel.XlBordersIndex.xlEdgeTop
                    Case LinePosition.Bottom : idxNone = Excel.XlBordersIndex.xlEdgeBottom
                    Case LinePosition.Left : idxNone = Excel.XlBordersIndex.xlEdgeLeft
                    Case LinePosition.Right : idxNone = Excel.XlBordersIndex.xlEdgeRight
                End Select

                rng.Borders(idxNone).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                Return
        End Select

        '-------------------------------------------
        ' 3. Apply border
        '-------------------------------------------
        Dim idx As Excel.XlBordersIndex

        Select Case posEnum
            Case LinePosition.Top : idx = Excel.XlBordersIndex.xlEdgeTop
            Case LinePosition.Bottom : idx = Excel.XlBordersIndex.xlEdgeBottom
            Case LinePosition.Left : idx = Excel.XlBordersIndex.xlEdgeLeft
            Case LinePosition.Right : idx = Excel.XlBordersIndex.xlEdgeRight
        End Select

        With rng.Borders(idx)
            .LineStyle = style
            .Color = lineColor
            .Weight = lineWeight
        End With

    End Sub


    Public Shared Sub SetBackFontColor(ws As Excel.Worksheet, row As Integer, col As Integer, fntclr As String, bckclr As String)
        Dim cell As Excel.Range = ws.Cells(row, col)

        ' --- Font Color ---
        If Not String.IsNullOrWhiteSpace(fntclr) Then
            Dim cleanFont = fntclr.Replace("RGB(", "").Replace(")", "")
            Dim parts = cleanFont.Split(","c)

            If parts.Length = 3 Then
                Dim r, g, b As Integer
                If Integer.TryParse(parts(0).Trim(), r) AndAlso
               Integer.TryParse(parts(1).Trim(), g) AndAlso
               Integer.TryParse(parts(2).Trim(), b) Then

                    cell.Font.Color = RGB(r, g, b)
                End If
            End If
        End If

        ' --- Background Color ---
        If Not String.IsNullOrWhiteSpace(bckclr) Then
            Dim cleanBack = bckclr.Replace("RGB(", "").Replace(")", "")
            Dim parts = cleanBack.Split(","c)

            If parts.Length = 3 Then
                Dim r, g, b As Integer
                If Integer.TryParse(parts(0).Trim(), r) AndAlso
               Integer.TryParse(parts(1).Trim(), g) AndAlso
               Integer.TryParse(parts(2).Trim(), b) Then

                    cell.Interior.Color = RGB(r, g, b)
                End If
            End If
        End If
    End Sub

#End Region

    Public Shared Sub FeatureUnavailable(Optional featureName As String = "")
        Dim message As String

        If String.IsNullOrWhiteSpace(featureName) Then
            message = "This feature is not yet available."
        Else
            message = $"The feature '{featureName}' is not yet available."
        End If

        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


End Class
