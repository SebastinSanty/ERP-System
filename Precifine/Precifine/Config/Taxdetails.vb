Imports System.Data.SqlClient
Public Class Taxdetails
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Private Sub Taxdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        loadgrid(dt)
        If Tax.ins = False Then
            TextBox1.Enabled = False
            Dim row As Integer = Tax.DataGridView1.CurrentRow.Index
            TextBox1.Text = dt.Rows(row).Item(0)
            TextBox2.Text = dt.Rows(row).Item(1)
            TextBox3.Text = dt.Rows(row).Item(2)
            TextBox4.Text = dt.Rows(row).Item(3)
            TextBox5.Text = dt.Rows(row).Item(4)
            TextBox6.Text = dt.Rows(row).Item(5)
        Else
            TextBox1.Enabled = True
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
        End If
    End Sub
    Private Sub loadgrid(ByRef dt As DataTable)

        con.Open()
        cmd.CommandText = "select * from Tax"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If Tax.ins = False Then
            cmd.CommandText = "update Tax set Name=@name, Prcent=@per, Surcharge=@sur, Note=@note, FormName=@fname where Code=@ui"
        Else
            cmd.CommandText = "insert into Tax values(@ui,@name,@per,@sur,@note,@fname)"
        End If

        cmd.Parameters.AddWithValue("@ui", TextBox1.Text)
        cmd.Parameters.AddWithValue("@name", TextBox2.Text)
        cmd.Parameters.AddWithValue("@per", TextBox3.Text)
        cmd.Parameters.AddWithValue("@sur", TextBox4.Text)
        cmd.Parameters.AddWithValue("@note", TextBox5.Text)
        cmd.Parameters.AddWithValue("@fname", TextBox6.Text)

        cmd.Connection = con

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select Code,Name from Tax"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        Tax.DataGridView1.DataSource = du
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class