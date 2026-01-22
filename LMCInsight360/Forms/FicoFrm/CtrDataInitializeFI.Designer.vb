<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrDataInitializeFI
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.BtnLoadData = New LMCInsight360.RoundedButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnClosedPeriod = New LMCInsight360.RoundedButton()
        Me.BtnOpenPeriod = New LMCInsight360.RoundedButton()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.TxtMonth = New DevExpress.XtraEditors.TextEdit()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.LblMessage = New DevExpress.XtraEditors.LabelControl()
        Me.BtnNewGL = New LMCInsight360.RoundedButton()
        Me.SidePanel1 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel2 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel3 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel4 = New DevExpress.XtraEditors.SidePanel()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        Me.SidePanel1.SuspendLayout()
        Me.SidePanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnLoadData
        '
        Me.BtnLoadData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnLoadData.FlatAppearance.BorderSize = 0
        Me.BtnLoadData.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadData.ForeColor = System.Drawing.Color.White
        Me.BtnLoadData.Location = New System.Drawing.Point(453, 9)
        Me.BtnLoadData.Name = "BtnLoadData"
        Me.BtnLoadData.Size = New System.Drawing.Size(140, 30)
        Me.BtnLoadData.TabIndex = 45
        Me.BtnLoadData.Text = "Load Data"
        Me.BtnLoadData.UseVisualStyleBackColor = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(20, 58)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(891, 452)
        Me.GridControl1.TabIndex = 46
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
        'BtnClosedPeriod
        '
        Me.BtnClosedPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClosedPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnClosedPeriod.FlatAppearance.BorderSize = 0
        Me.BtnClosedPeriod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClosedPeriod.ForeColor = System.Drawing.Color.White
        Me.BtnClosedPeriod.Location = New System.Drawing.Point(599, 9)
        Me.BtnClosedPeriod.Name = "BtnClosedPeriod"
        Me.BtnClosedPeriod.Size = New System.Drawing.Size(140, 30)
        Me.BtnClosedPeriod.TabIndex = 47
        Me.BtnClosedPeriod.Text = "Closed Period"
        Me.BtnClosedPeriod.UseVisualStyleBackColor = False
        '
        'BtnOpenPeriod
        '
        Me.BtnOpenPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpenPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnOpenPeriod.FlatAppearance.BorderSize = 0
        Me.BtnOpenPeriod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOpenPeriod.ForeColor = System.Drawing.Color.White
        Me.BtnOpenPeriod.Location = New System.Drawing.Point(745, 9)
        Me.BtnOpenPeriod.Name = "BtnOpenPeriod"
        Me.BtnOpenPeriod.Size = New System.Drawing.Size(140, 30)
        Me.BtnOpenPeriod.TabIndex = 48
        Me.BtnOpenPeriod.Text = "Open Period"
        Me.BtnOpenPeriod.UseVisualStyleBackColor = False
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(171, 16)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtYear.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtYear.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.TxtYear.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtYear.Properties.Appearance.Options.UseBackColor = True
        Me.TxtYear.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtYear.Properties.Appearance.Options.UseFont = True
        Me.TxtYear.Properties.Appearance.Options.UseForeColor = True
        Me.TxtYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtYear.Properties.ReadOnly = True
        Me.TxtYear.Size = New System.Drawing.Size(109, 30)
        Me.TxtYear.TabIndex = 51
        '
        'TxtMonth
        '
        Me.TxtMonth.Location = New System.Drawing.Point(18, 16)
        Me.TxtMonth.Name = "TxtMonth"
        Me.TxtMonth.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtMonth.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtMonth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.TxtMonth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtMonth.Properties.Appearance.Options.UseBackColor = True
        Me.TxtMonth.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtMonth.Properties.Appearance.Options.UseFont = True
        Me.TxtMonth.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtMonth.Properties.ReadOnly = True
        Me.TxtMonth.Size = New System.Drawing.Size(147, 30)
        Me.TxtMonth.TabIndex = 52
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.LblMessage)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 561)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(931, 36)
        Me.PnlFooter.TabIndex = 53
        '
        'LblMessage
        '
        Me.LblMessage.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMessage.Appearance.Options.UseFont = True
        Me.LblMessage.Appearance.Options.UseForeColor = True
        Me.LblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblMessage.Location = New System.Drawing.Point(0, 0)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(773, 36)
        Me.LblMessage.TabIndex = 25
        '
        'BtnNewGL
        '
        Me.BtnNewGL.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.BtnNewGL.FlatAppearance.BorderSize = 0
        Me.BtnNewGL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewGL.ForeColor = System.Drawing.Color.White
        Me.BtnNewGL.Location = New System.Drawing.Point(3, 9)
        Me.BtnNewGL.Name = "BtnNewGL"
        Me.BtnNewGL.Size = New System.Drawing.Size(162, 30)
        Me.BtnNewGL.TabIndex = 54
        Me.BtnNewGL.Text = "View New GL"
        Me.BtnNewGL.UseVisualStyleBackColor = False
        '
        'SidePanel1
        '
        Me.SidePanel1.BorderThickness = 0
        Me.SidePanel1.Controls.Add(Me.TxtYear)
        Me.SidePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SidePanel1.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel1.Name = "SidePanel1"
        Me.SidePanel1.Size = New System.Drawing.Size(931, 58)
        Me.SidePanel1.TabIndex = 55
        Me.SidePanel1.Text = "SidePanel1"
        '
        'SidePanel2
        '
        Me.SidePanel2.BorderThickness = 0
        Me.SidePanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel2.Location = New System.Drawing.Point(0, 58)
        Me.SidePanel2.Name = "SidePanel2"
        Me.SidePanel2.Size = New System.Drawing.Size(20, 503)
        Me.SidePanel2.TabIndex = 56
        Me.SidePanel2.Text = "SidePanel2"
        '
        'SidePanel3
        '
        Me.SidePanel3.BorderThickness = 0
        Me.SidePanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SidePanel3.Location = New System.Drawing.Point(911, 58)
        Me.SidePanel3.Name = "SidePanel3"
        Me.SidePanel3.Size = New System.Drawing.Size(20, 503)
        Me.SidePanel3.TabIndex = 56
        Me.SidePanel3.Text = "SidePanel3"
        '
        'SidePanel4
        '
        Me.SidePanel4.BorderThickness = 0
        Me.SidePanel4.Controls.Add(Me.BtnNewGL)
        Me.SidePanel4.Controls.Add(Me.BtnOpenPeriod)
        Me.SidePanel4.Controls.Add(Me.BtnLoadData)
        Me.SidePanel4.Controls.Add(Me.BtnClosedPeriod)
        Me.SidePanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SidePanel4.Location = New System.Drawing.Point(20, 510)
        Me.SidePanel4.Name = "SidePanel4"
        Me.SidePanel4.Size = New System.Drawing.Size(891, 51)
        Me.SidePanel4.TabIndex = 57
        Me.SidePanel4.Text = "SidePanel4"
        '
        'CtrDataInitializeFI
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TxtMonth)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SidePanel4)
        Me.Controls.Add(Me.SidePanel3)
        Me.Controls.Add(Me.SidePanel2)
        Me.Controls.Add(Me.SidePanel1)
        Me.Controls.Add(Me.PnlFooter)
        Me.Name = "CtrDataInitializeFI"
        Me.Size = New System.Drawing.Size(931, 597)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFooter.ResumeLayout(False)
        Me.SidePanel1.ResumeLayout(False)
        Me.SidePanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnLoadData As RoundedButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClosedPeriod As RoundedButton
    Friend WithEvents BtnOpenPeriod As RoundedButton
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtMonth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PnlFooter As Panel
    Friend WithEvents LblMessage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnNewGL As RoundedButton
    Friend WithEvents SidePanel1 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel2 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel3 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel4 As DevExpress.XtraEditors.SidePanel
End Class
