Imports System.Xml
Imports simpi.GlobalUtilities
Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSales
Imports simpi.MasterClient

Public Class MISCrosstabAUM
    Dim objBalance As New PositionCapital
    Dim dtBalance As New DataTable
    Dim dtDetail As New DataTable
    Dim dtIndividu As New DataTable
    Dim dtInstitusi As New DataTable

    Private Sub MISCrosstabAUM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetMasterSimpi()
        GetPortfolioUser()
        GetSalesMaster()
        GetClientMaster()
        GetClientKYC()
        GetParameterCountry()
        objBalance.UserAccess = objAccess
        dtAs.Value = Now
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataLoad
    End Sub

    Private Sub DataLoad()
        objBalance.Clear()
        dtBalance = objBalance.Search(objMasterSimpi, dtAs.Value)
        If objBalance.ErrID = 0 Then
            dtDetail = objBalance.Detail_Search(objMasterSimpi, dtAs.Value)
            _viewAll()
        Else
            ExceptionMessage.Show(objBalance.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub _viewAll()
        Dim q = From b In dtBalance.AsEnumerable Join d In dtDetail.AsEnumerable
                On b.Field(Of Integer)("PortfolioID") Equals d.Field(Of Integer)("PortfolioID") And
                   b.Field(Of Integer)("simpiID") Equals d.Field(Of Integer)("simpiID") And
                   b.Field(Of Integer)("ClientID") Equals d.Field(Of Integer)("ClientID")
                Join f In dtPortfolioUser.AsEnumerable On b.Field(Of Integer)("PortfolioID") Equals f.Field(Of Integer)("PortfolioID")
                Join s In dtSalesMaster.AsEnumerable On d.Field(Of Integer)("SalesID") Equals s.Field(Of Integer)("SalesID")
                Join c In dtClientMaster.AsEnumerable On b.Field(Of Integer)("simpiID") Equals c.Field(Of Integer)("simpiID") And
                                                         b.Field(Of Integer)("ClientID") Equals c.Field(Of Integer)("ClientID")
                Select Fund = f.Field(Of String)("PortfolioCode"),
                    Sales = s.Field(Of String)("SalesCode"),
                    Client = c.Field(Of String)("ClientName"),
                    City = c.Field(Of String)("CorrespondenceCity"),
                    AUM = b.Field(Of Decimal)("UnitPrice") * d.Field(Of Decimal)("AcqUnit")

        ' use LINQ query as DataSource
        cop.DataSource = q.ToList()

        ' show default view
        Dim olap = cop.OlapPanel.OlapEngine
        olap.BeginUpdate()
        olap.ColumnFields.Add("Fund")
        olap.RowFields.Add("Sales")
        olap.RowFields.Add("City")
        olap.ValueFields.Add("AUM")
        olap.ShowTotalsRows = C1.Olap.ShowTotals.Subtotals
        olap.EndUpdate()

        cop.OlapGrid.AllowSorting = True
    End Sub

End Class