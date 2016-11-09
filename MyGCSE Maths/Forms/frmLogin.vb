Imports MyGCSE_Maths.BaseClass
Imports System.Threading

Public Class frmLogin

    Private Login As New LoginService

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        btnLogin.Enabled = False
        ThreadPool.QueueUserWorkItem(Sub() CheckForConnection())
    End Sub

    Private Sub CheckForConnection()

        If Login.HasConnection() Then
            UpdateLabel("Connected", Color.Green)
        Else
            UpdateLabel("Connection failed", Color.Red)
        End If

        Invoke(Sub() btnLogin.Enabled = True)
    End Sub

    Private Sub UpdateLabel(text As String, foreColor As Color)
        ' Because we're trying to change the properties of a controls that's on a seperate thread, we need to make
        ' a safe call to the control, we do that by invoking the method using a delegate sub in order for it to be handled correctly. 
        ' Unless we 'd get a CrossThreadCall Exception thrown

        Invoke(Sub() lblConStatus.Text = text)
        Invoke(Sub() lblConStatus.ForeColor = foreColor)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Login.IsConnected Then
            If Login.CorrectLogin(txtUsername.Text, txtPassword.Text) Then
                ShowForm(MyUser.Rank)
            Else
                MessageBox.Show("Incorrect username or password", "Alert")
            End If
        Else
            MessageBox.Show("Cannot connect to server", "Noice")
        End If
    End Sub

    Private Sub ShowForm(userRank As Rank)
        ' After a successful login, this sub is called. It will show the user the correct UI depending on their rank

        Select Case userRank
            Case Rank.Admin
                frmAdmin.Show()

            Case Rank.Teacher
                frmTeacher.Show()

            Case Rank.Student
                frmStudent.Show()
        End Select

        Me.Hide()
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub
End Class