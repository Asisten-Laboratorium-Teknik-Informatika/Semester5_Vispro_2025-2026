Public Class Form_Menu
    Private Sub Form_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lbl_level.Text = "Kasir" Then
            Button6.Enabled = True
            Button2.Enabled = False
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        End

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Penjualan.ShowDialog()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Form_Barang.ShowDialog()

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Form_Piutang.ShowDialog()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub lbl_nama_Click(sender As Object, e As EventArgs) Handles lbl_nama.Click

    End Sub
End Class