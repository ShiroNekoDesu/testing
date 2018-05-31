Imports simpi.MasterClient
Imports simpi.ParameterClient
Imports simpi.globalutilities
Imports simpi.globalutilities.GlobalString
Imports C1.Win.C1FlexGrid

Public Class FormMyClientRiskScore
    Dim objClient As New MasterClient
    Dim dtRisk As New DataTable
    Dim objClientRisk As New ClientQuestioner

    Private Sub csMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles csMenu.ItemClicked
        Select Case e.ClickedItem.Text
            Case "Detach"
                MdiParent = Nothing
                e.ClickedItem.Text = "Attach"
            Case "Attach"
                e.ClickedItem.Text = "Detach"
                MdiParent = MDIMIS
            Case "Close"
                Close()
            Case "Export"
                PrintExcel(fgScore)
        End Select
    End Sub

    Private Sub FormAccountKYC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetParameterClientStatus()
        GetComboInit(New ParameterClientType, cmbClientType, "TypeID", "TypeCode")
        objClient.UserAccess = objAccess
        objClientRisk.UserAccess = objAccess
        RiskInit()
        fgScore.KeyActionEnter = KeyActionEnum.None
        fgScore.DrawMode = DrawModeEnum.OwnerDraw
    End Sub

    Private Sub RiskInit()
        dtRisk.Columns.Add("ID", GetType(Integer))
        dtRisk.Columns.Add("Sales", GetType(String))
        dtRisk.Columns.Add("Code", GetType(String))
        dtRisk.Columns.Add("Client", GetType(String))
        dtRisk.Columns.Add("Status", GetType(String))
        dtRisk.Columns.Add("Score", GetType(String))
        dtRisk.Columns.Add("RiskProfile", GetType(String))
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ClientSearch()
    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then ClientSearch()
    End Sub

    Public Sub ClientSearch()
        Dim dtClient As New DataTable
        objClient.Clear()
        Dim strKeyword As String = SQLKeyword(txtKeyword.Text, IIf(rbNone.Checked, SetNone, IIf(rbAnd.Checked, SetAnd, IIf(rbOr.Checked, SetOr, SetCombine))))
        dtClient = objClient.Search(objMasterSimpi, strKeyword, cmbClientType.SelectedValue)
        If objClient.ErrID = 0 Then
            Dim query As IEnumerable
            Dim dtClientRisk As New DataTable
            objClientRisk.Clear()
            dtClientRisk = objClientRisk.Search(objMasterSimpi)

            If dtClientRisk IsNot Nothing AndAlso dtClientRisk.Rows.Count > 0 Then
                Dim qRisk = From r In dtClientRisk Order By r.Field(Of Date)("QuestionerDate") Descending
                            Select ClientID = r.Field(Of Integer)("ClientID"),
                                   RiskValue = r.Field(Of Integer)("RiskValue"),
                                   RiskCode = r.Field(Of String)("RiskCode")

                query = From p In dtClient.AsEnumerable Join s In dtParameterClientStatus.AsEnumerable
                                On p.Field(Of Integer)("StatusID") Equals s.Field(Of Integer)("StatusID")
                        Group Join t In qRisk On p.Field(Of Integer)("ClientID") Equals t.ClientID
                                Into esc = Group Let t = esc.FirstOrDefault
                        Select
                                     ID = p.Field(Of Integer)("ClientID"),
                                     Sales = p.Field(Of String)("SalesCode"),
                                     Code = p.Field(Of String)("ClientCode"),
                                     Name = p.Field(Of String)("ClientName"),
                                     Status = s.Field(Of String)("StatusCode"),
                                     Score = If(t Is Nothing, "", t.RiskValue),
                                     RiskProfile = If(t Is Nothing, "", t.RiskCode)
            Else
                query = From p In dtClient.AsEnumerable Join s In dtParameterClientStatus.AsEnumerable
                                On p.Field(Of Integer)("StatusID") Equals s.Field(Of Integer)("StatusID")
                        Select
                                     ID = p.Field(Of Integer)("ClientID"),
                                     Sales = p.Field(Of String)("SalesCode"),
                                     Code = p.Field(Of String)("ClientCode"),
                                     Name = p.Field(Of String)("ClientName"),
                                     Status = s.Field(Of String)("StatusCode"), Score = "", RiskProfile = ""
            End If

            dtRisk.Clear()
            For Each item In query
                Dim dr As DataRow = dtRisk.NewRow()
                dr("ID") = item.ID
                dr("Sales") = item.Sales
                dr("Code") = item.Code
                dr("Client") = item.Name
                dr("Status") = item.Status
                dr("Score") = item.Score
                dr("RiskProfile") = item.RiskProfile
                dtRisk.Rows.Add(dr)
            Next

            fgScore.DataSource = dtRisk
            fgScore.AutoSizeCols()
        Else
            fgScore.DataSource = Nothing
        End If

    End Sub

    Private Sub fgKYC_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgScore.BeforeEdit
        If e.Col = 0 Or e.Col = 1 Or e.Col = 2 Or e.Col = 3 Or e.Col = 4 Or e.Col = 6 Then e.Cancel = True Else e.Cancel = False
    End Sub

    Private Sub fgKYC_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles fgScore.PreviewKeyDown
        Select Case (e.KeyCode)
            Case Keys.Down, Keys.Up
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub fgKYC_KeyUp(sender As Object, e As KeyEventArgs) Handles fgScore.KeyUp
        If e.KeyCode = Keys.Enter And fgScore.Col = 5 Then
            DataSave()
        ElseIf e.KeyCode = Keys.Delete And
            Not (fgScore.Col = 0 Or fgScore.Col = 1 Or fgScore.Col = 2 Or fgScore.Col = 3 Or fgScore.Col = 4 Or fgScore.Col = 6) Then
            fgScore(fgScore.Row, fgScore.Col) = ""
        End If
    End Sub

    Private Sub fgKYC_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgScore.OwnerDrawCell
        Dim s As CellStyle = fgScore.Styles.Add("RowStyle")
        s.BackColor = Color.LemonChiffon
        If e.Row > 0 And e.Row Mod 2 = 0 Then fgScore.Rows(e.Row).Style = fgScore.Styles("RowStyle")
    End Sub

    Private Sub DataSave()
        If fgScore.Row > 0 Then
            objClient.Clear()
            objClient.load(objMasterSimpi, fgScore(fgScore.Row, 2))
            If objClient.ErrID = 0 Then
                Dim i As Integer
                objClientRisk.Clear()
                Integer.TryParse(fgScore(fgScore.Row, 5), i)
                If i > 0 Then
                    objClientRisk.SetScore(objClient, i)
                    If objClientRisk.ErrID = 0 Then ClientSearch() Else ExceptionMessage.Show(objClientRisk.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ExceptionMessage.Show(objClient.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class