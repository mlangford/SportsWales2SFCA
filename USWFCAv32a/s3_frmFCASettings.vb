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

        'redisplay previous form
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

        'store FCA threshold size and score scaling factor in configObj
        Try
            configObj.NWdefCutOff = Convert.ToDouble(txtCutOff.Text)
        Catch ex As Exception
            MessageBox.Show("- unable to read FCA dimensions setting as a valid numeric input" & Environment.NewLine _
                                            & ex.Message, "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        'Try
        '    configObj.NWscale = Convert.ToDouble(cboScale.Text)
        'Catch ex As Exception
        '    MessageBox.Show("*ERROR* in scaling factor")
        '    Return
        'End Try

        'display next form
        Dim p_s4frmParameters As New s4_frmParameters(configObj)
        p_s4frmParameters.Location = Me.Location
        p_s4frmParameters.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'list of Network Dataset names/index positions
    Dim m_NWlayers As ArrayList

    'list of units for 'Cost' type attributes in the chosen network dataset
    Dim m_costFieldUnits As ArrayList = New ArrayList

#End Region

#Region "formLoad configuration"

    Private Sub s3_frmDemandDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get list of NetWork Dataset names/index positions
        m_NWlayers = fcaUtilities.getNWLayers()

        'if no Network Data layer is present, issue warning and prevent further progress
        If m_NWlayers.Count = 0 Then
            MessageBox.Show("**Error** - no layers containing a Network Dataset were identified", "**ERROR**", _
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboNWdataset.SelectedIndex = -1
            btn3Next.Enabled = False
            Return
        End If

        'populate dropdown with the Network Dataset names
        For Each NWlayer As layerItem In m_NWlayers
            cboNWdataset.Items.Add(NWlayer.title)
        Next
        cboNWdataset.SelectedIndex = 0
        grpImpedance.Enabled = True
        btn3Next.Enabled = True



        'get List of all Point data layers in current map (excluding selected Supply layer)
        m_Pointlayers = fcaUtilities.getPointlayers(configObj.SupplyLayerIndex)

        'populate dropdown with names of all Point data layers
        If m_Pointlayers.Count > 0 Then
            For Each list_item As layerItem In m_Pointlayers
                cboDemandPointsLayer.Items.Add(list_item.title)
            Next
            cboDemandPointsLayer.SelectedIndex = 0
            btn3Next.Enabled = True
        Else
            'if no Point data layer present issue warning message
            MessageBox.Show("**Error** - no layers containing point objects identified", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn3Next.Enabled = False
        End If
    End Sub

#End Region

#Region "user selects a Demand points layer"

    Private Sub cboOriginLocations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim PFLayer As IFeatureLayer2 = Nothing
        Dim pFS As IFeatureSelection = Nothing
        Dim pSS As ISelectionSet2 = Nothing

        'determine if a Selection Set is present in selected Layer
        PFLayer = pMap.Layer(m_Pointlayers(cboDemandPointsLayer.SelectedIndex).position)
        pFS = PFLayer
        pSS = pFS.SelectionSet

        'if yes, allow selected features to be specified
        'if not, disable the selected features option
        If pSS.Count > 0 Then
            chkDmdSel.Enabled = True
        Else
            chkDmdSel.Enabled = False
            chkDmdSel.Checked = False
        End If

        'get list of field names that may represent a demand volume
        Dim layer_item As layerItem = m_Pointlayers(cboDemandPointsLayer.SelectedIndex)
        m_Fieldlist = fcaUtilities.getDatafields(layer_item.position)

        'populate dropdown with these names and select first item
        If m_Fieldlist.Count > 0 Then
            TextBox2.Enabled = True
            chkDemandField.Enabled = True
            chkDemandField.Checked = True
            cboDecayModel.Items.Clear()
            For Each field_item As layerItem In m_Fieldlist
                cboDemandField.Items.Add(field_item.title)
            Next
            cboDecayModel.SelectedIndex = 0
        Else
            'or issue a warning message (provided this is not on form load)
            TextBox2.Enabled = False
            chkDemandField.Enabled = False
            chkDemandField.Checked = False
            cboDecayModel.SelectedIndex = 0
            MessageBox.Show("Selected Demand layer has no suitable fields for the" & Environment.NewLine _
                                       & "  Demand Volume information: field selection disabled", _
                                                           "*Information*", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

#End Region

#Region "demand volume field is requested"

    Private Sub chkDemandField_CheckedChanged(sender As System.Object, e As System.EventArgs)

        If Not chkDemandField.Checked Then
            TextBox2.Enabled = False
            cboDecayModel.Enabled = False
        Else
            TextBox2.Enabled = True
            cboDecayModel.Enabled = True
        End If

    End Sub

#End Region

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

        'get Cost attributes and populate drop-down-list
        cboCostField.Items.Clear()
        m_costFieldUnits.Clear()
        Try
            For i As Integer = 0 To pNWdataset.AttributeCount - 1
                networkAttribute = pNWdataset.Attribute(i)
                If networkAttribute.UsageType = esriNetworkAttributeUsageType.esriNAUTCost Then
                    cboCostField.Items.Add(networkAttribute.Name)
                    m_costFieldUnits.Add(networkAttribute.Units.ToString)
                End If
            Next
            If pNWdataset.AttributeCount > 0 Then
                'set Cost field as the first list item
                cboCostField.SelectedIndex = 0
                lblUnits.Visible = True
                grpFCAscaling.Enabled = True
            Else
                'if no cost field, issue warning message and prevent further progress
                MessageBox.Show("**Error** - no Cost field was found in selected Network Dataset", _
                                                "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btn3Next.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class