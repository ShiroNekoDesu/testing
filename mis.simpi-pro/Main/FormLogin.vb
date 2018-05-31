Imports simpi.GlobalUtilities
Imports System.IO
Imports simpi.GlobalConnection

Public Class FormLogin
    Dim ServerUser As String = ""
    Dim ServerPassword As String = ""
    Dim ServerAddress As String = ""
    Dim ServerPort As Integer = 0
    Dim ServerDestinationPort As Integer = 0

    Dim DatabaseName As String = ""
    Dim DatabaseServer As String = ""
    Dim DatabasePort As Integer = 0
    Dim DatabasePassword As String = ""
    Dim DatabaseUser As String = ""

    Dim UserPassword As String = ""
    Dim UserLogin As String = ""
    Dim isSSH As Boolean = False
    Dim UserConnection As String = ""
    Dim DatabaseType As String = ""

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        LogOn()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Return Then LogOn()
    End Sub

    Private Sub LogOn()
        Try
            ReadToken()
            Submit()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub ReadToken()
        Dim strFile As String = simpiFile("simpi.token")
        AppsTerminal = GetMacAddress()
        If AppsTerminal.Trim.Length < 1 Then Throw New ExceptionDataNotFound("internet connection/terminal MAC Address")
        strFile &= "." & AppsTerminal
        If Not GlobalFileWindows.FileExists(strFile) Then Throw New ExceptionDataNotFound("simpi token file")

        Dim objReader As New StreamReader(strFile)
        Dim aes As New GlobalEncryption
        LicenseKey = objReader.ReadLine
        Dim key, iv As String
        key = _key(AppsTerminal, LicenseKey)
        iv = _iv(AppsTerminal, LicenseKey)
        Dim TermimalMacAddress As String = aes.TDES_Decrypt(key, iv, objReader.ReadLine)
        If AppsTerminal <> TermimalMacAddress Then
            ExceptionMessage.Show("system detect simpi token is not valid for this terminal. Please contact your simpi administrator to resolve it",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If
        DatabaseServer = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 1, 99, 86, 65, 82, 66, 91, 67, 81)
        DatabasePort = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 88, 54, 55, 51)
        DatabaseName = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 84, 29, 13, 88, 38)
        DatabaseUser = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 21, 69, 28, 36)
        DatabasePassword = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 71, 85)
        DatabaseType = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 96, 4, 50, 23, 130)
        If aes.TDES_Decrypt(key, iv, objReader.ReadLine).Trim.ToUpper = "YES" Then
            isSSH = True
            ServerUser = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 38, 77, 103, 69)
            ServerPassword = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 133, 108, 89, 1, 32, 104, 120, 6, 15, 91, 76, 29)
            ServerAddress = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 31, 80, 61, 126, 36, 62, 32, 81, 67, 44, 68, 125, 74, 50)
            ServerPort = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 90, 53)
            ServerDestinationPort = getString(aes.TDES_Decrypt(key, iv, objReader.ReadLine), 91, 52, 17, 16)
        Else
            isSSH = False
            ServerUser = ""
            ServerPassword = ""
            ServerAddress = ""
            ServerPort = 0
            ServerDestinationPort = 0
        End If
        objReader.Close()
        objReader.Dispose()

        If DatabaseServer.Trim = "" Or DatabasePort = 0 Or DatabaseName.Trim = "" Or DatabaseUser.Trim = "" Then
            ExceptionMessage.Show("system detect invalid simpi token, can not read any database connection." &
                                  " Please contact your simpi administrator to resolve it",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If
    End Sub

    Private Sub Submit()
        With MDIMIS
            .Show()
            buttonSet(False)
            .isSSH = isSSH
            .ServerAddress = ServerAddress
            .ServerPort = ServerPort
            .ServerDestinationPort = ServerDestinationPort
            .ServerUser = ServerUser
            .ServerPassword = ServerPassword
            .DatabaseServer = DatabaseServer
            .DatabaseName = DatabaseName
            .DatabaseUser = DatabaseUser
            .DatabasePassword = DatabasePassword
            .DatabaseType = DatabaseType
            .UserLogin = txtUserLogin.Text
            .UserPassword = txtPassword.Text
            If chkProxy.Checked Then .proxyUse = True Else .proxyUse = False
            .proxyType = 2 'Sock 5
            .proxyServer = txtProxyHost.Text
            If IsNumeric(txtProxyPort.Text) Then .proxyPort = txtProxyPort.Text Else .proxyPort = 0
            .proxyUser = txtProxyUser.Text
            .proxyPassword = txtProxyPassword.Text
            .server_connect()
            Close()
        End With
    End Sub

    Public Sub buttonSet(state As Boolean)
        cmdSubmit.Enabled = state
        cmdClose.Enabled = state
        btnForgotPassword.Enabled = state
        btnFolder.Enabled = state
        btnPing.Enabled = state
        btnNetwork.Enabled = state
        chkProxy.Enabled = state
        If Not state Then ighProxy.Collapsed = True
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Application.Exit()
    End Sub

    Private Sub cmdClose_KeyDown(sender As Object, e As KeyEventArgs) Handles cmdClose.KeyDown
        Application.Exit()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTerminalID.Text = GetMacAddress()
    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click
        OpenFolder()
    End Sub

    Private Sub OpenFolder()
        Process.Start("explorer.exe", String.Format("/n, /e, {0}", My.Application.Info.DirectoryPath))
    End Sub

    Private Sub btnPing_Click(sender As Object, e As EventArgs) Handles btnPing.Click
        PingConnection()
    End Sub

    Private Sub PingConnection()
        Dim ps As New Process
        With ps.StartInfo
            .FileName = "cmd.exe"
            .Arguments = "/K ping www.google.com -t"
            .CreateNoWindow = False
        End With
        ps.Start()
        ps.Close()
    End Sub

    Private Sub btnNetwork_Click(sender As Object, e As EventArgs) Handles btnNetwork.Click
        ExceptionMessage.Show(GetMacAddressList, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ighProxy_CollapsedChanged(sender As Object, e As EventArgs) Handles ighProxy.CollapsedChanged
        If ighProxy.Collapsed Then Height = 275 Else Height = 375
    End Sub

    Private Sub chkProxy_CheckedChanged(sender As Object, e As EventArgs) Handles chkProxy.CheckedChanged
        proxyEnable()
    End Sub

    Private Sub proxyEnable()
        If chkProxy.Checked Then
            txtProxyHost.Enabled = True
            txtProxyPort.Enabled = True
            txtProxyUser.Enabled = True
            txtProxyPassword.Enabled = True
            btnSave.Enabled = True
            iniLoad()
        Else
            txtProxyHost.Enabled = False
            txtProxyPort.Enabled = False
            txtProxyUser.Enabled = False
            txtProxyPassword.Enabled = False
            btnSave.Enabled = False
            txtProxyHost.Text = ""
            txtProxyPort.Text = ""
            txtProxyUser.Text = ""
            txtProxyPassword.Text = ""
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        iniSave()
    End Sub

    Private Sub iniSave()
        Try
            If txtProxyHost.Text.Trim = "" Then
                ExceptionMessage.Show("System can not detect proxy host", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Not IsNumeric(txtProxyPort.Text) Then
                ExceptionMessage.Show("System can not detect proxy port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If txtProxyUser.Text.Trim = "" Then
                ExceptionMessage.Show("System can not detect proxy user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If txtProxyPassword.Text.Trim = "" Then
                ExceptionMessage.Show("System can not detect proxy password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim strFile As String = simpiFile("simpi.ini")
            Dim file As New GlobalINI(strFile)
            Dim section As String = "Proxy Server"
            file.WriteBoolean(section, "Proxy Use", True)
            file.WriteString(section, "Proxy Type", "SOCK 5")
            file.WriteString(section, "Proxy Host", txtProxyHost.Text.Trim)
            file.WriteInteger(section, "Proxy Port", txtProxyPort.Text.Trim)
            file.WriteString(section, "Proxy User", txtProxyUser.Text.Trim)
            Dim aes As New GlobalEncryption
            file.WriteString(section, "Proxy Password", aes.TDES_Encrypt(txtProxyPassword.Text.Trim))
            ExceptionMessage.Show("proxy setting had been saved")
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub iniLoad()
        Try
            Dim strFile As String = simpiFile("simpi.ini")
            If GlobalFileWindows.FileExists(strFile) Then
                Dim file As New GlobalINI(strFile)
                Dim section As String = "Proxy Server"
                If file.GetBoolean(section, "Proxy Use", False) Then
                    chkProxy.Checked = True
                    txtProxyHost.Text = file.GetString(section, "Proxy Host", "")
                    txtProxyPort.Text = file.GetInteger(section, "Proxy Port", 0)
                    txtProxyUser.Text = file.GetString(section, "Proxy User", "")
                    Dim readValue = file.GetString(section, "Proxy Type", "")
                    Dim aes As New GlobalEncryption
                    txtProxyPassword.Text = aes.TDES_Decrypt(file.GetString(section, "Proxy Password", ""))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class