Imports System.Data.SqlClient

Public Class frmlog
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim cmd As New SqlCommand
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim flag As Boolean
        For Each rows As DataRow In dt.Rows
            If rows.Item(1) = TextBox1.Text And rows.Item(3) = TextBox2.Text Then
                flag = True
            End If
        Next
        If flag = True Then
            Me.Hide()
            Main.Show()
        Else
            MsgBox("Incorrect Username and Password")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()

        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim auth As Boolean
        Dim flag As Boolean
        For Each rows As DataRow In dt.Rows
            If rows.Item(0) = "Admin" And rows.Item(1) = TextBox4.Text And rows.Item(3) = TextBox3.Text Then
                flag = True
            ElseIf rows.Item(0) <> "Admin" And rows.Item(1) = TextBox4.Text And rows.Item(3) = TextBox3.Text Then
                auth = True
            End If
        Next
        If flag = True Then
            Me.Hide()
            Config.Show()
        ElseIf auth = True Then
            MsgBox("You are not authorized to enter. Please enter from Enter from Entry Module")
            TextBox4.Clear()
            TextBox3.Clear()
            TextBox4.Focus()
        Else
            MsgBox("Incorrect Username and Password")
            TextBox4.Clear()
            TextBox3.Clear()
            TextBox4.Focus()

        End If
    End Sub

    Private Sub frmlog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        con.Open()
        cmd.CommandText = "select * from Users"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
    End Sub

 
End Class
