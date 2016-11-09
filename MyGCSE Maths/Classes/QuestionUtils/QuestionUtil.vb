Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports MyGCSE_Maths.BaseClass

Public Class QuestionUtil

    Public Shared Sub AddQuestion(newQuestion As Question)
        OpenConnection()

        Dim query As String = "Insert Into tblQuestion(Topic, Grade, Question, Image, Answer, MultiChoice) Values(@0, @1, @2, @3, @4, @5);"

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", newQuestion.Topic)
            SQLCmd.Parameters.AddWithValue("@1", newQuestion.Grade)
            SQLCmd.Parameters.AddWithValue("@2", newQuestion.QuestionString)
            SQLCmd.Parameters.AddWithValue("@3", newQuestion.Image.ToBytes())
            SQLCmd.Parameters.AddWithValue("@4", newQuestion.Answer)
            SQLCmd.Parameters.AddWithValue("@5", newQuestion.IsMultiChoice)

            If SQLCmd.ExecuteNonQuery >= 1 Then
                If newQuestion.IsMultiChoice Then
                    AddFalseAnswers(newQuestion.FalseAnswers)
                End If
            Else
                Throw New Exception("Error trying to insert a new question")
            End If

        End Using

        CloseConnection()
    End Sub

    Public Shared Function DeleteQuestion(questionId As Integer) As Boolean
        OpenConnection()

        Dim query As String = "Delete From tblQuestion Where QID = @0;" _
                              & "Delete From tblWrongAnswers Where QID = @0;" _
                              & "Delete From tblQuiz Where QID = @0"

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", questionId)

            If SQLCmd.ExecuteNonQuery >= 1 Then
                Return True
            Else
                Return False
            End If

        End Using

    End Function

    Public Shared Function UpdateQuestion(QuestionID As Integer, newQuestion As Question) As Boolean
        OpenConnection()

        Dim query As String = "Update tblQuestion Set Topic = @0, Grade = @1, Question = @2, Image = @3, Answer = @4, MultiChoice = @5 Where QID = @6"

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", newQuestion.Topic)
            SQLCmd.Parameters.AddWithValue("@1", newQuestion.Grade)
            SQLCmd.Parameters.AddWithValue("@2", newQuestion.QuestionString)
            SQLCmd.Parameters.AddWithValue("@3", newQuestion.Image)
            SQLCmd.Parameters.AddWithValue("@4", newQuestion.Answer)
            SQLCmd.Parameters.AddWithValue("@5", newQuestion.IsMultiChoice)
            SQLCmd.Parameters.AddWithValue("@6", QuestionID)

            If SQLCmd.ExecuteNonQuery = 1 Then
                If newQuestion.IsMultiChoice = True Then
                    Return UpdateMultiChoice(QuestionID, newQuestion.FalseAnswers)
                Else
                    Return True
                End If
            Else
                Return False
            End If

        End Using

        CloseConnection()
    End Function

    Private Shared Function UpdateMultiChoice(questionId As Integer, falseAnswers() As String) As Boolean

        OpenConnection()
        Dim query As String = "Update tblWrongAnswers Set Dummy1 = @A1, Dummy2 = @A2, Dummy3 = @A3 Where QID = @QID"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@QID", questionId)
            SQLCmd.Parameters.AddWithValue("A1", falseAnswers(0))
            SQLCmd.Parameters.AddWithValue("A2", falseAnswers(1))
            SQLCmd.Parameters.AddWithValue("A3", falseAnswers(2))

            If SQLCmd.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If

        End Using

        CloseConnection()
    End Function

    Private Shared Function GetNextIncrement() As Integer
        Dim query As String = "Select QID From tblQuestion Order By QID  Desc"

        Dim _NextID As Integer = 1
        'Setting it as one because if there were 
        'no records, the next one would be 1 since my Auto Increment increments by 1

        Using SQLCmd As New SqlCommand(query, SQLCon)
            _NextID = CInt(SQLCmd.ExecuteScalar)
        End Using

        Return _NextID
    End Function

    Private Shared Function AddFalseAnswers(wrongAnswers() As String) As Boolean
        Dim query As String = "Insert Into tblWrongAnswers(QID, Dummy1, Dummy2, Dummy3) Values(@0, @1, @2, @3)"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", GetNextIncrement)

            SQLCmd.Parameters.AddWithValue("@1", wrongAnswers(0))
            SQLCmd.Parameters.AddWithValue("@2", wrongAnswers(1))
            SQLCmd.Parameters.AddWithValue("@3", wrongAnswers(2))

            If SQLCmd.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If

        End Using
    End Function

    Public Shared Function GetQuestion(questionId As Integer) As Question
        OpenConnection()
        'Gets all the information of a question and returns the question

        Dim query As String = "Select * From tblQuestion Where QID = @0"
        Dim q As New Question

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", questionId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    q.QuestionID = Convert.ToInt32(R("QID"))
                    q.QuestionString = Convert.ToString("Question")
                    q.Image = DirectCast(R("Image"), Byte()).ToImage()
                    q.Answer = Convert.ToString("Answer")
                    q.IsMultiChoice = Convert.ToBoolean(R("MultiChoice"))
                    q.Topic = R("Topic").ToString()
                    q.Grade = Convert.ToChar(R("Grade"))
                End While
            End Using
        End Using

        If q.IsMultiChoice Then q.FalseAnswers = GetFalseAnswers(CInt(q.QuestionID))

        CloseConnection()

        Return q
    End Function

    Private Shared Function GetFalseAnswers(questionId As Integer) As String()
        OpenConnection()

        Dim query As String = "Select * From tblWrongAnswers Where QID = @0"
        Dim answersArray(3) As String

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", questionId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    answersArray(0) = R("Dummy1").ToString()
                    answersArray(1) = R("Dummy2").ToString()
                    answersArray(2) = R("Dummy3").ToString()
                End While
            End Using
        End Using

        CloseConnection()

        Return answersArray
    End Function

End Class