Imports System.Data.SqlClient
Public Class Quotation
    Dim con As New SqlConnection(entryconstring)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public qno As String
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub Quotation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
    End Sub

    Private Sub Quotation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        qno = "MGBQS" & QuotationMenu.DataGridView1.Rows.Count & "1516"
        TextBox1.Enabled = False
        Dim du As New DataTable
        Dim conn As New SqlConnection(connString)
        conn.Open()
        cmd.CommandText = "select * from Signatories"
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(du)
        conn.Close()
        ComboBox4.DataSource = du
        ComboBox4.ValueMember = "Code"
        ComboBox4.DisplayMember = "Code"
        Dim dk As New DataTable
        conn.Open()
        cmd.CommandText = "select * from Tax"
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(dk)
        conn.Close()
        ComboBox5.DataSource = dk
        ComboBox5.ValueMember = "Code"
        ComboBox5.DisplayMember = "Code"
        If QuotationMenu.ins = True Then
            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next
            TextBox1.Text = "MGBQS/" & QuotationMenu.DataGridView1.Rows.Count & "/15-16"
            For i = 1 To 7
                Dim chk = DirectCast(Me.Controls("CheckBox" & i & ""), CheckBox)
                chk.CheckState = 0
            Next
        Else
            loadgrid()
            Dim dt As New DataTable
            con.Open()
            cmd.CommandText = "select * from " & qno
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(dt)
            con.Close()
            DataGridView1.DataSource = dt
        End If

    End Sub
    Private Sub loadgrid()
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select * from QuoteMaster"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        TextBox1.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(0).ToString
        TextBox2.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(1).ToString
        TextBox3.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(2).ToString
        Label4.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(3).ToString
        TextBox4.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(4).ToString
        TextBox5.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(5).ToString
        TextBox6.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(6).ToString
        TextBox7.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(7).ToString
        ComboBox4.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(8).ToString
        TextBox9.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(9).ToString
        Label12.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(11).ToString
        ComboBox1.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(12).ToString
        TextBox10.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(13).ToString
        ComboBox2.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(14).ToString
        TextBox11.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(15).ToString
        TextBox12.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(16).ToString
        TextBox13.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(17).ToString
        ComboBox3.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(18).ToString
        TextBox14.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(19).ToString
        For i = 1 To 5
            Dim chk = DirectCast(Me.Controls("CheckBox" & (i) & ""), CheckBox)
            If dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(i + 19) = 1 Then
                chk.CheckState = 1
            Else
                chk.CheckState = 0
            End If
        Next
        TextBox8.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(25).ToString
        TextBox21.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(26).ToString
        TextBox15.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(27).ToString
        ComboBox5.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(28).ToString
        Label25.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(29).ToString
        TextBox16.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(30).ToString
        Label30.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(31).ToString
        TextBox17.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(32).ToString
        TextBox22.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(33).ToString
        TextBox18.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(34).ToString
        TextBox23.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(35).ToString
        TextBox19.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(36).ToString
        TextBox20.Text = dt.Rows(QuotationMenu.DataGridView1.CurrentRow.Index).Item(37).ToString
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DataGridView1.Columns.Count = 0 Then
            con.Open()
            cmd.CommandText = "select * into " & qno & " from QuoteDataMaster"
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        Productsel.Show()
    End Sub

   
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim dk As New DataTable
        Dim conn As New SqlConnection(connString)
        conn.Open()
        cmd.CommandText = "select * from Tax"
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(dk)
        conn.Close()
        Label25.Text = dk.Rows(ComboBox5.SelectedIndex).Item(2).ToString
        Label30.Text = dk.Rows(ComboBox5.SelectedIndex).Item(3).ToString
        TextBox16.Text = (Val(Label25.Text) / 100) * (Val(TextBox8.Text))
        TextBox17.Text = (Val(Label30.Text) / 100) * (Val(TextBox8.Text))

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Custsel.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.CheckState = 1 Then

            TextBox22.Enabled = True
        Else

            TextBox22.Enabled = False
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.CheckState = 1 Then

            TextBox23.Enabled = True
        Else

            TextBox23.Enabled = False
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        Dim du As New DataTable
        con.Open()
        cmd.CommandText = "select * from " & qno
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(du)
        con.Close()
        Dim sum As Double = 0.0
        For i = 0 To du.Rows.Count - 1
            sum += Val(du.Rows(i).Item("Amt"))
        Next
        TextBox8.Text = sum
        Dim gross As Double = sum
        gross -= Val(TextBox15.Text)
        For i = 16 To 19
            Dim tb = DirectCast(Me.Controls("TextBox" & i & ""), TextBox)
            gross += Val(tb.Text)
        Next
        TextBox20.Text = gross
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged, TextBox16.TextChanged, TextBox17.TextChanged, TextBox18.TextChanged, TextBox19.TextChanged, CheckBox6.CheckStateChanged, CheckBox7.CheckStateChanged
        Dim gross As Double = Val(TextBox8.Text)
        gross -= Val(TextBox15.Text)
        For i = 16 To 19
            If CheckBox6.CheckState = 0 Then
                If i = 18 Then
                    Continue For
                End If
            End If
            If CheckBox7.CheckState = 0 Then
                If i = 19 Then
                    Continue For
                End If
            End If
            Dim tb = DirectCast(Me.Controls("TextBox" & i & ""), TextBox)
            gross += Val(tb.Text)
        Next
        TextBox20.Text = gross
    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged
        TextBox15.Text = (Val(TextBox21.Text) / 100) * (Val(TextBox8.Text))
    End Sub

    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged
        TextBox18.Text = (Val(TextBox22.Text) / 100) * (Val(TextBox8.Text))
    End Sub

    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged
        TextBox19.Text = (Val(TextBox23.Text) / 100) * (Val(TextBox8.Text))
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        con.Open()
        cmd.CommandText = "insert into QuoteMaster values (@qn,@cc,@ct,@cn,@en,@ed,@d,@qd,@sb,@dd,@s,@p,@fq,@de,@sq,@cni,@di,@pa,@si,@tc,@pe,@i,@g,@rp,@gr,@sd,@sda,@t,@tp,@tpa,@sp,@spa,@pf,@pfa,@tr,@tra,@tot)"
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@qn", TextBox1.Text)
        cmd.Parameters.AddWithValue("@cc", TextBox2.Text)
        cmd.Parameters.AddWithValue("@ct", TextBox3.Text)
        cmd.Parameters.AddWithValue("@cn", Label4.Text)
        cmd.Parameters.AddWithValue("@en", TextBox4.Text)
        cmd.Parameters.AddWithValue("@ed", TextBox5.Text)
        cmd.Parameters.AddWithValue("@d", TextBox6.Text)
        cmd.Parameters.AddWithValue("@qd", TextBox7.Text)
        cmd.Parameters.AddWithValue("@sb", ComboBox4.Text)
        cmd.Parameters.AddWithValue("@dd", TextBox9.Text)
        cmd.Parameters.AddWithValue("@s", Label12.Text)
        cmd.Parameters.AddWithValue("@p", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@fq", TextBox10.Text)
        cmd.Parameters.AddWithValue("@de", ComboBox2.Text)
        cmd.Parameters.AddWithValue("@sq", TextBox11.Text)
        cmd.Parameters.AddWithValue("@cni", TextBox12.Text)
        cmd.Parameters.AddWithValue("@di", TextBox13.Text)
        cmd.Parameters.AddWithValue("@pa", ComboBox3.Text)
        cmd.Parameters.AddWithValue("@si", TextBox14.Text)
        Dim arr() As Integer = {0, 0, 0, 0, 0, 0, 0}
        For i = 0 To 6
            Dim chk = DirectCast(Me.Controls("CheckBox" & (i + 1) & ""), CheckBox)
            If chk.CheckState = 1 Then
                arr(i) = 1
            Else
                arr(i) = 0
            End If
        Next
        cmd.Parameters.AddWithValue("@tc", arr(0))
        cmd.Parameters.AddWithValue("@pe", arr(1))
        cmd.Parameters.AddWithValue("@g", arr(2))
        cmd.Parameters.AddWithValue("@i", arr(3))
        cmd.Parameters.AddWithValue("@rp", arr(4))
        'cmd.Parameters.AddWithValue("@", arr(5))
        'cmd.Parameters.AddWithValue("@", arr(6))
        cmd.Parameters.AddWithValue("@gr", TextBox8.Text)
        cmd.Parameters.AddWithValue("@sd", TextBox21.Text)
        cmd.Parameters.AddWithValue("@sda", TextBox15.Text)
        cmd.Parameters.AddWithValue("@t", ComboBox5.Text)
        cmd.Parameters.AddWithValue("@tp", Label25.Text)
        cmd.Parameters.AddWithValue("@tpa", TextBox16.Text)
        cmd.Parameters.AddWithValue("@sp", Label30.Text)
        cmd.Parameters.AddWithValue("@spa", TextBox17.Text)
        cmd.Parameters.AddWithValue("@pf", TextBox22.Text)
        cmd.Parameters.AddWithValue("@pfa", TextBox18.Text)
        cmd.Parameters.AddWithValue("@tr", TextBox23.Text)
        cmd.Parameters.AddWithValue("@tra", TextBox19.Text)
        cmd.Parameters.AddWithValue("@tot", TextBox20.Text)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        con.Close()
        Dim dt As New DataTable
        con.Open()
        cmd.CommandText = "select QuoteNo,CustName,QDate,Total from QuoteMaster"
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()
        QuotationMenu.DataGridView1.DataSource = dt
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class