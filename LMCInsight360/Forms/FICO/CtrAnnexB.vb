Public Class CtrAnnexB

    '  Dim BtnAnnexB As Integer

    Private Sub CtrlAnnexB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlReportType.Enabled = False
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
End Class
