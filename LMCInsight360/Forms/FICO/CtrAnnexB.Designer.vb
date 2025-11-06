<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrAnnexB
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
        Me.PnlReportType = New System.Windows.Forms.Panel()
        Me.RbtnBoth = New System.Windows.Forms.RadioButton()
        Me.RbtnMonthly = New System.Windows.Forms.RadioButton()
        Me.RbtnAccum = New System.Windows.Forms.RadioButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxBusinessType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxSapSource = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCompYear = New DevExpress.XtraEditors.TextEdit()
        Me.CbxCompMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CbxStatementType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LblTypeReport = New DevExpress.XtraEditors.LabelControl()
        Me.BtnGenerate = New LMCInsight360.RoundedButton()
        Me.CbxRptSheet = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.PnlReportType.SuspendLayout()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCompYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxCompMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxStatementType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxRptSheet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlReportType
        '
        Me.PnlReportType.Controls.Add(Me.RbtnBoth)
        Me.PnlReportType.Controls.Add(Me.RbtnMonthly)
        Me.PnlReportType.Controls.Add(Me.RbtnAccum)
        Me.PnlReportType.Controls.Add(Me.LabelControl6)
        Me.PnlReportType.Location = New System.Drawing.Point(49, 233)
        Me.PnlReportType.Name = "PnlReportType"
        Me.PnlReportType.Size = New System.Drawing.Size(350, 82)
        Me.PnlReportType.TabIndex = 52
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
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(50, 148)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(99, 23)
        Me.LabelControl4.TabIndex = 50
        Me.LabelControl4.Text = "End Period: *"
        '
        'CbxBusinessType
        '
        Me.CbxBusinessType.Location = New System.Drawing.Point(189, 91)
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
        Me.CbxBusinessType.TabIndex = 48
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(189, 177)
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
        Me.TxtYear.TabIndex = 45
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(189, 62)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(121, 23)
        Me.LabelControl3.TabIndex = 47
        Me.LabelControl3.Text = "Business Type: *"
        '
        'CbxSapSource
        '
        Me.CbxSapSource.Location = New System.Drawing.Point(49, 91)
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
        Me.CbxSapSource.TabIndex = 44
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(49, 62)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl1.TabIndex = 46
        Me.LabelControl1.Text = "SAP Source: *"
        '
        'CbxMonth
        '
        Me.CbxMonth.Location = New System.Drawing.Point(49, 177)
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
        Me.CbxMonth.TabIndex = 49
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(270, 148)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(162, 23)
        Me.LabelControl2.TabIndex = 55
        Me.LabelControl2.Text = "Comparison Period: *"
        '
        'TxtCompYear
        '
        Me.TxtCompYear.Location = New System.Drawing.Point(410, 177)
        Me.TxtCompYear.Name = "TxtCompYear"
        Me.TxtCompYear.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtCompYear.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtCompYear.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompYear.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtCompYear.Properties.Appearance.Options.UseBackColor = True
        Me.TxtCompYear.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtCompYear.Properties.Appearance.Options.UseFont = True
        Me.TxtCompYear.Properties.Appearance.Options.UseForeColor = True
        Me.TxtCompYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtCompYear.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtCompYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TxtCompYear.Properties.Mask.ShowPlaceHolders = False
        Me.TxtCompYear.Properties.MaxLength = 4
        Me.TxtCompYear.Size = New System.Drawing.Size(70, 30)
        Me.TxtCompYear.TabIndex = 53
        '
        'CbxCompMonth
        '
        Me.CbxCompMonth.Location = New System.Drawing.Point(270, 177)
        Me.CbxCompMonth.Name = "CbxCompMonth"
        Me.CbxCompMonth.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxCompMonth.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxCompMonth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxCompMonth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxCompMonth.Properties.Appearance.Options.UseBackColor = True
        Me.CbxCompMonth.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxCompMonth.Properties.Appearance.Options.UseFont = True
        Me.CbxCompMonth.Properties.Appearance.Options.UseForeColor = True
        Me.CbxCompMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxCompMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxCompMonth.Properties.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CbxCompMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxCompMonth.Size = New System.Drawing.Size(134, 30)
        Me.CbxCompMonth.TabIndex = 54
        '
        'CbxStatementType
        '
        Me.CbxStatementType.Location = New System.Drawing.Point(405, 91)
        Me.CbxStatementType.Name = "CbxStatementType"
        Me.CbxStatementType.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxStatementType.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxStatementType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxStatementType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxStatementType.Properties.Appearance.Options.UseBackColor = True
        Me.CbxStatementType.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxStatementType.Properties.Appearance.Options.UseFont = True
        Me.CbxStatementType.Properties.Appearance.Options.UseForeColor = True
        Me.CbxStatementType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxStatementType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxStatementType.Properties.Items.AddRange(New Object() {"", "MONTH TO MONTH", "YEAR TO YEAR"})
        Me.CbxStatementType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxStatementType.Size = New System.Drawing.Size(210, 30)
        Me.CbxStatementType.TabIndex = 57
        '
        'LblTypeReport
        '
        Me.LblTypeReport.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTypeReport.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblTypeReport.Appearance.Options.UseFont = True
        Me.LblTypeReport.Appearance.Options.UseForeColor = True
        Me.LblTypeReport.Location = New System.Drawing.Point(405, 62)
        Me.LblTypeReport.Name = "LblTypeReport"
        Me.LblTypeReport.Size = New System.Drawing.Size(136, 23)
        Me.LblTypeReport.TabIndex = 56
        Me.LblTypeReport.Text = "Statement Type: *"
        '
        'BtnGenerate
        '
        Me.BtnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.BtnGenerate.FlatAppearance.BorderSize = 0
        Me.BtnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.White
        Me.BtnGenerate.Location = New System.Drawing.Point(410, 270)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(210, 33)
        Me.BtnGenerate.TabIndex = 51
        Me.BtnGenerate.Text = "📥 Generate Report"
        Me.BtnGenerate.UseVisualStyleBackColor = False
        '
        'CbxRptSheet
        '
        Me.CbxRptSheet.Location = New System.Drawing.Point(405, 91)
        Me.CbxRptSheet.Name = "CbxRptSheet"
        Me.CbxRptSheet.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxRptSheet.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxRptSheet.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxRptSheet.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxRptSheet.Properties.Appearance.Options.UseBackColor = True
        Me.CbxRptSheet.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxRptSheet.Properties.Appearance.Options.UseFont = True
        Me.CbxRptSheet.Properties.Appearance.Options.UseForeColor = True
        Me.CbxRptSheet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxRptSheet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxRptSheet.Properties.Items.AddRange(New Object() {"", "Selling Expenses", "Administrative Expenses"})
        Me.CbxRptSheet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxRptSheet.Size = New System.Drawing.Size(210, 30)
        Me.CbxRptSheet.TabIndex = 58
        '
        'CtrAnnexB
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CbxRptSheet)
        Me.Controls.Add(Me.CbxStatementType)
        Me.Controls.Add(Me.LblTypeReport)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtCompYear)
        Me.Controls.Add(Me.CbxCompMonth)
        Me.Controls.Add(Me.PnlReportType)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.CbxBusinessType)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.CbxSapSource)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.CbxMonth)
        Me.Name = "CtrAnnexB"
        Me.Size = New System.Drawing.Size(1270, 765)
        Me.PnlReportType.ResumeLayout(False)
        Me.PnlReportType.PerformLayout()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCompYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxCompMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxStatementType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxRptSheet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlReportType As Panel
    Friend WithEvents RbtnBoth As RadioButton
    Friend WithEvents RbtnMonthly As RadioButton
    Friend WithEvents RbtnAccum As RadioButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnGenerate As RoundedButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxBusinessType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxSapSource As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCompYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CbxCompMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CbxStatementType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LblTypeReport As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxRptSheet As DevExpress.XtraEditors.ComboBoxEdit
End Class
