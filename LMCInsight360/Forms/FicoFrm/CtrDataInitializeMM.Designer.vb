<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrDataInitializeMM
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnBrowse = New LMCInsight360.RoundedButton()
        Me.BtnUpload = New LMCInsight360.RoundedButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TxtFilePath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnSave = New LMCInsight360.RoundedButton()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.CbxMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CbxOrigin = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CbxPrfitCtr = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtAmt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnNew = New LMCInsight360.RoundedButton()
        Me.BtnDelete = New LMCInsight360.RoundedButton()
        Me.SidePanel1 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel2 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel3 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel4 = New DevExpress.XtraEditors.SidePanel()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxOrigin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxPrfitCtr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SidePanel1.SuspendLayout()
        Me.SidePanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.BtnBrowse.FlatAppearance.BorderSize = 0
        Me.BtnBrowse.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowse.ForeColor = System.Drawing.Color.White
        Me.BtnBrowse.Location = New System.Drawing.Point(690, 10)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(142, 30)
        Me.BtnBrowse.TabIndex = 55
        Me.BtnBrowse.Text = "Browse"
        Me.BtnBrowse.UseVisualStyleBackColor = False
        '
        'BtnUpload
        '
        Me.BtnUpload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpload.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnUpload.FlatAppearance.BorderSize = 0
        Me.BtnUpload.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.ForeColor = System.Drawing.Color.White
        Me.BtnUpload.Location = New System.Drawing.Point(837, 10)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(134, 30)
        Me.BtnUpload.TabIndex = 57
        Me.BtnUpload.Text = "Upload"
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(20, 71)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(951, 462)
        Me.GridControl1.TabIndex = 58
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
        'TxtFilePath
        '
        Me.TxtFilePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFilePath.Location = New System.Drawing.Point(18, 10)
        Me.TxtFilePath.Multiline = True
        Me.TxtFilePath.Name = "TxtFilePath"
        Me.TxtFilePath.Size = New System.Drawing.Size(666, 30)
        Me.TxtFilePath.TabIndex = 59
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(774, 27)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 65
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(428, 29)
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
        Me.TxtYear.Properties.Mask.EditMask = "d"
        Me.TxtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtYear.Properties.MaxLength = 4
        Me.TxtYear.Size = New System.Drawing.Size(66, 30)
        Me.TxtYear.TabIndex = 68
        '
        'CbxMonth
        '
        Me.CbxMonth.Location = New System.Drawing.Point(287, 29)
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
        Me.CbxMonth.Size = New System.Drawing.Size(128, 30)
        Me.CbxMonth.TabIndex = 70
        '
        'CbxOrigin
        '
        Me.CbxOrigin.Location = New System.Drawing.Point(18, 29)
        Me.CbxOrigin.Name = "CbxOrigin"
        Me.CbxOrigin.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxOrigin.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxOrigin.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxOrigin.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxOrigin.Properties.Appearance.Options.UseBackColor = True
        Me.CbxOrigin.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxOrigin.Properties.Appearance.Options.UseFont = True
        Me.CbxOrigin.Properties.Appearance.Options.UseForeColor = True
        Me.CbxOrigin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxOrigin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxOrigin.Properties.Items.AddRange(New Object() {"CAS", "Reserved"})
        Me.CbxOrigin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxOrigin.Size = New System.Drawing.Size(115, 30)
        Me.CbxOrigin.TabIndex = 71
        '
        'CbxPrfitCtr
        '
        Me.CbxPrfitCtr.Location = New System.Drawing.Point(143, 29)
        Me.CbxPrfitCtr.Name = "CbxPrfitCtr"
        Me.CbxPrfitCtr.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CbxPrfitCtr.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.CbxPrfitCtr.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxPrfitCtr.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxPrfitCtr.Properties.Appearance.Options.UseBackColor = True
        Me.CbxPrfitCtr.Properties.Appearance.Options.UseBorderColor = True
        Me.CbxPrfitCtr.Properties.Appearance.Options.UseFont = True
        Me.CbxPrfitCtr.Properties.Appearance.Options.UseForeColor = True
        Me.CbxPrfitCtr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CbxPrfitCtr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CbxPrfitCtr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CbxPrfitCtr.Size = New System.Drawing.Size(134, 30)
        Me.CbxPrfitCtr.TabIndex = 72
        '
        'TxtAmt
        '
        Me.TxtAmt.Location = New System.Drawing.Point(505, 29)
        Me.TxtAmt.Name = "TxtAmt"
        Me.TxtAmt.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtAmt.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtAmt.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.TxtAmt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtAmt.Properties.Appearance.Options.UseBackColor = True
        Me.TxtAmt.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtAmt.Properties.Appearance.Options.UseFont = True
        Me.TxtAmt.Properties.Appearance.Options.UseForeColor = True
        Me.TxtAmt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtAmt.Properties.Mask.EditMask = "n2"
        Me.TxtAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmt.Size = New System.Drawing.Size(163, 30)
        Me.TxtAmt.TabIndex = 73
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(18, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl3.TabIndex = 74
        Me.LabelControl3.Text = "SAP Source: *"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(143, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(113, 23)
        Me.LabelControl1.TabIndex = 75
        Me.LabelControl1.Text = "Profit Center: *"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(287, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 23)
        Me.LabelControl2.TabIndex = 76
        Me.LabelControl2.Text = "Month: *"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(428, 8)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(49, 23)
        Me.LabelControl4.TabIndex = 77
        Me.LabelControl4.Text = "Year: *"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(505, 8)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(78, 23)
        Me.LabelControl5.TabIndex = 78
        Me.LabelControl5.Text = "Amount: *"
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.White
        Me.BtnNew.Location = New System.Drawing.Point(676, 27)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(95, 30)
        Me.BtnNew.TabIndex = 79
        Me.BtnNew.Text = "Add"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.Location = New System.Drawing.Point(873, 27)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(95, 30)
        Me.BtnDelete.TabIndex = 80
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'SidePanel1
        '
        Me.SidePanel1.AllowResize = False
        Me.SidePanel1.BorderThickness = 0
        Me.SidePanel1.Controls.Add(Me.TxtFilePath)
        Me.SidePanel1.Controls.Add(Me.BtnBrowse)
        Me.SidePanel1.Controls.Add(Me.BtnUpload)
        Me.SidePanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SidePanel1.Location = New System.Drawing.Point(0, 533)
        Me.SidePanel1.Name = "SidePanel1"
        Me.SidePanel1.Size = New System.Drawing.Size(991, 63)
        Me.SidePanel1.TabIndex = 81
        Me.SidePanel1.Text = "SidePanel1"
        '
        'SidePanel2
        '
        Me.SidePanel2.AllowResize = False
        Me.SidePanel2.BorderThickness = 0
        Me.SidePanel2.Controls.Add(Me.TxtAmt)
        Me.SidePanel2.Controls.Add(Me.BtnDelete)
        Me.SidePanel2.Controls.Add(Me.BtnSave)
        Me.SidePanel2.Controls.Add(Me.TxtYear)
        Me.SidePanel2.Controls.Add(Me.CbxMonth)
        Me.SidePanel2.Controls.Add(Me.BtnNew)
        Me.SidePanel2.Controls.Add(Me.CbxOrigin)
        Me.SidePanel2.Controls.Add(Me.LabelControl5)
        Me.SidePanel2.Controls.Add(Me.CbxPrfitCtr)
        Me.SidePanel2.Controls.Add(Me.LabelControl4)
        Me.SidePanel2.Controls.Add(Me.LabelControl2)
        Me.SidePanel2.Controls.Add(Me.LabelControl3)
        Me.SidePanel2.Controls.Add(Me.LabelControl1)
        Me.SidePanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SidePanel2.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel2.Name = "SidePanel2"
        Me.SidePanel2.Size = New System.Drawing.Size(991, 71)
        Me.SidePanel2.TabIndex = 82
        Me.SidePanel2.Text = "SidePanel2"
        '
        'SidePanel3
        '
        Me.SidePanel3.AllowResize = False
        Me.SidePanel3.BorderThickness = 0
        Me.SidePanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SidePanel3.Location = New System.Drawing.Point(971, 71)
        Me.SidePanel3.Name = "SidePanel3"
        Me.SidePanel3.Size = New System.Drawing.Size(20, 462)
        Me.SidePanel3.TabIndex = 83
        Me.SidePanel3.Text = "SidePanel3"
        '
        'SidePanel4
        '
        Me.SidePanel4.AllowResize = False
        Me.SidePanel4.BorderThickness = 0
        Me.SidePanel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel4.Location = New System.Drawing.Point(0, 71)
        Me.SidePanel4.Name = "SidePanel4"
        Me.SidePanel4.Size = New System.Drawing.Size(20, 462)
        Me.SidePanel4.TabIndex = 84
        Me.SidePanel4.Text = "SidePanel4"
        '
        'CtrDataInitializeMM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SidePanel4)
        Me.Controls.Add(Me.SidePanel3)
        Me.Controls.Add(Me.SidePanel2)
        Me.Controls.Add(Me.SidePanel1)
        Me.Name = "CtrDataInitializeMM"
        Me.Size = New System.Drawing.Size(991, 596)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxOrigin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxPrfitCtr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SidePanel1.ResumeLayout(False)
        Me.SidePanel1.PerformLayout()
        Me.SidePanel2.ResumeLayout(False)
        Me.SidePanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnBrowse As RoundedButton
    Friend WithEvents BtnUpload As RoundedButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtFilePath As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BtnSave As RoundedButton
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CbxMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CbxOrigin As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents CbxPrfitCtr As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtAmt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnNew As RoundedButton
    Friend WithEvents BtnDelete As RoundedButton
    Friend WithEvents SidePanel1 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel2 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel3 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel4 As DevExpress.XtraEditors.SidePanel
End Class
