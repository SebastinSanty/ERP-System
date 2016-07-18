Imports System.Data.SqlClient
Public Class QuotationMenu
    Dim con As New SqlConnection(entryconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public ins As Boolean
    Private Sub QuotationMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select QuoteNo,CustName,QDate,Total from QuoteMaster"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ins = True
        Quotation.Show()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        ins = False
        Quotation.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        con.Open()
        Dim arr() As String = Split(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value, "/")
        Dim daa() As String = Split(arr(2), "-")
        Dim quno As String = arr(0) & arr(1) & daa(0) & daa(1)
        cmd.CommandText = "delete from QuoteMaster where  = [" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "]"
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.CommandText = "drop table " & quno
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class