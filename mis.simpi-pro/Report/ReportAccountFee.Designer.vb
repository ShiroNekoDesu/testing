<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportAccountFee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAccountFee))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.btnSearchClient = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblClientCode = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblClientName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSalesCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSalesName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtFrom = New C1.Win.C1InputPanel.InputDatePicker()
        Me.dtTo = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.rbFund = New C1.Win.C1InputPanel.InputRadioButton()
        Me.btnSearchPortfolio = New C1.Win.C1InputPanel.InputButton()
        Me.lblPortfolioCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPortfolioName = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiName = New C1.Win.C1InputPanel.InputLabel()
        Me.rbCcy = New C1.Win.C1InputPanel.InputRadioButton()
        Me.cmbCcy = New C1.Win.C1InputPanel.InputComboBox()
        Me.btnExcelDaily = New C1.Win.C1InputPanel.InputButton()
        Me.btnExcelSummary = New C1.Win.C1InputPanel.InputButton()
        Me.btnPDF = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmail = New C1.Win.C1InputPanel.InputButton()
        Me.btnSetting = New C1.Win.C1InputPanel.InputButton()
        Me.lblBalance = New C1.Win.C1InputPanel.InputLabel()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGTransaction = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGFund = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartFee = New C1.Win.C1Chart.C1Chart()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.DBGTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.DBGFund, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.chartFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel1.Items.Add(Me.btnSearchClient)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.lblClientCode)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.lblClientName)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.lblSalesCode)
        Me.C1InputPanel1.Items.Add(Me.lblSalesName)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.dtFrom)
        Me.C1InputPanel1.Items.Add(Me.dtTo)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.rbFund)
        Me.C1InputPanel1.Items.Add(Me.btnSearchPortfolio)
        Me.C1InputPanel1.Items.Add(Me.lblPortfolioCode)
        Me.C1InputPanel1.Items.Add(Me.lblPortfolioName)
        Me.C1InputPanel1.Items.Add(Me.lblSimpiEmail)
        Me.C1InputPanel1.Items.Add(Me.lblSimpiName)
        Me.C1InputPanel1.Items.Add(Me.rbCcy)
        Me.C1InputPanel1.Items.Add(Me.cmbCcy)
        Me.C1InputPanel1.Items.Add(Me.btnExcelDaily)
        Me.C1InputPanel1.Items.Add(Me.btnExcelSummary)
        Me.C1InputPanel1.Items.Add(Me.btnPDF)
        Me.C1InputPanel1.Items.Add(Me.btnEmail)
        Me.C1InputPanel1.Items.Add(Me.btnSetting)
        Me.C1InputPanel1.Items.Add(Me.lblBalance)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(1191, 153)
        Me.C1InputPanel1.TabIndex = 5
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        Me.InputGroupHeader2.Text = "TRANSACTION FILTER"
        '
        'btnSearchClient
        '
        Me.btnSearchClient.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnSearchClient.Height = 40
        Me.btnSearchClient.Image = CType(resources.GetObject("btnSearchClient.Image"), System.Drawing.Image)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Text = "CLIENT"
        Me.btnSearchClient.Width = 100
        '
        'InputLabel7
        '
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "CIF: "
        '
        'lblClientCode
        '
        Me.lblClientCode.Name = "lblClientCode"
        Me.lblClientCode.Width = 150
        '
        'InputLabel8
        '
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Name: "
        '
        'lblClientName
        '
        Me.lblClientName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Width = 429
        '
        'InputLabel5
        '
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Sales Officer: "
        '
        'lblSalesCode
        '
        Me.lblSalesCode.Name = "lblSalesCode"
        Me.lblSalesCode.Width = 100
        '
        'lblSalesName
        '
        Me.lblSalesName.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSalesName.Name = "lblSalesName"
        Me.lblSalesName.Width = 466
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "From date: "
        Me.InputLabel1.Width = 65
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
        'btnSearch
        '
        Me.btnSearch.Height = 40
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.Width = 100
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Height = 1
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        '
        'rbFund
        '
        Me.rbFund.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFund.Name = "rbFund"
        Me.rbFund.Text = "Fund: "
        Me.rbFund.Width = 65
        '
        'btnSearchPortfolio
        '
        Me.btnSearchPortfolio.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearchPortfolio.Height = 35
        Me.btnSearchPortfolio.Image = CType(resources.GetObject("btnSearchPortfolio.Image"), System.Drawing.Image)
        Me.btnSearchPortfolio.Name = "btnSearchPortfolio"
        Me.btnSearchPortfolio.Text = "PORTFOLIO"
        Me.btnSearchPortfolio.Width = 100
        '
        'lblPortfolioCode
        '
        Me.lblPortfolioCode.Name = "lblPortfolioCode"
        Me.lblPortfolioCode.Width = 140
        '
        'lblPortfolioName
        '
        Me.lblPortfolioName.Name = "lblPortfolioName"
        Me.lblPortfolioName.Width = 848
        '
        'lblSimpiEmail
        '
        Me.lblSimpiEmail.Name = "lblSimpiEmail"
        Me.lblSimpiEmail.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        Me.lblSimpiEmail.Width = 1
        '
        'lblSimpiName
        '
        Me.lblSimpiName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSimpiName.Name = "lblSimpiName"
        Me.lblSimpiName.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        Me.lblSimpiName.Width = 1
        '
        'rbCcy
        '
        Me.rbCcy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbCcy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCcy.Name = "rbCcy"
        Me.rbCcy.Text = "Ccy: "
        Me.rbCcy.Width = 65
        '
        'cmbCcy
        '
        Me.cmbCcy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.cmbCcy.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbCcy.Name = "cmbCcy"
        '
        'btnExcelDaily
        '
        Me.btnExcelDaily.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelDaily.Height = 35
        Me.btnExcelDaily.Image = CType(resources.GetObject("btnExcelDaily.Image"), System.Drawing.Image)
        Me.btnExcelDaily.Name = "btnExcelDaily"
        Me.btnExcelDaily.Text = "DAILY"
        Me.btnExcelDaily.Width = 100
        '
        'btnExcelSummary
        '
        Me.btnExcelSummary.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelSummary.Height = 35
        Me.btnExcelSummary.Image = CType(resources.GetObject("btnExcelSummary.Image"), System.Drawing.Image)
        Me.btnExcelSummary.Name = "btnExcelSummary"
        Me.btnExcelSummary.Text = "SUMMARY"
        Me.btnExcelSummary.Width = 100
        '
        'btnPDF
        '
        Me.btnPDF.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnPDF.Enabled = False
        Me.btnPDF.Height = 35
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Text = "PDF"
        Me.btnPDF.Width = 100
        '
        'btnEmail
        '
        Me.btnEmail.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnEmail.Enabled = False
        Me.btnEmail.Height = 35
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Text = "EMAIL"
        Me.btnEmail.Width = 100
        '
        'btnSetting
        '
        Me.btnSetting.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSetting.Enabled = False
        Me.btnSetting.Height = 35
        Me.btnSetting.Image = CType(resources.GetObject("btnSetting.Image"), System.Drawing.Image)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Text = "SETTING"
        Me.btnSetting.Width = 100
        '
        'lblBalance
        '
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        Me.lblBalance.Width = 100
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 153)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1191, 371)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 7
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.DBGTransaction)
        Me.C1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel1.Height = 371
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(595, 350)
        Me.C1SplitterPanel1.TabIndex = 0
        Me.C1SplitterPanel1.Text = "Daily Historical"
        Me.C1SplitterPanel1.Width = 595
        '
        'DBGTransaction
        '
        Me.DBGTransaction.BackColor = System.Drawing.Color.White
        Me.DBGTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGTransaction.CaptionHeight = 17
        Me.DBGTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGTransaction.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGTransaction.Images.Add(CType(resources.GetObject("DBGTransaction.Images"), System.Drawing.Image))
        Me.DBGTransaction.Location = New System.Drawing.Point(0, 0)
        Me.DBGTransaction.Name = "DBGTransaction"
        Me.DBGTransaction.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGTransaction.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGTransaction.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGTransaction.PrintInfo.PageSettings = CType(resources.GetObject("DBGTransaction.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGTransaction.PropBag = resources.GetString("DBGTransaction.PropBag")
        Me.DBGTransaction.RecordSelectors = False
        Me.DBGTransaction.RowHeight = 15
        Me.DBGTransaction.Size = New System.Drawing.Size(595, 350)
        Me.DBGTransaction.TabIndex = 13
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.DBGFund)
        Me.C1SplitterPanel2.Height = 189
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(596, 21)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(595, 168)
        Me.C1SplitterPanel2.SizeRatio = 51.151R
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Text = "Fund Summary"
        Me.C1SplitterPanel2.Width = 595
        '
        'DBGFund
        '
        Me.DBGFund.BackColor = System.Drawing.Color.White
        Me.DBGFund.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGFund.CaptionHeight = 17
        Me.DBGFund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGFund.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGFund.Images.Add(CType(resources.GetObject("DBGFund.Images"), System.Drawing.Image))
        Me.DBGFund.Location = New System.Drawing.Point(0, 0)
        Me.DBGFund.Name = "DBGFund"
        Me.DBGFund.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGFund.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGFund.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGFund.PrintInfo.PageSettings = CType(resources.GetObject("DBGFund.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGFund.PropBag = resources.GetString("DBGFund.PropBag")
        Me.DBGFund.RecordSelectors = False
        Me.DBGFund.RowHeight = 15
        Me.DBGFund.Size = New System.Drawing.Size(595, 168)
        Me.DBGFund.TabIndex = 14
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.BackColor = System.Drawing.Color.White
        Me.C1SplitterPanel3.Controls.Add(Me.chartFee)
        Me.C1SplitterPanel3.Height = 181
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(596, 211)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(595, 160)
        Me.C1SplitterPanel3.TabIndex = 2
        Me.C1SplitterPanel3.Text = "Daily Chart"
        '
        'chartFee
        '
        Me.chartFee.BackColor = System.Drawing.Color.White
        Me.chartFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartFee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartFee.Location = New System.Drawing.Point(0, 0)
        Me.chartFee.Name = "chartFee"
        Me.chartFee.PropBag = resources.GetString("chartFee.PropBag")
        Me.chartFee.Size = New System.Drawing.Size(595, 160)
        Me.chartFee.TabIndex = 17
        '
        'ReportAccountFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 524)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportAccountFee"
        Me.Text = "REPORT: Account Management Fee"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.DBGTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.DBGFund, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.chartFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents btnSearchClient As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblClientCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblClientName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents btnSearchPortfolio As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblPortfolioCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPortfolioName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiEmail As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtFrom As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents dtTo As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents cmbCcy As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents btnExcelDaily As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnPDF As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnSetting As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblBalance As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents rbFund As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbCcy As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents DBGTransaction As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents DBGFund As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents chartFee As C1.Win.C1Chart.C1Chart
    Friend WithEvents btnExcelSummary As C1.Win.C1InputPanel.InputButton
End Class
