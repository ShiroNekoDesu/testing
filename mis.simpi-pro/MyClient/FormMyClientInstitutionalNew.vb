Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities
Imports simpi.MasterSecurities
Imports simpi.ParameterClient
Imports simpi.MasterSimpi
Imports simpi.MasterSales
Imports simpi.MasterClient
Imports simpi.GlobalUtilities.GlobalString

Public Class FormMyClientInstitutionalNew
    Public CallerForm As FormMyClient
    Dim objSales As New MasterSales
    Dim objClient As New MasterClientInstitution
    Dim objMasterClient As New MasterClient
    Dim objKYC As New SimpiKYC
    Dim objRisk As New SimpiRiskLevel
    Dim tblRisk As New DataTable
    Dim tblKYC As New DataTable
    Dim objClientKYC As New ClientKYC
    Dim objClientRisk As New ClientQuestioner
    Dim isKYC As Boolean = True
    Dim isRisk As Boolean = True

    Private Sub FormAccountInstitutionalNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        'lblSimpiID.Text = objMasterSimpi.GetSimpiID
        'lblSimpiName.Text = objMasterSimpi.GetSimpiName

        GetComboInit(New ParameterCountry, cmbAddressCountry, "CountryID", "CountryName")
        cmbAddressCountry.SelectedIndex = -1
        GetComboInit(New ParameterCountry, cmbValuation, "CountryID", "Ccy")
        GetComboInit(New ParameterXRate, cmbXRate, "XRateID", "XRateCode")
        GetComboInit(New ParameterBusinessActivity, cmbBusinessActivity, "ActivityID", "ActivityCode")
        GetComboInit(New ParameterBusinessType, cmbBusinessType, "TypeID", "TypeCode")
        GetComboInit(New ParameterCountry, cmbAccountCcy, "CountryID", "Ccy")

        objSales.UserAccess = objAccess
        objClient.UserAccess = objAccess
        objRisk.UserAccess = objAccess
        objKYC.UserAccess = objAccess
        objMasterClient.UserAccess = objAccess
        objClientKYC.UserAccess = objAccess
        objClientRisk.UserAccess = objAccess

        DBGKYC.FetchRowStyles = True
        DBGRisk.FetchRowStyles = True
        DBGKYCAnswer.FetchRowStyles = True

        RiskLoad()
        GetSimpiKYCField(2)
        KYCLoad()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

#Region "risk profile"
    Private Sub RiskLoad()
        tblRisk.Columns.Add("No", GetType(Integer))
        tblRisk.Columns.Add("Question", GetType(String))
        tblRisk.Columns.Add("Answer", GetType(String))
        tblRisk.Columns.Add("Value", GetType(Integer))

        Dim tbl As New DataTable
        tbl = objRisk.Question_Search(objMasterSimpi, 2)
        Dim query = From r In tbl.AsEnumerable
                    Select No = r.Field(Of Integer)("QuestionNo"),
                           Question = r.Field(Of String)("QuestionText")
        For Each item In query
            Dim dr As DataRow = tblRisk.NewRow()
            dr("No") = item.No
            dr("Question") = item.Question
            dr("Answer") = ""
            dr("Value") = 0
            tblRisk.Rows.Add(dr)
        Next

        RiskDisplay()
    End Sub

    Private Sub RiskDisplay()
        With DBGRisk
            If isRisk Then
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = tblRisk
                isRisk = False
            Else
                DBGRisk.Rebind(True)
            End If

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

    Private Sub DBGRisk_DoubleClick(sender As Object, e As EventArgs) Handles DBGRisk.DoubleClick
        RiskSelect()
    End Sub

    Private Sub RiskSelect()
        With DBGRisk
            If .RowCount > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                lblRiskID.Text = .Columns("No").Text
                lblRiskQuestion.Text = .Columns("Question").Text
                AnswerClear()
                AnswerDisplay(.Columns("No").Text, .Columns("Value").Text)
            End If
        End With
    End Sub

    Private Sub AnswerDisplay(ByVal QuestionNo As Integer, ByVal AnswerValue As Integer)
        Dim tbl As New DataTable
        tbl = objRisk.Answer_Search(objMasterSimpi, 2, QuestionNo)
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
            Dim rowRisk() As DataRow = tblRisk.Select("No = " & Str(CInt(lblRiskID.Text)))
            If rbRisk1.Checked Then
                rowRisk(0)("Answer") = rbRisk1.Text
                rowRisk(0)("Value") = lblRisk1.Text
                lblRiskScore.Text = CInt(lblRiskScore.Text) + CInt(lblRisk1.Text)
            ElseIf rbRisk2.Checked Then
                rowRisk(0)("Answer") = rbRisk2.Text
                rowRisk(0)("Value") = lblRisk2.Text
                lblRiskScore.Text = CInt(lblRiskScore.Text) + CInt(lblRisk2.Text)
            ElseIf rbRisk3.Checked Then
                rowRisk(0)("Answer") = rbRisk3.Text
                rowRisk(0)("Value") = lblRisk3.Text
                lblRiskScore.Text = CInt(lblRiskScore.Text) + CInt(lblRisk3.Text)
            ElseIf rbRisk4.Checked Then
                rowRisk(0)("Answer") = rbRisk4.Text
                rowRisk(0)("Value") = lblRisk4.Text
                lblRiskScore.Text = CInt(lblRiskScore.Text) + CInt(lblRisk4.Text)
            ElseIf rbRisk5.Checked Then
                rowRisk(0)("Answer") = rbRisk5.Text
                rowRisk(0)("Value") = lblRisk5.Text
                lblRiskScore.Text = CInt(lblRiskScore.Text) + CInt(lblRisk5.Text)
            End If
            lblRiskCode.Text = objRisk.GetSimpiRiskLevel(objMasterSimpi, CInt(lblRiskScore.Text))
            lblRiskID.Text = ""
            lblRiskQuestion.Text = ""
            AnswerClear()
            RiskDisplay()
        End If
    End Sub

    Private Sub btnCancelRisk_Click(sender As Object, e As EventArgs) Handles btnCancelRisk.Click
        RiskCancel()
    End Sub

    Private Sub RiskCancel()
        If lblRiskID.Text.Trim <> "" Then
            Dim rowRisk() As DataRow = tblRisk.Select("No = " & Str(CInt(lblRiskID.Text)))
            lblRiskScore.Text = CInt(lblRiskScore.Text) - CInt(rowRisk(0)("Value"))
            rowRisk(0)("Answer") = ""
            rowRisk(0)("Value") = 0
            lblRiskCode.Text = objRisk.GetSimpiRiskLevel(objMasterSimpi, CInt(lblRiskScore.Text))
            lblRiskID.Text = ""
            lblRiskQuestion.Text = ""
            AnswerClear()
            RiskDisplay()
        End If
    End Sub

#End Region

#Region "kyc"
    Private Sub KYCLoad()
        tblKYC.Columns.Add("ID", GetType(Integer))
        tblKYC.Columns.Add("KYC", GetType(String))
        tblKYC.Columns.Add("Answer", GetType(String))
        tblKYC.Columns.Add("Description", GetType(String))
        Dim query = From r In dtSimpiKYC.AsEnumerable
                    Select ID = r.Field(Of Integer)("kycID"),
                           KYC = r.Field(Of String)("kycCode"),
                           Description = r.Field(Of String)("kycDescription")
        For Each item In query
            Dim dr As DataRow = tblKYC.NewRow()
            dr("ID") = item.ID
            dr("KYC") = item.KYC
            dr("Answer") = ""
            dr("Description") = item.Description
            tblKYC.Rows.Add(dr)
        Next

        KYCDisplay()
    End Sub

    Private Sub KYCDisplay()
        With DBGKYC
            If isKYC Then
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = tblKYC
                isKYC = False
            Else
                DBGKYC.Rebind(True)
            End If

            For Each column As C1DisplayColumn In DBGKYC.Splits(0).DisplayColumns
                column.AutoSize()
            Next

            Dim desc As C1DisplayColumn
            desc = .Splits(0).DisplayColumns("Description")
            desc.Width = 0
        End With
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
            Dim rowKYC() As DataRow = tblKYC.Select("ID = " & Str(CInt(lblKYCID.Text)))
            rowKYC(0)("Answer") = txtKYCAnswer.Text
            KYCClear()
            KYCDisplay()
        End If
    End Sub

    Private Sub btnCancelKYC_Click(sender As Object, e As EventArgs) Handles btnCancelKYC.Click
        KYCCancel()
    End Sub

    Private Sub KYCCancel()
        If lblKYCID.Text.Trim <> "" Then
            Dim rowKYC() As DataRow = tblKYC.Select("ID = " & Str(CInt(lblKYCID.Text)))
            rowKYC(0)("Answer") = ""
            KYCClear()
            KYCDisplay()
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

#Region "sales"
    Private Sub btnSearchSales_Click(sender As Object, e As EventArgs)
        SalesSearch()
    End Sub

    Private Sub SalesSearch()
        Dim form As New SelectMasterSales
        form.Show()
        form.lblSalesCode = lblSalesCode
        form.lblSalesName = lblSalesName
        form.MdiParent = MDIMIS
    End Sub

    Private Sub lblSalesCode_TextChanged(sender As Object, e As EventArgs) Handles lblSalesCode.TextChanged
        SalesLoad()
    End Sub

    Private Sub SalesLoad()
        If lblSalesCode.Text.Trim <> "" Then
            objSales.Clear()
            objSales.Load(objMasterSimpi, lblSalesCode.Text)
            If objSales.ErrID = 0 Then
                lblSalesHead.Text = objSales.GetTreeParentCode
            Else
                ExceptionMessage.Show(objSales.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#End Region

#Region "address"
    Private Sub txtAddressStreet_TextChanged(sender As Object, e As EventArgs) Handles txtAddressStreet.TextChanged
        ClientAddress()
    End Sub

    Private Sub txtAddressCity_TextChanged(sender As Object, e As EventArgs) Handles txtAddressCity.TextChanged
        ClientAddress()
    End Sub

    Private Sub txtAddressState_TextChanged(sender As Object, e As EventArgs) Handles txtAddressState.TextChanged
        ClientAddress()
    End Sub

    Private Sub txtAddressPostal_TextChanged(sender As Object, e As EventArgs) Handles txtAddressPostal.TextChanged
        ClientAddress()
    End Sub

    Private Sub cmbAddressCountry_TextChanged(sender As Object, e As EventArgs) Handles cmbAddressCountry.TextChanged
        ClientAddress()
    End Sub

    Private Sub ClientAddress()
        lblCorrespondenceAddress.Text = txtAddressStreet.Text.Trim & " " & txtAddressCity.Text.Trim & " " &
                       txtAddressState.Text.Trim & " " & cmbAddressCountry.Text.Trim & " " & txtAddressPostal.Text.Trim
    End Sub

#End Region

#Region "save"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DataSave()
    End Sub

    Private Function _check() As Boolean
        If objSales.GetSalesID = 0 Then
            ExceptionMessage.Show(objError.Message(81) & " master sales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbValuation.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " client valuation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbXRate.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " client exchange currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbAddressCountry.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " address country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbBusinessActivity.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " business activity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbBusinessType.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " business type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If txtBankName.Text.Trim = "" Then
            ExceptionMessage.Show(objError.Message(81) & " bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If txtAccountNo.Text.Trim = "" Then
            ExceptionMessage.Show(objError.Message(81) & " account no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbAccountCcy.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " account currenncy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub DataSave()
        If _check() Then
            objClient.Clear()
            objClient.Add(objMasterSimpi, objMasterSales, txtName.Text, cmbValuation.SelectedValue,
                          objRisk.GetSimpiRiskLevelID(objMasterSimpi, lblRiskScore.Text), cmbXRate.SelectedValue,
                          IIf(rbLocal.Checked, "L"c, "F"c), txtAddressStreet.Text, txtAddressCity.Text,
                          txtAddressState.Text, cmbAddressCountry.SelectedValue, txtAddressPostal.Text, txtPhone.Text,
                          txtEmail.Text, txtContactPerson.Text, txtSignatureRule.Text, txtTaxID.Text,
                          cmbBusinessType.SelectedValue, cmbBusinessActivity.SelectedValue)
            If objClient.ErrID = 0 Then
                objMasterClient.Clear()
                objMasterClient.Load(objMasterSimpi, objClient.GetClientCode)
                _saveBank()
                _saveKYC()
                _saveRisk()
                'dms IDCard
                'dms signature
                CallerForm.ClientSearch()
                Close()
            Else
                ExceptionMessage.Show(objClient.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub _saveBank()
        Dim objBank As New ClientBankAccount
        objBank.UserAccess = objAccess
        objBank.Add(objMasterClient, txtBankName.Text, txtBankBranch.Text, txtAccountNo.Text,
                    txtAccountName.Text, txtAccountNotes.Text, cmbAccountCcy.SelectedValue)
        If objBank.ErrID <> 0 Then
            ExceptionMessage.Show(objBank.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub _saveKYC()
        Dim kycID As Integer = 0
        Dim kycAnswer As String = ""
        If tblKYC.Rows.Count > 0 Then
            For i = 0 To tblKYC.Rows.Count - 1
                kycID = CInt(GetNullData(tblKYC.Rows(i)("ID"), 1))
                kycAnswer = CStr(GetNullData(tblKYC.Rows(i)("Answer"), 0))
                If kycAnswer.Trim <> "" Then
                    objClientKYC.Add(objMasterClient, kycID, kycAnswer)
                End If
            Next
        End If
    End Sub

    Private Sub _saveRisk()
        Dim QuestionNo As Integer = 0
        Dim QuestionText As String = ""
        Dim AnswerValue As Integer = 0
        Dim AnswerText As String = ""
        If tblRisk.Rows.Count > 0 Then
            objClientRisk.Add(objMasterClient)
            For i = 0 To tblRisk.Rows.Count - 1
                AnswerText = CStr(GetNullData(tblRisk.Rows(i)("Answer"), 0))
                If AnswerText.Trim <> "" Then
                    QuestionNo = CInt(GetNullData(tblRisk.Rows(i)("No"), 1))
                    QuestionText = CStr(GetNullData(tblRisk.Rows(i)("Question"), 0))
                    AnswerValue = CInt(GetNullData(tblRisk.Rows(i)("Value"), 1))
                    objClientRisk.Answer_Insert(QuestionNo, QuestionText, AnswerText, AnswerValue)
                End If
            Next
        End If
    End Sub

#End Region

End Class