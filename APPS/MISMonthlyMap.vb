Imports simpi.CoreData
Imports simpi.MasterPortfolio
Imports simpi.MasterSimpi
Imports simpi.GlobalUtilities

Public Class MISMonthlyMap
    Dim objPortfolio As New MasterPortfolio
    Dim objSimpi As New MasterSimpi
    Dim objReturn As New PortfolioReturn

    Private Sub MISMonthlyMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPortfolio.UserAccess = objAccess
        objSimpi.UserAccess = objAccess
        objReturn.UserAccess = objAccess
        dtAs.Value = Now
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
        form.MdiParent = mdimenu
        lblPortfolioCode.Text = ""
        lblPortfolioName.Text = ""
        lblSimpiEmail.Text = ""
        lblSimpiName.Text = ""
        initMonth()
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

    Private Sub initMonth()
        With fgMonth
            .Rows.Count = 1
            .Cols.Count = 13
            .ExtendLastCol = False
            fgMonth(0, 0) = "YEAR"
            fgMonth(0, 1) = "JAN"
            fgMonth(0, 2) = "FEB"
            fgMonth(0, 3) = "MAR"
            fgMonth(0, 4) = "APR"
            fgMonth(0, 5) = "MAY"
            fgMonth(0, 6) = "JUN"
            fgMonth(0, 7) = "JUL"
            fgMonth(0, 8) = "AUG"
            fgMonth(0, 9) = "SEP"
            fgMonth(0, 10) = "OCT"
            fgMonth(0, 11) = "NOV"
            fgMonth(0, 12) = "DEC"
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            For i = 0 To 12
                fgMonth.Cols(i).Width = 65
            Next
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadMonth()
    End Sub

    Private Sub LoadMonth()
        If objPortfolio.GetPortfolioID > 0 Then
            initMonth()

            objReturn.Clear()
            objReturn.LoadLast(objPortfolio, New Date(dtAs.Value.Year, 12, 31))
            If objReturn.ErrID = 0 Then
                dtAs.Value = objReturn.GetPositionDate
                fgMonth.Rows.Add()
                fgMonth(fgMonth.Rows.Count - 1, 0) = objReturn.GetPositionDate.ToString("yyyy")
                fgMonth(fgMonth.Rows.Count - 1, 1) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 2) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 3) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 4) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 5) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 6) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 7) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 8) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 9) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 10) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 11) = (objReturn.GetrM1 * 100).ToString("n2")
                fgMonth(fgMonth.Rows.Count - 1, 12) = (objReturn.GetrM1 * 100).ToString("n2")


                Dim tbl As New DataTable
                tbl = objReturn.SearchEOY(objPortfolio, objPortfolio.GetInceptionDate, dtAs.Value)
                If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
                    Dim q = From r In tbl.AsEnumerable
                            Order By r.Field(Of Date)("PositionDate") Descending
                            Select year = r.Field(Of Date)("PositionDate").Year,
                                rM1 = (r.Field(Of Decimal)("rM1") * 100).ToString("n2"),
                                rM2 = (r.Field(Of Decimal)("rM2") * 100).ToString("n2"),
                                rM3 = (r.Field(Of Decimal)("rM3") * 100).ToString("n2"),
                                rM4 = (r.Field(Of Decimal)("rM4") * 100).ToString("n2"),
                                rM5 = (r.Field(Of Decimal)("rM5") * 100).ToString("n2"),
                                rM6 = (r.Field(Of Decimal)("rM6") * 100).ToString("n2"),
                                rM7 = (r.Field(Of Decimal)("rM7") * 100).ToString("n2"),
                                rM8 = (r.Field(Of Decimal)("rM8") * 100).ToString("n2"),
                                rM9 = (r.Field(Of Decimal)("rM9") * 100).ToString("n2"),
                                rM10 = (r.Field(Of Decimal)("rM10") * 100).ToString("n2"),
                                rM11 = (r.Field(Of Decimal)("rM11") * 100).ToString("n2"),
                                rM12 = (r.Field(Of Decimal)("rM12") * 100).ToString("n2")

                    For Each item In q
                        fgMonth.Rows.Add()
                        fgMonth(fgMonth.Rows.Count - 1, 0) = item.year
                        fgMonth(fgMonth.Rows.Count - 1, 1) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 2) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 3) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 4) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 5) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 6) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 7) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 8) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 9) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 10) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 11) = item.rM1
                        fgMonth(fgMonth.Rows.Count - 1, 12) = item.rM1
                    Next

                End If
            Else
                ExceptionMessage.Show(objReturn.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class