<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoEllipsis = True
        Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(0, 57)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblDescription.Size = New System.Drawing.Size(286, 72)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Deskripsi Task"
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(280, 20)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Status Task"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoEllipsis = True
        Me.lblTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTanggal.Location = New System.Drawing.Point(3, 22)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(280, 20)
        Me.lblTanggal.TabIndex = 7
        Me.lblTanggal.Text = "Status Task"
        '
        'HistoryCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTanggal)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "HistoryCard"
        Me.Size = New System.Drawing.Size(286, 129)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblDescription As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTanggal As Label
End Class
