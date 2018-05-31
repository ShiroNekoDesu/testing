Imports C1.Win.C1TrueDBGrid
Imports simpi.MasterClient
Imports simpi.GlobalUtilities
Imports simpi.GlobalUtilities.GlobalString

Public Class SelectMasterClient
    Public lblCode As C1.Win.C1InputPanel.InputLabel
    Public lblName As C1.Win.C1InputPanel.InputLabel
    Dim objClient As New MasterClient

    Private Sub FormSelectMasterClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParameterClientType()
        GetParameterClientStatus()
        GetParameterClientRisk()
        objClient.UserAccess = objAccess
        btnSelect.Enabled = False
        DBGClient.FetchRowStyles = True
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ClientSearch()
    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then ClientSearch()
    End Sub

    Private Sub ClientSearch()
        Dim dtClient As New DataTable
        objClient.Clear()
        Dim strKeyword As String = SQLKeyword(txtKeyword.Text, IIf(rbNone.Checked, SetNone, IIf(rbAnd.Checked, SetAnd, IIf(rbOr.Checked, SetOr, SetCombine))))
        dtClient = objClient.Search(objMasterSimpi, strKeyword)
        If objClient.ErrID = 0 Then
            Dim query = From p In dtClient.AsEnumerable
                        Join c In dtParameterClientType.AsEnumerable On
                               p.Field(Of Integer)("TypeID") Equals c.Field(Of Integer)("TypeID")
                        Join s In dtParameterClientStatus.AsEnumerable On
                               p.Field(Of Integer)("StatusID") Equals s.Field(Of Integer)("StatusID")
                        Join a In dtParameterClientRisk.AsEnumerable On
                               p.Field(Of Integer)("RiskID") Equals a.Field(Of Integer)("RiskID")
                        Select
                             ID = p.Field(Of Integer)("ClientID"),
                             Code = p.Field(Of String)("ClientCode"),
                             Name = p.Field(Of String)("ClientName"),
                             Type = c.Field(Of String)("TypeCode"),
                             Risk = a.Field(Of String)("RiskCode"),
                             Status = s.Field(Of String)("StatusCode")

            With DBGClient
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGClient.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

            End With
        Else
            DBGClient.Columns.Clear()
            ExceptionMessage.Show(objClient.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DBGClient_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGClient.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGClient.Click
        With DBGClient
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                btnSelect.Enabled = True
            End If
        End With
    End Sub

    Private Sub DBGClient_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGClient.DoubleClick
        ClientSelect()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        ClientSelect()
    End Sub

    Private Sub ClientSelect()
        With DBGClient
            If .RowCount > 0 Then
                lblCode.Text = .Columns("Code").Text
                lblName.Text = .Columns("Name").Text
                Close()
            End If
        End With
    End Sub

End Class