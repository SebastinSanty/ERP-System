Imports System.Data.SqlClient
Public Class Itemsel
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Public ok As Boolean
    Public row As Integer

    Private Sub Itemsel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open()
        cmd.CommandText = "select * from ItemProperties"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        Dim itcode As String = "C" & Items.itcode
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item(itcode) = 1 Then
                ListBox1.Items.Add(dt.Rows(i).Item("Name"))
            End If
        Next
       
    End Sub

   

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        row = ListBox1.SelectedIndex
        con.Open()
        cmd.CommandText = "create table " & Items.code & ListBox1.Items(row) & "(Code varchar(50), Name varchar(50))"
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        Dim dt As New DataTable
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from [" & Items.itcode & "]"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        Items.code = du.Rows(Items.DataGridView1.CurrentRow.Index).Item("Code")
        con.Open()
        cmd.CommandText = "select name from sysobjects where xtype='u'  and name <> 'dtproperties' and name like '" & Items.code & "%'  and name <> '" & Items.code & "' order by name asc"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        Items.DataGridView2.DataSource = dt
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

End Class