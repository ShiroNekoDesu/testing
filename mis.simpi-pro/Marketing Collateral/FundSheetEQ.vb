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
Imports simpi.GlobalUtilities.GlobalDate
Imports simpi.GlobalCore.GlobalStatistic
Imports simpi.CoreData
Imports simpi.Analyst

Public Class FundSheetEQ
    Dim objSimpi As New MasterSimpi
    Dim objPortfolio As New MasterPortfolio
    Dim objCodeset As New PortfolioCodeset
    Dim objCodesetSimpi As New simpi.SimpiMaster.SimpiCodeset
    Dim objTerm As New simpi.SimpiMaster.SimpiTerm
    Dim objSector As New ParameterSectorClass
    Dim objNAV As New PortfolioNAV
    Dim objNAV2 As New PortfolioNAV
    Dim objNAV1 As New PortfolioNAV
    Dim objReturn As New PortfolioReturn
    Dim objBenchmark As New simpi.CoreData.PortfolioBenchmark
    Dim objPosition As New PositionSecurities
    Dim objReview As New MarketReview
    Dim objSecurities As New MarketInstrument

    Dim dtSector As New DataTable
    Dim dtNAV As New DataTable
    Dim dtBenchmark As New DataTable
    Dim dtPosition As New DataTable
    Dim dtHolding As New DataTable
    Dim dtReturn As New DataTable
    Dim dtMonthly As New DataTable
    Dim tmp As String
    Dim no As Integer

    Private Sub FundSheetEQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSimpi.UserAccess = objAccess
        objPortfolio.UserAccess = objAccess
        objCodeset.UserAccess = objAccess
        objCodesetSimpi.UserAccess = objAccess
        objTerm.UserAccess = objAccess
        objSector.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        objNAV1.UserAccess = objAccess
        objNAV2.UserAccess = objAccess
        objReturn.UserAccess = objAccess
        objBenchmark.UserAccess = objAccess
        objPosition.UserAccess = objAccess
        objReview.UserAccess = objAccess
        objSecurities.UserAccess = objAccess

        dtAs.Value = Now.AddDays(-1)
        GetComboInit(New ParameterSectorClass, cmbSector, "ClassID", "ClassCode")
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

    Private Sub btnPDF1_Click(sender As Object, e As EventArgs) Handles btnPDF1.Click

    End Sub

    Private Sub btnPDF2_Click(sender As Object, e As EventArgs) Handles btnPDF2.Click

    End Sub

    Private Sub btnPDF3_Click(sender As Object, e As EventArgs) Handles btnPDF3.Click

    End Sub

    Private Sub btnEmail1_Click(sender As Object, e As EventArgs) Handles btnEmail1.Click

    End Sub

    Private Sub btnEmail2_Click(sender As Object, e As EventArgs) Handles btnEmail2.Click

    End Sub

    Private Sub btnEmail3_Click(sender As Object, e As EventArgs) Handles btnEmail3.Click

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
        If rbOption1.Checked Then DisplayOption()
    End Sub

    Private Sub rbOption2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbOption2.SelectedIndexChanged
        If rbOption2.Checked Then DisplayOption()
    End Sub

    Private Sub DisplayOption()

    End Sub

    Private Sub DisplayClear()
        lblCcy.Text = ""
        lblCurrency.Text = ""
        lblInception.Text = ""
        lblFundType.Text = ""
        lblBenchmark.Text = ""
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
        lblObjective.Text = ""
        lblStrategy.Text = ""
        lblPeriod.Text = ""
        lblRiskScore.Text = ""
        lblRiskTolerance.Text = ""
        lblRisk1.Text = ""
        lblRisk2.Text = ""
        lblRisk3.Text = ""
        lblRisk4.Text = ""
        lblRisk5.Text = ""
        lblRisk6.Text = ""
        lblRisk7.Text = ""
        lblReturnInception.Text = ""
        lblReturnStdDev.Text = ""
        lblReturnBeta.Text = ""
        lblReturnBestReturn.Text = ""
        lblReturnBestMonth.Text = ""
        lblReturnWorstReturn.Text = ""
        lblReturnWorstMonth.Text = ""
        lblReturnBestYear.Text = ""
        lblPolicyEQ.Text = ""
        lblPolicyFI.Text = ""
        lblPolicyMM.Text = ""
        lblPortfolioEQ.Text = ""
        lblPortfolioFI.Text = ""
        lblPortfolioMM.Text = ""
        lblPolicyNotes.Text = ""
        lblAboutTitle.Text = ""
        lblAboutCompany.Text = ""
        lblReviewTitle.Text = ""
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

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 6)
        lblObjective.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 21)
        lblStrategy.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 5)
        lblPeriod.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 22)
        lblRiskScore.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 3)
        lblRiskTolerance.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 23)
        lblRisk1.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 24)
        lblRisk2.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 25)
        lblRisk3.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 26)
        lblRisk4.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 27)
        lblRisk5.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 28)
        lblRisk6.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 29)
        lblRisk7.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 7)
        lblPolicyEQ.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 8)
        lblPolicyFI.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 9)
        lblPolicyMM.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = GetPortfolioCodeset(objPortfolio.GetPortfolioID, 30)
        lblPolicyNotes.Text = IIf(tmp.Trim = "", "-", tmp.Trim)

        tmp = objCodesetSimpi.GetFieldData(12)
        lblAboutTitle.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = objCodesetSimpi.GetFieldData(13)
        lblAboutCompany.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
        tmp = objCodesetSimpi.GetFieldData(14)
        lblReviewTitle.Text = IIf(tmp.Trim = "", "-", tmp.Trim)
    End Sub

    Private Sub DataLoad()
        If objPortfolio.GetPortfolioID > 0 Then
            objNAV.Clear()
            objNAV.LoadAt(objPortfolio, dtAs.Value)
            If objNAV.ErrID = 0 Then
                lblNAVUnit.Text = objNAV.GetNAVPerUnit.ToString("n4")
                lblAUM.Text = objNAV.GetNAV.ToString("n0")

                objPosition.Clear()
                dtPosition = objPosition.Search(objPortfolio, objNAV.GetPositionDate)
                cmbSector.Text = objPortfolio.GetPortfolioSector.GetClassCode

                objReturn.Clear()
                objReturn.LoadAt(objPortfolio, objNAV.GetPositionDate)

                objBenchmark.Clear()
                objBenchmark.LoadAt(objPortfolio, objNAV.GetPositionDate)

                objReview.Clear()
                objReview.Load(objPortfolio, objNAV.GetPositionDate)

                dtNAV = objNAV.SearchHistoryLast(objPortfolio, objNAV.GetPositionDate, 0)
                dtBenchmark = objBenchmark.SearchHistoryLast(objPortfolio, objNAV.GetPositionDate, 0)
                dtReturn = objReturn.SearchEOY(objPortfolio, objPortfolio.GetInceptionDate, objNAV.GetPositionDate)
                DataMonthly()

                DisplayPerformance()
                DisplayReview()
            Else
                DataClear()
                ExceptionMessage.Show(objNAV.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub DataClear()
        reviewClear()
        performanceClear()
        chartPortfolio.ChartGroups(0).ChartData.SeriesList.Clear()
        chartMonthly.ChartGroups(0).ChartData.SeriesList.Clear()
        chartSector.ChartGroups(0).ChartData.SeriesList.Clear()
        DBGHolding.Columns.Clear()
    End Sub

    Private Sub DataSector()
        dtSector.Clear()
        objSector.Clear()
        dtSector = objSector.Company_Member(cmbSector.SelectedValue, 0, 0)
    End Sub

    Private Sub DataMonthly()
        dtMonthly.Clear()
        If objReturn.ErrID = 0 Then
            Dim dr As DataRow = dtMonthly.NewRow()
            If objReturn.GetPositionDate.Month = 1 Then
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 1, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 1 Then
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 1, 1)
                dr("Return") = objReturn.GetrM1
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 2 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 2, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 2 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 2, 1)
                dr("Return") = objReturn.GetrM2
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 3 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 3, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 3 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 3, 1)
                dr("Return") = objReturn.GetrM3
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 4 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 4, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 4 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 4, 1)
                dr("Return") = objReturn.GetrM4
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 5 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 5, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 5 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 5, 1)
                dr("Return") = objReturn.GetrM5
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 6 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 6, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 6 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 6, 1)
                dr("Return") = objReturn.GetrM6
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 7 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 7, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 7 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 7, 1)
                dr("Return") = objReturn.GetrM7
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 8 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 8, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 8 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 8, 1)
                dr("Return") = objReturn.GetrM8
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 9 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 9, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 9 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 9, 1)
                dr("Return") = objReturn.GetrM9
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 10 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 10, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 10 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 10, 1)
                dr("Return") = objReturn.GetrM10
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 11 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 11, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            ElseIf objReturn.GetPositionDate.Month > 11 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 11, 1)
                dr("Return") = objReturn.GetrM11
                dtMonthly.Rows.Add(dr)
            End If

            If objReturn.GetPositionDate.Month = 12 Then
                dr = dtMonthly.NewRow()
                dr("Date") = New Date(objReturn.GetPositionDate.Year, 12, 1)
                dr("Return") = objReturn.GetrMTD
                dtMonthly.Rows.Add(dr)
            End If

        End If

        If dtReturn IsNot Nothing AndAlso dtReturn.Rows.Count > 0 Then
            Dim query = From q In dtReturn Select PositionDate = q.Field(Of Date)("PositionDate"),
                                                      M1 = q.Field(Of Decimal)("rM1"), M2 = q.Field(Of Decimal)("rM2"),
                                                      M3 = q.Field(Of Decimal)("rM3"), M4 = q.Field(Of Decimal)("rM4"),
                                                      M5 = q.Field(Of Decimal)("rM5"), M6 = q.Field(Of Decimal)("rM6"),
                                                      M7 = q.Field(Of Decimal)("rM7"), M8 = q.Field(Of Decimal)("rM8"),
                                                      M9 = q.Field(Of Decimal)("rM9"), M10 = q.Field(Of Decimal)("rM10"),
                                                      M11 = q.Field(Of Decimal)("rM11"), M12 = q.Field(Of Decimal)("rM12")

            Dim monthDate As Date
            For Each item In query
                Dim dr As DataRow = dtMonthly.NewRow()
                dr("Date") = New Date(item.PositionDate.Year, 12, 1)
                dr("Return") = item.M12
                dtMonthly.Rows.Add(dr)

                monthDate = New Date(item.PositionDate.Year, 11, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M11
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 10, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M10
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 9, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M9
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 8, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M8
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 7, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M7
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 6, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M6
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 5, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M5
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 4, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M4
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 3, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M3
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 2, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M2
                    dtMonthly.Rows.Add(dr)
                End If

                monthDate = New Date(item.PositionDate.Year, 1, 1)
                If objPortfolio.GetInceptionDate.Date < GenerateDate(monthDate, "EOM").Date Then
                    dr = dtMonthly.NewRow()
                    dr("Date") = monthDate
                    dr("Return") = item.M1
                    dtMonthly.Rows.Add(dr)
                End If

            Next
        End If
    End Sub

#Region "holding"
    Private Sub cmbSector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSector.SelectedIndexChanged
        If cmbSector.SelectedIndex <> -1 Then
            DataSector()
            DisplayHolding()
        End If
    End Sub

    Private Sub chkSectorOther_CheckedChanged(sender As Object, e As EventArgs) Handles chkSectorOther.CheckedChanged
        sectorCheck()
    End Sub

    Private Sub txtTopSector_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTopSector.KeyDown
        If e.KeyCode = Keys.Enter Then DisplayHolding()
    End Sub

    Private Sub txtTopHolding_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTopHolding.KeyDown
        If e.KeyCode = Keys.Enter Then DisplayHolding()
    End Sub

    Private Sub rbPersen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbPersen.SelectedIndexChanged
        If rbPersen.Checked Then DisplayHolding()
    End Sub

    Private Sub rbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbName.SelectedIndexChanged
        If rbName.Checked Then DisplayHolding()
    End Sub

    Private Sub sectorCheck()
        If chkSectorOther.Checked Then
            txtTopSector.Text = 4
            txtTopSector.Enabled = True
        Else
            txtTopSector.Text = 0
            txtTopSector.Enabled = False
        End If
    End Sub

    Private Sub btnSettingSector_Click(sender As Object, e As EventArgs) Handles btnSettingSector.Click
        Dim pg As New PropertyGrid()
        pg.SelectedObject = chartSector
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As New Form()
        f.Text = "Sector Allocation"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
    End Sub

    Private Sub tbarHoleRadius_Scroll(sender As Object, e As System.EventArgs) Handles tbarHoleRadius.Scroll
        chartSector.ChartGroups.Group0.Pie.InnerRadius = tbarHoleRadius.Value
    End Sub

    Private Sub bRotateCounterClockwise_Click(sender As Object, e As System.EventArgs) Handles btnRotateCounterClockwise.Click
        Dim pie As Pie = chartSector.ChartGroups.Group0.Pie
        pie.Start = (pie.Start + 10) Mod 360
    End Sub

    Private Sub bRotateClockwise_Click(sender As Object, e As System.EventArgs) Handles btnRotateClockwise.Click
        Dim pie As Pie = chartSector.ChartGroups.Group0.Pie
        pie.Start = (pie.Start + 350) Mod 360
    End Sub

    Private Sub chkAlpha_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAlpha.CheckedChanged
        Dim useAlpha As Boolean = chkAlpha.Checked
        Dim cdsc As ChartDataSeriesCollection = chartSector.ChartGroups(0).ChartData.SeriesList
        Dim cds As ChartDataSeries
        For Each cds In cdsc
            If useAlpha AndAlso cds.FillStyle.Alpha = 255 Then
                cds.FillStyle.Alpha = 100
            ElseIf cds.FillStyle.Alpha < 255 Then
                cds.FillStyle.Alpha = 255
            End If
        Next cds
    End Sub

    Private Sub chkAntiAlias_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAntiAlias.CheckedChanged
        chartSector.UseAntiAliasedGraphics = chkAntiAlias.Checked
    End Sub

    Private Sub DBGHolding_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGHolding.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub rbDonut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbDonut.SelectedIndexChanged
        If rbDonut.Checked Then pieCheck()
    End Sub

    Private Sub rbPie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbPie.SelectedIndexChanged
        If rbPie.Checked Then pieCheck()
    End Sub

    Private Sub pieCheck()
        If rbDonut.Checked Then
            tbarHoleRadius.Enabled = True
            tbarHoleRadius.Value = 65
            chartSector.ChartGroups.Group0.Pie.InnerRadius = tbarHoleRadius.Value
        Else
            tbarHoleRadius.Enabled = False
            chartSector.ChartGroups.Group0.Pie.InnerRadius = 0
        End If
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
                        Group Join sc In dtSector.AsEnumerable On sc.Field(Of Integer)("CompanyID") Equals s.Field(Of Integer)("CompanyID")
                                 Into si = Group Let sc = si.FirstOrDefault
                        Select SecuritiesCode = s.Field(Of String)("SecuritiesCode"),
                               SecuritiesName = s.Field(Of String)("SecuritiesNameShort"), SubTypeCode = st.Field(Of String)("SubTypeCode"),
                               TypeID = t.Field(Of Integer)("TypeID"), TypeCode = t.Field(Of String)("TypeCode"),
                               Sector = If(sc Is Nothing, "No Sector", sc.Field(Of String)("SectorName")),
                               Qty = d.Field(Of Decimal)("Qty"),
                               Price = IIf(t.Field(Of Integer)("TypeID") = SetFI(), CDbl(d.Field(Of Decimal)("MarketPrice") * 100), d.Field(Of Decimal)("MarketPrice")),
                               Cost = IIf(t.Field(Of Integer)("TypeID") = SetFI(), CDbl(d.Field(Of Decimal)("CostPrice") * 100), d.Field(Of Decimal)("CostPrice")),
                               Value = d.Field(Of Decimal)("TotalValue"),
                               Persen = CDbl(IIf(objNAV.GetNAV = 0, 0D, CDbl(d.Field(Of Decimal)("TotalValue") * 100 / objNAV.GetNAV)))

            lblPortfolioEQ.Text = (From q In query Where q.TypeID = SetEQ() Select q.Persen).Sum.ToString("n2")
            lblPortfolioFI.Text = (From q In query Where q.TypeID = SetFI() Select q.Persen).Sum.ToString("n2")
            lblPortfolioMM.Text = (100 - CDbl(lblPortfolioEQ.Text) - CDbl(lblPortfolioFI.Text)).ToString("n2")

            Dim Top As Integer
            Integer.TryParse(txtTopHolding.Text, Top)
            no = 0
            If Top > 0 Then
                Dim query1 = From q1 In query.Take(Top)
                If rbName.Checked Then
                    Dim query2 = From q In query1 Order By q.SecuritiesName Ascending
                                 Select No = _no(), Share = q.SecuritiesCode, Name = q.SecuritiesName, TypeCode = q.TypeCode, Sector = q.Sector,
                                   Qty = q.Qty, Price = q.Price, Cost = q.Cost, Value = q.Value, Persen = q.Persen
                    DisplayHoldingList(query2.ToList)
                Else
                    Dim query2 = From q In query1 Order By q.Value Descending
                                 Select No = _no(), Share = q.SecuritiesCode, Name = q.SecuritiesName, TypeCode = q.TypeCode, Sector = q.Sector,
                                   Qty = q.Qty, Price = q.Price, Cost = q.Cost, Value = q.Value, Persen = q.Persen
                    DisplayHoldingList(query2.ToList)
                End If
            Else
                If rbName.Checked Then
                    Dim query2 = From q In query Order By q.SecuritiesName Ascending
                                 Select No = _no(), Share = q.SecuritiesCode, Name = q.SecuritiesName, TypeCode = q.TypeCode, Sector = q.Sector,
                                   Qty = q.Qty, Price = q.Price, Cost = q.Cost, Value = q.Value, Persen = q.Persen
                    DisplayHoldingList(query2.ToList)
                Else
                    Dim query2 = From q In query Order By q.Value Descending
                                 Select No = _no(), Share = q.SecuritiesCode, Name = q.SecuritiesName, TypeCode = q.TypeCode, Sector = q.Sector,
                                   Qty = q.Qty, Price = q.Price, Cost = q.Cost, Value = q.Value, Persen = q.Persen
                    DisplayHoldingList(query2.ToList)
                End If
            End If

            Dim query3 = From q In query Where q.TypeID = SetEQ() Group By key = New With {Key .Sector = q.Sector}
                         Into Group Select New With {.Sector = key.Sector, .Value = Group.Sum(Function(r) CDbl(r.Value))}
            Dim query4 = From q In query Where q.TypeID = SetFI() Group By key = New With {Key .SubTypeCode = q.SubTypeCode}
                         Into Group Select New With {.SubTypeCode = key.SubTypeCode, .Value = Group.Sum(Function(r) CDbl(r.Value))}
            Dim fund As Double = (From q In query Where q.TypeID = SetFund() Select q.Value).Sum
            Dim pa As Double = (From q In query Where q.TypeID = SetPhysicalAsset() Select q.Value).Sum

            dtHolding.Clear()
            For Each item In query3
                Dim dr As DataRow = dtHolding.NewRow()
                dr("Sector") = item.Sector
                dr("Value") = item.Value
                dtHolding.Rows.Add(dr)
            Next
            For Each item In query4
                Dim dr As DataRow = dtHolding.NewRow()
                If item.SubTypeCode.Trim = "GOVT" Or item.SubTypeCode.Trim = "TBILLS" Then
                    dr("Sector") = "Government"
                Else
                    dr("Sector") = "Corporation"
                End If
                dr("Value") = item.Value
                dtHolding.Rows.Add(dr)
            Next
            If fund > 0 Then
                Dim dr As DataRow = dtHolding.NewRow()
                dr("Sector") = "Mutual Fund"
                dr("Value") = fund
                dtHolding.Rows.Add(dr)
            End If
            If pa > 0 Then
                Dim dr As DataRow = dtHolding.NewRow()
                dr("Sector") = "Physical Asset"
                dr("Value") = pa
                dtHolding.Rows.Add(dr)
            End If
            DisplayHoldingSector()

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
            .Columns("Price").NumberFormat = "n2"
            .Columns("Cost").NumberFormat = "n2"
            .Columns("Value").NumberFormat = "n0"
            .Columns("Persen").NumberFormat = "n2"

            .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Share").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("TypeCode").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sector").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Qty").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Share").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("TypeCode").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Sector").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Qty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

            .Columns("TypeCode").Caption = "Type"
            .Columns("Persen").Caption = "%"

            .Splits(0).DisplayColumns("No").Width = 25
            .Splits(0).DisplayColumns("Share").Width = 60
            .Splits(0).DisplayColumns("Name").Width = 175
            .Splits(0).DisplayColumns("TypeCode").Width = 40
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
            .Splits(0).DisplayColumns("TypeCode").Style.Font = font
            .Splits(0).DisplayColumns("Sector").Style.Font = font
            .Splits(0).DisplayColumns("Qty").Style.Font = font
            .Splits(0).DisplayColumns("Cost").Style.Font = font
            .Splits(0).DisplayColumns("Price").Style.Font = font
            .Splits(0).DisplayColumns("Value").Style.Font = font
            .Splits(0).DisplayColumns("Persen").Style.Font = font

        End With
    End Sub

    Private Function _valueLabel(ByVal item As Double) As Double
        If objNAV.GetNAV = 0 Then Return 0 Else Return CDbl(item * 100 / objNAV.GetNAV)
    End Function

    Private Sub DisplayHoldingSector()
        If dtHolding IsNot Nothing AndAlso dtHolding.Rows.Count > 0 Then
            Dim top, slice As Integer
            Dim valueSisa, valueItem As Double
            Dim stringLabel As String = ""
            valueSisa = 100
            slice = 0
            Integer.TryParse(txtTopSector.Text, top)
            Dim querySector As IEnumerable

            Dim query = From q In dtHolding.AsEnumerable Order By q.Field(Of Decimal)("Value") Descending
                        Select Sector = q.Field(Of String)("Sector"), Value = q.Field(Of Decimal)("Value")
            If top > 0 Then
                Dim query1 = From q1 In query.AsEnumerable.Take(top)
                If rbName.Checked Then
                    querySector = From qs In query1 Order By qs.Sector Ascending Select Sector = qs.Sector, Value = qs.Value
                Else
                    querySector = From qs In query1 Order By qs.Value Descending Select Sector = qs.Sector, Value = qs.Value
                End If
            Else
                If rbName.Checked Then
                    querySector = From qs In query Order By qs.Sector Ascending Select Sector = qs.Sector, Value = qs.Value
                Else
                    querySector = From qs In query Order By qs.Value Descending Select Sector = qs.Sector, Value = qs.Value
                End If
            End If

            chartSector.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None
            chartSector.ChartLabels.DefaultLabelStyle.BackColor = SystemColors.Info
            chartSector.ChartLabels.DefaultLabelStyle.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Solid

            Dim grp As ChartGroup = chartSector.ChartGroups(0)
            grp.ChartType = Chart2DTypeEnum.Pie
            grp.Pie.OtherOffset = 0
            grp.Pie.InnerRadius = 65

            Dim dat As ChartData = grp.ChartData
            dat.SeriesList.Clear()

            Dim ColorValue() As Color = {Color.OrangeRed, Color.Tan, Color.LightGreen, Color.MediumTurquoise,
                                         Color.DodgerBlue, Color.Magenta, Color.GreenYellow, Color.MediumBlue}

            For Each item In querySector
                valueItem = _valueLabel(item.Value)
                valueSisa -= valueItem

                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, valueItem)
                series.LineStyle.Color = ColorValue(slice Mod 8)
                stringLabel = GetSimpiTerm(item.Sector, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
                series.Label = GlobalString.CamelCase(stringLabel) & " " & valueItem.ToString("n2") & "%"
                slice += 1
            Next

            If valueSisa > 0 Then
                Dim series As ChartDataSeries = dat.SeriesList.AddNewSeries()
                series.PointData.Length = 1
                series.PointData(0) = New PointF(1.0F, valueSisa)
                series.LineStyle.Color = ColorValue(slice Mod 8)
                stringLabel = GetSimpiTerm("Others", IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
                series.Label = GlobalString.CamelCase(stringLabel) & " " & valueSisa.ToString("n2") & "%"
            End If

            chartSector.Legend.Visible = True
            chartSector.Legend.Compass = CompassEnum.East
            chartSector.ChartGroups(0).ShowOutline = False
        End If
    End Sub

#End Region

#Region "performance"
    Private Sub chkRebase_CheckedChanged(sender As Object, e As EventArgs) Handles chkRebase.CheckedChanged
        DisplayPerformancePortfolio()
    End Sub

    Private Sub chkReplace_CheckedChanged(sender As Object, e As EventArgs) Handles chkReplace.CheckedChanged
        DisplayPerformancePortfolio()
        ReplaceBenchmark()
    End Sub

    Private Sub rbNAVUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbNAVUnit.SelectedIndexChanged
        If rbNAVUnit.Checked Then DisplayPerformancePortfolio()
    End Sub

    Private Sub rbReturn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbReturn.SelectedIndexChanged
        If rbReturn.Checked Then DisplayPerformancePortfolio()
    End Sub

    Private Sub rbInception_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbInception.SelectedIndexChanged
        If rbInception.Checked Then DisplayPerformancePortfolio()
    End Sub

    Private Sub rbYTD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbYTD.SelectedIndexChanged
        If rbYTD.Checked Then DisplayPerformancePortfolio()
    End Sub

    Private Sub rbOneYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbOneYear.SelectedIndexChanged
        If rbOneYear.Checked Then DisplayPerformancePortfolio()
    End Sub

    Private Sub rbYearOne_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbYearOne.SelectedIndexChanged
        If rbYearOne.Checked Then DisplayPerformanceMonthly()
    End Sub

    Private Sub rbYearThis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbYearThis.SelectedIndexChanged
        If rbYearThis.Checked Then DisplayPerformanceMonthly()
    End Sub

    Private Sub txtBenchmark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBenchmark.KeyDown
        If e.KeyCode = Keys.Enter Then
            DisplayPerformancePortfolio()
            DisplayPerformanceMonthly()
            ReplaceBenchmark()
        End If
    End Sub

    Private Sub btnSettingPortfolio_Click(sender As Object, e As EventArgs) Handles btnSettingPortfolio.Click
        Dim pg As New PropertyGrid()
        pg.SelectedObject = chartPortfolio
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As New Form()
        f.Text = "Portfolio vs Benchmark"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
    End Sub

    Private Sub btnSettingMonthly_Click(sender As Object, e As EventArgs) Handles btnSettingMonthly.Click
        Dim pg As New PropertyGrid()
        pg.SelectedObject = chartMonthly
        pg.Dock = DockStyle.Fill
        pg.Size = New Size(100, 300)

        Dim f As New Form()
        f.Text = "Portfolio Monthly Return"
        f.Controls.Add(pg)
        f.Icon = My.Resources.icon
        f.ShowDialog()
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
            fgPerformance.Cols(0).Width = 75
            fgPerformance.Cols(1).Width = 40
            fgPerformance.Cols(2).Width = 40
            fgPerformance.Cols(3).Width = 40
            fgPerformance.Cols(4).Width = 40
            fgPerformance.Cols(5).Width = 40
            fgPerformance.Cols(6).Width = 40
            fgPerformance.Cols(7).Width = 40
            fgPerformance.Cols(8).Width = 40
            fgPerformance.Cols(9).Width = 40
            fgPerformance.Cols(10).Width = 40
            fgPerformance.Cols(11).Width = 40
            fgPerformance.Cols(12).Width = 40
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
            fgWeek.Cols(0).Width = 75
            fgWeek.Cols(1).Width = 45
            fgWeek.Cols(2).Width = 45
            fgWeek.Cols(3).Width = 45
            fgWeek.Cols(4).Width = 45
        End With
    End Sub

    Private Sub DisplayPerformance()
        DisplayPerformanceSummary
        DisplayPerformanceTable()
        DisplayPerformanceWeek()
        DisplayPerformanceMonthly()
        DisplayPerformancePortfolio()
    End Sub

    Private Sub DisplayPerformanceSummary()
        lblReturnInception.Text = (objReturn.GetrInception * 100).ToString("n2")
        Dim query1 = (From q1 In dtMonthly.AsEnumerable Order By q1.Field(Of Decimal)("Return") Descending
                      Select PositionDate = q1.Field(Of Date)("Date"), Monthly = q1.Field(Of Decimal)("Return")).Take(1)
        lblReturnBestReturn.Text = (query1.ToList(0).Monthly * 100).ToString("n2")
        lblReturnBestMonth.Text = query1.ToList(0).PositionDate.ToString("MMM-yy")


        Dim query2 = (From q2 In dtMonthly.AsEnumerable Order By q2.Field(Of Decimal)("Return") Ascending
                      Select PositionDate = q2.Field(Of Date)("Date"), Monthly = q2.Field(Of Decimal)("Return")).Take(1)
        lblReturnWorstReturn.Text = (query2.ToList(0).Monthly * 100).ToString("n2")
        lblReturnWorstMonth.Text = query2.ToList(0).PositionDate.ToString("MMM-yy")

        Dim query3 = (From q3 In dtMonthly.AsEnumerable
                      Where q3.Field(Of Date)("Date") <= dtAs.Value And q3.Field(Of Date)("Date") >= dtAs.Value.AddYears(-1)
                      Order By q3.Field(Of Decimal)("Return") Descending
                      Select PositionDate = q3.Field(Of Date)("Date"), Monthly = q3.Field(Of Decimal)("Return")).Take(1)
        lblReturnBestYear.Text = (query3.ToList(0).Monthly * 100).ToString("n2")
        lblReturnStdDev.Text = (StdDev((From q4 In dtMonthly.AsEnumerable Select CDbl(q4.Field(Of Decimal)("Return"))).ToArray) * Math.Sqrt(12) * 100).ToString("n2")
        lblReturnBeta.Text = "" 'Slope(return, benchmark)
    End Sub

    Private Sub DisplayPerformanceWeek()
        Dim dtDate() As Date = GlobalDate.MonthWeek(dtAs.Value)
        Dim LastDate As Date = New Date(dtAs.Value.Year, dtAs.Value.Month, 1)
        Dim r As Double = 0
        LastDate = LastDate.AddDays(-1)
        With fgWeek
            .Rows.Count = 3
            If dtDate.Length > 4 Then .Cols.Count = 6 Else .Cols.Count = 5
            .ExtendLastCol = False

            fgWeek(0, 1) = dtDate(0).ToString("dd-MMM")
            objNAV1.LoadLast(objPortfolio, LastDate)
            objNAV2.LoadLast(objPortfolio, dtDate(0))
            If objNAV1.ErrID = 0 And objNAV1.GetGeometricIndex <> 0 Then
                r = ((objNAV2.GetGeometricIndex / objNAV1.GetGeometricIndex) - 1) * 100
                fgWeek(1, 1) = r.ToString("n2")
            Else
                fgWeek(1, 1) = 0.ToString("n2")
            End If

            fgWeek(0, 2) = dtDate(1).ToString("dd-MMM")
            objNAV1.LoadLast(objPortfolio, dtDate(1))
            If objNAV2.ErrID = 0 And objNAV2.GetGeometricIndex <> 0 Then
                r = ((objNAV1.GetGeometricIndex / objNAV2.GetGeometricIndex) - 1) * 100
                fgWeek(1, 2) = r.ToString("n2")
            Else
                fgWeek(1, 2) = 0.ToString("n2")
            End If

            fgWeek(0, 3) = dtDate(2).ToString("dd-MMM")
            objNAV2.LoadLast(objPortfolio, dtDate(2))
            If objNAV1.ErrID = 0 And objNAV1.GetGeometricIndex <> 0 Then
                r = ((objNAV2.GetGeometricIndex / objNAV1.GetGeometricIndex) - 1) * 100
                fgWeek(1, 3) = r.ToString("n2")
            Else
                fgWeek(1, 3) = 0.ToString("n2")
            End If

            fgWeek(0, 4) = dtDate(3).ToString("dd-MMM")
            objNAV1.LoadLast(objPortfolio, dtDate(3))
            If objNAV2.ErrID = 0 And objNAV2.GetGeometricIndex <> 0 Then
                r = ((objNAV1.GetGeometricIndex / objNAV2.GetGeometricIndex) - 1) * 100
                fgWeek(1, 4) = r.ToString("n2")
            Else
                fgWeek(1, 4) = 0.ToString("n2")
            End If

            If dtDate.Length > 4 Then
                fgWeek(0, 5) = dtDate(4).ToString("dd-MMM")
                objNAV2.LoadLast(objPortfolio, dtDate(4))
                If objNAV1.ErrID = 0 And objNAV1.GetGeometricIndex <> 0 Then
                    r = ((objNAV2.GetGeometricIndex / objNAV1.GetGeometricIndex) - 1) * 100
                    fgWeek(1, 5) = r.ToString("n2")
                Else
                    fgWeek(1, 5) = 0.ToString("n2")
                End If

                fgWeek.Cols(0).Width = 75
                fgWeek.Cols(1).Width = 45
                fgWeek.Cols(2).Width = 45
                fgWeek.Cols(3).Width = 45
                fgWeek.Cols(4).Width = 45
                fgWeek.Cols(5).Width = 45
            End If
            fgWeek(1, 0) = lblPortfolioCode.Text.Trim
            fgWeek(2, 0) = GetSimpiTerm(lblBenchmark.Text.Trim, IIf(rbOption1.Checked, rbOption1.Text, rbOption2.Text))
        End With

    End Sub

    Private Sub DisplayPerformanceMonthly()
        If dtMonthly IsNot Nothing AndAlso dtMonthly.Rows.Count > 0 Then
            With chartMonthly
                Dim query2 = From q In dtMonthly.AsEnumerable Order By q.Field(Of Date)("Date") Descending
                             Select PositionDate = CDate(q.Field(Of Date)("Date")), Monthly = CDbl(q.Field(Of Decimal)("Return"))
                Dim query As IEnumerable
                If rbYearOne.Checked Then
                    query = From q2 In query2.Take(12) Order By q2.PositionDate Ascending
                            Select PositionDate = CDate(q2.PositionDate).ToString("MMM-yy"), Monthly = CDbl(q2.Monthly)
                Else
                    query = From q2 In query2 Order By q2.PositionDate Ascending
                            Where q2.PositionDate > New Date(dtAs.Value.AddYears(-1).Year, 12, 31)
                            Select PositionDate = CDate(q2.PositionDate).ToString("MMM-yy"), Monthly = CDbl(q2.Monthly)
                End If
                .Reset()
                .ChartGroups(0).ChartType = Chart2DTypeEnum.Bar
                .BackColor = Color.Transparent

                Dim dscoll As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
                dscoll.Clear()

                Dim series As ChartDataSeries = dscoll.AddNewSeries()
                series.PointData.Length = (From n In query).Count
                Dim i As Integer = 0
                For Each item In query
                    series.X(i) = i
                    series.Y(i) = item.Monthly
                    i += 1
                Next
                series.DataLabel.Visible = True
                series.DataLabel.Style.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular)
                series.DataLabel.Compass = LabelCompassEnum.North
                series.DataLabel.Text = "{#YVAL:0.00%}"
                Dim ax As Axis = .ChartArea.AxisX
                ax.AnnoMethod = AnnotationMethodEnum.ValueLabels
                ax.AnnotationRotation = 25
                ax.Thickness = 1

                i = 0
                For Each item In query
                    ax.ValueLabels.Add(i, item.PositionDate)
                    i += 1
                Next
                Dim ay As Axis = .ChartArea.AxisY
                ay.AnnoFormat = FormatEnum.NumericManual
                ay.AnnoFormatString = "p0"
                ay.AutoOrigin = False
                ay.Origin = 0
                ay.Thickness = 1

            End With
        End If
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

    Private Sub DisplayPerformancePortfolio()
        If dtNAV IsNot Nothing AndAlso dtNAV.Rows.Count > 0 Then
            'Dim query = From n In dtNAV.AsEnumerable Join b In dtBenchmark.AsEnumerable
            '            On n.Field(Of Date)("PositionDate") Equals b.Field(Of Date)("PositionDate")
            '            Order By n.Field(Of Date)("PositionDate") Ascending
            '            Select PositionDate = n.Field(Of Date)("PositionDate"),
            '                   NAV = n.Field(Of Decimal)("NAV"), giPortfolio = n.Field(Of Decimal)("GeometricIndex"),
            '                   BenchmarkValue = b.Field(Of Decimal)("BenchmarkValue"), giBenchmark = b.Field(Of Decimal)("GeometricIndex")
            Dim query As IEnumerable
            Dim giAwal As Double = 0
            If rbInception.Checked Then
                query = From n In dtNAV.AsEnumerable Order By n.Field(Of Date)("PositionDate") Ascending
                        Select PositionDate = n.Field(Of Date)("PositionDate"),
                               NAV = n.Field(Of Decimal)("NAVPerUnit"), giPortfolio = n.Field(Of Decimal)("GeometricIndex")
                giAwal = (From q2 In query Select q2).ToList(0).giPortfolio
            ElseIf rbYTD.Checked Then
                query = From n In dtNAV.AsEnumerable Order By n.Field(Of Date)("PositionDate") Ascending
                        Where n.Field(Of Date)("PositionDate") > New Date(dtAs.Value.AddYears(-1).Year, 12, 31)
                        Select PositionDate = n.Field(Of Date)("PositionDate"),
                               NAV = n.Field(Of Decimal)("NAVPerUnit"), giPortfolio = n.Field(Of Decimal)("GeometricIndex")
                giAwal = (From q2 In query Select q2).ToList(0).giPortfolio
            Else
                query = From n In dtNAV.AsEnumerable Order By n.Field(Of Date)("PositionDate") Ascending
                        Where n.Field(Of Date)("PositionDate") > dtAs.Value.AddYears(-1)
                        Select PositionDate = n.Field(Of Date)("PositionDate"),
                               NAV = n.Field(Of Decimal)("NAVPerUnit"), giPortfolio = n.Field(Of Decimal)("GeometricIndex")
                giAwal = (From q2 In query Select q2).ToList(0).giPortfolio
            End If

            With chartPortfolio
                .Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.None
                Dim ds As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
                ds.Clear()
                Dim series As ChartDataSeries = ds.AddNewSeries()
                series.LineStyle.Color = Color.Green
                series.LineStyle.Thickness = 1
                series.SymbolStyle.Shape = SymbolShapeEnum.None
                series.FitType = FitTypeEnum.Line

                series.X.CopyDataIn((From q In query Select CDate(q.PositionDate)).ToArray)
                If rbNAVUnit.Checked Then
                    series.Y.CopyDataIn((From q In query Select CDbl(q.NAV)).ToArray)
                ElseIf chkRebase.Checked Then
                    series.Y.CopyDataIn((From q In query Select (1 + ((CDbl(q.giPortfolio) / giAwal) - 1))).ToArray)
                Else
                    series.Y.CopyDataIn((From q In query Select (CDbl(q.giPortfolio) / giAwal) - 1).ToArray)
                End If
                series.PointData.Length = (From q In query).Count

                .BackColor = Color.Transparent
                .ChartArea.AxisX.Max = (From q In query Select q.PositionDate).Last.ToOADate
                .ChartArea.AxisX.Min = (From q In query Select q.PositionDate).First.ToOADate
                .ChartArea.AxisX.AutoMajor = True
                .ChartArea.AxisX.AutoMinor = True
                .ChartArea.AxisX.AnnoFormat = FormatEnum.DateManual
                .ChartArea.AxisX.AnnoFormatString = "MMM-yy"
                .ChartArea.AxisX.AnnotationRotation = 25
                .ChartArea.AxisX.Origin = .ChartArea.AxisX.Min

                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AutoMax = True
                .ChartArea.AxisY.AutoMin = True
                .ChartArea.AxisY.AutoMajor = True
                .ChartArea.AxisY.AutoMinor = True
                .ChartArea.AxisX.Thickness = 1
                .ChartArea.AxisY.Thickness = 1
                If rbNAVUnit.Checked Then
                    .ChartArea.AxisY.AnnoFormatString = "n0"
                    .ChartArea.AxisY.AutoOrigin = True
                ElseIf chkRebase.Checked Then
                    .ChartArea.AxisY.AnnoFormatString = "p0"
                    .ChartArea.AxisY.Origin = 1
                Else
                    .ChartArea.AxisY.AnnoFormatString = "p0"
                    .ChartArea.AxisY.Origin = 0
                End If

            End With

        End If
    End Sub

#End Region

#Region "market review"
    Private Sub btnReviewAdd_Click(sender As Object, e As EventArgs) Handles btnReviewAdd.Click
        reviewAdd
    End Sub

    Private Sub btnReviewRemove_Click(sender As Object, e As EventArgs) Handles btnReviewRemove.Click
        reviewRemove()
    End Sub

    Private Sub btnReviewClear_Click(sender As Object, e As EventArgs) Handles btnReviewClear.Click
        reviewClear()
    End Sub

    Private Sub btnReviewList_Click(sender As Object, e As EventArgs) Handles btnReviewList.Click
        reviewlist
    End Sub

    Private Sub DisplayReview()
        If objReview.GetReviewID > 0 Then
            lblReviewID.Text = objReview.GetReviewID
            lblReviewDate.Text = objReview.GetReviewDate.ToString("dd-MMM-yyy")
            txtReviewText.Text = objReview.GetReviewText
        End If
    End Sub

    Private Sub reviewClear()
        lblReviewID.Text = ""
        lblReviewDate.Text = ""
        txtReviewText.Text = ""
    End Sub

    Private Sub reviewAdd()
        If objPortfolio.GetPortfolioID > 0 And lblReviewID.Text.Trim = "" And txtReviewText.Text.Trim <> "" Then
            objReview.Clear()
            objReview.Add(objPortfolio, dtAs.Value, txtReviewText.Text)
            If objReview.ErrID <> 0 Then ExceptionMessage.Show(objReview.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub reviewRemove()
        If objPortfolio.GetPortfolioID > 0 And IsNumeric(lblReviewID.Text) Then
            objReview.Clear()
            objReview.Remove(objPortfolio, CInt(lblReviewID.Text))
            If objReview.ErrID = 0 Then
                objReview.Clear()
                objReview.Load(objPortfolio, objNAV.GetPositionDate)
                DisplayReview()
            Else
                ExceptionMessage.Show(objReview.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub reviewList()
        If objPortfolio.GetPortfolioID > 0 Then
            Dim form As New FundSheetMarketReview
            form.lblID = lblReviewID
            form.lblDate = lblReviewDate
            form.txtReview = txtReviewText
            form.objPortfolio = objPortfolio
            form.Show()
            form.MdiParent = MDIMIS
            lblReviewID.Text = ""
            lblReviewDate.Text = ""
            txtReviewText.Text = ""
        End If
    End Sub

#End Region

#Region "pdf, email & setting"

#End Region

End Class