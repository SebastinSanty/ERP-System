Imports System.Data.SqlClient
Public Class Custsel
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand

    Private Sub Custsel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select Code,Name from Customers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select * from Customers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        Quotation.TextBox2.Text = dt.Rows(DataGridView1.CurrentRow.Index).Item(0).ToString
        Quotation.TextBox3.Text = dt.Rows(DataGridView1.CurrentRow.Index).Item(3).ToString
        Quotation.Label4.Text = dt.Rows(DataGridView1.CurrentRow.Index).Item(2).ToString
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select Code,Name from Customers where Name like '" & TextBox1.Text & "%'"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
    End Sub
End Class