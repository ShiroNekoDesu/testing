Imports SBSSHForwarding
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

    Delegate Sub LogFunc(ByVal s As String, ByVal err As Boolean)
    Private Sub Log(ByVal s As String, ByVal err As Boolean)
        If lvLog.InvokeRequired Then
            Dim d As LogFunc = CType(AddressOf Log, LogFunc)
            Me.Invoke(d, New Object() {s, err})
        Else
            Dim lvi As ListViewItem = New ListViewItem
            lvi.Text = DateTime.Now.ToShortTimeString()
            lvi.SubItems.Add(s)
            If (err) Then
                lvi.ImageIndex = 1
            Else
                lvi.ImageIndex = 0
            End If
            lvLog.Items.Add(lvi)
        End If
    End Sub

    Delegate Sub SetButtonStartTextFunc(ByVal S As String)
    Private Sub SetButtonStartText(ByVal S As String)
        If btnStart.InvokeRequired Then
            Dim d As SetButtonStartTextFunc = CType(AddressOf SetButtonStartText, SetButtonStartTextFunc)
            Me.Invoke(d, New Object() {S})
        Else
            btnStart.Text = S
        End If
    End Sub

    Delegate Sub RefreshConnectionFunc(ByVal Conn As TElSSHForwardedConnection)
    Private Sub RefreshConnection(ByVal Conn As TElSSHForwardedConnection)
        If (lvConnections.InvokeRequired) Then
            Dim d As RefreshConnectionFunc = CType(AddressOf RefreshConnection, RefreshConnectionFunc)
            Me.Invoke(d, New Object() {Conn})
        Else
            Dim S As String = ""
            Dim lvi As ListViewItem = CType(Conn.Data, ListViewItem)
            lvi.SubItems.Clear()
            If (Not (Conn.Socket Is Nothing)) Then
                lvi.Text = Conn.Socket.Address
            Else
                lvi.Text = "N/A"
            End If
            lvi.SubItems.Add(Conn.ReceivedFromSocket.ToString())
            lvi.SubItems.Add(Conn.SentToSocket.ToString())
            lvi.SubItems.Add(Conn.ReceivedFromChannel.ToString())
            lvi.SubItems.Add(Conn.SentToChannel.ToString())
            If Conn.SocketState = TSBSSHForwardingSocketState.fssEstablishing Then
                S = "Establishing"
            ElseIf Conn.SocketState = TSBSSHForwardingSocketState.fssActive Then
                S = "Active"
            ElseIf Conn.SocketState = TSBSSHForwardingSocketState.fssClosing Then
                S = "Closing"
            Else
                S = "Closed"
            End If
            lvi.SubItems.Add(S)
            If Conn.ChannelState = TSBSSHForwardingChannelState.fcsEstablishing Then
                S = "Establishing"
            ElseIf Conn.ChannelState = TSBSSHForwardingChannelState.fcsActive Then
                S = "Active"
            ElseIf Conn.ChannelState = TSBSSHForwardingChannelState.fcsClosing Then
                S = "Closing"
            Else
                S = "Closed"
            End If
            lvi.SubItems.Add(S)
            If ((Conn.ChannelState = TSBSSHForwardingChannelState.fcsActive) AndAlso (Conn.SocketState = TSBSSHForwardingSocketState.fssActive)) Then
                lvi.ImageIndex = 1
            ElseIf ((Conn.ChannelState = TSBSSHForwardingChannelState.fcsEstablishing) Or (Conn.SocketState = TSBSSHForwardingSocketState.fssEstablishing)) Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 2
            End If
        End If
    End Sub

    Delegate Sub AddConnectionFunc(ByVal Conn As TElSSHForwardedConnection)
    Private Sub AddConnection(ByVal Conn As TElSSHForwardedConnection)
        If (lvConnections.InvokeRequired) Then
            Dim d As AddConnectionFunc = CType(AddressOf AddConnection, AddConnectionFunc)
            Me.Invoke(d, New Object() {Conn})
        Else
            Dim lvi As ListViewItem = New ListViewItem
            lvi.Tag = Conn
            Conn.Data = lvi
            lvConnections.Items.Add(lvi)
            RefreshConnection(Conn)
        End If
    End Sub

    Delegate Sub RemoveConnectionFunc(ByVal Conn As TElSSHForwardedConnection)
    Private Sub RemoveConnection(ByVal Conn As TElSSHForwardedConnection)
        If (lvConnections.InvokeRequired) Then
            Dim d As RemoveConnectionFunc = CType(AddressOf RemoveConnection, RemoveConnectionFunc)
            Me.Invoke(d, New Object() {Conn})
        Else
            Dim lvi As ListViewItem = CType(Conn.Data, ListViewItem)
            lvConnections.Items.Remove(lvi)
        End If
    End Sub

    Private Sub forwarding_OnAuthenticationFailed(ByVal Sender As Object, ByVal AuthenticationType As Integer) Handles forwarding.OnAuthenticationFailed
        Log("Authentication" & AuthenticationType.ToString() & " failed", True)
    End Sub

    Private Sub forwarding_OnAuthenticationSuccess(ByVal Sender As Object) Handles forwarding.OnAuthenticationSuccess
        Log("Authentication succeeded", False)
    End Sub

    Private Sub forwarding_OnClose(ByVal Sender As Object) Handles forwarding.OnClose
        Log("SSH session closed", False)
        SetButtonStartText("START")
    End Sub

    Private Sub forwarding_OnConnectionChange(ByVal Sender As Object, ByVal Conn As SBSSHForwarding.TElSSHForwardedConnection) Handles forwarding.OnConnectionChange
        RefreshConnection(Conn)
    End Sub

    Private Sub forwarding_OnConnectionClose(ByVal Sender As Object, ByVal Conn As SBSSHForwarding.TElSSHForwardedConnection) Handles forwarding.OnConnectionClose
        Log("Secure channel closed", False)
        RemoveConnection(Conn)
    End Sub

    Private Sub forwarding_OnConnectionError(ByVal Sender As Object, ByVal Conn As SBSSHForwarding.TElSSHForwardedConnection, ByVal ErrorCode As Integer) Handles forwarding.OnConnectionError
        Log("Secure channel error " & ErrorCode.ToString(), True)
    End Sub

    Private Sub forwarding_OnConnectionOpen(ByVal Sender As Object, ByVal Conn As SBSSHForwarding.TElSSHForwardedConnection) Handles forwarding.OnConnectionOpen
        Log("Secure channel opened", False)
        AddConnection(Conn)
    End Sub

    Private Sub forwarding_OnError(ByVal Sender As Object, ByVal ErrorCode As Integer) Handles forwarding.OnError
        Log("SSH error " & ErrorCode.ToString(), True)
    End Sub

    Private Sub forwarding_OnKeyValidate(ByVal Sender As Object, ByVal ServerKey As SBSSHKeyStorage.TElSSHKey, ByRef Validate As Boolean) Handles forwarding.OnKeyValidate
        Dim S As String = SBUtils.Unit.DigestToStr128(ServerKey.FingerprintMD5, True)
        Log("Server key received [" & S & "]", False)
        Validate = True
    End Sub

    Private Sub forwarding_OnOpen(ByVal Sender As Object) Handles forwarding.OnOpen
        Log("SSH session started", False)
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If Not forwarding.Active Then
            forwarding.Address = ServerAddress
            forwarding.Port = ServerPort
            forwarding.ForwardedHost = ""
            forwarding.ForwardedPort = 0
            forwarding.DestHost = DatabaseServer
            forwarding.DestPort = ServerDestinationPort
            forwarding.Username = ServerUser
            forwarding.Password = ServerPassword
            If chkProxy.Checked Then
                forwarding.UseSocks = True
                forwarding.SocksServer = txtProxyServer.Text.Trim
                forwarding.SocksVersion = 1
                forwarding.SocksPort = txtProxyPort.Text.Trim
                forwarding.SocksUserCode = txtProxyUser.Text.Trim
                forwarding.SocksPassword = txtProxyPassword.Text.Trim
            End If
            Try
                forwarding.Open()
                SetButtonStartText("STOP")
                btnRead.Enabled = True
            Catch Ex As Exception
                Log("Connection failed due to exception: " + Ex.Message, True)
                Log("If you have ensured that all connection parameters are correct and you still can't connect,", True)
                Log("please contact EldoS support via HelpDesk on http://sbb.eldos.com/helpdesk/", True)
                Log("Remember to provide details about the error that happened.", True)
                If forwarding.ServerSoftwareName.Length > 0 Then
                    Log("Server software identified itself as: " + forwarding.ServerSoftwareName, True)
                End If
            End Try
        Else
            forwarding.Close()
        End If
    End Sub

    Private Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If (forwarding.Active) Then
            forwarding.Close()
        End If
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
        UserConnection = "Server=" & DatabaseServer & ";Port=" & ServerDestinationPort & ";Database=" & DatabaseName & ";uid=" & DatabaseUser
        If DatabasePassword.Trim = "" Then UserConnection &= ";Pwd=''" Else UserConnection &= ";Pwd=" & DatabasePassword
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