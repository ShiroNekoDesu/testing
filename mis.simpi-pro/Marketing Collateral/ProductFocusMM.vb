Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Chart
Imports simpi.MasterSimpi
Imports simpi.MasterPortfolio
Imports simpi.MasterPortfolio.ParameterPortfolio
Imports simpi.MasterSecurities
Imports simpi.MarketInstrument
Imports simpi.MarketInstrument.ParameterSecurities
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.Analyst

Public Class ProductFocusMM
    Dim objSimpi As New MasterSimpi
    Dim objPortfolio As New MasterPortfolio
    Dim objCodeset As New PortfolioCodeset
    Dim objCodesetSimpi As New simpi.SimpiMaster.SimpiCodeset
    Dim objTerm As New simpi.SimpiMaster.SimpiTerm
    Dim objSector As New ParameterSectorClass
    Dim objNAV As New PortfolioNAV
    Dim objReturn As New PortfolioReturn
    Dim objBenchmark As New simpi.CoreData.PortfolioBenchmark
    Dim objPosition As New PositionSecurities
    Dim objStrategy As New PortfolioStrategy
    Dim objSecurities As New MarketInstrument

    Dim dtSector As New DataTable
    Dim dtNAV As New DataTable
    Dim dtBenchmark As New DataTable
    Dim dtPosition As New DataTable
    Dim dtHolding As New DataTable
    Dim dtReturn As New DataTable
    Dim dtMonthly As New DataTable
    Dim dtStrategy As New DataTable
    Dim tmp As String
    Dim no As Integer

    Private Sub ProductFocusFI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSimpi.UserAccess = objAccess
        objPortfolio.UserAccess = objAccess
        objCodeset.UserAccess = objAccess
        objCodesetSimpi.UserAccess = objAccess
        objTerm.UserAccess = objAccess
        objSector.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        objReturn.UserAccess = objAccess
        objBenchmark.UserAccess = objAccess
        objPosition.UserAccess = objAccess
        objStrategy.UserAccess = objAccess
        objSecurities.UserAccess = objAccess

        dtAs.Value = Now.AddDays(-1)
        GetParameterInstrumentType()
        GetParameterInstrumentSubType()
        GetSimpiTerm()
        GetPortfolioCodeset()
        GetInstrumentUser()

        DBGHolding.FetchRowStyles = True
        fgWeek.DrawMode = DrawModeEnum.OwnerDraw
        fgPerformance.DrawMode = DrawModeEnum.OwnerDraw

        dtHolding.Columns.Add("Sector", GetType(String))
        dtHolding.Columns.Add("Value", GetType(Decimal))

        dtMonthly.Columns.Add("Date", GetType(Date))
        dtMonthly.Columns.Add("Return", GetType(Decimal))
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PortfolioSearch()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        DataLoad()
    End Sub

    Private Sub btnPPT_Click(sender As Object, e As EventArgs) Handles btnPPT.Click

    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click

    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click

    End Sub

    Private Sub btnSettingPDF_Click(sender As Object, e As EventArgs) Handles btnSettingPDF.Click

    End Sub

    Private Sub PortfolioSearch()
        Dim form As New SelectMasterPortfolio
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
        DisplayClear()
        DataClear()
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
                    DisplayPortfolio()
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub rbOption1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbOption1.SelectedIndexChanged
        DisplayOption()
    End Sub

    Private Sub rbOption2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbOption2.SelectedIndexChanged
        DisplayOption()
    End Sub

    Private Sub DisplayOption()

    End Sub

    Private Sub DisplayClear()
        lblCcy.Text = ""
        lblCurrency.Text = ""
        lblInception.Text = ""
        lblFundType.Text = ""
        lblCustodianBank.Text = ""
        lblValuation.Text = ""
        lblISIN.Text = ""
        lblBloomberg.Text = ""
        lblFeeManagement.Text = ""
        lblFeeCustodian.Text = ""
        lblFeeSubscription.Text = ""
        lblFeeRedemption.Text = ""
        lblFeeSwitching.Text = ""
        lblMinimumSubscriptionInitial.Text = ""
        lblMinimumSubscriptionAdditional.Text = ""
        lblMinimumRedemption.Text = ""
        lblMinimumUnitholding.Text = ""
        lblPolicyEQ.Text = ""
        lblPolicyFI.Text = ""
        lblPolicyMM.Text = ""
        lblPolicyNotes.Text = ""
    End Sub

    Private Sub DisplayPortfolio()
        lblCcy.Text = GetSimpiTerm(objPortfolio.GetPortfolioCcy.GetCcy, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        lblCurrency.Text = GetSimpiTerm(objPortfolio.GetPortfolioCcy.GetCcyDescription, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        lblInception.Text = objPortfolio.GetInceptionDate.ToString("dd-MMM-yyyy")

        lblFundType.Text = GetSimpiTerm(objPortfolio.GetAssetType.GetAssetTypeDescription, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        If IsBenchmarkTypeBenchmark(objPortfolio.GetPortfolioBenchmarkType.GetBenchmarkTypeID) Then
            lblBenchmark.Text = objPortfolio.GetPortfolioBenchmarkClass.GetClassCode
        Else
            lblBenchmark.Text = objPortfolio.GetPortfolioBenchmarkPortfolioCode
        End If
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 2)
        lblCustodianBank.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 11)
        lblValuation.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = objPortfolio.ExternalID_Get(2)
        lblISIN.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = objPortfolio.ExternalID_Get(5)
        lblBloomberg.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 12)
        lblFeeManagement.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 13)
        lblFeeCustodian.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 14)
        lblFeeSubscription.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 15)
        lblFeeRedemption.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 16)
        lblFeeSwitching.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 17)
        lblMinimumSubscriptionInitial.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 18)
        lblMinimumSubscriptionAdditional.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 19)
        lblMinimumRedemption.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 20)
        lblMinimumUnitholding.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 7)
        lblPolicyEQ.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 8)
        lblPolicyFI.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 9)
        lblPolicyMM.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 30)
        lblPolicyNotes.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
    End Sub

    Private Sub DataLoad()
        If objPortfolio.GetPortfolioID > 0 Then
            objNAV.Clear()
            objNAV.LoadAt(objPortfolio, dtAs.Value)
            If objNAV.ErrID = 0 Then
                lblNAVUnit.Text = objNAV.GetNAVPerUnit.ToString("n4")
                lblAUM.Text = (objNAV.GetNAV / 1000000000).ToString("n2") & " M"

                objPosition.Clear()
                dtPosition = objPosition.Search(objPortfolio, objNAV.GetPositionDate)

                objReturn.Clear()
                objReturn.LoadAt(objPortfolio, objNAV.GetPositionDate)

                objBenchmark.Clear()
                objBenchmark.LoadAt(objPortfolio, objNAV.GetPositionDate)

                objStrategy.Clear()
                dtStrategy = objStrategy.Search(objPortfolio, objNAV.GetPositionDate)

                dtNAV = objNAV.SearchHistoryLast(objPortfolio, objNAV.GetPositionDate, 0)
                dtBenchmark = objBenchmark.SearchHistoryLast(objPortfolio, objNAV.GetPositionDate, 0)
                dtReturn = objReturn.SearchEOM(objPortfolio, objPortfolio.GetInceptionDate, objNAV.GetPositionDate)


            Else
                DataClear()
                ExceptionMessage.Show(objNAV.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub DataClear()

        chartAllocation.ChartGroups(0).ChartData.SeriesList.Clear()
        chartAsset.ChartGroups(0).ChartData.SeriesList.Clear()
        chartAUM.ChartGroups(0).ChartData.SeriesList.Clear()
        chartDuration.ChartGroups(0).ChartData.SeriesList.Clear()
        chartYTM.ChartGroups(0).ChartData.SeriesList.Clear()
    End Sub

#Region "holding"
    Private Sub txtTopHolding_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTopHolding.KeyDown
        If e.KeyCode = Keys.Enter Then DisplayHolding()
    End Sub

    Private Sub rbNameHolding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbNameHolding.SelectedIndexChanged
        DisplayHolding()
    End Sub

    Private Sub DBGHolding_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGHolding.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Function _no() As Integer
        no += 1
        Return no
    End Function

    Private Sub DisplayHolding()
        If dtPosition IsNot Nothing AndAlso dtPosition.Rows.Count > 0 AndAlso dtInstrumentUser IsNot Nothing AndAlso dtInstrumentUser.Rows.Count > 0 Then
            Dim query = From d In dtPosition.AsEnumerable Order By d.Field(Of Decimal)("TotalValue") Descending
                        Join s In dtInstrumentUser.AsEnumerable On d.Field(Of Long)("SecuritiesID") Equals s.Field(Of Long)("SecuritiesID")
                        Join st In dtParameterInstrumentSubType.AsEnumerable On st.Field(Of Integer)("SubTypeID") Equals s.Field(Of Integer)("SubTypeID")
                        Join t In dtParameterInstrumentType.AsEnumerable On t.Field(Of Integer)("TypeID") Equals st.Field(Of Integer)("TypeID")
                        Select SecuritiesCode = s.Field(Of String)("SecuritiesCode"),
                               SecuritiesName = s.Field(Of String)("SecuritiesNameShort"), SubTypeCode = st.Field(Of String)("SubTypeCode"),
                               TypeID = t.Field(Of Integer)("TypeID"), TypeCode = t.Field(Of String)("TypeCode"),
                               Qty = d.Field(Of Decimal)("Qty"),
                               Price = d.Field(Of Decimal)("MarketPrice"),
                               Cost = d.Field(Of Decimal)("CostPrice"),
                               Value = d.Field(Of Decimal)("TotalValue"),
                               Persen = CDbl(IIf(objNAV.GetNAV = 0, 0D, CDbl(d.Field(Of Decimal)("TotalValue") * 100 / objNAV.GetNAV)))

            lblPortfolioEQ.Text = (From q In query Where q.TypeID = SetEQ() Select q.Persen).Sum.ToString("n2")
            lblPortfolioFI.Text = (From q In query Where q.TypeID = SetFI() Select q.Persen).Sum.ToString("n2")
            lblPortfolioMM.Text = (100 - CDbl(lblPortfolioEQ.Text) - CDbl(lblPortfolioFI.Text)).ToString("n2")

        End If
    End Sub

    Private Sub DisplayHoldingList(ByVal dataHolding As Object)
        With DBGHolding
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()

            .DataSource = dataHolding

            .Columns("Qty").NumberFormat = "n0"
            .Columns("Price").NumberFormat = "n0"
            .Columns("Cost").NumberFormat = "n0"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Persen").NumberFormat = "n2"

            .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Share").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Qty").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Share").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Sector").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Qty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

            .Columns("Persen").Caption = "%"

            .Splits(0).DisplayColumns("No").Width = 25
            .Splits(0).DisplayColumns("Share").Width = 60
            .Splits(0).DisplayColumns("Name").Width = 175
            .Splits(0).DisplayColumns("Sector").Width = 100
            .Splits(0).DisplayColumns("Qty").Width = 75
            .Splits(0).DisplayColumns("Cost").Width = 55
            .Splits(0).DisplayColumns("Price").Width = 55
            .Splits(0).DisplayColumns("Value").Width = 100
            .Splits(0).DisplayColumns("Persen").Width = 35

            Dim font As New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .Splits(0).DisplayColumns("No").Style.Font = font
            .Splits(0).DisplayColumns("Share").Style.Font = font
            .Splits(0).DisplayColumns("Name").Style.Font = font
            .Splits(0).DisplayColumns("Sector").Style.Font = font
            .Splits(0).DisplayColumns("Qty").Style.Font = font
            .Splits(0).DisplayColumns("Cost").Style.Font = font
            .Splits(0).DisplayColumns("Price").Style.Font = font
            .Splits(0).DisplayColumns("Value").Style.Font = font
            .Splits(0).DisplayColumns("Persen").Style.Font = font

        End With
    End Sub

    Private Sub DisplayHoldingAllocation()
        If dtHolding IsNot Nothing AndAlso dtHolding.Rows.Count > 0 Then
            Dim slice, chartSisa, chartItem As Integer
            Dim valueSisa, valueItem As Double
            Dim stringLabel As String = ""
            chartSisa = 100
            valueSisa = 100
            slice = 0
            Dim querySector As IEnumerable

            chartAllocation.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None
            chartAllocation.ChartLabels.DefaultLabelStyle.BackColor = SystemColors.Info
            chartAllocation.ChartLabels.DefaultLabelStyle.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Solid

            Dim grp As ChartGroup = chartAllocation.ChartGroups(0)
            grp.ChartType = Chart2DTypeEnum.Pie
            grp.Pie.OtherOffset = 0
            grp.Pie.InnerRadius = 65

            Dim dat As ChartData = grp.ChartData
            dat.SeriesList.Clear()

            Dim ColorValue() As Color = {Color.OrangeRed, Color.Tan, Color.LightGreen, Color.MediumTurquoise,
                                         Color.DodgerBlue, Color.Magenta, Color.GreenYellow, Color.MediumBlue}

            For Each item In querySector
                'chartItem = _valuePie(item.Value)
                'chartSisa -= chartItem
                'valueItem = _valueLabel(item.Value)
                'valueSisa -= valueItem

                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, chartItem)
                series.LineStyle.Color = ColorValue(slice Mod 8)
                stringLabel = GetSimpiTerm(item.Sector, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
                series.Label = GlobalString.CamelCase(stringLabel) & " " & valueItem.ToString("n2") & "%"
                slice += 1
            Next

            If valueSisa > 0 Then
                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, chartSisa)
                series.LineStyle.Color = ColorValue(slice Mod 8)
                stringLabel = GetSimpiTerm("Others", IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
                series.Label = GlobalString.CamelCase(stringLabel) & " " & valueSisa.ToString("n2") & "%"
            End If

            chartAllocation.Legend.Visible = True
            chartAllocation.Legend.Compass = CompassEnum.East
            chartAllocation.ChartGroups(0).ShowOutline = False
        End If
    End Sub

#End Region

#Region "performance"
    Private Sub chkReplace_CheckedChanged(sender As Object, e As EventArgs) Handles chkReplace.CheckedChanged
        ReplaceBenchmark()
    End Sub

    Private Sub txtBenchmark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBenchmark.KeyDown
        If e.KeyCode = Keys.Enter Then ReplaceBenchmark()
    End Sub


    Private Sub fgPerformance_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgPerformance.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fgWeek_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgWeek.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub performanceClear()
        With fgPerformance
            .Rows.Count = 3
            .Cols.Count = 13
            .ExtendLastCol = False
            fgPerformance(0, 0) = ""
            fgPerformance(0, 1) = "1D"
            fgPerformance(0, 2) = "MTD"
            fgPerformance(0, 3) = "1Mo"
            fgPerformance(0, 4) = "3Mo"
            fgPerformance(0, 5) = "6Mo"
            fgPerformance(0, 6) = "YTD"
            fgPerformance(0, 7) = "1Y"
            fgPerformance(0, 8) = "2Y"
            fgPerformance(0, 9) = "3Y"
            fgPerformance(0, 10) = "5Y"
            fgPerformance(0, 11) = "10Y"
            fgPerformance(0, 12) = "Incp."

            fgPerformance(1, 0) = ""
            fgPerformance(1, 1) = ""
            fgPerformance(1, 2) = ""
            fgPerformance(1, 3) = ""
            fgPerformance(1, 4) = ""
            fgPerformance(1, 5) = ""
            fgPerformance(1, 6) = ""
            fgPerformance(1, 7) = ""
            fgPerformance(1, 8) = ""
            fgPerformance(1, 9) = ""
            fgPerformance(1, 10) = ""
            fgPerformance(1, 11) = ""
            fgPerformance(1, 12) = ""

            fgPerformance(2, 0) = ""
            fgPerformance(2, 1) = ""
            fgPerformance(2, 2) = ""
            fgPerformance(2, 3) = ""
            fgPerformance(2, 4) = ""
            fgPerformance(2, 5) = ""
            fgPerformance(2, 6) = ""
            fgPerformance(2, 7) = ""
            fgPerformance(2, 8) = ""
            fgPerformance(2, 9) = ""
            fgPerformance(2, 10) = ""
            fgPerformance(2, 11) = ""
            fgPerformance(2, 12) = ""

            .AllowResizing = AllowResizingEnum.Columns
            .SelectionMode = SelectionModeEnum.Row
            fgPerformance.Cols(0).Width = 100
            fgPerformance.Cols(1).Width = 50
            fgPerformance.Cols(2).Width = 50
            fgPerformance.Cols(3).Width = 50
            fgPerformance.Cols(4).Width = 50
            fgPerformance.Cols(5).Width = 50
            fgPerformance.Cols(6).Width = 50
            fgPerformance.Cols(7).Width = 50
            fgPerformance.Cols(8).Width = 50
            fgPerformance.Cols(9).Width = 50
            fgPerformance.Cols(10).Width = 50
            fgPerformance.Cols(11).Width = 50
            fgPerformance.Cols(12).Width = 50
        End With

        With fgWeek
            .Rows.Count = 3
            .Cols.Count = 5
            .ExtendLastCol = False
            fgWeek(0, 0) = ""
            fgWeek(0, 1) = "W1"
            fgWeek(0, 2) = "W2"
            fgWeek(0, 3) = "W3"
            fgWeek(0, 4) = "W4"

            fgWeek(1, 0) = ""
            fgWeek(1, 1) = ""
            fgWeek(1, 2) = ""
            fgWeek(1, 3) = ""
            fgWeek(1, 4) = ""

            fgWeek(2, 0) = ""
            fgWeek(2, 1) = ""
            fgWeek(2, 2) = ""
            fgWeek(2, 3) = ""
            fgWeek(2, 4) = ""
            .AllowResizing = AllowResizingEnum.Columns
            .SelectionMode = SelectionModeEnum.Row
            fgWeek.Cols(0).Width = 100
            fgWeek.Cols(1).Width = 50
            fgWeek.Cols(2).Width = 50
            fgWeek.Cols(3).Width = 50
            fgWeek.Cols(4).Width = 50
        End With
    End Sub

    Private Sub DisplayPerformance()
        DisplayPerformanceSummary()
        DisplayPerformanceTable()
        DisplayPerformanceWeek()
    End Sub


    Private Sub DisplayPerformanceSummary()
        lblReturnInception.Text = objReturn.GetrInception.ToString("n2")
        Dim query1 = From q1 In dtMonthly.AsEnumerable Order By q1.Field(Of Decimal)("Return") Descending
                     Select PositionDate = q1.Field(Of Date)("Date"), Monthly = q1.Field(Of Decimal)("Return")
        lblReturnBestReturn.Text = query1.Take(1).Select(Of Decimal)(Function(r) r.Monthly).ToString("n2")
        lblReturnBestMonth.Text = query1.Take(1).Select(Of Date)(Function(r) r.PositionDate).ToString("MMM-yy")


        Dim query2 = From q2 In dtMonthly.AsEnumerable Order By q2.Field(Of Decimal)("Return") Ascending
                     Select PositionDate = q2.Field(Of Date)("Date"), Monthly = q2.Field(Of Decimal)("Return")
        lblReturnWorstReturn.Text = query2.Take(1).Select(Of Decimal)(Function(r) r.Monthly).ToString("n2")
        lblReturnWorstMonth.Text = query2.Take(1).Select(Of Date)(Function(r) r.PositionDate).ToString("MMM-yy")

        Dim query3 = From q3 In dtMonthly.AsEnumerable
                     Where q3.Field(Of Date)("Date") <= dtAs.Value And q3.Field(Of Date)("Date") >= dtAs.Value.AddYears(-1)
                     Order By q3.Field(Of Decimal)("Return") Descending
                     Select PositionDate = q3.Field(Of Date)("Date"), Monthly = q3.Field(Of Decimal)("Return")
        lblReturnBestYear.Text = query3.Take(1).Select(Of Decimal)(Function(r) r.Monthly).ToString("n2")
        lblReturnStdDev.Text = ""
        lblReturnBeta.Text = ""
    End Sub

    Private Sub DisplayPerformanceWeek()
        Dim dtDate() As Date = GlobalDate.MonthWeek(dtAs.Value)
        With fgWeek
            .Rows.Count = 3
            If dtDate.Length > 4 Then .Cols.Count = 6 Else .Cols.Count = 5
            .ExtendLastCol = False
            fgWeek(0, 0) = ""
            fgWeek(0, 1) = dtDate(0).ToString("dd-MMM")
            fgWeek(0, 2) = dtDate(1).ToString("dd-MMM")
            fgWeek(0, 3) = dtDate(2).ToString("dd-MMM")
            fgWeek(0, 4) = dtDate(3).ToString("dd-MMM")
            If dtDate.Length > 4 Then
                fgWeek(0, 5) = dtDate(4).ToString("dd-MMM")
                fgWeek.Cols(0).Width = 100
                fgWeek.Cols(1).Width = 40
                fgWeek.Cols(2).Width = 40
                fgWeek.Cols(3).Width = 40
                fgWeek.Cols(4).Width = 40
                fgWeek.Cols(4).Width = 40
            End If
            fgWeek(1, 0) = lblPortfolioCode.Text.Trim
            fgWeek(2, 0) = GetSimpiTerm(lblBenchmark.Text.Trim, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
            .AutoSizeCols()
        End With

    End Sub

    Private Sub ReplaceBenchmark()
        If chkReplace.Checked Then
            If txtBenchmark.Text.Trim = "" Then txtBenchmark.Text = GetSimpiTerm("Tolok Ukur", IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
            fgWeek(2, 0) = txtBenchmark.Text
            fgPerformance(2, 0) = txtBenchmark.Text
        Else
            fgWeek(2, 0) = GetSimpiTerm(lblBenchmark.Text.Trim, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
            fgPerformance(2, 0) = GetSimpiTerm(lblBenchmark.Text.Trim, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        End If
    End Sub

    Private Sub DisplayPerformanceTable()
        fgPerformance(1, 0) = lblPortfolioCode.Text.Trim
        fgPerformance(1, 1) = (objReturn.Getr1D * 100).ToString("n2")
        fgPerformance(1, 2) = (objReturn.GetrMTD * 100).ToString("n2")
        fgPerformance(1, 3) = (objReturn.Getr1Mo * 100).ToString("n2")
        fgPerformance(1, 4) = (objReturn.Getr3Mo * 100).ToString("n2")
        fgPerformance(1, 5) = (objReturn.Getr6Mo * 100).ToString("n2")
        fgPerformance(1, 6) = (objReturn.GetrYTD * 100).ToString("n2")
        fgPerformance(1, 7) = (objReturn.Getr1Y * 100).ToString("n2")
        fgPerformance(1, 8) = (objReturn.Getr2Y * 100).ToString("n2")
        fgPerformance(1, 9) = (objReturn.Getr3Y * 100).ToString("n2")
        fgPerformance(1, 10) = (objReturn.Getr5Y * 100).ToString("n2")
        fgPerformance(1, 11) = (objReturn.Getr10Y * 100).ToString("n2")
        fgPerformance(1, 12) = (objReturn.GetrInception * 100).ToString("n2")

        fgPerformance(2, 0) = GetSimpiTerm(lblBenchmark.Text.Trim, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        fgPerformance(2, 1) = (objBenchmark.Getr1D * 100).ToString("n2")
        fgPerformance(2, 2) = (objBenchmark.GetrMTD * 100).ToString("n2")
        fgPerformance(2, 3) = (objBenchmark.Getr1Mo * 100).ToString("n2")
        fgPerformance(2, 4) = (objBenchmark.Getr3Mo * 100).ToString("n2")
        fgPerformance(2, 5) = (objBenchmark.Getr6Mo * 100).ToString("n2")
        fgPerformance(2, 6) = (objBenchmark.GetrYTD * 100).ToString("n2")
        fgPerformance(2, 7) = (objBenchmark.Getr1Y * 100).ToString("n2")
        fgPerformance(2, 8) = (objBenchmark.Getr2Y * 100).ToString("n2")
        fgPerformance(2, 9) = (objBenchmark.Getr3Y * 100).ToString("n2")
        fgPerformance(2, 10) = (objBenchmark.Getr5Y * 100).ToString("n2")
        fgPerformance(2, 11) = (objBenchmark.Getr10Y * 100).ToString("n2")
        fgPerformance(2, 12) = (objBenchmark.GetrInception * 100).ToString("n2")
    End Sub


#End Region

#Region "portfolio strategy"
    Private Sub btnStrategyAdd_Click(sender As Object, e As EventArgs) Handles btnStrategyAdd.Click
        strategyAdd()
    End Sub

    Private Sub btnStrategyRemove_Click(sender As Object, e As EventArgs) Handles btnStrategyRemove.Click
        strategyRemove()
    End Sub

    Private Sub btnStrategyClear_Click(sender As Object, e As EventArgs) Handles btnStrategyClear.Click
        strategyClear()
    End Sub

    Private Sub btnStrategyList_Click(sender As Object, e As EventArgs) Handles btnStrategyList.Click
        strategyList()
    End Sub

    Private Sub DisplayStrategy()
        If dtStrategy IsNot Nothing AndAlso dtStrategy.Rows.Count > 0 Then

        End If
    End Sub

    Private Sub strategyClear()
        txtStrategy1.Text = ""
        txtStrategy2.Text = ""
        txtStrategy3.Text = ""
        txtStrategy4.Text = ""
    End Sub

    Private Sub strategyAdd()
        If objPortfolio.GetPortfolioID > 0 Then
            If txtStrategy1.Text.Trim <> "" Then
                objStrategy.Clear()
                objStrategy.Add(objPortfolio, dtAs.Value, txtStrategy1.Text)
                If objStrategy.ErrID <> 0 Then ExceptionMessage.Show(objStrategy.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If txtStrategy2.Text.Trim <> "" Then
                objStrategy.Clear()
                objStrategy.Add(objPortfolio, dtAs.Value, txtStrategy2.Text)
                If objStrategy.ErrID <> 0 Then ExceptionMessage.Show(objStrategy.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If txtStrategy3.Text.Trim <> "" Then
                objStrategy.Clear()
                objStrategy.Add(objPortfolio, dtAs.Value, txtStrategy3.Text)
                If objStrategy.ErrID <> 0 Then ExceptionMessage.Show(objStrategy.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If txtStrategy4.Text.Trim <> "" Then
                objStrategy.Clear()
                objStrategy.Add(objPortfolio, dtAs.Value, txtStrategy4.Text)
                If objStrategy.ErrID <> 0 Then ExceptionMessage.Show(objStrategy.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub strategyRemove()
        If objPortfolio.GetPortfolioID > 0 Then
            objStrategy.Clear()
            objStrategy.Remove(objPortfolio, dtAs.Value)
            If objStrategy.ErrID = 0 Then
                objStrategy.Clear()
                dtStrategy = objStrategy.Search(objPortfolio, objNAV.GetPositionDate)
                DisplayStrategy()
            Else
                ExceptionMessage.Show(objStrategy.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub strategyList()
        If objPortfolio.GetPortfolioID > 0 Then
            Dim form As New ProductFocusPortfolioStrategy
            form.Show()
            form.MdiParent = MDIMIS
        End If
    End Sub

#End Region

#Region "ppt, pdf, email & setting"

#End Region

End Class