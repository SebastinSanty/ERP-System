Imports System.Data.SqlClient
Public Class Suppliers
    Dim ins As Boolean
    Dim con As New SqlConnection(connString)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Private Sub Suppliers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select Code,Name from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
        Dim dk As New DataTable
        con.Open()
        cmd.CommandText = "select * from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dk)
        con.Close()
        Loadbox(dk)
        code.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim dk As New DataTable
        con.Open()
        cmd.CommandText = "select * from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dk)
        con.Close()
        Loadbox(dk)
        code.Enabled = False
        Button4.Enabled = True
    End Sub
    Private Sub Loadbox(ByVal dt As DataTable)

        Dim row As Integer = DataGridView1.CurrentRow.Index
        If row <= dt.Rows.Count - 1 Then
            code.Text = dt.Rows(row).Item(0)
            nametxt.Text = dt.Rows(row).Item(1)
            cont.Text = dt.Rows(row).Item(2)
            desig.Text = dt.Rows(row).Item(3)
            add.Text = dt.Rows(row).Item(4)
            city.Text = dt.Rows(row).Item(5)
            pin.Text = dt.Rows(row).Item(6)
            state.Text = dt.Rows(row).Item(7)
            phno.Text = dt.Rows(row).Item(8)
            email.Text = dt.Rows(row).Item(9)
            PANno.Text = dt.Rows(row).Item(10)
            stno.Text = dt.Rows(row).Item(11)
            cstno.Text = dt.Rows(row).Item(12)
            tax.Text = dt.Rows(row).Item(13)
            vend.Text = dt.Rows(row).Item(14)
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ins = True
        Button2.Enabled = False
        code.Clear()
        nametxt.Clear()
        cont.Clear()
        PANno.Clear()
        desig.Clear()
        add.Clear()
        city.Clear()
        pin.Clear()
        state.Clear()
        phno.Clear()
        email.Clear()
        stno.Clear()
        cstno.Clear()
        vend.Clear()
        code.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        con.Open()
        If ins = True Then
            cmd.CommandText = "insert into Suppliers values(@code,@name,@cont,@desig,@add,@city,@pin,@state,@phno,@email,@pan,@stno,@cstno,@tax,@vend)"
        Else
            cmd.CommandText = "update Suppliers set Name=@name,Contact=@cont,Designation=@desig,Address=@add,City=@city,Pin=@pin,State=@state,Phone=@phno,eMail=@email,PANNo=@pan, GSTNo=@stno,CSTNo=@cstno,Tax=@tax,CompCode=@vend where Code=@code"
        End If
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@code", code.Text)
        cmd.Parameters.AddWithValue("@pan", PANno.Text)
        cmd.Parameters.AddWithValue("@name", nametxt.Text)
        cmd.Parameters.AddWithValue("@cont", cont.Text)
        cmd.Parameters.AddWithValue("@desig", desig.Text)
        cmd.Parameters.AddWithValue("@add", add.Text)
        cmd.Parameters.AddWithValue("@city", city.Text)
        cmd.Parameters.AddWithValue("@pin", pin.Text)
        cmd.Parameters.AddWithValue("@state", state.Text)
        cmd.Parameters.AddWithValue("@phno", phno.Text)
        cmd.Parameters.AddWithValue("@email", email.Text)
        cmd.Parameters.AddWithValue("@stno", stno.Text)
        cmd.Parameters.AddWithValue("@cstno", cstno.Text)
        cmd.Parameters.AddWithValue("@tax", tax.Text)
        cmd.Parameters.AddWithValue("@vend", vend.Text)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        ins = False
        Button2.Enabled = True

        con.Open()
        cmd.CommandText = "select Code,Name from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
        Dim dk As New DataTable
        con.Open()
        cmd.CommandText = "select * from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dk)
        con.Close()
        Loadbox(dk)
        code.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select Code,Name from Suppliers where Name like '" & TextBox1.Text & "%'"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "delete from Suppliers where Code = @code"
        cmd.Parameters.AddWithValue("@code", DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        con.Open()
        cmd.CommandText = "select Code,Name from Suppliers"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        DataGridView1.DataSource = dt
        code.Clear()
        nametxt.Clear()
        PANno.Clear()
        cont.Clear()
        desig.Clear()
        add.Clear()
        city.Clear()
        pin.Clear()
        state.Clear()
        phno.Clear()
        email.Clear()
        stno.Clear()
        cstno.Clear()
        vend.Clear()
    End Sub
End Class