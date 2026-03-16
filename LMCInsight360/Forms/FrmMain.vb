Imports LMCInsight360.ClassDesign
Imports LMCInsight360.SubClass
Imports LMCInsight360.ClassFunction
Public Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UserRefresh.Start()
        BtnHome.Hide()
        PnlLeft.Width = 0

        ApplyFlatStyle(SideBarSD.Elements)
        ApplyFlatStyle(SideBarFICO.Elements)
        ApplyFlatStyle(SideBarMaintenace.Elements)

        Lbluser.Text = StrConv(GstrUselogin, VbStrConv.ProperCase)
    End Sub

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

        If clickedBtn Is BtnSD Then
            If Not IsUserAuthorized(GstrUseID, "\01") Then
                MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        ElseIf clickedBtn Is BtnFico Then
            If Not IsUserAuthorized(GstrUseID, "\02") Then
                MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        ElseIf clickedBtn Is BtnMaintenance Then
            If Not IsUserAuthorized(GstrUseID, "\03") Then
                MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

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

            If Not IsUserAuthorized(GstrUseID, "\02") Then
                MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

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

        Dim popup As New FrmAdminInfo()

        popup.StartPosition = FormStartPosition.Manual

        ' Force DPI scaling and layout
        popup.AutoScaleMode = AutoScaleMode.Dpi
        popup.PerformLayout()

        ' Ensure handle is created so Width is correct
        popup.CreateControl()

        ' Now Width is DPI-correct
        Dim pt As Point = Me.PointToScreen(
        New Point(PnlBRight.Right - popup.Width, PnlTopHeader.Bottom)
    )

        popup.Location = pt
        popup.Show(Me)

    End Sub


#End Region

#Region "Finacial Statement"

#Region "Annex A Button"
    Private Sub BtnAnnxA_IS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_IS.Click

        If Not IsUserAuthorized(GstrUseID, "\02010101") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 1
        TabMenu(Me, New CtrAnnexA, "Income Statement")
    End Sub
    Private Sub BtnAnnxA_BS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_BS.Click
        If Not IsUserAuthorized(GstrUseID, "\02010102") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 2
        TabMenu(Me, New CtrAnnexA, "Balance Sheet")
    End Sub

    Private Sub BtnAnnxA_DS_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_DS.Click
        If Not IsUserAuthorized(GstrUseID, "\02010103") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 3
        TabMenu(Me, New CtrAnnexA, "Details Schedule")
    End Sub

    Private Sub BtnAnnxA_Gen_Click(sender As Object, e As EventArgs) Handles BtnAnnxA_Gen.Click
        If Not IsUserAuthorized(GstrUseID, "\02010104") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 4
        TabMenu(Me, New CtrAnnexA, "Generate Annex A")
    End Sub
#End Region

#Region "Annex B Button"
    Private Sub BtnAnnxB_IScomp_Click(sender As Object, e As EventArgs) Handles BtnAnnxB_IScomp.Click
        If Not IsUserAuthorized(GstrUseID, "\02010201") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 1
        TabMenu(Me, New CtrAnnexB, "IS Comparative")
    End Sub

    Private Sub BtnAnnxB_SEGAAE_Click(sender As Object, e As EventArgs) Handles BtnAnnxB_SEGAAE.Click
        If Not IsUserAuthorized(GstrUseID, "\02010202") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 2
        TabMenu(Me, New CtrAnnexB, "SE & GAAE")
    End Sub

    Private Sub BtnAnnxB_RUGainLoss_Click(sender As Object, e As EventArgs) Handles BtnAnnxB_RUGainLoss.Click
        If Not IsUserAuthorized(GstrUseID, "\02010203") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 3
        TabMenu(Me, New CtrAnnexB, "RealizedFx & UnrealizeFx")
    End Sub

    Private Sub BtnAnnxB_Gen_Click(sender As Object, e As EventArgs) Handles BtnAnnxB_Gen.Click
        If Not IsUserAuthorized(GstrUseID, "\02010204") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 4
        TabMenu(Me, New CtrAnnexB, "Generate Annex B")
    End Sub
#End Region

#Region "Annex C Button"
    Private Sub BtnAnnxC_CosRatio_Click(sender As Object, e As EventArgs) Handles BtnAnnxC_CosRatio.Click
        If Not IsUserAuthorized(GstrUseID, "\02010301") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 1
        TabMenu(Me, New CtrAnnexC, "Cost of Sales Ratio")
    End Sub

    Private Sub BtnAnnxC_MFGCost_Click(sender As Object, e As EventArgs) Handles BtnAnnxC_MFGCost.Click
        If Not IsUserAuthorized(GstrUseID, "\02010302") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 2
        TabMenu(Me, New CtrAnnexC, "Manufacturing Cost")
    End Sub

    Private Sub BtnAnnxC_MOHCost_Click(sender As Object, e As EventArgs) Handles BtnAnnxC_MOHCost.Click
        If Not IsUserAuthorized(GstrUseID, "\02010303") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 3
        TabMenu(Me, New CtrAnnexC, "Manufacturing Overhead")
    End Sub

    Private Sub BtnAnnxC_Gen_Click(sender As Object, e As EventArgs) Handles BtnAnnxC_Gen.Click
        If Not IsUserAuthorized(GstrUseID, "\02010304") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Gbl_ReportTag = 4
        TabMenu(Me, New CtrAnnexC, "Generate Annex C")
    End Sub

#End Region

#Region "Data Management Button"
    Private Sub BtnDataInitializedFI_Click(sender As Object, e As EventArgs) Handles BtnDataInitializedFI.Click
        If Not IsUserAuthorized(GstrUseID, "\020201") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        TabMenu(Me, New CtrDataInitializeFI, "Data Initialization-FI")
    End Sub
    Private Sub BtnDataInitializedMM_Click(sender As Object, e As EventArgs) Handles BtnDataInitializedMM.Click
        If Not IsUserAuthorized(GstrUseID, "\020202") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        TabMenu(Me, New CtrDataInitializeMM, "Data Initialization-MM")
    End Sub
#End Region

#End Region

#Region "Maintenance Module"

    Private Sub CreateAccount_Click(sender As Object, e As EventArgs) Handles CreateAccount.Click
        If Not IsUserAuthorized(GstrUseID, "\0301") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        TabMenu(Me, New CtrCreateAccount, "Create Account")
    End Sub

    Private Sub UserAccess_Click(sender As Object, e As EventArgs) Handles UserAccess.Click

        If Not IsUserAuthorized(GstrUseID, "\0302") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        TabMenu(Me, New CtrUserAccess, "User Access")
    End Sub

    Private Sub ResetPassword_Click(sender As Object, e As EventArgs) Handles ResetPassword.Click
        If Not IsUserAuthorized(GstrUseID, "\0303") Then
            MessageBox.Show("You are not authorized to perform this action.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        TabMenu(Me, New CtrResetPassword, "Reset Password")
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles BtnAbout.Click
        ' About Us section
        Dim aboutMsg As String = "About Us" & Environment.NewLine & Environment.NewLine &
                             "LMC Insight360 is a powerful reporting system designed to consolidate CAS and Reserved data into accurate and comprehensive reports. We provide tools that simplify the generation of complex Financial Statements and Sales Reports, helping organizations save time and reduce manual effort." & Environment.NewLine & Environment.NewLine &
                             "Our Purpose" & Environment.NewLine & Environment.NewLine &
                             "Our goal is to streamline the reporting process, improve data accuracy, and enhance decision making by delivering fast, reliable, and automated report generation. With LMC Insight360, users can focus on insights rather than manual data compilation." & Environment.NewLine & Environment.NewLine

        ' What's New section
        Dim updatesMsg As String = "What's New:" & Environment.NewLine & Environment.NewLine
        For Each u In AppUpdates.Updates
            updatesMsg &= $"Version {u.Version} ({u.ReleaseDate:MM/dd/yyyy})" & Environment.NewLine
            For Each desc In u.Descriptions
                updatesMsg &= $"• {desc}" & Environment.NewLine
            Next
            updatesMsg &= Environment.NewLine
        Next

        ' Combine both messages
        Dim fullMsg As String = aboutMsg & updatesMsg

        ' Show in scrollable form
        Dim frm As New FrmUpdates(fullMsg)
        frm.ShowDialog()
    End Sub

#End Region

    Private Sub AccordionControlElement10_Click(sender As Object, e As EventArgs) Handles AccordionControlElement10.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement12_Click(sender As Object, e As EventArgs) Handles AccordionControlElement12.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement13_Click(sender As Object, e As EventArgs) Handles AccordionControlElement13.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement14_Click(sender As Object, e As EventArgs) Handles AccordionControlElement14.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement15_Click(sender As Object, e As EventArgs) Handles AccordionControlElement15.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement16_Click(sender As Object, e As EventArgs) Handles AccordionControlElement16.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement17_Click(sender As Object, e As EventArgs) Handles AccordionControlElement17.Click
        ShowMaintenance()
    End Sub

    Private Sub AccordionControlElement18_Click(sender As Object, e As EventArgs) Handles AccordionControlElement18.Click
        ShowMaintenance()
    End Sub


    Private Sub FrmMain_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        UpdateLoginStatus(GstrUseID, False)
        FrmLogin.Close()
    End Sub

    Private Sub UserRefresh_Tick(sender As Object, e As EventArgs) Handles UserRefresh.Tick
        Dim Isloggged As String = GetValue($"Select IsLoggedIn from MSTR_USERS where UserID='{GstrUseID}'")

        If Isloggged = False Then
            Me.Dispose()
            Me.Close()
            FrmLogin.Close()
            FrmLogin.Dispose()
        End If
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class