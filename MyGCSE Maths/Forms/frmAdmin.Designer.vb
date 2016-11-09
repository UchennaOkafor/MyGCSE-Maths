<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabAdd = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoStudent = New System.Windows.Forms.RadioButton()
        Me.rdoTeacher = New System.Windows.Forms.RadioButton()
        Me.rdoAdmin = New System.Windows.Forms.RadioButton()
        Me.picUser = New System.Windows.Forms.PictureBox()
        Me.lblLastname = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.lblFirstname = New System.Windows.Forms.Label()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.lblClassInfo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstUsers = New System.Windows.Forms.ListBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblWelcomeBack = New System.Windows.Forms.Label()
        Me.tabClass = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.columnBlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnRoom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnFirstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnLastname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearchTeacher = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAddClass = New System.Windows.Forms.Button()
        Me.lblBlock = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBlock = New System.Windows.Forms.TextBox()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.tabAdd.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tabClass.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabAdd)
        Me.TabControl1.Controls.Add(Me.tabClass)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(839, 604)
        Me.TabControl1.TabIndex = 1
        '
        'tabAdd
        '
        Me.tabAdd.Controls.Add(Me.GroupBox3)
        Me.tabAdd.Controls.Add(Me.GroupBox2)
        Me.tabAdd.Controls.Add(Me.btnLogout)
        Me.tabAdd.Controls.Add(Me.lblWelcomeBack)
        Me.tabAdd.Location = New System.Drawing.Point(4, 27)
        Me.tabAdd.Name = "tabAdd"
        Me.tabAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdd.Size = New System.Drawing.Size(831, 573)
        Me.tabAdd.TabIndex = 0
        Me.tabAdd.Text = "New User"
        Me.tabAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoStudent)
        Me.GroupBox3.Controls.Add(Me.rdoTeacher)
        Me.GroupBox3.Controls.Add(Me.rdoAdmin)
        Me.GroupBox3.Controls.Add(Me.picUser)
        Me.GroupBox3.Controls.Add(Me.lblLastname)
        Me.GroupBox3.Controls.Add(Me.lblUserID)
        Me.GroupBox3.Controls.Add(Me.txtUserID)
        Me.GroupBox3.Controls.Add(Me.lblFirstname)
        Me.GroupBox3.Controls.Add(Me.txtLastname)
        Me.GroupBox3.Controls.Add(Me.txtFirstname)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.cboClass)
        Me.GroupBox3.Controls.Add(Me.lblClassInfo)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(17, 59)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(421, 365)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "User Information"
        '
        'rdoStudent
        '
        Me.rdoStudent.AutoSize = True
        Me.rdoStudent.Location = New System.Drawing.Point(206, 189)
        Me.rdoStudent.Name = "rdoStudent"
        Me.rdoStudent.Size = New System.Drawing.Size(76, 22)
        Me.rdoStudent.TabIndex = 13
        Me.rdoStudent.TabStop = True
        Me.rdoStudent.Text = "Student"
        Me.rdoStudent.UseVisualStyleBackColor = True
        '
        'rdoTeacher
        '
        Me.rdoTeacher.AutoSize = True
        Me.rdoTeacher.Location = New System.Drawing.Point(306, 191)
        Me.rdoTeacher.Name = "rdoTeacher"
        Me.rdoTeacher.Size = New System.Drawing.Size(80, 22)
        Me.rdoTeacher.TabIndex = 12
        Me.rdoTeacher.TabStop = True
        Me.rdoTeacher.Text = "Teacher"
        Me.rdoTeacher.UseVisualStyleBackColor = True
        '
        'rdoAdmin
        '
        Me.rdoAdmin.AutoSize = True
        Me.rdoAdmin.Location = New System.Drawing.Point(206, 216)
        Me.rdoAdmin.Name = "rdoAdmin"
        Me.rdoAdmin.Size = New System.Drawing.Size(67, 22)
        Me.rdoAdmin.TabIndex = 11
        Me.rdoAdmin.TabStop = True
        Me.rdoAdmin.Text = "Admin"
        Me.rdoAdmin.UseVisualStyleBackColor = True
        '
        'picUser
        '
        Me.picUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picUser.InitialImage = Nothing
        Me.picUser.Location = New System.Drawing.Point(10, 42)
        Me.picUser.Name = "picUser"
        Me.picUser.Size = New System.Drawing.Size(188, 257)
        Me.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picUser.TabIndex = 10
        Me.picUser.TabStop = False
        '
        'lblLastname
        '
        Me.lblLastname.AutoSize = True
        Me.lblLastname.Location = New System.Drawing.Point(204, 135)
        Me.lblLastname.Name = "lblLastname"
        Me.lblLastname.Size = New System.Drawing.Size(73, 18)
        Me.lblLastname.TabIndex = 4
        Me.lblLastname.Text = "Lastname"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(204, 30)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(66, 18)
        Me.lblUserID.TabIndex = 9
        Me.lblUserID.Text = "User ID: "
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(207, 55)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 24)
        Me.txtUserID.TabIndex = 0
        '
        'lblFirstname
        '
        Me.lblFirstname.AutoSize = True
        Me.lblFirstname.Location = New System.Drawing.Point(204, 82)
        Me.lblFirstname.Name = "lblFirstname"
        Me.lblFirstname.Size = New System.Drawing.Size(78, 18)
        Me.lblFirstname.TabIndex = 3
        Me.lblFirstname.Text = "Firstname:"
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(207, 156)
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(199, 24)
        Me.txtLastname.TabIndex = 2
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(207, 108)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(199, 24)
        Me.txtFirstname.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdd.Enabled = False
        Me.btnAdd.Image = Global.MyGCSE_Maths.My.Resources.Resources._1416029829_user_add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.Location = New System.Drawing.Point(252, 299)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(86, 38)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(207, 267)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(171, 26)
        Me.cboClass.TabIndex = 4
        Me.cboClass.Visible = False
        '
        'lblClassInfo
        '
        Me.lblClassInfo.AutoSize = True
        Me.lblClassInfo.Location = New System.Drawing.Point(205, 246)
        Me.lblClassInfo.Name = "lblClassInfo"
        Me.lblClassInfo.Size = New System.Drawing.Size(46, 18)
        Me.lblClassInfo.TabIndex = 3
        Me.lblClassInfo.Text = "Class"
        Me.lblClassInfo.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstUsers)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(458, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 365)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'lstUsers
        '
        Me.lstUsers.FormattingEnabled = True
        Me.lstUsers.ItemHeight = 18
        Me.lstUsers.Location = New System.Drawing.Point(23, 75)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(321, 274)
        Me.lstUsers.TabIndex = 9
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(82, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(171, 24)
        Me.txtSearch.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Name: "
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(259, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Image = Global.MyGCSE_Maths.My.Resources.Resources._1415569111_gnome_logout
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(732, 11)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(86, 35)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Log out"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblWelcomeBack
        '
        Me.lblWelcomeBack.AutoSize = True
        Me.lblWelcomeBack.Location = New System.Drawing.Point(14, 18)
        Me.lblWelcomeBack.Name = "lblWelcomeBack"
        Me.lblWelcomeBack.Size = New System.Drawing.Size(116, 18)
        Me.lblWelcomeBack.TabIndex = 1
        Me.lblWelcomeBack.Text = "Welcome back, "
        '
        'tabClass
        '
        Me.tabClass.Controls.Add(Me.DataGridView1)
        Me.tabClass.Controls.Add(Me.btnSearchTeacher)
        Me.tabClass.Controls.Add(Me.GroupBox4)
        Me.tabClass.Location = New System.Drawing.Point(4, 27)
        Me.tabClass.Name = "tabClass"
        Me.tabClass.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClass.Size = New System.Drawing.Size(831, 573)
        Me.tabClass.TabIndex = 2
        Me.tabClass.Text = "Class"
        Me.tabClass.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnBlock, Me.columnRoom, Me.columnFirstname, Me.columnLastname})
        Me.DataGridView1.Location = New System.Drawing.Point(339, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(444, 264)
        Me.DataGridView1.TabIndex = 3
        '
        'columnBlock
        '
        Me.columnBlock.HeaderText = "Block"
        Me.columnBlock.Name = "columnBlock"
        Me.columnBlock.ReadOnly = True
        '
        'columnRoom
        '
        Me.columnRoom.HeaderText = "Room"
        Me.columnRoom.Name = "columnRoom"
        Me.columnRoom.ReadOnly = True
        '
        'columnFirstname
        '
        Me.columnFirstname.HeaderText = "Firstname"
        Me.columnFirstname.Name = "columnFirstname"
        Me.columnFirstname.ReadOnly = True
        '
        'columnLastname
        '
        Me.columnLastname.HeaderText = "Lastname"
        Me.columnLastname.Name = "columnLastname"
        Me.columnLastname.ReadOnly = True
        '
        'btnSearchTeacher
        '
        Me.btnSearchTeacher.Location = New System.Drawing.Point(532, 307)
        Me.btnSearchTeacher.Name = "btnSearchTeacher"
        Me.btnSearchTeacher.Size = New System.Drawing.Size(79, 38)
        Me.btnSearchTeacher.TabIndex = 2
        Me.btnSearchTeacher.Text = "Search"
        Me.btnSearchTeacher.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnAddClass)
        Me.GroupBox4.Controls.Add(Me.lblBlock)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtBlock)
        Me.GroupBox4.Controls.Add(Me.txtRoom)
        Me.GroupBox4.Location = New System.Drawing.Point(26, 56)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(265, 157)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Add Class"
        '
        'btnAddClass
        '
        Me.btnAddClass.Location = New System.Drawing.Point(113, 113)
        Me.btnAddClass.Name = "btnAddClass"
        Me.btnAddClass.Size = New System.Drawing.Size(75, 31)
        Me.btnAddClass.TabIndex = 7
        Me.btnAddClass.Text = "Add"
        Me.btnAddClass.UseVisualStyleBackColor = True
        '
        'lblBlock
        '
        Me.lblBlock.AutoSize = True
        Me.lblBlock.Location = New System.Drawing.Point(30, 33)
        Me.lblBlock.Name = "lblBlock"
        Me.lblBlock.Size = New System.Drawing.Size(54, 18)
        Me.lblBlock.TabIndex = 4
        Me.lblBlock.Text = "Block: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Room:"
        '
        'txtBlock
        '
        Me.txtBlock.Location = New System.Drawing.Point(108, 30)
        Me.txtBlock.MaxLength = 1
        Me.txtBlock.Name = "txtBlock"
        Me.txtBlock.Size = New System.Drawing.Size(45, 24)
        Me.txtBlock.TabIndex = 1
        '
        'txtRoom
        '
        Me.txtRoom.Location = New System.Drawing.Point(108, 68)
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.Size = New System.Drawing.Size(80, 24)
        Me.txtRoom.TabIndex = 0
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 604)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAdmin"
        Me.Text = "MyGCSE Maths - Admin Panel"
        Me.TabControl1.ResumeLayout(False)
        Me.tabAdd.ResumeLayout(False)
        Me.tabAdd.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabClass.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabAdd As System.Windows.Forms.TabPage
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstUsers As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLastname As System.Windows.Forms.Label
    Friend WithEvents lblFirstname As System.Windows.Forms.Label
    Friend WithEvents txtLastname As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstname As System.Windows.Forms.TextBox
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents lblWelcomeBack As System.Windows.Forms.Label
    Friend WithEvents tabClass As System.Windows.Forms.TabPage
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblClassInfo As System.Windows.Forms.Label
    Friend WithEvents rdoStudent As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTeacher As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBlock As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtRoom As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchTeacher As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents columnBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnRoom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnFirstname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnLastname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddClass As System.Windows.Forms.Button
End Class