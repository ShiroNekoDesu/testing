Imports simpi.CoreData
Imports simpi.GlobalUtilities
Imports simpi.MasterPortfolio
Imports simpi.MasterSimpi

Public Class ReportFundDistribution
    Dim objPortfolio As New MasterPortfolio
    Dim objSimpi As New MasterSimpi
    Dim objDividend As New PortfolioDistribution

    Private Sub FormSchedulleDividend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objDividend.UserAccess = objAccess
        dtTo.Value = Now
        dtFrom.Value = Now.AddDays(-30)
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
        initNAV()
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

    Private Sub initNAV()
        With fgNAV
            .Rows.Count = 1
            .Cols.Count = 4
            .ExtendLastCol = False
            fgNAV(0, 0) = "ID"
            fgNAV(0, 1) = "NAV"
            fgNAV(0, 2) = "Payment"
            fgNAV(0, 3) = "Rate"
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        NAVSearch()
    End Sub

    Private Sub NAVSearch()
        Dim tbl As New DataTable
        objDividend.Clear()
        tbl = objDividend.SearchHistory(objPortfolio, dtFrom.Value, dtTo.Value)
        initNAV()
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            Dim q = From t In tbl.AsEnumerable
                    Select ID = t.Field(Of Integer)("DistributionID"),
                           NAV = t.Field(Of Date)("DateNAV"),
                           Payment = t.Field(Of Date)("DateDistribution"),
                           Rate = t.Field(Of Decimal)("DividendRate")
            For Each item In q
                fgNAV.Rows.Add()
                fgNAV(fgNAV.Rows.Count - 1, 0) = item.ID
                fgNAV(fgNAV.Rows.Count - 1, 1) = item.NAV.ToString("dd-MMM-yyyy")
                fgNAV(fgNAV.Rows.Count - 1, 2) = item.Payment.ToString("dd-MMM-yyyy")
                fgNAV(fgNAV.Rows.Count - 1, 3) = item.Rate
            Next
            fgNAV.AutoSizeCols()
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(False)
    End Sub

    Public Function ExportExcel(ByVal isSave As Boolean) As String
        Return PrintExcel(False, fgNAV, "ReportDS" & lblPortfolioCode.Text.Trim & dtFrom.Value.ToString("yyyymmdd") & ".xls")
    End Function

End Class