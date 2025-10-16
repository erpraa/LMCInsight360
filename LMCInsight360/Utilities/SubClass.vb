Imports DevExpress.XtraBars.Docking2010.Views.Tabbed
Imports DevExpress.XtraBars.Docking2010.Views
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
'Imports DevExpress.XtraGrid
'Imports DevExpress.XtraGrid.Views.Grid
Imports LMCInsight360.ClassFunction

Imports Excel = Microsoft.Office.Interop.Excel
Public Class SubClass

#Region "FrmMain"
    Public Shared Sub TabviewButton(TabControl As UserControl, TabName As String)
        ' Create a new Document for the DocumentManager
        Dim doc As BaseDocument = FrmMain.DocumentManager1.View.AddDocument(TabControl)

        ' Set the document caption (tab name)
        doc.Caption = TabName

        ' ✅ Disable close button only for specific tab
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


    ' Reusable function to load query into a GridControl (non-editable)
    'Public Shared Sub LoadDataToGrid(query As String, grid As GridControl)
    '    Using conn As New SqlConnection(SqlConnect)
    '        Dim da As New SqlDataAdapter(query, conn)
    '        Dim dt As New DataTable()
    '        da.Fill(dt)
    '        grid.DataSource = dt
    '    End Using

    '    ' Ensure the main view is a GridView and set read-only
    '    Dim view As GridView = TryCast(grid.MainView, GridView)
    '    If view IsNot Nothing Then
    '        view.OptionsBehavior.Editable = False
    '        view.OptionsBehavior.ReadOnly = True
    '        view.OptionsView.ShowGroupPanel = False   ' optional: hides group panel
    '        view.BestFitColumns()                     ' optional: auto-fit columns
    '    End If
    'End Sub


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

    Public Shared Sub SetBottomBorder(ws As Excel.Worksheet, row As Integer, col As Integer, uline As String)
        Dim cell As Excel.Range = ws.Cells(row, col)

        Select Case uline
            Case "S"  ' Single line
                cell.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                cell.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThin

            Case "D"  ' Double line
                cell.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
                ' For double line, Excel ignores Weight (it auto-formats as double line)
                ' but you can still set weight if needed:
                cell.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick

            Case Else ' No line
                cell.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        End Select
    End Sub

#End Region
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
