Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1Chart
Imports simpi.GlobalUtilities
Imports simpi.GlobalUtilities.GlobalDate
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSecurities
Imports simpi.MasterPortfolio.ParameterBank

Public Class MISHoldingTD
    Dim objPortfolio As New MasterPortfolio
    Dim objAccount As New PortfolioBankAccount
    Dim objPosition As New PositionBank
    Dim objNAV As New PortfolioNAV

    Dim dtPosition As New DataTable
    Dim dtAccount As New DataTable
    Dim dtNAV As New DataTable

    Dim assetData() As Integer
    Dim assetLabel() As String
    Dim assetRow As Integer = 0

    Private Sub ReportHoldingTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        GetPortfolioSimpi()
        GetParameterBankTDTerm()
        GetCompliancePortfolioDeposit()
        GetComplianceSimpiDeposit()
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        objPortfolio.UserAccess = objAccess
        objAccount.UserAccess = objAccess
        objPosition.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        DBGTD.FetchRowStyles = True
        DBGBank.FetchRowStyles = True
        DBGAging.FetchRowStyles = True
        dtAs.Value = Now
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
        DBGTD.Columns.Clear()
        DBGBank.Columns.Clear()
        DBGAging.Columns.Clear()
        chartTerm.Reset()
    End Sub

    Private Sub DataLoad()
        objPosition.Clear()
        dtPosition = objPosition.Search(objMasterSimpi, dtAs.Value)
        objAccount.Clear()
        dtAccount = objAccount.SearchAccount(objMasterSimpi)
        objNAV.Clear()
        dtNAV = objNAV.Search(dtAs.Value)
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
        displayTDCcy()
        displayBankCcy()
        displayTermCcy()
        displayAgingCcy()
    End Sub

    Private Sub btnSearchPortfolio_Click(sender As Object, e As EventArgs) Handles btnSearchPortfolio.Click
        PortfolioSearch()
    End Sub

    Private Sub PortfolioSearch()
        Dim form As New SelectMasterPortfolio
        form.lblCode = lblPortfolioCode
        form.lblName = lblPortfolioName
        form.lblSimpiEmail = lblSimpiEmail
        form.lblSimpiName = lblSimpiName
        form.Show()
        form.MdiParent = mdimenu
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
            objPortfolio.Clear()
            objPortfolio.LoadCode(objMasterSimpi, lblPortfolioCode.Text)
            If objPortfolio.ErrID = 0 Then
                displayTDFund()
                displayBankFund()
                displayTermFund()
                displayAgingFund()
            Else
                ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#Region "TD Placement"
    Private Sub displayTDCcy()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
            dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Join p In dtPortfoliosimpi.AsEnumerable On p.Field(Of Integer)("PortfolioID") Equals a.Field(Of Integer)("PortfolioID")
                        Join t In dtParameterBankTDTerm.AsEnumerable On t.Field(Of Integer)("TDTermID") Equals a.Field(Of Integer)("TDTermID")
                        Where a.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Select ID = s.Field(Of Long)("AccountID"),
                               Portfolio = p.Field(Of String)("PortfolioCode"),
                               Bank = a.Field(Of String)("CompanyName"),
                               Term = t.Field(Of String)("TDTermCode"),
                               Maturity = a.Field(Of Date)("DateEnd"),
                               Due = CalculateDays(dtAs.Value, a.Field(Of Date)("DateEnd"), "A"),
                               Rate = a.Field(Of Decimal)("InterestRate") * 100,
                               Qty = s.Field(Of Decimal)("AccountBalance"),
                               Interest = s.Field(Of Decimal)("AccountInterest")
                        Order By Maturity Ascending

            With DBGTD
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Maturity").NumberFormat = "dd-MMM-yyyy"
                .Columns("Rate").NumberFormat = "n5"
                .Columns("Qty").NumberFormat = "n0"
                .Columns("Interest").NumberFormat = "n0"

                For Each column As C1DisplayColumn In DBGTD.Splits(0).DisplayColumns
                    column.AutoSize()
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

            End With

        Else
            DBGTD.Columns.Clear()
        End If
    End Sub

    Private Sub displayTDFund()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
            dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Join p In dtPortfoliosimpi.AsEnumerable On p.Field(Of Integer)("PortfolioID") Equals a.Field(Of Integer)("PortfolioID")
                        Join t In dtParameterBankTDTerm.AsEnumerable On t.Field(Of Integer)("TDTermID") Equals a.Field(Of Integer)("TDTermID")
                        Where p.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Select ID = s.Field(Of Long)("AccountID"),
                               Portfolio = p.Field(Of String)("PortfolioCode"),
                               Bank = a.Field(Of String)("CompanyName"),
                               Term = t.Field(Of String)("TDTermCode"),
                               Maturity = a.Field(Of Date)("DateEnd"),
                               Due = CalculateDays(dtAs.Value, a.Field(Of Date)("DateEnd"), "A"),
                               Rate = a.Field(Of Decimal)("InterestRate") * 100,
                               Qty = s.Field(Of Decimal)("AccountBalance"),
                               Interest = s.Field(Of Decimal)("AccountInterest")
                        Order By Maturity Ascending

            With DBGTD
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Maturity").NumberFormat = "dd-MMM-yyyy"
                .Columns("Rate").NumberFormat = "n5"
                .Columns("Qty").NumberFormat = "n0"
                .Columns("Interest").NumberFormat = "n0"

                For Each column As C1DisplayColumn In DBGTD.Splits(0).DisplayColumns
                    column.AutoSize()
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

            End With

        Else
            DBGTD.Columns.Clear()
        End If
    End Sub

    Private Sub DBGTD_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGTD.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

#End Region

#Region "bank"
    Private Sub displayBankCcy()
        If dtCompliancePortfolioDeposit IsNot Nothing AndAlso dtCompliancePortfolioDeposit.Rows.Count > 0 Then displayBankCcy1() Else displayBankCcy2()
    End Sub

    Private Sub displayBankFund()
        If dtCompliancePortfolioDeposit IsNot Nothing AndAlso dtCompliancePortfolioDeposit.Rows.Count > 0 Then displayBankFund1() Else displayBankFund2()
    End Sub

    Private Sub displayBankCcy1()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim nav As Double = (From n In dtNAV.AsEnumerable Join p In dtPortfoliosimpi.AsEnumerable
                                 On p.Field(Of Integer)("PortfolioID") Equals n.Field(Of Integer)("PortfolioID")
                                 Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                 Select n.Field(Of Decimal)("NAV")).Sum
            txtAUM.Text = nav.ToString("n2")
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {
                            Key .BankID = a.Field(Of Integer)("CompanyID"),
                            Key .Bank = a.Field(Of String)("CompanyName")
                            }
                        Into Group Select New With {
                             .BankID = key.BankID, .Bank = key.Bank,
                             .Amount = Group.Sum(Function(r) r.Field(Of Decimal)("AccountBalance")),
                             .Percent = IIf(nav = 0, 0, .Amount * 100 / nav)
                             }
            Dim query2 = From p In dtComplianceSimpiDeposit.AsEnumerable
                         Where p.Field(Of Integer)("CountryID") = cmbCcy.SelectedValue
                         Select Bank = p.Field(Of Integer)("CompanyID"),
                                MaxAllocation = p.Field(Of Decimal)("MaxAllocation") * 100

            Dim query3 = From c In query
                         Group Join f In query2
                            On c.BankID Equals f.Bank Into cf = Group Let f = cf.FirstOrDefault
                         Select
                                Bank = c.Bank, Amount = c.Amount, Percent = c.Percent,
                                Max = If(f Is Nothing, "", f.MaxAllocation.ToString("n3"))

            With DBGBank
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query3.ToList

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                .Splits(0).DisplayColumns("Bank").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Percent").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Max").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far


                Dim Bank, Amount, Percent, Max As C1DisplayColumn
                Bank = .Splits(0).DisplayColumns("Bank")
                Amount = .Splits(0).DisplayColumns("Amount")
                Percent = .Splits(0).DisplayColumns("Percent")
                Max = .Splits(0).DisplayColumns("Max")

                Bank.Width = 160
                Amount.Width = 105
                Percent.Width = 50
                Max.Width = 50

                For Each column As C1DisplayColumn In .Splits(0).DisplayColumns
                    column.Style.WrapText = True
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                .Columns("Percent").Caption = "%"

            End With

        Else
            DBGBank.Columns.Clear()
        End If
    End Sub

    Private Sub displayBankCcy2()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim nav As Double = (From n In dtNAV.AsEnumerable Join p In dtPortfoliosimpi.AsEnumerable
                                 On p.Field(Of Integer)("PortfolioID") Equals n.Field(Of Integer)("PortfolioID")
                                 Where p.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue
                                 Select n.Field(Of Decimal)("NAV")).Sum
            txtAUM.Text = nav.ToString("n2")
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {Key .Bank = a.Field(Of String)("CompanyName")}
                        Into Group Select New With {
                             .Bank = key.Bank,
                             .Amount = Group.Sum(Function(s) s.Field(Of Decimal)("AccountBalance")),
                             .Percent = IIf(nav = 0, 0, .Amount * 100 / nav)
                             }

            With DBGBank
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                Dim Bank, Amount, Percent As C1DisplayColumn
                Bank = .Splits(0).DisplayColumns("Bank")
                Amount = .Splits(0).DisplayColumns("Amount")
                Percent = .Splits(0).DisplayColumns("Percent")

                Bank.Width = 220
                Amount.Width = 105
                Percent.Width = 50

                For Each column As C1DisplayColumn In DBGBank.Splits(0).DisplayColumns
                    column.Style.WrapText = True
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("Percent").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                Next

                .Columns("Percent").Caption = "%"

            End With

        Else
            DBGBank.Columns.Clear()
        End If
    End Sub

    Private Sub displayBankFund1()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim nav As Double = (From n In dtNAV.AsEnumerable
                                 Where n.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID
                                 Select n.Field(Of Decimal)("NAV")).Sum
            txtAUM.Text = nav.ToString("n2")
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {
                            Key .BankID = a.Field(Of Integer)("CompanyID"),
                            Key .Bank = a.Field(Of String)("CompanyName")
                            }
                        Into Group Select New With {
                             .BankID = key.BankID, .Bank = key.Bank,
                             .Amount = Group.Sum(Function(r) r.Field(Of Decimal)("AccountBalance")),
                             .Percent = IIf(nav = 0, 0, .Amount * 100 / nav)
                             }
            Dim query2 = From p In dtCompliancePortfolioDeposit.AsEnumerable
                         Where p.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID
                         Select Bank = p.Field(Of Integer)("CompanyID"),
                                MaxAllocation = p.Field(Of Decimal)("MaxAllocation") * 100

            Dim query3 = From c In query
                         Group Join f In query2
                            On c.BankID Equals f.Bank Into cf = Group Let f = cf.FirstOrDefault
                         Select
                                Bank = c.Bank, Amount = c.Amount, Percent = c.Percent,
                                Max = If(f Is Nothing, "", f.MaxAllocation.ToString("n3"))

            With DBGBank
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query3.ToList

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                .Splits(0).DisplayColumns("Bank").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Amount").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Percent").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Max").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far


                Dim Bank, Amount, Percent, Max As C1DisplayColumn
                Bank = .Splits(0).DisplayColumns("Bank")
                Amount = .Splits(0).DisplayColumns("Amount")
                Percent = .Splits(0).DisplayColumns("Percent")
                Max = .Splits(0).DisplayColumns("Max")

                Bank.Width = 160
                Amount.Width = 105
                Percent.Width = 50
                Max.Width = 50

                For Each column As C1DisplayColumn In .Splits(0).DisplayColumns
                    column.Style.WrapText = True
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                .Columns("Percent").Caption = "%"

            End With

        Else
            DBGBank.Columns.Clear()
        End If
    End Sub

    Private Sub displayBankFund2()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim nav As Double = (From n In dtNAV.AsEnumerable
                                 Where n.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID
                                 Select n.Field(Of Decimal)("NAV")).Sum
            txtAUM.Text = nav.ToString("n2")
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {Key .Bank = a.Field(Of String)("CompanyName")}
                        Into Group Select New With {
                             .Bank = key.Bank,
                             .Amount = Group.Sum(Function(r) r.Field(Of Decimal)("AccountBalance")),
                             .Percent = IIf(nav = 0, 0, .Amount * 100 / nav)
                             }

            With DBGBank
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                Dim Bank, Amount, Percent As C1DisplayColumn
                Bank = .Splits(0).DisplayColumns("Bank")
                Amount = .Splits(0).DisplayColumns("Amount")
                Percent = .Splits(0).DisplayColumns("Percent")

                Bank.Width = 220
                Amount.Width = 105
                Percent.Width = 50

                For Each column As C1DisplayColumn In DBGBank.Splits(0).DisplayColumns
                    column.Style.WrapText = True
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("Percent").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                Next

                .Columns("Percent").Caption = "%"

            End With

        Else
            DBGBank.Columns.Clear()
        End If
    End Sub

    Private Sub DBGBank_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGBank.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

#End Region

#Region "term"
    Private Sub displayTermCcy()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Join t In dtParameterBankTDTerm.AsEnumerable On t.Field(Of Integer)("TDTermID") Equals a.Field(Of Integer)("TDTermID")
                        Where a.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {Key .Term = t.Field(Of String)("TDTermCode")}
                        Into Group Select New With {
                             .Term = key.Term,
                             .Value = Group.Sum(Function(r) r.Field(Of Decimal)("AccountBalance"))
                             }
            assetData = Nothing
            assetLabel = Nothing
            assetRow = 0
            For Each item In query
                If CDbl(txtAUM.Text) = 0 Then termInit(0, item.Term) Else termInit(CInt(item.Value * 100 / CDbl(txtAUM.Text)), item.Term)
            Next
            termChart()
        Else
            chartTerm.ChartGroups(0).ChartData.SeriesList.Clear()
        End If
    End Sub

    Private Sub displayTermFund()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Join t In dtParameterBankTDTerm.AsEnumerable On t.Field(Of Integer)("TDTermID") Equals a.Field(Of Integer)("TDTermID")
                        Where a.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Group s By key = New With {Key .Term = t.Field(Of String)("TDTermCode")}
                        Into Group Select New With {
                             .Term = key.Term,
                             .Value = Group.Sum(Function(r) r.Field(Of Decimal)("AccountBalance"))
                             }
            assetData = Nothing
            assetLabel = Nothing
            assetRow = 0
            For Each item In query
                If CDbl(txtAUM.Text) = 0 Then termInit(0, item.Term) Else termInit(CInt(item.Value * 100 / CDbl(txtAUM.Text)), item.Term)
            Next
            termChart()
        Else
            chartTerm.ChartGroups(0).ChartData.SeriesList.Clear()
        End If
    End Sub

    Private Sub termInit(ByVal d As Integer, ByVal l As String)
        If d > 0 Then
            ReDim Preserve assetData(assetRow + 1)
            ReDim Preserve assetLabel(assetRow + 1)
            assetData(assetRow) = d
            assetLabel(assetRow) = l
            assetRow += 1
        End If
    End Sub

    Private Sub termChart()
        If assetData IsNot Nothing AndAlso assetData.Length > 0 Then
            chartTerm.Style.Border.BorderStyle = BorderStyleEnum.InsetBevel
            chartTerm.ChartLabels.DefaultLabelStyle.BackColor = SystemColors.Info
            chartTerm.ChartLabels.DefaultLabelStyle.Border.BorderStyle = BorderStyleEnum.Solid

            ' Set up a Pie chart with 8 slices
            Dim grp As ChartGroup = chartTerm.ChartGroups(0)
            grp.ChartType = Chart2DTypeEnum.Pie
            grp.Pie.OtherOffset = 0

            ' Clear existing, and add new data.
            Dim dat As ChartData = grp.ChartData
            dat.SeriesList.Clear()

            ' Pick a nice color for each Series.
            Dim ColorValue() As Color = {Color.Red, Color.Tan, Color.LightGreen, Color.MediumTurquoise,
                                         Color.Blue, Color.Magenta, Color.GreenYellow, Color.MediumBlue}

            Dim slice As Integer
            For slice = 0 To assetData.Length - 1
                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, assetData(slice))
                'series.X[0] = 1f;
                'series.Y[0] = SliceValue[slice];
                series.LineStyle.Color = ColorValue(slice)
                series.Label = assetLabel(slice)

                ' Add a chart label for each slice
                Dim lab As Label = chartTerm.ChartLabels.LabelsCollection.AddNewLabel()
                lab.AttachMethod = AttachMethodEnum.DataIndex

                Dim amd As AttachMethodData = lab.AttachMethodData
                amd.GroupIndex = 0
                amd.PointIndex = 0
                amd.SeriesIndex = slice

                lab.Text = assetData(slice) & "%"
                lab.Compass = LabelCompassEnum.Radial
                lab.Connected = True
                lab.Offset = 10
                lab.Visible = True
                lab.Style.Border.BorderStyle = BorderStyleEnum.None
            Next slice

            chartTerm.Legend.Visible = True
            chartTerm.Legend.Compass = CompassEnum.East
            chartTerm.ChartGroups(0).ShowOutline = True
            chartTerm.ChartArea.PlotArea.View3D.Elevation = 45

        End If
    End Sub

    Private Sub chartTerm_MouseUp(sender As Object, e As MouseEventArgs) Handles chartTerm.MouseUp
        Dim chart As C1Chart = CType(sender, C1Chart)

        If e.Button.Equals(MouseButtons.Left) Then
            Dim g As Integer = -1
            Dim s As Integer = -1
            Dim p As Integer = -1
            Dim d As Integer = -1
            Dim grp As ChartGroup = chart.ChartGroups(0)
            Dim ser As ChartDataSeries = Nothing

            Dim [region] As ChartRegionEnum = chart.ChartRegionFromCoord(e.X, e.Y)
            If [region].Equals(ChartRegionEnum.Legend) Then
                If chart.Legend.SeriesFromCoord(e.X, e.Y, g, s) Then
                    ser = grp.ChartData.SeriesList(s)
                    If ser.Display.Equals(SeriesDisplayEnum.Show) Then
                        ser.Display = SeriesDisplayEnum.Hide
                    Else
                        ser.Display = SeriesDisplayEnum.Show
                    End If
                End If
                Return
            End If

            If grp.CoordToDataIndex(e.X, e.Y, CoordinateFocusEnum.XandYCoord, s, p, d) Then
                If d = 0 AndAlso s >= 0 AndAlso p >= 0 Then
                    ser = grp.ChartData.SeriesList(s)
                    Dim offset As Integer = ser.Offset
                    If offset = 0 Then
                        offset = 40
                    Else
                        offset = 0
                    End If
                    ser.Offset = offset
                End If
            End If 'SetTextBoxSliceOffsetValue(s, offset);
        End If
    End Sub 'c1Chart1_MouseUp

#End Region

#Region "aging"
    Private Sub displayAgingCcy()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso cmbCcy.SelectedIndex <> -1 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("CcyID") = cmbCcy.SelectedValue And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Select Maturity = a.Field(Of Date)("DateEnd"),
                               Qty = s.Field(Of Decimal)("AccountBalance")

            Dim tbl As New DataTable
            Dim twa, twp, nwa, nwp, tma, tmp, nma, nmp, tya, typ As Double

            twa = (From q In query Where q.Maturity <= dtAs.Value.AddDays(7) Select q.Qty).Sum()
            If CDbl(txtAUM.Text) = 0 Then twp = 0 Else twp = twa * 100 / CDbl(txtAUM.Text)

            nwa = (From q In query Where q.Maturity <= dtAs.Value.AddDays(14) Select q.Qty).Sum()
            nwa = nwa - twa
            If CDbl(txtAUM.Text) = 0 Then nwp = 0 Else nwp = nwa * 100 / CDbl(txtAUM.Text)

            tma = (From q In query Where q.Maturity <= dtAs.Value.AddMonths(1) Select q.Qty).Sum()
            tma = tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then tmp = 0 Else tmp = tma * 100 / CDbl(txtAUM.Text)

            nma = (From q In query Where q.Maturity <= dtAs.Value.AddMonths(2) Select q.Qty).Sum()
            nma = nma - tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then nmp = 0 Else nmp = nma * 100 / CDbl(txtAUM.Text)

            tya = (From q In query Select q.Qty).Sum() - nma - tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then typ = 0 Else typ = tya * 100 / CDbl(txtAUM.Text)

            tbl.Columns.AddRange(New DataColumn() {
                New DataColumn("Periode", GetType(String)),
                New DataColumn("Amount", GetType(Decimal)),
                New DataColumn("Percent", GetType(Decimal))})

            tbl.Rows.Add("7 day(s)", twa, twp)
            tbl.Rows.Add("14 day(s)", nwa, nwp)
            tbl.Rows.Add("1 month", tma, tmp)
            tbl.Rows.Add("2 month(s)", nma, nmp)
            tbl.Rows.Add("> 2 month(s)", tya, typ)

            With DBGAging
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = tbl

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                .Columns("Percent").Caption = "%"

                For Each column As C1DisplayColumn In .Splits(0).DisplayColumns
                    column.AutoSize()
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("Periode").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next
            End With

        Else
            DBGAging.Columns.Clear()
        End If
    End Sub

    Private Sub displayAgingFund()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso
           dtAccount IsNot Nothing AndAlso dtAccount.Rows.Count > 0 AndAlso objPortfolio.GetPortfolioID > 0 Then
            Dim query = From s In dtPosition.AsEnumerable
                        Join a In dtAccount.AsEnumerable On s.Field(Of Long)("AccountID") Equals a.Field(Of Long)("AccountID")
                        Where a.Field(Of Integer)("PortfolioID") = objPortfolio.GetPortfolioID And
                              (a.Field(Of Integer)("TDTypeID") = SetBankDeposit() Or a.Field(Of Integer)("TDTypeID") = SetBankOnCall())
                        Select Maturity = a.Field(Of Date)("DateEnd"),
                               Qty = s.Field(Of Decimal)("AccountBalance")

            Dim tbl As New DataTable
            Dim twa, twp, nwa, nwp, tma, tmp, nma, nmp, tya, typ As Double

            twa = (From q In query Where q.Maturity <= dtAs.Value.AddDays(7) Select q.Qty).Sum()
            If CDbl(txtAUM.Text) = 0 Then twp = 0 Else twp = twa * 100 / CDbl(txtAUM.Text)

            nwa = (From q In query Where q.Maturity <= dtAs.Value.AddDays(14) Select q.Qty).Sum()
            nwa = nwa - twa
            If CDbl(txtAUM.Text) = 0 Then nwp = 0 Else nwp = nwa * 100 / CDbl(txtAUM.Text)

            tma = (From q In query Where q.Maturity <= dtAs.Value.AddMonths(1) Select q.Qty).Sum()
            tma = tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then tmp = 0 Else tmp = tma * 100 / CDbl(txtAUM.Text)

            nma = (From q In query Where q.Maturity <= dtAs.Value.AddMonths(2) Select q.Qty).Sum()
            nma = nma - tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then nmp = 0 Else nmp = nma * 100 / CDbl(txtAUM.Text)

            tya = (From q In query Select q.Qty).Sum() - nma - tma - nwa - twa
            If CDbl(txtAUM.Text) = 0 Then typ = 0 Else typ = tya * 100 / CDbl(txtAUM.Text)

            tbl.Columns.AddRange(New DataColumn() {
                New DataColumn("Periode", GetType(String)),
                New DataColumn("Amount", GetType(Decimal)),
                New DataColumn("Percent", GetType(Decimal))})

            tbl.Rows.Add("7 day(s)", twa, twp)
            tbl.Rows.Add("14 day(s)", nwa, nwp)
            tbl.Rows.Add("1 month", tma, tmp)
            tbl.Rows.Add("2 month(s)", nma, nmp)
            tbl.Rows.Add("> 2 month(s)", tya, typ)

            With DBGAging
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = tbl

                .Columns("Amount").NumberFormat = "n0"
                .Columns("Percent").NumberFormat = "n3"

                .Columns("Percent").Caption = "%"

                For Each column As C1DisplayColumn In .Splits(0).DisplayColumns
                    column.AutoSize()
                    .Splits(0).DisplayColumns(column.Name).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("Periode").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next
            End With

        Else
            DBGAging.Columns.Clear()
        End If
    End Sub

    Private Sub DBGAging_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGAging.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

#End Region


End Class