Imports System.Drawing.Drawing2D

Public Class RoundedButton
    Inherits Button

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Create rounded path
        Dim path As New GraphicsPath()
        Dim radius As Integer = 20
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseAllFigures()

        ' Apply region
        Me.Region = New Region(path)

        ' Optional: custom fill and border
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using brush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(brush, path)
        End Using
        Using pen As New Pen(Me.ForeColor, 2)
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Draw text
        TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, Me.ClientRectangle, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class
