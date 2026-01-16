<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUpdates
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpdates))
        Me.RtbUpdates = New System.Windows.Forms.RichTextBox()
        Me.SidePanel1 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel2 = New DevExpress.XtraEditors.SidePanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SidePanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RtbUpdates
        '
        Me.RtbUpdates.BackColor = System.Drawing.Color.White
        Me.RtbUpdates.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RtbUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RtbUpdates.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbUpdates.Location = New System.Drawing.Point(15, 50)
        Me.RtbUpdates.Name = "RtbUpdates"
        Me.RtbUpdates.ReadOnly = True
        Me.RtbUpdates.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RtbUpdates.Size = New System.Drawing.Size(383, 424)
        Me.RtbUpdates.TabIndex = 1
        Me.RtbUpdates.Text = ""
        '
        'SidePanel1
        '
        Me.SidePanel1.BorderThickness = 0
        Me.SidePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel1.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel1.Name = "SidePanel1"
        Me.SidePanel1.Size = New System.Drawing.Size(15, 474)
        Me.SidePanel1.TabIndex = 2
        Me.SidePanel1.Text = "SidePanel1"
        '
        'SidePanel2
        '
        Me.SidePanel2.BorderThickness = 0
        Me.SidePanel2.Controls.Add(Me.Panel2)
        Me.SidePanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SidePanel2.Location = New System.Drawing.Point(15, 0)
        Me.SidePanel2.Name = "SidePanel2"
        Me.SidePanel2.Size = New System.Drawing.Size(383, 50)
        Me.SidePanel2.TabIndex = 3
        Me.SidePanel2.Text = "SidePanel2"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel2.Location = New System.Drawing.Point(0, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(277, 33)
        Me.Panel2.TabIndex = 16
        '
        'FrmUpdates
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 474)
        Me.Controls.Add(Me.RtbUpdates)
        Me.Controls.Add(Me.SidePanel2)
        Me.Controls.Add(Me.SidePanel1)
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUpdates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.SidePanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RtbUpdates As RichTextBox
    Friend WithEvents SidePanel1 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel2 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents Panel2 As Panel
End Class
