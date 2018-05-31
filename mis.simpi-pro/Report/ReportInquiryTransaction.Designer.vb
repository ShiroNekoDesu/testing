<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportInquiryTransaction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportInquiryTransaction))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
        Me.cmbCcy = New C1.Win.C1InputPanel.InputComboBox()
        Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtPortfolio = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtClient = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtFrom = New C1.Win.C1InputPanel.InputDatePicker()
        Me.dtTo = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubscriptionNo = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedemptionNo = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDividendNo = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubscriptionUnit = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedemptionUnit = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDividendUnit = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubscriptionValue = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedemptionValue = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDividendValue = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader3 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.cmbType = New C1.Win.C1InputPanel.InputComboBox()
        Me.btnExcel = New C1.Win.C1InputPanel.InputButton()
        Me.btnPDF = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmail = New C1.Win.C1InputPanel.InputButton()
        Me.DBGTransaction = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBGTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel1.Items.Add(Me.InputLabel10)
        Me.C1InputPanel1.Items.Add(Me.cmbCcy)
        Me.C1InputPanel1.Items.Add(Me.InputLabel11)
        Me.C1InputPanel1.Items.Add(Me.txtPortfolio)
        Me.C1InputPanel1.Items.Add(Me.InputLabel12)
        Me.C1InputPanel1.Items.Add(Me.txtClient)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.dtFrom)
        Me.C1InputPanel1.Items.Add(Me.dtTo)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.InputLabel4)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.InputLabel6)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.lblSubscriptionNo)
        Me.C1InputPanel1.Items.Add(Me.lblRedemptionNo)
        Me.C1InputPanel1.Items.Add(Me.lblDividendNo)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.lblSubscriptionUnit)
        Me.C1InputPanel1.Items.Add(Me.lblRedemptionUnit)
        Me.C1InputPanel1.Items.Add(Me.lblDividendUnit)
        Me.C1InputPanel1.Items.Add(Me.InputLabel9)
        Me.C1InputPanel1.Items.Add(Me.lblSubscriptionValue)
        Me.C1InputPanel1.Items.Add(Me.lblRedemptionValue)
        Me.C1InputPanel1.Items.Add(Me.lblDividendValue)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader3)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.cmbType)
        Me.C1InputPanel1.Items.Add(Me.btnExcel)
        Me.C1InputPanel1.Items.Add(Me.btnPDF)
        Me.C1InputPanel1.Items.Add(Me.btnEmail)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(884, 218)
        Me.C1InputPanel1.TabIndex = 3
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        Me.InputGroupHeader2.Text = "TRANSACTION FILTER"
        '
        'InputLabel10
        '
        Me.InputLabel10.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel10.Name = "InputLabel10"
        Me.InputLabel10.Text = "Currency"
        '
        'cmbCcy
        '
        Me.cmbCcy.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.cmbCcy.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbCcy.Name = "cmbCcy"
        '
        'InputLabel11
        '
        Me.InputLabel11.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel11.Name = "InputLabel11"
        Me.InputLabel11.Text = "Portfolio keyword"
        '
        'txtPortfolio
        '
        Me.txtPortfolio.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtPortfolio.Name = "txtPortfolio"
        Me.txtPortfolio.Width = 250
        '
        'InputLabel12
        '
        Me.InputLabel12.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel12.Name = "InputLabel12"
        Me.InputLabel12.Text = "Client keyword"
        '
        'txtClient
        '
        Me.txtClient.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Width = 250
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "Transaction period"
        '
        'dtFrom
        '
        Me.dtFrom.Break = C1.Win.C1InputPanel.BreakType.None
        Me.dtFrom.Name = "dtFrom"
        '
        'dtTo
        '
        Me.dtTo.Break = C1.Win.C1InputPanel.BreakType.None
        Me.dtTo.Name = "dtTo"
        '
        'btnSearch
        '
        Me.btnSearch.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "TRANSACTION SUMMARY"
        '
        'InputLabel3
        '
        Me.InputLabel3.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "Summary"
        Me.InputLabel3.Width = 120
        '
        'InputLabel4
        '
        Me.InputLabel4.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "Subscription"
        Me.InputLabel4.Width = 120
        '
        'InputLabel5
        '
        Me.InputLabel5.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Redemption"
        Me.InputLabel5.Width = 120
        '
        'InputLabel6
        '
        Me.InputLabel6.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "Dividend"
        Me.InputLabel6.Width = 120
        '
        'InputLabel7
        '
        Me.InputLabel7.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "No of Transaction"
        Me.InputLabel7.Width = 110
        '
        'lblSubscriptionNo
        '
        Me.lblSubscriptionNo.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSubscriptionNo.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblSubscriptionNo.Name = "lblSubscriptionNo"
        Me.lblSubscriptionNo.Width = 110
        '
        'lblRedemptionNo
        '
        Me.lblRedemptionNo.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblRedemptionNo.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblRedemptionNo.Name = "lblRedemptionNo"
        Me.lblRedemptionNo.Width = 110
        '
        'lblDividendNo
        '
        Me.lblDividendNo.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblDividendNo.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDividendNo.Name = "lblDividendNo"
        Me.lblDividendNo.Width = 110
        '
        'InputLabel8
        '
        Me.InputLabel8.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "No of Unit(s)"
        Me.InputLabel8.Width = 120
        '
        'lblSubscriptionUnit
        '
        Me.lblSubscriptionUnit.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSubscriptionUnit.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSubscriptionUnit.Name = "lblSubscriptionUnit"
        Me.lblSubscriptionUnit.Width = 120
        '
        'lblRedemptionUnit
        '
        Me.lblRedemptionUnit.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblRedemptionUnit.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblRedemptionUnit.Name = "lblRedemptionUnit"
        Me.lblRedemptionUnit.Width = 120
        '
        'lblDividendUnit
        '
        Me.lblDividendUnit.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblDividendUnit.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblDividendUnit.Name = "lblDividendUnit"
        Me.lblDividendUnit.Width = 120
        '
        'InputLabel9
        '
        Me.InputLabel9.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel9.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "Value"
        Me.InputLabel9.Width = 150
        '
        'lblSubscriptionValue
        '
        Me.lblSubscriptionValue.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSubscriptionValue.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSubscriptionValue.Name = "lblSubscriptionValue"
        Me.lblSubscriptionValue.Width = 150
        '
        'lblRedemptionValue
        '
        Me.lblRedemptionValue.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblRedemptionValue.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblRedemptionValue.Name = "lblRedemptionValue"
        Me.lblRedemptionValue.Width = 150
        '
        'lblDividendValue
        '
        Me.lblDividendValue.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblDividendValue.Name = "lblDividendValue"
        Me.lblDividendValue.Width = 150
        '
        'InputGroupHeader3
        '
        Me.InputGroupHeader3.Name = "InputGroupHeader3"
        Me.InputGroupHeader3.Text = "TRANSACTION FILTER"
        '
        'InputLabel2
        '
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Transasction Type: "
        '
        'cmbType
        '
        Me.cmbType.Break = C1.Win.C1InputPanel.BreakType.None
        Me.cmbType.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Width = 150
        '
        'btnExcel
        '
        Me.btnExcel.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Name = "btnExcel"
        '
        'btnPDF
        '
        Me.btnPDF.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnPDF.Enabled = False
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.Name = "btnPDF"
        '
        'btnEmail
        '
        Me.btnEmail.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.Name = "btnEmail"
        '
        'DBGTransaction
        '
        Me.DBGTransaction.BackColor = System.Drawing.Color.White
        Me.DBGTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGTransaction.CaptionHeight = 17
        Me.DBGTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGTransaction.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGTransaction.Images.Add(CType(resources.GetObject("DBGTransaction.Images"), System.Drawing.Image))
        Me.DBGTransaction.Location = New System.Drawing.Point(0, 218)
        Me.DBGTransaction.Name = "DBGTransaction"
        Me.DBGTransaction.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGTransaction.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGTransaction.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGTransaction.PrintInfo.PageSettings = CType(resources.GetObject("DBGTransaction.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGTransaction.PropBag = resources.GetString("DBGTransaction.PropBag")
        Me.DBGTransaction.RecordSelectors = False
        Me.DBGTransaction.RowHeight = 15
        Me.DBGTransaction.Size = New System.Drawing.Size(884, 294)
        Me.DBGTransaction.TabIndex = 10
        '
        'ReportInquiryTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 512)
        Me.Controls.Add(Me.DBGTransaction)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportInquiryTransaction"
        Me.Text = "REPORT: Transaction Inquiry"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBGTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents dtFrom As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents dtTo As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents cmbType As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubscriptionNo As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedemptionNo As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDividendNo As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubscriptionUnit As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents DBGTransaction As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblRedemptionUnit As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDividendUnit As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubscriptionValue As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedemptionValue As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDividendValue As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputGroupHeader3 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents btnExcel As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnPDF As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents cmbCcy As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtPortfolio As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtClient As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
End Class
