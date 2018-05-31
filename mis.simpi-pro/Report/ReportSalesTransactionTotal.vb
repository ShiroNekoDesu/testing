Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.ParameterTA
Imports simpi.MasterSecurities

Public Class ReportSalesTransactionTotal
    Dim objCapital As New TransactionCapital
    Dim objSales As New simpi.MasterSales.MasterSales
    Dim dtTransaction As New DataTable
    Dim PortfolioID As Integer()

    Private Sub ReportSalesTransactionTotal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetComboInitAll(New ParameterTransactionTrxType1, cmbType, "TrxTypeID", "TrxTypeCode")
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        cmbCcy.Text = "IDR"
        GetSalesMaster()
        GetClientMaster()
        GetPortfolioUser()
        PortfolioID = (From t In dtPortfolioUser.AsEnumerable Select PortfolioID = t.Field(Of Integer)("PortfolioID")).ToArray
        GetParameterTATrxType1()
        objSimpi.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objSales.UserAccess = objAccess
        DBGTransaction.FetchRowStyles = True
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
    End Sub

    Private Sub btnSearchSales_Click(sender As Object, e As EventArgs) Handles btnSearchSales.Click
        SalesScreen()
    End Sub

    Private Sub SalesScreen()
        Dim form As New SelectMasterSales
        form.lblSalesCode = lblSalesCode
        form.lblSalesName = lblSalesName
        form.Show()
        If IsMdiChild Then form.MdiParent = MDIMIS
        lblSalesCode.Text = ""
        lblSalesName.Text = ""
        objSales.Clear()
    End Sub

    Private Sub lblSalesCode_TextChanged(sender As Object, e As EventArgs) Handles lblSalesCode.TextChanged
        SalesLoad()
    End Sub

    Private Sub SalesLoad()
        objSales.Clear()
        objSales.Load(objMasterSimpi, lblSalesCode.Text)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataSearch()
    End Sub

    Private Sub DataSearch()
        If objSales.GetSalesID > 0 Then
            objCapital.Clear()
            dtTransaction = objCapital.SearchPortfolio(PortfolioID, dtFrom.Value, dtTo.Value)
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

    Private Sub cmbCcy_Click(sender As Object, e As EventArgs) Handles cmbCcy.Click
        DataSearch()
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        DisplayTransaction()
    End Sub


    Private Sub rbSalesDirect_Click(sender As Object, e As EventArgs) Handles rbSalesDirect.Click
        DisplayTransaction()
    End Sub

    Private Sub rbSalesTeam_Click(sender As Object, e As EventArgs) Handles rbSalesTeam.Click
        DisplayTransaction()
    End Sub

    Private Sub rbSalesAll_Click(sender As Object, e As EventArgs) Handles rbSalesAll.Click
        DisplayTransaction()
    End Sub

    Private Sub DisplayTransaction()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            If cmbType.SelectedValue < 1 Then
                If rbSalesDirect.Checked Then
                    DisplayAllDirect()
                ElseIf rbSalesTeam.Checked Then
                    DisplayAllTeam()
                ElseIf rbSalesAll.Checked Then
                    DisplayAllAll()
                End If
            Else
                If rbSalesDirect.Checked Then
                    DisplayTypeDirect()
                ElseIf rbSalesTeam.Checked Then
                    DisplayTypeTeam()
                ElseIf rbSalesAll.Checked Then
                    DisplayTypeAll()
                End If
            End If
        End If
    End Sub

    Private Sub displayData(q As Object)
        With DBGTransaction
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = q

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
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = AlignHorzEnum.Near
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

    Private Sub DisplayAllDirect()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where u.Field(Of Integer)("SalesID") = objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = objSales.GetSalesCode,
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DisplayAllTeam()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                          u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = s.Field(Of String)("SalesCode"),
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DisplayAllAll()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = s.Field(Of String)("SalesCode"),
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DisplayTypeDirect()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue And u.Field(Of Integer)("SalesID") = objSales.GetSalesID And
                          p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = objSales.GetSalesCode,
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) - u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DisplayTypeTeam()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue And
                          s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                          s.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = s.Field(Of String)("SalesCode"),
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) - u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DisplayTypeAll()
        Dim query = From u In dtTransaction.AsEnumerable Join t In dtParameterTATrxType1.AsEnumerable
                    On u.Field(Of Integer)("TrxType1") Equals t.Field(Of Integer)("TrxTypeID")
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue And
                          s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                          p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = t.Field(Of String)("TrxTypeCode"),
                           Sales = s.Field(Of String)("SalesCode"),
                           Name = c.Field(Of String)("ClientName"),
                           Fund = p.Field(Of String)("PortfolioCode"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                           Unit = u.Field(Of Decimal)("TrxUnit"),
                           Gross = u.Field(Of Decimal)("TrxAmount"),
                           Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                                    (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                                 IIf(u.Field(Of Integer)("TrxType1") = 2,
                                    ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) - u.Field(Of Decimal)("TrxAmount")),
                                 u.Field(Of Decimal)("TrxAmount"))),
                           Price = u.Field(Of Decimal)("TrxPrice")

        displayData(query.ToList)

    End Sub

    Private Sub DBGTransaction_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGTransaction.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGTransaction.Click
        If DBGTransaction.RowCount > 0 Then DBGTransaction.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

    Private Sub SummaryClear()
        lblSubsNoSD.Text = "0"
        lblSubsValueSD.Text = "0"

        lblSubsNoST.Text = "0"
        lblSubsValueST.Text = "0"

        lblSubsNoSA.Text = "0"
        lblSubsValueSA.Text = "0"

        lblRedsNoSD.Text = "0"
        lblRedsValueSD.Text = "0"

        lblRedsNoST.Text = "0"
        lblRedsValueST.Text = "0"

        lblRedsNoSA.Text = "0"
        lblRedsValueSA.Text = "0"

        lblDivNoSD.Text = "0"
        lblDivValueSD.Text = "0"

        lblDivNoST.Text = "0"
        lblDivValueST.Text = "0"

        lblDivNoSA.Text = "0"
        lblDivValueSA.Text = "0"
    End Sub

    Private Sub SummarySubscription()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where u.Field(Of Integer)("TrxType1") = 1 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID And
                              p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select u.Field(Of Decimal)("TrxUnit")
            lblSubsNoSD.Text = query.Count
            lblSubsValueSD.Text = (From u In dtTransaction.AsEnumerable
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Where u.Field(Of Integer)("TrxType1") = 1 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID And
                                         p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query2 = From u In dtTransaction.AsEnumerable
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Where u.Field(Of Integer)("TrxType1") = 1 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblSubsNoST.Text = query2.Count
            lblSubsValueST.Text = (From u In dtTransaction.AsEnumerable
                                   Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Where u.Field(Of Integer)("TrxType1") = 1 And
                                         s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                         u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query3 = From u In dtTransaction.AsEnumerable
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Where u.Field(Of Integer)("TrxType1") = 1 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblSubsNoSA.Text = query3.Count
            lblSubsValueSA.Text = (From u In dtTransaction.AsEnumerable
                                   Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Where u.Field(Of Integer)("TrxType1") = 1 And
                                         s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                         p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

        End If
    End Sub

    Private Sub SummaryRedemption()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where u.Field(Of Integer)("TrxType1") = 2 And
                              u.Field(Of Integer)("SalesID") = objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                        Select u.Field(Of Decimal)("TrxUnit")
            lblRedsNoSD.Text = query.Count
            lblRedsValueSD.Text = (From u In dtTransaction.AsEnumerable
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Where u.Field(Of Integer)("TrxType1") = 2 And
                                         u.Field(Of Integer)("SalesID") = objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query2 = From u In dtTransaction.AsEnumerable
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Where u.Field(Of Integer)("TrxType1") = 2 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblRedsNoST.Text = query2.Count
            lblRedsValueST.Text = (From u In dtTransaction.AsEnumerable
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                   Where u.Field(Of Integer)("TrxType1") = 2 And
                                         s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                         u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query3 = From u In dtTransaction.AsEnumerable
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Where u.Field(Of Integer)("TrxType1") = 2 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblRedsNoSA.Text = query3.Count
            lblRedsValueSA.Text = (From u In dtTransaction.AsEnumerable
                                   Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                   Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                   Where u.Field(Of Integer)("TrxType1") = 2 And
                                         s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                         p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                   Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

        End If
    End Sub

    Private Sub SummaryDividend()
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            Dim query = From u In dtTransaction.AsEnumerable
                        Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Where u.Field(Of Integer)("TrxType1") = 3 And
                              u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Select u.Field(Of Decimal)("TrxUnit")
            lblDivNoSD.Text = query.Count
            lblDivValueSD.Text = (From u In dtTransaction.AsEnumerable
                                  Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                  Where u.Field(Of Integer)("TrxType1") = 3 And
                                        u.Field(Of Integer)("SalesID") = objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                  Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query2 = From u In dtTransaction.AsEnumerable
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Where u.Field(Of Integer)("TrxType1") = 3 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblDivNoST.Text = query2.Count
            lblDivValueST.Text = (From u In dtTransaction.AsEnumerable
                                  Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                  Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                  Where u.Field(Of Integer)("TrxType1") = 3 And
                                        s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                        u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                  Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

            Dim query3 = From u In dtTransaction.AsEnumerable
                         Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                         Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                         Where u.Field(Of Integer)("TrxType1") = 3 And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                               p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                         Select u.Field(Of Decimal)("TrxUnit")
            lblDivNoSA.Text = query3.Count
            lblDivValueSA.Text = (From u In dtTransaction.AsEnumerable
                                  Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                                  Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                  Where u.Field(Of Integer)("TrxType1") = 3 And
                                        s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                        p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                  Select u.Field(Of Decimal)("TrxAmount")).Sum().ToString("n0")

        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGTransaction, "ReportSTT.xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        'If DBGTransaction.RowCount > 0 Then
        '    Dim frm As New ReportSalesTransactionTotalEmail
        '    frm.Show()
        '    frm.frm = Me
        '    frm.MdiParent = MDIMIS
        'End If
    End Sub

End Class