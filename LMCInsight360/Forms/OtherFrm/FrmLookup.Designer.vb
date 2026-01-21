<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLookup
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SidePanel1 = New DevExpress.XtraEditors.SidePanel()
        Me.BtnBack = New LMCInsight360.RoundedButton()
        Me.BtnProceed = New LMCInsight360.RoundedButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SidePanel2 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel3 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel4 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SidePanel1
        '
        Me.SidePanel1.AllowResize = False
        Me.SidePanel1.BorderThickness = 0
        Me.SidePanel1.Controls.Add(Me.BtnBack)
        Me.SidePanel1.Controls.Add(Me.BtnProceed)
        Me.SidePanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SidePanel1.Location = New System.Drawing.Point(0, 384)
        Me.SidePanel1.Name = "SidePanel1"
        Me.SidePanel1.Size = New System.Drawing.Size(843, 50)
        Me.SidePanel1.TabIndex = 0
        Me.SidePanel1.Text = "SidePanel1"
        '
        'BtnBack
        '
        Me.BtnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnBack.FlatAppearance.BorderSize = 0
        Me.BtnBack.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBack.ForeColor = System.Drawing.Color.White
        Me.BtnBack.Location = New System.Drawing.Point(306, 9)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(125, 32)
        Me.BtnBack.TabIndex = 52
        Me.BtnBack.Text = "Back"
        Me.BtnBack.UseVisualStyleBackColor = False
        '
        'BtnProceed
        '
        Me.BtnProceed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnProceed.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnProceed.FlatAppearance.BorderSize = 0
        Me.BtnProceed.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProceed.ForeColor = System.Drawing.Color.White
        Me.BtnProceed.Location = New System.Drawing.Point(437, 9)
        Me.BtnProceed.Name = "BtnProceed"
        Me.BtnProceed.Size = New System.Drawing.Size(125, 32)
        Me.BtnProceed.TabIndex = 51
        Me.BtnProceed.Text = "Proceed"
        Me.BtnProceed.UseVisualStyleBackColor = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(20, 25)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(803, 359)
        Me.GridControl1.TabIndex = 47
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SidePanel2
        '
        Me.SidePanel2.AllowResize = False
        Me.SidePanel2.BorderThickness = 0
        Me.SidePanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SidePanel2.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel2.Name = "SidePanel2"
        Me.SidePanel2.Size = New System.Drawing.Size(843, 25)
        Me.SidePanel2.TabIndex = 48
        Me.SidePanel2.Text = "SidePanel2"
        '
        'SidePanel3
        '
        Me.SidePanel3.AllowResize = False
        Me.SidePanel3.BorderThickness = 0
        Me.SidePanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SidePanel3.Location = New System.Drawing.Point(823, 25)
        Me.SidePanel3.Name = "SidePanel3"
        Me.SidePanel3.Size = New System.Drawing.Size(20, 359)
        Me.SidePanel3.TabIndex = 49
        Me.SidePanel3.Text = "SidePanel3"
        '
        'SidePanel4
        '
        Me.SidePanel4.AllowResize = False
        Me.SidePanel4.BorderThickness = 0
        Me.SidePanel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel4.Location = New System.Drawing.Point(0, 25)
        Me.SidePanel4.Name = "SidePanel4"
        Me.SidePanel4.Size = New System.Drawing.Size(20, 359)
        Me.SidePanel4.TabIndex = 49
        Me.SidePanel4.Text = "SidePanel4"
        '
        'FrmLookup
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 434)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SidePanel4)
        Me.Controls.Add(Me.SidePanel3)
        Me.Controls.Add(Me.SidePanel2)
        Me.Controls.Add(Me.SidePanel1)
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.SidePanel1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SidePanel1 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents BtnBack As RoundedButton
    Friend WithEvents BtnProceed As RoundedButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SidePanel2 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel3 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel4 As DevExpress.XtraEditors.SidePanel
End Class
