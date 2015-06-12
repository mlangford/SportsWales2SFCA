Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geoprocessing
Imports ESRI.ArcGIS.NetworkAnalyst
Imports ESRI.ArcGIS.esriSystem

Public Class s5_frmResults

#Region "form controls"

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

#End Region

#Region "computes accessibility scores"

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim pLayer As ILayer = Nothing
        Dim pNALayer As INALayer = Nothing
        Dim pNWLayer As INetworkLayer = Nothing
        Dim pNWdataset As INetworkDataset = Nothing

        Dim pNAContext1 As INAContext = Nothing   'provides access to network analysis context
        Dim pNAContext2 As INAContext = Nothing

        Dim inputFL As IFeatureLayer = Nothing
        Dim inputFC As IFeatureClass = Nothing

        btnExecute.Enabled = False
        lstOutput.Items.Add("Network Analyst messages:")
        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(0)   'set TOC to "Contents View tab"

        'track from layer -> network layer -> network dataset
        pLayer = pMap.Layer(configObj.NWlayerindex)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset


        '** CF solving **

        'set NAContext as a ClosestFacility solver
        pNAContext1 = fcaNAcreateClosestsolver(pNWdataset)

        Label2.Text = "1. Loading data for 'Closest Facility'"
        System.Windows.Forms.Application.DoEvents()

        'create and configure Network Analyst layer
        pNALayer = pNAContext1.Solver.CreateLayer(pNAContext1)
        pLayer = pNALayer
        pLayer.Name = "uswFCA_" + pNAContext1.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1) 'move to bottom of ToC

        'load Facilities (Supply) from selected Feature layer
        pLayer = pMap.Layer(configObj.SupplyLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        Dim OIDname As String = inputFC.OIDFieldName

        'create a Geoprocessor tool and parameters arrray
        Dim gp As IGeoProcessor2 = New GeoProcessor
        Dim params As IVariantArray = New VarArrayClass

        'fill parameters for Closest Facility tool, then add the points
        params.Add(pNALayer)
        params.Add("Facilities")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'load Incidents (Demand) from selected Feature Layer
        pLayer = pMap.Layer(configObj.DemandLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'refill parameters for Closest Facility tool, then add the points
        params.RemoveAll()
        params.Add(pNALayer)
        params.Add("Incidents")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'solve network analyst Closest Facility problem
        Label2.Text = "2. Solving for 'Closest Facility'..."
        System.Windows.Forms.Application.DoEvents()

        fcaNAsetClosestsolver(pNAContext1, configObj)
        Dim gpMessages1 As IGPMessages = New GPMessages
        Dim isPartial As Boolean
        Try
            isPartial = pNAContext1.Solver.Solve(pNAContext1, gpMessages1, Nothing)
            If isPartial Then
                lstOutput.Items.Add("Closest Facility  ...a partial solution was found.")
            Else
                lstOutput.Items.Add("Closest Facility  ...a FULL solution was found.")
            End If
        Catch ex As Exception
            lstOutput.Items.Add("")
            lstOutput.Items.Add("Network Analyst Error Message: ")
            lstOutput.Items.Add(ex.Message)
        End Try

        'display returned messages
        If Not gpMessages1 Is Nothing Then
            For i As Integer = 0 To gpMessages1.Count - 1
                Select Case gpMessages1.GetMessage(i).Type
                    Case esriGPMessageType.esriGPMessageTypeError
                        lstOutput.Items.Add("Error: " + gpMessages1.GetMessage(i).ErrorCode.ToString() + " " + gpMessages1.GetMessage(i).Description)
                    Case esriGPMessageType.esriGPMessageTypeWarning
                        lstOutput.Items.Add("Warning: " + gpMessages1.GetMessage(i).Description)
                    Case Else
                        lstOutput.Items.Add("Information: " + gpMessages1.GetMessage(i).Description)
                End Select
            Next
        End If


        '** OD solving **

        'set NAContext as a OD matrix solver
        pNAContext2 = fcaNAcreateODsolver(pNWdataset)

        Label2.Text = "3. Loading data for 'O-D matrix'..."
        System.Windows.Forms.Application.DoEvents()

        'create and configure Network Analyst layer
        pNALayer = pNAContext2.Solver.CreateLayer(pNAContext2)
        pLayer = pNALayer
        pLayer.Name = "uswFCA_" + pNAContext2.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1)

        'load Origins (Supply) from selected Feature Layer
        pLayer = pMap.Layer(configObj.SupplyLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'fill parameters for OD matrix tool, then add the points
        params.RemoveAll()
        params.Add(pNALayer)
        params.Add("Origins")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'load Destinations (Demand) from selected Feature Layer
        pLayer = pMap.Layer(configObj.DemandLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'refill parameters for OD matrix tool, then add the points
        params.RemoveAll()
        params.Add(pNALayer)
        params.Add("Destinations")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'solve network analyst OD Matrix problem
        Label2.Text = "4. Solving for 'OD matrix'"
        System.Windows.Forms.Application.DoEvents()

        fcaNAsetODsolver(pNAContext2, configObj)
        Dim gpMessages2 As IGPMessages = New GPMessages
        Try
            isPartial = pNAContext2.Solver.Solve(pNAContext2, gpMessages2, Nothing)
            If isPartial Then
                lstOutput.Items.Add("OD Matrix         ...a partial solution was found.")
            Else
                lstOutput.Items.Add("OD Matrix         ...a FULL solution was found.")
            End If
        Catch ex As Exception
            lstOutput.Items.Add("")
            lstOutput.Items.Add("Network Analyst error message: ")
            lstOutput.Items.Add(ex.Message)
        End Try

        'display returned messages
        If Not gpMessages2 Is Nothing Then
            For i As Integer = 0 To gpMessages2.Count - 1
                Select Case gpMessages2.GetMessage(i).Type
                    Case esriGPMessageType.esriGPMessageTypeError
                        lstOutput.Items.Add("Error: " + gpMessages2.GetMessage(i).ErrorCode.ToString() + " " + gpMessages2.GetMessage(i).Description)
                    Case esriGPMessageType.esriGPMessageTypeWarning
                        lstOutput.Items.Add("Warning: " + gpMessages2.GetMessage(i).Description)
                    Case Else
                        lstOutput.Items.Add("Information: " + gpMessages2.GetMessage(i).Description)
                End Select
            Next
        End If


        '** accessibility scores computation **

        Dim pDataset As IDataset = Nothing
        Dim pDSWS As IWorkspace2 = Nothing
        Dim pWSFactory As IWorkspaceFactory
        Dim pFWS As IFeatureWorkspace = Nothing
        Dim pFieldsEdit As IFieldsEdit = Nothing

        Try

            'track through layer -> feature layer -> feature class -> dataset -> dataset workspace
            inputFL = pMap.Layer(configObj.DemandLayerIndex)
            inputFC = inputFL.FeatureClass
            pDataset = inputFC
            pDSWS = pDataset.Workspace

            'create a shapefile workspace factory
            pWSFactory = New ShapefileWorkspaceFactory
            pFWS = pWSFactory.OpenFromFile(configObj.ResultsLocation, My.ArcMap.Application.hWnd)

            'create a Fields object
            pFieldsEdit = New Fields

            'create a Field for output table's OID
            Dim pOIDField As IFieldEdit = New Field
            With pOIDField
                .Name_2 = "OID"
                .Type_2 = esriFieldType.esriFieldTypeOID
                .Length_2 = 8
            End With
            'create other output table fields
            Dim pDemandField As IFieldEdit = New Field
            With pDemandField
                .Name_2 = "DemandID"
                .Type_2 = esriFieldType.esriFieldTypeInteger
                .Length_2 = 8
            End With
            Dim pSupplyField As IFieldEdit = New Field
            With pSupplyField
                .Name_2 = "SupplyID"
                .Type_2 = esriFieldType.esriFieldTypeInteger
                .Length_2 = 8
            End With
            Dim pNearMetric As IFieldEdit = New Field
            With pNearMetric
                .Name_2 = "SupplyDist"
                .Type_2 = esriFieldType.esriFieldTypeSingle
                .Length_2 = 14
                .DefaultValue_2 = 0.0
                .Precision_2 = 12
                .Scale_2 = 4
            End With
            Dim pChoiceMetric As IFieldEdit = New Field
            With pChoiceMetric
                .Name_2 = "Choices"
                .Type_2 = esriFieldType.esriFieldTypeSingle
                .Length_2 = 14
                .DefaultValue_2 = 0.0
                .Precision_2 = 12
                .Scale_2 = 0
            End With
            Dim pMeanMetric As IFieldEdit = New Field
            With pMeanMetric
                .Name_2 = "MeanCost"
                .Type_2 = esriFieldType.esriFieldTypeSingle
                .Length_2 = 14
                .DefaultValue_2 = 0.0
                .Precision_2 = 12
                .Scale_2 = 2
            End With
            Dim pFCAMetric As IFieldEdit = New Field
            With pFCAMetric
                .Name_2 = "E2SFCA"
                .Type_2 = esriFieldType.esriFieldTypeSingle
                .Length_2 = 14
                .DefaultValue_2 = 0.0
                .Precision_2 = 12
                .Scale_2 = 8
            End With
            'add all fields to the table
            With pFieldsEdit
                .AddField(pOIDField)
                .AddField(pDemandField)
                .AddField(pSupplyField)
                .AddField(pNearMetric)
                .AddField(pChoiceMetric)
                .AddField(pMeanMetric)
                .AddField(pFCAMetric)
            End With
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'create pointer to tables collection of current focus map
        'and further pointers for accessing tables in this collection
        Dim pTableCollection As ITableCollection = pMap
        Dim pOutputTable As ITable = Nothing
        Dim pCFtable As ITable = Nothing
        Dim pODLinesTable As ITable = Nothing

        'construct a suitable output table name... 
        Dim outputTable As String = ""
        Try
            Dim tName As String = pDataset.BrowseName
            tName = tName.Replace(" ", "")
            tName = tName.Substring(0, 8)
            Dim tmp As decayType = configObj.filter
            tName += "_" & tmp.ToString
            tName += "_" & configObj.NWdefCutOff.ToString
            'search for an unused output table filename
            Dim runNumber As Integer = 0
            outputTable = tName & "_" & runNumber.ToString & ".dbf"
            Do Until Not My.Computer.FileSystem.FileExists(configObj.ResultsLocation & "\" & outputTable)
                runNumber += 1
                outputTable = tName & "_" & runNumber.ToString & ".dbf"
            Loop
            'create table with chosen name and add to session
            pOutputTable = pFWS.CreateTable(outputTable, pFieldsEdit, Nothing, Nothing, "")
            pTableCollection.AddTable(pOutputTable)
            pMxDoc.UpdateContents()
        Catch ex As Exception
            lstOutput.Items.Add("Error: Unable to create the output table " & outputTable)
            Exit Sub
        End Try

        Label2.Text = "5. Computing results for 'Closest Facility'"
        System.Windows.Forms.Application.DoEvents()

        'access the Closest Facility results table
        pCFtable = pNAContext1.NAClasses.ItemByName("CFRoutes")
        If pCFtable Is Nothing Then
            lstOutput.Items.Add("Error: Unable to access Closest Facility 'Routes' table")
            Exit Sub
        End If

        'create objects to access records of Closest Facility table
        Dim pCF_QueryFilter As IQueryFilter = New QueryFilter
        Dim pCF_Cursor As ICursor = Nothing
        Dim pCF_Row As IRow
        Dim pOutputRow As IRow

        Dim nameStr, numbers() As String
        Dim fieldInc, fieldFac, fieldImp, fieldNam As Integer 'index of field Incident, Facility, Impedance and Name
        Dim impedanceField As String = "Total_" & configObj.NWimpedanceField

        Dim supplyIDs As New Dictionary(Of Integer, String)
        Dim distances As New Dictionary(Of Integer, Double)


        'create cursor to access all rows of Closest Facility table
        pCF_Cursor = pCFtable.Search(Nothing, True)
        pCF_Row = pCF_Cursor.NextRow

        'get index of IncidentID and FacilityID fields in Closest Facility table
        If Not pCF_Row Is Nothing Then
            fieldInc = pCF_Row.Fields.FindField("IncidentID")
            fieldFac = pCF_Row.Fields.FindField("FacilityID")
            fieldNam = pCF_Row.Fields.FindField("Name")
            fieldImp = pCF_Row.Fields.FindField(impedanceField)
        End If

        'to maintain data matching continuity...
        Do Until pCF_Row Is Nothing
            nameStr = pCF_Row.Value(fieldNam)     'access the Name field
            numbers = nameStr.Split("-")                 'split the two values reported here
            pCF_Row.Value(fieldInc) = numbers(0)   'swap IncidentID for the original Demand point OID
            pCF_Row.Value(fieldFac) = numbers(1)   'swap FacilityID for the original Supply point OID 
            pCF_Row.Store()

            supplyIDs.Add(numbers(0), numbers(1))  'add to dictionary DemandID and SupplyID
            distances.Add(numbers(0), pCF_Row.Value(fieldImp)) 'add to dictionary DemandID and distance

            pCF_Row = pCF_Cursor.NextRow
        Loop

        'create a list of all Demand Point OIDs
        Dim oidDPlist As New List(Of Integer) 'stores Demand point OIDs
        Dim demandID As Integer                    'individual demand ID value
        Dim toLoad As Integer                         'number of IDs to identify
        Try
            inputFL = pMap.Layer(configObj.DemandLayerIndex)
            If configObj.DemandSelected = True Then     'if selection to be used
                Dim tableSelection As ITableSelection = CType(inputFL, ITableSelection) 'explicit Cast
                Dim selectionSet As ISelectionSet2 = tableSelection.SelectionSet
                toLoad = selectionSet.Count
                Dim enumIDs As IEnumIDs = selectionSet.IDs
                demandID = enumIDs.Next
                Do While demandID > 0
                    oidDPlist.Add(demandID)
                    demandID = enumIDs.Next
                Loop
            Else                                                              'if a selection not used
                inputFC = inputFL.FeatureClass
                toLoad = inputFC.FeatureCount(Nothing)
                Dim featCursor As IFeatureCursor = inputFC.Search(Nothing, True)
                Dim feat As IFeature = featCursor.NextFeature()
                Do Until feat Is Nothing
                    oidDPlist.Add(feat.OID)
                    feat = featCursor.NextFeature()
                Loop
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featCursor)
            End If

            'work through each Demand point OID in turn
            For Each demandID In oidDPlist
                pOutputRow = pOutputTable.CreateRow   'create new row in output table
                pOutputRow.Value(1) = demandID             'record original demand point OID

                If supplyIDs.ContainsKey(demandID) Then
                    pOutputRow.Value(2) = supplyIDs.Item(demandID) 'record original supply point OID
                    pOutputRow.Value(3) = distances.Item(demandID)  'record shortest network distance
                Else
                    pOutputRow.Value(2) = -1                                         'default values if route not found
                    pOutputRow.Value(3) = -1
                End If

                pOutputRow.Store()                                 'write row to output table
            Next

            'release resources
            If Not pCF_Cursor Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pCF_Cursor)
            End If
            supplyIDs = Nothing
            distances = Nothing

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try


        ' ** FCA Step1 - compute demand totals at each Supply (Origin) point  **

        'access the OD matrix results table
        pODLinesTable = pNAContext2.NAClasses.ItemByName("ODLines")
        If pODLinesTable Is Nothing Then
            lstOutput.Items.Add("Error: Unable to access the OD Matrix 'Lines' table")
            Exit Sub
        End If

        Label2.Text = "6. Computing FCA results from 'OD matrix'"
        System.Windows.Forms.Application.DoEvents()

        'dictionary for Step 1 results (i.e. total service demand at each supply point)
        Dim demandTotals As New Dictionary(Of Integer, Double)

        Dim supplyID As Integer
        Dim demandValue, distance As Double

        Dim pDemand_QF As IQueryFilter = New QueryFilter  'create a query object 
        Dim pDemand_FC As IFeatureCursor = Nothing
        Dim pDemand_Feature As IFeature
        Dim pODcursor As ICursor = Nothing
        Dim pODrow As IRow = Nothing

        Try
            'create a pointer (inputFC) to the demand points Feature Class table,
            pLayer = pMap.Layer(configObj.DemandLayerIndex)
            inputFL = pLayer
            inputFC = inputFL.FeatureClass

            'cursor to access all rows in OD matrix table
            pODcursor = pODLinesTable.Search(Nothing, True)
            pODrow = pODcursor.NextRow
            If Not pODrow Is Nothing Then
                fieldNam = pODrow.Fields.FindField("Name")            'get index of Name field
                fieldImp = pODrow.Fields.FindField(impedanceField)  'get index of Impedance field
            End If

            Do Until pODrow Is Nothing

                'extract supply and demand OIDs, and network distance between these
                nameStr = pODrow.Value(fieldNam)
                numbers = nameStr.Split("-")
                supplyID = numbers(0)
                demandID = numbers(1)
                distance = pODrow.Value(fieldImp)

                'look up the corresponding Demand Volume value
                If (configObj.DemandVolumeField > 0) Then
                    pDemand_QF.WhereClause = inputFC.OIDFieldName & " = " & demandID
                    pDemand_FC = inputFC.Search(pDemand_QF, True)
                    pDemand_Feature = pDemand_FC.NextFeature
                    demandValue = pDemand_Feature.Value(configObj.DemandVolumeField)
                Else
                    demandValue = 1.0
                End If

                'scale demand value using chosen distance-decay function
                demandValue = dist_weighted(demandValue, distance, configObj)

                'check if this Supply point already exists in the dictionary
                If demandTotals.ContainsKey(supplyID) Then
                    'if YES: add current demand volume to on-going total
                    demandTotals.Item(supplyID) += demandValue
                Else
                    'if NO: add a new dictionay entry with this intial demand volume
                    demandTotals.Add(supplyID, demandValue)
                End If

                pODrow = pODcursor.NextRow()
            Loop

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'Dim f2 As New Form2
        'f2.Show()
        ''display demands on each supply point
        'Dim pair As KeyValuePair(Of Integer, Double)
        'For Each pair In demandTotals
        '    f2.TextBox1.AppendText(pair.Key.ToString + " , " + pair.Value.ToString + Environment.NewLine)
        'Next
      

        ' ** FCA Step2 - calculate availability scores at each demand point **

        'dictionary for Step 2 results (i.e. sum of Step1 scores at each demand point)
        Dim demandList As New Dictionary(Of Integer, destObj)
        Try
            'create a pointer (inputFC) to the supply points Feature Class table
            pLayer = pMap.Layer(configObj.SupplyLayerIndex)
            inputFL = pLayer
            inputFC = inputFL.FeatureClass

            Dim supplyValue, availabilityScore As Double

            'cursor to access all rows in OD matrix table
            pODcursor = pODLinesTable.Search(Nothing, True)
            pODrow = pODcursor.NextRow

            Do Until pODrow Is Nothing

                'extract supply and demand OID, and network distance between these
                nameStr = pODrow.Value(fieldNam)
                numbers = nameStr.Split("-")
                supplyID = numbers(0)
                demandID = numbers(1)
                distance = pODrow.Value(fieldImp)

                'look up corresponding Supply Volume value
                If (configObj.SupplyVolumeField > 0) Then
                    pDemand_QF.WhereClause = inputFC.OIDFieldName & " = " & supplyID
                    pDemand_FC = inputFC.Search(pDemand_QF, True)
                    pDemand_Feature = pDemand_FC.NextFeature
                    supplyValue = pDemand_Feature.Value(configObj.SupplyVolumeField) * configObj.NWscale
                Else
                    supplyValue = configObj.NWscale
                End If

                'compute availability score for this Supply point
                availabilityScore = supplyValue / demandTotals(supplyID)

                'scale the supply value using chosen distance-decay function
                availabilityScore = dist_weighted(availabilityScore, distance, configObj)

                'check if this Demand point already exists in the dictionary
                If demandList.ContainsKey(demandID) Then
                    'if YES; update information relating to this Origin
                    demandList.Item(demandID).count += 1                              'total number of Supply points
                    demandList.Item(demandID).sumdist += distance                 'total distance to Supply points
                    demandList.Item(demandID).twostep += availabilityScore     'total Step1 FCA score
                Else
                    'if NO: add new dictionary entry with this current object
                    Dim newObj As New destObj
                    newObj.count = 1
                    newObj.sumdist = distance
                    newObj.twostep = availabilityScore
                    demandList.Add(demandID, newObj)
                End If

                pODrow = pODcursor.NextRow()
            Loop

            'release resources
            If Not pODcursor Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pODcursor)
            End If
            If Not pDemand_FC Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pDemand_FC)
            End If

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'write accessibility metrics to output table
        Try
            For Each obj As KeyValuePair(Of Integer, destObj) In demandList
                pDemand_QF.WhereClause = "DemandID = " & obj.Key.ToString
                pODcursor = pOutputTable.Search(pDemand_QF, True)
                pODrow = pODcursor.NextRow
                pODrow.Value(4) = obj.Value.count
                pODrow.Value(5) = (obj.Value.sumdist / obj.Value.count)
                pODrow.Value(6) = obj.Value.twostep
                pODrow.Store()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Label2.Text = "FCA computation completed." & Environment.NewLine _
                          & "results stored in dbf file..." & Environment.NewLine _
                          & outputTable + Environment.NewLine

        System.Runtime.InteropServices.Marshal.ReleaseComObject(pOutputTable)
        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(1)
        chkTidyUp.Visible = True
        btnClose.Enabled = True

    End Sub

#End Region

#Region "remove the working layers"

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        If chkTidyUp.Checked Then
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap
            Dim pLayer As INALayer = Nothing
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
        End If

        Me.Dispose()

    End Sub

#End Region

End Class