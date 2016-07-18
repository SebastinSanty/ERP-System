Imports System.Data.SqlClient
Public Class ItemProperties
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public ins As Boolean
    Private Sub ItemProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select Name from ItemProperties"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        ins = False

        ItemPropertiesdetails.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ins = True
        ItemPropertiesdetails.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "delete from ItemProperties where Name = @name"
        cmd.Parameters.AddWithValue("@name", DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        con.Open()
        cmd.CommandText = "select Name from ItemProperties"
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