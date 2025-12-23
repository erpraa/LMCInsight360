<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.RPnlLeft = New LMCInsight360.RoundedPanel()
        Me.PnlSelectConn = New System.Windows.Forms.Panel()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAddConnection = New System.Windows.Forms.Label()
        Me.ChkShowPass = New System.Windows.Forms.CheckBox()
        Me.LblLinkDatabase = New System.Windows.Forms.LinkLabel()
        Me.LblClose = New System.Windows.Forms.Label()
        Me.LblSignIn = New System.Windows.Forms.Label()
        Me.LblWelcome = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.BtnLogin = New LMCInsight360.RoundedButton()
        Me.RPnlRight = New LMCInsight360.RoundedPanel()
        Me.LblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.LblInsight = New System.Windows.Forms.Label()
        Me.LblLmc = New System.Windows.Forms.Label()
        Me.LblCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RPnlLeft.SuspendLayout()
        Me.PnlSelectConn.SuspendLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RPnlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'RPnlLeft
        '
        Me.RPnlLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.RPnlLeft.Controls.Add(Me.PnlSelectConn)
        Me.RPnlLeft.Controls.Add(Me.ChkShowPass)
        Me.RPnlLeft.Controls.Add(Me.LblLinkDatabase)
        Me.RPnlLeft.Controls.Add(Me.LblClose)
        Me.RPnlLeft.Controls.Add(Me.LblSignIn)
        Me.RPnlLeft.Controls.Add(Me.LblWelcome)
        Me.RPnlLeft.Controls.Add(Me.Panel1)
        Me.RPnlLeft.Controls.Add(Me.BtnLogin)
        Me.RPnlLeft.CornerRadius = 10
        Me.RPnlLeft.Dock = System.Windows.Forms.DockStyle.Right
        Me.RPnlLeft.Location = New System.Drawing.Point(270, 0)
        Me.RPnlLeft.Name = "RPnlLeft"
        Me.RPnlLeft.Size = New System.Drawing.Size(380, 500)
        Me.RPnlLeft.TabIndex = 49
        '
        'PnlSelectConn
        '
        Me.PnlSelectConn.Controls.Add(Me.ComboBoxEdit1)
        Me.PnlSelectConn.Controls.Add(Me.Label1)
        Me.PnlSelectConn.Controls.Add(Me.lblAddConnection)
        Me.PnlSelectConn.Location = New System.Drawing.Point(36, 409)
        Me.PnlSelectConn.Name = "PnlSelectConn"
        Me.PnlSelectConn.Size = New System.Drawing.Size(310, 43)
        Me.PnlSelectConn.TabIndex = 59
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(36, 0)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxEdit1.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ComboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(235, 30)
        Me.ComboBoxEdit1.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.Label1.Location = New System.Drawing.Point(271, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 28)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "🌐"
        '
        'lblAddConnection
        '
        Me.lblAddConnection.AutoSize = True
        Me.lblAddConnection.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblAddConnection.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddConnection.ForeColor = System.Drawing.Color.Red
        Me.lblAddConnection.Location = New System.Drawing.Point(0, 0)
        Me.lblAddConnection.Name = "lblAddConnection"
        Me.lblAddConnection.Size = New System.Drawing.Size(36, 32)
        Me.lblAddConnection.TabIndex = 28
        Me.lblAddConnection.Text = "✚"
        '
        'ChkShowPass
        '
        Me.ChkShowPass.AutoSize = True
        Me.ChkShowPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ChkShowPass.Location = New System.Drawing.Point(60, 270)
        Me.ChkShowPass.Name = "ChkShowPass"
        Me.ChkShowPass.Size = New System.Drawing.Size(126, 23)
        Me.ChkShowPass.TabIndex = 58
        Me.ChkShowPass.Text = "Show Password"
        Me.ChkShowPass.UseVisualStyleBackColor = True
        '
        'LblLinkDatabase
        '
        Me.LblLinkDatabase.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.LblLinkDatabase.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLinkDatabase.LinkColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.LblLinkDatabase.Location = New System.Drawing.Point(92, 360)
        Me.LblLinkDatabase.Name = "LblLinkDatabase"
        Me.LblLinkDatabase.Size = New System.Drawing.Size(189, 24)
        Me.LblLinkDatabase.TabIndex = 56
        Me.LblLinkDatabase.TabStop = True
        Me.LblLinkDatabase.Text = "🔗 Connect to Database"
        Me.LblLinkDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClose
        '
        Me.LblClose.AutoSize = True
        Me.LblClose.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClose.ForeColor = System.Drawing.Color.Red
        Me.LblClose.Location = New System.Drawing.Point(343, 5)
        Me.LblClose.Name = "LblClose"
        Me.LblClose.Size = New System.Drawing.Size(34, 25)
        Me.LblClose.TabIndex = 54
        Me.LblClose.Text = "❌️"
        Me.LblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSignIn
        '
        Me.LblSignIn.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSignIn.ForeColor = System.Drawing.Color.Gray
        Me.LblSignIn.Location = New System.Drawing.Point(53, 124)
        Me.LblSignIn.Name = "LblSignIn"
        Me.LblSignIn.Size = New System.Drawing.Size(280, 23)
        Me.LblSignIn.TabIndex = 53
        Me.LblSignIn.Text = "Sign In To Continue"
        Me.LblSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblWelcome
        '
        Me.LblWelcome.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.LblWelcome.Location = New System.Drawing.Point(53, 74)
        Me.LblWelcome.Name = "LblWelcome"
        Me.LblWelcome.Size = New System.Drawing.Size(280, 40)
        Me.LblWelcome.TabIndex = 52
        Me.LblWelcome.Text = "Welcome!"
        Me.LblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.TxtUsername)
        Me.Panel1.Controls.Add(Me.TxtPassword)
        Me.Panel1.Location = New System.Drawing.Point(53, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 102)
        Me.Panel1.TabIndex = 49
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(47, 10)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtUsername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsername.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.TxtUsername.Properties.Appearance.Options.UseBackColor = True
        Me.TxtUsername.Properties.Appearance.Options.UseFont = True
        Me.TxtUsername.Properties.Appearance.Options.UseForeColor = True
        Me.TxtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.TxtUsername.Size = New System.Drawing.Size(222, 28)
        Me.TxtUsername.TabIndex = 57
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(47, 65)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.TxtPassword.Properties.Appearance.Options.UseBackColor = True
        Me.TxtPassword.Properties.Appearance.Options.UseFont = True
        Me.TxtPassword.Properties.Appearance.Options.UseForeColor = True
        Me.TxtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.TxtPassword.Size = New System.Drawing.Size(222, 28)
        Me.TxtPassword.TabIndex = 58
        '
        'BtnLogin
        '
        Me.BtnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnLogin.FlatAppearance.BorderSize = 0
        Me.BtnLogin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogin.ForeColor = System.Drawing.Color.White
        Me.BtnLogin.Location = New System.Drawing.Point(120, 311)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(140, 35)
        Me.BtnLogin.TabIndex = 46
        Me.BtnLogin.Text = "LOGIN"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'RPnlRight
        '
        Me.RPnlRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.RPnlRight.Controls.Add(Me.LblVersion)
        Me.RPnlRight.Controls.Add(Me.LblInsight)
        Me.RPnlRight.Controls.Add(Me.LblLmc)
        Me.RPnlRight.Controls.Add(Me.LblCopyright)
        Me.RPnlRight.Controls.Add(Me.Panel2)
        Me.RPnlRight.CornerRadius = 10
        Me.RPnlRight.Dock = System.Windows.Forms.DockStyle.Left
        Me.RPnlRight.Location = New System.Drawing.Point(0, 0)
        Me.RPnlRight.Name = "RPnlRight"
        Me.RPnlRight.Size = New System.Drawing.Size(285, 500)
        Me.RPnlRight.TabIndex = 50
        '
        'LblVersion
        '
        Me.LblVersion.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVersion.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LblVersion.Appearance.Options.UseFont = True
        Me.LblVersion.Appearance.Options.UseForeColor = True
        Me.LblVersion.Appearance.Options.UseTextOptions = True
        Me.LblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblVersion.Location = New System.Drawing.Point(0, 256)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(271, 23)
        Me.LblVersion.TabIndex = 56
        Me.LblVersion.Text = "Version: 0.0.0.0"
        '
        'LblInsight
        '
        Me.LblInsight.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInsight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.LblInsight.Location = New System.Drawing.Point(0, 224)
        Me.LblInsight.Name = "LblInsight"
        Me.LblInsight.Size = New System.Drawing.Size(271, 26)
        Me.LblInsight.TabIndex = 55
        Me.LblInsight.Text = "Insight360"
        Me.LblInsight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblLmc
        '
        Me.LblLmc.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLmc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.LblLmc.Location = New System.Drawing.Point(0, 197)
        Me.LblLmc.Name = "LblLmc"
        Me.LblLmc.Size = New System.Drawing.Size(271, 26)
        Me.LblLmc.TabIndex = 54
        Me.LblLmc.Text = "Liwayway Marketing Corp."
        Me.LblLmc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCopyright
        '
        Me.LblCopyright.Appearance.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCopyright.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LblCopyright.Appearance.Options.UseFont = True
        Me.LblCopyright.Appearance.Options.UseForeColor = True
        Me.LblCopyright.Location = New System.Drawing.Point(12, 471)
        Me.LblCopyright.Name = "LblCopyright"
        Me.LblCopyright.Size = New System.Drawing.Size(194, 17)
        Me.LblCopyright.TabIndex = 52
        Me.LblCopyright.Text = "© 2025 Project by LMC ERP Dept"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(75, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(120, 120)
        Me.Panel2.TabIndex = 52
        '
        'FrmLogin
        '
        Me.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 500)
        Me.Controls.Add(Me.RPnlLeft)
        Me.Controls.Add(Me.RPnlRight)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogin"
        Me.RPnlLeft.ResumeLayout(False)
        Me.RPnlLeft.PerformLayout()
        Me.PnlSelectConn.ResumeLayout(False)
        Me.PnlSelectConn.PerformLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RPnlRight.ResumeLayout(False)
        Me.RPnlRight.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnLogin As RoundedButton
    Friend WithEvents RPnlLeft As RoundedPanel
    Friend WithEvents RPnlRight As RoundedPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblCopyright As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblSignIn As Label
    Friend WithEvents LblWelcome As Label
    Friend WithEvents LblInsight As Label
    Friend WithEvents LblLmc As Label
    Friend WithEvents LblClose As Label
    Friend WithEvents LblLinkDatabase As LinkLabel
    Friend WithEvents TxtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ChkShowPass As CheckBox
    Friend WithEvents LblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PnlSelectConn As Panel
    Friend WithEvents lblAddConnection As Label
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label1 As Label
End Class
