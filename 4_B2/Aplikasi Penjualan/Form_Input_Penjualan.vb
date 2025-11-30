Imports System.Data.Odbc

Public Class Form_Input_Penjualan
    Public id_entry As String

    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Form_Input_Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            cmd = New OdbcCommand("SELECT * FROM tbl_barang WHERE id_barang='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            If rd.Read Then
                TextBox2.Text = rd("nama_barang")
                ComboBox1.Text = rd("jenis_barang")
                ComboBox2.Text = rd("satuan_barang")
                TextBox3.Text = rd("harga_jual")
            Else
                TextBox2.Clear()
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                TextBox3.Clear()
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If IsNumeric(TextBox3.Text) AndAlso IsNumeric(TextBox4.Text) Then
            TextBox5.Text = Val(TextBox3.Text) * Val(TextBox4.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Semua data harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Simpan barang jika belum ada
        cmd = New OdbcCommand("SELECT * FROM tbl_barang WHERE id_barang='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader()
        If Not rd.HasRows Then
            cmd = New OdbcCommand("INSERT INTO tbl_barang (id_barang, nama_barang, jenis_barang, satuan_barang, harga_jual) VALUES('" &
                                  TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & Val(TextBox3.Text) & "')", conn)
            cmd.ExecuteNonQuery()
        End If

        ' Cegah duplikat barang untuk ID transaksi yang sama
        cmd = New OdbcCommand("SELECT * FROM tbl_rinci_jual WHERE id_entrypembelian='" & id_entry & "' AND id_barang='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader()
        If rd.HasRows Then
            MessageBox.Show("Barang ini sudah ditambahkan!", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Simpan data penjualan
        cmd = New OdbcCommand("INSERT INTO tbl_rinci_jual (id_entrypembelian, id_barang, qty, total_harga) VALUES('" &
                              id_entry & "','" & TextBox1.Text & "','" & Val(TextBox4.Text) & "','" & Val(TextBox5.Text) & "')", conn)
        cmd.ExecuteNonQuery()

        MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class
