Imports System.Data.SqlClient
Public Class Items
    Dim con As New SqlConnection(itemconstring)
    Dim conp As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public ins As Boolean
    Public itcode As String
    Public code As String
    
    Private Sub Items_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        Button8.Enabled = True
        Button5.Enabled = False
        ComboBox2.Enabled = False
       
        Dim dt As New DataTable
        conp.Open()
        cmd.CommandText = "select * from Units"
        cmd.Connection = conp
        da.SelectCommand = cmd
        da.Fill(dt)
        conp.Close()
        ComboBox2.DataSource = dt
        ComboBox2.ValueMember = "ShortName"
        ComboBox2.DisplayMember = "ShortName"
    End Sub

    
 
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        itcode = ComboBox1.Text(0) & ComboBox1.Text(1)
        Dim dk As New DataTable
        'con.Open()
        GroupBox1.Text = ComboBox1.Text
        cmd.CommandText = "select Code,Name from [" & itcode & "]"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dk)
        con.Close()
        DataGridView1.DataSource = dk
    End Sub

    
    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim dt As New DataTable
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from [" & itcode & "]"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        ComboBox2.Text = du.Rows(DataGridView1.CurrentRow.Index).Item(2).ToString
        code = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        con.Open()
        cmd.CommandText = "select name from sysobjects where xtype='u'  and name <> 'dtproperties' and name like '" & code & "%' and name <> '" & code & "' order by name asc"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView2.DataSource = dt
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "insert into [" & itcode & "] values (@name,@code,@unit)"
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        cmd.Parameters.AddWithValue("@code", TextBox2.Text)
        cmd.Parameters.AddWithValue("@unit", ComboBox2.SelectedValue)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        con.Open()
        cmd.CommandText = "select Code,Name from [" & itcode & "]"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        Button8.Enabled = True
        Button5.Enabled = False
        ComboBox2.Enabled = False

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        Button8.Enabled = False
        Button5.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DataGridView2.ColumnCount > 0 Then
            Itemsel.Show()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        con.Open()
        cmd.CommandText = "drop table " & DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select name from sysobjects where xtype='u'  and name <> 'dtproperties' and name like '" & code & "%' and name <> '" & code & "' order by name asc"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        DataGridView2.DataSource = du
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from " & DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        DataGridView3.DataSource = du
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Itemaddsub.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        con.Open()
        cmd.CommandText = "delete from " & DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value & " where Code = @code"
        cmd.Parameters.AddWithValue("@code", DataGridView3.Rows(DataGridView3.CurrentRow.Index).Cells(0).Value)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()

        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from " & DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        DataGridView3.DataSource = du
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Labelling.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        For i = 0 To DataGridView2.Rows.Count - 1
            cmd.CommandText = "drop table " & DataGridView2.Rows(i).Cells(0).Value
            cmd.Connection = con
            cmd.ExecuteNonQuery()
        Next
        con.Close()
        con.Open()
        cmd.CommandText = "drop table " & TextBox2.Text
        cmd.ExecuteNonQuery()
        con.Close()
        con.Open()
        cmd.CommandText = "delete from [" & itcode & "] where Name = " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub
End Class