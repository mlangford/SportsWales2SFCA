﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s4_frmRun
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.radSpecify = New System.Windows.Forms.RadioButton()
        Me.radAuto = New System.Windows.Forms.RadioButton()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cboDemandIDField = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkdemandID = New System.Windows.Forms.CheckBox()
        Me.btn4Prev = New System.Windows.Forms.Button()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkKeepNAworkings = New System.Windows.Forms.CheckBox()
        Me.chkShowlog = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 59)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(705, 145)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Panel3.Controls.Add(Me.radSpecify)
        Me.Panel3.Controls.Add(Me.radAuto)
        Me.Panel3.Controls.Add(Me.txtFilename)
        Me.Panel3.Location = New System.Drawing.Point(10, 86)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(660, 50)
        Me.Panel3.TabIndex = 1
        '
        'radSpecify
        '
        Me.radSpecify.AutoSize = True
        Me.radSpecify.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSpecify.ForeColor = System.Drawing.Color.Black
        Me.radSpecify.Location = New System.Drawing.Point(159, 14)
        Me.radSpecify.Name = "radSpecify"
        Me.radSpecify.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radSpecify.Size = New System.Drawing.Size(169, 24)
        Me.radSpecify.TabIndex = 2
        Me.radSpecify.Text = "Specify filename"
        Me.radSpecify.UseVisualStyleBackColor = True
        '
        'radAuto
        '
        Me.radAuto.AutoSize = True
        Me.radAuto.Checked = True
        Me.radAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAuto.ForeColor = System.Drawing.Color.Black
        Me.radAuto.Location = New System.Drawing.Point(8, 14)
        Me.radAuto.Name = "radAuto"
        Me.radAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.radAuto.Size = New System.Drawing.Size(145, 24)
        Me.radAuto.TabIndex = 1
        Me.radAuto.TabStop = True
        Me.radAuto.Text = "Auto filename"
        Me.radAuto.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.BackColor = System.Drawing.Color.White
        Me.txtFilename.Enabled = False
        Me.txtFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilename.Location = New System.Drawing.Point(333, 14)
        Me.txtFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.txtFilename.Size = New System.Drawing.Size(283, 22)
        Me.txtFilename.TabIndex = 1
        Me.txtFilename.Text = "output"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtPath)
        Me.Panel1.Location = New System.Drawing.Point(10, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 50)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folder"
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.Location = New System.Drawing.Point(82, 14)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(534, 22)
        Me.txtPath.TabIndex = 0
        Me.txtPath.Text = "C:\TEMP"
        '
        'cboDemandIDField
        '
        Me.cboDemandIDField.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDemandIDField.FormattingEnabled = True
        Me.cboDemandIDField.Location = New System.Drawing.Point(333, 11)
        Me.cboDemandIDField.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandIDField.Name = "cboDemandIDField"
        Me.cboDemandIDField.Size = New System.Drawing.Size(283, 24)
        Me.cboDemandIDField.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 212)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(705, 87)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel2.Controls.Add(Me.chkdemandID)
        Me.Panel2.Controls.Add(Me.cboDemandIDField)
        Me.Panel2.Location = New System.Drawing.Point(10, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(660, 50)
        Me.Panel2.TabIndex = 0
        '
        'chkdemandID
        '
        Me.chkdemandID.AutoSize = True
        Me.chkdemandID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdemandID.ForeColor = System.Drawing.Color.White
        Me.chkdemandID.Location = New System.Drawing.Point(79, 11)
        Me.chkdemandID.Name = "chkdemandID"
        Me.chkdemandID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkdemandID.Size = New System.Drawing.Size(210, 24)
        Me.chkdemandID.TabIndex = 0
        Me.chkdemandID.Text = "Additional demand ID"
        Me.chkdemandID.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkdemandID.UseVisualStyleBackColor = True
        '
        'btn4Prev
        '
        Me.btn4Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4Prev.ForeColor = System.Drawing.Color.White
        Me.btn4Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn4Prev.Location = New System.Drawing.Point(24, 435)
        Me.btn4Prev.Margin = New System.Windows.Forms.Padding(4)
        Me.btn4Prev.Name = "btn4Prev"
        Me.btn4Prev.Size = New System.Drawing.Size(55, 54)
        Me.btn4Prev.TabIndex = 1
        Me.btn4Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn4Prev.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExecute.ForeColor = System.Drawing.Color.White
        Me.btnExecute.Image = Global.USWFCAv32a.My.Resources.Resources.finish
        Me.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExecute.Location = New System.Drawing.Point(652, 435)
        Me.btnExecute.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(55, 54)
        Me.btnExecute.TabIndex = 2
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 30)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Options:"
        '
        'chkKeepNAworkings
        '
        Me.chkKeepNAworkings.AutoSize = True
        Me.chkKeepNAworkings.ForeColor = System.Drawing.Color.Black
        Me.chkKeepNAworkings.Location = New System.Drawing.Point(308, 13)
        Me.chkKeepNAworkings.Name = "chkKeepNAworkings"
        Me.chkKeepNAworkings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkKeepNAworkings.Size = New System.Drawing.Size(279, 24)
        Me.chkKeepNAworkings.TabIndex = 7
        Me.chkKeepNAworkings.Text = "Retain network analyst layers"
        Me.chkKeepNAworkings.UseVisualStyleBackColor = True
        '
        'chkShowlog
        '
        Me.chkShowlog.AutoSize = True
        Me.chkShowlog.Location = New System.Drawing.Point(116, 13)
        Me.chkShowlog.Name = "chkShowlog"
        Me.chkShowlog.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkShowlog.Size = New System.Drawing.Size(173, 24)
        Me.chkShowlog.TabIndex = 8
        Me.chkShowlog.Text = "Show activity log"
        Me.chkShowlog.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 307)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(705, 87)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Panel5.Controls.Add(Me.chkShowlog)
        Me.Panel5.Controls.Add(Me.chkKeepNAworkings)
        Me.Panel5.Location = New System.Drawing.Point(10, 26)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(660, 50)
        Me.Panel5.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 444)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(12, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(583, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        's4_frmRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(730, 493)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn4Prev)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "s4_frmRun"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SW-FCA - Page 4/4"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btn4Prev As System.Windows.Forms.Button
    Friend WithEvents cboDemandIDField As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkdemandID As System.Windows.Forms.CheckBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents radSpecify As System.Windows.Forms.RadioButton
    Friend WithEvents radAuto As System.Windows.Forms.RadioButton
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkKeepNAworkings As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowlog As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class