Imports System.Data.SqlClient
Public Class Labelling
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public ins As Boolean
    Public itcode As String
    Public code As String
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        itcode = ComboBox1.Text(0) & ComboBox1.Text(1)
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select * from [" & itcode & "]"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        ComboBox2.DataSource = dt
        ComboBox2.ValueMember = "Code"
        ComboBox2.DisplayMember = "Name"
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        For j = 0 To ListBox1.Items.Count - 1
            ListBox1.Items.Remove(ListBox1.Items(0))
        Next
        Dim du As New DataTable
        con.Open()
        Try

            cmd.CommandText = "select *  from " & ComboBox2.SelectedValue.ToString
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(du)
        Catch ex As Exception
            cmd.CommandText = "select name from sysobjects where xtype='u'  and name <> 'dtproperties' and name like '" & ComboBox2.SelectedValue.ToString & "%' and name <> '" & ComboBox2.SelectedValue.ToString & "' order by name asc"
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(du)
        End Try
        con.Close()
        For i = 0 To du.Rows.Count - 1
            ListBox1.Items.Add(du.Rows(i).Item(0))
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex > 0 Then
            Dim temp As String = ListBox1.Items(ListBox1.SelectedIndex - 1)
            ListBox1.Items(ListBox1.SelectedIndex - 1) = ListBox1.Items(ListBox1.SelectedIndex)
            ListBox1.Items(ListBox1.SelectedIndex) = temp
            ListBox1.SetSelected(ListBox1.SelectedIndex - 1, True)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
            Dim temp As String = ListBox1.Items(ListBox1.SelectedIndex + 1)
            ListBox1.Items(ListBox1.SelectedIndex + 1) = ListBox1.Items(ListBox1.SelectedIndex)
            ListBox1.Items(ListBox1.SelectedIndex) = temp
            ListBox1.SetSelected(ListBox1.SelectedIndex + 1, True)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        con.Open()
        Try
            cmd.CommandText = "create table " & ComboBox2.SelectedValue.ToString & " (Name varchar(50))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            cmd.CommandText = "drop table " & ComboBox2.SelectedValue.ToString
            cmd.ExecuteNonQuery()
            cmd.CommandText = "create table " & ComboBox2.SelectedValue.ToString & " (Name varchar(50))"
            cmd.ExecuteNonQuery()
        End Try
        con.Close()
        con.Open()
        For i As Integer = 0 To ListBox1.Items.Count - 1
            cmd.CommandText = "insert into " & ComboBox2.SelectedValue.ToString & " values(@val)"
            cmd.Parameters.AddWithValue("@val", ListBox1.Items(i).ToString)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Next
        con.Close()
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Labelling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class