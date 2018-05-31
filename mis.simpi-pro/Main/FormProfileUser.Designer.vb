<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProfileUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProfileUser))
        Me.c1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.inputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiID = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiType = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSalesOfficer = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader4 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.inputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiShortname = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel20 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiAddress = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel21 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiContact = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel22 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel23 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiPhone = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader5 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel13 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel15 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblAdminName = New C1.Win.C1InputPanel.InputLabel()
        Me.lblAdminEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.btnEmail = New C1.Win.C1InputPanel.InputButton()
        Me.inputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.inputLabel24 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel25 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblUserLogin = New C1.Win.C1InputPanel.InputLabel()
        Me.lblUserID = New C1.Win.C1InputPanel.InputLabel()
        Me.lblUserInitial = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel26 = New C1.Win.C1InputPanel.InputLabel()
        Me.inputLabel27 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblUserName = New C1.Win.C1InputPanel.InputLabel()
        Me.lblUserTitle = New C1.Win.C1InputPanel.InputLabel()
        Me.btnPassword = New C1.Win.C1InputPanel.InputButton()
        Me.inputGroupHeader3 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtFrom = New C1.Win.C1InputPanel.InputDatePicker()
        Me.dtTo = New C1.Win.C1InputPanel.InputDatePicker()
        Me.inputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtKeyword = New C1.Win.C1InputPanel.InputTextBox()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.DBGLog = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.c1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBGLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'c1InputPanel1
        '
        Me.c1InputPanel1.BorderThickness = 1
        Me.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.c1InputPanel1.Items.Add(Me.inputGroupHeader1)
        Me.c1InputPanel1.Items.Add(Me.InputLabel2)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiID)
        Me.c1InputPanel1.Items.Add(Me.InputLabel6)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiType)
        Me.c1InputPanel1.Items.Add(Me.InputLabel5)
        Me.c1InputPanel1.Items.Add(Me.lblSalesOfficer)
        Me.c1InputPanel1.Items.Add(Me.InputLabel10)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiName)
        Me.c1InputPanel1.Items.Add(Me.InputGroupHeader4)
        Me.c1InputPanel1.Items.Add(Me.inputLabel4)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiShortname)
        Me.c1InputPanel1.Items.Add(Me.inputLabel20)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiAddress)
        Me.c1InputPanel1.Items.Add(Me.inputLabel21)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiContact)
        Me.c1InputPanel1.Items.Add(Me.inputLabel22)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiEmail)
        Me.c1InputPanel1.Items.Add(Me.inputLabel23)
        Me.c1InputPanel1.Items.Add(Me.lblSimpiPhone)
        Me.c1InputPanel1.Items.Add(Me.InputGroupHeader5)
        Me.c1InputPanel1.Items.Add(Me.InputLabel13)
        Me.c1InputPanel1.Items.Add(Me.InputLabel15)
        Me.c1InputPanel1.Items.Add(Me.lblAdminName)
        Me.c1InputPanel1.Items.Add(Me.lblAdminEmail)
        Me.c1InputPanel1.Items.Add(Me.btnEmail)
        Me.c1InputPanel1.Items.Add(Me.inputGroupHeader2)
        Me.c1InputPanel1.Items.Add(Me.inputLabel24)
        Me.c1InputPanel1.Items.Add(Me.InputLabel3)
        Me.c1InputPanel1.Items.Add(Me.inputLabel25)
        Me.c1InputPanel1.Items.Add(Me.lblUserLogin)
        Me.c1InputPanel1.Items.Add(Me.lblUserID)
        Me.c1InputPanel1.Items.Add(Me.lblUserInitial)
        Me.c1InputPanel1.Items.Add(Me.inputLabel26)
        Me.c1InputPanel1.Items.Add(Me.inputLabel27)
        Me.c1InputPanel1.Items.Add(Me.lblUserName)
        Me.c1InputPanel1.Items.Add(Me.lblUserTitle)
        Me.c1InputPanel1.Items.Add(Me.btnPassword)
        Me.c1InputPanel1.Items.Add(Me.inputGroupHeader3)
        Me.c1InputPanel1.Items.Add(Me.InputLabel1)
        Me.c1InputPanel1.Items.Add(Me.dtFrom)
        Me.c1InputPanel1.Items.Add(Me.dtTo)
        Me.c1InputPanel1.Items.Add(Me.inputLabel8)
        Me.c1InputPanel1.Items.Add(Me.txtKeyword)
        Me.c1InputPanel1.Items.Add(Me.btnSearch)
        Me.c1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.c1InputPanel1.Name = "c1InputPanel1"
        Me.c1InputPanel1.Size = New System.Drawing.Size(749, 484)
        Me.c1InputPanel1.TabIndex = 3
        Me.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'inputGroupHeader1
        '
        Me.inputGroupHeader1.Name = "inputGroupHeader1"
        Me.inputGroupHeader1.Text = "MASTER SIMPI"
        '
        'InputLabel2
        '
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "ID: "
        Me.InputLabel2.Width = 75
        '
        'lblSimpiID
        '
        Me.lblSimpiID.Name = "lblSimpiID"
        Me.lblSimpiID.Text = "12345"
        Me.lblSimpiID.Width = 100
        '
        'InputLabel6
        '
        Me.InputLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "Type: "
        '
        'lblSimpiType
        '
        Me.lblSimpiType.Name = "lblSimpiType"
        Me.lblSimpiType.Text = "Fund Manager"
        Me.lblSimpiType.Width = 200
        '
        'InputLabel5
        '
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Simpi Officer: "
        '
        'lblSalesOfficer
        '
        Me.lblSalesOfficer.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSalesOfficer.Name = "lblSalesOfficer"
        Me.lblSalesOfficer.Text = "Label"
        '
        'InputLabel10
        '
        Me.InputLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel10.Name = "InputLabel10"
        Me.InputLabel10.Text = "Name: "
        Me.InputLabel10.Width = 75
        '
        'lblSimpiName
        '
        Me.lblSimpiName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiName.Name = "lblSimpiName"
        Me.lblSimpiName.Text = "PT BJ Manunggal Perkasa"
        '
        'InputGroupHeader4
        '
        Me.InputGroupHeader4.Height = 1
        Me.InputGroupHeader4.Name = "InputGroupHeader4"
        '
        'inputLabel4
        '
        Me.inputLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel4.Name = "inputLabel4"
        Me.inputLabel4.Text = "Shortname*: "
        Me.inputLabel4.Width = 75
        '
        'lblSimpiShortname
        '
        Me.lblSimpiShortname.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiShortname.Name = "lblSimpiShortname"
        Me.lblSimpiShortname.Text = "PT BJ Manunggal Perkasa"
        Me.lblSimpiShortname.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSimpiShortname.Width = 386
        '
        'inputLabel20
        '
        Me.inputLabel20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel20.Height = 50
        Me.inputLabel20.Name = "inputLabel20"
        Me.inputLabel20.Text = "Address: "
        Me.inputLabel20.Width = 75
        '
        'lblSimpiAddress
        '
        Me.lblSimpiAddress.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSimpiAddress.Height = 50
        Me.lblSimpiAddress.Name = "lblSimpiAddress"
        Me.lblSimpiAddress.Text = "Label"
        Me.lblSimpiAddress.Width = 384
        '
        'inputLabel21
        '
        Me.inputLabel21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel21.Name = "inputLabel21"
        Me.inputLabel21.Text = "PIC: "
        Me.inputLabel21.Width = 50
        '
        'lblSimpiContact
        '
        Me.lblSimpiContact.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiContact.Height = 20
        Me.lblSimpiContact.Name = "lblSimpiContact"
        Me.lblSimpiContact.Text = "Mochamad Junaidi"
        Me.lblSimpiContact.Width = 185
        '
        'inputLabel22
        '
        Me.inputLabel22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel22.Name = "inputLabel22"
        Me.inputLabel22.Text = "Email: "
        Me.inputLabel22.Width = 50
        '
        'lblSimpiEmail
        '
        Me.lblSimpiEmail.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiEmail.Height = 20
        Me.lblSimpiEmail.Name = "lblSimpiEmail"
        Me.lblSimpiEmail.Text = "admin@simpi-pro.com"
        Me.lblSimpiEmail.Width = 185
        '
        'inputLabel23
        '
        Me.inputLabel23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel23.Name = "inputLabel23"
        Me.inputLabel23.Text = "Phone: "
        Me.inputLabel23.Width = 50
        '
        'lblSimpiPhone
        '
        Me.lblSimpiPhone.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiPhone.Height = 20
        Me.lblSimpiPhone.Name = "lblSimpiPhone"
        Me.lblSimpiPhone.Text = "62-21-25076899"
        Me.lblSimpiPhone.Width = 185
        '
        'InputGroupHeader5
        '
        Me.InputGroupHeader5.Height = 1
        Me.InputGroupHeader5.Name = "InputGroupHeader5"
        '
        'InputLabel13
        '
        Me.InputLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel13.Name = "InputLabel13"
        Me.InputLabel13.Text = "Administrator"
        Me.InputLabel13.Width = 350
        '
        'InputLabel15
        '
        Me.InputLabel15.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel15.Name = "InputLabel15"
        Me.InputLabel15.Text = "Email"
        Me.InputLabel15.Width = 265
        '
        'lblAdminName
        '
        Me.lblAdminName.Name = "lblAdminName"
        Me.lblAdminName.Text = "Mochamad Junaidi"
        Me.lblAdminName.Width = 350
        '
        'lblAdminEmail
        '
        Me.lblAdminEmail.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblAdminEmail.Name = "lblAdminEmail"
        Me.lblAdminEmail.Text = "juna94@bjmanunggal.co.id"
        Me.lblAdminEmail.Width = 265
        '
        'btnEmail
        '
        Me.btnEmail.Height = 35
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Text = "EMAIL"
        Me.btnEmail.Width = 100
        '
        'inputGroupHeader2
        '
        Me.inputGroupHeader2.Name = "inputGroupHeader2"
        Me.inputGroupHeader2.Text = "USER PROFILE"
        '
        'inputLabel24
        '
        Me.inputLabel24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel24.Name = "inputLabel24"
        Me.inputLabel24.Text = "User login"
        Me.inputLabel24.Width = 400
        '
        'InputLabel3
        '
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "ID"
        Me.InputLabel3.Width = 75
        '
        'inputLabel25
        '
        Me.inputLabel25.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.inputLabel25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel25.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.inputLabel25.Name = "inputLabel25"
        Me.inputLabel25.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.inputLabel25.Text = "Initial"
        '
        'lblUserLogin
        '
        Me.lblUserLogin.Name = "lblUserLogin"
        Me.lblUserLogin.Text = "mochamad.junaidi@gmail.com"
        Me.lblUserLogin.Width = 400
        '
        'lblUserID
        '
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Text = "1235"
        Me.lblUserID.Width = 75
        '
        'lblUserInitial
        '
        Me.lblUserInitial.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblUserInitial.Name = "lblUserInitial"
        Me.lblUserInitial.Text = "juna94"
        Me.lblUserInitial.Width = 135
        '
        'inputLabel26
        '
        Me.inputLabel26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel26.Name = "inputLabel26"
        Me.inputLabel26.Text = "Username"
        Me.inputLabel26.Width = 478
        '
        'inputLabel27
        '
        Me.inputLabel27.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.inputLabel27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel27.Name = "inputLabel27"
        Me.inputLabel27.Text = "Title"
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Text = "Mochamad Junaidi"
        Me.lblUserName.Width = 480
        '
        'lblUserTitle
        '
        Me.lblUserTitle.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblUserTitle.Name = "lblUserTitle"
        Me.lblUserTitle.Text = "IT Manager"
        '
        'btnPassword
        '
        Me.btnPassword.Height = 35
        Me.btnPassword.Name = "btnPassword"
        Me.btnPassword.Text = "PASSWORD"
        Me.btnPassword.Width = 100
        '
        'inputGroupHeader3
        '
        Me.inputGroupHeader3.Name = "inputGroupHeader3"
        Me.inputGroupHeader3.Text = "USER ACTIVITY"
        '
        'InputLabel1
        '
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "From date: "
        '
        'dtFrom
        '
        Me.dtFrom.Break = C1.Win.C1InputPanel.BreakType.None
        Me.dtFrom.Name = "dtFrom"
        '
        'dtTo
        '
        Me.dtTo.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.dtTo.Name = "dtTo"
        '
        'inputLabel8
        '
        Me.inputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLabel8.Height = 35
        Me.inputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.inputLabel8.Name = "inputLabel8"
        Me.inputLabel8.Text = "Keyword: "
        '
        'txtKeyword
        '
        Me.txtKeyword.Break = C1.Win.C1InputPanel.BreakType.None
        Me.txtKeyword.Height = 35
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Width = 284
        '
        'btnSearch
        '
        Me.btnSearch.Height = 35
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.Width = 100
        '
        'DBGLog
        '
        Me.DBGLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGLog.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.DBGLog.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGLog.Images.Add(CType(resources.GetObject("DBGLog.Images"), System.Drawing.Image))
        Me.DBGLog.Location = New System.Drawing.Point(2, 336)
        Me.DBGLog.Name = "DBGLog"
        Me.DBGLog.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGLog.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGLog.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGLog.PrintInfo.PageSettings = CType(resources.GetObject("DBGLog.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGLog.PropBag = resources.GetString("DBGLog.PropBag")
        Me.DBGLog.RecordSelectors = False
        Me.DBGLog.Size = New System.Drawing.Size(743, 144)
        Me.DBGLog.TabIndex = 4
        Me.DBGLog.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2010Blue
        '
        'FormProfileUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 484)
        Me.Controls.Add(Me.DBGLog)
        Me.Controls.Add(Me.c1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProfileUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "my -> user profile"
        Me.TopMost = True
        CType(Me.c1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBGLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents c1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Private WithEvents inputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiID As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiType As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiName As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel4 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblSimpiShortname As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel20 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel21 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblSimpiContact As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel22 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblSimpiEmail As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel23 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblSimpiPhone As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Private WithEvents inputLabel24 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel25 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblUserLogin As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblUserInitial As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel26 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputLabel27 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblUserName As C1.Win.C1InputPanel.InputLabel
    Private WithEvents lblUserTitle As C1.Win.C1InputPanel.InputLabel
    Private WithEvents inputGroupHeader3 As C1.Win.C1InputPanel.InputGroupHeader
    Private WithEvents inputLabel8 As C1.Win.C1InputPanel.InputLabel
    Private WithEvents txtKeyword As C1.Win.C1InputPanel.InputTextBox
    Private WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputGroupHeader4 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputGroupHeader5 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel13 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel15 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblAdminName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblAdminEmail As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtFrom As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents dtTo As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents DBGLog As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnPassword As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblUserID As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesOfficer As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiAddress As C1.Win.C1InputPanel.InputLabel
End Class
