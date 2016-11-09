Imports MyGCSE_Maths.BaseClass
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Threading

Public Class frmTeacher

    Private Teacher As New TeacherService
    Dim FirstTime As Boolean
    Dim PreviousState As FormWindowState

    Private Sub MyForm_Closing(sender As Object, e As EventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub frmTeacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcomeBack.Text = String.Format("Welcome back, {0} {1}.", MyUser.Firstname, MyUser.Lastname)
        lblWelcomeBack.Text += String.Format("{0}{1}", Environment.NewLine, Teacher.GetClassInfo(MyUser.ClassID))

        InitializeChart()
        cboGrade.SelectedIndex = 0
        cboTopic.SelectedIndex = 0
        cboChartType.SelectedIndex = 1
        rdoQuestions.Checked = True
    End Sub

    Private Sub frmTeacher_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Resizes every control in this form when resized.

        If PreviousState <> FormWindowState.Minimized Then
            If FirstTime Then
                Select Case Me.WindowState
                    Case FormWindowState.Normal
                        ReLocateCtrls(-150)
                    Case FormWindowState.Maximized
                        ReLocateCtrls(+150)
                End Select
            End If
        End If

        PreviousState = Me.WindowState
        FirstTime = True
    End Sub

    Private Sub ReLocateCtrls(xLocation As Integer)
        'When the form is resized, this will resize either shift all the controls to the right of left.
        'We can also pass down negative numbers, therefore shifting the position to the left

        For Each ctrl As Control In Me.tabMngClass.Controls
            ctrl.Location = New Point(ctrl.Location.X + xLocation, ctrl.Location.Y)
        Next

        For Each ctrl As Control In Me.tabQuestions.Controls
            ctrl.Location = New Point(ctrl.Location.X + xLocation, ctrl.Location.Y)
        Next

        For Each ctrl As Control In Me.tabProgress.Controls
            ctrl.Location = New Point(ctrl.Location.X + xLocation, ctrl.Location.Y)
        Next

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Teacher.PromptLogout()
    End Sub

    Private Sub SaveToTxt(content As String)
        Using sfd As New SaveFileDialog With {.Filter = "Text File(.txt) | *.Txt"}
            If sfd.ShowDialog = DialogResult.OK Then
                IO.File.WriteAllText(sfd.FileName, content)
                Process.Start(sfd.FileName)
            End If
        End Using
    End Sub

#Region "Class Tab"
    Private Sub InitializeChart()

        Chart1.Titles.Add("Student Progress Tracker")
        Chart1.ChartAreas(0).AxisY.Title = "Percentage %"
        Chart1.ChartAreas(0).AxisX.Title = "Quizzes Taken"

        Chart1.Series(0).LabelFormat = "{#'%'}"
    End Sub

    Private Sub txtSearchField_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchField.KeyDown
        If e.KeyCode = Keys.Enter Then btnSearch.PerformClick()
    End Sub

    Private Sub ClearControls()
        Do
            For Each ctrl As Control In Panel1.Controls
                Panel1.Controls.Remove(ctrl)
                ctrl.Dispose()
            Next
        Loop Until Panel1.Controls.Count = 0
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ClearControls()

        Dim studentList As List(Of User) = Teacher.GetStudents(MyUser.ClassID, txtSearchField.Text)

        If IsNothing(studentList) Then
            MessageBox.Show("User not found")

            lblStudentCount.Text = String.Format("Student Count ({0})", 0)
        Else
            ThreadPool.QueueUserWorkItem(Sub() CreateDynamicStudents(studentList))

            lblStudentCount.Text = String.Format("Student Count ({0}) ", studentList.Count)
        End If

    End Sub

    Private Sub CreateDynamicStudents(student As List(Of User))

        Dim xLocation As Integer = 20
        Dim yLocation As Integer = 20
        Dim amountCreated As Integer = 0

        For i = 0 To student.Count - 1

            Dim picBox As New CustomPictureBox

            picBox.Name = student(i).Firstname & " " & student(i).Lastname
            picBox.UserID = student(i).UserID
            picBox.Username = student(i).Username
            picBox.Size = New Size(167, 186)
            picBox.Location = New Point(xLocation, yLocation)
            picBox.BorderStyle = BorderStyle.FixedSingle
            picBox.SizeMode = PictureBoxSizeMode.Zoom
            picBox.Cursor = Cursors.Hand
            picBox.Image = student(i).Image

            CreateDynamicLabels(picBox.Name, xLocation, yLocation)

            amountCreated += 1
            xLocation += 200

            If amountCreated = 5 Then
                xLocation = 20
                yLocation += 220
                amountCreated = 0
            End If

            AddHandler picBox.MouseDown, AddressOf StudentPicture_Clicked
            Invoke(Sub() Me.Panel1.Controls.Add(picBox))

        Next

        Invoke(Sub() Me.Panel1.Focus())

    End Sub

    Private Sub Panel1_MouseHover(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        Me.Panel1.Focus()
    End Sub

    Private Sub CreateDynamicLabels(name As String, xLocation As Integer, yLocation As Integer)
        Dim lblStudentName As New Label With {.Text = name, .AutoSize = True}

        xLocation += GetEstimateX(lblStudentName)
        yLocation += 190
        lblStudentName.Location = New Point(xLocation, yLocation)

        Invoke(Sub() Me.Panel1.Controls.Add(lblStudentName))
    End Sub

    Private Function GetEstimateX(lbl As Label) As Integer
        Dim amount As Integer

        Select Case MeasureLabel(lbl).Width
            Case Is <= 30 : amount = 60

            Case Is <= 40 : amount = 55

            Case Is <= 50 : amount = 50

            Case Is <= 60 : amount = 45

            Case Is <= 65 : amount = 40

            Case Is <= 70 : amount = 35

            Case Is <= 80 : amount = 30

            Case Is <= 100 : amount = 25

            Case Is >= 101 : amount = 5
        End Select

        Return amount
    End Function

    Private Function MeasureLabel(lbl As Label) As SizeF
        Dim g As Graphics = Me.CreateGraphics
        Return g.MeasureString(lbl.Text, lbl.Font)
    End Function

    Private Function GetMidPoint(p As PictureBox) As Point
        'picBox.Size = New Size(167, 186)
        'width, height

        Dim x1 As Integer = (p.Location.X)
        Dim y1 As Integer = (p.Location.Y + p.Size.Height)

        Dim x2 As Integer = (p.Location.X + p.Size.Width)
        Dim y2 As Integer = (p.Location.Y + p.Size.Height)

        Dim bottomLeft As New Point(x1, x2)
        Dim bottomRight As New Point(y1, y2)

        Dim midPoint As New Point(CInt((x2 + x1) / 2), CInt((y2 + y1) / 2))

        Return midPoint
    End Function

    Private Sub StudentPicture_Clicked(sender As Object, e As MouseEventArgs)

        If e.Button = MouseButtons.Right Then
            Dim picbx As CustomPictureBox = DirectCast(sender, CustomPictureBox)
            'We convert/cast the sender as the Object CustomPictureBox, this way we can
            'Access it's methods and attributes.

            ContextMenuStudent.Show(MousePosition)

            CurrentClickedPB = picbx

            Dim name As String = CurrentClickedPB.Name.Split(" "c)(0)

            MenuItemProgress.Text = String.Format("View {0}'s progress", name)
            MenuItemContact.Text = String.Format("Send {0} a message", name)
            MenuItemExport.Text = String.Format("Export {0}'s quiz results", name)
        End If

    End Sub

    Private CurrentClickedPB As New CustomPictureBox

    Private Sub MenuItemProgress_Click(sender As Object, e As EventArgs) Handles MenuItemProgress.Click

        Chart1.Series(0).Name = String.Format("{0} - {1}", CurrentClickedPB.Name, CurrentClickedPB.UserID)

        DateTimeFrom.Value = FirstDayOfMonth()

        DateTime_ValueChanged(sender, e) 'This is to fix a bug where the DateValueChanged event wouldn't fire
        'because the previous DateTimeValue was the same as the new one. So therefore the event wouldn't fire.

        'Changing the value of the datetime picker will raise the ValueChanged event in frmTeacher
        Me.TabControl1.SelectedTab = Me.tabProgress
    End Sub

    Private Sub MenuItemExport_Click(sender As Object, e As EventArgs) Handles MenuItemExport.Click
        Dim sb As New StringBuilder

        sb.AppendLine("                      " & CurrentClickedPB.Name & "'s Overall progress")
        sb.AppendLine()
        Dim data As String = Teacher.ExportStudentResults(CurrentClickedPB.UserID)

        If String.IsNullOrWhiteSpace(data) Then
            MessageBox.Show(CurrentClickedPB.Name & " has not completed any quizzes yet!")
        Else
            sb.AppendLine(data)
            SaveToTxt(sb.ToString())
        End If
    End Sub

    Private Sub MenuItemContact_Click(sender As Object, e As EventArgs) Handles MenuItemContact.Click
        MessageBox.Show("This feature has not yet been implemented")
    End Sub

#End Region

#Region "Students Progress Tab"
    Private Function FirstDayOfMonth() As DateTime
        Return New DateTime(Today.Year, Today.Month, 1) 'Gets the first day of the month as date
    End Function

    Private Sub cboChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChartType.SelectedIndexChanged

        Select Case cboChartType.SelectedItem.ToString
            Case "Line Graph"
                Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Case "Bar Chart"
                Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

            Case "Area Chart"
                Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Area
        End Select

    End Sub

    Private Sub chkDataPoint_CheckedChanged(sender As Object, e As EventArgs) Handles chkDataPoint.CheckedChanged
        If chkDataPoint.Checked Then
            Chart1.Series(0).IsValueShownAsLabel = True
        Else
            Chart1.Series(0).IsValueShownAsLabel = False
        End If
    End Sub

    Public Sub DateTime_ValueChanged(sender As Object, e As EventArgs) Handles DateTimeTo.ValueChanged, DateTimeFrom.ValueChanged
        Dim userId As Integer

        If Integer.TryParse(Regex.Replace(Chart1.Series(0).Name, "[^0-9]", String.Empty), userId) Then
            Dim name As String = Chart1.Series(0).Name.Split(" "c)(0)

            Me.Chart1.Series(0).Points.Clear()

            Dim studentResults = Teacher.GetStudentQuizResults(userId, DateTimeFrom.Value, DateTimeTo.Value)

            If IsNothing(studentResults) Then
                lblQuizInfo.Text = String.Format("No quizzes has been completed by {0} from {1} to {2}", name, DateTimeFrom.Text, DateTimeTo.Text)
            Else

                For Each item In studentResults
                    Me.Chart1.Series(0).Points.Add(item.Percentage).AxisLabel = item.Title
                Next

                lblQuizInfo.Text = String.Format("{0} has completed {1} quizzes from {2} to {3}", name, Chart1.Series(0).Points.Count, DateTimeFrom.Text, DateTimeTo.Text)
            End If
        End If
    End Sub

    Private Sub LinkLblViewAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLblViewAll.LinkClicked
        Dim studentQuizList As List(Of StudentQuizInfo) = Teacher.GetStudentsQuizResults(MyUser.ClassID)
        Dim sb As New StringBuilder

        sb.AppendLine("             MyGCSE Maths Benchmark       ")
        sb.AppendLine()

        For Each student In studentQuizList
            sb.AppendLine(String.Format("Name: {0} {1}", student.Firstname, student.Lastname))
            sb.AppendLine(String.Format("Average: {0}%", student.Average))
            sb.AppendLine(String.Format("Total Quizzes Completed: {0}", student.QuizScores.Count))
            sb.AppendLine()
        Next

        SaveToTxt(sb.ToString())
    End Sub

#End Region

#Region "Question Manager Tab"

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        frmQuestions.UsageMode(ActionType.Add)
        frmQuestions.Show()
    End Sub

    Private Sub btnSearchQuestion_Click(sender As Object, e As EventArgs) Handles btnSearchQuestion.Click

        tvQuestions.Nodes.Clear()

        Dim grade As String = cboGrade.SelectedItem.ToString
        Dim topic As String = cboTopic.SelectedItem.ToString

        If rdoQuestions.Checked Then
            btnAddQuiz.Visible = True

            HandleQuestion(topic, grade)

        ElseIf rdoQuiz.Checked Then
            btnAddQuiz.Visible = False

            Teacher.FetchQuiz()
        End If

        tvQuestions.ExpandAll()

        If tvQuestions.Nodes.Count > 0 Then tvQuestions.Nodes(0).EnsureVisible() 'Scrolls up to the top after expanding all

    End Sub

    Private Sub HandleQuestion(topic As String, grade As String)
        If topic = "-" And grade = "-" Then

            For Each itm As String In cboTopic.Items
                If itm <> "-" Then Teacher.PopulateTreeView(String.Empty, itm)
            Next

        ElseIf topic = "-" Or grade = "-" Then

            If grade = "-" Then
                grade = String.Empty
                Teacher.PopulateTreeView(grade, topic)
            End If

            If topic = "-" Then
                For Each itm As String In cboTopic.Items
                    Teacher.PopulateTreeView(grade, itm)
                Next
            End If

        Else
            Teacher.PopulateTreeView(grade, topic)
        End If
    End Sub

    Private Sub tvQuestions_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvQuestions.AfterCheck
        'Event is raised after a treenode is Checked
        For Each childNode As TreeNode In e.Node.Nodes
            childNode.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub btnGenerateQuestion_Click(sender As Object, e As EventArgs) Handles btnGenerateQuestion.Click
        frmGenerateQuestions.Show()
        frmGenerateQuestions.BringToFront()
    End Sub

    Private Sub btnAddQuiz_Click(sender As Object, e As EventArgs) Handles btnAddQuiz.Click
        'This loops through every checked childNode of every parentNode, and adds them to a quiz.
        'Each checked node is a question.

        If GetCheckedCount() = 0 Then
            MessageBox.Show("You must select atleast one question before continuing")
        Else
            Dim quizName As String = InputBox(String.Format("Enter the title of the quiz please{0}e.g.Tuesday's Quiz - Week 4", Environment.NewLine, "Quiz Title"))

            'Checks if the InputBox content was not empty.
            If String.IsNullOrWhiteSpace(quizName) = False Then
                'Loops through each childnode of each parentnode.
                'And adds 
                Dim questionIdList As New List(Of Integer)

                For Each parentNode As TreeNode In tvQuestions.Nodes
                    For Each childNode As CustomTreeNode In parentNode.Nodes.OfType(Of CustomTreeNode)()
                        If childNode.Checked Then questionIdList.Add(childNode.QuestionID)
                    Next
                Next
                If Teacher.AddQuiz(questionIdList, quizName) Then MessageBox.Show("Successfully added questions into the quiz set")
            End If

        End If
    End Sub

    Private Sub DeleteQstn()
        Dim counter As Integer

        For Each parentNode As TreeNode In tvQuestions.Nodes
            For Each childNode As CustomTreeNode In parentNode.Nodes
                If childNode.Checked Then
                    If QuestionUtil.DeleteQuestion(childNode.QuestionID) Then counter += 1 'Increments counter if delete successsfull
                End If
            Next
        Next

        If counter >= 1 Then
            MessageBox.Show("Sucessfully deleted " & counter & " question(s)")
            btnSearchQuestion.PerformClick()
        End If

    End Sub

    Private Sub btnDeleteQuestion_Click(sender As Object, e As EventArgs) Handles btnDeleteQuestion.Click
        If GetCheckedCount() = 0 Then
            MessageBox.Show("You must select atleast one question before continuing")
        Else
            If MessageBox.Show("Are you sure you want to delete the selected questions?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then DeleteQstn()
        End If
    End Sub

    Private Function GetCheckedCount() As Integer
        Dim counter As Integer

        For Each parentNode As TreeNode In tvQuestions.Nodes
            For Each childNode As CustomTreeNode In parentNode.Nodes
                If childNode.Checked Then counter += 1
            Next
        Next

        Return counter
    End Function

    Private Sub btnExportAnswers_Click(sender As Object, e As EventArgs) Handles btnExportAnswers.Click
        If GetCheckedCount() = 0 Then
            MessageBox.Show("You must select atleast one question before continuing")
        Else
            Dim questionIdList As New List(Of Integer)

            For Each parentNode As TreeNode In tvQuestions.Nodes
                For Each childNode As CustomTreeNode In parentNode.Nodes
                    If childNode.Checked Then questionIdList.Add(childNode.QuestionID)
                Next
            Next

            SaveToTxt(Teacher.ExportQuestions(questionIdList))
        End If
    End Sub

    Private CurrentSelectedNode As CustomTreeNode

    Private Sub tvQuestions_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvQuestions.NodeMouseClick

        If e.Node.GetType Is GetType(CustomTreeNode) Then
            tvQuestions.SelectedNode = e.Node
            If e.Button = MouseButtons.Right Then
                CurrentSelectedNode = DirectCast(e.Node, CustomTreeNode)

                ContextMenuQuestion.Show(MousePosition)
            End If
        End If

    End Sub

    Private Sub MenuItemEdit_Click(sender As Object, e As EventArgs) Handles MenuItemEdit.Click
        frmQuestions.CurrentQuestionID = CurrentSelectedNode.QuestionID

        Dim question As Question = QuestionUtil.GetQuestion(CurrentSelectedNode.QuestionID)

        frmQuestions.picQuestion.Image = question.Image
        frmQuestions.txtQuestion.Text = question.QuestionString

        frmQuestions.cboTopic.SelectedItem = question.Topic
        frmQuestions.cboGrade.SelectedItem = question.Grade.ToString()
        frmQuestions.txtCorrectAnswer.Text = question.Answer

        If question.IsMultiChoice Then
            frmQuestions.rdoMultiChoice.Checked = True

            frmQuestions.txtFalseAnswer1.Text = question.FalseAnswers(0)
            frmQuestions.txtFalseAnswer2.Text = question.FalseAnswers(1)
            frmQuestions.txtFalseAnswer3.Text = question.FalseAnswers(2)
        Else
            frmQuestions.rdoSingleAnswer.Checked = True
        End If

        frmQuestions.UsageMode(ActionType.Edit)
        frmQuestions.Show()

    End Sub

    Private Sub MenuItemDelete_Click(sender As Object, e As EventArgs) Handles MenuItemDelete.Click
        If MessageBox.Show("Are you sure you want to delete the selected question?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            If QuestionUtil.DeleteQuestion(CurrentSelectedNode.QuestionID) Then
                MessageBox.Show("Question deleted succesfully!")
            Else
                MessageBox.Show("Error deleting question")
            End If

            btnSearchQuestion.PerformClick()
        End If
    End Sub

#End Region
End Class