<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMyClientInstitutionalDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMyClientInstitutionalDocument))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputSeparator1 = New C1.Win.C1InputPanel.InputSeparator()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel6 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel7 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel8 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentType = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentIssuer = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentNo = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentIsExpired = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentExpired = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel12 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblDocumentTitle = New C1.Win.C1InputPanel.InputLabel()
        Me.InputSeparator2 = New C1.Win.C1InputPanel.InputSeparator()
        Me.InputLabel14 = New C1.Win.C1InputPanel.InputLabel()
        Me.btnDocument = New C1.Win.C1InputPanel.InputButton()
        Me.lblDocumentFile = New C1.Win.C1InputPanel.InputLabel()
        Me.wbDocument = New System.Windows.Forms.WebBrowser()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1InputPanel1
        '
        Me.C1InputPanel1.BorderThickness = 1
        Me.C1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1InputPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel1.Items.Add(Me.InputGroupHeader1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel9)
        Me.C1InputPanel1.Items.Add(Me.InputLabel2)
        Me.C1InputPanel1.Items.Add(Me.lblCode)
        Me.C1InputPanel1.Items.Add(Me.lblName)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel4)
        Me.C1InputPanel1.Items.Add(Me.InputLabel1)
        Me.C1InputPanel1.Items.Add(Me.InputLabel6)
        Me.C1InputPanel1.Items.Add(Me.InputLabel7)
        Me.C1InputPanel1.Items.Add(Me.InputLabel8)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentType)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentIssuer)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentNo)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentIsExpired)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentExpired)
        Me.C1InputPanel1.Items.Add(Me.InputLabel12)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentTitle)
        Me.C1InputPanel1.Items.Add(Me.InputSeparator2)
        Me.C1InputPanel1.Items.Add(Me.InputLabel14)
        Me.C1InputPanel1.Items.Add(Me.btnDocument)
        Me.C1InputPanel1.Items.Add(Me.lblDocumentFile)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(826, 164)
        Me.C1InputPanel1.TabIndex = 3
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "Institutional Document"
        '
        'InputLabel9
        '
        Me.InputLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel9.Name = "InputLabel9"
        Me.InputLabel9.Text = "CIF"
        Me.InputLabel9.Width = 120
        '
        'InputLabel2
        '
        Me.InputLabel2.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel2.Name = "InputLabel2"
        Me.InputLabel2.Text = "INSTITUTIONAL"
        Me.InputLabel2.Width = 500
        '
        'lblCode
        '
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Width = 120
        '
        'lblName
        '
        Me.lblName.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblName.Name = "lblName"
        Me.lblName.Width = 679
        '
        'InputSeparator1
        '
        Me.InputSeparator1.Name = "InputSeparator1"
        Me.InputSeparator1.Width = 804
        '
        'InputLabel4
        '
        Me.InputLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "TYPE"
        Me.InputLabel4.Width = 150
        '
        'InputLabel1
        '
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "ISSUER"
        Me.InputLabel1.Width = 320
        '
        'InputLabel6
        '
        Me.InputLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel6.Name = "InputLabel6"
        Me.InputLabel6.Text = "NO"
        Me.InputLabel6.Width = 150
        '
        'InputLabel7
        '
        Me.InputLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel7.Name = "InputLabel7"
        Me.InputLabel7.Text = "isEXPIRED?"
        Me.InputLabel7.Width = 75
        '
        'InputLabel8
        '
        Me.InputLabel8.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel8.Name = "InputLabel8"
        Me.InputLabel8.Text = "EXPIRED"
        Me.InputLabel8.Width = 100
        '
        'lblDocumentType
        '
        Me.lblDocumentType.Name = "lblDocumentType"
        Me.lblDocumentType.Width = 150
        '
        'lblDocumentIssuer
        '
        Me.lblDocumentIssuer.Name = "lblDocumentIssuer"
        Me.lblDocumentIssuer.Width = 320
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Width = 150
        '
        'lblDocumentIsExpired
        '
        Me.lblDocumentIsExpired.Name = "lblDocumentIsExpired"
        Me.lblDocumentIsExpired.Width = 75
        '
        'lblDocumentExpired
        '
        Me.lblDocumentExpired.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblDocumentExpired.Name = "lblDocumentExpired"
        Me.lblDocumentExpired.Width = 100
        '
        'InputLabel12
        '
        Me.InputLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel12.Name = "InputLabel12"
        Me.InputLabel12.Text = "TITLE: "
        '
        'lblDocumentTitle
        '
        Me.lblDocumentTitle.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblDocumentTitle.Name = "lblDocumentTitle"
        Me.lblDocumentTitle.Width = 761
        '
        'InputSeparator2
        '
        Me.InputSeparator2.Name = "InputSeparator2"
        Me.InputSeparator2.Width = 805
        '
        'InputLabel14
        '
        Me.InputLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel14.Name = "InputLabel14"
        Me.InputLabel14.Text = "Filename: "
        '
        'btnDocument
        '
        Me.btnDocument.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnDocument.Height = 35
        Me.btnDocument.Image = CType(resources.GetObject("btnDocument.Image"), System.Drawing.Image)
        Me.btnDocument.Name = "btnDocument"
        Me.btnDocument.Text = "PREVIEW"
        Me.btnDocument.Width = 100
        '
        'lblDocumentFile
        '
        Me.lblDocumentFile.Name = "lblDocumentFile"
        Me.lblDocumentFile.Width = 636
        '
        'wbDocument
        '
        Me.wbDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbDocument.Location = New System.Drawing.Point(0, 164)
        Me.wbDocument.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbDocument.Name = "wbDocument"
        Me.wbDocument.Size = New System.Drawing.Size(826, 360)
        Me.wbDocument.TabIndex = 4
        '
        'FormMyClientInstitutionalDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 524)
        Me.Controls.Add(Me.wbDocument)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Name = "FormMyClientInstitutionalDocument"
        Me.Text = "sales -> MyClient: Institutional Account Document"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1InputPanel1 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader1 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel9 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel2 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblCode As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputSeparator1 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents InputLabel1 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentNo As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentIssuer As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel6 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel7 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel8 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentType As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentExpired As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel12 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentTitle As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel14 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblDocumentFile As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputSeparator2 As C1.Win.C1InputPanel.InputSeparator
    Friend WithEvents btnDocument As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblDocumentIsExpired As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents wbDocument As WebBrowser
End Class
