Imports simpi.MasterClient

Public Class FormMyClientInstitutionalIDCard
    Public objOfficer As ClientOfficer

    Public Sub IDCardLoad()
        txtIDCardType.Text = objOfficer.GetIDCardType.GetTypeCode
        txtIDCardNo.Text = objOfficer.GetIDCardNo
        txtIDCardIssuer.Text = objOfficer.GetIDCardIssuer
        dtIDCardExpired.Value = objOfficer.GetIDCardExpired
        chkIDCardIsExpired.Checked = objOfficer.GetIDCardIsExpired
    End Sub

End Class