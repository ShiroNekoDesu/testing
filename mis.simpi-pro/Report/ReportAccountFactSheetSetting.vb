Imports simpi.GlobalConnection
Imports simpi.GlobalUtilities

Public Class ReportAccountFactSheetSetting
    Public frm As ReportAccountFactSheet
    Dim reportSection As String = "REPORT ACCOUNT HOLDER FACT SHEET"

    Public Sub FormLoad()
        rgbPaletteColor()
        If frm.pdfLayout.layoutType = "DEFAULT" Then
            rbDefault.Checked = True
        ElseIf frm.pdfLayout.layoutType = "OPTION1" Then
            rbOption1.Checked = True
        Else
            rbOption2.Checked = True
        End If
    End Sub

#Region "palette"
    Private Sub txtR_TextChanged(sender As Object, e As EventArgs) Handles txtR.TextChanged
        rgbPaletteColor()
    End Sub

    Private Sub txtB_TextChanged(sender As Object, e As EventArgs) Handles txtB.TextChanged
        rgbPaletteColor()
    End Sub

    Private Sub txtG_TextChanged(sender As Object, e As EventArgs) Handles txtG.TextChanged
        rgbPaletteColor()
    End Sub

    Private Sub rgbPaletteColor()
        Dim r, g, b As Integer
        Int32.TryParse(txtR.Text, r)
        Int32.TryParse(txtG.Text, g)
        Int32.TryParse(txtB.Text, b)
        If r <> RGBCheck(r) Then
            txtR.Text = RGBCheck(r)
            Exit Sub
        End If
        If g <> RGBCheck(g) Then
            txtG.Text = RGBCheck(g)
            Exit Sub
        End If
        If b <> RGBCheck(b) Then
            txtR.Text = RGBCheck(b)
            Exit Sub
        End If
        displayPaletteColor(r, g, b)
        If rbRGB.Checked Then displayCMYK(r, g, b)
    End Sub

    Private Sub displayPaletteColor(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        txtColor.BackColor = Color.FromArgb(r, g, b)
    End Sub

    Private Sub displayCMYK(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        Dim c, m, y, k As Double
        RGBConvertCMYK(r, g, b, c, m, y, k)
        txtC.Text = c.ToString("n2")
        txtM.Text = m.ToString("n2")
        txtY.Text = y.ToString("n2")
        txtK.Text = k.ToString("n2")
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        colorSet()
    End Sub

    Private Sub txtC_TextChanged(sender As Object, e As EventArgs) Handles txtC.TextChanged
        displayRGB()
    End Sub

    Private Sub txtM_TextChanged(sender As Object, e As EventArgs) Handles txtM.TextChanged
        displayRGB()
    End Sub

    Private Sub txtY_TextChanged(sender As Object, e As EventArgs) Handles txtY.TextChanged
        displayRGB()
    End Sub

    Private Sub txtK_TextChanged(sender As Object, e As EventArgs) Handles txtK.TextChanged
        displayRGB()
    End Sub

    Private Sub displayRGB()
        If rbYMCK.Checked Then
            Dim c, y, m, k As Double
            Dim r, g, b As Integer
            Double.TryParse(txtC.Text, c)
            Double.TryParse(txtM.Text, m)
            Double.TryParse(txtY.Text, y)
            Double.TryParse(txtK.Text, k)
            c = CMYKCheck(c)
            m = CMYKCheck(m)
            y = CMYKCheck(y)
            k = CMYKCheck(k)
            txtC.Text = c.ToString("n2")
            txtM.Text = m.ToString("n2")
            txtY.Text = y.ToString("n2")
            txtK.Text = k.ToString("n2")
            CMYKConvertRGB(c, m, y, k, r, g, b)
            txtR.Text = r
            txtG.Text = g
            txtB.Text = b
        End If
    End Sub

    Private Sub rbRGB_CheckedChanged(sender As Object, e As EventArgs) Handles rbRGB.CheckedChanged
        enablePalette()
    End Sub

    Private Sub rbYMCK_CheckedChanged(sender As Object, e As EventArgs) Handles rbYMCK.CheckedChanged
        enablePalette()
    End Sub

    Private Sub enablePalette()
        If rbRGB.Checked Then
            txtR.Enabled = True
            txtG.Enabled = True
            txtB.Enabled = True
            txtC.Enabled = False
            txtM.Enabled = False
            txtY.Enabled = False
            txtK.Enabled = False
        Else
            txtR.Enabled = False
            txtG.Enabled = False
            txtB.Enabled = False
            txtC.Enabled = True
            txtM.Enabled = True
            txtY.Enabled = True
            txtK.Enabled = True
        End If
    End Sub

#End Region

#Region "setting"
    Private Sub colorSet()
        Dim r, g, b As Integer
        Int32.TryParse(txtR.Text, r)
        Int32.TryParse(txtG.Text, g)
        Int32.TryParse(txtB.Text, b)
        If rbReportTitle.Checked Then
            txtColorReportTitle.BackColor = Color.FromArgb(r, g, b)
            ReportTitle_R.Text = RGBWrite("R", r)
            ReportTitle_G.Text = RGBWrite("G", g)
            ReportTitle_B.Text = RGBWrite("B", b)
        ElseIf rbReportLine.Checked Then
            txtColorReportLine.BackColor = Color.FromArgb(r, g, b)
            ReportLine_R.Text = RGBWrite("R", r)
            ReportLine_G.Text = RGBWrite("G", g)
            ReportLine_B.Text = RGBWrite("B", b)
        ElseIf rbClient.Checked Then
            txtColorClient.BackColor = Color.FromArgb(r, g, b)
            Client_R.Text = RGBWrite("R", r)
            Client_G.Text = RGBWrite("G", g)
            Client_B.Text = RGBWrite("B", b)
        ElseIf rbSummary.Checked Then
            txtColorSummary.BackColor = Color.FromArgb(r, g, b)
            Summary_R.Text = RGBWrite("R", r)
            Summary_G.Text = RGBWrite("G", g)
            Summary_B.Text = RGBWrite("B", b)
        ElseIf rbSummaryLine.Checked Then
            txtColorSummaryLine.BackColor = Color.FromArgb(r, g, b)
            SummaryLine_R.Text = RGBWrite("R", r)
            SummaryLine_G.Text = RGBWrite("G", g)
            SummaryLine_B.Text = RGBWrite("B", b)
        ElseIf rbSummaryItems.Checked Then
            txtColorSummaryItems.BackColor = Color.FromArgb(r, g, b)
            SummaryItems_R.Text = RGBWrite("R", r)
            SummaryItems_G.Text = RGBWrite("G", g)
            SummaryItems_B.Text = RGBWrite("B", b)
        ElseIf rbChartTitle.Checked Then
            txtColorChartTitle.BackColor = Color.FromArgb(r, g, b)
            ChartTitle_R.Text = RGBWrite("R", r)
            ChartTitle_G.Text = RGBWrite("G", g)
            ChartTitle_B.Text = RGBWrite("B", b)
        ElseIf rbChartBorder.Checked Then
            txtColorChartBorder.BackColor = Color.FromArgb(r, g, b)
            ChartBorder_R.Text = RGBWrite("R", r)
            ChartBorder_G.Text = RGBWrite("G", g)
            ChartBorder_B.Text = RGBWrite("B", b)
        ElseIf rbChartLine.Checked Then
            txtColorChartLine.BackColor = Color.FromArgb(r, g, b)
            ChartLine_R.Text = RGBWrite("R", r)
            ChartLine_G.Text = RGBWrite("G", g)
            ChartLine_B.Text = RGBWrite("B", b)
        ElseIf rbPieTitle1.Checked Then
            txtColorPieTitle1.BackColor = Color.FromArgb(r, g, b)
            PieTitle1_R.Text = RGBWrite("R", r)
            PieTitle1_G.Text = RGBWrite("G", g)
            PieTitle1_B.Text = RGBWrite("B", b)
        ElseIf rbPieBorder1.Checked Then
            txtColorPieBorder1.BackColor = Color.FromArgb(r, g, b)
            PieBorder1_R.Text = RGBWrite("R", r)
            PieBorder1_G.Text = RGBWrite("G", g)
            PieBorder1_B.Text = RGBWrite("B", b)
        ElseIf rbPieTitle2.Checked Then
            txtColorPieTitle2.BackColor = Color.FromArgb(r, g, b)
            PieTitle2_R.Text = RGBWrite("R", r)
            PieTitle2_G.Text = RGBWrite("G", g)
            PieTitle2_B.Text = RGBWrite("B", b)
        ElseIf rbPieBorder2.Checked Then
            txtColorPieBorder2.BackColor = Color.FromArgb(r, g, b)
            PieBorder2_R.Text = RGBWrite("R", r)
            PieBorder2_G.Text = RGBWrite("G", g)
            PieBorder2_B.Text = RGBWrite("B", b)
        ElseIf rbTableHeadertrx.Checked Then
            txtColorTableHeaderTrx.BackColor = Color.FromArgb(r, g, b)
            TableHeaderTrx_R.Text = RGBWrite("R", r)
            TableHeaderTrx_G.Text = RGBWrite("G", g)
            TableHeaderTrx_B.Text = RGBWrite("B", b)
        ElseIf rbTableLinetrx.Checked Then
            txtColorTableLineTrx.BackColor = Color.FromArgb(r, g, b)
            TableLineTrx_R.Text = RGBWrite("R", r)
            TableLineTrx_G.Text = RGBWrite("G", g)
            TableLineTrx_B.Text = RGBWrite("B", b)
        ElseIf rbTableItemstrx.Checked Then
            txtColorTableItemsTrx.BackColor = Color.FromArgb(r, g, b)
            TableItemsTrx_R.Text = RGBWrite("R", r)
            TableItemsTrx_G.Text = RGBWrite("G", g)
            TableItemsTrx_B.Text = RGBWrite("B", b)
        ElseIf rbTableTitletrx.Checked Then
            txtColorTableTitleTrx.BackColor = Color.FromArgb(r, g, b)
            TableTitleTrx_R.Text = RGBWrite("R", r)
            TableTitleTrx_G.Text = RGBWrite("G", g)
            TableTitleTrx_B.Text = RGBWrite("B", b)
        ElseIf rbTableHeaderholding.Checked Then
            txtColorTableHeaderHolding.BackColor = Color.FromArgb(r, g, b)
            TableHeaderHolding_R.Text = RGBWrite("R", r)
            TableHeaderHolding_G.Text = RGBWrite("G", g)
            TableHeaderHolding_B.Text = RGBWrite("B", b)
        ElseIf rbTableLineholding.Checked Then
            txtColorTableLineHolding.BackColor = Color.FromArgb(r, g, b)
            TableLineHolding_R.Text = RGBWrite("R", r)
            TableLineHolding_G.Text = RGBWrite("G", g)
            TableLineHolding_B.Text = RGBWrite("B", b)
        ElseIf rbTableItemsholding.Checked Then
            txtColorTableItemsHolding.BackColor = Color.FromArgb(r, g, b)
            TableItemsHolding_R.Text = RGBWrite("R", r)
            TableItemsHolding_G.Text = RGBWrite("G", g)
            TableItemsHolding_B.Text = RGBWrite("B", b)
        ElseIf rbTableTitleholding.Checked Then
            txtColorTableTitleHolding.BackColor = Color.FromArgb(r, g, b)
            TableTitleHolding_R.Text = RGBWrite("R", r)
            TableTitleHolding_G.Text = RGBWrite("G", g)
            TableTitleHolding_B.Text = RGBWrite("B", b)
        End If
    End Sub

    Private Sub colorGet()
        If rbReportTitle.Checked Then
            txtR.Text = RGBRead(ReportTitle_R.Text)
            txtG.Text = RGBRead(ReportTitle_G.Text)
            txtB.Text = RGBRead(ReportTitle_B.Text)
        ElseIf rbReportLine.Checked Then
            txtR.Text = RGBRead(ReportLine_R.Text)
            txtG.Text = RGBRead(ReportLine_G.Text)
            txtB.Text = RGBRead(ReportLine_B.Text)
        ElseIf rbClient.Checked Then
            txtR.Text = RGBRead(Client_R.Text)
            txtG.Text = RGBRead(Client_G.Text)
            txtB.Text = RGBRead(Client_B.Text)
        ElseIf rbSummary.Checked Then
            txtR.Text = RGBRead(Summary_R.Text)
            txtG.Text = RGBRead(Summary_G.Text)
            txtB.Text = RGBRead(Summary_B.Text)
        ElseIf rbSummaryLine.Checked Then
            txtR.Text = RGBRead(SummaryLine_R.Text)
            txtG.Text = RGBRead(SummaryLine_G.Text)
            txtB.Text = RGBRead(SummaryLine_B.Text)
        ElseIf rbSummaryItems.Checked Then
            txtR.Text = RGBRead(SummaryItems_R.Text)
            txtG.Text = RGBRead(SummaryItems_G.Text)
            txtB.Text = RGBRead(SummaryItems_B.Text)
        ElseIf rbChartTitle.Checked Then
            txtR.Text = RGBRead(ChartTitle_R.Text)
            txtG.Text = RGBRead(ChartTitle_G.Text)
            txtB.Text = RGBRead(ChartTitle_B.Text)
        ElseIf rbChartBorder.Checked Then
            txtR.Text = RGBRead(ChartBorder_R.Text)
            txtG.Text = RGBRead(ChartBorder_G.Text)
            txtB.Text = RGBRead(ChartBorder_B.Text)
        ElseIf rbChartLine.Checked Then
            txtR.Text = RGBRead(ChartLine_R.Text)
            txtG.Text = RGBRead(ChartLine_G.Text)
            txtB.Text = RGBRead(ChartLine_B.Text)
        ElseIf rbpieTitle1.Checked Then
            txtR.Text = RGBRead(PieTitle1_R.Text)
            txtG.Text = RGBRead(PieTitle1_G.Text)
            txtB.Text = RGBRead(PieTitle1_B.Text)
        ElseIf rbpieBorder1.Checked Then
            txtR.Text = RGBRead(PieBorder1_R.Text)
            txtG.Text = RGBRead(PieBorder1_G.Text)
            txtB.Text = RGBRead(PieBorder1_B.Text)
        ElseIf rbpieTitle2.Checked Then
            txtR.Text = RGBRead(PieTitle2_R.Text)
            txtG.Text = RGBRead(PieTitle2_G.Text)
            txtB.Text = RGBRead(PieTitle2_B.Text)
        ElseIf rbpieBorder2.Checked Then
            txtR.Text = RGBRead(PieBorder2_R.Text)
            txtG.Text = RGBRead(PieBorder2_G.Text)
            txtB.Text = RGBRead(PieBorder2_B.Text)
        ElseIf rbTableHeadertrx.Checked Then
            txtR.Text = RGBRead(TableHeaderTrx_R.Text)
            txtG.Text = RGBRead(TableHeaderTrx_G.Text)
            txtB.Text = RGBRead(TableHeaderTrx_B.Text)
        ElseIf rbTableLinetrx.Checked Then
            txtR.Text = RGBRead(TableLineTrx_R.Text)
            txtG.Text = RGBRead(TableLineTrx_G.Text)
            txtB.Text = RGBRead(TableLineTrx_B.Text)
        ElseIf rbTableItemstrx.Checked Then
            txtR.Text = RGBRead(TableItemsTrx_R.Text)
            txtG.Text = RGBRead(TableItemsTrx_G.Text)
            txtB.Text = RGBRead(TableItemsTrx_B.Text)
        ElseIf rbTableTitletrx.Checked Then
            txtR.Text = RGBRead(TableTitleTrx_R.Text)
            txtG.Text = RGBRead(TableTitleTrx_G.Text)
            txtB.Text = RGBRead(TableTitleTrx_B.Text)
        ElseIf rbTableHeaderholding.Checked Then
            txtR.Text = RGBRead(TableHeaderHolding_R.Text)
            txtG.Text = RGBRead(TableHeaderHolding_G.Text)
            txtB.Text = RGBRead(TableHeaderHolding_B.Text)
        ElseIf rbTableLineholding.Checked Then
            txtR.Text = RGBRead(TableLineHolding_R.Text)
            txtG.Text = RGBRead(TableLineHolding_G.Text)
            txtB.Text = RGBRead(TableLineHolding_B.Text)
        ElseIf rbTableItemsholding.Checked Then
            txtR.Text = RGBRead(TableItemsHolding_R.Text)
            txtG.Text = RGBRead(TableItemsHolding_G.Text)
            txtB.Text = RGBRead(TableItemsHolding_B.Text)
        ElseIf rbTableTitleholding.Checked Then
            txtR.Text = RGBRead(TableTitleHolding_R.Text)
            txtG.Text = RGBRead(TableTitleHolding_G.Text)
            txtB.Text = RGBRead(TableTitleHolding_B.Text)
        End If
    End Sub

    Private Sub rbReportTitle_CheckedChanged(sender As Object, e As EventArgs) Handles rbReportTitle.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbClient_CheckedChanged(sender As Object, e As EventArgs) Handles rbClient.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbSummary_CheckedChanged(sender As Object, e As EventArgs) Handles rbSummary.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbSummaryLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbSummaryLine.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbSummaryItems_CheckedChanged(sender As Object, e As EventArgs) Handles rbSummaryItems.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbChartTitle_CheckedChanged(sender As Object, e As EventArgs) Handles rbChartTitle.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbChartBorder_CheckedChanged(sender As Object, e As EventArgs) Handles rbChartBorder.CheckedChanged
        colorGet()
    End Sub

    Private Sub chkChartBorder_CheckedChanged(sender As Object, e As EventArgs) Handles chkChartBorder.CheckedChanged
        If chkChartBorder.Checked Then chkChartBorder.Text = "Y" Else chkChartBorder.Text = "N"
    End Sub

    Private Sub rbChartLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbChartLine.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableHeaderTrx_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableHeaderTrx.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableLineTrx_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableLineTrx.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableItemsTrx_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableItemsTrx.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableTitleTrx_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableTitleTrx.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbReportLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbReportLine.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableLineHolding_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableLineHolding.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableHeaderHolding_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableHeaderHolding.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableItemsHolding_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableItemsHolding.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableTitleHolding_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableTitleHolding.CheckedChanged
        colorGet()
    End Sub

#End Region

    Private Sub rbDefault_CheckedChanged(sender As Object, e As EventArgs) Handles rbDefault.CheckedChanged
        iniCheck()
    End Sub

    Private Sub rbOption1_CheckedChanged(sender As Object, e As EventArgs) Handles rbOption1.CheckedChanged
        iniCheck()
    End Sub

    Private Sub rbOption2_CheckedChanged(sender As Object, e As EventArgs) Handles rbOption2.CheckedChanged
        iniCheck()
    End Sub

    Private Sub iniCheck()
        If rbDefault.Checked Then
            iniLoad("DEFAULT")
        ElseIf rbOption1.Checked Then
            iniLoad("OPTION1")
        ElseIf rbOption2.Checked Then
            iniLoad("OPTION2")
        End If
    End Sub

    Private Sub iniLoad(ByVal iniType As String)
        Try
            If iniType.Trim = "DEFAULT" Then
                _default()
            Else
                Dim strFile As String = simpiFile("simpi.ini")
                If GlobalFileWindows.FileExists(strFile) Then
                    Dim r, g, b As Integer
                    Dim file As New GlobalINI(strFile)
                    r = file.GetInteger(reportSection, iniType & " Report Title R", 0)
                    g = file.GetInteger(reportSection, iniType & " Report Title G", 0)
                    b = file.GetInteger(reportSection, iniType & " Report Title B", 0)
                    ReportTitle_R.Text = RGBWrite("R", r)
                    ReportTitle_G.Text = RGBWrite("G", g)
                    ReportTitle_B.Text = RGBWrite("B", b)
                    txtColorReportTitle.BackColor = Color.FromArgb(r, g, b)
                    txtReportTitle.Text = file.GetString(reportSection, iniType & " Report Title", "")

                    r = file.GetInteger(reportSection, iniType & " Client R", 0)
                    g = file.GetInteger(reportSection, iniType & " Client G", 0)
                    b = file.GetInteger(reportSection, iniType & " Client B", 0)
                    Client_R.Text = RGBWrite("R", r)
                    Client_G.Text = RGBWrite("G", g)
                    Client_B.Text = RGBWrite("B", b)
                    txtColorClient.BackColor = Color.FromArgb(r, g, b)
                    txtAsOf.Text = file.GetString(reportSection, iniType & " AsOf", "")

                    r = file.GetInteger(reportSection, iniType & " Report Line R", 0)
                    g = file.GetInteger(reportSection, iniType & " Report Line G", 0)
                    b = file.GetInteger(reportSection, iniType & " Report Line B", 0)
                    ReportLine_R.Text = RGBWrite("R", r)
                    ReportLine_G.Text = RGBWrite("G", g)
                    ReportLine_B.Text = RGBWrite("B", b)
                    txtColorReportLine.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Summary R", 0)
                    g = file.GetInteger(reportSection, iniType & " Summary G", 0)
                    b = file.GetInteger(reportSection, iniType & " Summary B", 0)
                    Summary_R.Text = RGBWrite("R", r)
                    Summary_G.Text = RGBWrite("G", g)
                    Summary_B.Text = RGBWrite("B", b)
                    txtColorSummary.BackColor = Color.FromArgb(r, g, b)
                    txtSummary.Text = file.GetString(reportSection, iniType & " Summary", "")

                    r = file.GetInteger(reportSection, iniType & " Summary Line R", 0)
                    g = file.GetInteger(reportSection, iniType & " Summary Line G", 0)
                    b = file.GetInteger(reportSection, iniType & " Summary Line B", 0)
                    SummaryLine_R.Text = RGBWrite("R", r)
                    SummaryLine_G.Text = RGBWrite("G", g)
                    SummaryLine_B.Text = RGBWrite("B", b)
                    txtColorSummaryLine.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Summary Items R", 0)
                    g = file.GetInteger(reportSection, iniType & " Summary Items G", 0)
                    r = file.GetInteger(reportSection, iniType & " Summary Items B", 0)
                    SummaryItems_R.Text = RGBWrite("R", r)
                    SummaryItems_G.Text = RGBWrite("G", g)
                    SummaryItems_B.Text = RGBWrite("B", b)
                    txtColorSummaryItems.BackColor = Color.FromArgb(r, g, b)
                    txtSummaryItemsTotalInvestmentValue.Text = file.GetString(reportSection, iniType & " Summary Items Total Investment Value", "")
                    txtSummaryItemsTotalAcquisitionCost.Text = file.GetString(reportSection, iniType & " Summary Items Total Acquisition Cost", "")
                    txtSummaryItemsTotalUnrealizedPL.Text = file.GetString(reportSection, iniType & " Summary Items Total Unrealized P/L", "")
                    txtSummaryItemsInvestmentLength.Text = file.GetString(reportSection, iniType & " Summary Items Investment Length", "")
                    txtSummaryItemsTotalSubscription.Text = file.GetString(reportSection, iniType & " Summary Items Total Subscription", "")
                    txtSummaryItemsTotalRedemption.Text = file.GetString(reportSection, iniType & " Summary Items Total Redemption", "")
                    txtSummaryItemsTotalDividend.Text = file.GetString(reportSection, iniType & " Summary Items Total Dividend", "")

                    r = file.GetInteger(reportSection, iniType & " Chart Title R", 0)
                    b = file.GetInteger(reportSection, iniType & " Chart Title G", 0)
                    g = file.GetInteger(reportSection, iniType & " Chart Title B", 0)
                    ChartTitle_R.Text = RGBWrite("R", r)
                    ChartTitle_G.Text = RGBWrite("B", b)
                    ChartTitle_B.Text = RGBWrite("G", g)
                    txtColorChartTitle.BackColor = Color.FromArgb(r, b, g)
                    txtInvestmentGrowth.Text = file.GetString(reportSection, iniType & " Investment Growth", "")

                    r = file.GetInteger(reportSection, iniType & " Chart Border R", 0)
                    g = file.GetInteger(reportSection, iniType & " Chart Border G", 0)
                    b = file.GetInteger(reportSection, iniType & " Chart Border B", 0)
                    ChartBorder_R.Text = RGBWrite("R", r)
                    ChartBorder_G.Text = RGBWrite("G", g)
                    ChartBorder_B.Text = RGBWrite("B", b)
                    txtColorChartBorder.BackColor = Color.FromArgb(r, g, b)
                    If file.GetBoolean(reportSection, iniType & " Chart Border", False) Then chkChartBorder.Checked = True Else chkChartBorder.Checked = False

                    r = file.GetInteger(reportSection, iniType & " Chart Line R", 0)
                    g = file.GetInteger(reportSection, iniType & " Chart Line G", 0)
                    b = file.GetInteger(reportSection, iniType & " Chart Line B", 0)
                    ChartLine_R.Text = RGBWrite("R", r)
                    ChartLine_G.Text = RGBWrite("G", g)
                    ChartLine_B.Text = RGBWrite("B", b)
                    txtColorChartLine.BackColor = Color.FromArgb(r, g, b)
                    txtChartLabel1.Text = file.GetString(reportSection, iniType & " Chart Label 1", "")
                    txtChartLabel2.Text = file.GetString(reportSection, iniType & " Chart Label 2", "")

                    r = file.GetInteger(reportSection, iniType & " Pie Title 1 R", 0)
                    b = file.GetInteger(reportSection, iniType & " Pie Title 1 G", 0)
                    g = file.GetInteger(reportSection, iniType & " Pie Title 1 B", 0)
                    PieTitle1_R.Text = RGBWrite("R", r)
                    PieTitle1_G.Text = RGBWrite("B", b)
                    PieTitle1_B.Text = RGBWrite("G", g)
                    txtColorPieTitle1.BackColor = Color.FromArgb(r, b, g)
                    txtFundAllocation.Text = file.GetString(reportSection, iniType & " Fund Allocation", "")

                    r = file.GetInteger(reportSection, iniType & " Pie Border 1 R", 0)
                    g = file.GetInteger(reportSection, iniType & " Pie Border 1 G", 0)
                    b = file.GetInteger(reportSection, iniType & " Pie Border 1 B", 0)
                    PieBorder1_R.Text = RGBWrite("R", r)
                    PieBorder1_G.Text = RGBWrite("G", g)
                    PieBorder1_B.Text = RGBWrite("B", b)
                    txtColorPieBorder1.BackColor = Color.FromArgb(r, g, b)
                    If file.GetBoolean(reportSection, iniType & " Pie Border 1", False) Then chkPieBorder1.Checked = True Else chkPieBorder1.Checked = False

                    r = file.GetInteger(reportSection, iniType & " Pie Title 2 R", 0)
                    b = file.GetInteger(reportSection, iniType & " Pie Title 2 G", 0)
                    g = file.GetInteger(reportSection, iniType & " Pie Title 2 B", 0)
                    PieTitle2_R.Text = RGBWrite("R", r)
                    PieTitle2_G.Text = RGBWrite("B", b)
                    PieTitle2_B.Text = RGBWrite("G", g)
                    txtColorPieTitle2.BackColor = Color.FromArgb(r, b, g)
                    txtAssetTypeAllocation.Text = file.GetString(reportSection, iniType & " Asset Type Allocation", "")

                    r = file.GetInteger(reportSection, iniType & " Pie Border 2 R", 0)
                    g = file.GetInteger(reportSection, iniType & " Pie Border 2 G", 0)
                    b = file.GetInteger(reportSection, iniType & " Pie Border 2 B", 0)
                    PieBorder2_R.Text = RGBWrite("R", r)
                    PieBorder2_G.Text = RGBWrite("G", g)
                    PieBorder2_B.Text = RGBWrite("B", b)
                    txtColorPieBorder2.BackColor = Color.FromArgb(r, g, b)
                    If file.GetBoolean(reportSection, iniType & " Pie Border 2", False) Then chkPieBorder2.Checked = True Else chkPieBorder2.Checked = False

                    r = file.GetInteger(reportSection, iniType & " Table Header Trx R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Header Trx G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Header Trx B", 0)
                    TableHeaderTrx_R.Text = RGBWrite("R", r)
                    TableHeaderTrx_G.Text = RGBWrite("G", g)
                    TableHeaderTrx_B.Text = RGBWrite("B", b)
                    txtColorTableHeaderTrx.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Line Trx R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Line Trx G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Line Trx B", 0)
                    TableLineTrx_R.Text = RGBWrite("R", r)
                    TableLineTrx_G.Text = RGBWrite("G", g)
                    TableLineTrx_B.Text = RGBWrite("B", b)
                    txtColorTableLineTrx.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Items Trx R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Items Trx G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Items Trx B", 0)
                    TableItemsTrx_R.Text = RGBWrite("R", r)
                    TableItemsTrx_G.Text = RGBWrite("G", g)
                    TableItemsTrx_B.Text = RGBWrite("B", b)
                    txtColorTableItemsTrx.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Title Trx R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Title Trx G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Title Trx B", 0)
                    TableTitleTrx_R.Text = RGBWrite("R", r)
                    TableTitleTrx_G.Text = RGBWrite("G", g)
                    TableTitleTrx_B.Text = RGBWrite("B", b)
                    txtColorTableTitleTrx.BackColor = Color.FromArgb(r, g, b)
                    txtLatestTransaction.Text = file.GetString(reportSection, iniType & " Latest Transaction", "")
                    txtTableTrxDate.Text = file.GetString(reportSection, iniType & " Table Date Trx", "")
                    txtTableTrxFund.Text = file.GetString(reportSection, iniType & " Table Fund Trx", "")
                    txtTableTrxName.Text = file.GetString(reportSection, iniType & " Table Name Trx", "")
                    txtTableTrxType.Text = file.GetString(reportSection, iniType & " Table Type Trx", "")
                    txtTableTrxAmount.Text = file.GetString(reportSection, iniType & " Table Amount Trx", "")
                    txtTableTrxNAVUnit.Text = file.GetString(reportSection, iniType & " Table NAV/Unit Trx", "")
                    txtTableTrxUnit.Text = file.GetString(reportSection, iniType & " Table Unit(s) Trx", "")

                    r = file.GetInteger(reportSection, iniType & " Table Header Holding R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Header Holding G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Header Holding B", 0)
                    TableHeaderHolding_R.Text = RGBWrite("R", r)
                    TableHeaderHolding_G.Text = RGBWrite("G", g)
                    TableHeaderHolding_B.Text = RGBWrite("B", b)
                    txtColorTableHeaderHolding.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Line Holding R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Line Holding G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Line Holding B", 0)
                    TableLineHolding_R.Text = RGBWrite("R", r)
                    TableLineHolding_G.Text = RGBWrite("G", g)
                    TableLineHolding_B.Text = RGBWrite("B", b)
                    txtColorTableLineHolding.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Item Holdings R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Items Holding G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Items Holding B", 0)
                    TableItemsHolding_R.Text = RGBWrite("R", r)
                    TableItemsHolding_G.Text = RGBWrite("G", g)
                    TableItemsHolding_B.Text = RGBWrite("B", b)
                    txtColorTableItemsHolding.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Title Holding R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Title Holding G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Title Holding B", 0)
                    TableTitleHolding_R.Text = RGBWrite("R", r)
                    TableTitleHolding_G.Text = RGBWrite("G", g)
                    TableTitleHolding_B.Text = RGBWrite("B", b)
                    txtColorTableTitleHolding.BackColor = Color.FromArgb(r, g, b)
                    txtListOfUnitholding.Text = file.GetString(reportSection, iniType & " List of Unitholding", "")
                    txtTableHoldingNo.Text = file.GetString(reportSection, iniType & " Table No Holding", "")
                    txtTableHoldingFund.Text = file.GetString(reportSection, iniType & " Table Fund Holding", "")
                    txtTableHoldingName.Text = file.GetString(reportSection, iniType & " Table Name Holding", "")
                    txtTableHoldingType.Text = file.GetString(reportSection, iniType & " Table Type Holding", "")
                    txtTableHoldingUnit.Text = file.GetString(reportSection, iniType & " Table Unit(s) Holding", "")
                    txtTableHoldingNAVUnit.Text = file.GetString(reportSection, iniType & " Table NAV/Unit Holding", "")
                    txtTableHoldingAvgCost.Text = file.GetString(reportSection, iniType & " Table Avg. Cost Holding", "")
                    txtTableHoldingValue.Text = file.GetString(reportSection, iniType & " Table Value Holding", "")
                    txtTableHoldingAcqCost.Text = file.GetString(reportSection, iniType & " Table Acq. Cost Holding", "")
                    txtTableHoldingUnrealizedPL.Text = file.GetString(reportSection, iniType & " Table Unrealized P/L Holding", "")
                End If
            End If
        Catch ex As Exception
            _default()
        End Try
    End Sub

    Private Sub _default()
        With frm.pdfLayout
            frm.pdfColorDefault()
            ReportTitle_R.Text = "R: " & .ReportTitle_R
            ReportTitle_G.Text = "G: " & .ReportTitle_G
            ReportTitle_B.Text = "B: " & .ReportTitle_B
            txtColorReportTitle.BackColor = Color.FromArgb(.ReportTitle_R, .ReportTitle_G, .ReportTitle_B)
            txtReportTitle.Text = .ReportTitle
            Client_R.Text = "R: " & .Client_R
            Client_G.Text = "G: " & .Client_G
            Client_B.Text = "B: " & .Client_B
            txtColorClient.BackColor = Color.FromArgb(.Client_R, .Client_G, .Client_B)
            txtAsOf.Text = .AsOf
            ReportLine_R.Text = "R: " & .ReportLine_R
            ReportLine_G.Text = "G: " & .ReportLine_G
            ReportLine_B.Text = "B: " & .ReportLine_B
            txtColorReportLine.BackColor = Color.FromArgb(.ReportLine_R, .ReportLine_G, .ReportLine_B)
            Summary_R.Text = "R: " & .Summary_R
            Summary_G.Text = "G: " & .Summary_G
            Summary_B.Text = "B: " & .Summary_B
            txtColorSummary.BackColor = Color.FromArgb(.Summary_R, .Summary_G, .Summary_B)
            txtSummary.Text = .Summary
            SummaryLine_R.Text = "R: " & .SummaryLine_R
            SummaryLine_G.Text = "G: " & .SummaryLine_G
            SummaryLine_B.Text = "B: " & .SummaryLine_B
            txtColorSummaryLine.BackColor = Color.FromArgb(.SummaryLine_R, .SummaryLine_G, .SummaryLine_B)
            SummaryItems_R.Text = "R: " & .SummaryItems_R
            SummaryItems_G.Text = "G: " & .SummaryItems_G
            SummaryItems_B.Text = "B: " & .SummaryItems_B
            txtColorSummaryItems.BackColor = Color.FromArgb(.SummaryItems_R, .SummaryItems_G, .SummaryItems_B)
            txtSummaryItemsTotalInvestmentValue.Text = .SummaryItemsTotalInvestmentValue
            txtSummaryItemsTotalAcquisitionCost.Text = .SummaryItemsTotalAcqusitionCost
            txtSummaryItemsTotalUnrealizedPL.Text = .SummaryItemsTotalUnrealizedPL
            txtSummaryItemsTotalDividend.Text = .SummaryItemsTotalDividend
            txtSummaryItemsInvestmentLength.Text = .SummaryItemsInvestmentLength
            txtSummaryItemsTotalSubscription.Text = .SummaryItemsTotalSubscription
            txtSummaryItemsTotalRedemption.Text = .SummaryItemsTotalRedemption
            ChartTitle_R.Text = "R: " & .ChartTitle_R
            ChartTitle_G.Text = "G: " & .ChartTitle_G
            ChartTitle_B.Text = "B: " & .ChartTitle_B
            txtColorChartTitle.BackColor = Color.FromArgb(.ChartTitle_R, .ChartTitle_G, .ChartTitle_B)
            txtInvestmentGrowth.Text = .InvestmentGrowth
            ChartBorder_R.Text = "R: " & .ChartBorder_R
            ChartBorder_G.Text = "G: " & .ChartBorder_G
            ChartBorder_B.Text = "B: " & .ChartBorder_B
            txtColorChartBorder.BackColor = Color.FromArgb(.ChartBorder_R, .ChartBorder_G, .ChartBorder_B)
            chkChartBorder.Checked = .ChartBorder
            ChartLine_R.Text = "R: " & .ChartLine_R
            ChartLine_G.Text = "G: " & .ChartLine_G
            ChartLine_B.Text = "B: " & .ChartLine_B
            txtColorChartLine.BackColor = Color.FromArgb(.ChartLine_R, .ChartLine_G, .ChartLine_B)
            txtChartLabel1.Text = .ChartLabel1
            txtChartLabel2.Text = .ChartLabel2
            PieTitle1_R.Text = "R: " & .PieTitle1_R
            PieTitle1_G.Text = "G: " & .PieTitle1_G
            PieTitle1_B.Text = "B: " & .PieTitle1_B
            txtColorPieTitle1.BackColor = Color.FromArgb(.PieTitle1_R, .PieTitle1_G, .PieTitle1_B)
            txtFundAllocation.Text = .FundAllocation
            PieBorder1_R.Text = "R: " & .PieBorder1_R
            PieBorder1_G.Text = "G: " & .PieBorder1_G
            PieBorder1_B.Text = "B: " & .PieBorder1_B
            txtColorPieBorder1.BackColor = Color.FromArgb(.PieBorder1_R, .PieBorder1_G, .PieBorder1_B)
            chkPieBorder1.Checked = .PieBorder1
            PieTitle2_R.Text = "R: " & .PieTitle2_R
            PieTitle2_G.Text = "G: " & .PieTitle2_G
            PieTitle2_B.Text = "B: " & .PieTitle2_B
            txtColorPieTitle2.BackColor = Color.FromArgb(.PieTitle2_R, .PieTitle2_G, .PieTitle2_B)
            txtAssetTypeAllocation.Text = .AssetTypeAllocation
            PieBorder2_R.Text = "R: " & .PieBorder2_R
            PieBorder2_G.Text = "G: " & .PieBorder2_G
            PieBorder2_B.Text = "B: " & .PieBorder2_B
            txtColorPieBorder2.BackColor = Color.FromArgb(.PieBorder2_R, .PieBorder2_G, .PieBorder2_B)
            chkPieBorder2.Checked = .PieBorder2
            TableHeaderTrx_R.Text = "R: " & .TableHeaderTrx_R
            TableHeaderTrx_G.Text = "G: " & .TableHeaderTrx_G
            TableHeaderTrx_B.Text = "B: " & .TableHeaderTrx_B
            txtColorTableHeaderTrx.BackColor = Color.FromArgb(.TableHeaderTrx_R, .TableHeaderTrx_G, .TableHeaderTrx_B)
            TableLineTrx_R.Text = "R: " & .TableLineTrx_R
            TableLineTrx_G.Text = "G: " & .TableLineTrx_G
            TableLineTrx_B.Text = "B: " & .TableLineTrx_B
            txtColorTableLineTrx.BackColor = Color.FromArgb(.TableLineTrx_R, .TableLineTrx_G, .TableLineTrx_B)
            TableItemsTrx_R.Text = "R: " & .TableItemsTrx_R
            TableItemsTrx_G.Text = "G: " & .TableItemsTrx_G
            TableItemsTrx_B.Text = "B: " & .TableItemsTrx_B
            txtColorTableItemsTrx.BackColor = Color.FromArgb(.TableItemsTrx_R, .TableItemsTrx_G, .TableItemsTrx_B)
            TableTitleTrx_R.Text = "R: " & .TableTitleTrx_R
            TableTitleTrx_G.Text = "G: " & .TableTitleTrx_G
            TableTitleTrx_B.Text = "B: " & .TableTitleTrx_B
            txtColorTableTitleTrx.BackColor = Color.FromArgb(.TableTitleTrx_R, .TableTitleTrx_G, .TableTitleTrx_B)
            txtLatestTransaction.Text = .LatestTransaction
            txtTableTrxDate.Text = .TableTitleDateTrx
            txtTableTrxFund.Text = .TableTitleFundTrx
            txtTableTrxName.Text = .TableTitleNameTrx
            txtTableTrxType.Text = .TableTitleTypeTrx
            txtTableTrxAmount.Text = .TableTitleAmountTrx
            txtTableTrxNAVUnit.Text = .TableTitleNAVUnitTrx
            txtTableTrxUnit.Text = .TableTitleUnitTrx
            TableHeaderHolding_R.Text = "R: " & .TableHeaderHolding_R
            TableHeaderHolding_G.Text = "G: " & .TableHeaderHolding_G
            TableHeaderHolding_B.Text = "B: " & .TableHeaderHolding_B
            txtColorTableHeaderHolding.BackColor = Color.FromArgb(.TableHeaderHolding_R, .TableHeaderHolding_G, .TableHeaderHolding_B)
            TableLineHolding_R.Text = "R: " & .TableLineHolding_R
            TableLineHolding_G.Text = "G: " & .TableLineHolding_G
            TableLineHolding_B.Text = "B: " & .TableLineHolding_B
            txtColorTableLineHolding.BackColor = Color.FromArgb(.TableLineHolding_R, .TableLineHolding_G, .TableLineHolding_B)
            TableItemsHolding_R.Text = "R: " & .TableItemsHolding_R
            TableItemsHolding_G.Text = "G: " & .TableItemsHolding_G
            TableItemsHolding_B.Text = "B: " & .TableItemsHolding_B
            txtColorTableItemsHolding.BackColor = Color.FromArgb(.TableItemsHolding_R, .TableItemsHolding_G, .TableItemsHolding_B)
            TableTitleHolding_R.Text = "R: " & .TableTitleHolding_R
            TableTitleHolding_G.Text = "G: " & .TableTitleHolding_G
            TableTitleHolding_B.Text = "B: " & .TableTitleHolding_B
            txtColorTableTitleHolding.BackColor = Color.FromArgb(.TableTitleHolding_R, .TableTitleHolding_G, .TableTitleHolding_B)
            txtListOfUnitholding.Text = .ListOfUnitholding
            txtTableHoldingNo.Text = .TableTitleNoHolding
            txtTableHoldingFund.Text = .TableTitleFundHolding
            txtTableHoldingName.Text = .TableTitleNameHolding
            txtTableHoldingType.Text = .TableTitleTypeHolding
            txtTableHoldingUnit.Text = .TableTitleUnitHolding
            txtTableHoldingNAVUnit.Text = .TableTitleNAVUnitHolding
            txtTableHoldingAvgCost.Text = .TableTitleAvgCostHolding
            txtTableHoldingValue.Text = .TableTitleValueHolding
            txtTableHoldingAcqCost.Text = .TableTitleAcqCostHolding
            txtTableHoldingUnrealizedPL.Text = .TableTitleUnrealizedPLHolding
        End With
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rbDefault.Checked Then
            iniSave("DEFAULT")
        ElseIf rbOption1.Checked Then
            iniSave("OPTION1")
        ElseIf rbOption2.Checked Then
            iniSave("OPTION2")
        End If
    End Sub

    Private Sub iniSave(ByVal iniType As String)
        Try
            Dim strFile As String = simpiFile("simpi.ini")
            Dim file As New GlobalINI(strFile)
            file.WriteString(reportSection, "LAYOUT", iniType)
            If iniType.Trim <> "DEFAULT" Then
                file.WriteInteger(reportSection, iniType & " Report Title R", RGBRead(ReportTitle_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Title G", RGBRead(ReportTitle_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Title B", RGBRead(ReportTitle_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Report Title", txtReportTitle.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Client R", RGBRead(Client_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Client G", RGBRead(Client_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Client B", RGBRead(Client_B.Text.Trim))
                file.WriteString(reportSection, iniType & " AsOf", txtAsOf.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Report Line R", RGBRead(ReportLine_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Line G", RGBRead(ReportLine_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Line B", RGBRead(ReportLine_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Summary R", RGBRead(Summary_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary G", RGBRead(Summary_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary B", RGBRead(Summary_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Summary", txtSummary.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Summary Line R", RGBRead(SummaryLine_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary Line G", RGBRead(SummaryLine_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary Line B", RGBRead(SummaryLine_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Summary Items R", RGBRead(SummaryItems_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary Items G", RGBRead(SummaryItems_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Summary Items B", RGBRead(SummaryItems_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Summary Items Total Investment Value", txtSummaryItemsTotalInvestmentValue.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Total Acquisition Cost", txtSummaryItemsTotalAcquisitionCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Total Unrealized P/L", txtSummaryItemsTotalUnrealizedPL.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Investment Length", txtSummaryItemsInvestmentLength.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Total Subscription", txtSummaryItemsTotalSubscription.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Total Redemption", txtSummaryItemsTotalRedemption.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Total Dividend", txtSummaryItemsTotalDividend.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Chart Title R", RGBRead(ChartTitle_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Title G", RGBRead(ChartTitle_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Title B", RGBRead(ChartTitle_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Investment Growth", txtInvestmentGrowth.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Chart Border R", RGBRead(ChartBorder_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Border G", RGBRead(ChartBorder_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Border B", RGBRead(ChartBorder_B.Text.Trim))
                file.WriteBoolean(reportSection, iniType & " Chart Border", chkChartBorder.Checked)

                file.WriteInteger(reportSection, iniType & " Chart Line R", RGBRead(ChartLine_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Line G", RGBRead(ChartLine_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Chart Line B", RGBRead(ChartLine_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Chart Label 1", txtChartLabel1.Text.Trim)
                file.WriteString(reportSection, iniType & " Chart Label 2", txtChartLabel2.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Pie Title 1 R", RGBRead(PieTitle1_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Title 1 G", RGBRead(PieTitle1_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Title 1 B", RGBRead(PieTitle1_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Fund Allocation", txtFundAllocation.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Pie Border 1 R", RGBRead(PieBorder1_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Border 1 G", RGBRead(PieBorder1_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Border 1 B", RGBRead(PieBorder1_B.Text.Trim))
                file.WriteBoolean(reportSection, iniType & " Pie Border 1", chkPieBorder1.Checked)

                file.WriteInteger(reportSection, iniType & " Pie Title 2 R", RGBRead(PieTitle2_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Title 2 G", RGBRead(PieTitle2_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Title 2 B", RGBRead(PieTitle2_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Asset Type Allocation", txtAssetTypeAllocation.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Pie Border 2 R", RGBRead(PieBorder2_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Border 2 G", RGBRead(PieBorder2_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Pie Border 2 B", RGBRead(PieBorder2_B.Text.Trim))
                file.WriteBoolean(reportSection, iniType & " Pie Border 2", chkPieBorder2.Checked)

                file.WriteInteger(reportSection, iniType & " Table Header Trx R", RGBRead(TableHeaderTrx_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header Trx G", RGBRead(TableHeaderTrx_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header Trx B", RGBRead(TableHeaderTrx_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Line Trx R", RGBRead(TableLineTrx_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line Trx G", RGBRead(TableLineTrx_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line Trx B", RGBRead(TableLineTrx_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Items Trx R", RGBRead(TableItemsTrx_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items Trx G", RGBRead(TableItemsTrx_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items Trx B", RGBRead(TableItemsTrx_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Title Trx R", RGBRead(TableTitleTrx_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title Trx G", RGBRead(TableTitleTrx_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title Trx B", RGBRead(TableTitleTrx_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Latest Transaction", txtLatestTransaction.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Date Trx", txtTableTrxDate.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Fund Trx", txtTableTrxFund.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Name Trx", txtTableTrxName.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Type Trx", txtTableTrxType.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Amount Trx", txtTableTrxAmount.Text.Trim)
                file.WriteString(reportSection, iniType & " Table NAV/Unit Trx", txtTableTrxNAVUnit.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Unit(s) Trx", txtTableTrxUnit.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Table Header Holding R", RGBRead(TableHeaderHolding_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header Holding G", RGBRead(TableHeaderHolding_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header Holding B", RGBRead(TableHeaderHolding_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Line Holding R", RGBRead(TableLineHolding_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line Holding G", RGBRead(TableLineHolding_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line Holding B", RGBRead(TableLineHolding_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Items Holding R", RGBRead(TableItemsHolding_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items Holding G", RGBRead(TableItemsHolding_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items Holding B", RGBRead(TableItemsHolding_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Title Holding R", RGBRead(TableTitleHolding_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title Holding G", RGBRead(TableTitleHolding_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title Holding B", RGBRead(TableTitleHolding_B.Text.Trim))
                file.WriteString(reportSection, iniType & " List of Unitholding", txtListOfUnitholding.Text.Trim)
                file.WriteString(reportSection, iniType & " Table No Holding", txtTableHoldingNo.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Fund Holding", txtTableHoldingFund.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Name Holding", txtTableHoldingName.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Type Holding", txtTableHoldingType.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Unit(s) Holding", txtTableHoldingUnit.Text.Trim)
                file.WriteString(reportSection, iniType & " Table NAV/Unit Holding", txtTableHoldingNAVUnit.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Avg. Cost Holding", txtTableHoldingAvgCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Value Holding", txtTableHoldingValue.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Acq. Cost Holding", txtTableHoldingAcqCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Unrealized P/L Holding", txtTableHoldingUnrealizedPL.Text.Trim)
            End If
            frm.pdfSetting()
            Close()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class