Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geoprocessing
Imports ESRI.ArcGIS.NetworkAnalyst
Imports ESRI.ArcGIS.esriSystem

Public Class s4_frmRun

#Region "form controls"

    Private m_configObj As configParams
    Dim demandID As Object

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

#Region "globals"

    'Folder location for the results table
    Dim outpath As String

    'List of field names in the Demand points layer
    Dim m_FieldlistDem As List(Of layerItem)

#End Region

    Private Sub s5_frmResults_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            'If configuration file found with retained folder name, read and use
            If System.IO.File.Exists("swfca-save.txt") Then
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader("swfca-save.txt")
                outpath = sr.ReadLine()
                sr.Close()
                txtPath.Text = outpath

            Else    'otherwise set to My Documents folder
                txtPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
        Catch ex As Exception
            txtPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End Try

        cboScale.SelectedIndex = 3

    End Sub

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
        Dim f2 As frmActivityLog = Nothing

        btnExecute.Enabled = False
        btn4Prev.Enabled = False
        If chkShowlog.Checked Then
            f2 = New frmActivityLog
            f2.Show()
        End If

        If chkShowlog.Checked Then f2.txtLog.AppendText("Network Analyst messages:" & vbCrLf)
        Dim ScaleFactor As Double = Convert.ToDouble(cboScale.Text)

        'set the TOC to the "Contents View tab"
        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(0)

        'track from layer -> network layer -> network dataset
        pLayer = pMap.Layer(configObj.NWlayerindex)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset

        '** CF solving **
        Dim OIDname As String

        'set NAContext as a ClosestFacility solver
        pNAContext1 = fcaNAcreateClosestsolver(pNWdataset)

        Label1.Text = "loading data for closest facility analysis"
        Windows.Forms.Application.DoEvents()

        'create and configure the Network Analyst layer
        pNALayer = pNAContext1.Solver.CreateLayer(pNAContext1)
        pLayer = pNALayer
        pLayer.Name = "swFCA_" + pNAContext1.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1) 'move it to the bottom of the TOC

        'load up 'Facilities' (ie Supply) from the selected Feature layer
        pLayer = pMap.Layer(configObj.SupplyLayerIndex)
        inputFL = pLayer                                                       'track from ILayer -> IFeatureLayer
        inputFC = inputFL.FeatureClass                                  'track from IFeatureLayer -> IFeatureClass
        OIDname = inputFC.OIDFieldName                            'get the name of the OID field

        'create a Geoprocessor tool and a parameters arrray
        Dim gp As IGeoProcessor2 = New GeoProcessor
        Dim params As IVariantArray = New VarArrayClass

        'fill parameters for CF tool, then load the facilities (supply) points
        params.Add(pNALayer)
        params.Add("Facilities")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'load up 'Incidents' (ie Demand) from the selected Feature Layer
        pLayer = pMap.Layer(configObj.DemandLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'remove previous parameters
        params.RemoveAll()
        'fill parameters for CF tool, then load the incidents (demand) points
        params.Add(pNALayer)
        params.Add("Incidents")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'solve the network analyst Closest Facility problem
        Label1.Text = "solving closest facility analysis"
        Windows.Forms.Application.DoEvents()
        fcaNAsetClosestsolver(pNAContext1, configObj)

        Try

            Dim gpMessages1 As IGPMessages = New GPMessages
            Dim isPartial As Boolean = pNAContext1.Solver.Solve(pNAContext1, gpMessages1, Nothing)      'Solve CF !!

            If chkShowlog.Checked Then
                If isPartial Then
                    f2.txtLog.AppendText("Closest Facility  ...partial solution found" & vbCrLf)
                Else
                    f2.txtLog.AppendText("Closest Facility  ...full solution found" & vbCrLf)
                End If
                'display returned messages
                If Not gpMessages1 Is Nothing Then
                    For i As Integer = 0 To gpMessages1.Count - 1
                        Select Case gpMessages1.GetMessage(i).Type
                            Case esriGPMessageType.esriGPMessageTypeError
                                f2.txtLog.AppendText("Error: " & gpMessages1.GetMessage(i).ErrorCode.ToString() & " " & gpMessages1.GetMessage(i).Description & vbCrLf)
                            Case esriGPMessageType.esriGPMessageTypeWarning
                                f2.txtLog.AppendText("Warning: " + gpMessages1.GetMessage(i).Description & vbCrLf)
                            Case Else
                                f2.txtLog.AppendText("Information: " + gpMessages1.GetMessage(i).Description & vbCrLf)
                        End Select
                    Next
                End If
            End If

        Catch ex As Exception
            If chkShowlog.Checked Then f2.txtLog.AppendText(vbCrLf & "Network Analyst error message:" & vbCrLf & ex.Message & vbCrLf)
        End Try


        ''** OD solving **

        'set NAContext as a OD matrix solver
        pNAContext2 = fcaNAcreateODsolver(pNWdataset)

        Label1.Text = "loading data for OD matrix computation"
        Windows.Forms.Application.DoEvents()

        'create and configure the Network Analyst layer
        pNALayer = pNAContext2.Solver.CreateLayer(pNAContext2)
        pLayer = pNALayer
        pLayer.Name = "swFCA_" + pNAContext2.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1) 'move it to the bottom of the TOC

        'load the 'Origins' (ie Supply) from the selected Feature Layer
        pLayer = pMap.Layer(configObj.SupplyLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'remove previous parameters
        params.RemoveAll()
        'fill parameters for OD tool, then load the Origin (supply) points
        params.Add(pNALayer)
        params.Add("Origins")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'load the 'Destinations' (ie Demand) from the selected Feature Layer
        pLayer = pMap.Layer(configObj.DemandLayerIndex)
        inputFL = pLayer
        inputFC = inputFL.FeatureClass
        OIDname = inputFC.OIDFieldName

        'remove previous parameters
        params.RemoveAll()
        'fill parameters for OD tool, then load the Destination (demand) points
        params.Add(pNALayer)
        params.Add("Destinations")
        params.Add(inputFL)
        params.Add("SourceID SourceID #; SourceOID SourceOID #; PosAlong PosAlong #; SideOfEdge SideOfEdge #; Name " & OIDname & " #")
        gp.Execute("AddLocations_na", params, Nothing)

        'solve the network analyst OD Matrix problem
        Label1.Text = "solving OD matrix analysis"
        Windows.Forms.Application.DoEvents()
        fcaNAsetODsolver(pNAContext2, configObj)

        Try

            Dim gpMessages2 As IGPMessages = New GPMessages
            Dim isPartial As Boolean = pNAContext2.Solver.Solve(pNAContext2, gpMessages2, Nothing) 'Solve OD !!

            If chkShowlog.Checked Then
                If isPartial Then
                    f2.txtLog.AppendText("OD matrix         ...partial solution found" & vbCrLf)
                Else
                    f2.txtLog.AppendText("OD matrix         ...full solution  found" & vbCrLf)
                End If
                'display returned messages
                If Not gpMessages2 Is Nothing Then
                    For i As Integer = 0 To gpMessages2.Count - 1
                        Select Case gpMessages2.GetMessage(i).Type
                            Case esriGPMessageType.esriGPMessageTypeError
                                f2.txtLog.AppendText("Error: " & gpMessages2.GetMessage(i).ErrorCode.ToString() & " " & gpMessages2.GetMessage(i).Description & vbCrLf)
                            Case esriGPMessageType.esriGPMessageTypeWarning
                                f2.txtLog.AppendText("Warning: " & gpMessages2.GetMessage(i).Description & vbCrLf)
                            Case Else
                                f2.txtLog.AppendText("Information: " & gpMessages2.GetMessage(i).Description & vbCrLf)
                        End Select
                    Next
                End If
            End If

        Catch ex As Exception
            If chkShowlog.Checked Then f2.txtLog.AppendText(vbCrLf & "Network Analyst error message: " & vbCrLf & ex.Message & vbCrLf)
        End Try


        '** accessibility scores **

        Dim pDataset As IDataset = Nothing
        Dim pDisplayTable As IDisplayTable = Nothing
        Dim pTable As ITable = Nothing

        Dim pOldFields As IFields = Nothing
        Dim pOldField As IField = Nothing
        Dim pNewFields As IFields = Nothing
        Dim pNewField As IFieldEdit = Nothing

        'track from Demand Points layer -> to feature layer -> to feature class -> to dataset
        inputFL = pMap.Layer(configObj.DemandLayerIndex)
        inputFC = inputFL.FeatureClass
        pDataset = inputFC
        'cast to ITable from IFeatureClass
        pDisplayTable = inputFL
        pTable = pDisplayTable.DisplayTable

        'create a shapefile workspace factory in the user selected location
        Dim pWSFactory As IWorkspaceFactory = New ShapefileWorkspaceFactory
        Dim pFWS As IFeatureWorkspace = Nothing
        pFWS = pWSFactory.OpenFromFile(txtPath.Text, My.ArcMap.Application.hWnd)

        'create a pointer to the tables collection of the current focus map
        Dim pTableCollection As ITableCollection = pMap

        'create a pointer for the results table
        Dim pOutputTable As ITable = Nothing

        'construct the results table 
        Dim resultsTable As String = ""
        Try

            'find a name for the table
            If radSpecify.Checked Then
                resultsTable = txtFilename.Text & ".dbf"
            Else
                Dim runNum As Integer = 0                                    'used to create a unique version number
                Dim tmp As decayType = configObj.filter
                Dim tmpNm As String = pDataset.BrowseName        'sets the initial name to the Demand Layer name
                tmpNm = tmpNm.Replace(" ", "")                            'remove any spaces
                tmpNm = tmpNm.Substring(0, 8)                            'truncate to the first 8 characters
                tmpNm += "_" & tmp.ToString                                'add filter type (ie classic or linear)
                tmpNm += "_" & configObj.NWdefCutOff.ToString    'add threshold catchment size
                resultsTable = tmpNm & "_" & runNum.ToString & ".dbf"

                'check if filename is already present, if so increase the unique version number
                Do Until Not My.Computer.FileSystem.FileExists(txtPath.Text & "\" & resultsTable)
                    runNum += 1
                    resultsTable = tmpNm & "_" & runNum.ToString & ".dbf"
                Loop
            End If

            'create the fields for the table
            Dim pFieldsEdit As IFieldsEdit = New Fields
            pNewField = New Field
            pNewField.Name_2 = "OID"
            pNewField.Type_2 = esriFieldType.esriFieldTypeOID
            pNewField.Length_2 = 8
            pFieldsEdit.AddField(pNewField)

            'if requested, copy additional demand ID field
            If chkdemandID.Checked Then
                pOldField = inputFC.Fields.Field(cboDemandIDField.SelectedIndex)
                'copy field to results table
                pNewField = New Field
                pNewField.Name_2 = pOldField.Name
                pNewField.Type_2 = pOldField.Type
                pNewField.Length_2 = pOldField.Length
                pNewField.Scale_2 = pOldField.Scale
                pNewField.Precision_2 = pOldField.Precision
                pNewField.AliasName_2 = pOldField.AliasName
                pFieldsEdit.AddField(pNewField)
            End If

            'create other fields needed
            pNewField = New Field
            pNewField.Name_2 = "DemandID"
            pNewField.Type_2 = esriFieldType.esriFieldTypeInteger
            pNewField.Length_2 = 8
            pFieldsEdit.AddField(pNewField)

            pNewField = New Field
            pNewField.Name_2 = "SupplyID"
            pNewField.Type_2 = esriFieldType.esriFieldTypeInteger
            pNewField.Length_2 = 8
            pFieldsEdit.AddField(pNewField)

            pNewField = New Field
            pNewField.Name_2 = "NearDist"
            pNewField.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewField.Length_2 = 14
            pNewField.DefaultValue_2 = 0.0
            pNewField.Precision_2 = 12
            pNewField.Scale_2 = 4
            pFieldsEdit.AddField(pNewField)

            pNewField = New Field
            pNewField.Name_2 = "WithinDist"
            pNewField.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewField.Length_2 = 14
            pNewField.DefaultValue_2 = 0.0
            pNewField.Precision_2 = 12
            pNewField.Scale_2 = 0
            pFieldsEdit.AddField(pNewField)

            pNewField = New Field
            pNewField.Name_2 = "MeanDist"
            pNewField.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewField.Length_2 = 14
            pNewField.DefaultValue_2 = 0.0
            pNewField.Precision_2 = 12
            pNewField.Scale_2 = 2
            pFieldsEdit.AddField(pNewField)

            pNewField = New Field
            pNewField.Name_2 = "FCAscore"
            pNewField.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewField.Length_2 = 14
            pNewField.DefaultValue_2 = 0.0
            pNewField.Precision_2 = 12
            pNewField.Scale_2 = 8
            pFieldsEdit.AddField(pNewField)

            'create the results table and add it to the map
            pOutputTable = pFWS.CreateTable(resultsTable, pFieldsEdit, Nothing, Nothing, "")
            pTableCollection.AddTable(pOutputTable)
            pMxDoc.UpdateContents()

        Catch ex As Exception
            If chkShowlog.Checked Then
                f2.txtLog.AppendText("Error: Unable to create results table " & resultsTable & vbCrLf)
                f2.txtLog.AppendText(ex.Message)
            End If
            Exit Sub

        End Try


        Label1.Text = "computing closest facility metrics"
        Windows.Forms.Application.DoEvents()

        'connect to the CF results table
        Dim pCFtable As ITable = pNAContext1.NAClasses.ItemByName("CFRoutes")
        If pCFtable Is Nothing Then
            If chkShowlog.Checked Then f2.txtLog.AppendText("Error: Unable to access Closest Facility 'Routes' table" & vbCrLf)
            Exit Sub
        End If

        'objects to access records in the CF table
        Dim pCF_QueryFilter As IQueryFilter = New QueryFilter
        Dim pCF_Cursor As ICursor = Nothing
        Dim pCF_Row As IRow


        'stores the index position of the Incident, Facility, Impedance and Name fields
        Dim idxIncident, idxFacility, idxImpedance, idxName As Integer
        Dim impedanceField As String = "Total_" & configObj.NWimpedanceField
        'manipulates the Name field value
        Dim nameStr, numbers() As String

        'creates dictionaries for associated supplyIDs and network distances
        Dim supplyIDs As New Dictionary(Of Integer, String)
        Dim distances As New Dictionary(Of Integer, Double)

        'create a cursor that accesses all rows
        pCF_Cursor = pCFtable.Search(Nothing, True)
        pCF_Row = pCF_Cursor.NextRow

        'get the field positions of items of interest
        If Not pCF_Row Is Nothing Then
            idxIncident = pCF_Row.Fields.FindField("IncidentID")
            idxFacility = pCF_Row.Fields.FindField("FacilityID")
            idxName = pCF_Row.Fields.FindField("Name")
            idxImpedance = pCF_Row.Fields.FindField(impedanceField)
        End If

        'loop through each row of the CF table
        Do Until pCF_Row Is Nothing

            'swap the Incident ID and FacilityID values to maintain data matching continuity...
            nameStr = pCF_Row.Value(idxName)             'access the Name value
            numbers = nameStr.Split("-")                        'split the two IDs apart
            pCF_Row.Value(idxIncident) = numbers(0)    'replace IncidentID with original Demand point OID
            pCF_Row.Value(idxFacility) = numbers(1)      'replace FacilityID with original Supply point OID 
            pCF_Row.Store()                                          'write new values back to the table

            'put DemandID and SupplyID pair into dictionary
            supplyIDs.Add(numbers(0), numbers(1))

            'put DemandID and network distance pair into dictionary
            distances.Add(numbers(0), pCF_Row.Value(idxImpedance))

            pCF_Row = pCF_Cursor.NextRow
        Loop


        'pass through the Demand ID layer table and copy its IDs (and xtra ID) to the results table
        Dim featCursor As IFeatureCursor = inputFC.Search(Nothing, True)
        Dim feature As IFeature = featCursor.NextFeature()

        Dim pResultRow As IRowBuffer = pOutputTable.CreateRowBuffer
        Dim pResultIC As ICursor

        Try
            pResultIC = pOutputTable.Insert(True)

            If chkdemandID.Checked Then
                Do Until feature Is Nothing

                    pResultRow.Value(1) = feature.Value(cboDemandIDField.SelectedIndex)
                    pResultRow.Value(2) = feature.OID

                    If supplyIDs.ContainsKey(feature.OID) Then                   'was a supply point found during CF analysis?
                        pResultRow.Value(3) = supplyIDs.Item(feature.OID)   '    record original supply point OID
                        pResultRow.Value(4) = distances.Item(feature.OID)    '    record network distance
                    Else
                        pResultRow.Value(3) = -1                                         'otherwise store values to indicate no shortest route
                        pResultRow.Value(4) = -1
                    End If

                    pResultIC.InsertRow(pResultRow)
                    feature = featCursor.NextFeature()
                Loop
            Else
                Do Until feature Is Nothing

                    pResultRow.Value(1) = feature.OID

                    If supplyIDs.ContainsKey(feature.OID) Then                   'was a supply point found during CF analysis?
                        pResultRow.Value(2) = supplyIDs.Item(feature.OID)   '    record original supply point OID
                        pResultRow.Value(3) = distances.Item(feature.OID)    '    record network distance
                    Else
                        pResultRow.Value(2) = -1                                         'otherwise store values to indicate no shortest route
                        pResultRow.Value(3) = -1
                    End If

                    pResultIC.InsertRow(pResultRow)
                    feature = featCursor.NextFeature()
                Loop
            End If
            pResultIC.Flush()

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'release resources
        System.Runtime.InteropServices.Marshal.ReleaseComObject(featCursor)
        If Not pCF_Cursor Is Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pCF_Cursor)
        End If

        supplyIDs = Nothing
        distances = Nothing


        ' ** FCA Step1 - compute demand totals at each supply (Origin) point  **

        Label1.Text = "computing FCA scores - step 1"
        System.Windows.Forms.Application.DoEvents()

        'connect to the OD matrix results table
        Dim pODTable As ITable = pNAContext2.NAClasses.ItemByName("ODLines")
        If pODTable Is Nothing Then
            If chkShowlog.Checked Then f2.txtLog.AppendText("Error: Unable to access the OD Matrix 'Lines' table" & vbCrLf)
            Exit Sub
        End If

        'build dictionary for Step 1 (holding total demand volume on each supply point)
        Dim demandTotals As New Dictionary(Of Integer, Double)

        Dim supplyID As Integer
        Dim demandValue, distance As Double

        Dim pDemand_QF As IQueryFilter = New QueryFilter
        Dim pDemand_FC As IFeatureCursor = Nothing
        Dim pDemand_Feature As IFeature
        Dim pODcursor As ICursor = Nothing
        Dim pODrow As IRow = Nothing

        Try

            'create a pointer to the demand points attribute table (as ITable)
            inputFL = pMap.Layer(configObj.DemandLayerIndex)
            inputFC = inputFL.FeatureClass
            pDisplayTable = inputFL
            pTable = pDisplayTable.DisplayTable

            'set up a cursor to access all rows of the OD table
            pODcursor = pODTable.Search(Nothing, True)
            pODrow = pODcursor.NextRow
            If Not pODrow Is Nothing Then
                idxName = pODrow.Fields.FindField("Name")                       'index position of the Name field
                idxImpedance = pODrow.Fields.FindField(impedanceField)    'index position of the Impedance field
            End If

            'loop through each row of the OD table
            Do Until pODrow Is Nothing

                'extract the supply and demand OIDs, and the network distance between them
                nameStr = pODrow.Value(idxName)
                numbers = nameStr.Split("-")
                supplyID = numbers(0)
                demandID = numbers(1)
                distance = pODrow.Value(idxImpedance)

                'look up the demand point's Volume value
                pDemand_QF.WhereClause = inputFC.OIDFieldName & " = " & demandID
                pDemand_FC = pTable.Search(pDemand_QF, True)
                pDemand_Feature = pDemand_FC.NextFeature
                demandValue = pDemand_Feature.Value(configObj.DemandVolumeField)

                'scale demand value using distance-decay model
                demandValue = dist_weighted(demandValue, distance, configObj)

                'check if this Supply point exists in the dictionary
                If demandTotals.ContainsKey(supplyID) Then
                    'YES: add current demand volume to on-going total
                    demandTotals.Item(supplyID) += demandValue
                Else
                    'NO: add new dictionay entry with intial volume
                    demandTotals.Add(supplyID, demandValue)
                End If

                pODrow = pODcursor.NextRow()
            Loop

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'Dim pair As KeyValuePair(Of Integer, Double)
        'For Each pair In demandTotals
        '     Display Key and Value.
        '    f2.txtLog.AppendText(pair.Key & " -- " & pair.Value & vbCrLf)
        'Next


        ' ** FCA Step2 - calculate availability scores at each demand (Destination) point **
        Label1.Text = "computing FCA scores - step 2"
        System.Windows.Forms.Application.DoEvents()

        'build dictionary for Step 2 (holding total step-1 scores at each demand point)
        Dim demandList As New Dictionary(Of Integer, destObj)
        Dim supplyValue, availabilityScore As Double

        Try

            'create a pointer to the supply points attribute table (as ITable)
            inputFL = pMap.Layer(configObj.SupplyLayerIndex)
            inputFC = inputFL.FeatureClass
            pDisplayTable = inputFL
            pTable = pDisplayTable.DisplayTable

            'set up a cursor to access all rows of the OD table
            pODcursor = pODTable.Search(Nothing, True)
            pODrow = pODcursor.NextRow
            Do Until pODrow Is Nothing

                'extract the supply and demand OIDs, and the network distance between them
                nameStr = pODrow.Value(idxName)
                numbers = nameStr.Split("-")
                supplyID = numbers(0)
                demandID = numbers(1)
                distance = pODrow.Value(idxImpedance)

                'look up the supply point's Volume value
                pDemand_QF.WhereClause = inputFC.OIDFieldName & " = " & supplyID
                pDemand_FC = inputFC.Search(pDemand_QF, True)
                pDemand_Feature = pDemand_FC.NextFeature
                supplyValue = pDemand_Feature.Value(configObj.SupplyVolumeField) * ScaleFactor

                'compute availability score for this Supply point
                availabilityScore = supplyValue / demandTotals(supplyID)
                availabilityScore = dist_weighted(availabilityScore, distance, configObj)

                'check if this Demand point already exists in the dictionary
                If demandList.ContainsKey(demandID) Then
                    'YES: update information for this Demand
                    demandList.Item(demandID).count += 1                              'total Supply points
                    demandList.Item(demandID).sumdist += distance                 'total Distance to Supply points
                    demandList.Item(demandID).twostep += availabilityScore      'total Step1 FCA score
                Else
                    'NO: add a new dictionary entry using current object
                    Dim newObj As New destObj
                    newObj.count = 1
                    newObj.sumdist = distance
                    newObj.twostep = availabilityScore
                    demandList.Add(demandID, newObj)
                End If

                pODrow = pODcursor.NextRow()
            Loop

            'Dim pair2 As KeyValuePair(Of Integer, destObj)
            'Dim newObj2 As New destObj
            'For Each pair2 In demandList
            '    ' Display Key and Value.
            '    newObj2 = pair2.Value
            '    f2.txtLog.AppendText(pair2.Key & " -- " & newObj2.twostep.ToString & vbCrLf)
            'Next

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


        'record accessibility metrics in results table
        Label1.Text = "writing results to output table"
        System.Windows.Forms.Application.DoEvents()

        Try

            If chkdemandID.Checked Then

                'Create an update cursor on the results table

                Dim pOutputCursor As ICursor = pOutputTable.Update(Nothing, True)
                Dim pOT_Row As IRow = pOutputCursor.NextRow()

                'loop through each row and update field values
                Dim demandID As Integer
                pOT_Row = pOutputCursor.NextRow()
                Do Until pOT_Row Is Nothing
                    demandID = pOT_Row.Value(1)
                    If demandList.ContainsKey(demandID) Then
                        pOT_Row.Value(5) = demandList.Item(demandID).count
                        pOT_Row.Value(6) = demandList.Item(demandID).sumdist / demandList.Item(demandID).count
                        pOT_Row.Value(7) = demandList.Item(demandID).twostep
                    End If
                    pOutputCursor.UpdateRow(pOT_Row)
                    pOT_Row = pOutputCursor.NextRow()
                Loop

            Else

                'Create an update cursor on the results table

                Dim pOutputCursor As ICursor = pOutputTable.Update(Nothing, True)
                Dim pOT_Row As IRow = pOutputCursor.NextRow()

                'loop through each row and update field values
                Dim demandID As Integer
                pOT_Row = pOutputCursor.NextRow()
                Do Until pOT_Row Is Nothing
                    demandID = pOT_Row.Value(1)
                    If demandList.ContainsKey(demandID) Then
                        pOT_Row.Value(4) = demandList.Item(demandID).count
                        pOT_Row.Value(5) = demandList.Item(demandID).sumdist / demandList.Item(demandID).count
                        pOT_Row.Value(6) = demandList.Item(demandID).twostep
                    End If
                    pOutputCursor.UpdateRow(pOT_Row)
                    pOT_Row = pOutputCursor.NextRow()
                Loop

                'For Each obj As KeyValuePair(Of Integer, destObj) In demandList
                '    pDemand_QF.WhereClause = "DemandID = " & obj.Key.ToString
                '    pODcursor = pOutputTable.Search(pDemand_QF, False)
                '    pODrow = pODcursor.NextRow
                '    pODrow.Value(4) = obj.Value.count
                '    pODrow.Value(5) = (obj.Value.sumdist / obj.Value.count)
                '    pODrow.Value(6) = obj.Value.twostep
                '    pODrow.Store()
                'Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Windows.Forms.MessageBox.Show("Computation completed." & vbCrLf & "Results recorded in dbf file..." & vbCrLf & resultsTable, _
                                             "Complete", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)

        System.Runtime.InteropServices.Marshal.ReleaseComObject(pOutputTable)
        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(1)

        If Not chkKeepNAworkings.Checked Then
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
        End If

        Try
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("swfca-save.txt")
            sw.Write(txtPath.Text)
            sw.Close()
        Catch
            'txtPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End Try

    End Sub

#End Region

    Private Sub txtPath_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtPath.DoubleClick
        'select path for output table using FolderBrowser dialog
        FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            outpath = txtPath.Text
        End If
    End Sub

    Private Sub btn4Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn4Prev.Click

        Try
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("swfca-save.txt")
            sw.Write(txtPath.Text)
            sw.Close()
        Catch ex As Exception
            'txtPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        End Try

        'display previous form
        Dim p_s3frmFCASettings As New s3_frmFCASettings(configObj)
        p_s3frmFCASettings.Location = Me.Location
        p_s3frmFCASettings.Show()
        Me.Dispose()

    End Sub

    Private Sub chkdemandID_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkdemandID.CheckedChanged

        If chkdemandID.Checked Then

            'get a list of all field names in the Demand point layer
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap
            Dim layer_item As layerItem
            layer_item.position = configObj.DemandLayerIndex
            m_FieldlistDem = fcaUtilities.getDatafields3(layer_item.position)
            If m_FieldlistDem.Count > 0 Then
                'populate the selection dropdown with this list
                cboDemandIDField.Items.Clear()
                For Each field_item As layerItem In m_FieldlistDem
                    cboDemandIDField.Items.Add(field_item.title)
                Next
                'set the field selection to the first item in the list
                cboDemandIDField.SelectedIndex = 0
            End If
        Else
            cboDemandIDField.Items.Clear()
            cboDemandIDField.ResetText()
            cboDemandIDField.SelectedIndex = -1
        End If
    End Sub

    Private Sub radFilename(sender As System.Object, e As System.EventArgs) Handles radSpecify.CheckedChanged, radAuto.CheckedChanged
        If radSpecify.Checked Then
            txtFilename.Enabled = True
            radSpecify.ForeColor = Drawing.Color.FromArgb(0, 0, 0)
            radAuto.ForeColor = Drawing.Color.FromArgb(100, 100, 100)
        Else
            txtFilename.Enabled = False
            radSpecify.ForeColor = Drawing.Color.FromArgb(100, 100, 100)
            radAuto.ForeColor = Drawing.Color.FromArgb(0, 0, 0)
        End If
    End Sub

End Class