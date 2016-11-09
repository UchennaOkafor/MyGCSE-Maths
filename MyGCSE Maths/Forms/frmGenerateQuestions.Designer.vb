<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateQuestions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerateQuestions))
        Me.cboTopic = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGrade = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkboxMultiChoice = New System.Windows.Forms.CheckBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTopic
        '
        Me.cboTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTopic.FormattingEnabled = True
        Me.cboTopic.Items.AddRange(New Object() {"Numbers", "Shapes", "Algebra", "Handling Data"})
        Me.cboTopic.Location = New System.Drawing.Point(63, 24)
        Me.cboTopic.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTopic.Name = "cboTopic"
        Me.cboTopic.Size = New System.Drawing.Size(147, 26)
        Me.cboTopic.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Topic"
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(83, 227)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(102, 35)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Difficulty Level"
        '
        'cboGrade
        '
        Me.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrade.FormattingEnabled = True
        Me.cboGrade.Items.AddRange(New Object() {"A", "B", "C", "D", "E"})
        Me.cboGrade.Location = New System.Drawing.Point(63, 89)
        Me.cboGrade.Name = "cboGrade"
        Me.cboGrade.Size = New System.Drawing.Size(147, 26)
        Me.cboGrade.TabIndex = 4
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(63, 188)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(147, 24)
        Me.NumericUpDown1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Amount"
        '
        'chkboxMultiChoice
        '
        Me.chkboxMultiChoice.AutoSize = True
        Me.chkboxMultiChoice.Location = New System.Drawing.Point(63, 132)
        Me.chkboxMultiChoice.Name = "chkboxMultiChoice"
        Me.chkboxMultiChoice.Size = New System.Drawing.Size(109, 22)
        Me.chkboxMultiChoice.TabIndex = 7
        Me.chkboxMultiChoice.Text = "Multi Choice"
        Me.chkboxMultiChoice.UseVisualStyleBackColor = True
        '
        'frmGenerateQuestions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 271)
        Me.Controls.Add(Me.chkboxMultiChoice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.cboGrade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTopic)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateQuestions"
        Me.Text = "Question Generator"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTopic As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGrade As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkboxMultiChoice As System.Windows.Forms.CheckBox
End Class
