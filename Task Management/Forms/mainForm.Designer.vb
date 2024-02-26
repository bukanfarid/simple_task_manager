<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Me.lblStaffName = New System.Windows.Forms.Label()
        Me.lblDivisionName = New System.Windows.Forms.Label()
        Me.lblMyRequest = New System.Windows.Forms.Label()
        Me.lblRequestFromOther = New System.Windows.Forms.Label()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.panelLeftBar = New System.Windows.Forms.Panel()
        Me.panelRightBar = New System.Windows.Forms.Panel()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelMainData = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCloseRightBar = New System.Windows.Forms.Label()
        Me.lblTambah = New System.Windows.Forms.Label()
        Me.lblJenisProses = New System.Windows.Forms.Label()
        Me.panelRightData = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelMainTop = New System.Windows.Forms.Panel()
        Me.cboDivisi = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelHeader.SuspendLayout()
        Me.panelLeftBar.SuspendLayout()
        Me.panelRightBar.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.panelMainTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStaffName
        '
        Me.lblStaffName.AutoSize = True
        Me.lblStaffName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStaffName.Location = New System.Drawing.Point(16, 9)
        Me.lblStaffName.Name = "lblStaffName"
        Me.lblStaffName.Size = New System.Drawing.Size(128, 25)
        Me.lblStaffName.TabIndex = 0
        Me.lblStaffName.Text = "Nama Staff"
        '
        'lblDivisionName
        '
        Me.lblDivisionName.AutoSize = True
        Me.lblDivisionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivisionName.Location = New System.Drawing.Point(17, 35)
        Me.lblDivisionName.Name = "lblDivisionName"
        Me.lblDivisionName.Size = New System.Drawing.Size(100, 20)
        Me.lblDivisionName.TabIndex = 1
        Me.lblDivisionName.Text = "Nama Divisi"
        '
        'lblMyRequest
        '
        Me.lblMyRequest.BackColor = System.Drawing.Color.LightGray
        Me.lblMyRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMyRequest.ForeColor = System.Drawing.Color.Black
        Me.lblMyRequest.Location = New System.Drawing.Point(18, 62)
        Me.lblMyRequest.Name = "lblMyRequest"
        Me.lblMyRequest.Size = New System.Drawing.Size(163, 54)
        Me.lblMyRequest.TabIndex = 2
        Me.lblMyRequest.Text = "Permintaan Saya"
        Me.lblMyRequest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRequestFromOther
        '
        Me.lblRequestFromOther.AutoEllipsis = True
        Me.lblRequestFromOther.BackColor = System.Drawing.Color.LightCoral
        Me.lblRequestFromOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestFromOther.ForeColor = System.Drawing.Color.Black
        Me.lblRequestFromOther.Location = New System.Drawing.Point(18, 3)
        Me.lblRequestFromOther.Name = "lblRequestFromOther"
        Me.lblRequestFromOther.Size = New System.Drawing.Size(163, 54)
        Me.lblRequestFromOther.TabIndex = 3
        Me.lblRequestFromOther.Text = "Permintaan Ke"
        Me.lblRequestFromOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.lblJenisProses)
        Me.panelHeader.Controls.Add(Me.lblTambah)
        Me.panelHeader.Controls.Add(Me.lblStaffName)
        Me.panelHeader.Controls.Add(Me.lblDivisionName)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1097, 68)
        Me.panelHeader.TabIndex = 4
        '
        'panelLeftBar
        '
        Me.panelLeftBar.Controls.Add(Me.lblRequestFromOther)
        Me.panelLeftBar.Controls.Add(Me.lblMyRequest)
        Me.panelLeftBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftBar.Location = New System.Drawing.Point(0, 68)
        Me.panelLeftBar.Name = "panelLeftBar"
        Me.panelLeftBar.Size = New System.Drawing.Size(228, 443)
        Me.panelLeftBar.TabIndex = 5
        '
        'panelRightBar
        '
        Me.panelRightBar.Controls.Add(Me.panelRightData)
        Me.panelRightBar.Controls.Add(Me.lblCloseRightBar)
        Me.panelRightBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRightBar.Location = New System.Drawing.Point(790, 68)
        Me.panelRightBar.Name = "panelRightBar"
        Me.panelRightBar.Size = New System.Drawing.Size(307, 443)
        Me.panelRightBar.TabIndex = 6
        Me.panelRightBar.Visible = False
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.panelMainData)
        Me.panelMain.Controls.Add(Me.panelMainTop)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(228, 68)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(562, 443)
        Me.panelMain.TabIndex = 7
        '
        'panelMainData
        '
        Me.panelMainData.AutoScroll = True
        Me.panelMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMainData.Location = New System.Drawing.Point(0, 35)
        Me.panelMainData.Name = "panelMainData"
        Me.panelMainData.Size = New System.Drawing.Size(562, 408)
        Me.panelMainData.TabIndex = 1
        '
        'lblCloseRightBar
        '
        Me.lblCloseRightBar.AutoEllipsis = True
        Me.lblCloseRightBar.BackColor = System.Drawing.Color.LightCoral
        Me.lblCloseRightBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCloseRightBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCloseRightBar.ForeColor = System.Drawing.Color.Black
        Me.lblCloseRightBar.Location = New System.Drawing.Point(0, 414)
        Me.lblCloseRightBar.Name = "lblCloseRightBar"
        Me.lblCloseRightBar.Size = New System.Drawing.Size(307, 29)
        Me.lblCloseRightBar.TabIndex = 4
        Me.lblCloseRightBar.Text = "Tutup"
        Me.lblCloseRightBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTambah
        '
        Me.lblTambah.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTambah.AutoEllipsis = True
        Me.lblTambah.BackColor = System.Drawing.Color.LightCoral
        Me.lblTambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTambah.ForeColor = System.Drawing.Color.Black
        Me.lblTambah.Location = New System.Drawing.Point(916, 7)
        Me.lblTambah.Name = "lblTambah"
        Me.lblTambah.Size = New System.Drawing.Size(163, 54)
        Me.lblTambah.TabIndex = 4
        Me.lblTambah.Text = "Tambah Permintaan"
        Me.lblTambah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblJenisProses
        '
        Me.lblJenisProses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJenisProses.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJenisProses.Location = New System.Drawing.Point(231, 22)
        Me.lblJenisProses.Name = "lblJenisProses"
        Me.lblJenisProses.Size = New System.Drawing.Size(666, 37)
        Me.lblJenisProses.TabIndex = 5
        Me.lblJenisProses.Text = "-"
        Me.lblJenisProses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelRightData
        '
        Me.panelRightData.AutoScroll = True
        Me.panelRightData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelRightData.Location = New System.Drawing.Point(0, 0)
        Me.panelRightData.Name = "panelRightData"
        Me.panelRightData.Size = New System.Drawing.Size(307, 414)
        Me.panelRightData.TabIndex = 5
        '
        'panelMainTop
        '
        Me.panelMainTop.Controls.Add(Me.cboStatus)
        Me.panelMainTop.Controls.Add(Me.Label2)
        Me.panelMainTop.Controls.Add(Me.cboDivisi)
        Me.panelMainTop.Controls.Add(Me.Label1)
        Me.panelMainTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMainTop.Location = New System.Drawing.Point(0, 0)
        Me.panelMainTop.Name = "panelMainTop"
        Me.panelMainTop.Size = New System.Drawing.Size(562, 35)
        Me.panelMainTop.TabIndex = 2
        '
        'cboDivisi
        '
        Me.cboDivisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivisi.FormattingEnabled = True
        Me.cboDivisi.Location = New System.Drawing.Point(48, 7)
        Me.cboDivisi.Name = "cboDivisi"
        Me.cboDivisi.Size = New System.Drawing.Size(219, 21)
        Me.cboDivisi.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Divisi"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Pilih Status", "Setuju", "Tolak", "Proses", "Selesai", "Finished By Client"})
        Me.cboStatus.Location = New System.Drawing.Point(435, 7)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(121, 21)
        Me.cboStatus.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(371, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Status"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 511)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelRightBar)
        Me.Controls.Add(Me.panelLeftBar)
        Me.Controls.Add(Me.panelHeader)
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelLeftBar.ResumeLayout(False)
        Me.panelRightBar.ResumeLayout(False)
        Me.panelMain.ResumeLayout(False)
        Me.panelMainTop.ResumeLayout(False)
        Me.panelMainTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblStaffName As Label
    Friend WithEvents lblDivisionName As Label
    Friend WithEvents lblMyRequest As Label
    Friend WithEvents lblRequestFromOther As Label
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelLeftBar As Panel
    Friend WithEvents panelRightBar As Panel
    Friend WithEvents panelMain As Panel
    Friend WithEvents panelMainData As FlowLayoutPanel
    Friend WithEvents lblCloseRightBar As Label
    Friend WithEvents lblJenisProses As Label
    Friend WithEvents lblTambah As Label
    Friend WithEvents panelRightData As FlowLayoutPanel
    Friend WithEvents panelMainTop As Panel
    Friend WithEvents cboDivisi As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label2 As Label
End Class
