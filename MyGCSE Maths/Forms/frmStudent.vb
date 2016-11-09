Imports MyGCSE_Maths.BaseClass
Public Class frmStudent

    Private Student As New StudentService

    Private QuestionsIdQueue As New Queue 'Stores all the questions IDs of the current Quiz.
    Private CurrentTotalQuestions As Integer
    Private CurrentQuestion As New Question
    Private CurrentQuizID As Integer
    Private CurrentScore As Integer

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Student.PromptLogout()
    End Sub
    Private Sub MyForm_Closing(sender As Object, e As EventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub frmStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcomeBack.Text = String.Format("Welcome back, {0} {1}.", MyUser.Firstname, MyUser.Lastname)
        GetUncompletedQuizzez()
    End Sub

    Private Sub GetUncompletedQuizzez()
        QuestionsIdQueue.Clear()

        Dim quizList As List(Of Quiz) = Student.GetUncompletedQuizzes(MyUser.UserID)

        UpdateLabel(quizList.Count)
        CreateQuizLbls(quizList)
    End Sub

    Private Sub UpdateLabel(count As Integer)
        lblHomework.Cursor = Cursors.Default

        RemoveHandler lblHomework.Click, AddressOf PromptRandomQuestions

        If count = 0 Then
            lblHomework.Text = "You have no outstanding tasks. Click me to practise random set of questions!" _
                & Environment.NewLine & "Note: Your result will not be saved. This is for practising questions."

            lblHomework.Cursor = Cursors.Hand
            AddHandler lblHomework.Click, AddressOf PromptRandomQuestions
        Else
            lblHomework.Text = String.Format("You have {0} outstanding homework(s) {1} Click on one to complete it", count, Environment.NewLine)
        End If

    End Sub

    Private Sub ClearLinkLbls()
        For i = 1 To Me.Controls.Count
            For Each ctrl As CustomLinkLabel In Me.Controls.OfType(Of CustomLinkLabel)()
                Me.Controls.Remove(ctrl)
                ctrl.Dispose()
            Next
        Next
    End Sub

    Private Sub CreateQuizLbls(CurrentQuiz As List(Of Quiz))
        ClearLinkLbls()

        Dim xLocation As Integer = 25
        Dim yLocation As Integer = 86
        Dim amountCreated As Integer = 0

        For i = 0 To CurrentQuiz.Count - 1
            Dim linkLbls As New CustomLinkLabel 'Creates a new instance on each iteration

            linkLbls.QuizID = CurrentQuiz(i).QuizID
            linkLbls.Text = CurrentQuiz(i).Title
            linkLbls.Location = New Point(xLocation, yLocation)
            linkLbls.AutoSize = True

            amountCreated += 1
            yLocation += 33

            If amountCreated = 10 Then
                xLocation += 350
                yLocation = 86
                amountCreated = 0
            End If

            AddHandler linkLbls.Click, AddressOf PromptStartQuiz
            Me.Controls.Add(linkLbls)

        Next

    End Sub

    Public Sub PromptStartQuiz(sender As Object, e As EventArgs)

        Dim quiz = DirectCast(sender, CustomLinkLabel)

        If MessageBox.Show("Are you sure you want to start " & quiz.Text & " ?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            QuestionsIdQueue.Clear()

            Dim questionIds As List(Of Integer) = Student.GetQuestionsIds(quiz.QuizID)

            For Each QID In questionIds
                QuestionsIdQueue.Enqueue(QID)
            Next

            CurrentTotalQuestions = QuestionsIdQueue.Count
            CurrentQuizID = quiz.QuizID

            CurrentScore = 0
            ShowControls(True)

            GetNextQuestionHandler()

        End If
    End Sub

    Public Sub PromptRandomQuestions(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you sure you want to start?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            CurrentQuizID = Nothing

            Dim questionIds As List(Of Integer) = Student.GetRandomQuestionsIds(New Random().Next(10, 20))

            QuestionsIdQueue.Clear()
            For Each QID In questionIds
                QuestionsIdQueue.Enqueue(QID)
            Next

            CurrentTotalQuestions = QuestionsIdQueue.Count

            UpdateInformation()
            ShowControls(True)

            GetNextQuestionHandler()
        End If
    End Sub

    Private Sub ShowControls(value As Boolean)
        GroupBox1.Visible = value
        lblHomework.Visible = Not value
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If Student.AnswerIsCorrect(CurrentQuestion.Answer, GetUserAnswer()) Then
            CurrentScore += 1
            MessageBox.Show("Correct answer")
        Else
            MessageBox.Show("Incorrect answer")
        End If

        ClearUserAnswers()

        If QuestionsIdQueue.Count = 0 Then
            'Means the queue is empty, so that means student has answered all the questions.

            ShowResult(CurrentScore, CurrentTotalQuestions)

            If CurrentQuizID <> Nothing Then 'Because if it's not a quiz we don't want to save their result
                If Student.SaveQuizResults(CurrentQuizID, MyUser.UserID, CurrentScore, CurrentTotalQuestions) = True Then
                    MessageBox.Show("Your results has been saved successfully!")
                Else
                    MessageBox.Show("There has been an error in trying to save your results!")
                End If
            End If

            CurrentScore = 0 'Resets score
            ShowControls(False)
            GetUncompletedQuizzez() 'Gets all the uncompleted quizzes
        Else
            GetNextQuestionHandler()
        End If
    End Sub

    Private Sub GetNextQuestionHandler()

        If QuestionsIdQueue.Count > 0 Then
            Dim questionId As Integer = CInt(QuestionsIdQueue.Dequeue)
            Dim question As Question = QuestionUtil.GetQuestion(questionId)

            lblQuestion.Text = question.QuestionString
            picQuestion.Image = question.Image

            If question.IsMultiChoice Then
                question.FalseAnswers(3) = question.Answer

                RandomizeAnswers(question.FalseAnswers)

                rdoFalseAnswer1.Text = question.FalseAnswers(0)
                rdoFalseAnswer2.Text = question.FalseAnswers(1)
                rdoFalseAnswer3.Text = question.FalseAnswers(2)
                rdoCorrectAnswer.Text = question.FalseAnswers(3)

                ChangeControlsVisibility(True)
            Else
                ChangeControlsVisibility(False)
            End If

            CurrentQuestion = question
            UpdateInformation()
        Else
            ShowControls(False)
            MessageBox.Show("Sorry there are currently no questions avaiable")
        End If
    End Sub

    Private Sub RandomizeAnswers(ByRef qstnArray() As String)

        For i = 0 To qstnArray.Count - 1
            Dim tmp As String = qstnArray(i)
            Dim indx As Integer = New Random().Next(qstnArray.Count - i) + i
            qstnArray(i) = qstnArray(indx)
            qstnArray(indx) = tmp
        Next

    End Sub

    Private Function GetUserAnswer() As String

        If CurrentQuestion.IsMultiChoice = False Then
            Return txtAnswer.Text
        Else
            For Each rdo As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)()
                If rdo.Checked Then Return rdo.Text
            Next
        End If

        Return String.Empty 'It will never run this line because one of the conditions above must be true
    End Function

    Private Sub ClearUserAnswers()
        'Clears the textbox text and radio buttons checked status so it will be empty for the next question

        txtAnswer.Text = String.Empty

        For Each rdo As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)()
            rdo.Checked = False
        Next

    End Sub

    Private Sub ChangeControlsVisibility(value As Boolean)
        rdoCorrectAnswer.Visible = value
        rdoFalseAnswer1.Visible = value
        rdoFalseAnswer2.Visible = value
        rdoFalseAnswer3.Visible = value
        txtAnswer.Visible = Not value
    End Sub

    Private Sub ShowResult(mark As Integer, total As Integer)

        Dim percentage As Integer = CInt((mark / total) * 100)
        Dim grade As Char
        Dim msg As String = String.Empty

        Select Case percentage
            Case Is <= 39
                grade = CChar("U")
            Case Is <= 49
                grade = CChar("E")
            Case Is <= 59
                grade = CChar("D")
            Case Is <= 69
                grade = CChar("C")
            Case Is <= 79
                grade = CChar("B")
            Case Is >= 80
                grade = CChar("A")
        End Select

        If percentage >= 60 Then
            msg = "Well done!"
        Else
            msg = "You can do better!"
        End If

        Dim text As String = String.Format("{0} you scored {1} out of {2} ({3}%) which is a {4} grade.{5}{6}", MyUser.Firstname, mark, total, percentage, grade, Environment.NewLine, msg)

        MessageBox.Show(text)

    End Sub

    Public Sub UpdateInformation()
        GroupBox1.Text = String.Format("Question {0}/{1}", CurrentTotalQuestions - QuestionsIdQueue.Count, CurrentTotalQuestions)
    End Sub

    Private Sub txtAnswer_TextChanged(sender As Object, e As EventArgs) Handles txtAnswer.TextChanged
        Dim unicode As New Dictionary(Of String, String) From {{"^2", "² "}, {"^3", "³ "}, {"1/2", "½ "}, {"3/4", "¾ "}, {"1/4", "¼ "}}

        For Each x As String In unicode.Keys
            If txtAnswer.Text.Contains(x) Then
                txtAnswer.Text = txtAnswer.Text.Replace(x, unicode(x))
                txtAnswer.Select(txtAnswer.Text.Length, 0)
            End If
        Next
    End Sub

End Class