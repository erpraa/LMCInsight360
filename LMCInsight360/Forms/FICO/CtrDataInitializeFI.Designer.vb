<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrDataInitializeFI
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
        Me.BtnLoadData = New LMCInsight360.RoundedButton()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.CbxMonth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnClosedPeriod = New LMCInsight360.RoundedButton()
        Me.BtnOpenPeriod = New LMCInsight360.RoundedButton()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnLoadData
        '
        Me.BtnLoadData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnLoadData.FlatAppearance.BorderSize = 0
        Me.BtnLoadData.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadData.ForeColor = System.Drawing.Color.White
        Me.BtnLoadData.Location = New System.Drawing.Point(320, 446)
        Me.BtnLoadData.Name = "BtnLoadData"
        Me.BtnLoadData.Size = New System.Drawing.Size(140, 30)
        Me.BtnLoadData.TabIndex = 45
        Me.BtnLoadData.Text = "Load Data"
        Me.BtnLoadData.UseVisualStyleBackColor = False
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(179, 29)
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
        Me.TxtYear.TabIndex = 43
        '
        'CbxMonth
        '
        Me.CbxMonth.Location = New System.Drawing.Point(30, 29)
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
        Me.CbxMonth.TabIndex = 44
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(30, 95)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(752, 325)
        Me.GridControl1.TabIndex = 46
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'BtnClosedPeriod
        '
        Me.BtnClosedPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnClosedPeriod.FlatAppearance.BorderSize = 0
        Me.BtnClosedPeriod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClosedPeriod.ForeColor = System.Drawing.Color.White
        Me.BtnClosedPeriod.Location = New System.Drawing.Point(478, 446)
        Me.BtnClosedPeriod.Name = "BtnClosedPeriod"
        Me.BtnClosedPeriod.Size = New System.Drawing.Size(140, 30)
        Me.BtnClosedPeriod.TabIndex = 47
        Me.BtnClosedPeriod.Text = "Closed Period"
        Me.BtnClosedPeriod.UseVisualStyleBackColor = False
        '
        'BtnOpenPeriod
        '
        Me.BtnOpenPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.BtnOpenPeriod.FlatAppearance.BorderSize = 0
        Me.BtnOpenPeriod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOpenPeriod.ForeColor = System.Drawing.Color.White
        Me.BtnOpenPeriod.Location = New System.Drawing.Point(639, 446)
        Me.BtnOpenPeriod.Name = "BtnOpenPeriod"
        Me.BtnOpenPeriod.Size = New System.Drawing.Size(140, 30)
        Me.BtnOpenPeriod.TabIndex = 48
        Me.BtnOpenPeriod.Text = "Open Period"
        Me.BtnOpenPeriod.UseVisualStyleBackColor = False
        '
        'CtrDataInitializeFI
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnOpenPeriod)
        Me.Controls.Add(Me.BtnClosedPeriod)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.BtnLoadData)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.CbxMonth)
        Me.Name = "CtrDataInitializeFI"
        Me.Size = New System.Drawing.Size(1040, 670)
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbxMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnLoadData As RoundedButton
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CbxMonth As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClosedPeriod As RoundedButton
    Friend WithEvents BtnOpenPeriod As RoundedButton
End Class
