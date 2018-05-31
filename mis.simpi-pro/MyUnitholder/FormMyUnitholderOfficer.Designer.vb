<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMyUnitholderOfficer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMyUnitholderOfficer))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblCIF = New C1.Win.C1InputPanel.InputLabel()
        Me.lblName = New C1.Win.C1InputPanel.InputLabel()
        Me.DBGOfficer = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1InputPanel2 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerTitle = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtOfficerPhone = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtOfficerEmail = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficeReligion = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDayBirth = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerBirthDate = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerSpouseName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDaySpouse = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerSpouseBirth = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDayAnniversary = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerSpouseAnniversarry = New C1.Win.C1InputPanel.InputLabel()
        Me.btnIDCard = New C1.Win.C1InputPanel.InputButton()
        Me.InputButton2 = New C1.Win.C1InputPanel.InputButton()
        Me.InputButton3 = New C1.Win.C1InputPanel.InputButton()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBGOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.lblCIF)
        Me.C1InputPanel1.Items.Add(Me.lblName)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(346, 64)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "INSTITUTION CLIENT"
        '
        'InputLabel1
        '
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "CIF: "
        '
        'lblCIF
        '
        Me.lblCIF.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblCIF.Name = "lblCIF"
        Me.lblCIF.Width = 296
        '
        'lblName
        '
        Me.lblName.Name = "lblName"
        Me.lblName.Width = 328
        '
        'DBGOfficer
        '
        Me.DBGOfficer.BackColor = System.Drawing.Color.White
        Me.DBGOfficer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGOfficer.Dock = System.Windows.Forms.DockStyle.Top
        Me.DBGOfficer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DBGOfficer.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGOfficer.Images.Add(CType(resources.GetObject("DBGOfficer.Images"), System.Drawing.Image))
        Me.DBGOfficer.Location = New System.Drawing.Point(0, 64)
        Me.DBGOfficer.Name = "DBGOfficer"
        Me.DBGOfficer.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGOfficer.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGOfficer.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGOfficer.PrintInfo.PageSettings = CType(resources.GetObject("DBGOfficer.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGOfficer.PropBag = resources.GetString("DBGOfficer.PropBag")
        Me.DBGOfficer.RecordSelectors = False
        Me.DBGOfficer.RowHeight = 30
        Me.DBGOfficer.Size = New System.Drawing.Size(346, 216)
        Me.DBGOfficer.TabIndex = 18
        '
        'C1InputPanel2
        '
        Me.C1InputPanel2.BorderThickness = 1
        Me.C1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel2.Items.Add(Me.InputLabel2)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerName)
        Me.C1InputPanel2.Items.Add(Me.InputLabel5)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerTitle)
        Me.C1InputPanel2.Items.Add(Me.InputLabel6)
        Me.C1InputPanel2.Items.Add(Me.txtOfficerPhone)
        Me.C1InputPanel2.Items.Add(Me.InputLabel7)
        Me.C1InputPanel2.Items.Add(Me.txtOfficerEmail)
        Me.C1InputPanel2.Items.Add(Me.InputLabel8)
        Me.C1InputPanel2.Items.Add(Me.lblOfficeReligion)
        Me.C1InputPanel2.Items.Add(Me.InputLabel9)
        Me.C1InputPanel2.Items.Add(Me.lblDayBirth)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerBirthDate)
        Me.C1InputPanel2.Items.Add(Me.InputLabel10)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerSpouseName)
        Me.C1InputPanel2.Items.Add(Me.InputLabel11)
        Me.C1InputPanel2.Items.Add(Me.lblDaySpouse)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerSpouseBirth)
        Me.C1InputPanel2.Items.Add(Me.InputLabel12)
        Me.C1InputPanel2.Items.Add(Me.lblDayAnniversary)
        Me.C1InputPanel2.Items.Add(Me.lblOfficerSpouseAnniversarry)
        Me.C1InputPanel2.Items.Add(Me.btnIDCard)
        Me.C1InputPanel2.Items.Add(Me.InputButton2)
        Me.C1InputPanel2.Items.Add(Me.InputButton3)
        Me.C1InputPanel2.Location = New System.Drawing.Point(0, 280)
        Me.C1InputPanel2.Name = "C1InputPanel2"
        Me.C1InputPanel2.Size = New System.Drawing.Size(346, 242)
        Me.C1InputPanel2.TabIndex = 19
        Me.C1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        Me.InputGroupHeader2.Text = "OFFICER INFORMATION"
        '
        'InputLabel2
        '
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Name: "
        Me.InputLabel2.Width = 75
        '
        'lblOfficerName
        '
        Me.lblOfficerName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerName.Name = "lblOfficerName"
        Me.lblOfficerName.Width = 245
        '
        'InputLabel5
        '
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Title: "
        Me.InputLabel5.Width = 75
        '
        'lblOfficerTitle
        '
        Me.lblOfficerTitle.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerTitle.Name = "lblOfficerTitle"
        Me.lblOfficerTitle.Width = 245
        '
        'InputLabel6
        '
        Me.InputLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel6.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "Phone: "
        Me.InputLabel6.Width = 75
        '
        'txtOfficerPhone
        '
        Me.txtOfficerPhone.Name = "txtOfficerPhone"
        Me.txtOfficerPhone.ReadOnly = True
        Me.txtOfficerPhone.Width = 249
        '
        'InputLabel7
        '
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "Email: "
        Me.InputLabel7.Width = 75
        '
        'txtOfficerEmail
        '
        Me.txtOfficerEmail.Name = "txtOfficerEmail"
        Me.txtOfficerEmail.ReadOnly = True
        Me.txtOfficerEmail.Width = 249
        '
        'InputLabel8
        '
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Religion: "
        Me.InputLabel8.Width = 75
        '
        'lblOfficeReligion
        '
        Me.lblOfficeReligion.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficeReligion.Name = "lblOfficeReligion"
        Me.lblOfficeReligion.Width = 245
        '
        'InputLabel9
        '
        Me.InputLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel9.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "Birth Date: "
        Me.InputLabel9.Width = 75
        '
        'lblDayBirth
        '
        Me.lblDayBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDayBirth.ForeColor = System.Drawing.Color.Red
        Me.lblDayBirth.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDayBirth.Name = "lblDayBirth"
        Me.lblDayBirth.Width = 100
        '
        'lblOfficerBirthDate
        '
        Me.lblOfficerBirthDate.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerBirthDate.Name = "lblOfficerBirthDate"
        Me.lblOfficerBirthDate.Width = 120
        '
        'InputLabel10
        '
        Me.InputLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel10.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel10.Name = "InputLabel10"
        Me.InputLabel10.Text = "Spouse: "
        Me.InputLabel10.Width = 75
        '
        'lblOfficerSpouseName
        '
        Me.lblOfficerSpouseName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerSpouseName.Name = "lblOfficerSpouseName"
        Me.lblOfficerSpouseName.Width = 245
        '
        'InputLabel11
        '
        Me.InputLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel11.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel11.Name = "InputLabel11"
        Me.InputLabel11.Text = "Spouse birth: "
        Me.InputLabel11.Width = 75
        '
        'lblDaySpouse
        '
        Me.lblDaySpouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaySpouse.ForeColor = System.Drawing.Color.Red
        Me.lblDaySpouse.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDaySpouse.Name = "lblDaySpouse"
        Me.lblDaySpouse.Width = 100
        '
        'lblOfficerSpouseBirth
        '
        Me.lblOfficerSpouseBirth.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerSpouseBirth.Name = "lblOfficerSpouseBirth"
        Me.lblOfficerSpouseBirth.Width = 120
        '
        'InputLabel12
        '
        Me.InputLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel12.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel12.Name = "InputLabel12"
        Me.InputLabel12.Text = "Anniversarry: "
        Me.InputLabel12.Width = 75
        '
        'lblDayAnniversary
        '
        Me.lblDayAnniversary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDayAnniversary.ForeColor = System.Drawing.Color.Red
        Me.lblDayAnniversary.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDayAnniversary.Name = "lblDayAnniversary"
        Me.lblDayAnniversary.Width = 100
        '
        'lblOfficerSpouseAnniversarry
        '
        Me.lblOfficerSpouseAnniversarry.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblOfficerSpouseAnniversarry.Name = "lblOfficerSpouseAnniversarry"
        Me.lblOfficerSpouseAnniversarry.Width = 120
        '
        'btnIDCard
        '
        Me.btnIDCard.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnIDCard.Enabled = False
        Me.btnIDCard.Height = 40
        Me.btnIDCard.Name = "btnIDCard"
        Me.btnIDCard.Text = "IDCard"
        Me.btnIDCard.Width = 100
        '
        'InputButton2
        '
        Me.InputButton2.Break = C1.Win.C1InputPanel.BreakType.None
        Me.InputButton2.Enabled = False
        Me.InputButton2.Height = 40
        Me.InputButton2.Name = "InputButton2"
        Me.InputButton2.Width = 100
        '
        'InputButton3
        '
        Me.InputButton3.Enabled = False
        Me.InputButton3.Height = 40
        Me.InputButton3.Name = "InputButton3"
        Me.InputButton3.Width = 100
        '
        'FormMyUnitholderOfficer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 522)
        Me.Controls.Add(Me.C1InputPanel2)
        Me.Controls.Add(Me.DBGOfficer)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMyUnitholderOfficer"
        Me.Text = "MyUnitholder: Officer"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBGOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents lblCIF As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents DBGOfficer As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1InputPanel2 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerTitle As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtOfficerPhone As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtOfficerEmail As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficeReligion As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerBirthDate As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerSpouseName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerSpouseBirth As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerSpouseAnniversarry As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents btnIDCard As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputButton2 As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputButton3 As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblDayBirth As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDaySpouse As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDayAnniversary As C1.Win.C1InputPanel.InputLabel
End Class
