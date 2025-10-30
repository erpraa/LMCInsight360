Imports LMCInsight360.ClassFunction
Public Class FrmViewGL
    Private Sub FrmViewGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridControl1.DataSource = PopulateDataSQL("select * from vw_NEWGLACCNT")
        GridView1.BestFitColumns()
        GridView1.OptionsFind.AlwaysVisible = True
        GridView1.OptionsBehavior.Editable = True
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
End Class