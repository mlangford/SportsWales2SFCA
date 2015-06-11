<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s4_frmParameters
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pbDecayType = New System.Windows.Forms.PictureBox()
        Me.pnlGauss = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtResultsPath = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn4_Prev = New System.Windows.Forms.Button()
        Me.btn4Next = New System.Windows.Forms.Button()
        Me.numUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.pnlButt = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.numUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.optButterworth = New System.Windows.Forms.RadioButton()
        Me.optLinear = New System.Windows.Forms.RadioButton()
        Me.optGaussian = New System.Windows.Forms.RadioButton()
        Me.optClassic = New System.Windows.Forms.RadioButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.pbDecayType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGauss.SuspendLayout()
        CType(Me.numUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButt.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.Controls.Add(Me.pbDecayType)
        Me.Panel2.Location = New System.Drawing.Point(49, 60)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(425, 386)
        Me.Panel2.TabIndex = 59
        '
        'pbDecayType
        '
        Me.pbDecayType.Image = Global.USWFCAv32a.My.Resources.Resources.Fig_None
        Me.pbDecayType.Location = New System.Drawing.Point(9, 9)
        Me.pbDecayType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbDecayType.Name = "pbDecayType"
        Me.pbDecayType.Size = New System.Drawing.Size(305, 300)
        Me.pbDecayType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbDecayType.TabIndex = 35
        Me.pbDecayType.TabStop = False
        '
        'pnlGauss
        '
        Me.pnlGauss.Controls.Add(Me.Label2)
        Me.pnlGauss.Controls.Add(Me.numUpDown1)
        Me.pnlGauss.Controls.Add(Me.Label1)
        Me.pnlGauss.Controls.Add(Me.NumericUpDown5)
        Me.pnlGauss.Enabled = False
        Me.pnlGauss.Location = New System.Drawing.Point(523, 209)
        Me.pnlGauss.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlGauss.Name = "pnlGauss"
        Me.pnlGauss.Size = New System.Drawing.Size(537, 60)
        Me.pnlGauss.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, -90)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(276, 25)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Gaussian Decay Bandwidth"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'numUpDown1
        '
        Me.numUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numUpDown1.Location = New System.Drawing.Point(345, 17)
        Me.numUpDown1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numUpDown1.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.numUpDown1.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numUpDown1.Name = "numUpDown1"
        Me.numUpDown1.Size = New System.Drawing.Size(153, 30)
        Me.numUpDown1.TabIndex = 42
        Me.numUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numUpDown1.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 25)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Decay bandwidth"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown5.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown5.Location = New System.Drawing.Point(329, -92)
        Me.NumericUpDown5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(153, 30)
        Me.NumericUpDown5.TabIndex = 42
        Me.NumericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown5.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.txtResultsPath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(53, 481)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1007, 102)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Results Table Location"
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(16, 44)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(60, 27)
        Me.btnBrowse.TabIndex = 48
        Me.btnBrowse.Text = "Set"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'txtResultsPath
        '
        Me.txtResultsPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultsPath.Location = New System.Drawing.Point(84, 44)
        Me.txtResultsPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtResultsPath.Name = "txtResultsPath"
        Me.txtResultsPath.Size = New System.Drawing.Size(883, 26)
        Me.txtResultsPath.TabIndex = 47
        Me.txtResultsPath.Text = "C:\TEMP"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(380, 16)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(358, 25)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "Select FCA distance-decay function"
        '
        'btn4_Prev
        '
        Me.btn4_Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn4_Prev.Location = New System.Drawing.Point(24, 615)
        Me.btn4_Prev.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn4_Prev.Name = "btn4_Prev"
        Me.btn4_Prev.Size = New System.Drawing.Size(69, 64)
        Me.btn4_Prev.TabIndex = 50
        Me.btn4_Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn4_Prev.UseVisualStyleBackColor = True
        '
        'btn4Next
        '
        Me.btn4Next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn4Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn4Next.Location = New System.Drawing.Point(1032, 615)
        Me.btn4Next.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn4Next.Name = "btn4Next"
        Me.btn4Next.Size = New System.Drawing.Size(69, 64)
        Me.btn4Next.TabIndex = 51
        Me.btn4Next.UseVisualStyleBackColor = True
        '
        'numUpDown3
        '
        Me.numUpDown3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUpDown3.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numUpDown3.Location = New System.Drawing.Point(345, 62)
        Me.numUpDown3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numUpDown3.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.numUpDown3.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numUpDown3.Name = "numUpDown3"
        Me.numUpDown3.Size = New System.Drawing.Size(153, 30)
        Me.numUpDown3.TabIndex = 26
        Me.numUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numUpDown3.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'pnlButt
        '
        Me.pnlButt.Controls.Add(Me.Label19)
        Me.pnlButt.Controls.Add(Me.NumericUpDown1)
        Me.pnlButt.Controls.Add(Me.Label25)
        Me.pnlButt.Controls.Add(Me.numUpDown2)
        Me.pnlButt.Controls.Add(Me.Label20)
        Me.pnlButt.Controls.Add(Me.numUpDown3)
        Me.pnlButt.Enabled = False
        Me.pnlButt.Location = New System.Drawing.Point(523, 326)
        Me.pnlButt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlButt.Name = "pnlButt"
        Me.pnlButt.Size = New System.Drawing.Size(537, 108)
        Me.pnlButt.TabIndex = 57
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, -90)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(276, 25)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Gaussian Decay Bandwidth"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Location = New System.Drawing.Point(329, -92)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(153, 30)
        Me.NumericUpDown1.TabIndex = 42
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(20, 23)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(140, 25)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Power function"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'numUpDown2
        '
        Me.numUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUpDown2.Location = New System.Drawing.Point(344, 21)
        Me.numUpDown2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numUpDown2.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numUpDown2.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numUpDown2.Name = "numUpDown2"
        Me.numUpDown2.Size = New System.Drawing.Size(153, 30)
        Me.numUpDown2.TabIndex = 28
        Me.numUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numUpDown2.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(20, 64)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(255, 25)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Passband as % of threshold"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'optButterworth
        '
        Me.optButterworth.AutoSize = True
        Me.optButterworth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optButterworth.Location = New System.Drawing.Point(491, 288)
        Me.optButterworth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optButterworth.Name = "optButterworth"
        Me.optButterworth.Size = New System.Drawing.Size(192, 29)
        Me.optButterworth.TabIndex = 55
        Me.optButterworth.Text = "Butterworth Decay"
        Me.optButterworth.UseVisualStyleBackColor = True
        '
        'optLinear
        '
        Me.optLinear.AutoSize = True
        Me.optLinear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optLinear.Location = New System.Drawing.Point(491, 116)
        Me.optLinear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optLinear.Name = "optLinear"
        Me.optLinear.Size = New System.Drawing.Size(148, 29)
        Me.optLinear.TabIndex = 54
        Me.optLinear.Text = "Linear Decay"
        Me.optLinear.UseVisualStyleBackColor = True
        '
        'optGaussian
        '
        Me.optGaussian.AutoSize = True
        Me.optGaussian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optGaussian.Location = New System.Drawing.Point(491, 172)
        Me.optGaussian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optGaussian.Name = "optGaussian"
        Me.optGaussian.Size = New System.Drawing.Size(177, 29)
        Me.optGaussian.TabIndex = 53
        Me.optGaussian.Text = "Gaussian Decay"
        Me.optGaussian.UseVisualStyleBackColor = True
        '
        'optClassic
        '
        Me.optClassic.AutoSize = True
        Me.optClassic.Checked = True
        Me.optClassic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optClassic.Location = New System.Drawing.Point(491, 63)
        Me.optClassic.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optClassic.Name = "optClassic"
        Me.optClassic.Size = New System.Drawing.Size(452, 29)
        Me.optClassic.TabIndex = 52
        Me.optClassic.TabStop = True
        Me.optClassic.Text = "Classic Two-Step Algorithm (no distance decay)"
        Me.optClassic.UseVisualStyleBackColor = True
        '
        's4_frmParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1112, 692)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlGauss)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn4_Prev)
        Me.Controls.Add(Me.btn4Next)
        Me.Controls.Add(Me.pnlButt)
        Me.Controls.Add(Me.optButterworth)
        Me.Controls.Add(Me.optLinear)
        Me.Controls.Add(Me.optGaussian)
        Me.Controls.Add(Me.optClassic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "s4_frmParameters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "E2SFCA - Page 4/5"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbDecayType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGauss.ResumeLayout(False)
        Me.pnlGauss.PerformLayout()
        CType(Me.numUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButt.ResumeLayout(False)
        Me.pnlButt.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pbDecayType As System.Windows.Forms.PictureBox
    Friend WithEvents pnlGauss As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtResultsPath As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn4_Prev As System.Windows.Forms.Button
    Friend WithEvents btn4Next As System.Windows.Forms.Button
    Friend WithEvents numUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlButt As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents numUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents optButterworth As System.Windows.Forms.RadioButton
    Friend WithEvents optLinear As System.Windows.Forms.RadioButton
    Friend WithEvents optGaussian As System.Windows.Forms.RadioButton
    Friend WithEvents optClassic As System.Windows.Forms.RadioButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
