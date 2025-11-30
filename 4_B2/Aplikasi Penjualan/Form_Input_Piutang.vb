Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form_Input_Piutang
    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form_Input_Piutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("data wajib diisi!!")
        Else
            'Cek Barang Ke database'
            cmd = New OdbcCommand("Select * from tbl_utang where id_utang ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows = False Then
                cmd = New OdbcCommand("insert into tbl_utang values('" & TextBox1.Text &
                                      "','" & TextBox2.Text &
                                      "','" & TextBox3.Text &
                                      "','" & TextBox4.Text &
                                       "')", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data Berhasil Dibuat")
                Call Clear()
                Call Form_Piutang.tampil_Piutang()
            Else
                cmd = New OdbcCommand("update tbl_utang set nama_pelanggan='" & TextBox2.Text &
                                      "',tgl_belanja='" & TextBox3.Text &
                                      "',jmlh_utang='" & TextBox4.Text &
                                       "'where id_utang='" & TextBox1.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("data berhasil diedit")
                Call Clear()
                Call Form_Piutang.tampil_Piutang()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Apakah data ingin dihapus", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cmd = New OdbcCommand("delete from tbl_utang where id_utang='" & TextBox1.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Dihapus")
            Call Clear()
            Call Form_Piutang.tampil_Piutang()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cmd = New OdbcCommand("Select * from tbl_utang where id_utang='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            TextBox2.Text = rd(1)
            TextBox3.Text = rd(2)
            TextBox4.Text = rd(3)

        Else
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class