Public Class s4_frmParameters

#Region "formControl"

    Private m_configObj As configParams

    'Handles passing of the configObject through the forms
    Public Property configObj() As configParams
        Get
            Return m_configObj
        End Get
        Set(ByVal value As configParams)
            m_configObj = value
        End Set
    End Property

    Public Sub New(ByRef cObject As configParams)
        MyBase.New()
        'sets class level variable to the passed user object  
        configObj = cObject
        InitializeComponent()
    End Sub

    Private Sub btn4_Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn4_Prev.Click

        'redisplay previous form
        Dim p_s3frmDemandDetails As New s3_frmFCASettings(configObj)
        p_s3frmDemandDetails.Location = Me.Location
        p_s3frmDemandDetails.Show()
        Me.Dispose()

    End Sub

    Private Sub btn4Next_Click(sender As System.Object, e As System.EventArgs) Handles btn4Next.Click

        'store FCA options in configObj
        configObj.gaussian_bw = Convert.ToDouble(numUpDown1.Value)
        configObj.butterworth_bw = Convert.ToDouble(numUpDown3.Value)
        configObj.butterworth_pwr = Convert.ToDouble(numUpDown2.Value)
        configObj.ResultsLocation = txtResultsPath.Text

        'display next form
        Dim p_s5frmParameters As New s5_frmResults(configObj)
        p_s5frmParameters.Location = Me.Location
        p_s5frmParameters.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "form load configuration"

    Private Sub s4_frmParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'display user's default folder as initial output folder
        txtResultsPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    End Sub

#End Region

#Region "select output folder"

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        'select path for output table using FolderBrowser dialog
        FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtResultsPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

#End Region

#Region "user selects FCA type"

    Private Sub optClassic_CheckedChanged(sender As System.Object, e As System.EventArgs) _
        Handles optClassic.CheckedChanged, optLinear.CheckedChanged, optGaussian.CheckedChanged, optButterworth.CheckedChanged

        pnlGauss.Enabled = False
        pnlButt.Enabled = False

        'display appropriate diagram and store choice in configObj
        If optClassic.Checked Then
            pbDecayType.Image = My.Resources.Fig_None
            configObj.filter = decayType.Classic
        ElseIf optLinear.Checked Then
            pbDecayType.Image = My.Resources.Fig_Linear
            configObj.filter = decayType.Linear
        ElseIf optGaussian.Checked Then
            pbDecayType.Image = My.Resources.Fig_Gaussian
            configObj.filter = decayType.Gaussian
            pnlGauss.Enabled = True
        Else
            pbDecayType.Image = My.Resources.Fig_Butterworth
            configObj.filter = decayType.Butterworth
            pnlButt.Enabled = True
        End If

    End Sub

#End Region

End Class