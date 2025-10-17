Imports LMCInsight360.ClassDesign
Imports LMCInsight360.SubClass
Public Class FrmMain

#Region "Main GUI Design"

    Public targetWidth As Integer = Nothing
    Private activeButton As Button = Nothing
    Private ReadOnly animationSpeed As Integer = 15
    Private bouncePhase As Integer = 0
    Private collapseOnly As Boolean = False
    Private isAnimating As Boolean = False

    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles BtnHome.Paint, BtnFico.Paint, BtnSD.Paint, BtnMaintenance.Paint
        Dim btn As Button = CType(sender, Button)

        If btn Is activeButton Then
            ' Draw underline at the bottom of the active button
            Dim g As Graphics = e.Graphics
            Dim pen As New Pen(Color.FromArgb(10, 53, 121), 3) ' color + thickness
            g.DrawLine(pen, 0, btn.Height - 2, btn.Width, btn.Height - 2)
        End If
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs) Handles BtnHome.Click, BtnFico.Click, BtnSD.Click, BtnMaintenance.Click
        Dim clickedBtn As Button = DirectCast(sender, Button)

        'Ignore if animation is running
        If isAnimating Then Exit Sub

        'Ignore if same button clicked again
        If activeButton Is clickedBtn Then Exit Sub

        'Set the newly active button
        activeButton = clickedBtn

        'Decide behavior based on button
        If clickedBtn Is BtnHome Then
            collapseOnly = True   ' only collapse
        Else
            collapseOnly = False  ' bounce back
        End If

        ' Start collapse phase
        bouncePhase = 1
        isAnimating = True
        MenuSilde.Start()

        ResizeSidePanel(Me)
        CollapseAllElements(SideBarSD.Elements)
        CollapseAllElements(SideBarFICO.Elements)
        CollapseAllElements(SideBarMaintenace.Elements)
        CloseALLTab()

        If clickedBtn Is BtnHome Then
            LblTitle.Text = "☰" '🏠
            activeButton = CType(sender, Button)
            RedrawButton()
            BtnHome.Hide()
        ElseIf clickedBtn Is BtnSD Then
            LblTitle.Text = "Sales Report"
            activeButton = CType(sender, Button)
            RedrawButton()
            BtnHome.Show()
        ElseIf clickedBtn Is BtnFico Then
            LblTitle.Text = "Financial Statement"
            activeButton = CType(sender, Button)
            RedrawButton()
            BtnHome.Show()
        ElseIf clickedBtn Is BtnMaintenance Then
            LblTitle.Text = "User Maintenance"
            activeButton = CType(sender, Button)
            RedrawButton()
            BtnHome.Show()
        End If

    End Sub

    Sub RedrawButton()
        ' Force all buttons to redraw
        BtnHome.Invalidate()
        BtnFico.Invalidate()
        BtnSD.Invalidate()
        BtnMaintenance.Invalidate()
    End Sub

    Private Sub MenuSilde_Tick(sender As Object, e As EventArgs) Handles MenuSilde.Tick
        If bouncePhase = 1 Then
            ' Collapse
            PnlLeft.Width -= animationSpeed

            ' Hide sidebars during collapse
            SideBarSD.Hide()
            SideBarFICO.Hide()
            SideBarMaintenace.Hide()

            If PnlLeft.Width <= 0 Then
                PnlLeft.Width = 0
                If collapseOnly Then
                    ' Stop here (for BtnHome)
                    bouncePhase = 0
                    MenuSilde.Stop()
                    isAnimating = False
                Else
                    ' Continue expand back (bounce)
                    bouncePhase = 2
                End If
            End If

        ElseIf bouncePhase = 2 Then
            ' Expand
            PnlLeft.Width += animationSpeed

            If PnlLeft.Width >= targetWidth Then
                PnlLeft.Width = targetWidth
                bouncePhase = 0
                MenuSilde.Stop()
                isAnimating = False

                ' ✅ Show correct sidebar AFTER expansion
                If activeButton Is BtnSD Then
                    SideBarSD.Show()
                ElseIf activeButton Is BtnFico Then
                    SideBarFICO.Show()
                ElseIf activeButton Is BtnMaintenance Then
                    SideBarMaintenace.Show()
                End If
            End If
        End If

    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If BtnHome.Visible Then
            ResizeSidePanel(Me)
        End If
    End Sub


    Private Sub LblUserIcon_Click(sender As Object, e As EventArgs) Handles LblUserIcon.Click
        ShowUserInfo()
    End Sub

    Private Sub Lbluser_Click(sender As Object, e As EventArgs) Handles Lbluser.Click
        ShowUserInfo()
    End Sub

    Private Sub ShowUserInfo()
        Dim popup As New FrmAdminInfo With {
            .Size = New Size(309, 245)
        }
        Dim pt As Point = Me.PointToScreen(New Point(PnlBRight.Right - popup.Width, PnlTopHeader.Bottom))
        popup.StartPosition = FormStartPosition.Manual
        popup.Location = pt

        popup.Show(Me)
    End Sub


#End Region
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnHome.Hide()
        PnlLeft.Width = 0

        ApplyFlatStyle(SideBarSD.Elements)
        ApplyFlatStyle(SideBarFICO.Elements)
        ApplyFlatStyle(SideBarMaintenace.Elements)

    End Sub

#Region "Finacial Statement"

    Private Sub BtnAnnxA_IS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_IS.Click
        Gbl_ReportTag = 1
        TabMenu(Me, New CtrAnnexA, "Income Statement")
    End Sub

    Private Sub BtnAnnxA_BS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_BS.Click
        Gbl_ReportTag = 2
        TabMenu(Me, New CtrAnnexA, "Balance Sheet")
    End Sub

    Private Sub BtnAnnxA_DS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_DS.Click
        Gbl_ReportTag = 3
        TabMenu(Me, New CtrAnnexA, "Details Schedule")
    End Sub

    Private Sub BtnAnnxA_Gen_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_Gen.Click
        Gbl_ReportTag = 4
        TabMenu(Me, New CtrAnnexA, "Generate Annex A")
    End Sub

    Private Sub BtnDataInitializedFI_Click(sender As Object, e As EventArgs) Handles BtnDataInitializedFI.Click
        TabMenu(Me, New CtrDataInitializeFI, "Data Initialization-FI")
    End Sub

    Private Sub BtnAnnxB_IScomp_Click(sender As Object, e As EventArgs) Handles BtnAnnxB_IScomp.Click
        TabMenu(Me, New CtrAnnexB, "IS Comparative")
    End Sub





#End Region





End Class