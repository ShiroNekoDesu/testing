<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormForgotPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormForgotPassword))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputImage1 = New C1.Win.C1InputPanel.InputImage()
        Me.InputLabel3 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtUserEmail = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtConfirmEmail = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputSeparator1 = New C1.Win.C1InputPanel.InputSeparator()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.imgSecurity = New C1.Win.C1InputPanel.InputImage()
        Me.txtAnswer = New C1.Win.C1InputPanel.InputTextBox()
        Me.InputSeparator2 = New C1.Win.C1InputPanel.InputSeparator()
        Me.btnSubmit = New C1.Win.C1InputPanel.InputButton()
        Me.btnClose = New C1.Win.C1InputPanel.InputButton()
        Me.lblStatus = New C1.Win.C1InputPanel.InputLabel()
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
        Me.C1InputPanel1.Items.Add(Me.InputLabel3)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.txtUserEmail)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.txtConfirmEmail)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel4)
        Me.C1InputPanel1.Items.Add(Me.imgSecurity)
        Me.C1InputPanel1.Items.Add(Me.txtAnswer)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator2)
        Me.C1InputPanel1.Items.Add(Me.btnSubmit)
        Me.C1InputPanel1.Items.Add(Me.btnClose)
        Me.C1InputPanel1.Items.Add(Me.lblStatus)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(459, 272)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputImage1
        '
        Me.InputImage1.Break = C1.Win.C1InputPanel.BreakType.None
        Me.InputImage1.Height = 80
        Me.InputImage1.Image = CType(resources.GetObject("InputImage1.Image"), System.Drawing.Image)
        Me.InputImage1.Name = "InputImage1"
        Me.InputImage1.Width = 202
        '
        'InputLabel3
        '
        Me.InputLabel3.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel3.Font = New System.Drawing.Font("Comic Sans MS", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel3.Height = 73
        Me.InputLabel3.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel3.Name = "InputLabel3"
        Me.InputLabel3.Text = "mis.simpi-pro"
        Me.InputLabel3.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.InputLabel3.Width = 237
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "Email address: "
        Me.InputLabel1.Width = 96
        '
        'txtUserEmail
        '
        Me.txtUserEmail.Name = "txtUserEmail"
        Me.txtUserEmail.ToolTipText = "<i>Username</i>"
        Me.txtUserEmail.Width = 440
        '
        'InputLabel2
        '
        Me.InputLabel2.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "Confirm email address: "
        Me.InputLabel2.Width = 142
        '
        'txtConfirmEmail
        '
        Me.txtConfirmEmail.Name = "txtConfirmEmail"
        Me.txtConfirmEmail.Width = 440
        '
        'InputSeparator1
        '
        Me.InputSeparator1.Name = "InputSeparator1"
        Me.InputSeparator1.Width = 441
        '
        'InputLabel4
        '
        Me.InputLabel4.Height = 42
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "Please input security answer for this question: "
        Me.InputLabel4.Width = 182
        '
        'imgSecurity
        '
        Me.imgSecurity.Break = C1.Win.C1InputPanel.BreakType.None
        Me.imgSecurity.Height = 42
        Me.imgSecurity.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.imgSecurity.Image = CType(resources.GetObject("imgSecurity.Image"), System.Drawing.Image)
        Me.imgSecurity.ImageScaling = C1.Win.C1InputPanel.InputImageScaling.Clip
        Me.imgSecurity.Name = "imgSecurity"
        Me.imgSecurity.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.imgSecurity.Width = 200
        '
        'txtAnswer
        '
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAnswer.Width = 50
        '
        'InputSeparator2
        '
        Me.InputSeparator2.Name = "InputSeparator2"
        Me.InputSeparator2.Width = 442
        '
        'btnSubmit
        '
        Me.btnSubmit.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSubmit.Height = 35
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.Width = 100
        '
        'btnClose
        '
        Me.btnClose.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnClose.Height = 35
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Text = "CANCEL"
        Me.btnClose.Width = 100
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.HorizontalAlign = C1.Win.C1InputPanel.InputContentAlignment.Center
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Text = "NOT CONNECTED"
        Me.lblStatus.Width = 232
        '
        'FormForgotPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormForgotPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORGOT PASSWORD. Please wait until it's connected !"
        Me.TopMost = True
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtUserEmail As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtConfirmEmail As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents btnSubmit As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnClose As C1.Win.C1InputPanel.InputButton
    Friend WithEvents InputImage1 As C1.Win.C1InputPanel.InputImage
    Friend WithEvents InputLabel3 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputSeparator1 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgSecurity As C1.Win.C1InputPanel.InputImage
    Friend WithEvents txtAnswer As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents InputSeparator2 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents lblStatus As C1.Win.C1InputPanel.InputLabel
End Class
