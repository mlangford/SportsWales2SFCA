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

        'store the FCA computation method
        If (cboDecayModel.SelectedIndex = 0) Then
            configObj.filter = decayType.Classic
        Else
            configObj.filter = decayType.Linear
        End If

        'store the FCA catchment threshold size
        configObj.NWdefCutOff = Convert.ToDouble(txtCutOff.Text)

        'display the next form
        Dim p_s4frmRun As New s4_frmRun(configObj)
        p_s4frmRun.Location = Me.Location
        p_s4frmRun.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'list of Network Dataset names and their index positions
    Dim m_NWlayers As ArrayList

    'list of units for 'Cost' type attributes in the chosen network dataset
    Dim m_costFieldUnits As ArrayList = New ArrayList

    'a flag used to indicate if the entered threshold value is valid
    Dim cutoffOK As Boolean = False

#End Region

#Region "Form Load Configuration"

    Private Sub s3_frmNetworkLayers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get a list of all Network data layers in the current map
        m_NWlayers = fcaUtilities.getNWLayers()

        If m_NWlayers.Count > 0 Then
            'populate the network dataset selection dropdown with this list
            For Each NWlayer As layerItem In m_NWlayers
                cboNWdataset.Items.Add(NWlayer.title)
            Next
            cboNWdataset.SelectedIndex = 0
        Else
            'if no Network data layers are present, then issue a warning message
            MessageBox.Show("**Error** - there are no map layers containing a network dataset", _
                                         "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        cboDecayModel.SelectedIndex = 0
        checkComplete()

    End Sub

#End Region

#Region "Create List of Network Impedance fields"

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

        'get all Cost type attributes and use to populate the dropdown list
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
                'set the Cost field to the first item
                cboCostField.SelectedIndex = 0
            Else
                'if no cost field is present, issue a warning message
                MessageBox.Show("**Error** - no Cost field was found in the selected Network Dataset", _
                                                "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cboCostField.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock NW Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        checkComplete()

    End Sub

#End Region

#Region "Utility"

    Private Sub checkComplete()
        Dim ok As Boolean = (cboNWdataset.SelectedIndex > -1) _
                                 And (cboCostField.SelectedIndex > -1) _
                                 And (cboDecayModel.SelectedIndex > -1) _
                                 And cutoffOK
        btn3Next.Enabled = ok
    End Sub

    Private Sub txtCutOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCutOff.TextChanged
        Double.TryParse(txtCutOff.Text, cutoffOK)
        checkComplete()
    End Sub

#End Region

End Class