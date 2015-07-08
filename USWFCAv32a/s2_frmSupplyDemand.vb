Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s2_frmSupplyDemand

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

    Private Sub btn2Next_Click(sender As System.Object, e As System.EventArgs) Handles btn2Next.Click

        Dim list_item As layerItem

        'store Supply points layer index in configObj
        list_item = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
        configObj.SupplyLayerIndex = list_item.position

        'store Demand points layer index in configObj
        list_item = m_Pointlayers(cboDemandPointsLayer.SelectedIndex)
        configObj.DemandLayerIndex = list_item.position

        'store Supply Volume field index in configObj
        configObj.SupplySelected = True
        list_item = m_FieldlistSup(cboSupplyVolumeField.SelectedIndex)
        configObj.SupplyVolumeField = list_item.position

        'store Demand Volume field index in configObj
        configObj.DemandSelected = True
        list_item = m_FieldlistDem(cboDemandVolumeField.SelectedIndex)
        configObj.DemandVolumeField = list_item.position

        'display the next form
        Dim p_s3frmDemandDetails As New s3_frmFCASettings(configObj)
        p_s3frmDemandDetails.Location = Me.Location
        p_s3frmDemandDetails.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'List of point-data layer names and their map index positions
    Dim m_Pointlayers As List(Of layerItem)

    'List of field names that could be a Supply Volume
    Dim m_FieldlistSup As List(Of layerItem)

    'List of field names that could be a Demand Volume
    Dim m_FieldlistDem As List(Of layerItem)

#End Region

#Region "formLoad configuration"

    Private Sub s2_frmSupplyDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get a list of all Point data layers in the current map
        m_Pointlayers = fcaUtilities.getPointLayers(-1)

        If m_Pointlayers.Count > 0 Then
            'populate the layer selection dropdowns with this list
            For Each list_item As layerItem In m_Pointlayers
                cboSupplyPointsLayer.Items.Add(list_item.title)
                cboDemandPointsLayer.Items.Add(list_item.title)
            Next
        Else
            'or if no Point data layers are present, then issue a warning message
            MessageBox.Show("**Error** - there are no layers containing point objects", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        checkComplete()

    End Sub

#End Region

#Region "user selects the Supply points layer"

    Private Sub cboSupplyPointsLayer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSupplyPointsLayer.SelectedIndexChanged

        'get a list of all field names in the Supply layer that might be a supply volume
        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap
        Dim layer_item As layerItem
        layer_item = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
        m_FieldlistSup = fcaUtilities.getDatafields2(layer_item.position)

        If m_FieldlistSup.Count > 0 Then
            'populate field selection dropdown with this list
            cboSupplyVolumeField.Items.Clear()
            For Each field_item As layerItem In m_FieldlistSup
                cboSupplyVolumeField.Items.Add(field_item.title)
            Next
            'set field selection to the first item
            cboSupplyVolumeField.SelectedIndex = 0
        Else
            'or if no suitable fields are available, issue a warning message
            MessageBox.Show("Selected Supply Layer has no numeric fields" & Environment.NewLine _
                                             & "     but one is needed for Supply Volume information", _
                                                 "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboSupplyVolumeField.Items.Clear()
            cboSupplyVolumeField.ResetText()
            cboSupplyVolumeField.SelectedIndex = -1
        End If

        checkComplete()

    End Sub

#End Region

#Region "user selects the Demand points layer"

    Private Sub cboDemandPointsLayer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDemandPointsLayer.SelectedIndexChanged

        'get a list of all field names in the Demand layer that might be a demand volume
        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap
        Dim layer_item As layerItem
        layer_item = m_Pointlayers(cboDemandPointsLayer.SelectedIndex)
        m_FieldlistDem = fcaUtilities.getDatafields2(layer_item.position)

        If m_FieldlistDem.Count > 0 Then
            'populate field selection dropdown with this list
            cboDemandVolumeField.Items.Clear()
            For Each field_item As layerItem In m_FieldlistDem
                cboDemandVolumeField.Items.Add(field_item.title)
            Next
            'set the field selection to the first item in the list
            cboDemandVolumeField.SelectedIndex = 0
        Else
            'or if no suitable fields are available, issue a warning message
            MessageBox.Show("Selected Demand Layer has no numeric fields" & Environment.NewLine _
                                             & "     but one is needed for Demand Volume information", _
                                                 "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboDemandVolumeField.Items.Clear()
            cboDemandVolumeField.ResetText()
            cboDemandVolumeField.SelectedIndex = -1
        End If

        checkComplete()

    End Sub

#End Region

    Private Sub checkComplete()
        Dim ok As Boolean = (cboSupplyPointsLayer.SelectedIndex > -1) And (cboDemandPointsLayer.SelectedIndex > -1) _
                                And (cboSupplyVolumeField.SelectedIndex > -1) And (cboDemandVolumeField.SelectedIndex > -1)
        btn2Next.Enabled = ok
    End Sub

End Class