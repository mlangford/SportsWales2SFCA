<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s2_frmSupplyDetails
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
        Me.chkSplSel = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkSupplyField = New System.Windows.Forms.CheckBox()
        Me.cboSupplyVolumeField = New System.Windows.Forms.ComboBox()
        Me.cboSupplyPointsLayer = New System.Windows.Forms.ComboBox()
        Me.btn2Prev = New System.Windows.Forms.Button()
        Me.btn2Next = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSplSel
        '
        Me.chkSplSel.AutoSize = True
        Me.chkSplSel.Enabled = False
        Me.chkSplSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSplSel.Location = New System.Drawing.Point(579, 101)
        Me.chkSplSel.Name = "chkSplSel"
        Me.chkSplSel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSplSel.Size = New System.Drawing.Size(186, 20)
        Me.chkSplSel.TabIndex = 30
        Me.chkSplSel.Text = "Use only selected features"
        Me.chkSplSel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSplSel)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.chkSupplyField)
        Me.GroupBox2.Controls.Add(Me.cboSupplyVolumeField)
        Me.GroupBox2.Controls.Add(Me.cboSupplyPointsLayer)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(800, 300)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Identify service SUPPLY details:"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(6, 225)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(290, 50)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "Select the field that represents the service Supply volume (only numeric fields a" & _
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
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Select the layer that contains points objects" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "representing the service Supply lo" & _
    "cations :"
        '
        'chkSupplyField
        '
        Me.chkSupplyField.AutoSize = True
        Me.chkSupplyField.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSupplyField.Location = New System.Drawing.Point(403, 170)
        Me.chkSupplyField.Name = "chkSupplyField"
        Me.chkSupplyField.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSupplyField.Size = New System.Drawing.Size(362, 36)
        Me.chkSupplyField.TabIndex = 29
        Me.chkSupplyField.Text = "check to select a field in this layer as the Supply capacity" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (if unselected a d" & _
    "efault supply volume of '1' will be used)"
        Me.chkSupplyField.UseVisualStyleBackColor = True
        '
        'cboSupplyVolumeField
        '
        Me.cboSupplyVolumeField.Enabled = False
        Me.cboSupplyVolumeField.FormattingEnabled = True
        Me.cboSupplyVolumeField.Location = New System.Drawing.Point(325, 225)
        Me.cboSupplyVolumeField.Name = "cboSupplyVolumeField"
        Me.cboSupplyVolumeField.Size = New System.Drawing.Size(157, 24)
        Me.cboSupplyVolumeField.TabIndex = 26
        '
        'cboSupplyPointsLayer
        '
        Me.cboSupplyPointsLayer.FormattingEnabled = True
        Me.cboSupplyPointsLayer.Location = New System.Drawing.Point(325, 45)
        Me.cboSupplyPointsLayer.Name = "cboSupplyPointsLayer"
        Me.cboSupplyPointsLayer.Size = New System.Drawing.Size(440, 24)
        Me.cboSupplyPointsLayer.TabIndex = 0
        '
        'btn2Prev
        '
        Me.btn2Prev.Image = Global.USWFCAv32a.My.Resources.Resources.prevB
        Me.btn2Prev.Location = New System.Drawing.Point(18, 500)
        Me.btn2Prev.Name = "btn2Prev"
        Me.btn2Prev.Size = New System.Drawing.Size(52, 52)
        Me.btn2Prev.TabIndex = 11
        Me.btn2Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn2Prev.UseVisualStyleBackColor = True
        '
        'btn2Next
        '
        Me.btn2Next.Image = Global.USWFCAv32a.My.Resources.Resources.nextB
        Me.btn2Next.Location = New System.Drawing.Point(774, 500)
        Me.btn2Next.Name = "btn2Next"
        Me.btn2Next.Size = New System.Drawing.Size(52, 52)
        Me.btn2Next.TabIndex = 10
        Me.btn2Next.UseVisualStyleBackColor = True
        '
        's2_frmSupplyDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn2Prev)
        Me.Controls.Add(Me.btn2Next)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "s2_frmSupplyDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s2_frmSupplyDetails"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkSplSel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkSupplyField As System.Windows.Forms.CheckBox
    Friend WithEvents cboSupplyVolumeField As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplyPointsLayer As System.Windows.Forms.ComboBox
    Friend WithEvents btn2Prev As System.Windows.Forms.Button
    Friend WithEvents btn2Next As System.Windows.Forms.Button
End Class
