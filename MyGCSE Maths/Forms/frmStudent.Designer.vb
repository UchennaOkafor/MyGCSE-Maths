<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStudent))
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblWelcomeBack = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picQuestion = New System.Windows.Forms.PictureBox()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.rdoFalseAnswer3 = New System.Windows.Forms.RadioButton()
        Me.rdoFalseAnswer2 = New System.Windows.Forms.RadioButton()
        Me.rdoFalseAnswer1 = New System.Windows.Forms.RadioButton()
        Me.rdoCorrectAnswer = New System.Windows.Forms.RadioButton()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblHomework = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Image = Global.MyGCSE_Maths.My.Resources.Resources._1415569111_gnome_logout
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(834, 12)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(86, 35)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblWelcomeBack
        '
        Me.lblWelcomeBack.AutoSize = True
        Me.lblWelcomeBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeBack.Location = New System.Drawing.Point(25, 12)
        Me.lblWelcomeBack.Name = "lblWelcomeBack"
        Me.lblWelcomeBack.Size = New System.Drawing.Size(108, 18)
        Me.lblWelcomeBack.TabIndex = 5
        Me.lblWelcomeBack.Text = "Welome back, "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.picQuestion)
        Me.GroupBox1.Controls.Add(Me.txtAnswer)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Controls.Add(Me.rdoFalseAnswer3)
        Me.GroupBox1.Controls.Add(Me.rdoFalseAnswer2)
        Me.GroupBox1.Controls.Add(Me.rdoFalseAnswer1)
        Me.GroupBox1.Controls.Add(Me.rdoCorrectAnswer)
        Me.GroupBox1.Controls.Add(Me.lblQuestion)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(889, 439)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Question 1"
        Me.GroupBox1.Visible = False
        '
        'picQuestion
        '
        Me.picQuestion.Location = New System.Drawing.Point(6, 33)
        Me.picQuestion.Name = "picQuestion"
        Me.picQuestion.Size = New System.Drawing.Size(324, 316)
        Me.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picQuestion.TabIndex = 8
        Me.picQuestion.TabStop = False
        '
        'txtAnswer
        '
        Me.txtAnswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnswer.Location = New System.Drawing.Point(351, 285)
        Me.txtAnswer.Multiline = True
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.Size = New System.Drawing.Size(509, 64)
        Me.txtAnswer.TabIndex = 7
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(764, 355)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(96, 38)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'rdoFalseAnswer3
        '
        Me.rdoFalseAnswer3.AutoSize = True
        Me.rdoFalseAnswer3.Location = New System.Drawing.Point(351, 248)
        Me.rdoFalseAnswer3.Name = "rdoFalseAnswer3"
        Me.rdoFalseAnswer3.Size = New System.Drawing.Size(14, 13)
        Me.rdoFalseAnswer3.TabIndex = 6
        Me.rdoFalseAnswer3.TabStop = True
        Me.rdoFalseAnswer3.UseVisualStyleBackColor = True
        '
        'rdoFalseAnswer2
        '
        Me.rdoFalseAnswer2.AutoSize = True
        Me.rdoFalseAnswer2.Location = New System.Drawing.Point(351, 197)
        Me.rdoFalseAnswer2.Name = "rdoFalseAnswer2"
        Me.rdoFalseAnswer2.Size = New System.Drawing.Size(14, 13)
        Me.rdoFalseAnswer2.TabIndex = 5
        Me.rdoFalseAnswer2.TabStop = True
        Me.rdoFalseAnswer2.UseVisualStyleBackColor = True
        '
        'rdoFalseAnswer1
        '
        Me.rdoFalseAnswer1.AutoSize = True
        Me.rdoFalseAnswer1.Location = New System.Drawing.Point(351, 147)
        Me.rdoFalseAnswer1.Name = "rdoFalseAnswer1"
        Me.rdoFalseAnswer1.Size = New System.Drawing.Size(14, 13)
        Me.rdoFalseAnswer1.TabIndex = 4
        Me.rdoFalseAnswer1.TabStop = True
        Me.rdoFalseAnswer1.UseVisualStyleBackColor = True
        '
        'rdoCorrectAnswer
        '
        Me.rdoCorrectAnswer.AutoSize = True
        Me.rdoCorrectAnswer.Location = New System.Drawing.Point(351, 97)
        Me.rdoCorrectAnswer.Name = "rdoCorrectAnswer"
        Me.rdoCorrectAnswer.Size = New System.Drawing.Size(14, 13)
        Me.rdoCorrectAnswer.TabIndex = 3
        Me.rdoCorrectAnswer.TabStop = True
        Me.rdoCorrectAnswer.UseVisualStyleBackColor = True
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.Location = New System.Drawing.Point(348, 18)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(114, 18)
        Me.lblQuestion.TabIndex = 0
        Me.lblQuestion.Text = "-Question Here-"
        '
        'lblHomework
        '
        Me.lblHomework.AutoSize = True
        Me.lblHomework.Location = New System.Drawing.Point(26, 45)
        Me.lblHomework.Name = "lblHomework"
        Me.lblHomework.Size = New System.Drawing.Size(102, 16)
        Me.lblHomework.TabIndex = 10
        Me.lblHomework.Text = "{due tests here}"
        '
        'frmStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 593)
        Me.Controls.Add(Me.lblHomework)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblWelcomeBack)
        Me.Controls.Add(Me.btnLogout)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmStudent"
        Me.Text = "MyGCSE Maths - Students Panel"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents lblWelcomeBack As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents txtAnswer As System.Windows.Forms.TextBox
    Friend WithEvents rdoFalseAnswer3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFalseAnswer2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFalseAnswer1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCorrectAnswer As System.Windows.Forms.RadioButton
    Friend WithEvents picQuestion As System.Windows.Forms.PictureBox
    Friend WithEvents lblHomework As System.Windows.Forms.Label
End Class
