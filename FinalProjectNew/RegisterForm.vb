Imports System.Data.SqlClient

Public Class RegisterForm
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim mydb As String
    Sub koneksi()
        mydb = "Server =LAPTOP-BUCLP43I\MSSQLSERVER01; Database =Restaurant ;Integrated Security=True"
        con = New SqlConnection(mydb)
        If con.State = ConnectionState.Closed Then con.Open()

    End Sub


    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Call koneksi()
        Dim input As String = " Insert into Table_Register values('" & txtUsername.Text & "', '" & txtPassword.Text & "')"
        cmd = New SqlCommand(input, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Succesfully Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Hide()
    End Sub

    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class