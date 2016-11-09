Public Class ClassRoom

    Public ClassID As Integer
    Public Block As Char 'G or A

    'I'm overrding the ToString() method because I will be adding this Structure 
    'Into a ComboBox control as an Object, which will run the ToString() on the item added,
    'Which would return the name of the object E.g. MyGCSE_Maths.BaseClass.ClassRoom
    'And by overrding the ToString() method, we can get it to show anything we want.

    Public Overrides Function ToString() As String
        Return "Block " & Block
    End Function

End Class
