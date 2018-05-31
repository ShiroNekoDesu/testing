<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MISHoldingTD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MISHoldingTD))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtAs = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.rbFund = New C1.Win.C1InputPanel.InputRadioButton()
        Me.btnSearchPortfolio = New C1.Win.C1InputPanel.InputButton()
        Me.lblPortfolioCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPortfolioName = New C1.Win.C1InputPanel.InputLabel()
        Me.rbCcy = New C1.Win.C1InputPanel.InputRadioButton()
        Me.cmbCcy = New C1.Win.C1InputPanel.InputComboBox()
        Me.lblSimpiEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiName = New C1.Win.C1InputPanel.InputLabel()
        Me.btnExcelDaily = New C1.Win.C1InputPanel.InputButton()
        Me.btnExcelSummary = New C1.Win.C1InputPanel.InputButton()
        Me.btnPDF = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmail = New C1.Win.C1InputPanel.InputButton()
        Me.btnSetting = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtAUM = New C1.Win.C1InputPanel.InputTextBox()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGTD = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGBank = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartTerm = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGAging = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.DBGTD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.DBGBank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.chartTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel4.SuspendLayout()
        CType(Me.DBGAging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.dtAs)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Items.Add(Me.rbFund)
        Me.C1InputPanel1.Items.Add(Me.btnSearchPortfolio)
        Me.C1InputPanel1.Items.Add(Me.lblPortfolioCode)
        Me.C1InputPanel1.Items.Add(Me.lblPortfolioName)
        Me.C1InputPanel1.Items.Add(Me.rbCcy)
        Me.C1InputPanel1.Items.Add(Me.cmbCcy)
        Me.C1InputPanel1.Items.Add(Me.lblSimpiEmail)
        Me.C1InputPanel1.Items.Add(Me.lblSimpiName)
        Me.C1InputPanel1.Items.Add(Me.btnExcelDaily)
        Me.C1InputPanel1.Items.Add(Me.btnExcelSummary)
        Me.C1InputPanel1.Items.Add(Me.btnPDF)
        Me.C1InputPanel1.Items.Add(Me.btnEmail)
        Me.C1InputPanel1.Items.Add(Me.btnSetting)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.txtAUM)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(1040, 57)
        Me.C1InputPanel1.TabIndex = 6
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Height = 23
        Me.InputLabel1.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "As Of: "
        Me.InputLabel1.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel1.Width = 100
        '
        'dtAs
        '
        Me.dtAs.Break = C1.Win.C1InputPanel.BreakType.None
        Me.dtAs.Name = "dtAs"
        '
        'btnSearch
        '
        Me.btnSearch.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.ToolTipText = "Display client investment information"
        '
        'rbFund
        '
        Me.rbFund.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFund.Name = "rbFund"
        Me.rbFund.Text = "Fund: "
        Me.rbFund.Width = 75
        '
        'btnSearchPortfolio
        '
        Me.btnSearchPortfolio.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearchPortfolio.Enabled = False
        Me.btnSearchPortfolio.Image = CType(resources.GetObject("btnSearchPortfolio.Image"), System.Drawing.Image)
        Me.btnSearchPortfolio.Name = "btnSearchPortfolio"
        Me.btnSearchPortfolio.ToolTipText = "Search master portfolio"
        '
        'lblPortfolioCode
        '
        Me.lblPortfolioCode.Name = "lblPortfolioCode"
        Me.lblPortfolioCode.Width = 130
        '
        'lblPortfolioName
        '
        Me.lblPortfolioName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblPortfolioName.Name = "lblPortfolioName"
        Me.lblPortfolioName.Width = 638
        '
        'rbCcy
        '
        Me.rbCcy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbCcy.Checked = True
        Me.rbCcy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCcy.Name = "rbCcy"
        Me.rbCcy.Text = "Ccy: "
        Me.rbCcy.Width = 75
        '
        'cmbCcy
        '
        Me.cmbCcy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.cmbCcy.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbCcy.Name = "cmbCcy"
        '
        'lblSimpiEmail
        '
        Me.lblSimpiEmail.Name = "lblSimpiEmail"
        Me.lblSimpiEmail.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        Me.lblSimpiEmail.Width = 1
        '
        'lblSimpiName
        '
        Me.lblSimpiName.Name = "lblSimpiName"
        Me.lblSimpiName.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        Me.lblSimpiName.Width = 1
        '
        'btnExcelDaily
        '
        Me.btnExcelDaily.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelDaily.Image = CType(resources.GetObject("btnExcelDaily.Image"), System.Drawing.Image)
        Me.btnExcelDaily.Name = "btnExcelDaily"
        Me.btnExcelDaily.ToolTipText = "Export daily historical to excel"
        '
        'btnExcelSummary
        '
        Me.btnExcelSummary.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnExcelSummary.Image = CType(resources.GetObject("btnExcelSummary.Image"), System.Drawing.Image)
        Me.btnExcelSummary.Name = "btnExcelSummary"
        Me.btnExcelSummary.ToolTipText = "Export fund summary to excel"
        '
        'btnPDF
        '
        Me.btnPDF.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnPDF.Enabled = False
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.ToolTipText = "Generate pdf report"
        '
        'btnEmail
        '
        Me.btnEmail.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnEmail.Enabled = False
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.ToolTipText = "Send to email with excel or pdf attachment"
        '
        'btnSetting
        '
        Me.btnSetting.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSetting.Enabled = False
        Me.btnSetting.Image = CType(resources.GetObject("btnSetting.Image"), System.Drawing.Image)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.ToolTipText = "Set pdf layout reporting"
        '
        'InputLabel2
        '
        Me.InputLabel2.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "AUM: "
        Me.InputLabel2.Width = 397
        '
        'txtAUM
        '
        Me.txtAUM.Name = "txtAUM"
        Me.txtAUM.ReadOnly = True
        Me.txtAUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAUM.Width = 150
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 57)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel4)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1040, 500)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 7
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.BackColor = System.Drawing.Color.White
        Me.C1SplitterPanel1.Controls.Add(Me.DBGTD)
        Me.C1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom
        Me.C1SplitterPanel1.Height = 287
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 234)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(1040, 266)
        Me.C1SplitterPanel1.SizeRatio = 57.46R
        Me.C1SplitterPanel1.TabIndex = 0
        Me.C1SplitterPanel1.Text = "TD Placement"
        '
        'DBGTD
        '
        Me.DBGTD.BackColor = System.Drawing.Color.White
        Me.DBGTD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGTD.CaptionHeight = 17
        Me.DBGTD.Dock = System.Windows.Forms.DockStyle.Top
        Me.DBGTD.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGTD.Images.Add(CType(resources.GetObject("DBGTD.Images"), System.Drawing.Image))
        Me.DBGTD.Location = New System.Drawing.Point(0, 0)
        Me.DBGTD.Name = "DBGTD"
        Me.DBGTD.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGTD.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGTD.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGTD.PrintInfo.PageSettings = CType(resources.GetObject("DBGTD.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGTD.PropBag = resources.GetString("DBGTD.PropBag")
        Me.DBGTD.RecordSelectors = False
        Me.DBGTD.RowHeight = 15
        Me.DBGTD.Size = New System.Drawing.Size(1040, 263)
        Me.DBGTD.TabIndex = 11
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.BackColor = System.Drawing.Color.White
        Me.C1SplitterPanel2.Controls.Add(Me.DBGBank)
        Me.C1SplitterPanel2.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(402, 191)
        Me.C1SplitterPanel2.SizeRatio = 38.691R
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Text = "Bank"
        Me.C1SplitterPanel2.Width = 402
        '
        'DBGBank
        '
        Me.DBGBank.BackColor = System.Drawing.Color.White
        Me.DBGBank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGBank.CaptionHeight = 17
        Me.DBGBank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGBank.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGBank.Images.Add(CType(resources.GetObject("DBGBank.Images"), System.Drawing.Image))
        Me.DBGBank.Location = New System.Drawing.Point(0, 0)
        Me.DBGBank.Name = "DBGBank"
        Me.DBGBank.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGBank.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGBank.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGBank.PrintInfo.PageSettings = CType(resources.GetObject("DBGBank.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGBank.PropBag = resources.GetString("DBGBank.PropBag")
        Me.DBGBank.RecordSelectors = False
        Me.DBGBank.RowHeight = 15
        Me.DBGBank.Size = New System.Drawing.Size(402, 191)
        Me.DBGBank.TabIndex = 12
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.BackColor = System.Drawing.Color.White
        Me.C1SplitterPanel3.Controls.Add(Me.chartTerm)
        Me.C1SplitterPanel3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(403, 21)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(340, 191)
        Me.C1SplitterPanel3.SizeRatio = 53.459R
        Me.C1SplitterPanel3.TabIndex = 2
        Me.C1SplitterPanel3.Text = "TD Term"
        Me.C1SplitterPanel3.Width = 340
        '
        'chartTerm
        '
        Me.chartTerm.BackColor = System.Drawing.Color.White
        Me.chartTerm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartTerm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartTerm.Location = New System.Drawing.Point(0, 0)
        Me.chartTerm.Name = "chartTerm"
        Me.chartTerm.PropBag = resources.GetString("chartTerm.PropBag")
        Me.chartTerm.Size = New System.Drawing.Size(340, 191)
        Me.chartTerm.TabIndex = 3
        '
        'C1SplitterPanel4
        '
        Me.C1SplitterPanel4.BackColor = System.Drawing.Color.White
        Me.C1SplitterPanel4.Controls.Add(Me.DBGAging)
        Me.C1SplitterPanel4.Height = 212
        Me.C1SplitterPanel4.Location = New System.Drawing.Point(744, 21)
        Me.C1SplitterPanel4.Name = "C1SplitterPanel4"
        Me.C1SplitterPanel4.Size = New System.Drawing.Size(296, 191)
        Me.C1SplitterPanel4.TabIndex = 3
        Me.C1SplitterPanel4.Text = "Maturity Pofile"
        '
        'DBGAging
        '
        Me.DBGAging.BackColor = System.Drawing.Color.White
        Me.DBGAging.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGAging.CaptionHeight = 17
        Me.DBGAging.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGAging.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGAging.Images.Add(CType(resources.GetObject("DBGAging.Images"), System.Drawing.Image))
        Me.DBGAging.Location = New System.Drawing.Point(0, 0)
        Me.DBGAging.Name = "DBGAging"
        Me.DBGAging.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGAging.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGAging.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGAging.PrintInfo.PageSettings = CType(resources.GetObject("DBGAging.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGAging.PropBag = resources.GetString("DBGAging.PropBag")
        Me.DBGAging.RecordSelectors = False
        Me.DBGAging.RowHeight = 15
        Me.DBGAging.Size = New System.Drawing.Size(296, 191)
        Me.DBGAging.TabIndex = 13
        '
        'ReportHoldingTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 557)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportHoldingTD"
        Me.Text = "REPORT: TIME DEPOSIT POSITION"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.DBGTD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.DBGBank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.chartTerm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel4.ResumeLayout(False)
        CType(Me.DBGAging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents rbFund As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents btnSearchPortfolio As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblPortfolioCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPortfolioName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents rbCcy As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents cmbCcy As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents lblSimpiEmail As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtAs As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnExcelDaily As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnExcelSummary As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnPDF As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnSetting As C1.Win.C1InputPanel.InputButton
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents DBGTD As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DBGBank As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chartTerm As C1.Win.C1Chart.C1Chart
    Friend WithEvents DBGAging As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtAUM As C1.Win.C1InputPanel.InputTextBox
End Class
