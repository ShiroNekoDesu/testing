Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1Chart
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterClient
Imports simpi.MasterSecurities

Public Class ReportAccountFee
    Dim objPortfolio As New MasterPortfolio
    Dim objCapital As New PositionCapital
    Dim objClient As New MasterClient
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi

    Dim dtFee As New DataTable

    Private Sub ReportAccountFee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPortfolioSimpi()
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        objPortfolio.UserAccess = objAccess
        objClient.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        DBGTransaction.FetchRowStyles = True
        DBGFund.FetchRowStyles = True
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
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
        cmbCcy.Text = "IDR"
    End Sub

    Private Sub DataClear()
        DBGTransaction.Columns.Clear()
        DBGFund.Columns.Clear()
        chartFee.Reset()
    End Sub

    Private Sub DataLoad()
        If objClient.GetClientID > 0 Then
            objCapital.Clear()
            dtFee = objCapital.SearchHistory(objClient, dtFrom.Value, dtTo.Value)
        End If
    End Sub

    Private Sub rbFund_Click(sender As Object, e As EventArgs) Handles rbFund.Click
        btnSearchPortfolio.Enabled = True
        cmbCcy.Enabled = False
        cmbCcy.SelectedIndex = 1
    End Sub

    Private Sub rbCcy_Click(sender As Object, e As EventArgs) Handles rbCcy.Click
        btnSearchPortfolio.Enabled = False
        cmbCcy.Enabled = True
        lblPortfolioCode.Text = ""
        lblPortfolioName.Text = ""
        lblSimpiEmail.Text = ""
        lblSimpiName.Text = ""
    End Sub

    Private Sub cmbCcy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCcy.SelectedIndexChanged
        DisplaySummaryCcy()
        DisplayFeeCcy()
        'displaychart
    End Sub

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
                    DisplaySummaryFund()
                    DisplayFeeFund()
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#Region "fee historical"
    Private Sub DisplayFeeFund()
        If dtFee IsNot Nothing AndAlso dtFee.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim query = From f In dtFee.AsEnumerable
                        Where f.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID
                        Select Tanggal = f.Field(Of Date)("PositionDate"),
                               AUM = f.Field(Of Decimal)("UnitValue"),
                               Fee = f.Field(Of Decimal)("FeeManagement"),
                               Others = f.Field(Of Decimal)("FeeOther"),
                               Sales = f.Field(Of Decimal)("FeeSales")

            With DBGTransaction
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Tanggal").NumberFormat = "dd-MMM-yy"
                .Columns("AUM").NumberFormat = "n2"
                .Columns("Fee").NumberFormat = "n2"
                .Columns("Others").NumberFormat = "n2"
                .Columns("Sales").NumberFormat = "n2"

                .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fee").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Others").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Fee").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Others").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("Tanggal").Caption = "Date"
                .Columns("Fee").Caption = "Mngment Fee"
                .Columns("Others").Caption = "OJK & PPh"
                .Columns("Sales").Caption = "Comm./Reff."

                For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With

            With chartFee
                .Style.Border.BorderStyle = BorderStyleEnum.None
                Dim ds As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
                ds.Clear()
                Dim series As ChartDataSeries = ds.AddNewSeries()
                series.Label = "AUM"
                series.LineStyle.Color = Color.Blue
                series.LineStyle.Thickness = 2
                series.SymbolStyle.Shape = SymbolShapeEnum.None
                series.FitType = FitTypeEnum.Line

                series.X.CopyDataIn((From q In query Select q.Tanggal).ToArray)
                series.Y.CopyDataIn((From q In query Select q.AUM).ToArray)
                series.PointData.Length = query.Count


                Dim ds2 As ChartDataSeriesCollection = .ChartGroups(1).ChartData.SeriesList
                ds2.Clear()
                Dim series2 As ChartDataSeries = ds2.AddNewSeries()
                series2.Label = "Fee"
                series2.LineStyle.Color = Color.Green
                series2.LineStyle.Thickness = 1
                series2.SymbolStyle.Shape = SymbolShapeEnum.None
                series2.FitType = FitTypeEnum.Line

                series2.X.CopyDataIn((From q In query Select q.Tanggal).ToArray)
                series2.Y.CopyDataIn((From q In query Select q.Fee).ToArray)
                series2.PointData.Length = query.Count

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

                .ChartArea.AxisY2.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY2.AnnoFormatString = "n0"
            End With
        End If
    End Sub

    Private Sub DisplayFeeCcy()
        If dtFee IsNot Nothing AndAlso dtFee.Rows.Count > 0 AndAlso
           dtPortfolioSimpi IsNot Nothing AndAlso dtPortfolioSimpi.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim query = From f In dtFee.AsEnumerable
                        Join p In dtPortfolioSimpi On f.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Group f By key = New With {Key .Tanggal = f.Field(Of Date)("PositionDate")}
                              Into Group Select New With {
                                        .Tanggal = key.Tanggal,
                                        .AUM = Group.Sum(Function(r) r.Field(Of Decimal)("UnitValue")),
                                        .Fee = Group.Sum(Function(r) r.Field(Of Decimal)("FeeManagement")),
                                        .Others = Group.Sum(Function(r) r.Field(Of Decimal)("FeeOther")),
                                        .Sales = Group.Sum(Function(r) r.Field(Of Decimal)("FeeSales"))
                                        }


            With DBGTransaction
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Tanggal").NumberFormat = "dd-MMM-yy"
                .Columns("AUM").NumberFormat = "n2"
                .Columns("Fee").NumberFormat = "n2"
                .Columns("Others").NumberFormat = "n2"
                .Columns("Sales").NumberFormat = "n2"

                .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fee").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Others").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Fee").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Others").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("Tanggal").Caption = "Date"
                .Columns("Fee").Caption = "Mngment Fee"
                .Columns("Others").Caption = "OJK & PPh"
                .Columns("Sales").Caption = "Comm./Reff."

                For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With

            With chartFee
                .Style.Border.BorderStyle = BorderStyleEnum.None
                Dim ds As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
                ds.Clear()
                Dim series As ChartDataSeries = ds.AddNewSeries()
                series.Label = "AUM"
                series.LineStyle.Color = Color.Blue
                series.LineStyle.Thickness = 2
                series.SymbolStyle.Shape = SymbolShapeEnum.None
                series.FitType = FitTypeEnum.Line

                series.X.CopyDataIn((From q In query Select q.Tanggal).ToArray)
                series.Y.CopyDataIn((From q In query Select q.AUM).ToArray)
                series.PointData.Length = query.Count


                Dim ds2 As ChartDataSeriesCollection = .ChartGroups(1).ChartData.SeriesList
                ds2.Clear()
                Dim series2 As ChartDataSeries = ds2.AddNewSeries()
                series2.Label = "Fee"
                series2.LineStyle.Color = Color.Green
                series2.LineStyle.Thickness = 1
                series2.SymbolStyle.Shape = SymbolShapeEnum.None
                series2.FitType = FitTypeEnum.Line

                series2.X.CopyDataIn((From q In query Select q.Tanggal).ToArray)
                series2.Y.CopyDataIn((From q In query Select q.Fee).ToArray)
                series2.PointData.Length = query.Count

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

                .ChartArea.AxisY2.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY2.AnnoFormatString = "n0"
            End With
        End If
    End Sub

    Private Sub DBGTransaction_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGTransaction.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGTransaction.Click
        If DBGTransaction.RowCount > 0 Then DBGTransaction.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

#End Region

#Region "summary"
    Private Sub DisplaySummaryFund()
        If dtFee IsNot Nothing AndAlso dtFee.Rows.Count > 0 AndAlso
           dtPortfolioSimpi IsNot Nothing AndAlso dtPortfolioSimpi.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim query = From f In dtFee.AsEnumerable
                        Join p In dtPortfolioSimpi On f.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID
                        Group f By key = New With {Key .Fund = p.Field(Of String)("PortfolioCode")}
                              Into Group Select New With {
                                        .Fund = key.Fund,
                                        .AUM = Group.Average(Function(r) r.Field(Of Decimal)("UnitValue")),
                                        .Fee = Group.Sum(Function(r) r.Field(Of Decimal)("FeeManagement")),
                                        .Others = Group.Sum(Function(r) r.Field(Of Decimal)("FeeOther")),
                                        .Sales = Group.Sum(Function(r) r.Field(Of Decimal)("FeeSales"))
                                        }

            With DBGFund
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("AUM").NumberFormat = "n2"
                .Columns("Fee").NumberFormat = "n2"
                .Columns("Others").NumberFormat = "n2"
                .Columns("Sales").NumberFormat = "n2"

                .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fee").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Others").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("AUM").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Fee").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Others").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("AUM").Caption = "Avg AUM"
                .Columns("Fee").Caption = "Mngment Fee"
                .Columns("Others").Caption = "OJK & PPh"
                .Columns("Sales").Caption = "Comm./Reff."

                For Each column As C1DisplayColumn In DBGFund.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With
        End If
    End Sub

    Private Sub DisplaySummaryCcy()
        If dtFee IsNot Nothing AndAlso dtFee.Rows.Count > 0 AndAlso
           dtPortfolioSimpi IsNot Nothing AndAlso dtPortfolioSimpi.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim query = From f In dtFee.AsEnumerable
                        Join p In dtPortfolioSimpi On f.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Group f By key = New With {Key .Fund = p.Field(Of String)("PortfolioCode")}
                              Into Group Select New With {
                                        .Fund = key.Fund,
                                        .AUM = Group.Average(Function(r) r.Field(Of Decimal)("UnitValue")),
                                        .Fee = Group.Sum(Function(r) r.Field(Of Decimal)("FeeManagement")),
                                        .Others = Group.Sum(Function(r) r.Field(Of Decimal)("FeeOther")),
                                        .Sales = Group.Sum(Function(r) r.Field(Of Decimal)("FeeSales"))
                                        }


            With DBGFund
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("AUM").NumberFormat = "n2"
                .Columns("Fee").NumberFormat = "n2"
                .Columns("Others").NumberFormat = "n2"
                .Columns("Sales").NumberFormat = "n2"

                .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fee").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Others").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("AUM").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Fee").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Others").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("AUM").Caption = "Avg AUM"
                .Columns("Fee").Caption = "Mngment Fee"
                .Columns("Others").Caption = "OJK & PPh"
                .Columns("Sales").Caption = "Comm./Reff."

                For Each column As C1DisplayColumn In DBGFund.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With
        End If
    End Sub

    Private Sub DBGFund_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGFund.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFund.Click
        If DBGFund.RowCount > 0 Then DBGTransaction.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub


#End Region

#Region "export"
    Private Sub btnExcelDaily_Click(sender As Object, e As EventArgs) Handles btnExcelDaily.Click
        ExportExcelDaily(False)
    End Sub

    Public Function ExportExcelDaily(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGTransaction, "ReportAFDaily" & lblClientName.Text.Trim & dtFrom.Value.ToString("yyyymmdd") & dtTo.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnExcelSummary_Click(sender As Object, e As EventArgs) Handles btnExcelSummary.Click
        ExportExcelSummary(False)
    End Sub

    Public Function ExportExcelSummary(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGFund, "ReportAFSummary" & lblClientName.Text.Trim & dtFrom.Value.ToString("yyyymmdd") & dtTo.Value.ToString("yyyymmdd") & ".xls")
    End Function


#End Region

End Class