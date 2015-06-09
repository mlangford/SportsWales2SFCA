Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s1_frmNetworkLayer

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

    Private Sub btn1Next_Click(sender As System.Object, e As System.EventArgs) Handles btn1Next.Click

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
        Try
            configObj.NWscale = Convert.ToDouble(cboScale.Text)
        Catch ex As Exception
            MessageBox.Show("*ERROR* in scaling factor")
            Return
        End Try

        'display next form
        Dim p_s2frmDemandDetails As New s2_frmSupplyDetails(configObj)
        p_s2frmDemandDetails.Location = Me.Location
        p_s2frmDemandDetails.Show()
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

    Private Sub s1_frmNetworkLayer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get list of NetWork Dataset names/index positions
        m_NWlayers = fcaUtilities.getNWLayers()

        'if no Network Data layer is present, issue warning and prevent further progress
        If m_NWlayers.Count = 0 Then
            MessageBox.Show("**Error** - no layers containing a Network Dataset were identified", "**ERROR**", _
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboNWdataset.SelectedIndex = -1
            btn1Next.Enabled = False
            Return
        End If

        'populate dropdown with the Network Dataset names
        For Each NWlayer As layerItem In m_NWlayers
            cboNWdataset.Items.Add(NWlayer.title)
        Next
        cboNWdataset.SelectedIndex = 0
        grpImpedance.Enabled = True
        btn1Next.Enabled = True

    End Sub

#End Region

#Region "display list of Cost fields in selected NW layer"

    Private Sub cboNWdataset_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) _
        Handles cboNWdataset.SelectedIndexChanged

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
                btn1Next.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'display Cost field's Units
    Private Sub cboCostField_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCostField.SelectedIndexChanged
        Dim str() As String = Split(m_costFieldUnits(cboCostField.SelectedIndex), "esriNAU")
        lblUnits.Text = str(1)
    End Sub

#End Region

End Class