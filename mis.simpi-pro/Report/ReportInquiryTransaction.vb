Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterSecurities
Imports simpi.ParameterTA
Imports simpi.ParameterTA.ParameterTA

Public Class ReportInquiryTransaction
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi
    Dim objCapital As New TransactionCapital

    Dim dtTransaction As New DataTable
    Dim saldoUnit As Double = 0

    Private Sub ReportFundTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        cmbCcy.Text = "IDR"
        GetComboInitAll(New ParameterTransactionTrxType1, cmbType, "TrxTypeID", "TrxTypeCode")
        GetParameterTATrxType1()
        GetPortfolioSimpi()
        GetClientMaster()
        GetSalesMaster()

        objSimpi.UserAccess = objAccess
        objCapital.UserAccess = objAccess

        DBGTransaction.FetchRowStyles = True
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataSearch()
    End Sub

    Private Sub DataSearch()
        If cmbCcy.SelectedIndex <> -1 Then
            objCapital.Clear()
            dtTransaction = objCapital.Search(objMasterSimpi, dtFrom.Value, dtTo.Value)
            SummaryClear()
            DBGTransaction.Columns.Clear()
            If objCapital.ErrID = 0 Then
                DisplayTransaction()
                SummarySubscription()
                SummaryRedemption()
                SummaryDividend()
            Else
                ExceptionMessage.Show(objCapital.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ExceptionMessage.Show(objError.Message(81) & " master portfolio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        DisplayTransaction()
    End Sub

    Private Sub DisplayTransaction()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then If cmbType.SelectedValue < 1 Then DisplayAll() Else DisplayType()
    End Sub

    Private Sub DisplayAll()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join t In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join c In dtClientMaster.AsEnumerable
                               On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable
                               On c.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Code = p.Field(Of String)("PortfolioCode"),
                           Portfolio = p.Field(Of String)("PortfolioNameShort"),
                           Sales = s.Field(Of String)("SalesCode"),
                           CIF = c.Field(Of String)("ClientCode"),
                           Client = c.Field(Of String)("ClientName"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = SetSubscription(),
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")), u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

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

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Code").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Portfolio").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Client").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Code").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Portfolio").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Client").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Tanggal").Caption = "Date"
            .Columns("NAVDate").Caption = "NAV"

            For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub DisplayType()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join t In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join c In dtClientMaster.AsEnumerable
                               On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable
                               On c.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Code = p.Field(Of String)("PortfolioCode"),
                           Portfolio = p.Field(Of String)("PortfolioNameShort"),
                           Sales = s.Field(Of String)("SalesCode"),
                           CIF = c.Field(Of String)("ClientCode"),
                           Client = c.Field(Of String)("ClientName"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = SetSubscription(),
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) - u.Field(Of Decimal)("TrxAmount")), u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

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

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Code").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Portfolio").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Client").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Code").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Portfolio").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Client").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Tanggal").Caption = "Date"
            .Columns("NAVDate").Caption = "NAV"

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

    Private Sub SummaryClear()
        lblSubscriptionNo.Text = "0"
        lblSubscriptionUnit.Text = "0.0000"
        lblSubscriptionValue.Text = "0"

        lblRedemptionNo.Text = "0"
        lblRedemptionUnit.Text = "0.0000"
        lblRedemptionValue.Text = "0"

        lblDividendNo.Text = "0"
        lblDividendUnit.Text = "0.0000"
        lblDividendValue.Text = "0"
    End Sub

    Private Sub SummarySubscription()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Where u.Field(Of Integer)("TrxType1") = SetSubscription()
                        Select u.Field(Of Decimal)("TrxUnit")
            lblSubscriptionNo.Text = query.Count
            lblSubscriptionUnit.Text = query.Sum().ToString("n4")
            lblSubscriptionValue.Text = (From u In dtTransaction.AsEnumerable Where u.Field(Of Integer)("TrxType1") = SetSubscription()
                                         Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")
        End If
    End Sub

    Private Sub SummaryRedemption()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Where u.Field(Of Integer)("TrxType1") = SetRedemption()
                        Select u.Field(Of Decimal)("TrxUnit")
            lblRedemptionNo.Text = query.Count
            lblRedemptionUnit.Text = query.Sum().ToString("n4")
            lblRedemptionValue.Text = (From u In dtTransaction.AsEnumerable Where u.Field(Of Integer)("TrxType1") = SetRedemption()
                                       Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")
        End If
    End Sub

    Private Sub SummaryDividend()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Where u.Field(Of Integer)("TrxType1") = SetDividend()
                        Select u.Field(Of Decimal)("TrxUnit")
            lblDividendNo.Text = query.Count
            lblDividendUnit.Text = query.Sum().ToString("n4")
            lblDividendValue.Text = (From u In dtTransaction.AsEnumerable
                                     Where u.Field(Of Integer)("TrxType1") = SetDividend()
                                     Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")
        End If

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGTransaction, "ReportIT.xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGTransaction.RowCount > 0 Then
            'Dim frm As New ReportInquiryTransactionEmail
            'frm.Show()
            'frm.frm = Me
            'frm.MdiParent = MDIMIS
        End If
    End Sub


End Class