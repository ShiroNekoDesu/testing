<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportStatpro
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
        Me.WebIV = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WebIV
        '
        Me.WebIV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebIV.Location = New System.Drawing.Point(0, 0)
        Me.WebIV.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebIV.Name = "WebIV"
        Me.WebIV.Size = New System.Drawing.Size(1033, 525)
        Me.WebIV.TabIndex = 10
        '
        'ReportStatpro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 525)
        Me.Controls.Add(Me.WebIV)
        Me.Name = "ReportStatpro"
        Me.Text = "REPORT: Statpro.com"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebIV As WebBrowser
End Class
