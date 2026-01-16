<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdminInfo
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
        Me.LblUser = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LblDatabase = New DevExpress.XtraEditors.LabelControl()
        Me.LblReportServer = New DevExpress.XtraEditors.LabelControl()
        Me.LblCasServer = New DevExpress.XtraEditors.LabelControl()
        Me.LblResServer = New DevExpress.XtraEditors.LabelControl()
        Me.LblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblUser
        '
        Me.LblUser.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUser.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblUser.Appearance.Options.UseFont = True
        Me.LblUser.Appearance.Options.UseForeColor = True
        Me.LblUser.Appearance.Options.UseTextOptions = True
        Me.LblUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LblUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblUser.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop
        Me.LblUser.Location = New System.Drawing.Point(107, 15)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(203, 20)
        Me.LblUser.TabIndex = 1
        Me.LblUser.Text = "● User:  Admin"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(17, 30)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(67, 20)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Database:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(17, 63)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(73, 20)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "Sql Server:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(17, 96)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(75, 20)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Cas Server:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(17, 125)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(75, 20)
        Me.LabelControl6.TabIndex = 5
        Me.LabelControl6.Text = "Res Server:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.Appearance.Options.UseTextOptions = True
        Me.LabelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.Location = New System.Drawing.Point(17, 257)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(311, 22)
        Me.LabelControl7.TabIndex = 6
        Me.LabelControl7.Text = "© 2025 Project by LMC ERP Department"
        '
        'LblDatabase
        '
        Me.LblDatabase.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDatabase.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblDatabase.Appearance.Options.UseFont = True
        Me.LblDatabase.Appearance.Options.UseForeColor = True
        Me.LblDatabase.Appearance.Options.UseTextOptions = True
        Me.LblDatabase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LblDatabase.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblDatabase.Location = New System.Drawing.Point(96, 30)
        Me.LblDatabase.Name = "LblDatabase"
        Me.LblDatabase.Size = New System.Drawing.Size(197, 20)
        Me.LblDatabase.TabIndex = 7
        Me.LblDatabase.Text = "RPTLMCL4RP"
        '
        'LblReportServer
        '
        Me.LblReportServer.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReportServer.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblReportServer.Appearance.Options.UseFont = True
        Me.LblReportServer.Appearance.Options.UseForeColor = True
        Me.LblReportServer.Appearance.Options.UseTextOptions = True
        Me.LblReportServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LblReportServer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblReportServer.Location = New System.Drawing.Point(96, 63)
        Me.LblReportServer.Name = "LblReportServer"
        Me.LblReportServer.Size = New System.Drawing.Size(197, 20)
        Me.LblReportServer.TabIndex = 8
        Me.LblReportServer.Text = "192.168.200.91"
        '
        'LblCasServer
        '
        Me.LblCasServer.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCasServer.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblCasServer.Appearance.Options.UseFont = True
        Me.LblCasServer.Appearance.Options.UseForeColor = True
        Me.LblCasServer.Appearance.Options.UseTextOptions = True
        Me.LblCasServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LblCasServer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblCasServer.Location = New System.Drawing.Point(96, 96)
        Me.LblCasServer.Name = "LblCasServer"
        Me.LblCasServer.Size = New System.Drawing.Size(197, 20)
        Me.LblCasServer.TabIndex = 9
        Me.LblCasServer.Text = "192.168.200.233:32015"
        '
        'LblResServer
        '
        Me.LblResServer.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResServer.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblResServer.Appearance.Options.UseFont = True
        Me.LblResServer.Appearance.Options.UseForeColor = True
        Me.LblResServer.Appearance.Options.UseTextOptions = True
        Me.LblResServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LblResServer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblResServer.Location = New System.Drawing.Point(96, 125)
        Me.LblResServer.Name = "LblResServer"
        Me.LblResServer.Size = New System.Drawing.Size(197, 20)
        Me.LblResServer.TabIndex = 10
        Me.LblResServer.Text = "192.168.100.214:35015"
        '
        'LblVersion
        '
        Me.LblVersion.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVersion.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LblVersion.Appearance.Options.UseFont = True
        Me.LblVersion.Appearance.Options.UseForeColor = True
        Me.LblVersion.Appearance.Options.UseTextOptions = True
        Me.LblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LblVersion.Location = New System.Drawing.Point(17, 226)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(311, 16)
        Me.LblVersion.TabIndex = 11
        Me.LblVersion.Text = "Version: 1.0.0.1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblResServer)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.LabelControl4)
        Me.GroupBox1.Controls.Add(Me.LblCasServer)
        Me.GroupBox1.Controls.Add(Me.LabelControl5)
        Me.GroupBox1.Controls.Add(Me.LblReportServer)
        Me.GroupBox1.Controls.Add(Me.LabelControl6)
        Me.GroupBox1.Controls.Add(Me.LblDatabase)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 164)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection Info"
        '
        'FrmAdminInfo
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 300)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LblUser)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAdminInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblUser As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblDatabase As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblReportServer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblCasServer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblResServer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox1 As GroupBox
End Class
