Imports System.Windows.Forms
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

End Class