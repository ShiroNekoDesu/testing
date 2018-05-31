Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.MasterSecurities
Imports simpi.ParameterClient
Imports simpi.MasterClient
Imports simpi.MasterSimpi
Imports simpi.GlobalUtilities.GlobalString

Public Class FormMyClientIndividual
    Public CallerForm As FormMyClient
    Public objClient As MasterClientIndividu
    Dim objMasterClient As New MasterClient
    Dim objSub As New MasterClientIndividuSub
    Dim objBank As New ClientBankAccount
    Dim objKYC As New SimpiKYC
    Dim objClientKYC As New ClientKYC
    Dim objRisk As New SimpiRiskLevel
    Dim objClientRisk As New ClientQuestioner
    Dim isNew As Boolean = False

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            
            GetComboInit(New ParameterCountry, cmbAccountCcy, "CountryID", "Ccy")
            GetComboInit(New ParameterIDCardType, cmbIDCardType, "TypeID", "TypeCode")
            objBank.UserAccess = objAccess
            objMasterClient.UserAccess = objAccess
            objClientKYC.UserAccess = objAccess
            objClientRisk.UserAccess = objAccess
            objRisk.UserAccess = objAccess
            objKYC.UserAccess = objAccess
            objSub.UserAccess = objAccess
            GetParameterCountry()
            GetParameterClientStatus()

            DBGBank.FetchRowStyles = True
            DBGKYC.FetchRowStyles = True
            DBGKYCAnswer.FetchRowStyles = True
            DBGRisk.FetchRowStyles = True
            DBGSubAccount.FetchRowStyles = True

            lblSimpiID.Text = objClient.GetMasterSimpi.GetSimpiID
            lblSimpiName.Text = objClient.GetMasterSimpi.GetSimpiName
            lblSalesCode.Text = objClient.GetMasterSales.GetSalesCode
            lblSalesName.Text = objClient.GetMasterSales.GetSimpiUser.GetUserName
            lblSalesHead.Text = objClient.GetMasterSales.GetTreeParentCode
            lblCode.Text = objClient.GetClientCode
            lblName.Text = objClient.GetClientName
            lblStatus.Text = objClient.GetClientStatus.GetStatusCode
            lblRiskCode2.Text = objClient.GetClientRiskLevel.GetRiskCode
            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
            lblCorrespondencePhoneEmail.Text = objClient.GetCorrespondencePhone
            'lblCorrespondenceEmail.Text = objClient.GetCorrespondenceEmail
            lblValuation.Text = objClient.GetClientCcy.GetCcy
            lblXRate.Text = objClient.GetClientXRate.GetXRateCode

            lblNameFirst.Text = objClient.GetNameFirst
            lblNameMiddle.Text = objClient.GetNameMiddle
            lblNameLast.Text = objClient.GetNameLast
            lblTitleFirst.Text = objClient.GetTitleFirst
            lblTitleLast.Text = objClient.GetTitleLast
            lblGender.Text = objClient.GetGender
            lblBirthPlace.Text = objClient.GetBirthPlace
            lblBirthDate.Text = objClient.GetBirthDate.ToString("dd-MMM-yyyy")
            lblMMN.Text = objClient.GetMMN
            lblReligion.Text = objClient.GetReligion.GetReligionCode
            If objClient.GetLocalForeign = "L"c Then
                rbLocal.Checked = True
            Else
                rbForegin.Checked = True
            End If
            lblNationality.Text = objClient.GetNationality.GetNationality
            lblAddressStreet.Text = objClient.GetCorrespondenceAddress
            lblAddressCity.Text = objClient.GetCorrespondenceCity
            lblAddressState.Text = objClient.GetCorrespondenceProvince
            lblAddressCountry.Text = objClient.GetCorrespondenceCountry.GetCountryName
            lblAddressPostal.Text = objClient.GetCorrespondencePostal
            lblPhone.Text = objClient.GetCorrespondencePhone
            lblEmail.Text = objClient.GetCorrespondenceEmail
            lblTaxID.Text = objClient.GetTaxID
            lblOccupation.Text = objClient.GetOccupation.GetOccupationCode
            lblOfficeName.Text = objClient.GetOfficeName
            lblOfficeAddress.Text = objClient.GetOfficeAddress
            lblOfficePhone.Text = objClient.GetOfficePhone
            lblOfficeBusinessActivity.Text = objClient.GetOfficeBusinessActivity.GetActivityCode
            lblEducation.Text = objClient.GetEducationLevel.GetLevelCode
            lblMarital.Text = objClient.GetMaritalStatus.GetStatusCode
            lblSpouseName.Text = objClient.GetSpouseName
            lblSpouseBirth.Text = objClient.GetSpouseBirthDate

            cmbIDCardType.Text = objClient.GetIDCardType.GetTypeCode
            txtIDCardIssuer.Text = objClient.GetIDCardIssuer
            txtIDCardNo.Text = objClient.GetIDCardNo
            dtIDCardExpired.Value = objClient.GetIDCardExpired
            chkIDCardIsExpired.Checked = objClient.GetIDCardIsExpired

            objMasterClient.Clear()
            objMasterClient.Load(objClient.GetMasterSimpi, objClient.GetClientCode)
            GetSimpiKYCField(1)
            GetSimpiRisk(1)
            BankLoad()
            KYCLoad()
            RiskLoad()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ClientEdit()
    End Sub

    Private Sub ClientEdit()
        Dim frm As New FormMyClientIndividualEdit
        frm.Show()
        frm.objClient = objClient
        frm.ClientLoad()
        frm.CallerForm = CallerForm
        frm.MdiParent = MDIMIS
        Close()
    End Sub

#Region "bank account"
    Private Sub BankLoad()
        Dim tbl As New DataTable
        objBank.Clear()
        tbl = objBank.Search(objMasterClient)
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
        cmbAccountCcy.SelectedIndex = -1
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
                cmbAccountCcy.Text = .Columns("Ccy").Text
            End If
        End With
    End Sub

#End Region

#Region "idcard"
    Private Sub btnSaveIDCard_Click(sender As Object, e As EventArgs) Handles btnSaveIDCard.Click
        IDSave()
    End Sub

    Private Sub IDSave()
        If cmbIDCardType.SelectedIndex <> -1 Then
            objClient.SetIDCard(cmbIDCardType.SelectedValue, txtIDCardNo.Text, txtIDCardIssuer.Text,
                                IIf(chkIDCardIsExpired.Checked, 1, 0), dtIDCardExpired.Value)
            If objClient.ErrID = 0 Then
                ExceptionMessage.Show("IDCard succesfull upadated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ExceptionMessage.Show(objClient.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
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
        Dim query = From r In dtSimpiRisk.AsEnumerable
                    Group Join c In tbl.AsEnumerable On
                        r.Field(Of Integer)("QuestionNo") Equals c.Field(Of Integer)("QuestionNo") Into rc = Group
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
    End Sub

    Private Sub DBGRisk_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGRisk.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGRisk_Click(sender As Object, e As EventArgs) Handles DBGRisk.Click
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

    Private Sub DBGRisk_DoubleClick(sender As Object, e As EventArgs) Handles DBGRisk.DoubleClick
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
        tbl = objRisk.Answer_Search(objMasterSimpi, 1, QuestionNo)
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
        objKYC.Clear()
        dtSimpiKYC = objKYC.Search(objMasterClient.GetMasterSimpi, 1, "")

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

#Region "sub account"
    Private Sub btnSearchSubAccount_Click(sender As Object, e As EventArgs) Handles btnSearchSubAccount.Click
        SubAccountSearch()
    End Sub

    Private Sub txtKeywordSubAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeywordSubAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SubAccountSearch()
        End If
    End Sub

    Public Sub SubAccountSearch()
        Dim dtClient As New DataTable
        objSub.Clear()
        dtClient = objSub.SearchSub(objClient, txtKeywordSubAccount.Text)
        If objSub.ErrID = 0 Then
            Dim query = From p In dtClient.AsEnumerable
                        Join s In dtParameterClientStatus.AsEnumerable On
                               p.Field(Of Integer)("StatusID") Equals s.Field(Of Integer)("StatusID")
                        Select
                             ID = p.Field(Of Integer)("ClientID"),
                             Code = p.Field(Of String)("ClientCode"),
                             Name = p.Field(Of String)("ClientName"),
                             SubName = p.Field(Of String)("SubName"),
                             IsSeparateAccount = p.Field(Of String)("IsSeparateAccount"),
                             Status = s.Field(Of String)("StatusCode")

            With DBGSubAccount
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList

                For Each column As C1DisplayColumn In DBGSubAccount.Splits(0).DisplayColumns
                    column.AutoSize()
                Next

            End With
        Else
            DBGSubAccount.Columns.Clear()
            ExceptionMessage.Show(objSub.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        btnProfileSubAccount.Enabled = False
    End Sub

    Private Sub DBGSubAccount_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGSubAccount.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGSubAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGSubAccount.Click
        With DBGSubAccount
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                btnProfileSubAccount.Enabled = True
            End If
        End With
    End Sub

    Private Sub btnAddSubAccount_Click(sender As Object, e As EventArgs) Handles btnAddSubAccount.Click
        SubAccountAdd()
    End Sub

    Private Sub SubAccountAdd()
        Dim frm As New FormMyClientIndividualSubNew
        frm.CallerForm = Me
        frm.objParent = objClient
        frm.ParentLoad()
        frm.MdiParent = MDIMIS
        frm.Show()
    End Sub

    Private Sub btnProfileSubAccount_Click(sender As Object, e As EventArgs) Handles btnProfileSubAccount.Click
        SubAccountProfile()
    End Sub

    Private Sub SubAccountProfile()
        With DBGSubAccount
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                objSub.Clear()
                objSub.Load(objMasterSimpi, .Columns("Code").Text)
                Dim frm As New FormMyClientIndividualSub
                frm.Show()
                frm.objClient = objSub
                frm.ClientLoad()
                frm.CallerForm = Me
                frm.MdiParent = MDIMIS
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