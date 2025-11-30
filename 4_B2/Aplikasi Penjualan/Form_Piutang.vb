Imports System.Data.Odbc
Public Class Form_Piutang
    Sub tampil_piutang()
        cmd = New OdbcCommand("select * from tbl_utang", conn)
        rd = cmd.ExecuteReader
        DataGridView1.Rows.Clear()
        Do While rd.Read = True
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3))
        Loop
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_Input_Piutang.ShowDialog()
    End Sub

    Private Sub Form_Piutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        DataGridView1.AutoGenerateColumns = True
        Call tampil_piutang()
        With DataGridView1
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.Blue
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextCari_TextChanged(sender As Object, e As EventArgs) Handles TextCari.TextChanged
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            Call Koneksi()
        End If

        Dim searchText As String = "%" & TextCari.Text & "%"
        cmd = New OdbcCommand("SELECT * FROM tbl_utang WHERE id_utang LIKE ?", conn)
        cmd.Parameters.AddWithValue("?", searchText)

        rd = cmd.ExecuteReader()
        DataGridView1.Rows.Clear()
        While rd.Read()
            DataGridView1.Rows.Add(rd(0), rd(1), rd(2), rd(3))
        End While
        rd.Close()

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class