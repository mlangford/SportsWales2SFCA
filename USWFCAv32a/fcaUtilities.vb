Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

Module fcaUtilities

#Region "getNWlayers"

    'Returns an arraylist with names & index positions of
    'all Network Dataset layers in the current focus map

    Function getNWLayers() As ArrayList


        Dim listNWlayers As New ArrayList
        Dim selectedNWlayer As layerItem

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            Dim pLayer As ILayer
            For i As Integer = 0 To pMap.LayerCount - 1
                pLayer = pMap.Layer(i)
                If TypeOf pLayer Is INetworkLayer Then
                    selectedNWlayer.position = i
                    selectedNWlayer.title = pLayer.Name
                    listNWlayers.Add(selectedNWlayer)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getNWLayers = listNWlayers

    End Function

#End Region

#Region "getPointlayers"

    'Returns list of layerItems carrying names & index
    'positions of all point data layers. if the omit parameter > 0,
    'the layer with this index value is ommitted from the list

    Function getPointlayers(omit As Integer) As List(Of layerItem)

        Dim list_point_layers As New List(Of layerItem)
        Dim list_item As layerItem

        Dim pLayer As ILayer = Nothing
        Dim PFLayer As IFeatureLayer = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            Dim layerCount As Integer = pMap.LayerCount


            For i As Integer = 0 To layerCount - 1
                pLayer = pMap.Layer(i)
                If TypeOf pLayer Is IGeoFeatureLayer Then
                    PFLayer = pLayer
                    If PFLayer.FeatureClass.ShapeType = esriGeometryType.esriGeometryPoint Then
                        If omit <> i Then
                            list_item.title = pLayer.Name
                            list_item.position = i
                            list_point_layers.Add(list_item)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getPointlayers = list_point_layers

    End Function

#End Region

#Region "getDatafields"

    'Returns list with layerItems carrying names & index positions of all numeric data
    'attribute fields in the Feature Class located at the passed index position 

    Function getDatafields(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFClass As IFeatureClass = Nothing
        Dim fields As IFields = Nothing
        Dim field As IField = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)
            pFClass = pFLayer.FeatureClass
            fields = pFClass.Fields

            'cycle through each field to identify type
            'only add a field of data type: small int, int, single or double
            Dim list_item As layerItem
            For i As Integer = 0 To fields.FieldCount - 1
                field = fields.Field(i)
                If field.Type < 4 Then
                    list_item.title = field.Name
                    list_item.position = i
                    list_Fields.Add(list_item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util3 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields = list_Fields

    End Function

#End Region

#Region "distance-decay scaling function"

    'Scales passed quantity by a distance-based weight using selected decay function 
    Public Function dist_weighted(ByRef quantity As Double, ByRef distance As Double, m_configObj As configParams) As Double

        If m_configObj.filter = decayType.Classic Then
            'No decay
            dist_weighted = quantity
        ElseIf m_configObj.filter = decayType.Linear Then
            'Linear decay 
            dist_weighted = quantity * (1.0# - (distance / m_configObj.NWdefCutOff))
        ElseIf m_configObj.filter = decayType.Gaussian Then
            'Gaussian decay                           
            dist_weighted = quantity * Math.Exp(-(distance ^ 2.0#) / ((m_configObj.NWdefCutOff * m_configObj.gaussian_bw / 100.0#) ^ 2.0#))
        ElseIf m_configObj.filter = decayType.Butterworth Then
            'Butterworth decay   
            Dim bw As Double = m_configObj.NWdefCutOff * m_configObj.butterworth_bw / 100.0#
            dist_weighted = quantity * 1.0# / (1.0# + ((distance / bw) ^ m_configObj.butterworth_pwr))
        End If

    End Function

#End Region

End Module
