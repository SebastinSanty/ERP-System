Imports System.Data.SqlClient
Public Class ItemPropertiesdetails
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Private Sub ItemPropertiesdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        loadgrid(dt)
        If ItemProperties.ins = False Then
            TextBox2.Enabled = False
            Dim row As Integer = ItemProperties.DataGridView1.CurrentRow.Index
            If dt.Rows(row).Item(0) = 1 Then
                CheckBox1.CheckState = 1
            End If
            If dt.Rows(row).Item(1) = 1 Then
                CheckBox2.CheckState = 1
            End If
            If dt.Rows(row).Item(2) = 1 Then
                CheckBox3.CheckState = 1
            End If
            If dt.Rows(row).Item(3) = 1 Then
                CheckBox4.CheckState = 1
            End If
            If dt.Rows(row).Item(4) = 1 Then
                CheckBox5.CheckState = 1
            End If
            If dt.Rows(row).Item(5) = 1 Then
                CheckBox6.CheckState = 1
            End If
            If dt.Rows(row).Item(6) = 1 Then
                CheckBox7.CheckState = 1
            End If
            If dt.Rows(row).Item(7) = 1 Then
                CheckBox8.CheckState = 1
            End If
            If dt.Rows(row).Item(8) = 1 Then
                CheckBox9.CheckState = 1
            End If
            If dt.Rows(row).Item(9) = 1 Then
                CheckBox10.CheckState = 1
            End If
            TextBox2.Text = dt.Rows(row).Item(10)
        Else
            TextBox2.Enabled = True
            TextBox2.Clear()
        End If

    End Sub
    Private Sub loadgrid(ByRef dt As DataTable)

        con.Open()
        cmd.CommandText = "select * from ItemProperties"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If ItemProperties.ins = False Then
            cmd.CommandText = "update ItemProperties set C01=@1, C02=@2, C03=@3, C04=@4, C05=@5, C06=@6, C07=@7, C08=@8, C09=@9 where Name=@un"
        Else
            cmd.CommandText = "insert into ItemProperties values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@un)"
        End If
        Dim arr() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        If CheckBox1.CheckState = 1 Then
            arr(0) = 1
        End If
        If CheckBox2.CheckState = 1 Then
            arr(1) = 1
        End If
        If CheckBox3.CheckState = 1 Then
            arr(2) = 1
        End If
        If CheckBox4.CheckState = 1 Then
            arr(3) = 1
        End If
        If CheckBox5.CheckState = 1 Then
            arr(4) = 1
        End If
        If CheckBox6.CheckState = 1 Then
            arr(5) = 1
        End If
        If CheckBox7.CheckState = 1 Then
            arr(6) = 1
        End If
        If CheckBox8.CheckState = 1 Then
            arr(7) = 1
        End If
        If CheckBox9.CheckState = 1 Then
            arr(8) = 1
        End If
        If CheckBox10.CheckState = 1 Then
            arr(9) = 1
        End If
        cmd.Parameters.AddWithValue("@1", arr(0))
        cmd.Parameters.AddWithValue("@2", arr(1))
        cmd.Parameters.AddWithValue("@3", arr(2))
        cmd.Parameters.AddWithValue("@4", arr(3))
        cmd.Parameters.AddWithValue("@5", arr(4))
        cmd.Parameters.AddWithValue("@6", arr(5))
        cmd.Parameters.AddWithValue("@7", arr(6))
        cmd.Parameters.AddWithValue("@8", arr(7))
        cmd.Parameters.AddWithValue("@9", arr(8))
        cmd.Parameters.AddWithValue("@10", arr(9))
        cmd.Parameters.AddWithValue("@un", TextBox2.Text)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select Name from ItemProperties"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        ItemProperties.DataGridView1.DataSource = du
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class