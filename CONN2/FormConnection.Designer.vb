<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConnection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblServer = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblPort = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtUser = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtPassword = New C1.Win.C1InputPanel.InputTextBox()
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
        Me.InputLabel11 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblStatus = New C1.Win.C1InputPanel.InputLabel()
        Me.btnConnect = New C1.Win.C1InputPanel.InputButton()
        Me.btnRead = New C1.Win.C1InputPanel.InputButton()
        Me.connGrid = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.fgStatus = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel13 = New C1.Win.C1InputPanel.InputLabel()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.connGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgStatus, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1InputPanel1.Items.Add(Me.InputLabel12)
        Me.C1InputPanel1.Items.Add(Me.InputLabel13)
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
        Me.C1InputPanel1.Items.Add(Me.InputLabel11)
        Me.C1InputPanel1.Items.Add(Me.lblStatus)
        Me.C1InputPanel1.Items.Add(Me.btnConnect)
        Me.C1InputPanel1.Items.Add(Me.btnRead)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(759, 157)
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
        '
        'InputLabel11
        '
        Me.InputLabel11.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel11.Name = "InputLabel11"
        Me.InputLabel11.Text = "Connection Status"
        '
        'lblStatus
        '
        Me.lblStatus.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Text = "NOT CONNECTED"
        Me.lblStatus.Width = 151
        '
        'btnConnect
        '
        Me.btnConnect.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.btnConnect.Height = 50
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Text = "CONNECT"
        Me.btnConnect.Width = 100
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
        Me.connGrid.Size = New System.Drawing.Size(493, 287)
        Me.connGrid.TabIndex = 2
        '
        'tmr
        '
        Me.tmr.Interval = 1000
        '
        'bw
        '
        '
        'fgStatus
        '
        Me.fgStatus.ColumnInfo = "5,1,0,0,0,95,Columns:1{Caption:""No"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Caption:""Code"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Caption:""Description"";" &
    "}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Caption:""ID"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.fgStatus.Location = New System.Drawing.Point(493, 157)
        Me.fgStatus.Name = "fgStatus"
        Me.fgStatus.Rows.Count = 1
        Me.fgStatus.Rows.DefaultSize = 19
        Me.fgStatus.Size = New System.Drawing.Size(266, 287)
        Me.fgStatus.TabIndex = 3
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
        Me.InputLabel6.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "3306"
        '
        'InputLabel12
        '
        Me.InputLabel12.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel12.Name = "InputLabel12"
        Me.InputLabel12.Text = "Listen Port"
        '
        'InputLabel13
        '
        Me.InputLabel13.Name = "InputLabel13"
        Me.InputLabel13.Text = "3316"
        '
        'FormConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 444)
        Me.Controls.Add(Me.fgStatus)
        Me.Controls.Add(Me.connGrid)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Name = "FormConnection"
        Me.Text = "CONNECTION: Chilkat .Net Assemblies 4.5 Framework"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.connGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgStatus, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnConnect As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnRead As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel11 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblStatus As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtUser As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents txtPassword As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputGroupHeader2 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents tmr As Timer
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents fgStatus As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel13 As C1.Win.C1InputPanel.InputLabel
End Class
