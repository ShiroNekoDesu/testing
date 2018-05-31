<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMySales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMySales))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.dtAs = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnLoad = New C1.Win.C1InputPanel.InputButton()
        Me.cmbCcy = New C1.Win.C1InputPanel.InputComboBox()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblTeam = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblLevel = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel13 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSpan = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgAUM = New C1.Win.C1InputPanel.InputImage()
        Me.lblAUMPersen = New C1.Win.C1InputPanel.InputLabel()
        Me.lblAUM = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgFee = New C1.Win.C1InputPanel.InputImage()
        Me.lblFeePersen = New C1.Win.C1InputPanel.InputLabel()
        Me.lblFee = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgSales = New C1.Win.C1InputPanel.InputImage()
        Me.lblSalesPersen = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSales = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgAccount = New C1.Win.C1InputPanel.InputImage()
        Me.lblAccountLast = New C1.Win.C1InputPanel.InputLabel()
        Me.lblAccount = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgCommission = New C1.Win.C1InputPanel.InputImage()
        Me.lblCommissionPersen = New C1.Win.C1InputPanel.InputLabel()
        Me.lblCommission = New C1.Win.C1InputPanel.InputLabel()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitContainer2 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartNAV = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel4 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartSales = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitContainer3 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel5 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartCity = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel6 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartFund = New C1.Win.C1Chart.C1Chart()
        Me.C1SplitterPanel7 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chartAsset = New C1.Win.C1Chart.C1Chart()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer2.SuspendLayout()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.chartNAV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel4.SuspendLayout()
        CType(Me.chartSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.C1SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer3.SuspendLayout()
        Me.C1SplitterPanel5.SuspendLayout()
        CType(Me.chartCity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel6.SuspendLayout()
        CType(Me.chartFund, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel7.SuspendLayout()
        CType(Me.chartAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BackColor = System.Drawing.Color.White
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.dtAs)
        Me.C1InputPanel1.Items.Add(Me.btnLoad)
        Me.C1InputPanel1.Items.Add(Me.cmbCcy)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.lblTeam)
        Me.C1InputPanel1.Items.Add(Me.InputLabel11)
        Me.C1InputPanel1.Items.Add(Me.lblLevel)
        Me.C1InputPanel1.Items.Add(Me.InputLabel13)
        Me.C1InputPanel1.Items.Add(Me.lblSpan)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.imgAUM)
        Me.C1InputPanel1.Items.Add(Me.lblAUMPersen)
        Me.C1InputPanel1.Items.Add(Me.lblAUM)
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.imgFee)
        Me.C1InputPanel1.Items.Add(Me.lblFeePersen)
        Me.C1InputPanel1.Items.Add(Me.lblFee)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.imgSales)
        Me.C1InputPanel1.Items.Add(Me.lblSalesPersen)
        Me.C1InputPanel1.Items.Add(Me.lblSales)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.imgAccount)
        Me.C1InputPanel1.Items.Add(Me.lblAccountLast)
        Me.C1InputPanel1.Items.Add(Me.lblAccount)
        Me.C1InputPanel1.Items.Add(Me.InputLabel9)
        Me.C1InputPanel1.Items.Add(Me.imgCommission)
        Me.C1InputPanel1.Items.Add(Me.lblCommissionPersen)
        Me.C1InputPanel1.Items.Add(Me.lblCommission)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(984, 85)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'dtAs
        '
        Me.dtAs.Name = "dtAs"
        Me.dtAs.Value = New Date(2017, 10, 31, 0, 0, 0, 0)
        '
        'btnLoad
        '
        Me.btnLoad.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnLoad.Height = 50
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageScaling = C1.Win.C1InputPanel.InputImageScaling.Stretch
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.Width = 100
        '
        'cmbCcy
        '
        Me.cmbCcy.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbCcy.Name = "cmbCcy"
        Me.cmbCcy.Width = 75
        '
        'InputLabel8
        '
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Team#: "
        Me.InputLabel8.Width = 45
        '
        'lblTeam
        '
        Me.lblTeam.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Text = " "
        Me.lblTeam.Width = 25
        '
        'InputLabel11
        '
        Me.InputLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel11.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel11.Name = "InputLabel11"
        Me.InputLabel11.Text = "Level: "
        Me.InputLabel11.Width = 45
        '
        'lblLevel
        '
        Me.lblLevel.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Text = " "
        Me.lblLevel.Width = 25
        '
        'InputLabel13
        '
        Me.InputLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel13.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel13.Name = "InputLabel13"
        Me.InputLabel13.Text = "Span: "
        Me.InputLabel13.Width = 45
        '
        'lblSpan
        '
        Me.lblSpan.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSpan.Name = "lblSpan"
        Me.lblSpan.Text = " "
        Me.lblSpan.Width = 25
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.ForeColor = System.Drawing.Color.Transparent
        Me.InputLabel1.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "Asset Under Mgmnt"
        Me.InputLabel1.Width = 120
        '
        'imgAUM
        '
        Me.imgAUM.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgAUM.Height = 38
        Me.imgAUM.Image = CType(resources.GetObject("imgAUM.Image"), System.Drawing.Image)
        Me.imgAUM.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleRight
        Me.imgAUM.Name = "imgAUM"
        Me.imgAUM.Width = 50
        '
        'lblAUMPersen
        '
        Me.lblAUMPersen.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblAUMPersen.Name = "lblAUMPersen"
        Me.lblAUMPersen.Text = " "
        Me.lblAUMPersen.Width = 65
        '
        'lblAUM
        '
        Me.lblAUM.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblAUM.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblAUM.Name = "lblAUM"
        Me.lblAUM.Text = " "
        Me.lblAUM.Width = 120
        '
        'InputLabel3
        '
        Me.InputLabel3.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "Management Fee"
        Me.InputLabel3.Width = 120
        '
        'imgFee
        '
        Me.imgFee.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgFee.Height = 38
        Me.imgFee.Image = CType(resources.GetObject("imgFee.Image"), System.Drawing.Image)
        Me.imgFee.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleRight
        Me.imgFee.Name = "imgFee"
        Me.imgFee.Width = 50
        '
        'lblFeePersen
        '
        Me.lblFeePersen.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblFeePersen.Name = "lblFeePersen"
        Me.lblFeePersen.Text = " "
        Me.lblFeePersen.Width = 65
        '
        'lblFee
        '
        Me.lblFee.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblFee.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblFee.Name = "lblFee"
        Me.lblFee.Text = " "
        Me.lblFee.Width = 120
        '
        'InputLabel5
        '
        Me.InputLabel5.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Net Sales"
        Me.InputLabel5.Width = 120
        '
        'imgSales
        '
        Me.imgSales.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgSales.Height = 38
        Me.imgSales.Image = CType(resources.GetObject("imgSales.Image"), System.Drawing.Image)
        Me.imgSales.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleRight
        Me.imgSales.Name = "imgSales"
        Me.imgSales.Width = 50
        '
        'lblSalesPersen
        '
        Me.lblSalesPersen.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSalesPersen.Name = "lblSalesPersen"
        Me.lblSalesPersen.Text = " "
        Me.lblSalesPersen.Width = 65
        '
        'lblSales
        '
        Me.lblSales.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSales.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Text = " "
        Me.lblSales.Width = 120
        '
        'InputLabel7
        '
        Me.InputLabel7.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "NTA/LA"
        Me.InputLabel7.Width = 120
        '
        'imgAccount
        '
        Me.imgAccount.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgAccount.Height = 38
        Me.imgAccount.Image = CType(resources.GetObject("imgAccount.Image"), System.Drawing.Image)
        Me.imgAccount.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleRight
        Me.imgAccount.Name = "imgAccount"
        Me.imgAccount.Width = 50
        '
        'lblAccountLast
        '
        Me.lblAccountLast.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblAccountLast.Name = "lblAccountLast"
        Me.lblAccountLast.Text = " "
        Me.lblAccountLast.Width = 65
        '
        'lblAccount
        '
        Me.lblAccount.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblAccount.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Text = " "
        Me.lblAccount.Width = 120
        '
        'InputLabel9
        '
        Me.InputLabel9.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel9.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "Commission"
        Me.InputLabel9.Width = 120
        '
        'imgCommission
        '
        Me.imgCommission.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgCommission.Height = 38
        Me.imgCommission.Image = CType(resources.GetObject("imgCommission.Image"), System.Drawing.Image)
        Me.imgCommission.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleRight
        Me.imgCommission.Name = "imgCommission"
        Me.imgCommission.Width = 50
        '
        'lblCommissionPersen
        '
        Me.lblCommissionPersen.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblCommissionPersen.Name = "lblCommissionPersen"
        Me.lblCommissionPersen.Text = " "
        Me.lblCommissionPersen.Width = 65
        '
        'lblCommission
        '
        Me.lblCommission.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblCommission.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblCommission.Name = "lblCommission"
        Me.lblCommission.Text = " "
        Me.lblCommission.Width = 120
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 85)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(984, 427)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 1
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.C1SplitContainer2)
        Me.C1SplitterPanel1.Height = 213
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(984, 213)
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitContainer2
        '
        Me.C1SplitContainer2.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer2.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer2.Name = "C1SplitContainer2"
        Me.C1SplitContainer2.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer2.Panels.Add(Me.C1SplitterPanel4)
        Me.C1SplitContainer2.Size = New System.Drawing.Size(984, 213)
        Me.C1SplitContainer2.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer2.SplitterWidth = 1
        Me.C1SplitContainer2.TabIndex = 0
        Me.C1SplitContainer2.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.Controls.Add(Me.chartNAV)
        Me.C1SplitterPanel3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(645, 192)
        Me.C1SplitterPanel3.SizeRatio = 65.648R
        Me.C1SplitterPanel3.TabIndex = 0
        Me.C1SplitterPanel3.Text = "AUM & Fee Growth"
        Me.C1SplitterPanel3.Width = 645
        '
        'chartNAV
        '
        Me.chartNAV.BackColor = System.Drawing.Color.White
        Me.chartNAV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartNAV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartNAV.Location = New System.Drawing.Point(0, 0)
        Me.chartNAV.Name = "chartNAV"
        Me.chartNAV.PropBag = resources.GetString("chartNAV.PropBag")
        Me.chartNAV.Size = New System.Drawing.Size(645, 192)
        Me.chartNAV.TabIndex = 14
        '
        'C1SplitterPanel4
        '
        Me.C1SplitterPanel4.Controls.Add(Me.chartSales)
        Me.C1SplitterPanel4.Height = 213
        Me.C1SplitterPanel4.Location = New System.Drawing.Point(646, 21)
        Me.C1SplitterPanel4.Name = "C1SplitterPanel4"
        Me.C1SplitterPanel4.Size = New System.Drawing.Size(338, 192)
        Me.C1SplitterPanel4.TabIndex = 1
        Me.C1SplitterPanel4.Text = "Top Sales"
        '
        'chartSales
        '
        Me.chartSales.BackColor = System.Drawing.Color.White
        Me.chartSales.DataSource = Me.C1InputPanel1.ToolTipSettings.Images
        Me.chartSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartSales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartSales.Location = New System.Drawing.Point(0, 0)
        Me.chartSales.Name = "chartSales"
        Me.chartSales.PropBag = resources.GetString("chartSales.PropBag")
        Me.chartSales.Size = New System.Drawing.Size(338, 192)
        Me.chartSales.TabIndex = 0
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.C1SplitContainer3)
        Me.C1SplitterPanel2.Height = 213
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(0, 214)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(984, 213)
        Me.C1SplitterPanel2.TabIndex = 1
        '
        'C1SplitContainer3
        '
        Me.C1SplitContainer3.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer3.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitContainer3.Name = "C1SplitContainer3"
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel5)
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel6)
        Me.C1SplitContainer3.Panels.Add(Me.C1SplitterPanel7)
        Me.C1SplitContainer3.Size = New System.Drawing.Size(984, 213)
        Me.C1SplitContainer3.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer3.SplitterWidth = 1
        Me.C1SplitContainer3.TabIndex = 0
        Me.C1SplitContainer3.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'C1SplitterPanel5
        '
        Me.C1SplitterPanel5.Controls.Add(Me.chartCity)
        Me.C1SplitterPanel5.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel5.Location = New System.Drawing.Point(0, 21)
        Me.C1SplitterPanel5.Name = "C1SplitterPanel5"
        Me.C1SplitterPanel5.Size = New System.Drawing.Size(323, 192)
        Me.C1SplitterPanel5.SizeRatio = 32.885R
        Me.C1SplitterPanel5.TabIndex = 0
        Me.C1SplitterPanel5.Text = "by City"
        Me.C1SplitterPanel5.Width = 323
        '
        'chartCity
        '
        Me.chartCity.BackColor = System.Drawing.Color.White
        Me.chartCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartCity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartCity.Location = New System.Drawing.Point(0, 0)
        Me.chartCity.Name = "chartCity"
        Me.chartCity.PropBag = resources.GetString("chartCity.PropBag")
        Me.chartCity.Size = New System.Drawing.Size(323, 192)
        Me.chartCity.TabIndex = 0
        '
        'C1SplitterPanel6
        '
        Me.C1SplitterPanel6.Controls.Add(Me.chartFund)
        Me.C1SplitterPanel6.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel6.Location = New System.Drawing.Point(324, 21)
        Me.C1SplitterPanel6.Name = "C1SplitterPanel6"
        Me.C1SplitterPanel6.Size = New System.Drawing.Size(364, 192)
        Me.C1SplitterPanel6.SizeRatio = 55.292R
        Me.C1SplitterPanel6.TabIndex = 1
        Me.C1SplitterPanel6.Text = "by Fund"
        Me.C1SplitterPanel6.Width = 364
        '
        'chartFund
        '
        Me.chartFund.BackColor = System.Drawing.Color.White
        Me.chartFund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartFund.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartFund.Location = New System.Drawing.Point(0, 0)
        Me.chartFund.Name = "chartFund"
        Me.chartFund.PropBag = resources.GetString("chartFund.PropBag")
        Me.chartFund.Size = New System.Drawing.Size(364, 192)
        Me.chartFund.TabIndex = 0
        '
        'C1SplitterPanel7
        '
        Me.C1SplitterPanel7.Controls.Add(Me.chartAsset)
        Me.C1SplitterPanel7.Height = 213
        Me.C1SplitterPanel7.Location = New System.Drawing.Point(689, 21)
        Me.C1SplitterPanel7.Name = "C1SplitterPanel7"
        Me.C1SplitterPanel7.Size = New System.Drawing.Size(295, 192)
        Me.C1SplitterPanel7.TabIndex = 2
        Me.C1SplitterPanel7.Text = "by Asset Type"
        '
        'chartAsset
        '
        Me.chartAsset.BackColor = System.Drawing.Color.White
        Me.chartAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartAsset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chartAsset.Location = New System.Drawing.Point(0, 0)
        Me.chartAsset.Name = "chartAsset"
        Me.chartAsset.PropBag = resources.GetString("chartAsset.PropBag")
        Me.chartAsset.Size = New System.Drawing.Size(295, 192)
        Me.chartAsset.TabIndex = 2
        '
        'FormMySales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 512)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMySales"
        Me.Text = "sales -> MyDashboard: AVR-0001 Fahmi Arya"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.C1SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer2.ResumeLayout(False)
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.chartNAV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel4.ResumeLayout(False)
        CType(Me.chartSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.C1SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer3.ResumeLayout(False)
        Me.C1SplitterPanel5.ResumeLayout(False)
        CType(Me.chartCity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel6.ResumeLayout(False)
        CType(Me.chartFund, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel7.ResumeLayout(False)
        CType(Me.chartAsset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgAUM As C1.Win.C1InputPanel.InputImage
    Friend WithEvents lblAUMPersen As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgFee As C1.Win.C1InputPanel.InputImage
    Friend WithEvents lblFee As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgSales As C1.Win.C1InputPanel.InputImage
    Friend WithEvents lblSales As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgAccount As C1.Win.C1InputPanel.InputImage
    Friend WithEvents lblAccount As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgCommission As C1.Win.C1InputPanel.InputImage
    Friend WithEvents lblCommission As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitContainer2 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel4 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitContainer3 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel5 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel6 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel7 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents chartAsset As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartNAV As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartSales As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartCity As C1.Win.C1Chart.C1Chart
    Friend WithEvents chartFund As C1.Win.C1Chart.C1Chart
    Friend WithEvents cmbCcy As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblTeam As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel13 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSpan As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtAs As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnLoad As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblLevel As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblAUM As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblFeePersen As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesPersen As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblAccountLast As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblCommissionPersen As C1.Win.C1InputPanel.InputLabel
End Class
