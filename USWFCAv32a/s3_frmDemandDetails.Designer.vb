<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s3_frmDemandDetails
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
        Me.chkDmdSel = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkDemandField = New System.Windows.Forms.CheckBox()
        Me.cboDemandField = New System.Windows.Forms.ComboBox()
        Me.cboDemandPointsLayer = New System.Windows.Forms.ComboBox()
        Me.btn3_Prev = New System.Windows.Forms.Button()
        Me.btn3Next = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkDmdSel
        '
        Me.chkDmdSel.AutoSize = True
        Me.chkDmdSel.Enabled = False
        Me.chkDmdSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDmdSel.Location = New System.Drawing.Point(579, 101)
        Me.chkDmdSel.Name = "chkDmdSel"
        Me.chkDmdSel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDmdSel.Size = New System.Drawing.Size(186, 20)
        Me.chkDmdSel.TabIndex = 31
        Me.chkDmdSel.Text = "Use only selected features"
        Me.chkDmdSel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkDmdSel)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.chkDemandField)
        Me.GroupBox3.Controls.Add(Me.cboDemandField)
        Me.GroupBox3.Controls.Add(Me.cboDemandPointsLayer)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(823, 300)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Identify service DEMAND details:"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(6, 226)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(290, 50)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "Select the field that represents the service Demand volume (only numeric fields a" & _
    "re shown) :"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(6, 45)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(290, 50)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "Select the layer that contains points objects" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "representing the service Demand lo" & _
    "cations :"
        '
        'chkDemandField
        '
        Me.chkDemandField.AutoSize = True
        Me.chkDemandField.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDemandField.Location = New System.Drawing.Point(393, 170)
        Me.chkDemandField.Name = "chkDemandField"
        Me.chkDemandField.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDemandField.Size = New System.Drawing.Size(372, 36)
        Me.chkDemandField.TabIndex = 29
        Me.chkDemandField.Text = "check to select a field in this layer as the Demand capacity" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (if unselected a d" & _
    "efault demand volume of '1' will be used)"
        Me.chkDemandField.UseVisualStyleBackColor = True
        '
        'cboDemandField
        '
        Me.cboDemandField.Enabled = False
        Me.cboDemandField.FormattingEnabled = True
        Me.cboDemandField.Location = New System.Drawing.Point(325, 226)
        Me.cboDemandField.Name = "cboDemandField"
        Me.cboDemandField.Size = New System.Drawing.Size(157, 24)
        Me.cboDemandField.TabIndex = 26
        '
        'cboDemandPointsLayer
        '
        Me.cboDemandPointsLayer.FormattingEnabled = True
        Me.cboDemandPointsLayer.Location = New System.Drawing.Point(325, 45)
        Me.cboDemandPointsLayer.Name = "cboDemandPointsLayer"
        Me.cboDemandPointsLayer.Size = New System.Drawing.Size(440, 24)
        Me.cboDemandPointsLayer.TabIndex = 0
        '
        'btn3_Prev
        '
        Me.btn3_Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn3_Prev.Location = New System.Drawing.Point(18, 500)
        Me.btn3_Prev.Name = "btn3_Prev"
        Me.btn3_Prev.Size = New System.Drawing.Size(52, 52)
        Me.btn3_Prev.TabIndex = 33
        Me.btn3_Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn3_Prev.UseVisualStyleBackColor = True
        '
        'btn3Next
        '
        Me.btn3Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn3Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn3Next.Location = New System.Drawing.Point(774, 500)
        Me.btn3Next.Name = "btn3Next"
        Me.btn3Next.Size = New System.Drawing.Size(52, 52)
        Me.btn3Next.TabIndex = 34
        Me.btn3Next.UseVisualStyleBackColor = True
        '
        's3_frmDemandDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btn3_Prev)
        Me.Controls.Add(Me.btn3Next)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "s3_frmDemandDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s3_frmDemandDetails"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkDmdSel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkDemandField As System.Windows.Forms.CheckBox
    Friend WithEvents cboDemandField As System.Windows.Forms.ComboBox
    Friend WithEvents cboDemandPointsLayer As System.Windows.Forms.ComboBox
    Friend WithEvents btn3_Prev As System.Windows.Forms.Button
    Friend WithEvents btn3Next As System.Windows.Forms.Button
End Class
