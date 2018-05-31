Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterPortfolio.ParameterPortfolio
Imports simpi.MasterSimpi
Imports simpi.GlobalUtilities
Imports simpi.GlobalUtilities.GlobalDate
Imports C1.Win.C1TrueDBGrid

Public Class MISCalculatorReturn
    Dim objPortfolio As New MasterPortfolio
    Dim objSimpi As New MasterSimpi
    Dim objReturn As New PortfolioReturn
    Dim objMTM As New PortfolioMTM
    Dim objNAVFrom As New PortfolioNAV
    Dim objNAVTo As New PortfolioNAV
    Dim ToGeometricIndex As Double = 0
    Dim dtNAV As New DataTable

    Private Sub MISCalculatorReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objReturn.UserAccess = objAccess
        objMTM.UserAccess = objAccess
        objNAVFrom.UserAccess = objAccess
        objNAVTo.UserAccess = objAccess
        dtAs.Value = Now
        dtCustom.Value = Now.AddDays(-30)
        DBGHistorical.FetchRowStyles = True
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
        form.MdiParent = MDIMIS
        lblPortfolioCode.Text = ""
        lblPortfolioName.Text = ""
        lblSimpiEmail.Text = ""
        lblSimpiName.Text = ""
        lblReturnCalculation.Text = ""
        lblReturnDays.Text = ""
        objPortfolio.Clear()
        ClearReturnAt()
        ClearReturnMonthly()
        ClearNAVTo()
        ClearNAVFrom()
        ToGeometricIndex = 0
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
                    lblReturnCalculation.Text = objPortfolio.GetPortfolioReturn.GetReturnCode
                    lblReturnDays.Text = objPortfolio.GetPortfolioDays.GetDaysCode
                    objNAVTo.Clear()
                    dtNAV = objNAVTo.SearchHistory(objPortfolio, objPortfolio.GetInceptionDate, New Date(dtAs.Value.Year, 12, 31))
                Else
                    ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataNAVTo()
        DataReturnAt()
        DataReturnMonthly()
    End Sub

    Private Sub DataNAVTo()
        If objPortfolio.GetPortfolioID > 0 Then
            objNAVTo.Clear()
            objNAVTo.LoadAt(objPortfolio, dtAs.Value)
            ClearNAVTo()
            If objNAVTo.ErrID = 0 Then
                lblToDate.Text = objNAVTo.GetPositionDate.ToString("dd-MMM-yyyy")
                dtCustom.Value = objNAVTo.GetPositionDate.AddDays(-30)
                If IsReturnUnitPricing(objPortfolio.GetPortfolioReturn.GetReturnID) Then
                    lblToValue.Text = objNAVTo.GetNAVPerUnit.ToString("n5")
                    lblToAdjustment.Text = objNAVTo.GetAdjustmentNAVPerUnit.ToString("n5")
                Else
                    lblToValue.Text = objNAVTo.GetNAV.ToString("n2")
                    lblToAdjustment.Text = objNAVTo.GetAdjustmentNAV.ToString("n2")
                End If
                lblToIndex.Text = objNAVTo.GetGeometricIndex.ToString("n9")
                ToGeometricIndex = objNAVTo.GetGeometricIndex
            Else
                ExceptionMessage.Show(objNAVTo.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub GetReturnAdjustment()
        If dtNAV IsNot Nothing AndAlso dtNAV.Rows.Count > 0 Then
            If IsReturnUnitPricing(objPortfolio.GetPortfolioReturn.GetReturnID) Then
                lblToAdjustment.Text = (From n In dtNAV.AsEnumerable
                                        Where n.Field(Of Date)("PositionDate") >= CDate(lblFromDate.Text) And
                                              n.Field(Of Date)("PositionDate") <= CDate(lblToDate.Text)
                                        Select n.Field(Of Decimal)("AdjustmentNAVPerUnit")).Sum.ToString("n5")
            Else
                lblToAdjustment.Text = (From n In dtNAV.AsEnumerable
                                        Where n.Field(Of Date)("PositionDate") >= CDate(lblFromDate.Text) And
                                              n.Field(Of Date)("PositionDate") <= CDate(lblToDate.Text)
                                        Select n.Field(Of Decimal)("AdjustmentNAV")).Sum.ToString("n2")
            End If
        End If
    End Sub

    Private Sub SetReturnRelative()
        Dim t, a, f As Double
        Double.TryParse(lblToValue.Text, t)
        Double.TryParse(lblToAdjustment.Text, a)
        Double.TryParse(lblFromValue.Text, f)
        If f > 0 Then lblFromRelative.Text = ((((t + a) / f) - 1) * 100).ToString("n2") & " %" Else lblFromRelative.Text = 0.ToString("n2") & " %"
    End Sub

    Private Sub ClearNAVTo()
        lblToDate.Text = ""
        lblToValue.Text = ""
        lblToAdjustment.Text = ""
        lblToIndex.Text = ""
    End Sub

    Private Sub DataNAVFrom(ByVal FromDate As Date)
        If objPortfolio.GetPortfolioID > 0 Then
            objNAVFrom.Clear()
            objNAVFrom.LoadLast(objPortfolio, FromDate)
            ClearNAVFrom()
            If objNAVFrom.ErrID = 0 Then
                lblFromDate.Text = objNAVFrom.GetPositionDate.ToString("dd-MMM-yyyy")
                If IsReturnUnitPricing(objPortfolio.GetPortfolioReturn.GetReturnID) Then
                    lblFromValue.Text = objNAVFrom.GetNAVPerUnit.ToString("n5")
                Else
                    lblFromValue.Text = objNAVFrom.GetNAV.ToString("n2")
                End If
                lblFromIndex.Text = objNAVFrom.GetGeometricIndex.ToString("n9")
                GetReturnAdjustment()
                SetReturnRelative()

                If objNAVFrom.GetGeometricIndex > 0 Then lblFromReturn.Text = (((ToGeometricIndex / objNAVFrom.GetGeometricIndex) - 1) * 100).ToString("n2") & " %"
            Else
                ExceptionMessage.Show(objNAVFrom.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ClearNAVFrom()
        lblFromDate.Text = ""
        lblFromValue.Text = ""
        lblFromIndex.Text = ""
        lblFromRelative.Text = ""
        lblFromReturn.Text = ""
    End Sub

    Private Sub DataNAVMonthly(ByVal ToDate As Date)
        If objPortfolio.GetPortfolioID > 0 Then
            objNAVTo.Clear()
            objNAVTo.LoadAt(objPortfolio, ToDate)
            ClearNAVTo()
            If objNAVTo.ErrID = 0 Then
                lblToDate.Text = objNAVTo.GetPositionDate.ToString("dd-MMM-yyyy")
                If IsReturnUnitPricing(objPortfolio.GetPortfolioReturn.GetReturnID) Then
                    lblToValue.Text = objNAVTo.GetNAVPerUnit.ToString("n5")
                    lblToAdjustment.Text = objNAVTo.GetAdjustmentNAVPerUnit.ToString("n5")
                Else
                    lblToValue.Text = objNAVTo.GetNAV.ToString("n2")
                    lblToAdjustment.Text = objNAVTo.GetAdjustmentNAV.ToString("n2")
                End If
                lblToIndex.Text = objNAVTo.GetGeometricIndex.ToString("n9")
                ToGeometricIndex = objNAVTo.GetGeometricIndex
            Else
                ExceptionMessage.Show(objNAVTo.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub DataReturnMonthly()
        If objPortfolio.GetPortfolioID > 0 Then
            ClearReturnMonthly()
            objMTM.Clear()
            objMTM.LoadAt(objPortfolio, dtAs.Value)
            objReturn.Clear()
            objReturn.LoadLast(objPortfolio, New Date(dtAs.Value.Year, 12, 31))
            If objReturn.ErrID = 0 Then
                If objReturn.GetPositionDate.Year = dtAs.Value.Year Then
                    lblYear.Text = objReturn.GetPositionDate.Year

                    If objReturn.GetPositionDate.Month > 1 Or
                        (objReturn.GetPositionDate.Month = 1 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM1.Text = objReturn.GetDateM1.ToString("dd-MMM-yy")
                        txtReturnM1.Text = (objReturn.GetrM1 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 2 Or
                        (objReturn.GetPositionDate.Month = 2 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM2.Text = objReturn.GetDateM2.ToString("dd-MMM-yy")
                        txtReturnM2.Text = (objReturn.GetrM2 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 3 Or
                        (objReturn.GetPositionDate.Month = 3 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM3.Text = objReturn.GetDateM3.ToString("dd-MMM-yy")
                        txtDateQ1.Text = objReturn.GetDateQ1.ToString("dd-MMM-yy")
                        txtReturnM3.Text = (objReturn.GetrM3 * 100).ToString("n2")
                        txtReturnQ1.Text = (objReturn.GetrQ1 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 4 Or
                        (objReturn.GetPositionDate.Month = 4 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM4.Text = objReturn.GetDateM4.ToString("dd-MMM-yy")
                        txtReturnM4.Text = (objReturn.GetrM4 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 5 Or
                        (objReturn.GetPositionDate.Month = 5 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM5.Text = objReturn.GetDateM5.ToString("dd-MMM-yy")
                        txtReturnM5.Text = (objReturn.GetrM5 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 6 Or
                        (objReturn.GetPositionDate.Month = 6 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM6.Text = objReturn.GetDateM6.ToString("dd-MMM-yy")
                        txtDateQ2.Text = objReturn.GetDateQ2.ToString("dd-MMM-yy")
                        txtReturnM6.Text = (objReturn.GetrM6 * 100).ToString("n2")
                        txtReturnQ2.Text = (objReturn.GetrQ2 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 7 Or
                        (objReturn.GetPositionDate.Month = 7 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM7.Text = objReturn.GetDateM7.ToString("dd-MMM-yy")
                        txtReturnM7.Text = (objReturn.GetrM7 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 8 Or
                        (objReturn.GetPositionDate.Month = 8 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM8.Text = objReturn.GetDateM8.ToString("dd-MMM-yy")
                        txtReturnM8.Text = (objReturn.GetrM8 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 9 Or
                        (objReturn.GetPositionDate.Month = 9 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM9.Text = objReturn.GetDateM9.ToString("dd-MMM-yy")
                        txtDateQ3.Text = objReturn.GetDateQ3.ToString("dd-MMM-yy")
                        txtReturnM9.Text = (objReturn.GetrM9 * 100).ToString("n2")
                        txtReturnQ3.Text = (objReturn.GetrQ3 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 10 Or
                        (objReturn.GetPositionDate.Month = 10 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM10.Text = objReturn.GetDateM10.ToString("dd-MMM-yy")
                        txtReturnM10.Text = (objReturn.GetrM10 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month > 11 Or
                        (objReturn.GetPositionDate.Month = 11 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month) Then
                        txtDateM11.Text = objReturn.GetDateM11.ToString("dd-MMM-yy")
                        txtReturnM11.Text = (objReturn.GetrM11 * 100).ToString("n2")
                    End If

                    If objReturn.GetPositionDate.Month = 12 AndAlso objMTM.GetPositionDate.Month < objMTM.GetNextDate.Month Then
                        txtDateM12.Text = objReturn.GetDateM12.ToString("dd-MMM-yy")
                        txtDateQ4.Text = objReturn.GetDateQ4.ToString("dd-MMM-yy")
                        txtReturnM12.Text = (objReturn.GetrM12 * 100).ToString("n2")
                        txtReturnQ4.Text = (objReturn.GetrQ4 * 100).ToString("n2")
                    End If

                End If
            Else
                ExceptionMessage.Show(objReturn.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ClearReturnMonthly()
        txtDateM1.Text = ""
        txtDateM2.Text = ""
        txtDateM3.Text = ""
        txtDateM4.Text = ""
        txtDateM5.Text = ""
        txtDateM6.Text = ""
        txtDateM7.Text = ""
        txtDateM8.Text = ""
        txtDateM9.Text = ""
        txtDateM10.Text = ""
        txtDateM11.Text = ""
        txtDateM12.Text = ""
        txtReturnM1.Text = ""
        txtReturnM2.Text = ""
        txtReturnM3.Text = ""
        txtReturnM4.Text = ""
        txtReturnM5.Text = ""
        txtReturnM6.Text = ""
        txtReturnM7.Text = ""
        txtReturnM8.Text = ""
        txtReturnM9.Text = ""
        txtReturnM10.Text = ""
        txtReturnM11.Text = ""
        txtReturnM12.Text = ""
        txtDateQ1.Text = ""
        txtDateQ2.Text = ""
        txtDateQ3.Text = ""
        txtDateQ4.Text = ""
        txtReturnQ1.Text = ""
        txtReturnQ2.Text = ""
        txtReturnQ3.Text = ""
        txtReturnQ4.Text = ""
    End Sub

    Private Sub DataReturnAt()
        If objPortfolio.GetPortfolioID > 0 Then
            objReturn.Clear()
            objReturn.LoadAt(objPortfolio, dtAs.Value)
            ClearReturnAt()
            If objReturn.ErrID = 0 Then
                Dim daysMonth As String
                If objPortfolio.GetPortfolioDays.GetDaysID = 1 Then daysMonth = "A" Else daysMonth = "30"
                Dim days As Integer = 0
                Dim tmp As Double = 0

                If objReturn.GetDate1D.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate1D.Text = objReturn.GetDate1D.ToString("dd-MMM-yy")
                    txtReturn1D.Text = (objReturn.Getr1D * 100).ToString("n2")
                End If

                If objReturn.GetDate30D.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate30D.Text = objReturn.GetDate30D.ToString("dd-MMM-yy")
                    txtReturn30D.Text = (objReturn.Getr30D * 100).ToString("n2")
                End If

                If objReturn.GetDateMTD.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDateMTD.Text = objReturn.GetDateMTD.ToString("dd-MMM-yy")
                    txtReturnMTD.Text = (objReturn.GetrMTD * 100).ToString("n2")
                End If

                If objReturn.GetDate1Mo.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate1Mo.Text = objReturn.GetDate1Mo.ToString("dd-MMM-yy")
                    txtReturn1Mo.Text = (objReturn.Getr1Mo * 100).ToString("n2")
                End If

                If objReturn.GetDate3Mo.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate3Mo.Text = objReturn.GetDate3Mo.ToString("dd-MMM-yy")
                    txtReturn3Mo.Text = (objReturn.Getr3Mo * 100).ToString("n2")
                End If

                If objReturn.GetDate6Mo.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate6Mo.Text = objReturn.GetDate6Mo.ToString("dd-MMM-yy")
                    txtReturn6Mo.Text = (objReturn.Getr6Mo * 100).ToString("n2")
                End If

                If objReturn.GetDateYTD.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDateYTD.Text = objReturn.GetDateYTD.ToString("dd-MMM-yy")
                    txtReturnYTD.Text = (objReturn.GetrYTD * 100).ToString("n2")
                End If

                If objReturn.GetDate1Y.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate1Y.Text = objReturn.GetDate1Y.ToString("dd-MMM-yy")
                    txtReturn1Y.Text = (objReturn.Getr1Y * 100).ToString("n2")
                End If

                If objReturn.GetDate2Y.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate2Y.Text = objReturn.GetDate2Y.ToString("dd-MMM-yy")
                    txtReturn2Y.Text = (objReturn.Getr2Y * 100).ToString("n2")
                    days = CalculateDays(objReturn.GetDate2Y, dtAs.Value, daysMonth)
                    tmp = (1 + objReturn.Getr2Y) ^ (365 / days)
                    txtAnnualized2Y.Text = ((tmp - 1) * 100).ToString("n2")
                End If

                If objReturn.GetDate3Y.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate3Y.Text = objReturn.GetDate3Y.ToString("dd-MMM-yy")
                    txtReturn3Y.Text = (objReturn.Getr3Y * 100).ToString("n2")
                    days = CalculateDays(objReturn.GetDate3Y, dtAs.Value, daysMonth)
                    tmp = (1 + objReturn.Getr3Y) ^ (365 / days)
                    txtAnnualized3Y.Text = ((tmp - 1) * 100).ToString("n2")
                End If

                If objReturn.GetDate5Y.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate5Y.Text = objReturn.GetDate5Y.ToString("dd-MMM-yy")
                    txtReturn5Y.Text = (objReturn.Getr5Y * 100).ToString("n2")
                    days = CalculateDays(objReturn.GetDate5Y, dtAs.Value, daysMonth)
                    tmp = (1 + objReturn.Getr5Y) ^ (365 / days)
                    txtAnnualized5Y.Text = ((tmp - 1) * 100).ToString("n2")
                End If

                If objReturn.GetDate10Y.Date > objPortfolio.GetInceptionDate.Date Then
                    txtDate10Y.Text = objReturn.GetDate10Y.ToString("dd-MMM-yy")
                    txtReturn10Y.Text = (objReturn.Getr10Y * 100).ToString("n2")
                    days = CalculateDays(objReturn.GetDate10Y, dtAs.Value, daysMonth)
                    tmp = (1 + objReturn.Getr10Y) ^ (365 / days)
                    txtAnnualized10Y.Text = ((tmp - 1) * 100).ToString("n2")
                End If

                txtDateInception.Text = objReturn.GetDateInception.ToString("dd-MMM-yy")
                txtReturnInception.Text = (objReturn.GetrInception * 100).ToString("n2")
                days = CalculateDays(objReturn.GetDateInception, dtAs.Value, daysMonth)
                If days > 365 Then
                    tmp = (1 + objReturn.GetrInception) ^ (365 / days)
                    txtAnnualizedInception.Text = ((tmp - 1) * 100).ToString("n2")
                Else
                    txtAnnualizedInception.Text = ""
                End If

                CustomReturn()

            Else
                ExceptionMessage.Show(objReturn.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ClearReturnAt()
        txtDate1D.Text = ""
        txtDate30D.Text = ""
        txtDateMTD.Text = ""
        txtDate1Mo.Text = ""
        txtDate3Mo.Text = ""
        txtDate6Mo.Text = ""
        txtDateYTD.Text = ""
        txtDate1Y.Text = ""
        txtDate2Y.Text = ""
        txtDate3Y.Text = ""
        txtDate5Y.Text = ""
        txtDate10Y.Text = ""
        txtDateInception.Text = ""
        txtReturn1D.Text = ""
        txtReturn30D.Text = ""
        txtReturnMTD.Text = ""
        txtReturn1Mo.Text = ""
        txtReturn3Mo.Text = ""
        txtReturn6Mo.Text = ""
        txtReturnYTD.Text = ""
        txtReturn1Y.Text = ""
        txtReturn2Y.Text = ""
        txtReturn3Y.Text = ""
        txtReturn5Y.Text = ""
        txtReturn10Y.Text = ""
        txtReturnInception.Text = ""
        txtAnnualized2Y.Text = ""
        txtAnnualized3Y.Text = ""
        txtAnnualized5Y.Text = ""
        txtAnnualized10Y.Text = ""
        txtAnnualizedInception.Text = ""
    End Sub

    Private Sub DisplayNAV(ByVal fromDate As Date, ByVal toDate As Date)
        If dtNAV IsNot Nothing AndAlso dtNAV.Rows.Count > 0 Then
            Dim query = From t In dtNAV.AsEnumerable
                        Where t.Field(Of Date)("PositionDate") >= fromDate And t.Field(Of Date)("PositionDate") <= toDate
                        Order By t.Field(Of Date)("PositionDate") Ascending
                        Select PositionDate = t.Field(Of Date)("PositionDate"),
                               AUM = t.Field(Of Decimal)("NAV"),
                               SubsReds = t.Field(Of Decimal)("AdjustmentNAV"),
                               NAV = t.Field(Of Decimal)("NAVperUnit"),
                               Divd = t.Field(Of Decimal)("AdjustmentNAVperUnit"),
                               Index = t.Field(Of Decimal)("GeometricIndex")

            With DBGHistorical
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("PositionDate").NumberFormat = "dd-MMM-yyyy"
                .Columns("AUM").NumberFormat = "n2"
                .Columns("SubsReds").NumberFormat = "n2"
                .Columns("NAV").NumberFormat = "n5"
                .Columns("Divd").NumberFormat = "n5"
                .Columns("Index").NumberFormat = "n9"

                .Splits(0).DisplayColumns("PositionDate").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("SubsReds").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("NAV").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Divd").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Index").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

                .Splits(0).DisplayColumns("PositionDate").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AUM").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("SubsReds").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("NAV").Style.HorizontalAlignment = AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Divd").Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Index").Style.HorizontalAlignment = AlignHorzEnum.Far

                .Columns("PositionDate").Caption = "Date"
                .Columns("SubsReds").Caption = "Subs./Reds."
                .Columns("Divd").Caption = "Dividend Rate"

                For Each column As C1DisplayColumn In DBGHistorical.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

                .AllowVerticalSplit = True
                If .Splits.Count = 1 Then
                    .InsertVerticalSplit(0)
                    .Splits(0).SplitSize = 1
                End If

            End With

        End If
    End Sub

    Private Sub DBGHistorical_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGHistorical.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub txtDate1D_DoubleClick(sender As Object, e As EventArgs) Handles txtDate1D.DoubleClick
        Calculate1D()
    End Sub

    Private Sub txtReturn1D_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn1D.DoubleClick
        Calculate1D()
    End Sub

    Private Sub Calculate1D()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn1D.Text) AndAlso IsDate(txtDate1D.Text) Then
            lblReturnType.Text = "1 day"
            DisplayNAV(CDate(txtDate1D.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate1D.Text))
        End If
    End Sub

    Private Sub txtDate30D_DoubleClick(sender As Object, e As EventArgs) Handles txtDate30D.DoubleClick
        Calculate30D()
    End Sub

    Private Sub txtReturn30D_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn30D.DoubleClick
        Calculate30D()
    End Sub

    Private Sub Calculate30D()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn30D.Text) AndAlso IsDate(txtDate30D.Text) Then
            lblReturnType.Text = "30 day(s)"
            DisplayNAV(CDate(txtDate30D.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate30D.Text))
        End If
    End Sub

    Private Sub txtDateMTD_DoubleClick(sender As Object, e As EventArgs) Handles txtDateMTD.DoubleClick
        CalculateMTD()
    End Sub

    Private Sub txtReturnMTD_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnMTD.DoubleClick
        CalculateMTD()
    End Sub

    Private Sub CalculateMTD()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnMTD.Text) AndAlso IsDate(txtDateMTD.Text) Then
            lblReturnType.Text = "Month to Date"
            DisplayNAV(CDate(txtDateMTD.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDateMTD.Text))
        End If
    End Sub

    Private Sub txtDate1Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtDate1Mo.DoubleClick
        Calculate1Mo()
    End Sub

    Private Sub txtReturn1Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn1Mo.DoubleClick
        Calculate1Mo()
    End Sub

    Private Sub Calculate1Mo()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn1Mo.Text) AndAlso IsDate(txtDate1Mo.Text) Then
            lblReturnType.Text = "1 Month"
            DisplayNAV(CDate(txtDate1Mo.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate1Mo.Text))
        End If
    End Sub

    Private Sub txtDate3Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtDate3Mo.DoubleClick
        Calculate3Mo()
    End Sub

    Private Sub txtReturn3Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn3Mo.DoubleClick
        Calculate3Mo()
    End Sub

    Private Sub Calculate3Mo()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn3Mo.Text) AndAlso IsDate(txtDate3Mo.Text) Then
            lblReturnType.Text = "3 Month(s)"
            DisplayNAV(CDate(txtDate3Mo.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate3Mo.Text))
        End If
    End Sub

    Private Sub txtDate6Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtDate6Mo.DoubleClick
        Calculate6Mo()
    End Sub

    Private Sub txtReturn6Mo_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn6Mo.DoubleClick
        Calculate6Mo()
    End Sub

    Private Sub Calculate6Mo()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn6Mo.Text) AndAlso IsDate(txtDate6Mo.Text) Then
            lblReturnType.Text = "6 Month(s)"
            DisplayNAV(CDate(txtDate6Mo.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate6Mo.Text))
        End If
    End Sub

    Private Sub txtDateYTD_DoubleClick(sender As Object, e As EventArgs) Handles txtDateYTD.DoubleClick
        CalculateYTD()
    End Sub

    Private Sub txtReturnYTD_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnYTD.DoubleClick
        CalculateYTD()
    End Sub

    Private Sub CalculateYTD()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnYTD.Text) AndAlso IsDate(txtDateYTD.Text) Then
            lblReturnType.Text = "Year to Date"
            DisplayNAV(CDate(txtDateYTD.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDateYTD.Text))
        End If
    End Sub

    Private Sub txtDate1Y_DoubleClick(sender As Object, e As EventArgs) Handles txtDate1Y.DoubleClick
        Calculate1Y()
    End Sub

    Private Sub txtReturn1Y_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn1Y.DoubleClick
        Calculate1Y()
    End Sub

    Private Sub Calculate1Y()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn1Y.Text) AndAlso IsDate(txtDate1Y.Text) Then
            lblReturnType.Text = "1 year"
            DisplayNAV(CDate(txtDate1Y.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate1Y.Text))
        End If
    End Sub

    Private Sub txtDate2Y_DoubleClick(sender As Object, e As EventArgs) Handles txtDate2Y.DoubleClick
        Calculate2Y()
    End Sub

    Private Sub txtReturn2Y_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn2Y.DoubleClick
        Calculate2Y()
    End Sub

    Private Sub Calculate2Y()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn2Y.Text) AndAlso IsDate(txtDate2Y.Text) Then
            lblReturnType.Text = "2 year(s)"
            DisplayNAV(CDate(txtDate2Y.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate2Y.Text))
        End If
    End Sub

    Private Sub txtDate3Y_DoubleClick(sender As Object, e As EventArgs) Handles txtDate3Y.DoubleClick
        Calculate3Y()
    End Sub

    Private Sub txtReturn3Y_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn3Y.DoubleClick
        Calculate3Y()
    End Sub

    Private Sub Calculate3Y()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn3Y.Text) AndAlso IsDate(txtDate3Y.Text) Then
            lblReturnType.Text = "3 year(s)"
            DisplayNAV(CDate(txtDate3Y.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate3Y.Text))
        End If
    End Sub

    Private Sub txtDate5Y_DoubleClick(sender As Object, e As EventArgs) Handles txtDate5Y.DoubleClick
        Calculate5Y()
    End Sub

    Private Sub txtReturn5Y_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn5Y.DoubleClick
        Calculate5Y()
    End Sub

    Private Sub Calculate5Y()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn5Y.Text) AndAlso IsDate(txtDate5Y.Text) Then
            lblReturnType.Text = "5 year(s)"
            DisplayNAV(CDate(txtDate5Y.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate5Y.Text))
        End If
    End Sub

    Private Sub txtDate10Y_DoubleClick(sender As Object, e As EventArgs) Handles txtDate10Y.DoubleClick
        Calculate10Y()
    End Sub

    Private Sub txtReturn10Y_DoubleClick(sender As Object, e As EventArgs) Handles txtReturn10Y.DoubleClick
        Calculate10Y()
    End Sub

    Private Sub Calculate10Y()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturn10Y.Text) AndAlso IsDate(txtDate10Y.Text) Then
            lblReturnType.Text = "10 year(s)"
            DisplayNAV(CDate(txtDate10Y.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDate10Y.Text))
        End If
    End Sub

    Private Sub txtDateInception_DoubleClick(sender As Object, e As EventArgs) Handles txtDateInception.DoubleClick
        CalculateInception()
    End Sub

    Private Sub txtReturnInception_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnInception.DoubleClick
        CalculateInception()
    End Sub

    Private Sub CalculateInception()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnInception.Text) AndAlso IsDate(txtDateInception.Text) Then
            lblReturnType.Text = "Since Inception"
            DisplayNAV(CDate(txtDateInception.Text), dtAs.Value)
            DataNAVFrom(CDate(txtDateInception.Text))
        End If
    End Sub

    Private Sub txtDateM1_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM1.DoubleClick
        CalculateM1()
    End Sub

    Private Sub txtReturnM1_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM1.DoubleClick
        CalculateM1()
    End Sub

    Private Sub CalculateM1()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM1.Text) AndAlso IsDate(txtDateM1.Text) Then
            objNAVFrom.Clear()
            objNAVFrom.LoadLast(objPortfolio, New Date(dtAs.Value.Year - 1, 12, 31))
            If objNAVFrom.ErrID = 0 Then
                Dim lastDate As Date = objNAVFrom.GetPositionDate
                lblReturnType.Text = "JANUARY"
                DisplayNAV(lastDate, CDate(txtDateM1.Text))
                DataNAVMonthly(CDate(txtDateM1.Text))
                DataNAVFrom(lastDate)
            End If
        End If
    End Sub

    Private Sub txtDateQ1_DoubleClick(sender As Object, e As EventArgs) Handles txtDateQ1.DoubleClick
        CalculateQ1()
    End Sub

    Private Sub txtReturnQ1_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnQ1.DoubleClick
        CalculateQ1()
    End Sub

    Private Sub CalculateQ1()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnQ1.Text) AndAlso IsDate(txtDateQ1.Text) Then
            objNAVFrom.Clear()
            objNAVFrom.LoadLast(objPortfolio, New Date(dtAs.Value.Year - 1, 12, 31))
            If objNAVFrom.ErrID = 0 Then
                Dim lastDate As Date = objNAVFrom.GetPositionDate
                lblReturnType.Text = "Q1"
                DisplayNAV(lastDate, CDate(txtDateQ1.Text))
                DataNAVMonthly(CDate(txtDateQ1.Text))
                DataNAVFrom(lastDate)
            End If
        End If
    End Sub

    Private Sub txtDateM2_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM2.DoubleClick
        CalculateM2()
    End Sub

    Private Sub txtReturnM2_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM2.DoubleClick
        CalculateM2()
    End Sub

    Private Sub CalculateM2()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM2.Text) AndAlso IsDate(txtDateM2.Text) Then
            lblReturnType.Text = "FEBRUARY"
            DisplayNAV(CDate(txtDateM1.Text), CDate(txtDateM2.Text))
            DataNAVMonthly(CDate(txtDateM2.Text))
            DataNAVFrom(CDate(txtDateM1.Text))
        End If
    End Sub


    Private Sub txtDateM3_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM3.DoubleClick
        CalculateM3()
    End Sub

    Private Sub txtReturnM3_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM3.DoubleClick
        CalculateM3()
    End Sub

    Private Sub CalculateM3()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM3.Text) AndAlso IsDate(txtDateM3.Text) Then
            lblReturnType.Text = "MARCH"
            DisplayNAV(CDate(txtDateM2.Text), CDate(txtDateM3.Text))
            DataNAVMonthly(CDate(txtDateM3.Text))
            DataNAVFrom(CDate(txtDateM2.Text))
        End If
    End Sub


    Private Sub txtDateM4_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM4.DoubleClick
        CalculateM4()
    End Sub

    Private Sub txtReturnM4_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM4.DoubleClick
        CalculateM4()
    End Sub

    Private Sub CalculateM4()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM4.Text) AndAlso IsDate(txtDateM4.Text) Then
            lblReturnType.Text = "APRIL"
            DisplayNAV(CDate(txtDateM3.Text), CDate(txtDateM4.Text))
            DataNAVMonthly(CDate(txtDateM4.Text))
            DataNAVFrom(CDate(txtDateM3.Text))
        End If
    End Sub


    Private Sub txtDateM5_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM5.DoubleClick
        CalculateM5()
    End Sub

    Private Sub txtReturnM5_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM5.DoubleClick
        CalculateM5()
    End Sub

    Private Sub CalculateM5()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM5.Text) AndAlso IsDate(txtDateM5.Text) Then
            lblReturnType.Text = "MAY"
            DisplayNAV(CDate(txtDateM4.Text), CDate(txtDateM5.Text))
            DataNAVMonthly(CDate(txtDateM5.Text))
            DataNAVFrom(CDate(txtDateM4.Text))
        End If
    End Sub


    Private Sub txtDateM6_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM6.DoubleClick
        CalculateM6()
    End Sub

    Private Sub txtReturnM6_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM6.DoubleClick
        CalculateM6()
    End Sub

    Private Sub CalculateM6()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM6.Text) AndAlso IsDate(txtDateM6.Text) Then
            lblReturnType.Text = "JUNE"
            DisplayNAV(CDate(txtDateM5.Text), CDate(txtDateM6.Text))
            DataNAVMonthly(CDate(txtDateM6.Text))
            DataNAVFrom(CDate(txtDateM5.Text))
        End If
    End Sub

    Private Sub txtDateM7_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM7.DoubleClick
        CalculateM7()
    End Sub

    Private Sub txtReturnM7_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM7.DoubleClick
        CalculateM7()
    End Sub

    Private Sub CalculateM7()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM7.Text) AndAlso IsDate(txtDateM7.Text) Then
            lblReturnType.Text = "JULY"
            DisplayNAV(CDate(txtDateM6.Text), CDate(txtDateM7.Text))
            DataNAVMonthly(CDate(txtDateM7.Text))
            DataNAVFrom(CDate(txtDateM6.Text))
        End If
    End Sub


    Private Sub txtDateM8_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM8.DoubleClick
        CalculateM8()
    End Sub

    Private Sub txtReturnM8_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM8.DoubleClick
        CalculateM8()
    End Sub

    Private Sub CalculateM8()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM8.Text) AndAlso IsDate(txtDateM8.Text) Then
            lblReturnType.Text = "AUGUST"
            DisplayNAV(CDate(txtDateM7.Text), CDate(txtDateM8.Text))
            DataNAVMonthly(CDate(txtDateM8.Text))
            DataNAVFrom(CDate(txtDateM7.Text))
        End If
    End Sub

    Private Sub txtDateM9_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM9.DoubleClick
        CalculateM9()
    End Sub

    Private Sub txtReturnM9_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM9.DoubleClick
        CalculateM9()
    End Sub

    Private Sub CalculateM9()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM9.Text) AndAlso IsDate(txtDateM9.Text) Then
            lblReturnType.Text = "SEPTEMBER"
            DisplayNAV(CDate(txtDateM8.Text), CDate(txtDateM9.Text))
            DataNAVMonthly(CDate(txtDateM9.Text))
            DataNAVFrom(CDate(txtDateM8.Text))
        End If
    End Sub


    Private Sub txtDateM10_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM10.DoubleClick
        CalculateM10()
    End Sub

    Private Sub txtReturnM10_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM10.DoubleClick
        CalculateM10()
    End Sub

    Private Sub CalculateM10()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM10.Text) AndAlso IsDate(txtDateM10.Text) Then
            lblReturnType.Text = "OCTOBER"
            DisplayNAV(CDate(txtDateM9.Text), CDate(txtDateM10.Text))
            DataNAVMonthly(CDate(txtDateM10.Text))
            DataNAVFrom(CDate(txtDateM9.Text))
        End If
    End Sub

    Private Sub txtDateM11_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM11.DoubleClick
        CalculateM11()
    End Sub

    Private Sub txtReturnM11_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM11.DoubleClick
        CalculateM11()
    End Sub

    Private Sub CalculateM11()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM11.Text) AndAlso IsDate(txtDateM11.Text) Then
            lblReturnType.Text = "NOVEMBER"
            DisplayNAV(CDate(txtDateM10.Text), CDate(txtDateM11.Text))
            DataNAVMonthly(CDate(txtDateM11.Text))
            DataNAVFrom(CDate(txtDateM10.Text))
        End If
    End Sub

    Private Sub txtDateM12_DoubleClick(sender As Object, e As EventArgs) Handles txtDateM12.DoubleClick
        CalculateM12()
    End Sub

    Private Sub txtReturnM12_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnM12.DoubleClick
        CalculateM12()
    End Sub

    Private Sub CalculateM12()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnM12.Text) AndAlso IsDate(txtDateM12.Text) Then
            lblReturnType.Text = "DECEMBER"
            DisplayNAV(CDate(txtDateM11.Text), CDate(txtDateM12.Text))
            DataNAVMonthly(CDate(txtDateM12.Text))
            DataNAVFrom(CDate(txtDateM11.Text))
        End If
    End Sub

    Private Sub txtDateQ2_DoubleClick(sender As Object, e As EventArgs) Handles txtDateQ2.DoubleClick
        CalculateQ2()
    End Sub

    Private Sub txtReturnQ2_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnQ2.DoubleClick
        CalculateQ2()
    End Sub

    Private Sub CalculateQ2()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnQ2.Text) AndAlso IsDate(txtDateQ2.Text) Then
            lblReturnType.Text = "Q2"
            DisplayNAV(CDate(txtDateQ1.Text), CDate(txtDateQ2.Text))
            DataNAVMonthly(CDate(txtDateQ2.Text))
            DataNAVFrom(CDate(txtDateQ1.Text))
        End If
    End Sub

    Private Sub txtDateQ3_DoubleClick(sender As Object, e As EventArgs) Handles txtDateQ3.DoubleClick
        CalculateQ3()
    End Sub

    Private Sub txtReturnQ3_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnQ3.DoubleClick
        CalculateQ3()
    End Sub

    Private Sub CalculateQ3()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnQ3.Text) AndAlso IsDate(txtDateQ3.Text) Then
            lblReturnType.Text = "Q3"
            DisplayNAV(CDate(txtDateQ2.Text), CDate(txtDateQ3.Text))
            DataNAVMonthly(CDate(txtDateQ3.Text))
            DataNAVFrom(CDate(txtDateQ2.Text))
        End If
    End Sub

    Private Sub txtDateQ4_DoubleClick(sender As Object, e As EventArgs) Handles txtDateQ4.DoubleClick
        CalculateQ4()
    End Sub

    Private Sub txtReturnQ4_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnQ4.DoubleClick
        CalculateQ4()
    End Sub

    Private Sub CalculateQ4()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnQ4.Text) AndAlso IsDate(txtDateQ4.Text) Then
            lblReturnType.Text = "Q4"
            DisplayNAV(CDate(txtDateQ3.Text), CDate(txtDateQ4.Text))
            DataNAVMonthly(CDate(txtDateQ4.Text))
            DataNAVFrom(CDate(txtDateQ3.Text))
        End If
    End Sub

    Private Sub dtCustom_ValueChanged(sender As Object, e As EventArgs) Handles dtCustom.ValueChanged
        CustomReturn()
    End Sub

    Private Sub CustomReturn()
        txtReturnCustom.Text = ""
        If dtCustom.Value.Date > objPortfolio.GetInceptionDate.Date Then
            objNAVFrom.Clear()
            objNAVFrom.LoadLast(objPortfolio, dtCustom.Value)
            If objNAVFrom.ErrID = 0 Then
                dtCustom.Value = objNAVFrom.GetPositionDate.ToString("dd-MMM-yyyy")
                If objNAVFrom.GetGeometricIndex > 0 Then
                    txtReturnCustom.Text = (((ToGeometricIndex / objNAVFrom.GetGeometricIndex) - 1) * 100).ToString("n2")
                Else
                    txtReturnCustom.Text = 0.ToString("n2")
                End If
            Else
                ExceptionMessage.Show(objNAVFrom.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtReturnCustom_DoubleClick(sender As Object, e As EventArgs) Handles txtReturnCustom.DoubleClick
        CalculateCustom()
    End Sub

    Private Sub CalculateCustom()
        If objPortfolio.GetPortfolioID > 0 AndAlso IsNumeric(txtReturnCustom.Text) Then
            lblReturnType.Text = "Custom"
            DisplayNAV(dtCustom.Value, CDate(lblToDate.Text))
            DataNAVFrom(dtCustom.Value)
        End If
    End Sub

End Class