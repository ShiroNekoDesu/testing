Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports C1.Win.C1Chart

Public Class ReportFundOutstanding
    Dim objPortfolio As New simpi.MasterPortfolio.MasterPortfolio
    Dim objSimpi As New simpi.MasterSimpi.MasterSimpi
    Dim objCodeset As New simpi.MasterPortfolio.PortfolioCodeset
    Dim objCapital As New PositionCapital
    Dim objNAV As New PortfolioNAV

    Dim MaximumUnit As Double = 0
    Dim unit As Double = 0
    Dim dtOutstanding As New DataTable
    Private Sub ReportFundOutstanding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetClientMaster()
        GetSalesMaster()
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objCodeset.UserAccess = objAccess
        objCapital.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        DBGOutstanding.FetchRowStyles = True
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
        SummaryClear()
        DBGOutstanding.Columns.Clear()
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
                    Dim tmp = objCodeset.GetCodeset(objPortfolio, "MAXIMUM UNIT")
                    If tmp Is Nothing Or tmp.ToString.Trim = "" Then
                        MaximumUnit = 0
                    Else
                        MaximumUnit = tmp
                    End If
                    lblMaximumUnit.Text = MaximumUnit.ToString("n0")
                Else
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
            objNAV.LoadAt(objPortfolio, dtAs.Value)
            lblUnitPrice.Text = objNAV.GetNAVPerUnit.ToString("n4")

            objCapital.Clear()
            dtOutstanding = objCapital.Search(objPortfolio, dtAs.Value)
            SummaryClear()
            DBGOutstanding.Columns.Clear()
            If objCapital.ErrID = 0 Then
                DisplayOutstanding()
                Summary00()
                Summary05()
                Summary10()
                Summary20()
                SummaryTotal()
                SummaryLocal()
                SummaryForeign()
                LoadSummaryPieChart()
                LoadGraphicChart()
            Else
                ExceptionMessage.Show(objCapital.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ExceptionMessage.Show(objError.Message(81) & " master portfolio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DBGOutstanding_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGOutstanding.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGOutstanding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGOutstanding.Click
        If DBGOutstanding.RowCount > 0 Then DBGOutstanding.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

    Private Sub DisplayOutstanding()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable
                        Join c In dtClientMaster.AsEnumerable
                               On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Join s In dtSalesMaster.AsEnumerable
                               On c.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                        Select ID = c.Field(Of Integer)("ClientID"),
                               CIF = c.Field(Of String)("ClientCode"),
                               Name = c.Field(Of String)("ClientName"),
                               Sales = s.Field(Of String)("SalesCode"),
                               LF = c.Field(Of String)("LF"),
                               Unit = u.Field(Of Decimal)("UnitBalance"),
                               Persen = SetPersen(u.Field(Of Decimal)("UnitBalance")),
                               Value = u.Field(Of Decimal)("UnitValue"),
                               Cost = u.Field(Of Decimal)("CostPrice"),
                               PL = u.Field(Of Decimal)("UnitPrice") - u.Field(Of Decimal)("CostPrice")

            With DBGOutstanding
                .AllowSort = False
                .AllowArrows = True
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                .Columns("Unit").NumberFormat = "n4"
                .Columns("Persen").NumberFormat = "n2"
                .Columns("Value").NumberFormat = "n0"
                .Columns("Cost").NumberFormat = "n4"
                .Columns("PL").NumberFormat = "n4"

                .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("CIF").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Sales").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("LF").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Persen").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Value").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Cost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("PL").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("CIF").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Sales").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("LF").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Persen").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Value").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("PL").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Columns("Persen").Caption = "%"

            End With
            For Each column As C1DisplayColumn In DBGOutstanding.Splits(0).DisplayColumns
                column.AutoSize()
            Next

        End If
    End Sub

    Private Sub SummaryTotal()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            unit = (From u In dtOutstanding.AsEnumerable Select u.Field(Of Decimal)("UnitBalance")).Sum()
            lblClientTotal.Text = dtOutstanding.Rows.Count
            lblUnitTotal.Text = unit.ToString("n4")
            lblPersenTotal.Text = SetPersen(unit).ToString("n2")
            lblValueTotal.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub SummaryLocal()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable Join c In dtClientMaster.AsEnumerable
                        On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "L" Select u.Field(Of Decimal)("UnitBalance")
            lblClientLocal.Text = query.Count
            unit = query.Sum()
            lblUnitLocal.Text = unit.ToString("n4")
            lblPersenLocal.Text = SetPersen(unit).ToString("n2")
            lblValueLocal.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub SummaryForeign()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable Join c In dtClientMaster.AsEnumerable
                        On u.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                        Where c.Field(Of String)("LF") = "L" Select u.Field(Of Decimal)("UnitBalance")
            lblClientForeign.Text = query.Count
            unit = query.Sum()
            lblUnitForeign.Text = unit.ToString("n4")
            lblPersenForeign.Text = SetPersen(unit).ToString("n2")
            lblValueForeign.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub Summary00()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable
                        Where SetPersen(u.Field(Of Decimal)("UnitBalance")) <= 0.5D
                        Select u.Field(Of Decimal)("UnitBalance")
            lblClient00.Text = query.Count
            unit = query.Sum()
            lblUnit00.Text = unit.ToString("n4")
            lblPersen00.Text = SetPersen(unit).ToString("n2")
            lblValue00.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub Summary05()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable
                        Where SetPersen(u.Field(Of Decimal)("UnitBalance")) > 0.5D And
                              SetPersen(u.Field(Of Decimal)("UnitBalance")) <= 1D
                        Select u.Field(Of Decimal)("UnitBalance")
            lblClient05.Text = query.Count
            unit = query.Sum()
            lblUnit05.Text = unit.ToString("n4")
            lblPersen05.Text = SetPersen(unit).ToString("n2")
            lblValue05.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub Summary10()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable
                        Where SetPersen(u.Field(Of Decimal)("UnitBalance")) > 1D And
                              SetPersen(u.Field(Of Decimal)("UnitBalance")) <= 2D
                        Select u.Field(Of Decimal)("UnitBalance")
            lblClient10.Text = query.Count
            unit = query.Sum()
            lblUnit10.Text = unit.ToString("n4")
            lblPersen10.Text = SetPersen(unit).ToString("n2")
            lblValue10.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Sub Summary20()
        If dtOutstanding IsNot Nothing And dtOutstanding.Rows.Count > 0 Then
            Dim query = From u In dtOutstanding.AsEnumerable
                        Where SetPersen(u.Field(Of Decimal)("UnitBalance")) > 2D
                        Select u.Field(Of Decimal)("UnitBalance")
            lblClient20.Text = query.Count
            unit = query.Sum()
            lblUnit20.Text = unit.ToString("n4")
            lblPersen20.Text = SetPersen(unit).ToString("n2")
            lblValue20.Text = (unit * CDbl(lblUnitPrice.Text)).ToString("n0")
        End If
    End Sub

    Private Function SetPersen(ByVal value As Double) As Double
        If MaximumUnit = 0 Then Return 0 Else Return value * 100 / MaximumUnit
    End Function

    Private Sub SummaryClear()
        lblClient20.Text = "0"
        lblClient10.Text = "0"
        lblClient05.Text = "0"
        lblClient00.Text = "0"
        lblClientTotal.Text = "0"
        lblClientLocal.Text = "0"
        lblClientForeign.Text = "0"

        lblUnit20.Text = "0.0000"
        lblUnit10.Text = "0.0000"
        lblUnit05.Text = "0.0000"
        lblUnit00.Text = "0.0000"
        lblUnitTotal.Text = "0.0000"
        lblUnitLocal.Text = "0.0000"
        lblUnitForeign.Text = "0.0000"

        lblPersen20.Text = "0.00"
        lblPersen10.Text = "0.00"
        lblPersen05.Text = "0.00"
        lblPersen00.Text = "0.00"
        lblPersenTotal.Text = "0.00"
        lblPersenLocal.Text = "0.00"
        lblPersenForeign.Text = "0.00"

        lblValue20.Text = "0.00"
        lblValue10.Text = "0.00"
        lblValue05.Text = "0.00"
        lblValue00.Text = "0.00"
        lblValueTotal.Text = "0.00"
        lblValueLocal.Text = "0.00"
        lblValueForeign.Text = "0.00"
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGOutstanding, "ReportFO.xls")
    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        ReportEmail()
    End Sub

    Private Sub ReportEmail()
        If DBGOutstanding.RowCount > 0 Then
            Dim frm As New ReportFundOustandingEmail
            frm.Show()
            frm.frm = Me
            frm.MdiParent = MDIMIS
        End If
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click

    End Sub

    Private Sub LoadSummaryPieChart()
        Try
            ' Set chart type 
            C1Chart1.ChartArea.Inverted = True
            C1Chart1.ChartGroups(0).ChartType = C1.Win.C1Chart.Chart2DTypeEnum.Pie
            ' Clear previous data 
            C1Chart1.ChartGroups(0).ChartData.SeriesList.Clear()
            ' Add Data 
            Dim SummaryPersentageNames As String() = {"Foreign", "Local", "N/A"}
            Dim local, foreign As Double
            Double.TryParse(lblPersenLocal.Text, local)
            Double.TryParse(lblPersenForeign.Text, foreign)
            Dim PriceX As Double() = {foreign / 100, local / 100, (100 - local - foreign) / 100}
            'get series collection 
            Dim dscoll As ChartDataSeriesCollection = C1Chart1.ChartGroups(0).ChartData.SeriesList
            For i As Integer = 0 To PriceX.Length - 1
                'populate the series 
                Dim series As ChartDataSeries = dscoll.AddNewSeries()
                'Add one point to show one pie 
                series.PointData.Length = 1
                'Assign the prices to the Y Data series 
                series.Y(0) = PriceX(i)
                'format the product name and product price on the legend 
                series.Label = String.Format("{0} ({1:0.00%})", SummaryPersentageNames(i), PriceX(i))
            Next
            ' show pie Legend 
            C1Chart1.Legend.Visible = True
            'add a title to the chart legend 
            C1Chart1.Legend.Text = "Summary"

            'C1Chart1.SaveImage(fileNamePie, Imaging.ImageFormat.Bmp)
            'Process.Start(fileNamePie)
        Catch ex As Exception
            MessageBox.Show("Error Load Pie Chart " + ex.Message)
        End Try

    End Sub

    Private Sub LoadGraphicChart()
        Try
            C1Chart2.ChartGroups(0).ChartData.SeriesList.Clear()
            ' Data 
            Dim items As String() = New String() {"< 0.50%", "0.50% - 1.00%", "1.00% - 2.00%", "> 2.00%"}
            Dim unitHData As Double() = New Double() {7 / 100, 0, 0, 1 / 100}

            ' Create first series 
            Dim unitH As C1.Win.C1Chart.ChartDataSeries = C1Chart2.ChartGroups(0).ChartData.SeriesList.AddNewSeries()
            unitH.Label = "Unit Holder"
            unitH.LineStyle.Color = Color.MediumPurple
            unitH.X.CopyDataIn(items)
            unitH.Y.CopyDataIn(unitHData)
            ' Set chart type 
            C1Chart2.ChartGroups(0).ChartType = C1.Win.C1Chart.Chart2DTypeEnum.Bar
            C1Chart2.ChartGroups(0).Stacked = True
            ' Set y-axis minimum 
            C1Chart2.ChartArea.AxisY.Min = 0
            'C1Chart2.Legend.Visible = True
            ' Remove the Axes caption 
            C1Chart2.ChartArea.AxisX.Text = "Percentage Unitholder Group"
            C1Chart2.ChartArea.AxisY.Text = ""

            'C1Chart2.SaveImage(fileNameBar, System.Drawing.Imaging.ImageFormat.Bmp)
            'Process.Start(fileNameBar)
        Catch ex As Exception
            MessageBox.Show("Error Load Pie Chart " + ex.Message)
        End Try

    End Sub

End Class

