﻿Imports System.Data.SqlClient
Public Class ReferredBydetails
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Private Sub ReferredBydetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        loadgrid(dt)
        If ReferredBy.ins = False Then
            TextBox1.Enabled = False
            Dim row As Integer = ReferredBy.DataGridView1.CurrentRow.Index
            TextBox1.Text = dt.Rows(row).Item(0)
            TextBox2.Text = dt.Rows(row).Item(1)
        Else
            TextBox1.Enabled = True
            TextBox1.Clear()
            TextBox2.Clear()
        End If

    End Sub
    Private Sub loadgrid(ByRef dt As DataTable)

        con.Open()
        cmd.CommandText = "select * from ReferredBy"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If ReferredBy.ins = False Then
            cmd.CommandText = "update ReferredBy set Description=@un where Code=@ui"
        Else
            cmd.CommandText = "insert into ReferredBy values(@ui,@un)"
        End If

        cmd.Parameters.AddWithValue("@ui", TextBox1.Text)
        cmd.Parameters.AddWithValue("@un", TextBox2.Text)

        cmd.Connection = con

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from ReferredBy"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        ReferredBy.DataGridView1.DataSource = du
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class