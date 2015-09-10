Imports System.Windows.Forms
Imports ESRI.ArcGIS
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s1_frmIntroduction

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

        'display the next form
        Dim p_s2frmDemandDetails As New s2_frmSupplyDemand(configObj)
        p_s2frmDemandDetails.Location = Me.Location
        p_s2frmDemandDetails.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "display list of Cost fields in selected NW layer"

    Private Sub cboNWdataset_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)



    End Sub

    ''display Cost field's Units
    'Private Sub cboCostField_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    Dim str() As String = Split(m_costFieldUnits(cboCostField.SelectedIndex), "esriNAU")
    '    lblUnits.Text = str(1)
    'End Sub

#End Region

    Private Sub btnABOUT_Click(sender As System.Object, e As System.EventArgs) Handles btnAbout.Click
        Dim f As New frmAbout
        f.ShowDialog()
    End Sub

    Private Sub s1_frmIntroduction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim aoLicenseInitializer As LicenseInitializer
        aoLicenseInitializer = New LicenseInitializer

        'ESRI License Initializer generated code.
        If (Not aoLicenseInitializer.InitializeApplication(New esriLicenseProductCode() {esriLicenseProductCode.esriLicenseProductCodeEngine, esriLicenseProductCode.esriLicenseProductCodeBasic, esriLicenseProductCode.esriLicenseProductCodeStandard, esriLicenseProductCode.esriLicenseProductCodeAdvanced}, _
        New esriLicenseExtensionCode() {esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, esriLicenseExtensionCode.esriLicenseExtensionCodeAeronautical})) Then
            MessageBox.Show("This AddIn cannot be used as you do not have the required ArcGIS licenses: " + aoLicenseInitializer.LicenseMessage())
            'aoLicenseInitializer.ShutdownApplication()
            btn1Next.Enabled = False
            Return
        End If

    End Sub
End Class