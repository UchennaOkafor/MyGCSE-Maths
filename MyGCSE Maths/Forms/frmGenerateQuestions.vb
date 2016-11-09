Imports MyGCSE_Maths.BaseClass

Public Class frmGenerateQuestions

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If NumericUpDown1.Value > 0 And cboTopic.SelectedIndex > -1 And cboGrade.SelectedIndex > -1 Then
            Dim promptMsg As String = String.Format("Are you sure you want to generate {0} {1} question(s)", NumericUpDown1.Value, cboTopic.SelectedItem)

            If MessageBox.Show(promptMsg, "Notice", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim topic As Topic = DirectCast(cboTopic.SelectedIndex, Topic)
                Dim grade As Char = CChar(cboGrade.SelectedItem)
                Dim amountRequested As Integer = CInt(NumericUpDown1.Value)

                Dim questionsList As List(Of Question) = QuestionGenerator.GenerateQuestions(topic, grade, amountRequested, chkboxMultiChoice.Checked)

                questionsList.ForEach(Sub(q) QuestionUtil.AddQuestion(q))

                Dim msg As String = String.Format("{0} {1} questions have been generated and added sucessfully!", questionsList.Count, topic.ToString())
                MessageBox.Show(msg)
            End If
        Else
            MessageBox.Show("You must not leave any of the options empty")
        End If
    End Sub
End Class