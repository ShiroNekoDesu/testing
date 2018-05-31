Public Class ReportStatpro
    Private Sub ReportStatpro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebIV.Navigate(New Uri("https://secure.statpro.com/revolution"))
    End Sub
End Class