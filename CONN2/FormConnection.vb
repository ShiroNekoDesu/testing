Imports Chilkat
Imports System.Net.NetworkInformation
Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class FormConnection
    Public ServerUser As String = "root"
    Public ServerPassword As String = "4cXY3hrTBva1"
    Public ServerAddress As String = "103.253.107.55"
    Public ServerPort As Integer = 22
    Public ServerDestinationPort As UInteger = 3306

    Dim UserConnection As String = ""
    Public DatabaseType As String = "MySQL"
    Public DatabaseName As String = "simpi"
    Public DatabaseServer As String = "localhost"
    Public DatabasePassword As String = ""
    Public DatabaseUser As String = "root"

    Dim chilkatGlob As New Chilkat.Global
    Dim tunnel As New SshTunnel
    Dim success As Boolean
    Dim p As New Ping

    Public proxyUse As Boolean
    Public proxyServer As String
    Public proxyType As Integer
    Public proxyPort As Integer
    Public proxyUser As String
    Public proxyPassword As String

    Private Sub initStatus()
        With fgStatus
            .Rows.Count = 1
            .Cols.Count = 1
            fgStatus(0, 0) = "Status"
            .AutoSizeCols()
        End With
    End Sub

    Private Sub fillStatus(ByVal status As String)
        With fgStatus
            If fgStatus.Rows.Count > 13 Then
                fgStatus.Rows.Count = 0
                fgStatus(0, 0) = "Status"
            End If
            fgStatus.Rows.Add()
            fgStatus(fgStatus.Rows.Count - 1, 0) = status
            fgStatus.AutoSizeCols()
        End With
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        btnConnect.Enabled = False
        initStatus()
        lblStatus.Text = "Wait to Connect"
        lblStatus.ForeColor = Color.Red
        Application.DoEvents()
        Threading.Thread.Sleep(100)

        success = chilkatGlob.UnlockBundle("TrialChilkat")
        If Not success Then
            fillStatus(chilkatGlob.LastErrorText)
            Exit Sub
        Else
            fillStatus("chilkat initialization")
        End If
        If proxyUse Then
            Dim port As Integer
            tunnel.SocksHostname = txtProxyServer.Text.Trim
            Integer.TryParse(txtProxyPort.Text, port)
            tunnel.SocksPort = port
            tunnel.SocksUsername = txtProxyUser.Text.Trim
            tunnel.SocksPassword = txtProxyPassword.Text.Trim
            tunnel.SocksVersion = 5
        End If
        sConnect()
        tmr.Enabled = True
    End Sub

    Private Sub sConnect()
        success = tunnel.Connect(ServerAddress, ServerPort)
        If Not success Then
            fillStatus(chilkatGlob.LastErrorText)
            Exit Sub
        Else
            fillStatus("tunnel connect")
        End If

        success = tunnel.AuthenticatePw(ServerUser, ServerPassword)
        If Not success Then
            fillStatus(chilkatGlob.LastErrorText)
            Exit Sub
        Else
            fillStatus("tunnel authentication")
        End If

        tunnel.DestPort = ServerDestinationPort
        tunnel.DestHostname = DatabaseServer

        Dim listenPort As Integer = 3316
        success = tunnel.BeginAccepting(listenPort)
        If Not success Then
            fillStatus(tunnel.LastErrorText)
            Exit Sub
        Else
            fillStatus("tunnel begin accepting")
        End If

        RoundtripTime(ServerAddress)
        lblStatus.Text = "CONNECTED"
        lblStatus.ForeColor = Color.Green

        UserConnection = "Server=" & DatabaseServer & ";Port=" & listenPort & ";Database=" & DatabaseName & ";uid=" & DatabaseUser
        If DatabasePassword.Trim = "" Then UserConnection &= ";Pwd=''" Else UserConnection &= ";Pwd=" & DatabasePassword
        btnRead.Enabled = True
    End Sub

    Public Sub RoundtripTime(ByVal address As String)
        Dim reply As PingReply = p.Send(address)
        If reply.Status = IPStatus.Success Then
            fillStatus("connection speed: " & reply.RoundtripTime & " ms")
        End If
    End Sub

    Private Sub isConnectedProperty()
        If tunnel.IsSshConnected And lblStatus.Text.Trim <> "CONNECTED" Then
            lblStatus.Text = "CONNECTED"
            lblStatus.ForeColor = Color.Green
        ElseIf Not tunnel.IsSshConnected And lblStatus.Text.Trim <> "NOT CONNECTED" Then
            lblStatus.Text = "NOT CONNECTED"
            lblStatus.ForeColor = Color.Red
            'p.Dispose()
            tmr.Enabled = False
        End If
    End Sub

    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        tmr.Enabled = False
        bw.RunWorkerAsync()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Try
            RoundtripTime(ServerAddress)
            isConnectedProperty()
        Catch ex As Exception
            isConnectedProperty()
        End Try
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If lblStatus.Text.Trim = "CONNECTED" Then tmr.Enabled = True
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        DataRead()
    End Sub

    Private Sub initGrid()
        With connGrid
            .Rows.Count = 1
            .Cols.Count = 6
            .ExtendLastCol = False
            connGrid(0, 0) = "ID"
            connGrid(0, 1) = "Code"
            connGrid(0, 2) = "Name"
            connGrid(0, 3) = "Ccy"
            connGrid(0, 4) = "Phone"
            connGrid(0, 5) = "Nationality"
            .AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Columns
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .AutoSizeCols()
        End With
    End Sub

    Private Sub DataRead()
        Dim MysqlConn As New MySqlConnection()
        Dim cmd As MySqlCommand
        Dim adp As MySqlDataAdapter
        Dim tbl As New DataTable
        MysqlConn.ConnectionString = UserConnection
        Try
            MysqlConn.Open()
            cmd = New MySqlCommand("Select * From parameter_securities_country", MysqlConn)
            adp = New MySqlDataAdapter(cmd)
            adp.Fill(tbl)
            initGrid()
            If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
                Dim query = From n In tbl.AsEnumerable
                            Select ID = n.Field(Of Integer)("CountryID"),
                                   Code = n.Field(Of String)("CountryCode"),
                                   Name = n.Field(Of String)("CountryName"),
                                   Ccy = n.Field(Of String)("Ccy"),
                                   Phone = n.Field(Of String)("PhoneCode"),
                                   Nationality = n.Field(Of String)("Nationality")
                For Each item In query
                    connGrid.Rows.Add()
                    connGrid(connGrid.Rows.Count - 1, 0) = item.ID
                    connGrid(connGrid.Rows.Count - 1, 1) = item.Code
                    connGrid(connGrid.Rows.Count - 1, 2) = item.Name
                    connGrid(connGrid.Rows.Count - 1, 3) = item.Ccy
                    connGrid(connGrid.Rows.Count - 1, 4) = item.Phone
                    connGrid(connGrid.Rows.Count - 1, 5) = item.Nationality
                Next
                connGrid.AutoSizeCols()
            End If
            MysqlConn.Close()
        Catch myerror As MySqlException
            MessageBox.Show("Cannot connect to database: " & myerror.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

End Class