Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s2_frmSupplyDetails

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

        'display previous form
        Dim p_s1frmNetworkLayer As New s1_frmNetworkLayer(configObj)
        p_s1frmNetworkLayer.Location = Me.Location
        p_s1frmNetworkLayer.Show()
        Me.Dispose()

    End Sub

    Private Sub btn2Next_Click(sender As System.Object, e As System.EventArgs) Handles btn2Next.Click

        'store Supply points layer index in configObj
        Dim list_item As layerItem = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
        configObj.SupplyLayerIndex = list_item.position

        'store Selected Items option and Supply Volume field index in configObj
        configObj.SupplySelected = chkSplSel.Checked
        If chkSupplyField.Checked Then
            list_item = m_Fieldlist(cboSupplyVolumeField.SelectedIndex)
            configObj.SupplyVolumeField = list_item.position
        Else
            configObj.SupplyVolumeField = -1
        End If

        'display next form
        Dim p_s3frmDemandDetails As New s3_frmDemandDetails(configObj)
        p_s3frmDemandDetails.Location = Me.Location
        p_s3frmDemandDetails.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'List of point-data layer names and thier map index positions
    Dim m_Pointlayers As List(Of layerItem)

    'List of field names that could be used as Supply Volume
    Dim m_Fieldlist As List(Of layerItem)

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
            Next
            cboSupplyPointsLayer.SelectedIndex = 0
            btn2Next.Enabled = True
        Else
            'if no Point data layer present issue warning message
            MessageBox.Show("**Error** - no layers containing point objects identified", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn2Next.Enabled = False
        End If
    End Sub

#End Region

#Region "user selects a Supply points layer"

    Private Sub cboDestinationLocations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSupplyPointsLayer.SelectedIndexChanged

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim PFLayer As IFeatureLayer2 = Nothing
        Dim pFS As IFeatureSelection = Nothing
        Dim pSS As ISelectionSet2 = Nothing

        'set Supply Volume option to off
        chkSupplyField.Checked = False

        'determine if a Selection Set is present in selected Layer
        PFLayer = pMap.Layer(m_Pointlayers(cboSupplyPointsLayer.SelectedIndex).position)
        pFS = PFLayer
        pSS = pFS.SelectionSet

        'if yes, allow selected features to be specified
        'if not, disable the selected features option
        If pSS.Count > 0 Then
            chkSplSel.Enabled = True
        Else
            chkSplSel.Enabled = False
            chkSplSel.Checked = False
        End If

    End Sub

#End Region

#Region "a supply volume field is requested"

    Private Sub chkSupplyField_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSupplyField.CheckedChanged

        If chkSupplyField.Checked Then

            'get list of field names that may represent a supply volume
            Dim layer_item As layerItem = m_Pointlayers(cboSupplyPointsLayer.SelectedIndex)
            m_Fieldlist = fcaUtilities.getDatafields(layer_item.position)

            'populate dropdown with field names
            If m_Fieldlist.Count > 0 Then
                For Each field_item As layerItem In m_Fieldlist
                    cboSupplyVolumeField.Items.Add(field_item.title)
                Next
                cboSupplyVolumeField.SelectedIndex = 0
            Else
                'or issue a warning message (provided not initial form load)
                chkSupplyField.Checked = False
                If Not first Then
                    MessageBox.Show("~ The selected Supply Layer has no suitable numeric fields" & Environment.NewLine _
                                                     & "     that can carry the Supply Volume information", _
                                                         "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                first = False
            End If

        Else
            'if deactivated, clear dropdown list of field names
            cboSupplyVolumeField.Items.Clear()
            cboSupplyVolumeField.SelectedIndex = -1
            cboSupplyVolumeField.Text = ""
        End If

        'activate/deactive on-screen controls in response to user selection
        cboSupplyVolumeField.Enabled = chkSupplyField.Checked
        TextBox2.Enabled = chkSupplyField.Checked

    End Sub

#End Region

End Class