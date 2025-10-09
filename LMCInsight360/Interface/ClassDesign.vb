Public Class ClassDesign

    Public Shared Sub ApplyFlatStyle(elements As DevExpress.XtraBars.Navigation.AccordionControlElementCollection, Optional isRoot As Boolean = True)
        Dim fntsize As Integer = 10
        Dim fntcolor As Color = Color.FromArgb(10, 53, 121)


        For Each element As DevExpress.XtraBars.Navigation.AccordionControlElement In elements

            If isRoot AndAlso element.Style = DevExpress.XtraBars.Navigation.ElementStyle.Group Then
                ' ✅ Main group style
                element.Appearance.Normal.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Normal.ForeColor = fntcolor
                element.Appearance.Normal.Font = New Font("Segoe UI", fntsize, FontStyle.Regular)

                element.Appearance.Hovered.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Hovered.ForeColor = fntcolor
                element.Appearance.Hovered.Font = New Font("Segoe UI", fntsize, FontStyle.Bold)

                element.Appearance.Pressed.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Pressed.ForeColor = fntcolor
                element.Appearance.Pressed.Font = New Font("Segoe UI", fntsize, FontStyle.Bold)

            Else
                ' 🔹 Sub groups + items style
                element.Appearance.Normal.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Normal.ForeColor = fntcolor
                element.Appearance.Normal.Font = New Font("Segoe UI", fntsize, FontStyle.Regular)

                element.Appearance.Hovered.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Hovered.ForeColor = fntcolor
                element.Appearance.Hovered.Font = New Font("Segoe UI", fntsize, FontStyle.Bold)

                element.Appearance.Pressed.BackColor = Color.FromArgb(185, 206, 223)
                element.Appearance.Pressed.ForeColor = fntcolor
                element.Appearance.Pressed.Font = New Font("Segoe UI", fntsize, FontStyle.Bold)
            End If

            ' 🔹 Recursive apply (children are never root)
            If element.Elements.Count > 0 Then
                ApplyFlatStyle(element.Elements, False)
            End If
        Next
    End Sub


    Public Shared Sub CollapseAllElements(elements As DevExpress.XtraBars.Navigation.AccordionControlElementCollection)
        For Each element As DevExpress.XtraBars.Navigation.AccordionControlElement In elements
            element.Expanded = False
            If element.Elements.Count > 0 Then
                CollapseAllElements(element.Elements)
            End If
        Next
    End Sub

    Public Shared Sub ResizeSidePanel(frm As FrmMain)
        If frm.WindowState = FormWindowState.Maximized Then
            frm.targetWidth = 300
            ' frm.PnlLeft.Width = 300
        ElseIf frm.WindowState = FormWindowState.Normal Then
            frm.targetWidth = 270
            'frm.PnlLeft.Width = 270
        End If
    End Sub



End Class
