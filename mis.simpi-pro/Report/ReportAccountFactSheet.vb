Imports System.Drawing.Imaging
Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1Chart
Imports simpi.CoreData
Imports simpi.MasterSecurities
Imports simpi.ParameterTA.ParameterTA
Imports simpi.GlobalConnection
Imports simpi.GlobalUtilities

Public Class ReportAccountFactSheet
    Dim objCapital As New PositionCapital
    Dim objClient As New simpi.MasterClient.MasterClient
    Dim objTrx As New TransactionCapital
    Dim objCcy As New ParameterCountry
    Dim objPortfolio As New simpi.MasterPortfolio.MasterPortfolio

    Dim dtFund As New DataTable
    Dim dtTransaction As New DataTable
    Dim dtAUM As New DataTable
    Dim rowNomer As Integer = 0
    Dim reportSection As String = "REPORT ACCOUNT HOLDER FACT SHEET"
    Public pdfLayout As New pdfColor
    Dim PortfolioID As Integer()

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
        Public AsOf As String
        Public ReportLine_R As Integer
        Public ReportLine_G As Integer
        Public ReportLine_B As Integer
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
        Public SummaryItemsTotalInvestmentValue As String
        Public SummaryItemsTotalAcqusitionCost As String
        Public SummaryItemsTotalUnrealizedPL As String
        Public SummaryItemsInvestmentLength As String
        Public SummaryItemsTotalSubscription As String
        Public SummaryItemsTotalRedemption As String
        Public SummaryItemsTotalDividend As String
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
        Public ChartLabel1 As String
        Public ChartLabel2 As String
        Public PieTitle1_R As Integer
        Public PieTitle1_G As Integer
        Public PieTitle1_B As Integer
        Public FundAllocation As String
        Public PieBorder1_R As Integer
        Public PieBorder1_G As Integer
        Public PieBorder1_B As Integer
        Public PieBorder1 As Boolean
        Public PieTitle2_R As Integer
        Public PieTitle2_G As Integer
        Public PieTitle2_B As Integer
        Public AssetTypeAllocation As String
        Public PieBorder2_R As Integer
        Public PieBorder2_G As Integer
        Public PieBorder2_B As Integer
        Public PieBorder2 As Boolean
        Public LatestTransaction As String
        Public TableHeaderTrx_R As Integer
        Public TableHeaderTrx_G As Integer
        Public TableHeaderTrx_B As Integer
        Public TableLineTrx_R As Integer
        Public TableLineTrx_G As Integer
        Public TableLineTrx_B As Integer
        Public TableItemsTrx_R As Integer
        Public TableItemsTrx_G As Integer
        Public TableItemsTrx_B As Integer
        Public TableTitleTrx_R As Integer
        Public TableTitleTrx_G As Integer
        Public TableTitleTrx_B As Integer
        Public TableTitleDateTrx As String
        Public TableTitleFundTrx As String
        Public TableTitleNameTrx As String
        Public TableTitleTypeTrx As String
        Public TableTitleAmountTrx As String
        Public TableTitleNAVUnitTrx As String
        Public TableTitleUnitTrx As String
        Public ListOfUnitholding As String
        Public TableHeaderHolding_R As Integer
        Public TableHeaderHolding_G As Integer
        Public TableHeaderHolding_B As Integer
        Public TableLineHolding_R As Integer
        Public TableLineHolding_G As Integer
        Public TableLineHolding_B As Integer
        Public TableItemsHolding_R As Integer
        Public TableItemsHolding_G As Integer
        Public TableItemsHolding_B As Integer
        Public TableTitleHolding_R As Integer
        Public TableTitleHolding_G As Integer
        Public TableTitleHolding_B As Integer
        Public TableTitleNoHolding As String
        Public TableTitleFundHolding As String
        Public TableTitleNameHolding As String
        Public TableTitleTypeHolding As String
        Public TableTitleUnitHolding As String
        Public TableTitleNAVUnitHolding As String
        Public TableTitleAvgCostHolding As String
        Public TableTitleValueHolding As String
        Public TableTitleAcqCostHolding As String
        Public TableTitleUnrealizedPLHolding As String
    End Structure

    Public Sub pdfColorDefault()
        pdfLayout.layoutType = "DEFAULT"
        pdfLayout.ReportTitle_R = 0
        pdfLayout.ReportTitle_G = 61
        pdfLayout.ReportTitle_B = 121
        pdfLayout.ReportTitle = "CLIENT SHEET"

        pdfLayout.Client_R = 0
        pdfLayout.Client_G = 61
        pdfLayout.Client_B = 121
        pdfLayout.AsOf = "As Of: "

        pdfLayout.ReportLine_R = 255
        pdfLayout.ReportLine_G = 153
        pdfLayout.ReportLine_B = 51

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
        pdfLayout.SummaryItemsTotalInvestmentValue = "Total Investment Value: "
        pdfLayout.SummaryItemsTotalAcqusitionCost = "Total Acquisition Cost: "
        pdfLayout.SummaryItemsTotalUnrealizedPL = "Total Unrealized P/L: "
        pdfLayout.SummaryItemsInvestmentLength = "Investment Length: "
        pdfLayout.SummaryItemsTotalSubscription = "Total Subscription: "
        pdfLayout.SummaryItemsTotalRedemption = "Total Redemption: "
        pdfLayout.SummaryItemsTotalDividend = "Total Dividend: "

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
        pdfLayout.ChartLabel1 = "investment value within period:"
        pdfLayout.ChartLabel2 = "unit(s) balance * unit price"

        pdfLayout.PieTitle1_R = 0
        pdfLayout.PieTitle1_G = 61
        pdfLayout.PieTitle1_B = 121
        pdfLayout.FundAllocation = "Fund Allocation"

        pdfLayout.PieBorder1_R = 0
        pdfLayout.PieBorder1_G = 0
        pdfLayout.PieBorder1_B = 0
        pdfLayout.PieBorder1 = False

        pdfLayout.PieTitle2_R = 0
        pdfLayout.PieTitle2_G = 61
        pdfLayout.PieTitle2_B = 121
        pdfLayout.AssetTypeAllocation = "Asset Type Allocation"

        pdfLayout.PieBorder2_R = 0
        pdfLayout.PieBorder2_G = 0
        pdfLayout.PieBorder2_B = 0
        pdfLayout.PieBorder2 = False

        pdfLayout.TableHeaderTrx_R = 0
        pdfLayout.TableHeaderTrx_G = 61
        pdfLayout.TableHeaderTrx_B = 121

        pdfLayout.TableLineTrx_R = 255
        pdfLayout.TableLineTrx_G = 153
        pdfLayout.TableLineTrx_B = 51

        pdfLayout.TableItemsTrx_R = 0
        pdfLayout.TableItemsTrx_G = 0
        pdfLayout.TableItemsTrx_B = 0

        pdfLayout.TableTitleTrx_R = 255
        pdfLayout.TableTitleTrx_G = 255
        pdfLayout.TableTitleTrx_B = 255

        pdfLayout.LatestTransaction = "Latest Transaction"
        pdfLayout.TableTitleDateTrx = "Date"
        pdfLayout.TableTitleFundTrx = "Fund"
        pdfLayout.TableTitleNameTrx = "Name"
        pdfLayout.TableTitleTypeTrx = "Type"
        pdfLayout.TableTitleAmountTrx = "Amount"
        pdfLayout.TableTitleNAVUnitTrx = "NAV/Unit"
        pdfLayout.TableTitleUnitTrx = "Unit(s)"

        pdfLayout.TableHeaderHolding_R = 0
        pdfLayout.TableHeaderHolding_G = 61
        pdfLayout.TableHeaderHolding_B = 121

        pdfLayout.TableLineHolding_R = 255
        pdfLayout.TableLineHolding_G = 153
        pdfLayout.TableLineHolding_B = 51

        pdfLayout.TableItemsHolding_R = 0
        pdfLayout.TableItemsHolding_G = 0
        pdfLayout.TableItemsHolding_B = 0

        pdfLayout.TableTitleHolding_R = 255
        pdfLayout.TableTitleHolding_G = 255
        pdfLayout.TableTitleHolding_B = 255

        pdfLayout.ListOfUnitholding = "List of Unitholding"
        pdfLayout.TableTitleNoHolding = "No"
        pdfLayout.TableTitleFundHolding = "Fund"
        pdfLayout.TableTitleNameHolding = "Name"
        pdfLayout.TableTitleTypeHolding = "Type"
        pdfLayout.TableTitleUnitHolding = "Unit(s)"
        pdfLayout.TableTitleNAVUnitHolding = "NAV/Unit"
        pdfLayout.TableTitleAvgCostHolding = "Avg. Cost"
        pdfLayout.TableTitleValueHolding = "Value"
        pdfLayout.TableTitleAcqCostHolding = "Acq. Cost"
        pdfLayout.TableTitleUnrealizedPLHolding = "Unrealized P/L"
    End Sub

    Public Sub pdfSetting()
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
                    pdfLayout.AsOf = file.GetString(reportSection, iniType & " AsOf", "")

                    pdfLayout.ReportLine_R = file.GetInteger(reportSection, iniType & " Report Line R", 0)
                    pdfLayout.ReportLine_G = file.GetInteger(reportSection, iniType & " Report Line G", 0)
                    pdfLayout.ReportLine_B = file.GetInteger(reportSection, iniType & " Report Line B", 0)

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
                    pdfLayout.SummaryItemsTotalInvestmentValue = file.GetString(reportSection, iniType & " Summary Items Total Investment Value", "")
                    pdfLayout.SummaryItemsTotalAcqusitionCost = file.GetString(reportSection, iniType & " Summary Items Total Acquisition Cost", "")
                    pdfLayout.SummaryItemsTotalUnrealizedPL = file.GetString(reportSection, iniType & " Summary Items Total Unrealized P/L", "")
                    pdfLayout.SummaryItemsInvestmentLength = file.GetString(reportSection, iniType & " Summary Items Investment Length", "")
                    pdfLayout.SummaryItemsTotalSubscription = file.GetString(reportSection, iniType & " Summary Items Total Subscription", "")
                    pdfLayout.SummaryItemsTotalRedemption = file.GetString(reportSection, iniType & " Summary Items Total Redemption", "")
                    pdfLayout.SummaryItemsTotalDividend = file.GetString(reportSection, iniType & " Summary Items Total Dividend", "")

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
                    pdfLayout.ChartLabel1 = file.GetString(reportSection, iniType & " Chart Label 1", "")
                    pdfLayout.ChartLabel2 = file.GetString(reportSection, iniType & " Chart Label 2", "")

                    pdfLayout.PieTitle1_R = file.GetInteger(reportSection, iniType & " Pie Title 1 R", 0)
                    pdfLayout.PieTitle1_G = file.GetInteger(reportSection, iniType & " Pie Title 1 G", 0)
                    pdfLayout.PieTitle1_B = file.GetInteger(reportSection, iniType & " Pie Title 1 B", 0)
                    pdfLayout.FundAllocation = file.GetString(reportSection, iniType & " Fund Allocation", "")

                    pdfLayout.PieBorder1_R = file.GetInteger(reportSection, iniType & " Pie Border 1 R", 0)
                    pdfLayout.PieBorder1_G = file.GetInteger(reportSection, iniType & " Pie Border 1 G", 0)
                    pdfLayout.PieBorder1_B = file.GetInteger(reportSection, iniType & " Pie Border 1 B", 0)
                    If file.GetBoolean(reportSection, iniType & " Pie Border 1", False) Then pdfLayout.PieBorder1 = True Else pdfLayout.PieBorder1 = False

                    pdfLayout.PieTitle2_R = file.GetInteger(reportSection, iniType & " Pie Title 2 R", 0)
                    pdfLayout.PieTitle2_G = file.GetInteger(reportSection, iniType & " Pie Title 2 G", 0)
                    pdfLayout.PieTitle2_B = file.GetInteger(reportSection, iniType & " Pie Title 2 B", 0)
                    pdfLayout.AssetTypeAllocation = file.GetString(reportSection, iniType & " Asset Type Allocation", "")

                    pdfLayout.PieBorder2_R = file.GetInteger(reportSection, iniType & " Pie Border 2 R", 0)
                    pdfLayout.PieBorder2_G = file.GetInteger(reportSection, iniType & " Pie Border 2 G", 0)
                    pdfLayout.PieBorder2_B = file.GetInteger(reportSection, iniType & " Pie Border 2 B", 0)
                    If file.GetBoolean(reportSection, iniType & " Pie Border 2", False) Then pdfLayout.PieBorder2 = True Else pdfLayout.PieBorder2 = False

                    pdfLayout.TableHeaderTrx_R = file.GetInteger(reportSection, iniType & " Table Header Trx R", 0)
                    pdfLayout.TableHeaderTrx_G = file.GetInteger(reportSection, iniType & " Table Header Trx G", 0)
                    pdfLayout.TableHeaderTrx_B = file.GetInteger(reportSection, iniType & " Table Header Trx B", 0)

                    pdfLayout.TableLineTrx_R = file.GetInteger(reportSection, iniType & " Table Line Trx R", 0)
                    pdfLayout.TableLineTrx_G = file.GetInteger(reportSection, iniType & " Table Line Trx G", 0)
                    pdfLayout.TableLineTrx_B = file.GetInteger(reportSection, iniType & " Table Line Trx B", 0)

                    pdfLayout.TableItemsTrx_R = file.GetInteger(reportSection, iniType & " Table Items Trx R", 0)
                    pdfLayout.TableItemsTrx_G = file.GetInteger(reportSection, iniType & " Table Items Trx G", 0)
                    pdfLayout.TableItemsTrx_B = file.GetInteger(reportSection, iniType & " Table Items Trx B", 0)

                    pdfLayout.TableTitleTrx_R = file.GetInteger(reportSection, iniType & " Table Title Trx R", 0)
                    pdfLayout.TableTitleTrx_G = file.GetInteger(reportSection, iniType & " Table Title Trx G", 0)
                    pdfLayout.TableTitleTrx_B = file.GetInteger(reportSection, iniType & " Table Title Trx B", 0)

                    pdfLayout.LatestTransaction = file.GetString(reportSection, iniType & " Latest Transaction", "")
                    pdfLayout.TableTitleDateTrx = file.GetString(reportSection, iniType & " Table Date Trx", "")
                    pdfLayout.TableTitleFundTrx = file.GetString(reportSection, iniType & " Table Fund Trx", "")
                    pdfLayout.TableTitleNameTrx = file.GetString(reportSection, iniType & " Table Name Trx", "")
                    pdfLayout.TableTitleTypeTrx = file.GetString(reportSection, iniType & " Table Type Trx", "")
                    pdfLayout.TableTitleAmountTrx = file.GetString(reportSection, iniType & " Table Amount Trx", "")
                    pdfLayout.TableTitleNAVUnitTrx = file.GetString(reportSection, iniType & " Table NAV/Unit Trx", "")
                    pdfLayout.TableTitleUnitTrx = file.GetString(reportSection, iniType & " Table Unit(s) Trx", "")

                    pdfLayout.TableHeaderHolding_R = file.GetInteger(reportSection, iniType & " Table Header Holding R", 0)
                    pdfLayout.TableHeaderHolding_G = file.GetInteger(reportSection, iniType & " Table Header Holding G", 0)
                    pdfLayout.TableHeaderHolding_B = file.GetInteger(reportSection, iniType & " Table Header Holding B", 0)

                    pdfLayout.TableLineHolding_R = file.GetInteger(reportSection, iniType & " Table Line Holding R", 0)
                    pdfLayout.TableLineHolding_G = file.GetInteger(reportSection, iniType & " Table Line Holding G", 0)
                    pdfLayout.TableLineHolding_B = file.GetInteger(reportSection, iniType & " Table Line Holding B", 0)

                    pdfLayout.TableItemsHolding_R = file.GetInteger(reportSection, iniType & " Table Items Holding R", 0)
                    pdfLayout.TableItemsHolding_G = file.GetInteger(reportSection, iniType & " Table Items Holding G", 0)
                    pdfLayout.TableItemsHolding_B = file.GetInteger(reportSection, iniType & " Table Items Holding B", 0)

                    pdfLayout.TableTitleTrx_R = file.GetInteger(reportSection, iniType & " Table Title Holding R", 0)
                    pdfLayout.TableTitleTrx_G = file.GetInteger(reportSection, iniType & " Table Title Holding G", 0)
                    pdfLayout.TableTitleTrx_B = file.GetInteger(reportSection, iniType & " Table Title Holding B", 0)

                    pdfLayout.ListOfUnitholding = file.GetString(reportSection, iniType & " List of Unitholding", "")
                    pdfLayout.TableTitleNoHolding = file.GetString(reportSection, iniType & " Table No Holding", "")
                    pdfLayout.TableTitleFundHolding = file.GetString(reportSection, iniType & " Table Fund Holding", "")
                    pdfLayout.TableTitleNameHolding = file.GetString(reportSection, iniType & " Table Name Holding", "")
                    pdfLayout.TableTitleTypeHolding = file.GetString(reportSection, iniType & " Table Type Holding", "")
                    pdfLayout.TableTitleUnitHolding = file.GetString(reportSection, iniType & " Table Unit(s) Holding", "")
                    pdfLayout.TableTitleNAVUnitHolding = file.GetString(reportSection, iniType & " Table NAV/Unit Holding", "")
                    pdfLayout.TableTitleAvgCostHolding = file.GetString(reportSection, iniType & " Table Avg. Cost Holding", "")
                    pdfLayout.TableTitleValueHolding = file.GetString(reportSection, iniType & " Table Value Holding", "")
                    pdfLayout.TableTitleAcqCostHolding = file.GetString(reportSection, iniType & " Table Acq. Cost Holding", "")
                    pdfLayout.TableTitleUnrealizedPLHolding = file.GetString(reportSection, iniType & " Table Unrealized P/L Holding", "")
                End If
            Else
                pdfColorDefault()
            End If
        Catch ex As Exception
            pdfColorDefault()
        End Try
    End Sub
#End Region

    Private Sub ReportAccountValuation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParameterPortfolioAssetType()
        GetParameterTATrxType1()
        GetPortfolioSimpi()
        PortfolioID = (From p In dtPortfolioSimpi Select p.Field(Of Integer)("PortfolioID")).ToArray
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        cmbCcy.Text = "IDR"
        lblCcy.Text = "Indonesia Rupiah"
        pdfSetting()
        objCapital.UserAccess = objAccess
        objClient.UserAccess = objAccess
        objTrx.UserAccess = objAccess
        objCcy.UserAccess = objAccess
        objPortfolio.UserAccess = objAccess
        DBGFund.FetchRowStyles = True
        DBGTrx.FetchRowStyles = True
        dtAs.Value = Now
    End Sub

#Region "filter"
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
        DataClear()
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

    Public Sub DataSearch()
        DataClear()
        DataLoad()
        DataDisplay()
    End Sub

    Private Sub DataLoad()
        If objClient.GetClientID > 0 Then
            objCapital.Clear()
            dtFund = objCapital.Search(PortfolioID, objClient, dtAs.Value)

            objCapital.Clear()
            dtAUM = objCapital.SearchHistoryLast(PortfolioID, objClient, dtAs.Value, 0)

            objTrx.Clear()
            dtTransaction = objTrx.SearchLast(objClient, dtAs.Value, 0)
        End If
    End Sub

    Private Sub cmbCcy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCcy.SelectedIndexChanged
        If cmbCcy.SelectedIndex <> -1 And objClient.GetClientID > 0 Then
            objCcy.Clear()
            objCcy.LoadCcy(cmbCcy.Text)
            If objCcy.ErrID = 0 Then lblCcy.Text = objCcy.GetCcyDescription Else lblCcy.Text = ""
            DataClear()
            DataDisplay()
        End If
    End Sub

    Private Sub DataClear()
        chartNAV.Reset()
        chartAsset.Reset()
        chartFund.Reset()
        DBGFund.Columns.Clear()
        DBGTrx.Columns.Clear()
    End Sub

    Private Sub DataDisplay()
        DisplaySummary()
        DisplayAUM()
        DisplayFund()
        DisplayChartAsset()
        DisplayChartFund()
        DisplayTransaction()
    End Sub

    Private Sub DisplaySummary()
        If dtTransaction IsNot Nothing AndAlso dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtFund.AsEnumerable Join p In dtPortfolioSimpi.AsEnumerable
                        On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select UnitValue = u.Field(Of Decimal)("UnitValue"),
                               CostTotal = u.Field(Of Decimal)("CostTotal")
            lblLastValue.Text = (From q In query Select q.UnitValue).Sum.ToString("n2")
            lblLastCost.Text = (From q In query Select q.CostTotal).Sum.ToString("n2")
            lblLastPL.Text = (From q In query Select q.UnitValue - q.CostTotal).Sum.ToString("n2")

            Dim joinDate As Date
            joinDate = objTrx.GetFirstJoin(objClient)
            lblInitialJoin.Text = joinDate.ToString("dd-MMM-yyyy")
            lblInvestmentDays.Text = GlobalDate.CalculateDays(joinDate, dtAs.Value, "A")

            Dim query2 = From u In dtTransaction.AsEnumerable Join p In dtPortfolioSimpi.AsEnumerable
                         On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select TrxType1 = u.Field(Of Integer)("TrxType1"),
                                TrxAmount = u.Field(Of Decimal)("TrxAmount")

            lblSubscription.Text = (From q In query2 Where q.TrxType1 = SetSubscription() Select q.TrxAmount).Sum.ToString("n2")
            lblRedemption.Text = (From q In query2 Where q.TrxType1 = SetRedemption() Select q.TrxAmount).Sum.ToString("n2")
            lblDividend.Text = (From q In query2 Where q.TrxType1 = SetDividend() Select q.TrxAmount).Sum.ToString("n2")

        End If
    End Sub

#End Region

#Region "investment growth"
    Private Sub DisplayAUM()
        If dtAUM IsNot Nothing AndAlso dtAUM.Rows.Count > 0 Then
            Dim query = From u In dtAUM.AsEnumerable Join p In dtPortfolioSimpi.AsEnumerable
                        On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select PositionDate = u.Field(Of Date)("PositionDate"),
                               UnitValue = u.Field(Of Decimal)("UnitValue")

            Dim query2 = From p In query
                         Group By key = New With {Key .PositionDate = p.PositionDate}
                         Into Group Select New With {
                             .PositionDate = key.PositionDate,
                             .AUM = Group.Sum(Function(r) r.UnitValue)
                             }

            With chartNAV
                .Style.Border.BorderStyle = BorderStyleEnum.None
                Dim ds As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
                ds.Clear()
                Dim series As ChartDataSeries = ds.AddNewSeries()
                series.Label = "AUM"
                series.LineStyle.Color = Color.Green
                series.LineStyle.Thickness = 2
                series.SymbolStyle.Shape = SymbolShapeEnum.None
                series.FitType = FitTypeEnum.Line

                series.X.CopyDataIn((From q In query2 Select q.PositionDate).ToArray)
                series.Y.CopyDataIn((From q In query2 Select q.AUM).ToArray)
                series.PointData.Length = query.Count

                .BackColor = Color.Transparent
                .ChartArea.AxisX.AutoMax = True
                .ChartArea.AxisX.AutoMin = True
                .ChartArea.AxisX.AutoMajor = True
                .ChartArea.AxisX.AutoMinor = True
                .ChartArea.AxisY.AutoMax = True
                .ChartArea.AxisY.AutoMin = True
                .ChartArea.AxisY.AutoMajor = True
                .ChartArea.AxisY.AutoMinor = True
                .ChartArea.AxisX.AnnoFormat = FormatEnum.DateManual
                If DateDiff(DateInterval.Day, CDate(.ChartArea.AxisX.GetMin()), CDate(.ChartArea.AxisX.GetMax())) < 60 Then
                    .ChartArea.AxisX.AnnoFormatString = "dd-MMM-yy"
                Else
                    .ChartArea.AxisX.AnnoFormatString = "MMM-yy"
                End If
                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AnnoFormatString = "n0"
            End With
        End If
    End Sub

#End Region

#Region "list unitholding"
    Private Function generateNumber() As Integer
        rowNomer += 1
        Return rowNomer
    End Function

    Private Sub DisplayFund()
        If dtFund IsNot Nothing AndAlso dtFund.Rows.Count > 0 Then
            rowNomer = 0
            Dim query = From u In dtFund.AsEnumerable
                        Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Join a In dtParameterPortfolioAsset.AsEnumerable
                               On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select No = generateNumber(),
                               Fund = p.Field(Of String)("PortfolioCode"),
                               Name = p.Field(Of String)("PortfolioNameShort"),
                               AssetType = a.Field(Of String)("AssetTypeCode"),
                               Unit = u.Field(Of Decimal)("UnitBalance"),
                               Price = u.Field(Of Decimal)("UnitPrice"),
                               AvgCost = u.Field(Of Decimal)("CostPrice"),
                               Value = u.Field(Of Decimal)("UnitValue"),
                               TotalCost = u.Field(Of Decimal)("CostTotal"),
                               UnrlPL = u.Field(Of Decimal)("UnitValue") - u.Field(Of Decimal)("CostTotal")

            With DBGFund
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Unit").NumberFormat = "n4"
                .Columns("Price").NumberFormat = "n4"
                .Columns("AvgCost").NumberFormat = "n4"
                .Columns("Value").NumberFormat = "n2"
                .Columns("TotalCost").NumberFormat = "n2"
                .Columns("UnrlPL").NumberFormat = "n2"

                .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AssetType").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("TotalCost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("UnrlPL").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("AssetType").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("TotalCost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("UnrlPL").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("AssetType").Caption = "Type"
                .Columns("TotalCost").Caption = "Total Cost"
                .Columns("AvgCost").Caption = "Average Cost"
                .Columns("UnrlPL").Caption = "Unreal. PL"

                For Each column As C1DisplayColumn In DBGFund.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With
        End If
    End Sub

    Private Sub DBGFund_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGFund.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

#End Region

#Region "pie asset"
    Private Sub DisplayChartAsset()
        If dtFund IsNot Nothing AndAlso dtFund.Rows.Count > 0 Then
            chartAsset.Style.Border.BorderStyle = BorderStyleEnum.None
            chartAsset.ChartLabels.DefaultLabelStyle.BackColor = SystemColors.Info
            chartAsset.ChartLabels.DefaultLabelStyle.Border.BorderStyle = BorderStyleEnum.Solid
            Dim grp As ChartGroup = chartAsset.ChartGroups(0)
            grp.ChartType = Chart2DTypeEnum.Pie
            grp.Pie.OtherOffset = 0

            ' Clear existing, and add new data.
            Dim dat As ChartData = grp.ChartData
            dat.SeriesList.Clear()

            ' Pick a nice color for each Series.
            Dim ColorValue() As Color = {Color.OrangeRed, Color.Tan, Color.LightGreen, Color.MediumTurquoise,
                                         Color.DodgerBlue, Color.Magenta, Color.GreenYellow, Color.MediumBlue}

            Dim query = From u In dtFund.AsEnumerable
                        Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Join a In dtParameterPortfolioAsset.AsEnumerable
                               On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Group u By key = New With {Key .AssetType = a.Field(Of String)("AssetTypeCode")}
                              Into Group Select New With {
                                        .AssetType = key.AssetType,
                                        .Value = Group.Sum(Function(r) r.Field(Of Decimal)("UnitValue"))
                                        }
            Dim aumTotal As Double = (From c In query Select aum = c.Value).Sum()
            Dim slice, items, itemTotal As Integer
            itemTotal = 100
            slice = 0

            For Each item In query
                items = _valuePie(item.Value, aumTotal)
                itemTotal -= items

                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, items)
                series.LineStyle.Color = ColorValue(slice)
                series.Label = item.AssetType

                Dim lab As Label = chartAsset.ChartLabels.LabelsCollection.AddNewLabel()
                lab.AttachMethod = AttachMethodEnum.DataIndex

                Dim amd As AttachMethodData = lab.AttachMethodData
                amd.GroupIndex = 0
                amd.PointIndex = 0
                amd.SeriesIndex = slice

                lab.Text = items & " %"
                lab.Compass = LabelCompassEnum.Radial
                lab.Connected = True
                lab.Offset = 12
                lab.Visible = True
                lab.Style.Border.BorderStyle = BorderStyleEnum.None

                slice += 1
            Next
            chartAsset.Legend.Visible = True
            chartAsset.Legend.Compass = CompassEnum.South
            chartAsset.ChartGroups(0).ShowOutline = False
            chartAsset.ChartArea.PlotArea.View3D.Elevation = 45

        End If
    End Sub

#End Region

#Region "pie fund"
    Private Function _valuePie(ByVal item As Double, ByVal total As Double) As Integer
        If total = 0 Then Return 0 Else Return CInt(item * 100 / total)
    End Function

    Private Sub DisplayChartFund()
        If dtFund IsNot Nothing AndAlso dtFund.Rows.Count > 0 Then
            chartFund.Style.Border.BorderStyle = BorderStyleEnum.None
            chartFund.ChartLabels.DefaultLabelStyle.BackColor = SystemColors.Info
            chartFund.ChartLabels.DefaultLabelStyle.Border.BorderStyle = BorderStyleEnum.Solid
            Dim grp As ChartGroup = chartFund.ChartGroups(0)
            grp.ChartType = Chart2DTypeEnum.Pie
            grp.Pie.OtherOffset = 0

            ' Clear existing, and add new data.
            Dim dat As ChartData = grp.ChartData
            dat.SeriesList.Clear()

            ' Pick a nice color for each Series.
            Dim ColorValue() As Color = {Color.OrangeRed, Color.Tan, Color.LightGreen, Color.MediumTurquoise,
                                         Color.DodgerBlue, Color.Magenta, Color.GreenYellow, Color.MediumBlue}

            Dim slice, max, items, itemTotal As Integer
            itemTotal = 100
            slice = 0
            Dim total As Double = CDbl(lblLastValue.Text)

            Dim query = From u In dtFund.AsEnumerable
                        Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Order By u.Field(Of Decimal)("UnitValue") Descending
                        Select Fund = p.Field(Of String)("PortfolioCode"),
                               Value = u.Field(Of Decimal)("UnitValue")

            If query.Count < 6 Then max = query.Count - 1 Else max = 4

            For Each item In query
                items = _valuePie(item.Value, total)
                itemTotal -= items

                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, items)
                series.LineStyle.Color = ColorValue(slice)
                series.Label = item.Fund

                Dim lab As Label = chartFund.ChartLabels.LabelsCollection.AddNewLabel()
                lab.AttachMethod = AttachMethodEnum.DataIndex

                Dim amd As AttachMethodData = lab.AttachMethodData
                amd.GroupIndex = 0
                amd.PointIndex = 0
                amd.SeriesIndex = slice

                lab.Text = items & " %"
                lab.Compass = LabelCompassEnum.Radial
                lab.Connected = True
                lab.Offset = 12
                lab.Visible = True
                lab.Style.Border.BorderStyle = BorderStyleEnum.None
                slice += 1
            Next

            If itemTotal > 0 Then
                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, itemTotal)
                series.LineStyle.Color = ColorValue(slice)
                series.Label = "Other(s)"

                Dim lab As Label = chartFund.ChartLabels.LabelsCollection.AddNewLabel()
                lab.AttachMethod = AttachMethodEnum.DataIndex

                Dim amd As AttachMethodData = lab.AttachMethodData
                amd.GroupIndex = 0
                amd.PointIndex = 0
                amd.SeriesIndex = slice

                lab.Text = itemTotal & " %"
                lab.Compass = LabelCompassEnum.Radial
                lab.Connected = True
                lab.Offset = 12
                lab.Visible = True
                lab.Style.Border.BorderStyle = BorderStyleEnum.None
            End If
            chartFund.Legend.Visible = True
            chartFund.Legend.Compass = CompassEnum.South

            chartFund.ChartGroups(0).ShowOutline = False
            chartFund.ChartArea.PlotArea.View3D.Elevation = 45
        End If
    End Sub


#End Region

#Region "transaction history"
    Private Sub txtLatest_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLatest.KeyDown
        If e.KeyCode = Keys.Enter Then DisplayTransaction()
    End Sub

    Private Sub btnTrx_Click(sender As Object, e As EventArgs) Handles btnTrx.Click
        DisplayTransaction()
    End Sub

    Private Sub DisplayTransaction()
        If dtTransaction IsNot Nothing AndAlso dtTransaction.Rows.Count > 0 Then
            Dim query = From t In dtTransaction.AsEnumerable
                        Join p In dtPortfolioSimpi.AsEnumerable
                               On t.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Join a In dtParameterTATrxType1.AsEnumerable
                               On t.Field(Of Integer)("TrxType1") Equals a.Field(Of Integer)("TrxTypeID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select TrxDate = t.Field(Of Date)("TrxDate"),
                               Fund = p.Field(Of String)("PortfolioCode"),
                               Name = p.Field(Of String)("PortfolioNameshort"),
                               Type = a.Field(Of String)("TrxTypeCode"),
                               Amount = t.Field(Of Decimal)("TrxAmount"),
                               Price = t.Field(Of Decimal)("TrxPrice"),
                               Unit = t.Field(Of Decimal)("TrxUnit")

            Dim no As Integer
            Int32.TryParse(txtLatest.Text, no)

            With DBGTrx
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                If no > 0 Then .DataSource = query.Take(no).ToList Else .DataSource = query.ToList

                .Columns("TrxDate").NumberFormat = "dd-MMM-yyyy"
                .Columns("Amount").NumberFormat = "n2"
                .Columns("Price").NumberFormat = "n4"
                .Columns("Unit").NumberFormat = "n4"

                .Splits(0).DisplayColumns("TrxDate").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("TrxDate").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("TrxDate").Caption = "Date"

                For Each column As C1DisplayColumn In DBGTrx.Splits(0).DisplayColumns
                    If column.Name.Trim = "Name" Then column.Visible = False Else column.AutoSize()
                Next
            End With

        End If
    End Sub

    Private Sub DBGTrx_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGTrx.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

#End Region

#Region "export"
    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        ExportPDF(False)
    End Sub

    Public Function ExportPDF(ByVal isAttachment As Boolean) As String
        Return PrintPDF(isAttachment)
    End Function

    Private Sub btnExcelHolding_Click(sender As Object, e As EventArgs) Handles btnExcelHolding.Click
        ExportExcelHolding(False)
    End Sub

    Public Function ExportExcelHolding(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGFund, "ReportAFSHolding" & lblClientName.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnExcelTransaction_Click(sender As Object, e As EventArgs) Handles btnExcelTransaction.Click
        ExportExcelTransaction(False)
    End Sub

    Public Function ExportExcelTransaction(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGTrx, "ReportAFSTransaction" & lblClientName.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGFund.RowCount > 0 Then
            Dim frm As New ReportAccountFactSheetEmail
            frm.Show()
            frm.frm = Me
            frm.MdiParent = MDIMIS
        End If
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        ReportSetting()
    End Sub

    Private Sub ReportSetting()
        Dim frm As New ReportAccountFactSheetSetting
        frm.frm = Me
        frm.Show()
        frm.FormLoad()
        frm.MdiParent = MDIMIS
    End Sub

    Private Function PrintPDF(ByVal isAttachment As Boolean) As String
        Dim strFile As String = ""
        Dim strLayout As String = ""
        Dim myBrush As New SolidBrush(Color.FromArgb(0, 61, 121))
        Dim detailBrush As New SolidBrush(Color.Black)
        Dim headerBrush As New SolidBrush(Color.White)
        Dim koordX As Single = 40, koordY As Single = 35
        Dim fontType = "Calibri", fontSize = 8
        With c1pdf
            .Clear()
            .PaperKind = Printing.PaperKind.A4
            .Landscape = True
            Dim rc As RectangleF = .PageRectangle
            strLayout = reportPDFPortrait("REPORT TEMPLATE LANDSCAPE")
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
            .DrawString(pdfLayout.AsOf & dtAs.Value.ToString("dd MMMM yyyy") & " (" & cmbCcy.Text & " - " & lblCcy.Text & ")", New Font(fontType, 8),
                        New SolidBrush(Color.FromArgb(pdfLayout.Client_R, pdfLayout.Client_G, pdfLayout.Client_B)), New PointF(155, koordY))

            koordY += 15
            .DrawLine(New Pen(Color.FromArgb(255, 153, 51), 1.5), New PointF(koordX, koordY), New PointF(koordX + 625, koordY))

            koordY += 8
            .DrawString(pdfLayout.Summary, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.Summary_R, pdfLayout.Summary_G, pdfLayout.Summary_B)), New PointF(koordX, koordY))
            .DrawString(pdfLayout.InvestmentGrowth, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.ChartTitle_R, pdfLayout.ChartTitle_G, pdfLayout.ChartTitle_B)), New PointF(200, koordY))
            .DrawString(pdfLayout.FundAllocation, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.PieTitle1_R, pdfLayout.PieTitle1_G, pdfLayout.PieTitle1_B)), New PointF(635, koordY))

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
            rc = New RectangleF(New PointF(koordX + 170, koordY + 20), New SizeF(0.6 * chartNAV.Size.Width, 0.6 * chartNAV.Size.Height))
            .DrawImage(imgPortfolio, rc, ContentAlignment.TopLeft, C1.C1Pdf.ImageSizeModeEnum.Scale)
            If pdfLayout.ChartBorder Then
                Dim pnNAV As New Pen(New SolidBrush(Color.FromArgb(pdfLayout.ChartLine_R, pdfLayout.ChartLine_G, pdfLayout.ChartLine_B)), 0.5)
                .DrawRectangle(pnNAV, rc)
            Else
                .DrawRectangle(Pens.White, rc)
            End If

            If pdfLayout.PieBorder1 Then
                chartFund.BorderStyle = BorderStyle.FixedSingle
                chartFund.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.Solid
                chartFund.ChartArea.Style.Border.Color = Color.FromArgb(pdfLayout.PieBorder1_R, pdfLayout.PieBorder1_G, pdfLayout.PieBorder1_B)
            Else
                chartFund.BorderStyle = BorderStyle.None
                chartFund.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.None
            End If
            Dim imgFund = chartFund.GetImage(ImageFormat.Emf)
            rc = New RectangleF(New PointF(koordX + 600, koordY + 20), New SizeF(0.6 * chartFund.Size.Width, 0.6 * chartFund.Size.Height))
            .DrawImage(imgFund, rc, ContentAlignment.TopLeft, C1.C1Pdf.ImageSizeModeEnum.Scale)
            .DrawRectangle(Pens.White, rc)

            Dim strRight, strCenter, strLeft As New StringFormat()
            strLeft.Alignment = StringAlignment.Near
            strRight.Alignment = StringAlignment.Far
            strCenter.Alignment = StringAlignment.Center

            koordY += 15
            .DrawString(pdfLayout.SummaryItemsTotalInvestmentValue, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblLastValue.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsTotalAcqusitionCost, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblLastCost.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.SummaryLine_R, pdfLayout.SummaryLine_G, pdfLayout.SummaryLine_B), 0.5),
                      New PointF(koordX + 150, koordY), New PointF(koordX + 75, koordY))

            koordY += 2
            .DrawString(pdfLayout.SummaryItemsTotalUnrealizedPL, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblLastPL.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsInvestmentLength, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            If CInt(lblInvestmentDays.Text) < 2 Then
                .DrawString(lblInitialJoin.Text & " (" & lblInvestmentDays.Text & " day)", New Font(fontType, 7),
                                       New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                                       New PointF(koordX + 150, koordY), strRight)
            Else
                .DrawString(lblInitialJoin.Text & " (" & lblInvestmentDays.Text & " days)", New Font(fontType, 7),
                       New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                       New PointF(koordX + 150, koordY), strRight)
            End If

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsTotalSubscription, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblSubscription.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsTotalRedemption, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblRedemption.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 10
            .DrawString(pdfLayout.SummaryItemsTotalDividend, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 10, koordY))
            .DrawString(lblDividend.Text, New Font(fontType, 7),
                        New SolidBrush(Color.FromArgb(pdfLayout.SummaryItems_R, pdfLayout.SummaryItems_G, pdfLayout.SummaryItems_B)),
                        New PointF(koordX + 150, koordY), strRight)

            koordY += 20
            .DrawLine(New Pen(Color.FromArgb(pdfLayout.ChartLine_R, pdfLayout.ChartLine_G, pdfLayout.ChartLine_B), 0.75),
                      New PointF(koordX + 145, koordY), New PointF(koordX + 160, koordY))
            .DrawString(pdfLayout.ChartLabel1, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.Black), New PointF(koordX + 160, koordY), strRight)
            .DrawString(pdfLayout.ChartLabel2, New Font(fontType, 6, FontStyle.Italic),
                        New SolidBrush(Color.Black), New PointF(koordX + 160, koordY + 7), strRight)

            koordY += 30
            .DrawString(pdfLayout.ListOfUnitholding, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableHeaderHolding_R, pdfLayout.TableHeaderHolding_G, pdfLayout.TableHeaderHolding_B)),
                        New PointF(koordX, koordY))
            .DrawString(pdfLayout.AssetTypeAllocation, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.PieTitle1_R, pdfLayout.PieTitle1_G, pdfLayout.PieTitle1_B)),
                        New PointF(635, koordY))

            If pdfLayout.PieBorder2 Then
                chartAsset.BorderStyle = BorderStyle.FixedSingle
                chartAsset.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.Solid
                chartAsset.ChartArea.Style.Border.Color = Color.FromArgb(pdfLayout.PieBorder2_R, pdfLayout.PieBorder2_G, pdfLayout.PieBorder2_B)
            Else
                chartAsset.BorderStyle = BorderStyle.None
                chartAsset.ChartArea.Style.Border.BorderStyle = BorderStyleEnum.None
            End If
            Dim imgAsset = chartAsset.GetImage(ImageFormat.Emf)
            rc = New RectangleF(New PointF(koordX + 600, koordY + 20), New SizeF(0.6 * chartAsset.Size.Width, 0.6 * chartAsset.Size.Height))
            .DrawImage(imgAsset, rc, ContentAlignment.TopLeft, C1.C1Pdf.ImageSizeModeEnum.Scale)
            .DrawRectangle(Pens.White, rc)

            koordY += 14
            .FillRectangle(New SolidBrush(Color.FromArgb(pdfLayout.TableLineHolding_R, pdfLayout.TableLineHolding_G, pdfLayout.TableLineHolding_B)),
                           New RectangleF(koordX, koordY, 580, 10))
            .DrawString(pdfLayout.TableTitleNoHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 10, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleFundHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 45, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleNameHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 130, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleTypeHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 240, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleUnitHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 285, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleNAVUnitHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 335, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleAvgCostHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 380, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleValueHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 430, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleAcqCostHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 490, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleUnrealizedPLHolding, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleHolding_R, pdfLayout.TableTitleHolding_G, pdfLayout.TableTitleHolding_B)),
                        New PointF(koordX + 550, koordY), strCenter)

            koordY += 10
            Dim str As String
            If dtFund.Rows.Count > 0 Then
                Dim pn2 As New Pen(New SolidBrush(Color.FromArgb(pdfLayout.TableLineHolding_R, pdfLayout.TableLineHolding_G, pdfLayout.TableLineHolding_B)), 0.5)
                For i = 0 To DBGFund.RowCount - 1
                    DBGFund.Row = i
                    .DrawRectangle(pn2, New RectangleF(koordX, koordY, 20, 10))        'no
                    .DrawRectangle(pn2, New RectangleF(koordX + 20, koordY, 50, 10))   'fund
                    .DrawRectangle(pn2, New RectangleF(koordX + 70, koordY, 160, 10))  'name
                    .DrawRectangle(pn2, New RectangleF(koordX + 230, koordY, 20, 10))  'asset
                    .DrawRectangle(pn2, New RectangleF(koordX + 250, koordY, 60, 10))  'unit 
                    .DrawRectangle(pn2, New RectangleF(koordX + 310, koordY, 45, 10))  'price 
                    .DrawRectangle(pn2, New RectangleF(koordX + 355, koordY, 45, 10))  'cost
                    .DrawRectangle(pn2, New RectangleF(koordX + 400, koordY, 60, 10))  'value 
                    .DrawRectangle(pn2, New RectangleF(koordX + 460, koordY, 60, 10))  'cost
                    .DrawRectangle(pn2, New RectangleF(koordX + 520, koordY, 60, 10))  'PL

                    str = DBGFund.Columns("No").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 10, koordY), strCenter)
                    str = DBGFund.Columns("Fund").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 25, koordY), strLeft)
                    str = DBGFund.Columns("Name").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 75, koordY), strLeft)
                    str = DBGFund.Columns("AssetType").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 240, koordY), strCenter)
                    str = DBGFund.Columns("Unit").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 305, koordY), strRight)
                    str = DBGFund.Columns("Price").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 350, koordY), strRight)
                    str = DBGFund.Columns("AvgCost").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 395, koordY), strRight)
                    str = DBGFund.Columns("Value").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 455, koordY), strRight)
                    str = DBGFund.Columns("TotalCost").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 515, koordY), strRight)
                    str = DBGFund.Columns("UnrlPL").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsHolding_R, pdfLayout.TableItemsHolding_G, pdfLayout.TableItemsHolding_B)),
                                New PointF(koordX + 575, koordY), strRight)
                    koordY += 10
                Next
            End If

            koordY += 25
            .DrawString(pdfLayout.LatestTransaction, New Font(fontType, 11),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableHeaderTrx_R, pdfLayout.TableHeaderTrx_G, pdfLayout.TableHeaderTrx_B)),
                        New PointF(koordX, koordY))
            koordY += 14
            .FillRectangle(New SolidBrush(Color.FromArgb(pdfLayout.TableLineTrx_R, pdfLayout.TableLineTrx_G, pdfLayout.TableLineTrx_B)),
                           New RectangleF(koordX, koordY, 575, 10))
            .DrawString(pdfLayout.TableTitleDateTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 20, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleFundTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 65, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleNameTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 200, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleTypeTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 337, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleAmountTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 405, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleNAVUnitTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 470, koordY), strCenter)
            .DrawString(pdfLayout.TableTitleUnitTrx, New Font(fontType, 6, FontStyle.Bold),
                        New SolidBrush(Color.FromArgb(pdfLayout.TableTitleTrx_R, pdfLayout.TableTitleTrx_G, pdfLayout.TableTitleTrx_B)),
                        New PointF(koordX + 535, koordY), strCenter)

            koordY += 10
            If dtTransaction.Rows.Count > 0 Then
                Dim pn As New Pen(New SolidBrush(Color.FromArgb(pdfLayout.TableLineTrx_R, pdfLayout.TableLineTrx_G, pdfLayout.TableLineTrx_B)), 0.5)
                For i = 0 To DBGTrx.RowCount - 1
                    DBGTrx.Row = i
                    .DrawRectangle(pn, New RectangleF(koordX, koordY, 40, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 40, koordY, 50, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 90, koordY, 220, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 310, koordY, 60, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 370, koordY, 75, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 445, koordY, 55, 10))
                    .DrawRectangle(pn, New RectangleF(koordX + 500, koordY, 75, 10))

                    str = DBGTrx.Columns("TrxDate").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 20, koordY), strCenter)
                    str = DBGTrx.Columns("Fund").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 45, koordY), strLeft)
                    str = DBGTrx.Columns("Name").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 95, koordY), strLeft)
                    str = DBGTrx.Columns("Type").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 337, koordY), strCenter)
                    str = DBGTrx.Columns("Amount").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 440, koordY), strRight)
                    str = DBGTrx.Columns("Price").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 495, koordY), strRight)
                    str = DBGTrx.Columns("Unit").Text
                    .DrawString(str, New Font(fontType, 6),
                                New SolidBrush(Color.FromArgb(pdfLayout.TableItemsTrx_R, pdfLayout.TableItemsTrx_G, pdfLayout.TableItemsTrx_B)),
                                New PointF(koordX + 570, koordY), strRight)
                    koordY += 10
                Next
            End If

            strFile = reportFileExists("ReportAFS" & lblClientName.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".pdf")
            .Save(strFile)
            If Not isAttachment Then Process.Start(strFile)
        End With
        Return strFile
    End Function

    Private Sub btnProperty_Click(sender As Object, e As EventArgs) Handles btnInvestment.Click
        Dim pg As PropertyGrid = New PropertyGrid()
        pg.SelectedObject = chartNAV
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As Form = New Form()
        f.Text = "Investment Growth"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
    End Sub

    Private Sub btnFund_Click(sender As Object, e As EventArgs) Handles btnFund.Click
        Dim pg As PropertyGrid = New PropertyGrid()
        pg.SelectedObject = chartFund
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As Form = New Form()
        f.Text = "Fund Allocation"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
    End Sub

    Private Sub btnAsset_Click(sender As Object, e As EventArgs) Handles btnAsset.Click
        Dim pg As PropertyGrid = New PropertyGrid()
        pg.SelectedObject = chartAsset
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As Form = New Form()
        f.Text = "Asset Allocation"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
    End Sub

#End Region

End Class