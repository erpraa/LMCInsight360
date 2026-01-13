<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddConnection
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtdbserver = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txtdbuser = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtdbpassword = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbxdbname = New System.Windows.Forms.ComboBox()
        Me.CbxConnection = New System.Windows.Forms.ComboBox()
        Me.BtnSave = New LMCInsight360.RoundedButton()
        Me.BtnDelete = New LMCInsight360.RoundedButton()
        Me.BtnNew = New LMCInsight360.RoundedButton()
        CType(Me.Txtdbserver.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtdbuser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtdbpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 19)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Connection:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Database:"
        '
        'Txtdbserver
        '
        Me.Txtdbserver.Location = New System.Drawing.Point(116, 30)
        Me.Txtdbserver.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txtdbserver.Name = "Txtdbserver"
        Me.Txtdbserver.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Txtdbserver.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdbserver.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Txtdbserver.Properties.Appearance.Options.UseBackColor = True
        Me.Txtdbserver.Properties.Appearance.Options.UseFont = True
        Me.Txtdbserver.Properties.Appearance.Options.UseForeColor = True
        Me.Txtdbserver.Size = New System.Drawing.Size(178, 24)
        Me.Txtdbserver.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Password:"
        '
        'Txtdbuser
        '
        Me.Txtdbuser.EditValue = ""
        Me.Txtdbuser.Location = New System.Drawing.Point(116, 60)
        Me.Txtdbuser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txtdbuser.Name = "Txtdbuser"
        Me.Txtdbuser.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Txtdbuser.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdbuser.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Txtdbuser.Properties.Appearance.Options.UseBackColor = True
        Me.Txtdbuser.Properties.Appearance.Options.UseFont = True
        Me.Txtdbuser.Properties.Appearance.Options.UseForeColor = True
        Me.Txtdbuser.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtdbuser.Size = New System.Drawing.Size(178, 24)
        Me.Txtdbuser.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(70, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 19)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "User:"
        '
        'Txtdbpassword
        '
        Me.Txtdbpassword.EditValue = ""
        Me.Txtdbpassword.Location = New System.Drawing.Point(116, 90)
        Me.Txtdbpassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txtdbpassword.Name = "Txtdbpassword"
        Me.Txtdbpassword.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Txtdbpassword.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdbpassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Txtdbpassword.Properties.Appearance.Options.UseBackColor = True
        Me.Txtdbpassword.Properties.Appearance.Options.UseFont = True
        Me.Txtdbpassword.Properties.Appearance.Options.UseForeColor = True
        Me.Txtdbpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtdbpassword.Size = New System.Drawing.Size(178, 24)
        Me.Txtdbpassword.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Server:"
        '
        'Cbxdbname
        '
        Me.Cbxdbname.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbxdbname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cbxdbname.FormattingEnabled = True
        Me.Cbxdbname.Location = New System.Drawing.Point(116, 118)
        Me.Cbxdbname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cbxdbname.Name = "Cbxdbname"
        Me.Cbxdbname.Size = New System.Drawing.Size(178, 25)
        Me.Cbxdbname.TabIndex = 32
        '
        'CbxConnection
        '
        Me.CbxConnection.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxConnection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CbxConnection.FormattingEnabled = True
        Me.CbxConnection.Location = New System.Drawing.Point(116, 150)
        Me.CbxConnection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxConnection.Name = "CbxConnection"
        Me.CbxConnection.Size = New System.Drawing.Size(178, 24)
        Me.CbxConnection.TabIndex = 34
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(130, 195)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(88, 25)
        Me.BtnSave.TabIndex = 51
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.Location = New System.Drawing.Point(224, 195)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(88, 25)
        Me.BtnDelete.TabIndex = 50
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnNew
        '
        Me.BtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnNew.FlatAppearance.BorderSize = 0
        Me.BtnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNew.ForeColor = System.Drawing.Color.White
        Me.BtnNew.Location = New System.Drawing.Point(36, 195)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(88, 25)
        Me.BtnNew.TabIndex = 49
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = False
        '
        'FrmAddConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 248)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txtdbserver)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txtdbuser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtdbpassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbxdbname)
        Me.Controls.Add(Me.CbxConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAddConnection"
        Me.Text = "FrmAddConnection"
        CType(Me.Txtdbserver.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtdbuser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtdbpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Txtdbserver As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Txtdbuser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtdbpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Cbxdbname As ComboBox
    Friend WithEvents CbxConnection As ComboBox
    Friend WithEvents BtnSave As RoundedButton
    Friend WithEvents BtnDelete As RoundedButton
    Friend WithEvents BtnNew As RoundedButton
End Class
