Imports System.Data.SqlClient
Public Class OrderForm
    Dim con As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim rd As SqlDataReader
    Dim ds As DataSet
    Dim mydb As String
    Sub koneksi()
        mydb = "Server =LAPTOP-BUCLP43I\MSSQLSERVER01; Database =Restaurant;Integrated Security=True"
        con = New SqlConnection(mydb)
        If con.State = ConnectionState.Closed Then con.Open()

    End Sub
    Sub kondisiawal()
        Call koneksi()
        da = New SqlDataAdapter("select * from Table_Order", con)
        ds = New DataSet
        da.Fill(ds, "Table_Order")
        DataGridView1.DataSource = (ds.Tables("Table_Order"))
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub OrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        If HomeForm.lblcubo.Text = "Welcome, admin" Then
            DataGridView1.Visible = True
            'btnAdd.Visible =
            'btnEdit.Visible = True
            'btnDelete.Visible = True
        Else
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
        End If
        txtNamaDiOrder.Text = HomeForm.lblNama.Text
        Dim i As Integer
        For i = 1 To 10
            cmbQuantity.Items.Add(i)

        Next
        Dim type As String
        Dim typeitem() As String = {"Food", "Drink", "Snack"}
        For Each type In typeitem
            cmbType.Items.Add(type)
        Next
    End Sub



    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.Text = "Food" Then
            Dim food As String
            Dim fooditem() As String = {"Fried Rice", "Chicken Rice", "Fried Noodle"}
            For Each food In fooditem
                cmbName.Items.Add(food)
            Next
        ElseIf cmbType.Text = "Drink" Then
            Dim drink As String
            Dim drinkitem() As String = {"Orange Juice", "Ice Tea", "Mineral Water"}
            For Each drink In drinkitem
                cmbName.Items.Add(drink)
            Next
        ElseIf cmbType.Text = "Snacks" Then
            Dim snacks As String
            Dim snacksitem() As String = {"French Fries", "Burger", "Sausage"}
            For Each snacks In snacksitem
                cmbName.Items.Add(snacks)
            Next
        End If
    End Sub

    Private Sub cmbQuantity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbQuantity.SelectedIndexChanged
        txtTotal.Text = cmbQuantity.Text * txtPrice.Text
    End Sub

    Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged
        If cmbName.Text = "French Fries" Then
            txtPrice.Text = 12000
        ElseIf cmbName.Text = "Burger" Then
            txtPrice.Text = 10000
        ElseIf cmbName.Text = "Sausage" Then
            txtPrice.Text = 15000
        ElseIf cmbName.Text = "Fried Rice" Then
            txtPrice.Text = 25000
        ElseIf cmbName.Text = "Chicken Rice" Then
            txtPrice.Text = 20000
        ElseIf cmbName.Text = "Fried Noodle" Then
            txtPrice.Text = 20000
        ElseIf cmbName.Text = "Orange Juice" Then
            txtPrice.Text = 10000
        ElseIf cmbName.Text = "Ice Tea" Then
            txtPrice.Text = 7000
        ElseIf cmbName.Text = "Mineral Water" Then
            txtPrice.Text = 5000
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Call koneksi()
        Dim input As String = " Insert into Table_Order values('" & cmbType.Text & "','" & cmbName.Text & "','" & cmbQuantity.Text & "','" & txtPrice.Text & "','" & txtTotal.Text & "','" & txtNamaDiOrder.Text & "')"
        cmd = New SqlCommand(input, con)
        cmd.ExecuteNonQuery()
        MsgBox("Your order has been received.")
        Call kondisiawal()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call koneksi()
        Dim edit As String = "Update  Table_Order set OrderType = '" & cmbType.Text & "',OrderName ='" & cmbName.Text & "',OrderQuantity ='" & cmbQuantity.Text & "',OrderPrice='" & txtPrice.Text & "',OrderTotal='" & txtTotal.Text & "', where OrderID='" & txtOrderID.Text & "'"
        cmd = New SqlCommand(edit, con)
        cmd.ExecuteNonQuery()
        MsgBox("Data have been Edited")
        Call kondisiawal()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Call koneksi()
        Dim delete As String = "Delete Table_Order where OrderID='" & txtOrderID.Text & "'"
        cmd = New SqlCommand(delete, con)
        cmd.ExecuteNonQuery()
        MsgBox("Data have been Deleted")
        Call kondisiawal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        On Error Resume Next
        txtOrderID.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        cmbType.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        cmbName.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        txtPrice.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        cmbQuantity.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        txtTotal.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        txtNamaDiOrder.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
    End Sub
End Class