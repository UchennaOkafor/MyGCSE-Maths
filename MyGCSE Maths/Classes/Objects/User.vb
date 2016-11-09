Public Class User

    Public UserID As Integer
    Public Firstname As String
    Public Lastname As String
    Public Username As String
    Public Password As String
    Public Rank As Rank
    Public ClassID As Integer
    Public ClassName As String
    Public Image As Image
    Public Email As String


    'I'm overrding the ToString() method because I will be adding this Structure 
    'Into a ListBox control as an Object, which will run the ToString() on the item added,
    'Which would return the name of the object E.g. MyGCSE_Maths.BaseClass.User
    'And by overrding the ToString() method, we can get it to show anything we want.

    Public Overrides Function ToString() As String
        Return Firstname & " " & Lastname
    End Function

End Class

Public Enum Rank
    Student = 0
    Teacher = 1
    Admin = 2
End Enum