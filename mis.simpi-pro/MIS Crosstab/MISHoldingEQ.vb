Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1Chart
Imports simpi.GlobalUtilities
Imports simpi.GlobalUtilities.GlobalDate
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSecurities

Public Class MISHoldingEQ
    Dim objPortfolio As New MasterPortfolio
    Dim objPosition As New PositionSecurities
    Dim objNAV As New PortfolioNAV

    Dim dtPosition As New DataTable
    Private Sub ReportHoldingEQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        GetPortfolioSimpi()
        GetComboInit(New ParameterCountry, cmbCcy, "CountryID", "Ccy")
        objPortfolio.UserAccess = objAccess
        objPosition.UserAccess = objAccess
        objNAV.UserAccess = objAccess
        DBGHolding.FetchRowStyles = True
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
        DBGHolding.Columns.Clear()
        chartGICS.Reset()
        chartJCI.Reset()
    End Sub

    Private Sub DataLoad()
        objPosition.Clear()
        'dtPosition = objPosition.Search(dtAs.Value)
        '
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
        'display

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
        form.MdiParent = MDISO
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
                'display

            Else
                ExceptionMessage.Show(objPortfolio.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#Region "holding"

#End Region

#Region "GICS"

#End Region

#Region "JCI"

#End Region

End Class