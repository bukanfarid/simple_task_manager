<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataCard
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnResponse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(8, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(513, 25)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Judul Task"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoEllipsis = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.Location = New System.Drawing.Point(9, 31)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(484, 20)
        Me.lblSubtitle.TabIndex = 3
        Me.lblSubtitle.Text = "Status Task"
        '
        'lblDescription
        '
        Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(0, 64)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Padding = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.lblDescription.Size = New System.Drawing.Size(606, 98)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Deskripsi Task"
        '
        'btnResponse
        '
        Me.btnResponse.Location = New System.Drawing.Point(527, 6)
        Me.btnResponse.Name = "btnResponse"
        Me.btnResponse.Size = New System.Drawing.Size(75, 23)
        Me.btnResponse.TabIndex = 5
        Me.btnResponse.Text = "Respon"
        Me.btnResponse.UseVisualStyleBackColor = True
        Me.btnResponse.Visible = False
        '
        'DataCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnResponse)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Name = "DataCard"
        Me.Size = New System.Drawing.Size(606, 162)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnResponse As Button
End Class
