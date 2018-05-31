Imports simpi.GlobalUtilities
Imports simpi.ParameterClient
Imports simpi.MasterClient

Public Class FormMyClientInstitutionalSubEdit
    Public CallerForm As FormMyClientInstitutional
    Public objClient As MasterClientInstitutionSub

    Public Sub ClientLoad()
        If objClient.GetClientID = 0 Then
            Close()
        Else
            GetComboInit(New ParameterBusinessActivity, cmbBusinessActivity, "ActivityID", "ActivityCode")
            GetComboInit(New ParameterBusinessType, cmbBusinessType, "TypeID", "TypeCode")
            'parent
            lblSimpiID.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiID
            lblSimpiName.Text = objClient.GetClientParent.GetMasterSimpi.GetSimpiName
            lblSalesCode.Text = objClient.GetClientParent.GetMasterSales.GetSalesCode
            lblSalesName.Text = objClient.GetClientParent.GetMasterSales.GetSimpiUser.GetUserName
            lblSalesHead.Text = objClient.GetClientParent.GetMasterSales.GetTreeParentCode
            lblCode.Text = objClient.GetClientParent.GetClientCode
            lblName.Text = objClient.GetClientParent.GetClientName
            lblStatus.Text = objClient.GetClientParent.GetClientStatus.GetStatusCode
            lblRiskCode.Text = objClient.GetClientParent.GetClientRiskLevel.GetRiskCode
            lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
                   objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
                   objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
            lblCorrespondencePhone.Text = objClient.GetClientParent.GetCorrespondencePhone
            lblCorrespondenceEmail.Text = objClient.GetClientParent.GetCorrespondenceEmail

            'sub
            lblCIFSub.Text = objClient.GetClientCode
            lblNameSub.Text = objClient.GetClientName
            lblRiskCodeSubAccount.Text = objClient.GetClientRiskLevel.GetRiskCode
            txtSubName.Text = objClient.GetSubName
            txtSubSeparator.Text = objClient.GetSubSeparator
            lblValuation.Text = objClient.GetClientCcy.GetCcy
            lblXRate.Text = objClient.GetClientXRate.GetXRateCode
            txtTaxID.Text = objClient.GetLocalForeign
            If objClient.GetLocalForeign = "L"c Then
                rbLocal.Checked = True
            Else
                rbForegin.Checked = True
            End If
            cmbBusinessActivity.Text = objClient.GetBusinessActivity.GetActivityCode
            cmbBusinessType.Text = objClient.GetBusinessType.GetTypeCode
        End If
    End Sub

    Private Sub txtSubName_TextChanged(sender As Object, e As EventArgs) Handles txtSubName.TextChanged
        ClientName()
    End Sub

    Private Sub txtSubSeparator_TextChanged(sender As Object, e As EventArgs) Handles txtSubSeparator.TextChanged
        ClientName()
    End Sub

    Private Sub ClientName()
        lblNameSub.Text = lblName.Text.Trim & " " & txtSubSeparator.Text.Trim & " " & txtSubName.Text.Trim
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DataSave()
    End Sub

    Private Function _check() As Boolean
        If txtSubName.Text.Trim = "" Then
            ExceptionMessage.Show(objError.Message(81) & " sub name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            objClient.Edit(lblNameSub.Text, IIf(rbLocal.Checked, "L"c, "F"c), txtSignatureRule.Text,
                           txtTaxID.Text, cmbBusinessType.SelectedValue, cmbBusinessActivity.SelectedValue,
                           txtSubName.Text, txtSubSeparator.Text)
            If objClient.ErrID = 0 Then
                CallerForm.SubAccountSearch()
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