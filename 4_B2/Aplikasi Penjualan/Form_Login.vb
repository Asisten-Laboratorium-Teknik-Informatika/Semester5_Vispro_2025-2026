Imports System.Data.Odbc 'IMPORT LIBRARY untuk mengakses database ODBC'
Public Class Form_Login

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Username Atau Password Masih Kosong")
        Else
            Call Koneksi()
            cmd = New OdbcCommand("select * from tbl_user where username='" & TextBox1.Text & "' and pwd='" & TextBox2.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then 'BERHASIL LOGIN MASUK KE MENU'
                Form_Menu.lbl_level.Text = rd.Item("lvl")
                Form_Menu.lbl_nama.Text = rd.Item("nama_user")
                Me.Hide()
                Form_Menu.Show()
            Else
                MessageBox.Show("Username Atau Password Salah!!!z!")
            End If

        End If
    End Sub

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End

    End Sub
End Class