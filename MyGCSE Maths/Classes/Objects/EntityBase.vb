Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices

Public Class BaseClass
    Public Shared SQLCon As New SqlConnection With {.ConnectionString = "Server=Dev;Database=Hi;Trusted_Connection=True"}
    ' Public Shared SQLCon As New SqlConnection With {.ConnectionString = "Server=sfxlabdev01\sQL2012;Database=okaforu4436_db;Trusted_Connection=True"}

    Public Shared SQLCmd As SqlCommand

    Public Shared MyUser As User
    'MyUser is the user that is currently logged in to the system

#Region "Strucutres & Enum declerations"

    Public Enum ActionType
        Add
        Edit
    End Enum

    Public Enum Topic
        Numbers = 0
        Shapes = 1
        Algebra = 2
        HandlingData = 3
    End Enum

#End Region

#Region "Shared Methods"

    Public Shared Sub OpenConnection()
        'Every time I fire a new SQL query/command, this sub will be called to open the connection.

        If SQLCon.State = ConnectionState.Closed Or SQLCon.State = ConnectionState.Broken Then SQLCon.Open()
    End Sub

    Public Shared Sub CloseConnection()
        SQLCon.Close()
    End Sub

    Public Overridable Sub PromptLogout()
        'It will say something different for students.

        If MessageBox.Show("Are you sure you want to logout?", "Prompt", MessageBoxButtons.YesNo) = DialogResult.Yes Then Logout()
    End Sub

    Public Sub Logout()
        'Disposes all forms. And releases all the information stored for the current user(MyUser)

        frmAdmin.Dispose()
        frmEdit.Dispose()
        frmStudent.Dispose()
        frmTeacher.Dispose()
        frmQuestions.Dispose()
        frmGenerateQuestions.Dispose()

        MyUser = Nothing

        frmLogin.Show()
        frmLogin.BringToFront()
    End Sub

#End Region

End Class

Public Module MyExtensions

    'This is a custom Extension, this extends the byte datatype and picturebox. So I can call .ToStream()
    'on any variable of the datatype Byte() same thing with pictruebox, I can call it like PicBox1.Image.ToBytes()
    'It's just my preference, and makes calling this function look neater than doing ToBytes(PicBox1.Image)

    <Extension()>
    Public Function ToImage(value As Byte()) As Image
        'Converts the byte array to a memory stream

        If value Is Nothing Then
            Return My.Resources.DefaultImg
        Else
            Return Image.FromStream(New MemoryStream(value))
        End If

    End Function

    <Extension()>
    Public Function ToBytes(img As Image) As Byte()
        'Converts the Image data/object to an array of bytes.

        Dim ms As New MemoryStream

        If img Is Nothing Then
            My.Resources.DefaultImg.Save(ms, My.Resources.DefaultImg.RawFormat)
        Else
            img.Save(ms, img.RawFormat)
        End If

        Return ms.GetBuffer()
    End Function

End Module