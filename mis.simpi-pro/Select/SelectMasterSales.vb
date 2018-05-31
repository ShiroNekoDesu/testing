Imports C1.Win.C1TrueDBGrid
Imports simpi.MasterSales
Imports simpi.GlobalUtilities
Imports simpi.GlobalUtilities.GlobalString

Public Class SelectMasterSales
    Public lblSalesCode As C1.Win.C1InputPanel.InputLabel
    Public lblSalesName As C1.Win.C1InputPanel.InputLabel
    Dim objSales As New MasterSales

    Private Sub FormSelectMasterSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        objSales.UserAccess = objAccess
        btnSelect.Enabled = False
        DBGSales.FetchRowStyles = True
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SalesSearch()
    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then SalesSearch()
    End Sub

    Private Sub SalesSearch()
        Dim dtSales As New DataTable
        objSales.Clear()
        Dim strKeyword As String = SQLKeyword(txtKeyword.Text, IIf(rbAnd.Checked, SetAnd, IIf(rbOr.Checked, SetOr, SetCombine)))
        dtSales = objSales.SearchAll(objMasterSimpi, strKeyword)
        If objSales.ErrID = 0 Then
            dtUserStatus = GetParameterUserStatus("")
            Dim query = From p In dtSales.AsEnumerable
                        Join s In dtUserStatus.AsEnumerable On
                                  p.Field(Of Integer)("StatusID") Equals s.Field(Of Integer)("StatusID")
                        Select
                             ID = p.Field(Of Integer)("SalesID"),
                             Code = p.Field(Of String)("SalesCode"),
                             Name = p.Field(Of String)("UserName"),
                             Status = s.Field(Of String)("StatusCode")

            With DBGSales
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGSales.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

            End With
        Else
            DBGSales.Columns.Clear()
            ExceptionMessage.Show(objSales.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DBGSales_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGSales.FetchRowStyle
        If e.Row Mod 2 = 0 Then e.CellStyle.BackColor = Color.LemonChiffon
    End Sub

    Private Sub DBGSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGSales.Click
        If DBGSales.RowCount > 0 Then
            DBGSales.MarqueeStyle = MarqueeEnum.HighlightRow
            btnSelect.Enabled = True
        End If
    End Sub

    Private Sub DBGSales_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGSales.DoubleClick
        SalesSelect()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        SalesSelect()
    End Sub

    Private Sub SalesSelect()
        With DBGSales
            If .RowCount > 0 Then
                lblSalesCode.Text = .Columns("Code").Text
                lblSalesName.Text = .Columns("Name").Text
                Close()
            End If
        End With
    End Sub


End Class