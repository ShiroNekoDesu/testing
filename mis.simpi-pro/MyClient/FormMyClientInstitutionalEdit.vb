Imports simpi.GlobalUtilities
Imports simpi.MasterSecurities
Imports simpi.ParameterClient
Imports simpi.MasterClient

Public Class FormMyClientInstitutionalEdit
    Public CallerForm As FormMyClient
    Public objClient As MasterClientInstitution

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            GetComboInit(New ParameterCountry, cmbAddressCountry, "CountryID", "CountryName")
            cmbAddressCountry.SelectedIndex = -1
            GetComboInit(New ParameterBusinessActivity, cmbBusinessActivity, "ActivityID", "ActivityCode")
            GetComboInit(New ParameterBusinessType, cmbBusinessType, "TypeID", "TypeCode")

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

            txtName.Text = objClient.GetClientName
            txtTaxID.Text = objClient.GetTaxID
            cmbBusinessActivity.Text = objClient.GetBusinessActivity.GetActivityCode
            cmbBusinessType.Text = objClient.GetBusinessType.GetTypeCode
            If objClient.GetLocalForeign = "L"c Then
                rbLocal.Checked = True
            Else
                rbForegin.Checked = True
            End If
            txtAddressStreet.Text = objClient.GetCorrespondenceAddress
            txtAddressCity.Text = objClient.GetCorrespondenceCity
            txtAddressState.Text = objClient.GetCorrespondenceProvince
            cmbAddressCountry.Text = objClient.GetCorrespondenceCountry.GetCountryName
            txtAddressPostal.Text = objClient.GetCorrespondencePostal
            txtPhone.Text = objClient.GetCorrespondencePhone
            txtEmail.Text = objClient.GetCorrespondenceEmail
            txtContactPerson.Text = objClient.GetContactPerson
            txtSignatureRule.Text = objClient.GetSignatureRule

            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
        End If
    End Sub

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
        Return True
    End Function

    Private Sub DataSave()
        If _check() Then
            objClient.Edit(txtName.Text, IIf(rbLocal.Checked, "L"c, "F"c), txtAddressStreet.Text,
                      txtAddressCity.Text, txtAddressState.Text, cmbAddressCountry.SelectedValue, txtAddressPostal.Text,
                      txtPhone.Text, txtEmail.Text, txtContactPerson.Text, txtSignatureRule.Text, txtTaxID.Text,
                      cmbBusinessType.SelectedValue, cmbBusinessActivity.SelectedValue)
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