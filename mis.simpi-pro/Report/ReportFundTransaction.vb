Imports C1.Win.C1TrueDBGrid
Imports simpi.globalutilities
Imports simpi.CoreData
Imports simpi.ParameterTA
Imports simpi.ParameterTA.ParameterTA

Public Class ReportFundTransaction
    Dim objPortfolio As New simpi.MasterPortfolio.MasterPortfolio
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi
    Dim objCapital As New TransactionCapital
    Dim objNAV As New PortfolioNAV

    Dim dtTransaction As New DataTable
    Dim saldoUnit As Double = 0

    Private Sub ReportFundTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        GetComboInitAll(New ParameterTransactionTrxType1, cmbType, "TrxTypeID", "TrxTypeCode")
        GetParameterTATrxType1()
        GetClientMaster()
        GetSalesMaster()

        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objNAV.UserAccess = objAccess

        DBGTransaction.FetchRowStyles = True
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
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
        SummaryClear()
        DBGTransaction.Columns.Clear()
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
                If objPortfolio.ErrID <> 0 Then
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataSearch()
    End Sub

    Private Sub DataSearch()
        If objPortfolio.GetPortfolioID > 0 Then
            objNAV.Clear()
            objNAV.LoadBefore(objPortfolio, dtFrom.Value)
            If objNAV.ErrID = 0 Then lblBalance.Text = objNAV.GetTotalUnit.ToString("n4") Else lblBalance.Text = 0.ToString("n4")

            objCapital.Clear()
            dtTransaction = objCapital.Search(objPortfolio, dtFrom.Value, dtTo.Value)
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
        If dtTransaction IsNot Nothing And dtTransaction.Rows.Count > 0 Then
            saldoUnit = CDbl(lblBalance.Text)
            If cmbType.SelectedValue < 1 Then DisplayAll() Else DisplayType()
        End If
    End Sub

    Private Sub DisplayAll()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable
                               On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals s.Field(Of Integer)("TrxTypeID")
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                           NAVDate = u.Field(Of Date)("NAVDate"),
                           Type = s.Field(Of String)("TrxTypeCode"),
                           Description = u.Field(Of String)("TrxDescription"),
                           Name = c.Field(Of String)("ClientName"),
                           Amount = u.Field(Of Decimal)("TrxAmount"),
                       Unit = u.Field(Of Decimal)("TrxUnit"),
                       Gross = u.Field(Of Decimal)("TrxAmount"),
            Net = IIf(u.Field(Of Integer)("TrxType1") = SetSubscription(),
                     (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
                  IIf(u.Field(Of Integer)("TrxType1") = SetRedemption(),
                     ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) * u.Field(Of Decimal)("TrxAmount")),
                  u.Field(Of Decimal)("TrxAmount"))),
        Price = u.Field(Of Decimal)("TrxPrice"),
        Balance = RunningBalance(saldoUnit, u.Field(Of Integer)("TrxType1"), u.Field(Of Decimal)("TrxUnit"))

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
            .Columns("Balance").NumberFormat = "n2"

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Description").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Balance").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Description").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Balance").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Tanggal").Caption = "Date"
            .Columns("NAVDate").Caption = "NAV"

            For Each column As C1DisplayColumn In DBGTransaction.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub DisplayType()
        Dim query = From u In dtTransaction.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable
                           On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtParameterTATrxType1.AsEnumerable
                           On u.Field(Of Integer)("TrxType1") Equals s.Field(Of Integer)("TrxTypeID")
                    Where u.Field(Of Integer)("TrxType1") = cmbType.SelectedValue
                    Select Tanggal = u.Field(Of Date)("TrxDate"),
                        NAVDate = u.Field(Of Date)("NAVDate"),
                       Type = s.Field(Of String)("TrxTypeCode"),
                       Description = u.Field(Of String)("TrxDescription"),
                       Name = c.Field(Of String)("ClientName"),
                       Amount = u.Field(Of Decimal)("TrxAmount"),
                       Unit = u.Field(Of Decimal)("TrxUnit"),
                       Gross = u.Field(Of Decimal)("TrxAmount"),
        Net = IIf(u.Field(Of Integer)("TrxType1") = 1,
                 (u.Field(Of Decimal)("TrxAmount") / (1 + u.Field(Of Decimal)("SellingFeePercentage"))),
              IIf(u.Field(Of Integer)("TrxType1") = 2,
                 ((1 - u.Field(Of Decimal)("RedemptionFeePercentage")) - u.Field(Of Decimal)("TrxAmount")),
                  u.Field(Of Decimal)("TrxAmount"))),
        Price = u.Field(Of Decimal)("TrxPrice"),
        Balance = RunningBalance(saldoUnit, u.Field(Of Integer)("TrxType1"), u.Field(Of Decimal)("TrxUnit"))

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
            .Columns("Balance").NumberFormat = "n2"

            .Splits(0).DisplayColumns("Tanggal").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Description").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Amount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Gross").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Net").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Balance").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("Tanggal").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAVDate").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Type").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Description").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Gross").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Net").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Balance").Style.HorizontalAlignment = AlignHorzEnum.Far

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
            lblSubscriptionValue.Text = (From u In dtTransaction.AsEnumerable
                                         Where u.Field(Of Integer)("TrxType1") = SetSubscription()
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
            lblRedemptionValue.Text = (From u In dtTransaction.AsEnumerable
                                       Where u.Field(Of Integer)("TrxType1") = SetRedemption()
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
        Return PrintExcel(False, DBGTransaction, "ReportFT.xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGTransaction.RowCount > 0 Then
            Dim frm As New ReportFundTransactionEmail
            frm.Show()
            frm.frm = Me
            frm.MdiParent = MDIMIS
        End If
    End Sub


End Class