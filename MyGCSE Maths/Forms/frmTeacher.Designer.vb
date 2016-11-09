<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeacher
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeacher))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMngClass = New System.Windows.Forms.TabPage()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblWelcomeBack = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStudentCount = New System.Windows.Forms.Label()
        Me.GroupBoxSearch = New System.Windows.Forms.GroupBox()
        Me.txtSearchField = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tabProgress = New System.Windows.Forms.TabPage()
        Me.LinkLblViewAll = New System.Windows.Forms.LinkLabel()
        Me.lblQuizInfo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkDataPoint = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboChartType = New System.Windows.Forms.ComboBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabQuestions = New System.Windows.Forms.TabPage()
        Me.btnExportAnswers = New System.Windows.Forms.Button()
        Me.rdoQuiz = New System.Windows.Forms.RadioButton()
        Me.rdoQuestions = New System.Windows.Forms.RadioButton()
        Me.btnDeleteQuestion = New System.Windows.Forms.Button()
        Me.btnAddQuiz = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGrade = New System.Windows.Forms.ComboBox()
        Me.cboTopic = New System.Windows.Forms.ComboBox()
        Me.tvQuestions = New System.Windows.Forms.TreeView()
        Me.btnSearchQuestion = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGenerateQuestion = New System.Windows.Forms.Button()
        Me.btnAddQuestion = New System.Windows.Forms.Button()
        Me.ContextMenuStudent = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemProgress = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemContact = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuQuestion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.tabMngClass.SuspendLayout()
        Me.GroupBoxSearch.SuspendLayout()
        Me.tabProgress.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabQuestions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStudent.SuspendLayout()
        Me.ContextMenuQuestion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabMngClass)
        Me.TabControl1.Controls.Add(Me.tabProgress)
        Me.TabControl1.Controls.Add(Me.tabQuestions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1054, 733)
        Me.TabControl1.TabIndex = 0
        '
        'tabMngClass
        '
        Me.tabMngClass.AutoScroll = True
        Me.tabMngClass.BackColor = System.Drawing.Color.White
        Me.tabMngClass.Controls.Add(Me.btnLogout)
        Me.tabMngClass.Controls.Add(Me.lblWelcomeBack)
        Me.tabMngClass.Controls.Add(Me.Panel1)
        Me.tabMngClass.Controls.Add(Me.lblStudentCount)
        Me.tabMngClass.Controls.Add(Me.GroupBoxSearch)
        Me.tabMngClass.Location = New System.Drawing.Point(4, 27)
        Me.tabMngClass.Name = "tabMngClass"
        Me.tabMngClass.Size = New System.Drawing.Size(1046, 702)
        Me.tabMngClass.TabIndex = 2
        Me.tabMngClass.Text = "Class"
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Image = Global.MyGCSE_Maths.My.Resources.Resources._1415569111_gnome_logout
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(949, 7)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(86, 35)
        Me.btnLogout.TabIndex = 11
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblWelcomeBack
        '
        Me.lblWelcomeBack.AutoSize = True
        Me.lblWelcomeBack.Location = New System.Drawing.Point(5, 7)
        Me.lblWelcomeBack.Name = "lblWelcomeBack"
        Me.lblWelcomeBack.Size = New System.Drawing.Size(116, 18)
        Me.lblWelcomeBack.TabIndex = 10
        Me.lblWelcomeBack.Text = "Welcome back, "
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(5, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1030, 565)
        Me.Panel1.TabIndex = 9
        '
        'lblStudentCount
        '
        Me.lblStudentCount.AutoSize = True
        Me.lblStudentCount.Location = New System.Drawing.Point(12, 67)
        Me.lblStudentCount.Name = "lblStudentCount"
        Me.lblStudentCount.Size = New System.Drawing.Size(124, 18)
        Me.lblStudentCount.TabIndex = 8
        Me.lblStudentCount.Text = "Student Count (0)"
        '
        'GroupBoxSearch
        '
        Me.GroupBoxSearch.Controls.Add(Me.txtSearchField)
        Me.GroupBoxSearch.Controls.Add(Me.lblName)
        Me.GroupBoxSearch.Controls.Add(Me.btnSearch)
        Me.GroupBoxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxSearch.Location = New System.Drawing.Point(322, 20)
        Me.GroupBoxSearch.Name = "GroupBoxSearch"
        Me.GroupBoxSearch.Size = New System.Drawing.Size(428, 65)
        Me.GroupBoxSearch.TabIndex = 5
        Me.GroupBoxSearch.TabStop = False
        Me.GroupBoxSearch.Text = "Search Students"
        '
        'txtSearchField
        '
        Me.txtSearchField.Location = New System.Drawing.Point(75, 21)
        Me.txtSearchField.Name = "txtSearchField"
        Me.txtSearchField.Size = New System.Drawing.Size(256, 24)
        Me.txtSearchField.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(11, 24)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(52, 18)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(337, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tabProgress
        '
        Me.tabProgress.Controls.Add(Me.LinkLblViewAll)
        Me.tabProgress.Controls.Add(Me.lblQuizInfo)
        Me.tabProgress.Controls.Add(Me.Label6)
        Me.tabProgress.Controls.Add(Me.Label4)
        Me.tabProgress.Controls.Add(Me.DateTimeTo)
        Me.tabProgress.Controls.Add(Me.DateTimeFrom)
        Me.tabProgress.Controls.Add(Me.chkDataPoint)
        Me.tabProgress.Controls.Add(Me.Label3)
        Me.tabProgress.Controls.Add(Me.cboChartType)
        Me.tabProgress.Controls.Add(Me.Chart1)
        Me.tabProgress.Location = New System.Drawing.Point(4, 27)
        Me.tabProgress.Name = "tabProgress"
        Me.tabProgress.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProgress.Size = New System.Drawing.Size(1046, 702)
        Me.tabProgress.TabIndex = 1
        Me.tabProgress.Text = "Student Progress"
        Me.tabProgress.UseVisualStyleBackColor = True
        '
        'LinkLblViewAll
        '
        Me.LinkLblViewAll.AutoSize = True
        Me.LinkLblViewAll.Location = New System.Drawing.Point(571, 580)
        Me.LinkLblViewAll.Name = "LinkLblViewAll"
        Me.LinkLblViewAll.Size = New System.Drawing.Size(208, 18)
        Me.LinkLblViewAll.TabIndex = 14
        Me.LinkLblViewAll.TabStop = True
        Me.LinkLblViewAll.Text = "Export all students quiz results"
        '
        'lblQuizInfo
        '
        Me.lblQuizInfo.AutoSize = True
        Me.lblQuizInfo.Location = New System.Drawing.Point(152, 549)
        Me.lblQuizInfo.Name = "lblQuizInfo"
        Me.lblQuizInfo.Size = New System.Drawing.Size(36, 18)
        Me.lblQuizInfo.TabIndex = 13
        Me.lblQuizInfo.Text = "......."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(535, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 18)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "To:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(519, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "From:"
        '
        'DateTimeTo
        '
        Me.DateTimeTo.Location = New System.Drawing.Point(571, 58)
        Me.DateTimeTo.Name = "DateTimeTo"
        Me.DateTimeTo.Size = New System.Drawing.Size(200, 24)
        Me.DateTimeTo.TabIndex = 10
        '
        'DateTimeFrom
        '
        Me.DateTimeFrom.Location = New System.Drawing.Point(571, 15)
        Me.DateTimeFrom.Name = "DateTimeFrom"
        Me.DateTimeFrom.Size = New System.Drawing.Size(200, 24)
        Me.DateTimeFrom.TabIndex = 9
        '
        'chkDataPoint
        '
        Me.chkDataPoint.AutoSize = True
        Me.chkDataPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDataPoint.Location = New System.Drawing.Point(117, 64)
        Me.chkDataPoint.Name = "chkDataPoint"
        Me.chkDataPoint.Size = New System.Drawing.Size(126, 20)
        Me.chkDataPoint.TabIndex = 7
        Me.chkDataPoint.Text = "Label Data Point"
        Me.chkDataPoint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Chart Type: "
        '
        'cboChartType
        '
        Me.cboChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChartType.FormattingEnabled = True
        Me.cboChartType.Items.AddRange(New Object() {"Bar Chart", "Line Graph", "Area Chart"})
        Me.cboChartType.Location = New System.Drawing.Point(117, 26)
        Me.cboChartType.Name = "cboChartType"
        Me.cboChartType.Size = New System.Drawing.Size(106, 26)
        Me.cboChartType.TabIndex = 4
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(77, 113)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 3
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Legend = "Legend1"
        Series1.Name = "Name:"
        Series1.YValuesPerPoint = 2
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(918, 419)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Progress Tracker"
        '
        'tabQuestions
        '
        Me.tabQuestions.Controls.Add(Me.btnExportAnswers)
        Me.tabQuestions.Controls.Add(Me.rdoQuiz)
        Me.tabQuestions.Controls.Add(Me.rdoQuestions)
        Me.tabQuestions.Controls.Add(Me.btnDeleteQuestion)
        Me.tabQuestions.Controls.Add(Me.btnAddQuiz)
        Me.tabQuestions.Controls.Add(Me.Label5)
        Me.tabQuestions.Controls.Add(Me.Label2)
        Me.tabQuestions.Controls.Add(Me.cboGrade)
        Me.tabQuestions.Controls.Add(Me.cboTopic)
        Me.tabQuestions.Controls.Add(Me.tvQuestions)
        Me.tabQuestions.Controls.Add(Me.btnSearchQuestion)
        Me.tabQuestions.Controls.Add(Me.GroupBox1)
        Me.tabQuestions.Location = New System.Drawing.Point(4, 27)
        Me.tabQuestions.Name = "tabQuestions"
        Me.tabQuestions.Size = New System.Drawing.Size(1046, 702)
        Me.tabQuestions.TabIndex = 3
        Me.tabQuestions.Text = "Question Manager"
        Me.tabQuestions.UseVisualStyleBackColor = True
        '
        'btnExportAnswers
        '
        Me.btnExportAnswers.Location = New System.Drawing.Point(358, 582)
        Me.btnExportAnswers.Name = "btnExportAnswers"
        Me.btnExportAnswers.Size = New System.Drawing.Size(121, 37)
        Me.btnExportAnswers.TabIndex = 17
        Me.btnExportAnswers.Text = "Export answers"
        Me.btnExportAnswers.UseVisualStyleBackColor = True
        '
        'rdoQuiz
        '
        Me.rdoQuiz.AutoSize = True
        Me.rdoQuiz.Location = New System.Drawing.Point(260, 200)
        Me.rdoQuiz.Name = "rdoQuiz"
        Me.rdoQuiz.Size = New System.Drawing.Size(81, 22)
        Me.rdoQuiz.TabIndex = 16
        Me.rdoQuiz.TabStop = True
        Me.rdoQuiz.Text = "Quizzes"
        Me.rdoQuiz.UseVisualStyleBackColor = True
        '
        'rdoQuestions
        '
        Me.rdoQuestions.AutoSize = True
        Me.rdoQuestions.Location = New System.Drawing.Point(347, 200)
        Me.rdoQuestions.Name = "rdoQuestions"
        Me.rdoQuestions.Size = New System.Drawing.Size(94, 22)
        Me.rdoQuestions.TabIndex = 15
        Me.rdoQuestions.TabStop = True
        Me.rdoQuestions.Text = "Questions"
        Me.rdoQuestions.UseVisualStyleBackColor = True
        '
        'btnDeleteQuestion
        '
        Me.btnDeleteQuestion.Location = New System.Drawing.Point(699, 582)
        Me.btnDeleteQuestion.Name = "btnDeleteQuestion"
        Me.btnDeleteQuestion.Size = New System.Drawing.Size(81, 37)
        Me.btnDeleteQuestion.TabIndex = 14
        Me.btnDeleteQuestion.Text = "Delete"
        Me.btnDeleteQuestion.UseVisualStyleBackColor = True
        '
        'btnAddQuiz
        '
        Me.btnAddQuiz.Location = New System.Drawing.Point(246, 582)
        Me.btnAddQuiz.Name = "btnAddQuiz"
        Me.btnAddQuiz.Size = New System.Drawing.Size(92, 37)
        Me.btnAddQuiz.TabIndex = 3
        Me.btnAddQuiz.Text = "Add to quiz"
        Me.btnAddQuiz.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(580, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Topic"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(478, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Grade"
        '
        'cboGrade
        '
        Me.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrade.FormattingEnabled = True
        Me.cboGrade.Items.AddRange(New Object() {"-", "A", "B", "C", "D", "E"})
        Me.cboGrade.Location = New System.Drawing.Point(481, 199)
        Me.cboGrade.Name = "cboGrade"
        Me.cboGrade.Size = New System.Drawing.Size(52, 26)
        Me.cboGrade.TabIndex = 10
        '
        'cboTopic
        '
        Me.cboTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTopic.FormattingEnabled = True
        Me.cboTopic.Items.AddRange(New Object() {"-", "Shapes", "Numbers", "Algebra", "Handling Data"})
        Me.cboTopic.Location = New System.Drawing.Point(583, 199)
        Me.cboTopic.Name = "cboTopic"
        Me.cboTopic.Size = New System.Drawing.Size(121, 26)
        Me.cboTopic.TabIndex = 9
        '
        'tvQuestions
        '
        Me.tvQuestions.CheckBoxes = True
        Me.tvQuestions.Location = New System.Drawing.Point(209, 245)
        Me.tvQuestions.Name = "tvQuestions"
        Me.tvQuestions.Size = New System.Drawing.Size(655, 331)
        Me.tvQuestions.TabIndex = 8
        '
        'btnSearchQuestion
        '
        Me.btnSearchQuestion.Location = New System.Drawing.Point(735, 193)
        Me.btnSearchQuestion.Name = "btnSearchQuestion"
        Me.btnSearchQuestion.Size = New System.Drawing.Size(75, 36)
        Me.btnSearchQuestion.TabIndex = 7
        Me.btnSearchQuestion.Text = "Search"
        Me.btnSearchQuestion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGenerateQuestion)
        Me.GroupBox1.Controls.Add(Me.btnAddQuestion)
        Me.GroupBox1.Location = New System.Drawing.Point(258, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 78)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Navigation Menu"
        '
        'btnGenerateQuestion
        '
        Me.btnGenerateQuestion.Location = New System.Drawing.Point(313, 23)
        Me.btnGenerateQuestion.Name = "btnGenerateQuestion"
        Me.btnGenerateQuestion.Size = New System.Drawing.Size(145, 45)
        Me.btnGenerateQuestion.TabIndex = 2
        Me.btnGenerateQuestion.Text = "Generate Questions"
        Me.btnGenerateQuestion.UseVisualStyleBackColor = True
        '
        'btnAddQuestion
        '
        Me.btnAddQuestion.Location = New System.Drawing.Point(76, 23)
        Me.btnAddQuestion.Name = "btnAddQuestion"
        Me.btnAddQuestion.Size = New System.Drawing.Size(136, 45)
        Me.btnAddQuestion.TabIndex = 0
        Me.btnAddQuestion.Text = "Add Questions"
        Me.btnAddQuestion.UseVisualStyleBackColor = True
        '
        'ContextMenuStudent
        '
        Me.ContextMenuStudent.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemProgress, Me.MenuItemContact, Me.MenuItemExport})
        Me.ContextMenuStudent.Name = "ContextMenuStrip1"
        Me.ContextMenuStudent.Size = New System.Drawing.Size(170, 70)
        '
        'MenuItemProgress
        '
        Me.MenuItemProgress.Name = "MenuItemProgress"
        Me.MenuItemProgress.Size = New System.Drawing.Size(169, 22)
        Me.MenuItemProgress.Text = "View Progress"
        '
        'MenuItemContact
        '
        Me.MenuItemContact.Name = "MenuItemContact"
        Me.MenuItemContact.Size = New System.Drawing.Size(169, 22)
        Me.MenuItemContact.Text = "Message"
        '
        'MenuItemExport
        '
        Me.MenuItemExport.Name = "MenuItemExport"
        Me.MenuItemExport.Size = New System.Drawing.Size(169, 22)
        Me.MenuItemExport.Text = "Export quiz results"
        '
        'ContextMenuQuestion
        '
        Me.ContextMenuQuestion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemEdit, Me.MenuItemDelete})
        Me.ContextMenuQuestion.Name = "ContextMenuStrip2"
        Me.ContextMenuQuestion.Size = New System.Drawing.Size(159, 48)
        '
        'MenuItemEdit
        '
        Me.MenuItemEdit.Name = "MenuItemEdit"
        Me.MenuItemEdit.Size = New System.Drawing.Size(158, 22)
        Me.MenuItemEdit.Text = "Edit Question"
        '
        'MenuItemDelete
        '
        Me.MenuItemDelete.Name = "MenuItemDelete"
        Me.MenuItemDelete.Size = New System.Drawing.Size(158, 22)
        Me.MenuItemDelete.Text = "Delete Question"
        '
        'frmTeacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 733)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTeacher"
        Me.Text = "MyGCSE Maths - Teacher Panel"
        Me.TabControl1.ResumeLayout(False)
        Me.tabMngClass.ResumeLayout(False)
        Me.tabMngClass.PerformLayout()
        Me.GroupBoxSearch.ResumeLayout(False)
        Me.GroupBoxSearch.PerformLayout()
        Me.tabProgress.ResumeLayout(False)
        Me.tabProgress.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabQuestions.ResumeLayout(False)
        Me.tabQuestions.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStudent.ResumeLayout(False)
        Me.ContextMenuQuestion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabProgress As System.Windows.Forms.TabPage
    Friend WithEvents tabMngClass As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchField As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblStudentCount As System.Windows.Forms.Label
    Friend WithEvents lblWelcomeBack As System.Windows.Forms.Label
    Friend WithEvents tabQuestions As System.Windows.Forms.TabPage
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddQuiz As System.Windows.Forms.Button
    Friend WithEvents btnGenerateQuestion As System.Windows.Forms.Button
    Friend WithEvents btnAddQuestion As System.Windows.Forms.Button
    Friend WithEvents btnSearchQuestion As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboChartType As System.Windows.Forms.ComboBox
    Friend WithEvents tvQuestions As System.Windows.Forms.TreeView
    Friend WithEvents cboGrade As System.Windows.Forms.ComboBox
    Friend WithEvents cboTopic As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteQuestion As System.Windows.Forms.Button
    Friend WithEvents chkDataPoint As System.Windows.Forms.CheckBox
    Friend WithEvents rdoQuiz As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuestions As System.Windows.Forms.RadioButton
    Friend WithEvents btnExportAnswers As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimeTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblQuizInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStudent As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemProgress As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemContact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuQuestion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLblViewAll As System.Windows.Forms.LinkLabel
End Class
