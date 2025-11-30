Imports System.Data.Odbc

Module Module1
    'DEKLARASI GLOBAL'
    Public conn As OdbcConnection
    Public cmd As OdbcCommand
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public rd As OdbcDataReader

    Public Sub Koneksi() 'membuka koneksi database ODBC ke DSN= dsn_penjualan'
        conn = New OdbcConnection("DSN=dsn_penjualandb") ' DSN sesuai dari ODBC Anda
        If conn.State = ConnectionState.Closed Then 'untuk mengecek apakah kownksi masih tertutup'
            conn.Open() ' fungsi ini digunakan setiap kali saat ingin berinteraksi dengan Database'
        End If
    End Sub
End Module
