Imports MyGCSE_Maths.BaseClass
Public Class CustomPictureBox
    Inherits PictureBox

    Private _UserID As Integer
    Private _Username, _Password As String

    Public Property UserID As Integer
        Get
            Return _UserID
        End Get

        Set(value As Integer)
            _UserID = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _Username
        End Get

        Set(value As String)
            _Username = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get

        Set(value As String)
            _Password = value
        End Set
    End Property
End Class

Public Class CustomTreeNode
    Inherits TreeNode

    Private _QuestionID As Integer

    Public Property QuestionID() As Integer
        Get
            Return _QuestionID
        End Get
        Set(value As Integer)
            _QuestionID = value
        End Set
    End Property

End Class

Public Class CustomLinkLabel
    Inherits LinkLabel

    Private _QuizID As Integer

    Public Property QuizID() As Integer
        Get
            Return _QuizID
        End Get
        Set(value As Integer)
            _QuizID = value
        End Set
    End Property

End Class