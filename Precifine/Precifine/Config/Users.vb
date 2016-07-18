Imports System.Data.SqlClient

Public Class Users
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public ins As Boolean

    Private Sub Users_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select UserID,Name from Users"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt

        'ListView1.Clear()
        'Dim size As Integer = 2
        'Dim itemCollection(size) As String

        'Dim i, j As Integer

        'ListView1.Columns.Add(dt.Columns(1).ColumnName.ToString)
        'ListView1.Columns.Add(dt.Columns(3).ColumnName.ToString)
        'For i = 0 To dt.Rows.Count - 1
        '    itemCollection(0) = dt.Rows(i)(1).ToString
        '    Dim lvi As New ListViewItem(itemCollection)
        '    ListView1.Items.Add(lvi)
        'Next
        'For i = 0 To dt.Rows.Count - 1
        '    itemCollection(1) = dt.Rows(i)(3).ToString
        '    Dim lvi As New ListViewItem(itemCollection)
        '    ListView1.Items.Add(lvi)
        'Next
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        ins = False

        Userdetails.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ins = True
        Userdetails.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "delete from Users where Name = @name"
        cmd.Parameters.AddWithValue("@name", DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        con.Open()
        cmd.CommandText = "select UserID,Name from Users"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
       

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class