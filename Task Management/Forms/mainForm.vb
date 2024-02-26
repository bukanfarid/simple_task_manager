Imports System.ComponentModel

Public Class mainForm
    Private mainDataTable As DataTable = Nothing

#Region "Main Data"
    Private Sub pullData(Optional ByVal isMine As Boolean = False)

        Dim paramWorker As New paramWorker(db)
        Dim sqlQuery As String '= $"select * from m_task where id_divisi = {activeUserData.getDivisionId}"
        sqlQuery = $"select t.id_task, t.id_divisi, s.id_divisi divisi_asal, d.name nama_divisi, t.id_staff, t.title, t.description, IFNULL( DATE_FORMAT(t.created_at, '%d-%m-%Y'),'') tanggalRequest, ifnull(ht.status,0) status, ifnull(ht.subtitle,'') subtitle, ifnull(ht.description,'') description, IFNULL( DATE_FORMAT(ht.created_at, '%d-%m-%Y'),'') tanggalRespon from m_task t JOIN m_staff s ON t.created_by = s.id_staff JOIN m_divisi d ON s.id_divisi = d.id_divisi LEFT JOIN (SELECT * FROM hist_task ht JOIN (SELECT max(id_task_history) id_task_history FROM hist_task ht GROUP BY id_task) ht1 USING (id_task_history)) ht USING (id_task) where t.id_divisi = {activeUserData.getDivisionId }"

        If isMine Then
            '  sqlQuery = $"SELECT * FROM m_task t JOIN m_staff s USING (id_staff) JOIN m_divisi d ON s.id_divisi = d.id_divisi WHERE t.id_staff = {activeUserData.getUserId}"
            sqlQuery = $"SELECT t.id_task, t.id_divisi, s.id_divisi divisi_asal, d.name nama_divisi, t.id_staff, t.title, t.description, IFNULL( DATE_FORMAT(t.created_at, '%d-%m-%Y'),'') tanggalRequest, t.created_at, ifnull(ht.status,0) status, ifnull(ht.subtitle,'') subtitle, ifnull(ht.description,'') description, IFNULL( DATE_FORMAT(ht.created_at, '%d-%m-%Y'),'') tanggalRespon FROM m_task t JOIN m_staff s USING (id_staff) JOIN m_divisi d ON t.id_divisi = d.id_divisi LEFT JOIN (SELECT * FROM hist_task ht JOIN (SELECT max(id_task_history) id_task_history FROM hist_task ht GROUP BY id_task) ht1 USING (id_task_history)) ht USING (id_task) WHERE t.id_staff = {activeUserData.getUserId}"
        End If

        paramWorker.queries.Add("mydata", sqlQuery)

        Dim bw As New BackgroundWorker
        AddHandler bw.DoWork, AddressOf processPullData
        AddHandler bw.RunWorkerCompleted, AddressOf dataPulled
        bw.RunWorkerAsync(paramWorker)

    End Sub



    Private Sub dataPulled(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim responds As Dictionary(Of String, DatasetResult) = CType(e.Result, Dictionary(Of String, DatasetResult))
        Dim respond As DatasetResult = Nothing
        Dim isError As Boolean = False
        '  Dim ds As DataSet

        For Each kvp As KeyValuePair(Of String, DatasetResult) In responds
            respond = kvp.Value

            If Not respond.isSuccess Then

                MessageBox.Show(respond.errorMessage, "Kesalahan pada " & kvp.Key, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else

                'Dim arrColor() As Color = {SystemColors.Control, Color.LightGray, Color.LightBlue, Color.LightPink}
                mainDataTable = respond.dataset.Tables("mydata")
                ' buildMainData(mainDataTable)
                If cboDivisi.Items.Count > 0 Then cboDivisi.SelectedIndex = 0
                cboStatus.SelectedIndex = 0
                filterData()
            End If
        Next
    End Sub



    Private Sub respondClick(sender As Object, e As EventArgs)
        Dim senderType As Button = CType(sender, Button)
        Dim senderParent As DataCard = CType(sender.parent, DataCard)

        Using respond As New respondForm(senderParent.taskId)
            ' Kalau button response di click saat my request
            ' Ini berarti button response visible, menandakan bahwa status task sudah selesai di sisi divisi lain
            If lblMyRequest.BackColor = Color.LightCoral Then
                respond.cboStatus.Items.Clear()
                respond.cboStatus.Items.Add("Pilih Status")
                respond.cboStatus.Items.Add("Finished by Client")
            End If


            If respond.ShowDialog(Me) = DialogResult.OK Then
                If lblMyRequest.BackColor = Color.LightCoral Then
                    pullData(True)
                Else
                    pullData()
                End If
            End If

        End Using
    End Sub

    Private Sub DataCardClick(sender As Object, e As EventArgs)
        Dim senderType As DataCard = Nothing
        Dim alternateType As Label = Nothing
        Try
            senderType = CType(sender, DataCard)
        Catch ex As Exception
            alternateType = CType(sender, Label)
            senderType = alternateType.Parent
        End Try

        Dim paramWorker As New paramWorker(db)
        Dim sqlQuery As String = $"select ht.status, ht.subtitle, ht.description, DATE_FORMAT(created_at, '%d-%m-%Y') tanggalRespon from hist_task ht where ht.id_task = {senderType.taskId } ORDER BY ht.id_task_history DESC"

        paramWorker.queries.Add("taskDetail", sqlQuery)

        Dim bw As New BackgroundWorker
        AddHandler bw.DoWork, AddressOf processPullData
        AddHandler bw.RunWorkerCompleted, AddressOf dataCardPulled
        bw.RunWorkerAsync(paramWorker)
    End Sub


    Private Sub dataCardPulled(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim responds As Dictionary(Of String, DatasetResult) = CType(e.Result, Dictionary(Of String, DatasetResult))
        Dim respond As DatasetResult = Nothing
        Dim isError As Boolean = False

        panelRightData.Controls.Clear()
        panelRightBar.Visible = True

        If responds.ContainsKey("taskDetail") Then
            respond = responds("taskDetail")

            If Not respond.isSuccess Then
                MessageBox.Show(respond.errorMessage, "Terjadi kesalahan menarik detail task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If respond.dataset.Tables("taskDetail").Rows.Count < 1 Then
                Dim historyCard As New HistoryCard
                With historyCard
                    .lblTitle.Text = "Belum ada respon dari divisi terkait"
                    .lblTanggal.Text = ""
                    .lblDescription.Text = ""

                    .Width = panelRightBar.Width - 25
                    .Anchor = AnchorStyles.Left And AnchorStyles.Right
                End With
                panelRightData.Controls.Add(historyCard)
            End If
            Dim index As Integer = 0
            For Each dr As DataRow In respond.dataset.Tables("taskDetail").Rows
                Dim historyCard As New HistoryCard
                With historyCard
                    .lblTitle.Text = $"{getRequestStatus(dr("status"))} - {dr("subtitle")}"
                    .lblTanggal.Text = dr("tanggalRespon")
                    .lblDescription.Text = dr("description")

                    .Width = panelRightBar.Width - 25
                    .Anchor = AnchorStyles.Left And AnchorStyles.Right
                    If (index Mod 2) = 0 Then .BackColor = Color.LightGray
                End With
                panelRightData.Controls.Add(historyCard)
                index += 1
            Next
        End If
    End Sub


#End Region


#Region "Data Divisi"
    Private Sub pullDivisi()

        Dim paramWorker As New paramWorker(db)
        Dim sqlQuery As String = $"SELECT 0 id, 'Semua Divisi' name UNION ALL select id_divisi id, name from m_divisi WHERE id_divisi <> {activeUserData.getDivisionId }"


        paramWorker.queries.Add("daftarDivisi", sqlQuery)

        Dim bw As New BackgroundWorker
        AddHandler bw.DoWork, AddressOf processPullData
        AddHandler bw.RunWorkerCompleted, AddressOf divisiPulled
        bw.RunWorkerAsync(paramWorker)

    End Sub

    Private Sub divisiPulled(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim responds As Dictionary(Of String, DatasetResult) = CType(e.Result, Dictionary(Of String, DatasetResult))
        Dim respond As DatasetResult = Nothing
        Dim isError As Boolean = False
        '  Dim ds As DataSet

        If responds.ContainsKey("daftarDivisi") Then
            respond = responds("daftarDivisi")

            If Not respond.isSuccess Then
                MessageBox.Show(respond.errorMessage, "Kesalahan mengambil data divisi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            cboDivisi.DataSource = respond.dataset.Tables("daftarDivisi")
            cboDivisi.DisplayMember = "name"
            cboDivisi.ValueMember = "id"
            cboDivisi.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "UI Alter"
    Private Sub buildMainData(ByVal dt As DataTable)
        panelMainData.Controls.Clear()

        If dt Is Nothing Then Exit Sub


        Dim index As Integer = 0

        For Each dr As DataRow In dt.Rows
            Dim dataCard As New DataCard
            With dataCard
                .taskId = CInt(dr("id_task"))
                .lblTitle.Text = $"{dr("title")} ({dr("tanggalRequest")})"
                .lblSubtitle.Text = getRequestStatus(CInt(dr("status"))) & If(dr("subtitle") = "", "", " - ") & dr("subtitle")
                .lblDescription.Text = dr("nama_divisi") & " - " & dr("description")
                .Anchor = AnchorStyles.Left And AnchorStyles.Right
                If (index Mod 2) = 0 Then .BackColor = Color.LightGray
                .btnResponse.Visible = (lblRequestFromOther.BackColor = Color.LightCoral) OrElse CInt(dr("status")) = 4
                ' Pakai handler karena perlu ada next action di form ini.
                ' Opsi lain bisa pakai callback, agar handler bisa tetap di dalam DataCard instead of di mainForm
                AddHandler dataCard.Click, AddressOf DataCardClick
                AddHandler dataCard.lblTitle.Click, AddressOf DataCardClick
                AddHandler dataCard.lblSubtitle.Click, AddressOf DataCardClick
                AddHandler dataCard.lblDescription.Click, AddressOf DataCardClick
                AddHandler dataCard.btnResponse.Click, AddressOf respondClick
            End With
            panelMainData.Controls.Add(dataCard)
            index += 1
        Next
    End Sub

    Private Sub filterData()
        Dim filter As New List(Of String)

        ' Filter berdasarkan divisi
        If lblRequestFromOther.BackColor = Color.LightCoral Then
            ' Ini bagian permintaan dari divisi lain
            If cboDivisi.SelectedIndex <> 0 Then filter.Add("divisi_asal = " & cboDivisi.SelectedValue)
        Else
            ' Ini bagian permintaan dari divisi saya ke divisi lain
            If cboDivisi.SelectedIndex <> 0 Then filter.Add("id_divisi = " & cboDivisi.SelectedValue)
        End If

        If cboStatus.SelectedIndex <> 0 Then filter.Add("status = " & cboStatus.SelectedIndex)
        Dim copiedDatatable As DataTable = Nothing

        Try
            copiedDatatable = mainDataTable.Select(String.Join(" AND ", filter)).CopyToDataTable
        Catch ex As Exception

        End Try

        buildMainData(copiedDatatable)
    End Sub
#End Region
    Private Sub mainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        While activeUserData Is Nothing
            Using loginView As New loginForm
                loginView.ShowDialog(Me)
            End Using
        End While

        With activeUserData
            lblStaffName.Text = .getUserName
            lblDivisionName.Text = .getDivisionName
            lblRequestFromOther.Text = $"Permintaan ke { .getDivisionName}"
        End With
        pullDivisi()
        pullData()
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        mainFunction()
    End Sub

    Private Sub lblRequestFromOther_Click(sender As Object, e As EventArgs) Handles lblRequestFromOther.Click
        lblRequestFromOther.BackColor = Color.LightCoral
        lblMyRequest.BackColor = Color.LightGray
        lblJenisProses.Text = lblRequestFromOther.Text
        panelRightBar.Visible = False

        pullData()

    End Sub

    Private Sub lblMyRequest_Click(sender As Object, e As EventArgs) Handles lblMyRequest.Click
        lblRequestFromOther.BackColor = Color.LightGray
        lblMyRequest.BackColor = Color.LightCoral
        lblJenisProses.Text = lblMyRequest.Text
        panelRightBar.Visible = False
        pullData(True)
    End Sub

    Private Sub lblCloseRightBar_Click(sender As Object, e As EventArgs) Handles lblCloseRightBar.Click
        panelRightBar.Visible = False
    End Sub

    Private Sub lblTambah_Click(sender As Object, e As EventArgs) Handles lblTambah.Click
        Using addForm As New addRequestForm
            If addForm.ShowDialog(Me) = DialogResult.OK Then
                If lblMyRequest.BackColor = Color.LightCoral Then
                    pullData(True)
                Else
                    pullData()
                End If
            End If
        End Using
    End Sub

    Private Sub cboDivisi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivisi.SelectedIndexChanged
        If mainDataTable IsNot Nothing Then filterData()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        If mainDataTable IsNot Nothing Then filterData()
    End Sub
End Class
