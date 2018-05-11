<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPortfolioStrategy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPortfolioStrategy))
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGDate = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGAsOf = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1SplitterPanel3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.DBGAll = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1InputPanel2 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.lblPortfolioCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPortfolioName = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiEmail = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSimpiName = New C1.Win.C1InputPanel.InputLabel()
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitContainer1.SuspendLayout()
        Me.C1SplitterPanel1.SuspendLayout()
        CType(Me.DBGDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel2.SuspendLayout()
        CType(Me.DBGAsOf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1SplitterPanel3.SuspendLayout()
        CType(Me.DBGAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1SplitContainer1.BorderWidth = 1
        Me.C1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.C1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(0, 50)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel3)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(846, 473)
        Me.C1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 0
        Me.C1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.C1SplitContainer1.UseParentVisualStyle = False
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Controls.Add(Me.DBGDate)
        Me.C1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left
        Me.C1SplitterPanel1.Height = 471
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(1, 22)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(166, 450)
        Me.C1SplitterPanel1.SizeRatio = 19.692R
        Me.C1SplitterPanel1.TabIndex = 0
        Me.C1SplitterPanel1.Text = "Historical"
        Me.C1SplitterPanel1.Width = 166
        '
        'DBGDate
        '
        Me.DBGDate.AllowDrag = True
        Me.DBGDate.BackColor = System.Drawing.Color.White
        Me.DBGDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGDate.CaptionHeight = 17
        Me.DBGDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGDate.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGDate.Images.Add(CType(resources.GetObject("DBGDate.Images"), System.Drawing.Image))
        Me.DBGDate.Location = New System.Drawing.Point(0, 0)
        Me.DBGDate.Name = "DBGDate"
        Me.DBGDate.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGDate.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGDate.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGDate.PrintInfo.PageSettings = CType(resources.GetObject("DBGDate.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGDate.PropBag = resources.GetString("DBGDate.PropBag")
        Me.DBGDate.RecordSelectors = False
        Me.DBGDate.RowHeight = 15
        Me.DBGDate.Size = New System.Drawing.Size(166, 450)
        Me.DBGDate.TabIndex = 11
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Controls.Add(Me.DBGAsOf)
        Me.C1SplitterPanel2.Height = 152
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(168, 22)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(677, 131)
        Me.C1SplitterPanel2.SizeRatio = 32.34R
        Me.C1SplitterPanel2.TabIndex = 1
        Me.C1SplitterPanel2.Text = "As Of: "
        '
        'DBGAsOf
        '
        Me.DBGAsOf.AllowDrag = True
        Me.DBGAsOf.BackColor = System.Drawing.Color.White
        Me.DBGAsOf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGAsOf.CaptionHeight = 17
        Me.DBGAsOf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGAsOf.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGAsOf.Images.Add(CType(resources.GetObject("DBGAsOf.Images"), System.Drawing.Image))
        Me.DBGAsOf.Location = New System.Drawing.Point(0, 0)
        Me.DBGAsOf.Name = "DBGAsOf"
        Me.DBGAsOf.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGAsOf.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGAsOf.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGAsOf.PrintInfo.PageSettings = CType(resources.GetObject("DBGAsOf.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGAsOf.PropBag = resources.GetString("DBGAsOf.PropBag")
        Me.DBGAsOf.RecordSelectors = False
        Me.DBGAsOf.RowHeight = 15
        Me.DBGAsOf.Size = New System.Drawing.Size(677, 131)
        Me.DBGAsOf.TabIndex = 11
        '
        'C1SplitterPanel3
        '
        Me.C1SplitterPanel3.Controls.Add(Me.DBGAll)
        Me.C1SplitterPanel3.Height = 318
        Me.C1SplitterPanel3.Location = New System.Drawing.Point(168, 175)
        Me.C1SplitterPanel3.Name = "C1SplitterPanel3"
        Me.C1SplitterPanel3.Size = New System.Drawing.Size(677, 297)
        Me.C1SplitterPanel3.TabIndex = 2
        Me.C1SplitterPanel3.Text = "List All Portfolio Strategy"
        '
        'DBGAll
        '
        Me.DBGAll.AllowDrag = True
        Me.DBGAll.BackColor = System.Drawing.Color.White
        Me.DBGAll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGAll.CaptionHeight = 17
        Me.DBGAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGAll.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGAll.Images.Add(CType(resources.GetObject("DBGAll.Images"), System.Drawing.Image))
        Me.DBGAll.Location = New System.Drawing.Point(0, 0)
        Me.DBGAll.Name = "DBGAll"
        Me.DBGAll.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGAll.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGAll.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGAll.PrintInfo.PageSettings = CType(resources.GetObject("DBGAll.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGAll.PropBag = resources.GetString("DBGAll.PropBag")
        Me.DBGAll.RecordSelectors = False
        Me.DBGAll.RowHeight = 15
        Me.DBGAll.Size = New System.Drawing.Size(677, 297)
        Me.DBGAll.TabIndex = 11
        '
        'C1InputPanel2
        '
        Me.C1InputPanel2.BorderThickness = 1
        Me.C1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel2.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel2.Items.Add(Me.lblPortfolioCode)
        Me.C1InputPanel2.Items.Add(Me.lblPortfolioName)
        Me.C1InputPanel2.Items.Add(Me.lblSimpiEmail)
        Me.C1InputPanel2.Items.Add(Me.lblSimpiName)
        Me.C1InputPanel2.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel2.Name = "C1InputPanel2"
        Me.C1InputPanel2.Size = New System.Drawing.Size(846, 50)
        Me.C1InputPanel2.TabIndex = 15
        Me.C1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        Me.InputGroupHeader2.Text = "MASTER PORTFOLIO"
        '
        'lblPortfolioCode
        '
        Me.lblPortfolioCode.Name = "lblPortfolioCode"
        Me.lblPortfolioCode.Width = 100
        '
        'lblPortfolioName
        '
        Me.lblPortfolioName.Name = "lblPortfolioName"
        Me.lblPortfolioName.Width = 714
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
        'ReportPortfolioStrategy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 523)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.Controls.Add(Me.C1InputPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportPortfolioStrategy"
        Me.Text = "PRODUCT FOCUS: Portfolio Strategy"
        CType(Me.C1SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitContainer1.ResumeLayout(False)
        Me.C1SplitterPanel1.ResumeLayout(False)
        CType(Me.DBGDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel2.ResumeLayout(False)
        CType(Me.DBGAsOf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1SplitterPanel3.ResumeLayout(False)
        CType(Me.DBGAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1InputPanel2 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents lblPortfolioCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPortfolioName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiEmail As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSimpiName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents DBGDate As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DBGAsOf As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DBGAll As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
