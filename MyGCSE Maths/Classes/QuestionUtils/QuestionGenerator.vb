Imports System.IO
Imports System.Drawing.Imaging
Imports System.Text
Imports MyGCSE_Maths.BaseClass

Public Class QuestionGenerator

#Region "Shared Methods & Attributes"

    'These are methods and attributes that I want to be shared across all the sub classes in this class.

    Private Enum Difficulty
        Easy
        Medium
        Hard
    End Enum

    Private Shared WordStarters() As String = {"Simplify", "Evaluate", "What is", "Work out", "What is the answer to", "Multiply out these pair of brackets"}
    Private Shared Variables() As String = {"x", "y", "a", "b", "n"}
    Private Shared Powers() As String = {"⁰", "½", "¹", "²"}
    Private Shared Operators() As String = {"+", "-"}
    Private Shared R As New Random()

    Private Shared Function GetDifficulty(grade As Char) As Difficulty
        'The c next to each letter is just to let the compiler know the string is infact a char variable
        Select Case grade
            Case "A"c To "B"c
                Return Difficulty.Hard

            Case "C"c To "D"c
                Return Difficulty.Medium

            Case "E"c
                Return Difficulty.Easy
        End Select
        Return Nothing
    End Function
    Private Shared Function GetRandomPower() As String
        Dim index As Integer = R.Next(0, Powers.Length)
        Return Powers(index)
    End Function
    Private Shared Function GetRandomWord() As String
        Dim index As Integer = R.Next(0, WordStarters.Length - 1) 'I intentionally didn't want to get the last word.
        Return WordStarters(index)
    End Function
    Private Shared Function GetRandomOperator() As String
        Dim index As Integer = R.Next(0, Operators.Length)
        Return Operators(index)
    End Function
    Private Shared Function GetRandomVariable() As String
        Dim index As Integer = R.Next(0, Variables.Length)
        Return Variables(index)
    End Function
    Private Shared Function GetRandomNumber(difficultyLvl As Difficulty) As Integer

        Select Case difficultyLvl
            Case Difficulty.Easy
                Return R.Next(2, 10)

            Case Difficulty.Medium
                Return R.Next(10, 30)

            Case Difficulty.Hard
                Return R.Next(15, 50)
        End Select

        Return Nothing
    End Function

#End Region

    Public Shared Function GenerateQuestions(qTopic As Topic, grade As Char, amountRequested As Integer, multiChoice As Boolean) As List(Of Question)
        Dim difficultyLevel As Difficulty = GetDifficulty(grade)
        Dim questionList As New List(Of Question)

        For i = 1 To amountRequested
            Dim question As New Question

            Select Case qTopic
                Case Topic.Algebra
                    question = New AlgebraQuestion().GenerateQuestion()

                Case Topic.Numbers
                    question = New NumbersQuestion().GenerateQuestion(difficultyLevel)

                Case Topic.Shapes
                    question = New ShapesQuestion().GenerateQuestion()

                Case Topic.HandlingData
                    question = New HandlingDataQuestion().GenerateQuestion(difficultyLevel)

            End Select

            question.Grade = grade
            question.IsMultiChoice = multiChoice
            questionList.Add(question)
        Next

        Return questionList
    End Function

#Region "Question Generator Classes"
    Private Class AlgebraQuestion

        Private thisQuestion As New Question With {.Image = My.Resources.DefaultImg, .Topic = "Algebra"}

        Private Structure Bracket       '(x+3)
            Dim Variable As String      'e.g x or y
            Dim [Operator] As String    'e.g - or +
            Dim Number As Integer       'e.g 3
        End Structure

        Public Function GenerateQuestion() As Question

            Dim word As String = WordStarters(R.Next(2, WordStarters.Length)) 'I only wanted certain values
            Dim var As Char = CChar(GetRandomVariable())

            Dim bracket1 As New Bracket With {.Variable = var, .Number = R.Next(2, 15), .Operator = GetRandomOperator()}
            Dim bracket2 As New Bracket With {.Variable = var, .Number = R.Next(2, 15), .Operator = GetRandomOperator()}

            thisQuestion.QuestionString = String.Format("{0} ({1} {2} {3})({4} {5} {6})", word, bracket1.Variable, bracket1.Operator, bracket1.Number, bracket2.Variable, bracket2.Operator, bracket2.Number)
            'E.g. Calculate (x + 5)(x + 7)

            Dim firstBracketNum As Integer = CInt(bracket1.Operator & bracket1.Number) ' e.g -5
            Dim secondBracketNum As Integer = CInt(bracket2.Operator & bracket2.Number) ' e.g +8

            thisQuestion.Answer = SolveQuestion(var, firstBracketNum, secondBracketNum)
            thisQuestion.FalseAnswers = GenerateFalseAnswers(var, firstBracketNum, secondBracketNum)

            Return thisQuestion
        End Function

        Private Function SolveQuestion(variable As Char, firstBracket As Integer, secondBracket As Integer) As String
            Dim sb As New StringBuilder

            'ax² + bx + c 'This is how the format/forumla of what the answer would be like.

            Dim b As Integer = firstBracket + secondBracket   'The numbers in the first & second bracket. (x+1)(x+3) so the 1 and 3
            Dim c As Integer = firstBracket * secondBracket

            sb.Append(variable & "²") ' e.g. b²

            If b > 0 Then
                sb.Append(" + " & b & variable)
            ElseIf b < 0 Then
                sb.Append(" " & b & variable)
            End If

            ' e.g. b² + 5b

            If c > 0 Then
                sb.Append(" + " & c)
            ElseIf c < 0 Then
                sb.Append(" " & c)
            End If

            ' e.g. b² + 5b - 6

            Return sb.ToString()
        End Function

        Private Function GenerateFalseAnswers(var As Char, firstBracket As Integer, secondBracket As Integer) As String()
            Dim sb As New StringBuilder
            Dim answersFalse(2) As String

            'ax² + bx + c 'This is how the format/forumla of what the answer would be like.

            firstBracket += R.Next(-2, 5) 'Just to make it random so we can recieve a random false answer

            For i = 0 To 2
                sb.Clear()

                Dim b As Integer = firstBracket + Not secondBracket - (R.Next(-5, 5)) 'Just to make it random so we can recieve a random false answer
                Dim c As Integer = Not firstBracket * secondBracket + (R.Next(-5, 5)) 'Just to make it random so we can recieve a random false answer

                sb.Append(var & "²")

                If b > 0 Then
                    sb.Append(" + " & b & var)
                ElseIf b < 0 Then
                    sb.Append(" " & b & var)
                End If

                If c > 0 Then
                    sb.Append(" + " & c)
                ElseIf c < 0 Then
                    sb.Append(" " & c)
                End If

                answersFalse(i) = sb.ToString
            Next

            Return answersFalse
        End Function

    End Class

    Private Class NumbersQuestion

        Private thisQuestion As New Question With {.Image = My.Resources.DefaultImg, .Topic = "Numbers"}

        Public Function GenerateQuestion(difficultyLevel As Difficulty) As Question

            Dim number As Integer = GetRandomNumber(difficultyLevel)
            Dim power As String = GetRandomPower()

            thisQuestion.QuestionString = String.Format("{0} {1}{2}", GetRandomWord, number, power) 'e.g {Evaluate} {5}{²}
            thisQuestion.Answer = SolveQuestion(CInt(number), power)
            thisQuestion.FalseAnswers = GenerateFalseAnswers(thisQuestion.Answer)

            Return thisQuestion
        End Function

        Private Function SolveQuestion(number As Integer, power As String) As String
            Select Case power
                Case "⁰"
                    Return Math.Pow(number, 0).ToString
                Case "½"
                    Return (number / 2).ToString
                Case "¹"
                    Return Math.Pow(number, 1).ToString
                Case "²"
                    Return Math.Pow(number, 2).ToString
                Case Else
                    Return Nothing
            End Select
        End Function

        Private Function GenerateFalseAnswers(correctAnswer As String) As String()
            Dim falseAnswers(2) As String

            falseAnswers(0) = (CInt(correctAnswer) + R.Next(1, 5)).ToString

            falseAnswers(1) = (CInt(correctAnswer) - R.Next(1, 10)).ToString

            falseAnswers(2) = (CInt(correctAnswer) * R.Next(2, 5)).ToString

            Return falseAnswers
        End Function
    End Class

    Private Class ShapesQuestion

        Private Structure TPoint
            Dim Text As String
            Dim xLocation As Integer
            Dim yLocation As Integer
            Dim Format As StringFormatFlags
        End Structure

        Private Enum Shape
            Square
            Rectangle
            Triangle
        End Enum

        Private Enum QuestionType
            Perimeter
            Area
        End Enum

        Dim Shapes() As Shape = {Shape.Rectangle, Shape.Square, Shape.Triangle}
        Private QTypes() As QuestionType = {QuestionType.Area, QuestionType.Perimeter}
        Private Measurements() As String = {"cm", "m"}

        Private thisQuestion As New Question With {.Topic = "Shapes"}

        Public Function GenerateQuestion() As Question

            ReDim thisQuestion.FalseAnswers(2)
            Dim rndShape As Shape = Shapes(R.Next(0, Shapes.Length)) 'Gets a random shape from an array of shapes.
            Dim questionType As QuestionType = QTypes(R.Next(0, QTypes.Length)) 'Gets random question type. Perimeter or Area
            Dim m As String = Measurements(R.Next(0, Measurements.Length)) ' cm or m


            Select Case rndShape
                ' It will also solve the question, and the false answers for the questions too

                Case Shape.Rectangle
                    thisQuestion.Image = Image.FromStream(DrawRectangle(questionType, m))

                Case Shape.Square
                    thisQuestion.Image = Image.FromStream(DrawSquare(questionType, m))

                Case Shape.Triangle
                    thisQuestion.Image = Image.FromStream(DrawTriangle(questionType, m))

            End Select

            Dim a() As String = {"Work out the", "What is the", "Calculate the"}
            Dim b As String = a(R.Next(0, a.Length)) ' Picks random word from the a() array

            thisQuestion.QuestionString = String.Format("{0} {1} of this {2}", b, questionType.ToString.ToLower, rndShape.ToString)
            'E.g {Work out the} {area} of this {Triangle}

            Return thisQuestion
        End Function

        Private Function DrawTriangle(type As QuestionType, unit As String) As MemoryStream

            Dim hypot As Integer = 0
            Dim adjac As Integer = 0
            Dim oppos As Integer = 0
            ' These are the numeric values that will be plotted on each side of the triangle

            Do
                hypot = R.Next(5, 20)
                adjac = R.Next(3, 15)
                oppos = R.Next(2, 10)
            Loop Until hypot > adjac And oppos < adjac
            ' This is to make sure the Adjacent and Opposite sides are never greater than
            '   the hypotenouse. Therefore generating a more realistic question

            Dim lblHypotenouse As New TPoint With {.Text = hypot & unit, .xLocation = 140, .yLocation = 100}
            Dim lblAdjacent As New TPoint With {.Text = adjac & unit, .xLocation = 20, .yLocation = 115}
            Dim lblOpposite As New TPoint With {.Text = oppos & unit, .xLocation = 115, .yLocation = 216}

            Dim coordinateCollection As New Collection From {lblHypotenouse, lblAdjacent, lblOpposite}
            'add to collection so I can take advantage of the for each loop

            Dim canvas As New Bitmap(260, 260)
            Dim myFont As New Font("Arial", 10)

            Dim points(2) As Point ' Each point of the triangle I am yet to draw
            points(0) = New Point(58, 29)
            points(1) = New Point(58, 212)
            points(2) = New Point(214, 212)

            Using g As Graphics = Graphics.FromImage(canvas) : g.Clear(Color.White)
                g.DrawPolygon(Pens.Red, points) ' Draws Triangle

                For Each point As TPoint In coordinateCollection
                    g.DrawString(point.Text, myFont, Brushes.Green, New Point(point.xLocation, point.yLocation))
                    'Draws labels on the triangle
                Next

                g.Save()
            End Using

            SolveTriangleQuestion(type, hypot, oppos, adjac, unit)

            Dim memoryStrm As New MemoryStream()
            canvas.Save(memoryStrm, ImageFormat.Jpeg)
            DisposeObjects(canvas, myFont)

            Return memoryStrm
        End Function

        Private Function DrawSquare(type As QuestionType, unit As String) As MemoryStream

            'unit. E.g. cm or m

            Dim num As Integer = R.Next(1, 50)

            Dim labelA As New TPoint With {.Text = num & unit, .xLocation = 110, .yLocation = 15}
            Dim labelB As New TPoint With {.Text = num & unit, .xLocation = 15, .yLocation = 110, .Format = StringFormatFlags.DirectionVertical}

            Dim coordinateCollection As New Collection From {labelA, labelB}

            Dim canvas As New Bitmap(260, 260)
            Dim myFont As New Font("Arial", 10)

            Using g As Graphics = Graphics.FromImage(canvas) : g.Clear(Color.White)
                g.DrawRectangle(Pens.Blue, 35, 35, 190, 190) ' Draws the Square

                For Each point As TPoint In coordinateCollection
                    Dim sF As New StringFormat With {.FormatFlags = point.Format} 'This allows me to rotate the text
                    g.DrawString(point.Text, myFont, Brushes.Red, New Point(point.xLocation, point.yLocation), sF)
                Next

                g.Save()
            End Using

            SolveSquareQuestion(type, num, unit)

            Dim memoryStrm As New MemoryStream()
            canvas.Save(memoryStrm, ImageFormat.Jpeg)

            DisposeObjects(canvas, myFont)

            Return memoryStrm
        End Function

        Private Function DrawRectangle(type As QuestionType, unit As String) As MemoryStream
            Dim base As Integer = R.Next(5, 55)
            Dim height As Integer = R.Next(5, 25)

            Do
                base = R.Next(5, 55)
                height = R.Next(5, 25)
            Loop Until base > height ' Ensures the base length is always greater 

            Dim lblBase As New TPoint With {.Text = base & unit, .xLocation = 108, .yLocation = 30}
            Dim lblHeight As New TPoint With {.Text = height & unit, .xLocation = 15, .yLocation = 100}

            Dim coordinateCollection As New Collection From {lblBase, lblHeight}

            Dim canvas As New Bitmap(260, 260)
            Dim myFont As New Font("Arial", 10)

            Using g As Graphics = Graphics.FromImage(canvas) : g.Clear(Color.White)
                g.DrawRectangle(Pens.Blue, 15, 50, 230, 120) ' Draws the rectangle

                For Each point As TPoint In coordinateCollection
                    g.DrawString(point.Text, myFont, Brushes.Red, New Point(point.xLocation, point.yLocation))
                Next 'Draws the text of each label on each side.

                g.Save()
            End Using

            SolveRectangleQuestion(type, base, height, unit)

            Dim memoryStrm As New MemoryStream()
            canvas.Save(memoryStrm, ImageFormat.Jpeg)
            DisposeObjects(canvas, myFont)

            Return memoryStrm
        End Function

        Private Sub SolveTriangleQuestion(type As QuestionType, hypo As Integer, opposite As Integer, adjacent As Integer, unit As String)

            If type = QuestionType.Area Then
                thisQuestion.Answer = ((opposite * adjacent) / 2) & unit & "²" ' Calculates the area

                thisQuestion.FalseAnswers(0) = (hypo + opposite + adjacent) & unit ' Confuses student by calculating perimeter
                thisQuestion.FalseAnswers(1) = (opposite * adjacent) & unit & "²"

            ElseIf type = QuestionType.Perimeter Then
                thisQuestion.Answer = (hypo + opposite + adjacent) & unit ' Calculates the perimeter

                thisQuestion.FalseAnswers(0) = ((opposite * adjacent) / 2) & unit & "²" ' Confuses student by calculating area
                thisQuestion.FalseAnswers(1) = hypo + opposite & unit
            End If

            thisQuestion.FalseAnswers(2) = R.Next(opposite, hypo) & unit
        End Sub

        Private Sub SolveSquareQuestion(type As QuestionType, side As Integer, unit As String)
            If type = QuestionType.Area Then
                thisQuestion.Answer = Math.Pow(side, 2) & unit & "²"
                thisQuestion.FalseAnswers(0) = (side * 4) & unit ' To throw off the student

            ElseIf type = QuestionType.Perimeter Then
                thisQuestion.Answer = (side * 4) & unit
                thisQuestion.FalseAnswers(0) = Math.Pow(side, 2) & unit & "²"  ' To throw off the student
            End If

            thisQuestion.FalseAnswers(1) = ((side / 2) + R.Next(0, side)) & unit
            thisQuestion.FalseAnswers(2) = ((side / 2) * 4) & unit
        End Sub

        Private Sub SolveRectangleQuestion(type As QuestionType, base As Integer, height As Integer, unit As String)
            If type = QuestionType.Area Then
                thisQuestion.Answer = base * height & unit & "²"
                thisQuestion.FalseAnswers(0) = (base * 2) + (height * 2) & unit   ' To throw off the student

            ElseIf type = QuestionType.Perimeter Then
                thisQuestion.Answer = (base * 2) + (height * 2) & unit
                thisQuestion.FalseAnswers(0) = base * height & unit & "²"  ' To throw off the student
            End If

            thisQuestion.FalseAnswers(1) = R.Next(height, base) & unit
            thisQuestion.FalseAnswers(2) = R.Next(height, base) & unit & "²"
        End Sub

        Private Sub DisposeObjects(ByRef b As Bitmap, ByRef f As Font)
            b.Dispose()
            f.Dispose()
        End Sub

    End Class

    Private Class HandlingDataQuestion

        Private thisQuestion As New Question With {.Image = My.Resources.DefaultImg, .Topic = "Handling Data"}

        Public Function GenerateQuestion(difficultyLevel As Difficulty) As Question

            Dim percentages() As Integer = {5, 10, 12, 15, 17, 20, 22, 25, 30, 32, 35, 40, 42, 50} 'the list of possible percentages
            Dim number As Integer = GetRandomNumber(difficultyLevel)
            Dim percent As Integer = percentages(R.Next(0, percentages.Length)) 'gets a random percentage from the percentages() array

            Dim a() As String = {"What is", "Work out", "Calculate the answer to", "Work out the percentage to"}
            Dim b As String = a(R.Next(0, a.Length)) 'Gets a random word from the array above

            thisQuestion.QuestionString = String.Format("{0} {1}% of £{2}", b, percent, number)
            thisQuestion.Answer = SolveQuestion(percent, number)
            thisQuestion.FalseAnswers = GenerateFalseAnswers(CDbl(thisQuestion.Answer))

            Return thisQuestion
        End Function

        Private Function SolveQuestion(percentage As Integer, number As Integer) As String
            Dim onePercent As Double = percentage / 100 'Find out what one percent is first.
            Return "£" & (onePercent * number).ToString 'Then times it by the amount of percentage we need
        End Function

        Private Function GenerateFalseAnswers(answer As Double) As String()
            Dim falseAnswers(2) As String

            falseAnswers(0) = "£" & (answer + R.Next(2, 10)).ToString
            falseAnswers(1) = "£" & (answer - R.Next(2, 5)).ToString
            falseAnswers(2) = "£" & (answer * R.Next(2, 5)).ToString

            Return falseAnswers
        End Function

    End Class

#End Region

End Class