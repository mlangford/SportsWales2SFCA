Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s3_frmDemandDetails

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

    Private Sub btn3_Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn3_Prev.Click

        'set Demand details to initial defaults
        configObj.DemandLayerIndex = -1
        configObj.DemandSelected = False
        configObj.DemandVolumeField = -1

        'redisplay previous form
        Dim p_s2frmSupplyDetails As New s2_frmSupplyDetails(configObj)
        p_s2frmSupplyDetails.Location = Me.Location
        p_s2frmSupplyDetails.Show()
        Me.Dispose()

    End Sub

    Private Sub btn3Next_Click(sender As System.Object, e As System.EventArgs) Handles btn3Next.Click

        'store Demand points layer index in configObj
        Dim list_item As layerItem = m_Pointlayers(cboDemandPointsLayer.SelectedIndex)
        configObj.DemandLayerIndex = list_item.position

        'store Selected Items option and Demand Volume field index in configObj
        configObj.DemandSelected = chkDmdSel.Checked
        If chkDemandField.Checked Then
            list_item = m_Fieldlist(cboDemandField.SelectedIndex)
            configObj.DemandVolumeField = list_item.position
        Else
            configObj.DemandVolumeField = -1
        End If

        'display next form
        Dim p_s4frmParameters As New s4_frmParameters(configObj)
        p_s4frmParameters.Location = Me.Location
        p_s4frmParameters.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'List of point-data layer names and their map index positions
    Dim m_Pointlayers As List(Of layerItem)

    'List of field names that could be used as Demand Volume
    Dim m_Fieldlist As List(Of layerItem)

#End Region

#Region "formLoad configuration"

    Private Sub s3_frmDemandDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

    Private Sub cboOriginLocations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDemandPointsLayer.SelectedIndexChanged

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
            cboDemandField.Items.Clear()
            For Each field_item As layerItem In m_Fieldlist
                cboDemandField.Items.Add(field_item.title)
            Next
            cboDemandField.SelectedIndex = 0
        Else
            'or issue a warning message (provided this is not on form load)
            TextBox2.Enabled = False
            chkDemandField.Enabled = False
            chkDemandField.Checked = False
            cboDemandField.SelectedIndex = 0
            MessageBox.Show("Selected Demand layer has no suitable fields for the" & Environment.NewLine _
                                       & "  Demand Volume information: field selection disabled", _
                                                           "*Information*", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

#End Region

#Region "demand volume field is requested"

    Private Sub chkDemandField_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDemandField.CheckedChanged

        If Not chkDemandField.Checked Then
            TextBox2.Enabled = False
            cboDemandField.Enabled = False
        Else
            TextBox2.Enabled = True
            cboDemandField.Enabled = True
        End If

    End Sub

#End Region

End Class