Imports simpi.GlobalUtilities
Imports simpi.MasterSecurities
Imports simpi.MasterClient
Imports simpi.ParameterClient

Public Class FormMyClientIndividualEdit
    Public CallerForm As FormMyClient
    Public objClient As MasterClientIndividu

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            GetComboGender(cmbGender)
            GetComboInit(New ParameterReligion, cmbReligion, "ReligionID", "ReligionCode")
            GetComboInit(New ParameterCountry, cmbNationality, "CountryID", "Nationality")
            GetComboInit(New ParameterCountry, cmbAddressCountry, "CountryID", "CountryName")
            GetComboInit(New ParameterEducationLevel, cmbEducation, "LevelID", "LevelCode")
            GetComboInit(New ParameterMaritalStatus, cmbMarital, "StatusID", "StatusCode")
            GetComboInit(New ParameterOccupation, cmbOccupation, "OccupationID", "OccupationCode")
            GetComboInit(New ParameterBusinessActivity, cmbOfficeBusinessActivity, "ActivityID", "ActivityCode")

            lblSimpiID.Text = objClient.GetMasterSimpi.GetSimpiID
            lblSimpiName.Text = objClient.GetMasterSimpi.GetSimpiName
            lblSalesCode.Text = objClient.GetMasterSales.GetSalesCode
            lblSalesName.Text = objClient.GetMasterSales.GetSimpiUser.GetUserName
            lblSalesHead.Text = objClient.GetMasterSales.GetTreeParentCode
            lblCIF.Text = objClient.GetClientCode
            lblStatus.Text = objClient.GetClientStatus.GetStatusCode
            lblRiskCode.Text = objClient.GetClientRiskLevel.GetRiskCode
            lblCorrespondencePhone.Text = objClient.GetCorrespondencePhone
            lblCorrespondenceEmail.Text = objClient.GetCorrespondenceEmail
            lblValuation.Text = objClient.GetClientCcy.GetCcy
            lblXRate.Text = objClient.GetClientXRate.GetXRateCode

            txtNameFirst.Text = objClient.GetNameFirst
            txtNameMiddle.Text = objClient.GetNameMiddle
            txtNameLast.Text = objClient.GetNameLast
            txtTitleFirst.Text = objClient.GetTitleFirst
            txtTitleLast.Text = objClient.GetTitleLast
            cmbGender.Text = objClient.GetGender
            txtBirthPlace.Text = objClient.GetBirthPlace
            dtBirth.Value = objClient.GetBirthDate
            txtMMN.Text = objClient.GetMMN
            cmbReligion.Text = objClient.GetReligion.GetReligionCode
            If objClient.GetLocalForeign = "L"c Then
                rbLocal.Checked = True
            Else
                rbForegin.Checked = True
            End If
            cmbNationality.Text = objClient.GetNationality.GetNationality
            txtAddressStreet.Text = objClient.GetCorrespondenceAddress
            txtAddressCity.Text = objClient.GetCorrespondenceCity
            txtAddressState.Text = objClient.GetCorrespondenceProvince
            cmbAddressCountry.Text = objClient.GetCorrespondenceCountry.GetCountryName
            txtAddressPostal.Text = objClient.GetCorrespondencePostal
            txtPhone.Text = objClient.GetCorrespondencePhone
            txtEmail.Text = objClient.GetCorrespondenceEmail
            txtTaxID.Text = objClient.GetTaxID
            cmbOccupation.Text = objClient.GetOccupation.GetOccupationCode
            txtOfficeName.Text = objClient.GetOfficeName
            txtOfficeAddress.Text = objClient.GetOfficeAddress
            txtOfficePhone.Text = objClient.GetOfficePhone
            cmbOfficeBusinessActivity.Text = objClient.GetOfficeBusinessActivity.GetActivityCode
            cmbEducation.Text = objClient.GetEducationLevel.GetLevelCode
            cmbMarital.Text = objClient.GetMaritalStatus.GetStatusCode
            txtSpouseName.Text = objClient.GetSpouseName
            If objClient.GetSpouseBirthDate.Trim = "" Then
                chkSpouseBirth.Checked = False
            Else
                chkSpouseBirth.Checked = True
                dtSpouseBirth.Value = CDate(objClient.GetSpouseBirthDate)
            End If

            txtName.Text = objClient.GetClientName
            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
        End If
    End Sub


#Region "name"
    Private Sub txtNameFirst_TextChanged(sender As Object, e As EventArgs) Handles txtNameFirst.TextChanged
        ClientName()
    End Sub

    Private Sub txtNameMiddle_TextChanged(sender As Object, e As EventArgs) Handles txtNameMiddle.TextChanged
        ClientName()
    End Sub

    Private Sub txtNameLast_TextChanged(sender As Object, e As EventArgs) Handles txtNameLast.TextChanged
        ClientName()
    End Sub

    Private Sub txtTitleFirst_TextChanged(sender As Object, e As EventArgs) Handles txtTitleFirst.TextChanged
        ClientName()
    End Sub

    Private Sub txtTitleLast_TextChanged(sender As Object, e As EventArgs) Handles txtTitleLast.TextChanged
        ClientName()
    End Sub

    Private Sub ClientName()
        txtName.Text = txtTitleFirst.Text.Trim & " " & txtNameFirst.Text.Trim & " " &
                       txtNameMiddle.Text.Trim & " " & txtNameLast.Text.Trim & " " & txtTitleLast.Text.Trim

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DataSave()
    End Sub

    Private Function _check() As Boolean
        If cmbAddressCountry.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " address country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbGender.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbNationality.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " nationality", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbEducation.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " education level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbOccupation.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " occupation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbReligion.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbOfficeBusinessActivity.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " business activity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        If cmbMarital.SelectedIndex = -1 Then
            ExceptionMessage.Show(objError.Message(81) & " marital status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub DataSave()
        If _check() Then
            objClient.Edit(txtName.Text, IIf(rbLocal.Checked, "L"c, "F"c), txtAddressStreet.Text,
                      txtAddressCity.Text, txtAddressState.Text, cmbAddressCountry.SelectedValue, txtAddressPostal.Text,
                      txtPhone.Text, txtEmail.Text, txtNameFirst.Text, txtNameMiddle.Text, txtNameLast.Text, txtTitleFirst.Text,
                      txtTitleLast.Text, txtBirthPlace.Text, dtBirth.Value, txtMMN.Text, txtTaxID.Text,
                      cmbGender.Text, cmbNationality.SelectedValue, cmbReligion.SelectedValue, cmbEducation.SelectedValue,
                      cmbOccupation.SelectedValue, txtOfficeName.Text, txtOfficeAddress.Text, txtOfficePhone.Text,
                      cmbOfficeBusinessActivity.SelectedValue, cmbMarital.SelectedValue, txtSpouseName.Text,
                      IIf(chkSpouseBirth.Checked, dtSpouseBirth.Value.ToString("dd-MMM-yyyy"), ""))
            If objClient.ErrID = 0 Then
                CallerForm.ClientSearch()
                Close()
            Else
                ExceptionMessage.Show(objClient.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

End Class