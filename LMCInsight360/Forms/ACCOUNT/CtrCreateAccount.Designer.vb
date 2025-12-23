<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtrCreateAccount
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
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtUser = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPass = New DevExpress.XtraEditors.TextEdit()
        Me.TxtRepass = New DevExpress.XtraEditors.TextEdit()
        Me.ChkShowpass = New System.Windows.Forms.CheckBox()
        Me.BtnSave = New LMCInsight360.RoundedButton()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRepass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(14, 170)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(141, 23)
        Me.LabelControl4.TabIndex = 45
        Me.LabelControl4.Text = "Confirm Password:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(80, 130)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(75, 23)
        Me.LabelControl3.TabIndex = 44
        Me.LabelControl3.Text = "Password:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(76, 88)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(81, 23)
        Me.LabelControl2.TabIndex = 43
        Me.LabelControl2.Text = "Username:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(65, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(90, 23)
        Me.LabelControl1.TabIndex = 42
        Me.LabelControl1.Text = "Your Name:"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(187, 45)
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
        Me.TxtName.Properties.Mask.ShowPlaceHolders = False
        Me.TxtName.Properties.MaxLength = 50
        Me.TxtName.Size = New System.Drawing.Size(294, 30)
        Me.TxtName.TabIndex = 54
        '
        'TxtUser
        '
        Me.TxtUser.Location = New System.Drawing.Point(187, 85)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtUser.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtUser.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtUser.Properties.Appearance.Options.UseBackColor = True
        Me.TxtUser.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtUser.Properties.Appearance.Options.UseFont = True
        Me.TxtUser.Properties.Appearance.Options.UseForeColor = True
        Me.TxtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtUser.Properties.Mask.EditMask = "\d{0,4}"
        Me.TxtUser.Properties.Mask.ShowPlaceHolders = False
        Me.TxtUser.Properties.MaxLength = 50
        Me.TxtUser.Size = New System.Drawing.Size(294, 30)
        Me.TxtUser.TabIndex = 55
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(187, 127)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtPass.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtPass.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPass.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPass.Properties.Appearance.Options.UseBackColor = True
        Me.TxtPass.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtPass.Properties.Appearance.Options.UseFont = True
        Me.TxtPass.Properties.Appearance.Options.UseForeColor = True
        Me.TxtPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtPass.Properties.Mask.ShowPlaceHolders = False
        Me.TxtPass.Properties.MaxLength = 50
        Me.TxtPass.Size = New System.Drawing.Size(294, 30)
        Me.TxtPass.TabIndex = 56
        '
        'TxtRepass
        '
        Me.TxtRepass.Location = New System.Drawing.Point(187, 167)
        Me.TxtRepass.Name = "TxtRepass"
        Me.TxtRepass.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.TxtRepass.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.TxtRepass.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRepass.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtRepass.Properties.Appearance.Options.UseBackColor = True
        Me.TxtRepass.Properties.Appearance.Options.UseBorderColor = True
        Me.TxtRepass.Properties.Appearance.Options.UseFont = True
        Me.TxtRepass.Properties.Appearance.Options.UseForeColor = True
        Me.TxtRepass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TxtRepass.Properties.Mask.ShowPlaceHolders = False
        Me.TxtRepass.Properties.MaxLength = 50
        Me.TxtRepass.Size = New System.Drawing.Size(294, 30)
        Me.TxtRepass.TabIndex = 57
        '
        'ChkShowpass
        '
        Me.ChkShowpass.AutoSize = True
        Me.ChkShowpass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkShowpass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ChkShowpass.Location = New System.Drawing.Point(187, 212)
        Me.ChkShowpass.Name = "ChkShowpass"
        Me.ChkShowpass.Size = New System.Drawing.Size(132, 24)
        Me.ChkShowpass.TabIndex = 58
        Me.ChkShowpass.Text = "Show Password"
        Me.ChkShowpass.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(331, 269)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(150, 29)
        Me.BtnSave.TabIndex = 59
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'CtrCreateAccount
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.ChkShowpass)
        Me.Controls.Add(Me.TxtRepass)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "CtrCreateAccount"
        Me.Size = New System.Drawing.Size(1273, 701)
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRepass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtRepass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ChkShowpass As CheckBox
    Friend WithEvents BtnSave As RoundedButton
End Class
