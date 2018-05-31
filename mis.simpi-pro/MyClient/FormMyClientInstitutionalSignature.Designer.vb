<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMyClientInstitutionalSignature
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMyClientInstitutionalSignature))
        Me.C1InputPanel1 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader1 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel9 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel2 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblCode = New C1.Win.C1InputPanel.InputLabel()
        Me.lblName = New C1.Win.C1InputPanel.InputLabel()
        Me.InputSeparator1 = New C1.Win.C1InputPanel.InputSeparator()
        Me.InputLabel4 = New C1.Win.C1InputPanel.InputLabel()
        Me.InputLabel1 = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerTitle = New C1.Win.C1InputPanel.InputLabel()
        Me.lblOfficerName = New C1.Win.C1InputPanel.InputLabel()
        Me.C1InputPanel5 = New C1.Win.C1InputPanel.C1InputPanel()
        Me.InputGroupHeader4 = New C1.Win.C1InputPanel.InputGroupHeader()
        Me.InputLabel58 = New C1.Win.C1InputPanel.InputLabel()
        Me.btnSignature = New C1.Win.C1InputPanel.InputButton()
        Me.lblSignature = New C1.Win.C1InputPanel.InputLabel()
        Me.imgSignature = New C1.Win.C1InputPanel.InputImage()
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1InputPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.C1InputPanel1.Items.Add(Me.lblOfficerTitle)
        Me.C1InputPanel1.Items.Add(Me.lblOfficerName)
        Me.C1InputPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1InputPanel1.Name = "C1InputPanel1"
        Me.C1InputPanel1.Size = New System.Drawing.Size(680, 103)
        Me.C1InputPanel1.TabIndex = 3
        Me.C1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader1
        '
        Me.InputGroupHeader1.Name = "InputGroupHeader1"
        Me.InputGroupHeader1.Text = "Institutional Officer"
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
        Me.lblName.Width = 535
        '
        'InputSeparator1
        '
        Me.InputSeparator1.Name = "InputSeparator1"
        Me.InputSeparator1.Width = 656
        '
        'InputLabel4
        '
        Me.InputLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel4.Name = "InputLabel4"
        Me.InputLabel4.Text = "TITLE"
        Me.InputLabel4.Width = 120
        '
        'InputLabel1
        '
        Me.InputLabel1.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.InputLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel1.Name = "InputLabel1"
        Me.InputLabel1.Text = "OFFICER"
        '
        'lblOfficerTitle
        '
        Me.lblOfficerTitle.Name = "lblOfficerTitle"
        Me.lblOfficerTitle.Width = 120
        '
        'lblOfficerName
        '
        Me.lblOfficerName.Name = "lblOfficerName"
        Me.lblOfficerName.Width = 537
        '
        'C1InputPanel5
        '
        Me.C1InputPanel5.BackColor = System.Drawing.Color.White
        Me.C1InputPanel5.BorderThickness = 1
        Me.C1InputPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1InputPanel5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.C1InputPanel5.Items.Add(Me.InputGroupHeader4)
        Me.C1InputPanel5.Items.Add(Me.InputLabel58)
        Me.C1InputPanel5.Items.Add(Me.btnSignature)
        Me.C1InputPanel5.Items.Add(Me.lblSignature)
        Me.C1InputPanel5.Items.Add(Me.imgSignature)
        Me.C1InputPanel5.Location = New System.Drawing.Point(0, 103)
        Me.C1InputPanel5.Name = "C1InputPanel5"
        Me.C1InputPanel5.Size = New System.Drawing.Size(680, 315)
        Me.C1InputPanel5.TabIndex = 4
        Me.C1InputPanel5.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue
        '
        'InputGroupHeader4
        '
        Me.InputGroupHeader4.Name = "InputGroupHeader4"
        Me.InputGroupHeader4.Text = "Signature"
        '
        'InputLabel58
        '
        Me.InputLabel58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputLabel58.Name = "InputLabel58"
        Me.InputLabel58.Text = "Filename: "
        Me.InputLabel58.Width = 60
        '
        'btnSignature
        '
        Me.btnSignature.Break = C1.Win.C1InputPanel.BreakType.None
        Me.btnSignature.Height = 35
        Me.btnSignature.Image = CType(resources.GetObject("btnSignature.Image"), System.Drawing.Image)
        Me.btnSignature.Name = "btnSignature"
        Me.btnSignature.Text = "PREVIEW"
        Me.btnSignature.Width = 100
        '
        'lblSignature
        '
        Me.lblSignature.Break = C1.Win.C1InputPanel.BreakType.Row
        Me.lblSignature.Name = "lblSignature"
        '
        'imgSignature
        '
        Me.imgSignature.Height = 245
        Me.imgSignature.Image = CType(resources.GetObject("imgSignature.Image"), System.Drawing.Image)
        Me.imgSignature.ImageAlign = C1.Win.C1InputPanel.InputImageAlignment.MiddleCenter
        Me.imgSignature.Name = "imgSignature"
        Me.imgSignature.Width = 662
        '
        'FormMyClientInstitutionalSignature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 418)
        Me.Controls.Add(Me.C1InputPanel5)
        Me.Controls.Add(Me.C1InputPanel1)
        Me.Name = "FormMyClientInstitutionalSignature"
        Me.Text = "sales -> MyClient: Institutional Account Signature"
        CType(Me.C1InputPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1InputPanel5, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblOfficerName As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents InputLabel4 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents lblOfficerTitle As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents C1InputPanel5 As C1.Win.C1InputPanel.C1InputPanel
    Friend WithEvents InputGroupHeader4 As C1.Win.C1InputPanel.InputGroupHeader
    Friend WithEvents InputLabel58 As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents btnSignature As C1.Win.C1InputPanel.InputButton
    Friend WithEvents lblSignature As C1.Win.C1InputPanel.InputLabel
    Friend WithEvents imgSignature As C1.Win.C1InputPanel.InputImage
End Class
