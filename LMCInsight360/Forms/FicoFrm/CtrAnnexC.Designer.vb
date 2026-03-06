<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrAnnexC
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
        Me.LblCompPrd = New DevExpress.XtraEditors.LabelControl()
        Me.TxtEndYear = New DevExpress.XtraEditors.TextEdit()
        Me.CbxEndMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxBusinessType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtStrYear = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxSapSource = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CbxStrMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ChkBusUnit = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnGenerate = New LMCInsight360.RoundedButton()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.LblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.LblLoadDate = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TxtEndYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxEndMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStrYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxStrMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkBusUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblCompPrd
        '
        Me.LblCompPrd.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompPrd.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblCompPrd.Appearance.Options.UseFont = True
        Me.LblCompPrd.Appearance.Options.UseForeColor = True
        Me.LblCompPrd.Location = New System.Drawing.Point(49, 138)
        Me.LblCompPrd.Name = "LblCompPrd"
        Me.LblCompPrd.Size = New System.Drawing.Size(106, 23)
        Me.LblCompPrd.TabIndex = 71
        Me.LblCompPrd.Text = "Start Period: *"
        '
        'TxtEndYear
        '
        Me.TxtEndYear.Location = New System.Drawing.Point(410, 167)
        Me.TxtEndYear.Name = "TxtEndYear"
        Me.TxtEndYear.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtEndYear.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtEndYear.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEndYear.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtEndYear.Properties.Appearance.Options.UseBackColor = True
        Me.TxtEndYear.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtEndYear.Properties.Appearance.Options.UseFont = True
        Me.TxtEndYear.Properties.Appearance.Options.UseForeColor = True
        Me.TxtEndYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtEndYear.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtEndYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TxtEndYear.Properties.Mask.ShowPlaceHolders = False
        Me.TxtEndYear.Properties.MaxLength = 4
        Me.TxtEndYear.Size = New System.Drawing.Size(70, 30)
        Me.TxtEndYear.TabIndex = 69
        '
        'CbxEndMonth
        '
        Me.CbxEndMonth.Location = New System.Drawing.Point(270, 167)
        Me.CbxEndMonth.Name = "CbxEndMonth"
        Me.CbxEndMonth.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxEndMonth.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxEndMonth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxEndMonth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxEndMonth.Properties.Appearance.Options.UseBackColor = True
        Me.CbxEndMonth.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxEndMonth.Properties.Appearance.Options.UseFont = True
        Me.CbxEndMonth.Properties.Appearance.Options.UseForeColor = True
        Me.CbxEndMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxEndMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxEndMonth.Properties.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CbxEndMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxEndMonth.Size = New System.Drawing.Size(134, 30)
        Me.CbxEndMonth.TabIndex = 70
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(270, 138)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(99, 23)
        Me.LabelControl4.TabIndex = 66
        Me.LabelControl4.Text = "End Period: *"
        '
        'CbxBusinessType
        '
        Me.CbxBusinessType.Location = New System.Drawing.Point(189, 81)
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
        Me.CbxBusinessType.TabIndex = 64
        '
        'TxtStrYear
        '
        Me.TxtStrYear.Location = New System.Drawing.Point(189, 167)
        Me.TxtStrYear.Name = "TxtStrYear"
        Me.TxtStrYear.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtStrYear.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtStrYear.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStrYear.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtStrYear.Properties.Appearance.Options.UseBackColor = True
        Me.TxtStrYear.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtStrYear.Properties.Appearance.Options.UseFont = True
        Me.TxtStrYear.Properties.Appearance.Options.UseForeColor = True
        Me.TxtStrYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtStrYear.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtStrYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.TxtStrYear.Properties.Mask.ShowPlaceHolders = False
        Me.TxtStrYear.Properties.MaxLength = 4
        Me.TxtStrYear.Size = New System.Drawing.Size(70, 30)
        Me.TxtStrYear.TabIndex = 61
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(189, 52)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(121, 23)
        Me.LabelControl3.TabIndex = 63
        Me.LabelControl3.Text = "Business Type: *"
        '
        'CbxSapSource
        '
        Me.CbxSapSource.Location = New System.Drawing.Point(49, 81)
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
        Me.CbxSapSource.TabIndex = 60
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(49, 52)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl1.TabIndex = 62
        Me.LabelControl1.Text = "SAP Source: *"
        '
        'CbxStrMonth
        '
        Me.CbxStrMonth.Location = New System.Drawing.Point(49, 167)
        Me.CbxStrMonth.Name = "CbxStrMonth"
        Me.CbxStrMonth.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxStrMonth.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxStrMonth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxStrMonth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxStrMonth.Properties.Appearance.Options.UseBackColor = True
        Me.CbxStrMonth.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxStrMonth.Properties.Appearance.Options.UseFont = True
        Me.CbxStrMonth.Properties.Appearance.Options.UseForeColor = True
        Me.CbxStrMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxStrMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxStrMonth.Properties.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CbxStrMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxStrMonth.Size = New System.Drawing.Size(134, 30)
        Me.CbxStrMonth.TabIndex = 65
        '
        'ChkBusUnit
        '
        Me.ChkBusUnit.Location = New System.Drawing.Point(410, 82)
        Me.ChkBusUnit.Name = "ChkBusUnit"
        Me.ChkBusUnit.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.ChkBusUnit.Properties.Appearance.Options.UseFont = True
        Me.ChkBusUnit.Properties.Caption = "Gen. Per Business Unit"
        Me.ChkBusUnit.Size = New System.Drawing.Size(219, 27)
        Me.ChkBusUnit.TabIndex = 72
        '
        'BtnGenerate
        '
        Me.BtnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnGenerate.FlatAppearance.BorderSize = 0
        Me.BtnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.White
        Me.BtnGenerate.Location = New System.Drawing.Point(270, 235)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(210, 33)
        Me.BtnGenerate.TabIndex = 67
        Me.BtnGenerate.Text = "📥 Generate Report"
        Me.BtnGenerate.UseVisualStyleBackColor = False
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.LblStatus)
        Me.PnlFooter.Controls.Add(Me.LblLoadDate)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 608)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(1199, 36)
        Me.PnlFooter.TabIndex = 73
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
        'CtrAnnexC
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.ChkBusUnit)
        Me.Controls.Add(Me.LblCompPrd)
        Me.Controls.Add(Me.TxtEndYear)
        Me.Controls.Add(Me.CbxEndMonth)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.CbxBusinessType)
        Me.Controls.Add(Me.TxtStrYear)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.CbxSapSource)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.CbxStrMonth)
        Me.Name = "CtrAnnexC"
        Me.Size = New System.Drawing.Size(1199, 644)
        CType(Me.TxtEndYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxEndMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxBusinessType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStrYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxSapSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxStrMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkBusUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblCompPrd As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtEndYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CbxEndMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BtnGenerate As RoundedButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxBusinessType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtStrYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxSapSource As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CbxStrMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ChkBusUnit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PnlFooter As Panel
    Friend WithEvents LblStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblLoadDate As DevExpress.XtraEditors.LabelControl
End Class
