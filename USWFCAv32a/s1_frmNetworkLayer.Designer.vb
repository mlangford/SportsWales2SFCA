<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s1_frmNetworkLayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(s1_frmNetworkLayer))
        Me.grpNetworklayer = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cboNWdataset = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.cboScale = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.btn1Next = New System.Windows.Forms.Button()
        Me.cboCostField = New System.Windows.Forms.ComboBox()
        Me.lblUnits = New System.Windows.Forms.Label()
        Me.grpImpedance = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCutOff = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.grpFCAscaling = New System.Windows.Forms.GroupBox()
        Me.grpNetworklayer.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpImpedance.SuspendLayout()
        Me.grpFCAscaling.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpNetworklayer
        '
        Me.grpNetworklayer.Controls.Add(Me.TextBox1)
        Me.grpNetworklayer.Controls.Add(Me.cboNWdataset)
        Me.grpNetworklayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.grpNetworklayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNetworklayer.Location = New System.Drawing.Point(15, 116)
        Me.grpNetworklayer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpNetworklayer.Name = "grpNetworklayer"
        Me.grpNetworklayer.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpNetworklayer.Size = New System.Drawing.Size(1087, 148)
        Me.grpNetworklayer.TabIndex = 19
        Me.grpNetworklayer.TabStop = False
        Me.grpNetworklayer.Text = "Select the NETWORK dataset layer"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(8, 53)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(48, 8, 8, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(385, 61)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = "Select from this list the Network Dataset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "layer that is to be used in this analy" & _
    "sis :"
        '
        'cboNWdataset
        '
        Me.cboNWdataset.FormattingEnabled = True
        Me.cboNWdataset.Location = New System.Drawing.Point(433, 53)
        Me.cboNWdataset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboNWdataset.Name = "cboNWdataset"
        Me.cboNWdataset.Size = New System.Drawing.Size(585, 28)
        Me.cboNWdataset.TabIndex = 0
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(12, 50)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(7, 4, 4, 4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(385, 61)
        Me.TextBox3.TabIndex = 21
        Me.TextBox3.Text = "Select the Cost field of the Network Dataset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that is  to be used in this analysi" & _
    "s :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cboScale
        '
        Me.cboScale.FormattingEnabled = True
        Me.cboScale.Items.AddRange(New Object() {"1", "10", "100", "1000", "10000"})
        Me.cboScale.Location = New System.Drawing.Point(736, 49)
        Me.cboScale.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboScale.Name = "cboScale"
        Me.cboScale.Size = New System.Drawing.Size(75, 28)
        Me.cboScale.TabIndex = 34
        Me.cboScale.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(631, 58)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Enhanced Two-Step Floating Catchment Area (FCA)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Accessibility Scores (and other " & _
    "accessibility metrics) "
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(11, 7)
        Me.PictureBox9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(297, 90)
        Me.PictureBox9.TabIndex = 23
        Me.PictureBox9.TabStop = False
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(820, 49)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(249, 72)
        Me.TextBox5.TabIndex = 33
        Me.TextBox5.Text = "Scaling factor - select a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "multiplier to scale scores" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(use to preserve precisio" & _
    "n)"
        '
        'btn1Next
        '
        Me.btn1Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn1Next.Location = New System.Drawing.Point(1032, 615)
        Me.btn1Next.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn1Next.Name = "btn1Next"
        Me.btn1Next.Size = New System.Drawing.Size(69, 64)
        Me.btn1Next.TabIndex = 20
        Me.btn1Next.UseVisualStyleBackColor = True
        '
        'cboCostField
        '
        Me.cboCostField.FormattingEnabled = True
        Me.cboCostField.Location = New System.Drawing.Point(437, 50)
        Me.cboCostField.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCostField.Name = "cboCostField"
        Me.cboCostField.Size = New System.Drawing.Size(585, 28)
        Me.cboCostField.TabIndex = 22
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnits.Location = New System.Drawing.Point(657, 57)
        Me.lblUnits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(45, 20)
        Me.lblUnits.TabIndex = 22
        Me.lblUnits.Text = "units"
        Me.lblUnits.Visible = False
        '
        'grpImpedance
        '
        Me.grpImpedance.Controls.Add(Me.cboCostField)
        Me.grpImpedance.Controls.Add(Me.TextBox3)
        Me.grpImpedance.Enabled = False
        Me.grpImpedance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpImpedance.Location = New System.Drawing.Point(11, 282)
        Me.grpImpedance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpImpedance.Name = "grpImpedance"
        Me.grpImpedance.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpImpedance.Size = New System.Drawing.Size(1091, 148)
        Me.grpImpedance.TabIndex = 22
        Me.grpImpedance.TabStop = False
        Me.grpImpedance.Text = "Specify the Field associated with network travel impedance/cost"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 615)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Version 32a-04a"
        '
        'txtCutOff
        '
        Me.txtCutOff.Location = New System.Drawing.Point(437, 49)
        Me.txtCutOff.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCutOff.Name = "txtCutOff"
        Me.txtCutOff.Size = New System.Drawing.Size(208, 26)
        Me.txtCutOff.TabIndex = 4
        Me.txtCutOff.Text = "5000"
        Me.txtCutOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(12, 49)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(385, 61)
        Me.TextBox2.TabIndex = 21
        Me.TextBox2.Text = "Specify a threshold distance (or time) etc." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to set the size of Floating Catchmen" & _
    "t Areas :"
        '
        'grpFCAscaling
        '
        Me.grpFCAscaling.Controls.Add(Me.cboScale)
        Me.grpFCAscaling.Controls.Add(Me.TextBox5)
        Me.grpFCAscaling.Controls.Add(Me.lblUnits)
        Me.grpFCAscaling.Controls.Add(Me.TextBox2)
        Me.grpFCAscaling.Controls.Add(Me.txtCutOff)
        Me.grpFCAscaling.Enabled = False
        Me.grpFCAscaling.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFCAscaling.Location = New System.Drawing.Point(11, 437)
        Me.grpFCAscaling.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpFCAscaling.Name = "grpFCAscaling"
        Me.grpFCAscaling.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpFCAscaling.Size = New System.Drawing.Size(1091, 148)
        Me.grpFCAscaling.TabIndex = 21
        Me.grpFCAscaling.TabStop = False
        Me.grpFCAscaling.Text = "Specify Floating Catchment Area dimensions and FCA score scaling factor"
        '
        's1_frmNetworkLayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1112, 692)
        Me.Controls.Add(Me.grpNetworklayer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.btn1Next)
        Me.Controls.Add(Me.grpImpedance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grpFCAscaling)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "s1_frmNetworkLayer"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s1_frmNetworkLayer"
        Me.grpNetworklayer.ResumeLayout(False)
        Me.grpNetworklayer.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpImpedance.ResumeLayout(False)
        Me.grpImpedance.PerformLayout()
        Me.grpFCAscaling.ResumeLayout(False)
        Me.grpFCAscaling.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpNetworklayer As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cboNWdataset As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents cboScale As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents btn1Next As System.Windows.Forms.Button
    Friend WithEvents cboCostField As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents grpImpedance As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCutOff As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents grpFCAscaling As System.Windows.Forms.GroupBox
End Class
