Imports LMCInsight360.ClassFunction
Public Class FrmLookup

    Event Selected(GetIDNumber As String)

    Private ReadOnly GetModuleName As String

    Sub New(str_Query As String, Module_Name As String)

        InitializeComponent()

        LoadDataLookup(str_Query)

        GetModuleName = Module_Name
    End Sub

    Sub LoadDataLookup(GetstrQuery As String)

        GridControl1.DataSource = PopulateDataSQL(GetstrQuery)

        GridView1.BestFitColumns()
        GridView1.OptionsFind.AlwaysVisible = True
        GridView1.OptionsView.ShowAutoFilterRow = False
        GridView1.OptionsBehavior.Editable = False
    End Sub

    Private Sub BtnProceed_Click(sender As Object, e As EventArgs) Handles BtnProceed.Click
        GetSeletedID(GetModuleName)
    End Sub

    Sub GetSeletedID(FormsName As String)

        Dim focusedRowHandle As Integer = GridView1.FocusedRowHandle

        ' Check if the focused row is valid
        If focusedRowHandle >= 0 Then

            ' Get the values from the respective columns.
            Dim Get_IdNumber As String = Nothing

            Select Case FormsName
                Case "ResetPassword"
                    Get_IdNumber = GridView1.GetFocusedDataRow.Item("UserID")
                Case "CreateAccount"
                    Get_IdNumber = GridView1.GetFocusedDataRow.Item("DeptID")
            End Select

            RaiseEvent Selected(Get_IdNumber)
        End If

        Me.Close()

    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Me.Close()
    End Sub
End Class