<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s3_frmFCASettings
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboCostField = New System.Windows.Forms.ComboBox()
        Me.cboNWdataset = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtCutOff = New System.Windows.Forms.TextBox()
        Me.cboDecayModel = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btn3Next = New System.Windows.Forms.Button()
        Me.btn3Prev = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(700, 200)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transportation Network:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Panel1.Controls.Add(Me.cboCostField)
        Me.Panel1.Controls.Add(Me.cboNWdataset)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(10, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 125)
        Me.Panel1.TabIndex = 0
        '
        'cboCostField
        '
        Me.cboCostField.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCostField.FormattingEnabled = True
        Me.cboCostField.Location = New System.Drawing.Point(330, 71)
        Me.cboCostField.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCostField.Name = "cboCostField"
        Me.cboCostField.Size = New System.Drawing.Size(300, 28)
        Me.cboCostField.TabIndex = 1
        '
        'cboNWdataset
        '
        Me.cboNWdataset.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNWdataset.FormattingEnabled = True
        Me.cboNWdataset.Location = New System.Drawing.Point(330, 24)
        Me.cboNWdataset.Margin = New System.Windows.Forms.Padding(4)
        Me.cboNWdataset.Name = "cboNWdataset"
        Me.cboNWdataset.Size = New System.Drawing.Size(300, 28)
        Me.cboNWdataset.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(20, 70)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(285, 32)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "Impedance Field"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(20, 20)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(285, 32)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Network layer"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 227)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(700, 200)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Floating Catchment Areas:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtCutOff)
        Me.Panel2.Controls.Add(Me.cboDecayModel)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.TextBox4)
        Me.Panel2.Location = New System.Drawing.Point(10, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(660, 125)
        Me.Panel2.TabIndex = 0
        '
        'txtCutOff
        '
        Me.txtCutOff.AcceptsReturn = True
        Me.txtCutOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCutOff.Location = New System.Drawing.Point(330, 70)
        Me.txtCutOff.Name = "txtCutOff"
        Me.txtCutOff.Size = New System.Drawing.Size(300, 27)
        Me.txtCutOff.TabIndex = 0
        '
        'cboDecayModel
        '
        Me.cboDecayModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDecayModel.FormattingEnabled = True
        Me.cboDecayModel.Items.AddRange(New Object() {"No decay      (classic)", "Linear decay (enhanced)"})
        Me.cboDecayModel.Location = New System.Drawing.Point(330, 23)
        Me.cboDecayModel.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDecayModel.Name = "cboDecayModel"
        Me.cboDecayModel.Size = New System.Drawing.Size(300, 28)
        Me.cboDecayModel.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(21, 21)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(285, 32)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "Distance-decay Function"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(20, 68)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(285, 32)
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = "Threshold Distance/Time"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn3Next
        '
        Me.btn3Next.Enabled = False
        Me.btn3Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3Next.ForeColor = System.Drawing.Color.White
        Me.btn3Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn3Next.Location = New System.Drawing.Point(618, 430)
        Me.btn3Next.Margin = New System.Windows.Forms.Padding(4)
        Me.btn3Next.Name = "btn3Next"
        Me.btn3Next.Size = New System.Drawing.Size(95, 55)
        Me.btn3Next.TabIndex = 1
        Me.btn3Next.UseVisualStyleBackColor = True
        '
        'btn3Prev
        '
        Me.btn3Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3Prev.ForeColor = System.Drawing.Color.White
        Me.btn3Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn3Prev.Location = New System.Drawing.Point(15, 430)
        Me.btn3Prev.Margin = New System.Windows.Forms.Padding(4)
        Me.btn3Prev.Name = "btn3Prev"
        Me.btn3Prev.Size = New System.Drawing.Size(95, 55)
        Me.btn3Prev.TabIndex = 0
        Me.btn3Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn3Prev.UseVisualStyleBackColor = True
        '
        's3_frmFCASettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(740, 511)
        Me.Controls.Add(Me.btn3Next)
        Me.Controls.Add(Me.btn3Prev)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "s3_frmFCASettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SW-FCA - Page 3/4"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCostField As System.Windows.Forms.ComboBox
    Friend WithEvents cboNWdataset As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboDecayModel As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCutOff As System.Windows.Forms.TextBox
    Friend WithEvents btn3Prev As System.Windows.Forms.Button
    Friend WithEvents btn3Next As System.Windows.Forms.Button
End Class
