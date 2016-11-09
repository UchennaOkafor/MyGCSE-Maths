Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class LoginService
    Inherits BaseClass

    Public IsConnected As Boolean

    Public Function HasConnection() As Boolean
        Try
            SQLCon.Open()
            SQLCon.Close()
            IsConnected = True
            Return True
        Catch ex As SqlException
            IsConnected = False
            Return False
        End Try
    End Function

    Public Function CorrectLogin(username As String, password As String) As Boolean
        OpenConnection()

        Dim query As String = "SELECT * FROM tblUser WHERE Username = @0 AND Password = @1"

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", username)
            SQLCmd.Parameters.AddWithValue("@1", password)

            Try
                Using R As SqlDataReader = SQLCmd.ExecuteReader()

                    If R.HasRows Then
                        MyUser = New User

                        While R.Read
                            MyUser.UserID = CInt(R("UserID"))
                            MyUser.Rank = DirectCast(R("Rank"), Rank)
                            MyUser.Firstname = R("Firstname").ToString()
                            MyUser.Lastname = R("Lastname").ToString()
                        End While
                    Else
                        Return False
                    End If

                End Using

                If MyUser.Rank <> Rank.Admin Then
                    MyUser.ClassID = GetClassID(MyUser.UserID)
                End If

            Catch e As Exception
                Throw New Exception(e.Message)
            End Try
        End Using

        CloseConnection()

        Return True
    End Function

    Private Function GetClassID(userId As Integer) As Integer
        'Finds and returns the ClassID of the current user.

        Dim query As String = "SELECT ClassID From tblUserClass Where UserID = @0"
        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", userId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader
                While R.Read
                    Return CInt(R("ClassID"))
                End While
            End Using
        End Using

        Return 0
    End Function
End Class