Imports simpi.GlobalUtilities

Public Class FormPassword
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        PasswordSave()
    End Sub

    Private Sub PasswordSave()
        If txtPasswordOld.Text.Trim <> "" And
            txtPasswordNew.Text.Trim <> "" And txtPasswordConfirm.Text.Trim <> "" Then
            objAccess.PasswordChange(txtPasswordOld.Text, txtPasswordNew.Text, txtPasswordConfirm.Text)
            If objAccess.ErrID = 0 Then
                Close()
            Else
                ExceptionMessage.Show(objAccess.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class