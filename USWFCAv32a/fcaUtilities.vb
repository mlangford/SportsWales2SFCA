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
            MessageBox.Show(ex.Message, "Error: getNWLayers", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getNWLayers = listNWlayers

    End Function

#End Region

#Region "getPointlayers"

    'Returns a list of layerItems carrying the names & index
    'positions of all point data layers. if the omit parameter > 0,
    'the layer with this index value is ommitted from the list

    Function getPointlayers(omit As Integer) As List(Of layerItem)

        Dim list_item As layerItem
        Dim list_point_layers As New List(Of layerItem)

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
                            list_item.position = i
                            list_item.title = pLayer.Name
                            list_point_layers.Add(list_item)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: getPointlayers", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getPointlayers = list_point_layers

    End Function

#End Region

#Region "getDatafields"

    'Returns a list of LayerItems carrying the names & index positions of all numeric 
    'data attribute fields in the Feature Class located at the passed index position 

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

            'cycle through each field to identify its type and
            'only add a fields of type: small int, int, single or double
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
            MessageBox.Show(ex.Message, "Error: getDatafields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields = list_Fields

    End Function


    'Returns a list of layerItems carrying the names & index positions of all numeric
    'data attribute fields in Table of Feature Class located at the passed index position 

    Function getDatafields2(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing
        Dim list_item As layerItem = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)

            '**Cast to ITable to access fields in a joined table
            Dim pDisplayTable As IDisplayTable = pFLayer
            Dim pTable As ITable = pDisplayTable.DisplayTable
            pFields = pTable.Fields

            'cycle through each field, identify type, and only
            'add fields of type: small int, int, single or double
            For i As Integer = 0 To pFields.FieldCount - 1
                pField = pFields.Field(i)
                If pField.Type < 4 Then
                    list_item.title = pField.Name
                    list_item.position = i
                    list_Fields.Add(list_item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: getDatafields2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields2 = list_Fields

    End Function


    'Returns a list of layerItems carrying the names & index positions of all attribute
    'fields in Table of Feature Class located at the passed index position

    Function getDatafields3(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing
        Dim list_item As layerItem = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)

            '**Cast to ITable from IFeatureClass
            '     to access fields in a joined table
            Dim pDisplayTable As IDisplayTable = pFLayer
            Dim pTable As ITable = pDisplayTable.DisplayTable
            pFields = pTable.Fields

            'cycle through each field and add to list
            For i As Integer = 0 To pFields.FieldCount - 1
                pField = pFields.Field(i)
                    list_item.title = pField.Name
                    list_item.position = i
                    list_Fields.Add(list_item)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: getDatafields3", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields3 = list_Fields

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
        End If

    End Function

#End Region


    Sub showconfigParams(ByRef cObject As configParams)

        Dim f2 As New frmActivityLog
        f2.Show()

        f2.txtLog.AppendText("NWlayerindex  " & cObject.NWlayerindex.ToString & vbCrLf)
        f2.txtLog.AppendText("NWimpedanceField  " & cObject.NWimpedanceField.ToString & vbCrLf)
        f2.txtLog.AppendText("NWCutoff  " & cObject.NWdefCutOff.ToString & vbCrLf)
        f2.txtLog.AppendText("NW Scale  " & cObject.NWscale.ToString & vbCrLf)
        f2.txtLog.AppendText("Supply Index  " & cObject.SupplyLayerIndex.ToString & vbCrLf)
        f2.txtLog.AppendText("Supply Selected  " & cObject.SupplySelected.ToString & vbCrLf)
        f2.txtLog.AppendText("Supply Volume Field  " & cObject.SupplyVolumeField.ToString & vbCrLf)
        f2.txtLog.AppendText("Demandy Index  " & cObject.DemandLayerIndex.ToString & vbCrLf)
        f2.txtLog.AppendText("Demand Selected  " & cObject.DemandSelected.ToString & vbCrLf)
        f2.txtLog.AppendText("Demand Volume Field   " & cObject.DemandVolumeField.ToString & vbCrLf)
        f2.txtLog.AppendText("Res Location   " & cObject.ResultsLocation.ToString & vbCrLf)
        f2.txtLog.AppendText("Filter type " & cObject.filter.ToString & vbCrLf)
    End Sub

End Module
