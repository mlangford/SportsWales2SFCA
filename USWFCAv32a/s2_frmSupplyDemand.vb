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

    Private Sub btn2Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn2Prev.Click

        'reset Supply details to initial defaults
        configObj.SupplyLayerIndex = -1
        configObj.SupplySelected = False
        configObj.SupplyVolumeField = -1

        'reset Demand details to initial defaults
        configObj.DemandLayerIndex = -1
        configObj.DemandSelected = False
        configObj.DemandVolumeField = -1

        'display previous form
        Dim p_s1frmNetworkLayer As New s1_frmIntroduction(configObj)
        p_s1frmNetworkLayer.Location = Me.Location
        p_s1frmNetworkLayer.Show()
        Me.Dispose()

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

    'List of field names that could be used as Supply Volume
    Dim m_FieldlistSup As List(Of layerItem)

    'List of field names that could be used as Demand Volume
    Dim m_FieldlistDem As List(Of layerItem)

    'Flag to prevent the field names warning on initial form load
    Dim first As Boolean = True

#End Region

#Region "formLoad configuration"

    Private Sub s2_frmSupplyDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get List of all Point data layers in current map
        m_Pointlayers = fcaUtilities.getPointLayers(-1)

        'populate dropdown with names of all Point data layers
        If m_Pointlayers.Count > 0 Then
            For Each list_item As layerItem In m_Pointlayers
                cboSupplyPointsLayer.Items.Add(list_item.title)
                cboDemandPointsLayer.Items.Add(list_item.title)
            Next
            cboSupplyPointsLayer.SelectedIndex = 0
            cboDemandPointsLayer.SelectedIndex = 0
            btn2Next.Enabled = True
        Else
            'if no Point data layer present issue warning message
            MessageBox.Show("**Error** - no layers containing point objects are identified", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn2Next.Enabled = False
        End If
    End Sub

#End Region

#Region "user selects a Supply points layer"

    Private Sub cboDestinationLocations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSupplyPointsLayer.SelectedIndexChanged

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap
        Dim layer_item As layerItem

        'get list of field names that may represent a supply volume
        layer_item = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
        m_FieldlistSup = fcaUtilities.getDatafields(layer_item.position)

        'populate dropdown with field names
        If m_FieldlistSup.Count > 0 Then
            For Each field_item As layerItem In m_FieldlistSup
                cboSupplyVolumeField.Items.Add(field_item.title)
            Next
            cboSupplyVolumeField.SelectedIndex = 0
            cboSupplyVolumeField.Enabled = True
        Else
            'or issue a warning message (provided not initial form load)
            If Not first Then
                MessageBox.Show("~ The selected Supply Layer has no numeric fields" & Environment.NewLine _
                                                 & "     One is needed for the Supply Volume information", _
                                                     "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

#End Region

#Region "user selects a Demand points layer"

    Private Sub cboDemandPointsLayer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDemandPointsLayer.SelectedIndexChanged

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap
        Dim layer_item As layerItem

        'get list of field names that may represent a demand volume
        layer_item = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
        m_FieldlistDem = fcaUtilities.getDatafields(layer_item.position)

        'populate dropdown with field names
        If m_FieldlistDem.Count > 0 Then
            For Each field_item As layerItem In m_FieldlistDem
                cboDemandVolumeField.Items.Add(field_item.title)
            Next
            cboDemandVolumeField.SelectedIndex = 0
            cboDemandVolumeField.Enabled = True
        Else
            'or issue a warning message (provided not initial form load)
            If Not first Then
                MessageBox.Show("~ The selected Demand Layer has no numeric fields" & Environment.NewLine _
                                                 & "     One is needed for the Demand Volume information", _
                                                     "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            first = False
        End If

    End Sub

#End Region

End Class