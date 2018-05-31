Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.MasterSimpi
Imports simpi.MasterClient
Imports simpi.GlobalUtilities.GlobalString

Public Class FormMyClientInstitutionalSub
    Public CallerForm As FormMyClientInstitutional
    Public objClient As MasterClientInstitutionSub
    Dim objMasterClient As New MasterClient
    Dim objBank As New ClientBankAccount
    Dim objKYC As New SimpiKYC
    Dim objClientKYC As New ClientKYC
    Dim objRisk As New SimpiRiskLevel
    Dim objClientRisk As New ClientQuestioner
    Dim objDocument As New ClientDocument
    Dim isNew As Boolean = False

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            GetParameterCountry()
            GetParameterClientStatus()
            GetParameterClientDocumentType()

            objBank.UserAccess = objAccess
            objMasterClient.UserAccess = objAccess
            objClientKYC.UserAccess = objAccess
            objClientRisk.UserAccess = objAccess
            objRisk.UserAccess = objAccess
            objKYC.UserAccess = objAccess
            objDocument.UserAccess = objAccess

            DBGBank.FetchRowStyles = True
            DBGKYC.FetchRowStyles = True
            DBGKYCAnswer.FetchRowStyles = True
            DBGRisk.FetchRowStyles = True
            DBGDocument.FetchRowStyles = True

            'parent
            lblSimpiID.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiID
            lblSimpiName.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiName
            lblSalesCode.Text = objClient.GetClientParent.GetMasterSales.GetSalesCode
            lblSalesName.Text = objClient.GetClientParent.GetMasterSales.GetSimpiUser.GetUserName
            lblSalesHead.Text = objClient.GetClientParent.GetMasterSales.GetTreeParentCode
            lblCode.Text = objClient.GetClientParent.GetClientCode
            lblName.Text = objClient.GetClientParent.GetClientName
            lblStatus.Text = objClient.GetClientParent.GetClientStatus.GetStatusCode
            lblRiskCode2.Text = objClient.GetClientParent.GetClientRiskLevel.GetRiskCode
            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
            lblCorrespondencePhoneEmail.Text = objClient.GetClientParent.GetCorrespondencePhone
            'lblCorrespondenceEmail.Text = objClient.GetClientParent.GetCorrespondenceEmail

            'sub
            lblCIFSub.Text = objClient.GetClientCode
            lblNameSub.Text = objClient.GetClientName
            lblRiskCode2.Text = objClient.GetClientRiskLevel.GetRiskCode
            lblSubName.Text = objClient.GetSubName
            lblSubSeparator.Text = objClient.GetSubSeparator
            lblValuation.Text = objClient.GetClientCcy.GetCcy
            lblXRate.Text = objClient.GetClientXRate.GetXRateCode
            lblTaxID.Text = objClient.GetTaxID
            If objClient.GetLocalForeign = "L"c Then
                rbLocal.Checked = True
            Else
                rbForegin.Checked = True
            End If
            lblBusinessActivity.Text = objClient.GetBusinessActivity.GetActivityCode
            lblBusinessType.Text = objClient.GetBusinessType.GetTypeCode
            lblSignatureRule.Text = objClient.GetSignatureRule

            objMasterClient.Clear()
            objMasterClient.Load(objClient.GetClientParent.GetMasterSimpi, objClient.GetClientCode)
            GetSimpiKYCField(4)
            GetSimpiRisk(4)
            BankLoad()
            KYCLoad()
            RiskLoad()
        End If
    End Sub

#Region "bank account"
    Private Sub BankLoad()
        Dim tbl As New DataTable
        objBank.Clear()
        tbl = objBank.Search(objMasterClient)
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            Dim query = From b In tbl.AsEnumerable
                        Join c In dtParameterCountry.AsEnumerable On
                             c.Field(Of Integer)("CountryID") Equals b.Field(Of Integer)("AccountCcyID")
                        Select
                             Bank = b.Field(Of String)("BankName"),
                             Branch = b.Field(Of String)("BankBranch"),
                             AccountNo = b.Field(Of String)("AccountNo"),
                             Name = b.Field(Of String)("AccountName"),
                             Ccy = c.Field(Of String)("Ccy"),
                             Notes = b.Field(Of String)("AccountNotes")

            With DBGBank
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGBank.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

            End With
        Else
            DBGBank.Columns.Clear()
        End If

        BankClear()
    End Sub

    Private Sub DBGBank_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGBank.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub BankClear()
        txtBankName.Text = ""
        txtBankBranch.Text = ""
        txtAccountNo.Text = ""
        txtAccountName.Text = ""
        txtAccountNotes.Text = ""
        txtAccountCcy.Text = ""
    End Sub

    Private Sub DBGBank_Click(sender As Object, e As EventArgs) Handles DBGBank.Click
        With DBGBank
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGBank_DoubleClick(sender As Object, e As EventArgs) Handles DBGBank.DoubleClick
        BankSelect()
    End Sub

    Private Sub BankSelect()
        With DBGBank
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                txtBankName.Text = .Columns("Bank").Text
                txtBankBranch.Text = .Columns("Branch").Text
                txtAccountNo.Text = .Columns("AccountNo").Text
                txtAccountName.Text = .Columns("Name").Text
                txtAccountNotes.Text = .Columns("Notes").Text
                txtAccountCcy.Text = .Columns("Ccy").Text
            End If
        End With
    End Sub

#End Region

#Region "risk"
    Private Sub RiskLoad()
        Dim RiskDate As Date
        objClientRisk.Clear()
        objClientRisk.LoadLast(objMasterClient)
        If objClientRisk.ErrID = 0 Then
            RiskDate = objClientRisk.GetRiskDate
            lblRiskScore.Text = objClientRisk.GetRiskValue
            lblRiskCode2.Text = objClientRisk.GetClientRisk.GetRiskCode
            If RiskDate.Date = Now.Date Then
                btnNewRisk.Enabled = False
                btnAnswerRisk.Enabled = True
                btnCancelRisk.Enabled = True
            Else
                btnNewRisk.Enabled = True
                btnAnswerRisk.Enabled = False
                btnCancelRisk.Enabled = False
            End If
        Else
            RiskDate = Now
            lblRiskScore.Text = "0"
            lblRiskCode2.Text = ""
            btnNewRisk.Enabled = True
            btnAnswerRisk.Enabled = False
            btnCancelRisk.Enabled = False
        End If

        Dim tbl As New DataTable
        tbl = objClientRisk.Answer_Search() 'objMasterClient, RiskDate)
        If objClientRisk.ErrID = 0 And dtSimpiRisk IsNot Nothing AndAlso dtSimpiRisk.Rows.Count > 0 Then
            Dim query = From r In dtSimpiRisk.AsEnumerable
                        Group Join c In tbl.AsEnumerable On
                            r.Field(Of Integer)("QuestionNo") Equals
                            c.Field(Of Integer)("QuestionNo") Into rc = Group
                        Let c = rc.FirstOrDefault
                        Select No = r.Field(Of Integer)("QuestionNo"),
                               Question = r.Field(Of String)("QuestionText"),
                               Answer = If(c Is Nothing, "", c.Field(Of String)("AnswerText")),
                               Value = If(c Is Nothing, 0, c.Field(Of Integer)("AnswerValue"))

            With DBGRisk
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGRisk.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With
        Else
            DBGRisk.Columns.Clear()
        End If

    End Sub

    Private Sub DBGRisk_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs)
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGRisk_Click(sender As Object, e As EventArgs)
        With DBGRisk
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub btnNewRisk_Click(sender As Object, e As EventArgs) Handles btnNewRisk.Click
        NewRisk()
    End Sub

    Private Sub NewRisk()
        objClientRisk.Clear()
        objClientRisk.Add(objMasterClient)
        If objClientRisk.ErrID = 0 Then
            RiskLoad()
        Else
            ExceptionMessage.Show(objClientRisk.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DBGRisk_DoubleClick(sender As Object, e As EventArgs)
        RiskSelect()
    End Sub

    Private Sub RiskSelect()
        With DBGRisk
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                lblRiskID.Text = .Columns("No").Text
                lblRiskQuestion.Text = .Columns("Question").Text
                lblRiskValue.Text = .Columns("Value").Text
                AnswerClear()
                AnswerDisplay(.Columns("No").Text)
            End If
        End With
    End Sub

    Private Sub AnswerDisplay(ByVal QuestionNo As Integer)
        Dim AnswerValue As Integer = CInt(lblRiskValue.Text)
        Dim tbl As New DataTable
        tbl = objRisk.Answer_Search(objMasterClient.GetMasterSimpi, 1, QuestionNo)
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            btnAnswerRisk.Visibility = C1.Win.C1InputPanel.Visibility.Visible
            btnCancelRisk.Visibility = C1.Win.C1InputPanel.Visibility.Visible
            If tbl.Rows.Count > 0 Then
                rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk1.Text = CStr(GetNullData(tbl.Rows(0)("OptionText"), 0))
                lblRisk1.Text = CInt(GetNullData(tbl.Rows(0)("OptionValue"), 0))
                If AnswerValue = CInt(lblRisk1.Text) Then
                    rbRisk1.Checked = True
                End If
            End If
            If tbl.Rows.Count > 1 Then
                rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk2.Text = CStr(GetNullData(tbl.Rows(1)("OptionText"), 0))
                lblRisk2.Text = CInt(GetNullData(tbl.Rows(1)("OptionValue"), 0))
                If AnswerValue = CInt(lblRisk2.Text) Then
                    rbRisk2.Checked = True
                End If
            End If
            If tbl.Rows.Count > 2 Then
                rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk3.Text = CStr(GetNullData(tbl.Rows(2)("OptionText"), 0))
                lblRisk3.Text = CInt(GetNullData(tbl.Rows(2)("OptionValue"), 0))
                If AnswerValue = CInt(lblRisk3.Text) Then
                    rbRisk3.Checked = True
                End If
            End If
            If tbl.Rows.Count > 3 Then
                rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
                rbRisk4.Text = CStr(GetNullData(tbl.Rows(3)("OptionText"), 0))
                lblRisk4.Text = CInt(GetNullData(tbl.Rows(3)("OptionValue"), 0))
                If AnswerValue = CInt(lblRisk4.Text) Then
                    rbRisk4.Checked = True
                End If
            End If
            If tbl.Rows.Count > 4 Then
                rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Visible
                rbRisk5.Text = CStr(GetNullData(tbl.Rows(4)("OptionText"), 0))
                lblRisk5.Text = CInt(GetNullData(tbl.Rows(4)("OptionValue"), 0))
                If AnswerValue = CInt(lblRisk5.Text) Then
                    rbRisk5.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub AnswerClear()
        rbRisk1.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        rbRisk2.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        rbRisk3.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        rbRisk4.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        rbRisk5.Visibility = C1.Win.C1InputPanel.Visibility.Hidden

        rbRisk1.SelectedIndex = -1
        rbRisk2.SelectedIndex = -1
        rbRisk3.SelectedIndex = -1
        rbRisk4.SelectedIndex = -1
        rbRisk5.SelectedIndex = -1

        rbRisk1.Text = ""
        rbRisk2.Text = ""
        rbRisk3.Text = ""
        rbRisk4.Text = ""
        rbRisk5.Text = ""

        lblRisk1.Text = ""
        lblRisk2.Text = ""
        lblRisk3.Text = ""
        lblRisk4.Text = ""
        lblRisk5.Text = ""

        btnAnswerRisk.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
        btnCancelRisk.Visibility = C1.Win.C1InputPanel.Visibility.Hidden
    End Sub

    Private Sub btnAnswerRisk_Click(sender As Object, e As EventArgs) Handles btnAnswerRisk.Click
        RiskAnswer()
    End Sub

    Private Sub RiskAnswer()
        If lblRiskID.Text.Trim <> "" And
           (rbRisk1.Checked Or rbRisk2.Checked Or rbRisk3.Checked Or rbRisk4.Checked Or rbRisk5.Checked) Then
            Dim AnswerValue As Integer = 0
            Dim AnswerText As String = ""
            If rbRisk1.Checked Then
                AnswerText = rbRisk1.Text
                AnswerValue = lblRisk1.Text
            ElseIf rbRisk2.Checked Then
                AnswerText = rbRisk2.Text
                AnswerValue = lblRisk2.Text
            ElseIf rbRisk3.Checked Then
                AnswerText = rbRisk3.Text
                AnswerValue = lblRisk3.Text
            ElseIf rbRisk4.Checked Then
                AnswerText = rbRisk4.Text
                AnswerValue = lblRisk4.Text
            ElseIf rbRisk5.Checked Then
                AnswerText = rbRisk5.Text
                AnswerValue = lblRisk5.Text
            End If

            objClientRisk.Answer_Insert(lblRiskID.Text, lblRiskQuestion.Text, AnswerText, AnswerValue)
            If objClientRisk.ErrID = 0 Then
                lblRiskScore.Text = CInt(lblRiskScore.Text) + AnswerValue
                lblRiskCode2.Text = objRisk.GetSimpiRiskLevel(objMasterClient.GetMasterSimpi, CInt(lblRiskScore.Text))
                lblRiskID.Text = ""
                lblRiskQuestion.Text = ""
                lblRiskValue.Text = ""
                AnswerClear()
                RiskLoad()
            Else
                ExceptionMessage.Show(objClientRisk.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnCancelRisk_Click(sender As Object, e As EventArgs) Handles btnCancelRisk.Click
        RiskCancel()
    End Sub

    Private Sub RiskCancel()
        If lblRiskID.Text.Trim <> "" Then
            objClientRisk.Answer_Remove(lblRiskID.Text, CInt(lblRiskValue.Text))
            If objClientRisk.ErrID = 0 Then
                lblRiskScore.Text = CInt(lblRiskScore.Text) - CInt(lblRiskValue.Text)
                lblRiskCode2.Text = objRisk.GetSimpiRiskLevel(objMasterClient.GetMasterSimpi, CInt(lblRiskScore.Text))
                lblRiskID.Text = ""
                lblRiskQuestion.Text = ""
                lblRiskValue.Text = ""
                AnswerClear()
                RiskLoad()
            Else
                ExceptionMessage.Show(objClientRisk.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#End Region

#Region "kyc"
    Private Sub KYCLoad()
        objClientKYC.Clear()
        Dim tbl As New DataTable
        tbl = objClientKYC.Search(objMasterClient)
        If objClientKYC.ErrID = 0 And dtSimpiKYC IsNot Nothing AndAlso dtSimpiKYC.Rows.Count > 0 Then
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
        Else
            DBGKYC.Columns.Clear()
        End If

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
            If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
                Dim query = From k In tbl.AsEnumerable
                            Select ID = k.Field(Of Integer)("AnswerID"),
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
            Else
                DBGKYCAnswer.Columns.Clear()
            End If

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

    Private Sub KYCClear()
        lblKYCID.Text = ""
        lblKYCCode.Text = ""
        lblKYCDescription.Text = ""
        txtKYCAnswer.Text = ""
        DBGKYCAnswer.Columns.Clear()
    End Sub

#End Region

#Region "document"
    Private Sub btnSearchDocument_Click(sender As Object, e As EventArgs) Handles btnSearchDocument.Click
        DocumentSearch()
    End Sub

    Private Sub txtKeywordDocument_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeywordDocument.KeyDown
        If e.KeyCode = Keys.Enter Then
            DocumentSearch()
        End If
    End Sub

    Public Sub DocumentSearch()
        Dim tbl As New DataTable
        objDocument.Clear()
        tbl = objDocument.Search(objMasterClient, txtKeywordDocument.Text)
        If objDocument.ErrID = 0 Then
            If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
                Dim query = From p In tbl.AsEnumerable
                            Join s In dtParameterClientDocumentType.AsEnumerable On
                                   p.Field(Of Integer)("TypeID") Equals s.Field(Of Integer)("TypeID")
                            Select
                                 Type = s.Field(Of String)("TypeCode"),
                                 Issuer = p.Field(Of String)("DocumentIssuer"),
                                 No = p.Field(Of String)("DocumentNo"),
                                 Title = p.Field(Of String)("DocumentTitle"),
                                 IsExpired = IIf(p.Field(Of SByte)("DocumentIsExpired") = 0, "N", "Y"),
                                 Expiry = p.Field(Of Date)("DocumentExpired")

                With DBGDocument
                    .AllowAddNew = False
                    .AllowDelete = False
                    .AllowUpdate = False
                    .Style.WrapText = False
                    .Columns.Clear()
                    .DataSource = query.ToList

                    .Columns("Expiry").NumberFormat = "dd-MMM-yyyy"

                    For Each column As C1DisplayColumn In DBGDocument.Splits(0).DisplayColumns
                        column.AutoSize()
                    Next

                End With
            Else
                DBGDocument.Columns.Clear()
            End If

        Else
            DBGDocument.Columns.Clear()
            ExceptionMessage.Show(objDocument.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        DocumentClear()
    End Sub

    Private Sub DBGDocument_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGDocument.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DocumentClear()
        txtDocumentIssuer.Text = ""
        txtDocumentNo.Text = ""
        txtDocumentTitle.Text = ""
        txtDocumentType.Text = ""
    End Sub

    Private Sub DBGDocument_Click(sender As Object, e As EventArgs) Handles DBGDocument.Click
        With DBGDocument
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
            End If
        End With
    End Sub

    Private Sub DBGDocument_DoubleClick(sender As Object, e As EventArgs) Handles DBGDocument.DoubleClick
        DocumentSelect()
    End Sub

    Private Sub DocumentSelect()
        With DBGDocument
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                txtDocumentIssuer.Text = .Columns("Issuer").Text
                txtDocumentNo.Text = .Columns("No").Text
                txtDocumentTitle.Text = .Columns("Title").Text
                If .Columns("IsExpired").Text = "N" Then
                    chkDocumentIsExpired.Checked = False
                Else
                    chkDocumentIsExpired.Checked = True
                End If
                dtDocumentExpired.Value = .Columns("Expiry").Text
                txtDocumentType.Text = .Columns("Type").Text
            End If
        End With
    End Sub

    Private Sub btnClientSheet_Click(sender As Object, e As EventArgs) Handles btnClientSheet.Click
        ClientSheet()
    End Sub

    Private Sub ClientSheet()
        If objClient.GetClientID > 0 Then
            Dim frm As New ReportAccountFactSheet
            frm.Show()
            frm.lblClientName.Text = objClient.GetClientName
            frm.lblClientCode.Text = objClient.GetClientCode
            frm.dtAs.Value = Now.AddDays(-1)
            frm.DataSearch()
            frm.MdiParent = MDIMIS
        End If
    End Sub

#End Region

End Class