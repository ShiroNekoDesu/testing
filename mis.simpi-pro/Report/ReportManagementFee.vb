Imports C1.Win.C1TrueDBGrid
Imports simpi.ParameterFA
Imports simpi.GlobalUtilities
Imports simpi.CoreBilling

Public Class ReportManagementFee
    Dim objAccrual As New FundAccrual
    Dim objPortfolio As New simpi.MasterPortfolio.MasterPortfolio
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi
    Dim objSetting As New FundSetting
    Dim dtAll As New DataTable
    Dim dtMonthly As New DataTable
    Dim PortfolioID As Integer = 0
    Dim firstDate, lastDate As Date

    Private Sub ReportManagementFee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetMasterSimpi()
        GetComboInit(New ParameterCharges, cmbFeeAll, "FeeID", "FeeCode")
        GetComboInit(New ParameterCharges, cmbFeeMonthly, "FeeID", "FeeCode")
        GetParameterCountry()
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objAccrual.UserAccess = objAccess
        objSetting.UserAccess = objAccess
        DBGFundAll.FetchRowStyles = True
        DBGDailyAll.FetchRowStyles = True
        DBGMonthly.FetchRowStyles = True
        DBGAccrual.FetchRowStyles = True
        dtYear.Value = Now
        dtFrom.Value = Now.AddMonths(-1)
        dtTo.Value = Now
    End Sub

#Region "all fund"
    Private Sub btnSearchAll_Click(sender As Object, e As EventArgs) Handles btnSearchAll.Click
        AllSearch()
    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            AllSearch()
        End If
    End Sub

    Public Sub AllSearch()
        If cmbFeeAll.SelectedIndex <> -1 Then
            objAccrual.Clear()
            dtAll = objAccrual.Search_Daily(objMasterSimpi, cmbFeeAll.SelectedValue, dtFrom.Value, dtTo.Value, txtKeyword.Text)
            If dtAll IsNot Nothing AndAlso dtAll.Rows.Count > 0 Then
                Dim query = From a In dtAll.AsEnumerable
                            Join c In dtParameterCountry On a.Field(Of Integer)("PortfolioCcyID") Equals
                                                   c.Field(Of Integer)("CountryID")
                            Group a By key = New With {
                                 Key .ID = a.Field(Of Integer)("PortfolioID"),
                                 Key .Code = a.Field(Of String)("PortfolioCode"),
                                 Key .Name = a.Field(Of String)("PortfolioNameshort"),
                                 Key .Ccy = c.Field(Of String)("Ccy")
                                 }
                            Into Group Select New With {
                                .ID = key.ID, .Code = key.Code, .Name = key.Name, .Ccy = key.Ccy,
                                .Accrual = Group.Sum(Function(r) r.Field(Of Decimal)("AccrualDaily"))
                                 }

                With DBGFundAll
                    .AllowAddNew = False
                    .AllowDelete = False
                    .AllowUpdate = False
                    .Style.WrapText = False
                    .Columns.Clear()
                    .DataSource = query.ToList

                    .Columns("Accrual").NumberFormat = "n2"

                    For Each column As C1DisplayColumn In DBGFundAll.Splits(0).DisplayColumns
                        column.AutoSize()
                    Next

                    .DataView = DataViewEnum.GroupBy
                    .Columns("Ccy").GroupInfo.Interval = GroupIntervalEnum.Custom

                    .Columns("Ccy").GroupInfo.Position = GroupPositionEnum.HeaderAndFooter
                    .Splits(0).DisplayColumns("Accrual").GroupFooterStyle.BackColor = Color.Black
                    .Splits(0).DisplayColumns("Accrual").GroupFooterStyle.ForeColor = Color.White

                    .GroupedColumns.Add(.Columns("Ccy"))
                    .Columns("Accrual").Aggregate = AggregateEnum.Sum
                    .Columns("Ccy").GroupInfo.ColumnVisible = True

                End With
            Else
                DBGFundAll.Columns.Clear()
            End If
            AllClear()
        End If
    End Sub

    Private Sub DBGFundAll_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGFundAll.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGFundAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFundAll.Click
        With DBGFundAll
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGFundAll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFundAll.DoubleClick
        AllProfile()
    End Sub

    Private Sub AllProfile()
        With DBGFundAll
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                PortfolioID = .Columns("ID").Text
                lblPortfolioCodeAll.Text = .Columns("Code").Text
                lblPortfolioNameAll.Text = .Columns("Name").Text
                lblAccrualValueAll.Text = .Columns("Accrual").Text
                DailySearch()
                objPortfolio.Clear()
                objPortfolio.LoadCode(objMasterSimpi, lblPortfolioCodeAll.Text)
                If objPortfolio.ErrID = 0 Then
                    objSetting.Clear()
                    objSetting.Load(objPortfolio, cmbFeeAll.SelectedValue)
                    If objSetting.ErrID = 0 Then
                        lblVATRateAll.Text = objSetting.GetVATRate.ToString("n0") & "%"
                        lblVATAll.Text = (objSetting.GetVATRate / 100 * CDbl(lblAccrualValueAll.Text)).ToString("n2")
                        lblTotalAll.Text = (CDbl(lblAccrualValueAll.Text) + CDbl(lblVATAll.Text)).ToString("n2")
                        lblIncomeTaxRateAll.Text = objSetting.GetIncomeTaxRate.ToString("n0") & "%"
                        lblIncomeTaxAll.Text = (objSetting.GetIncomeTaxRate / 100 * CDbl(lblAccrualValueAll.Text)).ToString("n2")
                        lblNetAll.Text = (CDbl(lblTotalAll.Text) - CDbl(lblIncomeTaxAll.Text)).ToString("n2")
                    Else
                        ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End With
    End Sub

    Private Sub AllClear()
        lblPortfolioCodeAll.Text = ""
        lblPortfolioNameAll.Text = ""
        lblAccrualValueAll.Text = ""
        lblVATRateAll.Text = ""
        lblVATAll.Text = ""
        lblTotalAll.Text = ""
        lblIncomeTaxRateAll.Text = ""
        lblIncomeTaxAll.Text = ""
        lblNetAll.Text = ""
        PortfolioID = 0
    End Sub

    Private Sub DailySearch()
        If dtAll IsNot Nothing AndAlso dtAll.Rows.Count > 0 Then
            Dim query = From a In dtAll.AsEnumerable Where a.Field(Of Integer)("PortfolioID") = PortfolioID
                        Select AccrualDate = a.Field(Of Date)("AccrualDate"),
                               DateDaily = a.Field(Of Date)("DateDaily"),
                               AUM = a.Field(Of Decimal)("AUMValue"),
                               AccrualDaily = a.Field(Of Decimal)("AccrualDaily")
            With DBGDailyAll
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("DateDaily").NumberFormat = "dd-MMM-yyyy"
                .Columns("AccrualDate").NumberFormat = "dd-MMM-yyyy"
                .Columns("AUM").NumberFormat = "n2"
                .Columns("AccrualDaily").NumberFormat = "n2"

                For Each column As C1DisplayColumn In DBGDailyAll.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

                .Columns("AccrualDate").Caption = "Accrued"
                .Columns("DateDaily").Caption = "Date"
                .Columns("AccrualDaily").Caption = "Accrual"

                .DataView = DataViewEnum.GroupBy
                .Columns("AccrualDate").GroupInfo.Interval = GroupIntervalEnum.Custom
                .Columns("AccrualDate").NumberFormat = "dd-MMM-yyyy"

                .Columns("AccrualDate").GroupInfo.Position = GroupPositionEnum.HeaderAndFooter
                .Splits(0).DisplayColumns("AccrualDaily").GroupFooterStyle.BackColor = Color.Black
                .Splits(0).DisplayColumns("AccrualDaily").GroupFooterStyle.ForeColor = Color.White

                .GroupedColumns.Add(.Columns("AccrualDate"))
                .Columns("AccrualDaily").Aggregate = AggregateEnum.Sum
                .Columns("AccrualDate").GroupInfo.ColumnVisible = True

            End With
        Else
            DBGDailyAll.Columns.Clear()
        End If
    End Sub

    Dim sumDaily As Double = 0
    Private Sub DBGDailyAll_GroupAggregate(sender As Object, e As GroupTextEventArgs) Handles DBGDailyAll.GroupAggregate
        Dim s As String = e.GroupText
        sumDaily = sumDaily + Convert.ToInt32(s)
        e.Text = sumDaily.ToString()
    End Sub

    Private Sub DBGDailyAll_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGDailyAll.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGDailyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGDailyAll.Click
        With DBGDailyAll
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

#End Region

#Region "monthly fee"
    Private Sub btnSearchPortfolio_Click(sender As Object, e As EventArgs) Handles btnSearchPortfolio.Click
        PortfolioSearch()
    End Sub

    Private Sub PortfolioSearch()
        Dim form As New SelectMasterPortfolioNormal
        form.lblCode = lblPortfolioCodeMonthly
        form.lblName = lblPortfolioNameMonthly
        form.lblSimpiEmail = lblSimpiEmailMonthly
        form.lblSimpiName = lblSimpiNameMonthly
        form.Show()
        form.MdiParent = MDIMIS
        lblPortfolioCodeMonthly.Text = ""
        lblPortfolioNameMonthly.Text = ""
        lblSimpiEmailMonthly.Text = ""
        lblSimpiNameMonthly.Text = ""
        objPortfolio.Clear()
    End Sub

    Private Sub lblSimpiEmailMonthly_TextChanged(sender As Object, e As EventArgs) Handles lblSimpiEmailMonthly.TextChanged
        PortfolioLoad()
    End Sub

    Private Sub PortfolioLoad()
        If lblPortfolioCodeMonthly.Text.Trim <> "" Then
            objSimpi.Clear()
            objSimpi.Load(lblSimpiEmailMonthly.Text)
            If objSimpi.ErrID = 0 Then
                objPortfolio.Clear()
                objPortfolio.LoadCode(objSimpi, lblPortfolioCodeMonthly.Text)
                If objPortfolio.ErrID <> 0 Then
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnSearchMonthly_Click(sender As Object, e As EventArgs) Handles btnSearchMonthly.Click
        MonthlySearch()
    End Sub

    Private Sub MonthlySearch()
        If cmbFeeMonthly.SelectedIndex <> -1 And objPortfolio.GetPortfolioID > 0 Then
            firstDate = New Date(dtYear.Value.Year, 1, 1)
            lastDate = New Date(dtYear.Value.Year, 12, 31)
            objAccrual.Clear()

            dtMonthly = objAccrual.Search_Daily(objPortfolio, cmbFeeMonthly.SelectedValue, firstDate, lastDate)
            If dtMonthly IsNot Nothing AndAlso dtMonthly.Rows.Count > 0 Then
                Dim query = From a In dtMonthly.AsEnumerable Group a By key = New With {
                                 Key .AccrualDate = a.Field(Of Date)("DateDaily").ToString("MMM-yyyy")
                                 }
                            Into Group Select New With {
                                .AccrualDate = key.AccrualDate,
                                .AccrualValue = Group.Sum(Function(r) r.Field(Of Decimal)("AccrualDaily"))
                                 }

                With DBGMonthly
                    .AllowAddNew = False
                    .AllowDelete = False
                    .AllowUpdate = False
                    .Style.WrapText = False
                    .Columns.Clear()
                    .DataSource = query.ToList

                    .Columns("AccrualValue").NumberFormat = "n2"

                    For Each column As C1DisplayColumn In DBGMonthly.Splits(0).DisplayColumns
                        column.AutoSize()
                    Next

                    .Columns("AccrualDate").Caption = "Month"
                    .Columns("AccrualValue").Caption = "Accrual"

                End With
            Else
                DBGMonthly.Columns.Clear()
            End If
            MonthClear()
        End If
    End Sub

    Private Sub DBGMonthly_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGMonthly.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGMonthly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGMonthly.Click
        With DBGMonthly
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGMonthly_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGMonthly.DoubleClick
        MonthProfile()
    End Sub

    Private Sub MonthProfile()
        With DBGMonthly
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                lastDate = CDate(.Columns("AccrualDate").Text)
                firstDate = New Date(lastDate.Year, lastDate.Month, 1)
                lblDateFrom.Text = firstDate.ToString("dd-MMM-yyyy")
                lastDate = lastDate.AddMonths(1)
                lastDate = New Date(lastDate.Year, lastDate.Month, 1)
                lastDate = lastDate.AddDays(-1)
                lblDateTo.Text = lastDate.ToString("dd-MMM-yyyy")

                lblAccrualMonthly.Text = .Columns("AccrualValue").Text
                AccrualSearch()
                If objPortfolio.ErrID = 0 Then
                    objSetting.Clear()
                    objSetting.Load(objPortfolio, cmbFeeMonthly.SelectedValue)
                    If objSetting.ErrID = 0 Then
                        lblVATRateMonthly.Text = objSetting.GetVATRate.ToString("n0") & "%"
                        lblVATMonthly.Text = (objSetting.GetVATRate / 100 * CDbl(lblAccrualMonthly.Text)).ToString("n2")
                        lblTotalMonthly.Text = (CDbl(lblAccrualMonthly.Text) + CDbl(lblVATMonthly.Text)).ToString("n2")
                        lblIncomeTaxRateMonthly.Text = objSetting.GetIncomeTaxRate.ToString("n0") & "%"
                        lblIncomeTaxMonthly.Text = (objSetting.GetIncomeTaxRate / 100 * CDbl(lblAccrualMonthly.Text)).ToString("n2")
                        lblNetMonthly.Text = (CDbl(lblTotalMonthly.Text) - CDbl(lblIncomeTaxMonthly.Text)).ToString("n2")
                    Else
                        ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End With
    End Sub

    Private Sub MonthClear()
        lblDateFrom.Text = ""
        lblDateTo.Text = ""
        lblAccrualMonthly.Text = ""
        lblVATRateMonthly.Text = ""
        lblVATMonthly.Text = ""
        lblTotalMonthly.Text = ""
        lblIncomeTaxRateMonthly.Text = ""
        lblIncomeTaxMonthly.Text = ""
        lblNetMonthly.Text = ""
    End Sub

    Private Sub AccrualSearch()
        If dtMonthly IsNot Nothing AndAlso dtMonthly.Rows.Count > 0 Then
            Dim query = From a In dtMonthly.AsEnumerable
                        Where a.Field(Of Date)("DateDaily") >= firstDate And
                              a.Field(Of Date)("DateDaily") <= lastDate
                        Select AccrualDate = a.Field(Of Date)("AccrualDate"),
                               DateDaily = a.Field(Of Date)("DateDaily"),
                               AUM = a.Field(Of Decimal)("AUMValue"),
                               AccrualDaily = a.Field(Of Decimal)("AccrualDaily")
            With DBGAccrual
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("DateDaily").NumberFormat = "dd-MMM-yyyy"
                .Columns("AccrualDate").NumberFormat = "dd-MMM-yyyy"
                .Columns("AUM").NumberFormat = "n2"
                .Columns("AccrualDaily").NumberFormat = "n2"

                For Each column As C1DisplayColumn In DBGAccrual.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

                .Columns("AccrualDate").Caption = "Accrued"
                .Columns("DateDaily").Caption = "Date"
                .Columns("AccrualDaily").Caption = "Accrual"

                .DataView = DataViewEnum.GroupBy
                .Columns("AccrualDate").GroupInfo.Interval = GroupIntervalEnum.Custom
                .Columns("AccrualDate").NumberFormat = "dd-MMM-yyyy"

                .Columns("AccrualDate").GroupInfo.Position = GroupPositionEnum.HeaderAndFooter
                .Splits(0).DisplayColumns("AccrualDaily").GroupFooterStyle.BackColor = Color.Black
                .Splits(0).DisplayColumns("AccrualDaily").GroupFooterStyle.ForeColor = Color.White

                .GroupedColumns.Add(.Columns("AccrualDate"))
                .Columns("AccrualDaily").Aggregate = AggregateEnum.Sum
                .Columns("AccrualDate").GroupInfo.ColumnVisible = True
            End With
        Else
            DBGAccrual.Columns.Clear()
        End If
    End Sub

    Private Sub DBGAccrual_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGAccrual.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGAccrual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGAccrual.Click
        With DBGAccrual
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub



#End Region

End Class