Imports MyGCSE_Maths.BaseClass
Public Class frmEdit

    Private Admin As New AdminService

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ChangeState(True)
        Else
            ChangeState(False)
        End If
    End Sub

    Private Sub ChangeState(value As Boolean)
        cboClass.Enabled = value
        btnDelete.Enabled = value
        btnUpdate.Enabled = value
        PictureBox1.Enabled = value

        txtPassword.ReadOnly = Not value
        txtFirstname.ReadOnly = Not value
        txtLastname.ReadOnly = Not value
        txtEmail.ReadOnly = Not value
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If Admin.DeleteAccount(CInt(txtUserID.Text)) Then
                MessageBox.Show("User deleted successfully!", "Notice")
                Me.Close()
                frmAdmin.btnSearch.PerformClick() 'Clicks the refresh button, this in effects updates the items in the listbox
            Else
                MessageBox.Show("Failed to delete user", "Notice")
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim classID As Integer = 0

        If MessageBox.Show("Are you sure you want to update this record?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Try
                classID = DirectCast(cboClass.SelectedItem, ClassRoom).ClassID
            Catch
                'This is because the class combo box will only show for students and teachers. So if you're trying to update
                'an admins it will give an IndexOutOfBounds since the selected index would be -1
            End Try

            Dim userRank As Rank = CType(cboRank.SelectedIndex, Rank)

            If Admin.UpdateAccount(CInt(txtUserID.Text), txtFirstname.Text, txtLastname.Text, txtEmail.Text, txtPassword.Text, PictureBox1.Image, classID, userRank) Then
                MessageBox.Show("User updated successfully", "Notice")
                frmAdmin.btnSearch.PerformClick()
            Else
                MessageBox.Show("There was an error trying to edit user information", "Notice")
            End If

        End If

    End Sub

    Private Sub cboRank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRank.SelectedIndexChanged
        If CType(cboRank.SelectedIndex, Rank) = Rank.Admin Then
            ChangeVisibility(False)
        Else
            ChangeVisibility(True)
        End If
    End Sub

    Private Sub ChangeVisibility(Value As Boolean)
        lblClass.Visible = Value
        cboClass.Visible = Value
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Using ofd As New OpenFileDialog With {.Filter = "Image|*jpg;*png;*bmp"}
                If ofd.ShowDialog = DialogResult.OK Then PictureBox1.Image = Image.FromFile(ofd.FileName)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class