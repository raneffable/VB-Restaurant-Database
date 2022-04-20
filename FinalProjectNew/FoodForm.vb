Imports System.Data.SqlClient
Public Class FoodForm

    Dim con As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim rd As SqlDataReader
    Dim ds As DataSet
    Dim mydb As String
    Sub clear()
        txtFoodName.Text = ""
        txtPrice.Text = ""
        PictureBox1.ImageLocation = ""
    End Sub
    Sub koneksi()
        mydb = "Server =LAPTOP-BUCLP43I\MSSQLSERVER01; Database =Restaurant;Integrated Security=True"
        con = New SqlConnection(mydb)
        If con.State = ConnectionState.Closed Then con.Open()

    End Sub
    Sub kondisiawal()
        Call koneksi()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        da = New SqlDataAdapter("select * from Table_FoodMenu", con)
        ds = New DataSet
        da.Fill(ds, "Table_FoodMenu")
        DataGridView1.DataSource = (ds.Tables("Table_FoodMenu"))
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        Call clear()

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        ''OpenFile.Filter = "*.jpg"
        'OpenFile.ShowDialog()
        'Label1.Text = OpenFile.FileName
        'PictureBox1.ImageLocation = Label1.Text
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage


    End Sub

    Private Sub FoodForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        If HomeForm.lblcubo.Text = "Welcome, admin" Then
            'btnAdd.Visible =
            'btnEdit.Visible = True
            'btnDelete.Visible = True
        Else
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call koneksi()
        Dim input As String = " Insert into Table_FoodMenu values('" & txtFoodName.Text & "','" & txtPrice.Text & "','" & Label3.Text & "')"
        cmd = New SqlCommand(input, con)
        cmd.ExecuteNonQuery()
        MsgBox("Data have been Inserted")
        Call kondisiawal()
    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click

        Call koneksi()
        Dim edit As String = "Update  Table_FoodMenu set FoodName = '" & txtFoodName.Text & "',FoodPrice ='" & txtPrice.Text & "',URLPhoto ='" & Label3.Text & "' where FoodID='" & txtFoodID.Text & "'"
        cmd = New SqlCommand(edit, con)
        cmd.ExecuteNonQuery()
        MsgBox("Data have been Edited")
        Call kondisiawal()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Call koneksi()
        Dim delete As String = "Delete Table_FoodMenu where FoodID='" & txtFoodID.Text & "'"
        cmd = New SqlCommand(delete, con)
        cmd.ExecuteNonQuery()
        MsgBox("Data have been Deleted")
        Call kondisiawal()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFile.ShowDialog()
        Label3.Text = OpenFile.FileName
        PictureBox1.ImageLocation = Label3.Text
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        On Error Resume Next
        txtFoodID.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        txtFoodName.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        txtPrice.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        PictureBox1.ImageLocation = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class