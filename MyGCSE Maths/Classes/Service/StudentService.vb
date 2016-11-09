Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class StudentService
    Inherits BaseClass

    Public Overrides Sub PromptLogout()
        If MessageBox.Show("Are you sure you want to logout? Any unfinished work will be lost", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then Logout()
    End Sub

    Public Function GetRandomQuestionsIds(amount As Integer) As List(Of Integer)
        OpenConnection()

        Dim questionList As New List(Of Integer)

        'Selects x amount of random question IDs and returns them.
        Dim query As String = String.Format("Select Top {0} QID From tblQuestion Order By NEWID()", amount)

        Using SQLCmd As New SqlCommand(query, SQLCon)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    questionList.Add(CInt(R("QID")))
                End While
            End Using
        End Using

        CloseConnection()

        Return questionList
    End Function

    Public Function GetUncompletedQuizzes(userId As Integer) As List(Of Quiz)
        OpenConnection()

        Dim quizList As New List(Of Quiz)

        ' Finds the QuizID and Title of all the quizes the student hasn't completed
        Dim query As String = "SELECT Distinct tblQuiz.QuizID, tblQuizTitle.Title " _
                            & "FROM tblQuiz,tblQuizTitle WHERE tblQuiz.QuizID = tblQuizTitle.QuizID " _
                            & "And tblQuiz.QuizID NOT IN (SELECT QuizID FROM tblQuizLog Where UserID = @0)"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", userId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    quizList.Add(New Quiz With {.QuizID = CInt(R("QuizID")), .Title = R("Title").ToString()})
                End While
            End Using
        End Using

        CloseConnection()

        Return quizList
    End Function

    Public Function GetQuestionsIds(quizId As Integer) As List(Of Integer)
        OpenConnection()

        Dim questionIds As New List(Of Integer)

        Dim query As String = String.Format("Select QID From tblQuiz Where QuizID = @0 Order By NEWID()")

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", quizId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    questionIds.Add(CInt(R("QID")))
                End While
            End Using
        End Using

        CloseConnection()

        Return questionIds
    End Function

    Public Function AnswerIsCorrect(actualAnswer As String, userAnswer As String) As Boolean
        actualAnswer = actualAnswer.Replace(" ", String.Empty).ToLower()
        userAnswer = userAnswer.Replace(" ", String.Empty).ToLower()

        ' Replaces every blank spaces. And to converts all to lower, this makes for more accurate marking

        Return userAnswer = actualAnswer
        ' Marks questions and returns true if the user got the answer correct, and false if they haven't.
    End Function

    Public Function SaveQuizResults(quizId As Integer, userId As Integer, mark As Integer, totalQuestions As Integer) As Boolean
        OpenConnection()

        'GetDate() is an inbuilt MSSQL function that gets the current time specific
        Dim query As String = "Insert Into tblQuizLog(UserID, QuizID, Mark, Total, DateCompleted) " _
                            & "Values(@0, @1, @2, @3, GetDate())"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", userId)
            SQLCmd.Parameters.AddWithValue("@1", quizId)
            SQLCmd.Parameters.AddWithValue("@2", mark)
            SQLCmd.Parameters.AddWithValue("@3", totalQuestions)

            If SQLCmd.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
End Class