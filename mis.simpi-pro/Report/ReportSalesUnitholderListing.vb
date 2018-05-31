Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSimpi
Imports simpi.MasterSales
Imports simpi.MasterClient.ParameterClient

Public Class ReportSalesUnitholderListing
    Dim objPortfolio As New MasterPortfolio
    Dim objSimpi As New MasterSimpi
    Dim objCapital As New PositionCapital
    Dim objSales As New MasterSales
    Dim dtClient As New DataTable
    Dim value As Double = 0
    Dim SalesID As Integer()
    Dim kycSID As IEnumerable
    Dim kycFundAccount As IEnumerable

    Private Sub ReportSalesAUM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetClientMaster()
        GetSalesMaster()
        GetParameterClientType()
        GetClientKYC()
        kycSID = From sid In dtClientKYC Where sid.Field(Of Integer)("kycID") = 41
                 Select simpiID = sid.Field(Of Integer)("simpiID"), ClientID = sid.Field(Of Integer)("ClientID"), SID = sid.Field(Of String)("kycAnswer")
        kycFundAccount = From fa In dtClientKYC Where fa.Field(Of Integer)("kycID") = 42
                         Select simpiID = fa.Field(Of Integer)("simpiID"), ClientID = fa.Field(Of Integer)("ClientID"), FundAccount = fa.Field(Of String)("kycAnswer")
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objSales.UserAccess = objAccess
        DBGClient.FetchRowStyles = True
        dtAs.Value = Now
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
                If objPortfolio.ErrID <> 0 Then
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
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
        If objPortfolio.GetPortfolioID > 0 And objSales.GetSalesID > 0 Then
            objCapital.Clear()
            dtClient = objCapital.Detail_SalesSearch(objPortfolio, SalesID, dtAs.Value)
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

    Private Sub rbSalesDirect_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesDirect.CheckedChanged
        DataDisplay()
    End Sub

    Private Sub rbSalesAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesAll.CheckedChanged
        DataDisplay()
    End Sub

    Private Sub rbSalesTeam_CheckedChanged(sender As Object, e As EventArgs) Handles rbSalesTeam.CheckedChanged
        DataDisplay()
    End Sub

    Private Sub DataDisplay()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            If rbSalesDirect.Checked Then
                SummaryTotalDirect()
                DisplayDirect()
                SummaryLocalDirect()
                SummaryForeignDirect()
                SummaryIndividuDirect()
                SummaryIndividuSADirect()
                SummaryInstitutionDirect()
                SummaryInstitutionSADirect()
                SummaryDistributorDirect()
                SummaryNomineeDirect()
            ElseIf rbSalesTeam.Checked Then
                SummaryTotalTeam()
                DisplayTeam()
                SummaryLocalTeam()
                SummaryForeignTeam()
                SummaryIndividuTeam()
                SummaryIndividuSATeam()
                SummaryInstitutionTeam()
                SummaryInstitutionSATeam()
                SummaryDistributorTeam()
                SummaryNomineeTeam()
            ElseIf rbSalesAll.Checked Then
                SummaryTotalAll()
                DisplayAll()
                SummaryLocalAll()
                SummaryForeignAll()
                SummaryIndividuAll()
                SummaryIndividuSAAll()
                SummaryInstitutionAll()
                SummaryInstitutionSAAll()
                SummaryDistributorAll()
                SummaryNomineeAll()
            End If
        End If
    End Sub

#Region "direct"
    Private Sub DisplayDirect()
        Dim query = From u In dtClient.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                    Group u By key = New With {
                        Key .ID = u.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .Name = c.Field(Of String)("ClientName"),
                        Key .Type = c.Field(Of Integer)("TypeID"),
                        Key .Sales = s.Field(Of String)("SalesCode"),
                        Key .LF = c.Field(Of String)("LF")
                        }
                    Into Group Select New With {
                        .ID = key.ID, .CIF = key.CIF, .Name = key.Name, .Sales = key.Sales, .LF = key.LF, .TypeCode = SetClientType(key.Type),
                        .Unit = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit")),
                        .Price = Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice")),
                        .AvgCost = (Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice"))) / .Unit,
                        .AvgPL = .Price - .AvgCost,
                        .Value = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal")),
                        .PL = .Value - .Cost
                        }

        Dim query2 = From q In query
                     Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                     Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = fas.FirstOrDefault
                     Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount),
                            CIF = q.CIF, Name = q.Name, LF = q.LF, TypeCode = q.TypeCode, Sales = q.Sales,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        With DBGClient
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query2.ToList

            .Columns("Unit").NumberFormat = "n4"
            .Columns("Price").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n4"
            .Columns("AvgPL").NumberFormat = "n4"
            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundAccount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundAccount").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgPL").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"
            .Columns("TypeCode").Caption = "Type"

            For Each column As C1DisplayColumn In DBGClient.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub SummaryTotalDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Where u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblTotalNo.Text = query.Count.ToString("n0")
            lblTotalUnit.Text = query.Sum().ToString("n0")
            lblTotalValue.Text = (From u In dtClient.AsEnumerable
                                  Where u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                                  Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                                  Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum().ToString("n0")
            lblTotalPersen.Text = "100.00"
        End If
    End Sub

    Private Sub SummaryLocalDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "L" And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblLocalNo.Text = query.Count.ToString("n0")
            lblLocalUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of String)("LF") = "L" And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblLocalValue.Text = value.ToString("n0")
            lblLocalPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryForeignDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "F" And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblForeignNo.Text = query.Count.ToString("n0")
            lblForeignUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of String)("LF") = "F" And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblForeignValue.Text = value.ToString("n0")
            lblForeignPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 1 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuNo.Text = query.Count.ToString("n0")
            lblIndividuUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 1 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuValue.Text = value.ToString("n0")
            lblIndividuPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuSADirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 3 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuSANo.Text = query.Count.ToString("n0")
            lblIndividuSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 3 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuSAValue.Text = value.ToString("n0")
            lblIndividuSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 2 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionNo.Text = query.Count.ToString("n0")
            lblInstitutionUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 2 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionValue.Text = value.ToString("n0")
            lblInstitutionPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionSADirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 4 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionSANo.Text = query.Count.ToString("n0")
            lblInstitutionSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 4 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionSAValue.Text = value.ToString("n0")
            lblInstitutionSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryDistributorDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 7 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblDistributorNo.Text = query.Count.ToString("n0")
            lblDistributorUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 7 And u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblDistributorValue.Text = value.ToString("n0")
            lblDistributorPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryNomineeDirect()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6) And
                               u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblNomineeNo.Text = query.Count.ToString("n0")
            lblNomineeUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6) And
                            u.Field(Of Integer)("SalesID") = objSales.GetSalesID
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblNomineeValue.Text = value.ToString("n0")
            lblNomineePersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

#End Region

#Region "team"
    Private Sub DisplayTeam()
        Dim query = From u In dtClient.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Where s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                          u.Field(Of Integer)("SalesID") <> objSales.GetSalesID
                    Group u By key = New With {
                        Key .ID = u.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .Name = c.Field(Of String)("ClientName"),
                        Key .Type = c.Field(Of Integer)("TypeID"),
                        Key .Sales = s.Field(Of String)("SalesCode"),
                        Key .LF = c.Field(Of String)("LF")
                        }
                    Into Group Select New With {
                        .ID = key.ID, .CIF = key.CIF, .Name = key.Name, .Sales = key.Sales, .LF = key.LF, .TypeCode = SetClientType(key.Type),
                        .Unit = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit")),
                        .Price = Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice")),
                        .AvgCost = (Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice"))) / .Unit,
                        .AvgPL = .Price - .AvgCost,
                        .Value = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal")),
                        .PL = .Value - .Cost
                        }

        Dim query2 = From q In query
                     Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                     Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = fas.FirstOrDefault
                     Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount),
                            CIF = q.CIF, Name = q.Name, LF = q.LF, TypeCode = q.TypeCode, Sales = q.Sales,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        With DBGClient
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query2.ToList

            .Columns("Unit").NumberFormat = "n4"
            .Columns("Price").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n4"
            .Columns("AvgPL").NumberFormat = "n4"
            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundAccount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundAccount").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgPL").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"
            .Columns("TypeCode").Caption = "%"

            For Each column As C1DisplayColumn In DBGClient.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub SummaryTotalTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                              u.Field(Of Integer)("SalesID") <> objSales.GetSalesID
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblTotalNo.Text = query.Count.ToString("n0")
            lblTotalUnit.Text = query.Sum().ToString("n0")
            lblTotalValue.Text = (From u In dtClient.AsEnumerable
                                  Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                                  Where s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper) And
                                        u.Field(Of Integer)("SalesID") <> objSales.GetSalesID
                                  Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                                  Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum().ToString("n0")
            lblTotalPersen.Text = "100.00"
        End If
    End Sub

    Private Sub SummaryLocalTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of String)("LF") = "L" And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblLocalNo.Text = query.Count.ToString("n0")
            lblLocalUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of String)("LF") = "L" And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblLocalValue.Text = value.ToString("n0")
            lblLocalPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryForeignTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of String)("LF") = "F" And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblForeignNo.Text = query.Count.ToString("n0")
            lblForeignUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of String)("LF") = "F" And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblForeignValue.Text = value.ToString("n0")
            lblForeignPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of Integer)("TypeID") = 1 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuNo.Text = query.Count.ToString("n0")
            lblIndividuUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of Integer)("TypeID") = 1 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuValue.Text = value.ToString("n0")
            lblIndividuPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuSATeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of Integer)("TypeID") = 3 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuSANo.Text = query.Count.ToString("n0")
            lblIndividuSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of Integer)("TypeID") = 3 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuSAValue.Text = value.ToString("n0")
            lblIndividuSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of Integer)("TypeID") = 2 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionNo.Text = query.Count.ToString("n0")
            lblInstitutionUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of Integer)("TypeID") = 2 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionValue.Text = value.ToString("n0")
            lblInstitutionPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionSATeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of Integer)("TypeID") = 4 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionSANo.Text = query.Count.ToString("n0")
            lblInstitutionSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of Integer)("TypeID") = 4 And c.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionSAValue.Text = value.ToString("n0")
            lblInstitutionSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryDistributorTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where c.Field(Of Integer)("TypeID") = 7 And c.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                              s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblDistributorNo.Text = query.Count.ToString("n0")
            lblDistributorUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where c.Field(Of Integer)("TypeID") = 7 And u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                           s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblDistributorValue.Text = value.ToString("n0")
            lblDistributorPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryNomineeTeam()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6) And
                               u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                               s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblNomineeNo.Text = query.Count.ToString("n0")
            lblNomineeUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                     Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6) And
                            u.Field(Of Integer)("SalesID") <> objSales.GetSalesID And
                            s.Field(Of String)("TreePrefix").ToUpper.StartsWith(objSales.GetTreePrefix.ToUpper)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblNomineeValue.Text = value.ToString("n0")
            lblNomineePersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

#End Region

#Region "all"
    Private Sub DisplayAll()
        Dim query = From u In dtClient.AsEnumerable
                    Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                    Join s In dtSalesMaster.AsEnumerable On u.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                    Group u By key = New With {
                        Key .ID = u.Field(Of Integer)("ClientID"),
                        Key .CIF = c.Field(Of String)("ClientCode"),
                        Key .Name = c.Field(Of String)("ClientName"),
                        Key .Type = c.Field(Of Integer)("TypeID"),
                        Key .Sales = s.Field(Of String)("SalesCode"),
                        Key .LF = c.Field(Of String)("LF")
                        }
                    Into Group Select New With {
                        .ID = key.ID, .CIF = key.CIF, .Name = key.Name, .Sales = key.Sales, .LF = key.LF, .TypeCode = SetClientType(key.Type),
                        .Unit = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit")),
                        .Price = Group.Average(Function(r) r.Field(Of Decimal)("UnitPrice")),
                        .AvgCost = (Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("AcqPrice"))) / .Unit,
                        .AvgPL = .Price - .AvgCost,
                        .Value = Group.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice")),
                        .Persen = SetPersen(.Value),
                        .Cost = Group.Sum(Function(r) r.Field(Of Decimal)("AcqTotal")),
                        .PL = .Value - .Cost
                        }

        Dim query2 = From q In query
                     Group Join sid In kycSID On sid.ClientID Equals q.ID Into esc = Group Let sid = esc.FirstOrDefault
                     Group Join fa In kycFundAccount On fa.ClientID Equals q.ID Into fas = Group Let fa = fas.FirstOrDefault
                     Select ID = q.ID, SID = If(sid Is Nothing, "", sid.SID), FundAccount = If(fa Is Nothing, "", fa.FundAccount),
                            CIF = q.CIF, Name = q.Name, LF = q.LF, TypeCode = q.TypeCode, Sales = q.Sales,
                            Unit = q.Unit, Price = q.Price, AvgCost = CDbl(q.AvgCost), AvgPL = CDbl(q.AvgPL), Value = q.Value, Persen = q.Persen, Cost = q.Cost, PL = q.PL

        With DBGClient
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query2.ToList

            .Columns("Unit").NumberFormat = "n4"
            .Columns("Price").NumberFormat = "n4"
            .Columns("AvgCost").NumberFormat = "n4"
            .Columns("AvgPL").NumberFormat = "n4"
            .Columns("Persen").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("PL").NumberFormat = "n0"

            .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("FundAccount").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgCost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AvgPL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

            .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("SID").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("FundAccount").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgCost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("AvgPL").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = AlignHorzEnum.Far
            .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"
            .Columns("TypeCode").Caption = "Type"

            For Each column As C1DisplayColumn In DBGClient.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With
    End Sub

    Private Sub SummaryTotalAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblTotalNo.Text = query.Count.ToString("n0")
            lblTotalUnit.Text = query.Sum().ToString("n0")
            lblTotalValue.Text = (From u In dtClient.AsEnumerable
                                  Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                                  Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum().ToString("n0")
            lblTotalPersen.Text = "100.00"
        End If
    End Sub

    Private Sub SummaryLocalAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "L"
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblLocalNo.Text = query.Count.ToString("n0")
            lblLocalUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of String)("LF") = "L"
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblLocalValue.Text = value.ToString("n0")
            lblLocalPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryForeignAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "F"
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblForeignNo.Text = query.Count.ToString("n0")
            lblForeignUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of String)("LF") = "F"
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblForeignValue.Text = value.ToString("n0")
            lblForeignPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 1
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuNo.Text = query.Count.ToString("n0")
            lblIndividuUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 1
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuValue.Text = value.ToString("n0")
            lblIndividuPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryIndividuSAAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 3
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblIndividuSANo.Text = query.Count.ToString("n0")
            lblIndividuSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 3
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblIndividuSAValue.Text = value.ToString("n0")
            lblIndividuSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 2
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionNo.Text = query.Count.ToString("n0")
            lblInstitutionUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 2
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionValue.Text = value.ToString("n0")
            lblInstitutionPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryInstitutionSAAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 4
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblInstitutionSANo.Text = query.Count.ToString("n0")
            lblInstitutionSAUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 4
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblInstitutionSAValue.Text = value.ToString("n0")
            lblInstitutionSAPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryDistributorAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of Integer)("TypeID") = 7
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblDistributorNo.Text = query.Count.ToString("n0")
            lblDistributorUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where c.Field(Of Integer)("TypeID") = 7
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblDistributorValue.Text = value.ToString("n0")
            lblDistributorPersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

    Private Sub SummaryNomineeAll()
        If dtClient IsNot Nothing And dtClient.Rows.Count > 0 Then
            Dim query = From u In dtClient.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6)
                        Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                        Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit"))
            lblNomineeNo.Text = query.Count.ToString("n0")
            lblNomineeUnit.Text = query.Sum().ToString("n0")
            value = (From u In dtClient.AsEnumerable
                     Join c In dtClientMaster.AsEnumerable On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                     Where (c.Field(Of Integer)("TypeID") = 5 Or c.Field(Of Integer)("TypeID") = 6)
                     Group u By key = u.Field(Of Integer)("ClientID") Into uSum = Group
                     Select value = uSum.Sum(Function(r) r.Field(Of Decimal)("AcqUnit") * r.Field(Of Decimal)("UnitPrice"))).Sum()
            lblNomineeValue.Text = value.ToString("n0")
            lblNomineePersen.Text = SetPersen(value).ToString("n2")
        End If
    End Sub

#End Region

    Private Function SetPersen(ByVal value As Double) As Double
        Dim total As Double = 0
        If IsNumeric(lblTotalValue.Text) Then
            total = CDbl(lblTotalValue.Text)
        End If
        If total = 0 Then
            Return 0
        Else
            Return value * 100 / total
        End If
    End Function

    Private Sub DBGClient_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGClient.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGClient.Click
        If DBGClient.RowCount > 0 Then DBGClient.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

    Private Sub SummaryClear()
        lblLocalNo.Text = "0"
        lblLocalUnit.Text = "0"
        lblLocalValue.Text = "0"
        lblLocalPersen.Text = "0"

        lblForeignNo.Text = "0"
        lblForeignUnit.Text = "0"
        lblForeignValue.Text = "0"
        lblForeignPersen.Text = "0"

        lblIndividuNo.Text = "0"
        lblIndividuUnit.Text = "0"
        lblIndividuValue.Text = "0"
        lblIndividuPersen.Text = "0"

        lblIndividuSANo.Text = "0"
        lblIndividuSAUnit.Text = "0"
        lblIndividuSAValue.Text = "0"
        lblIndividuSAPersen.Text = "0"

        lblInstitutionNo.Text = "0"
        lblInstitutionUnit.Text = "0"
        lblInstitutionValue.Text = "0"
        lblInstitutionPersen.Text = "0"

        lblInstitutionSANo.Text = "0"
        lblInstitutionSAUnit.Text = "0"
        lblInstitutionSAValue.Text = "0"
        lblInstitutionSAPersen.Text = "0"

        lblDistributorNo.Text = "0"
        lblDistributorUnit.Text = "0"
        lblDistributorValue.Text = "0"
        lblDistributorPersen.Text = "0"

        lblNomineeNo.Text = "0"
        lblNomineeUnit.Text = "0"
        lblNomineeValue.Text = "0"
        lblNomineePersen.Text = "0"

        lblTotalNo.Text = "0"
        lblTotalUnit.Text = "0"
        lblTotalValue.Text = "0"
        lblTotalPersen.Text = "0"
    End Sub


    Private Sub btnExcelDetail_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGClient, "ReportSUH" & lblSalesCode.Text.Trim & dtAs.Value.ToString("yyyymmdd") & ".xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGClient.RowCount > 0 Then
            'Dim frm As New ReportSalesUnitholderListingEmail
            'frm.Show()
            'frm.frm = Me
            'frm.MdiParent = MDIMIS
        End If
    End Sub

End Class