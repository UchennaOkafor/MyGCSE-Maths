Imports MyGCSE_Maths.BaseClass

Public Class frmQuestions

    Public CurrentAction As ActionType
    Public CurrentQuestionID As Integer

    Private Sub frmQuestions_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.BringToFront()
    End Sub

    Private Sub rdoSingleAnswer_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSingleAnswer.CheckedChanged
        ChangeVisibility(False)
    End Sub

    Private Sub rdoMultiChoice_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMultiChoice.CheckedChanged
        ChangeVisibility(True)
    End Sub

    Public Sub ChangeVisibility(Value As Boolean)
        txtFalseAnswer1.Visible = Value
        txtFalseAnswer2.Visible = Value
        txtFalseAnswer3.Visible = Value

        lblFalseAnswer1.Visible = Value
        lblFalseAnswer2.Visible = Value
        lblFalseAnswer3.Visible = Value
    End Sub

    Private Sub picQuestion_Click(sender As Object, e As EventArgs) Handles picQuestion.Click
        Try
            Using ofd As New OpenFileDialog With {.Filter = "Image File |*.jpg; *.gif; *.png"}
                If ofd.ShowDialog = DialogResult.OK Then picQuestion.Image = Image.FromFile(ofd.FileName)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetCurrentQuestion() As Question
        Dim q As New Question

        q.FalseAnswers = {txtFalseAnswer1.Text.Trim, txtFalseAnswer2.Text.Trim, txtFalseAnswer3.Text.Trim}
        ' Put the false answers into an array

        q.Topic = cboTopic.SelectedItem.ToString()
        q.Grade = CChar(cboGrade.SelectedItem)
        q.QuestionString = txtQuestion.Text.Trim()
        q.Image = picQuestion.Image
        q.Answer = txtCorrectAnswer.Text
        q.IsMultiChoice = rdoMultiChoice.Checked

        Return q
    End Function

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click

        If InputEmpty() = False Then
            If CurrentAction = ActionType.Add Then
                If MessageBox.Show("Are you sure you want to add this question?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    AddQuestion()
                End If
            ElseIf CurrentAction = ActionType.Edit Then
                If MessageBox.Show("Are you sure you want to update this question?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    EditQuestion()
                End If
            End If
        Else
            MessageBox.Show("Cannot leave any of the input boxes empty")
        End If

    End Sub

    Private Function InputEmpty() As Boolean
        'This Function checks too see if any of the controls have been left empty.
        'If Single Answer Radio button is checked, this checks if the appropriate controls
        'Are set or empty, and if it, it returns true. Same with Multi Answer radio button.
        'If it checks everything and its all NOT empty, it returns false meaning the controls are not
        'Empty. 

        If rdoSingleAnswer.Checked Then

            If String.IsNullOrWhiteSpace(txtQuestion.Text) Or String.IsNullOrWhiteSpace(txtCorrectAnswer.Text) _
                   Or cboGrade.SelectedIndex = -1 Or cboTopic.SelectedIndex = -1 Then
                Return True
            End If

        ElseIf rdoMultiChoice.Checked Then
            For Each txtbx As TextBox In Me.Controls.OfType(Of TextBox)()
                If String.IsNullOrWhiteSpace(txtbx.Text) Then Return True
            Next

            If cboGrade.SelectedIndex = -1 Or cboTopic.SelectedIndex = -1 Then Return True
        Else
            Return True
        End If

        Return False
    End Function

    Private Sub FormatText() Handles txtCorrectAnswer.TextChanged, txtFalseAnswer1.TextChanged,
        txtFalseAnswer2.TextChanged, txtFalseAnswer3.TextChanged, txtQuestion.TextChanged

        ' Loops through each textbox on the form, and loops through each key/item in the dictionary
        ' and if the current textbox contains the text in the dictionary, it replaces it with value of the key in the dictionary
        Dim unicode As New Dictionary(Of String, String) From {{"^2", "² "}, {"^3", "³ "}, {"1/2", "½ "}, {"3/4", "¾ "}, {"1/4", "¼ "}}

        For Each TextBx As TextBox In Me.Controls.OfType(Of TextBox)()
            For Each x As String In unicode.Keys
                If TextBx.Text.Contains(x) Then
                    TextBx.Text = TextBx.Text.Replace(x, unicode(x))
                    TextBx.Select(TextBx.Text.Length, 0)
                End If
            Next
        Next

    End Sub

    Private Sub AddQuestion()
        Try
            QuestionUtil.AddQuestion(GetCurrentQuestion())
            MessageBox.Show("Question added succesfully")
        Catch ex As Exception
            MessageBox.Show("Error adding new question!")
        End Try
    End Sub

    Private Sub EditQuestion()

        Dim q As Question = GetCurrentQuestion()

        If QuestionUtil.UpdateQuestion(CurrentQuestionID, q) Then
            MessageBox.Show("Question updated sucessfully!")
        Else
            MessageBox.Show("Error updating question")
        End If

    End Sub

    Public Sub UsageMode(action As ActionType)
        If action = ActionType.Add Then
            CurrentAction = action
            btn.Text = "Add question"
            Me.Text = "Add Question"

        ElseIf action = ActionType.Edit Then
            CurrentAction = action
            btn.Text = "Update question"
            Me.Text = "Edit question"
        End If
    End Sub
End Class