Imports System.ComponentModel

Public Class addRequestForm

#Region "data processing"
    Private Sub pullDivisi()

        Dim paramWorker As New paramWorker(db)
        Dim sqlQuery As String = $"select id_divisi id, name from m_divisi WHERE id_divisi <> {activeUserData.getDivisionId }"


        paramWorker.queries.Add("daftarDivisi", sqlQuery)

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
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If MessageBox.Show("Apakah yakin akan membatalkan request?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub addRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub addRequestForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        pullDivisi()
    End Sub

    Private Sub cboDivisi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDivisi.SelectedIndexChanged
        txtTitle.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim errorMessage As String = ""
        If txtTitle.Text.Trim = "" Then
            errorMessage = "Judul belum diisi."
        ElseIf txtDescription.Text.Trim = "" Then
            errorMessage = "Deskripsi belum diisi."
        End If

        If errorMessage <> "" Then
            MessageBox.Show(errorMessage, "Terjadi kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sqlQuery As String = "INSERT INTO m_task (id_divisi, id_staff, title, description, created_at, created_by) VALUES (?id_divisi, ?id_staff, ?title, ?description, NOW(), ?created_by)"

        Dim sqlParam As New Dictionary(Of String, Object)
        With sqlParam
            .Add("?id_divisi", cboDivisi.SelectedValue)
            .Add("?id_staff", activeUserData.getUserId)
            .Add("?title", txtTitle.Text)
            .Add("?description", txtDescription.Text)
            .Add("?created_by", activeUserData.getUserId)
        End With

        Dim result As StringResult = db.executeQuery(sqlQuery, sqlParam)

        If Not result.isSuccess Then
            MessageBox.Show(result.errorMessage, "Kesalahan menyimpan data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        DialogResult = DialogResult.OK
    End Sub
End Class