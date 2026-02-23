Public Class FrmUpdates

    Public Sub New(updatesText As String)
        InitializeComponent()
        RtbUpdates.Text = updatesText
    End Sub

    Private Sub FrmUpdates_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class