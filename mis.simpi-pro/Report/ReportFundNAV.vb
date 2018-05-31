Imports C1.Win.C1Chart
Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSimpi

Public Class ReportFundNAV
    Dim objPortfolio As New MasterPortfolio
    Dim objSimpi As New MasterSimpi
    Dim objNAV As New PortfolioNAV
    Dim dtData As New DataTable
    Dim dtFilter As New DataTable
    Dim dtDisplay As New DataTable
    Dim dv As New DataView
    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim isChart As Boolean = False
    Dim PortfolioID As Integer()

    Private Sub ReportFundNAV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParameterPortfolioAssetType()
        GetParameterCountry()
        GetPortfolioSimpi()
        PortfolioID = (From p In dtPortfolioSimpi Select p.Field(Of Integer)("PortfolioID")).ToArray
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        DBGFund.FetchRowStyles = True
        DBGData.FetchRowStyles = True
        dtAs.Value = Now
        dtFrom.Value = New Date(Now.Year, 1, 1)
        dtTo.Value = Now
    End Sub

#Region "list of fund"
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DisplayNAV()
    End Sub

    Private Sub DisplayNAV()
        Dim dtNAV As New DataTable
        objNAV.Clear()
        dtNAV = objNAV.Search(PortfolioID, dtAs.Value)
        Dim query = From u In dtNAV.AsEnumerable
                    Join p In dtPortfolioSimpi.AsEnumerable
                               On u.Field(Of Integer)("PortfolioID") Equals p.Field(Of Integer)("PortfolioID")
                    Join a In dtParameterPortfolioAsset.AsEnumerable
                               On p.Field(Of Integer)("AssetTypeID") Equals a.Field(Of Integer)("AssetTypeID")
                    Join c In dtParameterCountry.AsEnumerable
                               On p.Field(Of Integer)("CcyID") Equals c.Field(Of Integer)("CountryID")
                    Select ID = p.Field(Of Integer)("PortfolioID"),
                           Code = p.Field(Of String)("PortfolioCode"),
                           Name = p.Field(Of String)("PortfolioNameshort"),
                           AssetType = a.Field(Of String)("AssetTypeCode"),
                           Ccy = c.Field(Of String)("Ccy"),
                           NAV = u.Field(Of Decimal)("NAV"),
                           Price = u.Field(Of Decimal)("NAVperUnit"),
                           Unit = u.Field(Of Decimal)("TotalUnit")

        lblAUM.Text = (From q In query Select q.NAV).Sum.ToString("n2")
        With DBGFund
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = query.ToList

            .Columns("Unit").NumberFormat = "n4"
            .Columns("Price").NumberFormat = "n4"
            .Columns("NAV").NumberFormat = "n0"

            .Splits(0).DisplayColumns("ID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Code").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Name").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("AssetType").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Ccy").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Price").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAV").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            .Splits(0).DisplayColumns("ID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Code").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            .Splits(0).DisplayColumns("AssetType").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Ccy").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Splits(0).DisplayColumns("Price").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("NAV").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

            .Columns("AssetType").Caption = "Type"
            .Columns("Price").Caption = "NAV/Unit"

            For Each column As C1DisplayColumn In DBGFund.Splits(0).DisplayColumns
                column.AutoSize()
            Next
        End With

    End Sub

    Private Sub DBGFund_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGFund.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGFund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGFund.Click
        If DBGFund.RowCount > 0 And DBGFund.Row > 0 Then DBGFund.MarqueeStyle = MarqueeEnum.HighlightRow
    End Sub

#End Region

#Region "list of nav"
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
                If objPortfolio.ErrID <> 0 Then ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnSearchNAV_Click(sender As Object, e As EventArgs) Handles btnSearchNAV.Click
        DataLoad()
    End Sub

    Private Sub DataLoad()
        If objPortfolio.GetPortfolioID > 0 Then
            objNAV.Clear()
            dtData = objNAV.SearchHistory(objPortfolio, dtFrom.Value, dtTo.Value)
            If objNAV.ErrID = 0 Then
                DataFilter()
            Else
                ExceptionMessage.Show(objNAV.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DataClear()
            End If
        End If
    End Sub

    Private Sub DataClear()
        dtData.Columns.Clear()
        dtDisplay.Columns.Clear()
        DisplayClear()
    End Sub

    Private Sub DisplayClear()
        dtFilter.Columns.Clear()
        DBGData.Columns.Clear()
        chartData.ChartGroups(0).ChartData.SeriesList.RemoveAll()
        chartData.ChartLabels.LabelsCollection.RemoveAll()
        isChart = False
    End Sub

    Private Sub DataCreate()
        dtFilter.Columns.Add("PositionDate", GetType(DateTime))
        dtFilter.Columns.Add("NAV", GetType(Double))
        dtFilter.Columns.Add("NAVPerUnit", GetType(Double))
        dtFilter.Columns.Add("TotalUnit", GetType(Double))
    End Sub

    Private Sub DataFilter()
        If dtData.Rows.Count > 1 Then
            Dim p1 As Double = 1
            Dim row1 As DataRow
            DisplayClear()
            If rbTimeDaily.Checked Then
                dtFilter = dtData.Copy
            ElseIf rbTimeWeekly.Checked Then
                DataCreate()
                dtFilter.Clear()
                For i As Integer = 0 To dtData.Rows.Count - 1
                    row1 = dtData.Rows(i)
                    If Format(row1("PositionDate"), "ddd") = Format(dtTo.Value, "ddd") Then
                        dtFilter.ImportRow(row1)
                    End If
                Next
            ElseIf rbTimeMonthly.Checked Then
                DataCreate()
                dtFilter.Clear()
                For i As Integer = 0 To dtData.Rows.Count - 1
                    row1 = dtData.Rows(i)
                    If Format(row1("PositionDate"), "dd") = Format(dtTo.Value, "dd") Then
                        dtFilter.ImportRow(row1)
                    End If
                Next
            Else
                dtFilter = dtData.Copy
            End If

            Dim strLabel As String = ""
            Dim Netflow As Double = 0
            If rbPrice.Checked Then
                dtDisplay = dtFilter.DefaultView.ToTable("price", True, "PositionDate", "NAVPerUnit")
                dtDisplay.Columns("NAVPerUnit").ColumnName = "Price"
                strLabel = "Price"
            ElseIf rbNAV.Checked Then
                dtDisplay = dtFilter.DefaultView.ToTable("price", True, "PositionDate", "NAV")
                dtDisplay.Columns("NAV").ColumnName = "AUM"
                strLabel = "AUM"
            ElseIf rbUnit.Checked Then
                dtDisplay = dtFilter.DefaultView.ToTable("price", True, "PositionDate", "TotalUnit")
                dtDisplay.Columns("TotalUnit").ColumnName = "Units"
                strLabel = "Units"
            Else
                dtDisplay = dtFilter.DefaultView.ToTable("price", True, "PositionDate", "NAVPerUnit")
                dtDisplay.Columns("NAVPerUnit").ColumnName = "Price"
                strLabel = "Price"
            End If
            dtDisplay.Columns("PositionDate").ColumnName = "Date"

            DataGrid()
            DataChart(strLabel, p1)
        Else
            ExceptionMessage.Show("System can found historical data of " & objPortfolio.GetPortfolioCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataClear()
        End If
    End Sub

    Private Sub DataGrid()
        With DBGData
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Style.WrapText = False
            .Columns.Clear()
            .DataSource = dtDisplay
            Dim No, Closing As C1DisplayColumn
            .Columns("Date").NumberFormat = "dd-MMM-yy"
            No = .Splits(0).DisplayColumns("Date")
            If rbPrice.Checked Then
                .Columns("Price").NumberFormat = "n4"
                Closing = .Splits(0).DisplayColumns("Price")
            ElseIf rbNAV.Checked Then
                .Columns("AUM").NumberFormat = "n2"
                Closing = .Splits(0).DisplayColumns("AUM")
            ElseIf rbUnit.Checked Then
                .Columns("Units").NumberFormat = "n4"
                Closing = .Splits(0).DisplayColumns("Units")
            Else
                .Columns("Price").NumberFormat = "n4"
                Closing = .Splits(0).DisplayColumns("Price")
            End If
            No.Width = 65
            Closing.Width = 75
        End With
    End Sub

    Private Sub DataChart(ByVal strLabel As String, Optional ByVal pI As Double = 1)
        With chartData
            .ChartArea.AxisY.Text = strLabel.ToUpper
            .ChartArea.AxisX.Text = ""

            Dim ds As ChartDataSeriesCollection = .ChartGroups(0).ChartData.SeriesList
            ds.Clear()

            Dim series As ChartDataSeries = ds.AddNewSeries()
            series.Label = strLabel
            series.LineStyle.Color = Color.Green
            series.LineStyle.Thickness = 2
            series.SymbolStyle.Shape = SymbolShapeEnum.None
            series.FitType = FitTypeEnum.Line

            Dim fundData1 As New DataView(dtDisplay)
            series.PointData.Length = fundData1.Count
            For i As Integer = 0 To fundData1.Count - 1
                series.X(i) = fundData1(i)("Date")

                If rbPrice.Checked Then
                    series.Y(i) = fundData1(i)("Price")
                ElseIf rbNAV.Checked Then
                    series.Y(i) = fundData1(i)("AUM")
                ElseIf rbUnit.Checked Then
                    series.Y(i) = fundData1(i)("Units")
                Else
                    series.Y(i) = fundData1(i)("Price")
                End If

            Next i
            isChart = True
            .BackColor = Color.Transparent
            .ChartArea.AxisX.AutoMax = True
            .ChartArea.AxisX.AutoMin = True
            .ChartArea.AxisX.AutoMajor = True
            .ChartArea.AxisX.AutoMinor = True
            .ChartArea.AxisY.AutoMax = True
            .ChartArea.AxisY.AutoMin = True
            .ChartArea.AxisY.AutoMajor = True
            .ChartArea.AxisY.AutoMinor = True
            .ChartArea.AxisX.AnnoFormat = FormatEnum.DateManual
            .ChartArea.AxisX.AnnoFormatString = "MMM-yy"
            If rbPrice.Checked Then
                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AnnoFormatString = "n0"
            ElseIf rbNAV.Checked Then
                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AnnoFormatString = "n0"
            ElseIf rbUnit.Checked Then
                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AnnoFormatString = "n0"
            Else
                .ChartArea.AxisY.AnnoFormat = FormatEnum.NumericManual
                .ChartArea.AxisY.AnnoFormatString = "n0"
            End If


        End With
    End Sub

    Private Sub chartData_MouseMove(sender As Object, e As MouseEventArgs) Handles chartData.MouseMove
        If isChart Then
            x = e.X
            y = e.Y
            Dim X__1 As Single = 0.0F, Y__2 As Single = 0.0F

            chartData.ChartArea.AxisX.AutoMax = False
            chartData.ChartArea.AxisX.AutoMin = False
            chartData.ChartArea.AxisY.AutoMax = False
            chartData.ChartArea.AxisY.AutoMin = False

            'Add series
            chartData.ChartGroups(0).ChartData.SeriesList.AddNewSeries()
            chartData.ChartGroups(0).ChartData.SeriesList.AddNewSeries()

            'Populate the series with X and Y Values
            chartData.ChartGroups(0).CoordToDataCoord(x, y, X__1, Y__2)
            Dim xSerHorz As Double() = New Double(2) {CDbl(chartData.ChartArea.AxisX.Min), CDbl(X__1), CDbl(chartData.ChartArea.AxisX.Max)}
            Dim ySerHorz As Double() = New Double(2) {CDbl(Y__2), CDbl(Y__2), CDbl(Y__2)}
            Dim xSerVert As Double() = New Double(2) {CDbl(X__1), CDbl(X__1), CDbl(X__1)}
            Dim ySerVert As Double() = New Double(2) {CDbl(chartData.ChartArea.AxisY.Min), CDbl(Y__2), CDbl(chartData.ChartArea.AxisY.Max)}
            chartData.ChartGroups(0).ChartData.SeriesList(1).X.CopyDataIn(xSerHorz)
            chartData.ChartGroups(0).ChartData.SeriesList(1).Y.CopyDataIn(ySerHorz)
            chartData.ChartGroups(0).ChartData.SeriesList(2).X.CopyDataIn(xSerVert)
            chartData.ChartGroups(0).ChartData.SeriesList(2).Y.CopyDataIn(ySerVert)

            'Style the Series
            chartData.ChartGroups(0).ChartData.SeriesList(1).SymbolStyle.Shape = SymbolShapeEnum.DiagCross
            chartData.ChartGroups(0).ChartData.SeriesList(1).SymbolStyle.Color = Color.Orange
            chartData.ChartGroups(0).ChartData.SeriesList(1).SymbolStyle.OutlineColor = Color.Orange
            chartData.ChartGroups(0).ChartData.SeriesList(1).SymbolStyle.Size = 3
            chartData.ChartGroups(0).ChartData.SeriesList(1).LineStyle.Color = Color.Red
            chartData.ChartGroups(0).ChartData.SeriesList(1).LineStyle.Thickness = 2

            chartData.ChartGroups(0).ChartData.SeriesList(2).SymbolStyle.Shape = SymbolShapeEnum.DiagCross
            chartData.ChartGroups(0).ChartData.SeriesList(2).SymbolStyle.Color = Color.Orange
            chartData.ChartGroups(0).ChartData.SeriesList(2).SymbolStyle.OutlineColor = Color.Orange
            chartData.ChartGroups(0).ChartData.SeriesList(2).SymbolStyle.Size = 3
            chartData.ChartGroups(0).ChartData.SeriesList(2).LineStyle.Color = Color.Red
            chartData.ChartGroups(0).ChartData.SeriesList(2).LineStyle.Thickness = 2


            chartData.ToolTip.Enabled = True
            chartData.Visible = True

            'Attach a Chart Label with the Coordinate to display the value of the point under the cross-hair cursor
            chartData.ChartLabels.LabelsCollection.AddNewLabel()
            chartData.ChartLabels.LabelsCollection(0).AttachMethod = AttachMethodEnum.Coordinate
            chartData.ChartLabels.LabelsCollection(0).AttachMethodData.X = x
            chartData.ChartLabels.LabelsCollection(0).AttachMethodData.Y = y - 8
            If rbPrice.Checked Then
                chartData.ChartLabels.LabelsCollection(0).Text = "Date: " + Date.FromOADate(X__1).ToString("dd-MMM-yy") + ", Price: " + Y__2.ToString()
            ElseIf rbNAV.Checked Then
                chartData.ChartLabels.LabelsCollection(0).Text = "Date: " + Date.FromOADate(X__1).ToString("dd-MMM-yy") + ", AUM: " + Y__2.ToString()
            ElseIf rbUnit.Checked Then
                chartData.ChartLabels.LabelsCollection(0).Text = "Date: " + Date.FromOADate(X__1).ToString("dd-MMM-yy") + ", Units: " + Y__2.ToString()
            Else
                chartData.ChartLabels.LabelsCollection(0).Text = "Date: " + Date.FromOADate(X__1).ToString("dd-MMM-yy") + ", Price: " + Y__2.ToString()
            End If
            chartData.ChartLabels.LabelsCollection(0).Visible = True
            chartData.ChartLabels.DefaultLabelStyle.BackColor = Color.Red
        End If

    End Sub

    Private Sub chartData_MouseLeave(sender As Object, e As EventArgs) Handles chartData.MouseLeave
        If dtData.Rows.Count > 1 And chartData.ChartGroups(0).ChartData.SeriesList.Count > 2 Then
            chartData.ChartGroups(0).ChartData.SeriesList.RemoveAt(2)
            chartData.ChartGroups(0).ChartData.SeriesList.RemoveAt(1)
            chartData.ChartLabels.LabelsCollection.RemoveAll()
        End If
    End Sub

    Private Sub DBGData_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGData.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub rbDataPrice_CheckedChanged(sender As Object, e As EventArgs) Handles rbPrice.CheckedChanged
        If rbPrice.Checked Then DataFilter()
    End Sub

    Private Sub rbDataValue_CheckedChanged(sender As Object, e As EventArgs) Handles rbNAV.CheckedChanged
        If rbNAV.Checked Then DataFilter()
    End Sub

    Private Sub rbDataShare_CheckedChanged(sender As Object, e As EventArgs) Handles rbUnit.CheckedChanged
        If rbUnit.Checked Then DataFilter()
    End Sub

    Private Sub rbTimeDaily_CheckedChanged(sender As Object, e As EventArgs) Handles rbTimeDaily.CheckedChanged
        If rbTimeDaily.Checked Then DataFilter()
    End Sub

    Private Sub rbTimeMonthly_CheckedChanged(sender As Object, e As EventArgs) Handles rbTimeMonthly.CheckedChanged
        If rbTimeMonthly.Checked Then DataFilter()
    End Sub

    Private Sub rbTimeWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles rbTimeWeekly.CheckedChanged
        If rbTimeWeekly.Checked Then DataFilter()
    End Sub

    Private Sub btnExcelFund_Click(sender As Object, e As EventArgs) Handles btnExcelFund.Click
        ExportExcel1(False)
    End Sub

    Private Sub btnExcelNAV_Click(sender As Object, e As EventArgs) Handles btnExcelNAV.Click
        ExportExcel2(False)
    End Sub

    Public Function ExportExcel1(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGFund, "ReportNAV1.xls")
    End Function

    Public Function ExportExcel2(ByVal isSave As Boolean) As String
        Return PrintExcel(False, DBGData, "ReportNAV2.xls")
    End Function

    Private Sub btnEmailFund_Click(sender As Object, e As EventArgs) Handles btnEmailFund.Click
        If DBGFund.RowCount > 0 Then
            Dim frm As New ReportFundNAVEmail
            frm.Show()
            frm.frm = Me
            frm.t = 1
            frm.MdiParent = MDIMIS
        End If
    End Sub

    Private Sub btnEmailNAV_Click(sender As Object, e As EventArgs) Handles btnEmailNAV.Click
        If DBGData.RowCount > 0 Then
            Dim frm As New ReportFundNAVEmail
            frm.Show()
            frm.frm = Me
            frm.t = 2
            frm.MdiParent = MDIMIS
        End If
    End Sub

#End Region

End Class