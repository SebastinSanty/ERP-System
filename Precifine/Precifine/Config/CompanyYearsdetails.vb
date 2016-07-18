Imports System.Data.SqlClient
Public Class CompanyYearsdetails
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Private Sub CompanyYearsdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        loadgrid(dt)
        If CompanyYears.ins = False Then
            TextBox1.Enabled = False
            Dim row As Integer = CompanyYears.DataGridView1.CurrentRow.Index
            TextBox1.Text = dt.Rows(row).Item(0)
            TextBox2.Text = dt.Rows(row).Item(1)
            TextBox3.Text = dt.Rows(row).Item(2)
        Else
            TextBox1.Enabled = True
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub
    Private Sub loadgrid(ByRef dt As DataTable)

        con.Open()
        cmd.CommandText = "select * from CompanyYears"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If CompanyYears.ins = False Then
            cmd.CommandText = "update CompanyYears set StartDate=@un, EndDate=@pa where Code=@ui"
        Else
            cmd.CommandText = "insert into CompanyYears values(@ui,@un,@pa)"
        End If
        cmd.Parameters.AddWithValue("@ui", TextBox1.Text)
        cmd.Parameters.AddWithValue("@un", TextBox2.Text)
        cmd.Parameters.AddWithValue("@pa", TextBox3.Text)
        cmd.Connection = con

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from CompanyYears"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        CompanyYears.DataGridView1.DataSource = du
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class