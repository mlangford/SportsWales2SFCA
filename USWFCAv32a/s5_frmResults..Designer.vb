<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s5_frmResults
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(s5_frmResults))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.chkTidyUp = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(438, 391)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(286, 18)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Two-Step FCA is ready to compute..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnExecute
        '
        Me.btnExecute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExecute.Image = Global.USWFCAv32a.My.Resources.Resources.compute
        Me.btnExecute.Location = New System.Drawing.Point(700, 500)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(52, 52)
        Me.btnExecute.TabIndex = 54
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(25, 248)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(393, 277)
        Me.lstOutput.TabIndex = 53
        '
        'chkTidyUp
        '
        Me.chkTidyUp.AutoSize = True
        Me.chkTidyUp.Checked = True
        Me.chkTidyUp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTidyUp.Location = New System.Drawing.Point(444, 461)
        Me.chkTidyUp.Name = "chkTidyUp"
        Me.chkTidyUp.Size = New System.Drawing.Size(308, 17)
        Me.chkTidyUp.TabIndex = 52
        Me.chkTidyUp.Text = "Delete intermediate stage Network Analyst layers upon exit?"
        Me.chkTidyUp.UseVisualStyleBackColor = True
        Me.chkTidyUp.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.Image = Global.USWFCAv32a.My.Resources.Resources.finish
        Me.btnClose.Location = New System.Drawing.Point(774, 500)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(52, 52)
        Me.btnClose.TabIndex = 51
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(438, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(382, 120)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Two-Step Floating Catchment Accessibility Tool " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "developed in Visual Studio 2010," & _
    " coded in VB.NET" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Version:          32a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Authors:         Mitchel Langford" & _
    " / Richard Fry"
        '
        'PictureBox10
        '
        Me.PictureBox10.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(834, 176)
        Me.PictureBox10.TabIndex = 49
        Me.PictureBox10.TabStop = False
        '
        's5_frmResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.chkTidyUp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "s5_frmResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s5_frmResults"
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents chkTidyUp As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
End Class
