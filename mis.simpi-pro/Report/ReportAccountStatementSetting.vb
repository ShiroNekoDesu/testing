Imports simpi.GlobalConnection
Imports simpi.GlobalUtilities

Public Class ReportAccountStatementSetting
    Public frm As ReportAccountStatement
    Dim reportSection As String = "REPORT ACCOUNT HOLDER ACCOUNT STATEMENT"

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
                    txtPeriod.Text = file.GetString(reportSection, iniType & " Period", "")

                    r = file.GetInteger(reportSection, iniType & " NAV/Unit R", 0)
                    g = file.GetInteger(reportSection, iniType & " NAV/Unit G", 0)
                    b = file.GetInteger(reportSection, iniType & " NAV/Unit B", 0)
                    NAVUnit_R.Text = RGBWrite("R", r)
                    NAVUnit_G.Text = RGBWrite("G", g)
                    NAVUnit_B.Text = RGBWrite("B", b)
                    txtColorNAVUnit.BackColor = Color.FromArgb(r, g, b)
                    txtNAVUnit.Text = file.GetString(reportSection, iniType & " NAV/Unit", "")

                    r = file.GetInteger(reportSection, iniType & " Report Line R", 0)
                    g = file.GetInteger(reportSection, iniType & " Report Line G", 0)
                    b = file.GetInteger(reportSection, iniType & " Report Line B", 0)
                    ReportLine_R.Text = RGBWrite("R", r)
                    ReportLine_G.Text = RGBWrite("G", g)
                    ReportLine_B.Text = RGBWrite("B", b)
                    txtColorReportLine.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Portfolio R", 0)
                    g = file.GetInteger(reportSection, iniType & " Portfolio G", 0)
                    b = file.GetInteger(reportSection, iniType & " Portfolio B", 0)
                    Portfolio_R.Text = RGBWrite("R", r)
                    Portfolio_G.Text = RGBWrite("G", g)
                    Portfolio_B.Text = RGBWrite("B", b)
                    txtColorPortfolio.BackColor = Color.FromArgb(r, g, b)

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
                    b = file.GetInteger(reportSection, iniType & " Summary Items B", 0)
                    SummaryItems_R.Text = RGBWrite("R", r)
                    SummaryItems_G.Text = RGBWrite("G", g)
                    SummaryItems_B.Text = RGBWrite("B", b)
                    txtColorSummaryItems.BackColor = Color.FromArgb(r, g, b)
                    txtSummaryItemsTotalRedemption.Text = file.GetString(reportSection, iniType & " Summary Items Total Redemption", "")
                    txtSummaryItemsAcqCost.Text = file.GetString(reportSection, iniType & " Summary Items Acq Cost", "")
                    txtSummaryItemsRedemptionPL.Text = file.GetString(reportSection, iniType & " Summary Items Redemption PL", "")
                    txtSummaryItemsDividend.Text = file.GetString(reportSection, iniType & " Summary Items Dividend", "")
                    txtSummaryItemsRealizedPL.Text = file.GetString(reportSection, iniType & " Summary Items Realized PL", "")
                    txtSummaryItemsLastInvestmentValue.Text = file.GetString(reportSection, iniType & " Summary Items Last Investment Value", "")
                    txtSummaryItemsLastAcqCost.Text = file.GetString(reportSection, iniType & " Summary Items Last Acq Cost", "")
                    txtSummaryItemsUnrealizedPL.Text = file.GetString(reportSection, iniType & " Summary Items Unrealized PL", "")

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
                    txtChartLabel.Text = file.GetString(reportSection, iniType & " Chart Label", "")

                    r = file.GetInteger(reportSection, iniType & " Table Header R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Header G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Header B", 0)
                    TableHeader_R.Text = RGBWrite("R", r)
                    TableHeader_G.Text = RGBWrite("G", g)
                    TableHeader_B.Text = RGBWrite("B", b)
                    txtColorTableHeader.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Line R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Line G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Line B", 0)
                    TableLine_R.Text = RGBWrite("R", r)
                    TableLine_G.Text = RGBWrite("G", g)
                    TableLine_B.Text = RGBWrite("B", b)
                    txtColorTableLine.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Items R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Items G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Items B", 0)
                    TableItems_R.Text = RGBWrite("R", r)
                    TableItems_G.Text = RGBWrite("G", g)
                    TableItems_B.Text = RGBWrite("B", b)
                    txtColorTableItems.BackColor = Color.FromArgb(r, g, b)

                    r = file.GetInteger(reportSection, iniType & " Table Title R", 0)
                    g = file.GetInteger(reportSection, iniType & " Table Title G", 0)
                    b = file.GetInteger(reportSection, iniType & " Table Title B", 0)
                    TableTitle_R.Text = RGBWrite("R", r)
                    TableTitle_G.Text = RGBWrite("G", g)
                    TableTitle_B.Text = RGBWrite("B", b)
                    txtColorTableTitle.BackColor = Color.FromArgb(r, g, b)
                    txtTableTanggal.Text = file.GetString(reportSection, iniType & " Table Tanggal", "")
                    txtTableDate.Text = file.GetString(reportSection, iniType & " Table Date", "")
                    txtTableUraian.Text = file.GetString(reportSection, iniType & " Table Uraian", "")
                    txtTableDescription.Text = file.GetString(reportSection, iniType & " Table Description", "")
                    txtTableNilaiTransaksi.Text = file.GetString(reportSection, iniType & " Table Nilai Transaksi", "")
                    txtTableGross.Text = file.GetString(reportSection, iniType & " Table Gross", "")
                    txtTableNet.Text = file.GetString(reportSection, iniType & " Table Net", "")
                    txtTableHargaUP.Text = file.GetString(reportSection, iniType & " Table Harga/UP", "")
                    txtTableNAVUnit.Text = file.GetString(reportSection, iniType & " Table NAV/Unit", "")
                    txtTableUnitPenyertaan.Text = file.GetString(reportSection, iniType & " Table Unit Penyertaan", "")
                    txtTableBiayaPerolehan.Text = file.GetString(reportSection, iniType & " Table Biaya Perolehan", "")
                    txtTableAcqCost.Text = file.GetString(reportSection, iniType & " Table Acq. Cost", "")
                    txtTableLRRealisasi.Text = file.GetString(reportSection, iniType & " Table L/R Realisasi", "")
                    txtTableRealizedPL.Text = file.GetString(reportSection, iniType & " Table Realized P/L", "")
                    txtTableSaldoUP.Text = file.GetString(reportSection, iniType & " Table Saldo (UP)", "")
                    txtTableBalanceUnit.Text = file.GetString(reportSection, iniType & " Table Balance (Unit)", "")
                End If
            End If
        Catch ex As Exception
            _default()
        End Try
    End Sub

    'Private Sub iniLoad2(ByVal iniType As String)
    '    Try
    '        If iniType.Trim = "DEFAULT" Then
    '            _default()
    '        Else
    '            Dim ini = New IniFile(New IniOptions() With {.Encoding = Encoding.Unicode})
    '            Dim strFile As String = simpiFile("simpi.ini")
    '            If GlobalFileWindows.FileExists(strFile) Then
    '                ini.Load(strFile)
    '                ReportTitle_R.Text = ini.Sections(reportSection).Keys(iniType & " Report Title R").Value
    '                ReportTitle_G.Text = ini.Sections(reportSection).Keys(iniType & " Report Title G").Value
    '                ReportTitle_B.Text = ini.Sections(reportSection).Keys(iniType & " Report Title B").Value
    '                txtColorReportTitle.BackColor = Color.FromArgb(RGBRead(ReportTitle_R.Text), RGBRead(ReportTitle_G.Text), RGBRead(ReportTitle_B.Text))
    '                txtReportTitle.Text = ini.Sections(reportSection).Keys(iniType & " Report Title").Value

    '                Client_R.Text = ini.Sections(reportSection).Keys(iniType & " Client R").Value
    '                Client_G.Text = ini.Sections(reportSection).Keys(iniType & " Client G").Value
    '                Client_B.Text = ini.Sections(reportSection).Keys(iniType & " Client B").Value
    '                txtColorClient.BackColor = Color.FromArgb(RGBRead(Client_R.Text), RGBRead(Client_G.Text), RGBRead(Client_B.Text))
    '                txtPeriod.Text = ini.Sections(reportSection).Keys(iniType & " Period").Value

    '                NAVUnit_R.Text = ini.Sections(reportSection).Keys(iniType & " NAV/Unit R").Value
    '                NAVUnit_G.Text = ini.Sections(reportSection).Keys(iniType & " NAV/Unit G").Value
    '                NAVUnit_B.Text = ini.Sections(reportSection).Keys(iniType & " NAV/Unit B").Value
    '                txtColorNAVUnit.BackColor = Color.FromArgb(RGBRead(NAVUnit_R.Text), RGBRead(NAVUnit_G.Text), RGBRead(NAVUnit_B.Text))
    '                txtNAVUnit.Text = ini.Sections(reportSection).Keys(iniType & " NAV/Unit").Value

    '                ReportLine_R.Text = ini.Sections(reportSection).Keys(iniType & " Report Line R").Value
    '                ReportLine_G.Text = ini.Sections(reportSection).Keys(iniType & " Report Line G").Value
    '                ReportLine_B.Text = ini.Sections(reportSection).Keys(iniType & " Report Line B").Value
    '                txtColorReportLine.BackColor = Color.FromArgb(RGBRead(ReportLine_R.Text), RGBRead(ReportLine_G.Text), RGBRead(ReportLine_B.Text))

    '                Portfolio_R.Text = ini.Sections(reportSection).Keys(iniType & " Portfolio R").Value
    '                Portfolio_G.Text = ini.Sections(reportSection).Keys(iniType & " Portfolio G").Value
    '                Portfolio_B.Text = ini.Sections(reportSection).Keys(iniType & " Portfolio B").Value
    '                txtColorPortfolio.BackColor = Color.FromArgb(RGBRead(Portfolio_R.Text), RGBRead(Portfolio_G.Text), RGBRead(Portfolio_B.Text))

    '                Summary_R.Text = ini.Sections(reportSection).Keys(iniType & " Summary R").Value
    '                Summary_G.Text = ini.Sections(reportSection).Keys(iniType & " Summary G").Value
    '                Summary_B.Text = ini.Sections(reportSection).Keys(iniType & " Summary B").Value
    '                txtColorSummary.BackColor = Color.FromArgb(RGBRead(Summary_R.Text), RGBRead(Summary_G.Text), RGBRead(Summary_B.Text))
    '                txtSummary.Text = ini.Sections(reportSection).Keys(iniType & " Summary").Value

    '                SummaryLine_R.Text = ini.Sections(reportSection).Keys(iniType & " Summary Line R").Value
    '                SummaryLine_G.Text = ini.Sections(reportSection).Keys(iniType & " Summary Line G").Value
    '                SummaryLine_B.Text = ini.Sections(reportSection).Keys(iniType & " Summary Line B").Value
    '                txtColorSummaryLine.BackColor = Color.FromArgb(RGBRead(SummaryLine_R.Text), RGBRead(SummaryLine_G.Text), RGBRead(SummaryLine_B.Text))

    '                SummaryItems_R.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items R").Value
    '                SummaryItems_G.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items G").Value
    '                SummaryItems_B.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items B").Value
    '                txtColorSummaryItems.BackColor = Color.FromArgb(RGBRead(SummaryItems_R.Text), RGBRead(SummaryItems_G.Text), RGBRead(SummaryItems_B.Text))
    '                txtSummaryItemsTotalRedemption.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Total Redemption").Value
    '                txtSummaryItemsAcqCost.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Acq Cost").Value
    '                txtSummaryItemsRedemptionPL.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Redemption PL").Value
    '                txtSummaryItemsDividend.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Dividend").Value
    '                txtSummaryItemsRealizedPL.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Realized PL").Value
    '                txtSummaryItemsLastInvestmentValue.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Last Investment Value").Value
    '                txtSummaryItemsLastAcqCost.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Last Acq Cost").Value
    '                txtSummaryItemsUnrealizedPL.Text = ini.Sections(reportSection).Keys(iniType & " Summary Items Unrealized PL").Value

    '                ChartTitle_R.Text = ini.Sections(reportSection).Keys(iniType & " Chart Title R").Value
    '                ChartTitle_G.Text = ini.Sections(reportSection).Keys(iniType & " Chart Title G").Value
    '                ChartTitle_B.Text = ini.Sections(reportSection).Keys(iniType & " Chart Title B").Value
    '                txtColorChartTitle.BackColor = Color.FromArgb(RGBRead(ChartTitle_R.Text), RGBRead(ChartTitle_G.Text), RGBRead(ChartTitle_B.Text))
    '                txtInvestmentGrowth.Text = ini.Sections(reportSection).Keys(iniType & " Investment Growth").Value

    '                ChartBorder_R.Text = ini.Sections(reportSection).Keys(iniType & " Chart Border R").Value
    '                ChartBorder_G.Text = ini.Sections(reportSection).Keys(iniType & " Chart Border G").Value
    '                ChartBorder_B.Text = ini.Sections(reportSection).Keys(iniType & " Chart Border B").Value
    '                txtColorChartBorder.BackColor = Color.FromArgb(RGBRead(ChartBorder_R.Text), RGBRead(ChartBorder_G.Text), RGBRead(ChartBorder_B.Text))
    '                If ini.Sections(reportSection).Keys(iniType & " Chart Border").Value.Trim.ToUpper = "YES" Then
    '                    chkChartBorder.Checked = True
    '                Else
    '                    chkChartBorder.Checked = False
    '                End If

    '                ChartLine_R.Text = ini.Sections(reportSection).Keys(iniType & " Chart Line R").Value
    '                ChartLine_G.Text = ini.Sections(reportSection).Keys(iniType & " Chart Line G").Value
    '                ChartLine_B.Text = ini.Sections(reportSection).Keys(iniType & " Chart Line B").Value
    '                txtColorChartLine.BackColor = Color.FromArgb(RGBRead(ChartLine_R.Text), RGBRead(ChartLine_G.Text), RGBRead(ChartLine_B.Text))
    '                txtChartLabel.Text = ini.Sections(reportSection).Keys(iniType & " Chart Label").Value

    '                TableHeader_R.Text = ini.Sections(reportSection).Keys(iniType & " Table Header R").Value
    '                TableHeader_G.Text = ini.Sections(reportSection).Keys(iniType & " Table Header G").Value
    '                TableHeader_B.Text = ini.Sections(reportSection).Keys(iniType & " Table Header B").Value
    '                txtColorTableHeader.BackColor = Color.FromArgb(RGBRead(TableHeader_R.Text), RGBRead(TableHeader_G.Text), RGBRead(TableHeader_B.Text))

    '                TableLine_R.Text = ini.Sections(reportSection).Keys(iniType & " Table Line R").Value
    '                TableLine_G.Text = ini.Sections(reportSection).Keys(iniType & " Table Line G").Value
    '                TableLine_B.Text = ini.Sections(reportSection).Keys(iniType & " Table Line B").Value
    '                txtColorTableLine.BackColor = Color.FromArgb(RGBRead(TableLine_R.Text), RGBRead(TableLine_G.Text), RGBRead(TableLine_B.Text))

    '                TableItems_R.Text = ini.Sections(reportSection).Keys(iniType & " Table Items R").Value
    '                TableItems_G.Text = ini.Sections(reportSection).Keys(iniType & " Table Items G").Value
    '                TableItems_B.Text = ini.Sections(reportSection).Keys(iniType & " Table Items B").Value
    '                txtColorTableItems.BackColor = Color.FromArgb(RGBRead(TableItems_R.Text), RGBRead(TableItems_G.Text), RGBRead(TableItems_B.Text))

    '                TableTitle_R.Text = ini.Sections(reportSection).Keys(iniType & " Table Title R").Value
    '                TableTitle_G.Text = ini.Sections(reportSection).Keys(iniType & " Table Title G").Value
    '                TableTitle_B.Text = ini.Sections(reportSection).Keys(iniType & " Table Title B").Value
    '                txtColorTableTitle.BackColor = Color.FromArgb(RGBRead(TableTitle_R.Text), RGBRead(TableTitle_G.Text), RGBRead(TableTitle_B.Text))
    '                txtTableTanggal.Text = ini.Sections(reportSection).Keys(iniType & " Table Tanggal").Value
    '                txtTableDate.Text = ini.Sections(reportSection).Keys(iniType & " Table Date").Value
    '                txtTableUraian.Text = ini.Sections(reportSection).Keys(iniType & " Table Uraian").Value
    '                txtTableDescription.Text = ini.Sections(reportSection).Keys(iniType & " Table Description").Value
    '                txtTableNilaiTransaksi.Text = ini.Sections(reportSection).Keys(iniType & " Table Nilai Transaksi").Value
    '                txtTableGross.Text = ini.Sections(reportSection).Keys(iniType & " Table Gross").Value
    '                txtTableNet.Text = ini.Sections(reportSection).Keys(iniType & " Table Net").Value
    '                txtTableHargaUP.Text = ini.Sections(reportSection).Keys(iniType & " Table Harga/UP").Value
    '                txtTableNAVUnit.Text = ini.Sections(reportSection).Keys(iniType & " Table NAV/Unit").Value
    '                txtTableUnitPenyertaan.Text = ini.Sections(reportSection).Keys(iniType & " Table Unit Penyertaan").Value
    '                txtTableBiayaPerolehan.Text = ini.Sections(reportSection).Keys(iniType & " Table Biaya Perolehan").Value
    '                txtTableAcqCost.Text = ini.Sections(reportSection).Keys(iniType & " Table Acq. Cost").Value
    '                txtTableLRRealisasi.Text = ini.Sections(reportSection).Keys(iniType & " Table L/R Realisasi").Value
    '                txtTableRealizedPL.Text = ini.Sections(reportSection).Keys(iniType & " Table Realized P/L").Value
    '                txtTableSaldoUP.Text = ini.Sections(reportSection).Keys(iniType & " Table Saldo (UP)").Value
    '                txtTableBalanceUnit.Text = ini.Sections(reportSection).Keys(iniType & " Table Balance (Unit)").Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        _default()
    '    End Try
    'End Sub

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
            txtPeriod.Text = .Period
            NAVUnit_R.Text = "R: " & .NAVUnit_R
            NAVUnit_G.Text = "G: " & .NAVUnit_G
            NAVUnit_B.Text = "B: " & .NAVUnit_B
            txtColorNAVUnit.BackColor = Color.FromArgb(.NAVUnit_R, .NAVUnit_G, .NAVUnit_B)
            txtNAVUnit.Text = .NAVUnit
            ReportLine_R.Text = "R: " & .ReportLine_R
            ReportLine_G.Text = "G: " & .ReportLine_G
            ReportLine_B.Text = "B: " & .ReportLine_B
            txtColorReportLine.BackColor = Color.FromArgb(.ReportLine_R, .ReportLine_G, .ReportLine_B)
            Portfolio_R.Text = "R: " & .Portfolio_R
            Portfolio_G.Text = "G: " & .Portfolio_G
            Portfolio_B.Text = "B: " & .Portfolio_B
            txtColorPortfolio.BackColor = Color.FromArgb(.Portfolio_R, .Portfolio_G, .Portfolio_B)
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
            txtSummaryItemsTotalRedemption.Text = .SummaryItemsTotalRedemption
            txtSummaryItemsAcqCost.Text = .SummaryItemsAcqCost
            txtSummaryItemsRedemptionPL.Text = .SummaryItemsRedemptionPL
            txtSummaryItemsDividend.Text = .SummaryItemsDividend
            txtSummaryItemsRealizedPL.Text = .SummaryItemsRealizedPL
            txtSummaryItemsLastInvestmentValue.Text = .SummaryItemsLastInvestmentValue
            txtSummaryItemsLastAcqCost.Text = .SummaryItemsLastAcqCost
            txtSummaryItemsUnrealizedPL.Text = .SummaryItemsUnrealizedPL
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
            txtChartLabel.Text = .ChartLabel
            TableHeader_R.Text = "R: " & .TableHeader_R
            TableHeader_G.Text = "G: " & .TableHeader_G
            TableHeader_B.Text = "B: " & .TableHeader_B
            txtColorTableHeader.BackColor = Color.FromArgb(.TableHeader_R, .TableHeader_G, .TableHeader_B)
            TableLine_R.Text = "R: " & .TableLine_R
            TableLine_G.Text = "G: " & .TableLine_G
            TableLine_B.Text = "B: " & .TableLine_B
            txtColorTableLine.BackColor = Color.FromArgb(.TableLine_R, .TableLine_G, .TableLine_B)
            TableItems_R.Text = "R: " & .TableItems_R
            TableItems_G.Text = "G: " & .TableItems_G
            TableItems_B.Text = "B: " & .TableItems_B
            txtColorTableItems.BackColor = Color.FromArgb(.TableItems_R, .TableItems_G, .TableItems_B)
            TableTitle_R.Text = "R: " & .TableTitle_R
            TableTitle_G.Text = "G: " & .TableTitle_G
            TableTitle_B.Text = "B: " & .TableTitle_B
            txtColorTableTitle.BackColor = Color.FromArgb(.TableTitle_R, .TableTitle_G, .TableTitle_B)
            txtTableTanggal.Text = .TableTitleTanggal
            txtTableDate.Text = .TableTitleDate
            txtTableUraian.Text = .TableTitleUraian
            txtTableDescription.Text = .TableTitleDescription
            txtTableNilaiTransaksi.Text = .TableTitleNilaiTransaksi
            txtTableGross.Text = .TableTitleGross
            txtTableNet.Text = .TableTitleNet
            txtTableHargaUP.Text = .TableTitleHargaUP
            txtTableNAVUnit.Text = .TableTitleNAVUnit
            txtTableUnitPenyertaan.Text = .TableTitleUnitPenyertaan
            txtTableBiayaPerolehan.Text = .TableTitleBiayaPerolehan
            txtTableAcqCost.Text = .TableTitleAcqCost
            txtTableLRRealisasi.Text = .TableTitleLRRealisasi
            txtTableRealizedPL.Text = .TableTitleRealizedPL
            txtTableSaldoUP.Text = .TableTitleSaldoUP
            txtTableBalanceUnit.Text = .TableTitleBalanceUnit
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
                file.WriteString(reportSection, iniType & " period", txtPeriod.Text.Trim)

                file.WriteInteger(reportSection, iniType & " NAV/Unit R", RGBRead(NAVUnit_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " NAV/Unit G", RGBRead(NAVUnit_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " NAV/Unit B", RGBRead(NAVUnit_B.Text.Trim))
                file.WriteString(reportSection, iniType & " NAV/Unit", txtNAVUnit.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Report Line R", RGBRead(ReportLine_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Line G", RGBRead(ReportLine_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Report Line B", RGBRead(ReportLine_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Portfolio R", RGBRead(Portfolio_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Portfolio G", RGBRead(Portfolio_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Portfolio B", RGBRead(Portfolio_B.Text.Trim))

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
                file.WriteString(reportSection, iniType & " Summary Items Total Redemption", txtSummaryItemsTotalRedemption.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Acq Cost", txtSummaryItemsAcqCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Redemption PL", txtSummaryItemsRedemptionPL.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Dividend", txtSummaryItemsDividend.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Realized PL", txtSummaryItemsRealizedPL.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Last Investment Value", txtSummaryItemsLastInvestmentValue.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Last Acq Cost", txtSummaryItemsLastAcqCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Summary Items Unrealized PL", txtSummaryItemsUnrealizedPL.Text.Trim)

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
                file.WriteString(reportSection, iniType & " Chart Label", txtChartLabel.Text.Trim)

                file.WriteInteger(reportSection, iniType & " Table Header R", RGBRead(TableHeader_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header G", RGBRead(TableHeader_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Header B", RGBRead(TableHeader_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Line R", RGBRead(TableLine_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line G", RGBRead(TableLine_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Line B", RGBRead(TableLine_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Items R", RGBRead(TableItems_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items G", RGBRead(TableItems_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Items B", RGBRead(TableItems_B.Text.Trim))

                file.WriteInteger(reportSection, iniType & " Table Title R", RGBRead(TableTitle_R.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title G", RGBRead(TableTitle_G.Text.Trim))
                file.WriteInteger(reportSection, iniType & " Table Title B", RGBRead(TableTitle_B.Text.Trim))
                file.WriteString(reportSection, iniType & " Table Tanggal", txtTableTanggal.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Date", txtTableTanggal.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Uraian", txtTableUraian.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Description", txtTableDescription.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Nilai Transaksi", txtTableNilaiTransaksi.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Gross", txtTableGross.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Net", txtTableNet.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Harga/UP", txtTableHargaUP.Text.Trim)
                file.WriteString(reportSection, iniType & " Table NAV/Unit", txtTableNAVUnit.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Unit Penyertaan", txtTableUnitPenyertaan.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Biaya Perolehan", txtTableBiayaPerolehan.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Acq. Cost", txtTableAcqCost.Text.Trim)
                file.WriteString(reportSection, iniType & " Table L/R Realisasi", txtTableLRRealisasi.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Realized P/L", txtTableRealizedPL.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Saldo (UP)", txtTableSaldoUP.Text.Trim)
                file.WriteString(reportSection, iniType & " Table Balance (Unit)", txtTableBalanceUnit.Text.Trim)
            End If

            Close()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub iniSave2(ByVal iniType As String)
    '    Try
    '        Dim file As New IniFile(New IniOptions() With {.Encoding = Encoding.Unicode})
    '        Dim strFile As String = simpiFile("simpi.ini")
    '        Dim section As IniSection = file.Sections.Add(reportSection)
    '        section.Keys.Add("LAYOUT", iniType)
    '        If iniType.Trim <> "DEFAULT" Then
    '            section.Keys.Add(iniType & " Report Title R", ReportTitle_R.Text.Trim)
    '            section.Keys.Add(iniType & " Report Title G", ReportTitle_G.Text.Trim)
    '            section.Keys.Add(iniType & " Report Title B", ReportTitle_B.Text.Trim)
    '            section.Keys.Add(iniType & " Report Title", txtReportTitle.Text.Trim)

    '            section.Keys.Add(iniType & " Client R", Client_R.Text.Trim)
    '            section.Keys.Add(iniType & " Client G", Client_G.Text.Trim)
    '            section.Keys.Add(iniType & " Client B", Client_B.Text.Trim)
    '            section.Keys.Add(iniType & " period", txtPeriod.Text.Trim)

    '            section.Keys.Add(iniType & " NAV/Unit R", Client_R.Text.Trim)
    '            section.Keys.Add(iniType & " NAV/Unit G", Client_G.Text.Trim)
    '            section.Keys.Add(iniType & " NAV/Unit B", Client_B.Text.Trim)
    '            section.Keys.Add(iniType & " NAV/Unit", txtPeriod.Text.Trim)

    '            section.Keys.Add(iniType & " Report Line R", ReportLine_R.Text.Trim)
    '            section.Keys.Add(iniType & " Report Line G", ReportLine_G.Text.Trim)
    '            section.Keys.Add(iniType & " Report Line B", ReportLine_B.Text.Trim)

    '            section.Keys.Add(iniType & " Portfolio R", Portfolio_R.Text.Trim)
    '            section.Keys.Add(iniType & " Portfolio G", Portfolio_G.Text.Trim)
    '            section.Keys.Add(iniType & " Portfolio B", Portfolio_B.Text.Trim)

    '            section.Keys.Add(iniType & " Summary R", Summary_R.Text.Trim)
    '            section.Keys.Add(iniType & " Summary G", Summary_G.Text.Trim)
    '            section.Keys.Add(iniType & " Summary B", Summary_B.Text.Trim)
    '            section.Keys.Add(iniType & " Summary", txtSummary.Text.Trim)

    '            section.Keys.Add(iniType & " Summary Line R", SummaryLine_R.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Line G", SummaryLine_G.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Line B", SummaryLine_B.Text.Trim)

    '            section.Keys.Add(iniType & " Summary Items R", SummaryItems_R.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items G", SummaryItems_G.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items B", SummaryItems_B.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Total Redemption", txtSummaryItemsTotalRedemption.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Acq Cost", txtSummaryItemsAcqCost.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Redemption PL", txtSummaryItemsRedemptionPL.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Dividend", txtSummaryItemsDividend.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Realized PL", txtSummaryItemsRealizedPL.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Last Investment Value", txtSummaryItemsLastInvestmentValue.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Last Acq Cost", txtSummaryItemsLastAcqCost.Text.Trim)
    '            section.Keys.Add(iniType & " Summary Items Unrealized PL", txtSummaryItemsUnrealizedPL.Text.Trim)

    '            section.Keys.Add(iniType & " Chart Title R", ChartTitle_R.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Title G", ChartTitle_G.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Title B", ChartTitle_B.Text.Trim)
    '            section.Keys.Add(iniType & " Investment Growth", txtInvestmentGrowth.Text.Trim)

    '            section.Keys.Add(iniType & " Chart Border R", ChartBorder_R.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Border G", ChartBorder_G.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Border B", ChartBorder_B.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Border", IIf(chkChartBorder.Checked, "YES", "NO"))

    '            section.Keys.Add(iniType & " Chart Line R", ChartLine_R.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Line G", ChartLine_G.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Line B", ChartLine_B.Text.Trim)
    '            section.Keys.Add(iniType & " Chart Label", txtChartLabel.Text.Trim)

    '            section.Keys.Add(iniType & " Table Header R", TableHeader_R.Text.Trim)
    '            section.Keys.Add(iniType & " Table Header G", TableHeader_G.Text.Trim)
    '            section.Keys.Add(iniType & " Table Header B", TableHeader_B.Text.Trim)

    '            section.Keys.Add(iniType & " Table Line R", TableLine_R.Text.Trim)
    '            section.Keys.Add(iniType & " Table Line G", TableLine_G.Text.Trim)
    '            section.Keys.Add(iniType & " Table Line B", TableLine_B.Text.Trim)

    '            section.Keys.Add(iniType & " Table Items R", TableItems_R.Text.Trim)
    '            section.Keys.Add(iniType & " Table Items G", TableItems_G.Text.Trim)
    '            section.Keys.Add(iniType & " Table Items B", TableItems_B.Text.Trim)

    '            section.Keys.Add(iniType & " Table Title R", TableTitle_R.Text.Trim)
    '            section.Keys.Add(iniType & " Table Title G", TableTitle_G.Text.Trim)
    '            section.Keys.Add(iniType & " Table Title B", TableTitle_B.Text.Trim)
    '            section.Keys.Add(iniType & " Table Tanggal", txtTableTanggal.Text.Trim)
    '            section.Keys.Add(iniType & " Table Date", txtTableTanggal.Text.Trim)
    '            section.Keys.Add(iniType & " Table Uraian", txtTableUraian.Text.Trim)
    '            section.Keys.Add(iniType & " Table Description", txtTableDescription.Text.Trim)
    '            section.Keys.Add(iniType & " Table Nilai Transaksi", txtTableNilaiTransaksi.Text.Trim)
    '            section.Keys.Add(iniType & " Table Gross", txtTableGross.Text.Trim)
    '            section.Keys.Add(iniType & " Table Net", txtTableNet.Text.Trim)
    '            section.Keys.Add(iniType & " Table Harga/UP", txtTableHargaUP.Text.Trim)
    '            section.Keys.Add(iniType & " Table NAV/Unit", txtTableNAVUnit.Text.Trim)
    '            section.Keys.Add(iniType & " Table Unit Penyertaan", txtTableUnitPenyertaan.Text.Trim)
    '            section.Keys.Add(iniType & " Table Biaya Perolehan", txtTableBiayaPerolehan.Text.Trim)
    '            section.Keys.Add(iniType & " Table Acq. Cost", txtTableAcqCost.Text.Trim)
    '            section.Keys.Add(iniType & " Table L/R Realisasi", txtTableLRRealisasi.Text.Trim)
    '            section.Keys.Add(iniType & " Table Realized P/L", txtTableRealizedPL.Text.Trim)
    '            section.Keys.Add(iniType & " Table Saldo (UP)", txtTableSaldoUP.Text.Trim)
    '            section.Keys.Add(iniType & " Table Balance (Unit)", txtTableBalanceUnit.Text.Trim)
    '        End If

    '        file.Save(strFile)
    '        Close()
    '    Catch ex As Exception
    '        ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

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
        ElseIf rbNAVUnit.Checked Then
            txtColorNAVUnit.BackColor = Color.FromArgb(r, g, b)
            NAVUnit_R.Text = RGBWrite("R", r)
            NAVUnit_G.Text = RGBWrite("G", g)
            NAVUnit_B.Text = RGBWrite("B", b)
        ElseIf rbPortfolio.Checked Then
            txtColorPortfolio.BackColor = Color.FromArgb(r, g, b)
            Portfolio_R.Text = RGBWrite("R", r)
            Portfolio_G.Text = RGBWrite("G", g)
            Portfolio_B.Text = RGBWrite("B", b)
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
        ElseIf rbTableHeader.Checked Then
            txtColorTableHeader.BackColor = Color.FromArgb(r, g, b)
            TableHeader_R.Text = RGBWrite("R", r)
            TableHeader_G.Text = RGBWrite("G", g)
            TableHeader_B.Text = RGBWrite("B", b)
        ElseIf rbTableLine.Checked Then
            txtColorTableLine.BackColor = Color.FromArgb(r, g, b)
            TableLine_R.Text = RGBWrite("R", r)
            TableLine_G.Text = RGBWrite("G", g)
            TableLine_B.Text = RGBWrite("B", b)
        ElseIf rbTableItems.Checked Then
            txtColorTableItems.BackColor = Color.FromArgb(r, g, b)
            TableItems_R.Text = RGBWrite("R", r)
            TableItems_G.Text = RGBWrite("G", g)
            TableItems_B.Text = RGBWrite("B", b)
        ElseIf rbTableTitle.Checked Then
            txtColorTableTitle.BackColor = Color.FromArgb(r, g, b)
            TableTitle_R.Text = RGBWrite("R", r)
            TableTitle_G.Text = RGBWrite("G", g)
            TableTitle_B.Text = RGBWrite("B", b)
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
        ElseIf rbNAVUnit.Checked Then
            txtR.Text = RGBRead(NAVUnit_R.Text)
            txtG.Text = RGBRead(NAVUnit_G.Text)
            txtB.Text = RGBRead(NAVUnit_B.Text)
        ElseIf rbPortfolio.Checked Then
            txtR.Text = RGBRead(Portfolio_R.Text)
            txtG.Text = RGBRead(Portfolio_G.Text)
            txtB.Text = RGBRead(Portfolio_B.Text)
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
        ElseIf rbTableHeader.Checked Then
            txtR.Text = RGBRead(TableHeader_R.Text)
            txtG.Text = RGBRead(TableHeader_G.Text)
            txtB.Text = RGBRead(TableHeader_B.Text)
        ElseIf rbTableLine.Checked Then
            txtR.Text = RGBRead(TableLine_R.Text)
            txtG.Text = RGBRead(TableLine_G.Text)
            txtB.Text = RGBRead(TableLine_B.Text)
        ElseIf rbTableItems.Checked Then
            txtR.Text = RGBRead(TableItems_R.Text)
            txtG.Text = RGBRead(TableItems_G.Text)
            txtB.Text = RGBRead(TableItems_B.Text)
        ElseIf rbTableTitle.Checked Then
            txtR.Text = RGBRead(TableTitle_R.Text)
            txtG.Text = RGBRead(TableTitle_G.Text)
            txtB.Text = RGBRead(TableTitle_B.Text)
        End If
    End Sub

    Private Sub rbReportTitle_CheckedChanged(sender As Object, e As EventArgs) Handles rbReportTitle.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbClient_CheckedChanged(sender As Object, e As EventArgs) Handles rbClient.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbNAVUnit_CheckedChanged(sender As Object, e As EventArgs) Handles rbNAVUnit.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbPortfolio_CheckedChanged(sender As Object, e As EventArgs) Handles rbPortfolio.CheckedChanged
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

    Private Sub rbTableHeader_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableHeader.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableLine.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableItems_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableItems.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbTableTitle_CheckedChanged(sender As Object, e As EventArgs) Handles rbTableTitle.CheckedChanged
        colorGet()
    End Sub

    Private Sub rbReportLine_CheckedChanged(sender As Object, e As EventArgs) Handles rbReportLine.CheckedChanged
        colorGet()
    End Sub


#End Region

End Class