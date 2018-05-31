Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterSales
Imports simpi.MasterSecurities
Imports simpi.MasterClient.ParameterClient

Public Class ReportSalesAUM
    Dim objCapital As New PositionCapital
    Dim objSales As New MasterSales
    Dim dtDetail As New DataTable
    Dim PortfolioID As Integer()
    Dim SalesID As Integer()
    Dim value As Double = 0
    Dim no As Integer = 0
    Dim queryClient As IEnumerable
    Dim queryDetail As IEnumerable
    Dim kycSID As IEnumerable
    Dim kycFundAccount As IEnumerable

    Private Sub ReportSalesAUM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPortfolioUser()
        GetClientMaster()
        GetClientKYC()
        kycSID = From sid In dtClientKYC Where sid.Field(Of Integer)("kycID") = 41
                 Select simpiID = sid.Field(Of Integer)("simpiID"), ClientID = sid.Field(Of Integer)("ClientID"), SID = sid.Field(Of String)("kycAnswer")
        kycFundAccount = From fa In dtClientKYC Where fa.Field(Of Integer)("kycID") = 42
                         Select simpiID = fa.Field(Of Integer)("simpiID"), ClientID = fa.Field(Of Integer)("ClientID"), FundAccount = fa.Field(Of String)("kycAnswer")
        GetSalesMaster()
        GetParameterClientType()
        PortfolioID = (From t In dtPortfolioUser.AsEnumerable Select PortfolioID = t.Field(Of Integer)("PortfolioID")).ToArray
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        cmbCcy.Text = "IDR"
        GetParameterPortfolioAssetType()
        objCapital.UserAccess = objAccess
        objSales.UserAccess = objAccess
        DBGFund.FetchRowStyles = True
        DBGClient.FetchRowStyles = True
        DBGSales.FetchRowStyles = True
        DBGDetail.FetchRowStyles = True
        dtAs.Value = Now
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
        SalesID = objSales.SearchAllID("")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataSearch()
    End Sub

    Private Sub DataSearch()
        If objSales.GetSalesID > 0 AndAlso SalesID.Length > 0 Then
            objCapital.Clear()
            dtDetail = objCapital.Detail_SalesSearch(objMasterSimpi, PortfolioID, SalesID, dtAs.Value)
            SummaryClear()
            DBGClient.Columns.Clear()
            If objCapital.ErrID = 0 Then
                DataDisplay()
            Else
                ExceptionMessage.Show(objCapital.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ExceptionMessage.Show(objError.Message(81) & " master portfolio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DataDisplay()
        If dtDetail IsNot Nothing And dtDetail.Rows.Count > 0 And cmbCcy.SelectedIndex <> -1 Then
            If rbSalesDirect.Checked Then
                queryDirect()
            ElseIf rbSalesTeam.Checked Then
                queryTeam()
            ElseIf rbSalesAll.Checked Then
                queryAll()
            End If
        End If
    End Sub

    Private Sub cmbCcy_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCcy.SelectedValueChanged
        DataDisplay()
    End Sub

    Private Sub rbSalesDirect_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesDirect.CheckedChanged
        DataDisplay()
    End Sub

    Private Sub rbSalesAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesAll.CheckedChanged
        DataDisplay()
    End Sub

    Private Sub rbSalesTeam_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesTeam.CheckedChanged
        DataDisplay()
    End Sub

    Private Function SetPersen(ByVal value As Double) As Double
        Dim total As Double = 0
        If IsNumeric(lblTotalValue.Text) Then total = CDbl(lblTotalValue.Text)
        If total = 0 Then Return 0 Else Return value * 100 / total
    End Function

    Private Sub DBGFund_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGFund.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFund.Click
        If DBGFund.RowCount > 0 AndAlso DBGFund.Row > 0 Then DBGFund.MarqueeStyle = MarqueeEnum.HighlightRow Else DBGFund.MarqueeStyle = MarqueeEnum.NoMarquee
    End Sub

    Private Sub DBGClient_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGClient.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGClient.Click
        If DBGClient.RowCount > 0 AndAlso DBGClient.Row > 0 Then DBGClient.MarqueeStyle = MarqueeEnum.HighlightRow Else DBGClient.MarqueeStyle = MarqueeEnum.NoMarquee
    End Sub

    Private Sub DBGDetail_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGDetail.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGDetail.Click
        If DBGDetail.RowCount > 0 AndAlso DBGDetail.Row > 0 Then DBGDetail.MarqueeStyle = MarqueeEnum.HighlightRow Else DBGDetail.MarqueeStyle = MarqueeEnum.NoMarquee
    End Sub

    Private Sub DBGSales_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGSales.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGSales.Click
        If DBGSales.RowCount > 0 AndAlso DBGSales.Row > 0 Then DBGSales.MarqueeStyle = MarqueeEnum.HighlightRow Else DBGSales.MarqueeStyle = MarqueeEnum.NoMarquee
    End Sub

    Private Sub SummaryClear()
        lblLocalNo.Text = "0"
        lblLocalValue.Text = "0"
        lblLocalPersen.Text = "0"

        lblForeignNo.Text = "0"
        lblForeignValue.Text = "0"
        lblForeignPersen.Text = "0"

        lblIndividuNo.Text = "0"
        lblIndividuValue.Text = "0"
        lblIndividuPersen.Text = "0"

        lblIndividuSANo.Text = "0"
        lblIndividuSAValue.Text = "0"
        lblIndividuSAPersen.Text = "0"

        lblInstitutionNo.Text = "0"
        lblInstitutionValue.Text = "0"
        lblInstitutionPersen.Text = "0"

        lblInstitutionSANo.Text = "0"
        lblInstitutionSAValue.Text = "0"
        lblInstitutionSAPersen.Text = "0"

        lblDistributorNo.Text = "0"
        lblDistributorValue.Text = "0"
        lblDistributorPersen.Text = "0"

        lblNomineeNo.Text = "0"
        lblNomineeValue.Text = "0"
        lblNomineePersen.Text = "0"

        lblTotalNo.Text = "0"
        lblTotalValue.Text = "0"
        lblTotalPersen.Text = "0"

        lblEQNo.Text = "0"
        lblEQUnit.Text = "0"
        lblEQValue.Text = "0"
        lblEQPersen.Text = "0"

        lblFINo.Text = "0"
        lblFIUnit.Text = "0"
        lblFIValue.Text = "0"
        lblFIPersen.Text = "0"

        lblMixNo.Text = "0"
        lblMixUnit.Text = "0"
        lblMixValue.Text = "0"
        lblMixPersen.Text = "0"

        lblMMNo.Text = "0"
        lblMMUnit.Text = "0"
        lblMMValue.Text = "0"
        lblMMPersen.Text = "0"

        lblCPFNo.Text = "0"
        lblCPFUnit.Text = "0"
        lblCPFValue.Text = "0"
        lblCPFPersen.Text = "0"
    End Sub

    Private Sub txtKeywordDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeywordDetail.KeyDown
        If e.KeyCode = Keys.Enter And dtDetail IsNot Nothing And dtDetail.Rows.Count > 0 Then
            If txtKeywordDetail.Text.Trim = "" Then DisplayDetailEmpty() Else DisplayDetailKeyword()
        End If
    End Sub

    Private Sub DisplayDetailEmpty()
        Dim query2 = From q In queryDetail
                     Select ID = q.ID, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        DisplayDetailList(query2.ToList)
    End Sub

    Private Sub DisplayDetailKeyword()
        Dim query2 = From q In queryDetail Where q.ClientName.ToString.ToUpper.Contains(txtKeywordDetail.Text.Trim.ToUpper)
                     Select ID = q.ID, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        DisplayDetailList(query2.ToList)
    End Sub

    Private Sub DisplayDetailList(ByVal q As Object)
        With DBGDetail
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = q

            .Columns("Unit").NumberFormat = "n0"
            .Columns("Price").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n4"
            .Columns("AvgPL").NumberFormat = "n4"
            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundName").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundAccount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("ClientName").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SalesCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundCode").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundName").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("SID").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundAccount").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("ClientName").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("SalesCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"
            .Columns("TypeCode").Caption = "Type"

            For Each column As C1DisplayColumn In DBGDetail.Splits(0).DisplayColumns
                If column.Name.Trim = "ClientType" Or column.Name.Trim = "SalesName" Or column.Name.Trim = "FundName" Or
                   column.Name.Trim = "Asset" Or column.Name.Trim = "AssetID" Then
                    column.Visible = False
                ElseIf column.Name.Trim = "ClientName" Then
                    column.Width = 200
                Else
                    column.AutoSize()
                End If
            Next

        End With
    End Sub

    Private Sub queryAll()
        Dim query = From u In dtDetail.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join t In dtParameterClientType.AsEnumerable On c.Field(Of Integer)("TypeID") Equals t.Field(Of Integer)("TypeID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join a In dtParameterPortfolioAsset.AsEnumerable On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                    Group u By key = New With {
                        Key .ID = c.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .ClientName = c.Field(Of String)("ClientName"),
                        Key .SalesCode = s.Field(Of String)("SalesCode"),
                        Key .SalesName = s.Field(Of String)("UserName"),
                        Key .FundCode = p.Field(Of String)("PortfolioCode"),
                        Key .FundName = p.Field(Of String)("PortfolioNameShort"),
                        Key .Asset = a.Field(Of String)("AssetTypeCode"), Key .AssetID = a.Field(Of Integer)("AssetTypeID"),
                        Key .LF = c.Field(Of String)("LF"), Key .ClientType = c.Field(Of Integer)("TypeID"), Key .TypeCode = t.Field(Of String)("TypeCode")
                        }
                    Into Group Order By Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")) Descending
                    Select New With {
                        .ID = key.ID, .CIF = key.CIF, .ClientName = key.ClientName, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .SalesCode = key.SalesCode, .SalesName = key.SalesName,
                        .FundCode = key.FundCode, .FundName = key.FundName, .Asset = key.Asset, .AssetID = key.AssetID,
                        .Unit = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))),
                        .Price = CDbl(Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice"))),
                        .AvgCost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice")) / .Unit),
                        .AvgPL = CDbl(.Price - .AvgCost),
                        .Value = CDbl(.Unit * .Price),
                        .Persen = SetPersen(.Value),
                        .Cost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal"))),
                        .PL = CDbl(.Value - .Cost)
                        }

        queryDetail = From q In query
                      Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                      Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = fas.FirstOrDefault
                      Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount), CIF = q.CIF,
                            ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        Dim query2 = From q In queryDetail
                     Select ID = q.ID, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        DisplayDetailList(query2.ToList)
        DisplayClient()
        DisplayFund()
        DisplaySales()

    End Sub

    Private Sub queryDirect()
        Dim query = From u In dtDetail.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join t In dtParameterClientType.AsEnumerable On c.Field(Of Integer)("TypeID") Equals t.Field(Of Integer)("TypeID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join a In dtParameterPortfolioAsset.AsEnumerable On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                    Group u By key = New With {
                        Key .ID = c.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .ClientName = c.Field(Of String)("ClientName"),
                        Key .SalesCode = s.Field(Of String)("SalesCode"),
                        Key .SalesName = s.Field(Of String)("UserName"),
                        Key .FundCode = p.Field(Of String)("PortfolioCode"),
                        Key .FundName = p.Field(Of String)("PortfolioNameShort"),
                        Key .Asset = a.Field(Of String)("AssetTypeCode"), Key .AssetID = a.Field(Of Integer)("AssetTypeID"),
                        Key .LF = c.Field(Of String)("LF"), Key .ClientType = c.Field(Of Integer)("TypeID"), Key .TypeCode = t.Field(Of String)("TypeCode")
                        }
                    Into Group Order By Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")) Descending
                    Select New With {
                        .ID = key.ID, .CIF = key.CIF, .ClientName = key.ClientName, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .SalesCode = key.SalesCode, .SalesName = key.SalesName,
                        .FundCode = key.FundCode, .FundName = key.FundName, .Asset = key.Asset, .AssetID = key.AssetID,
                        .Unit = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))),
                        .Price = CDbl(Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice"))),
                        .AvgCost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice")) / .Unit),
                        .AvgPL = CDbl(.Price - .AvgCost),
                        .Value = CDbl(.Unit * .Price),
                        .Persen = SetPersen(.Value),
                        .Cost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal"))),
                        .PL = CDbl(.Value - .Cost)
                        }

        queryDetail = From q In query
                      Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                      Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = fas.FirstOrDefault
                      Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount), CIF = q.CIF,
                            ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        Dim query2 = From q In queryDetail
                     Select ID = q.ID, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        DisplayDetailList(query2.ToList)
        DisplayClient()
        DisplayFund()
        DisplaySales()
    End Sub

    Private Sub queryTeam()
        Dim query = From u In dtDetail.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join t In dtParameterClientType.AsEnumerable On c.Field(Of Integer)("TypeID") Equals t.Field(Of Integer)("TypeID")
                    Join p In dtPortfolioUser.AsEnumerable On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join a In dtParameterPortfolioAsset.AsEnumerable On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                          s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                          u.Field(Of Integer)("SalesID") <> objSales.GetSalesID
                    Group u By key = New With {
                        Key .ID = c.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .ClientName = c.Field(Of String)("ClientName"),
                        Key .SalesCode = s.Field(Of String)("SalesCode"),
                        Key .SalesName = s.Field(Of String)("UserName"),
                        Key .FundCode = p.Field(Of String)("PortfolioCode"),
                        Key .FundName = p.Field(Of String)("PortfolioNameShort"),
                        Key .Asset = a.Field(Of String)("AssetTypeCode"), Key .AssetID = a.Field(Of Integer)("AssetTypeID"),
                        Key .LF = c.Field(Of String)("LF"), Key .ClientType = c.Field(Of Integer)("TypeID"), Key .TypeCode = t.Field(Of String)("TypeCode")
                        }
                    Into Group Order By Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")) Descending
                    Select New With {
                        .ID = key.ID, .CIF = key.CIF, .ClientName = key.ClientName, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .SalesCode = key.SalesCode, .SalesName = key.SalesName,
                        .FundCode = key.FundCode, .FundName = key.FundName, .Asset = key.Asset, .AssetID = key.AssetID,
                        .Unit = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))),
                        .Price = CDbl(Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice"))),
                        .AvgCost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice")) / .Unit),
                        .AvgPL = CDbl(.Price - .AvgCost),
                        .Value = CDbl(.Unit * .Price),
                        .Persen = SetPersen(.Value),
                        .Cost = CDbl(Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal"))),
                        .PL = CDbl(.Value - .Cost)
                        }

        queryDetail = From q In query
                      Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                      Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = esc.FirstOrDefault
                      Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount), CIF = q.CIF,
                            ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        Dim query2 = From q In queryDetail
                     Select ID = q.ID, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, ClientName = q.ClientName, LF = q.LF, ClientType = q.ClientType, TypeCode = SetClientType(q.ClientType),
                            SalesCode = q.SalesCode, SalesName = q.SalesName, FundCode = q.FundCode, FundName = q.FundName, Asset = q.Asset, AssetID = q.AssetID,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        DisplayDetailList(query2.ToList)
        DisplayClient()
        DisplayFund()
        DisplaySales()
    End Sub

    Private Function _no() As Integer
        no += 1
        Return no
    End Function

    Private Sub txtKeywordUnitholder_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeywordUnitholder.KeyDown
        If e.KeyCode = Keys.Enter And dtDetail IsNot Nothing And dtDetail.Rows.Count > 0 Then
            If txtKeywordUnitholder.Text.Trim = "" Then DisplayClientEmpty() Else DisplayClientKeyword()
        End If
    End Sub

    Private Sub DisplayClientEmpty()
        no = 0
        Dim query = From d In queryDetail Group d By key = New With {
                        Key .SID = d.SID, Key .FundAccount = d.FundAccount, Key .CIF = d.cif, Key .Name = d.ClientName,
                        Key .Sales = d.SalesCode, Key .LF = d.LF, Key .ClientType = d.clienttype, Key .TypeCode = d.TypeCode
                        }
                    Into Group Order By Group.Sum(Function(r) CDbl(r.Value)) Descending
                    Select New With {.No = _no(), .SID = key.SID, .FundAccount = key.FundAccount, .CIF = key.CIF, .Name = key.Name,
                        .Sales = key.Sales, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .Value = Group.Sum(Function(r) CDbl(r.Value)),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) CDbl(r.Cost)),
                        .PL = Group.Sum(Function(r) CDbl(r.PL))
                        }

        Dim query2 = From q In query
                     Select No = q.No, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, Name = q.Name, Sales = q.Sales, LF = q.LF,
                            TypeCode = SetClientType(q.ClientType), Persen = q.Persen, Value = q.Value, Cost = q.Cost, PL = q.PL

        DisplayClientList(query2.ToList)
    End Sub

    Private Sub DisplayClientKeyword()
        no = 0
        Dim query = From d In queryDetail Group d By key = New With {
                        Key .SID = d.SID, Key .FundAccount = d.FundAccount, Key .CIF = d.cif, Key .Name = d.ClientName,
                        Key .Sales = d.SalesCode, Key .LF = d.LF, Key .ClientType = d.clienttype, Key .TypeCode = d.TypeCode
                        }
                    Into Group Order By Group.Sum(Function(r) CDbl(r.Value)) Descending
                    Select New With {.No = _no(), .SID = key.SID, .FundAccount = key.FundAccount, .CIF = key.CIF, .Name = key.Name,
                        .Sales = key.Sales, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .Value = Group.Sum(Function(r) CDbl(r.Value)),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) CDbl(r.Cost)),
                        .PL = Group.Sum(Function(r) CDbl(r.PL))
                        }

        Dim query2 = From q In query Where q.Name.ToString.ToUpper.Contains(txtKeywordUnitholder.Text.Trim.ToUpper)
                     Select No = q.No, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, Name = q.Name, Sales = q.Sales, LF = q.LF,
                            TypeCode = SetClientType(q.ClientType), Persen = q.Persen, Value = q.Value, Cost = q.Cost, PL = q.PL

        DisplayClientList(query2.ToList)
    End Sub

    Private Sub DisplayClientList(ByVal q As Object)
        With DBGClient
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = q

            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundAccount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundAccount").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"
            .Columns("TypeCode").Caption = "Type"

            For Each column As C1DisplayColumn In DBGClient.Splits(0).DisplayColumns
                If column.Name.Trim = "ClientType" Then
                    column.Visible = False
                ElseIf column.Name.Trim = "Name" Then
                    column.Width = 400
                Else
                    column.AutoSize()
                End If
            Next
        End With
    End Sub

    Private Sub DisplayClient()
        no = 0
        Dim query = From d In queryDetail Group d By key = New With {
                        Key .SID = d.SID, Key .FundAccount = d.FundAccount, Key .CIF = d.cif, Key .Name = d.ClientName,
                        Key .Sales = d.SalesCode, Key .LF = d.LF, Key .ClientType = d.clienttype, Key .TypeCode = d.TypeCode
                        }
                    Into Group Order By Group.Sum(Function(r) CDbl(r.Value)) Descending
                    Select New With {.No = _no(), .SID = key.SID, .FundAccount = key.FundAccount, .CIF = key.CIF, .Name = key.Name,
                        .Sales = key.Sales, .LF = key.LF, .ClientType = key.ClientType, .TypeCode = key.TypeCode,
                        .Value = Group.Sum(Function(r) CDbl(r.Value)),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) CDbl(r.Cost)),
                        .PL = Group.Sum(Function(r) CDbl(r.PL))
                        }

        Dim query2 = From q In query
                     Select No = q.No, SID = q.SID, FundAccount = q.FundAccount, CIF = q.CIF, Name = q.Name, Sales = q.Sales, LF = q.LF,
                            TypeCode = SetClientType(q.ClientType), Persen = q.Persen, Value = q.Value, Cost = q.Cost, PL = q.PL

        DisplayClientList(query.ToList)

        'summary total
        lblTotalNo.Text = query.Count.ToString("n0")
        lblTotalValue.Text = (From q In query Select q.Value).Sum().ToString("n0")
        lblTotalPersen.Text = "100.00"

        'summary local
        Dim local = From q In query Where q.LF = "L" Select q.Value
        lblLocalNo.Text = local.Count.ToString("n0")
        value = local.Sum().ToString("n0")
        lblLocalValue.Text = value.ToString("n0")
        lblLocalPersen.Text = SetPersen(value).ToString("n2")

        'summary foreign
        Dim foreign = From q In query Where q.LF = "F" Select q.Value
        lblForeignNo.Text = foreign.Count.ToString("n0")
        value = foreign.Sum().ToString("n0")
        lblForeignValue.Text = value.ToString("n0")
        lblForeignPersen.Text = SetPersen(value).ToString("n2")

        'summary individu
        Dim individu = From q In query Where q.ClientType = SetIndividu() Select q.Value
        lblIndividuNo.Text = individu.Count.ToString("n0")
        value = individu.Sum().ToString("n0")
        lblIndividuValue.Text = value.ToString("n0")
        lblIndividuPersen.Text = SetPersen(value).ToString("n2")

        'summary individu sub account
        Dim individuSA = From q In query Where q.ClientType = SetIndividuSubAccount() Select q.Value
        lblIndividuSANo.Text = individuSA.Count.ToString("n0")
        value = individuSA.Sum().ToString("n0")
        lblIndividuSAValue.Text = value.ToString("n0")
        lblIndividuSAPersen.Text = SetPersen(value).ToString("n2")

        'summary institusi
        Dim institusi = From q In query Where q.ClientType = SetInstitution() Select q.Value
        lblInstitutionNo.Text = institusi.Count.ToString("n0")
        value = institusi.Sum().ToString("n0")
        lblInstitutionValue.Text = value.ToString("n0")
        lblInstitutionPersen.Text = SetPersen(value).ToString("n2")

        'summary institusi sub account
        Dim institusiSA = From q In query Where q.ClientType = SetInstitutionSubAccount() Select q.Value
        lblInstitutionSANo.Text = institusiSA.Count.ToString("n0")
        value = institusiSA.Sum().ToString("n0")
        lblInstitutionSAValue.Text = value.ToString("n0")
        lblInstitutionSAPersen.Text = SetPersen(value).ToString("n2")

        'summary distributor
        Dim distributor = From q In query Where q.ClientType = SetDistributor() Select q.Value
        lblDistributorNo.Text = distributor.Count.ToString("n0")
        value = distributor.Sum().ToString("n0")
        lblDistributorValue.Text = value.ToString("n0")
        lblDistributorPersen.Text = SetPersen(value).ToString("n2")

        'summary distributor
        Dim nominee = From q In query Where q.ClientType = SetIndividuNominee() Or q.ClientType = SetInstitutionNominee() Select q.Value
        lblNomineeNo.Text = nominee.Count.ToString("n0")
        value = nominee.Sum().ToString("n0")
        lblNomineeValue.Text = value.ToString("n0")
        lblNomineePersen.Text = SetPersen(value).ToString("n2")

    End Sub

    Private Sub DisplayFund()
        no = 0
        Dim query = From d In queryDetail Group d By key = New With {
                       Key .Fund = d.FundCode, Key .Name = d.FundName,
                       Key .Asset = d.Asset, Key .AssetID = d.AssetID
                       }
                   Into Group Order By Group.Sum(Function(r) CDbl(r.Value)) Descending
                    Select New With {
                        .No = _no(), .Fund = key.Fund, .Name = key.Name, .Asset = key.Asset, .AssetID = key.AssetID,
                        .Unit = Group.Sum(Function(r) CDbl(r.Unit)),
                        .Price = Group.Average(Function(r) CDbl(r.Price)),
                        .AvgCost = Group.Sum(Function(r) CDbl(r.AvgCost) * CDbl(r.Unit)) / .Unit,
                        .AvgPL = .Price - .AvgCost,
                        .Value = Group.Sum(Function(r) CDbl(r.Value)),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) CDbl(r.Cost)),
                        .PL = Group.Sum(Function(r) CDbl(r.PL))
                       }

        With DBGFund
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query.ToList

            .Columns("Unit").NumberFormat = "n0"
            .Columns("Price").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n4"
            .Columns("AvgPL").NumberFormat = "n4"
            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Fund").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Asset").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Fund").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Asset").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"

            For Each column As C1DisplayColumn In DBGFund.Splits(0).DisplayColumns
                If column.Name.Trim = "AssetID" Then
                    column.Visible = False
                Else
                    column.AutoSize()
                End If
            Next
        End With

        'summary eq
        Dim eq = From q In query Where q.AssetID = 1 Select unit = q.Unit, value = q.Value
        lblEQNo.Text = eq.Count.ToString("n0")
        lblEQUnit.Text = (From q In eq Select q.unit).Sum().ToString("n0")
        value = (From q In eq Select q.value).Sum().ToString("n0")
        lblEQValue.Text = value.ToString("n0")
        lblEQPersen.Text = SetPersen(value).ToString("n2")

        'summary fi
        Dim fi = From q In query Where q.AssetID = 2 Select unit = q.Unit, value = q.Value
        lblFINo.Text = fi.Count.ToString("n0")
        lblFIUnit.Text = (From q In fi Select q.unit).Sum().ToString("n0")
        value = (From q In fi Select q.value).Sum().ToString("n0")
        lblFIValue.Text = value.ToString("n0")
        lblFIPersen.Text = SetPersen(value).ToString("n2")

        'summary mix
        Dim mix = From q In query Where q.AssetID = 3 Select unit = q.Unit, value = q.Value
        lblMixNo.Text = mix.Count.ToString("n0")
        lblMixUnit.Text = (From q In mix Select q.unit).Sum().ToString("n0")
        value = (From q In mix Select q.value).Sum().ToString("n0")
        lblMixValue.Text = value.ToString("n0")
        lblMixPersen.Text = SetPersen(value).ToString("n2")

        'summary mm
        Dim mm = From q In query Where q.AssetID = 4 Select unit = q.Unit, value = q.Value
        lblMMNo.Text = mm.Count.ToString("n0")
        lblMMUnit.Text = (From q In mm Select q.unit).Sum().ToString("n0")
        value = (From q In mm Select q.value).Sum().ToString("n0")
        lblMMValue.Text = value.ToString("n0")
        lblMMPersen.Text = SetPersen(value).ToString("n2")

        'summary cpf
        Dim cpf = From q In query Where q.AssetID = 5 Select unit = q.Unit, value = q.Value
        lblCPFNo.Text = cpf.Count.ToString("n0")
        lblCPFUnit.Text = (From q In cpf Select q.unit).Sum().ToString("n0")
        value = (From q In cpf Select q.value).Sum().ToString("n0")
        lblCPFValue.Text = value.ToString("n0")
        lblCPFPersen.Text = SetPersen(value).ToString("n2")

    End Sub

    Private Sub DisplaySales()
        no = 0
        Dim query = From d In queryDetail Group d By key = New With {
                        Key .Sales = d.SalesCode, Key .Name = d.SalesName
                        }
                    Into Group Order By Group.Sum(Function(r) CDbl(r.Value)) Descending
                    Select New With {
                        .No = _no(), .Sales = key.Sales, .Name = key.Name,
                        .Value = Group.Sum(Function(r) CDbl(r.Value)),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) CDbl(r.Cost)),
                        .PL = Group.Sum(Function(r) CDbl(r.PL))
                        }

        With DBGSales
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query.ToList

            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"

            For Each column As C1DisplayColumn In DBGSales.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With

    End Sub

    Private Sub btnExcelFund_Click(sender As Object, e As EventArgs) Handles btnExcelFund.Click
        ExportExcelFund(False)
    End Sub

    Public Function ExportExcelFund(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGFund, "ReportSAUMFund" & lblSalesCode.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnExcelUnitholder_Click(sender As Object, e As EventArgs) Handles btnExcelUnitholder.Click
        ExportExcelClient(False)
    End Sub

    Public Function ExportExcelClient(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGClient, "ReportSAUMClient" & lblSalesCode.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnExcelSales_Click(sender As Object, e As EventArgs) Handles btnExcelSales.Click
        ExportExcelSales(False)
    End Sub

    Public Function ExportExcelSales(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGSales, "ReportSAUMSales" & lblSalesCode.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnExcelDetail_Click(sender As Object, e As EventArgs) Handles btnExcelDetail.Click
        ExportExcelDetail(False)
    End Sub

    Public Function ExportExcelDetail(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGDetail, "ReportSAUMDetail" & lblSalesCode.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGFund.RowCount > 0 Then
            'Dim frm As New ReportSalesAUMEmail
            'frm.Show()
            'frm.frm = Me
            'frm.MdiParent = MDIMIS
        End If
    End Sub

End Class