<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportFundNAV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportFundNAV))
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.DBGFund = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtAs = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.btnExcelFund = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmailFund = New C1.Win.C1InputPanel.InputButton()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.DBGData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chartData = New C1.Win.C1Chart.C1Chart()
        Me.C1InputPanel2 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.btnSearchPortfolio = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPortfolioCode = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPortfolioName = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtFrom = New C1.Win.C1InputPanel.InputDatePicker()
        Me.dtTo = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearchNAV = New C1.Win.C1InputPanel.InputButton()
        Me.btnExcelNAV = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmailNAV = New C1.Win.C1InputPanel.InputButton()
        Me.InputGroupHeader4 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.rbNAV = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbPrice = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbUnit = New C1.Win.C1InputPanel.InputRadioButton()
        Me.InputGroupHeader3 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.rbTimeDaily = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbTimeWeekly = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbTimeMonthly = New C1.Win.C1InputPanel.InputRadioButton()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblAUM = New C1.Win.C1InputPanel.InputLabel()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.DBGFund, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage2.SuspendLayout()
        CType(Me.DBGData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.ItemSize = New System.Drawing.Size(0, 35)
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 0)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedTabBold = True
        Me.C1DockingTab1.Size = New System.Drawing.Size(884, 462)
        Me.C1DockingTab1.TabIndex = 0
        Me.C1DockingTab1.TabsSpacing = 5
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2010
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.DBGFund)
        Me.C1DockingTabPage1.Controls.Add(Me.C1InputPanel1)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 38)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(882, 423)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "LIST OF FUND"
        '
        'DBGFund
        '
        Me.DBGFund.BackColor = System.Drawing.Color.White
        Me.DBGFund.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGFund.CaptionHeight = 17
        Me.DBGFund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGFund.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGFund.Images.Add(CType(resources.GetObject("DBGFund.Images"), System.Drawing.Image))
        Me.DBGFund.Location = New System.Drawing.Point(0, 47)
        Me.DBGFund.Name = "DBGFund"
        Me.DBGFund.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGFund.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGFund.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGFund.PrintInfo.PageSettings = CType(resources.GetObject("DBGFund.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGFund.PropBag = resources.GetString("DBGFund.PropBag")
        Me.DBGFund.RecordSelectors = False
        Me.DBGFund.RowHeight = 15
        Me.DBGFund.Size = New System.Drawing.Size(882, 376)
        Me.DBGFund.TabIndex = 13
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.dtAs)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Items.Add(Me.btnExcelFund)
        Me.C1InputPanel1.Items.Add(Me.btnEmailFund)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.lblAUM)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(882, 47)
        Me.C1InputPanel1.TabIndex = 6
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "As Of: "
        '
        'dtAs
        '
        Me.dtAs.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.dtAs.Name = "dtAs"
        Me.dtAs.Width = -1
        '
        'btnSearch
        '
        Me.btnSearch.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearch.Height = 40
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.Width = 100
        '
        'btnExcelFund
        '
        Me.btnExcelFund.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelFund.Height = 40
        Me.btnExcelFund.Image = CType(resources.GetObject("btnExcelFund.Image"), System.Drawing.Image)
        Me.btnExcelFund.Name = "btnExcelFund"
        Me.btnExcelFund.Text = "EXCEL"
        Me.btnExcelFund.Width = 100
        '
        'btnEmailFund
        '
        Me.btnEmailFund.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnEmailFund.Height = 40
        Me.btnEmailFund.Image = CType(resources.GetObject("btnEmailFund.Image"), System.Drawing.Image)
        Me.btnEmailFund.Name = "btnEmailFund"
        Me.btnEmailFund.Text = "EMAIL"
        Me.btnEmailFund.Width = 100
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.DBGData)
        Me.C1DockingTabPage2.Controls.Add(Me.chartData)
        Me.C1DockingTabPage2.Controls.Add(Me.C1InputPanel2)
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 38)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(882, 423)
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "HISTORICAL NAV"
        '
        'DBGData
        '
        Me.DBGData.BackColor = System.Drawing.Color.White
        Me.DBGData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGData.Dock = System.Windows.Forms.DockStyle.Left
        Me.DBGData.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGData.Images.Add(CType(resources.GetObject("DBGData.Images"), System.Drawing.Image))
        Me.DBGData.Location = New System.Drawing.Point(682, 172)
        Me.DBGData.Name = "DBGData"
        Me.DBGData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGData.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGData.PrintInfo.PageSettings = CType(resources.GetObject("DBGData.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGData.PropBag = resources.GetString("DBGData.PropBag")
        Me.DBGData.RecordSelectors = False
        Me.DBGData.Size = New System.Drawing.Size(199, 251)
        Me.DBGData.TabIndex = 8
        '
        'chartData
        '
        Me.chartData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.chartData.Dock = System.Windows.Forms.DockStyle.Left
        Me.chartData.Location = New System.Drawing.Point(0, 172)
        Me.chartData.Name = "chartData"
        Me.chartData.PropBag = resources.GetString("chartData.PropBag")
        Me.chartData.Size = New System.Drawing.Size(682, 251)
        Me.chartData.TabIndex = 7
        '
        'C1InputPanel2
        '
        Me.C1InputPanel2.BorderThickness = 1
        Me.C1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel2.Items.Add(Me.btnSearchPortfolio)
        Me.C1InputPanel2.Items.Add(Me.InputLabel3)
        Me.C1InputPanel2.Items.Add(Me.lblPortfolioCode)
        Me.C1InputPanel2.Items.Add(Me.InputLabel4)
        Me.C1InputPanel2.Items.Add(Me.lblPortfolioName)
        Me.C1InputPanel2.Items.Add(Me.lblSimpiEmail)
        Me.C1InputPanel2.Items.Add(Me.lblSimpiName)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel2.Items.Add(Me.InputLabel2)
        Me.C1InputPanel2.Items.Add(Me.dtFrom)
        Me.C1InputPanel2.Items.Add(Me.dtTo)
        Me.C1InputPanel2.Items.Add(Me.btnSearchNAV)
        Me.C1InputPanel2.Items.Add(Me.btnExcelNAV)
        Me.C1InputPanel2.Items.Add(Me.btnEmailNAV)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader4)
        Me.C1InputPanel2.Items.Add(Me.rbNAV)
        Me.C1InputPanel2.Items.Add(Me.rbPrice)
        Me.C1InputPanel2.Items.Add(Me.rbUnit)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader3)
        Me.C1InputPanel2.Items.Add(Me.rbTimeDaily)
        Me.C1InputPanel2.Items.Add(Me.rbTimeWeekly)
        Me.C1InputPanel2.Items.Add(Me.rbTimeMonthly)
        Me.C1InputPanel2.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel2.Name = "C1InputPanel2"
        Me.C1InputPanel2.Size = New System.Drawing.Size(882, 172)
        Me.C1InputPanel2.TabIndex = 6
        Me.C1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        Me.InputGroupHeader2.Text = "MASTER PORTFOLIO"
        '
        'btnSearchPortfolio
        '
        Me.btnSearchPortfolio.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnSearchPortfolio.Height = 35
        Me.btnSearchPortfolio.Image = CType(resources.GetObject("btnSearchPortfolio.Image"), System.Drawing.Image)
        Me.btnSearchPortfolio.Name = "btnSearchPortfolio"
        Me.btnSearchPortfolio.Text = "PORTFOLIO"
        Me.btnSearchPortfolio.Width = 100
        '
        'InputLabel3
        '
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "Fund: "
        '
        'lblPortfolioCode
        '
        Me.lblPortfolioCode.Name = "lblPortfolioCode"
        Me.lblPortfolioCode.Width = 100
        '
        'InputLabel4
        '
        Me.InputLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "Name: "
        '
        'lblPortfolioName
        '
        Me.lblPortfolioName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblPortfolioName.Name = "lblPortfolioName"
        Me.lblPortfolioName.Width = 559
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
        Me.lblSimpiName.Width = 739
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Height = 1
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        '
        'InputLabel2
        '
        Me.InputLabel2.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "From date: "
        Me.InputLabel2.Width = 65
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
        'btnSearchNAV
        '
        Me.btnSearchNAV.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearchNAV.Height = 40
        Me.btnSearchNAV.Image = CType(resources.GetObject("btnSearchNAV.Image"), System.Drawing.Image)
        Me.btnSearchNAV.Name = "btnSearchNAV"
        Me.btnSearchNAV.Text = "SEARCH"
        Me.btnSearchNAV.Width = 100
        '
        'btnExcelNAV
        '
        Me.btnExcelNAV.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelNAV.Height = 40
        Me.btnExcelNAV.Image = CType(resources.GetObject("btnExcelNAV.Image"), System.Drawing.Image)
        Me.btnExcelNAV.Name = "btnExcelNAV"
        Me.btnExcelNAV.Text = "EXCEL"
        Me.btnExcelNAV.Width = 100
        '
        'btnEmailNAV
        '
        Me.btnEmailNAV.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnEmailNAV.Height = 40
        Me.btnEmailNAV.Image = CType(resources.GetObject("btnEmailNAV.Image"), System.Drawing.Image)
        Me.btnEmailNAV.Name = "btnEmailNAV"
        Me.btnEmailNAV.Text = "EMAIL"
        Me.btnEmailNAV.Width = 100
        '
        'InputGroupHeader4
        '
        Me.InputGroupHeader4.Height = 1
        Me.InputGroupHeader4.Name = "InputGroupHeader4"
        '
        'rbNAV
        '
        Me.rbNAV.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbNAV.Checked = True
        Me.rbNAV.Name = "rbNAV"
        Me.rbNAV.Text = "NAV"
        Me.rbNAV.Width = 100
        '
        'rbPrice
        '
        Me.rbPrice.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbPrice.Name = "rbPrice"
        Me.rbPrice.Text = "NAV/Unit"
        Me.rbPrice.Width = 100
        '
        'rbUnit
        '
        Me.rbUnit.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbUnit.Name = "rbUnit"
        Me.rbUnit.Text = "Unit(s)"
        Me.rbUnit.Width = 100
        '
        'InputGroupHeader3
        '
        Me.InputGroupHeader3.Height = 1
        Me.InputGroupHeader3.Name = "InputGroupHeader3"
        '
        'rbTimeDaily
        '
        Me.rbTimeDaily.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbTimeDaily.Checked = True
        Me.rbTimeDaily.Name = "rbTimeDaily"
        Me.rbTimeDaily.Text = "Daily"
        Me.rbTimeDaily.Width = 100
        '
        'rbTimeWeekly
        '
        Me.rbTimeWeekly.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbTimeWeekly.Name = "rbTimeWeekly"
        Me.rbTimeWeekly.Text = "Weekly"
        Me.rbTimeWeekly.Width = 100
        '
        'rbTimeMonthly
        '
        Me.rbTimeMonthly.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbTimeMonthly.Name = "rbTimeMonthly"
        Me.rbTimeMonthly.Text = "Monthly"
        Me.rbTimeMonthly.Width = 100
        '
        'InputLabel5
        '
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Total AUM: "
        Me.InputLabel5.Width = 280
        '
        'lblAUM
        '
        Me.lblAUM.Name = "lblAUM"
        Me.lblAUM.Width = 150
        '
        'ReportFundNAV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 462)
        Me.Controls.Add(Me.C1DockingTab1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportFundNAV"
        Me.Text = "REPORT: Portfolio Net Asset Value"
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        CType(Me.DBGFund, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage2.ResumeLayout(False)
        CType(Me.DBGData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtAs As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnExcelFund As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnEmailFund As C1.Win.C1InputPanel.InputButton
    Friend WithEvents DBGFund As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1InputPanel2 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents btnSearchPortfolio As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPortfolioCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPortfolioName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiEmail As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtFrom As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents dtTo As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearchNAV As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnExcelNAV As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnEmailNAV As C1.Win.C1InputPanel.InputButton
    Friend WithEvents DBGData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chartData As C1.Win.C1Chart.C1Chart
    Friend WithEvents InputGroupHeader4 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents rbNAV As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbPrice As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbUnit As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents InputGroupHeader3 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents rbTimeDaily As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbTimeWeekly As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbTimeMonthly As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblAUM As C1.Win.C1InputPanel.InputLabel
End Class
