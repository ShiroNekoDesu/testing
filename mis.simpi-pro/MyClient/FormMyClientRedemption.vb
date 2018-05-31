Public Class FormMyClientRedemption
    Private Sub btnNew_Click(sender As Object, e As EventArgs) 
        Dim frm As New FormMyClientRedemptionNew
        frm.Left = 0
        frm.Top = 30
        frm.MdiParent = MDIMIS
        frm.Show()
    End Sub
End Class