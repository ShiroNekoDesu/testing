<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMyClient
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMyClient))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.csMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AttachToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.txtKeyword = New C1.Win.C1InputPanel.InputTextBox()
        Me.btnSearch = New C1.Win.C1InputPanel.InputButton()
        Me.DBGClient = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1InputPanel2 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.btnProfile = New C1.Win.C1InputPanel.InputButton()
        Me.btnRisk = New C1.Win.C1InputPanel.InputButton()
        Me.btnSubscription = New C1.Win.C1InputPanel.InputButton()
        Me.btnRedemption = New C1.Win.C1InputPanel.InputButton()
        Me.btnMyUnitholder = New C1.Win.C1InputPanel.InputButton()
        Me.btnClientSheet = New C1.Win.C1InputPanel.InputButton()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.csMenu.SuspendLayout()
        CType(Me.DBGClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.ContextMenuStrip = Me.csMenu
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.txtKeyword)
        Me.C1InputPanel1.Items.Add(Me.btnSearch)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(889, 50)
        Me.C1InputPanel1.TabIndex = 0
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'csMenu
        '
        Me.csMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AttachToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.csMenu.Name = "csMenu"
        Me.csMenu.Size = New System.Drawing.Size(112, 70)
        '
        'AttachToolStripMenuItem
        '
        Me.AttachToolStripMenuItem.Name = "AttachToolStripMenuItem"
        Me.AttachToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.AttachToolStripMenuItem.Text = "Detach"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "Keyword, that simillar with client name"
        '
        'txtKeyword
        '
        Me.txtKeyword.Break = C1.Win.C1InputPanel.BreakType.Column
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Width = 760
        '
        'btnSearch
        '
        Me.btnSearch.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSearch.Height = 40
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.Width = 100
        '
        'DBGClient
        '
        Me.DBGClient.BackColor = System.Drawing.Color.White
        Me.DBGClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DBGClient.ContextMenuStrip = Me.csMenu
        Me.DBGClient.Dock = System.Windows.Forms.DockStyle.Top
        Me.DBGClient.GroupByCaption = "Drag a column header here to group by that column"
        Me.DBGClient.Images.Add(CType(resources.GetObject("DBGClient.Images"), System.Drawing.Image))
        Me.DBGClient.Location = New System.Drawing.Point(0, 50)
        Me.DBGClient.Name = "DBGClient"
        Me.DBGClient.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.DBGClient.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.DBGClient.PreviewInfo.ZoomFactor = 75.0R
        Me.DBGClient.PrintInfo.PageSettings = CType(resources.GetObject("DBGClient.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.DBGClient.PropBag = resources.GetString("DBGClient.PropBag")
        Me.DBGClient.RecordSelectors = False
        Me.DBGClient.RowHeight = 35
        Me.DBGClient.Size = New System.Drawing.Size(889, 359)
        Me.DBGClient.TabIndex = 4
        Me.DBGClient.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2010Blue
        '
        'C1InputPanel2
        '
        Me.C1InputPanel2.BorderThickness = 1
        Me.C1InputPanel2.ContextMenuStrip = Me.csMenu
        Me.C1InputPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel2.Items.Add(Me.btnProfile)
        Me.C1InputPanel2.Items.Add(Me.btnRisk)
        Me.C1InputPanel2.Items.Add(Me.btnSubscription)
        Me.C1InputPanel2.Items.Add(Me.btnRedemption)
        Me.C1InputPanel2.Items.Add(Me.btnMyUnitholder)
        Me.C1InputPanel2.Items.Add(Me.btnClientSheet)
        Me.C1InputPanel2.Location = New System.Drawing.Point(0, 409)
        Me.C1InputPanel2.Name = "C1InputPanel2"
        Me.C1InputPanel2.Size = New System.Drawing.Size(889, 49)
        Me.C1InputPanel2.TabIndex = 5
        Me.C1InputPanel2.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'btnProfile
        '
        Me.btnProfile.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnProfile.Height = 40
        Me.btnProfile.Image = CType(resources.GetObject("btnProfile.Image"), System.Drawing.Image)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Text = "PROFILE"
        Me.btnProfile.Width = 100
        '
        'btnRisk
        '
        Me.btnRisk.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnRisk.Height = 35
        Me.btnRisk.Name = "btnRisk"
        Me.btnRisk.Text = "RISK SCORE"
        Me.btnRisk.Width = 100
        '
        'btnSubscription
        '
        Me.btnSubscription.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSubscription.Enabled = False
        Me.btnSubscription.Height = 40
        Me.btnSubscription.Name = "btnSubscription"
        Me.btnSubscription.Text = "ORDER SUBS"
        Me.btnSubscription.Width = 100
        '
        'btnRedemption
        '
        Me.btnRedemption.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnRedemption.Enabled = False
        Me.btnRedemption.Height = 40
        Me.btnRedemption.Name = "btnRedemption"
        Me.btnRedemption.Text = "ORDER REDS"
        Me.btnRedemption.Width = 100
        '
        'btnMyUnitholder
        '
        Me.btnMyUnitholder.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnMyUnitholder.Enabled = False
        Me.btnMyUnitholder.Height = 40
        Me.btnMyUnitholder.Name = "btnMyUnitholder"
        Me.btnMyUnitholder.Text = "MyUnitholder"
        Me.btnMyUnitholder.Width = 100
        '
        'btnClientSheet
        '
        Me.btnClientSheet.Height = 40
        Me.btnClientSheet.Name = "btnClientSheet"
        Me.btnClientSheet.Text = "Client Sheet"
        Me.btnClientSheet.Width = 100
        '
        'FormMyClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 459)
        Me.Controls.Add(Me.C1InputPanel2)
        Me.Controls.Add(Me.DBGClient)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Name = "FormMyClient"
        Me.Text = "sales -> MyClient"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.csMenu.ResumeLayout(False)
        CType(Me.DBGClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents txtKeyword As C1.Win.C1InputPanel.InputTextBox
    Friend WithEvents btnSearch As C1.Win.C1InputPanel.InputButton
    Friend WithEvents DBGClient As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1InputPanel2 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents btnProfile As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnSubscription As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnRedemption As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnMyUnitholder As C1.Win.C1InputPanel.InputButton
    Friend WithEvents btnClientSheet As C1.Win.C1InputPanel.InputButton
    Friend WithEvents csMenu As ContextMenuStrip
    Friend WithEvents AttachToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnRisk As C1.Win.C1InputPanel.InputButton
End Class
