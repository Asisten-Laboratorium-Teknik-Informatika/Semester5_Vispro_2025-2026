Imports System.Data.Odbc

Public Class Form_Penjualan
    Public id_entry_aktif As String

    Private Sub Form_Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        TextBox1.Text = GenerateNoTransaksi()
        ' Set tanggal dan jam real-time
        TextBox3.Text = DateTime.Now.ToString("yyyy-MM-dd")  ' TextBox3 = Tanggal
        TextBox2.Text = DateTime.Now.ToString("HH:mm:ss")    ' TextBox2 = Jam

        Timer1.Start()
        If String.IsNullOrEmpty(id_entry_aktif) Then
            id_entry_aktif = GenerateIDTransaksi()
        End If
        Tampil_Penjualan()
    End Sub

    Private Function GenerateNoTransaksi() As String
        Dim tgl = DateTime.Now.ToString("yyyyMMdd")
        Dim urutan As Integer = 1
        Dim noTrans As String = ""

        cmd = New OdbcCommand("SELECT MAX(no_transaksi) FROM tbl_jual WHERE no_transaksi LIKE 'TR" & tgl & "%'", conn)
        rd = cmd.ExecuteReader()
        If rd.Read() AndAlso Not IsDBNull(rd(0)) Then
            Dim lastId As String = rd(0).ToString()
            Dim lastNo As Integer = Integer.Parse(lastId.Substring(10))
            urutan = lastNo + 1
        End If

        noTrans = "TR" & tgl & urutan.ToString("D3")
        Return noTrans
    End Function

    Private Function GenerateIDTransaksi() As String
        Dim tgl = DateTime.Now.ToString("yyyyMMdd")
        Dim urutan As Integer = 1

        Try
            cmd = New OdbcCommand("SELECT MAX(id_entrypembelian) FROM tbl_jual WHERE id_entrypembelian LIKE 'TR" & tgl & "%'", conn)
            rd = cmd.ExecuteReader()
            If rd.Read() AndAlso Not IsDBNull(rd(0)) Then
                Dim lastId As String = rd(0).ToString()
                Dim lastNo As Integer = Integer.Parse(lastId.Substring(10))
                urutan = lastNo + 1
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal ambil ID transaksi: " & ex.Message)
        End Try

        Return "TR" & tgl & urutan.ToString("D3")
    End Function
    Private Sub SimpanTransaksi()
        If String.IsNullOrEmpty(TextBox1.Text) OrElse
       String.IsNullOrEmpty(TextBox3.Text) OrElse
       String.IsNullOrEmpty(TextBox5.Text) OrElse
       String.IsNullOrEmpty(TextBox6.Text) OrElse
       String.IsNullOrEmpty(TextBox7.Text) Then
            MessageBox.Show("Harap lengkapi semua data sebelum menyimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Pastikan koneksi terbuka
            Call Koneksi()

            ' Format tanggal
            Dim tanggalFormatted As String = DateTime.ParseExact(TextBox3.Text, "yyyy-MM-dd", Nothing).ToString("yyyy-MM-dd")

            ' SQL Insert
            Dim sql As String = "INSERT INTO tbl_jual (no_transaksi, id_entrypembelian, tanggal, grand_total, dibayar, kembalian, kasir) VALUES (?, ?, ?, ?, ?, ?, ?)"
            Dim cmd As New OdbcCommand(sql, conn)

            ' Isi parameter
            cmd.Parameters.AddWithValue("?", TextBox1.Text)
            cmd.Parameters.AddWithValue("?", id_entry_aktif)
            cmd.Parameters.AddWithValue("?", tanggalFormatted)
            cmd.Parameters.AddWithValue("?", Integer.Parse(TextBox7.Text.Replace(",", "")))
            cmd.Parameters.AddWithValue("?", Integer.Parse(TextBox5.Text.Replace(",", "")))
            cmd.Parameters.AddWithValue("?", Integer.Parse(TextBox6.Text.Replace(",", "")))
            cmd.Parameters.AddWithValue("?", Environment.UserName) ' Ganti jika ada input kasir manual

            ' Eksekusi query
            cmd.ExecuteNonQuery()

            MessageBox.Show("Transaksi berhasil disimpan ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset input
            TextBox1.Text = GenerateNoTransaksi()
            id_entry_aktif = GenerateIDTransaksi()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            DataGridView1.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Tampil_Penjualan()
        Dim da As New OdbcDataAdapter("SELECT r.id_barang, b.nama_barang, b.jenis_barang, b.satuan_barang, b.harga_jual, r.qty, r.total_harga FROM tbl_rinci_jual r JOIN tbl_barang b ON r.id_barang = b.id_barang WHERE r.id_entrypembelian='" & id_entry_aktif & "'", conn)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.AutoGenerateColumns = True
        ' Hitung total
        Dim totalSeluruh As Integer = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                totalSeluruh += Val(row.Cells("total_harga").Value)
            End If
        Next
        TextBox7.Text = totalSeluruh.ToString("N0")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Input_Penjualan.id_entry = id_entry_aktif ' Kirim ID aktif ke form input
        Form_Input_Penjualan.ShowDialog()
        Tampil_Penjualan()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub
    Private Sub HitungKembalian()
        Dim totalPembelian As Integer = 0
        Dim uangDiberikan As Integer = 0

        ' Ambil nilai dari TextBox7 (total pembelian)
        Integer.TryParse(TextBox7.Text.Replace(",", ""), totalPembelian)

        ' Ambil nilai dari TextBox5 (uang dari pelanggan)
        Integer.TryParse(TextBox5.Text.Replace(",", ""), uangDiberikan)

        ' Hitung kembalian dan tampilkan di TextBox6
        Dim kembalian As Integer = uangDiberikan - totalPembelian
        TextBox6.Text = kembalian.ToString("N0")
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        HitungKembalian()
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        Dim uang As Integer
        If Integer.TryParse(TextBox5.Text.Replace(",", ""), uang) Then
            TextBox5.Text = uang.ToString("N0")
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox2.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SimpanTransaksi()
    End Sub
End Class
