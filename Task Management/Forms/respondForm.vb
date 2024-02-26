Public Class respondForm
    Private id_task As Integer = 0

    Sub New(ByVal task_id As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        id_task = task_id
    End Sub

    Private Sub respondForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If MessageBox.Show("Apakah yakin akan membatalkan respond?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        txtTitle.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim errorMessage As String = ""
        If txtTitle.Text.Trim = "" Then
            errorMessage = "Judul belum diisi."
        ElseIf txtDescription.Text.Trim = "" Then
            errorMessage = "Deskripsi belum diisi."
        ElseIf cboStatus.SelectedIndex = 0 Then
            errorMessage = "Status task belum dipilih."
        End If

        If errorMessage <> "" Then
            MessageBox.Show(errorMessage, "Terjadi kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sqlQuery As String = "INSERT INTO hist_task (id_task, status, subtitle, description, created_at, created_by) VALUES (?id_task, ?status, ?subtitle, ?description, NOW(), ?created_by)"

        Dim sqlParam As New Dictionary(Of String, Object)
        With sqlParam
            .Add("?id_task", id_task)
            .Add("?status", cboStatus.SelectedIndex)
            .Add("?subtitle", txtTitle.Text)
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