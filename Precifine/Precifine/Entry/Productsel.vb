Imports System.Data.SqlClient
Public Class Productsel
    Dim con As New SqlConnection(entryconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProductIdentifier.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        con.Open()
        cmd.CommandText = "insert into " & Quotation.qno & " values(@code,@dscr,@qty,@unit,@rate,@disc,@amt)"
        cmd.Parameters.AddWithValue("@code", TextBox1.Text)
        cmd.Parameters.AddWithValue("@dscr", TextBox2.Text)
        cmd.Parameters.AddWithValue("@qty", TextBox3.Text)
        cmd.Parameters.AddWithValue("@unit", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@rate", TextBox4.Text)
        cmd.Parameters.AddWithValue("@disc", TextBox5.Text)
        cmd.Parameters.AddWithValue("@amt", TextBox6.Text)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select * from " & Quotation.qno
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        Quotation.DataGridView1.DataSource = dt
        Me.Close()
    End Sub

    Private Sub Productsel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim du As New DataTable
        Dim conn As New SqlConnection(connString)
        conn.Open()
        cmd.CommandText = "select * from Units"
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(du)
        conn.Close()
        ComboBox1.DataSource = du
        ComboBox1.DisplayMember = "ShortName"
        ComboBox1.ValueMember = "ShortName"

    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged
        Dim sum As Double = Val(TextBox3.Text) * Val(TextBox4.Text)
        TextBox6.Text = sum - (Val(TextBox5.Text) / 100 * sum)
    End Sub
End Class