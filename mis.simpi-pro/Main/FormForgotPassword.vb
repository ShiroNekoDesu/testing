Imports Renci.SshNet
Imports simpi.GlobalUtilities
Imports simpi.SimpiLogin

Public Class FormForgotPassword
    'Dim clientKey As Renci.SshNet.PrivateKeyFile
    'Dim clientSSH As SshClient
    'Dim tunnelSSH As ForwardedPort
    'Dim UserConnection As String = "Server=127.0.0.1;Port=8001;Database=simpi;uid=root;Pwd=''"
    'Dim DatabaseType As String = "MYSQL"
    'Dim objLogin As New UserLogin

    'Private Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    '    If clientSSH.IsConnected Then
    '        Try
    '            clientSSH.Disconnect()
    '            clientSSH.Dispose()
    '        Catch ex As Exception
    '            ExceptionMessage.Show(ex.Message)
    '        End Try
    '    End If
    'End Sub

    'Public Sub connect()
    '    Try
    '        'clientKey = New Renci.SshNet.PrivateKeyFile("c:\test", "filepassword")
    '        'clientSSH = New Renci.SshNet.SshClient(ServerAddress, ServerPort, ServerUser, clientKey)
    '        clientSSH = New SshClient("103.253.107.55", 22, "root", "4cXY3hrTBva1")
    '        clientSSH.Connect()
    '        tunnelSSH = New ForwardedPortLocal("127.0.0.1", 8001, "127.0.0.1", 3306)
    '        clientSSH.AddForwardedPort(tunnelSSH)
    '        tunnelSSH.Start()
    '        lblStatus.Text = "CONNECTED"
    '        Me.Text = "FORGOT PASSWORD"
    '        lblStatus.ForeColor = Color.Green
    '        imgSecurity.Image = objLogin.getSecurityImage()
    '    Catch ex As Exception
    '        ExceptionMessage.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    '    passwordSubmit()
    'End Sub

    'Private Sub passwordSubmit()
    '    Try
    '        objLogin.ForgotPassword(UserConnection, DatabaseType, txtAnswer.Text, AppsCode, txtUserEmail.Text, txtConfirmEmail.Text)
    '        If objLogin.ErrID = 0 Then
    '            ExceptionMessage.Show(objLogin.ErrorMessage(0, 75), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Application.Exit()
    '        Else
    '            ExceptionMessage.Show(objLogin.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Application.Exit()
    'End Sub

End Class