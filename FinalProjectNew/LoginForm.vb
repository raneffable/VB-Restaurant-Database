﻿Imports System.Data.SqlClient
Public Class LoginForm
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
        txtUsername.Focus()

    End Sub

    Private Sub checkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles checkShowPassword.CheckedChanged
        If checkShowPassword.Checked = True Then
            txtPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "*"

        End If
    End Sub


    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim con As SqlConnection = New SqlConnection("Server =LAPTOP-BUCLP43I\MSSQLSERVER01; Database= Restaurant;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand("select * from Table_Register where Username = '" + txtUsername.Text + "'and Password ='" + txtPassword.Text + "'", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)

        Dim table As New DataTable()

        sda.Fill(table)

        If (table.Rows.Count > 0) Then
            'Dim userid = Convert.ToInt32(table.Rows(0)("UserID"))
            Dim userid = txtUsername.Text
            MessageBox.Show("Login Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            HomeForm.Show()
            Me.Hide()
            HomeForm.lblcubo.Text = "Welcome, " + userid
            'HomeForm.lblcubo.Text = userid
            HomeForm.lblNama.Text = userid

        Else
            MessageBox.Show("Username or Password Incorrect", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        RegisterForm.Show()

    End Sub
End Class
