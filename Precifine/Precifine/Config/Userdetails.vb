Imports System.Data.SqlClient
Public Class Userdetails
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Userdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        loadgrid(dt)
        If Users.ins = False Then
            TextBox2.Enabled = False
            Dim row As Integer = Users.DataGridView1.CurrentRow.Index
            ComboBox1.Text = dt.Rows(row).Item(0)
            TextBox1.Text = dt.Rows(row).Item(1)
            TextBox2.Text = dt.Rows(row).Item(2)
            TextBox3.Text = dt.Rows(row).Item(3)
        Else
            TextBox2.Enabled = True
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        End If
       
    End Sub
    Private Sub loadgrid(ByRef dt As DataTable)

        con.Open()
        cmd.CommandText = "select * from Users"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If Users.ins = False Then
            cmd.CommandText = "update Users set UserType=@ut,UserID=@ui,Password=@pa where Name=@un"
        Else
            cmd.CommandText = "insert into Users values(@ut,@ui,@un,@pa)"
        End If
        cmd.Parameters.AddWithValue("@ut", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@ui", TextBox1.Text)
        cmd.Parameters.AddWithValue("@un", TextBox2.Text)
        cmd.Parameters.AddWithValue("@pa", TextBox3.Text)
        cmd.Connection = con

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select UserID,Name from Users"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        Users.DataGridView1.DataSource = du
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class