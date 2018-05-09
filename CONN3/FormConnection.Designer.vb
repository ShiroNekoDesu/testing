<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConnection
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' Please pick the evaluation license key from <SecureBlackbox>\LicenseKey.txt file and place it into the SetLicenseKey call below. 
        ' If the evaluation key expires, you can request an extension using the form at http://www.secureblackbox.com/order/keyreq/
        SBUtils.Unit.SetLicenseKey("4C30F9211C713C055967A0CC3F008788A8347381022E372DF456940FB2506C07FBC5308E6C4DFD11EAFB41723986499280CA638CD3C7EF542FD2E3C74D9F282D58165EA1187E7671135C4A306DFD9FC8C7C5BCC179F0676724CC46A4B82F403D9FA4C2EBE158B80A577633E301CE92414542256C66A166F5D2DE0364B69FDEAD4448944BE3CF9F66EF345BA0E6750FDE75290521B8E4DE38725E59772877747C9CDC0AF20420C2092AC082AC903F98E3277D08A40821306368B92F2C87FD116CDBB90531BFF0EC66C62CD786C3ECE946C1AB498883DAA2BC3E2C773FE861447A1107D49463CBF4B03C2C54294CA8EC4D6F5C93EC1DBF081C8B4C37551C0C3056")
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TElDNSSettings1 As SBSocket.TElDNSSettings = New SBSocket.TElDNSSettings()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConnection))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblServer = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPort = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtUser = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtPassword = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.chkProxy = New C1.Win.C1InputPanel.InputCheckBox()
        Me.InputGroupHeader2 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyServer = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyPort = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyUser = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel10 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyPassword = New C1.Win.C1InputPanel.InputTextBox()
        Me.btnRead = New C1.Win.C1InputPanel.InputButton()
        Me.connGrid = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.chTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEvent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConnections = New System.Windows.Forms.ListView()
        Me.chHost = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chInSocket = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chOutSocket = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chInChannel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chOutChannel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chSocketState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chChannelState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.forwarding = New SBSSHForwarding.TElSSHLocalPortForwarding()
        Me.imgLog = New System.Windows.Forms.ImageList(Me.components)
        Me.imgConns = New System.Windows.Forms.ImageList(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.connGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.lblServer)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.lblPort)
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.txtUser)
        Me.C1InputPanel1.Items.Add(Me.InputLabel4)
        Me.C1InputPanel1.Items.Add(Me.txtPassword)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.InputLabel6)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.chkProxy)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader2)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.txtProxyServer)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.txtProxyPort)
        Me.C1InputPanel1.Items.Add(Me.InputLabel9)
        Me.C1InputPanel1.Items.Add(Me.txtProxyUser)
        Me.C1InputPanel1.Items.Add(Me.InputLabel10)
        Me.C1InputPanel1.Items.Add(Me.txtProxyPassword)
        Me.C1InputPanel1.Items.Add(Me.btnRead)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(1071, 157)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "Server: "
        '
        'lblServer
        '
        Me.lblServer.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Text = "103.253.107.55"
        Me.lblServer.Width = 100
        '
        'InputLabel2
        '
        Me.InputLabel2.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Port: "
        '
        'lblPort
        '
        Me.lblPort.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Text = "22"
        Me.lblPort.Width = 100
        '
        'InputLabel3
        '
        Me.InputLabel3.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "User: "
        '
        'txtUser
        '
        Me.txtUser.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtUser.Enabled = False
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtUser.Text = "root"
        '
        'InputLabel4
        '
        Me.InputLabel4.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "Password: "
        '
        'txtPassword
        '
        Me.txtPassword.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtPassword.Enabled = False
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtPassword.Text = "4cXY3hrTBva1"
        '
        'InputLabel5
        '
        Me.InputLabel5.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Forwarded Port"
        '
        'InputLabel6
        '
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "3306"
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "PROXY SERVER"
        '
        'chkProxy
        '
        Me.chkProxy.Name = "chkProxy"
        Me.chkProxy.Text = "Use Sock5 Proxy"
        '
        'InputGroupHeader2
        '
        Me.InputGroupHeader2.Height = 1
        Me.InputGroupHeader2.Name = "InputGroupHeader2"
        '
        'InputLabel7
        '
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "Proxy Server: "
        Me.InputLabel7.Width = 75
        '
        'txtProxyServer
        '
        Me.txtProxyServer.Name = "txtProxyServer"
        '
        'InputLabel8
        '
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Port:"
        Me.InputLabel8.Width = 75
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtProxyPort.Name = "txtProxyPort"
        '
        'InputLabel9
        '
        Me.InputLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel9.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "User: "
        Me.InputLabel9.Width = 60
        '
        'txtProxyUser
        '
        Me.txtProxyUser.Name = "txtProxyUser"
        Me.txtProxyUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        '
        'InputLabel10
        '
        Me.InputLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel10.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.InputLabel10.Name = "InputLabel10"
        Me.InputLabel10.Text = "Password: "
        Me.InputLabel10.Width = 60
        '
        'txtProxyPassword
        '
        Me.txtProxyPassword.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtProxyPassword.Name = "txtProxyPassword"
        Me.txtProxyPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        '
        'btnRead
        '
        Me.btnRead.Enabled = False
        Me.btnRead.Height = 50
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Text = "READ"
        Me.btnRead.Width = 100
        '
        'connGrid
        '
        Me.connGrid.ColumnInfo = "5,1,0,0,0,95,Columns:1{Caption:""No"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Caption:""Code"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Caption:""Description"";" &
    "}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Caption:""ID"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.connGrid.Dock = System.Windows.Forms.DockStyle.Left
        Me.connGrid.Location = New System.Drawing.Point(0, 157)
        Me.connGrid.Name = "connGrid"
        Me.connGrid.Rows.Count = 1
        Me.connGrid.Rows.DefaultSize = 19
        Me.connGrid.Size = New System.Drawing.Size(425, 302)
        Me.connGrid.TabIndex = 2
        '
        'lvLog
        '
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTime, Me.chEvent})
        Me.lvLog.Dock = System.Windows.Forms.DockStyle.Top
        Me.lvLog.FullRowSelect = True
        Me.lvLog.Location = New System.Drawing.Point(425, 157)
        Me.lvLog.MultiSelect = False
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(646, 150)
        Me.lvLog.TabIndex = 3
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'chTime
        '
        Me.chTime.Text = "Time"
        Me.chTime.Width = 111
        '
        'chEvent
        '
        Me.chEvent.Text = "Event"
        Me.chEvent.Width = 422
        '
        'lvConnections
        '
        Me.lvConnections.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chHost, Me.chInSocket, Me.chOutSocket, Me.chInChannel, Me.chOutChannel, Me.chSocketState, Me.chChannelState})
        Me.lvConnections.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvConnections.FullRowSelect = True
        Me.lvConnections.Location = New System.Drawing.Point(425, 307)
        Me.lvConnections.MultiSelect = False
        Me.lvConnections.Name = "lvConnections"
        Me.lvConnections.Size = New System.Drawing.Size(646, 152)
        Me.lvConnections.TabIndex = 4
        Me.lvConnections.UseCompatibleStateImageBehavior = False
        Me.lvConnections.View = System.Windows.Forms.View.Details
        '
        'chHost
        '
        Me.chHost.Text = "Host"
        Me.chHost.Width = 98
        '
        'chInSocket
        '
        Me.chInSocket.Text = "Incoming (socket)"
        Me.chInSocket.Width = 85
        '
        'chOutSocket
        '
        Me.chOutSocket.Text = "Outgoing (socket)"
        Me.chOutSocket.Width = 84
        '
        'chInChannel
        '
        Me.chInChannel.Text = "Incoming (channel)"
        Me.chInChannel.Width = 90
        '
        'chOutChannel
        '
        Me.chOutChannel.Text = "Outgoing (channel)"
        Me.chOutChannel.Width = 89
        '
        'chSocketState
        '
        Me.chSocketState.Text = "Socket state"
        Me.chSocketState.Width = 70
        '
        'chChannelState
        '
        Me.chChannelState.Text = "Channel state"
        Me.chChannelState.Width = 76
        '
        'forwarding
        '
        Me.forwarding.Address = Nothing
        Me.forwarding.AuthAttempts = 1
        Me.forwarding.AuthenticationTypes = 4
        Me.forwarding.AutoAdjustCiphers = False
        Me.forwarding.AutoAdjustPriority = True
        Me.forwarding.CertAuthMode = SBSSHClient.TSBSSHCertAuthMode.camAuto
        Me.forwarding.ClientHostname = Nothing
        Me.forwarding.ClientUsername = Nothing
        Me.forwarding.CloseIfNoActiveTunnels = True
        Me.forwarding.CompressionLevel = 0
        Me.forwarding.CryptoProviderManager = Nothing
        Me.forwarding.DefaultWindowSize = 2048000
        Me.forwarding.DestHost = Nothing
        Me.forwarding.DestPort = 0
        TElDNSSettings1.AllowStatuses = CType(11, Byte)
        TElDNSSettings1.Port = CType(53US, UShort)
        Me.forwarding.DNS = TElDNSSettings1
        Me.forwarding.EstablishShellChannel = False
        Me.forwarding.FlushCachedDataOnClose = True
        Me.forwarding.ForceCompression = False
        Me.forwarding.ForwardedHost = ""
        Me.forwarding.ForwardedPort = 0
        Me.forwarding.ForwardedUseIPv6 = False
        Me.forwarding.GlobalKeepAlivePeriod = 0
        Me.forwarding.GSSDelegateCredentials = False
        Me.forwarding.GSSHostName = ""
        Me.forwarding.GSSMechanism = Nothing
        Me.forwarding.InactivityPeriod = 0
        Me.forwarding.IncomingSpeedLimit = 0
        Me.forwarding.Intercept = Nothing
        Me.forwarding.KeepAlivePeriod = 0
        Me.forwarding.KeyStorage = Nothing
        Me.forwarding.MaxCacheSize = 1048576
        Me.forwarding.MaxSSHPacketSize = 262144
        Me.forwarding.MinWindowSize = 2048
        Me.forwarding.ObfuscateHandshake = False
        Me.forwarding.ObfuscationPassword = ""
        Me.forwarding.OutgoingSpeedLimit = 0
        Me.forwarding.Password = Nothing
        Me.forwarding.Port = 0
        Me.forwarding.PortKnock = Nothing
        Me.forwarding.Priority = SBSSHForwarding.TSBSSHForwardingPriority.sfpNormal
        Me.forwarding.ReportRealClientLocationToServer = False
        Me.forwarding.RequestPasswordChange = False
        Me.forwarding.ResolveDynamicForwardingAddresses = False
        Me.forwarding.SessionTimeout = 0
        Me.forwarding.SocketReadBufSize = 524288
        Me.forwarding.SocketTimeout = 0
        Me.forwarding.SocketWriteBufSize = 524288
        Me.forwarding.SocksAuthentication = 0
        Me.forwarding.SocksPassword = Nothing
        Me.forwarding.SocksPort = 0
        Me.forwarding.SocksResolveAddress = False
        Me.forwarding.SocksServer = Nothing
        Me.forwarding.SocksUseIPv6 = False
        Me.forwarding.SocksUserCode = Nothing
        Me.forwarding.SocksVersion = 0
        Me.forwarding.SoftwareName = "SSHBlackbox.8"
        Me.forwarding.SSHAuthOrder = SBSSHCommon.TSBSSHAuthOrder.aoDefault
        Me.forwarding.SynchronizeGUI = True
        Me.forwarding.TrustedKeys = Nothing
        Me.forwarding.UseDynamicForwarding = False
        Me.forwarding.UseIPv6 = False
        Me.forwarding.Username = Nothing
        Me.forwarding.UseSocks = False
        Me.forwarding.UseUTF8 = False
        Me.forwarding.UseWebTunneling = False
        Me.forwarding.Versions = CType(2, Short)
        Me.forwarding.WebTunnelAddress = Nothing
        Me.forwarding.WebTunnelAuthentication = 0
        Me.forwarding.WebTunnelPassword = Nothing
        Me.forwarding.WebTunnelPort = 0
        Me.forwarding.WebTunnelUserId = Nothing
        '
        'imgLog
        '
        Me.imgLog.ImageStream = CType(resources.GetObject("imgLog.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLog.TransparentColor = System.Drawing.Color.Yellow
        Me.imgLog.Images.SetKeyName(0, "")
        Me.imgLog.Images.SetKeyName(1, "")
        '
        'imgConns
        '
        Me.imgConns.ImageStream = CType(resources.GetObject("imgConns.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgConns.TransparentColor = System.Drawing.Color.Yellow
        Me.imgConns.Images.SetKeyName(0, "")
        Me.imgConns.Images.SetKeyName(1, "")
        Me.imgConns.Images.SetKeyName(2, "")
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(480, 96)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(96, 55)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'FormConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 459)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lvConnections)
        Me.Controls.Add(Me.lvLog)
        Me.Controls.Add(Me.connGrid)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Name = "FormConnection"
        Me.Text = "CONNECTION: Eldos SecureBox"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.connGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents connGrid As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblServer As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblPort As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents chkProxy As C1.Win.C1InputPanel.InputCheckBox
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyServer As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyPort As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyUser As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel10 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyPassword As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents btnRead As C1.Win.C1InputPanel.InputButton
    Friend WithEvents txtUser As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents txtPassword As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents lvLog As ListView
    Friend WithEvents chTime As ColumnHeader
    Friend WithEvents chEvent As ColumnHeader
    Friend WithEvents lvConnections As ListView
    Friend WithEvents chHost As ColumnHeader
    Friend WithEvents chInSocket As ColumnHeader
    Friend WithEvents chOutSocket As ColumnHeader
    Friend WithEvents chInChannel As ColumnHeader
    Friend WithEvents chOutChannel As ColumnHeader
    Friend WithEvents chSocketState As ColumnHeader
    Friend WithEvents chChannelState As ColumnHeader
    Friend WithEvents forwarding As SBSSHForwarding.TElSSHLocalPortForwarding
    Friend WithEvents imgLog As ImageList
    Friend WithEvents imgConns As ImageList
    Friend WithEvents btnStart As Button
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
End Class
