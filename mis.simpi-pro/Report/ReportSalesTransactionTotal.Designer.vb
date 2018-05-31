<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportSalesTransactionTotal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSalesTransactionTotal))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.btnSearchSales = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel14 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSalesCode = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel15 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSalesName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.dtFrom = New C1.Win.C1InputPanel.InputDatePicker()
        Me.dtTo = New C1.Win.C1InputPanel.InputDatePicker()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.InputGroupHeader3 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel13 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel16 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsNoSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsNoST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsNoSA = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsNoSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsNoST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsNoSA = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivNoSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivNoST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivNoSA = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel29 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel30 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel31 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel27 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsValueSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsValueST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblSubsValueSA = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsValueSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsValueST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblRedsValueSA = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivValueSD = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivValueST = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDivValueSA = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader4 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.cmbCcy = New C1.Win.C1InputPanel.InputComboBox()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.rbSalesDirect = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbSalesTeam = New C1.Win.C1InputPanel.InputRadioButton()
        Me.rbSalesAll = New C1.Win.C1InputPanel.InputRadioButton()
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
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.btnSearchSales)
        Me.C1InputPanel1.Items.Add(Me.InputLabel14)
        Me.C1InputPanel1.Items.Add(Me.lblSalesCode)
        Me.C1InputPanel1.Items.Add(Me.InputLabel15)
        Me.C1InputPanel1.Items.Add(Me.lblSalesName)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.dtFrom)
        Me.C1InputPanel1.Items.Add(Me.dtTo)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader3)
        Me.C1InputPanel1.Items.Add(Me.InputLabel6)
        Me.C1InputPanel1.Items.Add(Me.InputLabel10)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.InputLabel9)
        Me.C1InputPanel1.Items.Add(Me.InputLabel11)
        Me.C1InputPanel1.Items.Add(Me.InputLabel12)
        Me.C1InputPanel1.Items.Add(Me.InputLabel13)
        Me.C1InputPanel1.Items.Add(Me.InputLabel16)
        Me.C1InputPanel1.Items.Add(Me.lblSubsNoSD)
        Me.C1InputPanel1.Items.Add(Me.lblSubsNoST)
        Me.C1InputPanel1.Items.Add(Me.lblSubsNoSA)
        Me.C1InputPanel1.Items.Add(Me.lblRedsNoSD)
        Me.C1InputPanel1.Items.Add(Me.lblRedsNoST)
        Me.C1InputPanel1.Items.Add(Me.lblRedsNoSA)
        Me.C1InputPanel1.Items.Add(Me.lblDivNoSD)
        Me.C1InputPanel1.Items.Add(Me.lblDivNoST)
        Me.C1InputPanel1.Items.Add(Me.lblDivNoSA)
        Me.C1InputPanel1.Items.Add(Me.InputLabel29)
        Me.C1InputPanel1.Items.Add(Me.InputLabel30)
        Me.C1InputPanel1.Items.Add(Me.InputLabel31)
        Me.C1InputPanel1.Items.Add(Me.InputLabel27)
        Me.C1InputPanel1.Items.Add(Me.lblSubsValueSD)
        Me.C1InputPanel1.Items.Add(Me.lblSubsValueST)
        Me.C1InputPanel1.Items.Add(Me.lblSubsValueSA)
        Me.C1InputPanel1.Items.Add(Me.lblRedsValueSD)
        Me.C1InputPanel1.Items.Add(Me.lblRedsValueST)
        Me.C1InputPanel1.Items.Add(Me.lblRedsValueSA)
        Me.C1InputPanel1.Items.Add(Me.lblDivValueSD)
        Me.C1InputPanel1.Items.Add(Me.lblDivValueST)
        Me.C1InputPanel1.Items.Add(Me.lblDivValueSA)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader4)
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.cmbCcy)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.rbSalesDirect)
        Me.C1InputPanel1.Items.Add(Me.rbSalesTeam)
        Me.C1InputPanel1.Items.Add(Me.rbSalesAll)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.cmbType)
        Me.C1InputPanel1.Items.Add(Me.btnExcel)
        Me.C1InputPanel1.Items.Add(Me.btnPDF)
        Me.C1InputPanel1.Items.Add(Me.btnEmail)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(941, 249)
        Me.C1InputPanel1.TabIndex = 6
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "SALES OFFICER"
        '
        'btnSearchSales
        '
        Me.btnSearchSales.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnSearchSales.Height = 40
        Me.btnSearchSales.Image = CType(resources.GetObject("btnSearchSales.Image"), System.Drawing.Image)
        Me.btnSearchSales.Name = "btnSearchSales"
        Me.btnSearchSales.Text = "SALES"
        Me.btnSearchSales.Width = 100
        '
        'InputLabel14
        '
        Me.InputLabel14.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel14.Name = "InputLabel14"
        Me.InputLabel14.Text = "Code: "
        '
        'lblSalesCode
        '
        Me.lblSalesCode.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSalesCode.Name = "lblSalesCode"
        Me.lblSalesCode.Width = 100
        '
        'InputLabel15
        '
        Me.InputLabel15.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel15.Name = "InputLabel15"
        Me.InputLabel15.Text = "Name: "
        '
        'lblSalesName
        '
        Me.lblSalesName.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblSalesName.Name = "lblSalesName"
        Me.lblSalesName.Width = 372
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
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
        Me.btnSearch.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearch.Height = 40
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.Width = 100
        '
        'InputGroupHeader3
        '
        Me.InputGroupHeader3.Name = "InputGroupHeader3"
        Me.InputGroupHeader3.Text = "TRANSACTION SUMMARY"
        '
        'InputLabel6
        '
        Me.InputLabel6.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "Summary"
        Me.InputLabel6.Width = 75
        '
        'InputLabel10
        '
        Me.InputLabel10.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel10.Name = "InputLabel10"
        Me.InputLabel10.Width = 75
        '
        'InputLabel7
        '
        Me.InputLabel7.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "Subscription"
        Me.InputLabel7.Width = 75
        '
        'InputLabel8
        '
        Me.InputLabel8.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Redemption"
        Me.InputLabel8.Width = 75
        '
        'InputLabel9
        '
        Me.InputLabel9.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "Dividend"
        Me.InputLabel9.Width = 75
        '
        'InputLabel11
        '
        Me.InputLabel11.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel11.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel11.Name = "InputLabel11"
        Me.InputLabel11.Text = "No Of Transaction"
        Me.InputLabel11.Width = 128
        '
        'InputLabel12
        '
        Me.InputLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel12.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel12.Name = "InputLabel12"
        Me.InputLabel12.Text = "Direct"
        Me.InputLabel12.Width = 40
        '
        'InputLabel13
        '
        Me.InputLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel13.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel13.Name = "InputLabel13"
        Me.InputLabel13.Text = "Team"
        Me.InputLabel13.Width = 40
        '
        'InputLabel16
        '
        Me.InputLabel16.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel16.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel16.Name = "InputLabel16"
        Me.InputLabel16.Text = "All"
        Me.InputLabel16.Width = 40
        '
        'lblSubsNoSD
        '
        Me.lblSubsNoSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblSubsNoSD.Name = "lblSubsNoSD"
        Me.lblSubsNoSD.Width = 40
        '
        'lblSubsNoST
        '
        Me.lblSubsNoST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblSubsNoST.Name = "lblSubsNoST"
        Me.lblSubsNoST.Width = 40
        '
        'lblSubsNoSA
        '
        Me.lblSubsNoSA.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSubsNoSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblSubsNoSA.Name = "lblSubsNoSA"
        Me.lblSubsNoSA.Width = 40
        '
        'lblRedsNoSD
        '
        Me.lblRedsNoSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblRedsNoSD.Name = "lblRedsNoSD"
        Me.lblRedsNoSD.Width = 40
        '
        'lblRedsNoST
        '
        Me.lblRedsNoST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblRedsNoST.Name = "lblRedsNoST"
        Me.lblRedsNoST.Width = 40
        '
        'lblRedsNoSA
        '
        Me.lblRedsNoSA.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblRedsNoSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblRedsNoSA.Name = "lblRedsNoSA"
        Me.lblRedsNoSA.Width = 40
        '
        'lblDivNoSD
        '
        Me.lblDivNoSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDivNoSD.Name = "lblDivNoSD"
        Me.lblDivNoSD.Width = 40
        '
        'lblDivNoST
        '
        Me.lblDivNoST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDivNoST.Name = "lblDivNoST"
        Me.lblDivNoST.Width = 40
        '
        'lblDivNoSA
        '
        Me.lblDivNoSA.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblDivNoSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblDivNoSA.Name = "lblDivNoSA"
        Me.lblDivNoSA.Width = 40
        '
        'InputLabel29
        '
        Me.InputLabel29.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel29.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel29.Name = "InputLabel29"
        Me.InputLabel29.Text = "Value"
        Me.InputLabel29.Width = 350
        '
        'InputLabel30
        '
        Me.InputLabel30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel30.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel30.Name = "InputLabel30"
        Me.InputLabel30.Text = "Direct Sales"
        Me.InputLabel30.Width = 120
        '
        'InputLabel31
        '
        Me.InputLabel31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel31.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel31.Name = "InputLabel31"
        Me.InputLabel31.Text = "Team Sales"
        Me.InputLabel31.Width = 120
        '
        'InputLabel27
        '
        Me.InputLabel27.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel27.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel27.Name = "InputLabel27"
        Me.InputLabel27.Text = "All Sales"
        Me.InputLabel27.Width = 120
        '
        'lblSubsValueSD
        '
        Me.lblSubsValueSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSubsValueSD.Name = "lblSubsValueSD"
        Me.lblSubsValueSD.Width = 120
        '
        'lblSubsValueST
        '
        Me.lblSubsValueST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSubsValueST.Name = "lblSubsValueST"
        Me.lblSubsValueST.Width = 120
        '
        'lblSubsValueSA
        '
        Me.lblSubsValueSA.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSubsValueSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblSubsValueSA.Name = "lblSubsValueSA"
        Me.lblSubsValueSA.Width = 120
        '
        'lblRedsValueSD
        '
        Me.lblRedsValueSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblRedsValueSD.Name = "lblRedsValueSD"
        Me.lblRedsValueSD.Width = 120
        '
        'lblRedsValueST
        '
        Me.lblRedsValueST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblRedsValueST.Name = "lblRedsValueST"
        Me.lblRedsValueST.Width = 120
        '
        'lblRedsValueSA
        '
        Me.lblRedsValueSA.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblRedsValueSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblRedsValueSA.Name = "lblRedsValueSA"
        Me.lblRedsValueSA.Width = 120
        '
        'lblDivValueSD
        '
        Me.lblDivValueSD.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblDivValueSD.Name = "lblDivValueSD"
        Me.lblDivValueSD.Width = 120
        '
        'lblDivValueST
        '
        Me.lblDivValueST.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblDivValueST.Name = "lblDivValueST"
        Me.lblDivValueST.Width = 120
        '
        'lblDivValueSA
        '
        Me.lblDivValueSA.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.lblDivValueSA.Name = "lblDivValueSA"
        Me.lblDivValueSA.Width = 120
        '
        'InputGroupHeader4
        '
        Me.InputGroupHeader4.Name = "InputGroupHeader4"
        Me.InputGroupHeader4.Text = "TRANSACTION FILTER"
        '
        'InputLabel3
        '
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "Ccy: "
        '
        'cmbCcy
        '
        Me.cmbCcy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.cmbCcy.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList
        Me.cmbCcy.Name = "cmbCcy"
        Me.cmbCcy.Width = 50
        '
        'InputLabel5
        '
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Level: "
        '
        'rbSalesDirect
        '
        Me.rbSalesDirect.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbSalesDirect.Name = "rbSalesDirect"
        Me.rbSalesDirect.Text = "Direct Sales"
        '
        'rbSalesTeam
        '
        Me.rbSalesTeam.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbSalesTeam.Name = "rbSalesTeam"
        Me.rbSalesTeam.Text = "Team Sales"
        '
        'rbSalesAll
        '
        Me.rbSalesAll.Break = C1.Win.C1InputPanel.BreakType.None
        Me.rbSalesAll.Checked = True
        Me.rbSalesAll.Name = "rbSalesAll"
        Me.rbSalesAll.Text = "All Sales"
        '
        'InputLabel2
        '
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Trans. Type: "
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
        Me.btnExcel.Height = 40
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Text = "EXCEL"
        Me.btnExcel.Width = 100
        '
        'btnPDF
        '
        Me.btnPDF.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnPDF.Enabled = False
        Me.btnPDF.Height = 40
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Text = "PDF"
        Me.btnPDF.Width = 100
        '
        'btnEmail
        '
        Me.btnEmail.Height = 35
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Text = "EMAIL"
        Me.btnEmail.Width = 100
        '
        'DBGTransaction
        '
        Me.DBGTransaction.BackColor = System.Drawing.Color.White
        Me.DBGTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DBGTransaction.CaptionHeight = 17
        Me.DBGTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DBGTransaction.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGTransaction.Images.Add(CType(resources.GetObject("DBGTransaction.Images"), System.Drawing.Image))
        Me.DBGTransaction.Location = New System.Drawing.Point(0, 249)
        Me.DBGTransaction.Name = "DBGTransaction"
        Me.DBGTransaction.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGTransaction.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGTransaction.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGTransaction.PrintInfo.PageSettings = CType(resources.GetObject("DBGTransaction.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGTransaction.PropBag = resources.GetString("DBGTransaction.PropBag")
        Me.DBGTransaction.RecordSelectors = False
        Me.DBGTransaction.RowHeight = 15
        Me.DBGTransaction.Size = New System.Drawing.Size(941, 270)
        Me.DBGTransaction.TabIndex = 14
        '
        'ReportSalesTransactionTotal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 519)
        Me.Controls.Add(Me.DBGTransaction)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportSalesTransactionTotal"
        Me.Text = "REPORT: Sales Total Transaction"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBGTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents btnSearchSales As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel14 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel15 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSalesName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents dtFrom As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents dtTo As C1.Win.C1InputPanel.InputDatePicker
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputGroupHeader3 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel13 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel16 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsNoSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsNoST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsNoSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsNoSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsNoST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsNoSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivNoSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivNoST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivNoSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel29 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel30 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel31 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel27 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsValueSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsValueST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblSubsValueSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsValueSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsValueST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblRedsValueSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivValueSD As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivValueST As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDivValueSA As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputGroupHeader4 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents rbSalesDirect As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbSalesTeam As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents rbSalesAll As C1.Win.C1InputPanel.InputRadioButton
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents cmbType As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents btnExcel As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnPDF As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents cmbCcy As C1.Win.C1InputPanel.InputComboBox
    Friend WithEvents DBGTransaction As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnEmail As C1.Win.C1InputPanel.InputButton
End Class
