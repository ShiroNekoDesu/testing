Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.MasterSimpi
Imports simpi.MasterClient

Public Class FormMyClientDistributorNominee
    Public CallerForm As FormMyClientDistributor
    Public objClient As MasterClientDistributorNominee
    Dim objMasterClient As New MasterClient
    Dim objKYC As New SimpiKYC
    Dim objClientKYC As New ClientKYC

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            'parent
            lblSimpiID.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiID
            lblSimpiName.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiName
            lblSalesCode.Text = objClient.GetClientParent.GetMasterSales.GetSalesCode
            lblSalesName.Text = objClient.GetClientParent.GetMasterSales.GetSimpiUser.GetUserName
            lblSalesHead.Text = objClient.GetClientParent.GetMasterSales.GetTreeParentCode
            lblCode.Text = objClient.GetClientParent.GetClientCode
            lblName.Text = objClient.GetClientParent.GetClientName
            lblStatus.Text = objClient.GetClientParent.GetClientStatus.GetStatusCode
            lblFL.Text = objClient.GetClientParent.GetLocalForeign
            lblRiskCode.Text = objClient.GetClientParent.GetClientRiskLevel.GetRiskCode
            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
            lblCorrespondencePhone.Text = objClient.GetClientParent.GetCorrespondencePhone
            lblCorrespondenceEmail.Text = objClient.GetClientParent.GetCorrespondenceEmail
            'sub
            lblCIFSub.Text = objClient.GetClientCode
            lblNameSub.Text = objClient.GetClientName
            lblNomineeStatus.Text = objClient.GetClientStatus.GetStatusCode
            lblNomineeID.Text = objClient.GetNomineeID
            lblNomineeName.Text = objClient.GetNomineeName
            If objClient.GetNomineeType = 1 Then
                rbIndividu.Checked = True
                GetSimpiKYCField(5)
            Else
                rbInstitution.Checked = True
                GetSimpiKYCField(6)
            End If
            lblValuation.Text = objClient.GetClientCcy.GetCcy
            lblXRate.Text = objClient.GetClientXRate.GetXRateCode

            objClientKYC.UserAccess = objAccess
            objKYC.UserAccess = objAccess
            objMasterClient.UserAccess = objAccess
            objMasterClient.Load(objClient.GetClientParent.GetMasterSimpi, objClient.GetClientCode)

            DBGKYC.FetchRowStyles = True
            DBGKYCAnswer.FetchRowStyles = True

            KYCLoad()
        End If
    End Sub

#Region "kyc"
    Private Sub KYCLoad()
        objClientKYC.Clear()
        Dim tbl As New DataTable
        tbl = objClientKYC.Search(objMasterClient)
        Dim query = From k In dtSimpiKYC.AsEnumerable
                    Group Join c In tbl.AsEnumerable On
                        k.Field(Of Integer)("kycID") Equals c.Field(Of Integer)("kycID") Into kc = Group
                    Let c = kc.FirstOrDefault
                    Select
                            ID = k.Field(Of Integer)("kycID"),
                            KYC = k.Field(Of String)("kycCode"),
                            Answer = If(c Is Nothing, "", c.Field(Of String)("kycAnswer")),
                            Description = k.Field(Of String)("kycDescription")

        With DBGKYC
            .AllowAddNew = False
            .AllowDelete = False
            .AllowUpdate = False
            .Columns.Clear()
            .DataSource = query.ToList

            For Each column As C1DisplayColumn In DBGKYC.Splits(0).DisplayColumns
                column.AutoSize()
            Next

            Dim desc As C1DisplayColumn
            desc = .Splits(0).DisplayColumns("Description")
            desc.Width = 0

        End With
        KYCClear()
    End Sub

    Private Sub DBGKYC_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGKYC.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGKYC_Click(sender As Object, e As EventArgs) Handles DBGKYC.Click
        With DBGKYC
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGKYC_DoubleClick(sender As Object, e As EventArgs) Handles DBGKYC.DoubleClick
        KYCSelect()
    End Sub

    Private Sub KYCSelect()
        If DBGKYC.RowCount > 0 Then
            DBGKYC.MarqueeStyle = MarqueeEnum.HighlightRow
            lblKYCID.Text = DBGKYC.Columns("ID").Text
            lblKYCCode.Text = DBGKYC.Columns("KYC").Text
            lblKYCDescription.Text = DBGKYC.Columns("Description").Text
            txtKYCAnswer.Text = DBGKYC.Columns("Answer").Text

            Dim tbl As New DataTable
            tbl = objKYC.Answer_Search(CInt(lblKYCID.Text))
            Dim query = From k In tbl.AsEnumerable Select ID = k.Field(Of Integer)("AnswerID"),
                                                       Answer = k.Field(Of String)("AnswerText")
            With DBGKYCAnswer
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGKYCAnswer.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With
        End If
    End Sub

    Private Sub DBGKYCAnswer_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGKYCAnswer.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGKYCAnswer_Click(sender As Object, e As EventArgs) Handles DBGKYCAnswer.Click
        With DBGKYCAnswer
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGKYCAnswer_DoubleClick(sender As Object, e As EventArgs) Handles DBGKYCAnswer.DoubleClick
        KYCAnswerSelect()
    End Sub

    Private Sub KYCAnswerSelect()
        With DBGKYCAnswer
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                txtKYCAnswer.Text = .Columns("Answer").Text
            End If
        End With
    End Sub

    Private Sub btnAnswerKYC_Click(sender As Object, e As EventArgs) Handles btnAnswerKYC.Click
        KYCAnswer()
    End Sub

    Private Sub KYCAnswer()
        If lblKYCID.Text.Trim <> "" And txtKYCAnswer.Text.Trim <> "" Then
            objClientKYC.Add(objMasterClient, lblKYCID.Text, txtKYCAnswer.Text)
            If objClientKYC.ErrID = 0 Then
                KYCLoad()
            Else
                ExceptionMessage.Show(objClientKYC.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnCancelKYC_Click(sender As Object, e As EventArgs) Handles btnCancelKYC.Click
        KYCCancel()
    End Sub

    Private Sub KYCCancel()
        If lblKYCID.Text.Trim <> "" Then
            objClientKYC.Remove(objMasterClient, lblKYCID.Text)
            If objClientKYC.ErrID = 0 Then
                KYCLoad()
            Else
                ExceptionMessage.Show(objClientKYC.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub KYCClear()
        lblKYCID.Text = ""
        lblKYCCode.Text = ""
        lblKYCDescription.Text = ""
        txtKYCAnswer.Text = ""
        DBGKYCAnswer.Columns.Clear()
    End Sub

#End Region

End Class