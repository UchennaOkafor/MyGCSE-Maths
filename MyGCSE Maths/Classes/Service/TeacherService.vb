Imports System.Data.SqlClient
Imports System.Text
Public Class TeacherService

    Inherits BaseClass

    Public Function GetClassInfo(classID As Integer) As String
        OpenConnection()

        Dim query As String = "Select * From tblClass Where ClassID = @0"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", classID)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    Return String.Format("Block: {0} | Room: {1} ", R("Block").ToString(), R("Room").ToString())
                End While
            End Using
        End Using

        CloseConnection()

        Return String.Empty
    End Function

    Public Function GetStudents(classID As Integer, name As String) As List(Of User)
        OpenConnection()

        'This function returns a list of all the students in a teachers class which match
        'the name parameter passed down.

        Dim studentList As New List(Of User)

        Dim query As String = "SELECT * FROM tblUser, tblUserClass" _
            & " WHERE tblUser.Firstname + ' ' + tblUser.Lastname LIKE @0 And tblUser.[Rank] = 0" _
            & " And tblUser.UserID = tblUserClass.UserID And tblUserClass.ClassID = @1 Order By tblUser.Firstname Asc"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", "%" & name & "%")
            SQLCmd.Parameters.AddWithValue("@1", classID)

            Using R As SqlDataReader = SQLCmd.ExecuteReader

                If R.HasRows Then
                    While R.Read
                        Dim student As New User

                        student.UserID = CInt(R("UserID"))
                        student.Username = R("Username").ToString
                        student.Firstname = R("Firstname").ToString
                        student.Lastname = R("Lastname").ToString
                        student.Image = DirectCast(R("Picture"), Byte()).ToImage()
                        studentList.Add(student)
                    End While
                Else
                    Return Nothing
                End If

            End Using
        End Using

        CloseConnection()
        Return studentList
    End Function

    Private Function CreateQuizID() As Integer
        'By ordering it by descending, we get the biggest quiz number as the first.
        'So then we just increment the biggest number, and we have our new unique QuizID

        Dim query As String = "Select Distinct QuizID From tblQuizTitle Order By QuizID Desc"
        Dim id As Integer

        Try
            Using SQLCmd As New SqlCommand(query, SQLCon)
                id = CInt(SQLCmd.ExecuteScalar)
            End Using
        Catch ex As Exception
            Return 1
        End Try

        Return id + 1
    End Function

    Public Function AddQuiz(questionIdList As List(Of Integer), quizTitle As String) As Boolean
        OpenConnection()

        Dim query As String = "Insert Into tblQuiz(QuizID, QID) Values(@0, @1)"
        Dim quizID As Integer = CreateQuizID()

        For Each questionId As Integer In questionIdList
            Using SQLCmd As New SqlCommand(query, SQLCon)
                SQLCmd.Parameters.AddWithValue("@0", quizID)
                SQLCmd.Parameters.AddWithValue("@1", questionId)

                SQLCmd.ExecuteNonQuery()
            End Using
        Next

        Return AddQuizTitle(quizID, quizTitle)

    End Function

    Private Function AddQuizTitle(quizId As Integer, title As String) As Boolean
        OpenConnection()

        Dim query As String = "Insert Into tblQuizTitle(QuizID, Title) Values(@0, @1)"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            'We paramatize just incase the user enters something that could tamper with the system database.

            SQLCmd.Parameters.AddWithValue("@0", quizId)
            SQLCmd.Parameters.AddWithValue("@1", title)

            If SQLCmd.ExecuteNonQuery() = 1 Then
                Return True
            Else
                Return False
            End If

        End Using
    End Function

    Public Function GetStudentQuizResults(userId As Integer, dateFrom As DateTime, dateTo As DateTime) As List(Of Quiz)
        OpenConnection()

        ' Selects all the completed quizzes in order of the latest one first
        Dim query As String = "Select * From tblQuizTitle, tblQuizLog " _
                            & "Where tblQuizTitle.QuizID = tblQuizLog.QuizID And UserID = @userId " _
                            & "And DateCompleted Between @from And @to Order By DateCompleted Asc"

        Dim quizList As New List(Of Quiz)

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@from", dateFrom)
            SQLCmd.Parameters.AddWithValue("@to", dateTo)
            SQLCmd.Parameters.AddWithValue("@userId", userId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                If R.HasRows Then
                    While R.Read
                        Dim percent As Integer = CalculatePercentage(CInt(R("Total")), CInt(R("Mark")))
                        quizList.Add(New Quiz With {.Percentage = percent, .Title = R("Title").ToString()})
                    End While
                Else
                    Return Nothing
                End If
            End Using
        End Using

        CloseConnection()

        Return quizList
    End Function

    Private Function CalculatePercentage(total As Integer, mark As Integer) As Integer
        Return CInt((mark / total) * 100)
    End Function

    Public Sub FetchQuiz()
        OpenConnection()

        Dim quizList As New List(Of Quiz)

        'Selects all the QuizIDs of the Quizzes that are in the database.
        Dim query As String = "Select Distinct tblQuiz.QuizID, tblQuizTitle.Title From tblQuiz, tblQuizTitle " _
                            & "Where tblQuiz.QuizID = tblQuizTitle.QuizID"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    quizList.Add(New Quiz With {.QuizID = CInt(R("QuizID")), .Title = R("Title").ToString})
                End While
            End Using
        End Using

        AddQuizToTree(quizList)

        CloseConnection()
    End Sub

    Public Sub PopulateTreeView(grade As String, topic As String)
        OpenConnection()

        Dim query As String = "Select * From tblQuestion Where Grade LIKE @0 And Topic LIKE @1"

        Using SQLCmd = New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", "%" & grade & "%")
            SQLCmd.Parameters.AddWithValue("@1", "%" & topic & "%")

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                If R.HasRows Then
                    Dim parentNode As TreeNode = frmTeacher.tvQuestions.Nodes.Add(topic) 'e.g Algebra

                    'Adds each question fetched under the parent node. 
                    'So under the ParentNode Algebra. All the algebra questions will be added under it.

                    While R.Read
                        parentNode.Nodes.Add(New CustomTreeNode() With {.QuestionID = CInt(R("QID")), .Text = R("Question").ToString})
                    End While
                End If

            End Using
        End Using

        CloseConnection()
    End Sub

    Private Sub AddQuizToTree(quizList As List(Of Quiz))

        For Each quiz As Quiz In quizList

            'Selects all the Questions in a quiz
            Dim query As String = "Select * From tblQuiz, tblQuestion " _
                                & "Where tblQuiz.QID = tblQuestion.QID And QuizID = @0"

            Dim parentNode As TreeNode = frmTeacher.tvQuestions.Nodes.Add(quiz.Title)

            Using SQLCmd As New SqlCommand(query, SQLCon)

                SQLCmd.Parameters.AddWithValue("@0", quiz.QuizID)

                Using R As SqlDataReader = SQLCmd.ExecuteReader()
                    While R.Read
                        parentNode.Nodes.Add(New CustomTreeNode() With {.QuestionID = CInt(R("QID")), .Text = R("Question").ToString})
                    End While

                End Using

            End Using
        Next

    End Sub

    Public Function ExportQuestions(quesionIdList As List(Of Integer)) As String
        OpenConnection()

        Dim sb As New StringBuilder
        Dim counter As Integer = 1

        For Each qID As Integer In quesionIdList

            Dim query As String = "Select Question, Answer From tblQuestion Where QID = @0"

            Using SQLCmd As New SqlCommand(query, SQLCon)
                SQLCmd.Parameters.AddWithValue("@0", qID)

                Using R As SqlDataReader = SQLCmd.ExecuteReader()
                    While R.Read
                        sb.AppendLine(String.Format("{0}) Question: {1}", counter, R("Question").ToString()))
                        sb.AppendLine(String.Format("Answer: {0}", R("Answer").ToString()))
                        sb.AppendLine()
                    End While
                End Using
            End Using

            counter += 1
        Next

        CloseConnection()

        Return sb.ToString()
    End Function

    Public Function ExportStudentResults(studentId As Integer) As String
        OpenConnection()

        Dim query As String = "SELECT * From tblUser, tblQuizLog, tblQuizTitle " _
                              & "Where tblQuizLog.UserID = tblUser.UserID " _
                              & "And tblQuizTitle.QuizID = tblQuizLog.QuizID " _
                              & "And tblUser.UserID = @0 " _
                              & "Order By DateCompleted Desc"

        Dim sb As New StringBuilder
        Dim counter As Integer

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", studentId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                If R.HasRows Then
                    While R.Read
                        counter += 1

                        sb.AppendLine(counter & ")")
                        sb.AppendLine("Quiz Title: " & R("Title").ToString())

                        Dim percentage As Integer = CalculatePercentage(CInt(R("Total")), CInt(R("Mark")))
                        sb.AppendLine("Score: " & percentage & "%")
                        sb.AppendLine("Date Completed: " & R("DateCompleted").ToString())
                        sb.AppendLine()
                    End While
                Else
                    Return Nothing
                End If
            End Using
        End Using

        CloseConnection()

        Return sb.ToString()
    End Function

    Private Function GetStudentQuizInfo(studentId As Integer) As StudentQuizInfo
        Dim student As New StudentQuizInfo With {.UserID = studentId}
        student.QuizScores = New List(Of Integer)


        'Selects all the logs of all the quizzes a user has completed
        Dim query As String = "Select * From tblUser, tblQuizLog " _
                               & "Where tblUser.UserID = tblQuizLog.UserID " _
                               & "And tblUser.UserID = @0"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", studentId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    student.Firstname = R("Firstname").ToString()
                    student.Lastname = R("Lastname").ToString().ToString()
                    Dim percent As Integer = CalculatePercentage(CInt(R("Total")), CInt(R("Mark")))
                    student.QuizScores.Add(percent)
                End While
            End Using

            For Each score As Integer In student.QuizScores
                student.Average += score
            Next

            student.Average = CInt(student.Average / student.QuizScores.Count)
            'Calculates the average of their score

            Return student
        End Using
    End Function

    Public Function GetStudentsQuizResults(classId As Integer) As List(Of StudentQuizInfo)
        OpenConnection()

        'This query gets a distinct list of the studentIds of all the students who have
        'completed a quiz from a specific class
        Dim query As String = "SELECT Distinct tblUser.UserID FROM tblUser, tblQuizLog, tblUserClass " _
                            & "Where tblQuizLog.UserID = tblUser.UserID " _
                            & "And tblUserClass.UserID = tblUser.UserID " _
                            & "And tblUserClass.ClassID = @0"

        Dim studentIDs As New List(Of Integer)

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", classId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    studentIDs.Add(CInt(R("UserID")))
                End While
            End Using
        End Using

        Dim studentsList As New List(Of StudentQuizInfo)

        For Each id As Integer In studentIDs
            studentsList.Add(GetStudentQuizInfo(id))
        Next

        Dim sortedList = From n In studentsList Order By n.Average Ascending

        CloseConnection()
        Return sortedList.ToList()
    End Function
End Class