Imports System.Data.SqlClient
Public Class Itemaddsub
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select name from sysobjects where xtype='u'  and name <> 'dtproperties' and name like '" & Items.code & "%'  and name <> '" & Items.code & "' order by name asc"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        con.Open()
        cmd.CommandText = "insert into " & dt.Rows(Items.DataGridView2.CurrentRow.Index).Item("Name") & " values (@code,@name)"
        cmd.Parameters.AddWithValue("@code", TextBox1.Text)
        cmd.Parameters.AddWithValue("@name", TextBox2.Text)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from " & dt.Rows(Items.DataGridView2.CurrentRow.Index).Item("Name")
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        Items.DataGridView3.DataSource = du
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Itemaddsub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class