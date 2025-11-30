Imports System.Data.Odbc
Public Class Form_Barang
    Sub tampil_barang()
        cmd = New OdbcCommand("select * from tbl_barang", conn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4), rd(5), rd(6))
        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Form_Barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call tampil_barang()

    End Sub

    Private Sub TextCari_TextChanged(sender As Object, e As EventArgs) Handles TextCari.TextChanged
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            Call Koneksi()
        End If

        Dim searchText As String = "%" & TextCari.Text & "%"
        cmd = New OdbcCommand("SELECT * FROM tbl_barang WHERE id_barang LIKE ?", conn)
        cmd.Parameters.AddWithValue("?", searchText)

        rd = cmd.ExecuteReader()
        DataGridView1.Rows.Clear()
        While rd.Read()
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3), rd(4), rd(5), rd(6))
        End While
        rd.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_Input_Barang.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class