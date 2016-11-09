Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports MyGCSE_Maths.BaseClass

Public Class AdminService

#Region "frmAdmin"

    Public Function GetUsers(name As String) As List(Of User)
        OpenConnection()

        'Searches for all the students' firstname from the sql user table
        Dim query As String = "SELECT * FROM tblUser " _
                            & "WHERE Firstname + ' ' + Lastname LIKE @0 " _
                            & "Order By Rank Desc"

        Dim usersList As New List(Of User)

        Using SQLCmd As New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", "%" & name & "%")

            Using R As SqlDataReader = SQLCmd.ExecuteReader()
                If R.HasRows Then
                    While R.Read
                        Dim thisUser As New User

                        thisUser.UserID = CInt(R("UserID"))
                        thisUser.Firstname = R("Firstname").ToString
                        thisUser.Lastname = R("Lastname").ToString
                        thisUser.Rank = DirectCast(R("Rank"), Rank)

                        'adds all the users found to a usersList.
                        usersList.Add(thisUser)
                    End While
                Else
                    Return Nothing
                End If
            End Using
        End Using


        CloseConnection()

        'Returns all the users found
        Return usersList
    End Function

    Public Function AddAccount(userId As Integer, firstname As String, lastname As String, userRank As Rank, img As Image, classId As Integer) As Boolean
        OpenConnection()

        Dim query As String = "INSERT INTO tblUser(UserID,Firstname,Lastname,Email,Picture,Username,Password,Rank) " _
                             & "VALUES (@0, @1, @2, @3, @img, @4, @5, @6);"

        'every occurance of a non alphabetic character
        firstname = ParseStr(firstname)
        lastname = ParseStr(lastname)

        Dim username As String = GenerateUsername(userId, firstname, lastname, userRank)
        Dim password As String = GeneratePassword()
        Dim email As String = GenerateEmail(userId, firstname, lastname, userRank)

        Try
            Using SQLCmd As New SqlCommand(query, SQLCon)

                SQLCmd.Parameters.AddWithValue("@0", userId)
                SQLCmd.Parameters.AddWithValue("@1", firstname)
                SQLCmd.Parameters.AddWithValue("@2", lastname)
                SQLCmd.Parameters.AddWithValue("@3", email)
                SQLCmd.Parameters.AddWithValue("@img", img)

                SQLCmd.Parameters.AddWithValue("@4", username)
                SQLCmd.Parameters.AddWithValue("@5", password)
                SQLCmd.Parameters.AddWithValue("@6", CInt(userRank))

                If SQLCmd.ExecuteNonQuery = 1 Then
                    If Not userRank = Rank.Admin Then
                        Return AddUserClass(userId, classId)
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If

            End Using

        Catch ex As SqlException
            If ex.Message.Contains("Cannot insert duplicate key") Then
                Throw New Exception("The UserID: " & userId & " already exists")
            Else
                Throw New Exception(ex.Message)
            End If
        End Try

        CloseConnection()
    End Function

    Private Function AddUserClass(userId As Integer, classId As Integer) As Boolean
        'Adds a user to a class. Only teachers and students can be added to a class.

        Dim query As String = "Insert Into tblUserClass(UserID, ClassID) Values(@0, @1);"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", userId)
            SQLCmd.Parameters.AddWithValue("@1", classId)

            If SQLCmd.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If
        End Using

    End Function

    Private Function ParseStr(txt As String) As String
        ' Replaces every occurance of a non alphabetic text, excluding - and returns the value
        Return Regex.Replace(txt, "[^a-zA-Z\- ]", String.Empty)
    End Function

    Private Function GenerateEmail(userId As Integer, firstname As String, lastname As String, userRank As Rank) As String
        'Generates the Email of the user according to the information provided through the paramaters.
        'This mimics the college system

        Dim email As String = String.Empty

        If userRank = Rank.Student Then
            If lastname.Length > 7 Then lastname = lastname.Substring(0, 7)
            email = String.Format("{0}{1}{2}@student.sfx.ac.uk", lastname, firstname.Substring(0, 1), userId)
        Else
            email = String.Format("{0}.{1}@sfx.ac.uk", firstname.Substring(0, 1), lastname)
        End If

        Return email.ToLower()
    End Function

    Private Function GenerateUsername(userId As Integer, firstname As String, lastname As String, userRank As Rank) As String
        Dim username As String = String.Empty

        If userRank = Rank.Student Then
            If lastname.Length > 7 Then lastname = lastname.Substring(0, 7)
            username = lastname & firstname.Substring(0, 1) & userId.ToString
        Else
            username = firstname.Substring(0, 1) & lastname
        End If

        Return username.ToLower()
    End Function

    Private Function GeneratePassword() As String

        Dim str As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder

        For i = 1 To 4
            Dim rdnNum As Integer = r.Next(0, str.Length - 1)
            sb.Append(str.Substring(rdnNum, 2))
            ' Picks a random substring from the str variable and appends it to a string builder
        Next

        Return sb.ToString()
    End Function

    Public Function GetAllClasses() As List(Of ClassRoom)
        OpenConnection()

        Dim classList As New List(Of ClassRoom)

        Dim query As String = "Select * From tblClass Order By Block Asc"
        'Selects all the classes in the system

        Using SQLCmd As New SqlCommand(query, SQLCon)
            Using R As SqlDataReader = SQLCmd.ExecuteReader()
                While R.Read

                    Dim block As Char = CChar(R("Block"))
                    Dim classId As Integer = CInt(R("ClassID"))
                    Dim item As New ClassRoom With {.Block = block, .ClassID = classId}

                    classList.Add(item)
                End While
            End Using
        End Using

        CloseConnection()
        Return classList
    End Function

    Public Function CreateClass(block As Char, room As String) As Boolean
        OpenConnection()

        'Creates a new class
        Dim query As String = "Insert Into tblClass(Block,Room) Values(@0, @1)"

        Using SQLCmd As New SqlCommand(query, SQLCon)
            SQLCmd.Parameters.AddWithValue("@0", block)
            SQLCmd.Parameters.AddWithValue("@1", room)

            If SQLCmd.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If

        End Using

        CloseConnection()
    End Function

    Public Sub AddOccupiedClasses()
        OpenConnection()

        'Gets information of what class either a teacher or students belongs to
        Dim query As String = "Select Block,Room,Firstname,Lastname From tblClass,tblUserClass,tblUser " _
                            & "Where Rank = 1 And tblUser.UserID = tblUserClass.UserID " _
                            & "And tblUserClass.ClassID = tblClass.ClassID "

        Using SQLCmd = New SqlCommand(query, SQLCon)

            Using R As SqlDataReader = SQLCmd.ExecuteReader()
                While R.Read
                    frmAdmin.DataGridView1.Rows.Add({R("Block").ToString(), R("Room").ToString(), R("Firstname").ToString(), R("Lastname").ToString()})
                    'Adds each array of item fetched to the DataGridView 
                End While
            End Using
        End Using

        CloseConnection()
    End Sub

    Public Sub AddEmptyClasses()
        'Gets all the classes that no teacher is currently teaching

        OpenConnection()

        Dim query As String = "Select * From tblClass " _
                            & "Where tblClass.ClassID NOT IN " _
                            & "(Select ClassID From tblUserClass, tblUser Where tblUser.UserID = tblUserClass.UserID And tblUser.[Rank] = 1)"

        Using SQLCmd = New SqlCommand(query, SQLCon)

            Using R As SqlDataReader = SQLCmd.ExecuteReader()
                While R.Read
                    frmAdmin.DataGridView1.Rows.Add({R("Block").ToString(), R("Room").ToString()})
                End While
            End Using
        End Using

        CloseConnection()
    End Sub

#End Region

#Region "frmEdit"

    Public Function DeleteAccount(userId As Integer) As Boolean

        OpenConnection()

        Dim query As String = "DELETE FROM tblUser Where UserID = @0;" _
                              & "DELETE FROM tblQuizLog Where UserID = @0;" _
                              & "DELETE FROM tblUserClass Where UserID = @0;"

        Try
            Using SQLCmd = New SqlCommand(query, SQLCon)
                SQLCmd.Parameters.AddWithValue("@0", userId)

                If SQLCmd.ExecuteNonQuery >= 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As SqlException
            Throw New Exception(ex.Message)
        End Try

        CloseConnection()
    End Function

    Public Function UpdateAccount(userId As Integer, firstname As String, lastname As String, email As String, password As String, img As Image, classId As Integer, userRank As Rank) As Boolean
        OpenConnection()

        Dim query As String = String.Empty

        If userRank = Rank.Admin Then
            query = "UPDATE tblUser SET Firstname = @1, Lastname = @2, Email = @3, Picture = @4, Password = @5 WHERE UserID = @0;"
        Else
            query = "UPDATE tblUser SET Firstname = @1, Lastname = @2, Email = @3, Picture = @4, Password = @5 WHERE UserID = @0;" _
                      & " UPDATE tblUserClass SET ClassID = @6 WHERE UserID = @0"
        End If

        Try
            Using SQLCmd = New SqlCommand(query, SQLCon)

                SQLCmd.Parameters.AddWithValue("@0", userId)
                SQLCmd.Parameters.AddWithValue("@1", firstname)
                SQLCmd.Parameters.AddWithValue("@2", lastname)
                SQLCmd.Parameters.AddWithValue("@3", email)
                SQLCmd.Parameters.AddWithValue("@4", ToBytes(img))
                SQLCmd.Parameters.AddWithValue("@5", password)

                If userRank <> Rank.Admin Then SQLCmd.Parameters.AddWithValue("@6", classId)

                If SQLCmd.ExecuteNonQuery >= 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As SqlException
            Throw New Exception(ex.Message)
        End Try

        CloseConnection()
    End Function

    Public Function GetUserInformation(userId As Integer, userRank As Rank) As User

        OpenConnection()

        Dim query As String = String.Empty
        Dim user As New User

        If userRank = Rank.Admin Then
            query = "SELECT * From tblUser WHERE tblUser.UserID = @0"
        Else
            query = "SELECT * From tblUser, tblClass, tblUserClass " _
                  & "WHERE tblUserClass.ClassID = tblClass.ClassID " _
                  & "AND tblUser.UserID = tblUserClass.UserID AND tblUser.UserID = @0"
        End If

        Using SQLCmd = New SqlCommand(query, SQLCon)

            SQLCmd.Parameters.AddWithValue("@0", userId)

            Using R As SqlDataReader = SQLCmd.ExecuteReader()
                While R.Read
                    user.UserID = CInt(R("UserID"))
                    user.Username = R("Username").ToString()
                    user.Password = R("Password").ToString()
                    user.Rank = CType(R("Rank"), Rank)

                    If userRank <> Rank.Admin Then user.ClassName = "Block " & R("Block").ToString ' E.g. Block A

                    user.Firstname = R("Firstname").ToString()
                    user.Lastname = R("Lastname").ToString()
                    user.Email = R("Email").ToString()
                    user.Image = DirectCast(R("Picture"), Byte()).ToImage()
                End While
            End Using
        End Using
        CloseConnection()
        Return user
    End Function

#End Region

End Class