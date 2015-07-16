Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s3_frmFCASettings

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

    Private Sub btn3_Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn3Prev.Click
 
        'reset Network details and FCA settings to initial defaults
        configObj.NWlayerindex = -1
        configObj.NWimpedanceField = ""
        configObj.NWdefCutOff = 0.0
        configObj.NWscale = 1.0

        'display previous form
        Dim p_s2frmSupplyDemand As New s2_frmSupplyDemand(configObj)
        p_s2frmSupplyDemand.Location = Me.Location
        p_s2frmSupplyDemand.Show()
        Me.Dispose()

    End Sub

    Private Sub btn3Next_Click(sender As System.Object, e As System.EventArgs) Handles btn3Next.Click

        'store NW dataset layer index and attribute name of impedance in configObj
        Dim list_item As layerItem = m_NWlayers(cboNWdataset.SelectedIndex)
        configObj.NWlayerindex = list_item.position
        configObj.NWimpedanceField = cboCostField.Text

        'store FCA method
        If (cboDecayModel.SelectedIndex = 0) Then
            configObj.filter = decayType.Classic
        Else
            configObj.filter = decayType.Linear
        End If

        'store FC threshold size
        configObj.NWdefCutOff = Convert.ToDouble(txtCutOff.Text)

        'display next form
        Dim p_s4frmRun As New s4_frmRun(configObj)
        p_s4frmRun.Location = Me.Location
        p_s4frmRun.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'list of Network Dataset names/index positions
    Dim m_NWlayers As ArrayList

    'list of units for 'Cost' type attributes in the chosen network dataset
    Dim m_costFieldUnits As ArrayList = New ArrayList

    'flag to indicate if entered threshold value is valid
    Dim cutoffOK As Boolean = False

#End Region

#Region "formLoad configuration"

    Private Sub s3_frmNetworkLayers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get a list of Network data layers in the current map
        m_NWlayers = fcaUtilities.getNWLayers()

        If m_NWlayers.Count > 0 Then
            'populate the network dataset selection dropdown with this list
            For Each NWlayer As layerItem In m_NWlayers
                cboNWdataset.Items.Add(NWlayer.title)
            Next
            cboNWdataset.SelectedIndex = 0
        Else
            'or if no Network data layers are present, then issue a warning message
            MessageBox.Show("**Error** - there are no layers containing a network dataset", _
                                         "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        cboDecayModel.SelectedIndex = 0
        checkComplete()

    End Sub

#End Region

#Region "user selects Network dataset"

    Private Sub cboNWdataset_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNWdataset.SelectedIndexChanged

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim pLayer As ILayer = Nothing
        Dim pNWLayer As INetworkLayer = Nothing
        Dim pNWdataset As INetworkDataset = Nothing
        Dim networkAttribute As INetworkAttribute = Nothing
        Dim selectedNWlayer As layerItem = Nothing

        selectedNWlayer = m_NWlayers(cboNWdataset.SelectedIndex)
        configObj.NWlayerindex = selectedNWlayer.position

        'track from layer, to network layer, to network dataset
        pLayer = pMap.Layer(configObj.NWlayerindex)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset

        'get all Cost attributes and populate dropdown
        Try

            cboCostField.Items.Clear()
            m_costFieldUnits.Clear()

            For i As Integer = 0 To pNWdataset.AttributeCount - 1
                networkAttribute = pNWdataset.Attribute(i)
                If networkAttribute.UsageType = esriNetworkAttributeUsageType.esriNAUTCost Then
                    cboCostField.Items.Add(networkAttribute.Name)
                    m_costFieldUnits.Add(networkAttribute.Units.ToString)
                End If
            Next

            If pNWdataset.AttributeCount > 0 Then
                'set Cost field to first item
                cboCostField.SelectedIndex = 0
            Else
                'or if no cost field is present, issue a warning message
                MessageBox.Show("**Error** - no Cost field found in the selected Network Dataset", _
                                                "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cboCostField.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock NW Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        checkComplete()

    End Sub

#End Region

    'Validate the catchment threshold value on Leave event
    'Private Sub txtCutOff_Leave(sender As System.Object, e As System.EventArgs) Handles txtCutOff.Leave
    '    Try
    '        Dim d As Double = Convert.ToDouble(txtCutOff.Text)
    '        cutoffOK = (d > 0.0)
    '        If Not cutoffOK Then
    '            MessageBox.Show("- enter a numeric value greater than 0.0 for the threshold" & Environment.NewLine, _
    '                                        "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            cutoffOK = False
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("- enter a numeric value greater than 0.0 for the threshold" & Environment.NewLine _
    '                                        & ex.Message, "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        cutoffOK = False
    '    End Try
    '    checkComplete()
    'End Sub

    Private Sub checkComplete()
        Dim ok As Boolean = (cboNWdataset.SelectedIndex > -1) And (cboCostField.SelectedIndex > -1) _
                                And (cboDecayModel.SelectedIndex > -1) And cutoffOK
        btn3Next.Enabled = ok
    End Sub

    Private Sub txtCutOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCutOff.TextChanged
        Double.TryParse(txtCutOff.Text, cutoffOK)
        checkComplete()
    End Sub
End Class