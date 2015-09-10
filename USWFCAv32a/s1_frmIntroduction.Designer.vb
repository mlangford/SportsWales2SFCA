<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s1_frmIntroduction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(s1_frmIntroduction))
        Me.grpNetworklayer = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btn1Next = New System.Windows.Forms.Button()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.grpNetworklayer.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpNetworklayer
        '
        Me.grpNetworklayer.Controls.Add(Me.TextBox1)
        Me.grpNetworklayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.grpNetworklayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNetworklayer.Location = New System.Drawing.Point(12, 180)
        Me.grpNetworklayer.Margin = New System.Windows.Forms.Padding(4)
        Me.grpNetworklayer.Name = "grpNetworklayer"
        Me.grpNetworklayer.Padding = New System.Windows.Forms.Padding(4)
        Me.grpNetworklayer.Size = New System.Drawing.Size(704, 251)
        Me.grpNetworklayer.TabIndex = 2
        Me.grpNetworklayer.TabStop = False
        Me.grpNetworklayer.Text = "Introduction:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(7, 34)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(682, 204)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(159, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(430, 58)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Geographical Accessibility Scores" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(FCA and other common metrics)"
        '
        'btnAbout
        '
        Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.Location = New System.Drawing.Point(12, 448)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(97, 28)
        Me.btnAbout.TabIndex = 24
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btn1Next
        '
        Me.btn1Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1Next.ForeColor = System.Drawing.Color.White
        Me.btn1Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn1Next.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn1Next.Location = New System.Drawing.Point(652, 435)
        Me.btn1Next.Margin = New System.Windows.Forms.Padding(4)
        Me.btn1Next.Name = "btn1Next"
        Me.btn1Next.Size = New System.Drawing.Size(55, 54)
        Me.btn1Next.TabIndex = 0
        Me.btn1Next.UseVisualStyleBackColor = True
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(12, 7)
        Me.PictureBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(255, 75)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 23
        Me.PictureBox9.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(304, 6)
        Me.PictureBox10.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(412, 76)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 50
        Me.PictureBox10.TabStop = False
        '
        's1_frmIntroduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(740, 503)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btn1Next)
        Me.Controls.Add(Me.grpNetworklayer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "s1_frmIntroduction"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SW-FCA - Page 1/4"
        Me.TopMost = True
        Me.grpNetworklayer.ResumeLayout(False)
        Me.grpNetworklayer.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpNetworklayer As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents btn1Next As System.Windows.Forms.Button
End Class
