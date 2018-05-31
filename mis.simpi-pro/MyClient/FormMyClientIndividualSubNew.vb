Imports simpi.GlobalUtilities
Imports simpi.MasterSecurities
Imports simpi.MasterClient

Public Class FormMyClientIndividualSubNew
    Public CallerForm As FormMyClientIndividual
    Public objParent As MasterClientIndividu
    Dim objClient As New MasterClientIndividuSub

    Public Sub ParentLoad()
        GetComboInit(New ParameterCountry, cmbValuation, "CountryID", "Ccy")
        GetComboInit(New ParameterXRate, cmbXRate, "XRateID", "XRateCode")
        objClient.UserAccess = objAccess

        lblSimpiID.Text = objParent.GetMasterSimpi.GetSimpiID
        lblSimpiName.Text = objParent.GetMasterSimpi.GetSimpiName
        lblSalesCode.Text = objParent.GetMasterSales.GetSalesCode
        lblSalesName.Text = objParent.GetMasterSales.GetSimpiUser.GetUserName
        lblSalesHead.Text = objParent.GetMasterSales.GetTreeParentCode
        lblCode.Text = objParent.GetClientCode
        lblName.Text = objParent.GetClientName
        lblStatus.Text = objParent.GetClientStatus.GetStatusCode
        lblRiskCode.Text = objParent.GetClientRiskLevel.GetRiskCode
        lblCorrespondenceAddress.Text = objClient.GetCorrespondenceAddress & " " &
               objClient.GetCorrespondenceCity & " " & objClient.GetCorrespondenceProvince & " " &
               objClient.GetCorrespondenceCountry.GetCountryName & " " & objClient.GetCorrespondencePostal
        lblCorrespondencePhone.Text = objParent.GetCorrespondencePhone
        lblCorrespondenceEmail.Text = objParent.GetCorrespondenceEmail
        cmbValuation.Text = objParent.GetClientCcy.GetCcy
        cmbXRate.Text = objParent.GetClientXRate.GetXRateCode
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

    Private Sub chkSeparateAccount_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeparateAccount.CheckedChanged
        If chkSeparateAccount.Checked Then
            chkSeparateAccount.Text = "Y"
        Else
            chkSeparateAccount.Text = "N"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DataSave()
    End Sub

    Private Function _check() As Boolean
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
        If txtSubName.Text.Trim = "" Then
            ExceptionMessage.Show(objError.Message(81) & " sub name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub DataSave()
        If _check() Then
            objClient.Clear()
            objClient.Add(objParent, objMasterSales, lblNameSub.Text, txtSubName.Text, txtSubSeparator.Text, chkSeparateAccount.Text)
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