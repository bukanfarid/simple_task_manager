Public Class loginForm


#Region "background process"
    Private Function validateInput() As Boolean
        Dim errorMessage As String = ""

        If txtUser.Text.Trim = "" Then
            errorMessage = "Username harus diisi"
        ElseIf txtPassword.Text.Trim = "" Then
            errorMessage = "Password harus diisi"
        End If

        If errorMessage <> "" Then
            MessageBox.Show(errorMessage, "Terjadi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub loginProcess()
        If Not validateInput() Then Exit Sub

        Dim sqlQuery As String = "select d.id_divisi, s.id_staff, d.name divisi_name, s.name staff_name from m_staff s join m_divisi d using (id_divisi) WHERE s.username = ?username AND s.password = ?password"
        Dim sqlParam As New Dictionary(Of String, Object)
        sqlParam.Add("?username", txtUser.Text)
        sqlParam.Add("?password", txtPassword.Text)

        Dim datasetResult As DatasetResult = db.query(sqlQuery, New DataSet, "dataUser", sqlParam)


        If Not datasetResult.isSuccess Then
            MessageBox.Show(datasetResult.errorMessage, "Kesalahan Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If datasetResult.dataset.Tables("dataUser").Rows.Count < 1 Then
            MessageBox.Show("Username dan password tidak ditemukan. Pastikan anda sudah memasukkan data dengan benar.", "Terjadi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dr As DataRow = datasetResult.dataset.Tables("dataUser").Rows(0)
        activeUserData = New UserData(CInt(dr("id_divisi")), dr("divisi_name"), CInt(dr("id_staff")), dr("staff_name"))
        DialogResult = DialogResult.OK
    End Sub
#End Region

    Private Sub loginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtUser.Focus()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        'txtPassword.PasswordChar = If(chkShowPassword.Checked, "", "*")
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Application.Exit()
        If MessageBox.Show($"Apakah yakin akan membatalkan login?{vbCrLf}Batal Login akan otomatis menutup aplikasi.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Application.Exit()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        loginProcess()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then loginProcess()
    End Sub
End Class