Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData

Public Class ReportAccountValuation
    Dim objCapital As New PositionCapital
    Dim objClient As New simpi.MasterClient.MasterClient
    Dim dtFund As New DataTable
    Dim no As Integer = 0
    Dim objPortfolio As New simpi.MasterPortfolio.MasterPortfolio
    Dim PortfolioID As Integer()

    Private Sub ReportAccountValuation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParameterCountry()
        GetPortfolioSimpi()
        PortfolioID = (From p In dtPortfolioSimpi Select p.Field(Of Integer)("PortfolioID")).ToArray
        objCapital.UserAccess = objAccess
        objClient.UserAccess = objAccess
        objPortfolio.UserAccess = objAccess
        DBGFund.FetchRowStyles = True
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
        If objClient.GetClientID > 0 Then
            objCapital.Clear()
            dtFund = objCapital.Search(PortfolioID, objClient, dtAs.Value)
            If objCapital.ErrID = 0 Then
                DisplayFund()
            Else
                ExceptionMessage.Show(objCapital.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ExceptionMessage.Show(objError.Message(81) & " master client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "List of Fund"
    Private Function increment() As Integer
        no += 1
        Return no
    End Function

    Private Sub DisplayFund()
        If dtFund IsNot Nothing And dtFund.Rows.Count > 0 Then
            no = 0
            Dim query = From u In dtFund.AsEnumerable
                        Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                        Join a In dtParameterPortfolioAsset.AsEnumerable
                               On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                        Join s In dtParameterCountry.AsEnumerable
                             On p.Field(Of Integer)("CcyID") Equals s.Field(Of Integer)("CountryID")
                        Select No = increment(),
                               Fund = p.Field(Of String)("PortfolioCode"),
                               Name = p.Field(Of String)("PortfolioNameShort"),
                               AssetType = a.Field(Of String)("AssetTypeCode"),
                               Unit = u.Field(Of Decimal)("UnitBalance"),
                               Ccy = s.Field(Of String)("Ccy"),
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

                .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AssetType").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Ccy").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("TotalCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("UnrlPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

                .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
                .Splits(0).DisplayColumns("AssetType").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Ccy").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("TotalCost").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("UnrlPL").Style.HorizontalAlignment = AlignHorzEnum.Far

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

    Private Sub DBGFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFund.Click
        If DBGFund.RowCount > 0 Then DBGFund.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub
#End Region

#Region "export"
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGFund, "ReportAV.xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGFund.RowCount > 0 Then
            Dim frm As New ReportAccountValuationEmail
            frm.Show()
            frm.frm = Me
            frm.MdiParent = MDIMIS
        End If
    End Sub
#End Region

End Class