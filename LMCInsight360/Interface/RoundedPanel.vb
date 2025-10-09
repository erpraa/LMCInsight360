Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedPanel
    Inherits Panel

    ' Property to control the corner radius
    Public Property CornerRadius As Integer = 10

    ' Constructor: Set styles for better performance and appearance
    Public Sub New()
        MyBase.New()
        Me.DoubleBuffered = True ' Reduces flickering
    End Sub

    ' The main method: Creates the rounded rectangle path
    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim diameter As Integer = radius * 2
        Dim arc As New Rectangle(rect.Location, New Size(diameter, diameter))
        Dim path As New GraphicsPath()

        ' Top left corner
        path.AddArc(arc, 180, 90)

        ' Top right corner
        arc.X = rect.Right - diameter
        path.AddArc(arc, 270, 90)

        ' Bottom right corner
        arc.Y = rect.Bottom - diameter
        path.AddArc(arc, 0, 90)

        ' Bottom left corner
        arc.X = rect.Left
        path.AddArc(arc, 90, 90)

        path.CloseFigure()
        Return path
    End Function

    ' Override OnResize to update the region when the panel size changes
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        If CornerRadius > 0 Then
            Using path As GraphicsPath = GetRoundedPath(Me.ClientRectangle, CornerRadius)
                Me.Region = New Region(path)
            End Using
        Else
            Me.Region = Nothing ' Reset to rectangle if radius is 0
        End If
    End Sub

    ' Override OnPaint to create a flat appearance with no border
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ' This is the key change: We ONLY fill the background
        ' and completely skip drawing any border
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Using path As GraphicsPath = GetRoundedPath(Me.ClientRectangle, CornerRadius)
            ' Fill the background with the panel's BackColor
            Using backBrush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(backBrush, path)
            End Using
            ' NOTE: No border is drawn here - that's what makes it flat!
        End Using
    End Sub

End Class
