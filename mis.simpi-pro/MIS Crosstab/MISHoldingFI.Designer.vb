<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MISHoldingFI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MISHoldingFI))
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
        Me.btnPDF = New C1.Win.C1InputPanel.InputButton()
        Me.btnEmail = New C1.Win.C1InputPanel.InputButton()
        Me.btnSetting = New C1.Win.C1InputPanel.InputButton()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitContainer2 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartTTM = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel6 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartBond = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel7 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartYTM = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitContainer3 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel5 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartDuration = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel8 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartRating = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel9 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartYield = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGHolding = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer2.SuspendLayout()
        Me.C1SplitterPanel4.SuspendLayout()
        CType(Me.chartTTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel6.SuspendLayout()
        CType(Me.chartBond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel7.SuspendLayout()
        CType(Me.chartYTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.C1SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer3.SuspendLayout()
        Me.C1SplitterPanel5.SuspendLayout()
        CType(Me.chartDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel8.SuspendLayout()
        CType(Me.chartRating, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel9.SuspendLayout()
        CType(Me.chartYield, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.DBGHolding, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1InputPanel1.Items.Add(Me.btnPDF)
        Me.C1InputPanel1.Items.Add(Me.btnEmail)
        Me.C1InputPanel1.Items.Add(Me.btnSetting)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(1185, 56)
        Me.C1InputPanel1.TabIndex = 6
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Height = 24
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
        Me.lblPortfolioName.Width = 691
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
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.White
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 56)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1185, 516)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 7
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.C1SplitContainer2)
        Me.C1SplitterPanel1.Height = 161
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(1185, 161)
        Me.C1SplitterPanel1.SizeRatio = 31.311R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitContainer2
        '
        Me.C1SplitContainer2.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer2.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer2.Name = "C1SplitContainer2"
        Me.C1SplitContainer2.Panels.Add(Me.C1SplitterPanel4)
        Me.C1SplitContainer2.Panels.Add(Me.C1SplitterPanel6)
        Me.C1SplitContainer2.Panels.Add(Me.C1SplitterPanel7)
        Me.C1SplitContainer2.Size = New System.Drawing.Size(1185, 161)
        Me.C1SplitContainer2.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer2.SplitterWidth = 1
        Me.C1SplitContainer2.TabIndex = 0
        Me.C1SplitContainer2.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer2.UseParentVisualStyle = False
        '
        'C1SplitterPanel4
        '
        Me.C1SplitterPanel4.Controls.Add(Me.chartTTM)
        Me.C1SplitterPanel4.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel4.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel4.Name = "C1SplitterPanel4"
        Me.C1SplitterPanel4.Size = New System.Drawing.Size(401, 140)
        Me.C1SplitterPanel4.SizeRatio = 33.868R
        Me.C1SplitterPanel4.TabIndex = 0
        Me.C1SplitterPanel4.Text = "Time To Maturity"
        Me.C1SplitterPanel4.Width = 401
        '
        'chartTTM
        '
        Me.chartTTM.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartTTM.BackColor = System.Drawing.Color.White
        Me.chartTTM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartTTM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartTTM.Location = New System.Drawing.Point(0, 0)
        Me.chartTTM.Name = "chartTTM"
        Me.chartTTM.PropBag = resources.GetString("chartTTM.PropBag")
        Me.chartTTM.Size = New System.Drawing.Size(401, 140)
        Me.chartTTM.TabIndex = 6
        '
        'C1SplitterPanel6
        '
        Me.C1SplitterPanel6.Controls.Add(Me.chartBond)
        Me.C1SplitterPanel6.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel6.Location = New System.Drawing.Point(402, 21)
        Me.C1SplitterPanel6.Name = "C1SplitterPanel6"
        Me.C1SplitterPanel6.Size = New System.Drawing.Size(401, 140)
        Me.C1SplitterPanel6.SizeRatio = 51.279R
        Me.C1SplitterPanel6.TabIndex = 1
        Me.C1SplitterPanel6.Text = "Bond Type"
        Me.C1SplitterPanel6.Width = 401
        '
        'chartBond
        '
        Me.chartBond.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartBond.BackColor = System.Drawing.Color.White
        Me.chartBond.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartBond.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartBond.Location = New System.Drawing.Point(0, 0)
        Me.chartBond.Name = "chartBond"
        Me.chartBond.PropBag = resources.GetString("chartBond.PropBag")
        Me.chartBond.Size = New System.Drawing.Size(401, 140)
        Me.chartBond.TabIndex = 6
        '
        'C1SplitterPanel7
        '
        Me.C1SplitterPanel7.Controls.Add(Me.chartYTM)
        Me.C1SplitterPanel7.Height = 161
        Me.C1SplitterPanel7.Location = New System.Drawing.Point(804, 21)
        Me.C1SplitterPanel7.Name = "C1SplitterPanel7"
        Me.C1SplitterPanel7.Size = New System.Drawing.Size(381, 140)
        Me.C1SplitterPanel7.TabIndex = 2
        Me.C1SplitterPanel7.Text = "YTM"
        '
        'chartYTM
        '
        Me.chartYTM.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartYTM.BackColor = System.Drawing.Color.White
        Me.chartYTM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartYTM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartYTM.Location = New System.Drawing.Point(0, 0)
        Me.chartYTM.Name = "chartYTM"
        Me.chartYTM.PropBag = resources.GetString("chartYTM.PropBag")
        Me.chartYTM.Size = New System.Drawing.Size(381, 140)
        Me.chartYTM.TabIndex = 6
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.C1SplitContainer3)
        Me.C1SplitterPanel2.Height = 164
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(0, 162)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(1185, 164)
        Me.C1SplitterPanel2.SizeRatio = 46.571R
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Width = 1185
        '
        'C1SplitContainer3
        '
        Me.C1SplitContainer3.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer3.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer3.Name = "C1SplitContainer3"
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel5)
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel8)
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel9)
        Me.C1SplitContainer3.Size = New System.Drawing.Size(1185, 164)
        Me.C1SplitContainer3.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer3.SplitterWidth = 1
        Me.C1SplitContainer3.TabIndex = 0
        Me.C1SplitContainer3.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer3.UseParentVisualStyle = False
        '
        'C1SplitterPanel5
        '
        Me.C1SplitterPanel5.Controls.Add(Me.chartDuration)
        Me.C1SplitterPanel5.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel5.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel5.Name = "C1SplitterPanel5"
        Me.C1SplitterPanel5.Size = New System.Drawing.Size(401, 143)
        Me.C1SplitterPanel5.SizeRatio = 33.868R
        Me.C1SplitterPanel5.TabIndex = 0
        Me.C1SplitterPanel5.Text = "Duration"
        Me.C1SplitterPanel5.Width = 401
        '
        'chartDuration
        '
        Me.chartDuration.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartDuration.BackColor = System.Drawing.Color.White
        Me.chartDuration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartDuration.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartDuration.Location = New System.Drawing.Point(0, 0)
        Me.chartDuration.Name = "chartDuration"
        Me.chartDuration.PropBag = resources.GetString("chartDuration.PropBag")
        Me.chartDuration.Size = New System.Drawing.Size(401, 143)
        Me.chartDuration.TabIndex = 6
        '
        'C1SplitterPanel8
        '
        Me.C1SplitterPanel8.Controls.Add(Me.chartRating)
        Me.C1SplitterPanel8.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel8.Location = New System.Drawing.Point(402, 21)
        Me.C1SplitterPanel8.Name = "C1SplitterPanel8"
        Me.C1SplitterPanel8.Size = New System.Drawing.Size(401, 143)
        Me.C1SplitterPanel8.SizeRatio = 51.279R
        Me.C1SplitterPanel8.TabIndex = 1
        Me.C1SplitterPanel8.Text = "Rating"
        Me.C1SplitterPanel8.Width = 401
        '
        'chartRating
        '
        Me.chartRating.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartRating.BackColor = System.Drawing.Color.White
        Me.chartRating.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartRating.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartRating.Location = New System.Drawing.Point(0, 0)
        Me.chartRating.Name = "chartRating"
        Me.chartRating.PropBag = resources.GetString("chartRating.PropBag")
        Me.chartRating.Size = New System.Drawing.Size(401, 143)
        Me.chartRating.TabIndex = 6
        '
        'C1SplitterPanel9
        '
        Me.C1SplitterPanel9.Controls.Add(Me.chartYield)
        Me.C1SplitterPanel9.Height = 164
        Me.C1SplitterPanel9.Location = New System.Drawing.Point(804, 21)
        Me.C1SplitterPanel9.Name = "C1SplitterPanel9"
        Me.C1SplitterPanel9.Size = New System.Drawing.Size(381, 143)
        Me.C1SplitterPanel9.TabIndex = 2
        Me.C1SplitterPanel9.Text = "Current Yield"
        '
        'chartYield
        '
        Me.chartYield.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.chartYield.BackColor = System.Drawing.Color.White
        Me.chartYield.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartYield.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartYield.Location = New System.Drawing.Point(0, 0)
        Me.chartYield.Name = "chartYield"
        Me.chartYield.PropBag = resources.GetString("chartYield.PropBag")
        Me.chartYield.Size = New System.Drawing.Size(381, 143)
        Me.chartYield.TabIndex = 6
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.Controls.Add(Me.DBGHolding)
        Me.C1SplitterPanel3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom
        Me.C1SplitterPanel3.Height = 189
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(0, 348)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(1185, 168)
        Me.C1SplitterPanel3.SizeRatio = 34.023R
        Me.C1SplitterPanel3.TabIndex = 2
        Me.C1SplitterPanel3.Text = "Bond Holding"
        Me.C1SplitterPanel3.Width = 1185
        '
        'DBGHolding
        '
        Me.DBGHolding.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGHolding.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGHolding.Images.Add(CType(resources.GetObject("DBGHolding.Images"), System.Drawing.Image))
        Me.DBGHolding.Location = New System.Drawing.Point(0, 0)
        Me.DBGHolding.Name = "DBGHolding"
        Me.DBGHolding.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGHolding.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGHolding.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGHolding.PrintInfo.PageSettings = CType(resources.GetObject("DBGHolding.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGHolding.PropBag = resources.GetString("DBGHolding.PropBag")
        Me.DBGHolding.Size = New System.Drawing.Size(1185, 168)
        Me.DBGHolding.TabIndex = 23
        '
        'ReportHoldingFI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 572)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportHoldingFI"
        Me.Text = "REPORT: FIXED INCOME POSITION"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer2.ResumeLayout(False)
        Me.C1SplitterPanel4.ResumeLayout(False)
        CType(Me.chartTTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel6.ResumeLayout(False)
        CType(Me.chartBond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel7.ResumeLayout(False)
        CType(Me.chartYTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.C1SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer3.ResumeLayout(False)
        Me.C1SplitterPanel5.ResumeLayout(False)
        CType(Me.chartDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel8.ResumeLayout(False)
        CType(Me.chartRating, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel9.ResumeLayout(False)
        CType(Me.chartYield, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.DBGHolding, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnPDF As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnSetting As C1.Win.C1InputPanel.InputButton
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitContainer2 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel6 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel7 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitContainer3 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel5 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel8 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel9 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents chartTTM As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartBond As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartYTM As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartDuration As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartRating As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartYield As C1.Win.C1Chart.C1Chart
    Friend WithEvents DBGHolding As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
