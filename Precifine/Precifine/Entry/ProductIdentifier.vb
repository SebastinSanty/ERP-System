Imports System.Data.SqlClient
Public Class ProductIdentifier
    Dim con As New SqlConnection(itemconstring)
    Dim da As New SqlDataAdapter
    Dim da1 As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public itcode As String
    Dim counter As Integer
    Dim rowofname As Integer
    Dim cc As Integer = 0

    Private Sub ProductIdentifier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Productsel.TextBox1.Text <> "" Then

        End If
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from ItemTypes"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        ComboBox1.DataSource = du
        ComboBox1.ValueMember = "ItemTypes"
        ComboBox1.DisplayMember = "ItemTypes"
        For i = 1 To 9
            Dim cmb = DirectCast(Me.Controls("ComboBox" & (i + 2) & ""), ComboBox)
            cmb.Visible = False
            Dim lbl = DirectCast(Me.Controls("Label" & (i + 2) & ""), Label)
            lbl.Text = ""
        Next
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        For i = 1 To 9
            Dim cmb = DirectCast(Me.Controls("ComboBox" & (i + 2) & ""), ComboBox)
            cmb.Visible = False
            Dim lbl = DirectCast(Me.Controls("Label" & (i + 2) & ""), Label)
            lbl.Text = ""
        Next

        counter += 1
        If counter > 2 Then
            Dim du As New DataTable
            con.Open()
            cmd.CommandText = "select * from " & ComboBox2.SelectedValue.ToString
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(du)
            con.Close()
            rowofname = du.Rows.Count
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Label Then
                    For i = 1 To rowofname
                        If ctrl.Name = "Label" & (i + 2) Then
                            ctrl.Text = du.Rows(i - 1).Item(0).ToString
                        End If
                    Next
                End If
            Next
            For i = 1 To rowofname
                Dim cmb = DirectCast(Me.Controls("ComboBox" & (i + 2) & ""), ComboBox)
                Dim dm As New DataTable
                con.Open()
                cmd.CommandText = "select * from " & du.Rows(i - 1).Item(0).ToString
                cmd.Connection = con
                da.SelectCommand = cmd
                da.Fill(dm)
                con.Close()
                cmb.Visible = True
                cmb.DataSource = dm
                cmb.DisplayMember = "Name"
                cmb.ValueMember = "Code"
            Next
            
        End If
    End Sub
    Private Sub ComboBoxIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged, ComboBox4.SelectedIndexChanged, ComboBox5.SelectedIndexChanged, ComboBox6.SelectedIndexChanged, ComboBox7.SelectedIndexChanged, ComboBox8.SelectedIndexChanged, ComboBox9.SelectedIndexChanged, ComboBox10.SelectedIndexChanged, ComboBox11.SelectedIndexChanged
        If counter > 3 Then
            Dim str As String = ""
            For i = 1 To rowofname
                Dim cmb = DirectCast(Me.Controls("ComboBox" & (i + 2) & ""), ComboBox)
                str = str + cmb.SelectedValue.ToString
            Next

            str = str + vbNewLine

            For i = 1 To rowofname
                Dim cmb = DirectCast(Me.Controls("ComboBox" & (i + 2) & ""), ComboBox)
                str = str + cmb.Text + " "
            Next
            TextBox1.Text = str
        End If
    End Sub

    Private Sub ComboBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseClick
        cc += 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        itcode = ComboBox1.Text(0) & ComboBox1.Text(1)
        If cc > 0 Then
            Dim dk As New DataTable
            con.Open()
            cmd.CommandText = "select Code,Name from [" & itcode & "]"
            cmd.Connection = con
            da1.SelectCommand = cmd
            da1.Fill(dk)
            con.Close()
            ComboBox2.DataSource = dk
            ComboBox2.ValueMember = "Code"
            ComboBox2.DisplayMember = "Name"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim arr() As String = Split(TextBox1.Text, vbNewLine)
        Productsel.TextBox1.Text = arr(0)
        Productsel.TextBox2.Text = arr(1)
        Me.Close()
    End Sub
End Class