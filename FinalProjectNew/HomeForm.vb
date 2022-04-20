Public Class HomeForm
    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FoodForm.MdiParent = Me
        FoodForm.Show()
        DrinkForm.Close()
        OrderForm.Close()
        SnacksForm.Close()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        OrderForm.MdiParent = Me
        OrderForm.Show()
        DrinkForm.Close()
        SnacksForm.Close()
        FoodForm.Close()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SnacksForm.MdiParent = Me
        SnacksForm.Show()
        DrinkForm.Close()
        OrderForm.Close()
        FoodForm.Close()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Close()
        LoginForm.txtUsername.Text = ""
        LoginForm.txtPassword.Text = ""
        LoginForm.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        DrinkForm.MdiParent = Me
        DrinkForm.Show()
        SnacksForm.Close()
        OrderForm.Close()
        FoodForm.Close()
    End Sub
End Class