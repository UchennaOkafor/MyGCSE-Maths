Public Class Question

    Public QuestionString As String
    Public QuestionID As Integer? 'The question mark means it can be null
    Public Answer As String
    Public IsMultiChoice As Boolean
    Public Image As Image
    Public Topic As String
    Public Grade As Char
    Public FalseAnswers() As String

    Public Overrides Function ToString() As String
        Return QuestionString
    End Function

End Class
