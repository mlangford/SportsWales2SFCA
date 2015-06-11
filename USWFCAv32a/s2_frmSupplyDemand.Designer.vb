<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s2_frmSupplyDemand
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
        Me.cboSupplyVolumeField = New System.Windows.Forms.ComboBox()
        Me.cboSupplyPointsLayer = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn2Prev = New System.Windows.Forms.Button()
        Me.btn2Next = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboDemandVolumeField = New System.Windows.Forms.ComboBox()
        Me.cboDemandPointsLayer = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1065, 290)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Service Supply Details"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Panel1.Controls.Add(Me.cboSupplyVolumeField)
        Me.Panel1.Controls.Add(Me.cboSupplyPointsLayer)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(10, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 230)
        Me.Panel1.TabIndex = 30
        '
        'cboSupplyVolumeField
        '
        Me.cboSupplyVolumeField.Enabled = False
        Me.cboSupplyVolumeField.FormattingEnabled = True
        Me.cboSupplyVolumeField.Location = New System.Drawing.Point(430, 150)
        Me.cboSupplyVolumeField.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSupplyVolumeField.Name = "cboSupplyVolumeField"
        Me.cboSupplyVolumeField.Size = New System.Drawing.Size(300, 39)
        Me.cboSupplyVolumeField.TabIndex = 32
        '
        'cboSupplyPointsLayer
        '
        Me.cboSupplyPointsLayer.FormattingEnabled = True
        Me.cboSupplyPointsLayer.Location = New System.Drawing.Point(430, 45)
        Me.cboSupplyPointsLayer.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSupplyPointsLayer.Name = "cboSupplyPointsLayer"
        Me.cboSupplyPointsLayer.Size = New System.Drawing.Size(300, 39)
        Me.cboSupplyPointsLayer.TabIndex = 31
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(20, 150)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(385, 39)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Field holding supply volume"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(20, 45)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(385, 39)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Layer holding supply points"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn2Prev
        '
        Me.btn2Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2Prev.ForeColor = System.Drawing.Color.White
        Me.btn2Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn2Prev.Location = New System.Drawing.Point(24, 615)
        Me.btn2Prev.Margin = New System.Windows.Forms.Padding(4)
        Me.btn2Prev.Name = "btn2Prev"
        Me.btn2Prev.Size = New System.Drawing.Size(55, 54)
        Me.btn2Prev.TabIndex = 11
        Me.btn2Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn2Prev.UseVisualStyleBackColor = True
        '
        'btn2Next
        '
        Me.btn2Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2Next.ForeColor = System.Drawing.Color.White
        Me.btn2Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn2Next.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn2Next.Location = New System.Drawing.Point(1032, 615)
        Me.btn2Next.Margin = New System.Windows.Forms.Padding(4)
        Me.btn2Next.Name = "btn2Next"
        Me.btn2Next.Size = New System.Drawing.Size(55, 54)
        Me.btn2Next.TabIndex = 10
        Me.btn2Next.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 315)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1065, 290)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Population Demand Details:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cboDemandVolumeField)
        Me.Panel2.Controls.Add(Me.cboDemandPointsLayer)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.TextBox4)
        Me.Panel2.Location = New System.Drawing.Point(10, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(760, 230)
        Me.Panel2.TabIndex = 32
        '
        'cboDemandVolumeField
        '
        Me.cboDemandVolumeField.Enabled = False
        Me.cboDemandVolumeField.FormattingEnabled = True
        Me.cboDemandVolumeField.Location = New System.Drawing.Point(430, 150)
        Me.cboDemandVolumeField.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandVolumeField.Name = "cboDemandVolumeField"
        Me.cboDemandVolumeField.Size = New System.Drawing.Size(300, 39)
        Me.cboDemandVolumeField.TabIndex = 27
        '
        'cboDemandPointsLayer
        '
        Me.cboDemandPointsLayer.FormattingEnabled = True
        Me.cboDemandPointsLayer.Location = New System.Drawing.Point(430, 45)
        Me.cboDemandPointsLayer.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandPointsLayer.Name = "cboDemandPointsLayer"
        Me.cboDemandPointsLayer.Size = New System.Drawing.Size(300, 39)
        Me.cboDemandPointsLayer.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(20, 150)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(385, 39)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.Text = "Field holding demand volume"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(20, 45)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(385, 39)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.Text = "Layer holding demand points"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        's2_frmSupplyDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1112, 692)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn2Prev)
        Me.Controls.Add(Me.btn2Next)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "s2_frmSupplyDemand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "E2SFCA - Page 2/5"
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn2Prev As System.Windows.Forms.Button
    Friend WithEvents btn2Next As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cboSupplyVolumeField As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplyPointsLayer As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboDemandVolumeField As System.Windows.Forms.ComboBox
    Friend WithEvents cboDemandPointsLayer As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
