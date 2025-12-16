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
        Me.lblLinkDatabase = New System.Windows.Forms.LinkLabel()
        Me.LblClose = New System.Windows.Forms.Label()
        Me.LblSignIn = New System.Windows.Forms.Label()
        Me.LblWelcome = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.BtnLogin = New LMCInsight360.RoundedButton()
        Me.RPnlRight = New LMCInsight360.RoundedPanel()
        Me.LblInsight = New System.Windows.Forms.Label()
        Me.LblLmc = New System.Windows.Forms.Label()
        Me.LblCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RPnlLeft.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RPnlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'RPnlLeft
        '
        Me.RPnlLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.RPnlLeft.Controls.Add(Me.lblLinkDatabase)
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
        'lblLinkDatabase
        '
        Me.lblLinkDatabase.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblLinkDatabase.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinkDatabase.LinkColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblLinkDatabase.Location = New System.Drawing.Point(96, 359)
        Me.lblLinkDatabase.Name = "lblLinkDatabase"
        Me.lblLinkDatabase.Size = New System.Drawing.Size(189, 24)
        Me.lblLinkDatabase.TabIndex = 56
        Me.lblLinkDatabase.TabStop = True
        Me.lblLinkDatabase.Text = "🔗 Connect to Database"
        Me.lblLinkDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblClose
        '
        Me.LblClose.AutoSize = True
        Me.LblClose.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClose.ForeColor = System.Drawing.Color.Red
        Me.LblClose.Location = New System.Drawing.Point(343, 3)
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
        Me.BtnLogin.Location = New System.Drawing.Point(120, 291)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(150, 36)
        Me.BtnLogin.TabIndex = 46
        Me.BtnLogin.Text = "LOGIN"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'RPnlRight
        '
        Me.RPnlRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(223, Byte), Integer))
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
        'LblInsight
        '
        Me.LblInsight.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInsight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.LblInsight.Location = New System.Drawing.Point(0, 226)
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
        Me.LblCopyright.Location = New System.Drawing.Point(10, 473)
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
    Friend WithEvents lblLinkDatabase As LinkLabel
    Friend WithEvents TxtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPassword As DevExpress.XtraEditors.TextEdit
End Class
