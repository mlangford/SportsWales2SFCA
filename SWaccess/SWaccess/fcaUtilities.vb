Imports System.Text
Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

Module fcaUtilities

#Region "Get Network Layers"

    'Returns an arraylist with the names and index positions of
    'all the Network Dataset layers in the current focus map
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

#Region "Get Point Layers"

    'Returns a list of layerItems carrying the name and index
    'position of all point data layers. If the omit parameter is > 0,
    'then the layer with this index value is ommitted from the list
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

#Region "Get Data Fields"

    'Returns a list of layerItems carrying the name and index position of all numeric 
    'data attribute fields within the Feature Class located at the passed index position 
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


    'Returns a list of layerItems carrying the name and index position of all numeric data
    'attribute fields in the Table of the Feature Class located at the passed index position 
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


    'Returns a list of layerItems carrying the name and index position of all attribute
    'fields in the Table of the Feature Class located at the passed index position
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

    'Scales the passed quantity by a distance-based weight using a linear decay function 
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

#Region "Build NA load string"

    'Returns a NA load string using the full names of and joined fields
    Function getNALoadString(displayTable As IDisplayTable) As String

        Dim builder As New StringBuilder

        Dim pTable As ITable = displayTable.DisplayTable
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing

        'Build a string that identifies the field names of the network locations infromation
        
        pFields = pTable.Fields

        builder.Append("SourceID ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SourceID") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("SourceOID ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SourceOID") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("PosAlong ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("PosAlong") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("SideOfEdge ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SideOfEdge") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("Name ")
        builder.Append(displayTable.DisplayTable.OIDFieldName)
        builder.Append("  #")

        getNALoadString = builder.ToString()

    End Function
#End Region

#Region "Utility"

    'Used during program development: displays the current state of the configObj
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

#End Region

End Module
