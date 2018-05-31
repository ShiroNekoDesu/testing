<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputImage1 = New C1.Win.C1InputPanel.InputImage()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtUserLogin = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtPassword = New C1.Win.C1InputPanel.InputTextBox()
        Me.cmdSubmit = New C1.Win.C1InputPanel.InputButton()
        Me.cmdClose = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputSeparator1 = New C1.Win.C1InputPanel.InputSeparator()
        Me.btnForgotPassword = New C1.Win.C1InputPanel.InputButton()
        Me.btnNetwork = New C1.Win.C1InputPanel.InputButton()
        Me.InputSeparator3 = New C1.Win.C1InputPanel.InputSeparator()
        Me.btnFolder = New C1.Win.C1InputPanel.InputButton()
        Me.btnPing = New C1.Win.C1InputPanel.InputButton()
        Me.InputSeparator4 = New C1.Win.C1InputPanel.InputSeparator()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtTerminalID = New C1.Win.C1InputPanel.InputTextBox()
        Me.ighProxy = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.chkProxy = New C1.Win.C1InputPanel.InputCheckBox()
        Me.btnSave = New C1.Win.C1InputPanel.InputButton()
        Me.InputLabel5 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyHost = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyUser = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyPort = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtProxyPassword = New C1.Win.C1InputPanel.InputTextBox()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BackColor = System.Drawing.Color.White
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputImage1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.txtUserLogin)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.txtPassword)
        Me.C1InputPanel1.Items.Add(Me.cmdSubmit)
        Me.C1InputPanel1.Items.Add(Me.cmdClose)
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator1)
        Me.C1InputPanel1.Items.Add(Me.btnForgotPassword)
        Me.C1InputPanel1.Items.Add(Me.btnNetwork)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator3)
        Me.C1InputPanel1.Items.Add(Me.btnFolder)
        Me.C1InputPanel1.Items.Add(Me.btnPing)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator4)
        Me.C1InputPanel1.Items.Add(Me.InputLabel4)
        Me.C1InputPanel1.Items.Add(Me.txtTerminalID)
        Me.C1InputPanel1.Items.Add(Me.ighProxy)
        Me.C1InputPanel1.Items.Add(Me.chkProxy)
        Me.C1InputPanel1.Items.Add(Me.btnSave)
        Me.C1InputPanel1.Items.Add(Me.InputLabel5)
        Me.C1InputPanel1.Items.Add(Me.txtProxyHost)
        Me.C1InputPanel1.Items.Add(Me.InputLabel6)
        Me.C1InputPanel1.Items.Add(Me.txtProxyUser)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.txtProxyPort)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.txtProxyPassword)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(484, 237)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputImage1
        '
        Me.InputImage1.Height = 80
        Me.InputImage1.Image = CType(resources.GetObject("InputImage1.Image"), System.Drawing.Image)
        Me.InputImage1.Name = "InputImage1"
        Me.InputImage1.Width = 202
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "User: "
        Me.InputLabel1.Width = 55
        '
        'txtUserLogin
        '
        Me.txtUserLogin.Name = "txtUserLogin"
        Me.txtUserLogin.ToolTipText = "<i>Username</i>"
        Me.txtUserLogin.Width = 202
        '
        'InputLabel2
        '
        Me.InputLabel2.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Password: "
        Me.InputLabel2.Width = 55
        '
        'txtPassword
        '
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Width = 202
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Break = C1.Win.C1InputPanel.BreakType.None
        Me.cmdSubmit.Height = 35
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Text = "SIGN-IN"
        Me.cmdSubmit.Width = 100
        '
        'cmdClose
        '
        Me.cmdClose.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.cmdClose.Height = 35
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Text = "CLOSE"
        Me.cmdClose.Width = 100
        '
        'InputLabel3
        '
        Me.InputLabel3.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel3.Font = New System.Drawing.Font("Comic Sans MS", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Height = 77
        Me.InputLabel3.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "mis.simpi-pro"
        Me.InputLabel3.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel3.Width = 250
        '
        'InputSeparator1
        '
        Me.InputSeparator1.Name = "InputSeparator1"
        Me.InputSeparator1.Width = 250
        '
        'btnForgotPassword
        '
        Me.btnForgotPassword.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnForgotPassword.Enabled = False
        Me.btnForgotPassword.Height = 35
        Me.btnForgotPassword.Name = "btnForgotPassword"
        Me.btnForgotPassword.Text = "FORGOT PASSWORD"
        Me.btnForgotPassword.Width = 122
        '
        'btnNetwork
        '
        Me.btnNetwork.Height = 35
        Me.btnNetwork.Name = "btnNetwork"
        Me.btnNetwork.Text = "TERMINAL LIST"
        Me.btnNetwork.Width = 122
        '
        'InputSeparator3
        '
        Me.InputSeparator3.Name = "InputSeparator3"
        Me.InputSeparator3.Width = 246
        '
        'btnFolder
        '
        Me.btnFolder.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnFolder.Height = 35
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Text = "APPS. FOLDER"
        Me.btnFolder.Width = 122
        '
        'btnPing
        '
        Me.btnPing.Height = 35
        Me.btnPing.Name = "btnPing"
        Me.btnPing.Text = "CONNECTION SPEED"
        Me.btnPing.Width = 122
        '
        'InputSeparator4
        '
        Me.InputSeparator4.Name = "InputSeparator4"
        Me.InputSeparator4.Width = 246
        '
        'InputLabel4
        '
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "TerminalID: "
        '
        'txtTerminalID
        '
        Me.txtTerminalID.Name = "txtTerminalID"
        Me.txtTerminalID.ReadOnly = True
        Me.txtTerminalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTerminalID.Width = 178
        '
        'ighProxy
        '
        Me.ighProxy.Collapsed = True
        Me.ighProxy.Collapsible = True
        Me.ighProxy.Name = "ighProxy"
        Me.ighProxy.Text = "IN/OUT OFFICE SETTING"
        '
        'chkProxy
        '
        Me.chkProxy.Break = C1.Win.C1InputPanel.BreakType.None
        Me.chkProxy.Height = 44
        Me.chkProxy.Name = "chkProxy"
        Me.chkProxy.Text = "Connect through office secure connection"
        Me.chkProxy.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Far
        Me.chkProxy.Width = 339
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Height = 35
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "OFFICE SETTING"
        Me.btnSave.Width = 120
        '
        'InputLabel5
        '
        Me.InputLabel5.Name = "InputLabel5"
        Me.InputLabel5.Text = "Proxy Host: "
        Me.InputLabel5.Width = 65
        '
        'txtProxyHost
        '
        Me.txtProxyHost.Break = C1.Win.C1InputPanel.BreakType.None
        Me.txtProxyHost.Name = "txtProxyHost"
        Me.txtProxyHost.Width = 150
        '
        'InputLabel6
        '
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "Username:"
        Me.InputLabel6.Width = 65
        '
        'txtProxyUser
        '
        Me.txtProxyUser.Name = "txtProxyUser"
        Me.txtProxyUser.Width = 170
        '
        'InputLabel7
        '
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "Proxy Port: "
        Me.InputLabel7.Width = 65
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Break = C1.Win.C1InputPanel.BreakType.None
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.txtProxyPort.Width = 150
        '
        'InputLabel8
        '
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "Password: "
        Me.InputLabel8.Width = 65
        '
        'txtProxyPassword
        '
        Me.txtProxyPassword.Name = "txtProxyPassword"
        Me.txtProxyPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtProxyPassword.Width = 170
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOG-ON"
        Me.TopMost = True
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtUserLogin As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtPassword As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents cmdSubmit As C1.Win.C1InputPanel.InputButton
    Friend WithEvents cmdClose As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputImage1 As C1.Win.C1InputPanel.InputImage
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents btnForgotPassword As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputSeparator1 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents InputSeparator3 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtTerminalID As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents btnFolder As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputSeparator4 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents btnPing As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnNetwork As C1.Win.C1InputPanel.InputButton
    Friend WithEvents ighProxy As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents chkProxy As C1.Win.C1InputPanel.InputCheckBox
    Friend WithEvents btnSave As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputLabel5 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyHost As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyUser As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyPort As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtProxyPassword As C1.Win.C1InputPanel.InputTextBox
End Class
