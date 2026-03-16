<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtrUserAccess
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
        Me.PnlFooter = New DevExpress.XtraEditors.SidePanel()
        Me.lblActiveSession = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lblActive = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDept = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnEdtUserID = New DevExpress.XtraEditors.ButtonEdit()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TxtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.RbtnInactive = New System.Windows.Forms.RadioButton()
        Me.RbtnActive = New System.Windows.Forms.RadioButton()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.SidePanel1 = New DevExpress.XtraEditors.SidePanel()
        Me.SidePanel3 = New DevExpress.XtraEditors.SidePanel()
        Me.BtnSave = New LMCInsight360.RoundedButton()
        Me.PnlFooter.SuspendLayout()
        CType(Me.TxtDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEdtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SidePanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFooter
        '
        Me.PnlFooter.BorderThickness = 0
        Me.PnlFooter.Controls.Add(Me.lblActiveSession)
        Me.PnlFooter.Controls.Add(Me.LabelControl6)
        Me.PnlFooter.Controls.Add(Me.lblActive)
        Me.PnlFooter.Controls.Add(Me.LabelControl7)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 531)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(940, 38)
        Me.PnlFooter.TabIndex = 85
        Me.PnlFooter.Text = "SidePanel1"
        '
        'lblActiveSession
        '
        Me.lblActiveSession.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.lblActiveSession.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblActiveSession.Appearance.Options.UseFont = True
        Me.lblActiveSession.Appearance.Options.UseForeColor = True
        Me.lblActiveSession.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblActiveSession.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblActiveSession.Location = New System.Drawing.Point(348, 0)
        Me.lblActiveSession.Name = "lblActiveSession"
        Me.lblActiveSession.Size = New System.Drawing.Size(129, 38)
        Me.lblActiveSession.TabIndex = 69
        Me.lblActiveSession.Text = "Online Offline"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl6.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl6.Location = New System.Drawing.Point(249, 0)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(99, 38)
        Me.LabelControl6.TabIndex = 70
        Me.LabelControl6.Text = "User Status:"
        '
        'lblActive
        '
        Me.lblActive.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.lblActive.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblActive.Appearance.Options.UseFont = True
        Me.lblActive.Appearance.Options.UseForeColor = True
        Me.lblActive.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblActive.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblActive.Location = New System.Drawing.Point(135, 0)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(114, 38)
        Me.lblActive.TabIndex = 68
        Me.lblActive.Text = "Active Session"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl7.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(135, 38)
        Me.LabelControl7.TabIndex = 71
        Me.LabelControl7.Text = " Account Status:"
        '
        'TxtDept
        '
        Me.TxtDept.Location = New System.Drawing.Point(124, 124)
        Me.TxtDept.Name = "TxtDept"
        Me.TxtDept.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtDept.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtDept.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDept.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtDept.Properties.Appearance.Options.UseBackColor = True
        Me.TxtDept.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtDept.Properties.Appearance.Options.UseFont = True
        Me.TxtDept.Properties.Appearance.Options.UseForeColor = True
        Me.TxtDept.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtDept.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtDept.Properties.Mask.ShowPlaceHolders = False
        Me.TxtDept.Properties.MaxLength = 50
        Me.TxtDept.Properties.ReadOnly = True
        Me.TxtDept.Size = New System.Drawing.Size(257, 30)
        Me.TxtDept.TabIndex = 98
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.Location = New System.Drawing.Point(13, 127)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(96, 23)
        Me.LabelControl8.TabIndex = 97
        Me.LabelControl8.Text = "Department:"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(124, 85)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtName.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtName.Properties.Appearance.Options.UseBackColor = True
        Me.TxtName.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtName.Properties.Appearance.Options.UseFont = True
        Me.TxtName.Properties.Appearance.Options.UseForeColor = True
        Me.TxtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtName.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtName.Properties.Mask.ShowPlaceHolders = False
        Me.TxtName.Properties.MaxLength = 50
        Me.TxtName.Properties.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(257, 30)
        Me.TxtName.TabIndex = 95
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(58, 88)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(50, 23)
        Me.LabelControl5.TabIndex = 94
        Me.LabelControl5.Text = "Name:"
        '
        'TxtUserName
        '
        Me.TxtUserName.Location = New System.Drawing.Point(125, 42)
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtUserName.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtUserName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUserName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtUserName.Properties.Appearance.Options.UseBackColor = True
        Me.TxtUserName.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtUserName.Properties.Appearance.Options.UseFont = True
        Me.TxtUserName.Properties.Appearance.Options.UseForeColor = True
        Me.TxtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtUserName.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtUserName.Properties.Mask.ShowPlaceHolders = False
        Me.TxtUserName.Properties.MaxLength = 50
        Me.TxtUserName.Properties.ReadOnly = True
        Me.TxtUserName.Size = New System.Drawing.Size(257, 30)
        Me.TxtUserName.TabIndex = 91
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(29, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(81, 23)
        Me.LabelControl2.TabIndex = 88
        Me.LabelControl2.Text = "Username:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(50, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 23)
        Me.LabelControl1.TabIndex = 87
        Me.LabelControl1.Text = "User ID:"
        '
        'BtnEdtUserID
        '
        Me.BtnEdtUserID.Location = New System.Drawing.Point(125, 2)
        Me.BtnEdtUserID.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnEdtUserID.Name = "BtnEdtUserID"
        Me.BtnEdtUserID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.BtnEdtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.BtnEdtUserID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.BtnEdtUserID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnEdtUserID.Properties.Appearance.Options.UseBackColor = True
        Me.BtnEdtUserID.Properties.Appearance.Options.UseBorderColor = True
        Me.BtnEdtUserID.Properties.Appearance.Options.UseFont = True
        Me.BtnEdtUserID.Properties.Appearance.Options.UseForeColor = True
        Me.BtnEdtUserID.Properties.AppearanceDisabled.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.BtnEdtUserID.Properties.AppearanceDisabled.Options.UseBorderColor = True
        Me.BtnEdtUserID.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.BtnEdtUserID.Properties.AppearanceFocused.Options.UseBorderColor = True
        Me.BtnEdtUserID.Properties.AppearanceReadOnly.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.BtnEdtUserID.Properties.AppearanceReadOnly.Options.UseBorderColor = True
        Me.BtnEdtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.BtnEdtUserID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BtnEdtUserID.Properties.ReadOnly = True
        Me.BtnEdtUserID.Size = New System.Drawing.Size(257, 30)
        Me.BtnEdtUserID.TabIndex = 86
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TreeView1.Location = New System.Drawing.Point(404, 23)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(536, 508)
        Me.TreeView1.TabIndex = 99
        '
        'TxtCreatedBy
        '
        Me.TxtCreatedBy.Location = New System.Drawing.Point(124, 164)
        Me.TxtCreatedBy.Name = "TxtCreatedBy"
        Me.TxtCreatedBy.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtCreatedBy.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtCreatedBy.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCreatedBy.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtCreatedBy.Properties.Appearance.Options.UseBackColor = True
        Me.TxtCreatedBy.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtCreatedBy.Properties.Appearance.Options.UseFont = True
        Me.TxtCreatedBy.Properties.Appearance.Options.UseForeColor = True
        Me.TxtCreatedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtCreatedBy.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtCreatedBy.Properties.Mask.ShowPlaceHolders = False
        Me.TxtCreatedBy.Properties.MaxLength = 50
        Me.TxtCreatedBy.Properties.ReadOnly = True
        Me.TxtCreatedBy.Size = New System.Drawing.Size(257, 30)
        Me.TxtCreatedBy.TabIndex = 101
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(21, 167)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(87, 23)
        Me.LabelControl3.TabIndex = 100
        Me.LabelControl3.Text = "Created By:"
        '
        'TxtCreatedDate
        '
        Me.TxtCreatedDate.Location = New System.Drawing.Point(124, 202)
        Me.TxtCreatedDate.Name = "TxtCreatedDate"
        Me.TxtCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtCreatedDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtCreatedDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtCreatedDate.Properties.Appearance.Options.UseBackColor = True
        Me.TxtCreatedDate.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtCreatedDate.Properties.Appearance.Options.UseFont = True
        Me.TxtCreatedDate.Properties.Appearance.Options.UseForeColor = True
        Me.TxtCreatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtCreatedDate.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtCreatedDate.Properties.Mask.ShowPlaceHolders = False
        Me.TxtCreatedDate.Properties.MaxLength = 50
        Me.TxtCreatedDate.Properties.ReadOnly = True
        Me.TxtCreatedDate.Size = New System.Drawing.Size(257, 30)
        Me.TxtCreatedDate.TabIndex = 103
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(5, 205)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(105, 23)
        Me.LabelControl4.TabIndex = 102
        Me.LabelControl4.Text = "Created Date:"
        '
        'RbtnInactive
        '
        Me.RbtnInactive.AutoSize = True
        Me.RbtnInactive.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.RbtnInactive.Location = New System.Drawing.Point(249, 251)
        Me.RbtnInactive.Name = "RbtnInactive"
        Me.RbtnInactive.Size = New System.Drawing.Size(90, 27)
        Me.RbtnInactive.TabIndex = 106
        Me.RbtnInactive.Text = "Inactive"
        Me.RbtnInactive.UseVisualStyleBackColor = True
        '
        'RbtnActive
        '
        Me.RbtnActive.AutoSize = True
        Me.RbtnActive.Checked = True
        Me.RbtnActive.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.RbtnActive.Location = New System.Drawing.Point(144, 251)
        Me.RbtnActive.Name = "RbtnActive"
        Me.RbtnActive.Size = New System.Drawing.Size(77, 27)
        Me.RbtnActive.TabIndex = 105
        Me.RbtnActive.TabStop = True
        Me.RbtnActive.Text = "Active"
        Me.RbtnActive.UseVisualStyleBackColor = True
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(125, 246)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Size = New System.Drawing.Size(256, 36)
        Me.RadioGroup1.TabIndex = 104
        '
        'SidePanel1
        '
        Me.SidePanel1.BorderThickness = 0
        Me.SidePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SidePanel1.Location = New System.Drawing.Point(0, 0)
        Me.SidePanel1.Name = "SidePanel1"
        Me.SidePanel1.Size = New System.Drawing.Size(940, 23)
        Me.SidePanel1.TabIndex = 107
        Me.SidePanel1.Text = "SidePanel1"
        '
        'SidePanel3
        '
        Me.SidePanel3.Controls.Add(Me.BtnSave)
        Me.SidePanel3.Controls.Add(Me.BtnEdtUserID)
        Me.SidePanel3.Controls.Add(Me.LabelControl1)
        Me.SidePanel3.Controls.Add(Me.RbtnInactive)
        Me.SidePanel3.Controls.Add(Me.LabelControl2)
        Me.SidePanel3.Controls.Add(Me.RbtnActive)
        Me.SidePanel3.Controls.Add(Me.TxtUserName)
        Me.SidePanel3.Controls.Add(Me.RadioGroup1)
        Me.SidePanel3.Controls.Add(Me.LabelControl5)
        Me.SidePanel3.Controls.Add(Me.TxtCreatedDate)
        Me.SidePanel3.Controls.Add(Me.TxtName)
        Me.SidePanel3.Controls.Add(Me.LabelControl4)
        Me.SidePanel3.Controls.Add(Me.LabelControl8)
        Me.SidePanel3.Controls.Add(Me.TxtCreatedBy)
        Me.SidePanel3.Controls.Add(Me.TxtDept)
        Me.SidePanel3.Controls.Add(Me.LabelControl3)
        Me.SidePanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SidePanel3.Location = New System.Drawing.Point(0, 23)
        Me.SidePanel3.Name = "SidePanel3"
        Me.SidePanel3.Size = New System.Drawing.Size(404, 508)
        Me.SidePanel3.TabIndex = 109
        Me.SidePanel3.Text = "SidePanel3"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(255, 304)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(126, 30)
        Me.BtnSave.TabIndex = 96
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'CtrUserAccess
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.SidePanel3)
        Me.Controls.Add(Me.SidePanel1)
        Me.Controls.Add(Me.PnlFooter)
        Me.Name = "CtrUserAccess"
        Me.Size = New System.Drawing.Size(940, 569)
        Me.PnlFooter.ResumeLayout(False)
        CType(Me.TxtDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEdtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SidePanel3.ResumeLayout(False)
        Me.SidePanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFooter As DevExpress.XtraEditors.SidePanel
    Friend WithEvents lblActiveSession As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblActive As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDept As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSave As RoundedButton
    Friend WithEvents TxtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnEdtUserID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TxtCreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCreatedDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RbtnInactive As RadioButton
    Friend WithEvents RbtnActive As RadioButton
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents SidePanel1 As DevExpress.XtraEditors.SidePanel
    Friend WithEvents SidePanel3 As DevExpress.XtraEditors.SidePanel
End Class
