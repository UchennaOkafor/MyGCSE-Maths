Imports MyGCSE_Maths.BaseClass
Public Class frmAdmin

    Private Admin As New AdminService

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcomeBack.Text = String.Format("Welcome back, {0} {1}.", MyUser.Firstname, MyUser.Lastname)
        rdoStudent.Checked = True
    End Sub

    Private Sub MyForm_Closing(sender As Object, e As EventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Function GetRank() As Rank
        If rdoAdmin.Checked Then
            Return Rank.Admin
        ElseIf rdoTeacher.Checked Then
            Return Rank.Teacher
        ElseIf rdoStudent.Checked Then
            Return Rank.Student
        Else
            Return Nothing

            'Implying that one of the radio buttons must be checked unless this function can't be executed
            'Putting this so the compiler will stop giving warnings.
        End If
    End Function

    Private Function GetClassID() As Integer
        If GetRank() = Rank.Student Or GetRank() = Rank.Teacher Then
            Return DirectCast(cboClass.SelectedItem, ClassRoom).ClassID
        Else
            Return 0
        End If
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'I didn't validate the txtFirstname or txtLastname to check if there's any text in this subroutine because I do that in another sub
        'ActivateAddBtn() Will do the validating

        If Integer.TryParse(txtUserID.Text, Nothing) Then
            If MessageBox.Show("Are you sure you want to add this user?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Try
                    If Admin.AddAccount(CInt(txtUserID.Text), txtFirstname.Text, txtLastname.Text, GetRank(), picUser.Image, GetClassID()) Then
                        MessageBox.Show("User added successfully", "Notice")
                        ClearControls()
                        RefreshClassList()
                    Else
                        MessageBox.Show("An error occured whilst to add a new user")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        Else
            MessageBox.Show("User rank must be selected, and UserID must only consist of numbers")
        End If

    End Sub

    Private Sub ClearControls()
        ' Clears or resets items in the controls 
        txtFirstname.Clear()
        txtLastname.Clear()
        txtUserID.Clear()
        cboClass.SelectedIndex = -1
        picUser.Image = Nothing
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lstUsers.Items.Clear()

        Dim usersList = Admin.GetUsers(txtSearch.Text)

        If IsNothing(usersList) Then
            MessageBox.Show("User not found")
        Else
            For Each user As User In usersList
                lstUsers.Items.Add(user)
            Next
        End If

    End Sub

    Private Sub lstUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstUsers.SelectedIndexChanged
        If lstUsers.SelectedIndex >= 0 Then

            RefreshClassList() 'Refreshes the class list

            'If each item is a CustomUser then the SelectedItem is a CustomUser.
            'The SelectedItem property is an Object, so a cast is required.
            Dim selectedUser = DirectCast(lstUsers.SelectedItem, User)
            GetUserInfo(selectedUser.UserID, selectedUser.Rank)

            frmEdit.Show()
            frmEdit.BringToFront()
        End If
    End Sub

    Private Sub GetUserInfo(userId As Integer, userRank As Rank)
        Dim targetUser = Admin.GetUserInformation(userId, userRank)

        frmEdit.txtUserID.Text = targetUser.UserID.ToString()
        frmEdit.txtUsername.Text = targetUser.Username
        frmEdit.txtPassword.Text = targetUser.Password
        frmEdit.cboRank.SelectedIndex = CInt(targetUser.Rank)

        If targetUser.Rank <> Rank.Admin Then frmEdit.cboClass.Text = targetUser.ClassName

        frmEdit.txtFirstname.Text = targetUser.Firstname
        frmEdit.txtLastname.Text = targetUser.Lastname
        frmEdit.txtEmail.Text = targetUser.Email

        frmEdit.PictureBox1.Image = targetUser.Image
    End Sub

    Private Sub picUser_Click(sender As Object, e As EventArgs) Handles picUser.Click
        Try
            Using ofd As New OpenFileDialog With {.Filter = "Images|*.jpg;*.png;*.bmp"}
                If ofd.ShowDialog = DialogResult.OK Then picUser.Image = Image.FromFile(ofd.FileName)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub rdoStudent_CheckedChanged(sender As Object, e As EventArgs) Handles rdoStudent.CheckedChanged, rdoAdmin.CheckedChanged, rdoTeacher.CheckedChanged
        If rdoStudent.Checked Or rdoTeacher.Checked Then
            RefreshClassList()
            LblsVisible(True)
        Else
            LblsVisible(False)
        End If
    End Sub

    Private Sub LblsVisible(value As Boolean)
        lblClassInfo.Visible = value
        cboClass.Visible = value
    End Sub

    Private Sub RefreshClassList()
        frmEdit.cboClass.Items.Clear()
        Me.cboClass.Items.Clear()

        Dim classList = Admin.GetAllClasses()

        For Each item As ClassRoom In classList
            frmEdit.cboClass.Items.Add(item)
            Me.cboClass.Items.Add(item)
        Next
    End Sub

    Private Sub ActivateAddBtn() Handles txtLastname.TextChanged, cboClass.SelectedIndexChanged, _
        rdoAdmin.CheckedChanged, rdoTeacher.CheckedChanged, rdoStudent.CheckedChanged

        btnAdd.Enabled = False

        If Not String.IsNullOrWhiteSpace(txtLastname.Text) Or Not String.IsNullOrWhiteSpace(txtFirstname.Text) Or Not String.IsNullOrWhiteSpace(txtUserID.Text) Then
            If rdoStudent.Checked Or rdoTeacher.Checked Then
                If cboClass.SelectedIndex >= 0 Then btnAdd.Enabled = True
            Else
                btnAdd.Enabled = True
            End If
        End If

        'This will only enable the add button if all the conditions are met

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim d As New BaseClass()
        d.PromptLogout()
    End Sub

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click

        If String.IsNullOrWhiteSpace(txtBlock.Text) = False And String.IsNullOrWhiteSpace(txtRoom.Text) = False Then
            If MessageBox.Show("Are you sure you want to add this class?", "Notice", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                If Admin.CreateClass(CChar(txtBlock.Text), txtRoom.Text) Then
                    MessageBox.Show("Class created successfully!")
                Else
                    MessageBox.Show("An error occured whilst adding class")
                End If

            End If
        Else
            MessageBox.Show("One or more fields have not been filled in", "Alert")
        End If

    End Sub

    Private Sub btnSearchTeacher_Click(sender As Object, e As EventArgs) Handles btnSearchTeacher.Click
        DataGridView1.Rows.Clear()

        Admin.AddOccupiedClasses()
        Admin.AddEmptyClasses()
    End Sub

End Class