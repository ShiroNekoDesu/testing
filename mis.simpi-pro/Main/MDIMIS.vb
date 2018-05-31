Imports Renci.SshNet
Imports System.Net.NetworkInformation
Imports System.ComponentModel
Imports simpi.GlobalUtilities
Imports simpi.SimpiLogin

Public Class MDIMIS
    Public ServerUser As String = ""
    Public ServerPassword As String = ""
    Public ServerAddress As String = ""
    Public ServerPort As Integer = 0
    Public ServerDestinationPort As UInteger = 0
    Public UserPassword As String = ""
    Public UserLogin As String = ""
    Public isSSH As Boolean = False

    Dim UserConnection As String = ""
    Public DatabaseType As String = ""
    Public DatabaseName As String = ""
    Public DatabaseServer As String = ""
    Public DatabasePassword As String = ""
    Public DatabaseUser As String = ""

    Dim objLogin As New UserLogin
    Dim clientSSH As SshClient
    Dim tunnelSSH As ForwardedPortLocal
    Dim p As New Ping

    Dim connInfo As ConnectionInfo
    Dim connUser As PasswordAuthenticationMethod
    Public proxyUse As Boolean
    Public proxyServer As String
    Public proxyType As Integer
    Public proxyPort As Integer
    Public proxyUser As String
    Public proxyPassword As String

#Region "windows"
    Private Sub fileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileExit.Click
        ApplicationExit()
    End Sub

    Private Sub fileWindowsCascade_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileWindowsCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub fileWindowsTileVertical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub fileWindowsTileHorizontal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub fileWindowsArrangeAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileWindowsArrangeAll.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub fileWindowsCloseAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileWindowsCloseAll.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub tsbExit_Click(sender As Object, e As EventArgs) Handles tsbExit.Click
        ApplicationExit()
    End Sub

#End Region

#Region "server connection"
    Private Sub server_close()
        If isSSH Then
            If clientSSH.IsConnected Then
                Try
                    clientSSH.Disconnect()
                    clientSSH.Dispose()
                Catch ex As Exception
                    ExceptionMessage.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Public Sub server_connect()
        Try
            If proxyUse Then sConnectProxy() Else sConnectNonProxy()
            logon()
            tmr.Enabled = True
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        If isSSH And Not clientSSH.IsConnected And lblStatus.Text.Trim = "NOT CONNECTED" Then
            lblStatus.Text = "Wait to Connect"
            lblStatus.ForeColor = Color.Red
            Application.DoEvents()
            Threading.Thread.Sleep(100)
            tunnelSSH.Stop()
            If proxyUse Then sConnectProxy() Else sConnectNonProxy()
            tmr.Enabled = True
        End If
    End Sub

    Private Sub sConnectProxy()
        If proxyType = 1 Then
            connUser = New PasswordAuthenticationMethod(ServerUser, "")
            connInfo = New ConnectionInfo(ServerAddress, ServerPort, ServerUser, proxyType, proxyServer, proxyPort, proxyUser, "", connUser)
        Else
            connUser = New PasswordAuthenticationMethod(ServerUser, ServerPassword)
            connInfo = New ConnectionInfo(ServerAddress, ServerPort, ServerUser, proxyType, proxyServer, proxyPort, proxyUser, proxyPassword, connUser)
        End If
        clientSSH = New SshClient(connInfo)
        sConnect()
    End Sub

    Private Sub sConnectNonProxy()
        clientSSH = New SshClient(ServerAddress, ServerPort, ServerUser, ServerPassword)
        sConnect()
    End Sub

    Private Sub sConnect()
        clientSSH.Connect()
        tunnelSSH = New ForwardedPortLocal(DatabaseServer, DatabaseServer, ServerDestinationPort)
        clientSSH.AddForwardedPort(tunnelSSH)
        tunnelSSH.Start()
        lblSpeed.Text = RoundtripTime(ServerAddress)
        lblStatus.Text = "CONNECTED"
        lblStatus.ForeColor = Color.Green

        UserConnection = "Server=" & DatabaseServer & ";Port=" & tunnelSSH.BoundPort & ";Database=" & DatabaseName & ";uid=" & DatabaseUser
        If DatabasePassword.Trim = "" Then
            UserConnection &= ";Pwd=''"
        Else
            UserConnection &= ";Pwd=" & DatabasePassword
        End If
        objAccess.DatabaseConnection = UserConnection
    End Sub

    Public Function RoundtripTime(ByVal address As String) As String
        Dim reply As PingReply = p.Send(address)
        If reply.Status = IPStatus.Success Then
            Return "connection speed: " & reply.RoundtripTime & " ms"
        End If
        Return ""
    End Function

    Private Sub isConnectedProperty()
        If isSSH Then
            If clientSSH.IsConnected And lblStatus.Text.Trim <> "CONNECTED" Then
                lblStatus.Text = "CONNECTED"
                lblStatus.ForeColor = Color.Green
            ElseIf Not clientSSH.IsConnected And lblStatus.Text.Trim <> "NOT CONNECTED" Then
                lblStatus.Text = "NOT CONNECTED"
                lblStatus.ForeColor = Color.Red
                'p.Dispose()
                lblSpeed.Text = ""
                tmr.Enabled = False
            End If
        End If
    End Sub

    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        If isSSH Then
            tmr.Enabled = False
            bw.RunWorkerAsync()
        End If
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Try
            lblSpeed.Text = RoundtripTime(ServerAddress)
            isConnectedProperty()
        Catch ex As Exception
            isConnectedProperty()
        End Try
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If isSSH And lblStatus.Text.Trim = "CONNECTED" Then
            tmr.Enabled = True
        End If
    End Sub

#End Region

#Region "application access"
    Private Sub logon()
        If objLogin.Logon(UserConnection, DatabaseType, UserLogin, UserPassword, AppsCode, AppsVersion) Then
            If objLogin.ErrID = 0 Then
                objAccess.DatabaseConnection = UserConnection
                objAccess.DatabaseType = DatabaseType
                objAccess.GetSimpiLogin = objLogin
                lblUser.Text = "Master Simpi: " & objAccess.GetSimpiName.ToString() + ", UserName: " + objAccess.GetUserName.ToString() +
                               " | " + objAccess.GetUserTitle.ToString()
                lblAsOf.Text = "As of: " + objAccess.GetServerDate().ToString("dd-MMM-yyyy")
                lblVersion.Text = "version: " & AppsVersion
                lblTerminal.Text = "terminal: " & AppsTerminal & " port: " & tunnelSSH.BoundPort
                objError.Clear()
                objError.UserAccess = objAccess
                GetMasterSimpi()
                cipLogin.Visible = False
                msMenu.Enabled = True
                tsbUserProfile.Enabled = True
                tsMenu.Enabled = True
            Else
                ExceptionMessage.Show(objLogin.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cipLogin.Visible = True
                txtUserLogin.Focus()
            End If
        Else
            ExceptionMessage.Show(objLogin.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cipLogin.Visible = True
            txtUserLogin.Focus()
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        logon2()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Return Then
            logon2()
        End If
    End Sub

    Private Sub logon2()
        UserLogin = txtUserLogin.Text
        UserPassword = txtPassword.Text
        If objLogin.Logon(UserConnection, DatabaseType, UserLogin, UserPassword, AppsCode, AppsVersion) Then
            If objLogin.ErrID = 0 Then
                objAccess.DatabaseConnection = UserConnection
                objAccess.DatabaseType = DatabaseType
                objAccess.GetSimpiLogin = objLogin
                lblUser.Text = "Master Simpi: " & objAccess.GetSimpiName.ToString() + ", UserName: " + objAccess.GetUserName.ToString() +
                               " | " + objAccess.GetUserTitle.ToString()
                lblAsOf.Text = "As of: " + objAccess.GetServerDate().ToString("dd-MMM-yyyy")
                lblVersion.Text = "version: " & AppsVersion
                lblTerminal.Text = "terminal: " & AppsTerminal & " port: " & clientSSH.ConnectionInfo.Port
                objError.Clear()
                objError.UserAccess = objAccess
                GetMasterSimpi()
                cipLogin.Visible = False
                msMenu.Enabled = True
                tsbUserProfile.Enabled = True
                tsMenu.Enabled = True
            Else
                ExceptionMessage.Show(objLogin.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUserLogin.Focus()
            End If
        Else
            ExceptionMessage.Show(objLogin.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUserLogin.Focus()
        End If
    End Sub

    Private Sub ApplicationExit()
        objAccess.Logout()
        Application.Exit()
    End Sub

    Private Sub MenuCheck(ByVal strMenu As String)
        'If Not objAccess.AccessMenu(strMenu) Then
        '    Throw New Exception("System detect user: " & objAccess.GetUserName & " did not had access to menu: " & strMenu)
        'End If
    End Sub

    Private Sub tsbUserProfile_Click(sender As Object, e As EventArgs) Handles tsbUserProfile.Click
        Dim frm As New FormProfileUser
        frm.Left = 0
        frm.Top = 30
        frm.MdiParent = Me
        frm.Show()
    End Sub


#End Region

#Region "unit registry fund report"
    Private Sub frFundOutstanding_Click(sender As Object, e As EventArgs) Handles frFundOutstanding.Click
        Try
            MenuCheck("Report Fund Outstanding")
            Dim frm As New ReportFundOutstanding
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub frFundTransaction_Click(sender As Object, e As EventArgs) Handles frFundTransaction.Click
        Try
            MenuCheck("Report Fund Transaction")
            Dim frm As New ReportFundTransaction
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub frAUM_Click(sender As Object, e As EventArgs) Handles frAUM.Click
        Try
            MenuCheck("Report Fund AUM")
            Dim frm As New ReportFundNAV
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub frFee_Click(sender As Object, e As EventArgs) Handles frFee.Click
        Try
            MenuCheck("Report Management Fee")
            Dim frm As New ReportManagementFee
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub frDividend_Click(sender As Object, e As EventArgs) Handles frDividend.Click
        Try
            MenuCheck("Report Dividend Distribution")
            Dim frm As New ReportFundDistribution
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "unit registry client report"
    Private Sub crAccountSheet_Click(sender As Object, e As EventArgs) Handles crAccountSheet.Click
        Try
            MenuCheck("Report Account Sheet")
            Dim frm As New ReportAccountFactSheet
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub crAccountValution_Click(sender As Object, e As EventArgs) Handles crAccountValution.Click
        Try
            MenuCheck("Report Account Valuation")
            Dim frm As New ReportAccountValuation
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub crAccountTransaction_Click(sender As Object, e As EventArgs) Handles crAccountTransaction.Click
        Try
            MenuCheck("Report Account Transaction")
            Dim frm As New ReportAccountStatement
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub crAccountFee_Click(sender As Object, e As EventArgs) Handles crAccountFee.Click
        Try
            MenuCheck("Report Account Revenue")
            Dim frm As New ReportAccountFee
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "unit registry sales report"
    Private Sub srAUM_Click(sender As Object, e As EventArgs) Handles srAUM.Click
        Try
            MenuCheck("Report Sales AUM")
            Dim frm As New ReportSalesAUM
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub srSalesTransaction_Click(sender As Object, e As EventArgs) Handles srSalesTransaction.Click
        Try
            MenuCheck("Report Sales Transaction")
            Dim frm As New ReportSalesTransaction
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub srTotalTransaction_Click(sender As Object, e As EventArgs) Handles srTotalTransaction.Click
        Try
            MenuCheck("Report Sales Total Transaction")
            Dim frm As New ReportSalesTransactionTotal
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub srUnitholderListing_Click(sender As Object, e As EventArgs) Handles srUnitholderListing.Click
        Try
            MenuCheck("Report Sales Unitholder")
            Dim frm As New ReportSalesUnitholderListing
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "unit registry transaction report"
    Private Sub urTransactionInquiry_Click(sender As Object, e As EventArgs) Handles urTransactionInquiry.Click
        Try
            MenuCheck("Report Unit Transaction")
            Dim frm As New ReportInquiryTransaction
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "marketing collateral"
    Private Sub mcFundSheetEQ_Click(sender As Object, e As EventArgs) Handles mcFundSheetEQ.Click
        Try
            MenuCheck("Fund Sheet Equities")
            Dim frm As New FundSheetEQ
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "mis & crosstab"
    Private Sub misReturnCalculator_Click(sender As Object, e As EventArgs) Handles misReturnCalculator.Click
        Try
            MenuCheck("MyClient")
            Dim frm As New MISCalculatorReturn
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub misMonthlyMap_Click(sender As Object, e As EventArgs) Handles misMonthlyMap.Click
        Try
            MenuCheck("MyClient")
            Dim frm As New MISMonthlyMap
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Dashboard"
    Private Sub MyClient_Click(sender As Object, e As EventArgs) Handles MyClient.Click
        Try
            MenuCheck("MyClient")
            Dim frm As New FormMyClient
            frm.Left = 0
            frm.Top = 30
            frm.MdiParent = Me
            frm.Show()
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

#End Region


End Class
