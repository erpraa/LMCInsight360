<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtrAnnexA
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxSapSource = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CbxBusinessType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.LblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.LblLoadDate = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.CbxMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RbtnBoth = New System.Windows.Forms.RadioButton()
        Me.RbtnAccum = New System.Windows.Forms.RadioButton()
        Me.RbtnMonthly = New System.Windows.Forms.RadioButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PnlReportType = New System.Windows.Forms.Panel()
        Me.BtnGenerate = New LMCInsight360.RoundedButton()
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlReportType.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(172, 38)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(121, 23)
        Me.LabelControl3.TabIndex = 29
        Me.LabelControl3.Text = "Business Type: *"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(32, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl1.TabIndex = 26
        Me.LabelControl1.Text = "SAP Source: *"
        '
        'CbxSapSource
        '
        Me.CbxSapSource.Location = New System.Drawing.Point(32, 67)
        Me.CbxSapSource.Name = "CbxSapSource"
        Me.CbxSapSource.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxSapSource.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxSapSource.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxSapSource.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxSapSource.Properties.Appearance.Options.UseBackColor = True
        Me.CbxSapSource.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxSapSource.Properties.Appearance.Options.UseFont = True
        Me.CbxSapSource.Properties.Appearance.Options.UseForeColor = True
        Me.CbxSapSource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxSapSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxSapSource.Properties.Items.AddRange(New Object() {"", "CAS", "Reserved"})
        Me.CbxSapSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxSapSource.Size = New System.Drawing.Size(134, 30)
        Me.CbxSapSource.TabIndex = 24
        '
        'CbxBusinessType
        '
        Me.CbxBusinessType.Location = New System.Drawing.Point(172, 67)
        Me.CbxBusinessType.Name = "CbxBusinessType"
        Me.CbxBusinessType.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxBusinessType.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxBusinessType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxBusinessType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxBusinessType.Properties.Appearance.Options.UseBackColor = True
        Me.CbxBusinessType.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxBusinessType.Properties.Appearance.Options.UseFont = True
        Me.CbxBusinessType.Properties.Appearance.Options.UseForeColor = True
        Me.CbxBusinessType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxBusinessType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxBusinessType.Properties.Items.AddRange(New Object() {"", "OVERALL", "FOODSTUFF"})
        Me.CbxBusinessType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxBusinessType.Size = New System.Drawing.Size(210, 30)
        Me.CbxBusinessType.TabIndex = 30
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.LblStatus)
        Me.PnlFooter.Controls.Add(Me.LblLoadDate)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 684)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(1406, 36)
        Me.PnlFooter.TabIndex = 41
        '
        'LblStatus
        '
        Me.LblStatus.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblStatus.Appearance.Options.UseFont = True
        Me.LblStatus.Appearance.Options.UseForeColor = True
        Me.LblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LblStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblStatus.Location = New System.Drawing.Point(112, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(51, 23)
        Me.LblStatus.TabIndex = 27
        Me.LblStatus.Text = "Status:"
        '
        'LblLoadDate
        '
        Me.LblLoadDate.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLoadDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblLoadDate.Appearance.Options.UseFont = True
        Me.LblLoadDate.Appearance.Options.UseForeColor = True
        Me.LblLoadDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LblLoadDate.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblLoadDate.Location = New System.Drawing.Point(0, 0)
        Me.LblLoadDate.Name = "LblLoadDate"
        Me.LblLoadDate.Size = New System.Drawing.Size(112, 23)
        Me.LblLoadDate.TabIndex = 25
        Me.LblLoadDate.Text = "Date and Time"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(389, 38)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(99, 23)
        Me.LabelControl4.TabIndex = 32
        Me.LabelControl4.Text = "End Period: *"
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(528, 67)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtYear.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtYear.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtYear.Properties.Appearance.Options.UseBackColor = True
        Me.TxtYear.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtYear.Properties.Appearance.Options.UseFont = True
        Me.TxtYear.Properties.Appearance.Options.UseForeColor = True
        Me.TxtYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtYear.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TxtYear.Properties.Mask.ShowPlaceHolders = False
        Me.TxtYear.Properties.MaxLength = 4
        Me.TxtYear.Size = New System.Drawing.Size(70, 30)
        Me.TxtYear.TabIndex = 25
        '
        'CbxMonth
        '
        Me.CbxMonth.Location = New System.Drawing.Point(388, 67)
        Me.CbxMonth.Name = "CbxMonth"
        Me.CbxMonth.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxMonth.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxMonth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxMonth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxMonth.Properties.Appearance.Options.UseBackColor = True
        Me.CbxMonth.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxMonth.Properties.Appearance.Options.UseFont = True
        Me.CbxMonth.Properties.Appearance.Options.UseForeColor = True
        Me.CbxMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxMonth.Properties.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CbxMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxMonth.Size = New System.Drawing.Size(134, 30)
        Me.CbxMonth.TabIndex = 31
        '
        'RbtnBoth
        '
        Me.RbtnBoth.AutoSize = True
        Me.RbtnBoth.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtnBoth.Location = New System.Drawing.Point(248, 43)
        Me.RbtnBoth.Name = "RbtnBoth"
        Me.RbtnBoth.Size = New System.Drawing.Size(67, 27)
        Me.RbtnBoth.TabIndex = 36
        Me.RbtnBoth.Text = "Both"
        Me.RbtnBoth.UseVisualStyleBackColor = True
        '
        'RbtnAccum
        '
        Me.RbtnAccum.AutoSize = True
        Me.RbtnAccum.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtnAccum.Location = New System.Drawing.Point(111, 43)
        Me.RbtnAccum.Name = "RbtnAccum"
        Me.RbtnAccum.Size = New System.Drawing.Size(131, 27)
        Me.RbtnAccum.TabIndex = 35
        Me.RbtnAccum.Text = "Accumulated"
        Me.RbtnAccum.UseVisualStyleBackColor = True
        '
        'RbtnMonthly
        '
        Me.RbtnMonthly.AutoSize = True
        Me.RbtnMonthly.Checked = True
        Me.RbtnMonthly.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtnMonthly.Location = New System.Drawing.Point(11, 43)
        Me.RbtnMonthly.Name = "RbtnMonthly"
        Me.RbtnMonthly.Size = New System.Drawing.Size(94, 27)
        Me.RbtnMonthly.TabIndex = 34
        Me.RbtnMonthly.TabStop = True
        Me.RbtnMonthly.Text = "Monthly"
        Me.RbtnMonthly.UseVisualStyleBackColor = True
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(94, 23)
        Me.LabelControl6.TabIndex = 39
        Me.LabelControl6.Text = "Report Type"
        '
        'PnlReportType
        '
        Me.PnlReportType.Controls.Add(Me.RbtnBoth)
        Me.PnlReportType.Controls.Add(Me.RbtnMonthly)
        Me.PnlReportType.Controls.Add(Me.RbtnAccum)
        Me.PnlReportType.Controls.Add(Me.LabelControl6)
        Me.PnlReportType.Location = New System.Drawing.Point(32, 113)
        Me.PnlReportType.Name = "PnlReportType"
        Me.PnlReportType.Size = New System.Drawing.Size(350, 82)
        Me.PnlReportType.TabIndex = 43
        '
        'BtnGenerate
        '
        Me.BtnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.BtnGenerate.FlatAppearance.BorderSize = 0
        Me.BtnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.White
        Me.BtnGenerate.Location = New System.Drawing.Point(388, 143)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(210, 33)
        Me.BtnGenerate.TabIndex = 42
        Me.BtnGenerate.Text = "📥 Generate Report"
        Me.BtnGenerate.UseVisualStyleBackColor = False
        '
        'CtrAnnexA
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlReportType)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.CbxBusinessType)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.CbxSapSource)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.CbxMonth)
        Me.Name = "CtrAnnexA"
        Me.Size = New System.Drawing.Size(1406, 720)
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlReportType.ResumeLayout(False)
        Me.PnlReportType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbxMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RbtnBoth As RadioButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RbtnAccum As RadioButton
    Friend WithEvents CbxSapSource As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CbxBusinessType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RbtnMonthly As RadioButton
    Friend WithEvents PnlFooter As Panel
    Friend WithEvents LblStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblLoadDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnGenerate As RoundedButton
    Friend WithEvents PnlReportType As Panel
End Class
