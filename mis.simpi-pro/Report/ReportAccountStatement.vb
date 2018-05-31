Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.ParameterTA
Imports simpi.ParameterTA.ParameterTA
Imports C1.Win.C1Chart
Imports simpi.GlobalUtilities.GlobalString
Imports simpi.GlobalConnection
Imports System.Drawing.Imaging
Imports simpi.MasterPortfolio
Imports simpi.MasterClient

Public Class ReportAccountStatement
    Dim objPortfolio As New MasterPortfolio
    Dim objCodeset As New PortfolioCodeset
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi
    Dim objCapital As New TransactionCapital
    Dim objNAV As New PortfolioNAV
    Dim objUnit As New PositionCapital
    Dim objClient As New MasterClient

    Dim dtTransaction As New DataTable
    Dim dtValue As New DataTable
    Dim saldoUnit As Double = 0
    Dim beginingValue As Double = 0

    Dim minDate, maxDate As Date
    Dim minY, minY2, maxY, maxY2, lastPrice As Double
    Dim reportSection As String = "REPORT ACCOUNT HOLDER ACCOUNT STATEMENT"
    Dim priceDigit As String = ""
    Public pdfLayout As New pdfColor

#Region "pdf"
    Structure pdfColor
        Public layoutType As String
        Public ReportTitle_R As Integer
        Public ReportTitle_G As Integer
        Public ReportTitle_B As Integer
        Public ReportTitle As String
        Public Client_R As Integer
        Public Client_G As Integer
        Public Client_B As Integer
        Public Period As String
        Public NAVUnit_R As Integer
        Public NAVUnit_G As Integer
        Public NAVUnit_B As Integer
        Public NAVUnit As String
        Public ReportLine_R As Integer
        Public ReportLine_G As Integer
        Public ReportLine_B As Integer
        Public Portfolio_R As Integer
        Public Portfolio_G As Integer
        Public Portfolio_B As Integer
        Public Summary_R As Integer
        Public Summary_G As Integer
        Public Summary_B As Integer
        Public Summary As String
        Public SummaryLine_R As Integer
        Public SummaryLine_G As Integer
        Public SummaryLine_B As Integer
        Public SummaryItems_R As Integer
        Public SummaryItems_G As Integer
        Public SummaryItems_B As Integer
        Public SummaryItemsTotalRedemption As String
        Public SummaryItemsAcqCost As String
        Public SummaryItemsRedemptionPL As String
        Public SummaryItemsDividend As String
        Public SummaryItemsRealizedPL As String
        Public SummaryItemsLastInvestmentValue As String
        Public SummaryItemsLastAcqCost As String
        Public SummaryItemsUnrealizedPL As String
        Public ChartTitle_R As Integer
        Public ChartTitle_G As Integer
        Public ChartTitle_B As Integer
        Public InvestmentGrowth As String
        Public ChartBorder_R As Integer
        Public ChartBorder_G As Integer
        Public ChartBorder_B As Integer
        Public ChartBorder As Boolean
        Public ChartLine_R As Integer
        Public ChartLine_G As Integer
        Public ChartLine_B As Integer
        Public ChartLabel As String
        Public TableHeader_R As Integer
        Public TableHeader_G As Integer
        Public TableHeader_B As Integer
        Public TableLine_R As Integer
        Public TableLine_G As Integer
        Public TableLine_B As Integer
        Public TableItems_R As Integer
        Public TableItems_G As Integer
        Public TableItems_B As Integer
        Public TableTitle_R As Integer
        Public TableTitle_G As Integer
        Public TableTitle_B As Integer
        Public TableTitleTanggal As String
        Public TableTitleDate As String
        Public TableTitleUraian As String
        Public TableTitleDescription As String
        Public TableTitleNilaiTransaksi As String
        Public TableTitleGross As String
        Public TableTitleNet As String
        Public TableTitleHargaUP As String
        Public TableTitleNAVUnit As String
        Public TableTitleUnitPenyertaan As String
        Public TableTitleBiayaPerolehan As String
        Public TableTitleAcqCost As String
        Public TableTitleLRRealisasi As String
        Public TableTitleRealizedPL As String
        Public TableTitleSaldoUP As String
        Public TableTitleBalanceUnit As String
    End Structure

    Public Sub pdfColorDefault()
        pdfLayout.layoutType = "DEFAULT"
        pdfLayout.ReportTitle_R = 0
        pdfLayout.ReportTitle_G = 61
        pdfLayout.ReportTitle_B = 121
        pdfLayout.ReportTitle = "ACCOUNT STATEMENT"

        pdfLayout.Client_R = 0
        pdfLayout.Client_G = 61
        pdfLayout.Client_B = 121
        pdfLayout.Period = "Period"

        pdfLayout.NAVUnit_R = 0
        pdfLayout.NAVUnit_G = 61
        pdfLayout.NAVUnit_B = 121
        pdfLayout.NAVUnit = "NAV/Unit: "

        pdfLayout.ReportLine_R = 255
        pdfLayout.ReportLine_G = 153
        pdfLayout.ReportLine_B = 51

        pdfLayout.Portfolio_R = 0
        pdfLayout.Portfolio_G = 61
        pdfLayout.Portfolio_B = 121

        pdfLayout.Summary_R = 0
        pdfLayout.Summary_G = 61
        pdfLayout.Summary_B = 121
        pdfLayout.Summary = "Summary"

        pdfLayout.SummaryLine_R = 255
        pdfLayout.SummaryLine_G = 153
        pdfLayout.SummaryLine_B = 51

        pdfLayout.SummaryItems_R = 0
        pdfLayout.SummaryItems_G = 0
        pdfLayout.SummaryItems_B = 0
        pdfLayout.SummaryItemsTotalRedemption = "Total Redemption: "
        pdfLayout.SummaryItemsAcqCost = "Acq. Cost: "
        pdfLayout.SummaryItemsRedemptionPL = "Redemption P/L: "
        pdfLayout.SummaryItemsDividend = "Dividend: "
        pdfLayout.SummaryItemsRealizedPL = "Realized P/L: "
        pdfLayout.SummaryItemsLastInvestmentValue = "Last Investment Value: "
        pdfLayout.SummaryItemsLastAcqCost = "Acq. Cost: "
        pdfLayout.SummaryItemsUnrealizedPL = "Unrealized P/L: "

        pdfLayout.ChartTitle_R = 0
        pdfLayout.ChartTitle_G = 61
        pdfLayout.ChartTitle_B = 121
        pdfLayout.InvestmentGrowth = "Investment Growth"

        pdfLayout.ChartBorder_R = 0
        pdfLayout.ChartBorder_G = 0
        pdfLayout.ChartBorder_B = 0
        pdfLayout.ChartBorder = False

        pdfLayout.ChartLine_R = 77
        pdfLayout.ChartLine_G = 183
        pdfLayout.ChartLine_B = 136
        pdfLayout.ChartLabel = "investment value within period: unit(s) balance * unit price"

        pdfLayout.TableHeader_R = 255
        pdfLayout.TableHeader_G = 153
        pdfLayout.TableHeader_B = 51

        pdfLayout.TableLine_R = 255
        pdfLayout.TableLine_G = 153
        pdfLayout.TableLine_B = 51

        pdfLayout.TableItems_R = 0
        pdfLayout.TableItems_G = 0
        pdfLayout.TableItems_B = 0

        pdfLayout.TableTitle_R = 255
        pdfLayout.TableTitle_G = 255
        pdfLayout.TableTitle_B = 255

        pdfLayout.TableTitleTanggal = "Tanggal"
        pdfLayout.TableTitleDate = "Date"
        pdfLayout.TableTitleUraian = "Uraian"
        pdfLayout.TableTitleDescription = "Description"
        pdfLayout.TableTitleNilaiTransaksi = "Nilai Transaksi"
        pdfLayout.TableTitleGross = "Gross"
        pdfLayout.TableTitleNet = "Net"
        pdfLayout.TableTitleHargaUP = "Harga/UP"
        pdfLayout.TableTitleNAVUnit = "NAV/Unit"
        pdfLayout.TableTitleUnitPenyertaan = "Unit Penyertaan"
        pdfLayout.TableTitleBiayaPerolehan = "Biaya Perolehan"
        pdfLayout.TableTitleAcqCost = "Acq. Cost"
        pdfLayout.TableTitleLRRealisasi = "L/R Realisasi"
        pdfLayout.TableTitleRealizedPL = "Realized P/L"
        pdfLayout.TableTitleSaldoUP = "Saldo (UP)"
        pdfLayout.TableTitleBalanceUnit = "Balance (Units)"
    End Sub

    Private Sub pdfSetting()
        Try
            Dim strFile As String = simpiFile("simpi.ini")
            If GlobalFileWindows.FileExists(strFile) Then
                Dim file As New GlobalINI(strFile)
                Dim iniType As String = file.GetString(reportSection, "LAYOUT", "")
                If iniType = "" Or iniType = "DEFAULT" Then
                    pdfColorDefault()
                Else
                    pdfLayout.layoutType = iniType
                    pdfLayout.ReportTitle_R = file.GetInteger(reportSection, iniType & " Report Title R", 0)
                    pdfLayout.ReportTitle_G = file.GetInteger(reportSection, iniType & " Report Title G", 0)
                    pdfLayout.ReportTitle_B = file.GetInteger(reportSection, iniType & " Report Title B", 0)
                    pdfLayout.ReportTitle = file.GetString(reportSection, iniType & " Report Title", "")

                    pdfLayout.Client_R = file.GetInteger(reportSection, iniType & " Client R", 0)
                    pdfLayout.Client_G = file.GetInteger(reportSection, iniType & " Client G", 0)
                    pdfLayout.Client_B = file.GetInteger(reportSection, iniType & " Client B", 0)
                    pdfLayout.Period = file.GetString(reportSection, iniType & " Period", "")

                    pdfLayout.NAVUnit_R = file.GetInteger(reportSection, iniType & " NAV/Unit R", 0)
                    pdfLayout.NAVUnit_G = file.GetInteger(reportSection, iniType & " NAV/Unit G", 0)
                    pdfLayout.NAVUnit_B = file.GetInteger(reportSection, iniType & " NAV/Unit B", 0)
                    pdfLayout.NAVUnit = file.GetString(reportSection, iniType & " NAV/Unit", "")

                    pdfLayout.ReportLine_R = file.GetInteger(reportSection, iniType & " Report Line R", 0)
                    pdfLayout.ReportLine_G = file.GetInteger(reportSection, iniType & " Report Line G", 0)
                    pdfLayout.ReportLine_B = file.GetInteger(reportSection, iniType & " Report Line B", 0)

                    pdfLayout.Portfolio_R = file.GetInteger(reportSection, iniType & " Portfolio R", 0)
                    pdfLayout.Portfolio_G = file.GetInteger(reportSection, iniType & " Portfolio G", 0)
                    pdfLayout.Portfolio_B = file.GetInteger(reportSection, iniType & " Portfolio B", 0)

                    pdfLayout.Summary_R = file.GetInteger(reportSection, iniType & " Summary R", 0)
                    pdfLayout.Summary_G = file.GetInteger(reportSection, iniType & " Summary G", 0)
                    pdfLayout.Summary_B = file.GetInteger(reportSection, iniType & " Summary B", 0)
                    pdfLayout.Summary = file.GetString(reportSection, iniType & " Summary", "")

                    pdfLayout.SummaryLine_R = file.GetInteger(reportSection, iniType & " Summary Line R", 0)
                    pdfLayout.SummaryLine_G = file.GetInteger(reportSection, iniType & " Summary Line G", 0)
                    pdfLayout.SummaryLine_B = file.GetInteger(reportSection, iniType & " Summary Line B", 0)

                    pdfLayout.SummaryItems_R = file.GetInteger(reportSection, iniType & " Summary Items R", 0)
                    pdfLayout.SummaryItems_G = file.GetInteger(reportSection, iniType & " Summary Items G", 0)
                    pdfLayout.SummaryItems_B = file.GetInteger(reportSection, iniType & " Summary Items B", 0)
                    pdfLayout.SummaryItemsTotalRedemption = file.GetString(reportSection, iniType & " Summary Items Total Redemption", "")
                    pdfLayout.SummaryItemsAcqCost = file.GetString(reportSection, iniType & " Summary Items Acq Cost", "")
                    pdfLayout.SummaryItemsRedemptionPL = file.GetString(reportSection, iniType & " Summary Items Redemption PL", "")
                    pdfLayout.SummaryItemsDividend = file.GetString(reportSection, iniType & " Summary Items Dividend", "")
                    pdfLayout.SummaryItemsRealizedPL = file.GetString(reportSection, iniType & " Summary Items Realized PL", "")
                    pdfLayout.SummaryItemsLastInvestmentValue = file.GetString(reportSection, iniType & " Summary Items Last Investment Value", "")
                    pdfLayout.SummaryItemsLastAcqCost = file.GetString(reportSection, iniType & " Summary Items Last Acq Cost", "")
                    pdfLayout.SummaryItemsUnrealizedPL = file.GetString(reportSection, iniType & " Summary Items Unrealized PL", "")

                    pdfLayout.ChartTitle_R = file.GetInteger(reportSection, iniType & " Chart Title R", 0)
                    pdfLayout.ChartTitle_G = file.GetInteger(reportSection, iniType & " Chart Title G", 0)
                    pdfLayout.ChartTitle_B = file.GetInteger(reportSection, iniType & " Chart Title B", 0)
                    pdfLayout.InvestmentGrowth = file.GetString(reportSection, iniType & " Investment Growth", "")

                    pdfLayout.ChartBorder_R = file.GetInteger(reportSection, iniType & " Chart Border R", 0)
                    pdfLayout.ChartBorder_G = file.GetInteger(reportSection, iniType & " Chart Border G", 0)
                    pdfLayout.ChartBorder_B = file.GetInteger(reportSection, iniType & " Chart Border B", 0)
                    If file.GetBoolean(reportSection, iniType & " Chart Border", False) Then pdfLayout.ChartBorder = True Else pdfLayout.ChartBorder = False

                    pdfLayout.ChartLine_R = file.GetInteger(reportSection, iniType & " Chart Line R", 0)
                    pdfLayout.ChartLine_G = file.GetInteger(reportSection, iniType & " Chart Line G", 0)
                    pdfLayout.ChartLine_B = file.GetInteger(reportSection, iniType & " Chart Line B", 0)
                    pdfLayout.ChartLabel = file.GetString(reportSection, iniType & " Chart Label", "")

                    pdfLayout.TableHeader_R = file.GetInteger(reportSection, iniType & " Table Header R", 0)
                    pdfLayout.TableHeader_G = file.GetInteger(reportSection, iniType & " Table Header G", 0)
                    pdfLayout.TableHeader_B = file.GetInteger(reportSection, iniType & " Table Header B", 0)

                    pdfLayout.TableLine_R = file.GetInteger(reportSection, iniType & " Table Line R", 0)
                    pdfLayout.TableLine_G = file.GetInteger(reportSection, iniType & " Table Line G", 0)
                    pdfLayout.TableLine_B = file.GetInteger(reportSection, iniType & " Table Line B", 0)

                    pdfLayout.TableItems_R = file.GetInteger(reportSection, iniType & " Table Items R", 0)
                    pdfLayout.TableItems_G = file.GetInteger(reportSection, iniType & " Table Items G", 0)
                    pdfLayout.TableItems_B = file.GetInteger(reportSection, iniType & " Table Items B", 0)

                    pdfLayout.TableTitle_R = file.GetInteger(reportSection, iniType & " Table Title R", 0)
                    pdfLayout.TableTitle_G = file.GetInteger(reportSection, iniType & " Table Title G", 0)
                    pdfLayout.TableTitle_B = file.GetInteger(reportSection, iniType & " Table Title B", 0)
                    pdfLayout.TableTitleTanggal = file.GetString(reportSection, iniType & " Table Tanggal", "")
                    pdfLayout.TableTitleDate = file.GetString(reportSection, iniType & " Table Date", "")
                    pdfLayout.TableTitleUraian = file.GetString(reportSection, iniType & " Table Uraian", "")
                    pdfLayout.TableTitleDescription = file.GetString(reportSection, iniType & " Table Description", "")
                    pdfLayout.TableTitleNilaiTransaksi = file.GetString(reportSection, iniType & " Table Nilai Transaksi", "")
                    pdfLayout.TableTitleGross = file.GetString(reportSection, iniType & " Table Gross", "")
                    pdfLayout.TableTitleNet = file.GetString(reportSection, iniType & " Table Net", "")
                    pdfLayout.TableTitleHargaUP = file.GetString(reportSection, iniType & " Table Harga/UP", "")
                    pdfLayout.TableTitleNAVUnit = file.GetString(reportSection, iniType & " Table NAV/Unit", "")
                    pdfLayout.TableTitleUnitPenyertaan = file.GetString(reportSection, iniType & " Table Unit Penyertaan", "")
                    pdfLayout.TableTitleBiayaPerolehan = file.GetString(reportSection, iniType & " Table Biaya Perolehan", "")
                    pdfLayout.TableTitleAcqCost = file.GetString(reportSection, iniType & " Table Acq. Cost", "")
                    pdfLayout.TableTitleLRRealisasi = file.GetString(reportSection, iniType & " Table L/R Realisasi", "")
                    pdfLayout.TableTitleRealizedPL = file.GetString(reportSection, iniType & " Table Realized P/L", "")
                    pdfLayout.TableTitleSaldoUP = file.GetString(reportSection, iniType & " Table Saldo (UP)", "")
                    pdfLayout.TableTitleBalanceUnit = file.GetString(reportSection, iniType & " Table Balance (Unit)", "")
                End If
            Else
                pdfColorDefault()
            End If
        Catch ex As Exception
            pdfColorDefault()
        End Try
    End Sub

#End Region

    Private Sub ReportAccountStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetComboInitAll(New ParameterTransactionTrxType1, cmbType, "TrxTypeID", "TrxTypeCode")
        GetParameterTATrxType1()
        pdfSetting()

        objPortfolio.UserAccess = objAccess
        objCodeset.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objClient.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        objUnit.UserAccess = objAccess

        DBGTransaction.FetchRowStyles = True
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
    End Sub

#Region "filter"
    Private Sub btnSearchPortfolio_Click(sender As Object, e As EventArgs) Handles btnSearchPortfolio.Click
        PortfolioSearch()
    End Sub

    Private Sub PortfolioSearch()
        Dim form As New SelectMasterPortfolioNormal
        form.lblCode = lblPortfolioCode
        form.lblName = lblPortfolioName
        form.lblSimpiEmail = lblSimpiEmail
        form.lblSimpiName = lblSimpiName
        form.Show()
        form.MdiParent = MDIMIS
        lblPortfolioCode.Text = ""
        lblPortfolioName.Text = ""
        lblSimpiEmail.Text = ""
        lblSimpiName.Text = ""
        objPortfolio.Clear()
    End Sub

    Private Sub lblSimpiEmail_TextChanged(sender As Object, e As EventArgs) Handles lblSimpiEmail.TextChanged
        PortfolioLoad()
    End Sub

    Private Sub PortfolioLoad()
        If lblPortfolioCode.Text.Trim <> "" Then
            objSimpi.Clear()
            objSimpi.Load(lblSimpiEmail.Text)
            If objSimpi.ErrID = 0 Then
                objPortfolio.Clear()
                objPortfolio.LoadCode(objSimpi, lblPortfolioCode.Text)
                If objPortfolio.ErrID = 0 Then
                    priceDigit = objCodeset.GetCodeset(objPortfolio, "UNIT PRICE DIGIT")
                    If IsNumeric(priceDigit.Trim) Then priceDigit = "n" & priceDigit.Trim Else priceDigit = "n4"
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        ClientScreen()
    End Sub

    Private Sub ClientScreen()
        Dim form As New SelectMasterClient
        form.lblCode = lblClientCode
        form.lblName = lblClientName
        form.Show()
        If IsMdiChild Then form.MdiParent = MDIMIS
        lblClientCode.Text = ""
        lblClientName.Text = ""
        objClient.Clear()
    End Sub

    Private Sub lblClientCode_TextChanged(sender As Object, e As EventArgs) Handles lblClientCode.TextChanged
        ClientLoad()
    End Sub

    Private Sub ClientLoad()
        If lblClientCode.Text.Trim <> "" Then
            objClient.Clear()
            objClient.load(objMasterSimpi, lblClientCode.Text)
            If objClient.ErrID = 0 Then
                lblSalesCode.Text = objClient.GetMasterSales.GetSalesCode
                lblSalesName.Text = objClient.GetMasterSales.GetSimpiUser.GetUserName
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataSearch()
    End Sub

    Private Sub DataSearch()
        DataClear()
        DataLoad()
        DataDisplay()
    End Sub

    Private Sub DataClear()
        DBGTransaction.Columns.Clear()
        chartNAV.Reset()
    End Sub

    Private Sub DataLoad()
        If objPortfolio.GetPortfolioID > 0 And objClient.GetClientID > 0 Then
            objCapital.Clear()
            dtTransaction = objCapital.Search(objPortfolio, objClient, dtFrom.Value, dtTo.Value)

            objCapital.Clear()
            dtValue = objUnit.SearchHistory(objPortfolio, objClient, dtFrom.Value, dtTo.Value, 0)
        End If
    End Sub

    Private Sub DataDisplay()
        DisplaySummary()
        DisplayTransaction()
        DisplayChart()
    End Sub

    Private Sub DisplaySummary()
        lblRedemption.Text = (From t In dtTransaction.AsEnumerable
                              Where t.Field(Of Integer)("TrxType1") = SetRedemption()
                              Select t.Field(Of Decimal)("TrxAmount")).Sum.ToString("n2")
        lblPLRedemption.Text = (From t In dtTransaction.AsEnumerable
                                Where t.Field(Of Integer)("TrxType1") = SetRedemption()
                                Select t.Field(Of Decimal)("TrxAmount") - t.Field(Of Decimal)("TrxCost")).Sum.ToString("n2")
        lblRedemptionCost.Text = (CDbl(lblRedemption.Text) - CDbl(lblPLRedemption.Text)).ToString("n2")

        lblDividend.Text = (From t In dtTransaction.AsEnumerable
                            Where t.Field(Of Integer)("TrxType1") = SetDividend()
                            Select t.Field(Of Decimal)("TrxAmount")).Sum.ToString("n2")

        lblPLRealized.Text = (CDbl(lblPLRedemption.Text) + CDbl(lblDividend.Text)).ToString("n2")

        objNAV.Clear()
        objNAV.LoadBefore(objPortfolio, dtFrom.Value)
        If objNAV.ErrID = 0 Then
            objUnit.Clear()
            objUnit.LoadAt(objPortfolio, objClient, objNAV.GetPositionDate)
            If objUnit.ErrID = 0 Then lblBalance.Text = objUnit.GetUnitBalance.ToString("n4") Else lblBalance.Text = 0.ToString("n4")
        Else
            lblBalance.Text = 0.ToString("n4")
        End If

        dtValue = objUnit.SearchHistory(objPortfolio, objClient, dtFrom.Value, dtTo.Value, 0)
        If dtValue.Rows.Count > 0 Then
            lblLastValue.Text = CDbl(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("UnitValue"), 1)).ToString("n2")
            lblLastCost.Text = CDbl(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("CostTotal"), 1)).ToString("n2")
            lblPLUnrealized.Text = (CDbl(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("UnitValue"), 1)) - CDbl(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("CostTotal"), 1))).ToString("n2")
            lastPrice = CDbl(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("UnitPrice"), 1))
        Else
            lblLastValue.Text = 0.ToString("n2")
            lblPLUnrealized.Text = 0.ToString("n2")
            lblLastCost.Text = 0.ToString("n2")
            objNAV.LoadEnd(objPortfolio)
            If objNAV.ErrID = 0 Then lastPrice = objNAV.GetNAVPerUnit Else lastPrice = 0
        End If

    End Sub

#End Region

#Region "transaction historical"
    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        DisplayTransaction()
    End Sub

    Private Sub DisplayTransaction()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            saldoUnit = CDbl(lblBalance.Text)
            If cmbType.SelectedValue < 1 Then DisplayAll() Else DisplayType()
        End If
    End Sub

    Private Sub DisplayAll()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join s In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals s.Field(Of Integer)("TrxTypeID")
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = s.Field(Of String)("TrxTypeCode"),
                           Description = u.Field(Of String)("TrxDescription"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = SetSubscription(),
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                                     u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice"),
                           Balance = RunningBalance(saldoUnit, u.Field(Of Integer)("TrxType1"), u.Field(Of Decimal)("TrxUnit")),
                           AvgCost = u.Field(Of Decimal)("TrxCost"),
                           RealPL = IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                        u.Field(Of Decimal)("TrxAmount") - u.Field(Of Decimal)("TrxCost"),
                                    IIf(u.Field(Of Integer)("TrxType1") = SetDividend(), u.Field(Of Decimal)("TrxAmount"), 0))
        With DBGTransaction
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query.ToList

            .Columns("Tanggal").NumberFormat = "dd-MMM-yyyy"
            .Columns("NAVDate").NumberFormat = "dd-MMM-yyyy"
            .Columns("Amount").NumberFormat = "n2"
            .Columns("Unit").NumberFormat = "n4"
            .Columns("Gross").NumberFormat = "n2"
            .Columns("Net").NumberFormat = "n2"
            .Columns("Price").NumberFormat = "n4"
            .Columns("Balance").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n2"
            .Columns("RealPL").NumberFormat = "n2"

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Balance").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("RealPL").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Description").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Balance").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("RealPL").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Description").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

            .Columns("Tanggal").Caption = "Date"
            .Columns("NAVDate").Caption = "NAV"
            .Columns("AvgCost").Caption = "Acq. Cost"
            .Columns("RealPL").Caption = "Realized PL"

            For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub DisplayType()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join s In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals s.Field(Of Integer)("TrxTypeID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = s.Field(Of String)("TrxTypeCode"),
                           Description = u.Field(Of String)("TrxDescription"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = SetSubscription(),
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                                     u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice"),
                           Balance = RunningBalance(saldoUnit, u.Field(Of Integer)("TrxType1"), u.Field(Of Decimal)("TrxUnit")),
                           AvgCost = u.Field(Of Decimal)("TrxCost"),
                           RealPL = IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                        u.Field(Of Decimal)("TrxAmount") - u.Field(Of Decimal)("TrxCost"), 0)

        With DBGTransaction
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query.ToList

            .Columns("Tanggal").NumberFormat = "dd-MMM-yyyy"
            .Columns("NAVDate").NumberFormat = "dd-MMM-yyyy"
            .Columns("Amount").NumberFormat = "n2"
            .Columns("Unit").NumberFormat = "n4"
            .Columns("Gross").NumberFormat = "n2"
            .Columns("Net").NumberFormat = "n2"
            .Columns("Price").NumberFormat = "n4"
            .Columns("Balance").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n2"
            .Columns("RealPL").NumberFormat = "n2"

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Balance").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("RealPL").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Description").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Balance").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("RealPL").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Description").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

            .Columns("Tanggal").Caption = "Date"
            .Columns("NAVDate").Caption = "NAV"
            .Columns("AvgCost").Caption = "Acq. Cost"
            .Columns("RealPL").Caption = "Realized PL"

            For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub DBGTransaction_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGTransaction.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGTransaction.Click
        If DBGTransaction.RowCount > 0 Then DBGTransaction.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

#End Region

#Region "investment growth"
    Private Sub DisplayChart()
        If dtValue.Rows.Count > 0 Then
            minDate = CDate(GetNullData(dtValue.Rows(0)("PositionDate"), 2))
            maxDate = CDate(GetNullData(dtValue.Rows(dtValue.Rows.Count - 1)("PositionDate"), 2))
            chartNAV.Reset()
            Dim ds1 As ChartDataSeriesCollection = chartNAV.ChartGroups(0).ChartData.SeriesList
            ds1.Clear()
            Dim series1 As ChartDataSeries = ds1.AddNewSeries()
            series1.LineStyle.Color = Color.FromArgb(77, 183, 136) 'Color.Blue
            series1.LineStyle.Thickness = 2
            series1.SymbolStyle.Shape = SymbolShapeEnum.None
            series1.FitType = FitTypeEnum.Line
            series1.PointData.Length = dtValue.Rows.Count
            For i = 0 To dtValue.Rows.Count - 1
                series1.X(i) = CDate(GetNullData(dtValue.Rows(i)("PositionDate"), 2))
                series1.Y(i) = CDbl(GetNullData(dtValue.Rows(i)("UnitValue"), 1))
            Next i
            Dim rangeDate As Double = (maxDate.ToOADate - minDate.ToOADate) / 10
            chartNAV.ChartArea.AxisX.Min = minDate.ToOADate '- (rangeDate / 2)
            chartNAV.ChartArea.AxisX.Max = maxDate.ToOADate
            chartNAV.ChartArea.AxisX.UnitMajor = rangeDate
            chartNAV.ChartArea.AxisX.AnnotationRotation = 45
            chartNAV.ChartArea.AxisX.Thickness = 0.75
            chartNAV.ChartArea.AxisY.AutoMax = True
            chartNAV.ChartArea.AxisY.AutoMin = True
            chartNAV.ChartArea.AxisY.AutoMajor = True
            chartNAV.ChartArea.AxisY.GridMajor.Pattern = LinePatternEnum.Solid
            chartNAV.ChartArea.AxisY.GridMajor.Thickness = 0.5
            chartNAV.ChartArea.AxisY.GridMajor.Visible = True
            chartNAV.ChartArea.AxisY.GridMajor.Color = Color.LightGray
            chartNAV.ChartArea.AxisY.Thickness = 0.75

            chartNAV.ChartArea.AxisX.AnnoFormat = FormatEnum.DateManual
            chartNAV.ChartArea.AxisX.AnnoFormatString = "MMM-yy"
            chartNAV.ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
            chartNAV.ChartArea.AxisY.AnnoFormatString = "n0"
        End If
    End Sub

#End Region

#Region "export"
    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        ExportPDF(False)
    End Sub

    Public Function ExportPDF(ByVal isAttachment As Boolean) As String
        Return PrintPDF(isAttachment)
    End Function

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isAttachment As Boolean) As String
        Return PrintExcel(isAttachment, DBGTransaction, "ReportAS" & lblClientName.Text.Trim & ".xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        If DBGTransaction.RowCount > 0 Then
            Dim frm As New ReportAccountStatementEmail
            frm.Show()
            frm.frm = Me
            frm.MdiParent = MDIMIS
        End If
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        ReportSetting()
    End Sub

    Private Sub ReportSetting()
        Dim frm As New ReportAccountStatementSetting
        frm.frm = Me
        frm.Show()
        frm.FormLoad()
        frm.MdiParent = MDIMIS
    End Sub

    Private Function PrintPDF(ByVal isAttachment As Boolean) As String
        Dim strFile As String = ""
        Dim strLayout As String = ""
        Dim koordX As Single = 40, koordY As Single = 35
        Dim fontType = "Calibri", fontSize = 8
        With c1pdf
            .Clear()
            .PaperKind = Printing.PaperKind.A4
            Dim rc As RectangleF = .PageRectangle
            strLayout = reportPDFPortrait("REPORT TEMPLATE PORTRAIT")
            If GlobalFileWindows.FileExists(strLayout) Then
                Dim img As Image = Image.FromFile(strLayout)
                .DrawImage(img, rc)
            End If
            simpiLogo(c1pdf, rc)
            pdfSetting()

            rc = New RectangleF(koordX, koordY, 150, fontSize)
            .DrawStringRtf("{\b " & pdfLayout.ReportTitle & "}", New Font(fontType, 10),
                           New SolidBrush(Color.FromArgb(pdfLayout.ReportTitle_R, pdfLayout.ReportTitle_G, pdfLayout.ReportTitle_B)), rc)
            .DrawString(lblClientName.Text & " (" & lblClientCode.Text & ")", New Font(fontType, 8),
                        New SolidBrush(Color.FromArgb(pdfLayout.Client_R, pdfLayout.Client_G, pdfLayout.Client_B)), New PointF(155, 27))
            .DrawString(pdfLayout.Period & minDate.ToString("dd MMMM yyyy") & " - " & maxDate.ToString("dd MMMM yyyy"), New Font(fontType, 8),
                        New SolidBrush(Color.FromArgb(pdfLayout.Client_R, pdfLayout.Client_G, pdfLayout.Client_B)), New PointF(155, koordY))
            .DrawString(pdfLayout.NAVUnit & lastPrice.ToString(priceDigit), New Font(fontType, 8),
                        New SolidBrush(Color.FromArgb(pdfLayout.NAVUnit_R, pdfLayout.NAVUnit_G, pdfLayout.NAVUnit_B)), New PointF(koordX + 350, koordY))

            koordY += 15
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.ReportLine_R, pdfLayout.ReportLine_G, pdfLayout.ReportLine_B), 1.5),
                      New PointF(koordX, koordY), New PointF(koordX + 425, koordY))
            koordY += fontSize
            Dim point = New PointF(koordX, koordY)
            point.Y += fontSize
            .DrawString(lblPortfolioName.Text, New Font(fontType, 20, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.Portfolio_R, pdfLayout.Portfolio_G, pdfLayout.Portfolio_B)), New PointF(koordX, koordY))

            koordY += 38
            .DrawString(pdfLayout.Summary, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.Summary_R, pdfLayout.Summary_G, pdfLayout.Summary_B)), New PointF(koordX, koordY))
            .DrawString(pdfLayout.InvestmentGrowth, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.ChartTitle_R, pdfLayout.ChartTitle_G, pdfLayout.ChartTitle_B)), New PointF(200, koordY))

            If pdfLayout.ChartBorder Then
                chartNAV.BorderStyle = BorderStyle.FixedSingle
                chartNAV.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.Solid
                chartNAV.ChartArea.Style.Border.Color = Color.FromArgb(pdfLayout.ChartBorder_R, pdfLayout.ChartBorder_G, pdfLayout.ChartBorder_B)
            Else
                chartNAV.BorderStyle = BorderStyle.None
                chartNAV.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.None
            End If
            chartNAV.ChartGroups(0).ChartData.SeriesList(0).LineStyle.Color = Color.FromArgb(pdfLayout.ChartLine_R, pdfLayout.ChartLine_G, pdfLayout.ChartLine_B)
            chartNAV.ChartArea.AxisX.GridMajor.Visible = False
            Dim imgPortfolio = chartNAV.GetImage(ImageFormat.Emf)
            rc = New RectangleF(New PointF(koordX + 160, koordY + 14), New SizeF(0.4 * chartNAV.Size.Width, 0.75 * chartNAV.Size.Height))
            .DrawImage(imgPortfolio, rc, ContentAlignment.TopLeft, C1.C1Pdf.ImageSizeModeEnum.Scale)
            If pdfLayout.ChartBorder Then
                Dim pnNAV As New Pen(New SolidBrush(Color.FromArgb(pdfLayout.ChartLine_R, pdfLayout.ChartLine_G, pdfLayout.ChartLine_B)), 0.5)
                .DrawRectangle(pnNAV, rc)
            Else
                .DrawRectangle(Pens.White, rc)
            End If

            Dim strRight, strCenter, strLeft As New StringFormat()
            strLeft.Alignment = StringAlignment.Near
            strRight.Alignment = StringAlignment.Far
            strCenter.Alignment = StringAlignment.Center

            koordY += 17
            .DrawString(pdfLayout.SummaryItemsTotalRedemption, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblRedemption.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsAcqCost, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblRedemptionCost.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.SummaryLine_R, pdfLayout.SummaryLine_G, pdfLayout.SummaryLine_B), 0.5),
                      New PointF(koordX + 150, koordY), New PointF(koordX + 75, koordY))

            koordY += 2
            .DrawString(pdfLayout.SummaryItemsRedemptionPL, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblPLRedemption.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsDividend, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblDividend.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.SummaryLine_R, pdfLayout.SummaryLine_G, pdfLayout.SummaryLine_B), 0.5),
                      New PointF(koordX + 150, koordY), New PointF(koordX + 75, koordY))

            koordY += 2
            .DrawString(pdfLayout.SummaryItemsRealizedPL, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblPLRealized.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 15
            .DrawString(pdfLayout.SummaryItemsLastInvestmentValue, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblLastValue.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsLastAcqCost, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblLastCost.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.SummaryLine_R, pdfLayout.SummaryLine_G, pdfLayout.SummaryLine_B), 0.5),
                      New PointF(koordX + 150, koordY), New PointF(koordX + 75, koordY))

            .DrawLine(New Pen(Color.FromArgb(pdfLayout.ChartLine_R, pdfLayout.ChartLine_G, pdfLayout.ChartLine_B), 0.75),
                      New PointF(koordX + 175, koordY - 1), New PointF(koordX + 165, koordY - 1))
            .DrawString(pdfLayout.ChartLabel, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.Black), New PointF(koordX + 180, koordY - 5), strLeft)

            koordY += 2
            .DrawString(pdfLayout.SummaryItemsUnrealizedPL, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblPLUnrealized.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 20
            .FillRectangle(New SolidBrush(Color.FromArgb(pdfLayout.TableHeader_R, pdfLayout.TableHeader_G, pdfLayout.TableHeader_B)),
                           New RectangleF(koordX, koordY, 525, 17))
            .DrawString(pdfLayout.TableTitleTanggal, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 20, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleDate, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 20, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleUraian, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 80, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleDescription, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 80, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleNilaiTransaksi, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 185, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleGross, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 155, koordY + 7), strCenter)
            .DrawString(pdfLayout.TableTitleNet, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 215, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleHargaUP, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 265, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleNAVUnit, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 265, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleUnitPenyertaan, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 317, koordY), strCenter)

            .DrawString(pdfLayout.TableTitleBiayaPerolehan, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 375, koordY), strCenter)

            .DrawString(pdfLayout.TableTitleAcqCost, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 375, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleLRRealisasi, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 435, koordY), strCenter)

            .DrawString(pdfLayout.TableTitleRealizedPL, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 435, koordY + 7), strCenter)

            .DrawString(pdfLayout.TableTitleSaldoUP, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 495, koordY), strCenter)

            .DrawString(pdfLayout.TableTitleBalanceUnit, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitle_R, pdfLayout.TableTitle_G, pdfLayout.TableTitle_B)),
                        New PointF(koordX + 495, koordY + 7), strCenter)

            Dim pn As New Pen(New SolidBrush(Color.FromArgb(pdfLayout.TableLine_R, pdfLayout.TableLine_G, pdfLayout.TableLine_B)), 0.5)
            Dim str As String
            koordY += 17
            If dtTransaction.Rows.Count > 0 Then
                For i = 0 To DBGTransaction.RowCount - 1
                    DBGTransaction.Row = i
                    .DrawRectangle(pn, New RectangleF(koordX, koordY, 40, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 40, koordY, 85, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 125, koordY, 60, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 185, koordY, 60, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 245, koordY, 45, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 290, koordY, 55, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 345, koordY, 60, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 405, koordY, 60, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 465, koordY, 60, 10))

                    str = DBGTransaction.Columns("NAVDate").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 20, koordY), strCenter)
                    str = DBGTransaction.Columns("Type").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 45, koordY), strLeft)
                    str = DBGTransaction.Columns("Gross").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 180, koordY), strRight)
                    str = DBGTransaction.Columns("Net").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 240, koordY), strRight)
                    str = DBGTransaction.Columns("Price").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 285, koordY), strRight)
                    str = DBGTransaction.Columns("Unit").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 340, koordY), strRight)
                    str = DBGTransaction.Columns("AvgCost").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 400, koordY), strRight)
                    str = DBGTransaction.Columns("RealPL").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 460, koordY), strRight)
                    str = DBGTransaction.Columns("Balance").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItems_R, pdfLayout.TableItems_G, pdfLayout.TableItems_B)),
                                New PointF(koordX + 520, koordY), strRight)

                    koordY += 10
                Next
            End If

            strFile = reportFileExists("ReportAS" & lblClientName.Text.Trim & ".pdf")
            .Save(strFile)
            If Not isAttachment Then Process.Start(strFile)
        End With
        Return strFile
    End Function

#End Region

End Class